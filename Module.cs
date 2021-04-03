using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GST
{
    public partial class Module : Form
    {
       
        public Module()
        {
            InitializeComponent();
        }

        private void Module_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(50);
            if (progressBar1.Value == 1000)
            {
                timer1.Enabled = false;
                this.Visible = false;
                Main main = new Main("");
                main.Show();
            }
                
               
            }
        }
    
}

