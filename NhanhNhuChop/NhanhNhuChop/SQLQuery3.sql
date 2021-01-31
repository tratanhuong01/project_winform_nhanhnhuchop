delete from ThongTinCaNhan
delete from TaiKhoanNguoiDung
delete from KetQua
delete from LichSuNguoiChoi
drop table LichSuNguoiChoi
create table LichSuNguoiChoi (
	IDNguoiChoi char(10) ,
	IDLichSu char (10),
	SoCauLienTiep int,
	TongSoCau int,
	SoCauDung int,
	SoCauSai int,
	NgayGioChoi datetime ,
	TienThang int
)