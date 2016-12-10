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

namespace QuanLyKhachSan.Phong
{
    public partial class DatPhongUI : Form
    {
        private BindingSource phongBindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private int maKS;
        private DatPhongDAO datphongDAO = new DatPhongDAO();
        public DatPhongUI()
        {
            InitializeComponent();
        }
        public DatPhongUI(int maKS)
        {
            InitializeComponent();
            this.maKS = maKS;
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

            gridviewPhong.DataSource = phongBindingSource;
            GetData("select lp.maLoaiPhong, lp.tenLoaiPhong, ks.tenKS, lp.donGia from KhachSan ks, LoaiPhong lp" +
                   " where ks.maKS = lp.maKS");
        }

        private void GridviewPhong_SelectionChanged(object sender, EventArgs e)
        {
            //gridviewKhachSan.SelectedRows[0].Cells["maKS"].Value.ToString()
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
            datphong.MaKH = 1;

            datphongDAO.datPhong(datphong);

            MessageBox.Show("Đặt phòng thành công.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new HoaDonUI().Show();
            Hide();
        }
    }
}
