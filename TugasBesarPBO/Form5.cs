﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TugasBesarPBO
{
    public partial class Form5 : Form
    {
        private string username;

        public Form5(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadChartData();
        }

        private void LoadChartData()
        {
            try
            {
                var collection = MongoDBConnection.GetCollection("daily_tomato_records");

                // Ambil data hanya yang dibuat oleh user yang sedang login
                var filter = Builders<BsonDocument>.Filter.Eq("created_by", username);
                var documents = collection.Find(filter)
                                          .Sort(Builders<BsonDocument>.Sort.Ascending("tanggal"))
                                          .ToList();

                if (documents.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk ditampilkan dalam grafik.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 🔹 Bersihkan data lama di chart
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();
                chart1.Titles.Clear();

                // 🔹 Tambahkan ChartArea sebelum menambahkan Series
                chart1.ChartAreas.Add(new ChartArea("MainChart"));

                // 🔹 Tambahkan Legenda
                Legend legend = new Legend("Legenda")
                {
                    Docking = Docking.Top
                };
                chart1.Legends.Add(legend);

                // 🔹 Series 1: Tinggi Tomat (Garis Biru)
                Series tinggiSeries = new Series("Tinggi Tomat")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.Date,
                    BorderWidth = 2,
                    Color = Color.Blue,
                    Legend = "Legenda",
                    ChartArea = "MainChart"
                };
                chart1.Series.Add(tinggiSeries);

                // 🔹 Tambahkan Data ke Chart
                foreach (var doc in documents)
                {
                    DateTime tanggal = doc["tanggal"].ToUniversalTime();
                    double tinggiTomat = doc.Contains("tinggi_tomat_cm") ? Convert.ToDouble(doc["tinggi_tomat_cm"]) : 0;

                    tinggiSeries.Points.AddXY(tanggal, tinggiTomat);
                }

                // 🔹 Format Sumbu X agar Tanggal Terlihat Jelas
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd MMM yyyy";
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                chart1.ChartAreas[0].AxisX.Interval = 1;

                // 🔹 Judul Sumbu
                chart1.ChartAreas[0].AxisY.Title = "Tinggi Tomat (cm)";
                chart1.ChartAreas[0].AxisX.Title = "Tanggal";

                // 🔹 Tambahkan Judul Grafik
                chart1.Titles.Add("Grafik Perkembangan Tinggi Tanaman Tomat");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat mengambil data: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
