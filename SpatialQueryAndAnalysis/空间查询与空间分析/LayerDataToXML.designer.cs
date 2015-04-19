namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class LayerDataToXML
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLayerDataToXML = new System.Windows.Forms.Button();
            this.btnExportDir = new System.Windows.Forms.Button();
            this.btnSelectDataSources = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvDatasets = new System.Windows.Forms.TreeView();
            this.lsvDetails = new System.Windows.Forms.ListView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 9;
            // 
            // btnLayerDataToXML
            // 
            this.btnLayerDataToXML.Location = new System.Drawing.Point(337, 12);
            this.btnLayerDataToXML.Name = "btnLayerDataToXML";
            this.btnLayerDataToXML.Size = new System.Drawing.Size(100, 23);
            this.btnLayerDataToXML.TabIndex = 8;
            this.btnLayerDataToXML.Text = "输出为报表数据";
            this.btnLayerDataToXML.UseVisualStyleBackColor = true;
            this.btnLayerDataToXML.Click += new System.EventHandler(this.btnLayerDataToXML_Click);
            // 
            // btnExportDir
            // 
            this.btnExportDir.Location = new System.Drawing.Point(180, 12);
            this.btnExportDir.Name = "btnExportDir";
            this.btnExportDir.Size = new System.Drawing.Size(113, 23);
            this.btnExportDir.TabIndex = 7;
            this.btnExportDir.Text = "设置输出目标路径";
            this.btnExportDir.UseVisualStyleBackColor = true;
            this.btnExportDir.Click += new System.EventHandler(this.btnExportDir_Click);
            // 
            // btnSelectDataSources
            // 
            this.btnSelectDataSources.Location = new System.Drawing.Point(61, 12);
            this.btnSelectDataSources.Name = "btnSelectDataSources";
            this.btnSelectDataSources.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDataSources.TabIndex = 6;
            this.btnSelectDataSources.Text = "选择数据源";
            this.btnSelectDataSources.UseVisualStyleBackColor = true;
            this.btnSelectDataSources.Click += new System.EventHandler(this.btnSelectDataSources_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvDatasets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lsvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(436, 299);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 5;
            // 
            // trvDatasets
            // 
            this.trvDatasets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDatasets.HotTracking = true;
            this.trvDatasets.Location = new System.Drawing.Point(0, 0);
            this.trvDatasets.Name = "trvDatasets";
            this.trvDatasets.Size = new System.Drawing.Size(145, 299);
            this.trvDatasets.TabIndex = 0;
            this.trvDatasets.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDatasets_AfterSelect);
            // 
            // lsvDetails
            // 
            this.lsvDetails.CheckBoxes = true;
            this.lsvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDetails.Location = new System.Drawing.Point(0, 0);
            this.lsvDetails.Name = "lsvDetails";
            this.lsvDetails.Size = new System.Drawing.Size(287, 299);
            this.lsvDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvDetails.TabIndex = 0;
            this.lsvDetails.UseCompatibleStateImageBehavior = false;
            this.lsvDetails.View = System.Windows.Forms.View.List;
            // 
            // LayerDataToXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLayerDataToXML);
            this.Controls.Add(this.btnExportDir);
            this.Controls.Add(this.btnSelectDataSources);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LayerDataToXML";
            this.Text = "要素类数据输出为报表数据格式";
            this.Load += new System.EventHandler(this.LayerDataToXML_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLayerDataToXML;
        private System.Windows.Forms.Button btnExportDir;
        private System.Windows.Forms.Button btnSelectDataSources;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvDatasets;
        private System.Windows.Forms.ListView lsvDetails;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}