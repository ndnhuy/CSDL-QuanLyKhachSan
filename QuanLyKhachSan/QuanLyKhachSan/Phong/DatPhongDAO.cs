using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Phong
{

    public class DatPhongDAO
    {
        private const String SP_KHACH_HANG_DAT_PHONG = "sp_khachHangDatPhong";
        // Lấy connection string từ file App.config
        private String connectionString = ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;
        private TrangThaiPhongDAO trangthaiphongDAO = new TrangThaiPhongDAO();

        public int pickAnyAvailableRoom(int maLoaiPhong, DateTime ngayBatDau)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

                String query = "select maPhong from Phong " +
                               "where loaiPhong = {0} " +
                               "and maPhong not in (select maPhong from TrangThaiPhong " +
                               "                    where [TrangThaiPhong].maPhong = maPhong " +
                               "                    and [TrangThaiPhong].ngay = '{1}' " +
                               "                    and [TrangThaiPhong].tinhTrang = N'đang sử dụng')";



                SqlCommand cmd = new SqlCommand(String.Format(query, maLoaiPhong, ngayBatDau.ToString("yyyy-MM-dd")),
                                                conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return ((int)reader["maPhong"]);
                }

                return -1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi xảy ra khi lấy phòng trống");
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        public void updateTrangThaiPhong(int maPhong, DateTime ngay, String tinhTrang)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();

                String query = "";
                
                if (trangthaiphongDAO.exist(maPhong, ngay))
                {
                    // update
                    query = String.Format("update TrangThaiPhong set tinhTrang = N'{0}' where maPhong = {1} and ngay = '{2}'",
                                          tinhTrang,
                                          maPhong,
                                          ngay.ToString("yyyy-MM-dd"));
                }
                else
                {
                    // create
                    query = String.Format("insert into TrangThaiPhong(maPhong, ngay, tinhTrang) values ({0}, '{1}', N'{2}')",
                                         maPhong,
                                         ngay.ToString("yyyy-MM-dd"),
                                         tinhTrang);
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("DatPhongDAO: Có lỗi xảy ra khi cập nhật trạng thái phòng");
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

        public bool hasAtLeastOneAvailableRoom(int maLoaiPhong)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

                String query = "select slTrong from LoaiPhong where maLoaiPhong = " + maLoaiPhong;
                SqlCommand cmd = new SqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return ((int)reader["slTrong"]) > 0;
                }

                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi xảy ra khi kiếm tra phòng trống cho loại phòng");
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        public void decreaseNumberOfAvailableRooms(int maLoaiPhong)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                String query = "update LoaiPhong set slTrong = slTrong - 1 where maLoaiPhong = " + maLoaiPhong;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi xảy ra khi giảm số lượng trống của loại phòng");
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

        public void datPhong(ThongTinDatPhong datphong)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SP_KHACH_HANG_DAT_PHONG, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@maLoaiPhong", SqlDbType.Int).Value = datphong.MaLoaiPhong;
                command.Parameters.Add("@maKH", SqlDbType.Int).Value = datphong.MaKH;
                command.Parameters.Add("@ngayBatDau", SqlDbType.Date).Value = datphong.NgayBatDau;
                command.Parameters.Add("@ngayTraPhong", SqlDbType.Date).Value = datphong.NgayTraPhong;
                command.Parameters.Add("@ngayDat", SqlDbType.Date).Value = datphong.NgayDat;
                command.Parameters.Add("@donGia", SqlDbType.Int).Value = datphong.DonGia;
                command.Parameters.Add("@moTa", SqlDbType.NVarChar).Value = datphong.MoTa;
                command.Parameters.Add("@tinhTrang", SqlDbType.NVarChar).Value = datphong.TinhTrang;

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi xảy ra khi đặt phòng");
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
    }
}
