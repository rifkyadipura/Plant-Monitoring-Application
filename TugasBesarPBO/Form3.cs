using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TugasBesarPBO
{
    public partial class Form3 : Form
    {
        private string username;
        public Form3(string username)
        {
            InitializeComponent();
            this.username = username;

            // Tampilkan username di label
            lblUsersname.Text = $"{username}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Tampilkan pesan konfirmasi
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Jika pengguna memilih "Yes"
            if (result == DialogResult.Yes)
            {
                // Buka form login (Form1)
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Tutup form saat ini
                this.Close();
            }
        }

        private void lblUsersname_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // **Hubungkan ke koleksi users** (Penempatan di sini)
            var usersCollection = MongoDBConnection.GetCollection("tomat");

            try
            {
                // Validasi input
                if (string.IsNullOrEmpty(Tbketerangan.Text) ||
                    string.IsNullOrEmpty(Tbtinggi.Text) || string.IsNullOrEmpty(Tbjadwalsiram.Text) || string.IsNullOrEmpty(Tbjadwalpupuk.Text))
                {
                    MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ambil data dari input pengguna
                string keterangan = Tbketerangan.Text;
                DateTime tanggal = datetanggal.Value;
                string tinggitomat = Tbtinggi.Text;
                string jadwalsiram = Tbjadwalsiram.Text;
                string jadwalpupuk = Tbjadwalpupuk.Text;

                // Buat dokumen BSON untuk disimpan ke MongoDB
                var Datatomat = new BsonDocument
                {
                    { "keterangan", keterangan },
                    { "tanggal", tanggal },
                    { "tinggitomat", tinggitomat },
                    { "jadwalsiram", jadwalsiram},
                    { "jadwalpupuk", jadwalpupuk },
                };

                // Simpan ke koleksi MongoDB
                usersCollection.InsertOne(Datatomat);

                // Tampilkan pesan sukses
                MessageBox.Show("Data pasien berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kosongkan form
                Tbketerangan.Clear();
                Tbtinggi.Clear();
                Tbjadwalsiram.Clear();
                Tbjadwalpupuk.Clear();
                datetanggal.Value = DateTime.Now;

                // Muat ulang data ke DataGridView

            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input yang Anda masukkan tidak valid: {ex.Message}", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(username);
            form4.Show();
            this.Hide();
        }
    }
}
