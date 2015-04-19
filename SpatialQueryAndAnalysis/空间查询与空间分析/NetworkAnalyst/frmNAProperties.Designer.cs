namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    partial class frmNAProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMessages = new System.Windows.Forms.GroupBox();
            this.rdoNoMessages = new System.Windows.Forms.RadioButton();
            this.rdoErrors = new System.Windows.Forms.RadioButton();
            this.rdoErrorsAndWarnings = new System.Windows.Forms.RadioButton();
            this.rdoAllMessages = new System.Windows.Forms.RadioButton();
            this.chkZoomToResultAfterSolve = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMessages
            // 
            this.grpMessages.Controls.Add(this.rdoNoMessages);
            this.grpMessages.Controls.Add(this.rdoErrors);
            this.grpMessages.Controls.Add(this.rdoErrorsAndWarnings);
            this.grpMessages.Controls.Add(this.rdoAllMessages);
            this.grpMessages.Location = new System.Drawing.Point(12, 76);
            this.grpMessages.Name = "grpMessages";
            this.grpMessages.Size = new System.Drawing.Size(403, 129);
            this.grpMessages.TabIndex = 10;
            this.grpMessages.TabStop = false;
            this.grpMessages.Text = "Messages";
            // 
            // rdoNoMessages
            // 
            this.rdoNoMessages.Location = new System.Drawing.Point(19, 95);
            this.rdoNoMessages.Name = "rdoNoMessages";
            this.rdoNoMessages.Size = new System.Drawing.Size(365, 26);
            this.rdoNoMessages.TabIndex = 3;
            this.rdoNoMessages.Text = "No Messages";
            // 
            // rdoErrors
            // 
            this.rdoErrors.Location = new System.Drawing.Point(19, 69);
            this.rdoErrors.Name = "rdoErrors";
            this.rdoErrors.Size = new System.Drawing.Size(365, 26);
            this.rdoErrors.TabIndex = 2;
            this.rdoErrors.Text = "Errors";
            // 
            // rdoErrorsAndWarnings
            // 
            this.rdoErrorsAndWarnings.Location = new System.Drawing.Point(19, 43);
            this.rdoErrorsAndWarnings.Name = "rdoErrorsAndWarnings";
            this.rdoErrorsAndWarnings.Size = new System.Drawing.Size(365, 26);
            this.rdoErrorsAndWarnings.TabIndex = 1;
            this.rdoErrorsAndWarnings.Text = "Errors and Warnings";
            // 
            // rdoAllMessages
            // 
            this.rdoAllMessages.Location = new System.Drawing.Point(19, 17);
            this.rdoAllMessages.Name = "rdoAllMessages";
            this.rdoAllMessages.Size = new System.Drawing.Size(365, 26);
            this.rdoAllMessages.TabIndex = 0;
            this.rdoAllMessages.Text = "All Messages";
            // 
            // chkZoomToResultAfterSolve
            // 
            this.chkZoomToResultAfterSolve.Location = new System.Drawing.Point(12, 24);
            this.chkZoomToResultAfterSolve.Name = "chkZoomToResultAfterSolve";
            this.chkZoomToResultAfterSolve.Size = new System.Drawing.Size(240, 26);
            this.chkZoomToResultAfterSolve.TabIndex = 9;
            this.chkZoomToResultAfterSolve.Text = "Zoom To Result After Solve";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 22);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(147, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 22);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmNAProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 274);
            this.Controls.Add(this.grpMessages);
            this.Controls.Add(this.chkZoomToResultAfterSolve);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmNAProperties";
            this.Text = "Network Analyst Properties";
            this.Load += new System.EventHandler(this.frmNAProperties_Load);
            this.grpMessages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMessages;
        private System.Windows.Forms.RadioButton rdoNoMessages;
        private System.Windows.Forms.RadioButton rdoErrors;
        private System.Windows.Forms.RadioButton rdoErrorsAndWarnings;
        private System.Windows.Forms.RadioButton rdoAllMessages;
        private System.Windows.Forms.CheckBox chkZoomToResultAfterSolve;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}