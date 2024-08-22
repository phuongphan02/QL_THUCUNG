CREATE DATABASE QL_THUCUNG
Use QL_THUCUNG
go
create table DonGia(
	ID_Gia varchar(5) primary key,
	GiaChuong money 
)
create table Chuong(
	ID_Chuong varchar(5) primary key not null,
	TenChuong nvarchar(30) not null,
	TinhTrangChuong nvarchar(50) not null,
	ID_Gia varchar(5)  not null,
	Hoatdong bit not null,
	FOREIGN KEY(ID_Gia) REFERENCES DonGia(ID_Gia) ON DELETE CASCADE
)

create table DichVu(
	ID_DV varchar(5) primary key not null,
	TenDV nvarchar(30) not null,
	AnhSP nvarchar(50),
	GiaBan money not null
)

create table ThanhToanDV(
	ID_TTDV varchar(5) primary key not null,
	ID_ThanhVien varchar(5)
)

create table CTTTDV(
	ID_TTDV varchar(5) not null,
	ID_DV varchar(5) not null,
	Soluong int,
	Gia money,
	FOREIGN KEY (ID_TTDV) REFERENCES ThanhToanDV(ID_TTDV) ON DELETE CASCADE,
	FOREIGN KEY (ID_DV) REFERENCES DichVu(ID_DV) ON DELETE CASCADE
)
create table ThanhVien(
	ID_ThanhVien varchar(5) primary key not null,
	TenThanhVien nvarchar(30) not null,
	TenDN nvarchar(20) not null,
	Matkhau varchar(20) not null,
	SDT VARCHAR(20) NOT NULL
)
create table HoaDon(
	ID_HoaDon varchar(10) primary key not null,
	ID_ThanhVien varchar(5) not null,
	ID_TTDV	varchar(5) not null,
	ID_Chuong varchar(5) not null,
	ThoiGianNhan datetime,
	ThoiGianTra datetime,
	TongTien money,
	TinhTrangHD nvarchar(50) ,
	FOREIGN KEY(ID_TTDV) REFERENCES ThanhToanDV(ID_TTDV) ON DELETE CASCADE,
	FOREIGN KEY(ID_ThanhVien) REFERENCES ThanhVien(ID_ThanhVien) ON DELETE CASCADE,
	FOREIGN KEY(ID_Chuong) REFERENCES Chuong(ID_Chuong) ON DELETE CASCADE
)

INSERT INTO DonGia(ID_Gia, GiaChuong)

VALUES

('GIA01', 150000),

('GIA02', 200000),

('GIA03', 250000),

('GIA04', 300000),

('GIA05', 400000),

('GIA06', 500000)
/* 3 cái thường và 3 cái vip từ 10kg đến 40kg*/

INSERT INTO Chuong(ID_Chuong, TenChuong, TinhTrangChuong, ID_Gia, Hoatdong)

VALUES

('CH01', N'Chuồng 1', N'Còn trống', 'GIA01', 1),

('CH02', N'Chuồng 2', N'Còn trống', 'GIA05', 1),

('CH03', N'Chuồng 3', N'Còn trống', 'GIA04', 1),

('CH04', N'Chuồng 4', N'Đã đầy', 'GIA05', 1),

('CH05', N'Chuồng 5', N'Còn trống', 'GIA04', 1),

('CH06', N'Chuồng 6', N'Đã đầy', 'GIA06', 1),

('CH07', N'Chuồng 7', N'Đã đầy', 'GIA03', 1),

('CH08', N'Chuồng 8', N'Còn trống', 'GIA06', 0),

('CH09', N'Chuồng 9', N'Còn trống', 'GIA05', 0),

('CH10', N'Chuồng 10', N'Còn trống', 'GIA05', 0)



INSERT INTO DichVu(ID_DV, TenDV, AnhSP, GiaBan)

VALUES

('DV01', N'Tắm cho thú cưng', 'tamchothucung.jpg', 100000),

('DV02', N'Cắt tỉa lông thú cưng', 'cattialongthucung.jpg', 250000),

('DV03', N'Chăm sóc y tế', 'chamsocyte.jpg', 200000),

('DV04', N'Bảo vệ thú cưng', 'baovethucung.jpg', 250000),

('DV05', N'Đặt lịch khám bệnh', 'datlichkhambenh.jpg', 50000),

('DV06', N'Ship thức ăn', 'giaothucan.jpg', 50000),

('DV07', N'Đào tạo thú cưng', 'daotaothucung.jpg', 400000),

('DV08', N'Vệ sinh cá nhân', 'vesinhcanhan.jpg', 100000),

('DV09', N'Đặt khách sạn', 'datkhachsan.jpg', 50000),

('DV10', N'Cho ăn', 'choan.jpg', 150000)

INSERT INTO ThanhToanDV(ID_TTDV, ID_ThanhVien)

VALUES

('TT01', 'TV01'),

('TT02', 'TV02'),

('TT03', 'TV03'),

('TT04', 'TV04'),

('TT05', 'TV05'),

