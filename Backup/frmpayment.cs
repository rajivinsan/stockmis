using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ImperialPlastics
{
    public partial class frmpayment : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        public frmpayment()
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
        }

        private void Update_Click(object sender, EventArgs e)
        {


        }

        private void frmpayment_Load(object sender, EventArgs e)
        {
            showdata();


        }

        private void showdata()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter(" SELECT Max(BILL.billno) AS BILLNO, Max(BILL.cname) AS CUSTOMER, (Sum(BILL.pamount)-Max(BILL.discount)) +(Sum(BILL.pamount)-Max(BILL.discount))*Max(BILL.vat)/100 AS BILLAMOUNT,  max(ramount) as RECEIPTAMOUNT, (BILLAMOUNT-RECEIPTAMOUNT) as BALANCE FROM BILL GROUP BY BILL.cname ", con);
            // ad1.SelectCommand.Parameters.Add("@ctype", OleDbType.VarChar, 100).Value = cmbtype.Text;
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form cfbillproduct = new frmPaymentdetail(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
           //bn = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
         
            cfbillproduct.Show();
        }

    }
}
