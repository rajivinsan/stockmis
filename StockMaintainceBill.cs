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
    public partial class StockMaintainceBill : Form
    {
        String companyid = "";
        
        int cnt = 0;
        //SqlConnection sqlcon = new SqlConnection();
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        OleDbConnection con1 = new OleDbConnection();
       

        public StockMaintainceBill()
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
            


             if (drpWork.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Select Office/Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //txtcname.BackColor = System.Drawing.Color.OrangeRed;

            }
            else if (drpWork.Text.Trim() == drpOffice1.Text.Trim())
            {
                MessageBox.Show("Select Work", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (txtremarks.Text.Trim()=="")
            {
                MessageBox.Show("Enter Remarks","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }


            else

            {
                String qry;

                //"update bill set billtype=@billtype,bdate=@badate,cid=@cid,cname=@cname,cmob=@cmob,qty=@qty,total=@total,tax=@tax,discount=@discount,GTotal=@gtotal,paid=@paid,balance=@balance where bid=@bid";
                //"update bill set totalamount=" + txtTotalAmount.Text + ",tax=" + txtTax.Text + ",discount=" + txtDiscount.Text + ",GTotal=" + txtGrandTotal.Text + ",paid=" + txtPaid.Text + ",balance=" + txtBalance.Text + " ,INWORDS='' where billno=" +  txtbid.Text + "";
                qry = "insert into StockMaintaince(dated,workid,cid,stockid,remarks) values(@dated,@workid,@cid,@stockid,@remarks)";
                
             
                OleDbTransaction trns = null;
                try
                {

                    OleDbCommand cmdsave = new OleDbCommand(qry, con);
                    cmdsave.Parameters.Add("@dated", OleDbType.Date).Value = dateTimePicker1.Text;
                    cmdsave.Parameters.Add("@workid", OleDbType.Numeric).Value = drpWork.SelectedValue;
                    cmdsave.Parameters.Add("@cid", OleDbType.Numeric).Value = drpOffice1.SelectedValue;
                    cmdsave.Parameters.Add("@stockid", OleDbType.Numeric).Value = lblpid.Text;
                    cmdsave.Parameters.Add("@remarkes", OleDbType.VarChar).Value = txtremarks.Text;


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


                    trns.Commit();
                                 
                    con.Close();
                    con1.Close();

                    drpWork.SelectedIndex = -1;
                    drpOffice1.SelectedIndex = -1;
                    lblpid.Text = "";
                    listBox1.Items.Clear();

                    MessageBox.Show("Work Added","Item Maintaince",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    
                }

                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message,"Error in Transcation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    trns.Rollback();
                
                  
                    
                    
                }
            }

        }

      
       

       
     

        private void Bill_Load(object sender, EventArgs e)
        {

            //if (checkNet() == 1) { lblprogress.Text = "Connected"; getIVR(); } else { lblprogress.Text = "NO Connection"; }
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();



        
            ShowOffice();
            
         
           
            btnSave.Focus();
            drpOffice1.SelectedIndex =- 1;
            drpWork.SelectedIndex =- 1;

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

      


      


       



      




       

       


        private void ShowOffice()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select offid,offname from officemas", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpWork.DataSource = ds1.Tables[0];
            drpWork.DisplayMember = "offname";
            drpWork.ValueMember = "offid";

            drpOffice1.DataSource = ds1.Tables[0];
            drpOffice1.DisplayMember = "offname";
            drpOffice1.ValueMember = "offid";

            ds1.Dispose();
            ad1.Dispose();
            ShowOffice1();



        }
        private void ShowOffice1()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select id,cname from category", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            

            drpOffice1.DataSource = ds1.Tables[0];
            drpOffice1.DisplayMember = "cname";
            drpOffice1.ValueMember = "id";

            ds1.Dispose();
            ad1.Dispose();




        }
        private void ShowWork()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from work_mas WHERE  c_code =" + drpOffice1.SelectedValue + " ", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);


            drpWork.DataSource = ds1.Tables[0];
            drpWork.DisplayMember = "Work_name";
            drpWork.ValueMember = "work_code";

            ds1.Dispose();
            ad1.Dispose();




        }

        private void drpCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowWork();
            showstock();
        }
        private void showstock()
        {
            try
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from stock WHERE  Category in (select cname from category where id=" + drpOffice1.SelectedValue + ") and issuedto is not null", con);

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
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from stock WHERE  Category+modelno+serialno like '%"+txtsearch.Text+"%' and category='"+drpOffice1.Text+"' and issuedto is not null", con);

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblpid.Text = listBox1.SelectedItem.ToString().Substring(0, listBox1.SelectedItem.ToString().IndexOf(","));
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void drpWork_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowWorkHis();
        }

        private void ShowWorkHis()
        {
            if (drpWork.SelectedValue != null && lblpid.Text.Trim() != "")
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT StockMaintaince.Dated, Work_Mas.Work_Name, StockMaintaince.Remarks FROM StockMaintaince " +
                    "INNER JOIN Work_Mas ON StockMaintaince.Workid = Work_Mas.Work_code where StockMaintaince.stockid =" + lblpid.Text + " and StockMaintaince.workid=" + drpWork.SelectedValue + " order by dated desc", con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);


                dataGridView1.DataSource = ds1.Tables[0];

                ds1.Dispose();
                ad1.Dispose();

            }


        }

        private void lblpid_TextChanged(object sender, EventArgs e)
        {
            ShowWorkHis();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            dataGridView1.Columns[0].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[0].Width = dataGridView1.Width / 3;
            dataGridView1.Columns[0].Width = dataGridView1.Width / 3;
        }
    }
    
}

