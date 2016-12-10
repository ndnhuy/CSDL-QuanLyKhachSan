using QuanLyKhachSan.KhachSan;
using QuanLyKhachSan.Phong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.KhachHang
{
    public partial class DangNhapUI : Form
    {
        private KhachHangDAO khachHangDAO = new KhachHangDAO();
        public DangNhapUI()
        {
            InitializeComponent();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if (textBoxTenDangNhap.Text == "" || textBoxMatKhau.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
                return;
            }

            if (!khachHangDAO.exist(textBoxTenDangNhap.Text, textBoxMatKhau.Text))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                return;
            }

            KhachHang kh = khachHangDAO.getKhachHang(textBoxTenDangNhap.Text);
            MessageBox.Show(String.Format("Chào mừng khách hàng {0} với mã số {1}",
                                          kh.HoTen,
                                          kh.MaKH));

            new ThongTinKhachSanUI(kh).Show();
            Hide();

        }

        private void buttonTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            new TaoTaiKhoanUI().Show();
        }
    }
}
