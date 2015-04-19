using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS;
using ESRI.ArcGIS.esriSystem;

namespace SpatialQueryAndAnalysis
{
    static class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new SpatialQueryAndAnalysis.LicenseInitializer();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code.
            m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine },
            new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RuntimeManager.Bind(ProductCode.EngineOrDesktop);
            Application.Run(new MainForm());
            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
            m_AOLicenseInitializer.ShutdownApplication();
        }
    }
}