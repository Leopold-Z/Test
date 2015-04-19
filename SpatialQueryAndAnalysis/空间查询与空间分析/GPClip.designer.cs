namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    partial class GPClip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPClip));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chklstLayers = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxClipGeometryType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClip = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtTolerance);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 334);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklstLayers);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(299, 158);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择要裁剪的要素图层";
            // 
            // chklstLayers
            // 
            this.chklstLayers.CheckOnClick = true;
            this.chklstLayers.FormattingEnabled = true;
            this.chklstLayers.Location = new System.Drawing.Point(12, 24);
            this.chklstLayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chklstLayers.Name = "chklstLayers";
            this.chklstLayers.ScrollAlwaysVisible = true;
            this.chklstLayers.Size = new System.Drawing.Size(277, 124);
            this.chklstLayers.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOutputPath);
            this.groupBox3.Controls.Add(this.btnOutputPath);
            this.groupBox3.Location = new System.Drawing.Point(4, 170);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(299, 64);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "指定输出要素存放位置";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(8, 25);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(243, 25);
            this.txtOutputPath.TabIndex = 4;
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Image = ((System.Drawing.Image)(resources.GetObject("btnOutputPath.Image")));
            this.btnOutputPath.Location = new System.Drawing.Point(265, 25);
            this.btnOutputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(25, 24);
            this.btnOutputPath.TabIndex = 5;
            this.btnOutputPath.Text = ">";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbxClipGeometryType);
            this.groupBox4.Location = new System.Drawing.Point(4, 242);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(299, 65);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "绘制用于裁剪的几何形状";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "选择并绘制裁剪几何：";
            // 
            // cbxClipGeometryType
            // 
            this.cbxClipGeometryType.FormattingEnabled = true;
            this.cbxClipGeometryType.Items.AddRange(new object[] {
            "圆",
            "矩形",
            "多边形"});
            this.cbxClipGeometryType.Location = new System.Drawing.Point(181, 25);
            this.cbxClipGeometryType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxClipGeometryType.Name = "cbxClipGeometryType";
            this.cbxClipGeometryType.Size = new System.Drawing.Size(108, 23);
            this.cbxClipGeometryType.TabIndex = 12;
            this.cbxClipGeometryType.SelectedIndexChanged += new System.EventHandler(this.cbxClipGeometryType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "ＸＹ容差（可选）：";
            // 
            // txtTolerance
            // 
            this.txtTolerance.Location = new System.Drawing.Point(154, 315);
            this.txtTolerance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.Size = new System.Drawing.Size(139, 25);
            this.txtTolerance.TabIndex = 6;
            this.txtTolerance.Leave += new System.EventHandler(this.txtTolerance_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMessages);
            this.groupBox2.Location = new System.Drawing.Point(4, 348);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(299, 148);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作信息";
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessages.Location = new System.Drawing.Point(4, 26);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(289, 116);
            this.txtMessages.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 13;
            // 
            // btnClip
            // 
            this.btnClip.Location = new System.Drawing.Point(72, 362);
            this.btnClip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClip.Name = "btnClip";
            this.btnClip.Size = new System.Drawing.Size(93, 28);
            this.btnClip.TabIndex = 14;
            this.btnClip.Text = "裁 剪";
            this.btnClip.UseVisualStyleBackColor = true;
            this.btnClip.Click += new System.EventHandler(this.btnClip_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(204, 362);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "关 闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GPClip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(375, 416);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClip);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GPClip";
            this.Text = "裁剪";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GPClip_FormClosed);
            this.Load += new System.EventHandler(this.GPClip_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chklstLayers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxClipGeometryType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClip;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnOutputPath;
    }
}