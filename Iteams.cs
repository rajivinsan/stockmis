using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Text.RegularExpressions;

namespace GST
{

    public partial class Iteams : Form
    {
        String companyid = "";
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        Int32 GID;

        public Iteams(string compid)
        {
            con.ConnectionString = cn.connectionstring;

            InitializeComponent();
            companyid = compid;
        }


        private void SaveDate()
        {
            GenratePID();
            OleDbCommand cmdsave = new OleDbCommand("insert into Stock(PID,barcode,invoice,category,PURCHASE_From,PDATE,modelno,serialno,warranty,amc,price,status,Remarks)" +
                "values(@PID,@barcode,@HsnCode,@Item_code,@PURCHASE_From,@PDATE,@modelno,@serialno,@warranty,@amc,@price,@status,@Remarks)", con);

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            cmdsave.Parameters.Add("@PID", OleDbType.VarChar, 100).Value = lbID.Text;
            cmdsave.Parameters.Add("@barcode", OleDbType.VarChar, 100).Value = txtbarcode.Text;
            cmdsave.Parameters.Add("@HsnCode", OleDbType.VarChar, 100).Value = txtinvoice.Text;
            cmdsave.Parameters.Add("@Item_code", OleDbType.VarChar, 255).Value = drpCategory.SelectedValue;
            cmdsave.Parameters.Add("@PURCHASE_From", OleDbType.VarChar, 255).Value = txtpurchasedetails.Text;

            cmdsave.Parameters.Add("@PDATE", OleDbType.Date).Value = dateTimePicker1.Text;
            cmdsave.Parameters.Add("@modelno", OleDbType.VarChar, 255).Value = txtmodel.Text;
            cmdsave.Parameters.Add("@serialno", OleDbType.VarChar, 255).Value = txtserialno.Text;
            cmdsave.Parameters.Add("@warranty", OleDbType.VarChar, 255).Value = txtwarranty.Text;
            cmdsave.Parameters.Add("@amc", OleDbType.VarChar, 255).Value = txtamc.Text;
            cmdsave.Parameters.Add("@price", OleDbType.VarChar, 255).Value = txtprice.Text;
            cmdsave.Parameters.Add("@status", OleDbType.VarChar, 255).Value = drpStatus.SelectedText;
            cmdsave.Parameters.Add("@Remarks", OleDbType.VarChar, 255).Value = txtremarks.Text;
           

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmdsave.ExecuteNonQuery();
            cmdsave.Parameters.Clear();
            cmdsave.Dispose();
            con.Close();
            MessageBox.Show("Data Saved Successfully");
            ShowStock("");
            clear();
            GenratePID();

            Button1.Text = "New";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text.Trim().ToUpper() == "SAVE")
            {
               
                 if (drpCategory.Text == "")
                {
                    MessageBox.Show("Select Category", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (txtmodel.Text == "" || txtserialno.Text == "")
                {
                    MessageBox.Show("Model/Serail Not Entred", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    SaveDate();

                }
                
            }

            else if (Button1.Text.Trim().ToUpper() == "UPDATE")
            {
                if (txtwarranty.Text.Trim().Length > 0)
                {
             
                    OleDbCommand cmdupdate = new OleDbCommand("update stock set barcode=@barcode,invoice=@HsnCode,category=@item_code,purchase_from=@purchase_from,pdate=@pdate," +
                        "modelno=@modelno,serialno=@serialno,warranty=@warranty,amc=@amc,price=@price,status=@status,remarks=@remarks where pid=@pid", con);
                    cmdupdate.Parameters.Clear();
         
                    cmdupdate.Parameters.Add("@barcode", OleDbType.VarChar, 100).Value = txtbarcode.Text;
                    cmdupdate.Parameters.Add("@HsnCode", OleDbType.VarChar, 100).Value = txtinvoice.Text;
                    cmdupdate.Parameters.Add("@Item_code", OleDbType.VarChar, 255).Value = drpCategory.SelectedText;
                    cmdupdate.Parameters.Add("@purchase_from", OleDbType.VarChar, 255).Value = txtpurchasedetails.Text;

                    cmdupdate.Parameters.Add("@PDATE", OleDbType.Date).Value = dateTimePicker1.Text;
                    cmdupdate.Parameters.Add("@modelno", OleDbType.VarChar, 255).Value = txtmodel.Text;
                    cmdupdate.Parameters.Add("@serialno", OleDbType.VarChar, 255).Value = txtserialno.Text;
                    cmdupdate.Parameters.Add("@warranty", OleDbType.VarChar, 255).Value = txtwarranty.Text;
                    cmdupdate.Parameters.Add("@amc", OleDbType.VarChar, 255).Value = txtamc.Text;
                    cmdupdate.Parameters.Add("@price", OleDbType.VarChar, 255).Value = txtprice.Text;
                    cmdupdate.Parameters.Add("@status", OleDbType.VarChar, 255).Value = drpStatus.SelectedText;
                    cmdupdate.Parameters.Add("@remarks", OleDbType.VarChar, 255).Value = txtremarks.Text;
                    cmdupdate.Parameters.Add("@PID", OleDbType.VarChar, 100).Value = lbID.Text;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdupdate.ExecuteNonQuery();
                    cmdupdate.Parameters.Clear();
                    cmdupdate.Dispose();
                    con.Close();
                    MessageBox.Show("Data Update Successfully");
                    ShowStock("");
                    clear();

                    Button1.Text = "New";
                    txtwarranty.Visible = false;
                    txtamc.Enabled = true;
                    
                }
                else { MessageBox.Show("Enter Quantity"); txtwarranty.BackColor = System.Drawing.Color.OrangeRed; }
            }
            else
            {
                clear();
                Button1.Text = "Save";
             
             
               
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                GenratePID();
                ShowStock("");
                Showcategory();
               
                lbID.Text = GenratePID();
                
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
               
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear()
        {
            try
            {


                //drpsaletype.SelectedIndex = -1;
                Button1.Text = "New";
                txtinvoice.Clear();
                txtwarranty.Clear();
              
              
                txtbarcode.Clear();

                txtserialno.Text = "";
                drpStatus.SelectedValue = -1;
                txtprice.Clear();
               
                txtremarks.Text = "";
                txtprice.Text="";
               
                           
                txtamc.Text = "";
                txtmodel.Text = "";
                txtpurchasedetails.Text = "";


                drpCategory.SelectedIndex = -1;
              
                groupBox1.Enabled = false;
                groupBox2.Enabled=false;

                ShowStock("");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ShowStock(String s)
        {
            String qry = "SELECT * from stock where pid<>0";
            if (drpCategory.Text != "")
            {

                qry += " and Category='" + drpCategory.SelectedValue + "'";
                
            }
           

           
            if (s.Length > 0)
            {
                qry += " and (modelno) like '%" + s + "%'";
            }
                       

            OleDbDataAdapter ad1 = new OleDbDataAdapter(qry, con);
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
        private void Showcategory()
        {
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select cname from category order by cname", con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            drpCategory.DataSource = ds1.Tables[0];
            drpCategory.DisplayMember = "CName";
            drpCategory.ValueMember = "CName";

            ds1.Dispose();
            ad1.Dispose();
            



        }
      
      
        

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Delete ", "Delete Records", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                OleDbCommand cmddel = new OleDbCommand("Delete from stock where pid=@pid", con);
                cmddel.Parameters.Add("@pid", OleDbType.Integer).Value = Convert.ToInt32(lbID.Text);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmddel.ExecuteNonQuery();
                cmddel.Parameters.Clear();
                cmddel.Dispose();
                con.Close();
                MessageBox.Show("Data Deleted Successfully");
                ShowStock("");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(e.RowIndex.ToString());

        }
        private void appkey(string key, string value)
        {
                  
            var configfile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var setting = configfile.AppSettings.Settings;
            if (setting[key] == null)
            {
                setting.Add(key, value);
                configfile.Save(ConfigurationSaveMode.Modified);
            }


            ConfigurationManager.RefreshSection(configfile.AppSettings.SectionInformation.Name);
        }
        private void Removekey(string key)
        {

            var configfile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var setting = configfile.AppSettings.Settings;
            if (setting[key] != null)
            {
                setting.Remove(key);
                configfile.Save(ConfigurationSaveMode.Modified);
            }


            ConfigurationManager.RefreshSection(configfile.AppSettings.SectionInformation.Name);
        }
        private string getkey(string key)
        {
            string result = "";
            var appsetting = ConfigurationManager.AppSettings;
            return result = appsetting[key];
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
              
                lbID.Text = dataGridView1.Rows[e.RowIndex].Cells["PID"].Value.ToString();

                OleDbDataAdapter ad2 = new OleDbDataAdapter("Select * from stock where pid=@Pid", con);
                ad2.SelectCommand.Parameters.Add("@Pid", OleDbType.Integer).Value = Convert.ToInt32(lbID.Text);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                
                
                
                drpCategory.SelectedValue = ds2.Tables[0].Rows[0]["category"].ToString();
              
                txtbarcode.Text = ds2.Tables[0].Rows[0]["barcode"].ToString();
                txtinvoice.Text = ds2.Tables[0].Rows[0]["invoice"].ToString();
                txtmodel.Text = ds2.Tables[0].Rows[0]["modelno"].ToString();
                txtserialno.Text = ds2.Tables[0].Rows[0]["serialno"].ToString();

                dateTimePicker1.Text = ds2.Tables[0].Rows[0]["pdate"].ToString();
                txtamc.Text = ds2.Tables[0].Rows[0]["amc"].ToString();

               
                txtprice.Text = ds2.Tables[0].Rows[0]["price"].ToString();
                txtwarranty.Text = ds2.Tables[0].Rows[0]["warranty"].ToString();
                drpStatus.SelectedText = ds2.Tables[0].Rows[0]["status"].ToString();

                txtpurchasedetails.Text = ds2.Tables[0].Rows[0]["purchase_from"].ToString();


                //txthight.Text = ds2.Tables[0].Rows[0]["D_H"].ToString();
                //txtlengthtotal.Text = ds2.Tables[0].Rows[0]["Total_DM"].ToString();

                txtremarks.Text = ds2.Tables[0].Rows[0]["remarks"].ToString();
                
             
                //count();

                ds2.Dispose();
                ad2.Dispose();
               
                con.Close();
                Button1.Text="Update";
               
                
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
                label17.Visible = true;
                
                //count();
            }
        }

        private void Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void drpcategory_Click(object sender, EventArgs e)
        {

        }

        private void drpcategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox1.Clear();
        
            ShowStock("");
            //scounStock();
            
        }

        
    
       

        private String GenratePID()
        {

            String id;

            OleDbCommand cmd = new OleDbCommand("select  Max(PID) from stock", con);
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            id = cmd.ExecuteScalar().ToString();

            if (id != null && id != "")
            {
                GID = Convert.ToInt32(id) + 1;


            }
            else
            {
                GID = Convert.ToInt32(DateTime.Now.Year + "01");

            }
            lbID.Text = GID.ToString();

            return GID.ToString();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtlengthtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void drpcategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

      

        private void drpsaletype_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtquantity_TextChanged_1(object sender, EventArgs e)
        {

        }

       

       

        private void txtlength_TextChanged_1(object sender, EventArgs e)
        {
           
           
        }

        

        private void drpsubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void txtAddQty_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void txtsgst_TextChanged(object sender, EventArgs e)
        {
            //TextBox txtbox = (TextBox)sender;
            //if (txtbox.Text == "") { txtbox.Text = "0"; }
        }

       

        private void txtcgst_TextChanged(object sender, EventArgs e)
        {
        //    TextBox txtbox = (TextBox)sender;
        //    if (txtbox.Text == "") { txtbox.Text = "0"; }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ItemMas frm = new ItemMas();
            
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Partymas frm = new Partymas();

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void drpItem_SelectionChangeCommitted(object sender, EventArgs e)
        {

            
           
            ShowStock("");


            
        }
      
        private void txtsaleamount_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (dup("barcode", txtbarcode.Text) > 0)
            {
                MessageBox.Show("IMEI/Barcode NO Already Exists", "Record Exits", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else { SaveDate(); }
        }

        private Int32 dup(String s,String v)
        {
            Int32 i = 0;
            if (v.Length>0)
            {
                OleDbCommand cmd = new OleDbCommand("select count(" + s + ") as [id] from stock where " + s + "=@id", con);
                cmd.Parameters.Add("@id", OleDbType.VarChar, 60).Value = v;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                i = Convert.ToInt32("0" + cmd.ExecuteScalar());
               
            }
            return i;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            Double val = 0;

            foreach(DataGridViewRow dr in dataGridView1.Rows)
            {

                val = val + 1;
               
                
            }
            lbltotalRows.Text = val.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ShowStock(textBox1.Text.Trim());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CategoryMas frm = new CategoryMas();

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void drpSaletype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ShowStock(textBox1.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Iteams_Enter(object sender, EventArgs e)
        {

        }

        private void txtmodel_TextChanged(object sender, EventArgs e)
        {

        }
    } 

        


}