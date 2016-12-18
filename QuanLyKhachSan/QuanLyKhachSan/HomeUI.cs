using QuanLyKhachSan.HoaDon;
using QuanLyKhachSan.KhachHang;
using QuanLyKhachSan.ThongKe;
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
    public partial class HomeUI : Form
    {
        public HomeUI()
        {
            InitializeComponent();   
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            new DangNhapUI().Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            new HoaDonUI().Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            new DoanhThuForm().Show();
        }

        private void btnSoLuongTrong_Click(object sender, EventArgs e)
        {
            new SlTrongReport().Show();
        }
    }
}
