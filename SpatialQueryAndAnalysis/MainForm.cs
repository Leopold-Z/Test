using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using SpatialQueryAndAnalysis.空间查询与空间分析;
using SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst;

namespace SpatialQueryAndAnalysis
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        IMapDocument m_MapDocument = new MapDocumentClass();


        //布局视图
        private IPageLayoutControl3 m_pageLayoutControl = null;
        


        IToolbarMenu m_TocLayerMenu = new ToolbarMenuClass();
        IToolbarMenu m_TocMapMenu = new ToolbarMenuClass();
        IToolbarMenu m_toolbarMenu=new ToolbarMenuClass ();
        IToolbarMenu m_toolbarMenu2 = new ToolbarMenuClass();
      //  IToolbarPalette m_ToolbarPalette = new ToolbarPaletteClass();

        
        // Reference to NAWindow.  Need to hold on to reference for events to work.
   

        ICustomizeDialog m_CustomizeDialog = new CustomizeDialogClass();
        ICustomizeDialogEvents_OnStartDialogEventHandler startDialogE;
        ICustomizeDialogEvents_OnCloseDialogEventHandler closeDialogE;

        // Listen for context menu on NAWindow
        private IEngineNAWindowEventsEx_OnContextMenuEventHandler m_onContextMenu;

        // Reference to Network Analyst Environment
        private IEngineNetworkAnalystEnvironment m_naEnv;

        // Reference to NAWindow.  Need to hold on to reference for events to work.
        private IEngineNAWindow m_naWindow;

        // Menu for our commands on the TOC context menu
        private IToolbarMenu m_menuLayer;

        // incrementor for auto generated names
        private static int autogenInt = 0;
       
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {           
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            m_pageLayoutControl = (IPageLayoutControl3)axPageLayoutControl1.Object;        
            
            menuSaveDoc.Enabled = false;            

            basicToolbarControl.AddItem(new CreateNewDocument(), 0, 0, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //TOCControl图层右键菜单
            m_TocLayerMenu.AddItem(new OpenAttributeTableCmd(), 0, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.AddItem(new RemoveLayerCmd(), 0, 1, false, esriCommandStyles.esriCommandStyleIconAndText);

            m_TocLayerMenu.AddItem(new ScaleThreSholds(), 1, 2, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new ScaleThreSholds(), 2, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new ScaleThreSholds(), 3, 4, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new LayerSelectable(), 1, 5, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new LayerSelectable(), 2, 6, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new ZoomToLayerCmd(), 0, 7, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.AddItem(new LayerPropertiesCmd(), 0, 8, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.SetHook(axMapControl1);

            //TOCControlMap右键菜单
            m_TocMapMenu.AddItem(new ControlsAddDataCommandClass(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new TurnAllLayersOnCmd(), 0, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new TurnAllLayersOffCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new SetReferenceScaleCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new ClearReferenceScaleCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new ZoomToReferenceScaleCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.SetHook(axMapControl1);

            //axMapControl控件中右键菜单           
            m_toolbarMenu .AddItem (new ClearCurrentTool (),0,-1,false , esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu.AddItem(new ClearFeatureSelection(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu.AddItem(new ZoomIn3X(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu.AddItem(new Refresh(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            // m_toolbarMenu.AddItem("esriControls.ControlsEditingSketchContextMenu", 0, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_toolbarMenu.SetHook(axMapControl1);

            //axPageLayoutControl右键菜单
            m_toolbarMenu2.AddItem(new ClearCurrentTool(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu2.SetHook(m_pageLayoutControl);

            CreateCustomizeDialog();

            SetupNetworkAnalysis();            
        }

        private void SetupNetworkAnalysis()
        {
            // Add commands to the NALayer context menu
            m_menuLayer = new ToolbarMenuClass();

            int nItem = -1;
            m_menuLayer.AddItem(new cmdLoadLocations(), -1, ++nItem, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new cmdRemoveLayer(), -1, ++nItem, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new cmdClearAnalysisLayer(), -1, ++nItem, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new cmdNALayerProperties(), -1, ++nItem, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.SetHook(axMapControl1);

            // Add command for Network Analyst env properties to end of "Network Analyst" dropdown menu
            nItem = -1;
            for (int i = 0; i < NAToolbarControl.Count; ++i)
            {
                IToolbarItem item = NAToolbarControl.GetItem(i);
                IToolbarMenu mnu = item.Menu;

                if (mnu == null)
                    continue;

                IMenuDef mnudef = mnu.GetMenuDef();
                string name = mnudef.Name;
                if (name == "ControlToolsNetworkAnalyst_SolverMenu")
                {
                    nItem = i;
                    break;
                }
            }

            if (nItem >= 0)
            {
                IToolbarItem item = NAToolbarControl.GetItem(nItem);
                IToolbarMenu mnu = item.Menu;
                if (mnu != null)
                    mnu.AddItem(new cmdNAProperties(), -1, mnu.Count, true, esriCommandStyles.esriCommandStyleTextOnly);
            }

            // Initialize naEnv variables
            m_naEnv = new EngineNetworkAnalystEnvironmentClass();
            m_naEnv.ZoomToResultAfterSolve = false;
            m_naEnv.ShowAnalysisMessagesAfterSolve = (int)(esriEngineNAMessageType.esriEngineNAMessageTypeInformative | esriEngineNAMessageType.esriEngineNAMessageTypeWarning);

            // Explicitly setup buddy control and initialize NA extension 
            // so we can get to NAWindow to listen to window events
            // This is necessary the various controls are not yet setup and they
            // need to be in order to get the NAWindow's events.
            NAToolbarControl.SetBuddyControl(axMapControl1);
            IExtension ext = m_naEnv as IExtension;
            object obj = NAToolbarControl.Object;
            ext.Startup(ref obj);
            m_naWindow = m_naEnv.NAWindow;
            m_onContextMenu = new IEngineNAWindowEventsEx_OnContextMenuEventHandler(OnContextMenu);
            ((IEngineNAWindowEventsEx_Event)m_naWindow).OnContextMenu += m_onContextMenu;
        }       

        private void CreateCustomizeDialog()
        {
            // Set the customize dialog box events.
            ICustomizeDialogEvents_Event pCustomizeDialogEvent = m_CustomizeDialog as ICustomizeDialogEvents_Event;
            startDialogE = new ICustomizeDialogEvents_OnStartDialogEventHandler(OnStartDialogHandler);
            pCustomizeDialogEvent.OnStartDialog += startDialogE;
            closeDialogE = new ICustomizeDialogEvents_OnCloseDialogEventHandler(OnCloseDialogHandler);
            pCustomizeDialogEvent.OnCloseDialog += closeDialogE;
            // Set the title.
            m_CustomizeDialog.DialogTitle = "定制工具条";
            // Set the ToolbarControl that new items will be added to.
            m_CustomizeDialog.SetDoubleClickDestination(basicToolbarControl);
        }
        private void OnStartDialogHandler()
        {
            basicToolbarControl.Customize = true;
           
        }
        private void OnCloseDialogHandler()
        {     
            basicToolbarControl.Customize = false;   
            chkCustomize.Checked = false;
        }
        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
  
        }
        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            ////execute Open Document command
            //ICommand command = new ControlsOpenDocCommandClass();
            //command.OnCreate(m_mapControl.Object);
            //command.OnClick();
      
            System.Windows.Forms.OpenFileDialog openFileDialog2;
            openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "Open Map Document";
            openFileDialog2.Filter = "Map Documents (*.mxd)|*.mxd";
            openFileDialog2.ShowDialog();      
            string sFilePath = openFileDialog2.FileName;
            if (axMapControl1.CheckMxFile(sFilePath))
            { axMapControl1.LoadMxFile(sFilePath, 0, Type.Missing); }
            else
            {
                MessageBox.Show(sFilePath + " is not a valid ArcMap document");
                return;
            }
        }
        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            if (m_MapDocument.get_IsReadOnly(m_MapDocument.DocumentFilename))
            {
                MessageBox.Show("This map document is read only!");
                return;
            }
            m_MapDocument.Save(m_MapDocument.UsesRelativePaths, true);
            MessageBox.Show("Changes saved successfully!");
            ////execute Save Document command
            //if (m_mapControl.CheckMxFile(m_mapDocumentName))
            //{
            //    //create a new instance of a MapDocument
            //    IMapDocument mapDoc = new MapDocumentClass();
            //    mapDoc.Open(m_mapDocumentName, string.Empty);

            //    //Make sure that the MapDocument is not readonly
            //    if (mapDoc.get_IsReadOnly(m_mapDocumentName))
            //    {
            //        MessageBox.Show("Map document is read only!");
            //        mapDoc.Close();
            //        return;
            //    }

            //    //Replace its contents with the current map
            //    mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

            //    //save the MapDocument in order to persist it
            //    mapDoc.Save(mapDoc.UsesRelativePaths, false);

            //    //close the MapDocument
            //    mapDoc.Close();
           
        }
        
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }
        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //CopyAndOverwriteMap();
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
                axPageLayoutControl1.LoadMxFile(m_mapDocumentName);       
                axPageLayoutControl1.Refresh();
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }
     
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {         
          if (e.button == 2)
            {
                if (e.button == 2) m_toolbarMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);
            }
        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            //IActiveView pActiveView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
            //IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
            //displayTransformation.VisibleBounds = axMapControl1.Extent;
            //axPageLayoutControl1.ActiveView.Refresh();
         //   CopyAndOverwriteMap();
        }

        private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            axTOCControl1.Update();
            //CopyAndOverwriteMap();
        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {

            }
            if (e.button == 2)
            {
                //Open the palette.
              //  m_ToolbarPalette.PopupPalette(e.x, e.y, axPageLayoutControl1.hWnd);
                m_toolbarMenu2.PopupMenu(e.x, e.y, axPageLayoutControl1.hWnd);
              
            }
            }


        //private void CopyAndOverwriteMap()
        //{
        //    IObjectCopy pObjectCopy = new ObjectCopyClass();
        //    //map to copy
        //    object toCopyMap = axMapControl1.Map;
        //    //copied map
        //    object copiedMap = pObjectCopy.Copy(toCopyMap);
        //    //map to overwrite
        //    object toOverwriteMap = axPageLayoutControl1.ActiveView.FocusMap;
        //    //overwrite the pagelayoutcontrol's map
        //    pObjectCopy.Overwrite(copiedMap, ref toOverwriteMap);
        //}

        public IColor getRGB(int yourRed, int yourGreen, int yourBlue)
        {
            IRgbColor pRGB = new RgbColorClass();
            pRGB.Red = yourRed;
            pRGB.Green = yourGreen;
            pRGB.Blue = yourBlue;
            pRGB.UseWindowsDithering = true;
            return pRGB;
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            ILayer layer = new FeatureLayerClass();
            object other = new object();
            object index = new object();
            esriTOCControlItem item = new esriTOCControlItem();

            //Determine what kind of item has been clicked on
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            if (e.button == 1)
            {
                //QI to IFeatureLayer and IGeoFeatuerLayer interface
                if (layer == null) return;
                IFeatureLayer featureLayer = layer as IFeatureLayer;
                if (featureLayer == null) return;
                IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)featureLayer;

                ILegendClass legendClass = new LegendClassClass();
                ISymbol symbol = null;
                if (other is ILegendGroup && (int)index != -1)
                {
                    legendClass = ((ILegendGroup)other).get_Class((int)index);
                    symbol = legendClass.Symbol;
                }
                if (symbol == null) return;

                symbol = GetSymbolByControl(symbol);
                //symbol = GetSymbolBySymbolSelector(symbol);
                if (symbol == null) return;
                legendClass.Symbol = symbol;
                this.Activate();
                //Fire contents changed event that the TOCControl listens to
                axMapControl1.ActiveView.ContentsChanged();
                //Refresh the display
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                axTOCControl1.Update();
            }
            if (e.button == 2)
            {
                if (item == esriTOCControlItem.esriTOCControlItemMap)
                {
                    m_mapControl.CustomProperty = map;
                    m_TocMapMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                }
                else if (layer is IFeatureLayer)
                {
                    m_mapControl.CustomProperty = layer;
                    m_TocLayerMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                }
                else if (layer is INALayer)
                {
                    m_mapControl.CustomProperty = layer;

                    if (item == esriTOCControlItem.esriTOCControlItemLayer)
                    {
                        m_menuLayer.PopupMenu(e.x, e.y, axMapControl1.hWnd);
                        ITOCControl toc = axTOCControl1.Object as ITOCControl;
                        toc.Update();
                    }
                }
            }
        }

        public bool OnContextMenu(int x, int y)
        {
            System.Drawing.Point pt = this.PointToClient(System.Windows.Forms.Cursor.Position);

            //Get the active category
            IEngineNAWindowCategory2 activeCategory = m_naWindow.ActiveCategory as IEngineNAWindowCategory2;
            if (activeCategory == null)
                return false;


            miLoadLocations.Enabled = false;
            miClearLocations.Enabled = false;

            // in order for the AddItem choice to appear in the context menu, the class
            // should be an input class, and it should not be editable
            INAClassDefinition pNAClassDefinition = activeCategory.NAClass.ClassDefinition;
            if (pNAClassDefinition.IsInput)
            {

                miLoadLocations.Enabled = true;
                miClearLocations.Enabled = true;

                // canEditShape should be false for AddItem to Apply (default is false)
                // if it's a StandaloneTable canEditShape is implicitly false (there's no shape to edit)
                bool canEditShape = false;
                IFields pFields = pNAClassDefinition.Fields;
                int nField = -1;
                nField = pFields.FindField("Shape");
                if (nField >= 0)
                {
                    int naFieldType = 0;
                    naFieldType = pNAClassDefinition.get_FieldType("Shape");

                    // determining whether or not the shape field can be edited consists of running a bitwise comparison
                    // on the FieldType of the shape field.  See the online help for a list of the possible field types.
                    // For our case, we want to verify that the shape field is an input field.  If it is an input field, 
                    // then we do NOT want to display the Add Item menu option.
                    canEditShape = ((naFieldType & (int)esriNAFieldType.esriNAFieldTypeInput) == (int)esriNAFieldType.esriNAFieldTypeInput) ? true : false;
                }

                if (!canEditShape)
                {
                    contextMenu1.Items.Add(miAddItem);
         
                }
            }

            contextMenu1.Show(this, pt);

            // even if the miAddItem menu item has not been added, Remove() won't crash.
            contextMenu1.Items.Remove(miAddItem);

            return true;
        }

        private ISymbol GetSymbolByControl(ISymbol symbolType)
        {
            ISymbol symbol = null;
            IStyleGalleryItem styleGalleryItem = null;
            esriSymbologyStyleClass styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            if (symbolType is IMarkerSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            }
            if (symbolType is ILineSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
            }
            if (symbolType is IFillSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
            } 
            GetSymbol symbolForm = new GetSymbol(styleClass);
            symbolForm.ShowDialog();
            styleGalleryItem = symbolForm.m_styleGalleryItem;
            if (styleGalleryItem == null) return null;
            symbol = styleGalleryItem.Item as ISymbol;
            symbolForm.Dispose();
            this.Activate();
            return symbol;
        }

        private void chkCustomize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomize.Checked == false)
            {
                m_CustomizeDialog.CloseDialog();
            }
            else
            {
                m_CustomizeDialog.StartDialog(basicToolbarControl.hWnd);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) //map view
            {
                basicToolbarControl.SetBuddyControl(axMapControl1);
                //activate the MapControl and deactivate the PageLayoutControl
               
            }
            else //layout view
            {
                //activate the PageLayoutControl and deactivate the MapControl
                basicToolbarControl.SetBuddyControl(axPageLayoutControl1);
            }
        }

        private void axPageLayoutControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0} {1} {2}", e.pageX.ToString("###.##"), e.pageY.ToString("###.##"), axPageLayoutControl1.Page.Units.ToString().Substring(4));
        }
   
        private void 删除所选择的要素ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ICommand tool = new 空间查询与空间分析.DeleteFeature();
            tool.OnCreate(axMapControl1.Object);
            m_mapControl.CurrentTool = tool as ITool;
        }
    
        private void 新建一个虚要素类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHookHelper helper = new HookHelperClass();
            helper.Hook = axMapControl1.Object;
            空间查询与空间分析.QueryDef实例 form = new QueryDef实例(helper);
            form.Show(this as System.Windows.Forms.IWin32Window);
        }

        private void 根据排序结果来选择要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHookHelper helper = new HookHelperClass();
            helper.Hook = axMapControl1.Object;
            空间查询与空间分析.TableSort实例 form = new TableSort实例(helper);
            form.Show(this as System.Windows.Forms.IWin32Window);
        }

        private void 属性条件查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new SpatialQueryAndAnalysis.空间查询与空间分析.AttributeQueryCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 基于空间位置空间关系的查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new SpatialQueryAndAnalysis.空间查询与空间分析.SpatialExtentQueryCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 缓冲区查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new SpatialQueryAndAnalysis.空间查询与空间分析.BufferQueryCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 邻接多边形查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new SpatialQueryAndAnalysis.空间查询与空间分析.SelectAdjacentFeaturesCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 多边形挖空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand tool = new 空间查询与空间分析.PolygonsDifference();
            tool.OnCreate(axMapControl1.Object);
            m_mapControl.CurrentTool = tool as ITool;

        }

        private void 计算两点间距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand tool = new 空间查询与空间分析.Distance2Points ();
            tool.OnCreate(axMapControl1.Object);
            m_mapControl.CurrentTool = tool as ITool;
        }

        private void 分割提取要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 裁剪要素类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHookHelper helper = new HookHelperClass();
            helper.Hook = axMapControl1.Object;
            空间查询与空间分析.GPClip form = new GPClip (helper);
            form.Show(this as System.Windows.Forms.IWin32Window);
        }

        private void 缓冲区分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new SpatialQueryAndAnalysis.空间查询与空间分析.BufferAnalysisCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 空间叠置分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new SpatialQueryAndAnalysis.空间查询与空间分析.OverlayAnalysisCmd();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void 网络分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NAToolbarControl.Visible == false)
                NAToolbarControl.Visible = true;
            else
                NAToolbarControl.Visible = false;
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMapControl3 mapControl = (IMapControl3)axMapControl1.Object;

            IEngineNAWindowCategory2 activeCategory = m_naWindow.ActiveCategory as IEngineNAWindowCategory2;
            IDataLayer pDataLayer = activeCategory.DataLayer;

            // In order to add an item, we need to create a new row in the class and populate it 
            // with the initial default values for that class.
            ITable table = pDataLayer as ITable;
            IRow row = table.CreateRow();
            IRowSubtypes rowSubtypes = row as IRowSubtypes;
            rowSubtypes.InitDefaultValues();

            IFeatureLayer ipFeatureLayer = activeCategory.Layer as IFeatureLayer;
            IStandaloneTable ipStandaloneTable = pDataLayer as IStandaloneTable;
            string name = "";
            if (ipFeatureLayer != null)
                name = ipFeatureLayer.DisplayField;
            else if (ipStandaloneTable != null)
                name = ipStandaloneTable.DisplayField;

            string currentName = "";
            int fieldIndex = row.Fields.FindField(name);
            if (fieldIndex >= 0)
            {
                currentName = row.get_Value(fieldIndex) as string;
                if (currentName.Length <= 0)
                    row.set_Value(fieldIndex, "Item" + ++autogenInt);
            }

            INAClassDefinition naClassDef = activeCategory.NAClass.ClassDefinition;
            if (naClassDef.Name == "OrderPairs")
            {
                fieldIndex = row.Fields.FindField("SecondOrderName");
                if (fieldIndex >= 0)
                {
                    string secondName = row.get_Value(fieldIndex) as string;
                    if (secondName.Length <= 0)
                        row.set_Value(fieldIndex, "Item" + ++autogenInt);
                }
            }

            row.Store();

            // notify that the context has changed because we have added an item to a NAClass within it
            INAContextEdit contextEdit = m_naEnv.NAWindow.ActiveAnalysis.Context as INAContextEdit;
            contextEdit.ContextChanged();

            // refresh the NAWindow and the Screen
            INALayer naLayer = m_naWindow.ActiveAnalysis;
            mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, mapControl.Extent);
            m_naWindow.UpdateContent(m_naWindow.ActiveCategory);
        }

        private void clearLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMapControl3 mapControl = (IMapControl3)axMapControl1.Object;
            IEngineNetworkAnalystHelper naHelper = m_naEnv as IEngineNetworkAnalystHelper;
            IEngineNAWindow naWindow = m_naWindow;
            INALayer naLayer = naWindow.ActiveAnalysis;
            naHelper.DeleteAllNetworkLocations();
            mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, mapControl.Extent);
        }

        private void loadLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMapControl3 mapControl = (IMapControl3)axMapControl1.Object;

            // Show the Property Page form for Network Analyst
            frmLoadLocation loadLocations = new frmLoadLocation();
            if (loadLocations.ShowModal(mapControl, m_naEnv))
            {
                // notify that the context has changed because we have added locations to a NAClass within it
                INAContextEdit contextEdit = m_naEnv.NAWindow.ActiveAnalysis.Context as INAContextEdit;
                contextEdit.ContextChanged();

                // If loaded locations, refresh the NAWindow and the Screen
                INALayer naLayer = m_naWindow.ActiveAnalysis;
                mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, mapControl.Extent);
                m_naWindow.UpdateContent(m_naWindow.ActiveCategory);
            }
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + @"\空间查询与空间分析.chm");         
        }      

        }
    }
