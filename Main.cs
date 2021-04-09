using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;

namespace GST
{
    public partial class Main : Form
    {
        String companyid = "";
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Main(string id)
        {
            con.ConnectionString = cn.connectionstring;
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            lbluid.Text = id;
            companyid = id;
           // getUser(id);
        }
        private void getUser(string id)
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("select compname from companymas where compid=@compid", con);
            adp.SelectCommand.Parameters.Add("@compid", OleDbType.VarChar, 50).Value = id;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblname.Text = ds.Tables[0].Rows[0]["compname"].ToString();
            }
            ds.Dispose();
            adp.Dispose();
            con.Close();
             

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //this.ParentForm.MaximizeBox = true;
            Welcome wel = new Welcome();
            wel.MdiParent = this;
            wel.Dock = DockStyle.Fill;
            wel.Show();
             //this.ParentForm.MaximizeBox = true;


        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = System.Drawing.Color.Orange;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = System.Drawing.Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

          
            OfficeMas frmpayment = new OfficeMas("");
            //String s=frmpayment.Text;
            //if (!CheckForm(frmpayment))
            {
                frmpayment.MdiParent = this;
                frmpayment.Dock = DockStyle.Fill;
                frmpayment.Show();
            }
            




        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Iteams frmpayment = new Iteams(companyid);
          
            {
                frmpayment.MdiParent = this;
                frmpayment.Dock = DockStyle.Fill;
                frmpayment.Show();
            }
            


        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            StockMaintainceBill frm = new StockMaintainceBill();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           

            NetProfit frm = new NetProfit();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

           
            CategoryWiseLeg frm = new CategoryWiseLeg();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            IssueStock frmpayment = new IssueStock();
          
            {
                frmpayment.MdiParent = this;
                frmpayment.Dock = DockStyle.Fill;
                frmpayment.Show();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

          
            SaleRegister exp = new SaleRegister();
            exp.MdiParent = this;
            exp.Dock = DockStyle.Fill;
            exp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

           
            CustomerLeg bal = new CustomerLeg();
            bal.MdiParent = this;
            bal.Dock = DockStyle.Fill;
            bal.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            CategoryWiseLeg emp = new CategoryWiseLeg();
            emp.MdiParent = this;
            emp.Dock = DockStyle.Fill;
            emp.Show();
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PurchaseRegister emp = new PurchaseRegister();
            emp.MdiParent = this;
            emp.Dock = DockStyle.Fill;
            emp.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
          TransferStock emp = new TransferStock();
            emp.MdiParent = this;
            emp.Dock = DockStyle.Fill;
            emp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Welcome frmpayment = new Welcome();
          
            {
                frmpayment.MdiParent = this;
                frmpayment.Dock = DockStyle.Fill;
                frmpayment.Show();
            }
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {

                this.WindowState = FormWindowState.Normal;
            }
            else { this.WindowState = FormWindowState.Maximized; }
        }

        private void Main_MaximumSizeChanged(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Main_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private bool CheckForm(Form form)
        {
            form = Application.OpenForms[form.Name];
            if (form != null)
                return true;
            else
                return false;
        }

        private void button22_MouseHover(object sender, EventArgs e)
        {
            Button pan = (sender as Button);
            pan.BackColor = System.Drawing.Color.Wheat;
            pan.FlatAppearance.BorderSize = 1;
            pan.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
        }

        private void button22_MouseLeave(object sender, EventArgs e)
        {
            Button pan = (sender as Button);
            pan.BackColor = System.Drawing.Color.Transparent;
            pan.FlatAppearance.BorderSize = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MasterData frm = new MasterData(companyid);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            PendBill frm = new PendBill();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            MaintainceLeg frm = new MaintainceLeg();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }
    }
}


