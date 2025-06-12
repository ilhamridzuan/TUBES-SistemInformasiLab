namespace SistemInformasiLab_GUI.view
{
    partial class DashboardPetugas
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
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLihatHasil = new Guna.UI2.WinForms.Guna2Button();
            this.btnKelola = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
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
            this.btnLogOut.Location = new System.Drawing.Point(242, 476);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(272, 84);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(504, 42);
            this.label2.TabIndex = 14;
            this.label2.Text = "Anda Login Sebagai Petugas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(96, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 79);
            this.label1.TabIndex = 13;
            this.label1.Text = "Selamat Datang!";
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
            this.btnLihatHasil.Location = new System.Drawing.Point(242, 357);
            this.btnLihatHasil.Name = "btnLihatHasil";
            this.btnLihatHasil.Size = new System.Drawing.Size(272, 84);
            this.btnLihatHasil.TabIndex = 12;
            this.btnLihatHasil.Text = "lihat Hasil Pemeriksaan";
            this.btnLihatHasil.Click += new System.EventHandler(this.btnLihatHasil_Click);
            // 
            // btnKelola
            // 
            this.btnKelola.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKelola.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKelola.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKelola.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKelola.FillColor = System.Drawing.Color.Indigo;
            this.btnKelola.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKelola.ForeColor = System.Drawing.Color.White;
            this.btnKelola.Location = new System.Drawing.Point(242, 255);
            this.btnKelola.Name = "btnKelola";
            this.btnKelola.Size = new System.Drawing.Size(272, 84);
            this.btnKelola.TabIndex = 16;
            this.btnKelola.Text = "Kelola Hasil Pemeriksaan";
            this.btnKelola.Click += new System.EventHandler(this.btnKelola_Click);
            // 
            // DashboardPetugas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 659);
            this.Controls.Add(this.btnKelola);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLihatHasil);
            this.Name = "DashboardPetugas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardPetugas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnLihatHasil;
        private Guna.UI2.WinForms.Guna2Button btnKelola;
    }
}