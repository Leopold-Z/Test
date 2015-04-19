using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;
using Microsoft.VisualBasic;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class QueryAdjacentFeatures : Form
    {
        IApplication m_application = null;
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;
        IMapControl3 m_mapControl = null;
        IEditor m_editor = null;

        IFeatureLayer currentLayer = null;

        //以下2个变量用于设置要素属性的显示与打印，displaySelectedFeatures变量设置为true时，
        //仅对要素的选择集有效； 否则对所有要素有效。
        //displayViaReport变量设置为true时，以报表方式显示或打印要素属性；
        //否则，以普通的属性表方式显示要素的属性
        bool displaySelectedFeatures = true;
        bool displayViaReport = true;

        public QueryAdjacentFeatures(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;

            if (m_hookHelper.Hook is IApplication)
            {
                m_application = m_hookHelper.Hook as IApplication;
                UID uID = new UID();
                uID.Value = "esriEditor.Editor";
                if (m_application == null)
                    return;
                m_editor = m_application.FindExtensionByCLSID(uID) as IEditor;
            }

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

        private void QueryAdjacentFeatures_Load(object sender, EventArgs e)
        {
            CboAddItems(cbxPolygonLayers, esriGeometryType.esriGeometryPolygon);
        }

        #region "CboAddItems"
        private void CboAddItems(ComboBox cbo, esriGeometryType geometryType)
        {
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.FeatureClass.ShapeType == geometryType)
                    {
                        cbo.Items.Add(layer.Name);
                    }
                }
                layer = layers.Next();
            }
        }
        #endregion

        private void cbxPolygonLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelectedLayer = cbxPolygonLayers.SelectedItem.ToString();
            currentLayer = GetFeatureLayer(strSelectedLayer);
            SetCurrentLayerSelectable(strSelectedLayer);
        }

        #region "SetSelectableLayers"
        private void SetCurrentLayerSelectable(string strCurrentLayer)
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                if (featureLayer == null) return;
                if (featureLayer.Name == strCurrentLayer)
                {
                    featureLayer.Selectable = true;
                }
                else
                {
                    featureLayer.Selectable = false;
                }
            }
        }
        #endregion

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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DeleteGraphics();

            txtMessages.Text += "开始邻接多边形查询： " + "\r\n";
            txtMessages.Text += "查询图层： " + currentLayer.Name + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n\r\n";
            txtMessages.Update();

            IFeatureSelection featureSelection = currentLayer as IFeatureSelection;
            ISelectionSet selectionSet = featureSelection.SelectionSet;
            IEnumIDs selectedIDs = selectionSet.IDs;
            selectedIDs.Reset();
            int selectedID = selectedIDs.Next();
            if (selectedID == -1) return;
            IFeature baseFeature = currentLayer.FeatureClass.GetFeature(selectedID);

            //The following code using SpatialFilter, and has been tested successfully!		
            if (baseFeature != null)
            {
                IGeometry baseGeom = baseFeature.Shape;
                ISpatialFilter pSFilter = new SpatialFilterClass();
                pSFilter.Geometry = baseGeom;
                pSFilter.GeometryField = "Shape";
                pSFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelTouches;
                featureSelection.SelectFeatures(pSFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            }
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);
            //突出显示基多边形要素
            DrawGraphics(baseFeature.ShapeCopy);

            txtMessages.Text += "邻接多边形查询结束! " + "\r\n";
            txtMessages.Text += "总查询要素个数: " + m_map.SelectionCount.ToString() + " \r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }

        private void DrawGraphics(IGeometry geometry)
        {
            IRgbColor rgbColor = GetRGBColor(255, 0, 0);
            IRgbColor outlineRgbColor = GetRGBColor(255, 255, 0);
            AddGraphic(m_map, geometry, rgbColor, outlineRgbColor);
        }

        private void DeleteGraphics()
        {
            IGraphicsContainer graphicsContainer = m_map as IGraphicsContainer;
            graphicsContainer.DeleteAllElements();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        #region "Add Graphic to Map"
        public void AddGraphic(IMap map, IGeometry geometry, IRgbColor rgbColor, IRgbColor outlineRgbColor)
        {
            if (geometry == null) return;
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map;
            ESRI.ArcGIS.Carto.IElement element = null;
            if ((geometry.GeometryType) == esriGeometryType.esriGeometryPoint)
            {
                // Marker symbols
                ESRI.ArcGIS.Display.ISimpleMarkerSymbol simpleMarkerSymbol = new ESRI.ArcGIS.Display.SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = rgbColor;
                simpleMarkerSymbol.Outline = true;
                simpleMarkerSymbol.OutlineColor = outlineRgbColor;
                simpleMarkerSymbol.Size = 15;
                simpleMarkerSymbol.Style = ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle;

                ESRI.ArcGIS.Carto.IMarkerElement markerElement = new ESRI.ArcGIS.Carto.MarkerElementClass();
                markerElement.Symbol = simpleMarkerSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)markerElement;
            }
            else if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline)
            {
                //  Line elements
                ESRI.ArcGIS.Display.ISimpleLineSymbol simpleLineSymbol = new ESRI.ArcGIS.Display.SimpleLineSymbolClass();
                simpleLineSymbol.Color = rgbColor;
                simpleLineSymbol.Style = ESRI.ArcGIS.Display.esriSimpleLineStyle.esriSLSSolid;
                simpleLineSymbol.Width = 5;

                ESRI.ArcGIS.Carto.ILineElement lineElement = new ESRI.ArcGIS.Carto.LineElementClass();
                lineElement.Symbol = simpleLineSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)lineElement;
            }
            else if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon)
            {
                // Polygon elements
                ESRI.ArcGIS.Display.ISimpleFillSymbol simpleFillSymbol = new ESRI.ArcGIS.Display.SimpleFillSymbolClass();
                simpleFillSymbol.Color = rgbColor;
                simpleFillSymbol.Style = ESRI.ArcGIS.Display.esriSimpleFillStyle.esriSFSForwardDiagonal;
                ESRI.ArcGIS.Carto.IFillShapeElement fillShapeElement = new ESRI.ArcGIS.Carto.PolygonElementClass();
                fillShapeElement.Symbol = simpleFillSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)fillShapeElement;
            }
            if (!(element == null))
            {
                element.Geometry = geometry;
                graphicsContainer.AddElement(element, 0);
            }
        }

        #endregion

        private void btnAttributeTable_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectOnePolygon_Click(object sender, EventArgs e)
        {
            m_map.ClearSelection();
            SetSelectToolAsCurrentTool();
        }

        #region "SetSelectToolAsCurrentTool"
        private void SetSelectToolAsCurrentTool()
        {
            if (m_application != null)
            {
                ICommandBars documentBars = m_application.Document.CommandBars;
                UID cmdID = new UIDClass();
                cmdID.Value = "{78FFF793-98B4-11D1-873B-0000F8751720}";//esriArcMapUI.SelectFeaturesTool
                ICommandItem cmdItem = documentBars.Find(cmdID, false, false);
                m_application.CurrentTool = cmdItem;
            }
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

        #region "GetFeatureLayer"
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

        #endregion

        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        }

        private IRgbColor GetRGBColor(int r, int g, int b)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = r;
            color.Green = g;
            color.Blue = b;
            return color;
        }

    }
}
