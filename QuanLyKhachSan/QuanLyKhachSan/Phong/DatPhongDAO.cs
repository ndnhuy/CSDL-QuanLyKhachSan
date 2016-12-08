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
