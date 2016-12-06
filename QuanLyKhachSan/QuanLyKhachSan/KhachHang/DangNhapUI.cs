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
        public DangNhapUI()
        {
            InitializeComponent();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void buttonTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            new TaoTaiKhoanUI().Show();
            Hide();
        }
    }
}
