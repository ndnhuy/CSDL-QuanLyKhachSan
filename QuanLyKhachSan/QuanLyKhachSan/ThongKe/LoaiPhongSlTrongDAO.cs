using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ThongKe
{
    public class LoaiPhongSlTrongDAO
    {
        // Lấy connection string từ file App.config
        private String connectionString = ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;
        
        public int countNumberOfAvailableRooms(int maLoaiPhong)
        {
            return 0;
        }



        public void updateAvailableRoomCountForEachLoaiPhong()
        {
            //SqlConnection conn = new SqlConnection(connectionString);
            //SqlDataReader reader = null;
            //try
            //{
            //    conn.Open();

            //    SqlCommand cmd = new SqlCommand(query, conn);

            //    reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
                   
            //    }

            //    return null;
            //}
            //catch (SqlException ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    if (reader != null)
            //    {
            //        reader.Close();
            //    }
            //    if (conn != null)
            //    {
            //        conn.Close();
            //    }
            //}
        }
    }
}
