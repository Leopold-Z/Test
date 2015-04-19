namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class SpatialExtentQuery
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
            this.btnAttributes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.chklstLayers = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGeometryType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSpatialRelationship = new System.Windows.Forms.ComboBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.grpQueryGeom = new System.Windows.Forms.GroupBox();
            this.rdoDrawGeom = new System.Windows.Forms.RadioButton();
            this.rdoSelGeom = new System.Windows.Forms.RadioButton();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.grpActionType = new System.Windows.Forms.GroupBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoDataGridView = new System.Windows.Forms.RadioButton();
            this.grpFearuesContents = new System.Windows.Forms.GroupBox();
            this.rdoSelectedFeatures = new System.Windows.Forms.RadioButton();
            this.rdoAllFeatures = new System.Windows.Forms.RadioButton();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.grpQueryGeom.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.grpActionType.SuspendLayout();
            this.grpFearuesContents.SuspendLayout();
            this.grpInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAttributes
            // 
            this.btnAttributes.Location = new System.Drawing.Point(237, 546);
            this.btnAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttributes.Name = "btnAttributes";
            this.btnAttributes.Size = new System.Drawing.Size(85, 29);
            this.btnAttributes.TabIndex = 22;
            this.btnAttributes.Text = "属性表";
            this.btnAttributes.UseVisualStyleBackColor = true;
            this.btnAttributes.Click += new System.EventHandler(this.btnAttributes_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(381, 546);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "关 闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.chklstLayers);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cboGeometryType);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cboSpatialRelationship);
            this.flowLayoutPanel1.Controls.Add(this.txtDistance);
            this.flowLayoutPanel1.Controls.Add(this.grpQueryGeom);
            this.flowLayoutPanel1.Controls.Add(this.grpAttributes);
            this.flowLayoutPanel1.Controls.Add(this.grpInformation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(537, 509);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "选择要查询的要素类：";
            // 
            // chklstLayers
            // 
            this.chklstLayers.CheckOnClick = true;
            this.chklstLayers.FormattingEnabled = true;
            this.chklstLayers.Location = new System.Drawing.Point(169, 4);
            this.chklstLayers.Margin = new System.Windows.Forms.Padding(4);
            this.chklstLayers.Name = "chklstLayers";
            this.chklstLayers.Size = new System.Drawing.Size(323, 144);
            this.chklstLayers.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "选择几何形状类型：  ";
            // 
            // cboGeometryType
            // 
            this.cboGeometryType.FormattingEnabled = true;
            this.cboGeometryType.Items.AddRange(new object[] {
            "点",
            "线",
            "矩形",
            "圆",
            "多边形"});
            this.cboGeometryType.Location = new System.Drawing.Point(170, 156);
            this.cboGeometryType.Margin = new System.Windows.Forms.Padding(4);
            this.cboGeometryType.Name = "cboGeometryType";
            this.cboGeometryType.Size = new System.Drawing.Size(323, 23);
            this.cboGeometryType.TabIndex = 8;
            this.cboGeometryType.SelectedIndexChanged += new System.EventHandler(this.cboGeometryType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "选择空间关系：      ";
            // 
            // cboSpatialRelationship
            // 
            this.cboSpatialRelationship.FormattingEnabled = true;
            this.cboSpatialRelationship.Items.AddRange(new object[] {
            "INTERSECT",
            "WITHIN_A_DISTANCE",
            "COMPLETELY_CONTAINS",
            "COMPLETELY_WITHIN",
            "HAVE_THEIR_CENTER_IN",
            "SHARE_A_LINE_SEGMENT_WITH",
            "BOUNDARY_TOUCHES",
            "ARE_IDENTICAL_TO",
            "CROSS_BY_THE_OUTLINE_OF",
            "CONTAINS",
            "CONTAINED_BY"});
            this.cboSpatialRelationship.Location = new System.Drawing.Point(172, 187);
            this.cboSpatialRelationship.Margin = new System.Windows.Forms.Padding(4);
            this.cboSpatialRelationship.Name = "cboSpatialRelationship";
            this.cboSpatialRelationship.Size = new System.Drawing.Size(231, 23);
            this.cboSpatialRelationship.TabIndex = 16;
            this.cboSpatialRelationship.SelectedIndexChanged += new System.EventHandler(this.cboSpatialRelationship_SelectedIndexChanged);
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(411, 187);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(4);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(83, 25);
            this.txtDistance.TabIndex = 18;
            this.txtDistance.Visible = false;
            // 
            // grpQueryGeom
            // 
            this.grpQueryGeom.Controls.Add(this.rdoDrawGeom);
            this.grpQueryGeom.Controls.Add(this.rdoSelGeom);
            this.grpQueryGeom.Location = new System.Drawing.Point(4, 220);
            this.grpQueryGeom.Margin = new System.Windows.Forms.Padding(4);
            this.grpQueryGeom.Name = "grpQueryGeom";
            this.grpQueryGeom.Padding = new System.Windows.Forms.Padding(4);
            this.grpQueryGeom.Size = new System.Drawing.Size(499, 52);
            this.grpQueryGeom.TabIndex = 17;
            this.grpQueryGeom.TabStop = false;
            this.grpQueryGeom.Text = "用于查询的几何形状";
            // 
            // rdoDrawGeom
            // 
            this.rdoDrawGeom.AutoSize = true;
            this.rdoDrawGeom.Checked = true;
            this.rdoDrawGeom.Location = new System.Drawing.Point(333, 25);
            this.rdoDrawGeom.Margin = new System.Windows.Forms.Padding(4);
            this.rdoDrawGeom.Name = "rdoDrawGeom";
            this.rdoDrawGeom.Size = new System.Drawing.Size(118, 19);
            this.rdoDrawGeom.TabIndex = 1;
            this.rdoDrawGeom.TabStop = true;
            this.rdoDrawGeom.Text = "绘制几何形状";
            this.rdoDrawGeom.UseVisualStyleBackColor = true;
            this.rdoDrawGeom.Click += new System.EventHandler(this.rdoDrawGeom_Click);
            // 
            // rdoSelGeom
            // 
            this.rdoSelGeom.AutoSize = true;
            this.rdoSelGeom.Location = new System.Drawing.Point(85, 25);
            this.rdoSelGeom.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSelGeom.Name = "rdoSelGeom";
            this.rdoSelGeom.Size = new System.Drawing.Size(118, 19);
            this.rdoSelGeom.TabIndex = 0;
            this.rdoSelGeom.Text = "选择几何形状";
            this.rdoSelGeom.UseVisualStyleBackColor = true;
            this.rdoSelGeom.Click += new System.EventHandler(this.rdoSelGeom_Click);
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.grpActionType);
            this.grpAttributes.Controls.Add(this.grpFearuesContents);
            this.grpAttributes.Location = new System.Drawing.Point(4, 280);
            this.grpAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Padding = new System.Windows.Forms.Padding(4);
            this.grpAttributes.Size = new System.Drawing.Size(499, 99);
            this.grpAttributes.TabIndex = 9;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "属性显示与打印";
            // 
            // grpActionType
            // 
            this.grpActionType.Controls.Add(this.rdoReport);
            this.grpActionType.Controls.Add(this.rdoDataGridView);
            this.grpActionType.Location = new System.Drawing.Point(265, 25);
            this.grpActionType.Margin = new System.Windows.Forms.Padding(4);
            this.grpActionType.Name = "grpActionType";
            this.grpActionType.Padding = new System.Windows.Forms.Padding(4);
            this.grpActionType.Size = new System.Drawing.Size(229, 61);
            this.grpActionType.TabIndex = 2;
            this.grpActionType.TabStop = false;
            this.grpActionType.Text = "操作方式";
            // 
            // rdoReport
            // 
            this.rdoReport.AutoSize = true;
            this.rdoReport.Checked = true;
            this.rdoReport.Location = new System.Drawing.Point(127, 25);
            this.rdoReport.Margin = new System.Windows.Forms.Padding(4);
            this.rdoReport.Name = "rdoReport";
            this.rdoReport.Size = new System.Drawing.Size(88, 19);
            this.rdoReport.TabIndex = 1;
            this.rdoReport.TabStop = true;
            this.rdoReport.Text = "属性报表";
            this.rdoReport.UseVisualStyleBackColor = true;
            this.rdoReport.CheckedChanged += new System.EventHandler(this.rdoReport_CheckedChanged);
            // 
            // rdoDataGridView
            // 
            this.rdoDataGridView.AutoSize = true;
            this.rdoDataGridView.Location = new System.Drawing.Point(9, 25);
            this.rdoDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.rdoDataGridView.Name = "rdoDataGridView";
            this.rdoDataGridView.Size = new System.Drawing.Size(103, 19);
            this.rdoDataGridView.TabIndex = 0;
            this.rdoDataGridView.Text = "普通属性表";
            this.rdoDataGridView.UseVisualStyleBackColor = true;
            // 
            // grpFearuesContents
            // 
            this.grpFearuesContents.Controls.Add(this.rdoSelectedFeatures);
            this.grpFearuesContents.Controls.Add(this.rdoAllFeatures);
            this.grpFearuesContents.Location = new System.Drawing.Point(9, 25);
            this.grpFearuesContents.Margin = new System.Windows.Forms.Padding(4);
            this.grpFearuesContents.Name = "grpFearuesContents";
            this.grpFearuesContents.Padding = new System.Windows.Forms.Padding(4);
            this.grpFearuesContents.Size = new System.Drawing.Size(251, 61);
            this.grpFearuesContents.TabIndex = 2;
            this.grpFearuesContents.TabStop = false;
            this.grpFearuesContents.Text = "要素范围";
            // 
            // rdoSelectedFeatures
            // 
            this.rdoSelectedFeatures.AutoSize = true;
            this.rdoSelectedFeatures.Checked = true;
            this.rdoSelectedFeatures.Location = new System.Drawing.Point(115, 25);
            this.rdoSelectedFeatures.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSelectedFeatures.Name = "rdoSelectedFeatures";
            this.rdoSelectedFeatures.Size = new System.Drawing.Size(118, 19);
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
            this.rdoAllFeatures.Margin = new System.Windows.Forms.Padding(4);
            this.rdoAllFeatures.Name = "rdoAllFeatures";
            this.rdoAllFeatures.Size = new System.Drawing.Size(88, 19);
            this.rdoAllFeatures.TabIndex = 0;
            this.rdoAllFeatures.Text = "全部要素";
            this.rdoAllFeatures.UseVisualStyleBackColor = true;
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.txtMessages);
            this.grpInformation.Location = new System.Drawing.Point(4, 387);
            this.grpInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpInformation.Size = new System.Drawing.Size(499, 198);
            this.grpInformation.TabIndex = 8;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "操作信息";
            // 
            // txtMessages
            // 
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(4, 22);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(491, 172);
            this.txtMessages.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(79, 546);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 29);
            this.btnQuery.TabIndex = 20;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // SpatialExtentQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(571, 582);
            this.Controls.Add(this.btnAttributes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnQuery);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpatialExtentQuery";
            this.Text = "空间位置、空间关系查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SpatialExtentQuery_FormClosed);
            this.Load += new System.EventHandler(this.SpatialExtentQuery_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grpQueryGeom.ResumeLayout(false);
            this.grpQueryGeom.PerformLayout();
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

        private System.Windows.Forms.Button btnAttributes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chklstLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGeometryType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSpatialRelationship;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.GroupBox grpQueryGeom;
        private System.Windows.Forms.RadioButton rdoDrawGeom;
        private System.Windows.Forms.RadioButton rdoSelGeom;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.GroupBox grpActionType;
        private System.Windows.Forms.RadioButton rdoReport;
        private System.Windows.Forms.RadioButton rdoDataGridView;
        private System.Windows.Forms.GroupBox grpFearuesContents;
        private System.Windows.Forms.RadioButton rdoSelectedFeatures;
        private System.Windows.Forms.RadioButton rdoAllFeatures;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnQuery;
    }
}