using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace GST
{
    public partial class ReportBooking : Form
    {
        public string str;
        public ReportBooking(String id)
        {
            InitializeComponent();
            str = id;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            
         
        }

        private void ReportBooking_Load(object sender, EventArgs e)
       
        {
           
            
            ReportDocument rpt = new ReportDocument();
            if (str.Trim() == "aid")
            {
                rpt.Load(Application.StartupPath + "\\" + "bookingAID.rpt"); rpt.Refresh();
            }
            else { rpt.Load(Application.StartupPath + "\\" + "Orderbill.rpt"); rpt.Refresh();}

           rpt.SetDatabaseLogon("Admin", "dbson");
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();
           
            
            
        }

        private void crystalReportViewer1_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void ReportBooking_MouseHover(object sender, EventArgs e)
        {

        }

       

        
    }
}
