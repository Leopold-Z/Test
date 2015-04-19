namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class BufferQuery
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.chklstLayers = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGeometryType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSpatialRelationship = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.grpQueryGeom = new System.Windows.Forms.GroupBox();
            this.rdoDrawGeom = new System.Windows.Forms.RadioButton();
            this.rdoSelGeom = new System.Windows.Forms.RadioButton();
            this.grpPolygonbufferType = new System.Windows.Forms.GroupBox();
            this.rdoExtAndPolygon = new System.Windows.Forms.RadioButton();
            this.rdoIntForward = new System.Windows.Forms.RadioButton();
            this.rdoBndInt = new System.Windows.Forms.RadioButton();
            this.rdoBndExt = new System.Windows.Forms.RadioButton();
            this.rdoBndExtInt = new System.Windows.Forms.RadioButton();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.grpActionType = new System.Windows.Forms.GroupBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoDataGridView = new System.Windows.Forms.RadioButton();
            this.grpFearuesContents = new System.Windows.Forms.GroupBox();
            this.rdoSelectedFeatures = new System.Windows.Forms.RadioButton();
            this.rdoAllFeatures = new System.Windows.Forms.RadioButton();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBuffer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.grpQueryGeom.SuspendLayout();
            this.grpPolygonbufferType.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.grpActionType.SuspendLayout();
            this.grpFearuesContents.SuspendLayout();
            this.grpInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAttributes
            // 
            this.btnAttributes.Location = new System.Drawing.Point(181, 554);
            this.btnAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttributes.Name = "btnAttributes";
            this.btnAttributes.Size = new System.Drawing.Size(100, 29);
            this.btnAttributes.TabIndex = 33;
            this.btnAttributes.Text = "属性表";
            this.btnAttributes.UseVisualStyleBackColor = true;
            this.btnAttributes.Click += new System.EventHandler(this.btnAttributes_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.chklstLayers);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cboGeometryType);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.cboSpatialRelationship);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtDistance);
            this.flowLayoutPanel1.Controls.Add(this.grpQueryGeom);
            this.flowLayoutPanel1.Controls.Add(this.grpPolygonbufferType);
            this.flowLayoutPanel1.Controls.Add(this.grpAttributes);
            this.flowLayoutPanel1.Controls.Add(this.grpInformation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(425, 525);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "选择要查询的要素类：";
            // 
            // chklstLayers
            // 
            this.chklstLayers.CheckOnClick = true;
            this.chklstLayers.FormattingEnabled = true;
            this.chklstLayers.Location = new System.Drawing.Point(169, 4);
            this.chklstLayers.Margin = new System.Windows.Forms.Padding(4);
            this.chklstLayers.Name = "chklstLayers";
            this.chklstLayers.Size = new System.Drawing.Size(213, 144);
            this.chklstLayers.TabIndex = 28;
            this.chklstLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstLayers_ItemCheck);
            this.chklstLayers.SelectedIndexChanged += new System.EventHandler(this.chklstLayers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 9;
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
            this.cboGeometryType.Size = new System.Drawing.Size(213, 23);
            this.cboGeometryType.TabIndex = 10;
            this.cboGeometryType.SelectedIndexChanged += new System.EventHandler(this.cboGeometryType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "选择空间关系：      ";
            // 
            // cboSpatialRelationship
            // 
            this.cboSpatialRelationship.FormattingEnabled = true;
            this.cboSpatialRelationship.Items.AddRange(new object[] {
            "相交",
            "包含",
            "被包含"});
            this.cboSpatialRelationship.Location = new System.Drawing.Point(172, 187);
            this.cboSpatialRelationship.Margin = new System.Windows.Forms.Padding(4);
            this.cboSpatialRelationship.Name = "cboSpatialRelationship";
            this.cboSpatialRelationship.Size = new System.Drawing.Size(213, 23);
            this.cboSpatialRelationship.TabIndex = 31;
            this.cboSpatialRelationship.SelectedIndexChanged += new System.EventHandler(this.cboSpatialRelationship_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "输入缓冲距离：      ";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(172, 218);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(4);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(213, 25);
            this.txtDistance.TabIndex = 30;
            this.txtDistance.TextChanged += new System.EventHandler(this.txtDistance_TextChanged);
            // 
            // grpQueryGeom
            // 
            this.grpQueryGeom.Controls.Add(this.rdoDrawGeom);
            this.grpQueryGeom.Controls.Add(this.rdoSelGeom);
            this.grpQueryGeom.Location = new System.Drawing.Point(4, 251);
            this.grpQueryGeom.Margin = new System.Windows.Forms.Padding(4);
            this.grpQueryGeom.Name = "grpQueryGeom";
            this.grpQueryGeom.Padding = new System.Windows.Forms.Padding(4);
            this.grpQueryGeom.Size = new System.Drawing.Size(389, 74);
            this.grpQueryGeom.TabIndex = 19;
            this.grpQueryGeom.TabStop = false;
            this.grpQueryGeom.Text = "用于查询的几何形状";
            // 
            // rdoDrawGeom
            // 
            this.rdoDrawGeom.AutoSize = true;
            this.rdoDrawGeom.Checked = true;
            this.rdoDrawGeom.Location = new System.Drawing.Point(243, 35);
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
            this.rdoSelGeom.Location = new System.Drawing.Point(19, 35);
            this.rdoSelGeom.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSelGeom.Name = "rdoSelGeom";
            this.rdoSelGeom.Size = new System.Drawing.Size(118, 19);
            this.rdoSelGeom.TabIndex = 0;
            this.rdoSelGeom.Text = "选择几何形状";
            this.rdoSelGeom.UseVisualStyleBackColor = true;           
            this.rdoSelGeom.Click += new System.EventHandler(this.rdoSelGeom_Click);
            // 
            // grpPolygonbufferType
            // 
            this.grpPolygonbufferType.Controls.Add(this.rdoExtAndPolygon);
            this.grpPolygonbufferType.Controls.Add(this.rdoIntForward);
            this.grpPolygonbufferType.Controls.Add(this.rdoBndInt);
            this.grpPolygonbufferType.Controls.Add(this.rdoBndExt);
            this.grpPolygonbufferType.Controls.Add(this.rdoBndExtInt);
            this.grpPolygonbufferType.Location = new System.Drawing.Point(4, 333);
            this.grpPolygonbufferType.Margin = new System.Windows.Forms.Padding(4);
            this.grpPolygonbufferType.Name = "grpPolygonbufferType";
            this.grpPolygonbufferType.Padding = new System.Windows.Forms.Padding(4);
            this.grpPolygonbufferType.Size = new System.Drawing.Size(389, 106);
            this.grpPolygonbufferType.TabIndex = 22;
            this.grpPolygonbufferType.TabStop = false;
            this.grpPolygonbufferType.Text = "多边形缓冲类型";
            // 
            // rdoExtAndPolygon
            // 
            this.rdoExtAndPolygon.AutoSize = true;
            this.rdoExtAndPolygon.Checked = true;
            this.rdoExtAndPolygon.Location = new System.Drawing.Point(15, 79);
            this.rdoExtAndPolygon.Margin = new System.Windows.Forms.Padding(4);
            this.rdoExtAndPolygon.Name = "rdoExtAndPolygon";
            this.rdoExtAndPolygon.Size = new System.Drawing.Size(133, 19);
            this.rdoExtAndPolygon.TabIndex = 3;
            this.rdoExtAndPolygon.TabStop = true;
            this.rdoExtAndPolygon.Text = "普通多边形缓冲";
            this.rdoExtAndPolygon.UseVisualStyleBackColor = true;
            this.rdoExtAndPolygon.CheckedChanged += new System.EventHandler(this.rdoExtAndPolygon_CheckedChanged);
            // 
            // rdoIntForward
            // 
            this.rdoIntForward.AutoSize = true;
            this.rdoIntForward.Location = new System.Drawing.Point(213, 51);
            this.rdoIntForward.Margin = new System.Windows.Forms.Padding(4);
            this.rdoIntForward.Name = "rdoIntForward";
            this.rdoIntForward.Size = new System.Drawing.Size(118, 19);
            this.rdoIntForward.TabIndex = 2;
            this.rdoIntForward.Text = "多边形内缓冲";
            this.rdoIntForward.UseVisualStyleBackColor = true;
            this.rdoIntForward.CheckedChanged += new System.EventHandler(this.rdoIntForward_CheckedChanged);
            // 
            // rdoBndInt
            // 
            this.rdoBndInt.AutoSize = true;
            this.rdoBndInt.Location = new System.Drawing.Point(15, 51);
            this.rdoBndInt.Margin = new System.Windows.Forms.Padding(4);
            this.rdoBndInt.Name = "rdoBndInt";
            this.rdoBndInt.Size = new System.Drawing.Size(148, 19);
            this.rdoBndInt.TabIndex = 2;
            this.rdoBndInt.Text = "多边形边界内缓冲";
            this.rdoBndInt.UseVisualStyleBackColor = true;
            this.rdoBndInt.CheckedChanged += new System.EventHandler(this.rdoBndInt_CheckedChanged);
            // 
            // rdoBndExt
            // 
            this.rdoBndExt.AutoSize = true;
            this.rdoBndExt.Location = new System.Drawing.Point(213, 24);
            this.rdoBndExt.Margin = new System.Windows.Forms.Padding(4);
            this.rdoBndExt.Name = "rdoBndExt";
            this.rdoBndExt.Size = new System.Drawing.Size(148, 19);
            this.rdoBndExt.TabIndex = 1;
            this.rdoBndExt.Text = "多边形边界外缓冲";
            this.rdoBndExt.UseVisualStyleBackColor = true;
            this.rdoBndExt.CheckedChanged += new System.EventHandler(this.rdoBndExt_CheckedChanged);
            // 
            // rdoBndExtInt
            // 
            this.rdoBndExtInt.AutoSize = true;
            this.rdoBndExtInt.Location = new System.Drawing.Point(13, 24);
            this.rdoBndExtInt.Margin = new System.Windows.Forms.Padding(4);
            this.rdoBndExtInt.Name = "rdoBndExtInt";
            this.rdoBndExtInt.Size = new System.Drawing.Size(163, 19);
            this.rdoBndExtInt.TabIndex = 0;
            this.rdoBndExtInt.Text = "多边形边界内外缓冲";
            this.rdoBndExtInt.UseVisualStyleBackColor = true;
            this.rdoBndExtInt.CheckedChanged += new System.EventHandler(this.rdoBndExtInt_CheckedChanged);
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.grpActionType);
            this.grpAttributes.Controls.Add(this.grpFearuesContents);
            this.grpAttributes.Location = new System.Drawing.Point(4, 447);
            this.grpAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Padding = new System.Windows.Forms.Padding(4);
            this.grpAttributes.Size = new System.Drawing.Size(389, 121);
            this.grpAttributes.TabIndex = 26;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "属性显示与打印";
            // 
            // grpActionType
            // 
            this.grpActionType.Controls.Add(this.rdoReport);
            this.grpActionType.Controls.Add(this.rdoDataGridView);
            this.grpActionType.Location = new System.Drawing.Point(201, 25);
            this.grpActionType.Margin = new System.Windows.Forms.Padding(4);
            this.grpActionType.Name = "grpActionType";
            this.grpActionType.Padding = new System.Windows.Forms.Padding(4);
            this.grpActionType.Size = new System.Drawing.Size(168, 85);
            this.grpActionType.TabIndex = 2;
            this.grpActionType.TabStop = false;
            this.grpActionType.Text = "操作方式";
            // 
            // rdoReport
            // 
            this.rdoReport.AutoSize = true;
            this.rdoReport.Checked = true;
            this.rdoReport.Location = new System.Drawing.Point(12, 52);
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
            this.rdoDataGridView.Location = new System.Drawing.Point(12, 25);
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
            this.grpFearuesContents.Location = new System.Drawing.Point(17, 25);
            this.grpFearuesContents.Margin = new System.Windows.Forms.Padding(4);
            this.grpFearuesContents.Name = "grpFearuesContents";
            this.grpFearuesContents.Padding = new System.Windows.Forms.Padding(4);
            this.grpFearuesContents.Size = new System.Drawing.Size(149, 85);
            this.grpFearuesContents.TabIndex = 2;
            this.grpFearuesContents.TabStop = false;
            this.grpFearuesContents.Text = "要素范围";
            // 
            // rdoSelectedFeatures
            // 
            this.rdoSelectedFeatures.AutoSize = true;
            this.rdoSelectedFeatures.Checked = true;
            this.rdoSelectedFeatures.Location = new System.Drawing.Point(12, 52);
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
            this.grpInformation.Location = new System.Drawing.Point(4, 576);
            this.grpInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpInformation.Size = new System.Drawing.Size(389, 161);
            this.grpInformation.TabIndex = 25;
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
            this.txtMessages.Size = new System.Drawing.Size(381, 135);
            this.txtMessages.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 554);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "关 闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBuffer
            // 
            this.btnBuffer.Location = new System.Drawing.Point(48, 554);
            this.btnBuffer.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuffer.Name = "btnBuffer";
            this.btnBuffer.Size = new System.Drawing.Size(100, 29);
            this.btnBuffer.TabIndex = 34;
            this.btnBuffer.Text = "查 询";
            this.btnBuffer.UseVisualStyleBackColor = true;
            this.btnBuffer.Click += new System.EventHandler(this.btnBuffer_Click);
            // 
            // BufferQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(488, 601);
            this.Controls.Add(this.btnAttributes);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuffer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BufferQuery";
            this.Text = "缓冲区查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BufferQuery_FormClosed);
            this.Load += new System.EventHandler(this.BufferQuery_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grpQueryGeom.ResumeLayout(false);
            this.grpQueryGeom.PerformLayout();
            this.grpPolygonbufferType.ResumeLayout(false);
            this.grpPolygonbufferType.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chklstLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGeometryType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSpatialRelationship;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.GroupBox grpQueryGeom;
        private System.Windows.Forms.RadioButton rdoDrawGeom;
        private System.Windows.Forms.RadioButton rdoSelGeom;
        private System.Windows.Forms.GroupBox grpPolygonbufferType;
        private System.Windows.Forms.RadioButton rdoExtAndPolygon;
        private System.Windows.Forms.RadioButton rdoIntForward;
        private System.Windows.Forms.RadioButton rdoBndInt;
        private System.Windows.Forms.RadioButton rdoBndExt;
        private System.Windows.Forms.RadioButton rdoBndExtInt;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.GroupBox grpActionType;
        private System.Windows.Forms.RadioButton rdoReport;
        private System.Windows.Forms.RadioButton rdoDataGridView;
        private System.Windows.Forms.GroupBox grpFearuesContents;
        private System.Windows.Forms.RadioButton rdoSelectedFeatures;
        private System.Windows.Forms.RadioButton rdoAllFeatures;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBuffer;
    }
}