
use QuanLyKhachSan
go

-- KHÁCH HÀNG TABLE
if object_id('HoaDon', 'U') is not null
drop table HoaDon;
if object_id('DatPhong', 'U') is not null
drop table DatPhong;
if object_id('TrangThaiPhong', 'U') is not null
drop table TrangThaiPhong;
if object_id('Phong', 'U') is not null
drop table Phong;
if object_id('LoaiPhong', 'U') is not null
drop table LoaiPhong;
if object_id('KhachHang', 'U') is not null
drop table KhachHang;

create table KhachHang (
	maKH int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	hoTen nvarchar(50) NOT NULL,
	tenDangNhap nvarchar(30) NOT NULL,
	matKhau nvarchar(30) NOT NULL,
	soCMND varchar(10) NOT NULL,
	diaChi nvarchar(50),
	soDienThoai nvarchar(30),
	moTa nvarchar(100),
	email nvarchar(30)
)

-- KHÁCH SẠN TABLE
if object_id('KhachSan', 'U') is not null
drop table KhachSan;

create table KhachSan (
	maKS int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenKS nvarchar(50) NOT NULL,
	soSao int NOT NULL,
	soNha varchar (10) NOT NULL,
	duong nvarchar(50) NOT NULL,
	quan nvarchar(20) NOT NULL,
	thanhPho nvarchar(20) NOT NULL,
	giaTB int NOT NULL,
	moTa nvarchar(100) NOT NULL,
)

-- LOẠI PHÒNG TABLE
if object_id('LoaiPhong', 'U') is not null
drop table LoaiPhong;

create table LoaiPhong (
	maLoaiPhong int IDENTITY(1,1) PRIMARY KEY,
	tenLoaiPhong nvarchar(50) NOT NULL,
	maKS int,
	donGia int,
	moTa nvarchar(100) NOT NULL,
	slTrong int NOT NULL
)

alter table LoaiPhong 
add constraint FK_LoaiPhong_KhachSan foreign key (maKS) 
references KhachSan (maKS);

-- PHÒNG TABLE
if object_id('Phong', 'U') is not null
drop table Phong;

create table Phong (
	maPhong int IDENTITY(1,1) PRIMARY KEY,
	loaiPhong int,
	soPhong int
)

alter table Phong 
add constraint FK_Phong_LoaiPhong foreign key (loaiPhong) 
references LoaiPhong (maLoaiPhong);

-- TRẠNG THÁI PHÒNG TABLE
if object_id('TrangThaiPhong', 'U') is not null
drop table TrangThaiPhong;

create table TrangThaiPhong (
	maPhong int,
	ngay date NOT NULL,
	tinhTrang nvarchar(30) NOT NULL,
	constraint pk_TrangThaiPhongID primary key (maPhong, ngay)
)

alter table TrangThaiPhong
add constraint FK_TrangThaiPhong_Phong foreign key (maPhong) 
references Phong (maPhong);

-- ĐẶT PHÒNG TABLE
if object_id('DatPhong', 'U') is not null
drop table DatPhong;

create table DatPhong (
	maDP int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	maLoaiPhong int,
	maKH int,
	ngayBatDau date NOT NULL,
	ngayTraPhong date NOT NULL,
	ngayDat date NOT NULL,
	donGia int NOT NULL,
	moTa nvarchar(100) NOT NULL,
	tinhTrang nvarchar(30) NOT NULL
)
alter table DatPhong 
add constraint FK_DatPhong_LoaiPhong foreign key (maLoaiPhong) 
references LoaiPhong (maLoaiPhong);

alter table DatPhong 
add constraint FK_DatPhong_KhachHang foreign key (maKH) 
references KhachHang (maKH);

-- HÓA ĐƠN TABLE
if object_id('HoaDon', 'U') is not null
drop table HoaDon;
create table HoaDon (
	maHD int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ngayThanhToan date NOT NULL,
	tongTien bigint NOT NULL,
	maDP int 
)
alter table HoaDon 
add constraint FK_HoaDon_DatPhong foreign key (maDP) 
references DatPhong (maDP);

--Stored Procedured

--Thêm khách hàng
if object_id('sp_themKhachHang') is not null
	drop procedure sp_themKhachHang;

go
	create procedure sp_themKhachHang
		@hoTen nvarchar(50),
		@tenDangNhap nvarchar(30),
		@matKhau nvarchar(30),
		@soCMND varchar(10),
		@diaChi nvarchar(50),
		@soDienThoai nvarchar(30),
		@moTa nvarchar(100),
		@email nvarchar(30)
as
	insert into KhachHang(  hoTen, 
							tenDangNhap, 
							matKhau, 
							soCMND, 
							diaChi, 
							soDienThoai,
							moTa, email) 
	values (
		@hoTen, 
		@tenDangNhap, 
		@matKhau, 
		@soCMND, 
		@diaChi, 
		@soDienThoai,
		@moTa,
		@email
	)

go

-- Kiểm tra tên đăng nhập và mật khẩu
if object_id('sp_dangNhap') is not null
	drop procedure sp_dangNhap;
go

	create procedure sp_dangNhap
		@maKH int output,
		@tenDangNhap nvarchar(30),
		@matKhau nvarchar(30)

as

	select @maKH = kh.maKH 
	from KhachHang kh
	where kh.tenDangNhap = @tenDangNhap AND kh.matKhau = @matKhau

go

-- Kiểm tra tên đăng nhập đã tồn tại chưa
if object_id('sp_kiemTraTenDangNhap') is not null
	drop procedure sp_kiemTraTenDangNhap;
