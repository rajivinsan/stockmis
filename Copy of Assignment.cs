using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace ImperialPlastics
{
    public partial class Assignment : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;
        String pid;

        public Assignment()
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();
        }

        private void Assignment_Load(object sender, EventArgs e)
        {
            try
            {
                Iteam();
                GenrateBID();
                GenrateAID();
                txtdate.Text = DateTime.Now.ToShortDateString();
               
                getImages();
                txtdate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Iteam()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from OrderType_Mas", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpAType.DataSource = ds1.Tables[0];
            drpAType.DisplayMember = ds1.Tables[0].Columns["Type_name"].ToString();
            drpAType.ValueMember = ds1.Tables[0].Columns["Type_ID"].ToString();
            
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            getCustomer();

        }

        private String GenrateBID()
        {


            String id;

            OleDbCommand cmd = new OleDbCommand("select  Max(BID) from Booking", con);
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            id = cmd.ExecuteScalar().ToString();

            if (id != null && id != "")
            {
                GID = Convert.ToInt32(id) + 1;


            }
            else
            {
                GID = Convert.ToInt32("101");

            }
            lblID.Text = GID.ToString();

            return GID.ToString();

        }
        private void GenrateAID()
        {

            String id;

            OleDbCommand cmd = new OleDbCommand("select  Max(AID) from Booking", con);
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            id = cmd.ExecuteScalar().ToString();

            if (id != null && id != "")
            {
                LblAID.Text = (Convert.ToInt32(id) + 1).ToString();


            }
            else
            {
                LblAID.Text = (Convert.ToInt32("01")).ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                frmregistation reg = new frmregistation();
                DialogResult res = reg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtid.Text = reg.str1;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtid_Enter(object sender, EventArgs e)
        {
            getCustomer();
        }
        private void getCustomer()
        {
            if (txtid.Text == "")
            {


            }
            else
            {

                OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from customer where Cid=@Pid", con);
                ad2.SelectCommand.Parameters.Add("@Pid", OleDbType.Integer).Value = Convert.ToInt32(txtid.Text);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds2.Tables[0].Rows[0]["cname"].ToString();


                    txtlength.Text = ds2.Tables[0].Rows[0]["lenght"].ToString();
                    txtchest.Text = ds2.Tables[0].Rows[0]["chest"].ToString();
                    txtwaist.Text = ds2.Tables[0].Rows[0]["waist"].ToString();
                    txthip.Text = ds2.Tables[0].Rows[0]["hip"].ToString();
                    txtfneck.Text = ds2.Tables[0].Rows[0]["fneck"].ToString();
                    txtbneck.Text = ds2.Tables[0].Rows[0]["bneck"].ToString();
                    txtsleave.Text = ds2.Tables[0].Rows[0]["sleave"].ToString();
                    txtammole.Text = ds2.Tables[0].Rows[0]["ammole"].ToString();
                    txtgher.Text = ds2.Tables[0].Rows[0]["gher"].ToString();
                    txtchak.Text = ds2.Tables[0].Rows[0]["chak"].ToString();
                    txtban.Text = ds2.Tables[0].Rows[0]["ban"].ToString();
                    txtplate.Text = ds2.Tables[0].Rows[0]["plate"].ToString();
                    txtteera.Text = ds2.Tables[0].Rows[0]["teera"].ToString();
                    txtslength.Text = ds2.Tables[0].Rows[0]["slength"].ToString();
                    txtspouncha.Text = ds2.Tables[0].Rows[0]["spouncha"].ToString();
                  
                    ds2.Dispose();
                    ad2.Dispose();
                    con.Close();

                }

            }

        }





        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }





        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void xButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtlength_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtwaist_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtchest_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfneck_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbneck_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtban_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtteera_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtammole_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtchak_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtspouncha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private Int32 checkdelivers()
        { 
        OleDbCommand cmd =new OleDbCommand("Select count(*) from booking where ddate=#"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"#",con);
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
           Int32 count= Convert.ToInt32(cmd.ExecuteScalar());
           return count;
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text=="")
                {
                    MessageBox.Show("Select Order Iteam");
                }

               else if (dateTimePicker1.Value.Date<=DateTime.Today)
                {
                    MessageBox.Show("Delivery Date Should Not Be Same Date or Back Date");
                }
               else if (checkdelivers() >= 10)
                {
                    MessageBox.Show("10 Deliverys Alradery on Same Date");
                }
                else
                {
                //pictureBox1.Image = listView1.SelectedItems;
                String line = "";
               


                OleDbCommand cmdsave = new OleDbCommand("insert into booking(bid,aid,AType,adate,ddate,cid,cname,cmob,remarks,line,stdLeng,Lenght,chest,waist,shoulder,front,hip,fneck, bneck,sleave,ammole,gher,chak,ban,plate,platetype,teera,slength,spouncha,plength,ppouncha,stiching,design,lining,paipin,button,other,pic1,pic2,pic3)values(@bid,@aid,@AType,@adate,@ddate,@cid,@cname,@cmob,@remarks,@line,@StdLeng,@Lenght,@chest,@waist,@shoulder,@front,@hip,@fneck,bneck,@sleave,@ammole,@gher,@chak,@ban,@plate,@platetype,@teera,@slength,@spouncha,@plength,@ppouncha,@stiching,@design,@lining,@paipin,@button,@others,@pic1,@pic2,@pic3)", con);
                cmdsave.Parameters.Add("@Bid", OleDbType.Numeric).Value = lblID.Text;
                cmdsave.Parameters.Add("@Aid", OleDbType.Numeric).Value = LblAID.Text;
                cmdsave.Parameters.Add("@AType", OleDbType.VarChar, 50).Value = drpAType.Text;
                cmdsave.Parameters.Add("@Adate", OleDbType.Date).Value = txtdate.Text;
                cmdsave.Parameters.Add("@Ddate", OleDbType.Date).Value = dateTimePicker1.Text;
                cmdsave.Parameters.Add("@cid", OleDbType.Numeric).Value =Convert.ToInt32("0"+txtid.Text);
                cmdsave.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = txtname.Text;
                cmdsave.Parameters.Add("@cmob", OleDbType.VarChar, 100).Value = txtmob.Text;
                cmdsave.Parameters.Add("@Remarks", OleDbType.VarChar, 100).Value = txtremarks.Text;
                cmdsave.Parameters.Add("@Line", OleDbType.VarChar, 100).Value = Convert.ToDouble("0" + txtline.Text); ;

                cmdsave.Parameters.Add("@StdLeng", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtstdleng.Text);
                cmdsave.Parameters.Add("@lenght", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtlength.Text);
                cmdsave.Parameters.Add("@chest", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtchest.Text);
                cmdsave.Parameters.Add("@waist", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtwaist.Text);

                cmdsave.Parameters.Add("@shoulder", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtshoulder.Text);
                cmdsave.Parameters.Add("@front", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtfront.Text);
                cmdsave.Parameters.Add("@hip", OleDbType.Numeric).Value = Convert.ToDouble("0" + txthip.Text);
                cmdsave.Parameters.Add("@neck", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtfneck.Text);
                cmdsave.Parameters.Add("@bneck", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtbneck.Text);
                cmdsave.Parameters.Add("@sleave", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtsleave.Text);
                cmdsave.Parameters.Add("@ammole", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtammole.Text);
                cmdsave.Parameters.Add("@gher", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtgher.Text);
                cmdsave.Parameters.Add("@chak", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtchak.Text);
                cmdsave.Parameters.Add("@teera", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtteera.Text);
                cmdsave.Parameters.Add("@ban", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtban.Text);
                cmdsave.Parameters.Add("@plate", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtplate.Text);
                cmdsave.Parameters.Add("@platetype", OleDbType.VarChar,50).Value =  drpplate.Text;

                cmdsave.Parameters.Add("@slength", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtslength.Text);
                cmdsave.Parameters.Add("@spouncha", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtspouncha.Text);
               
                
                cmdsave.Parameters.Add("@stiching", OleDbType.Numeric).Value =Convert.ToInt32("0"+ txtstiching.Text);
                cmdsave.Parameters.Add("@design", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtdesigne.Text);
                cmdsave.Parameters.Add("@lining", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtlining.Text);
                cmdsave.Parameters.Add("@paipin", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtpaipin.Text);
                cmdsave.Parameters.Add("@button", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtbutton.Text);
                cmdsave.Parameters.Add("@others", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtothers.Text);

                cmdsave.Parameters.Add("@pic1", OleDbType.VarChar, 100).Value = lblpic1.Text;
                cmdsave.Parameters.Add("@pic2", OleDbType.VarChar, 100).Value = txtdesigne.Text;
                cmdsave.Parameters.Add("@pic3", OleDbType.VarChar, 100).Value = "";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmdsave.ExecuteNonQuery();
                cmdsave.Parameters.Clear();
                cmdsave.Dispose();
                con.Close();
                MessageBox.Show("Data Saved Successfully");

                clear();

                GenrateAID();
                Showcustomer();
                xButton3.Text = "Edit";

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        
        }
        private void clear()
        {
            txtline.Clear();
            txtban.Clear();
            txtplate.Clear();
            txtname.Clear();
            txtremarks.Clear();

            txtchest.Clear();
            txtwaist.Clear();
            txtlength.Clear();
            txthip.Clear();
            txtfneck.Clear();
            txtbneck.Clear();
            txtsleave.Clear();
            txtammole.Clear();
            txtgher.Clear();
            txtchak.Clear();
            txtteera.Clear();
            txtslength.Clear();
            txtspouncha.Clear();
          
            lblpic1.Text = "";
            lblpic2.Text = "";
            lblpic3.Text = "";
            txtbutton.Clear();
            txtlining.Clear();
            txtpaipin.Clear();
            txtothers.Clear();
            txtstiching.Clear();
            txtdesigne.Clear();
            txtid.Clear();
            txtbid.Clear();

        }
        private void Showcustomer()
        {
            try
            {
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from booking where bid=" + lblID.Text + "", con);

                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);

                dataGridView1.DataSource = ds1.Tables[0];


                ad1.Dispose();
                ds1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void xButton6_Click(object sender, EventArgs e)
        {

        }

        private void xButton4_Click(object sender, EventArgs e)
        {

        }

        private void xButton3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void getImages()
        {
            if (label31.Text != "")
            {
                listView1.View = View.LargeIcon;
                imageList1.ImageSize = new Size(132, 132);
                listView1.LargeImageList = imageList1;
                int i = 0;
                DirectoryInfo dir = new DirectoryInfo(label31.Text);
                foreach (FileInfo file in dir.GetFiles())
                {

                    imageList1.Images.Add(Image.FromFile(file.FullName));



                    listView1.Items.Add(file.Name, i);
                    //listView1.Items[i].ToolTipText = file.Name;
                    listView1.Items[i].Tag = file.FullName;


                    i++;
                }
            }
        }
        private void ShowStock()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT * from Booking Where Bid=" + lblID.Text + "", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            ////dataGridView1.Columns[0].Width = 35;
            ////dataGridView1.Columns[1].Width = 160;
            ////dataGridView1.Columns[2].Width = 70;
            ////dataGridView1.Columns[3].Width = 70;
            ////dataGridView1.Columns[4].Width = 70;
            ////dataGridView1.Columns[5].Width = 90;
            ////dataGridView1.Columns[6].Width = 150;


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void xButton6_Click_1(object sender, EventArgs e)
        {
            if (xButton3.Text!="Edit")
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {


                        OleDbCommand cmddel = new OleDbCommand("Delete from booking where aid=@pid and bid=" + lblID.Text + "", con);
                        cmddel.Parameters.Add("@pid", OleDbType.Integer).Value = Convert.ToInt32(LblAID.Text);


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
                        GenrateAID();
                        xButton3.Text = "Edit";
                    }
                }
            }
            else { MessageBox.Show("Select Any Iteam"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            

            if (dataGridView1.Rows.Count>0)
            {

                LblAID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from booking where aid=@Pid and bid=" + lblID.Text + "", con);
                ad2.SelectCommand.Parameters.Add("@Pid", OleDbType.Integer).Value = Convert.ToInt32(LblAID.Text);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);

                txtname.Text = ds2.Tables[0].Rows[0]["cname"].ToString();
                txtid.Text = ds2.Tables[0].Rows[0]["cid"].ToString();
                drpAType.Text = ds2.Tables[0].Rows[0]["AType"].ToString();
                dateTimePicker1.Text = ds2.Tables[0].Rows[0]["ddate"].ToString();
                txtmob.Text = ds2.Tables[0].Rows[0]["cmob"].ToString();
                txtremarks.Text = ds2.Tables[0].Rows[0]["remarks"].ToString();
                txtlength.Text = ds2.Tables[0].Rows[0]["lenght"].ToString();
                txtchest.Text = ds2.Tables[0].Rows[0]["chest"].ToString();
                txtwaist.Text = ds2.Tables[0].Rows[0]["waist"].ToString();
                txthip.Text = ds2.Tables[0].Rows[0]["hip"].ToString();
                txtfneck.Text = ds2.Tables[0].Rows[0]["fneck"].ToString();
                txtbneck.Text = ds2.Tables[0].Rows[0]["bneck"].ToString();
                txtsleave.Text = ds2.Tables[0].Rows[0]["sleave"].ToString();
                txtammole.Text = ds2.Tables[0].Rows[0]["ammole"].ToString();
                txtgher.Text = ds2.Tables[0].Rows[0]["gher"].ToString();
                txtchak.Text = ds2.Tables[0].Rows[0]["chak"].ToString();
                txtban.Text = ds2.Tables[0].Rows[0]["ban"].ToString();
                txtplate.Text = ds2.Tables[0].Rows[0]["plate"].ToString();
                txtteera.Text = ds2.Tables[0].Rows[0]["teera"].ToString();
                txtslength.Text = ds2.Tables[0].Rows[0]["slength"].ToString();
                txtspouncha.Text = ds2.Tables[0].Rows[0]["spouncha"].ToString();
              

                txtstiching.Text = ds2.Tables[0].Rows[0]["stiching"].ToString();
                txtdesigne.Text = ds2.Tables[0].Rows[0]["design"].ToString();
                txtlining.Text = ds2.Tables[0].Rows[0]["lining"].ToString();
                txtpaipin.Text = ds2.Tables[0].Rows[0]["paipin"].ToString();
                txtbutton.Text = ds2.Tables[0].Rows[0]["button"].ToString();
                txtothers.Text = ds2.Tables[0].Rows[0]["other"].ToString();
                txttotal.Text = ds2.Tables[0].Rows[0]["total"].ToString();
                txtdesigne.Text = ds2.Tables[0].Rows[0]["pic2"].ToString();
                txtline.Text = ds2.Tables[0].Rows[0]["lining"].ToString();
                ds2.Dispose();
                ad2.Dispose();
                con.Close();
                xButton3.Text = "Update";
                xButton3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Select Iteam From Grid");
            }
        }

        private void xButton3_Click_1(object sender, EventArgs e)
        {

            //if (dateTimePicker1.Value <= DateTime.Today)
            //{
            //    MessageBox.Show("Delivery Date Should Not Be Same Date or Back Date");
            //}
            //else if (checkdelivers() >= 10)
            //{
            //    MessageBox.Show("10 Deliverys Alradery on Same Date");
            //}
            //else
            {

                if (xButton3.Text == "Update")
                {
                    String line = "";
                    

                    OleDbCommand cmdupdate = new OleDbCommand("update booking set AType=@AType,ddate=@ddate,cid=@cid,cname=@cname,cmob=@cmob,remarks=@remarks,line=@line,Lenght=@lenght,chest=@chest,waist=@waist,hip=@hip,fneck=@fneck,bneck=@bneck,sleave=@sleav,ammole=@ammole,gher=@gher,chak=@chak,ban=@ban,plate=@plate,teera=@teera,slength=@slength,spouncha=@spouncha,plength=@plength,ppouncha=@ppouncha,stiching=@stiching,design=@design,lining=@lining,paipin=@paipin,button=@button,other=@others,total=@total,pic1=@pic1,pic2=@pic2,pic3=@pic3 where bid=@bid and aid=@aid", con);


                    cmdupdate.Parameters.Add("@AType", OleDbType.VarChar, 50).Value = drpAType.Text;
                    //cmdupdate.Parameters.Add("@Adate", OleDbType.Date).Value = txtdate.Text;
                    cmdupdate.Parameters.Add("@Ddate", OleDbType.Date).Value = dateTimePicker1.Text;
                    cmdupdate.Parameters.Add("@cid", OleDbType.Numeric, 100).Value = txtid.Text;
                    cmdupdate.Parameters.Add("@cname", OleDbType.VarChar, 100).Value = txtname.Text;
                    cmdupdate.Parameters.Add("@cmob", OleDbType.VarChar, 100).Value = txtmob.Text;
                    cmdupdate.Parameters.Add("@Remarks", OleDbType.VarChar, 100).Value = txtremarks.Text;
                    cmdupdate.Parameters.Add("@Line", OleDbType.VarChar, 100).Value = line;


                    cmdupdate.Parameters.Add("@lenght", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtlength.Text);
                    cmdupdate.Parameters.Add("@chest", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtchest.Text);
                    cmdupdate.Parameters.Add("@waist", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtwaist.Text);
                    cmdupdate.Parameters.Add("@hip", OleDbType.Numeric).Value = Convert.ToDouble("0" + txthip.Text);
                    cmdupdate.Parameters.Add("@fneck", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtfneck.Text);
                    cmdupdate.Parameters.Add("@bneck", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtbneck.Text);
                    cmdupdate.Parameters.Add("@sleave", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtsleave.Text);
                    cmdupdate.Parameters.Add("@ammole", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtammole.Text);
                    cmdupdate.Parameters.Add("@gher", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtgher.Text);
                    cmdupdate.Parameters.Add("@chak", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtchak.Text);
                    cmdupdate.Parameters.Add("@ban", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtban.Text);
                    cmdupdate.Parameters.Add("@plate", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtplate.Text);
                    cmdupdate.Parameters.Add("@teera", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtteera.Text);
                    cmdupdate.Parameters.Add("@slength", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtslength.Text);
                    cmdupdate.Parameters.Add("@spouncha", OleDbType.Numeric).Value = Convert.ToDouble("0" + txtspouncha.Text);
                   

                    cmdupdate.Parameters.Add("@stiching", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtstiching.Text);
                    cmdupdate.Parameters.Add("@design", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtdesigne.Text);
                    cmdupdate.Parameters.Add("@lining", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtlining.Text);
                    cmdupdate.Parameters.Add("@paipin", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtpaipin.Text);
                    cmdupdate.Parameters.Add("@button", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtbutton.Text);
                    cmdupdate.Parameters.Add("@others", OleDbType.Numeric).Value = Convert.ToInt32("0" + txtothers.Text);
                    cmdupdate.Parameters.Add("@total", OleDbType.Numeric).Value = Convert.ToInt32("0" + txttotal.Text);
                    cmdupdate.Parameters.Add("@pic1", OleDbType.VarChar, 100).Value = lblpic1.Text;
                    cmdupdate.Parameters.Add("@pic2", OleDbType.VarChar, 100).Value = lblpic2.Text;
                    cmdupdate.Parameters.Add("@pic3", OleDbType.VarChar, 100).Value = lblpic3.Text;

                    cmdupdate.Parameters.Add("@Bid", OleDbType.Numeric).Value = lblID.Text;
                    cmdupdate.Parameters.Add("@Aid", OleDbType.Numeric).Value = LblAID.Text;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdupdate.ExecuteNonQuery();
                    cmdupdate.Parameters.Clear();
                    cmdupdate.Dispose();
                    con.Close();
                    MessageBox.Show("Data Updated Successfully");
                    Showcustomer();
                    clear();
                    xButton3.Text = "Edit";
                    GenrateAID();
                }

            }
        }
        private void calulate()
        {
            txttotal.Text = (Convert.ToInt32("0" + txtstiching.Text) + Convert.ToInt32("0" + txtdesigne.Text) + Convert.ToInt32("0" + txtlining.Text)+Convert.ToInt32("0"+txtpaipin.Text)+Convert.ToInt32("0"+txtothers.Text)+Convert.ToInt32("0"+txtbutton.Text)).ToString();
       
        }

        private void xButton2_Click(object sender, EventArgs e)
        {
            GenrateBID();
            GenrateAID();
            clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtbid.Text == "") { MessageBox.Show("Enter Booking ID"); }
            else
            {
                lblID.Text = txtbid.Text;
                Showcustomer();
                dataGridView1.Refresh();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { txtbid.Visible = true; btnGetBid.Visible = true; }
            if (checkBox1.Checked == false) { txtbid.Visible = false; btnGetBid.Visible = false; }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                
                    pictureBox1.Image = imageList1.Images[e.ItemIndex];
                    lblpic1.Text = listView1.Items[e.ItemIndex].Tag.ToString();
                    lblpic1.Visible=false;
                
                
                //else  
                //{
                //    pictureBox3.Image = imageList1.Images[e.ItemIndex];
                //    lblpic3.Text = listView1.Items[e.ItemIndex].Text;
                //}
                //}
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label31.Text = Application.StartupPath + "\\assignment\\" + comboBox2.Text;
            getImages();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void xButton4_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Delete Current Booking ", "Delete Records", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                OleDbCommand cmddel = new OleDbCommand("Delete from booking where bid=" + lblID.Text + "", con);



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmddel.ExecuteNonQuery();
                cmddel.Parameters.Clear();
                cmddel.Dispose();
                con.Close();
                MessageBox.Show("Booking Deleted Successfully");
                Showcustomer();
                GenrateBID();
                GenrateAID();
                clear();

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void txttotal_Enter(object sender, EventArgs e)
        {
            calulate();
        }

        private void txtstiching_TextChanged(object sender, EventArgs e)
        {
            calulate();
        }

        private void txtdesigne_TextChanged(object sender, EventArgs e)
        {
            calulate();
        }

        private void txtlining_TextChanged(object sender, EventArgs e)
        {
            calulate();
        }

        private void txtpaipin_TextChanged(object sender, EventArgs e)
        {
            calulate();
        }

        private void txtbutton_TextChanged(object sender, EventArgs e)
        {
            calulate();
        }

        private void txtothers_TextChanged(object sender, EventArgs e)
        {
            calulate();
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void xButton7_Click(object sender, EventArgs e)
        {
            printRpt();
        }

        void printRpt()
        {

            if (dataGridView1.SelectedCells.Count >= 1)
            {
                try
                {
                    OleDbCommand cmdBillClear = new OleDbCommand("update booking set print=null", con);
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

                    OleDbCommand cmdBillYes = new OleDbCommand("update booking set print='Y' WHERE bid=" + lblID.Text + "", con);
                    //cmdBillYes.Parameters.Add("@Billno", OleDbType.Integer).Value = Convert.ToInt32(0 + txtEnterQty.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdBillYes.ExecuteNonQuery();

                    cmdBillYes.Parameters.Clear();
                    cmdBillYes.Dispose();
                    con.Close();
                    Form cffrmReports = new ReportBooking("");

                    cffrmReports.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void drpAType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (drpAType.Text.ToUpper() == "BLOUSE")
            //{
            //    txtline.Visible=false;
            //    txtban.Visible=false;
            //    txtplate.Visible=true;
            //    txtname.Visible=false;
            //    txtremarks.Visible=false;

            //    txtchest.Visible=false;
            //    txtwaist.Visible=true;
            //    txtlength.Visible=true;
            //    txthip.Visible=false;
            //    txtfneck.Visible=false;
            //    txtbneck.Visible=false;
            //    txtsleave.Visible=true;
            //    txtammole.Visible=false;
            //    txtgher.Visible=false;
            //    txtchak.Visible=false;
            //    txtteera.Visible=false;
            //    txtslength.Visible=false;
            //    txtspouncha.Visible=false;
            //    txtshoulder.Visible = true;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
}