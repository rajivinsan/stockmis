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
    public partial class BillProducts : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        string billno;

        public BillProducts(string ctr)
        {
            ShowBill sb = new ShowBill();
            billno = sb.bn;
           
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
            billno = ctr;
            //MessageBox.Show(billno);
        }

        private void BillProducts_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(billno);
            OleDbDataAdapter ad4 = new OleDbDataAdapter("Select billno as Bill_No,bdate as Bill_Date,pname as Products,PSIZE AS P_SIZE,PCOLOR AS P_COLOR,QPC AS Q_P_CASE,PCASE AS P_CASE,pqty as T_QTY, pqtype as Unit,prate as Rate,pamount as Amount,bid from bill where billno=@billno and pamount>0 order by bid", con);

            ad4.SelectCommand.Parameters.Add("@billno", OleDbType.VarChar).Value = billno;
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            dataGridView1.DataSource = ds4.Tables[0];
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[5].Width = 65;
            dataGridView1.Columns[6].Width = 65;
            //dataGridView1.Columns[7].Width = 75;
            //dataGridView1.Columns[8].Width = 75;
            //dataGridView1.Columns[9].Width = 35;
            //dataGridView1.Columns[10].Width = 75;
            //dataGridView1.Columns[11].Width = 75;
            //dataGridView1.Columns[12].Width = 75;
        }

        private void BillProducts_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
