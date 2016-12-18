use QuanLyKhachSan
go
-- insert data
USE [QuanLyKhachSan]
GO

INSERT INTO [dbo].[KhachHang]
           ([hoTen]
           ,[tenDangNhap]
           ,[matKhau]
           ,[soCMND]
           ,[diaChi]
           ,[soDienThoai]
           ,[moTa]
           ,[email])
     VALUES
           (N'Nhật Huy'
           ,'admin'
           ,'admin'
           ,'123456789'
           ,''
           ,''
           ,''
           ,'')
GO




INSERT INTO [dbo].[KhachSan]
           ([tenKS]
           ,[soSao]
           ,[soNha]
           ,[duong]
           ,[quan]
           ,[thanhPho]
           ,[giaTB]
           ,[moTa])
     VALUES
           (N'Trường Thắng'
           , 3
           , '111/8'
           , N'Phạm Văn Chiêu'
           , N'Gò Vấp'
           , N'TPHCM'
           , 2000000
           , N'Khách sạn đẹp nhất thế giới')

INSERT INTO [dbo].[KhachSan]
           ([tenKS]
           ,[soSao]
           ,[soNha]
           ,[duong]
           ,[quan]
           ,[thanhPho]
           ,[giaTB]
           ,[moTa])
     VALUES
           (N'Trường Tồn'
           , 2
           , N'111/8'
           , N'Phạm Văn Chiêu'
           , N'Gò Vấp'
           , N'TPHCM'
           , 2000000
           , N'Khách sạn đẹp nhất thế giới')

USE [QuanLyKhachSan]
GO

INSERT INTO [dbo].[LoaiPhong]
           ([tenLoaiPhong]
           ,[maKS]
           ,[donGia]
           ,[moTa]
           ,[slTrong])
     VALUES (
           N'Bình thường'
           , 1
           , 500000
           , N'Khách sạn không nên ở'
           , 0)
GO

INSERT INTO [dbo].[LoaiPhong]
           ([tenLoaiPhong]
           ,[maKS]
           ,[donGia]
           ,[moTa]
           ,[slTrong])
     VALUES (
           N'VIP'
           , 1
           , 2000000
           , N'Khách sạn của VIP'
           , 0)
GO

INSERT INTO [dbo].[LoaiPhong]
           ([tenLoaiPhong]
           ,[maKS]
           ,[donGia]
           ,[moTa]
           ,[slTrong])
     VALUES (
           N'Bình thường'
           , 2
           , 500000
           , N'Khách sạn không nên ở'
           , 0)
GO

INSERT INTO [dbo].[LoaiPhong]
           ([tenLoaiPhong]
           ,[maKS]
           ,[donGia]
           ,[moTa]
           ,[slTrong])
     VALUES (
           N'VIP'
           , 2
           , 2000000
           , N'Khách sạn của VIP'
           , 0)
GO

USE [QuanLyKhachSan]
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (1
           ,1)
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (2
           ,2)
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (2
           ,3)
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (2
           ,4)
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (1
           ,5)
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (3
           ,6)
GO

INSERT INTO [dbo].[Phong]
           ([loaiPhong]
           ,[soPhong])
     VALUES
           (4
           ,7)
GO

--USE [QuanLyKhachSan]
--GO

--INSERT INTO [dbo].[TrangThaiPhong]
--           ([maPhong]
--		   ,[ngay]
--           ,[tinhTrang])
--     VALUES
--           (1
--		   ,GETDATE(),
--           N'Còn trống')
--GO

--INSERT INTO [dbo].[TrangThaiPhong]
--           ([maPhong]
--		   ,[ngay]
--           ,[tinhTrang])
--     VALUES
--           (2
--		   ,GETDATE(),
--           N'Còn trống')
--GO

--INSERT INTO [dbo].[TrangThaiPhong]
--           ([maPhong]
--		   ,[ngay]
--           ,[tinhTrang])
--     VALUES
--           (3
--		   ,GETDATE(),
--           N'Còn trống')
--GO

--INSERT INTO [dbo].[TrangThaiPhong]
--           ([maPhong]
--		   ,[ngay]
--           ,[tinhTrang])
--     VALUES
--           (4
--		   ,GETDATE(),
--           N'Còn trống')
--GO

--INSERT INTO [dbo].[TrangThaiPhong]
--           ([maPhong]
--		   ,[ngay]
--           ,[tinhTrang])
--     VALUES
--           (5
--		   ,GETDATE(),
--           N'Còn trống')
GO

-- INSERT KHÁCH HÀNG
USE [QuanLyKhachSan]
GO

INSERT INTO [dbo].[KhachHang]
           ([hoTen]
           ,[tenDangNhap]
           ,[matKhau]
           ,[soCMND]
           ,[diaChi]
           ,[soDienThoai]
           ,[moTa]
           ,[email])
     VALUES
           (N'Songoku'
           ,'songoku'
           ,'123'
           ,'123456788'
           ,'Trái đất'
           ,'09012121454'
           ,'Người giết Cell'
           ,'songoku@gmail.com')
GO






