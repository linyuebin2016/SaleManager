
using DataLayer;
using System;
using System.Windows.Forms;

namespace SaleManager.CustomerManager
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            CustomerDL dl = new CustomerDL();
           
            this.dataGridView1.DataSource = dl.GetList();
        }
    }
}
