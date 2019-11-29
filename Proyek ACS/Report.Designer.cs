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
            this.Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            "Yearly"});
            this.cmb_pilihan.Location = new System.Drawing.Point(23, 148);
            this.cmb_pilihan.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_pilihan.Name = "cmb_pilihan";
            this.cmb_pilihan.Size = new System.Drawing.Size(243, 30);
            this.cmb_pilihan.TabIndex = 1;
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
            this.Main.Location = new System.Drawing.Point(23, 207);
            this.Main.Name = "Main";
            this.Main.ShowCopyButton = false;
            this.Main.ShowZoomButton = false;
            this.Main.Size = new System.Drawing.Size(912, 709);
            this.Main.TabIndex = 8;
            this.Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.Main.Visible = false;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1729, 944);
            this.Controls.Add(this.Main);
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
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Main;
    }
}