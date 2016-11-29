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

