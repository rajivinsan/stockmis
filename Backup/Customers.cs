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

    public partial class Customers : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        public Customers()
        {
            con.ConnectionString = cn.connectionstring;
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbCommand cmdsave = new OleDbCommand("insert into customer(cname,caddress,ccontact,ctin,TINTYPE,OWNERNAME,CITY,TRANSPORT, Ctype)values(@cname,@caddress,@ccontact,@ctin,@TINTYPE,@OWNERNAME,@CITY,@TRANSPORT, @Ctype)", con);
                cmdsave.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = textBox1.Text;
                cmdsave.Parameters.Add("@caddress", OleDbType.VarChar, 100).Value = textBox2.Text;
                cmdsave.Parameters.Add("@ccontact", OleDbType.VarChar, 100).Value = textBox3.Text;
                cmdsave.Parameters.Add("@ctin", OleDbType.VarChar, 100).Value = textBox4.Text;
                cmdsave.Parameters.Add("@TINTYPE", OleDbType.VarChar, 100).Value = comboBox1.Text;
                cmdsave.Parameters.Add("@OWNERNAME", OleDbType.VarChar, 100).Value = textBox5.Text;
                cmdsave.Parameters.Add("@CITY", OleDbType.VarChar, 100).Value = textBox6.Text;
                cmdsave.Parameters.Add("@TRANSPORT", OleDbType.VarChar, 100).Value = textBox7.Text;
                cmdsave.Parameters.Add("@ctype", OleDbType.VarChar, 100).Value = cmbtype.Text;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdsave.ExecuteNonQuery();
                cmdsave.Parameters.Clear();
                cmdsave.Dispose();
                con.Close();
                MessageBox.Show("Data Saved Successfully");
                Showcustomer();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Please Enter Firm Name");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Showcustomer();
        }

        private void Showcustomer()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select cid as ID,OWNERNAME AS OWNER_NAME, cname as FIRM_NAME,caddress as ADDRESS,CITY,ccontact as CONTACT,TINTYPE, ctin as TIN_CST_NO,TRANSPORT from Customer WHERE   ctype=@ctype", con);
            ad1.SelectCommand.Parameters.Add("@ctype", OleDbType.VarChar, 100).Value = cmbtype.Text;
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 190;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 150;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand cmddel = new OleDbCommand("Delete from customer where cid=@cid", con);
            cmddel.Parameters.Add("@cid", OleDbType.Integer).Value = Convert.ToInt32(label6.Text);
           
           
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //MessageBox.Show(e.RowIndex.ToString());
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {


            if (label6.Text != "0")
            {
               
               
                    OleDbCommand cmdupdate = new OleDbCommand("update customer set cname=@cname,caddress=@caddress,ccontact=@ccontact,ctin=@ctin, TINTYPE=@TINTYPE,OWNERNAME=@OWNERNAME,CITY=@CITY,TRANSPORT=@TRANSPORT, ctype=@ctype where cid=@cid", con);

                    cmdupdate.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = textBox1.Text;
                    cmdupdate.Parameters.Add("@caddress", OleDbType.VarChar, 100).Value = textBox2.Text;
                    cmdupdate.Parameters.Add("@ccontect", OleDbType.VarChar, 100).Value = textBox3.Text;
                    cmdupdate.Parameters.Add("@ctin", OleDbType.VarChar, 100).Value = textBox4.Text;
                    cmdupdate.Parameters.Add("@TINTYPE", OleDbType.VarChar, 100).Value = comboBox1.Text;
                    cmdupdate.Parameters.Add("@OWNERNAME", OleDbType.VarChar, 100).Value = textBox5.Text;
                    cmdupdate.Parameters.Add("@CITY", OleDbType.VarChar, 100).Value = textBox6.Text;
                    cmdupdate.Parameters.Add("@TRANSPORT", OleDbType.VarChar, 100).Value = textBox7.Text;
                    cmdupdate.Parameters.Add("@ctype", OleDbType.VarChar, 100).Value = cmbtype.Text;
                    cmdupdate.Parameters.Add("@cid", OleDbType.Integer).Value = Convert.ToInt32(label6.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdupdate.ExecuteNonQuery();
                    cmdupdate.Parameters.Clear();
                    cmdupdate.Dispose();
                    con.Close();
                    MessageBox.Show("Data Updated Successfully");
                    Showcustomer();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    cmbtype.Text = "Creditor";
                    
               
                
            }
            else
            {
                MessageBox.Show("Please Select any customer Below");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                 textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                 comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                 textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                 textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
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

       
    }
}
