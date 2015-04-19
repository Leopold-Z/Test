namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    partial class frmLoadLocation
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkUseSelection = new System.Windows.Forms.CheckBox();
            this.lblInputData = new System.Windows.Forms.Label();
            this.cboInputData = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(274, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(130, 49);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 34);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkUseSelection
            // 
            this.chkUseSelection.Location = new System.Drawing.Point(16, 48);
            this.chkUseSelection.Name = "chkUseSelection";
            this.chkUseSelection.Size = new System.Drawing.Size(503, 17);
            this.chkUseSelection.TabIndex = 9;
            this.chkUseSelection.Text = "Use Selection";
            // 
            // lblInputData
            // 
            this.lblInputData.Location = new System.Drawing.Point(12, 19);
            this.lblInputData.Name = "lblInputData";
            this.lblInputData.Size = new System.Drawing.Size(77, 26);
            this.lblInputData.TabIndex = 8;
            this.lblInputData.Text = "Input Data";
            // 
            // cboInputData
            // 
            this.cboInputData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInputData.Location = new System.Drawing.Point(96, 16);
            this.cboInputData.Name = "cboInputData";
            this.cboInputData.Size = new System.Drawing.Size(388, 20);
            this.cboInputData.TabIndex = 7;
            this.cboInputData.SelectedIndexChanged += new System.EventHandler(this.cboInputData_SelectedIndexChanged);
            // 
            // frmLoadLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 95);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkUseSelection);
            this.Controls.Add(this.lblInputData);
            this.Controls.Add(this.cboInputData);
            this.Name = "frmLoadLocation";
            this.Text = "Load Locations";
            this.Load += new System.EventHandler(this.frmLoadLocation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkUseSelection;
        private System.Windows.Forms.Label lblInputData;
        private System.Windows.Forms.ComboBox cboInputData;
    }
}