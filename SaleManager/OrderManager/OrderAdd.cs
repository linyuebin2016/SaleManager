using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SaleManager.OrderManager
{
    public partial class OrderAdd : Form
    {
        private List<Commodity> commodityList;
        private Order order;
        public OrderAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            order.Quantity = commodityList.Count;
            order.Total = commodityList.Sum(i => i.Price);
            OrderDL dl = new OrderDL();
            dl.Add(order);
            OrderDetail f = new OrderDetail();
            f.order = order;
            f.cash = double.Parse(txtCash.Text) - double.Parse(this.labTotal.Text);
            f.ShowDialog();

            this.dataGridView1.DataSource = null;
            this.labTotal.Text = this.txtCash.Text = "0";
        }

        private void OrderAdd_Load(object sender, EventArgs e)
        {
            order = new Order();
            this.labOrderNo.Text = order.OrderNo;
            commodityList = new List<Commodity>();
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CommodityDL dl = new CommodityDL();
                var commodity = dl.GetCommodity(this.txtBarCode.Text.Trim());
                if (commodity != null)
                {
                    commodityList.Add(commodity);
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = commodityList;

                    var orderDetail = new Models.OrderDetail()
                    {
                        CommodityId = commodity.Id
                        //Price=commodity.Price
                    };
                    order.Details.Add(orderDetail);
                }
                this.labTotal.Text = commodityList.Sum(i => i.Price).ToString();
                this.txtBarCode.Text = string.Empty;
            }

        }
    }
}
