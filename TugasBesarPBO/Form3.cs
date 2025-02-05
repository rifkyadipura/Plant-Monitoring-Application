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

            // Tambahkan opsi ke ComboBox tbdaun
            tbdaun.Items.Add("Hijau Sehat");
            tbdaun.Items.Add("Kuning (Kurang Nutrisi)");
            tbdaun.Items.Add("Coklat Layu");
            tbdaun.Items.Add("Bercak Coklat / Hitam (Penyakit / Infeksi)");
            tbdaun.Items.Add("Ujung Daun Kering");

            // Set pilihan default
            tbdaun.SelectedIndex = 0;
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

                    // ✅ Pastikan tinggi tomat diformat dengan 1 digit desimal
                    string tinggiTomat = doc.Contains("tinggi_tomat_cm") ?
                                         Convert.ToDouble(doc["tinggi_tomat_cm"]).ToString("F1") : "0.0";

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

                // ✅ Konversi tinggi tomat ke double dengan format desimal yang tepat
                double tinggiTomat;
                if (!double.TryParse(Tbtinggi.Text.Replace(",", "."), out tinggiTomat))
                {
                    MessageBox.Show("Tinggi tomat harus berupa angka bulat atau desimal! Contoh: 12.5 cm",
                                    "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // ✅ Format tinggi tomat dengan 1 digit desimal sebelum disimpan
                tinggiTomat = Math.Round(tinggiTomat, 1);

                // ✅ Konversi kebutuhan air ke bilangan bulat
                int kebutuhanAir;
                if (!int.TryParse(tbair.Text, out kebutuhanAir))
                {
                    MessageBox.Show("Kebutuhan air harus berupa angka bulat! Contoh: 50 ml",
                                    "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string keterangan = Tbketerangan.Text;
                DateTime tanggal = datetanggal.Value.ToUniversalTime();
                string kondisiDaun = tbdaun.SelectedItem.ToString(); // Ambil nilai dari ComboBox

                var Datatomat = new BsonDocument
                {
                    { "tanggal", datetanggal.Value.ToUniversalTime() },
                    { "tinggi_tomat_cm", tinggiTomat }, // ✅ Nilai sudah dibulatkan
                    { "kondisi_daun", tbdaun.SelectedItem.ToString() },
                    { "kebutuhan_air_ml", int.Parse(tbair.Text) },
                    { "keterangan", Tbketerangan.Text },
                    { "created_by", username },
                    { "created_at", DateTime.UtcNow }
                };

                usersCollection.InsertOne(Datatomat);

                MessageBox.Show("Data tanaman berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Tbketerangan.Clear();
                Tbtinggi.Clear();
                tbdaun.SelectedIndex = 0;
                tbair.Clear();
                tb_id.Clear();
                datetanggal.Value = DateTime.UtcNow;

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
                tbair.Text = row.Cells["KebutuhanAir"].Value?.ToString() ?? "";
                Tbketerangan.Text = row.Cells["Keterangan"].Value?.ToString() ?? "";

                // ✅ Set ComboBox tbdaun sesuai dengan data yang diambil
                string kondisiDaun = row.Cells["KondisiDaun"].Value?.ToString() ?? "Hijau Sehat";
                if (tbdaun.Items.Contains(kondisiDaun))
                {
                    tbdaun.SelectedItem = kondisiDaun;
                }
                else
                {
                    tbdaun.SelectedIndex = 0; // Jika data tidak cocok, pilih default "Hijau Sehat"
                }
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
                    tbdaun.SelectedIndex = 0;
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

                // ✅ Ambil tanggal lama dari database agar tidak berubah
                DateTime tanggalLama = existingDocument["tanggal"].ToUniversalTime();
                DateTime tanggalInput = datetanggal.Value;

                if (tanggalInput.Date == tanggalLama.Date)
                {
                    tanggalInput = tanggalLama; // Gunakan tanggal lama tanpa perubahan
                }
                else
                {
                    tanggalInput = DateTime.SpecifyKind(tanggalInput, DateTimeKind.Utc);
                }

                // ✅ Ambil tinggi tomat dari input dan bulatkan ke 1 desimal
                double tinggiTomat;
                if (!double.TryParse(Tbtinggi.Text.Replace(",", "."), out tinggiTomat))
                {
                    MessageBox.Show("Tinggi tomat harus berupa angka bulat atau desimal! Contoh: 12.5 cm",
                                    "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tinggiTomat = Math.Round(tinggiTomat, 1); // ✅ Bulatkan ke 1 desimal

                // ✅ Konversi kebutuhan air ke integer
                int kebutuhanAir;
                if (!int.TryParse(tbair.Text, out kebutuhanAir))
                {
                    MessageBox.Show("Kebutuhan air harus berupa angka bulat! Contoh: 50 ml",
                                    "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string kondisiDaun = tbdaun.Text;
                string keterangan = Tbketerangan.Text;

                var update = Builders<BsonDocument>.Update
                    .Set("tanggal", tanggalInput)
                    .Set("tinggi_tomat_cm", tinggiTomat) // ✅ Nilai sudah diformat
                    .Set("kondisi_daun", tbdaun.SelectedItem.ToString())
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

        private void linkGoToGrafik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 grafikForm = new Form5(username);
            grafikForm.Show();
        }
    }
}
