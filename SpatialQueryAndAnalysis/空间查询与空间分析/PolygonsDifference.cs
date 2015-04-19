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
    /// Summary description for PolygonsDifference.
    /// </summary>
    [Guid("751f1fdb-3062-4b1a-bf07-61df3d12785e")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.PolygonsDifference")]
    public sealed class PolygonsDifference : BaseTool
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
        IActiveView m_activeView = null;
        IMap m_map = null;

        IEngineEditProperties m_engineEditor = null;
        public PolygonsDifference()
        {
            base.m_category = "SpatialQueryAndAnalysis";  
            base.m_caption = "多边形挖空处理";
            base.m_message = "多边形挖空处理";
            base.m_toolTip = "多边形挖空处理";
            base.m_name = "PolygonsDifference"; 
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

            m_engineEditor = new EngineEditorClass();
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

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null)
            {
                MessageBox.Show("请先启动编辑！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button != (int)Keys.LButton) return;
            ILayer layer = m_engineEditor.TargetLayer;
            if (layer == null)
            {
                MessageBox.Show("请先启动编辑！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
            if (m_map == null || m_activeView == null) return;

            IPoint pPoint = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            ISelectionEnvironment pSelectionEnvironment = new SelectionEnvironmentClass();
            pSelectionEnvironment.PointSelectionMethod = esriSpatialRelEnum.esriSpatialRelWithin;
            m_map.SelectByShape(pPoint as IGeometry, pSelectionEnvironment, false);
            if (m_map.SelectionCount != 2)
            {
                MessageBox.Show("选择的多边形个数应该为2！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);

            bool deleteInteriorPolygon = false;
            DialogResult pDialogResult = MessageBox.Show("是否要删除内多边形？", "操作提示", MessageBoxButtons.YesNo);
            if (pDialogResult == DialogResult.Yes)
            {
                deleteInteriorPolygon = true;
            }

            IEnumFeature pEnumFeature = m_map.FeatureSelection as IEnumFeature;
            IEnumFeatureSetup pEnumFeatureSetup = pEnumFeature as IEnumFeatureSetup;
            pEnumFeatureSetup.AllFields = true;
            IFeature firstFeature = pEnumFeature.Next();
            IFeature secondFeature = pEnumFeature.Next();

            IArea pAreaFirst = firstFeature.Shape as IArea;
            IArea pAreaSecond = secondFeature.Shape as IArea;
            IGeometry pGeometry = null;
            bool firstPolygonIsLarge = false;

            IRelationalOperator pRelationalOperator = firstFeature.Shape as IRelationalOperator;
            if (pAreaFirst.Area > pAreaSecond.Area)
            {
                if (pRelationalOperator.Contains(secondFeature.Shape))
                {
                    ITopologicalOperator pTopologicalOperator = firstFeature.Shape as ITopologicalOperator;
                    pGeometry = pTopologicalOperator.Difference(secondFeature.Shape);
                    firstPolygonIsLarge = true;
                }
            }
            else
            {
                pRelationalOperator = secondFeature.Shape as IRelationalOperator;
                if (pRelationalOperator.Contains(firstFeature.Shape))
                {
                    ITopologicalOperator pTopologicalOperator = secondFeature.Shape as ITopologicalOperator;
                    pGeometry = pTopologicalOperator.Difference(firstFeature.Shape);
                    firstPolygonIsLarge = false;
                }
            }
            IFeatureClass featureClass = firstFeature.Class as IFeatureClass;
            IDataset dataset = featureClass as IDataset;
            IWorkspaceEdit workspaceEdit = dataset.Workspace as IWorkspaceEdit;
            if (!(workspaceEdit.IsBeingEdited())) return;

            workspaceEdit.StartEditOperation();
            if (firstPolygonIsLarge)
            {
                firstFeature.Shape = pGeometry;
                firstFeature.Store();
                if (deleteInteriorPolygon)
                    secondFeature.Delete();
            }
            else
            {
                secondFeature.Shape = pGeometry;
                secondFeature.Store();
                if (deleteInteriorPolygon)
                    firstFeature.Delete();
            }
            workspaceEdit.StopEditOperation();
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add PolygonsDifference.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add PolygonsDifference.OnMouseUp implementation
        }
        #endregion
    }
}