('TT06', 'TV06'),

('TT07', 'TV07'),

('TT08', 'TV08'),

('TT09', 'TV09'),

('TT10', 'TV10')
INSERT INTO CTTTDV(ID_TTDV, ID_DV, Soluong, Gia)

VALUES

('TT01', 'DV01', 2, 200000),

('TT02', 'DV02', 3, 500000),

('TT03', 'DV03', 1, 200000),

('TT04', 'DV04', 1, 250000),

('TT05', 'DV05', 2, 100000),

('TT06', 'DV06', 1, 50000),

('TT07', 'DV07', 1, 400000),

('TT08', 'DV08', 2, 200000),

('TT09', 'DV09', 1, 50000),

('TT10', 'DV10', 3, 450000)


INSERT INTO ThanhVien(ID_ThanhVien, TenThanhVien, TenDN, Matkhau, SDT)

VALUES

('TV01', N'Huỳnh Công Lợi', 'huynhcongloi', 'loi123', 0905283558),

('TV02', N'Phan Trần Thu Phương', 'phantranthuphuong', 'phuong123', 0905283558),

('TV03', N'Nguyễn Thành Đạt', 'nguyenthanhdat', 'dat123', 0905283558),

('TV04', N'Lê Gia Hưng', 'legiahung', 'hung123', 0905283558),

('TV05', N'Nguyễn Thị Mai Anh', 'nguyenthimaianh', 'anh123', 0905283558),

('TV06', N'Đoàn Như Phục', 'doannhuphuc', 'phuc123', 0905283558),

('TV07', N'Lê Ngọc Tân', 'lengoctan', 'tan123', 0905283558),

('TV08', N'Đặng Trúc Ly', 'dangtrucly', 'ly123', 0905283558),

('TV09', N'Phạm Hoàng Long', 'phamhoanglong', 'long123', 0905283558),

('TV10', N'Nguyễn Hoài Duy', 'nguyenhoaiduy', 'duy123', 0905283558)



INSERT INTO HoaDon(ID_HoaDon, ID_ThanhVien, ID_TTDV, ID_Chuong, ThoiGianNhan, ThoiGianTra, TongTien, TinhTrangHD)

VALUES

('HD001', 'TV01', 'TT01', 'CH01', '2023-04-25', '2023-04-26', 400000, N'Đã thanh toán'),

('HD002', 'TV02', 'TT02', 'CH02', '2023-04-25', '2023-04-26', 900000, N'Đã thanh toán'),

('HD003', 'TV03', 'TT03', 'CH03', '2023-04-25', '2023-04-26', 500000, N'Đã thanh toán'),

('HD004', 'TV04', 'TT04', 'CH04', '2023-04-25', '2023-04-26', 650000, N'Chưa thanh toán'),

('HD005', 'TV05', 'TT05', 'CH05', '2023-04-26', '2023-04-27', 400000, N'Chưa thanh toán'),

('HD006', 'TV06', 'TT06', 'CH06', '2023-04-26', '2023-04-27', 550000, N'Chưa thanh toán'),

('HD007', 'TV07', 'TT07', 'CH07', '2023-04-27', '2023-04-28', 650000, N'Đã thanh toán'),

('HD008', 'TV08', 'TT08', 'CH06', '2023-04-27', '2023-04-28', 700000, N'Chưa thanh toán'),

('HD009', 'TV09', 'TT09', 'CH04', '2023-04-27', '2023-04-28', 450000, N'Chưa thanh toán'),

('HD010', 'TV10', 'TT10', 'CH07', '2023-04-27', '2023-04-28', 700000, N'Đã thanh toán')



/*PROCEDURE*/
/*Tìm kiếm trong bảng ThanhVien*/
go
CREATE PROCEDURE ThanhVien_TimKiem
@ID_ThanhVien varchar(5)=NULL,
@TenThanhVien nvarchar(30)=NULL,
@TenDN nvarchar(20)=NULL,
@SDT varchar(20)=null
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
@ParamList nvarchar(2000)
SELECT @SqlStr = '
SELECT *
FROM ThanhVien
WHERE  (1=1)
'
IF @ID_ThanhVien IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (ID_ThanhVien LIKE ''%'+@ID_ThanhVien+'%'')
'
IF @TenThanhVien IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (TenThanhVien LIKE ''%'+@TenThanhVien+'%'')
'
IF @TenDN IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (TenDN LIKE ''%'+@TenDN+'%'')
'
IF @SDT IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (SDT LIKE ''%'+@SDT+'%'')'
EXEC SP_EXECUTESQL @SqlStr
END

/*Tìm kiếm trong bảng DichVu*/
go
CREATE PROCEDURE DV_TimKiem
    @ID_DV varchar(5)=NULL,
	@TenDV nvarchar(30)=NULL,
	@AnhSP nvarchar(50)=NULL,
	@GiaBan money=null
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM DichVu
       WHERE  (1=1)
       '
IF @ID_DV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ID_DV LIKE ''%'+@ID_DV+'%'')
              '
