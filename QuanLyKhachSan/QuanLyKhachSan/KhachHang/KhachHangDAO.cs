using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.KhachHang
{
    public class KhachHangDAO
    {
        private const String SP_THEM_KHACH_HANG = "sp_themKhachHang";
        private const String SP_KIEM_TRA_TON_TAI = "sp_kiemtraKhachHangTonTai";

        public void add(KhachHang khachHang)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            
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
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyKhachSan;Integrated Security=True");

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SP_KIEM_TRA_TON_TAI, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar).Value = tenDangNhap;
                command.Parameters.Add("@matKhau", SqlDbType.NVarChar).Value = matKhau;
                command.Parameters.Add("@maKH", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return true;
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
