--select Year(ngayThanhToan) as Nam, Month(ngayThanhToan) as Thang, Day(ngayThanhToan) as Ngay, Sum(tongTien) Tong
--from HoaDon
--group by year(ngayThanhToan), month(ngayThanhToan), day(ngayThanhToan)
--order by year(ngayThanhToan), month(ngayThanhToan), day(ngayThanhToan)

--select KhachSan.tenKS, LoaiPhong.tenLoaiPhong, LoaiPhong.slTrong, KhachSan.thanhPho, KhachSan.soSao
--from LoaiPhong
--inner join KhachSan
--on LoaiPhong.maKS = KhachSan.maKS
--order by KhachSan.thanhPho, KhachSan.soSao

select * from LoaiPhong

select count(*) as sltrong from Phong
where Phong.loaiPhong = 1
and Phong.maPhong not in (select TrangThaiPhong.maPhong from TrangThaiPhong
						  where TrangThaiPhong.ngay = '2016-12-18'
						  and TrangThaiPhong.tinhTrang = 'đang sử dụng')


update LoaiPhong set LoaiPhong.slTrong = (select count(*) as sltrong from Phong
											where Phong.maPhong not in (select TrangThaiPhong.maPhong from TrangThaiPhong
																	  where TrangThaiPhong.ngay = '2016-12-18'
																	  and TrangThaiPhong.tinhTrang = N'đang sử dụng'))

select * from TrangThaiPhong
select * from LoaiPhong
select * from Phong

select LoaiPhong.maLoaiPhong, LoaiPhong.tenLoaiPhong, KhachSan.tenKS, LoaiPhong.donGia 
                            from LoaiPhong
                            inner join KhachSan
                            on LoaiPhong.maKS = KhachSan.maKS
                            where KhachSan.maKS = 2
                            and exists (select maPhong from Phong
			                            where Phong.loaiPhong = LoaiPhong.maLoaiPhong 
			                            and maPhong not in (select maPhong from TrangThaiPhong
									                        where TrangThaiPhong.maPhong = maPhong
									                                and TrangThaiPhong.ngay >= '2016-12-18'
									                                and TrangThaiPhong.ngay < '2016-12-23'
									                                and TrangThaiPhong.tinhTrang = N'đang sử dụng'))



select maPhong from Phong
			                            where Phong.loaiPhong = 3
			                            and maPhong not in (select maPhong from TrangThaiPhong
									                        where TrangThaiPhong.maPhong = maPhong
									                                and TrangThaiPhong.ngay >= '2016-12-18'
									                                and TrangThaiPhong.ngay < '2016-12-23'
									                                and TrangThaiPhong.tinhTrang = N'đang sử dụng')