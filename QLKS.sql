

-- KHÁCH HÀNG TABLE
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
	maLoaiPhong int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tenLoaiPhong nvarchar(50) NOT NULL,
	maKS int,
	donGia int NOT NULL,
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
	maPhong int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	loaiPhong int NOT NULL,
	soPhong int NOT NULL
)

alter table Phong 
add constraint FK_Phong_LoaiPhong foreign key (loaiPhong) 
references LoaiPhong (maLoaiPhong);

-- TRẠNG THÁI PHÒNG TABLE
if object_id('TrangThaiPhong', 'U') is not null
drop table TrangThaiPhong;

create table TrangThaiPhong (
	maPhong int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ngay date NOT NULL,
	tinhTrang nvarchar(30) NOT NULL
)
alter table TrangThaiPhong 
add constraint FK_TrangThaiPhong_Phong foreign key (maPhong) 
references Phong (maPhong);

-- ĐẶT PHÒNG TABLE
if object_id('DatPhong', 'U') is not null
drop table DatPhong;

create table DatPhong (
	maDP int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	maPhong int,
	maKH int,
	ngayBatDau date NOT NULL,
	ngayTraPhong date NOT NULL,
	ngayDat date NOT NULL,
	donGia int NOT NULL,
	moTa nvarchar(100) NOT NULL,
	tinhTrang nvarchar(30) NOT NULL
)
alter table DatPhong 
add constraint FK_DatPhong_Phong foreign key (maPhong) 
references Phong (maPhong);

alter table DatPhong 
add constraint FK_DatPhong_KhachHang foreign key (maKH) 
references KhachHang (maKH);

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

-- Kiểm tra khách hàng có tồn tại hay không
if object_id('sp_kiemtraKhachHangTonTai') is not null
	drop procedure sp_kiemtraKhachHangTonTai;
go

	create procedure sp_kiemtraKhachHangTonTai
		@maKH int output,
		@tenDangNhap nvarchar(30),
		@matKhau nvarchar(30)

as

	select @maKH = kh.maKH 
	from KhachHang kh
	where kh.tenDangNhap = @tenDangNhap AND kh.matKhau = @matKhau
