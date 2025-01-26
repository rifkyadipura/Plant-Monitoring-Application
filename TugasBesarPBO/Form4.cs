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

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            // Bersihkan input di modal
            ClearModalInputs();
            selectedScheduleId = null;

            // Tampilkan modal untuk Create
            panelModal.Visible = true;
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

                if (selectedScheduleId == null)
                {
                    // Create
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
                else
                {
                    // Update
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
                var schedules = schedulesCollection.Find(new BsonDocument()).ToList();

                dataGridViewsSchedule.DataSource = schedules.Select((s, index) => new
                {
                    No = index + 1,
                    Id = s["_id"].ToString(),
                    Hari = s["hari"].AsString,
                    Aktivitas = s["aktivitas"].AsString,
                    JumlahPelaksanaan = s.Contains("jumlah_pelaksanaan") ? s["jumlah_pelaksanaan"].AsInt32 : 0, // Default 0
                    Keterangan = s.Contains("keterangan") ? s["keterangan"].AsString : "-" // Default "-"
                }).ToList();

                dataGridViewsSchedule.Columns["Id"].Visible = false; // Sembunyikan kolom ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data jadwal: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewsSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewsSchedule.Rows[e.RowIndex];
                selectedScheduleId = selectedRow.Cells["Id"].Value.ToString();

                if (dataGridViewsSchedule.Columns[e.ColumnIndex].HeaderText == "Update")
                {
                    // Load data ke modal
                    cmbHari.SelectedItem = selectedRow.Cells["Hari"].Value.ToString();
                    txtAktivitas.Text = selectedRow.Cells["Aktivitas"].Value.ToString();
                    numJumlahPelaksanaan.Value = Convert.ToInt32(selectedRow.Cells["JumlahPelaksanaan"].Value);
                    rtbKeterangan.Text = selectedRow.Cells["Keterangan"].Value.ToString();

                    // Tampilkan modal
                    panelModal.Visible = true;
                }
                else if (dataGridViewsSchedule.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus jadwal ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        var schedulesCollection = MongoDBConnection.GetCollection("schedules");
                        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(selectedScheduleId));
                        schedulesCollection.DeleteOne(filter);

                        // Refresh tabel
                        LoadSchedules();
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
        }
    }
}
