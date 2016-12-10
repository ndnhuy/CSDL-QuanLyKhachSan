using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        private const String SP_LAP_HOA_DON = "sp_lapHoaDon";


        // Lập hóa 
        public String getQueryStringOfAllDatPhong()
        {
            return "select datphong.maDP, ks.tenKS, kh.hoTen, loaiphong.tenLoaiPhong, loaiphong.donGia, datphong.ngayBatDau, datphong.ngayTraPhong, datphong.ngayDat" +
                                                 " from DatPhong datphong, LoaiPhong loaiphong, KhachSan ks, KhachHang kh where" +
                                                 " datphong.maLoaiPhong = loaiphong.maLoaiPhong" +
                                                 " AND datphong.maKH = kh.maKH" +
                                                 " AND loaiphong.maKS = ks.maKS";
        }

        public void saveHoaDon(DateTime ngayThanhToan, long tongTien, int maDP)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SP_LAP_HOA_DON, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ngayThanhToan", SqlDbType.DateTime).Value = ngayThanhToan;
                command.Parameters.Add("@tongTien", SqlDbType.BigInt).Value = tongTien;
                command.Parameters.Add("@maDP", SqlDbType.Int).Value = maDP;
                
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Xảy ra lỗi khi lưu hóa đơn");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public HoaDon getHoaDon(int maHD)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

                String query = String.Format("select hd.ngayThanhToan, hd.tongTien, ks.tenKS, kh.hoTen, loaiphong.tenLoaiPhong, loaiphong.donGia, datphong.ngayBatDau, datphong.ngayTraPhong, datphong.ngayDat" +
                                                 " from DatPhong datphong, LoaiPhong loaiphong, KhachSan ks, KhachHang kh, HoaDon hd where" +
                                                 " datphong.maLoaiPhong = loaiphong.maLoaiPhong" +
                                                 " AND datphong.maKH = kh.maKH" +
                                                 " AND loaiphong.maKS = ks.maKS" +
                                                 " AND datphong.maDP = hd.maDP" +
                                                 " AND hd.maHD = {0}",
                                              maHD);


                SqlCommand cmd = new SqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hd = new HoaDon();
                    hd.TenKhachSan = (String)reader["tenKS"];
                    hd.TenKhachHang = (String)reader["hoTen"];
                    hd.TenLoaiPhong = (String)reader["tenLoaiPhong"];
                    hd.DonGia = (int)reader["donGia"];
                    hd.NgayBatDau = (DateTime)reader["ngayBatDau"];
                    hd.NgayTraPhong = (DateTime)reader["ngayTraPhong"];
                    hd.NgayDat = (DateTime)reader["ngayDat"];

                    hd.NgayThanhToan = (DateTime)reader["ngayThanhToan"];
                    hd.TongTien = (long)reader["tongTien"];

                    return hd;
                }

                return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi khi xuất hóa đơn");
                throw ex;
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
                                                 " AND loaiphong.maKS = ks.maKS" +
                                                 " AND datphong.maDP = {0}",
                                              maDP);

            
                SqlCommand cmd = new SqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hd = new HoaDon();
                    hd.TenKhachSan = (String)reader["tenKS"];
                    hd.TenKhachHang = (String)reader["hoTen"];
                    hd.TenLoaiPhong = (String)reader["tenLoaiPhong"];
                    hd.DonGia = (int)reader["donGia"];
                    hd.NgayBatDau = (DateTime)reader["ngayBatDau"];
                    hd.NgayTraPhong = (DateTime)reader["ngayTraPhong"];
                    hd.NgayDat = (DateTime)reader["ngayDat"];

                    hd.NgayThanhToan = DateTime.Now;
                    hd.TongTien = (hd.NgayTraPhong - hd.NgayBatDau).Days * hd.DonGia;

                    return hd;
                }

                return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi khi xuất hóa đơn");
                throw ex;
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
