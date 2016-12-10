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
    public partial class HoaDonUI : Form
    {
        private BindingSource datphongBindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();

        public HoaDonUI()
        {
            InitializeComponent();
        }

        private void gridviewDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
                datphongBindingSource.DataSource = table;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Đã xảy ra lỗi.");
            }
        }

        private void HoaDonUI_Load(object sender, EventArgs e)
        {
            gridviewDatPhong.DataSource = datphongBindingSource;
            gridviewDatPhong.SelectionChanged += GridviewDatPhong_SelectionChanged;
            txtMaDP.KeyPress += TxtMaDP_KeyPress;

            GetData(hoaDonDAO.getQueryStringOfAllDatPhong());
           // GetData("select * from DatPhong");
        }

        private void TxtMaDP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void GridviewDatPhong_SelectionChanged(object sender, EventArgs e)
        {
            txtMaDP.Text = gridviewDatPhong.SelectedRows[0].Cells["maDP"].Value.ToString();
            txtTenKS.Text = gridviewDatPhong.SelectedRows[0].Cells["tenKS"].Value.ToString();
            txtDonGia.Text = gridviewDatPhong.SelectedRows[0].Cells["donGia"].Value.ToString();
            txtTenLoaiPhong.Text = gridviewDatPhong.SelectedRows[0].Cells["tenLoaiPhong"].Value.ToString();
            txtTenKH.Text = gridviewDatPhong.SelectedRows[0].Cells["hoTen"].Value.ToString();
            dateBatDau.Text = gridviewDatPhong.SelectedRows[0].Cells["ngayBatDau"].Value.ToString();
            dateNgayDat.Text = gridviewDatPhong.SelectedRows[0].Cells["ngayDat"].Value.ToString();
            dateTraPhong.Text = gridviewDatPhong.SelectedRows[0].Cells["ngayTraPhong"].Value.ToString();
            dateNgayThanhToan.Text = DateTime.Now.ToString();
            txtTongTien.Text = ( (dateTraPhong.Value - dateBatDau.Value).Days * Int32.Parse(txtDonGia.Text.ToString()) ).ToString();
        }

        private void btnTimDP_Click(object sender, EventArgs e)
        {
            if (txtMaDP.Text == "")
            {
                MessageBox.Show("Nhập mã đặt phòng");
                return;
            }
            int maDP = Int32.Parse(txtMaDP.Text.ToString());
            HoaDon hd = hoaDonDAO.lapHoaDon(maDP);

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
            dateNgayThanhToan.Text = DateTime.Now.ToString();
            txtTongTien.Text = ((dateTraPhong.Value - dateBatDau.Value).Days * Int32.Parse(txtDonGia.Text.ToString())).ToString();
        }

        private void checkboxTimKiemDP_CheckedChanged(object sender, EventArgs e)
        {
            txtMaDP.Enabled = ((CheckBox)sender).Checked;
            btnTimDP.Enabled = ((CheckBox)sender).Checked;
        }

        private void btnSaveHoaDon_Click(object sender, EventArgs e)
        {
            if (dateNgayThanhToan.Value == null || txtTongTien.Text == "" || txtMaDP.Text == "")
            {
                MessageBox.Show("Không thể lưu hóa đơn vì dữ liệu không hợp lệ");
                return;
            }
            hoaDonDAO.saveHoaDon(dateNgayThanhToan.Value, Int64.Parse(txtTongTien.Text), Int32.Parse(txtMaDP.Text));
            MessageBox.Show("Lưu hóa đơn thành công");
        }
    }
}
