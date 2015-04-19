using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Carto;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class OverlayAnalysis : Form
    {
        IHookHelper m_hookHelper;
        IActiveView m_activeView;
        IMap m_map;

        string strOveralyerType = "";

        string strInputLayer;//输入图层
        string strOverLayer; //叠置图层
        double tolerance = 0.1;
        string strJoinAttributeType = "ALL";//叠置分析结果属性输出类型，即输出哪些属性字段
        string strOutputFeatureType = "INPUT";//叠置分析结果要素输出类型
        string strOutputPath = System.IO.Path.GetTempPath();
        decimal inputLevel = 1;
        decimal overlayLevel = 1;

        //以下2个变量用于设置要素属性的显示与打印，displaySelectedFeatures变量设置为true时，
        //仅对要素的选择集有效； 否则对所有要素有效。
        //displayViaReport变量设置为true时，以报表方式显示或打印要素属性；
        //否则，以普通的属性表方式显示要素的属性
        bool displaySelectedFeatures = true;
        bool displayViaReport = true;

        public OverlayAnalysis(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
        }

        #region "GetLayers"
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";// IFeatureLayer
            //uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";  // IGeoFeatureLayer
            //uid.Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}";  // IDataLayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }
        #endregion

        private void OverlayAnalysis_Load(object sender, EventArgs e)
        {
            CboAddItems(cboSelectInputLayer);
            cboAttributeType.Enabled = false;
            cboFeatureType.Enabled = false;
            lblAttributeType.Enabled = false;
            lblFeatureType.Enabled = false;
        }

        private void rdoSelectedFeatures_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSelectedFeatures.Checked)
                displaySelectedFeatures = true;
            else
                displaySelectedFeatures = false;
        }

        private void rdoReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReport.Checked)
                displayViaReport = true;
            else
                displayViaReport = false;
        }

        #region "btnAttributes_Click"
        private void btnAttributes_Click(object sender, EventArgs e)
        {
            if (displayViaReport)
            {
                DynamicAttributesReport displayAtrributes = new DynamicAttributesReport(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            }
            else
            {
                AttributesForm displayAtrributes = new AttributesForm(m_map, displaySelectedFeatures);
                displayAtrributes.Show(this as System.Windows.Forms.IWin32Window);
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "CboAddItems"
        private void CboAddItems(ComboBox cbo, esriGeometryType geometryType)
        {
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.FeatureClass.ShapeType == geometryType)
                    {
                        cbo.Items.Add(layer.Name);
                    }
                }
                layer = layers.Next();
            }
        }

        private void CboAddItems(ComboBox cbo, esriGeometryType geometryType, IFeatureLayer inputLayer)
        {
            esriGeometryType inputGeometryType = inputLayer.FeatureClass.ShapeType;
            string inputName = inputLayer.Name;
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.Name == inputName) goto label1;
                    if (featureLayer.FeatureClass.ShapeType == geometryType)
                    {
                        cbo.Items.Add(layer.Name);
                    }
                }
            label1: layer = layers.Next();
            }
        }

        private void CboAddItems(ComboBox cbo, IFeatureLayer inputLayer)
        {
            esriGeometryType inputGeometryType = inputLayer.FeatureClass.ShapeType;
            string inputName = inputLayer.Name;
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.Name == inputName) goto label1;
                    cbo.Items.Add(layer.Name);
                }
            label1: layer = layers.Next();
            }
        }
        #endregion

        #region "CboAddItems"
        private void CboAddItemsForErase(ComboBox cbo, IFeatureLayer inputLayer)
        {
            esriGeometryType inputGeometryType = inputLayer.FeatureClass.ShapeType;
            string inputName = inputLayer.Name;
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.Name == inputName) goto label1;
                    esriGeometryType overlayGeometryType = featureLayer.FeatureClass.ShapeType;
                    if (inputGeometryType == esriGeometryType.esriGeometryPoint || inputGeometryType == esriGeometryType.esriGeometryMultipoint)
                    {
                        cbo.Items.Add(layer.Name);
                    }
                    if (inputGeometryType == esriGeometryType.esriGeometryPolyline)
                    {
                        if (overlayGeometryType == esriGeometryType.esriGeometryPolyline || overlayGeometryType == esriGeometryType.esriGeometryPolygon)
                        {
                            cbo.Items.Add(layer.Name);
                        }
                    }
                    if (inputGeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        if (overlayGeometryType == esriGeometryType.esriGeometryPolygon)
                        {
                            cbo.Items.Add(layer.Name);
                        }
                    }

                }
            label1: layer = layers.Next();
            }
        }

        private void CboAddItemsForIdentity(ComboBox cbo, IFeatureLayer inputLayer)
        {
            esriGeometryType inputGeometryType = inputLayer.FeatureClass.ShapeType;
            string inputName = inputLayer.Name;
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.Name == inputName) goto label1;
                    esriGeometryType overlayGeometryType = featureLayer.FeatureClass.ShapeType;
                    if (overlayGeometryType == inputGeometryType || overlayGeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        cbo.Items.Add(layer.Name);
                    }
                }
            label1: layer = layers.Next();
            }
        }

        private void CboAddItemsForSymDiff(ComboBox cbo, IFeatureLayer inputLayer)
        {
            esriGeometryType inputGeometryType = inputLayer.FeatureClass.ShapeType;
            string inputName = inputLayer.Name;
            IFeatureLayer featureLayer;
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    featureLayer = layer as IFeatureLayer;
                    if (featureLayer.Name == inputName) goto label1;
                    esriGeometryType overlayGeometryType = featureLayer.FeatureClass.ShapeType;
                    if (overlayGeometryType == inputGeometryType)
                    {
                        cbo.Items.Add(layer.Name);
                    }
                }
            label1: layer = layers.Next();
            }
        }
        #endregion

        #region "CboAddItems"
        private void CboAddItems(ComboBox cbo)
        {
            IEnumLayer layers = GetLayers();
            if (layers == null) return;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    cbo.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
        }
        #endregion

        #region "cboOveralyerType_SelectedIndexChanged"
        private void cboOveralyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            strOveralyerType = cboOveralyerType.SelectedItem.ToString();
            switch (strOveralyerType)
            {
                case "求交叠置":
                    cboSelectInputLayer.Items.Clear();
                    CboAddItems(cboSelectInputLayer);
                    cboAttributeType.Enabled = true;
                    lblAttributeType.Enabled = true;
                    cboFeatureType.Enabled = true;
                    lblFeatureType.Enabled = true;
                    numUpDownInputLevel.Enabled = true;
                    lblInputLevel.Enabled = true;
                    numUpDownOverlayLevel.Enabled = true;
                    lblOverlayLevel.Enabled = true;
                    break;

                case "求和叠置":
                    cboSelectInputLayer.Items.Clear();
                    CboAddItems(cboSelectInputLayer, esriGeometryType.esriGeometryPolygon);
                    cboAttributeType.Enabled = true;
                    lblAttributeType.Enabled = true;
                    cboFeatureType.Enabled = false;
                    lblFeatureType.Enabled = false;
                    numUpDownInputLevel.Enabled = true;
                    lblInputLevel.Enabled = true;
                    numUpDownOverlayLevel.Enabled = true;
                    lblOverlayLevel.Enabled = true;
                    break;

                case "擦除叠置":
                    cboSelectInputLayer.Items.Clear();
                    CboAddItems(cboSelectInputLayer);
                    cboAttributeType.Enabled = false;
                    lblAttributeType.Enabled = false;
                    cboFeatureType.Enabled = false;
                    lblFeatureType.Enabled = false;
                    numUpDownInputLevel.Enabled = false;
                    lblInputLevel.Enabled = false;
                    numUpDownOverlayLevel.Enabled = false;
                    lblOverlayLevel.Enabled = false;
                    break;
                case "同一性叠置":
                    cboSelectInputLayer.Items.Clear();
                    CboAddItems(cboSelectInputLayer);
                    cboAttributeType.Enabled = true;
                    lblAttributeType.Enabled = true;
                    cboFeatureType.Enabled = false;
                    lblFeatureType.Enabled = false;
                    numUpDownInputLevel.Enabled = false;
                    lblInputLevel.Enabled = false;
                    numUpDownOverlayLevel.Enabled = false;
                    lblOverlayLevel.Enabled = false;
                    break;

                case "更新叠置":
                    cboSelectInputLayer.Items.Clear();
                    CboAddItems(cboSelectInputLayer, esriGeometryType.esriGeometryPolygon);
                    cboAttributeType.Enabled = false;
                    lblAttributeType.Enabled = false;
                    cboFeatureType.Enabled = false;
                    lblFeatureType.Enabled = false;
                    numUpDownInputLevel.Enabled = false;
                    lblInputLevel.Enabled = false;
                    numUpDownOverlayLevel.Enabled = false;
                    lblOverlayLevel.Enabled = false;
                    break;
                case "异或叠置":
                    cboSelectInputLayer.Items.Clear();
                    CboAddItems(cboSelectInputLayer);
                    cboAttributeType.Enabled = true;
                    lblAttributeType.Enabled = true;
                    cboFeatureType.Enabled = false;
                    lblFeatureType.Enabled = false;
                    numUpDownInputLevel.Enabled = false;
                    lblInputLevel.Enabled = false;
                    numUpDownOverlayLevel.Enabled = false;
                    lblOverlayLevel.Enabled = false;
                    break;
                default:
                    break;
            }
            cboSelectInputLayer.Text = "";
            cboOverlayLayer.Text = "";
        }

        #endregion

        private void btnOverlay_Click(object sender, EventArgs e)
        {
            if (strInputLayer == "" || strOverLayer == "") return;
            txtMessages.Text += "叠置分析: " + strOveralyerType + "\r\n";
            txtMessages.Text += "输入图层: " + strInputLayer + "\r\n";
            txtMessages.Text += "叠置图层: " + strOverLayer + "\r\n";
            txtMessages.Text += "\r\n开始叠置分析. 请稍候...\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            txtMessages.Update();

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            gp.AddOutputsToMap = true;
            //DisplayEnvironmentPameters(gp);
            IGeoProcessorResult results = null;
            switch (strOveralyerType)
            {
                case "求交叠置":
                    results = IntersectOverlay(gp);
                    break;
                case "求和叠置":
                    results = UnionOverlay(gp);
                    break;
                case "擦除叠置":
                    results = EraseOverlay(gp);
                    break;
                case "同一性叠置":
                    results = IdentityOverlay(gp);
                    break;

                case "更新叠置":
                    results = UpdateOverlay(gp);
                    break;
                case "异或叠置":
                    results = SymDiffOverlay(gp);
                    break;
                default:
                    break;
            }

            txtMessages.Text += ReturnMessages(gp);

            txtMessages.Text += "\r\n叠置分析完成.\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            txtMessages.Text += "-------------------------------------------------------\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }

        private void DisplayEnvironmentPameters(Geoprocessor gp)
        {
            IGpEnumList environments = gp.ListEnvironments("*");
            environments.Reset();
            string env = environments.Next();
            while (env != "")
            {
                txtMessages.Text += "环境参数: " + env + "\r\n";
                env = environments.Next();
            }
            txtMessages.Update();
        }

        private IGeoProcessorResult IntersectOverlay3(Geoprocessor gp)
        {
            //Intersect_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, output_type) 

            IGpValueTableObject vtobject = new GpValueTableObjectClass();
            vtobject.SetColumns(2);
            object row = "";
            row = strInputLayer + " " + inputLevel.ToString();
            vtobject.AddRow(ref row);
            row = strOverLayer + " " + overlayLevel.ToString();
            vtobject.AddRow(ref row);
            IVariantArray pVarArray = new VarArrayClass();
            pVarArray.Add(vtobject);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Intersect");
            pVarArray.Add(outputFullPath);
            pVarArray.Add(strJoinAttributeType);
            pVarArray.Add(tolerance);
            pVarArray.Add(strOutputFeatureType);

            // Execute the Intersect tool.
            IGeoProcessorResult results = gp.Execute("intersect_analysis", pVarArray, null) as IGeoProcessorResult;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(pVarArray);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(vtobject);

            return results;
        }

        private IGeoProcessorResult IntersectOverlay(Geoprocessor gp)
        {
            //Intersect_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, output_type) 

            IGpValueTableObject vtobject = new GpValueTableObjectClass();
            vtobject.SetColumns(1);
            object row = null;
            row = GetFeatureLayer(strInputLayer);
            vtobject.AddRow(ref row);
            row = GetFeatureLayer(strOverLayer);
            vtobject.AddRow(ref row);
            IVariantArray pVarArray = new VarArrayClass();
            pVarArray.Add(vtobject);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Intersect");
            pVarArray.Add(outputFullPath);
            pVarArray.Add(strJoinAttributeType);
            pVarArray.Add(tolerance);
            pVarArray.Add(strOutputFeatureType);

            // Execute the Intersect tool.
            IGeoProcessorResult results = gp.Execute("intersect_analysis", pVarArray, null) as IGeoProcessorResult;
            return results;
        }

        private IGeoProcessorResult IntersectOverlay2(Geoprocessor gp)
        {
            //Intersect_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, output_type) 

            object row = null;
            IVariantArray pVarArray = new VarArrayClass();
            row = GetFeatureLayer(strInputLayer);
            pVarArray.Add(row);
            row = GetFeatureLayer(strOverLayer);
            pVarArray.Add(row);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Intersect");
            pVarArray.Add(outputFullPath);
            pVarArray.Add(strJoinAttributeType);
            pVarArray.Add(tolerance);
            pVarArray.Add(strOutputFeatureType);

            // Execute the Intersect tool.
            IGeoProcessorResult results = gp.Execute("intersect_analysis", pVarArray, null) as IGeoProcessorResult;
            return results;
        }

        private IGeoProcessorResult UnionOverlay2(Geoprocessor gp)
        {
            //Union_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, gaps)

            IGpValueTableObject vtobject = new GpValueTableObjectClass();
            vtobject.SetColumns(2);
            object row = "";
            row = strInputLayer + " " + inputLevel.ToString();
            vtobject.AddRow(ref row);
            row = strOverLayer + " " + overlayLevel.ToString();
            vtobject.AddRow(ref row);
            IVariantArray pVarArray = new VarArrayClass();
            pVarArray.Add(vtobject);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Union");
            pVarArray.Add(outputFullPath);
            pVarArray.Add(strJoinAttributeType);
            pVarArray.Add(tolerance);

            IGeoProcessorResult results = gp.Execute("Union_analysis", pVarArray, null) as IGeoProcessorResult;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pVarArray);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(vtobject);

            return results;
        }

        private IGeoProcessorResult UnionOverlay(Geoprocessor gp)
        {
            //Union_analysis (in_features, out_feature_class, join_attributes, cluster_tolerance, gaps)

            IGpValueTableObject vtobject = new GpValueTableObjectClass();
            vtobject.SetColumns(1);
            object row = "";
            row = GetFeatureLayer(strInputLayer);
            vtobject.AddRow(ref row);
            row = GetFeatureLayer(strOverLayer);
            vtobject.AddRow(ref row);
            IVariantArray pVarArray = new VarArrayClass();
            pVarArray.Add(vtobject);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Union.shp");
            pVarArray.Add(outputFullPath);
            pVarArray.Add(strJoinAttributeType);
            pVarArray.Add(tolerance);

            IGeoProcessorResult results = gp.Execute("Union_analysis", pVarArray, null) as IGeoProcessorResult;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pVarArray);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(vtobject);

            return results;
        }

        private IGeoProcessorResult EraseOverlay2(Geoprocessor gp)
        {
            //Erase_analysis (in_features, erase_features, out_feature_class, cluster_tolerance) 
            ESRI.ArcGIS.AnalysisTools.Erase erase = new ESRI.ArcGIS.AnalysisTools.Erase();
            erase.in_features = strInputLayer;
            erase.erase_features = strOverLayer;
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Erase");
            erase.out_feature_class = outputFullPath;
            erase.cluster_tolerance = tolerance;
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(erase, null);
            return results;
        }

        private IGeoProcessorResult EraseOverlay(Geoprocessor gp)
        {
            //Erase_analysis (in_features, erase_features, out_feature_class, cluster_tolerance) 
            ESRI.ArcGIS.AnalysisTools.Erase erase = new ESRI.ArcGIS.AnalysisTools.Erase();
            IFeatureLayer inputLayer = GetFeatureLayer(strInputLayer);
            erase.in_features = inputLayer;
            IFeatureLayer eraseLayer = GetFeatureLayer(strOverLayer);
            erase.erase_features = eraseLayer;
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Erase.shp");
            erase.out_feature_class = outputFullPath;
            erase.cluster_tolerance = tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(erase, null);

            //IGpValueTableObject vtobject = new GpValueTableObjectClass();
            //vtobject.SetColumns(1);
            //object row = "";
            //row = GetFeatureLayer(strInputLayer);
            //vtobject.AddRow(ref row);
            //row = GetFeatureLayer(strOverLayer);
            //vtobject.AddRow(ref row);
            //IVariantArray pVarArray = new VarArrayClass();
            //pVarArray.Add(vtobject);

            //string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Erase.shp");
            //pVarArray.Add(outputFullPath);
            //pVarArray.Add(tolerance);

            //IGeoProcessorResult results = gp.Execute("Erase_analysis", pVarArray, null) as IGeoProcessorResult;

            return results;
        }

        private IGeoProcessorResult IdentityOverlay2(Geoprocessor gp)
        {
            //Identity_analysis(in_features, identity_features, out_feature_class, join_attributes, cluster_tolerance, relationship)
            Identity identity = new Identity();
            identity.in_features = strInputLayer;
            identity.identity_features = strOverLayer;
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Identity");
            identity.out_feature_class = outputFullPath;
            identity.join_attributes = strJoinAttributeType;
            identity.cluster_tolerance = tolerance;
            //identity.relationship = true;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(identity, null);
            return results;
        }

        private IGeoProcessorResult IdentityOverlay(Geoprocessor gp)
        {
            //Identity_analysis(in_features, identity_features, out_feature_class, join_attributes, cluster_tolerance, relationship)
            Identity identity = new Identity();
            identity.in_features = GetFeatureLayer(strInputLayer);
            identity.identity_features = GetFeatureLayer(strOverLayer);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Identity.shp");
            identity.out_feature_class = outputFullPath;
            identity.join_attributes = strJoinAttributeType;
            identity.cluster_tolerance = tolerance;
            //identity.relationship = true;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(identity, null);
            return results;
        }

        private IGeoProcessorResult UpdateOverlay2(Geoprocessor gp)
        {
            //Update_analysis (in_features, update_features, out_feature_class, keep_borders, cluster_tolerance) 

            ESRI.ArcGIS.AnalysisTools.Update update = new ESRI.ArcGIS.AnalysisTools.Update();
            update.in_features = strInputLayer;
            update.update_features = strOverLayer;
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Update");
            update.out_feature_class = outputFullPath;
            update.keep_borders = "false";
            update.cluster_tolerance = tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(update, null);
            return results;
        }

        private IGeoProcessorResult UpdateOverlay(Geoprocessor gp)
        {
            //Update_analysis (in_features, update_features, out_feature_class, keep_borders, cluster_tolerance) 

            Update update = new Update();
            update.in_features = GetFeatureLayer(strInputLayer);
            update.update_features = GetFeatureLayer(strOverLayer);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "Update.shp");
            update.out_feature_class = outputFullPath;
            update.keep_borders = "false";
            update.cluster_tolerance = tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(update, null);
            return results;
        }

        private IGeoProcessorResult SymDiffOverlay2(Geoprocessor gp)
        {
            //SymDiff_analysis (in_features, update_features, out_feature_class, join_attributes, cluster_tolerance) 

            SymDiff symDiff = new SymDiff();
            symDiff.in_features = strInputLayer;
            symDiff.update_features = strOverLayer;
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "SymDiff");
            symDiff.out_feature_class = outputFullPath;
            symDiff.join_attributes = strJoinAttributeType;
            symDiff.cluster_tolerance = tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(symDiff, null);
            return results;
        }

        private IGeoProcessorResult SymDiffOverlay(Geoprocessor gp)
        {
            //SymDiff_analysis (in_features, update_features, out_feature_class, join_attributes, cluster_tolerance) 

            SymDiff symDiff = new SymDiff();
            symDiff.in_features = GetFeatureLayer(strInputLayer);
            symDiff.update_features = GetFeatureLayer(strOverLayer);
            string outputFullPath = System.IO.Path.Combine(strOutputPath, strInputLayer + "_" + strOverLayer + "_" + "SymDiff.shp");
            symDiff.out_feature_class = outputFullPath;
            symDiff.join_attributes = strJoinAttributeType;
            symDiff.cluster_tolerance = tolerance;

            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(symDiff, null);
            return results;
        }


        private void cboSelectInputLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            strInputLayer = cboSelectInputLayer.SelectedItem.ToString();
            IFeatureLayer inputLayer = GetFeatureLayer(strInputLayer);
            if (inputLayer == null) return;
            switch (strOveralyerType)
            {
                case "求交叠置":
                    cboOverlayLayer.Items.Clear();
                    CboAddItems(cboOverlayLayer, inputLayer);
                    break;
                case "求和叠置":
                    cboOverlayLayer.Items.Clear();
                    CboAddItems(cboOverlayLayer, esriGeometryType.esriGeometryPolygon, inputLayer);
                    break;
                case "擦除叠置":
                    cboOverlayLayer.Items.Clear();
                    CboAddItemsForErase(cboOverlayLayer, inputLayer);
                    break;
                case "同一性叠置":
                    cboOverlayLayer.Items.Clear();
                    CboAddItemsForIdentity(cboOverlayLayer, inputLayer);
                    break;
                case "更新叠置":
                    cboOverlayLayer.Items.Clear();
                    CboAddItems(cboOverlayLayer, esriGeometryType.esriGeometryPolygon, inputLayer);
                    break;
                case "异或叠置":
                    cboOverlayLayer.Items.Clear();
                    CboAddItemsForSymDiff(cboOverlayLayer, inputLayer);
                    break;
                default:
                    break;
            }
        }

        private void cboOverlayLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            strOverLayer = cboOverlayLayer.SelectedItem.ToString();
        }

        private string ReturnMessages(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private void txtTolerance_TextChanged(object sender, EventArgs e)
        {
            if (txtTolerance.Text != "")
                tolerance = Convert.ToDouble(txtTolerance.Text);
        }

        private void cboAttributeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string attributeType = cboAttributeType.SelectedItem.ToString();
            switch (attributeType)
            {
                case "所有属性":
                    strJoinAttributeType = "ALL";
                    break;
                case "不包括FID":
                    strJoinAttributeType = "NO_FID";
                    break;
                case "仅包括FID":
                    strJoinAttributeType = "ONLY_FID";
                    break;
                default:
                    break;
            }

        }

        private void cboFeatureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string featureType = cboFeatureType.SelectedItem.ToString();
            switch (featureType)
            {
                case "根据输入要素确定":
                    strOutputFeatureType = "INPUT";
                    break;
                case "线":
                    strOutputFeatureType = "LINE";
                    break;
                case "点":
                    strOutputFeatureType = "POINT";
                    break;
                default:
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strOutputPath = folderBrowserDialog1.SelectedPath;
            }
        }


        private void numUpDownInputLevel_ValueChanged(object sender, EventArgs e)
        {
            inputLevel = numUpDownInputLevel.Value;
        }


        private void numUpDownOverlayLevel_ValueChanged(object sender, EventArgs e)
        {
            overlayLevel = numUpDownOverlayLevel.Value;
        }

        #region "GetFeatureLayer"
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            if (GetLayers() == null) return null;
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }
            return null;
        }

        #endregion

        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        }

    }
}