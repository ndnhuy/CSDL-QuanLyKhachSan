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

