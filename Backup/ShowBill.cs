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
    public partial class ShowBill : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        public string bn;
        
         
        public ShowBill()
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
        }

        private void ShowBill_Load(object sender, EventArgs e)
        {
            Showbill();
            ShowCustomer();
        }

        private void Showbill()
        {
            OleDbDataAdapter ad4 = new OleDbDataAdapter("Select billno as Bill_No, max(bdate) as Bill_Date, max(cname) as Customer_Name, max(caddress) as Address, max(ccity) as City, max(ccontact) as Contact, max(CTINTYPE) AS Tin_Type, max(ctinno) as Tin_No, max(grno) as Gr_No, max(transport) as Transport, max(Discount) as Discount, max(Vat) as CST, max(Vatamount) as CST_Amount, max(GrandTotal) as Grand_Total from bill where billtype=@billtype group by billno order by billno", con);
            ad4.SelectCommand.Parameters.Add("@billtype", OleDbType.VarChar).Value = "final";
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            dataGridView1.DataSource = ds4.Tables[0];
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[5].Width = 75;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[7].Width = 75;
            dataGridView1.Columns[8].Width = 55;
            dataGridView1.Columns[9].Width = 95;
            dataGridView1.Columns[10].Width = 65;
            dataGridView1.Columns[11].Width = 55;
            dataGridView1.Columns[12].Width = 55;
            //dataGridView1.Columns[13].Width = 75;
        }


        private void ShowCustomer()
        {
           
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from Customer", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = ds1.Tables[0].Columns["cname"].ToString();
            comboBox1.ValueMember = ds1.Tables[0].Columns["cid"].ToString();
            comboBox1.SelectedValue = 9;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form cfbillproduct = new BillProducts(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            bn = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            cfbillproduct.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                OleDbCommand cmddelete = new OleDbCommand("delete from bill where billno=@billno", con);
                cmddelete.Parameters.Add("@Billno", OleDbType.Integer).Value =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmddelete.ExecuteNonQuery();
                cmddelete.Parameters.Clear();
                cmddelete.Dispose();
                con.Close();
                MessageBox.Show("Data Deleted Successfully");
                Showbill();
            }
            else
            {
                MessageBox.Show("Please Select Any Row");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 1)
            {
                OleDbCommand cmdBillClear = new OleDbCommand("update bill set billprint='N'", con);
                cmdBillClear.Parameters.Add("@billno", OleDbType.VarChar, 100).Value = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdBillClear.ExecuteNonQuery();

                cmdBillClear.Parameters.Clear();
                cmdBillClear.Dispose();

                
                OleDbCommand cmdBillYes = new OleDbCommand("update bill set billprint='Y' WHERE billno=@billno", con);
                cmdBillYes.Parameters.Add("@billno", OleDbType.Integer).Value =Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdBillYes.ExecuteNonQuery();

                cmdBillYes.Parameters.Clear();
                cmdBillYes.Dispose();
                con.Close();
                Form cffrmReports = new frmReports();
                cffrmReports.Show();
            }
            else {
                MessageBox.Show("Select Any Record");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter ad4 = new OleDbDataAdapter("Select billno as Bill_No, max(bdate) as Bill_Date, max(cname) as Customer_Name, max(caddress) as Address, max(ccity) as City, max(ccontact) as Contact, max(CTINTYPE) AS Tin_Type, max(ctinno) as Tin_No, max(grno) as Gr_No, max(transport) as Transport, max(Discount) as Discount, max(Vat) as CST, max(Vatamount) as CST_Amount, max(GrandTotal) as Grand_Total from bill where billtype=@billtype and cname=@cname group by billno order by billno", con);
                ad4.SelectCommand.Parameters.Add("@billtype", OleDbType.VarChar).Value = "final";
                ad4.SelectCommand.Parameters.Add("@cname", OleDbType.VarChar).Value = comboBox1.Text;
                DataSet ds4 = new DataSet();
                ad4.Fill(ds4);
                dataGridView1.DataSource = ds4.Tables[0];
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 75;
                dataGridView1.Columns[6].Width = 75;
                dataGridView1.Columns[7].Width = 75;
                dataGridView1.Columns[8].Width = 55;
                dataGridView1.Columns[9].Width = 95;
                dataGridView1.Columns[10].Width = 65;
                dataGridView1.Columns[11].Width = 55;
                dataGridView1.Columns[12].Width = 55;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter ad4 = new OleDbDataAdapter("Select billno as Bill_No, max(bdate) as Bill_Date, max(cname) as Customer_Name, max(caddress) as Address, max(ccity) as City, max(ccontact) as Contact, max(CTINTYPE) AS Tin_Type, max(ctinno) as Tin_No, max(grno) as Gr_No, max(transport) as Transport, max(Discount) as Discount, max(Vat) as CST, max(Vatamount) as CST_Amount, max(GrandTotal) as Grand_Total from bill where billtype=@billtype and bdate=@bdate group by billno order by billno", con);
                ad4.SelectCommand.Parameters.Add("@billtype", OleDbType.VarChar).Value = "final";
                ad4.SelectCommand.Parameters.Add("@bdate", OleDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString();
                DataSet ds4 = new DataSet();
                ad4.Fill(ds4);
                dataGridView1.DataSource = ds4.Tables[0];
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 75;
                dataGridView1.Columns[6].Width = 75;
                dataGridView1.Columns[7].Width = 75;
                dataGridView1.Columns[8].Width = 55;
                dataGridView1.Columns[9].Width = 95;
                dataGridView1.Columns[10].Width = 65;
                dataGridView1.Columns[11].Width = 55;
                dataGridView1.Columns[12].Width = 55;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
