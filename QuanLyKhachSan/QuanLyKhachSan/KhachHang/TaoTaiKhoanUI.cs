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

            if (IsInvalidInput(textBoxTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được chứa kí tự đặc biệt");
                return;
            }

            if (textBoxMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                return;
            }

            if (textBoxMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu không được ít hơn 6 kí tự");
                return;
            }

            if (IsInvalidInput(textBoxMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được chứa kí tự đặc biệt");
                return;
            }

            if (textBoxCMND.Text == "")
            {
                MessageBox.Show("Số CMND không được bỏ trống");
                return;
            }

            if (textBoxEmail.Text != "" && !IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }

            if (new KhachHangDAO().exist(textBoxTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại.");
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
            Hide();
        }

        private bool IsInvalidInput(String s)
        {
            return !s.All(c => char.IsLetter(c) || char.IsNumber(c));
        }

        private void TaoTaiKhoanUI_Load(object sender, EventArgs e)
        {
            textBoxCMND.KeyPress += NumberOnly_KeyPress;
            textBoxSDT.KeyPress += NumberOnly_KeyPress;
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
