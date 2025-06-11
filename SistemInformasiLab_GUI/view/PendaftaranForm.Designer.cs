namespace SistemInformasiLab_GUI.view
{
    partial class PendaftaranForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label labelTanggalLahir;
        private System.Windows.Forms.DateTimePicker dateLahir;
        private System.Windows.Forms.Label labelTelepon;
        private System.Windows.Forms.TextBox txtTelepon;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelAlamat;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label labelSurat;
        private System.Windows.Forms.Label lblSuratFile;
        private System.Windows.Forms.Button btnPilihSurat;
        private System.Windows.Forms.Button btnKirim;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelJudul = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.labelTanggalLahir = new System.Windows.Forms.Label();
            this.dateLahir = new System.Windows.Forms.DateTimePicker();
            this.labelTelepon = new System.Windows.Forms.Label();
            this.txtTelepon = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelAlamat = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.labelSurat = new System.Windows.Forms.Label();
            this.lblSuratFile = new System.Windows.Forms.Label();
            this.btnPilihSurat = new System.Windows.Forms.Button();
            this.btnKirim = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // labelJudul
            // 
            this.labelJudul.AutoSize = true;
            this.labelJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelJudul.Location = new System.Drawing.Point(90, 20);
            this.labelJudul.Name = "labelJudul";
            this.labelJudul.Size = new System.Drawing.Size(258, 32);
            this.labelJudul.TabIndex = 0;
            this.labelJudul.Text = "Formulir Pendaftaran";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(30, 65);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(106, 16);
            this.labelNama.TabIndex = 1;
            this.labelNama.Text = "Nama Lengkap :";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(150, 62);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(200, 22);
            this.txtNama.TabIndex = 2;

            // 
            // labelTanggalLahir
            // 
            this.labelTanggalLahir.AutoSize = true;
            this.labelTanggalLahir.Location = new System.Drawing.Point(30, 100);
            this.labelTanggalLahir.Name = "labelTanggalLahir";
            this.labelTanggalLahir.Size = new System.Drawing.Size(96, 16);
            this.labelTanggalLahir.TabIndex = 3;
            this.labelTanggalLahir.Text = "Tanggal Lahir :";
            // 
            // dateLahir
            // 
            this.dateLahir.Location = new System.Drawing.Point(150, 97);
            this.dateLahir.Name = "dateLahir";
            this.dateLahir.Size = new System.Drawing.Size(200, 22);
            this.dateLahir.TabIndex = 4;
            // 
            // labelTelepon
            // 
            this.labelTelepon.AutoSize = true;
            this.labelTelepon.Location = new System.Drawing.Point(30, 135);
            this.labelTelepon.Name = "labelTelepon";
            this.labelTelepon.Size = new System.Drawing.Size(108, 16);
            this.labelTelepon.TabIndex = 5;
            this.labelTelepon.Text = "Nomor Telepon :";
            // 
            // txtTelepon
            // 
            this.txtTelepon.Location = new System.Drawing.Point(150, 132);
            this.txtTelepon.Name = "txtTelepon";
            this.txtTelepon.Size = new System.Drawing.Size(200, 22);
            this.txtTelepon.TabIndex = 6;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(30, 170);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(47, 16);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "Email :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 167);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 8;
            // 
            // labelAlamat
            // 
            this.labelAlamat.AutoSize = true;
            this.labelAlamat.Location = new System.Drawing.Point(30, 205);
            this.labelAlamat.Name = "labelAlamat";
            this.labelAlamat.Size = new System.Drawing.Size(55, 16);
            this.labelAlamat.TabIndex = 9;
            this.labelAlamat.Text = "Alamat :";
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(150, 202);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(200, 22);
            this.txtAlamat.TabIndex = 10;
            // 
            // labelSurat
            // 
            this.labelSurat.AutoSize = true;
            this.labelSurat.Location = new System.Drawing.Point(30, 240);
            this.labelSurat.Name = "labelSurat";
            this.labelSurat.Size = new System.Drawing.Size(96, 16);
            this.labelSurat.TabIndex = 11;
            this.labelSurat.Text = "Surat Rujukan :";
            // 
            // lblSuratFile
            // 
            this.lblSuratFile.AutoSize = true;
            this.lblSuratFile.Location = new System.Drawing.Point(150, 265);
            this.lblSuratFile.Name = "lblSuratFile";
            this.lblSuratFile.Size = new System.Drawing.Size(130, 16);
            this.lblSuratFile.TabIndex = 0;
            this.lblSuratFile.Text = "Belum ada file dipilih";
            // 
            // btnPilihSurat
            // 
            this.btnPilihSurat.Location = new System.Drawing.Point(150, 235);
            this.btnPilihSurat.Name = "btnPilihSurat";
            this.btnPilihSurat.Size = new System.Drawing.Size(90, 25);
            this.btnPilihSurat.TabIndex = 13;
            this.btnPilihSurat.Text = "Pilih File";
            this.btnPilihSurat.UseVisualStyleBackColor = true;
            this.btnPilihSurat.Click += new System.EventHandler(this.btnPilihSurat_Click);
            // 
            // btnKirim
            // 
            this.btnKirim.Location = new System.Drawing.Point(150, 300);
            this.btnKirim.Name = "btnKirim";
            this.btnKirim.Size = new System.Drawing.Size(100, 30);
            this.btnKirim.TabIndex = 14;
            this.btnKirim.Text = "Kirim";
            this.btnKirim.UseVisualStyleBackColor = true;
            this.btnKirim.Click += new System.EventHandler(this.btnKirim_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
            this.openFileDialog1.Title = "Pilih Surat Rujukan";
            // 
            // PendaftaranForm
            // 
            this.ClientSize = new System.Drawing.Size(428, 360);
            this.Controls.Add(this.labelJudul);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.labelTanggalLahir);
            this.Controls.Add(this.dateLahir);
            this.Controls.Add(this.labelTelepon);
            this.Controls.Add(this.txtTelepon);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.labelAlamat);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.labelSurat);
            this.Controls.Add(this.lblSuratFile);
            this.Controls.Add(this.btnPilihSurat);
            this.Controls.Add(this.btnKirim);
            this.Name = "PendaftaranForm";
            this.Text = "Formulir Pendaftaran";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}