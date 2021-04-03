namespace ImperialPlastics
{
    partial class Purchased
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbttype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.txtref = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtbno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbttype);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.cmbtype);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.txtamount);
            this.panel1.Controls.Add(this.txtref);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.txtbno);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 460);
            this.panel1.TabIndex = 0;
            // 
            // cmbttype
            // 
            this.cmbttype.FormattingEnabled = true;
            this.cmbttype.Items.AddRange(new object[] {
            "Payment"});
            this.cmbttype.Location = new System.Drawing.Point(332, 47);
            this.cmbttype.Name = "cmbttype";
            this.cmbttype.Size = new System.Drawing.Size(199, 21);
            this.cmbttype.TabIndex = 87;
            this.cmbttype.Text = "Payment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 86;
            this.label4.Text = "Trn Type";
            // 
            // cmbname
            // 
            this.cmbname.FormattingEnabled = true;
            this.cmbname.Items.AddRange(new object[] {
            "By Cheque",
            "By Cash"});
            this.cmbname.Location = new System.Drawing.Point(332, 110);
            this.cmbname.Name = "cmbname";
            this.cmbname.Size = new System.Drawing.Size(199, 21);
            this.cmbname.TabIndex = 85;
            this.cmbname.Text = "select";
            this.cmbname.SelectedIndexChanged += new System.EventHandler(this.cmbname_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 84;
            this.label1.Text = "Amount";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(332, 80);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(199, 20);
            this.dateTimePicker2.TabIndex = 54;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(241, 80);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(71, 17);
            this.label32.TabIndex = 52;
            this.label32.Text = "Rec. Date";
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "By Cheque",
            "By Cash"});
            this.cmbtype.Location = new System.Drawing.Point(332, 141);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(199, 21);
            this.cmbtype.TabIndex = 51;
            this.cmbtype.Text = "By Cash";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label.Location = new System.Drawing.Point(593, 37);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(13, 13);
            this.label.TabIndex = 83;
            this.label.Text = "0";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(332, 207);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(199, 20);
            this.txtamount.TabIndex = 22;
            // 
            // txtref
            // 
            this.txtref.Location = new System.Drawing.Point(332, 173);
            this.txtref.Name = "txtref";
            this.txtref.Size = new System.Drawing.Size(199, 20);
            this.txtref.TabIndex = 21;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(220, 141);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 17);
            this.label30.TabIndex = 18;
            this.label30.Text = "Receipt Type";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(256, 176);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 17);
            this.label31.TabIndex = 17;
            this.label31.Text = "Ref No.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 78;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(395, 240);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 77;
            this.button5.Text = "Delete";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 240);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 76;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(215, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 75;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(725, 177);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtbno
            // 
            this.txtbno.Location = new System.Drawing.Point(332, 15);
            this.txtbno.Name = "txtbno";
            this.txtbno.Size = new System.Drawing.Size(79, 20);
            this.txtbno.TabIndex = 0;
            this.txtbno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbno_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 67;
            this.label3.Text = "Bill No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Name";
            // 
            // Purchased
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 460);
            this.Controls.Add(this.panel1);
            this.Name = "Purchased";
            this.Text = "Purchased";
            this.Load += new System.EventHandler(this.Purchased_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtbno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.TextBox txtref;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbname;
        private System.Windows.Forms.ComboBox cmbttype;
        private System.Windows.Forms.Label label4;

    }
}