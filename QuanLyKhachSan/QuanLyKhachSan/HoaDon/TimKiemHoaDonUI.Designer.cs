namespace QuanLyKhachSan.HoaDon
{
    partial class TimKiemHoaDonUI
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
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxMaKH = new System.Windows.Forms.TextBox();
            this.textboxThanhTien = new System.Windows.Forms.TextBox();
            this.gridviewHoaDon = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.Location = new System.Drawing.Point(103, 35);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(200, 20);
            this.dateNgayLap.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày Lập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thành Tiền";
            // 
            // textboxMaKH
            // 
            this.textboxMaKH.Location = new System.Drawing.Point(103, 9);
            this.textboxMaKH.Name = "textboxMaKH";
            this.textboxMaKH.Size = new System.Drawing.Size(200, 20);
            this.textboxMaKH.TabIndex = 4;
            // 
            // textboxThanhTien
            // 
            this.textboxThanhTien.Location = new System.Drawing.Point(103, 61);
            this.textboxThanhTien.Name = "textboxThanhTien";
            this.textboxThanhTien.Size = new System.Drawing.Size(200, 20);
            this.textboxThanhTien.TabIndex = 5;
            // 
            // gridviewHoaDon
            // 
            this.gridviewHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewHoaDon.Location = new System.Drawing.Point(15, 109);
            this.gridviewHoaDon.Name = "gridviewHoaDon";
            this.gridviewHoaDon.Size = new System.Drawing.Size(371, 150);
            this.gridviewHoaDon.TabIndex = 6;
            // 
            // TimKiemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 272);
            this.Controls.Add(this.gridviewHoaDon);
            this.Controls.Add(this.textboxThanhTien);
            this.Controls.Add(this.textboxMaKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateNgayLap);
            this.Controls.Add(this.label1);
            this.Name = "TimKiemHoaDon";
            this.Text = "TimKiemHoaDon";
            this.Load += new System.EventHandler(this.TimKiemHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textboxMaKH;
        private System.Windows.Forms.TextBox textboxThanhTien;
        private System.Windows.Forms.DataGridView gridviewHoaDon;
    }
}