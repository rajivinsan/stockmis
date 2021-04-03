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
    public partial class Partymas : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        string pid = "";
        public Partymas()
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

                OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT PID, PName, QUANTITY, SALE_RATE FROM Stock where Pid =" + pid + "", con);
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
        private void Showbalance()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select  (Max(pid)+1) as [ID] from purchase_party", con);

            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            lblID.Text = ds1.Tables[0].Rows[0]["ID"].ToString();

            if (lblID.Text.Trim() == "")
            {
                lblID.Text = "1";
            }
            //label9.Text = ds1.Tables[0].Rows[0][2].ToString();
        }

        private void Partymas_Load(object sender, EventArgs e)
        {
      
            
            Showbalance();
            showdata();
            lblID.Text = MaxID();

        }

        private string MaxID()
        {
            string pid = "";
            OleDbDataAdapter ad3 = new OleDbDataAdapter("Select max(pid)+1 from purchase_party", con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            //lblID.Text = ds3.Tables[0].Rows[0][0].ToString();
            pid = ds3.Tables[0].Rows[0][0].ToString();
            if (pid == null || pid == "")
            {
                pid = "001";
            }
            ad3.Dispose();
            ds3.Dispose();
            
            return pid;

        }

        private void showdata()
        {
           
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT  * FROM purchase_party", con);
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
            




        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (btnSave.Text == "Save" && txtparty.Text == "")
            {
                MessageBox.Show("Enter Party Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (btnSave.Text == "Save" && txtparty.Text != "")
            {
                lblID.Text = MaxID();
                OleDbCommand cmdsave = new OleDbCommand("insert into Purchase_Party(pid,pname,padd,mob,AC)values(" + lblID.Text + ",'" + txtparty.Text + "','" + txtadd.Text + "','" + txtcontact.Text + "','" + txtac.Text + "')", con);


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
                Showbalance();
            }

            if (btnSave.Text == "Update")
            {


                OleDbCommand cmdupdate = new OleDbCommand("update purchase_party set pname='" + txtparty.Text + "', padd='" + txtadd.Text + "' ,mob='" + txtcontact.Text + "',ac='" + txtac.Text + "' where id=" + lblID.Text + "", con);

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
                Showbalance();

            }
            btnSave.Text = "Save";
            clear();
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtadd.Text = dataGridView1.Rows[e.RowIndex].Cells["padd"].Value.ToString();
                txtparty.Text  = dataGridView1.Rows[e.RowIndex].Cells["pname"].Value.ToString();
                txtcontact.Text = dataGridView1.Rows[e.RowIndex].Cells["mob"].Value.ToString();
                //txtac.Text = dataGridView1.Rows[e.RowIndex].Cells["ac"].Value.ToString();
                btnSave.Text = "Update";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           



        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                OleDbCommand cmddel = new OleDbCommand("delete from purchase_party where ID=" + lblID.Text + "", con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmddel.ExecuteNonQuery();
                cmddel.Parameters.Clear();
                cmddel.Dispose();
                con.Close();
                MessageBox.Show("Data Deleted Successfully");
                showdata();
                Showbalance();
                clear();
            }
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
            txtparty.Text = string.Empty;
            txtadd.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtac.Text = string.Empty;
            btnSave.Text = "Save";
            lblID.Text = MaxID();

        }

        

       

    }
}
