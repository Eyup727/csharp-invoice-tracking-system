namespace FaturaTakipSistemi2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblFirma = new System.Windows.Forms.Label();
            this.LblTarih = new System.Windows.Forms.Label();
            this.LblTutar = new System.Windows.Forms.Label();
            this.LblAçıklama = new System.Windows.Forms.Label();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.TxtTutar = new System.Windows.Forms.TextBox();
            this.TxtAçıklama = new System.Windows.Forms.TextBox();
            this.DtTarih = new System.Windows.Forms.DateTimePicker();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.BtnListele = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.dgvFaturalar = new System.Windows.Forms.DataGridView();
            this.faturalarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.faturaDBDataSet1 = new FaturaTakipSistemi2.FaturaDBDataSet1();
            this.faturalarTableAdapter = new FaturaTakipSistemi2.FaturaDBDataSet1TableAdapters.FaturalarTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRaporlar = new System.Windows.Forms.ComboBox();
            this.lblRaporlar = new System.Windows.Forms.Label();
            this.RprListele = new System.Windows.Forms.Button();
            this.Zamanlayici = new System.Windows.Forms.Timer(this.components);
            this.RprYazdır = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faturalarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faturaDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblFirma
            // 
            this.LblFirma.AutoSize = true;
            this.LblFirma.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblFirma.Location = new System.Drawing.Point(135, 23);
            this.LblFirma.Name = "LblFirma";
            this.LblFirma.Size = new System.Drawing.Size(46, 17);
            this.LblFirma.TabIndex = 0;
            this.LblFirma.Text = "Firma:";
            // 
            // LblTarih
            // 
            this.LblTarih.AutoSize = true;
            this.LblTarih.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTarih.Location = new System.Drawing.Point(135, 75);
            this.LblTarih.Name = "LblTarih";
            this.LblTarih.Size = new System.Drawing.Size(43, 17);
            this.LblTarih.TabIndex = 1;
            this.LblTarih.Text = "Tarih:";
            // 
            // LblTutar
            // 
            this.LblTutar.AutoSize = true;
            this.LblTutar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTutar.Location = new System.Drawing.Point(135, 132);
            this.LblTutar.Name = "LblTutar";
            this.LblTutar.Size = new System.Drawing.Size(44, 17);
            this.LblTutar.TabIndex = 2;
            this.LblTutar.Text = "Tutar:";
            // 
            // LblAçıklama
            // 
            this.LblAçıklama.AutoSize = true;
            this.LblAçıklama.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAçıklama.Location = new System.Drawing.Point(124, 191);
            this.LblAçıklama.Name = "LblAçıklama";
            this.LblAçıklama.Size = new System.Drawing.Size(67, 17);
            this.LblAçıklama.TabIndex = 3;
            this.LblAçıklama.Text = "Acıklama:";
            // 
            // txtFirma
            // 
            this.txtFirma.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFirma.Location = new System.Drawing.Point(192, 23);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(100, 23);
            this.txtFirma.TabIndex = 4;
            // 
            // TxtTutar
            // 
            this.TxtTutar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTutar.Location = new System.Drawing.Point(192, 129);
            this.TxtTutar.Name = "TxtTutar";
            this.TxtTutar.Size = new System.Drawing.Size(100, 23);
            this.TxtTutar.TabIndex = 6;
            // 
            // TxtAçıklama
            // 
            this.TxtAçıklama.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAçıklama.Location = new System.Drawing.Point(192, 191);
            this.TxtAçıklama.Name = "TxtAçıklama";
            this.TxtAçıklama.Size = new System.Drawing.Size(100, 23);
            this.TxtAçıklama.TabIndex = 7;
            // 
            // DtTarih
            // 
            this.DtTarih.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DtTarih.Location = new System.Drawing.Point(192, 75);
            this.DtTarih.Name = "DtTarih";
            this.DtTarih.Size = new System.Drawing.Size(200, 23);
            this.DtTarih.TabIndex = 8;
            // 
            // BtnEkle
            // 
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(509, 36);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(112, 23);
            this.BtnEkle.TabIndex = 9;
            this.BtnEkle.Text = "FaturaEkle";
            this.BtnEkle.UseVisualStyleBackColor = true;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // BtnListele
            // 
            this.BtnListele.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnListele.Location = new System.Drawing.Point(509, 75);
            this.BtnListele.Name = "BtnListele";
            this.BtnListele.Size = new System.Drawing.Size(112, 23);
            this.BtnListele.TabIndex = 10;
            this.BtnListele.Text = "FaturaListele";
            this.BtnListele.UseVisualStyleBackColor = true;
            this.BtnListele.Click += new System.EventHandler(this.BtnListele_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(509, 117);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(112, 23);
            this.BtnGuncelle.TabIndex = 11;
            this.BtnGuncelle.Text = "FaturaGuncelle";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(509, 156);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(112, 23);
            this.BtnSil.TabIndex = 12;
            this.BtnSil.Text = "FaturaSil";
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // dgvFaturalar
            // 
            this.dgvFaturalar.AutoGenerateColumns = false;
            this.dgvFaturalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaturalar.DataSource = this.faturalarBindingSource;
            this.dgvFaturalar.Location = new System.Drawing.Point(226, 227);
            this.dgvFaturalar.Name = "dgvFaturalar";
            this.dgvFaturalar.Size = new System.Drawing.Size(515, 142);
            this.dgvFaturalar.TabIndex = 13;
            this.dgvFaturalar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaturalar_CellContentClick);
            // 
            // faturalarBindingSource
            // 
            this.faturalarBindingSource.DataMember = "Faturalar";
            this.faturalarBindingSource.DataSource = this.faturaDBDataSet1;
            // 
            // faturaDBDataSet1
            // 
            this.faturaDBDataSet1.DataSetName = "FaturaDBDataSet1";
            this.faturaDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // faturalarTableAdapter
            // 
            this.faturalarTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FaturaTakipSistemi2.Properties.Resources.FT__1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fatura Takip Sistemi";
            // 
            // cmbRaporlar
            // 
            this.cmbRaporlar.FormattingEnabled = true;
            this.cmbRaporlar.Items.AddRange(new object[] {
            "Ocak  ",
            "Şubat  ",
            "Mart  ",
            "Nisan  ",
            "Mayıs  ",
            "Haziran  ",
            "Temmuz  ",
            "Ağustos  ",
            "Eylül  ",
            "Ekim  ",
            "Kasım  ",
            "Aralık"});
            this.cmbRaporlar.Location = new System.Drawing.Point(363, 193);
            this.cmbRaporlar.Name = "cmbRaporlar";
            this.cmbRaporlar.Size = new System.Drawing.Size(121, 21);
            this.cmbRaporlar.TabIndex = 16;
            this.cmbRaporlar.SelectedIndexChanged += new System.EventHandler(this.cmbRaporlar_SelectedIndexChanged);
            // 
            // lblRaporlar
            // 
            this.lblRaporlar.AutoSize = true;
            this.lblRaporlar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRaporlar.Location = new System.Drawing.Point(369, 173);
            this.lblRaporlar.Name = "lblRaporlar";
            this.lblRaporlar.Size = new System.Drawing.Size(63, 17);
            this.lblRaporlar.TabIndex = 17;
            this.lblRaporlar.Text = "Raporlar:";
            // 
            // RprListele
            // 
            this.RprListele.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RprListele.Location = new System.Drawing.Point(509, 191);
            this.RprListele.Name = "RprListele";
            this.RprListele.Size = new System.Drawing.Size(112, 23);
            this.RprListele.TabIndex = 18;
            this.RprListele.Text = "RaporlarıListele";
            this.RprListele.UseVisualStyleBackColor = true;
            this.RprListele.Click += new System.EventHandler(this.RprListele_Click);
            // 
            // Zamanlayici
            // 
            this.Zamanlayici.Tick += new System.EventHandler(this.Zamanlayici_Tick);
            // 
            // RprYazdır
            // 
            this.RprYazdır.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RprYazdır.Location = new System.Drawing.Point(629, 191);
            this.RprYazdır.Name = "RprYazdır";
            this.RprYazdır.Size = new System.Drawing.Size(112, 23);
            this.RprYazdır.TabIndex = 19;
            this.RprYazdır.Text = "RaporlarıYazdır";
            this.RprYazdır.UseVisualStyleBackColor = true;
            this.RprYazdır.Click += new System.EventHandler(this.RprYazdır_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RprYazdır);
            this.Controls.Add(this.RprListele);
            this.Controls.Add(this.lblRaporlar);
            this.Controls.Add(this.cmbRaporlar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvFaturalar);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnListele);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.DtTarih);
            this.Controls.Add(this.TxtAçıklama);
            this.Controls.Add(this.TxtTutar);
            this.Controls.Add(this.txtFirma);
            this.Controls.Add(this.LblAçıklama);
            this.Controls.Add(this.LblTutar);
            this.Controls.Add(this.LblTarih);
            this.Controls.Add(this.LblFirma);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faturalarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faturaDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFirma;
        private System.Windows.Forms.Label LblTarih;
        private System.Windows.Forms.Label LblTutar;
        private System.Windows.Forms.Label LblAçıklama;
        private System.Windows.Forms.TextBox txtFirma;
        private System.Windows.Forms.TextBox TxtTutar;
        private System.Windows.Forms.TextBox TxtAçıklama;
        private System.Windows.Forms.DateTimePicker DtTarih;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.Button BtnListele;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.DataGridView dgvFaturalar;
        private FaturaDBDataSet1 faturaDBDataSet1;
        private System.Windows.Forms.BindingSource faturalarBindingSource;
        private FaturaDBDataSet1TableAdapters.FaturalarTableAdapter faturalarTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRaporlar;
        private System.Windows.Forms.Label lblRaporlar;
        private System.Windows.Forms.Button RprListele;
        private System.Windows.Forms.Timer Zamanlayici;
        private System.Windows.Forms.Button RprYazdır;
    }
}

