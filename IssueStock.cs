using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Text.RegularExpressions;



namespace GST
{
    public partial class IssueStock : Form
    {
        String companyid = "";
        
        int cnt = 0;
        //SqlConnection sqlcon = new SqlConnection();
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        OleDbConnection con1 = new OleDbConnection();
       

        public IssueStock()
        {
            con.ConnectionString = cn.connectionstring;
            con1.ConnectionString = cn.connectionstring;
          
             String companyid = "";

            //sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            InitializeComponent();

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {




             if (drpOffice.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Select Office/Branch");
                return;
                //txtcname.BackColor = System.Drawing.Color.OrangeRed;

            }
            //else if (comboBox1.Text.Trim() == "Booking" && txtbookid.Text.Trim().Length <= 0)
            //{
            //    MessageBox.Show("Enter Booking ");
            //    txtbookid.BackColor = System.Drawing.Color.OrangeRed;

            //}




            else
            {



                String qry;


                //"update bill set billtype=@billtype,bdate=@badate,cid=@cid,cname=@cname,cmob=@cmob,qty=@qty,total=@total,tax=@tax,discount=@discount,GTotal=@gtotal,paid=@paid,balance=@balance where bid=@bid";
                //"update bill set totalamount=" + txtTotalAmount.Text + ",tax=" + txtTax.Text + ",discount=" + txtDiscount.Text + ",GTotal=" + txtGrandTotal.Text + ",paid=" + txtPaid.Text + ",balance=" + txtBalance.Text + " ,INWORDS='' where billno=" +  txtbid.Text + "";
                qry = "insert into StockHistory(dated,cid,issuedto,pid) values(@dated,@cid,@issuedto,@pid)";

                OleDbTransaction trns1 = null;
                OleDbTransaction trns = null;
                try
                {




                    OleDbCommand cmdsave = new OleDbCommand(qry, con);
                    cmdsave.Parameters.Add("@dated", OleDbType.Date).Value = dateTimePicker1.Text;
                    cmdsave.Parameters.Add("@cid", OleDbType.Numeric).Value = drpCategory.SelectedValue;
                    cmdsave.Parameters.Add("@issuedto", OleDbType.Numeric).Value = drpOffice.SelectedValue;
                    cmdsave.Parameters.Add("@pid", OleDbType.Numeric).Value = lblpid.Text;


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    // Start a local transaction with ReadCommitted isolation level.
                    trns = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmdsave.Transaction = trns;
                    cmdsave.ExecuteNonQuery();
                    //cmdsave.Parameters.Clear();
                    cmdsave.Dispose();
                    //con.Close();
                    //ShowBillItems();


                    //Update Online Orders
                    //OleDbCommand cmdupdate = new OleDbCommand("Update online_orders set Flag='Y' where item_code='" + txtItem_code.Text + "'", con);
                    //if (con.State == ConnectionState.Closed) { con.Open(); }
                    //cmdupdate.ExecuteNonQuery();

                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();
                    }
                    OleDbCommand cmdTrns = con1.CreateCommand();
                    trns1 = con1.BeginTransaction(IsolationLevel.ReadCommitted);
                    cmdTrns.Transaction = trns1;
                    cmdTrns.Connection = con1;
                    cmdTrns.CommandText = "Update stock set issuedto=@issuedto where id=@id";
                    cmdTrns.Parameters.Add("@issuedto", OleDbType.Numeric).Value = drpOffice.SelectedValue;
                    cmdTrns.Parameters.Add("@pid", OleDbType.Numeric, 100).Value = lblpid.Text;

                    cmdTrns.ExecuteNonQuery();


                    trns.Commit();
                    trns1.Commit();

                    cmdTrns.Dispose();
                    cmdTrns.Parameters.Clear();





                    con.Close();
                    con1.Close();

                    drpOffice.SelectedIndex = -1;
                    drpCategory.SelectedIndex = -1;
                    lblpid.Text = "";
                    listBox1.Items.Clear();

                    MessageBox.Show("Item Issued for Branch/Office", "Bill Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);







                }

                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message, "Error in Transcation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trns.Rollback();
                    trns1.Rollback();



                }
            }
        

        }

      
       

       
     

        private void Bill_Load(object sender, EventArgs e)
        {

            //if (checkNet() == 1) { lblprogress.Text = "Connected"; getIVR(); } else { lblprogress.Text = "NO Connection"; }
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();



            Showcategory();
            ShowOffice();
            
         
           
            btnSave.Focus();
            drpCategory.SelectedIndex =- 1;
            drpOffice.SelectedIndex =- 1;

        }

        
      

       




        private void button5_Click(object sender, EventArgs e)
        {
            //DialogResult res = MessageBox.Show("Do You Want to Cancel New Record", "Cancel Item Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            //if (res == DialogResult.OK)
            //{


            //}
            this.Close();
        }

    

        


       

        

      

      
      

        private void Bill_KeyDown(object sender, KeyEventArgs e)
        
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

      


      


       



      




       

        private void Showcategory()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select id,cname from category order by cname", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpCategory.DataSource = ds1.Tables[0];
            drpCategory.DisplayMember = "CName";
            drpCategory.ValueMember = "id";

            ds1.Dispose();
            ad1.Dispose();




        }


        private void ShowOffice()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select offid,offname from officemas", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpOffice.DataSource = ds1.Tables[0];
            drpOffice.DisplayMember = "offname";
            drpOffice.ValueMember = "offid";

            ds1.Dispose();
            ad1.Dispose();




        }

        private void drpCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from stock WHERE  Category in (select cname from category where id="+drpCategory.SelectedValue+") and issuedto is null", con);

                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                listBox1.Items.Clear();
                ////listBox1.DataSource = ds1.Tables[0];
                //listBox1.DisplayMember = "Cname";
                // listBox1.ValueMember = "cid";

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds1.Tables[0].Rows[i]["id"].ToString() + ",  " + ds1.Tables[0].Rows[i]["modelno"].ToString() + ",  " + ds1.Tables[0].Rows[i]["serialno"].ToString());
                    listBox1.ValueMember = ds1.Tables[0].Rows[i]["id"].ToString();
                }
                ad1.Dispose();
                ds1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from stock WHERE  Category+modelno+serialno like '%"+txtsearch.Text+"%' and issuedto is null", con);

                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                listBox1.Items.Clear();
                ////listBox1.DataSource = ds1.Tables[0];
                //listBox1.DisplayMember = "Cname";
                // listBox1.ValueMember = "cid";
                
                

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds1.Tables[0].Rows[i]["id"].ToString() + ",  " + ds1.Tables[0].Rows[i]["modelno"].ToString() + ",  " + ds1.Tables[0].Rows[i]["serialno"].ToString());
                    listBox1.ValueMember = ds1.Tables[0].Rows[i]["id"].ToString();
                }
                ad1.Dispose();
                ds1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void drpCategory_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblpid.Text = listBox1.SelectedItem.ToString().Substring(0, listBox1.SelectedItem.ToString().IndexOf(","));
        }
    }
    
}

