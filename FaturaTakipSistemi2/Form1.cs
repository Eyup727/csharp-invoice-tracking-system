using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;

namespace FaturaTakipSistemi2
{
    public partial class Form1 : Form
    {
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private string yazdirilacakMetin = "";
        Timer zamanlayici = new Timer();
        int gecenSure = 0; // Saniye cinsinden
        bool ilkAcilis = true;
        private bool formHazir = false;
        bool formYuklendiMi = false;
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brkdr\Documents\FaturaDB.accdb");


        public Form1()
        {
            InitializeComponent();
        }
        private void YazdirilacakMetniHazirla()
        {
            yazdirilacakMetin = "FATURA RAPORU\n";
            yazdirilacakMetin += "Tarih: " + DateTime.Now.ToShortDateString() + "\n\n";
            yazdirilacakMetin += "Ürün Adı\tAdet\tFiyat\n";
            yazdirilacakMetin += "-------------------------------\n";

            foreach (DataGridViewRow row in dgvFaturalar.Rows)
            {
                if (row.IsNewRow) continue;

                string urunAdi = row.Cells["Firma"].Value?.ToString();
                string adet = "1"; // Eğer adet kolonu yoksa sabit yaz
                string fiyat = row.Cells["Tutar"].Value?.ToString();

                yazdirilacakMetin += $"{urunAdi}\t{adet}\t{fiyat} ₺\n";
            }

            yazdirilacakMetin += "\n-------------------------------\n";
            yazdirilacakMetin += "Toplam: " + ToplamTutariHesapla() + " ₺";
        }
        private decimal ToplamTutariHesapla()
        {
            decimal toplam = 0;
            foreach (DataGridViewRow row in dgvFaturalar.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(row.Cells["Tutar"].Value?.ToString(), out decimal tutar))
                {
                    toplam += tutar;
                }
            }
            return toplam;
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Consolas", 12);
            e.Graphics.DrawString(yazdirilacakMetin, font, Brushes.Black, new PointF(50, 50));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.KeyPreview = true;
            // Timer ayarları
            zamanlayici.Interval = 1000; // 1 saniye
            zamanlayici.Tick += Zamanlayici_Tick;
            zamanlayici.Start();

            // Diğer kodlar...
            formHazir = true;
            formYuklendiMi = true;
            cmbRaporlar.Items.Clear();
            cmbRaporlar.Items.Add("Ocak");
            cmbRaporlar.Items.Add("Şubat");
            cmbRaporlar.Items.Add("Mart");
            cmbRaporlar.Items.Add("Nisan");
            cmbRaporlar.Items.Add("Mayıs");
            cmbRaporlar.Items.Add("Haziran");
            cmbRaporlar.Items.Add("Temmuz");
            cmbRaporlar.Items.Add("Ağustos");
            cmbRaporlar.Items.Add("Eylül");
            cmbRaporlar.Items.Add("Ekim");
            cmbRaporlar.Items.Add("Kasım");
            cmbRaporlar.Items.Add("Aralık");

            cmbRaporlar.SelectedIndex = 0; // "Tüm Aylar"

