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
            rtbKeterangan = new RichTextBox();
            numJumlahPelaksanaan = new NumericUpDown();
            txtAktivitas = new TextBox();
            cmbHari = new ComboBox();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsSchedule).BeginInit();
            panelModal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numJumlahPelaksanaan).BeginInit();
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
            btnSaveSchedule.FlatAppearance.BorderSize = 0;
            btnSaveSchedule.FlatStyle = FlatStyle.Flat;
            btnSaveSchedule.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveSchedule.ForeColor = Color.FromArgb(0, 126, 249);
            btnSaveSchedule.Image = (Image)resources.GetObject("btnSaveSchedule.Image");
            btnSaveSchedule.Location = new Point(65, 255);
            btnSaveSchedule.Name = "btnSaveSchedule";
            btnSaveSchedule.Size = new Size(186, 42);
            btnSaveSchedule.TabIndex = 1;
            btnSaveSchedule.Text = "Save";
            btnSaveSchedule.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSaveSchedule.UseVisualStyleBackColor = true;
            btnSaveSchedule.Click += btnSaveSchedule_Click;
            // 
            // btnCreateSchedule
            // 
            btnCreateSchedule.FlatAppearance.BorderSize = 0;
            btnCreateSchedule.FlatStyle = FlatStyle.Flat;
            btnCreateSchedule.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateSchedule.ForeColor = Color.FromArgb(0, 126, 249);
            btnCreateSchedule.Image = (Image)resources.GetObject("btnCreateSchedule.Image");
            btnCreateSchedule.Location = new Point(302, 117);
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
            dataGridViewsSchedule.Location = new Point(248, 165);
            dataGridViewsSchedule.Name = "dataGridViewsSchedule";
            dataGridViewsSchedule.Size = new Size(317, 219);
            dataGridViewsSchedule.TabIndex = 44;
            // 
            // panelModal
            // 
            panelModal.Controls.Add(rtbKeterangan);
            panelModal.Controls.Add(btnSaveSchedule);
            panelModal.Controls.Add(numJumlahPelaksanaan);
            panelModal.Controls.Add(txtAktivitas);
            panelModal.Controls.Add(cmbHari);
            panelModal.Location = new Point(631, 148);
            panelModal.Name = "panelModal";
            panelModal.Size = new Size(283, 305);
            panelModal.TabIndex = 45;
            // 
            // rtbKeterangan
            // 
            rtbKeterangan.Location = new Point(148, 153);
            rtbKeterangan.Name = "rtbKeterangan";
            rtbKeterangan.Size = new Size(132, 96);
            rtbKeterangan.TabIndex = 4;
            rtbKeterangan.Text = "";
            // 
            // numJumlahPelaksanaan
            // 
            numJumlahPelaksanaan.Location = new Point(152, 114);
            numJumlahPelaksanaan.Name = "numJumlahPelaksanaan";
            numJumlahPelaksanaan.Size = new Size(120, 23);
            numJumlahPelaksanaan.TabIndex = 2;
            // 
            // txtAktivitas
            // 
            txtAktivitas.Location = new Point(151, 72);
            txtAktivitas.Name = "txtAktivitas";
            txtAktivitas.Size = new Size(118, 23);
            txtAktivitas.TabIndex = 1;
            // 
            // cmbHari
            // 
            cmbHari.FormattingEnabled = true;
            cmbHari.Location = new Point(148, 33);
            cmbHari.Name = "cmbHari";
            cmbHari.Size = new Size(121, 23);
            cmbHari.TabIndex = 0;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(935, 561);
            Controls.Add(panelModal);
            Controls.Add(dataGridViewsSchedule);
            Controls.Add(panel1);
            Controls.Add(btnCreateSchedule);
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
    }
}