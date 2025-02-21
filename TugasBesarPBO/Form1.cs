using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;

namespace TugasBesarPBO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AddPlaceholder(txtUsername, "Masukkan Username");
            AddPlaceholder(txtPassword, "Masukkan Password", isPassword: true);

            // Atur fokus awal ke label
            this.ActiveControl = label1; 
            // Tambahkan event untuk show/hide password
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
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username dan Password harus diisi.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usersCollection = MongoDBConnection.GetCollection("users");
                var user = usersCollection.Find(u => u["username"] == username).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Username tidak ditemukan.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = user["hashed_password"].AsString;
                if (!VerifyPassword(password, hashedPassword))
                {
                    MessageBox.Show("Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ambil data jadwal hari ini dari koleksi schedules
                var schedulesCollection = MongoDBConnection.GetCollection("schedules");
                string today = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("id-ID"));

                // Filter untuk mengambil jadwal yang dibuat oleh pengguna yang login
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("hari", today), 
                    Builders<BsonDocument>.Filter.Eq("created_by", username) 
                );

                // Ambil jadwal berdasarkan hari ini dan username
                var todaysSchedules = schedulesCollection.Find(filter).ToList();

                // Jika ada jadwal hari ini
                if (todaysSchedules.Any())
                {
                    string jadwalHariIni = string.Join("\n", todaysSchedules.Select(s =>
                        $"- Aktivitas: {s["aktivitas"]}\n  Keterangan: {s["keterangan"]}\n"));

                    MessageBox.Show($"Jadwal Hari {today} ini:\n{jadwalHariIni}", "Pengingat Perawatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Tidak ada jadwal perawatan untuk hari {today} ini.", "Pengingat Perawatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Arahkan ke Form3 (dashboard)
                Form3 formDashboard = new Form3(username);
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
