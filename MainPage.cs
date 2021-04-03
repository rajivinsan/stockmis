using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vishal
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form cflogin = new Login();
            //cflogin.MdiParent = this.MdiParent;
            cflogin.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form cflogin = new Login();
            //cflogin.MdiParent = this.MdiParent;
            cflogin.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form cfchangepasword = new ChangePassword();
            //cfchangepasword.MdiParent = this.MdiParent;
            cfchangepasword.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form cfCustomer = new Customer();
            //cfchangepasword.MdiParent = this.MdiParent;
            cfCustomer.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form cfSupplier = new Supplier();
            //cfchangepasword.MdiParent = this.MdiParent;
            cfSupplier.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form cfProducts = new Products();
            //cfchangepasword.MdiParent = this.MdiParent;
            cfProducts.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form cfBill = new Bill();
            //cfchangepasword.MdiParent = this.MdiParent;
            cfBill.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form cfShowBill = new ShowBill();
            //cfchangepasword.MdiParent = this.MdiParent;
            cfShowBill.ShowDialog();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
