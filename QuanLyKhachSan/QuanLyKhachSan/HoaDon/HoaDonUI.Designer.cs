namespace QuanLyKhachSan.HoaDon
{
    partial class HoaDonUI
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
            this.gridviewDatPhong = new System.Windows.Forms.DataGridView();
            this.btnSaveHoaDon = new System.Windows.Forms.Button();
            this.txtMaDP = new System.Windows.Forms.TextBox();
            this.btnTimDP = new System.Windows.Forms.Button();
            this.dateNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtTenLoaiPhong = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtTenKS = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.dateNgayDat = new System.Windows.Forms.DateTimePicker();
            this.dateTraPhong = new System.Windows.Forms.DateTimePicker();
            this.dateBatDau = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkboxTimKiemDP = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewDatPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewDatPhong
            // 
            this.gridviewDatPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewDatPhong.Location = new System.Drawing.Point(12, 305);
            this.gridviewDatPhong.Name = "gridviewDatPhong";
            this.gridviewDatPhong.ReadOnly = true;
            this.gridviewDatPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewDatPhong.Size = new System.Drawing.Size(577, 181);
            this.gridviewDatPhong.TabIndex = 0;
            this.gridviewDatPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewDatPhong_CellContentClick);
            // 
            // btnSaveHoaDon
            // 
            this.btnSaveHoaDon.Location = new System.Drawing.Point(498, 276);
            this.btnSaveHoaDon.Name = "btnSaveHoaDon";
            this.btnSaveHoaDon.Size = new System.Drawing.Size(91, 23);
            this.btnSaveHoaDon.TabIndex = 1;
            this.btnSaveHoaDon.Text = "Lưu trữ";
            this.btnSaveHoaDon.UseVisualStyleBackColor = true;
            this.btnSaveHoaDon.Click += new System.EventHandler(this.btnSaveHoaDon_Click);
            // 
            // txtMaDP
            // 
            this.txtMaDP.Enabled = false;
            this.txtMaDP.Location = new System.Drawing.Point(118, 12);
            this.txtMaDP.Name = "txtMaDP";
            this.txtMaDP.Size = new System.Drawing.Size(126, 20);
            this.txtMaDP.TabIndex = 2;
            // 
            // btnTimDP
            // 
            this.btnTimDP.Enabled = false;
            this.btnTimDP.Location = new System.Drawing.Point(250, 12);
            this.btnTimDP.Name = "btnTimDP";
            this.btnTimDP.Size = new System.Drawing.Size(139, 23);
            this.btnTimDP.TabIndex = 4;
            this.btnTimDP.Text = "Tìm thông tin đặt phòng";
            this.btnTimDP.UseVisualStyleBackColor = true;
            this.btnTimDP.Click += new System.EventHandler(this.btnTimDP_Click);
            // 
            // dateNgayThanhToan
            // 
            this.dateNgayThanhToan.Location = new System.Drawing.Point(119, 75);
            this.dateNgayThanhToan.Name = "dateNgayThanhToan";
            this.dateNgayThanhToan.Size = new System.Drawing.Size(269, 20);
            this.dateNgayThanhToan.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày Thanh Toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng Tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(119, 101);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(269, 20);
            this.txtTongTien.TabIndex = 8;
            // 
            // txtTenLoaiPhong
            // 
            this.txtTenLoaiPhong.Location = new System.Drawing.Point(119, 196);
            this.txtTenLoaiPhong.Name = "txtTenLoaiPhong";
            this.txtTenLoaiPhong.ReadOnly = true;
            this.txtTenLoaiPhong.Size = new System.Drawing.Size(268, 20);
            this.txtTenLoaiPhong.TabIndex = 35;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(120, 171);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(268, 20);
            this.txtTenKH.TabIndex = 34;
            // 
            // txtTenKS
            // 
            this.txtTenKS.Location = new System.Drawing.Point(120, 148);
            this.txtTenKS.Name = "txtTenKS";
            this.txtTenKS.ReadOnly = true;
            this.txtTenKS.Size = new System.Drawing.Size(268, 20);
            this.txtTenKS.TabIndex = 33;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(119, 223);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(269, 20);
            this.txtDonGia.TabIndex = 31;
            // 
            // dateNgayDat
            // 
            this.dateNgayDat.Location = new System.Drawing.Point(523, 196);
            this.dateNgayDat.Name = "dateNgayDat";
            this.dateNgayDat.Size = new System.Drawing.Size(269, 20);
            this.dateNgayDat.TabIndex = 30;
            // 
            // dateTraPhong
            // 
            this.dateTraPhong.Location = new System.Drawing.Point(523, 170);
            this.dateTraPhong.Name = "dateTraPhong";
            this.dateTraPhong.Size = new System.Drawing.Size(269, 20);
            this.dateTraPhong.TabIndex = 29;
            // 
            // dateBatDau
            // 
            this.dateBatDau.Location = new System.Drawing.Point(523, 145);
            this.dateBatDau.Name = "dateBatDau";
            this.dateBatDau.Size = new System.Drawing.Size(269, 20);
            this.dateBatDau.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "ĐƠN GIÁ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "NGÀY ĐẶT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "NGÀY TRẢ PHÒNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "NGÀY BẮT ĐẦU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "TÊN KHÁCH HÀNG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "TÊN LOẠI PHÒNG";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "KHÁCH SẠN";
            // 
            // checkboxTimKiemDP
            // 
            this.checkboxTimKiemDP.AutoSize = true;
            this.checkboxTimKiemDP.Location = new System.Drawing.Point(12, 14);
            this.checkboxTimKiemDP.Name = "checkboxTimKiemDP";
            this.checkboxTimKiemDP.Size = new System.Drawing.Size(95, 17);
            this.checkboxTimKiemDP.TabIndex = 36;
            this.checkboxTimKiemDP.Text = "Mã Đặt Phòng";
            this.checkboxTimKiemDP.UseVisualStyleBackColor = true;
            this.checkboxTimKiemDP.CheckedChanged += new System.EventHandler(this.checkboxTimKiemDP_CheckedChanged);
            // 
            // HoaDonUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 489);
            this.Controls.Add(this.checkboxTimKiemDP);
            this.Controls.Add(this.txtTenLoaiPhong);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtTenKS);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.dateNgayDat);
            this.Controls.Add(this.dateTraPhong);
            this.Controls.Add(this.dateBatDau);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateNgayThanhToan);
            this.Controls.Add(this.btnTimDP);
            this.Controls.Add(this.txtMaDP);
            this.Controls.Add(this.btnSaveHoaDon);
            this.Controls.Add(this.gridviewDatPhong);
            this.Name = "HoaDonUI";
            this.Text = "HoaDonUI";
            this.Load += new System.EventHandler(this.HoaDonUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewDatPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridviewDatPhong;
        private System.Windows.Forms.Button btnSaveHoaDon;
        private System.Windows.Forms.TextBox txtMaDP;
        private System.Windows.Forms.Button btnTimDP;
        private System.Windows.Forms.DateTimePicker dateNgayThanhToan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtTenLoaiPhong;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtTenKS;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.DateTimePicker dateNgayDat;
        private System.Windows.Forms.DateTimePicker dateTraPhong;
        private System.Windows.Forms.DateTimePicker dateBatDau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkboxTimKiemDP;
    }
}