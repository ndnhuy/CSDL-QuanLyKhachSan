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

        private const String SELECT_ALL_LOAIPHONG_KHACHSAN = @"select lp.maLoaiPhong, lp.tenLoaiPhong, ks.tenKS, lp.donGia
                                                               from LoaiPhong lp
                                                               inner join KhachSan ks
                                                               on ks.maKS = lp.maKS
                                                               where ks.maKS = {0}";

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
            // DateTimePicker events
            dateNgayDat.Value = DateTime.Now;
            dateBatDau.MinDate = DateTime.Now;
            dateBatDau.ValueChanged += DateBatDau_ValueChanged;

            comboboxTinhTrang.SelectedIndex = 0;
            gridviewPhong.SelectionChanged += GridviewPhong_SelectionChanged;

            txtTenKH.Text = khachHang.HoTen;

            gridviewPhong.DataSource = phongBindingSource;
            gridviewPhong.Rows.Clear();
        }

        private void DateBatDau_ValueChanged(object sender, EventArgs e)
        {
            //DateTimePicker datetime = (DateTimePicker)sender;
            // if pickanydate return -1, then show error
            //int maLoaiPhong = (int)gridviewPhong.SelectedRows[0].Cells["maLoaiPhong"].Value;
            //if (datphongDAO.pickAnyAvailableRoom(maLoaiPhong, datetime.Value) == -1)
            //{
            //    MessageBox.Show("Ngày bắt đầu không hợp lệ vì không còn phòng trống");
            //    datetime.Value = DateTime.Now;
            //}
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

            if (datphong.NgayTraPhong <= datphong.NgayBatDau)
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày bắt đầu");
                gridviewPhong.Rows.Clear();
                return;
            }

            int maPhongTrong = datphongDAO.pickAnyAvailableRoom(datphong.MaLoaiPhong, datphong.NgayBatDau, datphong.NgayTraPhong);
            if (maPhongTrong == -1) 
            {
                // Không còn phòng trống
                MessageBox.Show("Không còn phòng trống");
                return;
            }

            // Đặt phòng
            // Update hoặc create trạng thái mới "đang sử dụng" cho phòng tương ứng trong các ngày từ ngayBatDau -> ngayTraPhong
            datphongDAO.datPhong(datphong);
            DateTime ngay = datphong.NgayBatDau;
            for (; ngay < datphong.NgayTraPhong; ngay = ngay.AddDays(1))
            {
                datphongDAO.updateTrangThaiPhong(maPhongTrong, ngay, "đang sử dụng");
            }

            MessageBox.Show(String.Format("Quý khách đã đặt phòng thành công (Mã phòng: {0})", maPhongTrong));
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dateTraPhong.Value <= dateBatDau.Value)
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày bắt đầu");
                return;
            }

            String query = @"select LoaiPhong.maLoaiPhong, LoaiPhong.tenLoaiPhong, KhachSan.tenKS, LoaiPhong.donGia 
                            from LoaiPhong
                            inner join KhachSan
                            on LoaiPhong.maKS = KhachSan.maKS
                            where KhachSan.maKS = {0}
                            and exists (select maPhong from Phong
			                            where Phong.loaiPhong = LoaiPhong.maLoaiPhong 
			                            and maPhong not in (select maPhong from TrangThaiPhong
									                        where TrangThaiPhong.maPhong = maPhong
									                                and TrangThaiPhong.ngay >= '{1}'
									                                and TrangThaiPhong.ngay < '{2}'
									                                and TrangThaiPhong.tinhTrang = N'đang sử dụng'))";


            GetData(String.Format(query, 
                                  maKS,
                                  dateBatDau.Value.ToString("yyyy-MM-dd"), 
                                  dateTraPhong.Value.ToString("yyyy-MM-dd"))
                   );
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
