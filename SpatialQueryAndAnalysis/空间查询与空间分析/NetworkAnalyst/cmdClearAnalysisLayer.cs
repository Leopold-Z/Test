using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Carto;

namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("a9e622f9-2a1d-4508-90f9-ec29c5183edd")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.NetworkAnalyst.cmdClearAnalysisLayer")]
    public sealed class cmdClearAnalysisLayer : BaseCommand
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
        private IMapControl3 m_mapControl;
        public cmdClearAnalysisLayer()
        {
            base.m_caption = "Clear Analysis Layer";
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                m_mapControl = (IMapControl3)m_hookHelper.Hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            IEngineNetworkAnalystEnvironment naEnv = new EngineNetworkAnalystEnvironmentClass();
            IEngineNetworkAnalystHelper naHelper = naEnv as IEngineNetworkAnalystHelper;
            IEngineNAWindow naWindow = naEnv.NAWindow;

            // Get the NALayer and corresponding NAContext of the layer that
            // was right-clicked on in the table of contents
            // m_MapControl.CustomProperty was set in frmMain.axTOCControl1_OnMouseDown
            INALayer naLayer = (INALayer)m_mapControl.CustomProperty;
            INAContext naContext = naLayer.Context;

            // Set the active Analysis layer
            if (naWindow.ActiveAnalysis != naLayer)
                naWindow.ActiveAnalysis = naLayer;

            // Remember what the current category is
            IEngineNAWindowCategory currentCategory = naWindow.ActiveCategory;

            // Loop through deleting all the items from all the categories
            INamedSet naClasses = naContext.NAClasses;
            for (int i = 0; i < naClasses.Count; i++)
            {
                IEngineNAWindowCategory category = naWindow.get_CategoryByNAClassName(naClasses.get_Name(i));
                naWindow.ActiveCategory = category;
                naHelper.DeleteAllNetworkLocations();
            }

            //Reset to the original category
            naWindow.ActiveCategory = currentCategory;

            m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, m_mapControl.Extent);
        }

        #endregion
    }
}
