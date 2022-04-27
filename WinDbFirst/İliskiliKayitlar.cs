using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDbFirst
{
    public partial class İliskiliKayitlar : Form
    {
        NorthwindEntities db =new NorthwindEntities();
        public İliskiliKayitlar()
        {
            InitializeComponent();
        }

        private void İliskiliKayitlar_Load(object sender, EventArgs e)
        {
            dataGridView4.DataSource=db.Customers.ToList();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex=e.RowIndex;
            DataGridViewRow row=dataGridView4.Rows[rowIndex];
            string customerId=row.Cells[0].Value.ToString();

            var orderResult = db.Orders.Where(x => x.CustomerID == customerId);
            dataGridView5.DataSource=orderResult.ToList();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView5.Rows[rowIndex];
            string orderId = row.Cells[0].Value.ToString();

            var orderResult = db.Order_Details.Where(p => p.OrderID.ToString() == orderId);
            dataGridView6.DataSource = orderResult.ToList();
        }
    }
}
