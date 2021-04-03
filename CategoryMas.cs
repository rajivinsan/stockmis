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
    public partial class CategoryMas : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        string pid = "";
        public CategoryMas()
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
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select  Max(id) from category", con);

            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows[0][0].ToString()!="")
            {
                lblID.Text = (Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString()) + 1).ToString();
            }
            else
            {
                lblID.Text = "1";
            }
            //label9.Text = ds1.Tables[0].Rows[0][2].ToString();
        }

        private void CategoryMas_Load(object sender, EventArgs e)
        {
      
           
            Showbalance();
            Showdata();
           

        }

        private void Showdata()
        {

            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select ID,Cname as [Category Name] from category order by 1", con);

            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);

            dataGridView1.DataSource = ds1.Tables[0];

            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = (dataGridView1.Width- dataGridView1.Columns[0].Width)-1;






        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }





        

        private string MaxID()
        {
            string pid = "";
            OleDbDataAdapter ad3 = new OleDbDataAdapter("Select max(item_code)+1 from item_mas", con);
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


        private void button3_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save" && txtCatName.Text == "")
            {
                MessageBox.Show("Enter Party Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (btnSave.Text == "Save" && txtCatName.Text != "")
            {
               
                OleDbCommand cmdsaveEmployee = new OleDbCommand("insert into category(Cname)values(@cname)", con);
              
                cmdsaveEmployee.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = txtCatName.Text;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdsaveEmployee.ExecuteNonQuery();
                cmdsaveEmployee.Parameters.Clear();
                cmdsaveEmployee.Dispose();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                Showdata();
                Showbalance();
            }
            if (btnSave.Text == "Update")
            {
                OleDbCommand cmdupdate = new OleDbCommand("update category set cname='" + txtCatName.Text + "' where CID=" + lblID.Text + "", con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdupdate.ExecuteNonQuery();
                cmdupdate.Parameters.Clear();
                cmdupdate.Dispose();
                con.Close();
                MessageBox.Show("Data updated Successfully");
                //clear();
                Showdata();
                Showbalance();
            }
            clear();
        }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtCatName.Text = dataGridView1.Rows[e.RowIndex].Cells["Category Name"].Value.ToString();


                btnSave.Text = "Update";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           

        }

        private void button5_Click(object sender, EventArgs e)
        { DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                OleDbCommand cmddel = new OleDbCommand("delete from category where ID=" + lblID.Text + "", con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmddel.ExecuteNonQuery();
                cmddel.Parameters.Clear();
                cmddel.Dispose();
                con.Close();
                MessageBox.Show("Data Deleted Successfully");
                Showdata();
                Showbalance();
            }
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            txtCatName.Text = string.Empty;
            btnSave.Text = "Save";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
