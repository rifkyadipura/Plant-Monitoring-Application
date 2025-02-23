namespace TugasBesarPBO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            panel1 = new Panel();
            btnSchedule = new Button();
            panel3 = new Panel();
            btnLogout = new Button();
            btnDasboard = new Button();
            panel2 = new Panel();
            lblUsersname = new Label();
            pictureBox1 = new PictureBox();
            linkGoToGrafik = new LinkLabel();
            btn_delete = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            button5 = new Button();
            datetanggal = new DateTimePicker();
            Tbtinggi = new TextBox();
            Tbketerangan = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            tbair = new TextBox();
            tb_id = new TextBox();
            tbdaun = new ComboBox();
            btnExportPdf = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(btnSchedule);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btnDasboard);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 561);
            panel1.TabIndex = 0;
            // 
            // btnSchedule
            // 
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.ForeColor = Color.White;
            btnSchedule.Image = (Image)resources.GetObject("btnSchedule.Image");
            btnSchedule.Location = new Point(-1, 197);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(186, 42);
            btnSchedule.TabIndex = 3;
            btnSchedule.Text = "Jadwal       ";
            btnSchedule.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnLogout);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 499);
            panel3.Name = "panel3";
            panel3.Size = new Size(186, 62);
            panel3.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.Location = new Point(-3, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(186, 42);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnDasboard
            // 
            btnDasboard.FlatAppearance.BorderSize = 0;
            btnDasboard.FlatStyle = FlatStyle.Flat;
            btnDasboard.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDasboard.ForeColor = Color.White;
            btnDasboard.Image = (Image)resources.GetObject("btnDasboard.Image");
            btnDasboard.Location = new Point(-1, 148);
            btnDasboard.Name = "btnDasboard";
            btnDasboard.Size = new Size(186, 42);
            btnDasboard.TabIndex = 1;
            btnDasboard.Text = "Dashboard";
            btnDasboard.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDasboard.UseVisualStyleBackColor = true;
            btnDasboard.Click += btnDasboard_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblUsersname);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 144);
            panel2.TabIndex = 0;
            // 
            // lblUsersname
            // 
            lblUsersname.AutoSize = true;
            lblUsersname.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsersname.ForeColor = Color.White;
            lblUsersname.Location = new Point(47, 93);
            lblUsersname.Name = "lblUsersname";
            lblUsersname.Size = new Size(85, 16);
            lblUsersname.TabIndex = 1;
            lblUsersname.Text = "User Name";
            lblUsersname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(60, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // linkGoToGrafik
            // 
            linkGoToGrafik.AutoSize = true;
            linkGoToGrafik.Location = new Point(593, 347);
            linkGoToGrafik.Name = "linkGoToGrafik";
            linkGoToGrafik.Size = new Size(124, 15);
            linkGoToGrafik.TabIndex = 38;
            linkGoToGrafik.TabStop = true;
            linkGoToGrafik.Text = "Go to Grafik Analisis?";
            linkGoToGrafik.LinkClicked += linkGoToGrafik_LinkClicked;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(711, 308);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(112, 34);
            btn_delete.TabIndex = 35;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(592, 308);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 34;
            button4.Text = "Edit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column6, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(548, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(424, 225);
            dataGridView1.TabIndex = 33;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Keterangan";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column6
            // 
            Column6.HeaderText = "_id";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.Visible = false;
            Column6.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tanggal";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Tinggi Tomat";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Kondisi Daun";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.HeaderText = "Kebutuhan Air";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 150;
            // 
            // button5
            // 
            button5.Location = new Point(279, 414);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 32;
            button5.Text = "Simpan";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // datetanggal
            // 
            datetanggal.CustomFormat = "yyyy-MM-dd";
            datetanggal.Format = DateTimePickerFormat.Custom;
            datetanggal.Location = new Point(349, 70);
            datetanggal.Name = "datetanggal";
            datetanggal.Size = new Size(146, 23);
            datetanggal.TabIndex = 31;
            // 
            // Tbtinggi
            // 
            Tbtinggi.Location = new Point(349, 130);
            Tbtinggi.Name = "Tbtinggi";
            Tbtinggi.Size = new Size(146, 23);
            Tbtinggi.TabIndex = 30;
            // 
            // Tbketerangan
            // 
            Tbketerangan.Location = new Point(349, 285);
            Tbketerangan.Name = "Tbketerangan";
            Tbketerangan.Size = new Size(146, 23);
            Tbketerangan.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(192, 130);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 25;
            label7.Text = "Tinggi Tomat";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(188, 197);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(192, 75);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 23;
            label5.Text = "Tanggal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(192, 291);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 22;
            label4.Text = "Keterangan";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(196, 195);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 39;
            label1.Text = "Kondisi Daun";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(192, 241);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 40;
            label3.Text = "Kebutuhan Air";
            // 
            // tbair
            // 
            tbair.Location = new Point(349, 241);
            tbair.Name = "tbair";
            tbair.Size = new Size(146, 23);
            tbair.TabIndex = 42;
            // 
            // tb_id
            // 
            tb_id.Location = new Point(345, 20);
            tb_id.Name = "tb_id";
            tb_id.Size = new Size(150, 23);
            tb_id.TabIndex = 43;
            tb_id.Visible = false;
            // 
            // tbdaun
            // 
            tbdaun.FormattingEnabled = true;
            tbdaun.Location = new Point(349, 189);
            tbdaun.Name = "tbdaun";
            tbdaun.Size = new Size(146, 23);
            tbdaun.TabIndex = 44;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(860, 22);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(112, 34);
            btnExportPdf.TabIndex = 45;
            btnExportPdf.Text = "Export PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(984, 561);
            Controls.Add(btnExportPdf);
            Controls.Add(tbdaun);
            Controls.Add(tb_id);
            Controls.Add(tbair);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(linkGoToGrafik);
            Controls.Add(btn_delete);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(button5);
            Controls.Add(datetanggal);
            Controls.Add(Tbtinggi);
            Controls.Add(Tbketerangan);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label lblUsersname;
        private Button btnDasboard;
        private Button btnLogout;
        private LinkLabel linkGoToGrafik;
        private Button btn_delete;
        private Button button4;
        private DataGridView dataGridView1;
        private Button button5;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox5;
        private TextBox textBox3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker datetanggal;
        private TextBox Tbketerangan;
        private TextBox Tbtinggi;
        private TextBox tbair;
        private Panel panel3;
        private Button btnSchedule;
        private TextBox tb_id;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private ComboBox tbdaun;
        private Button btnExportPdf;
    }
}