go

	create procedure sp_kiemTraTenDangNhap
		@maKH int output,
		@tenDangNhap nvarchar(30)

as

	select @maKH = kh.maKH 
	from KhachHang kh
	where kh.tenDangNhap = @tenDangNhap

go
-- Đặt phòng
if object_id('sp_khachHangDatPhong') is not null
	drop procedure sp_khachHangDatPhong;
go

	create procedure sp_khachHangDatPhong
		@maLoaiPhong int,
		@maKH int,
		@ngayBatDau date,
		@ngayTraPhong date,
		@ngayDat date,
		@donGia int,
		@moTa nvarchar(100),
		@tinhTrang nvarchar(30)
as
	insert into DatPhong(	
							maLoaiPhong,
							maKH,
							ngayBatDau,
							ngayTraPhong,
							ngayDat,
							donGia,
							moTa,
							tinhTrang
						) 
	values (
		@maLoaiPhong,
		@maKH,
		@ngayBatDau,
		@ngayTraPhong,
		@ngayDat,
		@donGia,
		@moTa,
		@tinhTrang
	)

go

-- Lập hóa đơn
if object_id('sp_lapHoaDon') is not null
	drop procedure sp_lapHoaDon;
go

	create procedure sp_lapHoaDon
		@ngayThanhToan date,
		@tongTien bigint, 
		@maDP int
as
	insert into HoaDon(	
							ngayThanhToan,
							tongTien,
							maDP
						) 
	values (
		@ngayThanhToan,
		@tongTien,
		@maDP
	)

go

-- INDEX

-- index KhachHang (tenDangNhap, matKhau)
if exists (select name from sys.indexes
		   where name = N'IX_KhachHang_tenDangNhap_matKhau')
	drop index IX_KhachHang_tenDangNhap_matKhau on KhachHang;

go

create unique index IX_KhachHang_tenDangNhap_matKhau on KhachHang (tenDangNhap, matKhau)

go

-- index KhachHang (soCMND)
if exists (select name from sys.indexes
		   where name = N'IX_KhachHang_soCMND')
	drop index IX_KhachHang_soCMND on KhachHang;

go

create index IX_KhachHang_soCMND on KhachHang (soCMND)

go

-- index KhachSan (soSao, thanhPho) 
if exists (select name from sys.indexes
		   where name = N'IX_KhachSan_soSao_thanhPho')
	drop index IX_KhachSan_soSao_thanhPho on KhachSan;

go

create index IX_KhachSan_soSao_thanhPho on KhachSan (soSao, thanhPho) 

go

-- index KhachSan (giaTB, thanhPho)
if exists (select name from sys.indexes
		   where name = N'IX_KhachSan_giaTB_thanhPho')
	drop index IX_KhachSan_giaTB_thanhPho on KhachSan;

go

create index IX_KhachSan_giaTB_thanhPho on KhachSan (giaTB, thanhPho)

go

-- index KhachSan (thanhPho)
if exists (select name from sys.indexes
		   where name = N'IX_KhachSan_thanhPho')
	drop index IX_KhachSan_thanhPho on KhachSan;

go

create index IX_KhachSan_thanhPho on KhachSan (thanhPho)

go
-- index LoaiPhong (maKS)
if exists (select name from sys.indexes
		   where name = N'IX_LoaiPhong_maKS')
	drop index IX_LoaiPhong_maKS on LoaiPhong;

go

create index IX_LoaiPhong_maKS on LoaiPhong (maKS)

go

-- index LoaiPhong (maKS, donGia)
if exists (select name from sys.indexes
		   where name = N'IX_LoaiPhong_maKS_donGia')
	drop index IX_LoaiPhong_maKS_donGia on LoaiPhong;

go

create index IX_LoaiPhong_maKS_donGia on LoaiPhong (maKS, donGia)

go

-- index Phong (loaiPhong)
if exists (select name from sys.indexes
		   where name = N'IX_Phong_loaiPhong')
	drop index IX_Phong_loaiPhong on Phong;

go

create index IX_Phong_loaiPhong on Phong (loaiPhong)

go

-- index TrangThaiPhong (maPhong)
if exists (select name from sys.indexes
		   where name = N'IX_TrangThaiPhong_maPhong')
	drop index IX_TrangThaiPhong_maPhong on TrangThaiPhong;

go

create index IX_TrangThaiPhong_maPhong on TrangThaiPhong (maPhong)

go

-- index DatPhong (maLoaiPhong, maKH)
if exists (select name from sys.indexes
		   where name = N'IX_DatPhong_maLoaiPhong_maKH')
	drop index IX_DatPhong_maLoaiPhong_maKH on DatPhong;

go

create index IX_DatPhong_maLoaiPhong_maKH on DatPhong (maLoaiPhong, maKH)

go

-- index HoaDon (maDP)
if exists (select name from sys.indexes
		   where name = N'IX_HoaDon_maDP')
	drop index IX_HoaDon_maDP on HoaDon;

go

create index IX_HoaDon_maDP on HoaDon (maDP)

go

-- index HoaDon (ngayThanhToan, tongTien)
if exists (select name from sys.indexes
		   where name = N'IX_HoaDon_ngayThanhToan_tongTien')
	drop index IX_HoaDon_ngayThanhToan_tongTien on HoaDon;

go

create index IX_HoaDon_ngayThanhToan_tongTien on HoaDon (ngayThanhToan, tongTien)

go

-- TRIGGERS
create trigger update_sltrong on LoaiPhong
for select
as
begin
	
end