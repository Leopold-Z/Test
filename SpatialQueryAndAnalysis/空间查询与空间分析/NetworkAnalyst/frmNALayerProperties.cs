using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;

namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    public partial class frmNALayerProperties : Form
    {
        bool m_okClicked;

        public frmNALayerProperties()
        {
            InitializeComponent();
        }

        private void frmNALayerProperties_Load(object sender, EventArgs e)
        {

        }

        public bool ShowModal(INALayer naLayer)
        {
            m_okClicked = false;

            // Get the NAContext and NetworkDataset
            INAContext naContext = naLayer.Context;
            INetworkDataset networkDataset = naContext.NetworkDataset;

            // Setup the window based on the current NALayer settings
            PopulateControls(naLayer);
            tabPropPages.SelectedIndex = 1;
            this.Text = ((ILayer)naLayer).Name + " Properties";

            this.ShowDialog();
            if (m_okClicked)
            {
                // Update the layer properties based on the items chosen
                UpdateNALayer(naLayer);

                // Update the Context so it can respond to changes made to the solver settings
                IGPMessages gpMessages = new GPMessagesClass();
                IDENetworkDataset deNetworkDataset = ((IDatasetComponent)networkDataset).DataElement as IDENetworkDataset;
                naContext.Solver.UpdateContext(naContext, deNetworkDataset, gpMessages);
            }

            return m_okClicked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_okClicked = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_okClicked = false;
            this.Close();
        }

        /// <summary>
        /// Set controls based on the current NALayer settings
        /// This function takes the current NALayer and determines what type of solver it's pointing to
        /// and populates the corresponding controls and hides the tabs for the other solvers.
        /// </summary>
        private void PopulateControls(INALayer naLayer)
        {
            ILayer layer = naLayer as ILayer;
            INAContext naContext = naLayer.Context;
            INetworkDataset networkDataset = naContext.NetworkDataset;
            INALocator2 naLocator = naContext.Locator as INALocator2;
            INASolver naSolver = naContext.Solver;
            INASolverSettings naSolverSettings = naSolver as INASolverSettings2;
            INARouteSolver2 routeSolver = naSolver as INARouteSolver2;
            INAClosestFacilitySolver cfSolver = naSolver as INAClosestFacilitySolver;
            INAODCostMatrixSolver odSolver = naSolver as INAODCostMatrixSolver;
            INAServiceAreaSolver2 saSolver = naSolver as INAServiceAreaSolver2;
            INAVRPSolver vrpSolver = naSolver as INAVRPSolver;
            INALocationAllocationSolver laSolver = naSolver as INALocationAllocationSolver;

            // Populate general Layer controls
            txtLayerName.Text = layer.Name;
            txtMaxSearchTolerance.Text = naLocator.MaxSnapTolerance.ToString();
            cboMaxSearchToleranceUnits.SelectedIndex = Convert.ToInt32(naLocator.SnapToleranceUnits);

            // Populate controls for the particular solver

            if (routeSolver != null)  // ROUTE LAYER
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabClosestFacility);
                tabPropPages.TabPages.Remove(tabODCostMatrix);
                tabPropPages.TabPages.Remove(tabServiceArea);
                tabPropPages.TabPages.Remove(tabVRP);
                tabPropPages.TabPages.Remove(tabLocationAllocation);

                // INARouteSolver2
                chkRouteFindBestSequence.Checked = routeSolver.FindBestSequence;
                chkRoutePreserveFirstStop.Checked = routeSolver.PreserveFirstStop;
                chkRoutePreserveLastStop.Checked = routeSolver.PreserveLastStop;
                chkRouteUseTimeWindows.Checked = routeSolver.UseTimeWindows;
                chkRouteUseStartTime.Checked = routeSolver.UseStartTime;
                txtRouteStartTime.Text = routeSolver.StartTime.ToShortTimeString();
                cboRouteOutputLines.SelectedIndex = System.Convert.ToInt32(routeSolver.OutputLines);

                // INASolverSettings
                PopulateImpedanceNameControl(cboRouteImpedance, networkDataset, naSolverSettings.ImpedanceAttributeName);
                chkRouteUseHierarchy.Enabled = (naSolverSettings.HierarchyAttributeName.Length > 0);
                chkRouteUseHierarchy.Checked = (chkRouteUseHierarchy.Enabled && naSolverSettings.UseHierarchy);
                chkRouteIgnoreInvalidLocations.Checked = naSolverSettings.IgnoreInvalidLocations;
                cboRouteRestrictUTurns.SelectedIndex = System.Convert.ToInt32(naSolverSettings.RestrictUTurns);
                PopulateAttributeControl(chklstRouteAccumulateAttributeNames, networkDataset, naSolverSettings.AccumulateAttributeNames, esriNetworkAttributeUsageType.esriNAUTCost);
                PopulateAttributeControl(chklstRouteRestrictionAttributeNames, networkDataset, naSolverSettings.RestrictionAttributeNames, esriNetworkAttributeUsageType.esriNAUTRestriction);
            }
            else if (cfSolver != null)  // CLOSEST FACILITY LAYER
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabRoute);
                tabPropPages.TabPages.Remove(tabODCostMatrix);
                tabPropPages.TabPages.Remove(tabServiceArea);
                tabPropPages.TabPages.Remove(tabVRP);
                tabPropPages.TabPages.Remove(tabLocationAllocation);

                // INAClosestFacilitySolver
                txtCFDefaultCutoff.Text = GetStringFromObject(cfSolver.DefaultCutoff);
                txtCFDefaultTargetFacilityCount.Text = cfSolver.DefaultTargetFacilityCount.ToString();
                cboCFTravelDirection.SelectedIndex = Convert.ToInt32(cfSolver.TravelDirection);
                cboCFOutputLines.SelectedIndex = Convert.ToInt32(cfSolver.OutputLines);

                // INASolverSettings
                PopulateImpedanceNameControl(cboCFImpedance, networkDataset, naSolverSettings.ImpedanceAttributeName);
                chkCFUseHierarchy.Enabled = (naSolverSettings.HierarchyAttributeName.Length > 0);
                chkCFUseHierarchy.Checked = (chkCFUseHierarchy.Enabled && naSolverSettings.UseHierarchy);
                chkCFIgnoreInvalidLocations.Checked = naSolverSettings.IgnoreInvalidLocations;
                cboCFRestrictUTurns.SelectedIndex = System.Convert.ToInt32(naSolverSettings.RestrictUTurns);
                PopulateAttributeControl(chklstCFAccumulateAttributeNames, networkDataset, naSolverSettings.AccumulateAttributeNames, esriNetworkAttributeUsageType.esriNAUTCost);
                PopulateAttributeControl(chklstCFRestrictionAttributeNames, networkDataset, naSolverSettings.RestrictionAttributeNames, esriNetworkAttributeUsageType.esriNAUTRestriction);
            }
            else if (odSolver != null) // OD COST MATRIX LAYER
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabRoute);
                tabPropPages.TabPages.Remove(tabClosestFacility);
                tabPropPages.TabPages.Remove(tabServiceArea);
                tabPropPages.TabPages.Remove(tabVRP);

                // INAODCostMatrixSolver
                txtODDefaultCutoff.Text = GetStringFromObject(odSolver.DefaultCutoff);
                txtODDefaultTargetDestinationCount.Text = GetStringFromObject(odSolver.DefaultTargetDestinationCount);
                cboODOutputLines.SelectedIndex = Convert.ToInt32(odSolver.OutputLines);

                // INASolverSettings
                PopulateImpedanceNameControl(cboODImpedance, networkDataset, naSolverSettings.ImpedanceAttributeName);
                chkODUseHierarchy.Enabled = (naSolverSettings.HierarchyAttributeName.Length > 0);
                chkODUseHierarchy.Checked = (chkODUseHierarchy.Enabled && naSolverSettings.UseHierarchy);
                chkODIgnoreInvalidLocations.Checked = naSolverSettings.IgnoreInvalidLocations;
                cboODRestrictUTurns.SelectedIndex = System.Convert.ToInt32(naSolverSettings.RestrictUTurns);
                PopulateAttributeControl(chklstODAccumulateAttributeNames, networkDataset, naSolverSettings.AccumulateAttributeNames, esriNetworkAttributeUsageType.esriNAUTCost);
                PopulateAttributeControl(chklstODRestrictionAttributeNames, networkDataset, naSolverSettings.RestrictionAttributeNames, esriNetworkAttributeUsageType.esriNAUTRestriction);
            }
            else if (saSolver != null)  //SERVICE AREA SOLVER
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabRoute);
                tabPropPages.TabPages.Remove(tabClosestFacility);
                tabPropPages.TabPages.Remove(tabODCostMatrix);
                tabPropPages.TabPages.Remove(tabVRP);
                tabPropPages.TabPages.Remove(tabLocationAllocation);

                // INAServiceAreaSolver2
                txtSADefaultBreaks.Text = "";
                for (int iBreak = 0; iBreak < saSolver.DefaultBreaks.Count; iBreak++)
                    txtSADefaultBreaks.Text = txtSADefaultBreaks.Text + " " + saSolver.DefaultBreaks.get_Element(iBreak).ToString();
                cboSATravelDirection.SelectedIndex = Convert.ToInt32(saSolver.TravelDirection);

                cboSAOutputPolygons.SelectedIndex = -1;
                cboSAOutputPolygons.SelectedIndex = Convert.ToInt32(saSolver.OutputPolygons);
                chkSAOverlapPolygons.Checked = saSolver.OverlapPolygons;
                chkSASplitPolygonsAtBreaks.Checked = saSolver.SplitPolygonsAtBreaks;
                chkSAMergeSimilarPolygonRanges.Checked = saSolver.MergeSimilarPolygonRanges;
                chkSATrimOuterPolygon.Checked = saSolver.TrimOuterPolygon;
                txtSATrimPolygonDistance.Text = saSolver.TrimPolygonDistance.ToString();
                cboSATrimPolygonDistanceUnits.SelectedIndex = Convert.ToInt32(saSolver.TrimPolygonDistanceUnits);

                cboSAOutputLines.SelectedIndex = -1;
                cboSAOutputLines.SelectedIndex = Convert.ToInt32(saSolver.OutputLines);
                chkSAOverlapLines.Checked = saSolver.OverlapLines;
                chkSASplitLinesAtBreaks.Checked = saSolver.SplitLinesAtBreaks;
                chkSAIncludeSourceInformationOnLines.Checked = saSolver.IncludeSourceInformationOnLines;

                // INASolverSettings
                PopulateImpedanceNameControl(cboSAImpedance, networkDataset, naSolverSettings.ImpedanceAttributeName);
                chkSAIgnoreInvalidLocations.Checked = naSolverSettings.IgnoreInvalidLocations;
                cboSARestrictUTurns.SelectedIndex = System.Convert.ToInt32(naSolverSettings.RestrictUTurns);
                PopulateAttributeControl(chklstSAAccumulateAttributeNames, networkDataset, naSolverSettings.AccumulateAttributeNames, esriNetworkAttributeUsageType.esriNAUTCost);
                PopulateAttributeControl(chklstSARestrictionAttributeNames, networkDataset, naSolverSettings.RestrictionAttributeNames, esriNetworkAttributeUsageType.esriNAUTRestriction);
            }
            else if (vrpSolver != null) // VRP Solver
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabRoute);
                tabPropPages.TabPages.Remove(tabClosestFacility);
                tabPropPages.TabPages.Remove(tabODCostMatrix);
                tabPropPages.TabPages.Remove(tabServiceArea);
                tabPropPages.TabPages.Remove(tabLocationAllocation);

                cboVRPOutputShapeType.SelectedIndex = Convert.ToInt32(vrpSolver.OutputLines);
                cboVRPAllowUTurns.SelectedIndex = Convert.ToInt32(naSolverSettings.RestrictUTurns);
                // VRP cannot have unknown units, so the index is offset by 1 from the solver field units
                cboVRPDistanceFieldUnits.SelectedIndex = Convert.ToInt32(vrpSolver.DistanceFieldUnits) - 1;
                cboVRPTransitTime.SelectedIndex = Convert.ToInt32(vrpSolver.ExcessTransitTimePenaltyFactor);
                cboVRPTimeWindow.SelectedIndex = Convert.ToInt32(vrpSolver.TimeWindowViolationPenaltyFactor);
                cboVRPTimeFieldUnits.SelectedIndex = Convert.ToInt32(vrpSolver.TimeFieldUnits - 20);

                txtVRPCapacityCount.Text = vrpSolver.CapacityCount.ToString();
                txtVRPDefaultDate.Text = vrpSolver.DefaultDate.ToShortDateString();

                chkVRPUseHierarchy.Checked = naSolverSettings.UseHierarchy;

                PopulateAttributeControl(chklstVRPRestrictionAttributeNames, networkDataset, naSolverSettings.RestrictionAttributeNames, esriNetworkAttributeUsageType.esriNAUTRestriction);

                //populate the time attribute combo box
                cboVRPTimeAttribute.Items.Clear();

                for (int i = 0; i < networkDataset.AttributeCount; i++)
                {
                    INetworkAttribute networkAttribute = networkDataset.get_Attribute(i);

                    if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost &&
                        networkAttribute.Units >= esriNetworkAttributeUnits.esriNAUSeconds)
                        cboVRPTimeAttribute.Items.Add(networkAttribute.Name);
                }

                if (cboVRPTimeAttribute.Items.Count > 0)
                    cboVRPTimeAttribute.Text = naSolverSettings.ImpedanceAttributeName;


                // for VRP, the AccumulateAttributeNames hold the length, and it can only hold one length.
                //  Loop through the network dataset attributes
                cboVRPDistanceAttribute.Items.Clear();
                cboVRPDistanceAttribute.SelectedIndex = cboVRPDistanceAttribute.Items.Add("");

                for (int i = 0; i < networkDataset.AttributeCount; i++)
                {
                    INetworkAttribute networkAttribute = networkDataset.get_Attribute(i);
                    if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost &&
                        networkAttribute.Units < esriNetworkAttributeUnits.esriNAUSeconds)
                    {
                        string attributeName = networkAttribute.Name;

                        int cboindex = cboVRPDistanceAttribute.Items.Add(networkAttribute.Name);

                        // If the attribute is in the strArray, it should be the selected one
                        for (int j = 0; j < naSolverSettings.AccumulateAttributeNames.Count; j++)
                            if (naSolverSettings.AccumulateAttributeNames.get_Element(j) == attributeName)
                                cboVRPDistanceAttribute.SelectedIndex = cboindex;
                    }
                }
            }
            else if (laSolver != null)  // Location-Allocation LAYER
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabRoute);
                tabPropPages.TabPages.Remove(tabClosestFacility);
                tabPropPages.TabPages.Remove(tabODCostMatrix);
                tabPropPages.TabPages.Remove(tabServiceArea);
                tabPropPages.TabPages.Remove(tabVRP);

                // INALocationAllocationSolver
                txtLACutOff.Text = GetStringFromObject(laSolver.DefaultCutoff);
                txtLAFacilitiesToLocate.Text = laSolver.NumberFacilitiesToLocate.ToString();
                txtLAImpParameter.Text = laSolver.TransformationParameter.ToString();
                txtLATargetMarketShare.Text = laSolver.TargetMarketSharePercentage.ToString();

                cboLAImpTransformation.SelectedIndex = Convert.ToInt32(laSolver.ImpedanceTransformation);
                cboLAProblemType.SelectedIndex = Convert.ToInt32(laSolver.ProblemType);
                cboLAOutputLines.SelectedIndex = Convert.ToInt32(laSolver.OutputLines);
                cboLATravelDirection.SelectedIndex = Convert.ToInt32(laSolver.TravelDirection);

                //// INASolverSettings
                PopulateImpedanceNameControl(cboLAImpedance, networkDataset, naSolverSettings.ImpedanceAttributeName);
                PopulateAttributeControl(chklstLAAccumulateAttributeNames, networkDataset, naSolverSettings.AccumulateAttributeNames, esriNetworkAttributeUsageType.esriNAUTCost);
                PopulateAttributeControl(chklstLARestrictionAttributeNames, networkDataset, naSolverSettings.RestrictionAttributeNames, esriNetworkAttributeUsageType.esriNAUTRestriction);
                chkLAUseHierarchy.Enabled = (naSolverSettings.HierarchyAttributeName.Length > 0);
                chkLAUseHierarchy.Checked = (chkCFUseHierarchy.Enabled && naSolverSettings.UseHierarchy);
                chkLAIgnoreInvalidLocations.Checked = naSolverSettings.IgnoreInvalidLocations;
            }
            else  // Unknown type of layer
            {
                // Remove unnecessary tabs
                tabPropPages.TabPages.Remove(tabRoute);
                tabPropPages.TabPages.Remove(tabClosestFacility);
                tabPropPages.TabPages.Remove(tabODCostMatrix);
                tabPropPages.TabPages.Remove(tabServiceArea);
                tabPropPages.TabPages.Remove(tabVRP);
                tabPropPages.TabPages.Remove(tabLocationAllocation);
            }
        }

        /// <summary>
        /// Updates the NALayer based on the current controls.
        /// This will update the solver settings for the solver referenced by the NALayer.
        /// </summary>
        private void UpdateNALayer(INALayer naLayer)
        {
            ILayer layer = naLayer as ILayer;
            INAContext naContext = naLayer.Context;
            INetworkDataset networkDataset = naContext.NetworkDataset;
            INALocator2 naLocator = naContext.Locator as INALocator2;
            INASolver naSolver = naContext.Solver;
            INASolverSettings naSolverSettings = naSolver as INASolverSettings2;
            INARouteSolver2 routeSolver = naSolver as INARouteSolver2;
            INAClosestFacilitySolver cfSolver = naSolver as INAClosestFacilitySolver;
            INAODCostMatrixSolver odSolver = naSolver as INAODCostMatrixSolver;
            INAServiceAreaSolver2 saSolver = naSolver as INAServiceAreaSolver2;
            INAVRPSolver vrpSolver = naSolver as INAVRPSolver;
            INALocationAllocationSolver laSolver = naSolver as INALocationAllocationSolver;

            // Set Layer properties
            layer.Name = txtLayerName.Text;
            naLocator.MaxSnapTolerance = Convert.ToDouble(txtMaxSearchTolerance.Text);
            naLocator.SnapToleranceUnits = (esriUnits)cboMaxSearchToleranceUnits.SelectedIndex;

            // Set Solver properties
            if (routeSolver != null)  // ROUTE LAYER
            {
                // INARouteSolver
                routeSolver.FindBestSequence = chkRouteFindBestSequence.Checked;
                routeSolver.PreserveFirstStop = chkRoutePreserveFirstStop.Checked;
                routeSolver.PreserveLastStop = chkRoutePreserveLastStop.Checked;
                routeSolver.UseTimeWindows = chkRouteUseTimeWindows.Checked;
                routeSolver.UseStartTime = chkRouteUseStartTime.Checked;
                routeSolver.StartTime = System.Convert.ToDateTime(txtRouteStartTime.Text);
                routeSolver.OutputLines = (esriNAOutputLineType)cboRouteOutputLines.SelectedIndex;

                // INASolverSettings
                naSolverSettings.ImpedanceAttributeName = cboRouteImpedance.Text;
                naSolverSettings.UseHierarchy = chkRouteUseHierarchy.Checked;
                naSolverSettings.IgnoreInvalidLocations = chkRouteIgnoreInvalidLocations.Checked;
                naSolverSettings.RestrictUTurns = (esriNetworkForwardStarBacktrack)cboRouteRestrictUTurns.SelectedIndex;
                naSolverSettings.AccumulateAttributeNames = GetCheckedAttributeNamesFromControl(chklstRouteAccumulateAttributeNames);
                naSolverSettings.RestrictionAttributeNames = GetCheckedAttributeNamesFromControl(chklstRouteRestrictionAttributeNames);
            }

            else if (cfSolver != null)  // CLOSEST FACILITY LAYER
            {
                if (txtCFDefaultCutoff.Text.Length == 0)
                    cfSolver.DefaultCutoff = null;
                else
                    cfSolver.DefaultCutoff = Convert.ToDouble(txtCFDefaultCutoff.Text);

                if (txtCFDefaultTargetFacilityCount.Text.Length == 0)
                    cfSolver.DefaultTargetFacilityCount = 1;
                else
                    cfSolver.DefaultTargetFacilityCount = Convert.ToInt32(txtCFDefaultTargetFacilityCount.Text);

                cfSolver.TravelDirection = (esriNATravelDirection)cboCFTravelDirection.SelectedIndex;
                cfSolver.OutputLines = (esriNAOutputLineType)cboCFOutputLines.SelectedIndex;

                // INASolverSettings
                naSolverSettings.ImpedanceAttributeName = cboCFImpedance.Text;
                naSolverSettings.UseHierarchy = chkCFUseHierarchy.Checked;
                naSolverSettings.IgnoreInvalidLocations = chkCFIgnoreInvalidLocations.Checked;
                naSolverSettings.RestrictUTurns = (esriNetworkForwardStarBacktrack)cboCFRestrictUTurns.SelectedIndex;
                naSolverSettings.AccumulateAttributeNames = GetCheckedAttributeNamesFromControl(chklstCFAccumulateAttributeNames);
                naSolverSettings.RestrictionAttributeNames = GetCheckedAttributeNamesFromControl(chklstCFRestrictionAttributeNames);
            }

            else if (odSolver != null)  // OD COST MATRIX LAYER
            {
                if (txtODDefaultCutoff.Text.Length == 0)
                    odSolver.DefaultCutoff = null;
                else
                    odSolver.DefaultCutoff = Convert.ToDouble(txtODDefaultCutoff.Text);

                if (txtODDefaultTargetDestinationCount.Text.Length == 0)
                    odSolver.DefaultTargetDestinationCount = null;
                else
                    odSolver.DefaultTargetDestinationCount = Convert.ToInt32(txtODDefaultTargetDestinationCount.Text);

                odSolver.OutputLines = (esriNAOutputLineType)cboODOutputLines.SelectedIndex;

                // INASolverSettings
                naSolverSettings.ImpedanceAttributeName = cboODImpedance.Text;
                naSolverSettings.UseHierarchy = chkODUseHierarchy.Checked;
                naSolverSettings.IgnoreInvalidLocations = chkODIgnoreInvalidLocations.Checked;
                naSolverSettings.RestrictUTurns = (esriNetworkForwardStarBacktrack)cboODRestrictUTurns.SelectedIndex;
                naSolverSettings.AccumulateAttributeNames = GetCheckedAttributeNamesFromControl(chklstODAccumulateAttributeNames);
                naSolverSettings.RestrictionAttributeNames = GetCheckedAttributeNamesFromControl(chklstODRestrictionAttributeNames);
            }

            else if (saSolver != null)  // SERVICE AREA SOLVER
            {
                IDoubleArray defaultBreaks = saSolver.DefaultBreaks;
                defaultBreaks.RemoveAll();
                string breaks = txtSADefaultBreaks.Text.Trim();
                breaks.Replace("  ", " ");
                string[] values = breaks.Split(' ');
                for (int iBreak = values.GetLowerBound(0); iBreak <= values.GetUpperBound(0); iBreak++)
                    defaultBreaks.Add(System.Convert.ToDouble(values.GetValue(iBreak)));
                saSolver.DefaultBreaks = defaultBreaks;
                saSolver.TravelDirection = (esriNATravelDirection)cboSATravelDirection.SelectedIndex;

                saSolver.OutputPolygons = (esriNAOutputPolygonType)cboSAOutputPolygons.SelectedIndex;
                saSolver.OverlapPolygons = chkSAOverlapPolygons.Checked;
                saSolver.SplitPolygonsAtBreaks = chkSASplitPolygonsAtBreaks.Checked;
                saSolver.MergeSimilarPolygonRanges = chkSAMergeSimilarPolygonRanges.Checked;
                saSolver.TrimOuterPolygon = chkSATrimOuterPolygon.Checked;
                saSolver.TrimPolygonDistance = Convert.ToDouble(this.txtSATrimPolygonDistance.Text);
                saSolver.TrimPolygonDistanceUnits = (esriUnits)cboSATrimPolygonDistanceUnits.SelectedIndex;

                if (cboSAOutputLines.SelectedIndex == 0)
                    saSolver.OutputLines = (esriNAOutputLineType)cboSAOutputLines.SelectedIndex;
                else // Does not support Straight lines, so not in combobox, up by one to account for this
                    saSolver.OutputLines = (esriNAOutputLineType)(cboSAOutputLines.SelectedIndex + 1);

                saSolver.OverlapLines = chkSAOverlapLines.Checked;
                saSolver.SplitLinesAtBreaks = chkSASplitLinesAtBreaks.Checked;
                saSolver.IncludeSourceInformationOnLines = this.chkSAIncludeSourceInformationOnLines.Checked;

                // INASolverSettings
                naSolverSettings.ImpedanceAttributeName = cboSAImpedance.Text;
                naSolverSettings.IgnoreInvalidLocations = chkSAIgnoreInvalidLocations.Checked;
                naSolverSettings.RestrictUTurns = (esriNetworkForwardStarBacktrack)cboSARestrictUTurns.SelectedIndex;
                naSolverSettings.AccumulateAttributeNames = GetCheckedAttributeNamesFromControl(chklstSAAccumulateAttributeNames);
                naSolverSettings.RestrictionAttributeNames = GetCheckedAttributeNamesFromControl(chklstSARestrictionAttributeNames);
            }
            else if (vrpSolver != null)
            {
                naSolverSettings.ImpedanceAttributeName = cboVRPTimeAttribute.Text;
                naSolverSettings.AccumulateAttributeNames.RemoveAll();
                IStringArray strArray = naSolverSettings.AccumulateAttributeNames;
                strArray.RemoveAll();
                strArray.Add(cboVRPDistanceAttribute.Text);
                naSolverSettings.AccumulateAttributeNames = strArray;

                vrpSolver.CapacityCount = Convert.ToInt32(txtVRPCapacityCount.Text);
                vrpSolver.DefaultDate = Convert.ToDateTime(txtVRPDefaultDate.Text);
                vrpSolver.TimeFieldUnits = ((esriNetworkAttributeUnits)cboVRPTimeFieldUnits.SelectedIndex) + 20;

                // there cannot be unknown units for a VRP, so the index is offset by 1
                vrpSolver.DistanceFieldUnits = (esriNetworkAttributeUnits)cboVRPDistanceFieldUnits.SelectedIndex + 1;
                naSolverSettings.RestrictUTurns = (esriNetworkForwardStarBacktrack)cboVRPAllowUTurns.SelectedIndex;
                vrpSolver.OutputLines = (esriNAOutputLineType)cboVRPOutputShapeType.SelectedIndex;
                vrpSolver.TimeWindowViolationPenaltyFactor = cboVRPTimeWindow.SelectedIndex;
                vrpSolver.ExcessTransitTimePenaltyFactor = cboVRPTransitTime.SelectedIndex;

                naSolverSettings.UseHierarchy = chkVRPUseHierarchy.Checked;

                naSolverSettings.RestrictionAttributeNames = GetCheckedAttributeNamesFromControl(chklstVRPRestrictionAttributeNames);
            }
            else if (laSolver != null)  // Location-Allocation LAYER
            {
                if (txtLACutOff.Text.Length == 0)
                    laSolver.DefaultCutoff = null;
                else if (Convert.ToDouble(txtLACutOff.Text) == 0.0)
                    laSolver.DefaultCutoff = null;
                else
                    laSolver.DefaultCutoff = Convert.ToDouble(txtLACutOff.Text);

                if (txtLAFacilitiesToLocate.Text.Length == 0)
                    laSolver.NumberFacilitiesToLocate = 1;
                else
                    laSolver.NumberFacilitiesToLocate = Convert.ToInt32(txtLAFacilitiesToLocate.Text);

                laSolver.ProblemType = (esriNALocationAllocationProblemType)cboLAProblemType.SelectedIndex;
                laSolver.ImpedanceTransformation = (esriNAImpedanceTransformationType)cboLAImpTransformation.SelectedIndex;
                laSolver.TransformationParameter = Convert.ToDouble(txtLAImpParameter.Text);
                laSolver.TargetMarketSharePercentage = Convert.ToDouble(txtLATargetMarketShare.Text);
                laSolver.TravelDirection = (esriNATravelDirection)cboLATravelDirection.SelectedIndex;
                laSolver.OutputLines = (esriNAOutputLineType)cboLAOutputLines.SelectedIndex;

                //// INASolverSettings
                naSolverSettings.ImpedanceAttributeName = cboLAImpedance.Text;
                naSolverSettings.UseHierarchy = chkLAUseHierarchy.Checked;
                naSolverSettings.AccumulateAttributeNames = GetCheckedAttributeNamesFromControl(chklstLAAccumulateAttributeNames);
                naSolverSettings.RestrictionAttributeNames = GetCheckedAttributeNamesFromControl(chklstLARestrictionAttributeNames);
                naSolverSettings.IgnoreInvalidLocations = chkLAIgnoreInvalidLocations.Checked;
            }
        }

        /// <summary>
        /// Update the Impedance control based on the network dataset cost attributes
        /// </summary>
        private void PopulateImpedanceNameControl(ComboBox cboImpedance, INetworkDataset networkDataset, string impedanceName)
        {
            cboImpedance.Items.Clear();

            for (int i = 0; i < networkDataset.AttributeCount; i++)
            {
                INetworkAttribute networkAttribute = networkDataset.get_Attribute(i);
                if (networkAttribute.UsageType == esriNetworkAttributeUsageType.esriNAUTCost)
                    cboImpedance.Items.Add(networkAttribute.Name);
            }

            if (cboImpedance.Items.Count > 0)
                cboImpedance.Text = impedanceName;
        }

        /// <summary>
        /// Update the CheckedListBox control based on the network dataset attributes (checking the ones currently chosen by the solver)
        /// </summary>
        private void PopulateAttributeControl(CheckedListBox chklstBox, INetworkDataset networkDataset, IStringArray strArray, esriNetworkAttributeUsageType usageType)
        {
            chklstBox.Items.Clear();

            //  Loop through the network dataset attributes
            for (int i = 0; i < networkDataset.AttributeCount; i++)
            {
                INetworkAttribute networkAttribute = networkDataset.get_Attribute(i);
                if (networkAttribute.UsageType == usageType)
                {
                    string attributeName = networkAttribute.Name;
                    CheckState checkState = CheckState.Unchecked;

                    // If the attribute is in the strArray, it should be checked
                    for (int j = 0; j < strArray.Count; j++)
                        if (strArray.get_Element(j) == attributeName)
                            checkState = CheckState.Checked;

                    // Add the attribute to the control
                    chklstBox.Items.Add(attributeName, checkState);
                }
            }
        }

        /// <summary>
        /// Returns the attribute names checked.
        /// </summary>
        private IStringArray GetCheckedAttributeNamesFromControl(CheckedListBox chklstBox)
        {
            IStringArray attributeNames = new StrArrayClass();

            for (int i = 0; i < chklstBox.CheckedItems.Count; i++)
                attributeNames.Add(chklstBox.Items[chklstBox.CheckedIndices[i]].ToString());

            return attributeNames;
        }

        /// <summary>
        /// Encapsulates returning an empty string if the object is NULL.
        /// </summary>
        private string GetStringFromObject(object value)
        {
            if (value == null)
                return "";
            else
                return value.ToString();
        }

        private void chkRouteUseStartTime_CheckedChanged(object sender, EventArgs e)
        {
            txtRouteStartTime.Enabled = chkRouteUseStartTime.Checked;
        }

        private void chkRouteFindBestSequence_CheckedChanged(object sender, EventArgs e)
        {
            chkRoutePreserveFirstStop.Enabled = chkRouteFindBestSequence.Checked;
            chkRoutePreserveLastStop.Enabled = chkRouteFindBestSequence.Checked;
        }

        // Enable/Disable SA Polygon controls if not generating polygons
        private void cboSAOutputPolygons_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bOutputPolygons = (cboSAOutputPolygons.SelectedIndex > 0);
            chkSAOverlapPolygons.Enabled = bOutputPolygons;
            chkSASplitPolygonsAtBreaks.Enabled = bOutputPolygons;
            chkSAMergeSimilarPolygonRanges.Enabled = bOutputPolygons;
            chkSATrimOuterPolygon.Enabled = bOutputPolygons;
            txtSATrimPolygonDistance.Enabled = bOutputPolygons;
            cboSATrimPolygonDistanceUnits.Enabled = bOutputPolygons;
        }

        // Enable/Disable SA Line controls if not generating lines
        private void cboSAOutputLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bOutputLines = (cboSAOutputLines.SelectedIndex > 0);
            chkSAOverlapLines.Enabled = bOutputLines;
            chkSASplitLinesAtBreaks.Enabled = bOutputLines;
            chkSAIncludeSourceInformationOnLines.Enabled = bOutputLines;
        }

        private void cboLAProblemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboLAProblemType.SelectedIndex == 5) || (cboLAProblemType.SelectedIndex == 2))
                txtLAFacilitiesToLocate.Enabled = false;
            else
                txtLAFacilitiesToLocate.Enabled = true;

            if (cboLAProblemType.SelectedIndex == 5)
                txtLATargetMarketShare.Enabled = true;
            else
                txtLATargetMarketShare.Enabled = false;
        }
    }
}
