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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtMaLoaiPhong = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtLoading = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewDatPhong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridviewDatPhong
            // 
            this.gridviewDatPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewDatPhong.Location = new System.Drawing.Point(13, 363);
            this.gridviewDatPhong.Name = "gridviewDatPhong";
            this.gridviewDatPhong.ReadOnly = true;
            this.gridviewDatPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewDatPhong.Size = new System.Drawing.Size(811, 155);
            this.gridviewDatPhong.TabIndex = 0;
            this.gridviewDatPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewDatPhong_CellContentClick);
            // 
            // btnSaveHoaDon
            // 
            this.btnSaveHoaDon.Location = new System.Drawing.Point(627, 322);
            this.btnSaveHoaDon.Name = "btnSaveHoaDon";
            this.btnSaveHoaDon.Size = new System.Drawing.Size(91, 38);
            this.btnSaveHoaDon.TabIndex = 1;
            this.btnSaveHoaDon.Text = "Lưu trữ";
            this.btnSaveHoaDon.UseVisualStyleBackColor = true;
            this.btnSaveHoaDon.Click += new System.EventHandler(this.btnSaveHoaDon_Click);
            // 
            // txtMaDP
            // 
            this.txtMaDP.Location = new System.Drawing.Point(113, 12);
            this.txtMaDP.Name = "txtMaDP";
            this.txtMaDP.Size = new System.Drawing.Size(100, 20);
            this.txtMaDP.TabIndex = 2;
            // 
            // btnTimDP
            // 
            this.btnTimDP.Location = new System.Drawing.Point(457, 15);
            this.btnTimDP.Name = "btnTimDP";
            this.btnTimDP.Size = new System.Drawing.Size(139, 23);
            this.btnTimDP.TabIndex = 4;
            this.btnTimDP.Text = "Tìm thông tin đặt phòng";
            this.btnTimDP.UseVisualStyleBackColor = true;
            this.btnTimDP.Click += new System.EventHandler(this.btnTimDP_Click);
            // 
            // dateNgayThanhToan
            // 
            this.dateNgayThanhToan.Location = new System.Drawing.Point(123, 28);
            this.dateNgayThanhToan.Name = "dateNgayThanhToan";
            this.dateNgayThanhToan.Size = new System.Drawing.Size(269, 20);
            this.dateNgayThanhToan.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày Thanh Toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng Tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(123, 54);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(269, 20);
            this.txtTongTien.TabIndex = 8;
            // 
            // txtTenLoaiPhong
            // 
            this.txtTenLoaiPhong.Location = new System.Drawing.Point(122, 135);
            this.txtTenLoaiPhong.Name = "txtTenLoaiPhong";
            this.txtTenLoaiPhong.ReadOnly = true;
            this.txtTenLoaiPhong.Size = new System.Drawing.Size(268, 20);
            this.txtTenLoaiPhong.TabIndex = 35;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(123, 110);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(268, 20);
            this.txtTenKH.TabIndex = 34;
            // 
            // txtTenKS
            // 
            this.txtTenKS.Location = new System.Drawing.Point(123, 87);
            this.txtTenKS.Name = "txtTenKS";
            this.txtTenKS.ReadOnly = true;
            this.txtTenKS.Size = new System.Drawing.Size(268, 20);
            this.txtTenKS.TabIndex = 33;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(122, 162);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(269, 20);
            this.txtDonGia.TabIndex = 31;
            // 
            // dateNgayDat
            // 
            this.dateNgayDat.Location = new System.Drawing.Point(535, 79);
            this.dateNgayDat.Name = "dateNgayDat";
            this.dateNgayDat.Size = new System.Drawing.Size(269, 20);
            this.dateNgayDat.TabIndex = 30;
            // 
            // dateTraPhong
            // 
            this.dateTraPhong.Location = new System.Drawing.Point(535, 53);
            this.dateTraPhong.Name = "dateTraPhong";
            this.dateTraPhong.Size = new System.Drawing.Size(269, 20);
            this.dateTraPhong.TabIndex = 29;
            // 
            // dateBatDau
            // 
            this.dateBatDau.Location = new System.Drawing.Point(535, 28);
            this.dateBatDau.Name = "dateBatDau";
            this.dateBatDau.Size = new System.Drawing.Size(269, 20);
            this.dateBatDau.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "ĐƠN GIÁ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "NGÀY ĐẶT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "NGÀY TRẢ PHÒNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "NGÀY BẮT ĐẦU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "TÊN KHÁCH HÀNG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "TÊN LOẠI PHÒNG";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "KHÁCH SẠN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(724, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 37;
            this.button1.Text = "Tìm kiếm hóa đơn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateNgayDat);
            this.groupBox1.Controls.Add(this.dateNgayThanhToan);
            this.groupBox1.Controls.Add(this.dateTraPhong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateBatDau);
            this.groupBox1.Controls.Add(this.txtTenLoaiPhong);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTenKS);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 206);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HÓA ĐƠN";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(14, 336);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 39;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtMaLoaiPhong
            // 
            this.txtMaLoaiPhong.Location = new System.Drawing.Point(326, 41);
            this.txtMaLoaiPhong.Name = "txtMaLoaiPhong";
            this.txtMaLoaiPhong.Size = new System.Drawing.Size(100, 20);
            this.txtMaLoaiPhong.TabIndex = 42;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(326, 64);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(100, 20);
            this.txtTenDangNhap.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Mã Đặt Phòng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Mã Loại Phòng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(224, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Tên Đăng Nhập";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(272, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "CMND";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(326, 15);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(100, 20);
            this.txtCMND.TabIndex = 48;
            // 
            // txtLoading
            // 
            this.txtLoading.AutoSize = true;
            this.txtLoading.ForeColor = System.Drawing.Color.DarkRed;
            this.txtLoading.Location = new System.Drawing.Point(110, 341);
            this.txtLoading.Name = "txtLoading";
            this.txtLoading.Size = new System.Drawing.Size(0, 13);
            this.txtLoading.TabIndex = 49;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(724, 84);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(100, 20);
            this.txtMaKH.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(631, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Mã Khách Hàng";
            // 
            // HoaDonUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 530);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.txtLoading);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.txtMaLoaiPhong);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTimDP);
            this.Controls.Add(this.txtMaDP);
            this.Controls.Add(this.btnSaveHoaDon);
            this.Controls.Add(this.gridviewDatPhong);
            this.Name = "HoaDonUI";
            this.Text = "HoaDonUI";
            this.Load += new System.EventHandler(this.HoaDonUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewDatPhong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtMaLoaiPhong;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label txtLoading;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label14;
    }
}