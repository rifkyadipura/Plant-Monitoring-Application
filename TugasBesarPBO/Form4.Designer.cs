namespace TugasBesarPBO
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            panel3 = new Panel();
            btnLogout = new Button();
            panel1 = new Panel();
            btnSchedule = new Button();
            btnDasboard = new Button();
            panel2 = new Panel();
            lblUsersname = new Label();
            pictureBox1 = new PictureBox();
            btnSaveSchedule = new Button();
            btnCreateSchedule = new Button();
            dataGridViewsSchedule = new DataGridView();
            panelModal = new Panel();
            btnCloseModal = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            rtbKeterangan = new RichTextBox();
            numJumlahPelaksanaan = new NumericUpDown();
            txtAktivitas = new TextBox();
            cmbHari = new ComboBox();
            panel4 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsSchedule).BeginInit();
            panelModal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numJumlahPelaksanaan).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
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
            btnLogout.ForeColor = Color.FromArgb(0, 126, 249);
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btnSchedule);
            panel1.Controls.Add(btnDasboard);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 561);
            panel1.TabIndex = 43;
            // 
            // btnSchedule
            // 
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.ForeColor = Color.FromArgb(0, 126, 249);
            btnSchedule.Image = (Image)resources.GetObject("btnSchedule.Image");
            btnSchedule.Location = new Point(-1, 197);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(186, 42);
            btnSchedule.TabIndex = 1;
            btnSchedule.Text = "Jadwal       ";
            btnSchedule.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnDasboard
            // 
            btnDasboard.FlatAppearance.BorderSize = 0;
            btnDasboard.FlatStyle = FlatStyle.Flat;
            btnDasboard.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDasboard.ForeColor = Color.FromArgb(0, 126, 249);
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
            lblUsersname.ForeColor = Color.FromArgb(0, 126, 249);
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
            // btnSaveSchedule
            // 
            btnSaveSchedule.BackColor = Color.FromArgb(24, 30, 54);
            btnSaveSchedule.FlatAppearance.BorderSize = 0;
            btnSaveSchedule.FlatStyle = FlatStyle.Flat;
            btnSaveSchedule.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveSchedule.ForeColor = Color.FromArgb(0, 126, 249);
            btnSaveSchedule.Image = (Image)resources.GetObject("btnSaveSchedule.Image");
            btnSaveSchedule.Location = new Point(120, 235);
            btnSaveSchedule.Name = "btnSaveSchedule";
            btnSaveSchedule.Size = new Size(112, 39);
            btnSaveSchedule.TabIndex = 1;
            btnSaveSchedule.Text = "Save";
            btnSaveSchedule.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSaveSchedule.UseVisualStyleBackColor = false;
            btnSaveSchedule.Click += btnSaveSchedule_Click;
            // 
            // btnCreateSchedule
            // 
            btnCreateSchedule.FlatAppearance.BorderSize = 0;
            btnCreateSchedule.FlatStyle = FlatStyle.Flat;
            btnCreateSchedule.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateSchedule.ForeColor = Color.FromArgb(0, 126, 249);
            btnCreateSchedule.Image = (Image)resources.GetObject("btnCreateSchedule.Image");
            btnCreateSchedule.Location = new Point(540, 34);
            btnCreateSchedule.Name = "btnCreateSchedule";
            btnCreateSchedule.Size = new Size(186, 42);
            btnCreateSchedule.TabIndex = 1;
            btnCreateSchedule.Text = "Buat Jadwal";
            btnCreateSchedule.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCreateSchedule.UseVisualStyleBackColor = true;
            btnCreateSchedule.Click += btnCreateSchedule_Click;
            // 
            // dataGridViewsSchedule
            // 
            dataGridViewsSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewsSchedule.Location = new Point(26, 82);
            dataGridViewsSchedule.Name = "dataGridViewsSchedule";
            dataGridViewsSchedule.Size = new Size(700, 305);
            dataGridViewsSchedule.TabIndex = 44;
            dataGridViewsSchedule.CellContentClick += dataGridViewsSchedule_CellContentClick;
            // 
            // panelModal
            // 
            panelModal.BorderStyle = BorderStyle.Fixed3D;
            panelModal.Controls.Add(btnCloseModal);
            panelModal.Controls.Add(label6);
            panelModal.Controls.Add(label5);
            panelModal.Controls.Add(label4);
            panelModal.Controls.Add(label3);
            panelModal.Controls.Add(label2);
            panelModal.Controls.Add(rtbKeterangan);
            panelModal.Controls.Add(btnSaveSchedule);
            panelModal.Controls.Add(numJumlahPelaksanaan);
            panelModal.Controls.Add(txtAktivitas);
            panelModal.Controls.Add(cmbHari);
            panelModal.Location = new Point(231, 34);
            panelModal.Name = "panelModal";
            panelModal.Size = new Size(324, 288);
            panelModal.TabIndex = 45;
            // 
            // btnCloseModal
            // 
            btnCloseModal.BackColor = Color.Silver;
            btnCloseModal.FlatAppearance.BorderSize = 0;
            btnCloseModal.FlatStyle = FlatStyle.Flat;
            btnCloseModal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseModal.ForeColor = Color.FromArgb(0, 126, 249);
            btnCloseModal.Image = (Image)resources.GetObject("btnCloseModal.Image");
            btnCloseModal.Location = new Point(296, 2);
            btnCloseModal.Name = "btnCloseModal";
            btnCloseModal.Size = new Size(23, 22);
            btnCloseModal.TabIndex = 47;
            btnCloseModal.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCloseModal.UseVisualStyleBackColor = false;
            btnCloseModal.Click += btnCloseModal_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 126, 249);
            label6.Location = new Point(5, 174);
            label6.Name = "label6";
            label6.Size = new Size(83, 18);
            label6.TabIndex = 48;
            label6.Text = "Keterangan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 126, 249);
            label5.Location = new Point(5, 134);
            label5.Name = "label5";
            label5.Size = new Size(145, 18);
            label5.TabIndex = 48;
            label5.Text = "Jumlah Pelaksanaan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 126, 249);
            label4.Location = new Point(5, 92);
            label4.Name = "label4";
            label4.Size = new Size(62, 18);
            label4.TabIndex = 48;
            label4.Text = "Aktivitas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 126, 249);
            label3.Location = new Point(5, 59);
            label3.Name = "label3";
            label3.Size = new Size(35, 18);
            label3.TabIndex = 48;
            label3.Text = "Hari";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 126, 249);
            label2.Location = new Point(68, 15);
            label2.Name = "label2";
            label2.Size = new Size(191, 24);
            label2.TabIndex = 47;
            label2.Text = "Formulir Perawatan";
            // 
            // rtbKeterangan
            // 
            rtbKeterangan.Location = new Point(156, 171);
            rtbKeterangan.Name = "rtbKeterangan";
            rtbKeterangan.Size = new Size(156, 51);
            rtbKeterangan.TabIndex = 4;
            rtbKeterangan.Text = "";
            // 
            // numJumlahPelaksanaan
            // 
            numJumlahPelaksanaan.Location = new Point(156, 132);
            numJumlahPelaksanaan.Name = "numJumlahPelaksanaan";
            numJumlahPelaksanaan.Size = new Size(156, 23);
            numJumlahPelaksanaan.TabIndex = 2;
            // 
            // txtAktivitas
            // 
            txtAktivitas.Location = new Point(156, 90);
            txtAktivitas.Name = "txtAktivitas";
            txtAktivitas.Size = new Size(153, 23);
            txtAktivitas.TabIndex = 1;
            // 
            // cmbHari
            // 
            cmbHari.FormattingEnabled = true;
            cmbHari.Location = new Point(156, 57);
            cmbHari.Name = "cmbHari";
            cmbHari.Size = new Size(153, 23);
            cmbHari.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(186, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(749, 86);
            panel4.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 126, 249);
            label1.Location = new Point(231, 25);
            label1.Name = "label1";
            label1.Size = new Size(340, 42);
            label1.TabIndex = 0;
            label1.Text = "Jadwal Perawatan";
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridViewsSchedule);
            panel5.Controls.Add(btnCreateSchedule);
            panel5.Controls.Add(panelModal);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(186, 86);
            panel5.Name = "panel5";
            panel5.Size = new Size(749, 475);
            panel5.TabIndex = 47;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(935, 561);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsSchedule).EndInit();
            panelModal.ResumeLayout(false);
            panelModal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numJumlahPelaksanaan).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Button btnLogout;
        private Panel panel1;
        private Button btnSaveSchedule;
        private Button btnCreateSchedule;
        private Button btnSchedule;
        private Button btnDasboard;
        private Panel panel2;
        private Label lblUsersname;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewsSchedule;
        private Panel panelModal;
        private NumericUpDown numJumlahPelaksanaan;
        private TextBox txtAktivitas;
        private ComboBox cmbHari;
        private RichTextBox rtbKeterangan;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnCloseModal;
        private Panel panel5;
    }
}