using MongoDB.Driver;
using System.Text;

namespace TugasBesarPBO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Tambahkan placeholder untuk username dan password
            AddPlaceholder(txtUsername, "Masukkan Username");
            AddPlaceholder(txtPassword, "Masukkan Password", isPassword: true);

            // Atur fokus awal ke label atau elemen lain
            this.ActiveControl = label1; // Pastikan label1 ada di form Anda

            // Tambahkan event untuk show/hide password
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        }

        private void AddPlaceholder(TextBox textBox, string placeholderText, bool isPassword = false)
        {
            // Simpan placeholder pada TextBox.Tag
            textBox.Tag = placeholderText;

            // Atur teks awal sebagai placeholder
            textBox.Text = placeholderText;

            // Warna placeholder
            textBox.ForeColor = Color.Gray;

            // Event untuk menangani fokus masuk
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
                txtPassword.PasswordChar = '\0'; // Tampilkan password
            }
            else
            {
                if (txtPassword.Text != (string)txtPassword.Tag) // Jangan aktifkan jika placeholder
                {
                    txtPassword.PasswordChar = '*'; // Sembunyikan password
                }
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 formRegister = new Form2();
            formRegister.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil input dari form
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Validasi input kosong
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username dan Password harus diisi.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hubungkan ke koleksi users
                var usersCollection = MongoDBConnection.GetCollection("users");

                // Cari pengguna berdasarkan username
                var user = usersCollection.Find(u => u["username"] == username).FirstOrDefault();

                // Jika pengguna tidak ditemukan
                if (user == null)
                {
                    MessageBox.Show("Username tidak ditemukan.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validasi password
                string hashedPassword = user["hashed_password"].AsString;
                if (!VerifyPassword(password, hashedPassword))
                {
                    MessageBox.Show("Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Login berhasil
                MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Arahkan ke Form3
                Form3 formDashboard = new Form3(username); // Kirim username
                formDashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fungsi untuk memverifikasi password
        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                string hashedInput = Convert.ToBase64String(hashedBytes);
                return hashedInput == hashedPassword;
            }
        }
    }
}
