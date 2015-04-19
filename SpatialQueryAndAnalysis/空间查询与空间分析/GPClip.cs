using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataSourcesFile;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class GPClip : Form
    {
        IApplication m_application = null;
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;
        IMapControl3 m_mapControl = null;
        IEditor m_editor = null;

        string strGeometryType = "多边形";

        IFeatureLayer tempFeatureLayer = null;
        static string tempFeatureClassName = "TempFeatureClass";
        IFeatureClass clipFeatureClass = null;//存储用于裁剪的临时要素类    
        double tolerance = 0.1;
        string strOutputPath = System.IO.Path.GetTempPath();


        public GPClip(IHookHelper hookHelper)
        {
            InitializeComponent();
            if (hookHelper == null) return;

            m_hookHelper = hookHelper;
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;

            if (m_hookHelper.Hook is IApplication)
            {
                m_application = m_hookHelper.Hook as IApplication;
                UID uID = new UID();
                uID.Value = "esriEditor.Editor";
                if (m_application == null)
                    return;
                m_editor = m_application.FindExtensionByCLSID(uID) as IEditor;
            }

            if (m_hookHelper.Hook is IToolbarControl)
            {
                IToolbarControl toolbarControl = m_hookHelper.Hook as IToolbarControl;
                m_mapControl = (IMapControl3)toolbarControl.Buddy;
            }
            if (m_hookHelper.Hook is IMapControl3)
            {
                m_mapControl = m_hookHelper.Hook as IMapControl3;
            }
        }

        private void GPClip_Load(object sender, EventArgs e)
        {
            if (m_hookHelper == null || null == m_hookHelper.Hook || 0 == m_hookHelper.FocusMap.LayerCount)
                return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                chklstLayers.Items.Add(layer.Name, true);
            }

            DeleteTempFeatureClass();
            clipFeatureClass = CreateFeatureClass(tempFeatureClassName, esriGeometryType.esriGeometryPolygon, m_hookHelper.FocusMap.SpatialReference);
            AddTempLayer();
        }

        private void AddTempLayer()
        {
            tempFeatureLayer = new FeatureLayerClass();
            tempFeatureLayer.FeatureClass = clipFeatureClass;
            tempFeatureLayer.Name = clipFeatureClass.AliasName;
            ILayerEffects layerEffects = tempFeatureLayer as ILayerEffects;
            layerEffects.Transparency = 65;
            m_map.AddLayer(tempFeatureLayer);
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
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


        #region "SetCurrentSketchTool"
        private void SetCurrentSketchTool()
        {
            if (m_application != null)
            {
                ICommandBars documentBars = m_application.Document.CommandBars;
                UID cmdID = new UIDClass();
                switch (strGeometryType)
                {
                    case "点":
                    case "线":
                    case "多边形":
                        cmdID.Value = "{B479F48A-199D-11D1-9646-0000F8037368}";//sketch tool
                        break;
                    case "矩形":
                        cmdID.Value = "{6F0ED2CC-C099-4895-BD7E-BEEC2F78ADBF}"; //esriEditor.RectangleTool
                        break;
                    case "圆":
                        cmdID.Value = "{09C6F589-A3CE-48AB-81BC-46965C58F264}";//esriEditor.CircleTool
                        break;
                    default:
                        break;
                }
                ICommandItem cmdItem = documentBars.Find(cmdID, false, false);
                m_application.CurrentTool = cmdItem;
            }
            if (m_mapControl != null)
            {
                ICommand tool = null;
                switch (strGeometryType)
                {
                    case "点":
                        tool = new 空间查询与空间分析.createPointTool(tempFeatureLayer);  //CreatePointTool
                        break;
                    case "线":
                        tool = new 空间查询与空间分析.CreatePolylineTool(tempFeatureLayer);  //CreatePolylineTool
                        break;
                    case "多边形":
                        tool = new 空间查询与空间分析.CreatePolygonTool(tempFeatureLayer);  //CreatePolygonTool
                        break;
                    case "矩形":
                        tool = new 空间查询与空间分析.CreateRectangleTool(tempFeatureLayer);  //CreateRectangleTool
                        break;
                    case "圆":
                        tool = new 空间查询与空间分析.CreateCircleTool(tempFeatureLayer); //CreateCircleTool
                        break;
                    default:
                        break;
                }
                if (tool == null) return;
                tool.OnCreate(m_mapControl);
                m_mapControl.CurrentTool = tool as ITool;
                m_mapControl.MousePointer = esriControlsMousePointer.esriPointerHand;
            }
        }
        #endregion

        #region "DeleteTempFeatureClass"
        private bool DeleteTempFeatureClass()
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IWorkspace workspace = workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
                IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(tempFeatureClassName);
                IDataset dataSet = featureClass as IDataset;
                if (dataSet.CanDelete())
                {
                    dataSet.Delete();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region "Create FeatureClass"
        public IFeatureClass CreateFeatureClass(string featureClassName, esriGeometryType geometryType, ISpatialReference spatialReference)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = (IFieldsEdit)fields;
            fieldsEdit.FieldCount_2 = 2;
            //Create the Object ID field.
            IField fieldUserDefined = new Field();
            IFieldEdit fieldEdit = (IFieldEdit)fieldUserDefined;
            fieldEdit.Name_2 = "FID";
            fieldEdit.AliasName_2 = "OBJECT ID";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.set_Field(0, fieldUserDefined);
            // Create the Shape field.
            fieldUserDefined = new Field();
            fieldEdit = (IFieldEdit)fieldUserDefined;
            // Set up the geometry definition for the Shape field.
            IGeometryDef geometryDef = new GeometryDefClass();
            IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
            switch (geometryType)
            {
                case esriGeometryType.esriGeometryPoint:
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                    break;
                default:
                    break;
            }
            geometryDefEdit.GridCount_2 = 1;
            geometryDefEdit.set_GridSize(0, 0);
            geometryDefEdit.HasM_2 = false;
            geometryDefEdit.HasZ_2 = false;
            if (spatialReference != null)
            {
                geometryDefEdit.SpatialReference_2 = spatialReference;
            }
            // Set standard field properties.
            fieldEdit.Name_2 = "SHAPE";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geometryDef;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.Required_2 = true;
            fieldsEdit.set_Field(1, fieldUserDefined);

            UID CLSID = new UIDClass();
            CLSID.Value = "esriGeoDatabase.Feature";

            return featureWorkspace.CreateFeatureClass(featureClassName, fields, CLSID, null, esriFeatureType.esriFTSimple, fields.get_Field(1).Name, "");
        }
        #endregion

        #region "AddTempFeatureLayer"

        private IFeatureLayer AddTempFeatureLayer()
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetTempPath(), 0);
                IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(tempFeatureClassName);
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.FeatureClass = featureClass;
                featureLayer.Name = featureClass.AliasName;
                featureLayer.Visible = true;
                ILayerEffects layerEffects = featureLayer as ILayerEffects;
                layerEffects.Transparency = 60;
                IActiveView activeView = m_hookHelper.ActiveView;
                activeView.FocusMap.AddLayer(featureLayer);
                activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                txtMessages.Text += "已创建临时层:Temp_Layer\r\n";
                return featureLayer;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region "RemoveTempLayer"

        private void RemoveTempLayer()
        {
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i) == tempFeatureLayer)
                {
                    m_map.DelayEvents(true);
                    m_map.DeleteLayer(m_map.get_Layer(i));
                    break;
                }
            }
        }
        #endregion


        #region "IsExistTempLayer"

        private IFeatureLayer IsExistTempLayer()
        {
            ILayer layer = null;
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                if (m_map.get_Layer(i) == tempFeatureLayer)
                {
                    layer = m_map.get_Layer(i);
                }
            }
            return layer as IFeatureLayer;
        }
        #endregion


        #region "StartEditTempLayer"

        private void StartEditTempLayer(ILayer templayer)
        {
            if (templayer == null) return;
            if (m_application != null)
            {
                if (m_editor == null) return;
                if (m_editor.EditState == esriEditState.esriStateEditing)
                    return;
                try
                {
                    IDataset dataset = templayer as IDataset;
                    IWorkspace workSpace = dataset.Workspace;
                    m_editor.StartEditing(workSpace);
                }
                catch
                {
                }
            }
            //if (mapControl != null)
            //{
            //    ControlsEditingStartCommand startEdit = new ControlsEditingStartCommandClass();
            //    startEdit.OnCreate(m_hookHelper.Hook);
            //    startEdit.OnClick();
            //}
        }
        #endregion

        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            StopEditTempLayer(IsExistTempLayer(), true);
            foreach (object itemChecked in chklstLayers.CheckedItems)
            {
                ClipOneLayer(itemChecked.ToString());
            }
        }

        private void ClipOneLayer(String obj)
        {
            ScrollToBottom(txtMessages);

            txtMessages.Text += "裁剪的层: " + obj + "\r\n";
            txtMessages.Text += "\r\n开始裁剪. 这可能要花几分钟时间...\r\n";
            txtMessages.Update();

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            txtMessages.Text += "裁剪...\r\n";
            txtMessages.Update();
            try
            {
                ESRI.ArcGIS.AnalysisTools.Clip clip = new ESRI.ArcGIS.AnalysisTools.Clip();
                if (GetFeatureLayer(obj) != null)
                {
                    clip.in_features = GetFeatureLayer(obj);
                    clip.out_feature_class = txtOutputPath.Text + "\\" + "clip_" + obj;
                }
                else
                {
                    return;
                }
                clip.clip_features = clipFeatureClass;
                clip.cluster_tolerance = tolerance;
                IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(clip, null);
                if (results != null)
                {
                    if (results.Status != esriJobStatus.esriJobSucceeded)
                    {
                        txtMessages.Text += "裁剪要素/层失败: " + obj + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("裁剪要素问题： " + ex.Message);
            }
            txtMessages.Text += ReturnMessages(gp);
            //scroll the textbox to the bottom
            ScrollToBottom(txtMessages);

            txtMessages.Text += "\r\n完成.\r\n";
            txtMessages.Text += "-------------------------------------------------------\r\n";
            //scroll the textbox to the bottom
            ScrollToBottom(txtMessages);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
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

        #region "StopEditTempLayer"

        private void StopEditTempLayer(IFeatureLayer templayer, bool save)
        {
            if (templayer == null) return;
            if (m_application != null)
            {
                IDataset dataset = templayer as IDataset;
                IWorkspace workSpace = dataset.Workspace;
                if (m_editor.EditState == esriEditState.esriStateEditing)
                {
                    m_editor.StopEditing(save);
                }
            }
        }
        #endregion

        private void GPClip_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveTempLayer();
        }

        private void txtTolerance_Leave(object sender, EventArgs e)
        {
            if (IsDouble(txtTolerance.Text))
                tolerance = Convert.ToDouble(txtTolerance.Text);
        }

        private bool IsDouble(string s)
        {
            try
            {
                Double.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void cbxClipGeometryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClipGeometryType.SelectedItem == null) return;
            strGeometryType = cbxClipGeometryType.SelectedItem.ToString();
            if (clipFeatureClass == null) return;
            StartEditTempLayer(IsExistTempLayer());//启动临时要素编辑  
            SetCurrentSketchTool();        
        }

        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strOutputPath = folderBrowserDialog1.SelectedPath;
                txtOutputPath.Text = strOutputPath;
            }
        }
    }
}
