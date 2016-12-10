using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.KhachHang;
using System.Configuration;
using QuanLyKhachSan.KhachSan;
using QuanLyKhachSan.Phong;
using QuanLyKhachSan.HoaDon;

namespace QuanLyKhachSan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //KhachHang.KhachHang kh = new KhachHang.KhachHang();
            //kh.HoTen = "Nguyen Van A";
            //kh.TenDangNhap = "username";
            //kh.MatKhau = "password";
            //kh.SoCMND = "123456";
            //kh.DiaChi = "go vap, pham van chieu, ho chi minh city";
            //kh.SoDienThoai = "01627873740";
            //kh.MoTa = "Mo ta ne";
            //kh.Email = "ndnhuy2504@gmail.com";

            //KhachHangDAO dao = new KhachHangDAO();
            //dao.add(kh);

            //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            //SqlDataReader reader = null;

            //try
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("sp_layKhachHang", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    SqlParameter paramMaKH = cmd.Parameters.Add("@maKH", SqlDbType.Int);
            //    SqlParameter paramHoTen = cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 50);

            //    paramMaKH.Value = 1;
            //    paramHoTen.Direction = ParameterDirection.Output;

            //    cmd.ExecuteNonQuery();

            //    Console.WriteLine("Ho ten: " + paramHoTen.Value);
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
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhapUI());
        }
    }
}
