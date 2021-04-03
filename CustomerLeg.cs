using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GST
{

    public partial class CustomerLeg : Form
    {
        
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;

        public CustomerLeg()
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                bdParty();
                drpParty.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bdParty()
        {

            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select cid,cname from customer", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpParty.DisplayMember = "cname";
            drpParty.ValueMember = "cid";
            drpParty.DataSource = ds1.Tables[0];
            ds1.Dispose();

        }


        private void ShowStock()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT Stock.PID, Stock.PDATE as [Date], Stock.HSNCode, Item_Mas.Item_Name as [Item Name], Stock.QUANTITY as [Qty], Stock.Sale_Rate as [Sale Rate], Stock.Taxrate as [Tax Slab], Purchase_Party.PName FROM(Stock INNER JOIN Item_Mas ON Stock.item_code = Item_Mas.Item_code) INNER JOIN Purchase_Party ON Stock.PURCHASE_From = Purchase_Party.PID where where stock.date>=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and stock.pdate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "#", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 200;
            ds1.Dispose();
            ad1.Dispose();


        }
        
       
        
        
        private void count()
        {
           
            

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (drpParty.Text.Trim() == "")
            {
                MessageBox.Show("Select Customer", "Please Select Customer",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            


            else if (drpParty.Text.Trim() != "")
            {

                String qry = "";
                String qry1 = "";
                //if (comboBox1.Text.ToUpper() == "BILL")
                {
                    if (checkBox1.Checked == false)
                    { qry = "SELECT BILL.BILLNO as [Bill No], BILL.BDATE as [Date], customer.CNAME as [Customer], BILL.Gtotal as [Total Amount] FROM BILL INNER JOIN customer ON BILL.CID = customer.CID  where bill.cid=" + drpParty.SelectedValue + " and bill.bdate >=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and bill.bdate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "# GROUP BY BILL.BILLNO, BILL.BDATE, customer.CNAME, BILL.Gtotal, BILL.paid, (bill.balance) order by bill.billno"; }
                    else { qry = "SELECT BILL.BILLNO as [Bill No], BILL.BDATE as [Date], customer.CNAME as [Customer], BILL.Gtotal as [Total Amount] FROM BILL INNER JOIN customer ON BILL.CID = customer.CID  where bill.cid=" + drpParty.SelectedValue + " GROUP BY BILL.BILLNO, BILL.BDATE, customer.CNAME, BILL.Gtotal, BILL.paid, (bill.balance) order by bill.billno"; }
                }
                //else
                
                {
                    
                    if (checkBox1.Checked == false)
                    { qry1 = "SELECT payments.Billno, payments.TRNDATE, customer.CNAME, payments.Paid, payments.Remarks FROM payments INNER JOIN customer ON payments.CID = customer.CID  where payments.cid=" + drpParty.SelectedValue + " and payments.trndate >=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and payments.trndate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "# order by payments.billno"; }
                    else { qry1 = "SELECT payments.Billno, payments.TRNDATE, customer.CNAME as [Customer], payments.Paid  as [Amount Paid], payments.Remarks FROM payments INNER JOIN customer ON payments.CID = customer.CID   where payments.cid=" + drpParty.SelectedValue + "  order by payments.billno"; }
                }

                OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adp.Dispose();


                OleDbDataAdapter adp1 = new OleDbDataAdapter(qry1, con);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0];
                ds1.Dispose();
                adp1.Dispose();



            }


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double pamount, samount, tamount;
            pamount = samount = tamount = 0;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
               
                    pamount = pamount + Convert.ToDouble("0" + dr.Cells["Total Amount"].Value);
                  
               
                

                txttotal.Text = pamount.ToString();
            }
           
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double pamount, samount, tamount;
            pamount = samount = tamount = 0;


            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {

                pamount = pamount + Convert.ToDouble("0" + dr.Cells["Amount Paid"].Value);




                txtpaidtotal.Text = pamount.ToString();
            }

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void drpParty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalBalance();
        }
        private void CalBalance()
        {

            try
            {
                double totamount, balance, payed;
                balance = payed = totamount = 0;

                OleDbCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandText = "select sum(Gtotal) from bill where cid = @cid";
                cmd.Parameters.Add("@cid", OleDbType.VarChar, 50).Value = drpParty.SelectedValue;
                totamount = Convert.ToDouble("0" + cmd.ExecuteScalar());



                cmd.CommandText = "select sum(paid) from payments where cid = @cid";
                cmd.Parameters.Add("@cid", OleDbType.VarChar, 50).Value = drpParty.SelectedValue;
                payed = Convert.ToDouble("0" + cmd.ExecuteScalar());
                txtbalance.Text = (totamount - payed).ToString();

                txtPurAmount.Text = totamount.ToString();
                txtpaid.Text = payed.ToString();
                cmd.Dispose();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Enabled = false;
            }
            else { groupBox1.Enabled = true; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 

        


}