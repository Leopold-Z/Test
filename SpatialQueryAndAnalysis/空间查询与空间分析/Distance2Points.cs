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

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    /// <summary>
    /// Summary description for Distance2Points.
    /// </summary>
    [Guid("2b1ce911-602f-4f49-8b1b-3b288f960bfe")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.Distance2Points")]
    public sealed class Distance2Points : BaseTool
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
        IMap pmap;
        IActiveView pactiveView;
        IPoint pPointStd;

        public Distance2Points()
        {
            base.m_category = "SpatialQueryAndAnalysis";  
            base.m_caption = "计算两点间距离";   
            base.m_message = "计算两点间距离";  
            base.m_toolTip = "计算两点间距离";  
            base.m_name = "计算两点间距离";   
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
                pactiveView = m_hookHelper.ActiveView;
                pmap = pactiveView.FocusMap;

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
            // TODO: Add Distance2Points.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                //产生一个当前的点击的点对象
                IPoint pPoint;
                pPoint = new PointClass();
                pPoint.SpatialReference = pmap.SpatialReference;
                pPoint = pactiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                //判断是否为第一个点
                if (pPointStd == null)
                {
                    pPointStd = pPoint;
                    //在屏幕上绘制
                    IScreenDisplay screenDisplay = pactiveView.ScreenDisplay;
                    screenDisplay.StartDrawing(screenDisplay.hDC, (short)esriScreenCache.esriNoScreenCache);
                    screenDisplay.SetSymbol(new SimpleMarkerSymbolClass());
                    screenDisplay.DrawPoint(pPointStd);
                    screenDisplay.FinishDrawing();
                }
                else
                {
                    IProximityOperator pProximity;
                    pProximity = pPointStd as IProximityOperator;
                    double pDistance;
                    pDistance = pProximity.ReturnDistance(pPoint);
                    //标签对象上出现两点间的距离
                    MessageBox.Show(pDistance.ToString());
                }
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Distance2Points.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Distance2Points.OnMouseUp implementation
        }
        #endregion
    }
}
