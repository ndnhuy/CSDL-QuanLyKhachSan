using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.KhachHang
{
    public class KhachHangDAO
    {
        // Lấy connection string từ file App.config
        private String connectionString = ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;

        // Tên của các stored procedured
        private const String SP_THEM_KHACH_HANG = "sp_themKhachHang";
        private const String SP_KIEM_TRA_TON_TAI = "sp_kiemtraKhachHangTonTai";
        private const String TABLE_NAME_KHACHHANG = "KhachHang";

        public KhachHang getKhachHang(string tenDangNhap)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                conn.Open();

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

        public void add(KhachHang khachHang)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SP_THEM_KHACH_HANG, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@hoTen", SqlDbType.NVarChar).Value = khachHang.HoTen;
                command.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar).Value = khachHang.TenDangNhap;
                command.Parameters.Add("@matKhau", SqlDbType.NVarChar).Value = khachHang.MatKhau;
                command.Parameters.Add("@soCMND", SqlDbType.NVarChar).Value = khachHang.SoCMND; 
                command.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = khachHang.DiaChi; 
                command.Parameters.Add("@moTa", SqlDbType.NVarChar).Value = khachHang.MoTa;
                command.Parameters.Add("@soDienThoai", SqlDbType.NVarChar).Value = khachHang.SoDienThoai;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = khachHang.Email;

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ThemKhachHangException(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool exist(String tenDangNhap, String matKhau)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SP_KIEM_TRA_TON_TAI, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar).Value = tenDangNhap;
                command.Parameters.Add("@matKhau", SqlDbType.NVarChar).Value = matKhau;
                SqlParameter maKH = command.Parameters.Add("@maKH", SqlDbType.Int);
                maKH.Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return maKH.Value != DBNull.Value;
            }
            catch (SqlException ex)
            {
                throw new ThemKhachHangException(ex.Message);
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
