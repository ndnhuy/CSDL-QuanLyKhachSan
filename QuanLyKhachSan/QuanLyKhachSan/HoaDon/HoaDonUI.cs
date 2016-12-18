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
                Console.WriteLine("Done");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Đã xảy ra lỗi.");
                throw e;
            }
        }

        private void HoaDonUI_Load(object sender, EventArgs e)
        {
            gridviewDatPhong.DataSource = datphongBindingSource;
            gridviewDatPhong.SelectionChanged += GridviewDatPhong_SelectionChanged;
            txtMaDP.KeyPress += NumberOnly_KeyPress;
            txtCMND.KeyPress += NumberOnly_KeyPress;
            txtMaLoaiPhong.KeyPress += NumberOnly_KeyPress;

            //GetData(hoaDonDAO.getQueryStringOfAllDatPhong());
            // GetData("select * from DatPhong");
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void GridviewDatPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (gridviewDatPhong.SelectedRows.Count == 0)
            {
                return;
            }

            txtMaKH.Text = gridviewDatPhong.SelectedRows[0].Cells["maKH"].Value.ToString();

            txtMaDP.Text = gridviewDatPhong.SelectedRows[0].Cells["maDP"].Value.ToString();
            txtTenKS.Text = gridviewDatPhong.SelectedRows[0].Cells["tenKS"].Value.ToString();
            txtDonGia.Text = gridviewDatPhong.SelectedRows[0].Cells["donGia"].Value.ToString();
            txtTenLoaiPhong.Text = gridviewDatPhong.SelectedRows[0].Cells["tenLoaiPhong"].Value.ToString();
            txtTenKH.Text = gridviewDatPhong.SelectedRows[0].Cells["hoTen"].Value.ToString();
            dateBatDau.Text = gridviewDatPhong.SelectedRows[0].Cells["ngayBatDau"].Value.ToString();
            dateNgayDat.Text = gridviewDatPhong.SelectedRows[0].Cells["ngayDat"].Value.ToString();
            dateTraPhong.Text = gridviewDatPhong.SelectedRows[0].Cells["ngayTraPhong"].Value.ToString();
            dateNgayThanhToan.Text = DateTime.Now.ToString();

            int dongia;
            if (Int32.TryParse(gridviewDatPhong.SelectedRows[0].Cells["donGia"].Value.ToString(), out dongia))
            {
                txtTongTien.Text = ((dateTraPhong.Value - dateBatDau.Value).Days * dongia).ToString();
            }
        }

        private void btnTimDP_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Loading...");
            if (txtMaDP.Text == "" && txtCMND.Text == "" && txtMaLoaiPhong.Text == "" && txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Nhập mã đặt phòng");
                return;
            }

            int maDP, maLoaiPhong;
            GetData(hoaDonDAO.buildQueryStringFromSearchArgs(Int32.TryParse(txtMaDP.Text, out maDP) ? maDP : 0,
                                                             Int32.TryParse(txtMaLoaiPhong.Text, out maLoaiPhong) ? maLoaiPhong : 0,
                                                             txtCMND.Text,
                                                             txtTenDangNhap.Text));

            //int maDP = Int32.Parse(txtMaDP.Text.ToString());
            //int maLoaiPhong;
            //HoaDon hd = hoaDonDAO.lapHoaDon(maDP, 
            //                                Int32.TryParse(txtMaLoaiPhong.Text, out maLoaiPhong) ? maLoaiPhong : 0,
            //                                txtCMND.Text,
            //                                txtTenDangNhap.Text);

            //if (hd == null)
            //{
            //    MessageBox.Show("Mã đặt phòng không tồn tại");
            //    return;
            //}

            //txtTenKS.Text = hd.TenKhachSan;
            //txtDonGia.Text = hd.DonGia.ToString();
            //txtTenLoaiPhong.Text = hd.TenLoaiPhong;
            //txtTenKH.Text = hd.TenKhachHang;
            //dateNgayDat.Text = hd.NgayDat.ToString();
            //dateBatDau.Text = hd.NgayBatDau.ToString();
            //dateTraPhong.Text = hd.NgayTraPhong.ToString();
            //dateNgayThanhToan.Text = DateTime.Now.ToString();
            //txtTongTien.Text = ((dateTraPhong.Value - dateBatDau.Value).Days * Int32.Parse(txtDonGia.Text.ToString())).ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new TimKiemHoaDonUI().Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
