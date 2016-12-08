select p.soPhong, lp.tenLoaiPhong, ks.tenKS, lp.donGia, ttp.tinhTrang from KhachSan ks, Phong p, LoaiPhong lp, TrangThaiPhong ttp
where p.loaiPhong = lp.maLoaiPhong
AND ks.maKS = lp.maKS
AND p.maPhong = ttp.maPhong
AND ttp.tinhTrang = N'Còn trống'

