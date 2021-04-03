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
    public partial class frmPaymentdetail : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        String BILLno = "0";
        public frmPaymentdetail()
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }
        public frmPaymentdetail(String BNO)
        {
            BILLno = BNO;
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPaymentdetail_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("  SELECT  billno,bid, cname, (pamount-discount) +(pamount-discount)*(vat)/100 AS BILLAMOUNT,  ramount, (BILLAMOUNT-ramount) as BALANCE FROM BILL where billno=@billno and pamount>0 order by bid  ", con);
            ad1.SelectCommand.Parameters.Add("@billno", OleDbType.Integer).Value = BILLno;
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
           
           
        }
    }
}
