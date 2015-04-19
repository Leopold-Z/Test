namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class OverlayAnalysis
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOveralyerType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSelectInputLayer = new System.Windows.Forms.ComboBox();
            this.lblInputLevel = new System.Windows.Forms.Label();
            this.numUpDownInputLevel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOverlayLayer = new System.Windows.Forms.ComboBox();
            this.lblOverlayLevel = new System.Windows.Forms.Label();
            this.numUpDownOverlayLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.lblAttributeType = new System.Windows.Forms.Label();
            this.cboAttributeType = new System.Windows.Forms.ComboBox();
            this.lblFeatureType = new System.Windows.Forms.Label();
            this.cboFeatureType = new System.Windows.Forms.ComboBox();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.grpActionType = new System.Windows.Forms.GroupBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoDataGridView = new System.Windows.Forms.RadioButton();
            this.grpFearuesContents = new System.Windows.Forms.GroupBox();
            this.rdoSelectedFeatures = new System.Windows.Forms.RadioButton();
            this.rdoAllFeatures = new System.Windows.Forms.RadioButton();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAttributes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOverlay = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownInputLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownOverlayLevel)).BeginInit();
            this.grpAttributes.SuspendLayout();
            this.grpActionType.SuspendLayout();
            this.grpFearuesContents.SuspendLayout();
            this.grpInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.cboOveralyerType);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cboSelectInputLayer);
            this.flowLayoutPanel1.Controls.Add(this.lblInputLevel);
            this.flowLayoutPanel1.Controls.Add(this.numUpDownInputLevel);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cboOverlayLayer);
            this.flowLayoutPanel1.Controls.Add(this.lblOverlayLevel);
            this.flowLayoutPanel1.Controls.Add(this.numUpDownOverlayLevel);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtTolerance);
            this.flowLayoutPanel1.Controls.Add(this.lblAttributeType);
            this.flowLayoutPanel1.Controls.Add(this.cboAttributeType);
            this.flowLayoutPanel1.Controls.Add(this.lblFeatureType);
            this.flowLayoutPanel1.Controls.Add(this.cboFeatureType);
            this.flowLayoutPanel1.Controls.Add(this.grpAttributes);
            this.flowLayoutPanel1.Controls.Add(this.grpInformation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 26);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(395, 445);
            this.flowLayoutPanel1.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "选择叠置分析类型：";
            // 
            // cboOveralyerType
            // 
            this.cboOveralyerType.FormattingEnabled = true;
            this.cboOveralyerType.Items.AddRange(new object[] {
            "求交叠置",
            "求和叠置",
            "擦除叠置",
            "同一性叠置",
            "更新叠置",
            "异或叠置"});
            this.cboOveralyerType.Location = new System.Drawing.Point(154, 4);
            this.cboOveralyerType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboOveralyerType.Name = "cboOveralyerType";
            this.cboOveralyerType.Size = new System.Drawing.Size(197, 23);
            this.cboOveralyerType.TabIndex = 31;
            this.cboOveralyerType.SelectedIndexChanged += new System.EventHandler(this.cboOveralyerType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "选择输入图层：    ";
            // 
            // cboSelectInputLayer
            // 
            this.cboSelectInputLayer.FormattingEnabled = true;
            this.cboSelectInputLayer.Location = new System.Drawing.Point(156, 35);
            this.cboSelectInputLayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSelectInputLayer.Name = "cboSelectInputLayer";
            this.cboSelectInputLayer.Size = new System.Drawing.Size(197, 23);
            this.cboSelectInputLayer.TabIndex = 10;
            this.cboSelectInputLayer.SelectedIndexChanged += new System.EventHandler(this.cboSelectInputLayer_SelectedIndexChanged);
            // 
            // lblInputLevel
            // 
            this.lblInputLevel.AutoSize = true;
            this.lblInputLevel.Location = new System.Drawing.Point(4, 62);
            this.lblInputLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputLevel.Name = "lblInputLevel";
            this.lblInputLevel.Size = new System.Drawing.Size(142, 15);
            this.lblInputLevel.TabIndex = 9;
            this.lblInputLevel.Text = "输入图层精度等级：";
            // 
            // numUpDownInputLevel
            // 
            this.numUpDownInputLevel.Location = new System.Drawing.Point(154, 66);
            this.numUpDownInputLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numUpDownInputLevel.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDownInputLevel.Name = "numUpDownInputLevel";
            this.numUpDownInputLevel.Size = new System.Drawing.Size(200, 25);
            this.numUpDownInputLevel.TabIndex = 33;
            this.numUpDownInputLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownInputLevel.ValueChanged += new System.EventHandler(this.numUpDownInputLevel_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "选择叠置图层：    ";
            // 
            // cboOverlayLayer
            // 
            this.cboOverlayLayer.FormattingEnabled = true;
            this.cboOverlayLayer.Location = new System.Drawing.Point(156, 99);
            this.cboOverlayLayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboOverlayLayer.Name = "cboOverlayLayer";
            this.cboOverlayLayer.Size = new System.Drawing.Size(197, 23);
            this.cboOverlayLayer.TabIndex = 10;
            this.cboOverlayLayer.SelectedIndexChanged += new System.EventHandler(this.cboOverlayLayer_SelectedIndexChanged);
            // 
            // lblOverlayLevel
            // 
            this.lblOverlayLevel.AutoSize = true;
            this.lblOverlayLevel.Location = new System.Drawing.Point(4, 126);
            this.lblOverlayLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOverlayLevel.Name = "lblOverlayLevel";
            this.lblOverlayLevel.Size = new System.Drawing.Size(142, 15);
            this.lblOverlayLevel.TabIndex = 9;
            this.lblOverlayLevel.Text = "叠置图层精度等级：";
            // 
            // numUpDownOverlayLevel
            // 
            this.numUpDownOverlayLevel.Location = new System.Drawing.Point(154, 130);
            this.numUpDownOverlayLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numUpDownOverlayLevel.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDownOverlayLevel.Name = "numUpDownOverlayLevel";
            this.numUpDownOverlayLevel.Size = new System.Drawing.Size(200, 25);
            this.numUpDownOverlayLevel.TabIndex = 33;
            this.numUpDownOverlayLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownOverlayLevel.ValueChanged += new System.EventHandler(this.numUpDownOverlayLevel_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "设置容差：        ";
            // 
            // txtTolerance
            // 
            this.txtTolerance.Location = new System.Drawing.Point(158, 163);
            this.txtTolerance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.Size = new System.Drawing.Size(197, 25);
            this.txtTolerance.TabIndex = 32;
            this.txtTolerance.TextChanged += new System.EventHandler(this.txtTolerance_TextChanged);
            // 
            // lblAttributeType
            // 
            this.lblAttributeType.AutoSize = true;
            this.lblAttributeType.Location = new System.Drawing.Point(4, 192);
            this.lblAttributeType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttributeType.Name = "lblAttributeType";
            this.lblAttributeType.Size = new System.Drawing.Size(142, 15);
            this.lblAttributeType.TabIndex = 19;
            this.lblAttributeType.Text = "选择属性输出类型：";
            // 
            // cboAttributeType
            // 
            this.cboAttributeType.FormattingEnabled = true;
            this.cboAttributeType.Items.AddRange(new object[] {
            "所有属性",
            "不包括FID",
            "仅包括FID"});
            this.cboAttributeType.Location = new System.Drawing.Point(154, 196);
            this.cboAttributeType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboAttributeType.Name = "cboAttributeType";
            this.cboAttributeType.Size = new System.Drawing.Size(197, 23);
            this.cboAttributeType.TabIndex = 10;
            this.cboAttributeType.SelectedIndexChanged += new System.EventHandler(this.cboAttributeType_SelectedIndexChanged);
            // 
            // lblFeatureType
            // 
            this.lblFeatureType.AutoSize = true;
            this.lblFeatureType.Location = new System.Drawing.Point(4, 223);
            this.lblFeatureType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeatureType.Name = "lblFeatureType";
            this.lblFeatureType.Size = new System.Drawing.Size(142, 15);
            this.lblFeatureType.TabIndex = 19;
            this.lblFeatureType.Text = "选择要素输出类型：";
            // 
            // cboFeatureType
            // 
            this.cboFeatureType.FormattingEnabled = true;
            this.cboFeatureType.Items.AddRange(new object[] {
            "根据输入要素确定",
            "线",
            "点"});
            this.cboFeatureType.Location = new System.Drawing.Point(154, 227);
            this.cboFeatureType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboFeatureType.Name = "cboFeatureType";
            this.cboFeatureType.Size = new System.Drawing.Size(197, 23);
            this.cboFeatureType.TabIndex = 10;
            this.cboFeatureType.SelectedIndexChanged += new System.EventHandler(this.cboFeatureType_SelectedIndexChanged);
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.grpActionType);
            this.grpAttributes.Controls.Add(this.grpFearuesContents);
            this.grpAttributes.Location = new System.Drawing.Point(4, 258);
            this.grpAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAttributes.Size = new System.Drawing.Size(357, 111);
            this.grpAttributes.TabIndex = 26;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "属性显示与打印";
            // 
            // grpActionType
            // 
            this.grpActionType.Controls.Add(this.rdoReport);
            this.grpActionType.Controls.Add(this.rdoDataGridView);
            this.grpActionType.Location = new System.Drawing.Point(193, 22);
            this.grpActionType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpActionType.Name = "grpActionType";
            this.grpActionType.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpActionType.Size = new System.Drawing.Size(147, 79);
            this.grpActionType.TabIndex = 2;
            this.grpActionType.TabStop = false;
            this.grpActionType.Text = "操作方式";
            // 
            // rdoReport
            // 
            this.rdoReport.AutoSize = true;
            this.rdoReport.Checked = true;
            this.rdoReport.Location = new System.Drawing.Point(12, 49);
            this.rdoReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoReport.Name = "rdoReport";
            this.rdoReport.Size = new System.Drawing.Size(117, 24);
            this.rdoReport.TabIndex = 1;
            this.rdoReport.TabStop = true;
            this.rdoReport.Text = "属性报表";
            this.rdoReport.UseVisualStyleBackColor = true;
            this.rdoReport.CheckedChanged += new System.EventHandler(this.rdoReport_CheckedChanged);
            // 
            // rdoDataGridView
            // 
            this.rdoDataGridView.AutoSize = true;
            this.rdoDataGridView.Location = new System.Drawing.Point(12, 25);
            this.rdoDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoDataGridView.Name = "rdoDataGridView";
            this.rdoDataGridView.Size = new System.Drawing.Size(137, 24);
            this.rdoDataGridView.TabIndex = 0;
            this.rdoDataGridView.Text = "普通属性表";
            this.rdoDataGridView.UseVisualStyleBackColor = true;
            // 
            // grpFearuesContents
            // 
            this.grpFearuesContents.Controls.Add(this.rdoSelectedFeatures);
            this.grpFearuesContents.Controls.Add(this.rdoAllFeatures);
            this.grpFearuesContents.Location = new System.Drawing.Point(16, 22);
            this.grpFearuesContents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFearuesContents.Name = "grpFearuesContents";
            this.grpFearuesContents.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFearuesContents.Size = new System.Drawing.Size(160, 79);
            this.grpFearuesContents.TabIndex = 2;
            this.grpFearuesContents.TabStop = false;
            this.grpFearuesContents.Text = "要素范围";
            // 
            // rdoSelectedFeatures
            // 
            this.rdoSelectedFeatures.AutoSize = true;
            this.rdoSelectedFeatures.Checked = true;
            this.rdoSelectedFeatures.Location = new System.Drawing.Point(12, 49);
            this.rdoSelectedFeatures.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoSelectedFeatures.Name = "rdoSelectedFeatures";
            this.rdoSelectedFeatures.Size = new System.Drawing.Size(157, 24);
            this.rdoSelectedFeatures.TabIndex = 1;
            this.rdoSelectedFeatures.TabStop = true;
            this.rdoSelectedFeatures.Text = "仅选择的要素";
            this.rdoSelectedFeatures.UseVisualStyleBackColor = true;
            this.rdoSelectedFeatures.CheckedChanged += new System.EventHandler(this.rdoSelectedFeatures_CheckedChanged);
            // 
            // rdoAllFeatures
            // 
            this.rdoAllFeatures.AutoSize = true;
            this.rdoAllFeatures.Location = new System.Drawing.Point(12, 25);
            this.rdoAllFeatures.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoAllFeatures.Name = "rdoAllFeatures";
            this.rdoAllFeatures.Size = new System.Drawing.Size(117, 24);
            this.rdoAllFeatures.TabIndex = 0;
            this.rdoAllFeatures.Text = "全部要素";
            this.rdoAllFeatures.UseVisualStyleBackColor = true;
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.txtMessages);
            this.grpInformation.Location = new System.Drawing.Point(4, 377);
            this.grpInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInformation.Size = new System.Drawing.Size(357, 210);
            this.grpInformation.TabIndex = 25;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "操作信息";
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(4, 26);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(348, 179);
            this.txtMessages.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 484);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 29);
            this.button1.TabIndex = 39;
            this.button1.Text = "设置输出路径";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAttributes
            // 
            this.btnAttributes.Location = new System.Drawing.Point(239, 484);
            this.btnAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAttributes.Name = "btnAttributes";
            this.btnAttributes.Size = new System.Drawing.Size(80, 29);
            this.btnAttributes.TabIndex = 36;
            this.btnAttributes.Text = "属性表";
            this.btnAttributes.UseVisualStyleBackColor = true;
            this.btnAttributes.Click += new System.EventHandler(this.btnAttributes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 484);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 29);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "关  闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOverlay
            // 
            this.btnOverlay.Location = new System.Drawing.Point(145, 484);
            this.btnOverlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOverlay.Name = "btnOverlay";
            this.btnOverlay.Size = new System.Drawing.Size(85, 29);
            this.btnOverlay.TabIndex = 37;
            this.btnOverlay.Text = "叠置分析";
            this.btnOverlay.UseVisualStyleBackColor = true;
            this.btnOverlay.Click += new System.EventHandler(this.btnOverlay_Click);
            // 
            // OverlayAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(432, 528);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAttributes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOverlay);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OverlayAnalysis";
            this.Text = "空间叠置分析";
            this.Load += new System.EventHandler(this.OverlayAnalysis_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownInputLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownOverlayLevel)).EndInit();
            this.grpAttributes.ResumeLayout(false);
            this.grpActionType.ResumeLayout(false);
            this.grpActionType.PerformLayout();
            this.grpFearuesContents.ResumeLayout(false);
            this.grpFearuesContents.PerformLayout();
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOveralyerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSelectInputLayer;
        private System.Windows.Forms.Label lblInputLevel;
        private System.Windows.Forms.NumericUpDown numUpDownInputLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOverlayLayer;
        private System.Windows.Forms.Label lblOverlayLevel;
        private System.Windows.Forms.NumericUpDown numUpDownOverlayLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.Label lblAttributeType;
        private System.Windows.Forms.ComboBox cboAttributeType;
        private System.Windows.Forms.Label lblFeatureType;
        private System.Windows.Forms.ComboBox cboFeatureType;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.GroupBox grpActionType;
        private System.Windows.Forms.RadioButton rdoReport;
        private System.Windows.Forms.RadioButton rdoDataGridView;
        private System.Windows.Forms.GroupBox grpFearuesContents;
        private System.Windows.Forms.RadioButton rdoSelectedFeatures;
        private System.Windows.Forms.RadioButton rdoAllFeatures;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAttributes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOverlay;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}