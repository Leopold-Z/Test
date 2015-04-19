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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class TableSort实例 : Form
    {
        IMapControl3 m_mapcontrol;
        IMap m_map;
       
        string layername;
        IFeatureLayer featurelayer;

        public TableSort实例(IHookHelper hook)
        {
            if (hook != null)
            {
                m_mapcontrol = (IMapControl3)hook.Hook;
                m_map = m_mapcontrol.Map;
                InitializeComponent();
            }
        }

        private void TableSort实例_Load(object sender, EventArgs e)
        {
            CbxLayersAddItems();
            if (featurelayer == null) return;
            CbxFieldAdditems(featurelayer);
            getFeatureCount(layername);
        }

        private void CbxLayersAddItems()
        {
            if (GetLayers() == null) return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = layers.Next();
            cbxLayers.Items.Clear();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    cbxLayers.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
            cbxLayers.SelectedIndex = 0;
        }

        private void CbxFieldAdditems(IFeatureLayer featureLayer)
        {
            IFields fields = featureLayer.FeatureClass.Fields;
            cbxFirstField.Items.Clear();
            cbxSecField.Items.Clear();
            cbxThirdField.Items.Clear();
            for (int i = 0; i < fields.FieldCount; i++)
            {
                cbxFirstField.Items.Add(fields.get_Field(i).Name);
                cbxSecField.Items.Add(fields.get_Field(i).Name);
                cbxThirdField.Items.Add(fields.get_Field(i).Name);
            }
            cbxFirstField.SelectedIndex = 0;
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

        private void  getFeatureCount(string layername)
        {
            int count=0;
            IFeatureLayer featurelayer = GetFeatureLayer(layername);
            if (featurelayer == null) return ;
            count = featurelayer.FeatureClass.FeatureCount(null);
            comboBox1.Items.Clear();
            for (int i = 1; i <= count; i++) comboBox1.Items.Add(i.ToString());           
        }

        private void cbxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            layername = cbxLayers.Text;
            featurelayer = GetFeatureLayer(layername);
            CbxFieldAdditems(featurelayer);
            getFeatureCount(layername);
        }

        private void FeatureSort()
        {
            IFeatureSelection featureSel = featurelayer as IFeatureSelection;
            featureSel.SelectFeatures(null, esriSelectionResultEnum.esriSelectionResultNew, false);
            ISelectionSet selectionSet = featureSel.SelectionSet;

            //新建TableSort对象
            ITableSort pTableSort = new TableSortClass();

            //进行排序的字段,排序方法，
            //只选一个字段排序
            if (cbxSecField.Text == "" && cbxThirdField.Text == "")
            {
                pTableSort.Fields = cbxFirstField.Text;
                if (checkBox1.Checked == true) pTableSort.set_Ascending(cbxFirstField.Text, true);
            }
            //根据三个字段排序
            if (cbxFirstField.Text != "" && cbxThirdField.Text != "")
            {
                pTableSort.Fields = cbxThirdField.Text + "," + cbxSecField.Text + "," + cbxThirdField.Text;
                if (checkBox1.Checked == true) pTableSort.set_Ascending(cbxFirstField.Text, true);
                else pTableSort.set_Ascending(cbxFirstField.Text, false);
                if (checkBox2.Checked == true) pTableSort.set_Ascending(cbxSecField.Text, true);
                else pTableSort.set_Ascending(cbxSecField.Text, false);
                if (checkBox3.Checked == true) pTableSort.set_Ascending(cbxSecField.Text, true);
                else pTableSort.set_Ascending(cbxThirdField.Text, false);
            }
            //根据两个字段排序
            if (cbxSecField.Text != "" && cbxThirdField.Text == "")
            {
                pTableSort.Fields = cbxFirstField.Text + "," + cbxSecField.Text;
                if (checkBox1.Checked == true) pTableSort.set_Ascending(cbxFirstField.Text, true);
                else pTableSort.set_Ascending(cbxFirstField.Text, false);
                if (checkBox2.Checked == true) pTableSort.set_Ascending(cbxSecField.Text, true);
                else pTableSort.set_Ascending(cbxSecField.Text, false);
            }

            //设置排序的数据源
            pTableSort.SelectionSet = selectionSet;
            pTableSort.Sort(null);
            IFeatureCursor featureCursor;
            featureCursor = pTableSort.Rows as IFeatureCursor;
            IFeature feature;
            feature = featureCursor.NextFeature();
            //选取要素
            m_map.ClearSelection();
            int i = Convert.ToInt32(comboBox1.Text);
            int j = 0;
            while (feature != null)
            {
                j++;
                if (j <= i)
                {
                    m_map.SelectFeature(featurelayer as ILayer, feature);
                    feature = featureCursor.NextFeature();
                }
                else break;
            }
            m_mapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            FeatureSort();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
    }
}
