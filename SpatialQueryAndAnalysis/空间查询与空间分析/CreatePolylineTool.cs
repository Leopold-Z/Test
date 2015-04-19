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
    /// Summary description for CreatePolylineTool.
    /// </summary>
    [Guid("c15595b0-bb4e-47f9-af7a-8fdd27722ec1")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.空间查询与空间分析.CreatePolylineTool")]
    public sealed class CreatePolylineTool : BaseTool
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

        private IHookHelper m_hookHelper = null;
        IMap m_Map;
        IActiveView m_ActiveView;
        INewLineFeedback pLineFeedback;
        IFeatureLayer m_pCurrentLayer;
        IPoint m_pPoint;
        public CreatePolylineTool(IFeatureLayer featureLayer)
        {
            base.m_category = "高级编辑";
            base.m_caption = "创建线";
            base.m_message = "创建线";
            base.m_toolTip = "创建线";
            base.m_name = "CreatePolylineTool";    
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
            // TODO: Add CreatePolylineTool.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            //获得鼠标在控件上点击的位置，产生一个点对象
            IPoint pPt = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

            if (pLineFeedback == null)
            {
                pLineFeedback = new NewLineFeedbackClass();
                pLineFeedback.Display = m_ActiveView.ScreenDisplay;
                pLineFeedback.Start(pPt);
            }
            else
            {
                pLineFeedback.AddPoint(pPt);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            IPoint pPt = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //MoveTo方法继承自IDisplayFeedback接口的定义
            if (pLineFeedback != null) pLineFeedback.MoveTo(pPt);
            m_pPoint = m_ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add CreatePolylineTool.OnMouseUp implementation
        }

        public override void OnDblClick()
        {
            IGeometry pGeom = null;
            IPointCollection pPointCollection = null;

            pLineFeedback.AddPoint(m_pPoint);
            IPolyline pPolyLine = pLineFeedback.Stop();
            if (pPolyLine != null)
                pPointCollection = (IPointCollection)pPolyLine;
            if (pPointCollection.PointCount < 2)
                MessageBox.Show("You must have at least two vertices in a line.", "Bad Line Geometry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                pGeom = (IGeometry)pPointCollection;

            pLineFeedback = null;
            CreateFeature(pGeom);
        }

        private void CreateFeature(IGeometry pGeom)
        {
            if (pGeom == null) return;
            if (m_pCurrentLayer == null) return;

            // Create the feature
            IWorkspaceEdit pWorkspaceEdit = GetWorkspaceEdit();
            IFeatureLayer pFeatureLayer = (IFeatureLayer)m_pCurrentLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            pWorkspaceEdit.StartEditOperation();
            IFeature pFeature = pFeatureClass.CreateFeature();
            try
            {
                pFeature.Shape = pGeom;
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

        #endregion
    }
}
