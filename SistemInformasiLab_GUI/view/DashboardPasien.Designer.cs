namespace SistemInformasiLab_GUI.view
{
    partial class DashboardPasien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPendaftaran = new Guna.UI2.WinForms.Guna2Button();
            this.btnLihatHasil = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnPendaftaran
            // 
            this.btnPendaftaran.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPendaftaran.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPendaftaran.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPendaftaran.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPendaftaran.FillColor = System.Drawing.Color.Indigo;
            this.btnPendaftaran.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPendaftaran.ForeColor = System.Drawing.Color.White;
            this.btnPendaftaran.Location = new System.Drawing.Point(238, 267);
            this.btnPendaftaran.Name = "btnPendaftaran";
            this.btnPendaftaran.Size = new System.Drawing.Size(272, 84);
            this.btnPendaftaran.TabIndex = 0;
            this.btnPendaftaran.Text = "Lakukan Pendaftaran";
            this.btnPendaftaran.Click += new System.EventHandler(this.btnPendaftaran_Click);
            // 
            // btnLihatHasil
            // 
            this.btnLihatHasil.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLihatHasil.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLihatHasil.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLihatHasil.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLihatHasil.FillColor = System.Drawing.Color.Indigo;
            this.btnLihatHasil.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLihatHasil.ForeColor = System.Drawing.Color.White;
            this.btnLihatHasil.Location = new System.Drawing.Point(238, 384);
            this.btnLihatHasil.Name = "btnLihatHasil";
            this.btnLihatHasil.Size = new System.Drawing.Size(272, 84);
            this.btnLihatHasil.TabIndex = 1;
            this.btnLihatHasil.Text = "Lihat Hasil Pemeriksaan";
            this.btnLihatHasil.Click += new System.EventHandler(this.btnLihatHasil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(82, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 79);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selamat Datang!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "Anda Login Sebagai Pasien";
            // 
            // btnLogOut
            // 
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.GhostWhite;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogOut.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.Location = new System.Drawing.Point(238, 618);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(272, 84);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // DashboardPasien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 797);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLihatHasil);
            this.Controls.Add(this.btnPendaftaran);
            this.Name = "DashboardPasien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardPasien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnPendaftaran;
        private Guna.UI2.WinForms.Guna2Button btnLihatHasil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
    }
}