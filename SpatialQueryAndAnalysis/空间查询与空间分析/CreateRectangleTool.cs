using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    /// <summary>
    /// Summary description for CreateRectangleTool.
    /// </summary>
    [Guid("68b61286-1a26-4799-a0f6-a907cee85e01")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.空间查询与空间分析.CreateRectangleTool")]
    public sealed class CreateRectangleTool : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        IHookHelper m_hookHelper = null;
        IMap m_Map;
        IActiveView m_ActiveView;
        INewEnvelopeFeedback pEnvelopeFeedback;
        IFeatureLayer m_pCurrentLayer;

        public CreateRectangleTool(IFeatureLayer featureLayer)
        {
            base.m_category = "高级编辑";
            base.m_caption = "创建矩形";
            base.m_message = "创建矩形";
            base.m_toolTip = "创建矩形";
            base.m_name = "CreateRectangleTool";  
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
            m_pCurrentLayer = featureLayer; 
        }

        private IFeatureLayer GetLayerByName(string layerName)
        {
            ILayer layer = null;
            for (int i = 0; i < m_Map.LayerCount; i++)
            {
                if (m_Map.get_Layer(i).Name == layerName)
                {
                    layer = m_Map.get_Layer(i);
                }
            }
            return layer as IFeatureLayer;
        }


        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            m_ActiveView = m_hookHelper.ActiveView;
            m_Map = m_hookHelper.FocusMap;
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add CreateRectangleTool.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //获得鼠标在控件上点击的位置，产生一个点对象
            IPoint pPt = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

            if (pEnvelopeFeedback == null)
            {
                pEnvelopeFeedback = new NewEnvelopeFeedbackClass();
                pEnvelopeFeedback.Display = m_ActiveView.ScreenDisplay;
                pEnvelopeFeedback.Start(pPt);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            IPoint pPt = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //MoveTo方法继承自IDisplayFeedback接口的定义
            if (pEnvelopeFeedback != null) pEnvelopeFeedback.MoveTo(pPt);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            IGeometry pGeo = null;
            pGeo = pEnvelopeFeedback.Stop();
            pEnvelopeFeedback = null;
            CreateFeature(pGeo);
        }
        #endregion

        private void CreateFeature(IGeometry pGeom)
        {
            if (pGeom == null) return;
            if (m_pCurrentLayer == null) return;

            // Create the feature
            IWorkspaceEdit pWorkspaceEdit = GetWorkspaceEdit();
            IFeatureLayer pFeatureLayer = (IFeatureLayer)m_pCurrentLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            pWorkspaceEdit.StartEditOperation();

            //Envelope to Polygon
            IEnvelope pEnv = pGeom as IEnvelope;
            IPointCollection pPtColl;
            pPtColl = new PolygonClass();
            object missing = Type.Missing;
            pPtColl.AddPoint(pEnv.LowerLeft, ref missing, ref missing);
            pPtColl.AddPoint(pEnv.UpperLeft, ref missing, ref missing);
            pPtColl.AddPoint(pEnv.UpperRight, ref missing, ref missing);
            pPtColl.AddPoint(pEnv.LowerRight, ref missing, ref missing);
            //Close the polygon
            pPtColl.AddPoint(pEnv.LowerLeft, ref missing, ref missing);

            IFeature pFeature = pFeatureClass.CreateFeature();
            try
            {
                pFeature.Shape = pPtColl as IGeometry;
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建要素", ex.Message);
            }
            pFeature.Store();
            pWorkspaceEdit.StopEditOperation();

            m_ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, m_pCurrentLayer, pGeom.Envelope);
        }
        private IWorkspaceEdit GetWorkspaceEdit()
        {
            if (m_pCurrentLayer == null) return null;

            IFeatureLayer pFeatureLayer = (IFeatureLayer)m_pCurrentLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IDataset pDataset = (IDataset)pFeatureClass;
            if (pDataset == null) return null;
            return (IWorkspaceEdit)pDataset.Workspace;
        }

        private double ConvertPixelsToMapUnits(IActiveView pActiveView, double pixelUnits)
        {
            // Uses the ratio of the size of the map in pixels to map units to do the conversion
            IPoint p1 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperLeft;
            IPoint p2 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperRight;
            int x1, x2, y1, y2;
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p1, out x1, out y1);
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p2, out x2, out y2);
            double pixelExtent = x2 - x1;
            double realWorldDisplayExtent = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / pixelExtent;
            return pixelUnits * sizeOfOnePixel;
        }


        private void AddCircleElement(IGeometry pGeo, IActiveView pAv)
        {
            ISegmentCollection pSegColl;
            pSegColl = new PolygonClass();
            object Missing1 = Type.Missing;
            object Missing2 = Type.Missing;
            pSegColl.AddSegment(pGeo as ISegment, ref Missing1, ref Missing2);
            ISimpleLineSymbol pLineSym;
            pLineSym = new SimpleLineSymbolClass();
            pLineSym.Color = getRGB(110, 22, 125);
            pLineSym.Style = esriSimpleLineStyle.esriSLSSolid;
            pLineSym.Width = 2;
            ISimpleFillSymbol pSimpleFillSym;
            pSimpleFillSym = new SimpleFillSymbolClass();
            pSimpleFillSym.Color = getRGB(66, 55, 145);
            pSimpleFillSym.Outline = pLineSym;
            pSimpleFillSym.Style = esriSimpleFillStyle.esriSFSCross;
            IElement pPolygonEle;
            pPolygonEle = new CircleElementClass();
            pPolygonEle.Geometry = pSegColl as IGeometry;
            IFillShapeElement pFillEle;
            pFillEle = pPolygonEle as IFillShapeElement;
            pFillEle.Symbol = pSimpleFillSym;
            IGraphicsContainer pGraphicsContainer;
            pGraphicsContainer = pAv as IGraphicsContainer;
            pGraphicsContainer.AddElement(pFillEle as IElement, 0);
            pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
		
    }
}
