using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace GST
{
    public partial class frmLogin : Form
    {
        connection cn = new connection();
        OleDbConnection con = new OleDbConnection();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text =="admin" && textBox2.Text == "admin")
                {
                    this.Visible = false;
                   
                   
                   
                }
                else
                {
                    this.Visible = false;
                    Form childForm = new Main("");
                    childForm.Parent = this.Parent;
                    childForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
