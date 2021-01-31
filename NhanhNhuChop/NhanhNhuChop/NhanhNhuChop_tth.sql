create database NhanhNhuChop 
go
use NhanhNhuChop
go

create table TaiKhoanNguoiDung (
	tenNguoiDung varchar(30) not null primary key,
	matKhauNguoiDung varchar(32) not null
)

insert into TaiKhoanNguoiDung(tenNguoiDung,matKhauNguoiDung)values 
	('admin','123admin')

delete from TaiKhoanNguoiDung