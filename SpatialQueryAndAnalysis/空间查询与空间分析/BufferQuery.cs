using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessor;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.SystemUI;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class BufferQuery : Form
    {
        IApplication m_application = null;
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;
        IMapControl3 m_mapControl = null;
        IEditor m_editor = null;

        string strGeometryType = "";
        string strSpatialRelationship = "";

        static string tempFeatureLayerName = "TempLayerXXX";//存储查询几何形状的临时图层
        IFeatureClass queryFeatureClass;//存储查询几何形状的临时要素类

        string polygonBufferType = "普通多边形缓冲";//存储多边形缓冲类型

        //以下2个变量用于设置要素属性的显示与打印，displaySelectedFeatures变量设置为true时，
        //仅对要素的选择集有效； 否则对所有要素有效。
        //displayViaReport变量设置为true时，以报表方式显示或打印要素属性；
        //否则，以普通的属性表方式显示要素的属性
        bool displaySelectedFeatures = true;
        bool displayViaReport = true;

       public BufferQuery(IHookHelper hookHelper)
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

        private void BufferQuery_Load(object sender, EventArgs e)
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
            btnBuffer.Enabled = false;
            grpPolygonbufferType.Enabled = false;
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
            strGeometryType = cboGeometryType.SelectedItem.ToString();
            btnBuffer.Enabled = true;
            if (strGeometryType == "矩形" || strGeometryType == "圆" || strGeometryType == "多边形")
                grpPolygonbufferType.Enabled = true;
            else
                grpPolygonbufferType.Enabled = false;
        }              

        private void cboSpatialRelationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            strSpatialRelationship = cboSpatialRelationship.SelectedItem.ToString();
            btnBuffer.Enabled = true;
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

        private void btnBuffer_Click(object sender, EventArgs e)
        {
            btnBuffer.Enabled = false;
            btnAttributes.Enabled = true;
            DeleteGraphics();
            if (rdoSelGeom.Checked)
            {
                SaveSelectedFeaturesToQueryFeatureClass();
            }
            IGeometryCollection geometries = CreateBufferPolygons();
            if (geometries == null) return;
            StopEditTempLayer(IsExistTempLayer(), true);
            SetAllLayersSelectable();
            //GetQueryGeometry();
            ExecuteQuery(geometries);
            //清除临时图层上的选择要素
            IFeatureLayer featureLayer = GetFeatureLayer(tempFeatureLayerName);
            if (featureLayer == null) return;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            featureSelection.Clear();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            txtMessages.Text += "所有查询结束! " + "\r\n";
            txtMessages.Text += "\r\n总查询要素个数: " + m_map.SelectionCount.ToString() + " \r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
            geometries = null;
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

        #region "initialize"
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
            this.btnBuffer.Enabled = true;
            StartEditTempLayer(IsExistTempLayer());//启动临时要素编辑  
        }
        #endregion   

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveTempLayer();
            DeleteGraphics();
            this.Close();
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
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = (ESRI.ArcGIS.Carto.IGraphicsContainer)map; // Explicit Cast
            ESRI.ArcGIS.Carto.IElement element = null;
            if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
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
                element = (ESRI.ArcGIS.Carto.IElement)markerElement; // Explicit Cast
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
                element = (ESRI.ArcGIS.Carto.IElement)lineElement; // Explicit Cast
            }
            else if ((geometry.GeometryType) == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon)
            {
                // Polygon elements
                ESRI.ArcGIS.Display.ISimpleFillSymbol simpleFillSymbol = new ESRI.ArcGIS.Display.SimpleFillSymbolClass();
                simpleFillSymbol.Color = rgbColor;
                simpleFillSymbol.Style = ESRI.ArcGIS.Display.esriSimpleFillStyle.esriSFSForwardDiagonal;
                ESRI.ArcGIS.Carto.IFillShapeElement fillShapeElement = new ESRI.ArcGIS.Carto.PolygonElementClass();
                fillShapeElement.Symbol = simpleFillSymbol;
                element = (ESRI.ArcGIS.Carto.IElement)fillShapeElement; // Explicit Cast
            }
            if (!(element == null))
            {
                element.Geometry = geometry;
                graphicsContainer.AddElement(element, 0);
            }
        }

        #endregion

        private IGeometryCollection CreateBufferPolygons()
        {
            IGeometryCollection geometries = new GeometryBagClass() as IGeometryCollection;
            if (queryFeatureClass == null) return null;
            double bufferDistance = 0;
            if (Information.IsNumeric(txtDistance.Text))
            {
                bufferDistance = Convert.ToDouble(txtDistance.Text);
            }
            else
                return null;

            IFeatureCursor featureCursor = queryFeatureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                IGeometry geometry = feature.ShapeCopy;
                ITopologicalOperator topogeometry = geometry as ITopologicalOperator;
                if (topogeometry == null || geometry == null) return null;

                object obj = Type.Missing;
                IGeometry bufferResult;

                if (queryFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    IPolygon4 polygon = geometry as IPolygon4;
                    IGeometry buffBoundaryExtAndInt;
                    ITopologicalOperator topoBuffer;
                    #region "switch (polygonBufferType)"
                    switch (polygonBufferType)
                    {
                        case "多边形边界内外缓冲":
                            //多边形边界内外缓冲即对多边形的所有内外环边界进行缓冲，要注意各边界缓冲区的合并
                            buffBoundaryExtAndInt = BufferExtAndIntBoundary(polygon, bufferDistance, true);
                            geometries.AddGeometry(buffBoundaryExtAndInt, ref obj, ref obj);
                            break;
                        case "多边形边界外缓冲":
                            //多边形边界外缓冲即对多边形的所有内外环边界仅作外缓冲
                            //可以由普通多边形缓冲减去多边形本身得到
                            IGeometry bufferPolygon = topogeometry.Buffer(bufferDistance);
                            topoBuffer = bufferPolygon as ITopologicalOperator;
                            bufferResult = topoBuffer.Difference(geometry);
                            DrawGraphics(bufferResult);
                            geometries.AddGeometry(bufferResult, ref obj, ref obj);
                            break;
                        case "多边形边界内缓冲":
                            //多边形边界内缓冲即对多边形的所有内外环边界仅作内缓冲
                            //可以由多边形边界内外缓冲和多边形本身求交得到
                            buffBoundaryExtAndInt = BufferExtAndIntBoundary(polygon, bufferDistance, false);
                            topoBuffer = buffBoundaryExtAndInt as ITopologicalOperator;
                            bufferResult = topoBuffer.Intersect(geometry, esriGeometryDimension.esriGeometry2Dimension);
                            DrawGraphics(bufferResult);
                            geometries.AddGeometry(bufferResult, ref obj, ref obj);
                            break;
                        case "多边形内缓冲":
                            //普通多边形缓冲就是在多边形外作缓冲， 多边形内缓冲即对多边形向内作缓冲
                            //可以通过给负距离产生
                            topoBuffer = geometry as ITopologicalOperator;
                            bufferResult = topoBuffer.Buffer(-bufferDistance);
                            DrawGraphics(bufferResult);
                            geometries.AddGeometry(bufferResult, ref obj, ref obj);
                            break;
                        case "普通多边形缓冲":
                            topoBuffer = geometry as ITopologicalOperator;
                            bufferResult = topoBuffer.Buffer(bufferDistance);
                            DrawGraphics(bufferResult);
                            geometries.AddGeometry(bufferResult, ref obj, ref obj);
                            break;
                        default:
                            break;
                    }
                    #endregion
                }
                else
                {
                    bufferResult = topogeometry.Buffer(bufferDistance);
                    DrawGraphics(bufferResult);
                    geometries.AddGeometry(bufferResult, ref obj, ref obj);
                }

                feature = featureCursor.NextFeature();
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);

            ITopologicalOperator topoGeometries = geometries as ITopologicalOperator;
            topoGeometries.Simplify();
            return geometries;
        }

        private IGeometry BufferExtAndIntBoundary(IPolygon4 polygon, double bufferDistance, bool draw)
        {
            IGeometry bndBuffer;
            object obj = Type.Missing;
            IGeometryCollection bufferGeometries = new GeometryBagClass() as IGeometryCollection;

            IGeometryBag exteriorRings = polygon.ExteriorRingBag;
            IEnumGeometry exteriorRingsEnum = exteriorRings as IEnumGeometry;
            exteriorRingsEnum.Reset();
            IRing currentExteriorRing = exteriorRingsEnum.Next() as IRing;
            while (currentExteriorRing != null)
            {
                bndBuffer = BufferBoundary(currentExteriorRing, bufferDistance, false);
                bufferGeometries.AddGeometry(bndBuffer, ref obj, ref obj);

                //IPolygon4.get_InteriorRingBag should be used instead of IPolygon.QueryInteriorRings,
                //which does not work in .NET because of C-Style Arrays
                IGeometryBag interiorRings = polygon.get_InteriorRingBag(currentExteriorRing);
                IEnumGeometry interiorRingsEnum = interiorRings as IEnumGeometry;
                interiorRingsEnum.Reset();
                IRing currentInteriorRing = interiorRingsEnum.Next() as IRing;
                while (currentInteriorRing != null)
                {
                    bndBuffer = BufferBoundary(currentInteriorRing, bufferDistance, false);
                    bufferGeometries.AddGeometry(bndBuffer, ref obj, ref obj);
                    currentInteriorRing = interiorRingsEnum.Next() as IRing;
                }
                currentExteriorRing = exteriorRingsEnum.Next() as IRing;
            }

            ITopologicalOperator topoBufferGeometries = bufferGeometries as ITopologicalOperator;
            topoBufferGeometries.Simplify();
            IPolygon buffPolygon = new PolygonClass();
            ITopologicalOperator topoPolygon = buffPolygon as ITopologicalOperator;
            IEnumGeometry enumGeometry = bufferGeometries as IEnumGeometry;
            topoPolygon.ConstructUnion(enumGeometry);
            if (draw) DrawGraphics(buffPolygon as IGeometry);
            return buffPolygon as IGeometry;
        }

        private IGeometry BufferBoundary(IRing currentRing, double bufferDistance, bool draw)
        {
            ISegmentCollection polyline = new PolylineClass() as ISegmentCollection;
            ISegmentCollection ringSegmentCollection = currentRing as ISegmentCollection;
            List<ISegment> ringSegments = new List<ISegment>();
            for (int i = 0; i < ringSegmentCollection.SegmentCount; i++)
            {
                ringSegments.Add(ringSegmentCollection.get_Segment(i));
            }
            ISegment[] ringSegmentsArray = ringSegments.ToArray();

            IGeometryBridge geometryBridge = new GeometryEnvironmentClass();
            geometryBridge.AddSegments(polyline, ref ringSegmentsArray);
            ITopologicalOperator topoBndBuffer = polyline as ITopologicalOperator;
            IGeometry bndBuffer = topoBndBuffer.Buffer(bufferDistance);
            if (draw) DrawGraphics(bndBuffer);
            return bndBuffer;
        }

        private void DrawGraphics(IGeometry geometry)
        {
            IRgbColor rgbColor = GetRGBColor(255, 0, 0);
            IRgbColor outlineRgbColor = GetRGBColor(255, 255, 0);
            AddGraphic(m_map, geometry, rgbColor, outlineRgbColor);
        }

        private void DrawGraphics(IGeometryCollection geometries)
        {
            IGeometry geometry;
            for (int i = 0; i < geometries.GeometryCount; i++)
            {
                geometry = geometries.get_Geometry(i);
                DrawGraphics(geometry);
            }
        }

        private IRgbColor GetRGBColor(int r, int g, int b)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = r;
            color.Green = g;
            color.Blue = b;
            return color;
        }

        #region "SaveSelectedFeaturesToQueryFeatureClass"

        private void SaveSelectedFeaturesToQueryFeatureClass()
        {
            try
            {
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
                m_map.ClearSelection();
                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            catch
            {

            }
        }
        #endregion

        #region "SetSelectableLayers"
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
        #endregion

        #region "SetSelectableLayers"
        private void SetSelectableLayers(esriGeometryType geometryType)
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                if (featureLayer == null) return;
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
        #endregion

        #region "SetAllLayersSelectable"
        private void SetAllLayersSelectable()
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = m_map.get_Layer(i) as IFeatureLayer;
                if (featureLayer == null) return;
                featureLayer.Selectable = true;
            }
        }
        #endregion

        #region "ExecuteQuery"
        private void ExecuteQuery(IGeometryCollection geometries)
        {
            if (queryFeatureClass == null || queryFeatureClass.FeatureCount(null) == 0)
                return;
            foreach (object itemChecked in chklstLayers.CheckedItems)
            {
                SelectOneLayer(itemChecked.ToString(), geometries);
            }
        }

        #endregion

        #region "SelectOneLayer"
        private void SelectOneLayer(string queriedLayer, IGeometryCollection geometries)
        {
            txtMessages.Text += "选择的层: " + queriedLayer + "\r\n";
            txtMessages.Text += "\r\n开始查询. 请稍候...\r\n";
            txtMessages.Update();
            IFeatureLayer featureLayer = GetFeatureLayer(queriedLayer);
            if (featureLayer == null) return;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            ISpatialFilter spatialFilter = new SpatialFilterClass();
            for (int i = 0; i < geometries.GeometryCount; i++)
            {
                spatialFilter.Geometry = geometries.get_Geometry(i);
                spatialFilter.GeometryField = featureLayer.FeatureClass.ShapeFieldName;
                if (strSpatialRelationship == "") strSpatialRelationship = "相交";
                switch (strSpatialRelationship)
                {
                    case "相交":
                        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        break;
                    case "包含":
                        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        break;
                    case "被包含":
                        spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                        break;
                    default:
                        break;
                }
                featureSelection.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
            }

            txtMessages.Text += "\r\n完成.\r\n";
            txtMessages.Text += "-------------------------------------------------------\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
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

        #region "DeleteTempFeatureClass"
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
        #endregion

        #region "Create FeatureClass"
        public IFeatureClass CreateFeatureClass(string geometryType, ISpatialReference spatialReference)
        {
            //IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
            //string gdbName = "FGISTemp" + ".gdb";
            //string gdbFullPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), gdbName);
            //IWorkspace workspace;
            //IFeatureWorkspace featureWorkspace;

            //if (System.IO.Directory.Exists(gdbFullPath))
            //{
            //    featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(gdbFullPath, 0);
            //}
            //else
            //{
            //    IWorkspaceName workspaceName = workspaceFactory.Create(System.IO.Path.GetTempPath(), gdbName, null, 0);
            //    IName name = (ESRI.ArcGIS.esriSystem.IName)workspaceName;
            //    workspace = (IWorkspace)name.Open();
            //    featureWorkspace = workspace as IFeatureWorkspace;
            //}

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
        #endregion

        #region "Create FeatureClass"
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
        #endregion

        #region "AddTempFeatureLayer"

        private IFeatureLayer AddTempFeatureLayer()
        {
            try
            {
                //IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
                //string gdbName = "FGISTemp" + ".gdb";
                //string gdbFullPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), gdbName);
                //IWorkspace workspace;
                //IFeatureWorkspace featureWorkspace;

                //if (System.IO.Directory.Exists(gdbFullPath))
                //{
                //    featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(gdbFullPath, 0);
                //}
                //else
                //{
                //    IWorkspaceName workspaceName = workspaceFactory.Create(System.IO.Path.GetTempPath(), gdbName, null, 0);
                //    IName name = (ESRI.ArcGIS.esriSystem.IName)workspaceName;
                //    workspace = (IWorkspace)name.Open();
                //    featureWorkspace = workspace as IFeatureWorkspace;
                //}

                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
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
            if (templayer == null) return;
            if (m_application != null)
            {
                if (m_editor == null) return;
                if (m_editor.EditState == esriEditState.esriStateEditing)
                    return;
                try
                {
                    IDataset dataset = templayer as IDataset;
                    IWorkspace workSpace = dataset.Workspace;
                    m_editor.StartEditing(workSpace);
                }
                catch
                {
                }
            }
            //if (mapControl != null)
            //{
            //    ControlsEditingStartCommand startEdit = new ControlsEditingStartCommandClass();
            //    startEdit.OnCreate(m_hookHelper.Hook);
            //    startEdit.OnClick();
            //}
        }
        #endregion

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

        #region "SetCurrentSketchTool"

        private void SetCurrentSketchTool()
        {
            if (m_application != null)
            {
                ICommandBars documentBars = m_application.Document.CommandBars;
                UID cmdID = new UIDClass();
                switch (strGeometryType)
                {
                    case "点":
                    case "线":
                    case "多边形":
                        cmdID.Value = "{B479F48A-199D-11D1-9646-0000F8037368}";//sketch tool
                        break;
                    case "矩形":
                        cmdID.Value = "{6F0ED2CC-C099-4895-BD7E-BEEC2F78ADBF}"; //esriEditor.RectangleTool
                        break;
                    case "圆":
                        cmdID.Value = "{09C6F589-A3CE-48AB-81BC-46965C58F264}";//esriEditor.CircleTool
                        break;
                    default:
                        break;
                }
                ICommandItem cmdItem = documentBars.Find(cmdID, false, false);
                m_application.CurrentTool = cmdItem;
            }
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
                        tool = new CreateCircleTool(GetFeatureLayer(tempFeatureLayerName)); //CreateCircleTool
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
            if (templayer == null) return;
            if (m_application != null)
            {
                IDataset dataset = templayer as IDataset;
                IWorkspace workSpace = dataset.Workspace;
                if (m_editor.EditState == esriEditState.esriStateEditing)
                {
                    m_editor.StopEditing(save);
                }
            }
            //if (mapControl != null)
            //{
            //    ControlsEditingStopCommand stopEdit = new ControlsEditingStopCommandClass();
            //    stopEdit.OnCreate(m_hookHelper.Hook);
            //    stopEdit.OnClick();
            //}
        }
        #endregion

        private void BufferQuery_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtDistance_TextChanged(object sender, EventArgs e)
        {
            btnBuffer.Enabled = true;
        }

        private void chklstLayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chklstLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnBuffer.Enabled = true;    
        }

        private void rdoBndExtInt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBndExtInt.Checked)
                polygonBufferType = "多边形边界内外缓冲";
        }

        private void rdoBndInt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBndInt.Checked)
                polygonBufferType = "多边形边界内缓冲"; 
        }

        private void rdoExtAndPolygon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExtAndPolygon.Checked)
                polygonBufferType = "普通多边形缓冲"; 
        }

        private void rdoBndExt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBndExt.Checked)
                polygonBufferType = "多边形边界外缓冲";
        }

        private void rdoIntForward_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoIntForward.Checked)
                polygonBufferType = "多边形内缓冲"; 
        }

        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        }

        private void rdoDrawGeom_Click(object sender, EventArgs e)
        {
            if (rdoDrawGeom.Checked)
            {
                m_map.ClearSelection();
                DeleteGraphics();
                initialize();
                SetCurrentSketchTool();
                btnBuffer.Enabled = true;
                btnAttributes.Enabled = true;
            }
        }

        private void rdoSelGeom_Click(object sender, EventArgs e)
        {
            if (rdoSelGeom.Checked)
            {
                m_map.ClearSelection();
                DeleteGraphics();
                initialize();
                SetSelectToolAsCurrentTool();
                SetSelectableLayers();
                btnBuffer.Enabled = true;
                btnAttributes.Enabled = true;
            }
        }
      
    }
}
