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
            // maDP, soPhong, tenKH
            GetData("select dp.maDP, p.soPhong, kh.hoTen, dp.ngayBatDau, dp.ngayTraPhong, dp.ngayDat, dp.donGia, dp.moTa, dp.tinhTrang " +
                "from DatPhong dp, Phong p, KhachHang kh " +
                " where dp.maPhong = p.maPhong and dp.maKH = kh.maKH");
        }

        private void btnTimDP_Click(object sender, EventArgs e)
        {

        }
    }
}
