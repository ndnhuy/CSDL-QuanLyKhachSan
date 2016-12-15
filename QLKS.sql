
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
	tongTien bigint,
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

-- TRIGGERS

-- Lúc insert 1 phòng thì số lượng phòng trống của loại phòng tương ứng tăng thêm 1 và 
-- trạng thái phòng "còn trống" được tạo ra
create trigger insert_phong on Phong
for insert
as 
begin
	set nocount on;

	declare @maLoaiPhong INT, @maPhong INT
	select @maLoaiPhong = inserted.loaiPhong, @maPhong = inserted.maPhong
	from inserted

	update LoaiPhong
	set slTrong = slTrong + 1
	where maLoaiPhong = @maLoaiPhong;

	insert into TrangThaiPhong(maPhong, ngay, tinhTrang) values(@maPhong, GETDATE(), N'còn trống')

end