using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpatialQueryAndAnalysis.空间查询与空间分析
{
    public partial class ReportOptionDialog : Form
    {
        public ReportOptionDialog(List<string> availableFields)
        {
            InitializeComponent();
            foreach (string field in availableFields)
                fieldsListBox.Items.Add(field);
            for (int i = 0; i < fieldsListBox.Items.Count; i++)
                fieldsListBox.SetItemChecked(i, true);
        }
        public List<string> GetSelectedFields()
        {
            List<string> fields = new List<string>();
            for (int i = 0; i < fieldsListBox.CheckedItems.Count; i++)
            {
                fields.Add(fieldsListBox.CheckedItems[i].ToString());
            }
            return fields;
        }
        private void ReportOptionDialog_Load(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (fieldsListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("At least one field must be selected");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
