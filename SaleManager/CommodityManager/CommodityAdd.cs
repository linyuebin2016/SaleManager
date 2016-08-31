using DataLayer;
using Models;
using Models.SaleEnum;
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
    public partial class CommodityAdd : Form
    {
        public Guid Id { get; set; }
        public CommodityAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CommodityDL dl = new CommodityDL();
            if (Id == null || Id == Guid.Empty)
            {
                Commodity model = new Commodity();
                model.Code = txtCode.Text;
                model.Name = txtName.Text;
                model.Price = double.Parse(txtPrice.Text);
                dl.Add(model);
            }
            else
            {
                var model = dl.GetCommodityById(Id);

                model.Code = txtCode.Text;
                model.Name = txtName.Text;
                model.Price = double.Parse(txtPrice.Text);
                dl.Update(model);
            }

            this.Close();
        }

        private void CommodityAdd_Load(object sender, EventArgs e)
        {
            if (Id != null && Id != Guid.Empty)
            {
                CommodityDL dl = new CommodityDL();
                var model = dl.GetCommodityById(Id);

                txtCode.Text = model.Code;
                txtName.Text = model.Name;
                txtPrice.Text = model.Price.ToString();
            }

        }
    }
}
