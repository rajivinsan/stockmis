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
    public partial class MasterData : Form
    {
        String companyid = "";
         connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        public MasterData(String compid)
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
            companyid = compid;
        }

        private void ListBill_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CategoryMas frm = new CategoryMas();
            //frm.MdiParent = this.MdiParent;
            //frm.Dock = DockStyle.Fill;
            //frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
           



        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
          
           
          
           
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
           

        }
        void printRpt(string billno)
        {

           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CompanyMas frm = new CompanyMas(companyid);
            //frm.MdiParent = this.MdiParent;
            //frm.Dock = DockStyle.Fill;
            //frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemMas   frm = new ItemMas();
            //frm.MdiParent = this.MdiParent;
            //frm.Dock = DockStyle.Fill;
            //frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OfficeMas officeMas = new OfficeMas("");
            officeMas.MdiParent = this.MdiParent;
            officeMas.Dock = DockStyle.Fill;
            officeMas.StartPosition = FormStartPosition.CenterParent;
            officeMas.Show();

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
