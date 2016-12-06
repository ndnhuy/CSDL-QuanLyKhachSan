using QuanLyKhachSan.KhachHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class TaoTaiKhoanUI : Form
    {
        public TaoTaiKhoanUI()
        {
            InitializeComponent();
        }

        private void buttonTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (textBoxHoTen.Text == "")
            {
                MessageBox.Show("Họ tên không được bỏ trống");
                return;
            }

            if (textBoxTenDangNhap.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
                return;
            }

            if (textBoxMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                return;
            }

            if (textBoxCMND.Text == "")
            {
                MessageBox.Show("Số CMND không được bỏ trống");
                return;
            }

            KhachHang.KhachHang khachHang = new KhachHang.KhachHang();
            khachHang.HoTen = textBoxHoTen.Text;
            khachHang.TenDangNhap = textBoxTenDangNhap.Text;
            khachHang.MatKhau = textBoxMatKhau.Text;
            khachHang.SoCMND = textBoxCMND.Text;
            khachHang.DiaChi = textBoxDiaChi.Text;
            khachHang.SoDienThoai = textBoxSDT.Text;
            khachHang.MoTa = textBoxMoTa.Text;
            khachHang.Email = textBoxEmail.Text;

            KhachHangDAO khachHangDAO = new KhachHangDAO();
            khachHangDAO.add(khachHang);

            // Sau khi đăng nhập thành công thì quay trở lại màn hình đăng nhập
            MessageBox.Show("Đã tạo tài khoản thành công với tên đăng nhập là: " + khachHang.TenDangNhap);
            new DangNhapUI().Show();
            Hide();
        }
    }
}
