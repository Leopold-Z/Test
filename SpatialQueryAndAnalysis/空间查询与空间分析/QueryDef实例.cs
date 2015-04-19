using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class QueryDef实例 : Form
    {
        IFeatureWorkspace featureworkspace;
        IMap pMap;
        IMapControl3 mapControl;

        public QueryDef实例(IHookHelper hook)
        {
            if (hook != null)
            {
                mapControl = (IMapControl3)hook.Hook;
                pMap = mapControl.Map;
                InitializeComponent();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
                IWorkspace  workspace = workspaceFactory.OpenFromFile(path, 0);
                featureworkspace = (IFeatureWorkspace)workspace;              
            }
        }

        //QueryDef对象
        private IQueryDef  CreateQueryDef(IFeatureWorkspace pFeatureWorkspace)
        {
           
            //产生一个QueryDef对象
            IQueryDef pQueryDef = pFeatureWorkspace.CreateQueryDef();
            //基于连接的两个表必须是在一个工作空间内，设置它的各种属性
            pQueryDef.Tables = "Counties,Cities";
            pQueryDef.SubFields = "*";
            pQueryDef.WhereClause = "Counties.STATE_FIPS =Cities.STFIPS";
            
            return pQueryDef;
        }

        //新建一个要素类
        private void CreateFeatureclass(IQueryDef pQueryDef,IFeatureWorkspace pFeatureWorkspace)
        {
            IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureQuery("My counties join ", pQueryDef);
            IFeatureClassContainer pFeatureClassContainer = pFeatureDataset as IFeatureClassContainer;
            //判断IFeatureClassContainer中是否有要素类存在
            if (pFeatureClassContainer.ClassCount != 1)
            {
                MessageBox.Show("Failed to create feature class by query！");
                return;
            }
            IFeatureClass pFeatureClass = pFeatureClassContainer.get_Class(0);
            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.FeatureClass = pFeatureClass;
            pFeatureLayer.Name = pFeatureClass.AliasName;
            pMap.AddLayer(pFeatureLayer); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IQueryDef queryDef = CreateQueryDef(featureworkspace );
            CreateFeatureclass(queryDef, featureworkspace);
        }
        
    }
}
