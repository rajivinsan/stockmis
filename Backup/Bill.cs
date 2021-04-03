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
    public partial class Bill : Form
    {
        int cnt = 0;
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection1 = new AutoCompleteStringCollection();
        public Bill()
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            
            try
            {
            if (dataGridView1.SelectedCells.Count >= 1)
            {
                countproduct();
                while (cnt < 23)
                {
                    OleDbCommand cmdsave = new OleDbCommand("insert into bill(Billno)values(@Billno)", con);
                    cmdsave.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0+textBox1.Text);
                    //cmdsave.Parameters.Add("@pqty", OleDbType.VarChar, 100).Value = "";
                    //cmdsave.Parameters.Add("@prate", OleDbType.VarChar, 100).Value = "";
                    //cmdsave.Parameters.Add("@pamount", OleDbType.VarChar, 100).Value = "";

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdsave.ExecuteNonQuery();
                    cmdsave.Parameters.Clear();
                    cmdsave.Dispose();
                    con.Close();
                    cnt = cnt + 1;
                }

                OleDbCommand cmdupdate = new OleDbCommand("update bill set cname=@cname, caddress=@caddress, ccontact=@ccontact, ccity=@ccity,ctinno=@ctinno, bdate=@bdate,grno=@grno, transport=@transport, vat=@vat, vatamount=@vatamount, DISCOUNT=@DISCOUNT, grandtotal=@grandtotal, inwords=@inwords, billtype=@billtype, ctintype=@ctintype, rtype=@rtype, refno=@refno, rdate=@rdate, ramount=@ramount  where billno=@billno", con);

                cmdupdate.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = comboBox1.Text;
                cmdupdate.Parameters.Add("@caddress", OleDbType.VarChar, 100).Value = textBox2.Text;
                cmdupdate.Parameters.Add("@ccontact", OleDbType.VarChar, 100).Value = textBox3.Text;
                cmdupdate.Parameters.Add("@ccity", OleDbType.VarChar, 100).Value = textBox19.Text;
                cmdupdate.Parameters.Add("@ctinno", OleDbType.VarChar, 100).Value = textBox4.Text;
                cmdupdate.Parameters.Add("@bdate", OleDbType.Date).Value = dateTimePicker1.Text;
                cmdupdate.Parameters.Add("@grno", OleDbType.VarChar, 100).Value = textBox6.Text;
                cmdupdate.Parameters.Add("@transport", OleDbType.VarChar, 100).Value = textBox5.Text;
                //cmdsave.Parameters.Add("@pname", OleDbType.VarChar, 100).Value = textBox7.Text;
                //cmdsave.Parameters.Add("@pqty", OleDbType.Double).Value = Convert.ToDouble(0 + comboBox3.Text);
                //cmdsave.Parameters.Add("@pqtype", OleDbType.VarChar, 100).Value = textBox9.Text;
                //cmdsave.Parameters.Add("@prate", OleDbType.Double).Value = Convert.ToDouble(0 + textBox10.Text);
                //cmdsave.Parameters.Add("@pamount", OleDbType.Double).Value = Convert.ToDouble(0 + textBox12.Text);


                cmdupdate.Parameters.Add("@vat", OleDbType.Double).Value = Convert.ToDouble(0 + textBox11.Text);
                cmdupdate.Parameters.Add("@vatamount", OleDbType.Double).Value = Convert.ToDouble(0 + textBox14.Text) * Convert.ToDouble(0 + textBox11.Text) / 100;
                cmdupdate.Parameters.Add("@DISCOUNT", OleDbType.Double).Value = Convert.ToDouble(0 + textBox13.Text);
                cmdupdate.Parameters.Add("@grandtotal", OleDbType.VarChar, 100).Value = textBox15.Text;

                cmdupdate.Parameters.Add("@inwords", OleDbType.VarChar, 100).Value = textBox16.Text;
                cmdupdate.Parameters.Add("@billtype", OleDbType.VarChar, 100).Value = "final";
                //cmdsave.Parameters.Add("@CCITY", OleDbType.VarChar, 100).Value = textBox19.Text;
                //cmdsave.Parameters.Add("@CTINTYPE", OleDbType.VarChar, 100).Value = label4.Text;
                cmdupdate.Parameters.Add("@CTINTYPE", OleDbType.VarChar, 100).Value = label4.Text;
                cmdupdate.Parameters.Add("@rtype", OleDbType.VarChar, 100).Value = cmbtype.Text;
                cmdupdate.Parameters.Add("@refno", OleDbType.VarChar, 100).Value = txtref.Text;
                cmdupdate.Parameters.Add("@rdate", OleDbType.VarChar, 100).Value = dateTimePicker2.Text;
                cmdupdate.Parameters.Add("@ramount", OleDbType.VarChar, 100).Value = txtamount.Text;
                cmdupdate.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + textBox1.Text);
                
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdupdate.ExecuteNonQuery();

                cmdupdate.Parameters.Clear();
                cmdupdate.Dispose();
                con.Close();
                MessageBox.Show("Bill Saved Successfully");
                //Cleartextbox();
                //ShowCustomer();
                //ShowProducts();
                //Maxbillno();
                //ShowBillItems();

            }
            else
            {
                MessageBox.Show("Please add Product first ");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Cleartextbox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            //textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "0";
            textBox12.Text = "";
            textBox13.Text = "0";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            txtamount.Text = "";
            txtref.Text = "";
        }
        public string NumberToText(int number)
        {
            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ", 
"Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", 
"Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", 
"Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] = number % 1000; // units 
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands 
            num[3] = number / 10000000; // crores 
            num[2] = num[2] - 100 * num[3]; // lakhs 
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones 
                t = num[i] / 10;
                h = num[i] / 100; // hundreds 
                t = t - 10 * h; // tens 
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Text = DateTime.Now.ToShortDateString();
            clearbillno();
            Maxbillno();
            
            
            autocompleteproduct();
            autocomplete();
            ShowCustomer();
            ShowProducts();
            
        }

        private void clearbillno()
        {
            OleDbCommand cmdupdatebillno = new OleDbCommand("update bill set billno=@billno where cname='AAA'", con);
            cmdupdatebillno.Parameters.Add("@billno", OleDbType.VarChar, 100).Value = "0";
            //cmdupdatebillno.Parameters.Add("@discount", OleDbType.Integer).Value = Convert.ToInt32(count);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmdupdatebillno.ExecuteNonQuery();
            cmdupdatebillno.Parameters.Clear();
            cmdupdatebillno.Dispose();
        }

        private void ShowCustomer()
        {
            
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from Customer order by cname", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            
            comboBox1.DisplayMember = "cname";
            comboBox1.ValueMember ="cid";
            comboBox1.DataSource = ds1.Tables[0];
            //comboBox1.SelectedValue = 9;
        }

        private void Maxbillno()
        {
            OleDbDataAdapter ad3 = new OleDbDataAdapter("Select max(billno)+1 from bill", con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            textBox1.Text = ds3.Tables[0].Rows[0][0].ToString();
        }

        private void ShowProducts()
        {
            
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select pid, pname+' '+pcolor+' '+psize as Products, psize, pcolor, pprice, pcase from Products order by pid", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            comboBox2.DisplayMember = "products";
            comboBox2.ValueMember = "pid";
            comboBox2.DataSource = ds1.Tables[0];
            //comboBox2.SelectedValue = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count >= 1 && comboBox1.SelectedIndex != -1 && comboBox1.SelectedValue != null)
            {

                //MessageBox.Show(comboBox1.SelectedValue.ToString());
                OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from Customer where cid=@cid", con);
                ad2.SelectCommand.Parameters.Add("@cid", OleDbType.Integer).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                //MessageBox.Show(comboBox1.SelectedValue.ToString());
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                //textBox1.Text = ds1.Tables[0].Rows[0][1].ToString();
                textBox2.Text = ds2.Tables[0].Rows[0][2].ToString();
                textBox3.Text = ds2.Tables[0].Rows[0][3].ToString();
                textBox4.Text = ds2.Tables[0].Rows[0][4].ToString();
                textBox5.Text = ds2.Tables[0].Rows[0]["transport"].ToString();
                label4.Text = ds2.Tables[0].Rows[0]["tintype"].ToString();
                textBox19.Text = ds2.Tables[0].Rows[0]["city"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                
                {
                    OleDbCommand cmdDellItem1 = new OleDbCommand("delete from bill  WHERE billno=@billno and pname is null", con);
                    cmdDellItem1.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + textBox1.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdDellItem1.ExecuteNonQuery();

                    cmdDellItem1.Parameters.Clear();
                    cmdDellItem1.Dispose();
                    con.Close();
                }
                    OleDbCommand cmdsave = new OleDbCommand("insert into bill(Billno,cname,caddress,ccontact,ctinno,bdate,grno,transport,pname,pqty,pqtype,prate,pamount,billtype,PCASE,QPC,PSIZE,PCOLOR,CCITY,CTINTYPE)values(@Billno,@cname,@caddress,@ccontact,@ctinno,@bdate,@grno,@transport,@pname,@pqty,@pqtype,@prate,@pamount,@billtype,@PCASE,@QPC,@PSIZE,@PCOLOR,@CCITY,@CTINTYPE)", con);
                    cmdsave.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + textBox1.Text);
                    cmdsave.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = comboBox1.Text;
                    cmdsave.Parameters.Add("@caddress", OleDbType.VarChar, 100).Value = textBox2.Text;
                    cmdsave.Parameters.Add("@ccontact", OleDbType.VarChar, 100).Value = textBox3.Text;
                    cmdsave.Parameters.Add("@ctinno", OleDbType.VarChar, 100).Value = textBox4.Text;
                    cmdsave.Parameters.Add("@bdate", OleDbType.Date).Value = dateTimePicker1.Text;
                    cmdsave.Parameters.Add("@grno", OleDbType.VarChar, 100).Value = textBox6.Text;
                    cmdsave.Parameters.Add("@transport", OleDbType.VarChar, 100).Value = textBox5.Text;
                    cmdsave.Parameters.Add("@pname", OleDbType.VarChar, 100).Value = label24.Text;
                    cmdsave.Parameters.Add("@pqty", OleDbType.Double).Value = Convert.ToDouble(0 + textBox17.Text);
                    cmdsave.Parameters.Add("@pqtype", OleDbType.VarChar, 100).Value = "Doz/pair";
                    cmdsave.Parameters.Add("@prate", OleDbType.Double).Value = Convert.ToDouble(0 + textBox18.Text);
                    cmdsave.Parameters.Add("@pamount", OleDbType.Double).Value = Convert.ToDouble(0 + textBox10.Text);
                    cmdsave.Parameters.Add("@billtype", OleDbType.VarChar, 100).Value = "Product";
                    cmdsave.Parameters.Add("@pcase", OleDbType.Double).Value = Convert.ToDouble(0 + comboBox3.Text);
                    cmdsave.Parameters.Add("@qpc", OleDbType.Double).Value = Convert.ToDouble(0 + label22.Text);
                    cmdsave.Parameters.Add("@psize", OleDbType.VarChar, 100).Value = textBox7.Text;
                    cmdsave.Parameters.Add("@pcolor", OleDbType.VarChar, 100).Value = textBox9.Text;
                    cmdsave.Parameters.Add("@ccity", OleDbType.VarChar, 100).Value = textBox19.Text;
                    cmdsave.Parameters.Add("@CTINTYPE", OleDbType.VarChar, 100).Value = label4.Text;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdsave.ExecuteNonQuery();
                    cmdsave.Parameters.Clear();
                    cmdsave.Dispose();
                    con.Close();
                    //MessageBox.Show("Data Added Successfully");
                    calc_amount();
                    Showbalance();
                    calc_tax();

                    //gridview display
                    ShowBillItems();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            
            //Showcustomer();
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
        }

        private void calc_amount()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select sum(pamount) from bill where billno=@billno", con);
            ad1.SelectCommand.Parameters.Add("@billno", OleDbType.Integer).Value = Convert.ToInt32(textBox1.Text);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            textBox12.Text = ds1.Tables[0].Rows[0][0].ToString();
        }

        private void ShowBillItems()
        {
            OleDbDataAdapter ad4 = new OleDbDataAdapter("Select pname as PRODUCT, pcolor as P_COLOR,PSIZE AS P_SIZE,PRATE AS RATE,PCASE AS T_CASE,QPC AS QTY_P_CASE,pqty as T_QTY,pamount as AMOUNT, bid  from bill where billno=@billno and pamount>0 order by bid", con);
            ad4.SelectCommand.Parameters.Add("@billno", OleDbType.Integer).Value = Convert.ToInt32(textBox1.Text);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            dataGridView1.DataSource = ds4.Tables[0];

            
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 60;
            
            if (dataGridView1.Rows.Count >= 23)
            {
                MessageBox.Show("You have added " + dataGridView1.Rows.Count + " Product. Please Make another Bill");
            }
            //MessageBox.Show(cnt.ToString());

            OleDbDataAdapter ad11 = new OleDbDataAdapter("Select sum(pcase) from bill where billno=@billno", con);
            ad11.SelectCommand.Parameters.Add("@billno", OleDbType.Integer).Value = Convert.ToInt32(textBox1.Text);
            DataSet ds11 = new DataSet();
            ad11.Fill(ds11);
            label28.Text = ds11.Tables[0].Rows[0][0].ToString();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            calc_tax();
        }

        private void countproduct()
        {
            OleDbDataAdapter ad5 = new OleDbDataAdapter("Select pname as PRODUCT, pcolor as P_COLOR,PSIZE AS P_SIZE,PRATE AS RATE,PCASE AS T_CASE,QPC AS QTY_P_CASE,pqty as T_QTY,pamount as AMOUNT, bid  from bill where billno=@billno order by bid", con);
            ad5.SelectCommand.Parameters.Add("@billno", OleDbType.Integer).Value = Convert.ToInt32(textBox1.Text);
            DataSet ds5 = new DataSet();
            ad5.Fill(ds5);
            cnt = ds5.Tables[0].Rows.Count;
            
        }

        private void calc_tax()
        {
            textBox15.Text = (Math.Round((Convert.ToDouble(0 + textBox14.Text) * Convert.ToDouble(0 + textBox11.Text) / 100) + (Convert.ToDouble(0 + textBox14.Text)), 0)).ToString();
            textBox16.Text = NumberToText(Convert.ToInt32(Math.Round(Convert.ToDouble(textBox15.Text))))+" Only";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            Showbalance();
            calc_tax();
        }

        private void Showbalance()
        {
            try
            {
                textBox14.Text = (Convert.ToDouble(0 + textBox12.Text) - (Convert.ToDouble(0 + textBox12.Text) * Convert.ToDouble(0 + textBox13.Text) / 100)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 1)
            {
                try
                {
                    OleDbCommand cmdBillClear = new OleDbCommand("update bill set billprint='N'", con);
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

                    OleDbCommand cmdBillYes = new OleDbCommand("update bill set billprint='Y' WHERE billno=@billno", con);
                    cmdBillYes.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + textBox1.Text);
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count >= 1 && comboBox2.SelectedIndex != -1 && comboBox2.SelectedValue!=null)
            {
                OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from Products where pid=@pid", con);
                ad2.SelectCommand.Parameters.Add("@pid", OleDbType.Integer).Value = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                //MessageBox.Show(comboBox1.SelectedValue.ToString());
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                //textBox1.Text = ds1.Tables[0].Rows[0][1].ToString();
                textBox7.Text = ds2.Tables[0].Rows[0]["psize"].ToString();
                textBox9.Text = ds2.Tables[0].Rows[0]["pcolor"].ToString();
                textBox18.Text = ds2.Tables[0].Rows[0]["pprice"].ToString();
                label22.Text = ds2.Tables[0].Rows[0]["pcase"].ToString();
                label24.Text = ds2.Tables[0].Rows[0]["pname"].ToString();
                calc_price();
               
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox17.Text = (Convert.ToDouble(0+label22.Text) * Convert.ToDouble(0+comboBox3.Text)).ToString() ;
            textBox10.Text = (Convert.ToDouble(0 + textBox18.Text) * Convert.ToDouble(0 + textBox17.Text)).ToString();
        }

        private void Bill_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 1)
            {
                OleDbCommand cmdDellItem = new OleDbCommand("delete from bill  WHERE bid=@bid", con);
                cmdDellItem.Parameters.Add("@bid", OleDbType.Integer).Value = Convert.ToInt32("0" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["bid"].Value.ToString());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdDellItem.ExecuteNonQuery();

                cmdDellItem.Parameters.Clear();
                cmdDellItem.Dispose();
                con.Close();
                ShowBillItems();
                calc_amount();
                Showbalance();
                calc_tax();
                cnt = cnt - 1;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            calc_price();
        }

        private void calc_price()
        {
            textBox17.Text = (Convert.ToDouble(0 + label22.Text) * Convert.ToDouble(0 + comboBox3.Text)).ToString();
            textBox10.Text = (Convert.ToDouble(0 + textBox18.Text) * Convert.ToDouble(0 + textBox17.Text)).ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            Showbalance();
            calc_tax();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        

        private void autocomplete()
        {
            OleDbCommand cmd = new OleDbCommand("Select distinct cname from customer order by cname asc", con);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader dr;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    namesCollection.Add(dr["cname"].ToString());
            }
            con.Close();

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteCustomSource = namesCollection;
        }
        private void autocompleteproduct()
        {
            OleDbCommand cmd = new OleDbCommand("Select distinct pname+' '+pcolor+' '+psize as pname from products order by 1 asc", con);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader dr;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    namesCollection1.Add(dr["pname"].ToString());
            }
            con.Close();

            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox2.AutoCompleteCustomSource = namesCollection1;
        }

        private void Bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            OleDbCommand cmdDelete = new OleDbCommand("delete from bill WHERE billtype=@billtype", con);
            //cmdDelete.Parameters.Add("@bid", OleDbType.Integer).Value = Convert.ToInt32("0" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["bid"].Value.ToString());
            cmdDelete.Parameters.Add("@billtype", OleDbType.VarChar, 100).Value = "Product";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmdDelete.ExecuteNonQuery();

            cmdDelete.Parameters.Clear();
            cmdDelete.Dispose();
            con.Close();
        }

       

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                OleDbDataAdapter ad3 = new OleDbDataAdapter("Select * from bill where billno=@billno", con);
                ad3.SelectCommand.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + textBox1.Text);
                DataSet ds3 = new DataSet();
                ad3.Fill(ds3);
                if (ds3.Tables[0].Rows.Count >= 1)
                {
                    comboBox1.Text = ds3.Tables[0].Rows[0]["cname"].ToString(); 
                    textBox2.Text = ds3.Tables[0].Rows[0]["caddress"].ToString();
                    textBox19.Text = ds3.Tables[0].Rows[0]["ccity"].ToString();
                    textBox5.Text = ds3.Tables[0].Rows[0]["transport"].ToString();
                    textBox3.Text = ds3.Tables[0].Rows[0]["ccontact"].ToString();
                    textBox4.Text = ds3.Tables[0].Rows[0]["ctinno"].ToString();
                    textBox6.Text = ds3.Tables[0].Rows[0]["grno"].ToString();
                    dateTimePicker1.Text = ds3.Tables[0].Rows[0]["bdate"].ToString();
                    textBox13.Text = ds3.Tables[0].Rows[0]["discount"].ToString();
                    textBox11.Text = ds3.Tables[0].Rows[0]["vat"].ToString();
                   
                    ShowBillItems();
                    calc_amount(); 
                    Showbalance();
                    calc_tax();
                }
                else
                {
                    MessageBox.Show("No Record Found");
                }

                
            }
        }

        

       
    }
}
