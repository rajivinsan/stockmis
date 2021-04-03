using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GST
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbsonDataSet.BILL' table. You can move, or remove it, as needed.
            this.BILLTableAdapter.Fill(this.dbsonDataSet.BILL);
            // TODO: This line of code loads data into the 'dbsonDataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dbsonDataSet.customer);
            // TODO: This line of code loads data into the 'dbsonDataSet1.Stock' table. You can move, or remove it, as needed.
            this.StockTableAdapter.Fill(this.dbsonDataSet1.Stock);

            this.reportViewer1.RefreshReport();
        }
    }
}
