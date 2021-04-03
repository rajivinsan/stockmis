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

    public partial class SelectCompany : Form
    {
        Int32 GID;
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        public SelectCompany()
        {
            con.ConnectionString = cn.connectionstring;
            
            
            InitializeComponent();
        }

        private String GenratePID()
        {

            String id;

            OleDbCommand cmd = new OleDbCommand("select Max(CompId) from companyMas", con);
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            id = cmd.ExecuteScalar().ToString();

            if (id != null && id != "")
            {
                GID = Convert.ToInt32(id) + 1;


            }
            else
            {
                GID = Convert.ToInt32("1" + "01");

            }

            return GID.ToString();

        }

       


       

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getdate();
           
          
        }
        private void getdate()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("select compid,compname as [Company],Address,State,GST from companymas", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
            adp.Dispose();
            con.Close();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 2;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 6;


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
                
                
               
            }
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            lblid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //Main main = new Main(id);
            //main.Show();
            
        }

        private void xButton2_Click(object sender, EventArgs e)
        {
            CompanyMas frmcompany = new CompanyMas("");
            frmcompany.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "0")
            { MessageBox.Show("Select any Company", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                CompanyMas frmcompany = new CompanyMas(lblid.Text);
                frmcompany.Show();
            }
        }

        private void SelectCompany_Move(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "0")
            { MessageBox.Show("Select any Company","Select", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                Main main = new Main(lblid.Text);
                main.Show();
            }
        }
    }
}