IF @TenDV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenDV LIKE ''%'+@TenDV+'%'')
              '
IF @AnhSP IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (AnhSP LIKE ''%'+@AnhSP+'%'')
			  '
IF @GiaBan IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (GiaBan LIKE ''%'+CONVERT(varchar(20),@GiaBan)+'%'')'
	EXEC SP_EXECUTESQL @SqlStr
END
/*Tìm Kiếm*/
GO
CREATE PROCEDURE TimKiem_DV
    @Ma varchar(5)=NULL,
	@Ten nvarchar(30)=NULL,
	@Giatu varchar(30)=NULL,
	@Giaden varchar(30)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)

SELECT @SqlStr = '
       SELECT * 
       FROM DichVu
       WHERE  (1=1)
       '
IF @Ma IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ID_DV LIKE ''%'+@Ma+'%'')
              '
IF @Ten IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenDV LIKE ''%'+@Ten+'%'')
              '
IF @Giatu IS NOT NULL and @Giaden IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (GiaBan Between Convert(int,'''+@Giatu+''') AND Convert(int, '''+@Giaden+'''))
             '
	EXEC SP_EXECUTESQL @SqlStr
END
GO
/*Tìm Chuồng*/
CREATE PROCEDURE Chuong_TimKiem
    @ID_Chuong varchar(5)=NULL,
	@TenChuong nvarchar(30)=NULL,
	@TinhTrangChuong nvarchar(50)=null,
	@ID_Gia varchar(5)=null,
	@Hoatdong varchar(10) =null
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM Chuong
       WHERE  (1=1)
       '
IF @ID_Chuong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ID_Chuong LIKE ''%'+@ID_Chuong+'%'')
              '
IF @TenChuong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenChuong LIKE ''%'+@TenChuong+'%'')
              '
IF @TinhTrangChuong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TinhTrangChuong LIKE ''%'+@TinhTrangChuong+'%'')
			  '
IF @ID_Gia IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ID_Gia LIKE ''%'+@ID_Gia+'%'')'
IF @Hoatdong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (Hoatdong LIKE ''%'+@Hoatdong+'%'')'
	EXEC SP_EXECUTESQL @SqlStr
END
/*Đơn gía*/
GO
CREATE PROCEDURE DonGia_TimKiem
    @ID_Gia varchar(5)=NULL,
	@GiaChuong varchar(20)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM DonGia
       WHERE  (1=1)
       '
IF @ID_Gia IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (ID_Gia LIKE ''%'+@ID_Gia+'%'')
              '
IF @GiaChuong IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (GiaChuong Convert(int,'''+@GiaChuong+''')
              '
	EXEC SP_EXECUTESQL @SqlStr
END

Go 
CREATE PROCEDURE [dbo].[TimKiem]
    @TuKhoa NVARCHAR(1)
AS
BEGIN
    SET NOCOUNT ON;
    
     --Tìm kiếm trong bảng DichVu
    SELECT * FROM DichVu
    WHERE ID_DV LIKE '%' + @TuKhoa + '%' OR TenDV LIKE '%' + @TuKhoa + '%';
END
GO
CREATE PROCEDURE Chuong_TK
@ID_Chuong varchar(5) = NULL,
@TenChuong nvarchar(30) = NULL,
@TinhTrangChuong nvarchar(50) = NULL,
@ID_Gia varchar(5) = NULL,
@Hoatdong bit = NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
@ParamList nvarchar(2000)
SELECT @SqlStr = '
SELECT *
FROM Chuong
WHERE  (1=1)
'
IF @ID_Chuong IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (ID_Chuong LIKE ''%'+@ID_Chuong+'%'')
'
IF @TenChuong IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (TenChuong LIKE ''%'+@TenChuong+'%'')
'
IF @TinhTrangChuong IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (TinhTrangChuong LIKE ''%'+@TinhTrangChuong+'%'')
'
IF @ID_Gia IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (ID_Gia LIKE ''%'+@ID_Gia+'%'')
'
IF @Hoatdong IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (Hoatdong = '+CONVERT(varchar(1),@Hoatdong)+')
'
EXEC SP_EXECUTESQL @SqlStr
END

Go
CREATE PROCEDURE DichVu_TK
@ID_DV varchar(5) = NULL,
@TenDV nvarchar(30) = NULL,
@GiaMin varchar(30)=NULL,
@GiaMax varchar(30)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
@ParamList nvarchar(2000)
SELECT @SqlStr = '
SELECT *
FROM DichVu
WHERE  (1=1)
'
IF @ID_DV IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (ID_DV LIKE ''%'+@ID_DV+'%'')
'
IF @TenDV IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (TenDV LIKE ''%'+@TenDV+'%'')
'
IF @GiaMin IS NOT NULL and @GiaMax IS NOT NULL
SELECT @SqlStr = @SqlStr + '
AND (GiaBan Between Convert(int,'''+@GiaMin+''') AND Convert(int, '''+@GiaMax+'''))
'
EXEC SP_EXECUTESQL @SqlStr
END