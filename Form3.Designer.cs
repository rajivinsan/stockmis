namespace GST
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dbsonDataSet = new GST.dbsonDataSet();
            this.BILLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BILLTableAdapter = new GST.dbsonDataSetTableAdapters.BILLTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dbsonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BILLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BILLBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GST.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1151, 432);
            this.reportViewer1.TabIndex = 0;
            // 
            // dbsonDataSet
            // 
            this.dbsonDataSet.DataSetName = "dbsonDataSet";
            this.dbsonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BILLBindingSource
            // 
            this.BILLBindingSource.DataMember = "BILL";
            this.BILLBindingSource.DataSource = this.dbsonDataSet;
            // 
            // BILLTableAdapter
            // 
            this.BILLTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 432);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbsonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BILLBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BILLBindingSource;
        private dbsonDataSet dbsonDataSet;
        private dbsonDataSetTableAdapters.BILLTableAdapter BILLTableAdapter;
    }
}