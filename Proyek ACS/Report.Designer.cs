namespace Proyek_ACS
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
            this.TglAwal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.DailyLbl = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TglAkhir = new System.Windows.Forms.DateTimePicker();
            this.TglAwalLbl = new System.Windows.Forms.Label();
            this.TglAkhirLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(755, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report";
            // 
            // cmb_pilihan
            // 
            this.cmb_pilihan.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pilihan.FormattingEnabled = true;
            this.cmb_pilihan.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Yearly",
            "Custom"});
            this.cmb_pilihan.Location = new System.Drawing.Point(23, 148);
            this.cmb_pilihan.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_pilihan.Name = "cmb_pilihan";
            this.cmb_pilihan.Size = new System.Drawing.Size(243, 30);
            this.cmb_pilihan.TabIndex = 1;
            this.cmb_pilihan.SelectedIndexChanged += new System.EventHandler(this.Cmb_pilihan_SelectedIndexChanged);
            // 
            // btn_buat
            // 
            this.btn_buat.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buat.Location = new System.Drawing.Point(275, 140);
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
            // TglAwal
            // 
            this.TglAwal.ActiveViewIndex = -1;
            this.TglAwal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TglAwal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TglAwal.Cursor = System.Windows.Forms.Cursors.Default;
            this.TglAwal.DisplayStatusBar = false;
            this.TglAwal.Location = new System.Drawing.Point(418, 127);
            this.TglAwal.Name = "TglAwal";
            this.TglAwal.ShowCopyButton = false;
            this.TglAwal.ShowZoomButton = false;
            this.TglAwal.Size = new System.Drawing.Size(1302, 814);
            this.TglAwal.TabIndex = 8;
            this.TglAwal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.TglAwal.Visible = false;
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(27, 217);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(243, 22);
            this.Date.TabIndex = 9;
            this.Date.Visible = false;
            // 
            // DailyLbl
            // 
            this.DailyLbl.AutoSize = true;
            this.DailyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DailyLbl.Location = new System.Drawing.Point(23, 194);
            this.DailyLbl.Name = "DailyLbl";
            this.DailyLbl.Size = new System.Drawing.Size(130, 20);
            this.DailyLbl.TabIndex = 10;
            this.DailyLbl.Text = "Pilih Tanggal :";
            this.DailyLbl.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(27, 217);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(243, 22);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Visible = false;
            // 
            // TglAkhir
            // 
            this.TglAkhir.Location = new System.Drawing.Point(27, 265);
            this.TglAkhir.Name = "TglAkhir";
            this.TglAkhir.Size = new System.Drawing.Size(243, 22);
            this.TglAkhir.TabIndex = 12;
            this.TglAkhir.Visible = false;
            // 
            // TglAwalLbl
            // 
            this.TglAwalLbl.AutoSize = true;
            this.TglAwalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TglAwalLbl.Location = new System.Drawing.Point(23, 194);
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
            this.TglAkhirLbl.Location = new System.Drawing.Point(23, 242);
            this.TglAkhirLbl.Name = "TglAkhirLbl";
            this.TglAkhirLbl.Size = new System.Drawing.Size(136, 20);
            this.TglAkhirLbl.TabIndex = 14;
            this.TglAkhirLbl.Text = "Tanggal Akhir :";
            this.TglAkhirLbl.Visible = false;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1732, 953);
            this.Controls.Add(this.TglAkhirLbl);
            this.Controls.Add(this.TglAwalLbl);
            this.Controls.Add(this.TglAkhir);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.DailyLbl);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.TglAwal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_buat);
            this.Controls.Add(this.cmb_pilihan);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_pilihan;
        private System.Windows.Forms.Button btn_buat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer TglAwal;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.Label DailyLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker TglAkhir;
        private System.Windows.Forms.Label TglAwalLbl;
        private System.Windows.Forms.Label TglAkhirLbl;
    }
}