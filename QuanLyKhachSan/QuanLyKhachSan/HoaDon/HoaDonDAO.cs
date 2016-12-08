using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HoaDon
{
    public class HoaDonDAO
    {
        // Lấy connection string từ file App.config
        private String connectionString = ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;

        // Lập hóa đơn
        public HoaDon lapHoaDon(int maDP)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

                String query = String.Format("select ks.tenKS, kh.hoTen, loaiphong.tenLoaiPhong, loaiphong.donGia, datphong.ngayBatDau, datphong.ngayTraPhong, datphong.ngayDat" + 
                                                 " from DatPhong datphong, LoaiPhong loaiphong, KhachSan ks, KhachHang kh where" +
                                                 " datphong.maLoaiPhong = loaiphong.maLoaiPhong" +
                                                 " AND datphong.maKH = kh.maKH" +
                                                 " AND loaiphong.maKS = ks.maKS"
                                                 " AND datphong.maDP = {0}",
                                              maDP);

                String query = String.Format("select * from {0} where tenDangNhap = {1}",
                                                               TABLE_NAME_KHACHHANG,
                                                               "'" + tenDangNhap + "'");
                SqlCommand cmd = new SqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhachHang kh = new KhachHang();
                    kh.MaKH = (int)reader["maKH"];
                    kh.HoTen = (string)reader["hoTen"];
                    kh.TenDangNhap = (string)reader["tenDangNhap"];
                    kh.SoCMND = (string)reader["soCMND"];
                    kh.DiaChi = (string)reader["diaChi"];
                    kh.SoDienThoai = (string)reader["soDienThoai"];
                    kh.MoTa = (string)reader["moTa"];
                    kh.Email = (string)reader["email"];
                    return kh;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new ThemKhachHangException(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
