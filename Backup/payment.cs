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
    public partial class Payment : Form
    {
        OleDbConnection con = new OleDbConnection();
        connection cn = new connection();
        public Payment()
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }
        public void showcust()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select cname, cid from customer where ctype='Creditor' ", con);

            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            cmbname.DisplayMember = "cname";
            cmbname.ValueMember = "cid";
            cmbname.DataSource = ds1.Tables[0];

        }


        public void showbillno()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select max(id)+1 from payments ", con);

            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            //dataGridView1.DataSource = ds1.Tables[0];
            txtid.Text = ds1.Tables[0].Rows[0][0].ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmdsave = new OleDbCommand("insert into payments(Pname, ptype, pdate,refno, amount, TRNTYPE)values(@Pname, @ptype, @pdate, @refno, @amount, @TRNTYPE)", con);

            cmdsave.Parameters.Add("@Pname", OleDbType.VarChar, 100).Value = cmbname.SelectedValue.ToString();
            cmdsave.Parameters.Add("@ptype", OleDbType.VarChar, 100).Value = txttype.Text;
            cmdsave.Parameters.Add("@pdate", OleDbType.VarChar, 100).Value = DateTime.Now.ToShortTimeString();
            cmdsave.Parameters.Add("@refno", OleDbType.VarChar, 100).Value = txtrefno.Text;
            cmdsave.Parameters.Add("@amount", OleDbType.VarChar, 100).Value = txtamount.Text;
            cmdsave.Parameters.Add("@TRNTYPE", OleDbType.VarChar, 100).Value = CMBTYPE1.Text;



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
            Showcustomer();
            showbillno();

            //gridview display

        }


        private void Showcustomer()
        {
            if (cmbname.Items.Count >= 1 && cmbname.SelectedIndex != -1 && cmbname.SelectedValue != null)
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select p.id as [TRN ID], c.cname as [PARTY NAME], p.REFNO AS [REFERENCE NO], p.ptype as  [PAYMENT TYPE],  p.Amount as AMOUNT, p.trntype as[TRN TYPE] from PAYMENTS as p, customer as c  where cint(p.pname)=c.cid and p.pname=@pname  ", con);
                ad1.SelectCommand.Parameters.Add("@pname", OleDbType.VarChar, 100).Value = cmbname.SelectedValue.ToString();
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
            }



        }





        public void clear()
        {
            txtamount.Text = "";
            txttype.Text = "";
            txtrefno.Text = "";
          
            CMBTYPE1.Text = "Purchase";




        }



        private void Payment_Load_1(object sender, EventArgs e)
        {
            Showcustomer();
            showbillno();
            showcust();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OleDbCommand cmdupdate = new OleDbCommand("update PAYMENTS set pname=@Pname, PTYPE=@PTYPE, PDATE=@PDATE, REFNO=@REFNO, amount=@amount,trntype=@trntype where ID=@ID", con);

            cmdupdate.Parameters.Add("@Pname", OleDbType.VarChar, 100).Value = cmbname.Text;
            cmdupdate.Parameters.Add("@PTYPE", OleDbType.VarChar, 100).Value = txttype.Text;
            cmdupdate.Parameters.Add("@PDATE", OleDbType.VarChar, 100).Value = DateTime.Now.ToShortTimeString();
            cmdupdate.Parameters.Add("@REFNO", OleDbType.VarChar, 100).Value = txtrefno.Text;
            cmdupdate.Parameters.Add("@AMOUNT", OleDbType.VarChar, 100).Value = txtamount.Text;
            cmdupdate.Parameters.Add("@trntype", OleDbType.VarChar, 100).Value = CMBTYPE1.Text;
            cmdupdate.Parameters.Add("@ID", OleDbType.VarChar, 100).Value = label4.Text;




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
            showbillno();


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OleDbCommand cmddel = new OleDbCommand("delete from PAYMENTS where id=@id", con);

            cmddel.Parameters.Add("@id", OleDbType.VarChar, 100).Value = label4.Text;



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
            showbillno();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtrefno.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtamount.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                CMBTYPE1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txttype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from PAYMENTS where id=@id ", con);
                ad1.SelectCommand.Parameters.Add("@id", OleDbType.Integer).Value = Convert.ToInt32(txtid.Text.ToString());
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
               label4.Text = ds1.Tables[0].Rows[0]["id"].ToString();
   txtid.Text = ds1.Tables[0].Rows[0]["id"].ToString();
                cmbname.Text = ds1.Tables[0].Rows[0]["pname"].ToString();
                txttype.Text = ds1.Tables[0].Rows[0]["ptype"].ToString();
                txtamount.Text = ds1.Tables[0].Rows[0]["amount"].ToString();
                dateTimePicker1.Text = ds1.Tables[0].Rows[0]["pdate"].ToString();
                txtrefno.Text = ds1.Tables[0].Rows[0]["refno"].ToString();
                CMBTYPE1.Text = ds1.Tables[0].Rows[0]["trntype"].ToString();


            }





        }

        private void CMBTYPE1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBTYPE1.Text == "Purchase")
            {
                txttype.Enabled = false;
                txttype.Text = "";
            }
            else
            {
                txttype.Enabled = true;
                txttype.Text = "By Cash";

            }

        }

        private void cmbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbname.Items.Count >= 1 && cmbname.SelectedIndex != -1 && cmbname.SelectedValue != null)
            {
                Showcustomer();
                Showbalance();
            }
        }

        private void Showbalance()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select  (t1.amount1)-(t2.amount2) as Balance from (select sum(amount ) as amount1 from payments where trntype='purchase' and pname=@pname) as t1  , (select sum(amount) as amount2  from payments where trntype='Payment' and pname=@pname ) as t2 ", con);
            ad1.SelectCommand.Parameters.Add("@pname", OleDbType.VarChar, 100).Value = cmbname.SelectedValue.ToString();
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            label9.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
    }
}

