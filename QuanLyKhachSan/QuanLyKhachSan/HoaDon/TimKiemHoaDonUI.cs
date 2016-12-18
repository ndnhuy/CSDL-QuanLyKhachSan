using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.HoaDon
{
    public partial class TimKiemHoaDonUI : Form
    {
        private BindingSource timkiemBindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public TimKiemHoaDonUI()
        {
            InitializeComponent();
        }
        private void GetData(string selectCommand)
        {
            try
            {
                String connectionString =
                    ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                timkiemBindingSource.DataSource = table;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Đã xảy ra lỗi.");
            }
        }

        private void TimKiemHoaDon_Load(object sender, EventArgs e)
        {
            gridviewHoaDon.DataSource = timkiemBindingSource;
            gridviewHoaDon.SelectionChanged += GridviewHoaDon_SelectionChanged;

            textboxMaKH.KeyPress += TextboxNumberInputOnly_KeyPress;
            textboxThanhTien.KeyPress += TextboxNumberInputOnly_KeyPress;

            //GetData(queryAll());
        }

        private void GridviewHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (gridviewHoaDon.SelectedRows.Count == 0 || gridviewHoaDon.SelectedRows[0].Cells.Count == 0)
            {
                return;
            }


            int maHD;
            if (!Int32.TryParse(gridviewHoaDon.SelectedRows[0].Cells["maHD"].Value.ToString(), out maHD))
            {
                return;
            }

            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            HoaDon hd = hoaDonDAO.getHoaDon(maHD);

            if (hd == null)
            {
                MessageBox.Show("Mã đặt phòng không tồn tại");
                return;
            }

            txtTenKS.Text = hd.TenKhachSan;
            txtDonGia.Text = hd.DonGia.ToString();
            txtTenLoaiPhong.Text = hd.TenLoaiPhong;
            txtTenKH.Text = hd.TenKhachHang;
            dateNgayDat.Text = hd.NgayDat.ToString();
            dateBatDau.Text = hd.NgayBatDau.ToString();
            dateTraPhong.Text = hd.NgayTraPhong.ToString();
            dateNgayThanhToan.Text = hd.NgayThanhToan.ToString();
            txtTongTien.Text = hd.TongTien.ToString();
        }

        private void TextboxNumberInputOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (textboxMaKH.Text == "" 
                || dateNgayLap.Text == "" 
                || textboxThanhTien.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin tìm kiếm.");
                return;
            }

            GetData(queryWith(
                    textboxMaKH.Text,
                    dateNgayLap.Value.ToString("yyyy-MM-dd"),
                    textboxThanhTien.Text
                ));
        }

        private String queryWith(String maKH, String ngayLap, String tongTien)
        {
            //dateNgayLap.Value.ToShortDateString()
            return String.Format("select hd.maDP, hd.maHD, hd.ngayThanhToan, hd.tongTien from HoaDon hd, DatPhong dp, KhachHang kh" +
                            " where hd.maDP = dp.maDP" +
                            " AND dp.maKH = kh.maKH" +
                            " AND dp.maKH = {0}" +
                            " AND hd.ngayThanhToan = '{1}'" +
                            " AND hd.tongTien = {2}",
                            maKH,
                            ngayLap,
                            tongTien);
        }

        private String queryAll()
        {
            return "select hd.maDP, hd.maHD, hd.ngayThanhToan, hd.tongTien from HoaDon hd, DatPhong dp, KhachHang kh" +
                            " where hd.maDP = dp.maDP" +
                            " AND dp.maKH = kh.maKH";
        }
    }
}
