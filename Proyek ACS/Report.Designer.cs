﻿namespace Proyek_ACS
{
    partial class Report
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_pilihan = new System.Windows.Forms.ComboBox();
            this.btn_buat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.DailyLbl = new System.Windows.Forms.Label();
            this.TglAwal = new System.Windows.Forms.DateTimePicker();
            this.TglAkhir = new System.Windows.Forms.DateTimePicker();
            this.TglAwalLbl = new System.Windows.Forms.Label();
            this.TglAkhirLbl = new System.Windows.Forms.Label();
            this.BulanCmb = new System.Windows.Forms.ComboBox();
            this.TahunCmbBulanan = new System.Windows.Forms.ComboBox();
            this.TahunCmbTahunan = new System.Windows.Forms.ComboBox();
            this.TahunLbl = new System.Windows.Forms.Label();
            this.TahunLblBulanan = new System.Windows.Forms.Label();
            this.BulanLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NamaLbl = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(596, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(764, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laporan Detail Mutasi Stock";
            // 
            // cmb_pilihan
            // 
            this.cmb_pilihan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pilihan.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pilihan.FormattingEnabled = true;
            this.cmb_pilihan.Items.AddRange(new object[] {
            "Harian",
            "Bulanan",
            "Tahunan",
            "Custom"});
            this.cmb_pilihan.Location = new System.Drawing.Point(23, 262);
            this.cmb_pilihan.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_pilihan.Name = "cmb_pilihan";
            this.cmb_pilihan.Size = new System.Drawing.Size(243, 30);
            this.cmb_pilihan.TabIndex = 1;
            this.cmb_pilihan.SelectedIndexChanged += new System.EventHandler(this.Cmb_pilihan_SelectedIndexChanged);
            // 
            // btn_buat
            // 
            this.btn_buat.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buat.Location = new System.Drawing.Point(275, 254);
            this.btn_buat.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buat.Name = "btn_buat";
            this.btn_buat.Size = new System.Drawing.Size(136, 45);
            this.btn_buat.TabIndex = 2;
            this.btn_buat.Text = "Generate";
            this.btn_buat.UseVisualStyleBackColor = true;
            this.btn_buat.Visible = false;
            this.btn_buat.Click += new System.EventHandler(this.Btn_buat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyek_ACS.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 116);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.Main.ActiveViewIndex = -1;
            this.Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main.DisplayStatusBar = false;
            this.Main.Location = new System.Drawing.Point(463, 127);
            this.Main.Name = "Main";
            this.Main.ShowCopyButton = false;
            this.Main.ShowGroupTreeButton = false;
            this.Main.ShowLogo = false;
            this.Main.ShowParameterPanelButton = false;
            this.Main.ShowZoomButton = false;
            this.Main.Size = new System.Drawing.Size(1114, 814);
            this.Main.TabIndex = 8;
            this.Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.Main.Visible = false;
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(27, 331);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(243, 22);
            this.Date.TabIndex = 9;
            this.Date.Visible = false;
            // 
            // DailyLbl
            // 
            this.DailyLbl.AutoSize = true;
            this.DailyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DailyLbl.Location = new System.Drawing.Point(23, 308);
            this.DailyLbl.Name = "DailyLbl";
            this.DailyLbl.Size = new System.Drawing.Size(130, 20);
            this.DailyLbl.TabIndex = 10;
            this.DailyLbl.Text = "Pilih Tanggal :";
            this.DailyLbl.Visible = false;
            // 
            // TglAwal
            // 
            this.TglAwal.Location = new System.Drawing.Point(27, 331);
            this.TglAwal.Name = "TglAwal";
            this.TglAwal.Size = new System.Drawing.Size(243, 22);
            this.TglAwal.TabIndex = 11;
            this.TglAwal.Visible = false;
            // 
            // TglAkhir
            // 
            this.TglAkhir.Location = new System.Drawing.Point(27, 379);
            this.TglAkhir.Name = "TglAkhir";
            this.TglAkhir.Size = new System.Drawing.Size(243, 22);
            this.TglAkhir.TabIndex = 12;
            this.TglAkhir.Visible = false;
            // 
            // TglAwalLbl
            // 
            this.TglAwalLbl.AutoSize = true;
            this.TglAwalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TglAwalLbl.Location = new System.Drawing.Point(23, 308);
            this.TglAwalLbl.Name = "TglAwalLbl";
            this.TglAwalLbl.Size = new System.Drawing.Size(133, 20);
            this.TglAwalLbl.TabIndex = 13;
            this.TglAwalLbl.Text = "Tanggal Awal :";
            this.TglAwalLbl.Visible = false;
            // 
            // TglAkhirLbl
            // 
            this.TglAkhirLbl.AutoSize = true;
            this.TglAkhirLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TglAkhirLbl.Location = new System.Drawing.Point(23, 356);
            this.TglAkhirLbl.Name = "TglAkhirLbl";
            this.TglAkhirLbl.Size = new System.Drawing.Size(136, 20);
            this.TglAkhirLbl.TabIndex = 14;
            this.TglAkhirLbl.Text = "Tanggal Akhir :";
            this.TglAkhirLbl.Visible = false;
            // 
            // BulanCmb
            // 
            this.BulanCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BulanCmb.FormattingEnabled = true;
            this.BulanCmb.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.BulanCmb.Location = new System.Drawing.Point(27, 331);
            this.BulanCmb.Name = "BulanCmb";
            this.BulanCmb.Size = new System.Drawing.Size(191, 24);
            this.BulanCmb.TabIndex = 15;
            this.BulanCmb.Visible = false;
            // 
            // TahunCmbBulanan
            // 
            this.TahunCmbBulanan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TahunCmbBulanan.FormattingEnabled = true;
            this.TahunCmbBulanan.Location = new System.Drawing.Point(27, 388);
            this.TahunCmbBulanan.Name = "TahunCmbBulanan";
            this.TahunCmbBulanan.Size = new System.Drawing.Size(191, 24);
            this.TahunCmbBulanan.TabIndex = 16;
            this.TahunCmbBulanan.Visible = false;
            // 
            // TahunCmbTahunan
            // 
            this.TahunCmbTahunan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TahunCmbTahunan.FormattingEnabled = true;
            this.TahunCmbTahunan.Location = new System.Drawing.Point(27, 331);
            this.TahunCmbTahunan.Name = "TahunCmbTahunan";
            this.TahunCmbTahunan.Size = new System.Drawing.Size(191, 24);
            this.TahunCmbTahunan.TabIndex = 17;
            this.TahunCmbTahunan.Visible = false;
            // 
            // TahunLbl
            // 
            this.TahunLbl.AutoSize = true;
            this.TahunLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TahunLbl.Location = new System.Drawing.Point(23, 308);
            this.TahunLbl.Name = "TahunLbl";
            this.TahunLbl.Size = new System.Drawing.Size(72, 20);
            this.TahunLbl.TabIndex = 18;
            this.TahunLbl.Text = "Tahun :";
            this.TahunLbl.Visible = false;
            // 
            // TahunLblBulanan
            // 
            this.TahunLblBulanan.AutoSize = true;
            this.TahunLblBulanan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TahunLblBulanan.Location = new System.Drawing.Point(23, 365);
            this.TahunLblBulanan.Name = "TahunLblBulanan";
            this.TahunLblBulanan.Size = new System.Drawing.Size(72, 20);
            this.TahunLblBulanan.TabIndex = 19;
            this.TahunLblBulanan.Text = "Tahun :";
            this.TahunLblBulanan.Visible = false;
            // 
            // BulanLbl
            // 
            this.BulanLbl.AutoSize = true;
            this.BulanLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BulanLbl.Location = new System.Drawing.Point(23, 308);
            this.BulanLbl.Name = "BulanLbl";
            this.BulanLbl.Size = new System.Drawing.Size(69, 20);
            this.BulanLbl.TabIndex = 20;
            this.BulanLbl.Text = "Bulan :";
            this.BulanLbl.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Jenis Laporan :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "Nama Sepatu :";
            // 
            // NamaLbl
            // 
            this.NamaLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaLbl.Location = new System.Drawing.Point(166, 156);
            this.NamaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NamaLbl.Name = "NamaLbl";
            this.NamaLbl.Size = new System.Drawing.Size(278, 74);
            this.NamaLbl.TabIndex = 23;
            this.NamaLbl.Text = "-";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Tan;
            this.btn_back.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(1517, 15);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(80, 34);
            this.btn_back.TabIndex = 93;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.Btn_back_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 953);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.NamaLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BulanLbl);
            this.Controls.Add(this.TahunLblBulanan);
            this.Controls.Add(this.TahunLbl);
            this.Controls.Add(this.TahunCmbTahunan);
            this.Controls.Add(this.TahunCmbBulanan);
            this.Controls.Add(this.BulanCmb);
            this.Controls.Add(this.TglAkhirLbl);
            this.Controls.Add(this.TglAwalLbl);
            this.Controls.Add(this.TglAkhir);
            this.Controls.Add(this.TglAwal);
            this.Controls.Add(this.DailyLbl);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Main);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_buat);
            this.Controls.Add(this.cmb_pilihan);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_pilihan;
        private System.Windows.Forms.Button btn_buat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Main;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.Label DailyLbl;
        private System.Windows.Forms.DateTimePicker TglAwal;
        private System.Windows.Forms.DateTimePicker TglAkhir;
        private System.Windows.Forms.Label TglAwalLbl;
        private System.Windows.Forms.Label TglAkhirLbl;
        private System.Windows.Forms.ComboBox BulanCmb;
        private System.Windows.Forms.ComboBox TahunCmbBulanan;
        private System.Windows.Forms.ComboBox TahunCmbTahunan;
        private System.Windows.Forms.Label TahunLbl;
        private System.Windows.Forms.Label TahunLblBulanan;
        private System.Windows.Forms.Label BulanLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label NamaLbl;
        private System.Windows.Forms.Button btn_back;
    }
}