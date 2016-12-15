using QuanLyKhachSan.HoaDon;
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
using QuanLyKhachSan.KhachHang;

namespace QuanLyKhachSan.Phong
{
    public partial class DatPhongUI : Form
    {
        private BindingSource phongBindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private int maKS;
        private KhachHang.KhachHang khachHang = null;
        private DatPhongDAO datphongDAO = new DatPhongDAO();

        private const String SELECT_ALL_LOAIPHONG_KHACHSAN = "select lp.maLoaiPhong, lp.tenLoaiPhong, ks.tenKS, lp.donGia, lp.slTrong from KhachSan ks, LoaiPhong lp" +
                                                            " where ks.maKS = lp.maKS";

        public DatPhongUI()
        {
            InitializeComponent();
        }
        public DatPhongUI(int maKS, KhachHang.KhachHang kh)
        {
            InitializeComponent();
            this.maKS = maKS;
            this.khachHang = kh;
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
                phongBindingSource.DataSource = table;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Đã xảy ra lỗi.");
            }
        }

        private void DatPhongUI_Load(object sender, EventArgs e)
        {
            comboboxTinhTrang.SelectedIndex = 0;
            gridviewPhong.SelectionChanged += GridviewPhong_SelectionChanged;

            txtTenKH.Text = khachHang.HoTen;

            gridviewPhong.DataSource = phongBindingSource;
            GetData(SELECT_ALL_LOAIPHONG_KHACHSAN);
        }


        private void GridviewPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (gridviewPhong.SelectedRows.Count == 0)
            {
                return;
            }
            txtTenKS.Text = gridviewPhong.SelectedRows[0].Cells["tenKS"].Value.ToString();
            txtDonGia.Text = gridviewPhong.SelectedRows[0].Cells["donGia"].Value.ToString();
            txtTenLoaiPhong.Text = gridviewPhong.SelectedRows[0].Cells["tenLoaiPhong"].Value.ToString();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (gridviewPhong.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Chưa chọn loại phòng.");
                return;
            }

            ThongTinDatPhong datphong = new ThongTinDatPhong();
            datphong.MaLoaiPhong = (int)gridviewPhong.SelectedRows[0].Cells["maLoaiPhong"].Value;
            datphong.NgayBatDau = dateBatDau.Value;
            datphong.NgayTraPhong = dateTraPhong.Value;
            datphong.NgayDat = dateNgayDat.Value;
            datphong.DonGia = (int)gridviewPhong.SelectedRows[0].Cells["donGia"].Value;
            datphong.MoTa = txtMoTa.Text;
            datphong.TinhTrang = comboboxTinhTrang.SelectedItem.ToString();
            datphong.MaKH = khachHang.MaKH;


            int maPhongTrong = datphongDAO.pickAnyAvailableRoom(datphong.MaLoaiPhong, datphong.NgayBatDau);
            if (maPhongTrong == -1) 
            {
                // Không còn phòng trống
                MessageBox.Show("Không còn phòng trống");
                return;
            }

            // Đặt phòng
            // Giảm số lượng trống của loại phòng tương ứng
            // Update hoặc create trạng thái mới "đang sử dụng" cho phòng tương ứng
            datphongDAO.datPhong(datphong);
            datphongDAO.decreaseNumberOfAvailableRooms(datphong.MaLoaiPhong);
            datphongDAO.updateTrangThaiPhong(maPhongTrong, datphong.NgayBatDau, "đang sử dụng");

            MessageBox.Show("Đặt phòng thành công.");
            GetData(SELECT_ALL_LOAIPHONG_KHACHSAN);
        }

    }
}
