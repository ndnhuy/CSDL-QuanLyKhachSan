using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.HoaDon
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public long TongTien { get; set; }
        public String TenKhachSan { get; set; }
        public String TenKhachHang { get; set; }
        public String TenLoaiPhong { get; set; }
        public int DonGia { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public DateTime NgayDat { get; set; }
    }
}
