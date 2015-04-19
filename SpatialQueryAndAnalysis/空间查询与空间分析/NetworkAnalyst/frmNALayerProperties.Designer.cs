namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    partial class frmNALayerProperties
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
            this.tabPropPages = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lblMaxSearchTolerance = new System.Windows.Forms.Label();
            this.cboMaxSearchToleranceUnits = new System.Windows.Forms.ComboBox();
            this.txtMaxSearchTolerance = new System.Windows.Forms.TextBox();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.lblLayerName = new System.Windows.Forms.Label();
            this.tabRoute = new System.Windows.Forms.TabPage();
            this.labelRouteOutputLines = new System.Windows.Forms.Label();
            this.cboRouteOutputLines = new System.Windows.Forms.ComboBox();
            this.chkRouteUseTimeWindows = new System.Windows.Forms.CheckBox();
            this.chkRoutePreserveLastStop = new System.Windows.Forms.CheckBox();
            this.chkRoutePreserveFirstStop = new System.Windows.Forms.CheckBox();
            this.chkRouteFindBestSequence = new System.Windows.Forms.CheckBox();
            this.chkRouteUseStartTime = new System.Windows.Forms.CheckBox();
            this.txtRouteStartTime = new System.Windows.Forms.TextBox();
            this.chkRouteIgnoreInvalidLocations = new System.Windows.Forms.CheckBox();
            this.cboRouteRestrictUTurns = new System.Windows.Forms.ComboBox();
            this.lblRouteRestrictUTurns = new System.Windows.Forms.Label();
            this.lblRouteAccumulateAttributeNames = new System.Windows.Forms.Label();
            this.chklstRouteAccumulateAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.lblRouteRestrictionAttributeNames = new System.Windows.Forms.Label();
            this.chklstRouteRestrictionAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.cboRouteImpedance = new System.Windows.Forms.ComboBox();
            this.lblRouteImpedance = new System.Windows.Forms.Label();
            this.chkRouteUseHierarchy = new System.Windows.Forms.CheckBox();
            this.tabClosestFacility = new System.Windows.Forms.TabPage();
            this.chkCFIgnoreInvalidLocations = new System.Windows.Forms.CheckBox();
            this.cboCFRestrictUTurns = new System.Windows.Forms.ComboBox();
            this.lblCFRestrictUTurns = new System.Windows.Forms.Label();
            this.lblCFAccumulateAttributeNames = new System.Windows.Forms.Label();
            this.chklstCFAccumulateAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.lblCFRestrictionAttributeNames = new System.Windows.Forms.Label();
            this.chklstCFRestrictionAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.cboCFImpedance = new System.Windows.Forms.ComboBox();
            this.lblCFImpedance = new System.Windows.Forms.Label();
            this.chkCFUseHierarchy = new System.Windows.Forms.CheckBox();
            this.cboCFOutputLines = new System.Windows.Forms.ComboBox();
            this.lblCFOutputLines = new System.Windows.Forms.Label();
            this.cboCFTravelDirection = new System.Windows.Forms.ComboBox();
            this.lblCFTravelDirection = new System.Windows.Forms.Label();
            this.txtCFDefaultTargetFacilityCount = new System.Windows.Forms.TextBox();
            this.lblCFDefaultTargetFacilityCount = new System.Windows.Forms.Label();
            this.txtCFDefaultCutoff = new System.Windows.Forms.TextBox();
            this.lblCFDefaultCutoff = new System.Windows.Forms.Label();
            this.tabODCostMatrix = new System.Windows.Forms.TabPage();
            this.chkODIgnoreInvalidLocations = new System.Windows.Forms.CheckBox();
            this.cboODRestrictUTurns = new System.Windows.Forms.ComboBox();
            this.lblODRestrictUTurns = new System.Windows.Forms.Label();
            this.lblODAccumulateAttributeNames = new System.Windows.Forms.Label();
            this.chklstODAccumulateAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.lblODRestrictionAttributeNames = new System.Windows.Forms.Label();
            this.chklstODRestrictionAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.cboODImpedance = new System.Windows.Forms.ComboBox();
            this.lblODImpedance = new System.Windows.Forms.Label();
            this.chkODUseHierarchy = new System.Windows.Forms.CheckBox();
            this.cboODOutputLines = new System.Windows.Forms.ComboBox();
            this.lblODOutputLines = new System.Windows.Forms.Label();
            this.txtODDefaultTargetDestinationCount = new System.Windows.Forms.TextBox();
            this.lblODDefaultTargetDestinationCount = new System.Windows.Forms.Label();
            this.txtODDefaultCutoff = new System.Windows.Forms.TextBox();
            this.lblODDefaultCutoff = new System.Windows.Forms.Label();
            this.tabServiceArea = new System.Windows.Forms.TabPage();
            this.cboSATrimPolygonDistanceUnits = new System.Windows.Forms.ComboBox();
            this.txtSATrimPolygonDistance = new System.Windows.Forms.TextBox();
            this.chkSATrimOuterPolygon = new System.Windows.Forms.CheckBox();
            this.chkSAIncludeSourceInformationOnLines = new System.Windows.Forms.CheckBox();
            this.cboSATravelDirection = new System.Windows.Forms.ComboBox();
            this.lblSATravelDirection = new System.Windows.Forms.Label();
            this.chkSASplitPolygonsAtBreaks = new System.Windows.Forms.CheckBox();
            this.chkSAOverlapPolygons = new System.Windows.Forms.CheckBox();
            this.chkSASplitLinesAtBreaks = new System.Windows.Forms.CheckBox();
            this.chkSAOverlapLines = new System.Windows.Forms.CheckBox();
            this.chkSAIgnoreInvalidLocations = new System.Windows.Forms.CheckBox();
            this.cboSARestrictUTurns = new System.Windows.Forms.ComboBox();
            this.lblSARestrictUTurns = new System.Windows.Forms.Label();
            this.lblSAAccumulateAttributeNames = new System.Windows.Forms.Label();
            this.chklstSAAccumulateAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.lblSARestrictionAttributeNames = new System.Windows.Forms.Label();
            this.chklstSARestrictionAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.lblSAOutputPolygons = new System.Windows.Forms.Label();
            this.cboSAOutputPolygons = new System.Windows.Forms.ComboBox();
            this.lblSAOutputLines = new System.Windows.Forms.Label();
            this.cboSAOutputLines = new System.Windows.Forms.ComboBox();
            this.chkSAMergeSimilarPolygonRanges = new System.Windows.Forms.CheckBox();
            this.txtSADefaultBreaks = new System.Windows.Forms.TextBox();
            this.lblSADefaultBreaks = new System.Windows.Forms.Label();
            this.cboSAImpedance = new System.Windows.Forms.ComboBox();
            this.lblSAImpedance = new System.Windows.Forms.Label();
            this.tabVRP = new System.Windows.Forms.TabPage();
            this.gbRestrictions = new System.Windows.Forms.GroupBox();
            this.chklstVRPRestrictionAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cboVRPDistanceFieldUnits = new System.Windows.Forms.ComboBox();
            this.cboVRPTransitTime = new System.Windows.Forms.ComboBox();
            this.cboVRPTimeWindow = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkVRPUseHierarchy = new System.Windows.Forms.CheckBox();
            this.cboVRPOutputShapeType = new System.Windows.Forms.ComboBox();
            this.cboVRPAllowUTurns = new System.Windows.Forms.ComboBox();
            this.cboVRPTimeFieldUnits = new System.Windows.Forms.ComboBox();
            this.txtVRPCapacityCount = new System.Windows.Forms.TextBox();
            this.txtVRPDefaultDate = new System.Windows.Forms.TextBox();
            this.cboVRPDistanceAttribute = new System.Windows.Forms.ComboBox();
            this.cboVRPTimeAttribute = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimeAttribute = new System.Windows.Forms.Label();
            this.tabLocationAllocation = new System.Windows.Forms.TabPage();
            this.chkLAIgnoreInvalidLocations = new System.Windows.Forms.CheckBox();
            this.grpLASettings = new System.Windows.Forms.GroupBox();
            this.lblTargetMarketShare = new System.Windows.Forms.Label();
            this.txtLATargetMarketShare = new System.Windows.Forms.TextBox();
            this.cboLAImpTransformation = new System.Windows.Forms.ComboBox();
            this.lblImpParameter = new System.Windows.Forms.Label();
            this.txtLAImpParameter = new System.Windows.Forms.TextBox();
            this.lblImpTransformation = new System.Windows.Forms.Label();
            this.lblProblemType = new System.Windows.Forms.Label();
            this.cboLAProblemType = new System.Windows.Forms.ComboBox();
            this.lblCutOff = new System.Windows.Forms.Label();
            this.txtLACutOff = new System.Windows.Forms.TextBox();
            this.lblNumFacilities = new System.Windows.Forms.Label();
            this.txtLAFacilitiesToLocate = new System.Windows.Forms.TextBox();
            this.chkLAUseHierarchy = new System.Windows.Forms.CheckBox();
            this.lblLAAccumulateAttributeNames = new System.Windows.Forms.Label();
            this.chklstLAAccumulateAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.lblLARestrictionAttributeNames = new System.Windows.Forms.Label();
            this.chklstLARestrictionAttributeNames = new System.Windows.Forms.CheckedListBox();
            this.cboLAOutputLines = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboLATravelDirection = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCostAttribute = new System.Windows.Forms.Label();
            this.cboLAImpedance = new System.Windows.Forms.ComboBox();
            this.tabPropPages.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabRoute.SuspendLayout();
            this.tabClosestFacility.SuspendLayout();
            this.tabODCostMatrix.SuspendLayout();
            this.tabServiceArea.SuspendLayout();
            this.tabVRP.SuspendLayout();
            this.gbRestrictions.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.tabLocationAllocation.SuspendLayout();
            this.grpLASettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(607, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(434, 512);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 35);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabPropPages
            // 
            this.tabPropPages.Controls.Add(this.tabGeneral);
            this.tabPropPages.Controls.Add(this.tabRoute);
            this.tabPropPages.Controls.Add(this.tabClosestFacility);
            this.tabPropPages.Controls.Add(this.tabODCostMatrix);
            this.tabPropPages.Controls.Add(this.tabServiceArea);
            this.tabPropPages.Controls.Add(this.tabVRP);
            this.tabPropPages.Controls.Add(this.tabLocationAllocation);
            this.tabPropPages.Location = new System.Drawing.Point(27, 12);
            this.tabPropPages.Name = "tabPropPages";
            this.tabPropPages.SelectedIndex = 0;
            this.tabPropPages.Size = new System.Drawing.Size(716, 456);
            this.tabPropPages.TabIndex = 3;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lblMaxSearchTolerance);
            this.tabGeneral.Controls.Add(this.cboMaxSearchToleranceUnits);
            this.tabGeneral.Controls.Add(this.txtMaxSearchTolerance);
            this.tabGeneral.Controls.Add(this.txtLayerName);
            this.tabGeneral.Controls.Add(this.lblLayerName);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(708, 430);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lblMaxSearchTolerance
            // 
            this.lblMaxSearchTolerance.Location = new System.Drawing.Point(29, 69);
            this.lblMaxSearchTolerance.Name = "lblMaxSearchTolerance";
            this.lblMaxSearchTolerance.Size = new System.Drawing.Size(120, 26);
            this.lblMaxSearchTolerance.TabIndex = 123;
            this.lblMaxSearchTolerance.Text = "Search Tolerance";
            // 
            // cboMaxSearchToleranceUnits
            // 
            this.cboMaxSearchToleranceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxSearchToleranceUnits.ItemHeight = 12;
            this.cboMaxSearchToleranceUnits.Items.AddRange(new object[] {
            "Unknown Units",
            "Inches",
            "Points",
            "Feet",
            "Yards",
            "Miles",
            "Nautical Miles",
            "Millimeters",
            "Centimeters",
            "Meters",
            "Kilometers",
            "DecimalDegrees",
            "Decimeters"});
            this.cboMaxSearchToleranceUnits.Location = new System.Drawing.Point(310, 66);
            this.cboMaxSearchToleranceUnits.Name = "cboMaxSearchToleranceUnits";
            this.cboMaxSearchToleranceUnits.Size = new System.Drawing.Size(156, 20);
            this.cboMaxSearchToleranceUnits.TabIndex = 122;
            // 
            // txtMaxSearchTolerance
            // 
            this.txtMaxSearchTolerance.Location = new System.Drawing.Point(156, 67);
            this.txtMaxSearchTolerance.Name = "txtMaxSearchTolerance";
            this.txtMaxSearchTolerance.Size = new System.Drawing.Size(146, 21);
            this.txtMaxSearchTolerance.TabIndex = 121;
            // 
            // txtLayerName
            // 
            this.txtLayerName.Location = new System.Drawing.Point(156, 34);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(310, 21);
            this.txtLayerName.TabIndex = 1;
            // 
            // lblLayerName
            // 
            this.lblLayerName.Location = new System.Drawing.Point(29, 38);
            this.lblLayerName.Name = "lblLayerName";
            this.lblLayerName.Size = new System.Drawing.Size(105, 26);
            this.lblLayerName.TabIndex = 0;
            this.lblLayerName.Text = "Layer Name";
            // 
            // tabRoute
            // 
            this.tabRoute.Controls.Add(this.labelRouteOutputLines);
            this.tabRoute.Controls.Add(this.cboRouteOutputLines);
            this.tabRoute.Controls.Add(this.chkRouteUseTimeWindows);
            this.tabRoute.Controls.Add(this.chkRoutePreserveLastStop);
            this.tabRoute.Controls.Add(this.chkRoutePreserveFirstStop);
            this.tabRoute.Controls.Add(this.chkRouteFindBestSequence);
            this.tabRoute.Controls.Add(this.chkRouteUseStartTime);
            this.tabRoute.Controls.Add(this.txtRouteStartTime);
            this.tabRoute.Controls.Add(this.chkRouteIgnoreInvalidLocations);
            this.tabRoute.Controls.Add(this.cboRouteRestrictUTurns);
            this.tabRoute.Controls.Add(this.lblRouteRestrictUTurns);
            this.tabRoute.Controls.Add(this.lblRouteAccumulateAttributeNames);
            this.tabRoute.Controls.Add(this.chklstRouteAccumulateAttributeNames);
            this.tabRoute.Controls.Add(this.lblRouteRestrictionAttributeNames);
            this.tabRoute.Controls.Add(this.chklstRouteRestrictionAttributeNames);
            this.tabRoute.Controls.Add(this.cboRouteImpedance);
            this.tabRoute.Controls.Add(this.lblRouteImpedance);
            this.tabRoute.Controls.Add(this.chkRouteUseHierarchy);
            this.tabRoute.Location = new System.Drawing.Point(4, 22);
            this.tabRoute.Name = "tabRoute";
            this.tabRoute.Size = new System.Drawing.Size(708, 430);
            this.tabRoute.TabIndex = 1;
            this.tabRoute.Text = "Route";
            this.tabRoute.UseVisualStyleBackColor = true;
            // 
            // labelRouteOutputLines
            // 
            this.labelRouteOutputLines.Location = new System.Drawing.Point(24, 225);
            this.labelRouteOutputLines.Name = "labelRouteOutputLines";
            this.labelRouteOutputLines.Size = new System.Drawing.Size(48, 17);
            this.labelRouteOutputLines.TabIndex = 96;
            this.labelRouteOutputLines.Text = "Shape";
            // 
            // cboRouteOutputLines
            // 
            this.cboRouteOutputLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteOutputLines.ItemHeight = 12;
            this.cboRouteOutputLines.Items.AddRange(new object[] {
            "No Lines",
            "Straight Lines",
            "True Shape",
            "True Shape With Measures"});
            this.cboRouteOutputLines.Location = new System.Drawing.Point(178, 220);
            this.cboRouteOutputLines.Name = "cboRouteOutputLines";
            this.cboRouteOutputLines.Size = new System.Drawing.Size(240, 20);
            this.cboRouteOutputLines.TabIndex = 95;
            // 
            // chkRouteUseTimeWindows
            // 
            this.chkRouteUseTimeWindows.Location = new System.Drawing.Point(24, 82);
            this.chkRouteUseTimeWindows.Name = "chkRouteUseTimeWindows";
            this.chkRouteUseTimeWindows.Size = new System.Drawing.Size(154, 17);
            this.chkRouteUseTimeWindows.TabIndex = 92;
            this.chkRouteUseTimeWindows.Text = "Use Time Windows";
            // 
            // chkRoutePreserveLastStop
            // 
            this.chkRoutePreserveLastStop.Location = new System.Drawing.Point(47, 163);
            this.chkRoutePreserveLastStop.Name = "chkRoutePreserveLastStop";
            this.chkRoutePreserveLastStop.Size = new System.Drawing.Size(397, 24);
            this.chkRoutePreserveLastStop.TabIndex = 91;
            this.chkRoutePreserveLastStop.Text = "Preserve Last Stop";
            // 
            // chkRoutePreserveFirstStop
            // 
            this.chkRoutePreserveFirstStop.Location = new System.Drawing.Point(47, 132);
            this.chkRoutePreserveFirstStop.Name = "chkRoutePreserveFirstStop";
            this.chkRoutePreserveFirstStop.Size = new System.Drawing.Size(397, 31);
            this.chkRoutePreserveFirstStop.TabIndex = 90;
            this.chkRoutePreserveFirstStop.Text = "Preserve First Stop";
            // 
            // chkRouteFindBestSequence
            // 
            this.chkRouteFindBestSequence.Checked = true;
            this.chkRouteFindBestSequence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRouteFindBestSequence.Location = new System.Drawing.Point(24, 106);
            this.chkRouteFindBestSequence.Name = "chkRouteFindBestSequence";
            this.chkRouteFindBestSequence.Size = new System.Drawing.Size(403, 34);
            this.chkRouteFindBestSequence.TabIndex = 89;
            this.chkRouteFindBestSequence.Text = "Find Best Sequence";
            this.chkRouteFindBestSequence.CheckedChanged += new System.EventHandler(this.chkRouteFindBestSequence_CheckedChanged);
            // 
            // chkRouteUseStartTime
            // 
            this.chkRouteUseStartTime.Checked = true;
            this.chkRouteUseStartTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRouteUseStartTime.Location = new System.Drawing.Point(24, 58);
            this.chkRouteUseStartTime.Name = "chkRouteUseStartTime";
            this.chkRouteUseStartTime.Size = new System.Drawing.Size(125, 17);
            this.chkRouteUseStartTime.TabIndex = 93;
            this.chkRouteUseStartTime.Text = "Use Start Time";
            this.chkRouteUseStartTime.CheckedChanged += new System.EventHandler(this.chkRouteUseStartTime_CheckedChanged);
            // 
            // txtRouteStartTime
            // 
            this.txtRouteStartTime.Location = new System.Drawing.Point(181, 54);
            this.txtRouteStartTime.Name = "txtRouteStartTime";
            this.txtRouteStartTime.Size = new System.Drawing.Size(240, 21);
            this.txtRouteStartTime.TabIndex = 94;
            // 
            // chkRouteIgnoreInvalidLocations
            // 
            this.chkRouteIgnoreInvalidLocations.Location = new System.Drawing.Point(24, 271);
            this.chkRouteIgnoreInvalidLocations.Name = "chkRouteIgnoreInvalidLocations";
            this.chkRouteIgnoreInvalidLocations.Size = new System.Drawing.Size(173, 32);
            this.chkRouteIgnoreInvalidLocations.TabIndex = 81;
            this.chkRouteIgnoreInvalidLocations.Text = "Ignore Invalid Locations";
            // 
            // cboRouteRestrictUTurns
            // 
            this.cboRouteRestrictUTurns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteRestrictUTurns.ItemHeight = 12;
            this.cboRouteRestrictUTurns.Items.AddRange(new object[] {
            "No U-Turns",
            "Allow U-Turns",
            "Only At Dead Ends"});
            this.cboRouteRestrictUTurns.Location = new System.Drawing.Point(178, 191);
            this.cboRouteRestrictUTurns.Name = "cboRouteRestrictUTurns";
            this.cboRouteRestrictUTurns.Size = new System.Drawing.Size(240, 20);
            this.cboRouteRestrictUTurns.TabIndex = 80;
            // 
            // lblRouteRestrictUTurns
            // 
            this.lblRouteRestrictUTurns.Location = new System.Drawing.Point(24, 196);
            this.lblRouteRestrictUTurns.Name = "lblRouteRestrictUTurns";
            this.lblRouteRestrictUTurns.Size = new System.Drawing.Size(106, 17);
            this.lblRouteRestrictUTurns.TabIndex = 88;
            this.lblRouteRestrictUTurns.Text = "UTurn Policy";
            // 
            // lblRouteAccumulateAttributeNames
            // 
            this.lblRouteAccumulateAttributeNames.Location = new System.Drawing.Point(283, 306);
            this.lblRouteAccumulateAttributeNames.Name = "lblRouteAccumulateAttributeNames";
            this.lblRouteAccumulateAttributeNames.Size = new System.Drawing.Size(144, 17);
            this.lblRouteAccumulateAttributeNames.TabIndex = 87;
            this.lblRouteAccumulateAttributeNames.Text = "Accumulate Attributes";
            // 
            // chklstRouteAccumulateAttributeNames
            // 
            this.chklstRouteAccumulateAttributeNames.CheckOnClick = true;
            this.chklstRouteAccumulateAttributeNames.Location = new System.Drawing.Point(283, 323);
            this.chklstRouteAccumulateAttributeNames.Name = "chklstRouteAccumulateAttributeNames";
            this.chklstRouteAccumulateAttributeNames.ScrollAlwaysVisible = true;
            this.chklstRouteAccumulateAttributeNames.Size = new System.Drawing.Size(231, 20);
            this.chklstRouteAccumulateAttributeNames.TabIndex = 84;
            // 
            // lblRouteRestrictionAttributeNames
            // 
            this.lblRouteRestrictionAttributeNames.Location = new System.Drawing.Point(24, 306);
            this.lblRouteRestrictionAttributeNames.Name = "lblRouteRestrictionAttributeNames";
            this.lblRouteRestrictionAttributeNames.Size = new System.Drawing.Size(86, 17);
            this.lblRouteRestrictionAttributeNames.TabIndex = 86;
            this.lblRouteRestrictionAttributeNames.Text = "Restrictions";
            // 
            // chklstRouteRestrictionAttributeNames
            // 
            this.chklstRouteRestrictionAttributeNames.CheckOnClick = true;
            this.chklstRouteRestrictionAttributeNames.Location = new System.Drawing.Point(24, 323);
            this.chklstRouteRestrictionAttributeNames.Name = "chklstRouteRestrictionAttributeNames";
            this.chklstRouteRestrictionAttributeNames.ScrollAlwaysVisible = true;
            this.chklstRouteRestrictionAttributeNames.Size = new System.Drawing.Size(230, 20);
            this.chklstRouteRestrictionAttributeNames.TabIndex = 83;
            // 
            // cboRouteImpedance
            // 
            this.cboRouteImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteImpedance.ItemHeight = 12;
            this.cboRouteImpedance.Location = new System.Drawing.Point(181, 25);
            this.cboRouteImpedance.Name = "cboRouteImpedance";
            this.cboRouteImpedance.Size = new System.Drawing.Size(240, 20);
            this.cboRouteImpedance.TabIndex = 79;
            // 
            // lblRouteImpedance
            // 
            this.lblRouteImpedance.Location = new System.Drawing.Point(24, 30);
            this.lblRouteImpedance.Name = "lblRouteImpedance";
            this.lblRouteImpedance.Size = new System.Drawing.Size(77, 17);
            this.lblRouteImpedance.TabIndex = 85;
            this.lblRouteImpedance.Text = "Impedance";
            // 
            // chkRouteUseHierarchy
            // 
            this.chkRouteUseHierarchy.Location = new System.Drawing.Point(24, 246);
            this.chkRouteUseHierarchy.Name = "chkRouteUseHierarchy";
            this.chkRouteUseHierarchy.Size = new System.Drawing.Size(115, 28);
            this.chkRouteUseHierarchy.TabIndex = 82;
            this.chkRouteUseHierarchy.Text = "Use Hierarchy";
            // 
            // tabClosestFacility
            // 
            this.tabClosestFacility.Controls.Add(this.chkCFIgnoreInvalidLocations);
            this.tabClosestFacility.Controls.Add(this.cboCFRestrictUTurns);
            this.tabClosestFacility.Controls.Add(this.lblCFRestrictUTurns);
            this.tabClosestFacility.Controls.Add(this.lblCFAccumulateAttributeNames);
            this.tabClosestFacility.Controls.Add(this.chklstCFAccumulateAttributeNames);
            this.tabClosestFacility.Controls.Add(this.lblCFRestrictionAttributeNames);
            this.tabClosestFacility.Controls.Add(this.chklstCFRestrictionAttributeNames);
            this.tabClosestFacility.Controls.Add(this.cboCFImpedance);
            this.tabClosestFacility.Controls.Add(this.lblCFImpedance);
            this.tabClosestFacility.Controls.Add(this.chkCFUseHierarchy);
            this.tabClosestFacility.Controls.Add(this.cboCFOutputLines);
            this.tabClosestFacility.Controls.Add(this.lblCFOutputLines);
            this.tabClosestFacility.Controls.Add(this.cboCFTravelDirection);
            this.tabClosestFacility.Controls.Add(this.lblCFTravelDirection);
            this.tabClosestFacility.Controls.Add(this.txtCFDefaultTargetFacilityCount);
            this.tabClosestFacility.Controls.Add(this.lblCFDefaultTargetFacilityCount);
            this.tabClosestFacility.Controls.Add(this.txtCFDefaultCutoff);
            this.tabClosestFacility.Controls.Add(this.lblCFDefaultCutoff);
            this.tabClosestFacility.Location = new System.Drawing.Point(4, 22);
            this.tabClosestFacility.Name = "tabClosestFacility";
            this.tabClosestFacility.Size = new System.Drawing.Size(708, 430);
            this.tabClosestFacility.TabIndex = 3;
            this.tabClosestFacility.Text = "Closest Facility";
            this.tabClosestFacility.UseVisualStyleBackColor = true;
            // 
            // chkCFIgnoreInvalidLocations
            // 
            this.chkCFIgnoreInvalidLocations.Location = new System.Drawing.Point(24, 237);
            this.chkCFIgnoreInvalidLocations.Name = "chkCFIgnoreInvalidLocations";
            this.chkCFIgnoreInvalidLocations.Size = new System.Drawing.Size(173, 31);
            this.chkCFIgnoreInvalidLocations.TabIndex = 105;
            this.chkCFIgnoreInvalidLocations.Text = "Ignore Invalid Locations";
            // 
            // cboCFRestrictUTurns
            // 
            this.cboCFRestrictUTurns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCFRestrictUTurns.ItemHeight = 12;
            this.cboCFRestrictUTurns.Items.AddRange(new object[] {
            "No U-Turns",
            "Allow U-Turns",
            "Only At Dead Ends"});
            this.cboCFRestrictUTurns.Location = new System.Drawing.Point(181, 139);
            this.cboCFRestrictUTurns.Name = "cboCFRestrictUTurns";
            this.cboCFRestrictUTurns.Size = new System.Drawing.Size(240, 20);
            this.cboCFRestrictUTurns.TabIndex = 104;
            // 
            // lblCFRestrictUTurns
            // 
            this.lblCFRestrictUTurns.Location = new System.Drawing.Point(24, 144);
            this.lblCFRestrictUTurns.Name = "lblCFRestrictUTurns";
            this.lblCFRestrictUTurns.Size = new System.Drawing.Size(106, 18);
            this.lblCFRestrictUTurns.TabIndex = 112;
            this.lblCFRestrictUTurns.Text = "UTurn Policy";
            // 
            // lblCFAccumulateAttributeNames
            // 
            this.lblCFAccumulateAttributeNames.Location = new System.Drawing.Point(283, 271);
            this.lblCFAccumulateAttributeNames.Name = "lblCFAccumulateAttributeNames";
            this.lblCFAccumulateAttributeNames.Size = new System.Drawing.Size(144, 18);
            this.lblCFAccumulateAttributeNames.TabIndex = 111;
            this.lblCFAccumulateAttributeNames.Text = "Accumulate Attributes";
            // 
            // chklstCFAccumulateAttributeNames
            // 
            this.chklstCFAccumulateAttributeNames.CheckOnClick = true;
            this.chklstCFAccumulateAttributeNames.Location = new System.Drawing.Point(283, 289);
            this.chklstCFAccumulateAttributeNames.Name = "chklstCFAccumulateAttributeNames";
            this.chklstCFAccumulateAttributeNames.ScrollAlwaysVisible = true;
            this.chklstCFAccumulateAttributeNames.Size = new System.Drawing.Size(231, 20);
            this.chklstCFAccumulateAttributeNames.TabIndex = 108;
            // 
            // lblCFRestrictionAttributeNames
            // 
            this.lblCFRestrictionAttributeNames.Location = new System.Drawing.Point(24, 271);
            this.lblCFRestrictionAttributeNames.Name = "lblCFRestrictionAttributeNames";
            this.lblCFRestrictionAttributeNames.Size = new System.Drawing.Size(86, 18);
            this.lblCFRestrictionAttributeNames.TabIndex = 110;
            this.lblCFRestrictionAttributeNames.Text = "Restrictions";
            // 
            // chklstCFRestrictionAttributeNames
            // 
            this.chklstCFRestrictionAttributeNames.CheckOnClick = true;
            this.chklstCFRestrictionAttributeNames.Location = new System.Drawing.Point(24, 289);
            this.chklstCFRestrictionAttributeNames.Name = "chklstCFRestrictionAttributeNames";
            this.chklstCFRestrictionAttributeNames.ScrollAlwaysVisible = true;
            this.chklstCFRestrictionAttributeNames.Size = new System.Drawing.Size(230, 20);
            this.chklstCFRestrictionAttributeNames.TabIndex = 107;
            // 
            // cboCFImpedance
            // 
            this.cboCFImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCFImpedance.ItemHeight = 12;
            this.cboCFImpedance.Location = new System.Drawing.Point(181, 25);
            this.cboCFImpedance.Name = "cboCFImpedance";
            this.cboCFImpedance.Size = new System.Drawing.Size(240, 20);
            this.cboCFImpedance.TabIndex = 103;
            // 
            // lblCFImpedance
            // 
            this.lblCFImpedance.Location = new System.Drawing.Point(24, 30);
            this.lblCFImpedance.Name = "lblCFImpedance";
            this.lblCFImpedance.Size = new System.Drawing.Size(77, 17);
            this.lblCFImpedance.TabIndex = 109;
            this.lblCFImpedance.Text = "Impedance";
            // 
            // chkCFUseHierarchy
            // 
            this.chkCFUseHierarchy.Location = new System.Drawing.Point(24, 202);
            this.chkCFUseHierarchy.Name = "chkCFUseHierarchy";
            this.chkCFUseHierarchy.Size = new System.Drawing.Size(115, 28);
            this.chkCFUseHierarchy.TabIndex = 106;
            this.chkCFUseHierarchy.Text = "Use Hierarchy";
            // 
            // cboCFOutputLines
            // 
            this.cboCFOutputLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCFOutputLines.ItemHeight = 12;
            this.cboCFOutputLines.Items.AddRange(new object[] {
            "No Lines",
            "Straight Lines",
            "True Shape",
            "True Shape With Measures"});
            this.cboCFOutputLines.Location = new System.Drawing.Point(181, 168);
            this.cboCFOutputLines.Name = "cboCFOutputLines";
            this.cboCFOutputLines.Size = new System.Drawing.Size(240, 20);
            this.cboCFOutputLines.TabIndex = 101;
            // 
            // lblCFOutputLines
            // 
            this.lblCFOutputLines.Location = new System.Drawing.Point(24, 173);
            this.lblCFOutputLines.Name = "lblCFOutputLines";
            this.lblCFOutputLines.Size = new System.Drawing.Size(137, 18);
            this.lblCFOutputLines.TabIndex = 102;
            this.lblCFOutputLines.Text = "Shape";
            // 
            // cboCFTravelDirection
            // 
            this.cboCFTravelDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCFTravelDirection.ItemHeight = 12;
            this.cboCFTravelDirection.Items.AddRange(new object[] {
            "From Facility",
            "To Facility"});
            this.cboCFTravelDirection.Location = new System.Drawing.Point(181, 110);
            this.cboCFTravelDirection.Name = "cboCFTravelDirection";
            this.cboCFTravelDirection.Size = new System.Drawing.Size(240, 20);
            this.cboCFTravelDirection.TabIndex = 99;
            // 
            // lblCFTravelDirection
            // 
            this.lblCFTravelDirection.Location = new System.Drawing.Point(24, 115);
            this.lblCFTravelDirection.Name = "lblCFTravelDirection";
            this.lblCFTravelDirection.Size = new System.Drawing.Size(137, 17);
            this.lblCFTravelDirection.TabIndex = 100;
            this.lblCFTravelDirection.Text = "Travel Direction";
            // 
            // txtCFDefaultTargetFacilityCount
            // 
            this.txtCFDefaultTargetFacilityCount.Location = new System.Drawing.Point(181, 82);
            this.txtCFDefaultTargetFacilityCount.Name = "txtCFDefaultTargetFacilityCount";
            this.txtCFDefaultTargetFacilityCount.Size = new System.Drawing.Size(240, 21);
            this.txtCFDefaultTargetFacilityCount.TabIndex = 98;
            // 
            // lblCFDefaultTargetFacilityCount
            // 
            this.lblCFDefaultTargetFacilityCount.Location = new System.Drawing.Point(24, 86);
            this.lblCFDefaultTargetFacilityCount.Name = "lblCFDefaultTargetFacilityCount";
            this.lblCFDefaultTargetFacilityCount.Size = new System.Drawing.Size(137, 17);
            this.lblCFDefaultTargetFacilityCount.TabIndex = 97;
            this.lblCFDefaultTargetFacilityCount.Text = "Number of Facilities";
            // 
            // txtCFDefaultCutoff
            // 
            this.txtCFDefaultCutoff.Location = new System.Drawing.Point(181, 54);
            this.txtCFDefaultCutoff.Name = "txtCFDefaultCutoff";
            this.txtCFDefaultCutoff.Size = new System.Drawing.Size(240, 21);
            this.txtCFDefaultCutoff.TabIndex = 96;
            // 
            // lblCFDefaultCutoff
            // 
            this.lblCFDefaultCutoff.Location = new System.Drawing.Point(24, 58);
            this.lblCFDefaultCutoff.Name = "lblCFDefaultCutoff";
            this.lblCFDefaultCutoff.Size = new System.Drawing.Size(137, 17);
            this.lblCFDefaultCutoff.TabIndex = 95;
            this.lblCFDefaultCutoff.Text = "Default Cutoff";
            // 
            // tabODCostMatrix
            // 
            this.tabODCostMatrix.Controls.Add(this.chkODIgnoreInvalidLocations);
            this.tabODCostMatrix.Controls.Add(this.cboODRestrictUTurns);
            this.tabODCostMatrix.Controls.Add(this.lblODRestrictUTurns);
            this.tabODCostMatrix.Controls.Add(this.lblODAccumulateAttributeNames);
            this.tabODCostMatrix.Controls.Add(this.chklstODAccumulateAttributeNames);
            this.tabODCostMatrix.Controls.Add(this.lblODRestrictionAttributeNames);
            this.tabODCostMatrix.Controls.Add(this.chklstODRestrictionAttributeNames);
            this.tabODCostMatrix.Controls.Add(this.cboODImpedance);
            this.tabODCostMatrix.Controls.Add(this.lblODImpedance);
            this.tabODCostMatrix.Controls.Add(this.chkODUseHierarchy);
            this.tabODCostMatrix.Controls.Add(this.cboODOutputLines);
            this.tabODCostMatrix.Controls.Add(this.lblODOutputLines);
            this.tabODCostMatrix.Controls.Add(this.txtODDefaultTargetDestinationCount);
            this.tabODCostMatrix.Controls.Add(this.lblODDefaultTargetDestinationCount);
            this.tabODCostMatrix.Controls.Add(this.txtODDefaultCutoff);
            this.tabODCostMatrix.Controls.Add(this.lblODDefaultCutoff);
            this.tabODCostMatrix.Location = new System.Drawing.Point(4, 22);
            this.tabODCostMatrix.Name = "tabODCostMatrix";
            this.tabODCostMatrix.Size = new System.Drawing.Size(708, 430);
            this.tabODCostMatrix.TabIndex = 4;
            this.tabODCostMatrix.Text = "Origin-Destination Cost Matrix";
            this.tabODCostMatrix.UseVisualStyleBackColor = true;
            // 
            // chkODIgnoreInvalidLocations
            // 
            this.chkODIgnoreInvalidLocations.Location = new System.Drawing.Point(24, 211);
            this.chkODIgnoreInvalidLocations.Name = "chkODIgnoreInvalidLocations";
            this.chkODIgnoreInvalidLocations.Size = new System.Drawing.Size(173, 31);
            this.chkODIgnoreInvalidLocations.TabIndex = 123;
            this.chkODIgnoreInvalidLocations.Text = "Ignore Invalid Locations";
            // 
            // cboODRestrictUTurns
            // 
            this.cboODRestrictUTurns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboODRestrictUTurns.ItemHeight = 12;
            this.cboODRestrictUTurns.Items.AddRange(new object[] {
            "No U-Turns",
            "Allow U-Turns",
            "Only At Dead Ends"});
            this.cboODRestrictUTurns.Location = new System.Drawing.Point(181, 113);
            this.cboODRestrictUTurns.Name = "cboODRestrictUTurns";
            this.cboODRestrictUTurns.Size = new System.Drawing.Size(240, 20);
            this.cboODRestrictUTurns.TabIndex = 122;
            // 
            // lblODRestrictUTurns
            // 
            this.lblODRestrictUTurns.Location = new System.Drawing.Point(24, 118);
            this.lblODRestrictUTurns.Name = "lblODRestrictUTurns";
            this.lblODRestrictUTurns.Size = new System.Drawing.Size(106, 18);
            this.lblODRestrictUTurns.TabIndex = 130;
            this.lblODRestrictUTurns.Text = "UTurn Policy";
            // 
            // lblODAccumulateAttributeNames
            // 
            this.lblODAccumulateAttributeNames.Location = new System.Drawing.Point(283, 246);
            this.lblODAccumulateAttributeNames.Name = "lblODAccumulateAttributeNames";
            this.lblODAccumulateAttributeNames.Size = new System.Drawing.Size(144, 17);
            this.lblODAccumulateAttributeNames.TabIndex = 129;
            this.lblODAccumulateAttributeNames.Text = "Accumulate Attributes";
            // 
            // chklstODAccumulateAttributeNames
            // 
            this.chklstODAccumulateAttributeNames.CheckOnClick = true;
            this.chklstODAccumulateAttributeNames.Location = new System.Drawing.Point(283, 263);
            this.chklstODAccumulateAttributeNames.Name = "chklstODAccumulateAttributeNames";
            this.chklstODAccumulateAttributeNames.ScrollAlwaysVisible = true;
            this.chklstODAccumulateAttributeNames.Size = new System.Drawing.Size(231, 20);
            this.chklstODAccumulateAttributeNames.TabIndex = 126;
            // 
            // lblODRestrictionAttributeNames
            // 
            this.lblODRestrictionAttributeNames.Location = new System.Drawing.Point(24, 246);
            this.lblODRestrictionAttributeNames.Name = "lblODRestrictionAttributeNames";
            this.lblODRestrictionAttributeNames.Size = new System.Drawing.Size(86, 17);
            this.lblODRestrictionAttributeNames.TabIndex = 128;
            this.lblODRestrictionAttributeNames.Text = "Restrictions";
            // 
            // chklstODRestrictionAttributeNames
            // 
            this.chklstODRestrictionAttributeNames.CheckOnClick = true;
            this.chklstODRestrictionAttributeNames.Location = new System.Drawing.Point(24, 263);
            this.chklstODRestrictionAttributeNames.Name = "chklstODRestrictionAttributeNames";
            this.chklstODRestrictionAttributeNames.ScrollAlwaysVisible = true;
            this.chklstODRestrictionAttributeNames.Size = new System.Drawing.Size(230, 20);
            this.chklstODRestrictionAttributeNames.TabIndex = 125;
            // 
            // cboODImpedance
            // 
            this.cboODImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboODImpedance.ItemHeight = 12;
            this.cboODImpedance.Location = new System.Drawing.Point(181, 25);
            this.cboODImpedance.Name = "cboODImpedance";
            this.cboODImpedance.Size = new System.Drawing.Size(240, 20);
            this.cboODImpedance.TabIndex = 121;
            // 
            // lblODImpedance
            // 
            this.lblODImpedance.Location = new System.Drawing.Point(24, 30);
            this.lblODImpedance.Name = "lblODImpedance";
            this.lblODImpedance.Size = new System.Drawing.Size(77, 17);
            this.lblODImpedance.TabIndex = 127;
            this.lblODImpedance.Text = "Impedance";
            // 
            // chkODUseHierarchy
            // 
            this.chkODUseHierarchy.Location = new System.Drawing.Point(24, 177);
            this.chkODUseHierarchy.Name = "chkODUseHierarchy";
            this.chkODUseHierarchy.Size = new System.Drawing.Size(115, 28);
            this.chkODUseHierarchy.TabIndex = 124;
            this.chkODUseHierarchy.Text = "Use Hierarchy";
            // 
            // cboODOutputLines
            // 
            this.cboODOutputLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboODOutputLines.ItemHeight = 12;
            this.cboODOutputLines.Items.AddRange(new object[] {
            "No Lines",
            "Straight Lines"});
            this.cboODOutputLines.Location = new System.Drawing.Point(181, 142);
            this.cboODOutputLines.Name = "cboODOutputLines";
            this.cboODOutputLines.Size = new System.Drawing.Size(240, 20);
            this.cboODOutputLines.TabIndex = 119;
            // 
            // lblODOutputLines
            // 
            this.lblODOutputLines.Location = new System.Drawing.Point(24, 148);
            this.lblODOutputLines.Name = "lblODOutputLines";
            this.lblODOutputLines.Size = new System.Drawing.Size(137, 17);
            this.lblODOutputLines.TabIndex = 120;
            this.lblODOutputLines.Text = "Shape";
            // 
            // txtODDefaultTargetDestinationCount
            // 
            this.txtODDefaultTargetDestinationCount.Location = new System.Drawing.Point(181, 82);
            this.txtODDefaultTargetDestinationCount.Name = "txtODDefaultTargetDestinationCount";
            this.txtODDefaultTargetDestinationCount.Size = new System.Drawing.Size(240, 21);
            this.txtODDefaultTargetDestinationCount.TabIndex = 116;
            // 
            // lblODDefaultTargetDestinationCount
            // 
            this.lblODDefaultTargetDestinationCount.Location = new System.Drawing.Point(24, 86);
            this.lblODDefaultTargetDestinationCount.Name = "lblODDefaultTargetDestinationCount";
            this.lblODDefaultTargetDestinationCount.Size = new System.Drawing.Size(150, 17);
            this.lblODDefaultTargetDestinationCount.TabIndex = 115;
            this.lblODDefaultTargetDestinationCount.Text = "Number of Destinations";
            // 
            // txtODDefaultCutoff
            // 
            this.txtODDefaultCutoff.Location = new System.Drawing.Point(181, 54);
            this.txtODDefaultCutoff.Name = "txtODDefaultCutoff";
            this.txtODDefaultCutoff.Size = new System.Drawing.Size(240, 21);
            this.txtODDefaultCutoff.TabIndex = 114;
            // 
            // lblODDefaultCutoff
            // 
            this.lblODDefaultCutoff.Location = new System.Drawing.Point(24, 58);
            this.lblODDefaultCutoff.Name = "lblODDefaultCutoff";
            this.lblODDefaultCutoff.Size = new System.Drawing.Size(137, 17);
            this.lblODDefaultCutoff.TabIndex = 113;
            this.lblODDefaultCutoff.Text = "Default Cutoff";
            // 
            // tabServiceArea
            // 
            this.tabServiceArea.Controls.Add(this.cboSATrimPolygonDistanceUnits);
            this.tabServiceArea.Controls.Add(this.txtSATrimPolygonDistance);
            this.tabServiceArea.Controls.Add(this.chkSATrimOuterPolygon);
            this.tabServiceArea.Controls.Add(this.chkSAIncludeSourceInformationOnLines);
            this.tabServiceArea.Controls.Add(this.cboSATravelDirection);
            this.tabServiceArea.Controls.Add(this.lblSATravelDirection);
            this.tabServiceArea.Controls.Add(this.chkSASplitPolygonsAtBreaks);
            this.tabServiceArea.Controls.Add(this.chkSAOverlapPolygons);
            this.tabServiceArea.Controls.Add(this.chkSASplitLinesAtBreaks);
            this.tabServiceArea.Controls.Add(this.chkSAOverlapLines);
            this.tabServiceArea.Controls.Add(this.chkSAIgnoreInvalidLocations);
            this.tabServiceArea.Controls.Add(this.cboSARestrictUTurns);
            this.tabServiceArea.Controls.Add(this.lblSARestrictUTurns);
            this.tabServiceArea.Controls.Add(this.lblSAAccumulateAttributeNames);
            this.tabServiceArea.Controls.Add(this.chklstSAAccumulateAttributeNames);
            this.tabServiceArea.Controls.Add(this.lblSARestrictionAttributeNames);
            this.tabServiceArea.Controls.Add(this.chklstSARestrictionAttributeNames);
            this.tabServiceArea.Controls.Add(this.lblSAOutputPolygons);
            this.tabServiceArea.Controls.Add(this.cboSAOutputPolygons);
            this.tabServiceArea.Controls.Add(this.lblSAOutputLines);
            this.tabServiceArea.Controls.Add(this.cboSAOutputLines);
            this.tabServiceArea.Controls.Add(this.chkSAMergeSimilarPolygonRanges);
            this.tabServiceArea.Controls.Add(this.txtSADefaultBreaks);
            this.tabServiceArea.Controls.Add(this.lblSADefaultBreaks);
            this.tabServiceArea.Controls.Add(this.cboSAImpedance);
            this.tabServiceArea.Controls.Add(this.lblSAImpedance);
            this.tabServiceArea.Location = new System.Drawing.Point(4, 22);
            this.tabServiceArea.Name = "tabServiceArea";
            this.tabServiceArea.Size = new System.Drawing.Size(708, 430);
            this.tabServiceArea.TabIndex = 2;
            this.tabServiceArea.Text = "Service Area";
            this.tabServiceArea.UseVisualStyleBackColor = true;
            // 
            // cboSATrimPolygonDistanceUnits
            // 
            this.cboSATrimPolygonDistanceUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSATrimPolygonDistanceUnits.ItemHeight = 12;
            this.cboSATrimPolygonDistanceUnits.Items.AddRange(new object[] {
            "Unknown Units",
            "Inches",
            "Points",
            "Feet",
            "Yards",
            "Miles",
            "Nautical Miles",
            "Millimeters",
            "Centimeters",
            "Meters",
            "Kilometers",
            "DecimalDegrees",
            "Decimeters"});
            this.cboSATrimPolygonDistanceUnits.Location = new System.Drawing.Point(289, 166);
            this.cboSATrimPolygonDistanceUnits.Name = "cboSATrimPolygonDistanceUnits";
            this.cboSATrimPolygonDistanceUnits.Size = new System.Drawing.Size(132, 20);
            this.cboSATrimPolygonDistanceUnits.TabIndex = 120;
            // 
            // txtSATrimPolygonDistance
            // 
            this.txtSATrimPolygonDistance.Location = new System.Drawing.Point(203, 167);
            this.txtSATrimPolygonDistance.Name = "txtSATrimPolygonDistance";
            this.txtSATrimPolygonDistance.Size = new System.Drawing.Size(79, 21);
            this.txtSATrimPolygonDistance.TabIndex = 119;
            // 
            // chkSATrimOuterPolygon
            // 
            this.chkSATrimOuterPolygon.Location = new System.Drawing.Point(49, 167);
            this.chkSATrimOuterPolygon.Name = "chkSATrimOuterPolygon";
            this.chkSATrimOuterPolygon.Size = new System.Drawing.Size(147, 24);
            this.chkSATrimOuterPolygon.TabIndex = 118;
            this.chkSATrimOuterPolygon.Text = "Trim Outer Polygon";
            // 
            // chkSAIncludeSourceInformationOnLines
            // 
            this.chkSAIncludeSourceInformationOnLines.Location = new System.Drawing.Point(395, 226);
            this.chkSAIncludeSourceInformationOnLines.Name = "chkSAIncludeSourceInformationOnLines";
            this.chkSAIncludeSourceInformationOnLines.Size = new System.Drawing.Size(258, 24);
            this.chkSAIncludeSourceInformationOnLines.TabIndex = 117;
            this.chkSAIncludeSourceInformationOnLines.Text = "Include Source Information On Lines";
            // 
            // cboSATravelDirection
            // 
            this.cboSATravelDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSATravelDirection.ItemHeight = 12;
            this.cboSATravelDirection.Items.AddRange(new object[] {
            "From Facility",
            "To Facility"});
            this.cboSATravelDirection.Location = new System.Drawing.Point(181, 82);
            this.cboSATravelDirection.Name = "cboSATravelDirection";
            this.cboSATravelDirection.Size = new System.Drawing.Size(240, 20);
            this.cboSATravelDirection.TabIndex = 115;
            // 
            // lblSATravelDirection
            // 
            this.lblSATravelDirection.Location = new System.Drawing.Point(24, 87);
            this.lblSATravelDirection.Name = "lblSATravelDirection";
            this.lblSATravelDirection.Size = new System.Drawing.Size(137, 17);
            this.lblSATravelDirection.TabIndex = 116;
            this.lblSATravelDirection.Text = "Travel Direction";
            // 
            // chkSASplitPolygonsAtBreaks
            // 
            this.chkSASplitPolygonsAtBreaks.Location = new System.Drawing.Point(203, 141);
            this.chkSASplitPolygonsAtBreaks.Name = "chkSASplitPolygonsAtBreaks";
            this.chkSASplitPolygonsAtBreaks.Size = new System.Drawing.Size(185, 24);
            this.chkSASplitPolygonsAtBreaks.TabIndex = 114;
            this.chkSASplitPolygonsAtBreaks.Text = "Split Polygons At Breaks";
            // 
            // chkSAOverlapPolygons
            // 
            this.chkSAOverlapPolygons.Location = new System.Drawing.Point(49, 140);
            this.chkSAOverlapPolygons.Name = "chkSAOverlapPolygons";
            this.chkSAOverlapPolygons.Size = new System.Drawing.Size(147, 24);
            this.chkSAOverlapPolygons.TabIndex = 113;
            this.chkSAOverlapPolygons.Text = "Overlap Polygons";
            // 
            // chkSASplitLinesAtBreaks
            // 
            this.chkSASplitLinesAtBreaks.Location = new System.Drawing.Point(203, 226);
            this.chkSASplitLinesAtBreaks.Name = "chkSASplitLinesAtBreaks";
            this.chkSASplitLinesAtBreaks.Size = new System.Drawing.Size(185, 24);
            this.chkSASplitLinesAtBreaks.TabIndex = 112;
            this.chkSASplitLinesAtBreaks.Text = "Split Lines At Breaks";
            // 
            // chkSAOverlapLines
            // 
            this.chkSAOverlapLines.Location = new System.Drawing.Point(49, 226);
            this.chkSAOverlapLines.Name = "chkSAOverlapLines";
            this.chkSAOverlapLines.Size = new System.Drawing.Size(147, 24);
            this.chkSAOverlapLines.TabIndex = 111;
            this.chkSAOverlapLines.Text = "Overlap Lines";
            // 
            // chkSAIgnoreInvalidLocations
            // 
            this.chkSAIgnoreInvalidLocations.Location = new System.Drawing.Point(28, 284);
            this.chkSAIgnoreInvalidLocations.Name = "chkSAIgnoreInvalidLocations";
            this.chkSAIgnoreInvalidLocations.Size = new System.Drawing.Size(172, 32);
            this.chkSAIgnoreInvalidLocations.TabIndex = 105;
            this.chkSAIgnoreInvalidLocations.Text = "Ignore Invalid Locations";
            // 
            // cboSARestrictUTurns
            // 
            this.cboSARestrictUTurns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSARestrictUTurns.ItemHeight = 12;
            this.cboSARestrictUTurns.Items.AddRange(new object[] {
            "No U-Turns",
            "Allow U-Turns",
            "Only At Dead Ends"});
            this.cboSARestrictUTurns.Location = new System.Drawing.Point(181, 258);
            this.cboSARestrictUTurns.Name = "cboSARestrictUTurns";
            this.cboSARestrictUTurns.Size = new System.Drawing.Size(240, 20);
            this.cboSARestrictUTurns.TabIndex = 104;
            // 
            // lblSARestrictUTurns
            // 
            this.lblSARestrictUTurns.Location = new System.Drawing.Point(24, 264);
            this.lblSARestrictUTurns.Name = "lblSARestrictUTurns";
            this.lblSARestrictUTurns.Size = new System.Drawing.Size(106, 17);
            this.lblSARestrictUTurns.TabIndex = 110;
            this.lblSARestrictUTurns.Text = "UTurn Policy";
            // 
            // lblSAAccumulateAttributeNames
            // 
            this.lblSAAccumulateAttributeNames.Location = new System.Drawing.Point(286, 318);
            this.lblSAAccumulateAttributeNames.Name = "lblSAAccumulateAttributeNames";
            this.lblSAAccumulateAttributeNames.Size = new System.Drawing.Size(144, 17);
            this.lblSAAccumulateAttributeNames.TabIndex = 109;
            this.lblSAAccumulateAttributeNames.Text = "Accumulate Attributes";
            // 
            // chklstSAAccumulateAttributeNames
            // 
            this.chklstSAAccumulateAttributeNames.CheckOnClick = true;
            this.chklstSAAccumulateAttributeNames.Location = new System.Drawing.Point(286, 335);
            this.chklstSAAccumulateAttributeNames.Name = "chklstSAAccumulateAttributeNames";
            this.chklstSAAccumulateAttributeNames.ScrollAlwaysVisible = true;
            this.chklstSAAccumulateAttributeNames.Size = new System.Drawing.Size(230, 20);
            this.chklstSAAccumulateAttributeNames.TabIndex = 107;
            // 
            // lblSARestrictionAttributeNames
            // 
            this.lblSARestrictionAttributeNames.Location = new System.Drawing.Point(26, 318);
            this.lblSARestrictionAttributeNames.Name = "lblSARestrictionAttributeNames";
            this.lblSARestrictionAttributeNames.Size = new System.Drawing.Size(87, 17);
            this.lblSARestrictionAttributeNames.TabIndex = 108;
            this.lblSARestrictionAttributeNames.Text = "Restrictions";
            // 
            // chklstSARestrictionAttributeNames
            // 
            this.chklstSARestrictionAttributeNames.CheckOnClick = true;
            this.chklstSARestrictionAttributeNames.Location = new System.Drawing.Point(26, 335);
            this.chklstSARestrictionAttributeNames.Name = "chklstSARestrictionAttributeNames";
            this.chklstSARestrictionAttributeNames.ScrollAlwaysVisible = true;
            this.chklstSARestrictionAttributeNames.Size = new System.Drawing.Size(231, 20);
            this.chklstSARestrictionAttributeNames.TabIndex = 106;
            // 
            // lblSAOutputPolygons
            // 
            this.lblSAOutputPolygons.Location = new System.Drawing.Point(24, 116);
            this.lblSAOutputPolygons.Name = "lblSAOutputPolygons";
            this.lblSAOutputPolygons.Size = new System.Drawing.Size(146, 18);
            this.lblSAOutputPolygons.TabIndex = 103;
            this.lblSAOutputPolygons.Text = "Output Polygons";
            // 
            // cboSAOutputPolygons
            // 
            this.cboSAOutputPolygons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSAOutputPolygons.ItemHeight = 12;
            this.cboSAOutputPolygons.Items.AddRange(new object[] {
            "No Polygons",
            "Simplified Polygons",
            "Detailed Polygons"});
            this.cboSAOutputPolygons.Location = new System.Drawing.Point(181, 111);
            this.cboSAOutputPolygons.Name = "cboSAOutputPolygons";
            this.cboSAOutputPolygons.Size = new System.Drawing.Size(240, 20);
            this.cboSAOutputPolygons.TabIndex = 102;
            this.cboSAOutputPolygons.SelectedIndexChanged += new System.EventHandler(this.cboSAOutputPolygons_SelectedIndexChanged);
            // 
            // lblSAOutputLines
            // 
            this.lblSAOutputLines.Location = new System.Drawing.Point(24, 202);
            this.lblSAOutputLines.Name = "lblSAOutputLines";
            this.lblSAOutputLines.Size = new System.Drawing.Size(146, 18);
            this.lblSAOutputLines.TabIndex = 101;
            this.lblSAOutputLines.Text = "Output Lines";
            // 
            // cboSAOutputLines
            // 
            this.cboSAOutputLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSAOutputLines.ItemHeight = 12;
            this.cboSAOutputLines.Items.AddRange(new object[] {
            "No Lines",
            "True Shape",
            "True Shape With Measures"});
            this.cboSAOutputLines.Location = new System.Drawing.Point(181, 197);
            this.cboSAOutputLines.Name = "cboSAOutputLines";
            this.cboSAOutputLines.Size = new System.Drawing.Size(240, 20);
            this.cboSAOutputLines.TabIndex = 100;
            this.cboSAOutputLines.SelectedIndexChanged += new System.EventHandler(this.cboSAOutputLines_SelectedIndexChanged);
            // 
            // chkSAMergeSimilarPolygonRanges
            // 
            this.chkSAMergeSimilarPolygonRanges.Location = new System.Drawing.Point(395, 140);
            this.chkSAMergeSimilarPolygonRanges.Name = "chkSAMergeSimilarPolygonRanges";
            this.chkSAMergeSimilarPolygonRanges.Size = new System.Drawing.Size(230, 24);
            this.chkSAMergeSimilarPolygonRanges.TabIndex = 99;
            this.chkSAMergeSimilarPolygonRanges.Text = "Merge Similar Polygon Ranges";
            // 
            // txtSADefaultBreaks
            // 
            this.txtSADefaultBreaks.Location = new System.Drawing.Point(181, 54);
            this.txtSADefaultBreaks.Name = "txtSADefaultBreaks";
            this.txtSADefaultBreaks.Size = new System.Drawing.Size(240, 21);
            this.txtSADefaultBreaks.TabIndex = 98;
            // 
            // lblSADefaultBreaks
            // 
            this.lblSADefaultBreaks.Location = new System.Drawing.Point(24, 58);
            this.lblSADefaultBreaks.Name = "lblSADefaultBreaks";
            this.lblSADefaultBreaks.Size = new System.Drawing.Size(137, 17);
            this.lblSADefaultBreaks.TabIndex = 97;
            this.lblSADefaultBreaks.Text = "Default Breaks";
            // 
            // cboSAImpedance
            // 
            this.cboSAImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSAImpedance.ItemHeight = 12;
            this.cboSAImpedance.Location = new System.Drawing.Point(181, 25);
            this.cboSAImpedance.Name = "cboSAImpedance";
            this.cboSAImpedance.Size = new System.Drawing.Size(240, 20);
            this.cboSAImpedance.TabIndex = 86;
            // 
            // lblSAImpedance
            // 
            this.lblSAImpedance.Location = new System.Drawing.Point(24, 30);
            this.lblSAImpedance.Name = "lblSAImpedance";
            this.lblSAImpedance.Size = new System.Drawing.Size(77, 17);
            this.lblSAImpedance.TabIndex = 87;
            this.lblSAImpedance.Text = "Impedance";
            // 
            // tabVRP
            // 
            this.tabVRP.Controls.Add(this.gbRestrictions);
            this.tabVRP.Controls.Add(this.gbSettings);
            this.tabVRP.Location = new System.Drawing.Point(4, 22);
            this.tabVRP.Name = "tabVRP";
            this.tabVRP.Size = new System.Drawing.Size(708, 430);
            this.tabVRP.TabIndex = 5;
            this.tabVRP.Text = "VRP";
            this.tabVRP.UseVisualStyleBackColor = true;
            // 
            // gbRestrictions
            // 
            this.gbRestrictions.Controls.Add(this.chklstVRPRestrictionAttributeNames);
            this.gbRestrictions.Location = new System.Drawing.Point(419, 3);
            this.gbRestrictions.Name = "gbRestrictions";
            this.gbRestrictions.Size = new System.Drawing.Size(247, 97);
            this.gbRestrictions.TabIndex = 1;
            this.gbRestrictions.TabStop = false;
            this.gbRestrictions.Text = "Restrictions";
            // 
            // chklstVRPRestrictionAttributeNames
            // 
            this.chklstVRPRestrictionAttributeNames.CheckOnClick = true;
            this.chklstVRPRestrictionAttributeNames.Location = new System.Drawing.Point(7, 15);
            this.chklstVRPRestrictionAttributeNames.Name = "chklstVRPRestrictionAttributeNames";
            this.chklstVRPRestrictionAttributeNames.ScrollAlwaysVisible = true;
            this.chklstVRPRestrictionAttributeNames.Size = new System.Drawing.Size(231, 20);
            this.chklstVRPRestrictionAttributeNames.TabIndex = 109;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.cboVRPDistanceFieldUnits);
            this.gbSettings.Controls.Add(this.cboVRPTransitTime);
            this.gbSettings.Controls.Add(this.cboVRPTimeWindow);
            this.gbSettings.Controls.Add(this.label10);
            this.gbSettings.Controls.Add(this.label9);
            this.gbSettings.Controls.Add(this.chkVRPUseHierarchy);
            this.gbSettings.Controls.Add(this.cboVRPOutputShapeType);
            this.gbSettings.Controls.Add(this.cboVRPAllowUTurns);
            this.gbSettings.Controls.Add(this.cboVRPTimeFieldUnits);
            this.gbSettings.Controls.Add(this.txtVRPCapacityCount);
            this.gbSettings.Controls.Add(this.txtVRPDefaultDate);
            this.gbSettings.Controls.Add(this.cboVRPDistanceAttribute);
            this.gbSettings.Controls.Add(this.cboVRPTimeAttribute);
            this.gbSettings.Controls.Add(this.label7);
            this.gbSettings.Controls.Add(this.label6);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.lblTimeAttribute);
            this.gbSettings.Location = new System.Drawing.Point(4, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(408, 346);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // cboVRPDistanceFieldUnits
            // 
            this.cboVRPDistanceFieldUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPDistanceFieldUnits.ItemHeight = 12;
            this.cboVRPDistanceFieldUnits.Items.AddRange(new object[] {
            "Inches",
            "Points",
            "Feet",
            "Yards",
            "Miles",
            "Nautical Miles",
            "Millimeters",
            "Centimeters",
            "Meters",
            "Kilometers",
            "DecimalDegrees",
            "Decimeters"});
            this.cboVRPDistanceFieldUnits.Location = new System.Drawing.Point(227, 163);
            this.cboVRPDistanceFieldUnits.Name = "cboVRPDistanceFieldUnits";
            this.cboVRPDistanceFieldUnits.Size = new System.Drawing.Size(163, 20);
            this.cboVRPDistanceFieldUnits.TabIndex = 123;
            // 
            // cboVRPTransitTime
            // 
            this.cboVRPTransitTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPTransitTime.FormattingEnabled = true;
            this.cboVRPTransitTime.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cboVRPTransitTime.Location = new System.Drawing.Point(227, 285);
            this.cboVRPTransitTime.Name = "cboVRPTransitTime";
            this.cboVRPTransitTime.Size = new System.Drawing.Size(163, 20);
            this.cboVRPTransitTime.TabIndex = 20;
            // 
            // cboVRPTimeWindow
            // 
            this.cboVRPTimeWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPTimeWindow.FormattingEnabled = true;
            this.cboVRPTimeWindow.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cboVRPTimeWindow.Location = new System.Drawing.Point(227, 256);
            this.cboVRPTimeWindow.Name = "cboVRPTimeWindow";
            this.cboVRPTimeWindow.Size = new System.Drawing.Size(163, 20);
            this.cboVRPTimeWindow.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "Excess Transit Time Importance:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "Time Window Violation Importance:";
            // 
            // chkVRPUseHierarchy
            // 
            this.chkVRPUseHierarchy.AutoSize = true;
            this.chkVRPUseHierarchy.Location = new System.Drawing.Point(14, 317);
            this.chkVRPUseHierarchy.Name = "chkVRPUseHierarchy";
            this.chkVRPUseHierarchy.Size = new System.Drawing.Size(102, 16);
            this.chkVRPUseHierarchy.TabIndex = 16;
            this.chkVRPUseHierarchy.Text = "Use Hierarchy";
            this.chkVRPUseHierarchy.UseVisualStyleBackColor = true;
            // 
            // cboVRPOutputShapeType
            // 
            this.cboVRPOutputShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPOutputShapeType.FormattingEnabled = true;
            this.cboVRPOutputShapeType.Items.AddRange(new object[] {
            "None",
            "Straight Line",
            "True Shape",
            "True Shape with Measure"});
            this.cboVRPOutputShapeType.Location = new System.Drawing.Point(227, 224);
            this.cboVRPOutputShapeType.Name = "cboVRPOutputShapeType";
            this.cboVRPOutputShapeType.Size = new System.Drawing.Size(163, 20);
            this.cboVRPOutputShapeType.TabIndex = 15;
            // 
            // cboVRPAllowUTurns
            // 
            this.cboVRPAllowUTurns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPAllowUTurns.FormattingEnabled = true;
            this.cboVRPAllowUTurns.Items.AddRange(new object[] {
            "No U-Turns",
            "Allow U-Turns",
            "Only At Dead Ends"});
            this.cboVRPAllowUTurns.Location = new System.Drawing.Point(227, 194);
            this.cboVRPAllowUTurns.Name = "cboVRPAllowUTurns";
            this.cboVRPAllowUTurns.Size = new System.Drawing.Size(163, 20);
            this.cboVRPAllowUTurns.TabIndex = 14;
            // 
            // cboVRPTimeFieldUnits
            // 
            this.cboVRPTimeFieldUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPTimeFieldUnits.FormattingEnabled = true;
            this.cboVRPTimeFieldUnits.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days"});
            this.cboVRPTimeFieldUnits.Location = new System.Drawing.Point(227, 134);
            this.cboVRPTimeFieldUnits.Name = "cboVRPTimeFieldUnits";
            this.cboVRPTimeFieldUnits.Size = new System.Drawing.Size(163, 20);
            this.cboVRPTimeFieldUnits.TabIndex = 12;
            // 
            // txtVRPCapacityCount
            // 
            this.txtVRPCapacityCount.Location = new System.Drawing.Point(227, 104);
            this.txtVRPCapacityCount.Name = "txtVRPCapacityCount";
            this.txtVRPCapacityCount.Size = new System.Drawing.Size(163, 21);
            this.txtVRPCapacityCount.TabIndex = 11;
            // 
            // txtVRPDefaultDate
            // 
            this.txtVRPDefaultDate.Location = new System.Drawing.Point(227, 75);
            this.txtVRPDefaultDate.Name = "txtVRPDefaultDate";
            this.txtVRPDefaultDate.Size = new System.Drawing.Size(163, 21);
            this.txtVRPDefaultDate.TabIndex = 10;
            // 
            // cboVRPDistanceAttribute
            // 
            this.cboVRPDistanceAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPDistanceAttribute.FormattingEnabled = true;
            this.cboVRPDistanceAttribute.Items.AddRange(new object[] {
            "",
            "Meters (Meters)"});
            this.cboVRPDistanceAttribute.Location = new System.Drawing.Point(227, 45);
            this.cboVRPDistanceAttribute.Name = "cboVRPDistanceAttribute";
            this.cboVRPDistanceAttribute.Size = new System.Drawing.Size(163, 20);
            this.cboVRPDistanceAttribute.TabIndex = 9;
            // 
            // cboVRPTimeAttribute
            // 
            this.cboVRPTimeAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVRPTimeAttribute.FormattingEnabled = true;
            this.cboVRPTimeAttribute.Location = new System.Drawing.Point(227, 15);
            this.cboVRPTimeAttribute.Name = "cboVRPTimeAttribute";
            this.cboVRPTimeAttribute.Size = new System.Drawing.Size(163, 20);
            this.cboVRPTimeAttribute.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Distance Attribute:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Default Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Capacity Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Time Field Units:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Distance Field Units:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "U-Turn Policy:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output Shape Type:";
            // 
            // lblTimeAttribute
            // 
            this.lblTimeAttribute.AutoSize = true;
            this.lblTimeAttribute.Location = new System.Drawing.Point(11, 24);
            this.lblTimeAttribute.Name = "lblTimeAttribute";
            this.lblTimeAttribute.Size = new System.Drawing.Size(95, 12);
            this.lblTimeAttribute.TabIndex = 0;
            this.lblTimeAttribute.Text = "Time Attribute:";
            // 
            // tabLocationAllocation
            // 
            this.tabLocationAllocation.Controls.Add(this.chkLAIgnoreInvalidLocations);
            this.tabLocationAllocation.Controls.Add(this.grpLASettings);
            this.tabLocationAllocation.Controls.Add(this.chkLAUseHierarchy);
            this.tabLocationAllocation.Controls.Add(this.lblLAAccumulateAttributeNames);
            this.tabLocationAllocation.Controls.Add(this.chklstLAAccumulateAttributeNames);
            this.tabLocationAllocation.Controls.Add(this.lblLARestrictionAttributeNames);
            this.tabLocationAllocation.Controls.Add(this.chklstLARestrictionAttributeNames);
            this.tabLocationAllocation.Controls.Add(this.cboLAOutputLines);
            this.tabLocationAllocation.Controls.Add(this.label11);
            this.tabLocationAllocation.Controls.Add(this.cboLATravelDirection);
            this.tabLocationAllocation.Controls.Add(this.label12);
            this.tabLocationAllocation.Controls.Add(this.lblCostAttribute);
            this.tabLocationAllocation.Controls.Add(this.cboLAImpedance);
            this.tabLocationAllocation.Location = new System.Drawing.Point(4, 22);
            this.tabLocationAllocation.Name = "tabLocationAllocation";
            this.tabLocationAllocation.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocationAllocation.Size = new System.Drawing.Size(708, 430);
            this.tabLocationAllocation.TabIndex = 6;
            this.tabLocationAllocation.Text = "Location-Allocation";
            this.tabLocationAllocation.UseVisualStyleBackColor = true;
            // 
            // chkLAIgnoreInvalidLocations
            // 
            this.chkLAIgnoreInvalidLocations.Location = new System.Drawing.Point(16, 160);
            this.chkLAIgnoreInvalidLocations.Name = "chkLAIgnoreInvalidLocations";
            this.chkLAIgnoreInvalidLocations.Size = new System.Drawing.Size(172, 32);
            this.chkLAIgnoreInvalidLocations.TabIndex = 123;
            this.chkLAIgnoreInvalidLocations.Text = "Ignore Invalid Locations";
            // 
            // grpLASettings
            // 
            this.grpLASettings.Controls.Add(this.lblTargetMarketShare);
            this.grpLASettings.Controls.Add(this.txtLATargetMarketShare);
            this.grpLASettings.Controls.Add(this.cboLAImpTransformation);
            this.grpLASettings.Controls.Add(this.lblImpParameter);
            this.grpLASettings.Controls.Add(this.txtLAImpParameter);
            this.grpLASettings.Controls.Add(this.lblImpTransformation);
            this.grpLASettings.Controls.Add(this.lblProblemType);
            this.grpLASettings.Controls.Add(this.cboLAProblemType);
            this.grpLASettings.Controls.Add(this.lblCutOff);
            this.grpLASettings.Controls.Add(this.txtLACutOff);
            this.grpLASettings.Controls.Add(this.lblNumFacilities);
            this.grpLASettings.Controls.Add(this.txtLAFacilitiesToLocate);
            this.grpLASettings.Location = new System.Drawing.Point(276, 139);
            this.grpLASettings.Name = "grpLASettings";
            this.grpLASettings.Size = new System.Drawing.Size(410, 259);
            this.grpLASettings.TabIndex = 122;
            this.grpLASettings.TabStop = false;
            this.grpLASettings.Text = "Advanced Settings";
            // 
            // lblTargetMarketShare
            // 
            this.lblTargetMarketShare.AccessibleDescription = "grpLA";
            this.lblTargetMarketShare.AutoSize = true;
            this.lblTargetMarketShare.Location = new System.Drawing.Point(24, 221);
            this.lblTargetMarketShare.Name = "lblTargetMarketShare";
            this.lblTargetMarketShare.Size = new System.Drawing.Size(143, 12);
            this.lblTargetMarketShare.TabIndex = 31;
            this.lblTargetMarketShare.Text = "Target Market Share (%)";
            // 
            // txtLATargetMarketShare
            // 
            this.txtLATargetMarketShare.AccessibleDescription = "grpLA";
            this.txtLATargetMarketShare.Location = new System.Drawing.Point(239, 216);
            this.txtLATargetMarketShare.Name = "txtLATargetMarketShare";
            this.txtLATargetMarketShare.Size = new System.Drawing.Size(155, 21);
            this.txtLATargetMarketShare.TabIndex = 30;
            this.txtLATargetMarketShare.Text = "10.0";
            // 
            // cboLAImpTransformation
            // 
            this.cboLAImpTransformation.AccessibleDescription = "grpLA";
            this.cboLAImpTransformation.FormattingEnabled = true;
            this.cboLAImpTransformation.Items.AddRange(new object[] {
            "Linear",
            "Power",
            "Exponential"});
            this.cboLAImpTransformation.Location = new System.Drawing.Point(242, 145);
            this.cboLAImpTransformation.Name = "cboLAImpTransformation";
            this.cboLAImpTransformation.Size = new System.Drawing.Size(154, 20);
            this.cboLAImpTransformation.TabIndex = 29;
            this.cboLAImpTransformation.Text = "Linear";
            // 
            // lblImpParameter
            // 
            this.lblImpParameter.AccessibleDescription = "grpLA";
            this.lblImpParameter.AutoSize = true;
            this.lblImpParameter.Location = new System.Drawing.Point(23, 184);
            this.lblImpParameter.Name = "lblImpParameter";
            this.lblImpParameter.Size = new System.Drawing.Size(119, 12);
            this.lblImpParameter.TabIndex = 28;
            this.lblImpParameter.Text = "Impedance Parameter";
            // 
            // txtLAImpParameter
            // 
            this.txtLAImpParameter.AccessibleDescription = "grpLA";
            this.txtLAImpParameter.Location = new System.Drawing.Point(240, 179);
            this.txtLAImpParameter.Name = "txtLAImpParameter";
            this.txtLAImpParameter.Size = new System.Drawing.Size(155, 21);
            this.txtLAImpParameter.TabIndex = 27;
            this.txtLAImpParameter.Text = "1.0";
            // 
            // lblImpTransformation
            // 
            this.lblImpTransformation.AccessibleDescription = "grpLA";
            this.lblImpTransformation.AutoSize = true;
            this.lblImpTransformation.Location = new System.Drawing.Point(23, 145);
            this.lblImpTransformation.Name = "lblImpTransformation";
            this.lblImpTransformation.Size = new System.Drawing.Size(149, 12);
            this.lblImpTransformation.TabIndex = 26;
            this.lblImpTransformation.Text = "Impedance Transformation";
            // 
            // lblProblemType
            // 
            this.lblProblemType.AccessibleDescription = "grpLA";
            this.lblProblemType.AutoSize = true;
            this.lblProblemType.Location = new System.Drawing.Point(23, 32);
            this.lblProblemType.Name = "lblProblemType";
            this.lblProblemType.Size = new System.Drawing.Size(77, 12);
            this.lblProblemType.TabIndex = 23;
            this.lblProblemType.Text = "Problem Type";
            // 
            // cboLAProblemType
            // 
            this.cboLAProblemType.AccessibleDescription = "grpLA";
            this.cboLAProblemType.FormattingEnabled = true;
            this.cboLAProblemType.Items.AddRange(new object[] {
            "Minimize Impedance",
            "Maximize Coverage",
            "Minimize Facilities",
            "Maximize Attendance",
            "Maximize Market Share",
            "Target Market Share"});
            this.cboLAProblemType.Location = new System.Drawing.Point(242, 26);
            this.cboLAProblemType.Name = "cboLAProblemType";
            this.cboLAProblemType.Size = new System.Drawing.Size(154, 20);
            this.cboLAProblemType.TabIndex = 22;
            this.cboLAProblemType.Text = "Minimize Impedance";
            this.cboLAProblemType.SelectedIndexChanged += new System.EventHandler(this.cboLAProblemType_SelectedIndexChanged);
            // 
            // lblCutOff
            // 
            this.lblCutOff.AccessibleDescription = "grpLA";
            this.lblCutOff.AutoSize = true;
            this.lblCutOff.Location = new System.Drawing.Point(24, 106);
            this.lblCutOff.Name = "lblCutOff";
            this.lblCutOff.Size = new System.Drawing.Size(101, 12);
            this.lblCutOff.TabIndex = 21;
            this.lblCutOff.Text = "Impedance Cutoff";
            // 
            // txtLACutOff
            // 
            this.txtLACutOff.AccessibleDescription = "grpLA";
            this.txtLACutOff.Location = new System.Drawing.Point(242, 106);
            this.txtLACutOff.Name = "txtLACutOff";
            this.txtLACutOff.Size = new System.Drawing.Size(155, 21);
            this.txtLACutOff.TabIndex = 20;
            this.txtLACutOff.Text = "<None>";
            // 
            // lblNumFacilities
            // 
            this.lblNumFacilities.AccessibleDescription = "grpLA";
            this.lblNumFacilities.AutoSize = true;
            this.lblNumFacilities.Location = new System.Drawing.Point(24, 68);
            this.lblNumFacilities.Name = "lblNumFacilities";
            this.lblNumFacilities.Size = new System.Drawing.Size(125, 12);
            this.lblNumFacilities.TabIndex = 19;
            this.lblNumFacilities.Text = "Facilities To Choose";
            // 
            // txtLAFacilitiesToLocate
            // 
            this.txtLAFacilitiesToLocate.AccessibleDescription = "grpLA";
            this.txtLAFacilitiesToLocate.Location = new System.Drawing.Point(242, 68);
            this.txtLAFacilitiesToLocate.Name = "txtLAFacilitiesToLocate";
            this.txtLAFacilitiesToLocate.Size = new System.Drawing.Size(156, 21);
            this.txtLAFacilitiesToLocate.TabIndex = 18;
            this.txtLAFacilitiesToLocate.Text = "1";
            // 
            // chkLAUseHierarchy
            // 
            this.chkLAUseHierarchy.AutoSize = true;
            this.chkLAUseHierarchy.Location = new System.Drawing.Point(16, 129);
            this.chkLAUseHierarchy.Name = "chkLAUseHierarchy";
            this.chkLAUseHierarchy.Size = new System.Drawing.Size(102, 16);
            this.chkLAUseHierarchy.TabIndex = 121;
            this.chkLAUseHierarchy.Text = "Use Hierarchy";
            this.chkLAUseHierarchy.UseVisualStyleBackColor = true;
            // 
            // lblLAAccumulateAttributeNames
            // 
            this.lblLAAccumulateAttributeNames.Location = new System.Drawing.Point(13, 302);
            this.lblLAAccumulateAttributeNames.Name = "lblLAAccumulateAttributeNames";
            this.lblLAAccumulateAttributeNames.Size = new System.Drawing.Size(144, 17);
            this.lblLAAccumulateAttributeNames.TabIndex = 120;
            this.lblLAAccumulateAttributeNames.Text = "Accumulate Attributes";
            // 
            // chklstLAAccumulateAttributeNames
            // 
            this.chklstLAAccumulateAttributeNames.CheckOnClick = true;
            this.chklstLAAccumulateAttributeNames.Location = new System.Drawing.Point(13, 319);
            this.chklstLAAccumulateAttributeNames.Name = "chklstLAAccumulateAttributeNames";
            this.chklstLAAccumulateAttributeNames.ScrollAlwaysVisible = true;
            this.chklstLAAccumulateAttributeNames.Size = new System.Drawing.Size(231, 20);
            this.chklstLAAccumulateAttributeNames.TabIndex = 119;
            // 
            // lblLARestrictionAttributeNames
            // 
            this.lblLARestrictionAttributeNames.Location = new System.Drawing.Point(13, 207);
            this.lblLARestrictionAttributeNames.Name = "lblLARestrictionAttributeNames";
            this.lblLARestrictionAttributeNames.Size = new System.Drawing.Size(85, 16);
            this.lblLARestrictionAttributeNames.TabIndex = 118;
            this.lblLARestrictionAttributeNames.Text = "Restrictions";
            // 
            // chklstLARestrictionAttributeNames
            // 
            this.chklstLARestrictionAttributeNames.CheckOnClick = true;
            this.chklstLARestrictionAttributeNames.Location = new System.Drawing.Point(13, 226);
            this.chklstLARestrictionAttributeNames.Name = "chklstLARestrictionAttributeNames";
            this.chklstLARestrictionAttributeNames.ScrollAlwaysVisible = true;
            this.chklstLARestrictionAttributeNames.Size = new System.Drawing.Size(229, 20);
            this.chklstLARestrictionAttributeNames.TabIndex = 117;
            // 
            // cboLAOutputLines
            // 
            this.cboLAOutputLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLAOutputLines.ItemHeight = 12;
            this.cboLAOutputLines.Items.AddRange(new object[] {
            "Straight Lines",
            "None"});
            this.cboLAOutputLines.Location = new System.Drawing.Point(170, 94);
            this.cboLAOutputLines.Name = "cboLAOutputLines";
            this.cboLAOutputLines.Size = new System.Drawing.Size(214, 20);
            this.cboLAOutputLines.TabIndex = 115;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(13, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 16);
            this.label11.TabIndex = 116;
            this.label11.Text = "Shape";
            // 
            // cboLATravelDirection
            // 
            this.cboLATravelDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLATravelDirection.ItemHeight = 12;
            this.cboLATravelDirection.Items.AddRange(new object[] {
            "Facility To Demand",
            "Demand To Facility"});
            this.cboLATravelDirection.Location = new System.Drawing.Point(170, 60);
            this.cboLATravelDirection.Name = "cboLATravelDirection";
            this.cboLATravelDirection.Size = new System.Drawing.Size(214, 20);
            this.cboLATravelDirection.TabIndex = 113;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(13, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 17);
            this.label12.TabIndex = 114;
            this.label12.Text = "Travel Direction";
            // 
            // lblCostAttribute
            // 
            this.lblCostAttribute.AutoSize = true;
            this.lblCostAttribute.Location = new System.Drawing.Point(10, 27);
            this.lblCostAttribute.Name = "lblCostAttribute";
            this.lblCostAttribute.Size = new System.Drawing.Size(89, 12);
            this.lblCostAttribute.TabIndex = 25;
            this.lblCostAttribute.Text = "Cost Attribute";
            // 
            // cboLAImpedance
            // 
            this.cboLAImpedance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLAImpedance.FormattingEnabled = true;
            this.cboLAImpedance.Location = new System.Drawing.Point(170, 27);
            this.cboLAImpedance.Name = "cboLAImpedance";
            this.cboLAImpedance.Size = new System.Drawing.Size(212, 20);
            this.cboLAImpedance.TabIndex = 24;
            // 
            // frmNALayerProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 544);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabPropPages);
            this.Name = "frmNALayerProperties";
            this.Text = "Properties";
            this.Load += new System.EventHandler(this.frmNALayerProperties_Load);
            this.tabPropPages.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabRoute.ResumeLayout(false);
            this.tabRoute.PerformLayout();
            this.tabClosestFacility.ResumeLayout(false);
            this.tabClosestFacility.PerformLayout();
            this.tabODCostMatrix.ResumeLayout(false);
            this.tabODCostMatrix.PerformLayout();
            this.tabServiceArea.ResumeLayout(false);
            this.tabServiceArea.PerformLayout();
            this.tabVRP.ResumeLayout(false);
            this.gbRestrictions.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tabLocationAllocation.ResumeLayout(false);
            this.tabLocationAllocation.PerformLayout();
            this.grpLASettings.ResumeLayout(false);
            this.grpLASettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabPropPages;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Label lblMaxSearchTolerance;
        private System.Windows.Forms.ComboBox cboMaxSearchToleranceUnits;
        private System.Windows.Forms.TextBox txtMaxSearchTolerance;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.Label lblLayerName;
        private System.Windows.Forms.TabPage tabRoute;
        private System.Windows.Forms.Label labelRouteOutputLines;
        private System.Windows.Forms.ComboBox cboRouteOutputLines;
        private System.Windows.Forms.CheckBox chkRouteUseTimeWindows;
        private System.Windows.Forms.CheckBox chkRoutePreserveLastStop;
        private System.Windows.Forms.CheckBox chkRoutePreserveFirstStop;
        private System.Windows.Forms.CheckBox chkRouteFindBestSequence;
        private System.Windows.Forms.CheckBox chkRouteUseStartTime;
        private System.Windows.Forms.TextBox txtRouteStartTime;
        private System.Windows.Forms.CheckBox chkRouteIgnoreInvalidLocations;
        private System.Windows.Forms.ComboBox cboRouteRestrictUTurns;
        private System.Windows.Forms.Label lblRouteRestrictUTurns;
        private System.Windows.Forms.Label lblRouteAccumulateAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstRouteAccumulateAttributeNames;
        private System.Windows.Forms.Label lblRouteRestrictionAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstRouteRestrictionAttributeNames;
        private System.Windows.Forms.ComboBox cboRouteImpedance;
        private System.Windows.Forms.Label lblRouteImpedance;
        private System.Windows.Forms.CheckBox chkRouteUseHierarchy;
        private System.Windows.Forms.TabPage tabClosestFacility;
        private System.Windows.Forms.CheckBox chkCFIgnoreInvalidLocations;
        private System.Windows.Forms.ComboBox cboCFRestrictUTurns;
        private System.Windows.Forms.Label lblCFRestrictUTurns;
        private System.Windows.Forms.Label lblCFAccumulateAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstCFAccumulateAttributeNames;
        private System.Windows.Forms.Label lblCFRestrictionAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstCFRestrictionAttributeNames;
        private System.Windows.Forms.ComboBox cboCFImpedance;
        private System.Windows.Forms.Label lblCFImpedance;
        private System.Windows.Forms.CheckBox chkCFUseHierarchy;
        private System.Windows.Forms.ComboBox cboCFOutputLines;
        private System.Windows.Forms.Label lblCFOutputLines;
        private System.Windows.Forms.ComboBox cboCFTravelDirection;
        private System.Windows.Forms.Label lblCFTravelDirection;
        private System.Windows.Forms.TextBox txtCFDefaultTargetFacilityCount;
        private System.Windows.Forms.Label lblCFDefaultTargetFacilityCount;
        private System.Windows.Forms.TextBox txtCFDefaultCutoff;
        private System.Windows.Forms.Label lblCFDefaultCutoff;
        private System.Windows.Forms.TabPage tabODCostMatrix;
        private System.Windows.Forms.CheckBox chkODIgnoreInvalidLocations;
        private System.Windows.Forms.ComboBox cboODRestrictUTurns;
        private System.Windows.Forms.Label lblODRestrictUTurns;
        private System.Windows.Forms.Label lblODAccumulateAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstODAccumulateAttributeNames;
        private System.Windows.Forms.Label lblODRestrictionAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstODRestrictionAttributeNames;
        private System.Windows.Forms.ComboBox cboODImpedance;
        private System.Windows.Forms.Label lblODImpedance;
        private System.Windows.Forms.CheckBox chkODUseHierarchy;
        private System.Windows.Forms.ComboBox cboODOutputLines;
        private System.Windows.Forms.Label lblODOutputLines;
        private System.Windows.Forms.TextBox txtODDefaultTargetDestinationCount;
        private System.Windows.Forms.Label lblODDefaultTargetDestinationCount;
        private System.Windows.Forms.TextBox txtODDefaultCutoff;
        private System.Windows.Forms.Label lblODDefaultCutoff;
        private System.Windows.Forms.TabPage tabServiceArea;
        private System.Windows.Forms.ComboBox cboSATrimPolygonDistanceUnits;
        private System.Windows.Forms.TextBox txtSATrimPolygonDistance;
        private System.Windows.Forms.CheckBox chkSATrimOuterPolygon;
        private System.Windows.Forms.CheckBox chkSAIncludeSourceInformationOnLines;
        private System.Windows.Forms.ComboBox cboSATravelDirection;
        private System.Windows.Forms.Label lblSATravelDirection;
        private System.Windows.Forms.CheckBox chkSASplitPolygonsAtBreaks;
        private System.Windows.Forms.CheckBox chkSAOverlapPolygons;
        private System.Windows.Forms.CheckBox chkSASplitLinesAtBreaks;
        private System.Windows.Forms.CheckBox chkSAOverlapLines;
        private System.Windows.Forms.CheckBox chkSAIgnoreInvalidLocations;
        private System.Windows.Forms.ComboBox cboSARestrictUTurns;
        private System.Windows.Forms.Label lblSARestrictUTurns;
        private System.Windows.Forms.Label lblSAAccumulateAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstSAAccumulateAttributeNames;
        private System.Windows.Forms.Label lblSARestrictionAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstSARestrictionAttributeNames;
        private System.Windows.Forms.Label lblSAOutputPolygons;
        private System.Windows.Forms.ComboBox cboSAOutputPolygons;
        private System.Windows.Forms.Label lblSAOutputLines;
        private System.Windows.Forms.ComboBox cboSAOutputLines;
        private System.Windows.Forms.CheckBox chkSAMergeSimilarPolygonRanges;
        private System.Windows.Forms.TextBox txtSADefaultBreaks;
        private System.Windows.Forms.Label lblSADefaultBreaks;
        private System.Windows.Forms.ComboBox cboSAImpedance;
        private System.Windows.Forms.Label lblSAImpedance;
        private System.Windows.Forms.TabPage tabVRP;
        private System.Windows.Forms.GroupBox gbRestrictions;
        private System.Windows.Forms.CheckedListBox chklstVRPRestrictionAttributeNames;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ComboBox cboVRPDistanceFieldUnits;
        private System.Windows.Forms.ComboBox cboVRPTransitTime;
        private System.Windows.Forms.ComboBox cboVRPTimeWindow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkVRPUseHierarchy;
        private System.Windows.Forms.ComboBox cboVRPOutputShapeType;
        private System.Windows.Forms.ComboBox cboVRPAllowUTurns;
        private System.Windows.Forms.ComboBox cboVRPTimeFieldUnits;
        private System.Windows.Forms.TextBox txtVRPCapacityCount;
        private System.Windows.Forms.TextBox txtVRPDefaultDate;
        private System.Windows.Forms.ComboBox cboVRPDistanceAttribute;
        private System.Windows.Forms.ComboBox cboVRPTimeAttribute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTimeAttribute;
        private System.Windows.Forms.TabPage tabLocationAllocation;
        private System.Windows.Forms.CheckBox chkLAIgnoreInvalidLocations;
        private System.Windows.Forms.GroupBox grpLASettings;
        private System.Windows.Forms.Label lblTargetMarketShare;
        private System.Windows.Forms.TextBox txtLATargetMarketShare;
        private System.Windows.Forms.ComboBox cboLAImpTransformation;
        private System.Windows.Forms.Label lblImpParameter;
        private System.Windows.Forms.TextBox txtLAImpParameter;
        private System.Windows.Forms.Label lblImpTransformation;
        private System.Windows.Forms.Label lblProblemType;
        private System.Windows.Forms.ComboBox cboLAProblemType;
        private System.Windows.Forms.Label lblCutOff;
        private System.Windows.Forms.TextBox txtLACutOff;
        private System.Windows.Forms.Label lblNumFacilities;
        private System.Windows.Forms.TextBox txtLAFacilitiesToLocate;
        private System.Windows.Forms.CheckBox chkLAUseHierarchy;
        private System.Windows.Forms.Label lblLAAccumulateAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstLAAccumulateAttributeNames;
        private System.Windows.Forms.Label lblLARestrictionAttributeNames;
        private System.Windows.Forms.CheckedListBox chklstLARestrictionAttributeNames;
        private System.Windows.Forms.ComboBox cboLAOutputLines;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboLATravelDirection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCostAttribute;
        private System.Windows.Forms.ComboBox cboLAImpedance;
    }
}