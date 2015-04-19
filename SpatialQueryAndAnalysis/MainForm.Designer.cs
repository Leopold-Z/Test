namespace SpatialQueryAndAnalysis
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.basicToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkCustomize = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataView = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.LayoutView = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.空间查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCursorISpatialFilter与IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除所选择的要素ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.queryDef实例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建一个虚要素类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableSort对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.根据排序结果来选择要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间查询ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.属性条件查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基于空间位置空间关系的查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓冲区查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.邻接多边形查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析基础ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iTopologicalOperatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAUnionOfPolygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iProximityOperator接口实例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算两点间距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geoprocessor对象实例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.裁剪要素类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓冲区分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间叠置分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NAToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miLoadLocations = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearLocations = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.basicToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.dataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.LayoutView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NAToolbarControl)).BeginInit();
            this.contextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // basicToolbarControl
            // 
            this.basicToolbarControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.basicToolbarControl.Location = new System.Drawing.Point(0, 28);
            this.basicToolbarControl.Margin = new System.Windows.Forms.Padding(4);
            this.basicToolbarControl.Name = "basicToolbarControl";
            this.basicToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("basicToolbarControl.OcxState")));
            this.basicToolbarControl.Size = new System.Drawing.Size(1199, 28);
            this.basicToolbarControl.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(3, 79);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(235, 550);
            this.axTOCControl1.TabIndex = 4;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 620);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(4, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1195, 25);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(71, 20);
            this.statusBarXY.Text = "Test 123";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkCustomize
            // 
            this.chkCustomize.AutoSize = true;
            this.chkCustomize.Location = new System.Drawing.Point(933, 5);
            this.chkCustomize.Margin = new System.Windows.Forms.Padding(4);
            this.chkCustomize.Name = "chkCustomize";
            this.chkCustomize.Size = new System.Drawing.Size(128, 19);
            this.chkCustomize.TabIndex = 10;
            this.chkCustomize.Text = "定制工具条...";
            this.chkCustomize.UseVisualStyleBackColor = false;
            this.chkCustomize.CheckedChanged += new System.EventHandler(this.chkCustomize_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.dataView);
            this.tabControl1.Controls.Add(this.LayoutView);
            this.tabControl1.Location = new System.Drawing.Point(251, 99);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(949, 550);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // dataView
            // 
            this.dataView.Controls.Add(this.axMapControl1);
            this.dataView.Location = new System.Drawing.Point(4, 4);
            this.dataView.Margin = new System.Windows.Forms.Padding(4);
            this.dataView.Name = "dataView";
            this.dataView.Padding = new System.Windows.Forms.Padding(4);
            this.dataView.Size = new System.Drawing.Size(941, 521);
            this.dataView.TabIndex = 0;
            this.dataView.Text = "数据视图";
            this.dataView.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(4, 4);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(933, 513);
            this.axMapControl1.TabIndex = 3;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnViewRefreshed += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnViewRefreshedEventHandler(this.axMapControl1_OnViewRefreshed);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // LayoutView
            // 
            this.LayoutView.Controls.Add(this.axPageLayoutControl1);
            this.LayoutView.Location = new System.Drawing.Point(4, 4);
            this.LayoutView.Margin = new System.Windows.Forms.Padding(4);
            this.LayoutView.Name = "LayoutView";
            this.LayoutView.Padding = new System.Windows.Forms.Padding(4);
            this.LayoutView.Size = new System.Drawing.Size(941, 521);
            this.LayoutView.TabIndex = 1;
            this.LayoutView.Text = "布局视图";
            this.LayoutView.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(4, 4);
            this.axPageLayoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(1039, 513);
            this.axPageLayoutControl1.TabIndex = 9;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            this.axPageLayoutControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.axPageLayoutControl1_OnMouseMove);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp,
            this.退出ToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(51, 24);
            this.menuFile.Text = "文件";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(180, 24);
            this.menuNewDoc.Text = "新建地图文档";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(180, 24);
            this.menuOpenDoc.Text = "打开地图文档...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(180, 24);
            this.menuSaveDoc.Text = "保存地图文档";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(180, 24);
            this.menuSaveAs.Text = "另存地图文档...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Image = ((System.Drawing.Image)(resources.GetObject("menuExitApp.Image")));
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(180, 24);
            this.menuExitApp.Text = "添加数据";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出ToolStripMenuItem.Image")));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.空间查询ToolStripMenuItem,
            this.空间查询ToolStripMenuItem1,
            this.空间分析基础ToolStripMenuItem,
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem,
            this.空间分析ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1199, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 空间查询ToolStripMenuItem
            // 
            this.空间查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iCursorISpatialFilter与IToolStripMenuItem,
            this.queryDef实例ToolStripMenuItem,
            this.tableSort对象ToolStripMenuItem});
            this.空间查询ToolStripMenuItem.Name = "空间查询ToolStripMenuItem";
            this.空间查询ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.空间查询ToolStripMenuItem.Text = "空间查询基础";
            // 
            // iCursorISpatialFilter与IToolStripMenuItem
            // 
            this.iCursorISpatialFilter与IToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除所选择的要素ToolStripMenuItem1});
            this.iCursorISpatialFilter与IToolStripMenuItem.Name = "iCursorISpatialFilter与IToolStripMenuItem";
            this.iCursorISpatialFilter与IToolStripMenuItem.Size = new System.Drawing.Size(376, 24);
            this.iCursorISpatialFilter与IToolStripMenuItem.Text = "ICursor、ISpatialFilter与ISelectionSet实例";
            // 
            // 删除所选择的要素ToolStripMenuItem1
            // 
            this.删除所选择的要素ToolStripMenuItem1.Name = "删除所选择的要素ToolStripMenuItem1";
            this.删除所选择的要素ToolStripMenuItem1.Size = new System.Drawing.Size(198, 24);
            this.删除所选择的要素ToolStripMenuItem1.Text = "删除所选择的要素";
            this.删除所选择的要素ToolStripMenuItem1.Click += new System.EventHandler(this.删除所选择的要素ToolStripMenuItem1_Click);
            // 
            // queryDef实例ToolStripMenuItem
            // 
            this.queryDef实例ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建一个虚要素类ToolStripMenuItem});
            this.queryDef实例ToolStripMenuItem.Name = "queryDef实例ToolStripMenuItem";
            this.queryDef实例ToolStripMenuItem.Size = new System.Drawing.Size(376, 24);
            this.queryDef实例ToolStripMenuItem.Text = "QueryDef 实例";
            // 
            // 新建一个虚要素类ToolStripMenuItem
            // 
            this.新建一个虚要素类ToolStripMenuItem.Name = "新建一个虚要素类ToolStripMenuItem";
            this.新建一个虚要素类ToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.新建一个虚要素类ToolStripMenuItem.Text = "新建一个虚要素类 ";
            this.新建一个虚要素类ToolStripMenuItem.Click += new System.EventHandler(this.新建一个虚要素类ToolStripMenuItem_Click);
            // 
            // tableSort对象ToolStripMenuItem
            // 
            this.tableSort对象ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.根据排序结果来选择要素ToolStripMenuItem});
            this.tableSort对象ToolStripMenuItem.Name = "tableSort对象ToolStripMenuItem";
            this.tableSort对象ToolStripMenuItem.Size = new System.Drawing.Size(376, 24);
            this.tableSort对象ToolStripMenuItem.Text = "TableSort对象实例";
            // 
            // 根据排序结果来选择要素ToolStripMenuItem
            // 
            this.根据排序结果来选择要素ToolStripMenuItem.Name = "根据排序结果来选择要素ToolStripMenuItem";
            this.根据排序结果来选择要素ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.根据排序结果来选择要素ToolStripMenuItem.Text = "根据排序结果来选择要素";
            this.根据排序结果来选择要素ToolStripMenuItem.Click += new System.EventHandler(this.根据排序结果来选择要素ToolStripMenuItem_Click);
            // 
            // 空间查询ToolStripMenuItem1
            // 
            this.空间查询ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性条件查询ToolStripMenuItem,
            this.基于空间位置空间关系的查询ToolStripMenuItem,
            this.缓冲区查询ToolStripMenuItem,
            this.邻接多边形查询ToolStripMenuItem});
            this.空间查询ToolStripMenuItem1.Name = "空间查询ToolStripMenuItem1";
            this.空间查询ToolStripMenuItem1.Size = new System.Drawing.Size(81, 24);
            this.空间查询ToolStripMenuItem1.Text = "空间查询";
            // 
            // 属性条件查询ToolStripMenuItem
            // 
            this.属性条件查询ToolStripMenuItem.Name = "属性条件查询ToolStripMenuItem";
            this.属性条件查询ToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.属性条件查询ToolStripMenuItem.Text = "属性条件查询";
            this.属性条件查询ToolStripMenuItem.Click += new System.EventHandler(this.属性条件查询ToolStripMenuItem_Click);
            // 
            // 基于空间位置空间关系的查询ToolStripMenuItem
            // 
            this.基于空间位置空间关系的查询ToolStripMenuItem.Name = "基于空间位置空间关系的查询ToolStripMenuItem";
            this.基于空间位置空间关系的查询ToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.基于空间位置空间关系的查询ToolStripMenuItem.Text = "基于空间位置、空间关系的查询";
            this.基于空间位置空间关系的查询ToolStripMenuItem.Click += new System.EventHandler(this.基于空间位置空间关系的查询ToolStripMenuItem_Click);
            // 
            // 缓冲区查询ToolStripMenuItem
            // 
            this.缓冲区查询ToolStripMenuItem.Name = "缓冲区查询ToolStripMenuItem";
            this.缓冲区查询ToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.缓冲区查询ToolStripMenuItem.Text = "缓冲区查询";
            this.缓冲区查询ToolStripMenuItem.Click += new System.EventHandler(this.缓冲区查询ToolStripMenuItem_Click);
            // 
            // 邻接多边形查询ToolStripMenuItem
            // 
            this.邻接多边形查询ToolStripMenuItem.Name = "邻接多边形查询ToolStripMenuItem";
            this.邻接多边形查询ToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.邻接多边形查询ToolStripMenuItem.Text = "邻接多边形查询";
            this.邻接多边形查询ToolStripMenuItem.Click += new System.EventHandler(this.邻接多边形查询ToolStripMenuItem_Click);
            // 
            // 空间分析基础ToolStripMenuItem
            // 
            this.空间分析基础ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iTopologicalOperatorToolStripMenuItem,
            this.iProximityOperator接口实例ToolStripMenuItem});
            this.空间分析基础ToolStripMenuItem.Name = "空间分析基础ToolStripMenuItem";
            this.空间分析基础ToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.空间分析基础ToolStripMenuItem.Text = "空间分析基础 ";
            // 
            // iTopologicalOperatorToolStripMenuItem
            // 
            this.iTopologicalOperatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAUnionOfPolygonsToolStripMenuItem});
            this.iTopologicalOperatorToolStripMenuItem.Name = "iTopologicalOperatorToolStripMenuItem";
            this.iTopologicalOperatorToolStripMenuItem.Size = new System.Drawing.Size(452, 24);
            this.iTopologicalOperatorToolStripMenuItem.Text = "ITopologicalOperator与IRelationaloperator接口实例";
            // 
            // createAUnionOfPolygonsToolStripMenuItem
            // 
            this.createAUnionOfPolygonsToolStripMenuItem.Name = "createAUnionOfPolygonsToolStripMenuItem";
            this.createAUnionOfPolygonsToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.createAUnionOfPolygonsToolStripMenuItem.Text = "多边形挖空";
            this.createAUnionOfPolygonsToolStripMenuItem.Click += new System.EventHandler(this.多边形挖空ToolStripMenuItem_Click);
            // 
            // iProximityOperator接口实例ToolStripMenuItem
            // 
            this.iProximityOperator接口实例ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算两点间距离ToolStripMenuItem});
            this.iProximityOperator接口实例ToolStripMenuItem.Name = "iProximityOperator接口实例ToolStripMenuItem";
            this.iProximityOperator接口实例ToolStripMenuItem.Size = new System.Drawing.Size(452, 24);
            this.iProximityOperator接口实例ToolStripMenuItem.Text = "IProximityOperator接口实例";
            // 
            // 计算两点间距离ToolStripMenuItem
            // 
            this.计算两点间距离ToolStripMenuItem.Name = "计算两点间距离ToolStripMenuItem";
            this.计算两点间距离ToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.计算两点间距离ToolStripMenuItem.Text = "计算两点间距离";
            this.计算两点间距离ToolStripMenuItem.Click += new System.EventHandler(this.计算两点间距离ToolStripMenuItem_Click);
            // 
            // iPROXIMITYOPERATOR接口ToolStripMenuItem
            // 
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem.Checked = true;
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geoprocessor对象实例ToolStripMenuItem});
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem.Name = "iPROXIMITYOPERATOR接口ToolStripMenuItem";
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.iPROXIMITYOPERATOR接口ToolStripMenuItem.Text = "地学处理工具";
            // 
            // geoprocessor对象实例ToolStripMenuItem
            // 
            this.geoprocessor对象实例ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.裁剪要素类ToolStripMenuItem});
            this.geoprocessor对象实例ToolStripMenuItem.Name = "geoprocessor对象实例ToolStripMenuItem";
            this.geoprocessor对象实例ToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.geoprocessor对象实例ToolStripMenuItem.Text = "Geoprocessor对象实例";
            // 
            // 裁剪要素类ToolStripMenuItem
            // 
            this.裁剪要素类ToolStripMenuItem.Name = "裁剪要素类ToolStripMenuItem";
            this.裁剪要素类ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.裁剪要素类ToolStripMenuItem.Text = "裁剪要素类";
            this.裁剪要素类ToolStripMenuItem.Click += new System.EventHandler(this.裁剪要素类ToolStripMenuItem_Click);
            // 
            // 空间分析ToolStripMenuItem
            // 
            this.空间分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.缓冲区分析ToolStripMenuItem,
            this.空间叠置分析ToolStripMenuItem,
            this.网络分析ToolStripMenuItem});
            this.空间分析ToolStripMenuItem.Name = "空间分析ToolStripMenuItem";
            this.空间分析ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.空间分析ToolStripMenuItem.Text = "空间分析";
            // 
            // 缓冲区分析ToolStripMenuItem
            // 
            this.缓冲区分析ToolStripMenuItem.Name = "缓冲区分析ToolStripMenuItem";
            this.缓冲区分析ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.缓冲区分析ToolStripMenuItem.Text = "缓冲区分析";
            this.缓冲区分析ToolStripMenuItem.Click += new System.EventHandler(this.缓冲区分析ToolStripMenuItem_Click);
            // 
            // 空间叠置分析ToolStripMenuItem
            // 
            this.空间叠置分析ToolStripMenuItem.Name = "空间叠置分析ToolStripMenuItem";
            this.空间叠置分析ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.空间叠置分析ToolStripMenuItem.Text = "空间叠置分析";
            this.空间叠置分析ToolStripMenuItem.Click += new System.EventHandler(this.空间叠置分析ToolStripMenuItem_Click);
            // 
            // 网络分析ToolStripMenuItem
            // 
            this.网络分析ToolStripMenuItem.Name = "网络分析ToolStripMenuItem";
            this.网络分析ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.网络分析ToolStripMenuItem.Text = "网络分析";
            this.网络分析ToolStripMenuItem.Click += new System.EventHandler(this.网络分析ToolStripMenuItem_Click);
            // 
            // NAToolbarControl
            // 
            this.NAToolbarControl.Location = new System.Drawing.Point(3, 52);
            this.NAToolbarControl.Margin = new System.Windows.Forms.Padding(4);
            this.NAToolbarControl.Name = "NAToolbarControl";
            this.NAToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("NAToolbarControl.OcxState")));
            this.NAToolbarControl.Size = new System.Drawing.Size(982, 28);
            this.NAToolbarControl.TabIndex = 14;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLoadLocations,
            this.miClearLocations,
            this.miAddItem});
            this.contextMenu1.Name = "contextMenuStrip1";
            this.contextMenu1.Size = new System.Drawing.Size(202, 76);
            // 
            // miLoadLocations
            // 
            this.miLoadLocations.Name = "miLoadLocations";
            this.miLoadLocations.Size = new System.Drawing.Size(201, 24);
            this.miLoadLocations.Text = "Load Locations...";
            this.miLoadLocations.Click += new System.EventHandler(this.loadLocationsToolStripMenuItem_Click);
            // 
            // miClearLocations
            // 
            this.miClearLocations.Name = "miClearLocations";
            this.miClearLocations.Size = new System.Drawing.Size(201, 24);
            this.miClearLocations.Text = "Clear Locations...";
            this.miClearLocations.Click += new System.EventHandler(this.clearLocationsToolStripMenuItem_Click);
            // 
            // miAddItem
            // 
            this.miAddItem.Name = "miAddItem";
            this.miAddItem.Size = new System.Drawing.Size(201, 24);
            this.miAddItem.Text = "Add Item";
            this.miAddItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1199, 676);
            this.Controls.Add(this.NAToolbarControl);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.chkCustomize);
            this.Controls.Add(this.basicToolbarControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "城市基础地理信息系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.basicToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.dataView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.LayoutView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NAToolbarControl)).EndInit();
            this.contextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl basicToolbarControl;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkCustomize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage dataView;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.TabPage LayoutView;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxToolbarControl NAToolbarControl;
        private System.Windows.Forms.ContextMenuStrip contextMenu1;
        private System.Windows.Forms.ToolStripMenuItem 空间查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableSort对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iCursorISpatialFilter与IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除所选择的要素ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem queryDef实例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建一个虚要素类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 根据排序结果来选择要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间查询ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 属性条件查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基于空间位置空间关系的查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓冲区查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 邻接多边形查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析基础ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPROXIMITYOPERATOR接口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓冲区分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间叠置分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iTopologicalOperatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAUnionOfPolygonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iProximityOperator接口实例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算两点间距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geoprocessor对象实例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 裁剪要素类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miLoadLocations;
        private System.Windows.Forms.ToolStripMenuItem miClearLocations;
        private System.Windows.Forms.ToolStripMenuItem miAddItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}

