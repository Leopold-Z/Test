namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class QueryAdjacentFeatures
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
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.grpActionType = new System.Windows.Forms.GroupBox();
            this.rdoReport = new System.Windows.Forms.RadioButton();
            this.rdoDataGridView = new System.Windows.Forms.RadioButton();
            this.grpFearuesContents = new System.Windows.Forms.GroupBox();
            this.rdoSelectedFeatures = new System.Windows.Forms.RadioButton();
            this.rdoAllFeatures = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAttributeTable = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnSelectOnePolygon = new System.Windows.Forms.Button();
            this.cbxPolygonLayers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpInformation.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.grpActionType.SuspendLayout();
            this.grpFearuesContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.txtMessages);
            this.grpInformation.Location = new System.Drawing.Point(16, 224);
            this.grpInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInformation.Size = new System.Drawing.Size(368, 128);
            this.grpInformation.TabIndex = 36;
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
            this.txtMessages.Size = new System.Drawing.Size(359, 96);
            this.txtMessages.TabIndex = 0;
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.grpActionType);
            this.grpAttributes.Controls.Add(this.grpFearuesContents);
            this.grpAttributes.Location = new System.Drawing.Point(16, 96);
            this.grpAttributes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAttributes.Size = new System.Drawing.Size(367, 120);
            this.grpAttributes.TabIndex = 35;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "属性显示与打印";
            // 
            // grpActionType
            // 
            this.grpActionType.Controls.Add(this.rdoReport);
            this.grpActionType.Controls.Add(this.rdoDataGridView);
            this.grpActionType.Location = new System.Drawing.Point(201, 25);
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
            this.grpFearuesContents.Location = new System.Drawing.Point(21, 25);
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
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.PeachPuff;
            this.btnClose.Location = new System.Drawing.Point(277, 364);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 29);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAttributeTable
            // 
            this.btnAttributeTable.BackColor = System.Drawing.Color.PeachPuff;
            this.btnAttributeTable.Location = new System.Drawing.Point(157, 364);
            this.btnAttributeTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAttributeTable.Name = "btnAttributeTable";
            this.btnAttributeTable.Size = new System.Drawing.Size(100, 29);
            this.btnAttributeTable.TabIndex = 33;
            this.btnAttributeTable.Text = "属性表";
            this.btnAttributeTable.UseVisualStyleBackColor = false;
            this.btnAttributeTable.Click += new System.EventHandler(this.btnAttributeTable_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.PeachPuff;
            this.btnQuery.Location = new System.Drawing.Point(24, 364);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 29);
            this.btnQuery.TabIndex = 32;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnSelectOnePolygon
            // 
            this.btnSelectOnePolygon.BackColor = System.Drawing.Color.Bisque;
            this.btnSelectOnePolygon.Location = new System.Drawing.Point(23, 55);
            this.btnSelectOnePolygon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectOnePolygon.Name = "btnSelectOnePolygon";
            this.btnSelectOnePolygon.Size = new System.Drawing.Size(359, 29);
            this.btnSelectOnePolygon.TabIndex = 31;
            this.btnSelectOnePolygon.Text = "选择一多边形要素";
            this.btnSelectOnePolygon.UseVisualStyleBackColor = false;
            this.btnSelectOnePolygon.Click += new System.EventHandler(this.btnSelectOnePolygon_Click);
            // 
            // cbxPolygonLayers
            // 
            this.cbxPolygonLayers.FormattingEnabled = true;
            this.cbxPolygonLayers.Location = new System.Drawing.Point(157, 18);
            this.cbxPolygonLayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPolygonLayers.Name = "cbxPolygonLayers";
            this.cbxPolygonLayers.Size = new System.Drawing.Size(224, 23);
            this.cbxPolygonLayers.TabIndex = 30;
            this.cbxPolygonLayers.SelectedIndexChanged += new System.EventHandler(this.cbxPolygonLayers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "选择多边形图层：";
            // 
            // QueryAdjacentFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(416, 422);
            this.Controls.Add(this.grpInformation);
            this.Controls.Add(this.grpAttributes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAttributeTable);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnSelectOnePolygon);
            this.Controls.Add(this.cbxPolygonLayers);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QueryAdjacentFeatures";
            this.Text = "邻接多边形查询";
            this.Load += new System.EventHandler(this.QueryAdjacentFeatures_Load);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.grpAttributes.ResumeLayout(false);
            this.grpActionType.ResumeLayout(false);
            this.grpActionType.PerformLayout();
            this.grpFearuesContents.ResumeLayout(false);
            this.grpFearuesContents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.GroupBox grpActionType;
        private System.Windows.Forms.RadioButton rdoReport;
        private System.Windows.Forms.RadioButton rdoDataGridView;
        private System.Windows.Forms.GroupBox grpFearuesContents;
        private System.Windows.Forms.RadioButton rdoSelectedFeatures;
        private System.Windows.Forms.RadioButton rdoAllFeatures;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAttributeTable;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnSelectOnePolygon;
        private System.Windows.Forms.ComboBox cbxPolygonLayers;
        private System.Windows.Forms.Label label1;
    }
}