            // ComboBox'a otomatik seçim YAPMA, sadece listele
            ilkAcilis = false;
            cmbRaporlar.SelectedIndex = 0;
            cmbRaporlar.Items.Insert(0, "Tüm Aylar");
            cmbRaporlar.SelectedIndex = 0; // Varsayılan seçili
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9);
            dgvFaturalar.BorderStyle = BorderStyle.None;
            dgvFaturalar.EnableHeadersVisualStyles = false;
            dgvFaturalar.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvFaturalar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFaturalar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvFaturalar.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvFaturalar.DefaultCellStyle.BackColor = Color.White;
            dgvFaturalar.DefaultCellStyle.ForeColor = Color.Black;
            dgvFaturalar.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvFaturalar.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvFaturalar.GridColor = Color.LightGray;
            dgvFaturalar.RowHeadersVisible = false;
            dgvFaturalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFaturalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFaturalar.AutoGenerateColumns = true;
            FaturalariListele();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            gecenSure = 0;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            gecenSure = 0;
        }
        private void FiltreliListele()
        {
            if (cmbRaporlar.SelectedItem == null || cmbRaporlar.SelectedItem.ToString() == "Tüm Aylar")
            {
                FaturalariListele();
                return;
            }

            string secilenAy = cmbRaporlar.SelectedItem.ToString();
            string ayNumarasi = AyNumarasiniGetir(secilenAy);

            string query = "SELECT * FROM Faturalar WHERE FORMAT([Tarih], 'MM') = ? ORDER BY Tarih DESC";

            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LAB-1\Documents\FaturaDB.accdb"))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("?", ayNumarasi);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFaturalar.DataSource = dt;
            }
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            // 1. AY ve tarih uyuşmazlık kontrolü
            if (cmbRaporlar.SelectedItem.ToString() != "Tüm Aylar" &&
                DtTarih.Value.Month.ToString("00") != AyNumarasiniGetir(cmbRaporlar.SelectedItem.ToString()))
            {
                MessageBox.Show("Seçilen ay ile tarih uyuşmuyor! Lütfen doğru ayı seçin.");
                return;
            }

            // 2. Buton tasarımı
            BtnEkle.BackColor = Color.MediumSeaGreen;
            BtnEkle.ForeColor = Color.White;
            BtnEkle.FlatStyle = FlatStyle.Flat;
            BtnEkle.FlatAppearance.BorderSize = 0;
            BtnEkle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnEkle.Cursor = Cursors.Hand;

            try
            {
                // 3. Tutar kontrolü
                if (!decimal.TryParse(TxtTutar.Text, out decimal tutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar girin.");
                    return;
                }

                // 4. Fatura oluştur
                Fatura yeniFatura = new Fatura()
                {
                    Tarih = DtTarih.Value,
                    Firma = txtFirma.Text,
                    Tutar = tutar,
                    Aciklama = TxtAçıklama.Text
                };

                // 5. Veritabanı işlemi
                string sorgu = "INSERT INTO Faturalar (Tarih, Firma, Tutar, [Açıklama]) VALUES (@Tarih, @Firma, @Tutar, @Aciklama)";
                using (OleDbCommand komut = new OleDbCommand(sorgu, baglanti))
                {
                    komut.Parameters.Add("@Tarih", OleDbType.Date).Value = yeniFatura.Tarih;
                    komut.Parameters.Add("@Firma", OleDbType.VarWChar).Value = yeniFatura.Firma;
                    komut.Parameters.Add("@Tutar", OleDbType.Currency).Value = yeniFatura.Tutar;
                    komut.Parameters.Add("@Aciklama", OleDbType.LongVarWChar).Value = yeniFatura.Aciklama;

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }

                MessageBox.Show("Fatura başarıyla eklendi!");
                FiltreliListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }

        private void FaturalariListele()
        {
            try
            {
                string sorgu = "SELECT * FROM Faturalar";
                using (OleDbDataAdapter da = new OleDbDataAdapter(sorgu, baglanti))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFaturalar.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            FiltreliListele();
            BtnGuncelle.BackColor = Color.SteelBlue;
            BtnGuncelle.ForeColor = Color.White;
            BtnGuncelle.FlatStyle = FlatStyle.Flat;
            BtnGuncelle.FlatAppearance.BorderSize = 0;
            BtnGuncelle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnGuncelle.Cursor = Cursors.Hand;

            if (dgvFaturalar.CurrentRow == null) return;

            if (!decimal.TryParse(TxtTutar.Text, out decimal tutar))
            {
                MessageBox.Show("Lütfen geçerli bir tutar girin.");
                return;
            }

            int id = Convert.ToInt32(dgvFaturalar.CurrentRow.Cells["ID"].Value);
            string sorgu = "UPDATE Faturalar SET Tarih = ?, Firma = ?, Tutar = ?, [Açıklama] = ? WHERE ID = ?";

            using (OleDbCommand komut = new OleDbCommand(sorgu, baglanti))
            {
                // Parametre sırası SQL'deki sırayla olmalı (OleDb'de isim önemli değil, sıra önemli!)
                komut.Parameters.AddWithValue("?", DtTarih.Value);              // DateTime
                komut.Parameters.AddWithValue("?", txtFirma.Text);              // String
                komut.Parameters.AddWithValue("?", Convert.ToDecimal(tutar));   // Decimal / Number
                komut.Parameters.AddWithValue("?", TxtAçıklama.Text);           // String
                komut.Parameters.AddWithValue("?", Convert.ToInt32(id));        // Integer

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }

            MessageBox.Show("Fatura güncellendi.");
        }

        private void dgvFaturalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvFaturalar.Rows[e.RowIndex].Cells["Firma"].Value != DBNull.Value)
            {
                DataGridViewRow row = dgvFaturalar.Rows[e.RowIndex];
                txtFirma.Text = row.Cells["Firma"].Value?.ToString();
                TxtTutar.Text = row.Cells["Tutar"].Value?.ToString();
                TxtAçıklama.Text = row.Cells["Açıklama"].Value?.ToString();
                DtTarih.Value = Convert.ToDateTime(row.Cells["Tarih"].Value);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            FiltreliListele();
            BtnSil.FlatStyle = FlatStyle.Flat;
            BtnSil.BackColor = Color.FromArgb(255, 77, 77);
            BtnSil.ForeColor = Color.White;
            BtnSil.FlatAppearance.BorderSize = 0;
            BtnSil.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            BtnSil.Cursor = Cursors.Hand;
            BtnSil.Height = 40;
            BtnSil.Width = 140;
            BtnSil.TextAlign = ContentAlignment.MiddleCenter;

            if (dgvFaturalar.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvFaturalar.CurrentRow.Cells["ID"].Value);
            DialogResult sonuc = MessageBox.Show("Bu faturayı silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo);

            if (sonuc == DialogResult.Yes)
            {
                string sorgu = "DELETE FROM Faturalar WHERE ID=@ID";
                using (OleDbCommand komut = new OleDbCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@ID", id);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }

                MessageBox.Show("Fatura silindi.");
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

            FiltreliListele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbRaporlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ilkAcilis) return;

            if (cmbRaporlar.SelectedItem == null)
                return;

            string secilenAy = cmbRaporlar.SelectedItem.ToString();
            string query;
            OleDbDataAdapter da;
            DataTable dt = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brkdr\Documents\FaturaDB.accdb"))
            {
                if (secilenAy == "Tüm Aylar")
                {
                    query = "SELECT * FROM Faturalar ORDER BY Tarih DESC";
                    da = new OleDbDataAdapter(query, conn);
                }
                else
                {
                    string ayNumarasi = AyNumarasiniGetir(secilenAy);
                    query = "SELECT * FROM Faturalar WHERE FORMAT([Tarih], 'MM') = ? ORDER BY Tarih DESC";
                    da = new OleDbDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("?", ayNumarasi);
                }

                da.Fill(dt);
                dgvFaturalar.DataSource = dt;
            }

            MessageBox.Show($"{secilenAy} ayına ait toplam fatura sayısı: {dt.Rows.Count}");
        }

        private string AyNumarasiniGetir(string ay)
        {
            switch (ay)
            {
                case "Ocak": return "01";
                case "Şubat": return "02";
                case "Mart": return "03";
                case "Nisan": return "04";
                case "Mayıs": return "05";
                case "Haziran": return "06";
                case "Temmuz": return "07";
                case "Ağustos": return "08";
                case "Eylül": return "09";
                case "Ekim": return "10";
                case "Kasım": return "11";
                case "Aralık": return "12";
                default: return "01";
            }
        }

        private void RprListele_Click(object sender, EventArgs e)
        {
            FiltreliListele();
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            gecenSure++;

            if (gecenSure >= 120) // ❗ 2 dakika = 120 saniye
            {
                zamanlayici.Stop();
                MessageBox.Show("2 dakika boyunca işlem yapılmadığı için uygulama kapanıyor.");
                Application.Exit();
            }
        }

        private void RprYazdır_Click(object sender, EventArgs e)
        {
            YazdirilacakMetniHazirla();

    // Önce PrintPage event handler'ını sıfırla
    printDocument1.PrintPage -= PrintDocument1_PrintPage;
    printDocument1.PrintPage -= printDocument1_PrintPage;

    // Sonra yeniden sadece 1 kez bağla
    printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

    printPreviewDialog1.Document = printDocument1;
    printPreviewDialog1.ShowDialog();
            
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font baslikFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font icerikFont = new Font("Segoe UI", 13);
            float y = 100;
            float x = e.MarginBounds.Left;
            float sayfaGenisligi = e.MarginBounds.Width;

            string[] satirlar = yazdirilacakMetin.Split('\n');

            // Metni ortalayarak yazdır
            foreach (string satir in satirlar)
            {
                SizeF stringSize = e.Graphics.MeasureString(satir, icerikFont);
                float xOrtalanmis = x + (sayfaGenisligi - stringSize.Width) / 2;

                // Başlık satırını kalın yaz
                if (satir.Contains("FATURA RAPORU") || satir.Contains("Toplam:"))
                {
                    e.Graphics.DrawString(satir, baslikFont, Brushes.Black, xOrtalanmis, y);
                    y += baslikFont.GetHeight() + 10;
                }
                else
                {
                    e.Graphics.DrawString(satir, icerikFont, Brushes.Black, xOrtalanmis, y);
                    y += icerikFont.GetHeight() + 5;
                }
            }
        }
    }
}
