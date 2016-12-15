namespace QuanLyKhachSan
{
    partial class HomeUI
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
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(70, 12);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(95, 23);
            this.btnHoaDon.TabIndex = 0;
            this.btnHoaDon.Text = "LẬP HÓA ĐƠN";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(70, 54);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(95, 23);
            this.btnDangNhap.TabIndex = 1;
            this.btnDangNhap.Text = "ĐẶT PHÒNG";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // HomeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 95);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnHoaDon);
            this.Name = "HomeUI";
            this.Text = "Quản Lý Khách Sạn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnDangNhap;
    }
}