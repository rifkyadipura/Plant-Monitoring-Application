using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TugasBesarPBO
{
    public partial class Form4 : Form
    {
        private string username;
        private string selectedScheduleId = null; // ID jadwal yang dipilih untuk update/delete

        public Form4(string username)
        {
            InitializeComponent();
            this.username = username;

            lblUsersname.Text = $"{username}";

            // Tambahkan daftar hari ke ComboBox
            cmbHari.Items.AddRange(new string[]
            {
                "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu"
            });

            // Sembunyikan panel modal
            panelModal.Visible = false;

            // Muat jadwal awal
            LoadSchedules();
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(username);
            form3.Show();
            this.Hide();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            this.Refresh();
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

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            // Bersihkan input di modal
            ClearModalInputs();
            selectedScheduleId = null;

            // Tampilkan modal untuk Create
            panelModal.Visible = true;
            panelModal.BringToFront();
            btnSaveSchedule.Text = "Save"; // Pastikan tombol menunjukkan mode "Create"
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil input dari modal
                string hari = cmbHari.SelectedItem?.ToString();
                string aktivitas = txtAktivitas.Text.Trim();
                int jumlahPelaksanaan = (int)numJumlahPelaksanaan.Value;
                string keterangan = rtbKeterangan.Text.Trim();

                // Validasi input
                if (string.IsNullOrEmpty(hari) || string.IsNullOrEmpty(aktivitas) || string.IsNullOrEmpty(keterangan))
                {
                    MessageBox.Show("Semua kolom harus diisi.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var schedulesCollection = MongoDBConnection.GetCollection("schedules");

                // Cek apakah hari sudah dijadwalkan
                var existingSchedule = schedulesCollection.Find(new BsonDocument { { "hari", hari } }).FirstOrDefault();

                if (selectedScheduleId == null) // Jika Create
                {
                    if (existingSchedule != null)
                    {
                        MessageBox.Show("Hari ini sudah dijadwalkan. Silakan pilih hari lain.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newSchedule = new BsonDocument
                    {
                        { "hari", hari },
                        { "aktivitas", aktivitas },
                        { "jumlah_pelaksanaan", jumlahPelaksanaan },
                        { "keterangan", keterangan },
                        { "created_by", username },
                        { "created_at", DateTime.UtcNow }
                    };
                    schedulesCollection.InsertOne(newSchedule);
                    MessageBox.Show("Jadwal berhasil dibuat.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Jika Update
                {
                    // Validasi agar tidak bisa mengubah ke hari lain yang sudah ada
                    if (existingSchedule != null && existingSchedule["_id"].ToString() != selectedScheduleId)
                    {
                        MessageBox.Show("Hari ini sudah dijadwalkan. Silakan pilih hari lain.", "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(selectedScheduleId));
                    var update = Builders<BsonDocument>.Update
                        .Set("hari", hari)
                        .Set("aktivitas", aktivitas)
                        .Set("jumlah_pelaksanaan", jumlahPelaksanaan)
                        .Set("keterangan", keterangan)
                        .Set("updated_at", DateTime.UtcNow);
                    schedulesCollection.UpdateOne(filter, update);
                    MessageBox.Show("Jadwal berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refresh tabel dan sembunyikan modal
                LoadSchedules();
                panelModal.Visible = false;

                // Bersihkan ID jadwal yang dipilih
                selectedScheduleId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSchedules()
        {
            try
            {
                var schedulesCollection = MongoDBConnection.GetCollection("schedules");

                // Filter hanya mengambil data berdasarkan username pengguna yang login
                var filter = Builders<BsonDocument>.Filter.Eq("created_by", username);
                var schedules = schedulesCollection.Find(filter).ToList();

                dataGridViewsSchedule.DataSource = schedules.Select((s, index) => new
                {
                    No = index + 1,
                    Id = s["_id"].ToString(), // Pastikan kolom "_id" dipetakan sebagai "Id"
                    Hari = s["hari"].AsString,
                    Aktivitas = s["aktivitas"].AsString,
                    JumlahPelaksanaan = s.Contains("jumlah_pelaksanaan") ? s["jumlah_pelaksanaan"].AsInt32 : 0, // Default 0
                    Keterangan = s.Contains("keterangan") ? s["keterangan"].AsString : "-" // Default "-"
                }).ToList();

                // Tambahkan kolom tombol untuk Update dan Delete jika belum ada
                if (!dataGridViewsSchedule.Columns.Contains("Update"))
                {
                    DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Update",
                        Name = "Update",
                        Text = "Update",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewsSchedule.Columns.Add(updateColumn);
                }

                if (!dataGridViewsSchedule.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Delete",
                        Name = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewsSchedule.Columns.Add(deleteColumn);
                }

                dataGridViewsSchedule.Columns["Id"].Visible = false; // Sembunyikan kolom ID

                // Atur ukuran kolom secara manual
                dataGridViewsSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Matikan otomatisasi ukuran
                dataGridViewsSchedule.Columns["No"].Width = 50; // Kolom "No" kecil
                dataGridViewsSchedule.Columns["Hari"].Width = 100; // Kolom "Hari"
                dataGridViewsSchedule.Columns["Aktivitas"].Width = 150; // Kolom "Aktivitas" lebih besar
                dataGridViewsSchedule.Columns["JumlahPelaksanaan"].Width = 120; // Kolom "JumlahPelaksanaan"
                dataGridViewsSchedule.Columns["Keterangan"].Width = 260; // Kolom "Keterangan" paling besar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data jadwal: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewsSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Pastikan baris dan kolom yang diklik valid
            {
                var selectedRow = dataGridViewsSchedule.Rows[e.RowIndex]; // Ambil baris yang diklik

                // Ambil nama kolom yang diklik
                string columnName = dataGridViewsSchedule.Columns[e.ColumnIndex].Name;

                if (columnName == "Update") // Jika tombol Update diklik
                {
                    try
                    {
                        // Ambil data dari baris yang dipilih
                        selectedScheduleId = selectedRow.Cells["Id"].Value.ToString(); // Pastikan kolom "Id" sesuai

                        // Isi modal dengan data dari baris yang dipilih
                        cmbHari.SelectedItem = selectedRow.Cells["Hari"].Value.ToString();
                        txtAktivitas.Text = selectedRow.Cells["Aktivitas"].Value.ToString();
                        numJumlahPelaksanaan.Value = Convert.ToInt32(selectedRow.Cells["JumlahPelaksanaan"].Value);
                        rtbKeterangan.Text = selectedRow.Cells["Keterangan"].Value.ToString();

                        // Ubah teks tombol menjadi "Update"
                        btnSaveSchedule.Text = "Update";

                        // Tampilkan modal
                        panelModal.Visible = true;

                        // Pastikan modal berada di depan
                        panelModal.BringToFront();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gagal memuat data untuk update: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (columnName == "Delete") // Jika tombol Delete diklik
                {
                    var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus jadwal ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            var schedulesCollection = MongoDBConnection.GetCollection("schedules");
                            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(selectedRow.Cells["Id"].Value.ToString())); // Pastikan kolom "Id" sesuai
                            schedulesCollection.DeleteOne(filter);

                            // Refresh tabel setelah penghapusan
                            LoadSchedules();
                            MessageBox.Show("Jadwal berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Gagal menghapus jadwal: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ClearModalInputs()
        {
            cmbHari.SelectedIndex = -1;
            txtAktivitas.Clear();
            numJumlahPelaksanaan.Value = 1;
            rtbKeterangan.Clear();
            selectedScheduleId = null;
        }

        private void btnCloseModal_Click(object sender, EventArgs e)
        {
            panelModal.Visible = false;
            ClearModalInputs();
        }
    }
}
