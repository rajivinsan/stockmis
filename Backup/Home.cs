using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ImperialPlastics
{
    public partial class Home : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        public Home()
        {
            InitializeComponent();
            con.ConnectionString = cn.connectionstring;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Form childFormcst = new Products();
            //childFormcst.Parent = this.Parent;
            childFormcst.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form cfcreatebill = new Bill();
            //cfcreatebill.Parent = this.Parent;
            cfcreatebill.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cfdisplaybill = new ShowBill();
            //cfdisplaybill.Parent = this.Parent;
            cfdisplaybill.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form childFormcst = new Customers();
            //childFormcst.Parent = this.Parent;
            childFormcst.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            String str= Microsoft.VisualBasic.Interaction.InputBox("Enter Bill No.","Print Bill","61",500,300);
            if (str != "")
            {

                OleDbCommand cmdBillClear = new OleDbCommand("update bill set billprint='N'", con);
                cmdBillClear.Parameters.Add("@billno", OleDbType.VarChar, 100).Value = str;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdBillClear.ExecuteNonQuery();
                cmdBillClear.Parameters.Clear();
                cmdBillClear.Dispose();
               
                
                OleDbCommand cmdBillYes = new OleDbCommand("update bill set billprint='Y' WHERE billno=@billno", con);
                cmdBillYes.Parameters.Add("@billno", OleDbType.VarChar, 100).Value = str;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdBillYes.ExecuteNonQuery();

                cmdBillYes.Parameters.Clear();
                cmdBillYes.Dispose();
                con.Close();
                Form cffrmReports = new frmReports();
                cffrmReports.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form createbill = new frmpayment();
            //cfcreatebill.Parent = this.Parent;
            createbill.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Form createbill = new Purchased();
            //cfcreatebill.Parent = this.Parent;
            createbill.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form createbill = new Payment();
            //cfcreatebill.Parent = this.Parent;
            createbill.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form createbill = new Purchased();
            //cfcreatebill.Parent = this.Parent;
            createbill.Show();

        }

        
    }
}
