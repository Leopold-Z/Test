using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataManagementTools;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.Geoprocessing;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class SpatialExtentQuery : Form
    {
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;
        IMapControl3 m_mapControl = null;

        string strGeometryType = "";
        string strSpatialRelationship = "";
        IGeometryCollection queryGeometry;

        static string tempFeatureLayerName = "TempLayerXXX";//存储查询几何形状的临时图层
        IFeatureClass queryFeatureClass;//存储查询几何形状的临时要素类

        //以下2个变量用于设置要素属性的显示与打印，displaySelectedFeatures变量设置为true时，
        //仅对要素的选择集有效； 否则对所有要素有效。
        //displayViaReport变量设置为true时，以报表方式显示或打印要素属性；
        //否则，以普通的属性表方式显示要素的属性
        bool displaySelectedFeatures = true;
        bool displayViaReport = true;

         public SpatialExtentQuery(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
            if (m_hookHelper.Hook is IToolbarControl)
            {
                IToolbarControl toolbarControl = m_hookHelper.Hook as IToolbarControl;
                m_mapControl = (IMapControl3)toolbarControl.Buddy;
            }
            if (m_hookHelper.Hook is IMapControl3)
            {
                m_mapControl = m_hookHelper.Hook as IMapControl3;
            }
        }


        private void SpatialExtentQuery_Load(object sender, EventArgs e)
        {
            if (m_hookHelper == null || null == m_hookHelper.Hook || 0 == m_hookHelper.FocusMap.LayerCount)
                return;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                chklstLayers.Items.Add(layer.Name, false);
            }
        }

        #region "GetLayers"
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";// IFeatureLayer
            //uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";  // IGeoFeatureLayer
            //uid.Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}";  // IDataLayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }
        #endregion

        private void cboGeometryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            strGeometryType  = cboGeometryType.SelectedItem.ToString();
   
        }

        private void cboSpatialRelationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            strSpatialRelationship = cboSpatialRelationship.SelectedItem.ToString();
            if (strSpatialRelationship == "WITHIN_A_DISTANCE")
                txtDistance.Visible = true;
        }              

        private void rdoSelectedFeatures_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSelectedFeatures.Checked)
                displaySelectedFeatures = true;
            else
                displaySelectedFeatures = false;
        }

        private void rdoReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReport.Checked)
                displayViaReport = true;
            else
                displayViaReport = false;
        }

        private void initialize()
        {
            if (strGeometryType == "") return;
            DeleteTempFeatureClass();

            queryFeatureClass = CreateFeatureClass(strGeometryType, m_hookHelper.FocusMap.SpatialReference);
            if (queryFeatureClass == null) return;
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = queryFeatureClass;
            StopEditTempLayer(featureLayer, false);
            RemoveTempLayer();
            AddTempFeatureLayer();
            this.btnQuery.Enabled = true;
            StartEditTempLayer(IsExistTempLayer());//启动临时要素编辑  
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (rdoSelGeom.Checked)
            {
                SaveSelectedFeaturesToQueryFeatureClass();
            }
            StopEditTempLayer(IsExistTempLayer(), true);
            SetAllLayersSelectable();
            //GetQueryGeometry();
            ExecuteQuery();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            txtMessages.Text += "所有查询结束! " + "\r\n";
            txtMessages.Text += "\r\n总查询要素个数: " + m_map.SelectionCount.ToString() + " \r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }

        private void SaveSelectedFeaturesToQueryFeatureClass()
        {
            int selCount = m_map.SelectionCount;
            ISelection selection = m_map.FeatureSelection;
            IEnumFeature selFeatures = selection as IEnumFeature;
            selFeatures.Reset();
            IFeature selFeature = selFeatures.Next();
            while (selFeature != null)
            {
                IFeature feature = queryFeatureClass.CreateFeature();
                feature.Shape = selFeature.Shape;
                feature.Store();
                selFeature = selFeatures.Next();
            }
        }

        private void SetSelectableLayers()
        {
            switch (strGeometryType)
            {
                case "点":
                    SetSelectableLayers(esriGeometryType.esriGeometryPoint);
                    break;
                case "线":
                    SetSelectableLayers(esriGeometryType.esriGeometryPolyline);
                    break;
                case "多边形":
                case "矩形":
                case "圆":
                    SetSelectableLayers(esriGeometryType.esriGeometryPolygon);
                    break;
                default:
                    break;
            }
        }

        private void SetSelectableLayers(esriGeometryType geometryType)
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                if (featureLayer.FeatureClass.ShapeType == geometryType)
                {
                    featureLayer.Selectable = true;
                }
                else
                {
                    featureLayer.Selectable = false;
                }
            }
        }

        private void SetAllLayersSelectable()
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                if (featureLayer == null) return;
                featureLayer.Selectable = true;
            }
        }

        private void GetQueryGeometry()
        {
            if (queryFeatureClass == null) return;
            queryGeometry = null;
            object missing = Type.Missing;

            switch (strGeometryType)
            {
                case "点":
                    queryGeometry = new MultipointClass();
                    break;
                case "线":
                    queryGeometry = new PolylineClass();
                    break;
                case "多边形":
                case "矩形":
                case "圆":
                    queryGeometry = new PolygonClass();
                    break;
                default:
                    break;
            }

            for (int i = 0; i < queryFeatureClass.FeatureCount(null); i++)
            {
                queryGeometry.AddGeometry(queryFeatureClass.GetFeature(i).Shape, ref missing, ref missing);
            }

        }

        private void ExecuteQuery()
        {
            foreach (object itemChecked in chklstLayers.CheckedItems)
            {
                SelectOneLayer(itemChecked.ToString());
            }
        }

        private void SelectOneLayer(string queriedLayer)
        {
            txtMessages.Text += "选择的层: " + queriedLayer + "\r\n";
            txtMessages.Text += "\r\n开始查询. 请稍候...\r\n";
            txtMessages.Update();
            //ScrollToBottom();

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            txtMessages.Text += "选择...\r\n";
            txtMessages.Update();
            object dt = "";

            SelectLayerByLocation select = new SelectLayerByLocation();
            if (GetFeatureLayer(queriedLayer) == null) return;
            select.in_layer = GetFeatureLayer(queriedLayer);
            if (strSpatialRelationship == "") strSpatialRelationship = "INTERSECT";
            select.overlap_type = strSpatialRelationship;
            if (Information.IsNumeric(txtDistance.Text))
            {
                select.search_distance = Convert.ToDouble(txtDistance.Text);
            }
            select.select_features = queryFeatureClass;
            select.selection_type = "NEW_SELECTION";

            try
            {
                IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(select, null);
                if (results != null)
                {

                    if (results.Status != esriJobStatus.esriJobSucceeded)
                    {
                        txtMessages.Text += "选择要素/层失败: " + queriedLayer + "\r\n";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("空间位置空间关系查询问题： "+ex.Message);
            }         
           
            txtMessages.Text += ReturnMessages(gp);

            txtMessages.Text += "\r\n完成.\r\n";
            txtMessages.Text += "--------------------------------\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }

        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            IEnumLayer layers = GetLayers();
            if (layers == null) return null;
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }

            return null;
        }


        private bool DeleteTempFeatureClass()
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IWorkspace workspace = workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
                IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(tempFeatureLayerName);
                IDataset dataSet = featureClass as IDataset;
                if (dataSet.CanDelete())
                {
                    dataSet.Delete();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IFeatureClass CreateFeatureClass(string geometryType, ISpatialReference spatialReference)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);

            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = (IFieldsEdit)fields;
            fieldsEdit.FieldCount_2 = 2;
            //Create the Object ID field.
            IField fieldUserDefined = new Field();
            IFieldEdit fieldEdit = (IFieldEdit)fieldUserDefined;
            fieldEdit.Name_2 = "FID";
            fieldEdit.AliasName_2 = "OBJECT ID";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.set_Field(0, fieldUserDefined);
            // Create the Shape field.
            fieldUserDefined = new Field();
            fieldEdit = (IFieldEdit)fieldUserDefined;
            // Set up the geometry definition for the Shape field.
            IGeometryDef geometryDef = new GeometryDefClass();
            IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
            switch (geometryType)
            {
                case "点":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                    break;
                case "线":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                    break;
                case "多边形":
                case "矩形":
                case "圆":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                    break;
                default:
                    break;
            }
            // By setting the grid size to 0, you're allowing ArcGIS to determine the appropriate grid sizes for the feature class. 
            // If in a personal geodatabase, the grid size will be 1000. If in a file or ArcSDE geodatabase, the grid size
            // will be based on the initial loading or inserting of features.
            geometryDefEdit.GridCount_2 = 1;
            geometryDefEdit.set_GridSize(0, 0);
            geometryDefEdit.HasM_2 = false;
            geometryDefEdit.HasZ_2 = false;
            //Assign the spatial reference that was passed in, possibly from
            //IGeodatabase.SpatialReference for the containing feature dataset.
            if (spatialReference != null)
            {
                geometryDefEdit.SpatialReference_2 = spatialReference;
            }
            // Set standard field properties.
            fieldEdit.Name_2 = "SHAPE";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geometryDef;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.Required_2 = true;
            fieldsEdit.set_Field(1, fieldUserDefined);

            UID CLSID = new UIDClass();
            CLSID.Value = "esriGeoDatabase.Feature";

            return featureWorkspace.CreateFeatureClass(tempFeatureLayerName, fields, CLSID, null, esriFeatureType.esriFTSimple, fields.get_Field(1).Name, "");
        }

        public IFeatureClass CreateFeatureClass(string geometryType)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);

            IFeatureClass featureClass;

            IFields fields;
            UID CLSID = new UIDClass();
            CLSID.Value = "esriGeoDatabase.Feature";
            IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();
            // create the fields using the required fields method
            fields = objectClassDescription.RequiredFields;


            string strShapeField = "";

            // locate the shape field
            for (int j = 0; j < fields.FieldCount; j++)
            {
                if (fields.get_Field(j).Type == ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeGeometry)
                {
                    strShapeField = fields.get_Field(j).Name;
                }
            }

            featureClass = featureWorkspace.CreateFeatureClass(tempFeatureLayerName, fields, CLSID, null, esriFeatureType.esriFTSimple, strShapeField, null);

            return featureClass;
        }

        #region "AddTempFeatureLayer"

        private IFeatureLayer AddTempFeatureLayer()
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0); // Explicit Cast
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(tempFeatureLayerName);
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.FeatureClass = featureClass;
                featureLayer.Name = featureClass.AliasName;
                featureLayer.Visible = true;
                ILayerEffects layerEffects = featureLayer as ILayerEffects;
                layerEffects.Transparency = 60;
                IActiveView activeView = m_hookHelper.ActiveView;
                activeView.FocusMap.AddLayer(featureLayer);
                activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                txtMessages.Text += "已创建临时层:Temp_Layer\r\n";
                return featureLayer;

            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        #region "RemoveTempLayer"

        private void RemoveTempLayer()
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i).Name == tempFeatureLayerName)
                {
                    m_map.DelayEvents(true);
                    m_map.DeleteLayer(m_map.get_Layer(i));
                    break;
                }
            }
        }
        #endregion


        #region "IsExistTempLayer"

        private IFeatureLayer IsExistTempLayer()
        {
            ILayer layer = null;
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i).Name == tempFeatureLayerName)
                {
                    layer = m_map.get_Layer(i);
                }
            }
            return layer as IFeatureLayer;
        }
        #endregion


        #region "StartEditTempLayer"

        private void StartEditTempLayer(ILayer templayer)
        {
            //if (templayer == null) return;
            //if (m_application != null)
            //{
            //    if (m_editor == null) return;
            //    if (m_editor.EditState == esriEditState.esriStateEditing)
            //        return;
            //    try
            //    {
            //        IDataset dataset = templayer as IDataset;
            //        IWorkspace workSpace = dataset.Workspace;
            //        m_editor.StartEditing(workSpace);
            //    }
            //    catch
            //    {
            //    }
            //}
        }
        #endregion

        #region "SetSelectToolAsCurrentTool"

        private void SetSelectToolAsCurrentTool()
        {
            //if (m_application != null)
            //{
            //    ICommandBars documentBars = m_application.Document.CommandBars;
            //    UID cmdID = new UIDClass();
            //    cmdID.Value = "{78FFF793-98B4-11D1-873B-0000F8751720}";//esriArcMapUI.SelectFeaturesTool
            //    ICommandItem cmdItem = documentBars.Find(cmdID, false, false);
            //    m_application.CurrentTool = cmdItem;
            //}
            if (m_mapControl != null)
            {
                ICommand tool = null;
                tool = new ControlsSelectFeaturesToolClass();
                tool.OnCreate(m_mapControl);
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                m_mapControl.CurrentTool = tool as ITool;
            }
        }
        #endregion

        #region "SetCurrentSketchTool"

        private void SetCurrentSketchTool()
        {
          
           
            if (m_mapControl != null)
            {
                ICommand tool = null;

                switch (strGeometryType)
                {
                    case "点":
                        tool = new CreatePointTool(GetFeatureLayer(tempFeatureLayerName));  //CreatePointTool
                        break;
                    case "线":
                        tool = new CreatePolylineTool(GetFeatureLayer(tempFeatureLayerName));  //CreatePolylineTool
                        break;
                    case "多边形":
                        tool = new CreatePolygonTool(GetFeatureLayer(tempFeatureLayerName));  //CreatePolygonTool
                        break;
                    case "矩形":
                        tool = new CreateRectangleTool(GetFeatureLayer(tempFeatureLayerName));  //CreateRectangleTool
                        break;
                    case "圆":
                        tool = new CreateCircleTool(GetFeatureLayer(tempFeatureLayerName));  //CreateCircleTool
                        break;
                    default:
                        break;
                }
                if (tool == null) return;
                tool.OnCreate(m_mapControl);
                m_mapControl.CurrentTool = tool as ITool;
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerHand;
            }
        }
        #endregion



        #region "StopEditTempLayer"

        private void StopEditTempLayer(IFeatureLayer templayer, bool save)
        {
            //if (templayer == null) return;
            //if (m_application != null)
            //{
            //    IDataset dataset = templayer as IDataset;
            //    IWorkspace workSpace = dataset.Workspace;
            //    if (m_editor.EditState == esriEditState.esriStateEditing)
            //    {
            //        m_editor.StopEditing(save);
            //    }
            //}
        }
        #endregion

        private void SpatialExtentQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveTempLayer();
        }

        private string ReturnMessages(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveTempLayer();
            this.Close();
        }

        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        }

        private void btnAttributes_Click(object sender, EventArgs e)
        {
            if (displayViaReport)
            {
                DynamicAttributesReport displayAtrributes = new DynamicAttributesReport(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            }
            else
            {
                AttributesForm displayAtrributes = new AttributesForm(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            }
        }

        private void rdoDrawGeom_Click(object sender, EventArgs e)
        {
            if (rdoDrawGeom.Checked)
            {
                m_map.ClearSelection();
                initialize();
                SetCurrentSketchTool();
            }
        }

        private void rdoSelGeom_Click(object sender, EventArgs e)
        {
            if (rdoSelGeom.Checked)
            {
                m_map.ClearSelection();
                initialize();
                SetSelectToolAsCurrentTool();
                SetSelectableLayers();
            }
        }

    }

}
