using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;

namespace SpatialQueryAndAnalysis.空间查询与空间分析.NetworkAnalyst
{
    public partial class frmLoadLocation : Form
    {
        bool m_okClicked;
        System.Collections.IList m_listDisplayTable;

        public frmLoadLocation()
        {
            InitializeComponent();
        }

        public bool ShowModal(IMapControl3 mapControl, IEngineNetworkAnalystEnvironment naEnv)
        {
            // Initialize variables
            m_okClicked = false;
            m_listDisplayTable = new System.Collections.ArrayList();

            // Get the NALayer and NAContext
            INALayer naLayer = naEnv.NAWindow.ActiveAnalysis;
            INAContext naContext = naLayer.Context;

            //Get the active category
            IEngineNAWindowCategory2 activeCategory = naEnv.NAWindow.ActiveCategory as IEngineNAWindowCategory2;
            if (activeCategory == null)
                return false;

            INAClass naClass = activeCategory.NAClass;
            IDataset naDataset = naClass as IDataset;
            IDataLayer pDataLayer = activeCategory.DataLayer;

            ILayer pLayer = pDataLayer as ILayer;
            IFeatureLayer pFeatureLayer = pDataLayer as IFeatureLayer;
            IStandaloneTable pStandaloneTable = pDataLayer as IStandaloneTable;

            esriGeometryType targetGeoType = esriGeometryType.esriGeometryNull;

            String dataLayerName = "";
            if (pFeatureLayer != null)
            {
                if (pLayer.Valid)
                {
                    IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                    if (pFeatureClass != null)
                    {
                        targetGeoType = pFeatureClass.ShapeType;
                        dataLayerName = pLayer.Name;
                    }
                }
            }
            else if (pStandaloneTable != null)
            {
                dataLayerName = pStandaloneTable.Name;
            }

            if (dataLayerName.Length == 0)
                return false;

            this.Text = "Load Items into " + dataLayerName;

            // Loop through all the sourcedisplayTables having targetGeoType to the combo box and the
            // list of displayTables

            IEnumLayer sourceLayers = null;
            ILayer sourceLayer = null;
            IDisplayTable sourceDisplayTable = null;
            UID searchInterfaceUID = new UID();

            if (targetGeoType != esriGeometryType.esriGeometryNull)
            {
                searchInterfaceUID.Value = typeof(IFeatureLayer).GUID.ToString("B");
                sourceLayers = mapControl.Map.get_Layers(searchInterfaceUID, true);

                sourceLayer = sourceLayers.Next();
                while (sourceLayer != null)
                {
                    IFeatureLayer sourceFeatureLayer = sourceLayer as IFeatureLayer;
                    sourceDisplayTable = sourceLayer as IDisplayTable;

                    if ((sourceFeatureLayer != null) && (sourceDisplayTable != null))
                    {
                        IFeatureClass sourceFeatureClass = sourceFeatureLayer.FeatureClass;
                        esriGeometryType sourceGeoType = sourceFeatureClass.ShapeType;
                        if ((sourceGeoType == targetGeoType) ||
                           (targetGeoType == esriGeometryType.esriGeometryPoint && sourceGeoType == esriGeometryType.esriGeometryMultipoint))
                        {
                            // Add the layer name to the combobox and the layer to the list
                            cboInputData.Items.Add(sourceLayer.Name);
                            m_listDisplayTable.Add(sourceDisplayTable);
                        }
                    }

                    sourceLayer = sourceLayers.Next();
                }
            }
            else //if (targetGeoType == esriGeometryType.esriGeometryNull)
            {
                IStandaloneTableCollection sourceStandaloneTables = mapControl.Map as IStandaloneTableCollection;
                IStandaloneTable sourceStandaloneTable = null;
                sourceDisplayTable = null;

                int count = 0;
                if (sourceStandaloneTables != null)
                    count = sourceStandaloneTables.StandaloneTableCount;

                for (int i = 0; i < count; ++i)
                {
                    sourceStandaloneTable = sourceStandaloneTables.get_StandaloneTable(i);
                    sourceDisplayTable = sourceStandaloneTable as IDisplayTable;

                    if ((sourceStandaloneTable != null) && (sourceDisplayTable != null))
                    {
                        // Add the table name to the combobox and the layer to the list
                        cboInputData.Items.Add(sourceStandaloneTable.Name);
                        m_listDisplayTable.Add(sourceDisplayTable);
                    }
                }

                searchInterfaceUID.Value = typeof(INALayer).GUID.ToString("B");
                sourceLayers = mapControl.Map.get_Layers(searchInterfaceUID, true);

                sourceLayer = sourceLayers.Next();
                while (sourceLayer != null)
                {
                    INALayer sourceNALayer = sourceLayer as INALayer;
                    if (sourceNALayer != null)
                    {
                        sourceStandaloneTables = sourceNALayer as IStandaloneTableCollection;
                        sourceStandaloneTable = null;
                        sourceDisplayTable = null;

                        count = 0;
                        if (sourceStandaloneTables != null)
                            count = sourceStandaloneTables.StandaloneTableCount;

                        for (int i = 0; i < count; ++i)
                        {
                            sourceStandaloneTable = sourceStandaloneTables.get_StandaloneTable(i);
                            sourceDisplayTable = sourceStandaloneTable as IDisplayTable;

                            if ((sourceStandaloneTable != null) && (sourceDisplayTable != null))
                            {
                                // Add the table name to the combobox and the layer to the list
                                cboInputData.Items.Add(sourceStandaloneTable.Name);
                                m_listDisplayTable.Add(sourceDisplayTable);
                            }
                        }
                    }

                    sourceLayer = sourceLayers.Next();
                }
            }

            //Select the first display table from the list
            if (cboInputData.Items.Count > 0)
                cboInputData.SelectedIndex = 0;

            // Show the window
            this.ShowDialog();

            // If we selected a layer and clicked OK, load the locations
            if (m_okClicked && (cboInputData.SelectedIndex >= 0))
            {
                // Get a cursor on the source display table (either though the selection set or table)
                // Use IDisplayTable because it accounts for joins, querydefs, etc.
                // IDisplayTable is implemented by FeatureLayers and StandaloneTables.
                //
                IDisplayTable displayTable = m_listDisplayTable[cboInputData.SelectedIndex] as IDisplayTable;
                ICursor cursor;
                if (chkUseSelection.Checked)
                {
                    ISelectionSet selSet;
                    selSet = displayTable.DisplaySelectionSet;
                    selSet.Search(null, false, out cursor);
                }
                else
                {
                    cursor = displayTable.SearchDisplayTable(null, false);
                }

                // Setup NAClassLoader and Load Locations
                INAClassLoader2 naClassLoader = new NAClassLoader() as INAClassLoader2;
                naClassLoader.Initialize(naContext, naDataset.Name, cursor);

                // Avoid loading network locations onto non-traversable portions of elements
                INALocator3 locator = naContext.Locator as INALocator3;
                locator.ExcludeRestrictedElements = true;
                locator.CacheRestrictedElements(naContext);

                int rowsIn = 0;
                int rowsLocated = 0;
                naClassLoader.Load(cursor, null, ref rowsIn, ref rowsLocated);

                return true;
            }

            return false;
        }

        private void frmLoadLocation_Load(object sender, EventArgs e)
        {

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

        private void cboInputData_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the chkUseSelecteFeatures control based on if anything is selected or not
            if (cboInputData.SelectedIndex >= 0)
            {
                IDisplayTable displayTable = m_listDisplayTable[cboInputData.SelectedIndex] as IDisplayTable;
                chkUseSelection.Checked = (displayTable.DisplaySelectionSet.Count > 0);
                chkUseSelection.Enabled = (displayTable.DisplaySelectionSet.Count > 0);
            }
        }
    }
}
