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


        public String buildQueryStringFromSearchArgs(int maDP, int maLoaiPhong, String CMND, String tenDangNhap)
        {
            String maDatPhongCondition = maDP == 0 ? "1 = 1" :
                                         String.Format("DatPhong.maDP = {0}", maDP);
            String maLoaiPhongCondition = maLoaiPhong == 0 ? "1 = 1" :
                                                     String.Format("DatPhong.maLoaiPhong = {0}", maLoaiPhong);
            String tenDangNhapCondition = tenDangNhap == "" ? "1 = 1" :
                                                     String.Format("KhachHang.tenDangNhap = '{0}'", tenDangNhap);

            String soCMNDCondition = CMND == "" ? "1 = 1" :
                                                     String.Format("KhachHang.soCMND = '{0}'", CMND);

            String query = @"select DatPhong.maDP, DatPhong.ngayBatDau, DatPhong.ngayDat, DatPhong.ngayTraPhong,
		                                            LoaiPhong.maLoaiPhong, LoaiPhong.tenLoaiPhong, LoaiPhong.donGia,
		                                            KhachSan.tenKS,
		                                            KhachHang.hoTen,
                                                    KhachHang.maKH
                                            from DatPhong, KhachSan, KhachHang, LoaiPhong
                                            where DatPhong.maLoaiPhong = LoaiPhong.maLoaiPhong
                                            AND DatPhong.maKH = KhachHang.maKH
                                            AND LoaiPhong.maKS = KhachSan.maKS
                                            AND {0}
                                            AND {1} 
                                            AND DatPhong.maKH in (select maKH from KhachHang
                                                                  where {2}
                                                                  and {3})";

            return String.Format(query, maDatPhongCondition,
                                       maLoaiPhongCondition,
                                       tenDangNhapCondition,
                                       soCMNDCondition);
        }


        public String getQueryStringOfAllDatPhong()
        {
            return @"select DatPhong.maDP, DatPhong.ngayBatDau, DatPhong.ngayDat, 
		                        LoaiPhong_KhachSan.maLoaiPhong, LoaiPhong_KhachSan.tenLoaiPhong, LoaiPhong_KhachSan.donGia, LoaiPhong_KhachSan.tenKS,
		                        KhachHang.hoTen
                        from DatPhong
                        inner join (
	                                    select LoaiPhong.maLoaiPhong, LoaiPhong.tenLoaiPhong, LoaiPhong.donGia, KhachSan.tenKS
	                                    from LoaiPhong
	                                    inner join KhachSan
	                                    on LoaiPhong.maKS = KhachSan.maKS
                                    ) LoaiPhong_KhachSan
	                        on DatPhong.maLoaiPhong = LoaiPhong_KhachSan.maLoaiPhong
                        inner join KhachHang
	                        on DatPhong.maKH = KhachHang.maKH";
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
                throw ex;
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

        public HoaDon lapHoaDon(int maDP, int maLoaiPhong, String CMND, String tenDangNhap)
        {
            String maDatPhongCondition = maDP == 0 ? "1 = 1" : 
                                                     String.Format("DatPhong.maDP = {0}", maDP);
            String maLoaiPhongCondition = maLoaiPhong == 0 ? "1 = 1" : 
                                                     String.Format("DatPhong.maLoaiPhong = {0}", maLoaiPhong);
            String tenDangNhapCondition = tenDangNhap == "" ? "1 = 1" :
                                                     String.Format("KhachHang.tenDangNhap = '{0}'", tenDangNhap);

            String soCMNDCondition = CMND == "" ? "1 = 1" :
                                                     String.Format("KhachHang.soCMND = '{0}'", CMND);


            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

                String query = @"select DatPhong.maDP, DatPhong.ngayBatDau, DatPhong.ngayDat, DatPhong.ngayTraPhong,
		                                            LoaiPhong.maLoaiPhong, LoaiPhong.tenLoaiPhong, LoaiPhong.donGia,
		                                            KhachSan.tenKS,
		                                            KhachHang.hoTen
                                            from DatPhong, KhachSan, KhachHang, LoaiPhong
                                            where DatPhong.maLoaiPhong = LoaiPhong.maLoaiPhong
                                            AND DatPhong.maKH = KhachHang.maKH
                                            AND LoaiPhong.maKS = KhachSan.maKS
                                            AND {0}
                                            AND {1} 
                                            AND DatPhong.maKH in (select maKH from KhachHang
                                                                  where {2}
                                                                  and {3})";


                SqlCommand cmd = new SqlCommand(String.Format(query, maDatPhongCondition, 
                                                                     maLoaiPhongCondition, 
                                                                     tenDangNhapCondition, 
                                                                     soCMNDCondition), 
                                                conn);

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
