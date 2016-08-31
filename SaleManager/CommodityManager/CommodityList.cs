using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManager
{
    public partial class CommodityList : Form
    {
        public CommodityList()
        {
            InitializeComponent();
        }

        private void CommodityList_Load(object sender, EventArgs e)
        {
            var dl = new CommodityDL();
            dataGridView1.DataSource = dl.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CommodityAdd f = new CommodityAdd();
            f.ShowDialog();
            var dl = new CommodityDL();
            dataGridView1.DataSource = dl.ToList();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = this.dataGridView1.CurrentRow.Cells["Id"].Value;
            CommodityAdd f = new CommodityAdd();
            f.Id = (Guid)id;
            f.ShowDialog();
            var dl = new CommodityDL();
            dataGridView1.DataSource = dl.ToList();
        }
    }
}
