﻿using System;
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

    public partial class SaleRegister : Form
    {
        
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;

        public SaleRegister()
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
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT Stock.PID, Stock.PDATE as [Date], Stock.HSNCode, Item_Mas.Item_Name as [Item Name], Stock.QUANTITY as [Qty], Stock.Sale_Rate as [Sale Rate], Stock.Taxrate as [Tax Slab], Purchase_Party.PName FROM(Stock INNER JOIN Item_Mas ON Stock.item_code = Item_Mas.Item_code) INNER JOIN Purchase_Party ON Stock.PURCHASE_From = Purchase_Party.PID where where stock.date>=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and stock.pdate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "#", con);
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
            

            String qry = "SELECT BILL.BILLNO as [Bill No], BILL.BDATE as [Date], customer.CNAME as [Party], BILL.Qty as [Saled Qty], Stock.QUANTITY as [Avl Qty], Item_Mas.Item_Name as [Item Name], BILL.Rate as [Rate], BILL.Idiscount as [Discount], BILL.taxrate as [Tax Slab],(bill.total-BILL.Idiscount) as [Amount],Bill.TaxAmount FROM((BILL INNER JOIN Stock ON BILL.Pid = Stock.PID) INNER JOIN customer ON BILL.CID = customer.CID) INNER JOIN Item_Mas ON Stock.item_code = Item_Mas.Item_code where bill.bdate >=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and bill.bdate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "# order by bill.billno";
            OleDbDataAdapter adp = new OleDbDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
            adp.Dispose();
            dataGridView1.Columns[0].Width = dataGridView1.Width / 15;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 12;
            dataGridView1.Columns[2].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[3].Width = dataGridView1.Width / 14;
            dataGridView1.Columns[4].Width = dataGridView1.Width / 14;
            dataGridView1.Columns[5].Width = dataGridView1.Width / 6;
            dataGridView1.Columns[6].Width = dataGridView1.Width / 14;
            dataGridView1.Columns[7].Width = dataGridView1.Width / 14;
            dataGridView1.Columns[8].Width = dataGridView1.Width / 13;
            dataGridView1.Columns[9].Width = dataGridView1.Width / 12;
            dataGridView1.Columns[10].Width = dataGridView1.Width / 15;




        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double pamount, samount, tamount;
            pamount = samount = tamount = 0;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                pamount = pamount + Convert.ToDouble("0" + dr.Cells["Amount"].Value);
                //samount = samount + Convert.ToDouble("0" + dr.Cells["Sale Amt"].Value);
                tamount = tamount + Convert.ToDouble("0" + dr.Cells["TaxAmount"].Value);

            }
            txtPurAmount.Text = pamount.ToString();
            txtSaleAmount.Text = tamount.ToString();
            txtPamount.Text = (tamount + pamount).ToString();
        }
    } 

        


}