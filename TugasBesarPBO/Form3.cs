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
            LoadData();

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

        private void LoadData()
        {
            try
            {
                // Hapus semua baris di DataGridView
                dataGridView1.Rows.Clear();

                var collection = MongoDBConnection.GetCollection("daily_tomato_records");

                // Ambil semua dokumen dari koleksi MongoDB
                var documents = collection.Find(new BsonDocument()).ToList();

                // Loop melalui dokumen dan tambahkan ke DataGridView
                foreach (var doc in documents)
                {
                    string _id = doc.GetValue("_id", "").ToString();
                    string keterangan = doc.GetValue("keterangan", "").ToString();
                    DateTime tanggal = doc.GetValue("tanggal", DateTime.Now).ToUniversalTime();
                    string tinggitomat = doc.GetValue("tinggitomat", "").ToString();
                    string kondisidaun = doc.GetValue("kondisidaun", "").ToString();
                    string kebutuhanair = doc.GetValue("kebutuhanair", "").ToString();

                    // Tambahkan baris ke DataGridView
                    dataGridView1.Rows.Add(keterangan, _id, tanggal.ToString("yyyy-MM-dd"), tinggitomat, kondisidaun, kebutuhanair);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var usersCollection = MongoDBConnection.GetCollection("daily_tomato_records");

            try
            {
                // Validasi input
                if (string.IsNullOrEmpty(Tbketerangan.Text) ||
                    string.IsNullOrEmpty(Tbtinggi.Text) || string.IsNullOrEmpty(tbdaun.Text) || string.IsNullOrEmpty(tbair.Text))
                {
                    MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ambil data dari input pengguna
                string keterangan = Tbketerangan.Text;
                DateTime tanggal = datetanggal.Value;
                string tinggitomat = Tbtinggi.Text;
                string kondisidaun = tbdaun.Text;
                string kebutuhanair = tbair.Text;

                // Buat dokumen BSON untuk disimpan ke MongoDB
                var Datatomat = new BsonDocument
                {
                    { "keterangan", keterangan },
                    { "tanggal", tanggal },
                    { "tinggitomat", tinggitomat },
                    { "kondisidaun", kondisidaun},
                    { "kebutuhanair", kebutuhanair},
                };

                // Simpan ke koleksi MongoDB
                usersCollection.InsertOne(Datatomat);

                // Tampilkan pesan sukses
                MessageBox.Show("Data pasien berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kosongkan form
                Tbketerangan.Clear();
                Tbtinggi.Clear();
                tbdaun.Clear();
                tbair.Clear();
                tb_id.Clear();
                datetanggal.Value = DateTime.Now;

                // Muat ulang data ke DataGridView
                LoadData();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cek jika ada baris yang dipilih (e.RowIndex tidak -1)
            if (e.RowIndex >= 0)
            {
                // Ambil data dari baris yang dipilih
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Set data ke TextBox sesuai dengan kolom di DataGridView
                Tbketerangan.Text = row.Cells["Column1"].Value?.ToString() ?? ""; // Nama

                // Periksa apakah nilai tanggal adalah null sebelum diproses
                if (row.Cells["Column2"].Value != null && DateTime.TryParse(row.Cells["Column2"].Value.ToString(), out DateTime tanggal))
                {
                    datetanggal.Value = tanggal; // Set nilai valid ke DateTimePicker
                }
                else
                {
                    datetanggal.Value = DateTime.Now; // Default ke tanggal saat ini jika null atau tidak valid
                    MessageBox.Show("Tanggal tidak valid atau kosong. Mengatur ke tanggal saat ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Tbtinggi.Text = row.Cells["Column3"].Value?.ToString() ?? "";
                tbdaun.Text = row.Cells["Column4"].Value?.ToString() ?? "";
                tbair.Text = row.Cells["Column5"].Value?.ToString() ?? "";
                tb_id.Text = row.Cells["Column6"].Value?.ToString() ?? "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input, pastikan id tidak kosong (karena digunakan sebagai kunci pencarian)
                if (string.IsNullOrEmpty(tb_id.Text))
                {
                    MessageBox.Show("ID harus diisi untuk mengedit data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string keterangan = Tbketerangan.Text;
                DateTime tanggal = datetanggal.Value;
                string tinggi = Tbtinggi.Text;
                string kondisidaun = tbdaun.Text;
                string kebutuhanair = tbair.Text;

                // Build filter untuk mencari dokumen berdasarkan _id
                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(tb_id.Text));

                // Build pembaruan menggunakan UpdateDefinition
                var update = Builders<BsonDocument>.Update.Combine(
                    !string.IsNullOrEmpty(keterangan) ? Builders<BsonDocument>.Update.Set("keterangan", keterangan) : null,
                    Builders<BsonDocument>.Update.Set("tanggal", tanggal),
                    !string.IsNullOrEmpty(tinggi) ? Builders<BsonDocument>.Update.Set("tinggitomat", tinggi) : null,
                    !string.IsNullOrEmpty(kondisidaun) ? Builders<BsonDocument>.Update.Set("kondisidaun", kondisidaun) : null,
                    !string.IsNullOrEmpty(kebutuhanair) ? Builders<BsonDocument>.Update.Set("kebutuhanair", kebutuhanair) : null
                );


                // Panggil metode UpdateDocument dari MongoDBConnection
                MongoDBConnection.UpdateDocument("daily_tomato_records", filter, update);

                // Tampilkan pesan hasil
                MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kosongkan form
                Tbketerangan.Clear();
                Tbtinggi.Clear();
                tbdaun.Clear();
                tbair.Clear();
                tb_id.Clear();
                datetanggal.Value = DateTime.Now;

                // Muat ulang data ke DataGridView
                LoadData();
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

        private void btn_delete_Click_1(object sender, EventArgs e)
        {

            try
            {
                // Validasi input, pastikan ID tidak kosong
                if (string.IsNullOrEmpty(tb_id.Text))
                {
                    MessageBox.Show("ID harus diisi untuk menghapus data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Build filter untuk mencari dokumen berdasarkan _id
                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(tb_id.Text));

                // Eksekusi penghapusan dan simpan hasilnya
                var result = MongoDBConnection.GetCollection("daily_tomato_records").DeleteOne(filter);

                // Tampilkan pesan hasil
                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kosongkan form setelah penghapusan
                    Tbketerangan.Clear();
                    Tbtinggi.Clear();
                    tbdaun.Clear();
                    tbair.Clear();
                    tb_id.Clear();
                    datetanggal.Value = DateTime.Now;

                    // Muat ulang data ke DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ID yang dimasukkan tidak valid! Pastikan formatnya benar.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
