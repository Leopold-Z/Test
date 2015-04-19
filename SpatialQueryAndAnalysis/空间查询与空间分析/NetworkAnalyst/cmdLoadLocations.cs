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
    [Guid("c901a79b-edf8-4322-8123-b14d1124924e")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialQueryAndAnalysis.NetworkAnalyst.cmdLoadLocations")]
    public sealed class cmdLoadLocations : BaseCommand
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

        private IMapControl3 m_mapControl;
        private IEngineNetworkAnalystEnvironment m_naEnv;
        public cmdLoadLocations()
        {
            base.m_caption = "Load Locations...";
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        /// 

        public override bool Enabled
        {
            get
            {
                // Enabled if the active category is an input NAClass

                IEngineNAWindowCategory naWindowCategory = m_naEnv.NAWindow.ActiveCategory;
                if (naWindowCategory == null)
                    return false;

                INAClass naClass = naWindowCategory.NAClass;
                if (naClass == null)
                    return false;

                INAClassDefinition naClassDefinition = naClass.ClassDefinition;
                if (naClassDefinition == null)
                    return false;

                return naClassDefinition.IsInput;
            }
        }


        public override void OnCreate(object hook)
        {
            IHookHelper hookhelper = new HookHelperClass();
            if (hook != null)
            {
                hookhelper.Hook = hook;

                m_mapControl = (IMapControl3)hookhelper.Hook;

                // Get the Network Analyst Env
                m_naEnv = new EngineNetworkAnalystEnvironmentClass();
            }
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // Get the NALayer and corresponding NAContext of the layer that
            // was right-clicked on in the table of contents
            // m_MapControl.CustomProperty was set in frmMain.axTOCControl1_OnMouseDown
            INALayer naLayer = (INALayer)m_mapControl.CustomProperty;

            // Set the Active Analysis layer to be the layer right-clicked on
            m_naEnv.NAWindow.ActiveAnalysis = naLayer;

            if (!Enabled)
                return;

            // Show the Property Page form for Network Analyst
            frmLoadLocation loadLocations = new frmLoadLocation();
            if (loadLocations.ShowModal(m_mapControl, m_naEnv))
            {
                // notify that the context has changed because we have added locations to a NAClass within it
                INAContextEdit contextEdit = m_naEnv.NAWindow.ActiveAnalysis.Context as INAContextEdit;
                contextEdit.ContextChanged();

                // If loaded locations, refresh the NAWindow and the Screen
                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, m_mapControl.Extent);
                m_naEnv.NAWindow.UpdateContent(m_naEnv.NAWindow.ActiveCategory);
            }
        }

        #endregion
    }
}
