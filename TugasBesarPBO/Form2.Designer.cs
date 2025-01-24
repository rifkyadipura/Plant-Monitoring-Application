namespace TugasBesarPBO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            linkLogin = new LinkLabel();
            label2 = new Label();
            btnRegister = new Button();
            panel2 = new Panel();
            txtPassword = new TextBox();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            txtFullName = new TextBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            panel3 = new Panel();
            txtEmail = new TextBox();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            txtUsername = new TextBox();
            pictureBox4 = new PictureBox();
            chkShowPassword = new CheckBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLogin.Location = new Point(281, 404);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(40, 17);
            linkLogin.TabIndex = 13;
            linkLogin.TabStop = true;
            linkLogin.Text = "Login";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(132, 405);
            label2.Name = "label2";
            label2.Size = new Size(152, 17);
            label2.TabIndex = 12;
            label2.Text = "Sudah mempunyai akun?";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 120, 212);
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(75, 355);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(323, 40);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(chkShowPassword);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(pictureBox3);
            panel2.Location = new Point(75, 284);
            panel2.Name = "panel2";
            panel2.Size = new Size(323, 48);
            panel2.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(67, 17);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(231, 18);
            txtPassword.TabIndex = 4;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(8, 7);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(75, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 48);
            panel1.TabIndex = 9;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.ForeColor = Color.Black;
            txtFullName.Location = new Point(67, 17);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(241, 18);
            txtFullName.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(8, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(197, 51);
            label1.Name = "label1";
            label1.Size = new Size(91, 30);
            label1.TabIndex = 8;
            label1.Text = "Sign Up";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(75, 176);
            panel3.Name = "panel3";
            panel3.Size = new Size(323, 48);
            panel3.TabIndex = 14;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(67, 17);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(241, 18);
            txtEmail.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(txtUsername);
            panel4.Controls.Add(pictureBox4);
            panel4.Location = new Point(75, 230);
            panel4.Name = "panel4";
            panel4.Size = new Size(323, 48);
            panel4.TabIndex = 15;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(67, 17);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(241, 18);
            txtUsername.TabIndex = 4;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(8, 7);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 35);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(303, 19);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(15, 14);
            chkShowPassword.TabIndex = 23;
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 247);
            ClientSize = new Size(469, 543);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(linkLogin);
            Controls.Add(label2);
            Controls.Add(btnRegister);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLogin;
        private Label label2;
        private Button btnRegister;
        private Panel panel2;
        private TextBox txtPassword;
        private PictureBox pictureBox3;
        private Panel panel1;
        private TextBox txtFullName;
        private PictureBox pictureBox2;
        private Label label1;
        private Panel panel3;
        private TextBox txtEmail;
        private PictureBox pictureBox1;
        private Panel panel4;
        private TextBox txtUsername;
        private PictureBox pictureBox4;
        private CheckBox chkShowPassword;
    }
}