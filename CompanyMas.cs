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

    public partial class CompanyMas : Form
    {
        Int32 GID;
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        public CompanyMas(String cid)
        {
            con.ConnectionString = cn.connectionstring;
            
            
            InitializeComponent();
            if (cid.Length > 0)
            {
                Showcustomer(cid);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            //if (xButton2.Text != "New" )
            //{
            //    if (txtcompname.Text == "")
            //    {
            //        MessageBox.Show("Please Enter Name");
            //    }
                
            //   else if ( xButton2.Text == "Save")
            //    {
            //        OleDbCommand cmdsave = new OleDbCommand("insert into companymas(CompID,CompName,address,city,state,Contactname,Contact,website,gst,pan,cst,acno,acname,ifsc,bank)values(@Cid,@CompName,@address,@city,@state,@Contactname,@Contact,@website,@gst,@pan,@cst,@acno,@acname,@ifsc,@bank)", con);
            //        cmdsave.Parameters.Add("@cid", OleDbType.Numeric).Value = GenratePID();
            //        cmdsave.Parameters.Add("@CompName", OleDbType.VarChar, 100).Value = txtcompname.Text;
            //        cmdsave.Parameters.Add("@address", OleDbType.VarChar, 100).Value = txtadd.Text;
            //        cmdsave.Parameters.Add("@CITY", OleDbType.VarChar, 100).Value = txtcity.Text;
            //        cmdsave.Parameters.Add("@sate", OleDbType.VarChar, 100).Value = txtstate.Text;
            //        cmdsave.Parameters.Add("@Contactname", OleDbType.VarChar, 100).Value = txtcontactname.Text;
            //        cmdsave.Parameters.Add("@Contact", OleDbType.VarChar, 100).Value = txtcontactno.Text;
            //        cmdsave.Parameters.Add("@website", OleDbType.VarChar, 200).Value = txtwebsite.Text;
            //        cmdsave.Parameters.Add("@gst", OleDbType.VarChar, 100).Value = txtgst.Text;
            //        cmdsave.Parameters.Add("@pan", OleDbType.VarChar, 100).Value = txtpanno.Text;
            //        cmdsave.Parameters.Add("@cst", OleDbType.VarChar, 100).Value = txtcstno.Text;
            //        cmdsave.Parameters.Add("@acno", OleDbType.VarChar, 100).Value = txtacno.Text;
            //        cmdsave.Parameters.Add("@acname", OleDbType.VarChar, 100).Value = txtacname.Text;
            //        cmdsave.Parameters.Add("@ifsc", OleDbType.VarChar, 100).Value = txtifsc.Text;
            //        cmdsave.Parameters.Add("@bank", OleDbType.VarChar, 100).Value = txtbank.Text;
            //        if (con.State == ConnectionState.Closed)
            //        {
            //            con.Open();
            //        }
            //        cmdsave.ExecuteNonQuery();

            //        cmdsave.Parameters.Clear();
            //        cmdsave.Dispose();
            //        con.Close();
            //        //deleteDM();
            //        //ADDDM();
            //        MessageBox.Show("Data Saved Successfully");
                   
            //        clear();
            //        xButton2.Text = "New";
                   

            //    }
                
            //   else if (xButton2.Text == "Update")
            //    {


            //        OleDbCommand cmdupdate = new OleDbCommand("update companymas set CompID=@CompID,CompName=@CompName,address=@address,city=@city,state=@state,countery=@countery,pin=@pin,Contactname=@Contactname,Contact=@Contact,website=@website,gst=@gst,pan=@pan,cst=@cst,acno=@acno,acname=@acname,ifsc=@ifsc,bank=@bank,tag=@tag where CompID=@CompID", con);
            //        cmdupdate.Parameters.Add("@CompID", OleDbType.Numeric).Value = lblID.Text.Trim();
            //        cmdupdate.Parameters.Add("@CompName", OleDbType.VarChar, 100).Value = txtcompname.Text;
            //        cmdupdate.Parameters.Add("@address", OleDbType.VarChar, 100).Value = txtadd.Text;
            //        cmdupdate.Parameters.Add("@CITY", OleDbType.VarChar, 100).Value = txtcity.Text;
            //        cmdupdate.Parameters.Add("@state", OleDbType.VarChar, 100).Value = txtstate.Text;
            //        cmdupdate.Parameters.Add("@countery", OleDbType.VarChar, 100).Value = "";
            //        cmdupdate.Parameters.Add("@pin", OleDbType.VarChar, 100).Value = "";
            //        cmdupdate.Parameters.Add("@Contactname", OleDbType.VarChar, 100).Value = txtcontactname.Text;
            //        cmdupdate.Parameters.Add("@Contact", OleDbType.VarChar, 100).Value = txtcontactno.Text;
            //        cmdupdate.Parameters.Add("@website", OleDbType.VarChar, 200).Value = txtwebsite.Text;
            //        cmdupdate.Parameters.Add("@gst", OleDbType.VarChar, 100).Value = txtgst.Text;
            //        cmdupdate.Parameters.Add("@pan", OleDbType.VarChar, 100).Value = txtpanno.Text;
            //        cmdupdate.Parameters.Add("@cst", OleDbType.VarChar, 100).Value = txtcstno.Text;
            //        cmdupdate.Parameters.Add("@acno", OleDbType.VarChar, 100).Value = txtacno.Text;
            //        cmdupdate.Parameters.Add("@acname", OleDbType.VarChar, 100).Value = txtacname.Text;
            //        cmdupdate.Parameters.Add("@ifsc", OleDbType.VarChar, 100).Value = txtifsc.Text;
            //        cmdupdate.Parameters.Add("@bank", OleDbType.VarChar, 100).Value = txtbank.Text;
            //        cmdupdate.Parameters.Add("@tag", OleDbType.VarChar, 100).Value = "";
                   
                  

            //        if (con.State == ConnectionState.Closed)
            //        {
            //            con.Open();
            //        }
            //        cmdupdate.ExecuteNonQuery();
            //        cmdupdate.Parameters.Clear();
            //        cmdupdate.Dispose();
            //        con.Close();
            //        //   deleteDM();
            //        // ADDDM();
            //        MessageBox.Show("Data Updated Successfully");
                   
            //        xButton2.Text = "New";
            //        clear();
            //        //groupBox2.Controls.Clear();




            //    }
                
            //}
            //else
            //{
            //    clear();
            //    xButton2.Text = "Save";
            //   lblID.Text= GenratePID();
             
            
            //}
            
        }


       

       
        private void clear()
        {
            
            txtcompname.Clear();
            txtcontactname.Clear();
            txtadd.Clear();
            txtcity.Clear();
            txtcontactno.Clear();
            txtgst.Clear();
            txtacno.Clear();
            txtacname.Clear();
            txtifsc.Clear();
            txtbank.Clear();
            txtwebsite.Clear();
            txtstate.Clear();
            txtpanno.Clear();
            txtcstno.Clear();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
          
           
        }

       

       

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

            if (lblID.Text != "1111")
            {
                if (result == DialogResult.Yes)
                {
                    OleDbCommand cmddel = new OleDbCommand("Delete from customer where cid=@cid", con);
                    cmddel.Parameters.Add("@cid", OleDbType.Integer).Value = Convert.ToInt32(lblID.Text);


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmddel.ExecuteNonQuery();
                    cmddel.Parameters.Clear();
                    cmddel.Dispose();
                    con.Close();
                    MessageBox.Show("Data Deleted Successfully");
                   
                    clear();
                 
                    xButton2.Text = "New";
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //MessageBox.Show(e.RowIndex.ToString());
            
        }

        private void Showcustomer(string id)
        {
            try
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from CompanyMas where compid=@id", con);
                ad1.SelectCommand.Parameters.Add("@id", OleDbType.VarChar, 50).Value = id;

                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                txtcompname.Text = ds1.Tables[0].Rows[0]["compname"].ToString();
                txtadd.Text = ds1.Tables[0].Rows[0]["address"].ToString();
                txtcity.Text = ds1.Tables[0].Rows[0]["city"].ToString();
                txtstate.Text = ds1.Tables[0].Rows[0]["state"].ToString();
                txtcontactname.Text = ds1.Tables[0].Rows[0]["contactname"].ToString();
                txtcontactno.Text = ds1.Tables[0].Rows[0]["contact"].ToString();
                txtwebsite.Text = ds1.Tables[0].Rows[0]["website"].ToString();
                txtgst.Text = ds1.Tables[0].Rows[0]["gst"].ToString();
                txtpanno.Text = ds1.Tables[0].Rows[0]["pan"].ToString();
                txtcstno.Text = ds1.Tables[0].Rows[0]["cst"].ToString();
                txtacno.Text = ds1.Tables[0].Rows[0]["acno"].ToString();
                txtacname.Text = ds1.Tables[0].Rows[0]["acname"].ToString();
                txtifsc.Text = ds1.Tables[0].Rows[0]["ifsc"].ToString();
                txtbank.Text = ds1.Tables[0].Rows[0]["bank"].ToString();
                xButton2.Text = "Update";

                ad1.Dispose();
                ds1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        private void button2_Click(object sender, EventArgs e)
        {


            
            
        }

        


        private void Customers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

       

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        
       

        

        private void txtslength_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            clear();
            xButton2.Text = "New";
       
            
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtgst_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
