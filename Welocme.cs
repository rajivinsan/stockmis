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
    public partial class Welcome : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        public Welcome()
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            //CalCash();
            TotalSale();
            TotalSaleinCredit();
            TotalSaleininCash();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void CalCash()
            {
            Double s = 0;

            String qry = "select Sum(Gtotal) as [Total] from bill where bid in(Select   Max(bid) from bill group by billno) and  bdate =#" + DateTime.Now.ToString("yyyy/MM/dd") + "# and Term='Cash'";
            OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                s = Convert.ToDouble("0" + ds.Tables[0].Rows[0]["Total"]);
            }
            ds.Dispose();
            adp.Dispose();

         
            OleDbDataAdapter adp1 = new OleDbDataAdapter("SELECT Sum(Paid) as [Total] FROM  payments where trndate =#" + DateTime.Now.ToString("yyyy/MM/dd") + "#", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                s = s + Convert.ToDouble("0" + ds1.Tables[0].Rows[0]["Total"]);
            }
            ds1.Dispose();
            adp1.Dispose();


            label2.Text = s.ToString();

        }
        private void TotalSale()
        {
            //String qry = "select Sum(Gtotal) as [Total] from bill where bid in(Select   Max(bid) from bill group by billno) and  bdate =#" + DateTime.Now.ToString("yyyy/MM/dd") + "#";
            String qry = "select count(*) as [Total] from stock ";
            OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltotalstock.Text = ds.Tables[0].Rows[0]["Total"].ToString();
            }
            ds.Dispose();
            adp.Dispose();
        }
        private void TotalSaleinCredit()
        {
            String qry = "select count(*) as [Total] from officemas";
            OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltotalps.Text = ds.Tables[0].Rows[0]["Total"].ToString();
            }
            ds.Dispose();
            adp.Dispose();
        }
        private void TotalSaleininCash()
        {
            String qry = "select count(*) as [Total] from Stock where issuedto is not null";
            OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltotalissued.Text = ds.Tables[0].Rows[0]["Total"].ToString();
            }
            ds.Dispose();
            adp.Dispose();
        }
    }
}
