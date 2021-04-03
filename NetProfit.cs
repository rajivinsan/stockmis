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

    public partial class NetProfit : Form
    {
        
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;

        public NetProfit()
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void ShowStock()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT Stock.PID, Stock.PDATE as [Date], Stock.HSNCode, Item_Mas.Item_Name as [Item Name], Stock.QUANTITY as [Qty], Stock.Sale_Rate as [Sale Rate], Stock.Taxrate as [Tax Slab], Purchase_Party.PName FROM(Stock INNER JOIN Item_Mas ON Stock.item_code = Item_Mas.Item_code) INNER JOIN Purchase_Party ON Stock.PURCHASE_From = Purchase_Party.PID", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 200;
            ds1.Dispose();
            ad1.Dispose();


        }
        
       
        
        
        private void count()
        {
           
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            String qry = "Select Bdate as [Date],Billno as [Bill No],round(sum(purchase_rate * qty),2) as [Purchase Amount] ,round(sum(Total - Idiscount),2) as [Sale Amt],round(([Sale Amt]) - sum(purchase_rate * qty),2) as [Net Profit],sum(taxamount) as [Tax Amount] from bill  where bdate>=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and bdate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "# group by Bdate ,Billno , (Totalamount)  order by billno";
            OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
            adp.Dispose();
            dataGridView1.Columns[0].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[5].Width = dataGridView1.Width / 6;

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double pamount , samount ,tamount ;
            pamount = samount = tamount = 0;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                pamount = pamount+ Convert.ToDouble("0"+dr.Cells["Purchase Amount"].Value);
                samount =samount+  Convert.ToDouble("0" + dr.Cells["Sale Amt"].Value);
                tamount = tamount+ Convert.ToDouble("0" + dr.Cells["Tax Amount"].Value);

            }
            txtPurAmount.Text = pamount.ToString();
            txtSaleAmount.Text = samount.ToString();
            txtPamount.Text = (samount - pamount).ToString();
            txtTaxamount.Text = tamount.ToString();
        }
    } 

        


}