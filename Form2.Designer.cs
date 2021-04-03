namespace GST
{
    partial class Form2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbsonDataSet1 = new GST.dbsonDataSet1();
            this.StockTableAdapter = new GST.dbsonDataSet1TableAdapters.StockTableAdapter();
            this.BILLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbsonDataSet = new GST.dbsonDataSet();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BILLTableAdapter = new GST.dbsonDataSetTableAdapters.BILLTableAdapter();
            this.customerTableAdapter = new GST.dbsonDataSetTableAdapters.customerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsonDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BILLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Bill";
            reportDataSource1.Value = this.BILLBindingSource;
            reportDataSource2.Name = "Cutomer";
            reportDataSource2.Value = this.customerBindingSource;
            reportDataSource3.Name = "Stock";
            reportDataSource3.Value = this.StockBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GST.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(915, 416);
            this.reportViewer1.TabIndex = 0;
            // 
            // StockBindingSource
            // 
            this.StockBindingSource.DataMember = "Stock";
            this.StockBindingSource.DataSource = this.dbsonDataSet1;
            // 
            // dbsonDataSet1
            // 
            this.dbsonDataSet1.DataSetName = "dbsonDataSet1";
            this.dbsonDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StockTableAdapter
            // 
            this.StockTableAdapter.ClearBeforeFill = true;
            // 
            // BILLBindingSource
            // 
            this.BILLBindingSource.DataMember = "BILL";
            this.BILLBindingSource.DataSource = this.dbsonDataSet;
            // 
            // dbsonDataSet
            // 
            this.dbsonDataSet.DataSetName = "dbsonDataSet";
            this.dbsonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "customer";
            this.customerBindingSource.DataSource = this.dbsonDataSet;
            // 
            // BILLTableAdapter
            // 
            this.BILLTableAdapter.ClearBeforeFill = true;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 419);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsonDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BILLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BILLBindingSource;
        private dbsonDataSet dbsonDataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource StockBindingSource;
        private dbsonDataSet1 dbsonDataSet1;
        private dbsonDataSetTableAdapters.BILLTableAdapter BILLTableAdapter;
        private dbsonDataSetTableAdapters.customerTableAdapter customerTableAdapter;
        private dbsonDataSet1TableAdapters.StockTableAdapter StockTableAdapter;
    }
}