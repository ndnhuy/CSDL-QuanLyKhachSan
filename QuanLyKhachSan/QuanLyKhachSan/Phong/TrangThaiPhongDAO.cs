using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Phong
{
    public class TrangThaiPhongDAO
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;

        public bool exist(int maPhong, DateTime ngay)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

                String query = "select maPhong from TrangThaiPhong " +
                               "where [TrangThaiPhong].maPhong = " + maPhong + " " +
                               "and [TrangThaiPhong].ngay = '" + ngay.ToString("yyyy-MM-dd") + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return true;
                }

                return false;
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

        public void createTrangThaiPhong(int maPhong, DateTime ngay, String tinhTrang)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();

                String query = "insert into TrangThaiPhong(maPhong, ngay, tinhTrang) values ({0}, {1}, {2})";



                SqlCommand cmd = new SqlCommand(String.Format(query, maPhong, ngay.ToString("yyyy-MM-dd"), tinhTrang),
                                                conn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Có lỗi xảy ra khi cập nhật trạng thái phòng");
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
