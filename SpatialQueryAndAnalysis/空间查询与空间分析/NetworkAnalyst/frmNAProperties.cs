using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;

namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    public partial class frmNAProperties : Form
    {
        bool m_okClicked;

        public frmNAProperties()
        {
            InitializeComponent();
        }
        public bool ShowModal(IEngineNetworkAnalystEnvironment naEnv)
        {
            m_okClicked = false;

            // Zoom to result after solve or not
            chkZoomToResultAfterSolve.Checked = naEnv.ZoomToResultAfterSolve;

            // Set the radio button based on the value in ShowAnalysisMessagesAfterSolve.
            // This is a bit property where multiple values are possible.  
            // Simplify it for the user so assume message types build on each other.  
            //  For example, if you want info, you probably want warnings and errors too
            //   No Messages = 0
            //   Errors = esriEngineNAMessageTypeError
            //   Errors and warnings = esriEngineNAMessageTypeError & esriEngineNAMessageTypeWarning
            //   All = esriEngineNAMessageTypeError & esriEngineNAMessageTypeWarning & esriEngineNAMessageTypeInformative
            if ((esriEngineNAMessageType)(naEnv.ShowAnalysisMessagesAfterSolve & (int)esriEngineNAMessageType.esriEngineNAMessageTypeInformative) == esriEngineNAMessageType.esriEngineNAMessageTypeInformative)
                rdoAllMessages.Checked = true;
            else if ((esriEngineNAMessageType)(naEnv.ShowAnalysisMessagesAfterSolve & (int)esriEngineNAMessageType.esriEngineNAMessageTypeWarning) == esriEngineNAMessageType.esriEngineNAMessageTypeWarning)
                rdoErrorsAndWarnings.Checked = true;
            else if ((esriEngineNAMessageType)(naEnv.ShowAnalysisMessagesAfterSolve & (int)esriEngineNAMessageType.esriEngineNAMessageTypeError) == esriEngineNAMessageType.esriEngineNAMessageTypeError)
                rdoErrors.Checked = true;
            else
                rdoNoMessages.Checked = true;

            this.ShowDialog();
            if (m_okClicked)
            {
                // Set ZoomToResultAfterSolve
                naEnv.ZoomToResultAfterSolve = chkZoomToResultAfterSolve.Checked;

                // Set ShowAnalysisMessagesAfterSolve
                // Use simplified version so higher severity errors also show lower severity "info" and "warnings"
                if (rdoAllMessages.Checked)
                    naEnv.ShowAnalysisMessagesAfterSolve = (int)esriEngineNAMessageType.esriEngineNAMessageTypeInformative + (int)esriEngineNAMessageType.esriEngineNAMessageTypeWarning + (int)esriEngineNAMessageType.esriEngineNAMessageTypeError;
                else if (rdoErrorsAndWarnings.Checked)
                    naEnv.ShowAnalysisMessagesAfterSolve = (int)esriEngineNAMessageType.esriEngineNAMessageTypeWarning + (int)esriEngineNAMessageType.esriEngineNAMessageTypeError;
                else if (rdoErrors.Checked)
                    naEnv.ShowAnalysisMessagesAfterSolve = (int)esriEngineNAMessageType.esriEngineNAMessageTypeError;
                else
                    naEnv.ShowAnalysisMessagesAfterSolve = 0;
            }

            return m_okClicked;
        }
        private void frmNAProperties_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_okClicked = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_okClicked = false;
            this.Close();
        }
    }
}
