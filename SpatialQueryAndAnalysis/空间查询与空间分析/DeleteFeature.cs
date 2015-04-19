using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    /// <summary>
    /// Summary description for DeleteFeature.
    /// </summary>
    [Guid("b1128f6d-1950-4f1e-9191-50f2f0178748")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.DeleteFeature")]
    public sealed class DeleteFeature : BaseTool
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
        
        IMap map;
        IActiveView activeview;
        IEngineEditProperties eep;

        public DeleteFeature()
        {            
            base.m_category = "SpatialQueryAndAnalysis";  
            base.m_caption = "删除要素";   
            base.m_message = "删除要素";  
            base.m_toolTip = "删除要素";  
            base.m_name = "DeleteFeature";   
            try
            {
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
            eep = new EngineEditorClass();
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

            map = m_hookHelper.FocusMap;

            activeview = m_hookHelper.ActiveView;
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add DeleteFeature.OnClick implementation
        }

        private void setalllayerSelectable()
        {
            ILayer layer;
            IFeatureLayer featurelayer;
            for (int i = 0; i < map.LayerCount; i++)
            {
                layer = map.get_Layer(i);
                if (layer is IFeatureLayer)
                {
                    featurelayer = layer as IFeatureLayer;
                    featurelayer.Selectable = true;
                }
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                setalllayerSelectable();
                IFeatureLayer featurelayer = eep.TargetLayer as IFeatureLayer;
                if (featurelayer == null) { MessageBox.Show("请启动编辑！并选择目标图层！"); return; }
                IPoint pt = activeview.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                ITopologicalOperator topo = pt as ITopologicalOperator;
                IGeometry pGeo = topo.Buffer(5);
                pt.SpatialReference = map.SpatialReference;
                ISpatialFilter sf = new SpatialFilterClass();
                sf.Geometry = pGeo;
                sf.GeometryField = featurelayer.FeatureClass.ShapeFieldName;
                switch (featurelayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint: sf.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains; break;
                    case esriGeometryType.esriGeometryPolyline: sf.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses; break;
                    case esriGeometryType.esriGeometryPolygon: sf.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects; break;
                }

                IFeatureSelection pfs = featurelayer as IFeatureSelection;
                pfs.SelectFeatures(sf, esriSelectionResultEnum.esriSelectionResultNew, true);
                ISelectionSet ss = pfs.SelectionSet;
                ICursor pcursor;
                ss.Search(null, true, out pcursor);
                IFeatureCursor pfcursor = pcursor as IFeatureCursor;
                IFeature pfeature = pfcursor.NextFeature();
                if (pfeature != null)
                {
                    activeview.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeview.Extent);
                    DialogResult result;
                    result = MessageBox.Show("确定删除该要素？", "Question Dialog", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    { pfeature.Delete(); activeview.Refresh(); }
                    else return;
                }
                else { MessageBox.Show("未选中要素"); return; }
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add DeleteFeature.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add DeleteFeature.OnMouseUp implementation
        }
        #endregion
    }
}
