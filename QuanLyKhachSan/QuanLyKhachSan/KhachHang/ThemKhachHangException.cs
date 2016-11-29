using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.KhachHang
{
    public class ThemKhachHangException : Exception
    {
        public ThemKhachHangException() { }
        public ThemKhachHangException(string message) : base(message) { }
        public ThemKhachHangException(string message, Exception inner) : base(message, inner) { }
    }
}
