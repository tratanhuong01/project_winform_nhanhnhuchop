create table ThongTinCaNhan (
	IDNguoiChoi char(10) primary key ,
	Ho nvarchar(15) ,
	Ten nvarchar(70) ,
	GioiTinh nvarchar(5),
	NgaySinh date ,
	DiaChi nvarchar(100) ,
	Email varchar(50) ,
	SoDienThoai char(10) ,
)
create table TaiKhoanNguoiDung (
	IDNguoiChoi char(10) ,
	TenDangNhap varchar(30) ,
	MatKhau varchar(30) ,
	constraint pk_tknd primary key (IDNguoiChoi,TenDangNhap)
)
create table KetQua (
	IDNguoiChoi char(10),
	Tien int,
	SoCauCaoNhat int,
	SoCauDung int
)
create table LichSuNguoiChoi(
	IDNguoiChoi char(10) ,
	SoCauDung int,
	SoCauSai int,
	Ngay date ,
	Gio time 
)
insert into TaiKhoanNguoiDung(IDNguoiChoi,TenDangNhap,MatKhau)values ('NNC0007','354354','hihi')
insert into ThongTinCaNhan(IDNguoiChoi)values ('NNC0007')
insert into KetQua(IDNguoiChoi,TenDangNhap)values ('NNC0007','354354')
drop table TaiKhoanNguoiDung
drop table ThongTinCaNhan
drop table KetQua
drop table LichSuNguoiChoi