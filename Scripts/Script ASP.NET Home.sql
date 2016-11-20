create database QLHocVien
use QLHocVien

create table HocSinh
(
MaHS varchar(50),
HoHS nvarchar(50),
TenHS nvarchar(50),
NgaySinh datetime,
Phai bit,
DiaChi nvarchar(50),
DienThoai varchar(20)
);
create table KetQua
(
MaHV varchar(50),
MaMon varchar(50),
Diem15 numeric,
Diem1Tiet numeric,
DiemHocKy numeric,
TBMon numeric,
HocKy int,
MaLop varchar(50)
);

create table MonHoc
(
MaMon varchar(50),
TenMon varchar(50)
)
create table HocSinh_Lop
(
MaHS varchar(50),
MaLop varchar(50)
)
create table Lop
(
MaLop varchar(50),
TenLop nvarchar(50),
Khoi nvarchar(50),
NamHoc int
);
Create table MonHoc_Lop
(
MaMon varchar(50),
MaLop varchar(50)
)

alter table HocSinh
add constraint pk_MaHS primary key(MaHS);
alter table KetQua
add constraint pk_MaHV primary key(MaHV);
alter table KetQua
add constraint pk_HocKy primary key(HocKy);
alter table KetQua
add constraint fk_MaMon foreign key(MaMon) references MonHoc(MaMon);
alter table KetQua
add constraint fk_MaLop foreign key(MaLop) references Lop(MaLop);
alter table MonHoc
add constraint pk_MaMon primary key(MaMon);
alter table HocSinh_Lop
add constraint pk_MaHS primary key(MaHS);
alter table HocSinh_Lop
add constraint fk_MaHS foreign key(MaHS) references HocSinh(MaHS);
alter table HocSinh_Lop
add constraint pk_MaLop primary key(MaLop);
alter table HocSinh_Lop
add constraint fk_MaLop foreign key(MaLop) references Lop(MaLop);
alter table Lop
add constraint pk_primary key(MaLop);
alter table MonHoc_Lop
add constraint pk_MaMon primary key(MaMon);
alter table MonHoc_Lop
add constraint pk_MaLop primary key(MaLop);
alter table MonHoc_Lop
add constraint fk_MaMon foreign key(MaMon) references MonHoc(MaMon);
alter table MonHoc_Lop
add constraint fk_MaLop foreign key(MaLop) references Lop(MaLop);

CREATE FUNCTION dbo.TaoMaLopMoi(@namhoc NUMERIC, @khoilop NUMERIC) RETURNS VARCHAR(20)
AS
BEGIN
		DECLARE @ketqua VARCHAR(20)
		DECLARE @khoi VARCHAR(5)
		DECLARE @nam VARCHAR(5)		
		DECLARE @stt_max VARCHAR(5)

		SET @khoi = (SELECT CONVERT(CHAR(2),@khoilop) )
		SET @nam  = (SELECT RIGHT(CONVERT(CHAR(4),@namhoc),2) )
		
		IF ( ( SELECT COUNT(*) FROM lop 
			   WHERE @khoi=SUBSTRING(malop,3,2) AND @nam=SUBSTRING(malop,5,2) ) = 0 )
			BEGIN
				 SET @stt_max = '01'			 	
			END
		ELSE
			BEGIN				 
				 SET @stt_max = (SELECT CONVERT(CHAR(2),MAX(RIGHT(malop,2))+1) 
								 FROM lop 
								 WHERE @khoi=SUBSTRING(malop,3,2) 
									   AND @nam=SUBSTRING(malop,5,2))

				 IF LEN(@stt_max) = 1
					BEGIN
						SET @stt_max = '0' + @stt_max
					END				 
			END

		SET @ketqua = 'LH' + @khoi + RIGHT(@nam,2) + @stt_max

		RETURN (@ketqua)
END;
GO


CREATE FUNCTION dbo.TaoMaHocSinhMoi(@malophoc VARCHAR(20)) RETURNS VARCHAR(20)
AS
BEGIN
		DECLARE @ketqua VARCHAR(20)
		DECLARE @stt_max VARCHAR(5)

		IF (( SELECT COUNT(*) FROM hocsinh WHERE @malophoc = SUBSTRING(mahs,3,8)) = 0)
			BEGIN
				SET @stt_max = '01'
			END
		ELSE
			BEGIN
				SET @stt_max = (SELECT CONVERT(CHAR(2),(MAX(RIGHT(mahs,2))+1)) FROM hocsinh WHERE @malophoc=SUBSTRING(mahs,3,8))

				IF LEN(@stt_max) = 1
					BEGIN
						SET @stt_max = '0' + @stt_max
					END				
			END

		SET @ketqua = 'HS' + @malophoc + @stt_max

		RETURN @ketqua

END;
GO

CREATE PROCEDURE Them_HocSinh(@mahs VARCHAR, @hohs NVARCHAR,@tenhs NVARCHAR, @ngaysinh DATETIME, 
							  @phai bit, @diachi NVARCHAR, @dienthoai VARCHAR)
AS
INSERT INTO hocsinh(mahs,hohs,tenhs,ngaysinh,phai,diachi,dienthoai) 
VALUES(@mahs,@hohs,@tenhs,@ngaysinh,@phai,@diachi,@dienthoai)
GO




