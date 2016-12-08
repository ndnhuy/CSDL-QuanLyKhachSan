using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Phong
{
    public class ThongTinDatPhong
    {
        public int MaDP { get; set; }
        public int MaLoaiPhong { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public DateTime NgayDat { get; set; }
        public int DonGia { get; set; }
        public String MoTa { get; set; }
        public String TinhTrang { get; set; }
    }
}
