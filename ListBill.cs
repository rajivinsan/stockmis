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
    public partial class ListBill : Form
    {
        String companyid = "";
         connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        public ListBill(String compid)
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
            this.Close();
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
            String qry = "";
            if (checkBox1.Checked == false)
            { qry = "SELECT  Billno,Cname,TotalAmount,Taxamount,totDiscount,Gtotal from Bill where bdate>=#" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "# and bdate<=#" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "# group by Billno,Cname,TotalAmount,Taxamount,totDiscount,Gtotal order by billno"; }
            else { qry = "SELECT  bdate,Billno,Cname,TotalAmount,Taxamount,totDiscount,Gtotal from Bill group by bdate,Billno,Cname,TotalAmount,Taxamount,totDiscount,Gtotal order by bdate,billno"; }
            dataGridView1.Columns.Clear();
            OleDbDataAdapter ad1 = new OleDbDataAdapter(qry, con);

            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            ds1.Dispose();
            ad1.Dispose();

            //Add a CheckBox Column to the DataGridView Header Cell.
            CheckBox headerCheckBox = new CheckBox();
    //Find the Location of Header Cell.
    Point headerCellLocation = this.dataGridView1.GetCellDisplayRectangle(0, -1, true).Location;
 
    //Place the Header CheckBox in the Location of the Header Cell.
    headerCheckBox.Location = new Point(headerCellLocation.X + 60, headerCellLocation.Y + 2);
    //headerCheckBox.BackColor = Color.White;
    headerCheckBox.Size = new Size(18, 18);
 
    //Assign Click event to the Header CheckBox.
    headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
    dataGridView1.Controls.Add(headerCheckBox);
 
    





             DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

            checkbox.HeaderText = "Select All";
            checkbox.Width = 30;
            checkbox.Name = "Checkbox";
            dataGridView1.Columns.Insert(0, checkbox);

            foreach (DataGridViewColumn dr in dataGridView1.Columns)
            {
                dr.Width = dataGridView1.Width / dataGridView1.ColumnCount;
            
            }




        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            
            CheckBox headerCheckBox = new CheckBox();
            //Necessary to end the edit mode of the Cell.
            dataGridView1.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Boolean Selected = Convert.ToBoolean(row.Cells["checkbox"].Value);
                if (Selected)
                {
                    row.Cells["checkbox"].Value = false;
                }
                else { row.Cells["checkbox"].Value = true; }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
          
           
          
         
            
           
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            String Id="";
            if (dataGridView1.SelectedCells.Count >= 1)
            {
                String message = string.Empty;
                foreach (DataGridViewRow rows in dataGridView1.Rows)
                {
                    Boolean Selected = Convert.ToBoolean(rows.Cells["checkbox"].Value);
                    if (Selected)
                    {
                        message = message + rows.Cells["billno"].Value + ",";
                    }
                }
                Id= message.Substring(0, message.Length - 1);
            }

            printRpt(Id);

        }
        void printRpt(string billno)
        {

            if (dataGridView1.Rows.Count >= 1)
            {
                try
                {
                    OleDbCommand cmdBillClear = new OleDbCommand("update bill set print=null", con);
                    //cmdBillClear.Parameters.Add("@billno", OleDbType.VarChar, 100).Value = "441818";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdBillClear.ExecuteNonQuery();

                    cmdBillClear.Parameters.Clear();
                    cmdBillClear.Dispose();

                    //OleDbDataAdapter adcount = new OleDbDataAdapter("Select * from bill where billno=@billno and billtype=@billtype", con);
                    //adcount.SelectCommand.Parameters.Add("@billno", OleDbType.Integer).Value = Convert.ToInt32(textBox1.Text);
                    //adcount.SelectCommand.Parameters.Add("@billtype", OleDbType.VarChar, 100).Value = "final";
                    //DataSet dscount = new DataSet();
                    //adcount.Fill(dscount);
                    //String count = dscount.Tables[0].Rows.Count.ToString();
                    //count = (23 - Convert.ToInt32(count)).ToString();
                    ////MessageBox.Show(count);

                    //OleDbCommand cmdupdatebillno = new OleDbCommand("update bill set billno=@billno where cname='AAA' and discount<=@discount", con);
                    //cmdupdatebillno.Parameters.Add("@billno", OleDbType.VarChar, 100).Value = textBox1.Text;
                    //cmdupdatebillno.Parameters.Add("@discount", OleDbType.Integer).Value = Convert.ToInt32(count);
                    //if (con.State == ConnectionState.Closed)
                    //{
                    //    con.Open();
                    //}
                    //cmdupdatebillno.ExecuteNonQuery();
                    //cmdupdatebillno.Parameters.Clear();
                    //cmdupdatebillno.Dispose();

                    OleDbCommand cmdBillYes = new OleDbCommand("update bill set print='Y' WHERE billno in("+billno+") ", con);
                    //cmdBillYes.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + txtEnterQty.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdBillYes.ExecuteNonQuery();

                    cmdBillYes.Parameters.Clear();
                    cmdBillYes.Dispose();
                    con.Close();
                    Form cffrmReports = new IteamReport("");

                    cffrmReports.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
