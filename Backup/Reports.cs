using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
namespace ImperialPlastics
{
    public partial class frmReports : Form
    {
        SqlConnection con = new SqlConnection();
       // connection cn = new connection();
        String ReportName = "DisplayStudents.rpt";
        public frmReports(String str)
        {
            ReportName = str;
            InitializeComponent();
           // con.ConnectionString = cn.con;
        }
        public frmReports()
        {
            InitializeComponent();
           // con.ConnectionString = cn.con;
        }
        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && textBox1.Text.Length>=2)
        //    {
        //        DataSet ds1 = new DataSet();
        //        ds1.Clear();
        //        SqlDataAdapter ad1 = new SqlDataAdapter("select * from othertruck where ltrim(rtrim(truck_no)) like '%" + textBox1.Text + "%'", con);
             

        //        ad1.Fill(ds1);

        //        if (ds1.Tables[0].Rows.Count >= 1)
        //        {

        //            dataGridView1.DataSource = ds1.Tables[0];
                
               
        //            ds1.Dispose();
        //            ad1.SelectCommand.Parameters.Clear();
        //            ad1.Dispose();
                 
                   
        //        }
        //        else
        //        {
        //            MessageBox.Show("No Records Found");
                   
        //        }
        //    }
         
        //}

        private void viewothertruck_Load(object sender, EventArgs e)
        {
           
           
        }

      
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
           rpt.Load(Application.StartupPath + "\\" + "REPORT.rpt");
            rpt.SetDatabaseLogon("Admin","dbson");
            crystalReportViewer2.ReportSource = rpt;
           // crystalReportViewer1.Refresh();
        }

        private void frmReports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
