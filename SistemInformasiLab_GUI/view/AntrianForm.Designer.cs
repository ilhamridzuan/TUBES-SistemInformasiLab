﻿namespace SistemInformasiLab_GUI.view
{
    partial class AntrianForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNomorSaya = new System.Windows.Forms.Label();
            this.listViewAntrian = new System.Windows.Forms.ListView();
            this.columnHeaderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNama = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblUrutanSaya = new System.Windows.Forms.Label();
            this.btnBeranda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(180, 39);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(330, 59);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Nomor Antrian";
            // 
            // lblNomorSaya
            // 
            this.lblNomorSaya.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblNomorSaya.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblNomorSaya.ForeColor = System.Drawing.Color.White;
            this.lblNomorSaya.Location = new System.Drawing.Point(200, 116);
            this.lblNomorSaya.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomorSaya.Name = "lblNomorSaya";
            this.lblNomorSaya.Size = new System.Drawing.Size(320, 116);
            this.lblNomorSaya.TabIndex = 1;
            this.lblNomorSaya.Text = "000";
            this.lblNomorSaya.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNomorSaya.Click += new System.EventHandler(this.lblNomorSaya_Click);
            // 
            // listViewAntrian
            // 
            this.listViewAntrian.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderNama});
            this.listViewAntrian.FullRowSelect = true;
            this.listViewAntrian.GridLines = true;
            this.listViewAntrian.HideSelection = false;
            this.listViewAntrian.Location = new System.Drawing.Point(60, 269);
            this.listViewAntrian.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewAntrian.Name = "listViewAntrian";
            this.listViewAntrian.Size = new System.Drawing.Size(596, 381);
            this.listViewAntrian.TabIndex = 2;
            this.listViewAntrian.UseCompatibleStateImageBehavior = false;
            this.listViewAntrian.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "No";
            this.columnHeaderNo.Width = 70;
            // 
            // columnHeaderNama
            // 
            this.columnHeaderNama.Text = "Nama Pasien";
            this.columnHeaderNama.Width = 220;
            // 
            // lblUrutanSaya
            // 
            this.lblUrutanSaya.AutoSize = true;
            this.lblUrutanSaya.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUrutanSaya.Location = new System.Drawing.Point(160, 692);
            this.lblUrutanSaya.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrutanSaya.Name = "lblUrutanSaya";
            this.lblUrutanSaya.Size = new System.Drawing.Size(354, 37);
            this.lblUrutanSaya.TabIndex = 3;
            this.lblUrutanSaya.Text = "Urutan Anda: 0 dari 0 pasien";
            // 
            // btnBeranda
            // 
            this.btnBeranda.Location = new System.Drawing.Point(282, 747);
            this.btnBeranda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBeranda.Name = "btnBeranda";
            this.btnBeranda.Size = new System.Drawing.Size(150, 47);
            this.btnBeranda.TabIndex = 4;
            this.btnBeranda.Text = "Beranda";
            this.btnBeranda.UseVisualStyleBackColor = true;
            this.btnBeranda.Click += new System.EventHandler(this.btnBeranda_Click);
            // 
            // AntrianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 812);
            this.Controls.Add(this.btnBeranda);
            this.Controls.Add(this.lblUrutanSaya);
            this.Controls.Add(this.listViewAntrian);
            this.Controls.Add(this.lblNomorSaya);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AntrianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Antrian";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNomorSaya;
        private System.Windows.Forms.ListView listViewAntrian;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderNama;
        private System.Windows.Forms.Label lblUrutanSaya;
        private System.Windows.Forms.Button btnBeranda;
    }
}
