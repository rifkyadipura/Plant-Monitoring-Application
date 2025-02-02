using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TugasBesarPBO
{
    public partial class Form3 : Form
    {
        private string username;
        public Form3(string username)
        {
            InitializeComponent();
            this.username = username;
            SetupDataGridView();
            LoadData();

            // Tampilkan username di label
            lblUsersname.Text = $"{username}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

            // Mencegah baris kosong muncul
            dataGridView1.AllowUserToAddRows = false;

            // Mengatur kolom DataGridView
            dataGridView1.Columns.Add("Nomor", "No.");
            dataGridView1.Columns.Add("Tanggal", "Tanggal");
            dataGridView1.Columns.Add("TinggiTomat", "Tinggi Tomat (cm)");
            dataGridView1.Columns.Add("KondisiDaun", "Kondisi Daun");
            dataGridView1.Columns.Add("KebutuhanAir", "Kebutuhan Air (ml)");
            dataGridView1.Columns.Add("Keterangan", "Keterangan");

            // Tambahkan kolom ID tetapi disembunyikan
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "ID";
            idColumn.HeaderText = "ID";
            idColumn.Visible = false;
            dataGridView1.Columns.Add(idColumn);

            // Mencegah editing manual
            dataGridView1.ReadOnly = true;
        }

        private void LoadData()
        {
            try
            {
                dataGridView1.Rows.Clear();

                var collection = MongoDBConnection.GetCollection("daily_tomato_records");

                // Hanya mengambil data yang dibuat oleh akun yang sedang login
                var filter = Builders<BsonDocument>.Filter.Eq("created_by", username);

                var documents = collection.Find(filter)
                                          .Sort(Builders<BsonDocument>.Sort.Descending("tanggal"))
                                          .ToList();

                int nomor = 1;

                foreach (var doc in documents)
                {
                    string _id = doc.Contains("_id") ? doc["_id"].ToString() : "-";
                    DateTime tanggalRaw = doc.Contains("tanggal") ? doc["tanggal"].ToUniversalTime() : DateTime.UtcNow;
                    string tanggal = tanggalRaw.ToLocalTime().ToString("yyyy-MM-dd");

                    string tinggiTomat = doc.Contains("tinggi_tomat_cm") ? doc["tinggi_tomat_cm"].ToString() : "0";
                    string kondisiDaun = doc.Contains("kondisi_daun") ? doc["kondisi_daun"].ToString() : "-";
                    string kebutuhanAir = doc.Contains("kebutuhan_air_ml") ? doc["kebutuhan_air_ml"].ToString() : "0";
                    string keterangan = doc.Contains("keterangan") ? doc["keterangan"].ToString() : "-";

                    dataGridView1.Rows.Add(nomor++, tanggal, tinggiTomat, kondisiDaun, kebutuhanAir, keterangan, _id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(username);
            form4.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var usersCollection = MongoDBConnection.GetCollection("daily_tomato_records");

            try
            {
                if (string.IsNullOrEmpty(Tbketerangan.Text) ||
                    string.IsNullOrEmpty(Tbtinggi.Text) || string.IsNullOrEmpty(tbdaun.Text) || string.IsNullOrEmpty(tbair.Text))
                {
                    MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int tinggiTomat = int.Parse(Tbtinggi.Text);
                int kebutuhanAir = int.Parse(tbair.Text);
                string keterangan = Tbketerangan.Text;
                DateTime tanggal = datetanggal.Value.ToUniversalTime();
                string kondisiDaun = tbdaun.Text;

                var Datatomat = new BsonDocument
                {
                    { "tanggal", tanggal },
                    { "tinggi_tomat_cm", tinggiTomat },
                    { "kondisi_daun", kondisiDaun },
                    { "kebutuhan_air_ml", kebutuhanAir },
                    { "keterangan", keterangan },
                    { "created_by", username }, // ✅ Simpan username yang membuat data
                    { "created_at", DateTime.UtcNow } // ✅ Simpan waktu pembuatan dalam UTC
                };

                usersCollection.InsertOne(Datatomat);

                MessageBox.Show("Data tanaman berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Tbketerangan.Clear();
                Tbtinggi.Clear();
                tbdaun.Clear();
                tbair.Clear();
                tb_id.Clear();
                datetanggal.Value = DateTime.UtcNow;

                LoadData();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input angka tidak valid: {ex.Message}", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tb_id.Text = row.Cells["ID"].Value?.ToString() ?? "";
                if (row.Cells["Tanggal"].Value != null && DateTime.TryParse(row.Cells["Tanggal"].Value.ToString(), out DateTime tanggal))
                {
                    datetanggal.Value = tanggal;
                }
                else
                {
                    datetanggal.Value = DateTime.Now;
                    MessageBox.Show("Tanggal tidak valid atau kosong. Mengatur ke tanggal saat ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Tbtinggi.Text = row.Cells["TinggiTomat"].Value?.ToString() ?? "";
                tbdaun.Text = row.Cells["KondisiDaun"].Value?.ToString() ?? "";
                tbair.Text = row.Cells["KebutuhanAir"].Value?.ToString() ?? "";
                Tbketerangan.Text = row.Cells["Keterangan"].Value?.ToString() ?? "";
            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tb_id.Text))
                {
                    MessageBox.Show("ID harus diisi untuk menghapus data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(tb_id.Text));
                var result = MongoDBConnection.GetCollection("daily_tomato_records").DeleteOne(filter);

                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Tbketerangan.Clear();
                    Tbtinggi.Clear();
                    tbdaun.Clear();
                    tbair.Clear();
                    tb_id.Clear();
                    datetanggal.Value = DateTime.Now;

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tb_id.Text))
                {
                    MessageBox.Show("ID harus diisi untuk mengedit data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(tb_id.Text));

                var existingDocument = MongoDBConnection.GetCollection("daily_tomato_records").Find(filter).FirstOrDefault();
                if (existingDocument == null)
                {
                    MessageBox.Show("Data tidak ditemukan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Ambil tanggal lama dari database dan pastikan tidak berubah jika user tidak mengedit
                DateTime tanggalLama = existingDocument["tanggal"].ToUniversalTime();
                DateTime tanggalInput = datetanggal.Value; // Nilai dari DateTimePicker

                // ✅ Jika user tidak mengubah tanggal, gunakan tanggal lama
                if (tanggalInput.Date == tanggalLama.Date)
                {
                    tanggalInput = tanggalLama; // Gunakan tanggal lama tanpa perubahan
                }
                else
                {
                    tanggalInput = DateTime.SpecifyKind(tanggalInput, DateTimeKind.Utc); // Pastikan disimpan dalam UTC
                }

                int tinggiTomat = int.Parse(Tbtinggi.Text);
                string kondisiDaun = tbdaun.Text;
                int kebutuhanAir = int.Parse(tbair.Text);
                string keterangan = Tbketerangan.Text;

                var update = Builders<BsonDocument>.Update
                    .Set("tanggal", tanggalInput) // ✅ Pastikan tidak terjadi perubahan waktu
                    .Set("tinggi_tomat_cm", tinggiTomat)
                    .Set("kondisi_daun", kondisiDaun)
                    .Set("kebutuhan_air_ml", kebutuhanAir)
                    .Set("keterangan", keterangan);

                MongoDBConnection.UpdateDocument("daily_tomato_records", filter, update);

                MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input tidak valid: {ex.Message}", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
