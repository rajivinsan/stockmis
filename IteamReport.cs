using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
namespace GST
{
    public partial class IteamReport : Form
    {
        public string rp;
        
        public IteamReport(String str)
        {
            InitializeComponent();
            rp = str;
        }

        private void IteamReport_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            

            try

            {
                if (rp.Trim() == "Booking")
                {
                    rpt.Load(Application.StartupPath + "\\" + "Orderbill.rpt"); 
                }
                else
                {

                    rpt.Load(Application.StartupPath + "\\" + "iteambill.rpt"); rpt.Refresh();


                    connectionInfo.ServerName = Application.StartupPath + "\\" + "dbson.mdb";
                    connectionInfo.DatabaseName = "";
                    connectionInfo.UserID = "Admin";
                    connectionInfo.Password = "dbson";

                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
                    {
                        //*********************************Cache the logon info block

                        TableLogOnInfo logOnInfo = table.LogOnInfo;

                        //*************************************Set the connection

                        logOnInfo.ConnectionInfo = connectionInfo;

                        //******************************Apply the connection to the table!

                        table.ApplyLogOnInfo(logOnInfo);
                    }
                    rpt.VerifyDatabase();
                    crystalReportViewer1.ReportSource = rpt;

                    crystalReportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void IteamReport_Leave(object sender, EventArgs e)
        {
            crystalReportViewer1.Dispose();
            

        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {

        }

        private void IteamReport_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
