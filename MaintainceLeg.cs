using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using ClosedXML.Excel;

namespace GST
{

    public partial class MaintainceLeg : Form
    {
        
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;

        public MaintainceLeg()
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
            DataRow row = ds1.Tables[0].NewRow();
            row["id"] = 0;
            row["cname"] = "ALL";
            
            ds1.Tables[0].Rows.InsertAt(row, 0);


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
            DataRow row = ds1.Tables[0].NewRow();
            row["offid"] = 0;
            row["offname"] = "ALL";

            ds1.Tables[0].Rows.InsertAt(row, 0);


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
                return;
            }
          else if (drpOffice.Text.Trim() == "")
            {
                MessageBox.Show("Select Party", "Please Select Party", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string qry = "SELECT StockMaintaince.Dated, Work_Mas.Work_Name, Stock.Category, Stock.Modelno, Stock.Serialno, OfficeMas.offname, StockMaintaince.Remarks " +
                    "FROM Work_Mas INNER JOIN((Stock INNER JOIN StockMaintaince ON Stock.ID = StockMaintaince.StockID) INNER JOIN OfficeMas ON Stock.Issuedto = OfficeMas.offid) ON Work_Mas.Work_code = StockMaintaince.Workid; ";
                
               
                if (drpCategory.Text.ToUpper() != "ALL" && drpCategory.Text.Trim() != "")
                {
                     qry = qry+ " and stock.category='" + drpCategory.Text + "'";
                }
                if (drpOffice.Text.ToUpper() != "ALL" && drpOffice.Text.Trim() != "")
                {
                    qry = qry+ " and stock.issuedto=" + drpOffice.SelectedValue+ " order by issuedto";
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

        private void button2_Click(object sender, EventArgs e)
        {

            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel
            string folderPath = "C:\\Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "MaintenanceData");
                wb.SaveAs(folderPath + "MaintenanceData" + DateTime.Now.Day+ DateTime.Now.Month+DateTime.Now.Year+".xlsx");
            }
            MessageBox.Show("Data Export", "Your Data Exported Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    } 

        


}