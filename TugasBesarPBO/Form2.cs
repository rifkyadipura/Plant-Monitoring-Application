using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TugasBesarPBO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            AddPlaceholder(txtFullName, "Masukkan Nama Lengkap");
            AddPlaceholder(txtUsername, "Masukkan Username");
            AddPlaceholder(txtEmail, "Masukkan Email");
            AddPlaceholder(txtPassword, "Masukkan Password", isPassword: true);

            this.ActiveControl = label1; 

            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        }

        private void AddPlaceholder(TextBox textBox, string placeholderText, bool isPassword = false)
        {
            textBox.Tag = placeholderText;
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;
            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;

                    // Aktifkan PasswordChar jika ini TextBox Password
                    if (isPassword)
                        textBox.PasswordChar = '*';
                }
            };

            // Event untuk menangani fokus keluar
            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;

                    // Nonaktifkan PasswordChar jika ini TextBox Password
                    if (isPassword)
                        textBox.PasswordChar = '\0';
                }
            };
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; 
            }
            else
            {
                if (txtPassword.Text != (string)txtPassword.Tag) 
                {
                    txtPassword.PasswordChar = '*'; 
                }
            }
        }
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil input dari form
                string fullName = txtFullName.Text.Trim();
                string emailAddress = txtEmail.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Validasi input
                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Semua kolom harus diisi.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi format email
                if (!IsValidEmail(emailAddress))
                {
                    MessageBox.Show("Format email tidak valid. Harap masukkan email yang benar.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // **Hubungkan ke koleksi users** (Penempatan di sini)
                var usersCollection = MongoDBConnection.GetCollection("users");

                // Cek apakah username atau email sudah terdaftar
                var existingUser = usersCollection.Find(u => u["username"] == username || u["email_address"] == emailAddress).FirstOrDefault();
                if (existingUser != null)
                {
                    MessageBox.Show("Username atau Email sudah terdaftar. Gunakan data lain.", "Kesalahan Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buat dokumen baru
                var newUser = new BsonDocument
                {
                    { "full_name", fullName },
                    { "username", username },
                    { "email_address", emailAddress },
                    { "hashed_password", HashPassword(txtPassword.Text.Trim()) },
                    { "created_at", DateTime.UtcNow },
                    { "updated_at", DateTime.UtcNow }
                };

                // Simpan ke database
                usersCollection.InsertOne(newUser);

                MessageBox.Show("Registrasi berhasil! Silakan login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pindah ke form login
                Form1 formLogin = new Form1();
                formLogin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fungsi untuk validasi email menggunakan Regex
        private bool IsValidEmail(string email)
        {
            try
            {
                // Gunakan Regex untuk memeriksa format email
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
