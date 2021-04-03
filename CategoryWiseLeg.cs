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

    public partial class CategoryWiseLeg : Form
    {
        
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;

        public CategoryWiseLeg()
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Showcategory();
                ShowOffice();
                drpOffice.SelectedIndex = -1;
                drpCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      


       
        
       
        
        
        private void count()
        {
           
            

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Showcategory()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select id,cname from category order by cname", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpCategory.DataSource = ds1.Tables[0];
            drpCategory.DisplayMember = "CName";
            drpCategory.ValueMember = "id";

            ds1.Dispose();
            ad1.Dispose();




        }
        private void ShowOffice()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select offid,offname from officemas", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpOffice.DataSource = ds1.Tables[0];
            drpOffice.DisplayMember = "offname";
            drpOffice.ValueMember = "offid";

            ds1.Dispose();
            ad1.Dispose();




        }
        private void Button1_Click(object sender, EventArgs e)
        {

           
            if (drpCategory.Text.Trim() == "")
            {
                MessageBox.Show("Select Party", "Please Select Party", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          else if (drpOffice.Text.Trim() == "")
            {
                MessageBox.Show("Select Party", "Please Select Party", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                string qry = "SELECT stock.Invoice, stock.Category, stock.PDATE, stock.Modelno, stock.Serialno, stock.Warranty, stock.AMC, stock.Price, stock.Status, OfficeMas.offname, " +
                       "FROM stock INNER JOIN OfficeMas ON stock.Issuedto = OfficeMas.offid where stock.issued is not null ";
                
               
                if (drpCategory.SelectedText.ToUpper() != "ALL" && drpCategory.SelectedText.Trim() != "")
                {
                     qry = " and stock.category='" + drpCategory.SelectedText+"'";
                }
                if (drpOffice.SelectedText.ToUpper() != "ALL" && drpOffice.SelectedText.Trim() == "")
                {
                    qry = " and stock.issuedto='" + drpOffice.SelectedText + "' order by issuedto";
                }


                OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adp.Dispose();
                

            }


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double pamount, samount, tamount;








            lbltotal.Text = dataGridView1.Rows.Count.ToString();
            

        }

       

        private void label16_Click(object sender, EventArgs e)
        {

        }

       
        

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }
    } 

        


}