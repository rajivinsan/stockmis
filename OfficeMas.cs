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

    public partial class OfficeMas : Form
    {
        Int32 GID;
        String companyid = "";
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        public OfficeMas(string compid)
        {
            con.ConnectionString = cn.connectionstring;
            
            
            InitializeComponent();
            companyid = compid;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (xButton2.Text != "New")
                {
                    if (txtname.Text == "")
                    {
                        MessageBox.Show("Please Enter Name");
                    }

                    else if (xButton2.Text == "Save")
                    {
                        OleDbCommand cmdsave = new OleDbCommand("insert into officemas(offname,contact,address,contactperson)values(@offname,@contact,@address,@contactperson)", con);
                       
                        cmdsave.Parameters.Add("@offname", OleDbType.VarChar, 255).Value = txtname.Text;
                        cmdsave.Parameters.Add("@contactperson", OleDbType.VarChar, 255).Value = txtcontactperson.Text;
                        cmdsave.Parameters.Add("@address", OleDbType.VarChar, 100).Value = txtadd.Text;
                      
                        cmdsave.Parameters.Add("@contact", OleDbType.VarChar, 100).Value = txtcontactno.Text;
                       
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmdsave.ExecuteNonQuery();

                        cmdsave.Parameters.Clear();
                        cmdsave.Dispose();
                        con.Close();
                        //deleteDM();
                        //ADDDM();
                        MessageBox.Show("Data Saved Successfully");
                        Showcustomer();
                        clear();
                        xButton2.Text = "New";
                        groupBox2.Controls.Clear();

                    }

                    else if (lblID.Text != "0" && xButton2.Text == "Update")
                    {


                        OleDbCommand cmdupdate = new OleDbCommand("update officemas set offname=@offname,contact=@contact,address=@address,contactperson=@contactperson where offid=@cid ", con);

                        cmdupdate.Parameters.Add("@cid", OleDbType.Numeric).Value = lblID.Text.Trim();
                        cmdupdate.Parameters.Add("@offname", OleDbType.VarChar, 255).Value = txtname.Text;
                        cmdupdate.Parameters.Add("@contactperson", OleDbType.VarChar, 255).Value = txtcontactperson.Text;
                        cmdupdate.Parameters.Add("@address", OleDbType.VarChar, 255).Value = txtadd.Text;
                     
                        cmdupdate.Parameters.Add("@contact", OleDbType.VarChar, 100).Value = txtcontactno.Text;
                       
                        //cmdupdate.Parameters.Add("@compid", OleDbType.VarChar, 100).Value = companyid;

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmdupdate.ExecuteNonQuery();
                        cmdupdate.Parameters.Clear();
                        cmdupdate.Dispose();
                        con.Close();
                        //   deleteDM();
                        // ADDDM();
                        MessageBox.Show("Data Updated Successfully");
                        Showcustomer();
                        xButton2.Text = "New";
                        clear();
                        //groupBox2.Controls.Clear();




                    }

                }
                else
                {
                    clear();
                    xButton2.Text = "Save";
                 
                    groupBox1.Enabled = true;
                    groupBox3.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


       
        private void clear()
        {
            
            txtname.Clear();
            txtcontactperson.Clear();
            txtadd.Clear();
           
            txtcontactno.Clear();
           
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Showcustomer();
           
          
            groupBox1.Enabled = false;
           groupBox2.Enabled = false;
        }

        private void Showcustomer()
        {
            try
            {
                con.Open();
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from officemas", con);

                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                listBox1.Items.Clear();
                ////listBox1.DataSource = ds1.Tables[0];
                //listBox1.DisplayMember = "Cname";
                //listBox1.ValueMember = "Offid";
                
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds1.Tables[0].Rows[i]["offid"].ToString() + ",  " + ds1.Tables[0].Rows[i]["offname"].ToString() + ",  " + ds1.Tables[0].Rows[i]["contact"].ToString());
                    listBox1.ValueMember = ds1.Tables[0].Rows[i]["offid"].ToString();
                }
                ad1.Dispose();
                ds1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            

        }
      
        

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

            if (lblID.Text != "1111")
            {
                if (result == DialogResult.Yes)
                {
                    OleDbCommand cmddel = new OleDbCommand("Delete from OfficeMas where offid=@cid", con);
                    cmddel.Parameters.Add("@cid", OleDbType.Integer).Value = Convert.ToInt32(lblID.Text);
                    //cmddel.Parameters.Add("@compid", OleDbType.Integer).Value = companyid;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmddel.ExecuteNonQuery();
                    cmddel.Parameters.Clear();
                    cmddel.Dispose();
                    con.Close();
                    MessageBox.Show("Data Deleted Successfully");
                    Showcustomer();
                    clear();
                    groupBox2.Controls.Clear();
                    xButton2.Text = "New";
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //MessageBox.Show(e.RowIndex.ToString());
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {


            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtcontactperson.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtadd.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                 txtcontactno.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                 
                
                 
               
            }
        }

        private void Customers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Showcustomer();
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

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    groupBox1.Enabled = true;
                    //lblID.Text= listBox1.SelectedValue.ToString();
                    lblID.Text = listBox1.SelectedItem.ToString().Substring(0, listBox1.SelectedItem.ToString().IndexOf(","));

                    OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from OfficeMas where offid=@Pid", con);
                    ad2.SelectCommand.Parameters.Add("@Pid", OleDbType.Integer).Value = Convert.ToInt32(lblID.Text);
                    DataSet ds2 = new DataSet();
                    ad2.Fill(ds2);

                    txtname.Text = ds2.Tables[0].Rows[0]["offname"].ToString();
                    txtcontactperson.Text = ds2.Tables[0].Rows[0]["contactperson"].ToString();
                    txtadd.Text = ds2.Tables[0].Rows[0]["address"].ToString();
                  
                    txtcontactno.Text = ds2.Tables[0].Rows[0]["contact"].ToString();
                   
                    ds2.Dispose();
                    ad2.Dispose();
                    con.Close();
                    if (lblID.Text == "1111")
                    {
                        xButton2.Enabled = false;
                    }
                    else { xButton2.Enabled = true; }
                    xButton2.Text = "Update";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchData()
        {
            try
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select offid,offname,contact from OfficeMas WHERE (offname+contact) like '%" + txtsearch.Text + "%'", con);

                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                listBox1.Items.Clear();
                ////listBox1.DataSource = ds1.Tables[0];
                //listBox1.DisplayMember = "Cname";
                listBox1.ValueMember = "offid";

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds1.Tables[0].Rows[i]["offid"].ToString() + ",  " + ds1.Tables[0].Rows[i]["offname"].ToString() + ",  " + ds1.Tables[0].Rows[i]["contact"].ToString());
                    listBox1.ValueMember = ds1.Tables[0].Rows[i]["offid"].ToString();
                }
                ad1.Dispose();
                ds1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            SearchData();

        }

        private void txtslength_TextChanged(object sender, EventArgs e)
        {

        }

        
       
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            clear();
            xButton2.Text = "New";
            
            
        }

      

    }
}
