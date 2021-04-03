namespace ImperialPlastics
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.REPORT1 = new ImperialPlastics.REPORT();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.SelectionFormula = "";
            this.crystalReportViewer2.Size = new System.Drawing.Size(757, 429);
            this.crystalReportViewer2.TabIndex = 0;
            this.crystalReportViewer2.ViewTimeSelectionFormula = "";
            // 
            // frmReports
            // 
            this.ClientSize = new System.Drawing.Size(757, 429);
            this.Controls.Add(this.crystalReportViewer2);
            this.KeyPreview = true;
            this.Name = "frmReports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReports_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ImperialPlastics.REPORT REPORT1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}