namespace QuanLyKhachSan.KhachSan
{
    partial class ThongTinKhachSanUI
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
            this.gridviewKhachSan = new System.Windows.Forms.DataGridView();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.comboboxHangSao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThanhPho = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.checkboxGiaTB = new System.Windows.Forms.CheckBox();
            this.checkboxHangSao = new System.Windows.Forms.CheckBox();
            this.btnDatPhong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewKhachSan)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewKhachSan
            // 
            this.gridviewKhachSan.AllowUserToAddRows = false;
            this.gridviewKhachSan.AllowUserToDeleteRows = false;
            this.gridviewKhachSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewKhachSan.Location = new System.Drawing.Point(12, 177);
            this.gridviewKhachSan.MultiSelect = false;
            this.gridviewKhachSan.Name = "gridviewKhachSan";
            this.gridviewKhachSan.ReadOnly = true;
            this.gridviewKhachSan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewKhachSan.Size = new System.Drawing.Size(781, 150);
            this.gridviewKhachSan.TabIndex = 0;
            this.gridviewKhachSan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewKhachSan_CellContentClick);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(303, 20);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.Text = "0";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(442, 20);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 2;
            this.txtTo.Text = "0";
            // 
            // comboboxHangSao
            // 
            this.comboboxHangSao.AllowDrop = true;
            this.comboboxHangSao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxHangSao.FormattingEnabled = true;
            this.comboboxHangSao.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboboxHangSao.Location = new System.Drawing.Point(303, 46);
            this.comboboxHangSao.Name = "comboboxHangSao";
            this.comboboxHangSao.Size = new System.Drawing.Size(121, 21);
            this.comboboxHangSao.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Thành phố";
            // 
            // txtThanhPho
            // 
            this.txtThanhPho.Location = new System.Drawing.Point(303, 77);
            this.txtThanhPho.Name = "txtThanhPho";
            this.txtThanhPho.Size = new System.Drawing.Size(100, 20);
            this.txtThanhPho.TabIndex = 9;
            this.txtThanhPho.Text = "Hồ Chí Minh";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(303, 113);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // checkboxGiaTB
            // 
            this.checkboxGiaTB.AutoSize = true;
            this.checkboxGiaTB.Location = new System.Drawing.Point(169, 23);
            this.checkboxGiaTB.Name = "checkboxGiaTB";
            this.checkboxGiaTB.Size = new System.Drawing.Size(92, 17);
            this.checkboxGiaTB.TabIndex = 11;
            this.checkboxGiaTB.Text = "Giá trung bình";
            this.checkboxGiaTB.UseVisualStyleBackColor = true;
            this.checkboxGiaTB.CheckedChanged += new System.EventHandler(this.checkboxGiaTB_CheckedChanged);
            // 
            // checkboxHangSao
            // 
            this.checkboxHangSao.AutoSize = true;
            this.checkboxHangSao.Location = new System.Drawing.Point(169, 50);
            this.checkboxHangSao.Name = "checkboxHangSao";
            this.checkboxHangSao.Size = new System.Drawing.Size(72, 17);
            this.checkboxHangSao.TabIndex = 12;
            this.checkboxHangSao.Text = "Hạng sao";
            this.checkboxHangSao.UseVisualStyleBackColor = true;
            this.checkboxHangSao.CheckedChanged += new System.EventHandler(this.checkboxHangSao_CheckedChanged);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.Location = new System.Drawing.Point(396, 113);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(75, 23);
            this.btnDatPhong.TabIndex = 13;
            this.btnDatPhong.Text = "Đặt Phòng";
            this.btnDatPhong.UseVisualStyleBackColor = true;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // ThongTinKhachSanUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 352);
            this.Controls.Add(this.btnDatPhong);
            this.Controls.Add(this.checkboxHangSao);
            this.Controls.Add(this.checkboxGiaTB);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtThanhPho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboboxHangSao);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.gridviewKhachSan);
            this.Name = "ThongTinKhachSanUI";
            this.Text = "ThongTinKhachSanUI";
            this.Load += new System.EventHandler(this.ThongTinKhachSanUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewKhachSan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridviewKhachSan;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.ComboBox comboboxHangSao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThanhPho;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.CheckBox checkboxGiaTB;
        private System.Windows.Forms.CheckBox checkboxHangSao;
        private System.Windows.Forms.Button btnDatPhong;
    }
}