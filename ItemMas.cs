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
    public partial class ItemMas : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        string pid = "";
        public ItemMas()
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
        }

        private void Update_Click(object sender, EventArgs e)
        {


        }
        private void Showproduct()
        {
            try
            {

                OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT PID, PName, QUANTITY, SALE_RATE FROM Stock where Pid =" + pid + " order by 1", con);
                //ad1.SelectCommand.Parameters.Add("@pid", OleDbType.Numeric).Value = txtpid.Text.Trim();
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                //dataGridView1.DataSource = ds1.Tables[0];
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       

        private void ItemMas_Load(object sender, EventArgs e)
        {
      
            Showcategory();
          
            showdata();
           

        }

        private void showdata()
        {
            string value;
            if (comboBox1.SelectedValue != null)
            { value=comboBox1.SelectedValue.ToString(); }
            else { value=null; }
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT  * FROM Work_Mas where  c_code="+value+" ", con);
            // ad1.SelectCommand.Parameters.Add("@ctype", OleDbType.VarChar, 100).Value = cmbtype.Text;
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            
                dataGridView1.DataSource = ds1.Tables[0];
                   

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void Showcategory()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select id,cname from category order by cname", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = "CNAME";
            comboBox1.ValueMember = "id";




        }

        


        private void button3_Click(object sender, EventArgs e)
        {
           
            if (btnSave.Text == "Save" && txtItemname.Text == "")
            {
                MessageBox.Show("Enter  Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (btnSave.Text == "Save" && txtItemname.Text != "")
            {
              
                OleDbCommand cmdsave = new OleDbCommand("insert into work_mas(work_name,c_code,hsncode,taxslab)values('" + txtItemname.Text + "'," + comboBox1.SelectedValue + ",'" + txthsncode.Text + "','" + txtTaxSlab.Text + "')", con);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdsave.ExecuteNonQuery();
                cmdsave.Parameters.Clear();
                cmdsave.Dispose();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                showdata();
               
            }
            if(btnSave.Text=="Update")
            {
                OleDbCommand cmdupdate = new OleDbCommand("update work_mas set work_name='" + txtItemname.Text + "', c_code=" + comboBox1.SelectedValue + " ,hsncode='" + txthsncode.Text + "',taxslab='" + txtTaxSlab.Text + "' where ID=" + lblID.Text + "", con);

                //cmdupdate.Parameters.Add("@CNAME", OleDbType.VarChar, 100).Value = cmbname.Text;
                //cmdupdate.Parameters.Add("@TTYPE", OleDbType.VarChar, 100).Value = cmbttype.Text;
                //cmdupdate.Parameters.Add("@RTYPE", OleDbType.VarChar, 100).Value = cmbtype.Text;
                //cmdupdate.Parameters.Add("@REFNO", OleDbType.VarChar, 100).Value = txtname.Text;
                //cmdupdate.Parameters.Add("@RDATE", OleDbType.VarChar, 100).Value = DateTime.Now.ToShortTimeString();
                //cmdupdate.Parameters.Add("@Ramount", OleDbType.VarChar, 100).Value = txtamount.Text;
                //cmdupdate.Parameters.Add("@bid", OleDbType.VarChar, 100).Value = label.Text;


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdupdate.ExecuteNonQuery();
                cmdupdate.Parameters.Clear();
                cmdupdate.Dispose();
                con.Close();
                MessageBox.Show("Data updated Successfully");
                showdata();
              
              }
            clear();
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells["Work_Code"].Value.ToString();
                txtItemname.Text = dataGridView1.Rows[e.RowIndex].Cells["Work_name"].Value.ToString();
                comboBox1.SelectedValue  = dataGridView1.Rows[e.RowIndex].Cells["c_code"].Value.ToString();
                txthsncode.Text = dataGridView1.Rows[e.RowIndex].Cells["hsncode"].Value.ToString();
                txtTaxSlab.Text = dataGridView1.Rows[e.RowIndex].Cells["taxslab"].Value.ToString();

                btnSave.Text = "Update";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           



        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

            //if (result == DialogResult.Yes)
            //{
            //    OleDbCommand cmddel = new OleDbCommand("delete from item_mas where ID=" + lblID.Text + "", con);

            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }
            //    cmddel.ExecuteNonQuery();
            //    cmddel.Parameters.Clear();
            //    cmddel.Dispose();
            //    con.Close();
            //    MessageBox.Show("Data Deleted Successfully");
            //    showdata();
               
            //}
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            showdata();
        }

        private void txtbillno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            comboBox1.SelectedIndex = -1;
            txtItemname.Text = string.Empty;
            txthsncode.Text = string.Empty;
            txtTaxSlab.Text = string.Empty;
            btnSave.Text = "Save";
            
        }

        

       

    }
}
