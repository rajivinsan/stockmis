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
    public partial class Purchased : Form
    { 
        OleDbConnection con = new OleDbConnection();
    connection cn = new connection();
        public Purchased()
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }

        private void Purchased_Load(object sender, EventArgs e)
        {
            Showcustomer();
            showbillno();
            showcust();

        }
        public void showbillno()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select max(bid)+1 from bill " , con);
           
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            txtbno.Text = ds1.Tables[0].Rows[0][0].ToString();
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmdsave = new OleDbCommand("insert into bill(cname,ttype, rtype, refno,rdate, ramount)values(@cname,@ttype,@rtype, @refno, @rdate, @ramount)", con);
            cmdsave.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = cmbname.Text;
            cmdsave.Parameters.Add("@ttype", OleDbType.VarChar, 100).Value = cmbttype.Text;
            cmdsave.Parameters.Add("@rtype", OleDbType.VarChar, 100).Value = cmbtype.Text;
            cmdsave.Parameters.Add("@refno", OleDbType.VarChar, 100).Value = txtref.Text;
            cmdsave.Parameters.Add("@rdate", OleDbType.VarChar, 100).Value = DateTime.Now.ToShortTimeString();
            cmdsave.Parameters.Add("@ramount", OleDbType.VarChar, 100).Value = txtamount.Text;
            
           

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmdsave.ExecuteNonQuery();
            cmdsave.Parameters.Clear();
            cmdsave.Dispose();
            con.Close();
           MessageBox.Show("Data Added Successfully");
           clear();
           showcust();
           showbillno();
           Showcustomer();

            //gridview display
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            OleDbCommand cmddel = new OleDbCommand("delete from bill where bid=@bid" , con);

            cmddel.Parameters.Add("@bid", OleDbType.VarChar, 100).Value = label.Text;
           


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmddel.ExecuteNonQuery();
            cmddel.Parameters.Clear();
            cmddel.Dispose();
            con.Close();
            MessageBox.Show("Data Deleted Successfully");
            Showcustomer();
            showcust();
            showbillno();


        }

        private void Showcustomer()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select bid as[BILL ID], cname as NAME, RTYPE AS [RECEIVE TYPE], REFNO AS [REF NO], RAmount AS [AMOUNT] from bill WHERE CNAME=@CNAME AND TTYPE='Payment' ", con);
            ad1.SelectCommand.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = cmbname.Text;
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand cmdupdate = new OleDbCommand("update BILL set CNAME=@CNAME, TTYPE=@TTYPE, RTYPE=@RTYPE, REFNO=@REFNO,  RDATE=@RDATE, Ramount=@Ramount where bid=@bid", con);

            cmdupdate.Parameters.Add("@CNAME", OleDbType.VarChar, 100).Value = cmbname.Text;
            cmdupdate.Parameters.Add("@TTYPE", OleDbType.VarChar, 100).Value = cmbttype.Text;
            cmdupdate.Parameters.Add("@RTYPE", OleDbType.VarChar, 100).Value = cmbtype.Text;
            cmdupdate.Parameters.Add("@REFNO", OleDbType.VarChar, 100).Value = txtref.Text;
            cmdupdate.Parameters.Add("@RDATE", OleDbType.VarChar, 100).Value = DateTime.Now.ToShortTimeString();
            cmdupdate.Parameters.Add("@Ramount", OleDbType.VarChar, 100).Value = txtamount.Text;
            cmdupdate.Parameters.Add("@bid", OleDbType.VarChar, 100).Value = label.Text;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmdupdate.ExecuteNonQuery();
            cmdupdate.Parameters.Clear();
            cmdupdate.Dispose();
            con.Close();
            MessageBox.Show("Data updated Successfully");
            clear();
            Showcustomer();
            showcust();
            showbillno();


        }
       public void clear()
    {
        txtamount.Text = "";
        txtref.Text = "";
        cmbtype.Text = "By Cash";
       

      
    }

       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           if (e.RowIndex >= 0)
           {
               label.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
             cmbname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
               
               txtamount.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
               cmbtype.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
               txtref.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
              
              
           }

       }
       public void showcust()
       {
           OleDbDataAdapter ad1 = new OleDbDataAdapter("Select cname, cid from customer where ctype='Debtor' ", con);

           DataSet ds1 = new DataSet();
           ad1.Fill(ds1);
           cmbname.DisplayMember = "cname";
           cmbname.ValueMember = "cid";
           cmbname.DataSource = ds1.Tables[0];

       }

       private void cmbname_SelectedIndexChanged(object sender, EventArgs e)
       {
           Showcustomer();


       }

       private void txtbno_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from bill where bid=@bid ", con);
               ad1.SelectCommand.Parameters.Add("@bid", OleDbType.Integer).Value = Convert.ToInt32(txtbno.Text.ToString());
               DataSet ds1 = new DataSet();
               ad1.Fill(ds1);
               label.Text = ds1.Tables[0].Rows[0]["bid"].ToString();
               txtbno.Text = ds1.Tables[0].Rows[0]["bid"].ToString();
               cmbname.Text = ds1.Tables[0].Rows[0]["cname"].ToString();
               cmbtype.Text = ds1.Tables[0].Rows[0]["rtype"].ToString();
               cmbttype.Text = ds1.Tables[0].Rows[0]["ttype"].ToString();
               dateTimePicker2.Text = ds1.Tables[0].Rows[0]["rdate"].ToString();
               txtref.Text = ds1.Tables[0].Rows[0]["refno"].ToString();
               txtamount.Text = ds1.Tables[0].Rows[0]["ramount"].ToString();


           }

       }
    }
}
