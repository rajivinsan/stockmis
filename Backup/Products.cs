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
   
    public partial class Products : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        public Products()
        {
            con.ConnectionString = cn.connectionstring;
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    OleDbCommand cmdsave = new OleDbCommand("insert into PRODUCTS(PNAME,PSIZE,PCOLOR,PPRICE,PCASE,PDESC)values(@PNAME,@PSIZE,@PCOLOR,@PPRICE,@PCASE,@PDESC)", con);
                    cmdsave.Parameters.Add("@PNAME", OleDbType.VarChar, 100).Value = textBox1.Text;
                    cmdsave.Parameters.Add("@PSIZE", OleDbType.VarChar, 100).Value = textBox2.Text;
                    cmdsave.Parameters.Add("@PCOLOR", OleDbType.VarChar, 100).Value = textBox3.Text;
                    cmdsave.Parameters.Add("@PPRICE", OleDbType.Integer).Value = Convert.ToInt32(0 + textBox4.Text);
                    cmdsave.Parameters.Add("@PCASE", OleDbType.Decimal).Value = Convert.ToDecimal(0 + textBox5.Text);
                    cmdsave.Parameters.Add("@PDESC", OleDbType.VarChar, 100).Value = textBox6.Text;
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Please Enter Item Name");
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
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select PID as ID,PNAME AS ITEM_NAME,PSIZE as P_SIZE,PCOLOR as P_COLOR,PPRICE AS PRICE,PCASE AS DOZ_IN_CASE,PDESC AS DESCRIPTION from PRODUCTS WHERE  PID>1 order by pid", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 90;
            dataGridView1.Columns[6].Width = 150;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand cmddel = new OleDbCommand("Delete from products where pid=@pid", con);
            cmddel.Parameters.Add("@pid", OleDbType.Integer).Value = Convert.ToInt32(label6.Text);
           
           
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
                if (button2.Text == "Edit")
                {
                    OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from PRODUCTS where pid=@Pid", con);
                    ad2.SelectCommand.Parameters.Add("@Pid", OleDbType.Integer).Value = Convert.ToInt32(label6.Text);
                    DataSet ds2 = new DataSet();
                    ad2.Fill(ds2);
                    textBox1.Text = ds2.Tables[0].Rows[0][1].ToString();
                    textBox2.Text = ds2.Tables[0].Rows[0][2].ToString();
                    textBox3.Text = ds2.Tables[0].Rows[0][3].ToString();
                    textBox4.Text = ds2.Tables[0].Rows[0][4].ToString();
                    textBox5.Text = ds2.Tables[0].Rows[0][5].ToString();
                    textBox6.Text = ds2.Tables[0].Rows[0][6].ToString();
                   
                    
                    button2.Text = "Update";
                }
                else
                {
                    try
                    {
                        OleDbCommand cmdupdate = new OleDbCommand("update PRODUCTS set PNAME=@PNAME,PSIZE=@PSIZE,PCOLOR=@PCOLOR,PPRICE=@PPRICE,PCASE=@PCASE,PDESC=@PDESC where Pid=@Pid", con);

                        cmdupdate.Parameters.Add("@PNAME", OleDbType.VarChar, 100).Value = textBox1.Text;
                        cmdupdate.Parameters.Add("@PSIZE", OleDbType.VarChar, 100).Value = textBox2.Text;
                        cmdupdate.Parameters.Add("@PCOLOR", OleDbType.VarChar, 100).Value = textBox3.Text;
                        cmdupdate.Parameters.Add("@PPRICE", OleDbType.Integer).Value = Convert.ToInt32(textBox4.Text);

                        cmdupdate.Parameters.Add("@PCASE", OleDbType.Decimal).Value = Convert.ToDecimal(textBox5.Text);
                        cmdupdate.Parameters.Add("@PDESC", OleDbType.VarChar, 100).Value = textBox6.Text;

                        cmdupdate.Parameters.Add("@Pid", OleDbType.Integer).Value = Convert.ToInt32(label6.Text);
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

                        button2.Text = "Edit";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } 
                
            }
            else
            {
                MessageBox.Show("Please Select any Product Below");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

       
    }
}
