Create Database QL_CUA_HANG_BAN_DIEN_THOAI
Use QL_CUA_HANG_BAN_DIEN_THOAI
-- Bảng Sản phẩm
drop database QL_CUA_HANG_BAN_DIEN_THOAI
------------------Tạo bảng----------------------
Create table NHACUNGCAP(
	MANCC CHAR(10) NOT NULL,
	TENNCC NVARCHAR(30),
	DIACHI NVARCHAR(50),
	SODIENTHOAI VARCHAR(15),
	CONSTRAINT PK_NHACUNGCAP PRIMARY KEY(MANCC)
);

Create table TAIKHOAN(
	TENTAIKHOAN VARCHAR(MAX),
	MATKHAU VARCHAR(255),
);

Create table SANPHAM(
	MASANPHAM CHAR(10) NOT NULL,
	TENSANPHAM NVARCHAR(30),
	CONSTRAINT PK_MASANPHAM PRIMARY KEY(MASANPHAM)
);

Create table KHO(
	MAKHO CHAR(10) NOT NULL,
	TENKHO NVARCHAR(30),
	DIACHIKHO NVARCHAR(50),
	SOLUONGSP int,
	SODIENTHOAIKHO VARCHAR(15),
	CONSTRAINT PK_KHO PRIMARY KEY(MAKHO),
);

Create table NHAPKHO(
	MANHAPKHO CHAR(10) NOT NULL,
	MASANPHAM CHAR(10),
	MAKHO CHAR(10),
	SOLUONG INT,
	DONGIA FLOAT,
	NGAYNHAP DATE,
	MANCC CHAR(10),
	CONSTRAINT PK_NHAPKHO PRIMARY KEY(MANHAPKHO),
	CONSTRAINT FK_SANPHAM_NHAPKHO FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
	CONSTRAINT FK_NHACUNGCAP_NHAPKHO FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC),
	CONSTRAINT FK_KHO_NHAPKHO FOREIGN KEY (MAKHO) REFERENCES KHO(MAKHO),
);
CREATE TABLE XUATKHO(
	MAXUATKHO CHAR(10) NOT NULL,
	MAKHO CHAR(10),
	MASANPHAM CHAR(10),
	SOLUONG INT,
	NGAYXUAT DATE,
	CONSTRAINT PK_XUATKHO PRIMARY KEY(MAXUATKHO),
	CONSTRAINT FK_KHO_XUATKHO FOREIGN KEY (MAKHO) REFERENCES KHO(MAKHO),
	CONSTRAINT FK_SANPHAM_XUATKHO FOREIGN KEY(MASANPHAM) REFERENCES SANPHAM(MASANPHAM)
);
CREATE TABLE CHITIETSANPHAM(
	MACHITIETSANPHAM CHAR(10) NOT NULL,
	MASANPHAM CHAR(10),
	TENSANPHAM NVARCHAR(MAX),
	GIA FLOAT,
	MAUSAC NVARCHAR(MAX),
	MOTASANPHAM NVARCHAR(MAX),
	HINHANH VARCHAR(MAX),
	CONSTRAINT PK_CHITIETSANPHAM PRIMARY KEY(MACHITIETSANPHAM),
	CONSTRAINT FK_SANPHAM_CHITIETSANPHAM FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM)
);

CREATE TABLE KHACHHANG(
	MAKHACHHANG CHAR(10) NOT NULL,
	TENKHACHHANG NVARCHAR(30),
	SODIENTHOAI CHAR(15),
	EMAIL VARCHAR(50),
	DIACHI NVARCHAR(50),
	GIOITINH NVARCHAR(10),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKHACHHANG)
);

CREATE TABLE NHANVIEN(
	MANHANVIEN CHAR(10) NOT NULL,
	TENNHANVIEN NVARCHAR(MAX),
	SODIENTHOAI VARCHAR(15),
	EMAIL VARCHAR(MAX),
	DIACHI NVARCHAR(MAX),
	GIOITINH NVARCHAR(10),
	CHUCVU NVARCHAR(25),
	CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANHANVIEN)
);

CREATE TABLE DONHANG(
	MADONHANG CHAR(10) NOT NULL,
	MAKHACHHANG CHAR(10),
	NGAYDATHANG DATE,
	TRANGTHAI NVARCHAR(20),
	TONGTIEN FLOAT,
	CONSTRAINT PK_DONHANG PRIMARY KEY(MADONHANG),
	CONSTRAINT FK_KHACHHANG_DONHANG FOREIGN KEY (MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG)
);

CREATE TABLE CHITIETDONHANG(
	MACHITIETDONHANG CHAR(10) NOT NULL,
	MADONHANG CHAR(10) NOT NULL,
	MASANPHAM CHAR(10) NOT NULL,
	SOLUONG INT,
	KIEMTRATHANHTOAN BIT,
);
ALTER TABLE CHITIETDONHANG
	ADD CONSTRAINT PK_CHITIETDONHANG PRIMARY KEY(MACHITIETDONHANG, MADONHANG, MASANPHAM),
		CONSTRAINT FK_SANPHAM_CHITIETDONHANG FOREIGN KEY (MASANPHAM) REFERENCES SANPHAM(MASANPHAM),
		CONSTRAINT FK_DONHANG_CHITIETDONHANG FOREIGN KEY (MADONHANG) REFERENCES DONHANG(MADONHANG)

CREATE TABLE THANHTOANDONHANG(
	MATHANHTOANDONHANG CHAR(10) NOT NULL,
	MADONHANG CHAR(10),
	NGAYTHANHTOAN DATETIME,
	TONGTIEN FLOAT,
	CONSTRAINT PK_THANHTOANDONHANG PRIMARY KEY(MATHANHTOANDONHANG),
	CONSTRAINT FK_DONHANG_THANHTOANDONHANG FOREIGN KEY (MADONHANG) REFERENCES DONHANG(MADONHANG)
);
ALTER TABLE THANHTOANDONHANG
	ADD	CONSTRAINT CK_TONGTIEN_TTDH CHECK (TONGTIEN > 0)
-------------------Ràng buộc toàn vẹn-------------------
---------------------Bảng NHACUNGCAP--------------------
Alter table NHACUNGCAP
	ADD CONSTRAINT CK_SODIENTHOAI CHECK (SODIENTHOAI LIKE '[0-9]%' AND LEN(SODIENTHOAI) <= 11);
-----------------------Bảng KHO-------------------------
Alter table KHO
	ADD CONSTRAINT CK_SODIENTHOAIKHO CHECK (SODIENTHOAIKHO LIKE '[0-9]%' AND LEN(SODIENTHOAIKHO) <= 11)
----------------------Bảng NHAPKHO----------------------
Alter table NHAPKHO
	ADD CONSTRAINT CK_SOLUONG CHECK(SOLUONG > 0),
		CONSTRAINT CK_DONGIA CHECK(DONGIA > 0);	
go
create trigger KT_NgayNhap 
on NHAPKHO
for insert
as 
if (select NGAYNHAP from inserted) > GETDATE() 
	begin 
		print N'Ngày nhập kho phải nhỏ hơn ngày hiện tại'
		rollback tran
	end

 select * from NHAPKHO

go
create trigger CN_SOLUONG
ON NHAPKHO
for INSERT
AS
BEGIN
    UPDATE KHO
    SET KHO.SOLUONGSP = KHO.SOLUONGSP + i.SOLUONG
    FROM KHO
    INNER JOIN inserted i ON KHO.MAKHO = i.MAKHO;
END;
SELECT * FROM KHO
SELECT * FROM NHAPKHO

create trigger CN_TONGTIEN
on CHITIETDONHANG
for INSERT
AS
begin 
	UPDATE DONHANG
	SET TONGTIEN = (SELECT SUM(SOLUONG * GIA) FROM CHITIETDONHANG
			INNER JOIN CHITIETSANPHAM ON CHITIETDONHANG.MASANPHAM = CHITIETSANPHAM.MASANPHAM
			WHERE CHITIETDONHANG.MADONHANG = DONHANG.MADONHANG)
END;
SELECT * FROM DONHANG

----------------------Bảng XUATKHO----------------------
ALTER TABLE XUATKHO
	ADD	CONSTRAINT CK_SOLUONG_XUATKHO CHECK (SOLUONG > 0)
go
create trigger CN_SOLUONGXK
ON XUATKHO
for INSERT
AS
BEGIN
    UPDATE KHO
    SET KHO.SOLUONGSP = KHO.SOLUONGSP - i.SOLUONG
    FROM KHO
    INNER JOIN inserted i ON KHO.MAKHO = i.MAKHO;
END;
SELECT * FROM KHO
SELECT * FROM XUATKHO

---------------------Ràng buộc toàn vẹn-----------------
-----------------------Bảng DONHANG--------------------
alter table DONHANG
add constraint CK_TongTien check (TONGTIEN >= 0)

alter table DONHANG
add constraint CK_TrangThai check(TRANGTHAI in(N'Đã xử lý',N'Chưa xử lý'))

alter table DONHANG
add constraint CK_NgayDat check (NGAYDATHANG <= getdate())

alter table DONHANG
add constraint DF_NgayDat default getdate() for NGAYDATHANG
----------------------Bảng CHITIETDONHANG--------------------
alter table CHITIETDONHANG
add constraint CK_SoLuongDN check (SOLUONG >=0)

alter table CHITIETDONHANG
add constraint CK_KTTT check(KIEMTRATHANHTOAN in(0,1))

alter table CHITIETDONHANG
add constraint UQ_CTDH unique (MACHITIETDONHANG)

----------------------Bảng KHACHHANG------------------
------ràng buộc mã khách hàng là KHxxx với xxx đi từ 001-999
ALTER TABLE KHACHHANG ADD CONSTRAINT CK_MAKHACHHANG CHECK (MAKHACHHANG LIKE 'KH[0-9][0-9][0-9]')

------ràng buộc số điện thoại là độc nhất-------------------
ALTER TABLE KHACHHANG ADD CONSTRAINT UQ_SODIENTHOAI UNIQUE (SODIENTHOAI)

------ràng buộc email phải kết thúc bằng @gmail.com
ALTER TABLE KHACHHANG ADD CONSTRAINT CK_EMAIL CHECK (EMAIL LIKE '%@gmail.com')

------ràng buộc số điện thoại bé hơn 15 và lớn hơn 8
ALTER TABLE KHACHHANG ADD CONSTRAINT CK_SDT CHECK (LEN(SODIENTHOAI) <= 15 AND LEN(SODIENTHOAI)>8)

------ràng buộc giới tính là nam hoặc nữ
ALTER TABLE KHACHHANG ADD CONSTRAINT CK_GIOITINH CHECK (GIOITINH = 'Nam' OR GIOITINH = N'Nữ')


----------------------Bảng NHANVIEN----------------------
------ràng buộc mã nhân viên là NVxxx với xxx đi từ 001-999
ALTER TABLE NHANVIEN ADD CONSTRAINT CK_MANHANVIEN CHECK (MANHANVIEN LIKE 'NV[0-9][0-9][0-9]')

------ràng buộc số điện thoại là độc nhất-------------------
ALTER TABLE NHANVIEN ADD CONSTRAINT UQ_SODIENTHOAI_NHANVIEN UNIQUE (SODIENTHOAI)

------ràng buộc email phải kết thúc bằng @gmail.com
ALTER TABLE NHANVIEN ADD CONSTRAINT CK_EMAIL_NHANVIEN CHECK (EMAIL LIKE '%@gmail.com')

------ràng buộc số điện thoại bé hơn 15 và lớn hơn 8
ALTER TABLE NHANVIEN ADD CONSTRAINT CK_SDT_NHANVIEN CHECK (LEN(SODIENTHOAI) <= 15 AND LEN(SODIENTHOAI)>8)

------ràng buộc giới tính là nam hoặc nữ
ALTER TABLE NHANVIEN ADD CONSTRAINT CK_GIOITINH_NHANVIEN CHECK (GIOITINH = 'Nam' OR GIOITINH = N'Nữ')
------------------BẢNG CHI TIẾT SẢN PHẨM - SẢN PHẨM - TÀI KHOẢN---Quang------------------------------
----MÃ SẢN PHẨM BẮT ĐẦU TỪ [SP] VÀ LẤY CÁC SỐ TỪ 0-9
ALTER TABLE CHITIETSANPHAM ADD CONSTRAINT CK_MASANPHAM CHECK (MASANPHAM LIKE 'SP[0-9][0-9][0-9]')
----MÃ CHI TIẾT SẢN PHẨM BẮT ĐẦU TỪ [CTSP] VÀ LẤY CÁC SỐ TỪ 0-9
ALTER TABLE CHITIETSANPHAM ADD CONSTRAINT CK_MACHITIETSANPHAM CHECK (MACHITIETSANPHAM LIKE 'CTSP[0-9][0-9][0-9]')
----GIÁ TIỀN LỚN HƠN 0
ALTER TABLE CHITIETSANPHAM ADD CONSTRAINT CK_GIA CHECK (GIA > 0)
----MẬT KHẨU PHẢI BẮT ĐẦU BẰNG CHỮ CÁI HOA VÀ THEO 9 CHỮ SỐ KHÔNG DÀI HƠN 10 KÍ TỰ---- VD: A12345678
ALTER TABLE TAIKHOAN ADD CONSTRAINT CK_MATKHAU CHECK ((MATKHAU LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') AND (LEN(MATKHAU)=9))
------------------------Thêm dữ liệu---------------------------
insert into NHACUNGCAP
values
('NCC001', N'Cellphone S', N'123 Âu Cơ, Phường 10, Quận Tân Bình', '0123456789'),
('NCC002', N'Điện máy xanh', N'456 Lạc Long Quân, Phường 11, Quận Tân Bình', '0987654321'),
('NCC003', N'FPT shop', N'89 Lê Trọng Tấn, Quận Tân Phú', '0369871245'),
('NCC004', N'Siêu thị Nguyễn Kim', N'657 Lý Thường Kiệt, Quận 10', '0312457896'),
('NCC005', N'Điện máy chợ Lớn', N'456/78 Nguyễn Chi Phương', '0758213694')
select * from NHACUNGCAP

-- Insert data into SANPHAM table with phone brand names
INSERT INTO SANPHAM (MASANPHAM, TENSANPHAM)
VALUES
    ('SP001', 'Samsung'),
    ('SP002', 'iPhone'),
    ('SP003', 'Xiaomi'),
    ('SP004', 'Google Pixel'),
    ('SP005', 'OnePlus'),
    ('SP006', 'Huawei'),
    ('SP007', 'Sony Xperia'),
    ('SP008', 'LG'),
    ('SP009', 'Nokia'),
    ('SP010', 'Motorola');
SELECT * FROM SANPHAM;

INSERT INTO TAIKHOAN (TENTAIKHOAN, MATKHAU)
VALUES
('TK001','A00000001'),
('TK002','A00000002'),
('TK003','A00000003'),
('TK004','A00000004'),
('TK005','A00000005');
select * from TAIKHOAN

insert into KHO
values
('KHO01', 'Kho 1' ,N'123 Lạc Long Quân',1000, '0123456789'),
('KHO02', 'Kho 2' ,N'789/98 Lạc Long Quân',3000 ,'0987654321'),
('KHO03', 'Kho 3',N'999 Âu Cơ', 5000,'0369871245'),
('KHO04', 'Kho 4', N'123 Lê Trọng Tấn',1000, '0312457896'),
('KHO05', 'Kho 5', N'190 Nguyễn Chi Phương',2000, '0758213694')
select * from KHO

insert into NHAPKHO
values('NHAP001', 'SP001', 'KHO01', 100, 50000000, '2023-10-28', 'NCC001')
insert into NHAPKHO
values('NHAP002', 'SP002', 'KHO02', 150, 60000000, '2023-10-29', 'NCC002')
insert into NHAPKHO
values('NHAP003', 'SP003', 'KHO03', 200, 45000000, '2023-10-30', 'NCC003')
insert into NHAPKHO
values('NHAP004', 'SP004', 'KHO04', 120, 55000000, '2023-11-01', 'NCC004')
insert into NHAPKHO
values('NHAP005', 'SP005', 'KHO05', 180, 70000000, '2023-11-02', 'NCC005')
select * from NHAPKHO


INSERT INTO XUATKHO (MAXUATKHO, MAKHO, MASANPHAM, SOLUONG, NGAYXUAT)
VALUES
('XUAT1', 'KHO01', 'SP001' ,50, '2023-11-25'),
('XUAT2', 'KHO02', 'SP002' ,70, '2023-11-26'),
('XUAT3', 'KHO03', 'SP003' ,90, '2023-11-27'),
('XUAT4', 'KHO04', 'SP004' ,60, '2023-11-28'),
('XUAT5', 'KHO05', 'SP005' ,80, '2023-11-29');
select * from XUATKHO
INSERT INTO CHITIETSANPHAM (MACHITIETSANPHAM, MASANPHAM, TENSANPHAM, GIA, MAUSAC, MOTASANPHAM, HINHANH)
VALUES
    ('CTSP001', 'SP001', 'Samsung', 5000000, N'Đen', N'Mô tả sản phẩm 1', 'image1.jpg'),
    ('CTSP002', 'SP002', 'iPhone', 6000000, N'Trắng', N'Mô tả sản phẩm 2', 'image2.jpg'),
    ('CTSP003', 'SP003', 'Xiaomi', 4500000, N'Xanh', N'Mô tả sản phẩm 3', 'image3.jpg'),
    ('CTSP004', 'SP004', 'Google Pixel', 5500000, N'Đỏ', N'Mô tả sản phẩm 4', 'image4.jpg'),
    ('CTSP005', 'SP005', 'OnePlus', 7000000, N'Vàng', N'Mô tả sản phẩm 5', 'image5.jpg'),
    ('CTSP006', 'SP006', 'Huawei', 4000000, N'Xanh', N'Mô tả sản phẩm 6', 'image6.jpg'),
    ('CTSP007', 'SP007', 'Sony Xperia', 7000000, N'Vàng', N'Mô tả sản phẩm 7', 'image7.jpg'),
    ('CTSP008', 'SP008', 'LG', 2900000, N'Đỏ', N'Mô tả sản phẩm 8', 'image8.jpg'),
    ('CTSP009', 'SP009', 'Nokia', 7300000, N'Tím', N'Mô tả sản phẩm 9', 'image9.jpg'),
    ('CTSP010', 'SP010', 'Motorola', 6000000, N'Chàm', N'Mô tả sản phẩm 10', 'image10.jpg');

INSERT INTO KHACHHANG
VALUES
    ('KH001', N'Nguyễn Văn A', '0123456789', 'nguyenvana@gmail.com', N'140 Lê Trọng Tấn, P.Tây Thạnh, Q.Tân Phú, TP.HCM', N'Nam'),
    ('KH002', N'Trần Thị B', '0987654321', 'tranthib@gmail.com', N'151 Đồng Khởi, Bến Nghé, Q.1, TP.HCM', N'Nữ'),
    ('KH003', N'Hồ Văn C', '0369852147', 'hovanc@gmail.com', N'92 Đinh Tiên Hoàng, Đa Kao, Q.1 , TP.HCM', N'Nam'),
    ('KH004', N'Lê Thị D', '0856473829', 'lethid@gmail.com', N'55 Nam Kỳ Khởi Nghĩa, Phường 7, Q.3, TP.HCM', N'Nữ'),
    ('KH005', N'Phạm Văn E', '0213478965', 'phamvane@gmail.com', N'2A/20 Bạch Đằng, P.2, Q.Tân Bình, TP.HCM', N'Nam'),
    ('KH006', N'Nguyễn Thị F', '0369587421', 'nguyenthif@gmail.com', N'82 Phan Đình Phùng, TP.Đà Lạt', N'Nữ'),
    ('KH007', N'Trần Văn G', '0987054321', 'tranvang@gmail.com', N'150 Nguyễn Trãi, P.Phạm Ngũ Lão, Q.1, TP.HCM', N'Nam'),
    ('KH008', N'Lê Thị H', '0123442789', 'lethih@gmail.com', N'39 Nguyễn Tri Phương, P.7, TP.Bà Rịa Vũng Tàu', N'Nữ'),
    ('KH009', N'Phạm Văn I', '0368952147', 'phamvani@gmail.com', N'84 Tân Kỳ Tấn Quý, P.Tây Thạnh, Q.Tân Phú, TP.HCM', N'Nam'),
    ('KH010', N'Hồ Thị K', '0856437829', 'hothik@gmail.com', N'234 Tân Sơn Nhì, P.Tân Sơn Nhì, Q.Tân Phú, TP.HCM', N'Nữ')
select * from KHACHHANG

INSERT INTO NHANVIEN
VALUES
    ('NV001', N'Trần Mạnh Thiện', '0123456789', 'tranmanhthien@gmail.com', N'60 Nam Kỳ Khởi Nghĩa, Phường 7, Q.3, TP.HCM', 'Nam',N'Quản Lý Kho'),
    ('NV002', N'Lê Dương Lý', '0987654321', 'leduongly@gmail.com', N'20 Phan Đình Phùng, TP.Đà Lạt', 'Nam',N'Nhân Viên Kỹ Thuật'),
    ('NV003', N'Trần Hậu Linh', '0369852147', 'tranhaulinh@gmail.com', N'92 Đinh Tiên Hoàng, Đa Kao, Q.1 , TP.HCM', N'Nữ',N'Nhân Viên Bán Hàng'),
    ('NV004', N'Trần Ngọc Thiện', '0856473829', 'tranngocthien@gmail.com', N'120 Lê Trọng Tấn, P.Tây Thạnh, Q.Tân Phú, TP.HCM', 'Nam',N'Nhân Viên Bán Hàng'),
    ('NV005', N'Trần Yến Nhi', '0213478965', 'tranyennhi@gmail.com', N'15 Nguyễn Trãi, P.Phạm Ngũ Lão, Q.1, TP.HCM', N'Nữ',N'Quản Lý Cửa Hàng'),
    ('NV006', N'Đặng Thị Quyên', '0369587421', 'dangthiquyen@gmail.com', N'100 Đồng Khởi, Bến Nghé, Q.1, TP.HCM', N'Nữ',N'Bảo Vệ'),
    ('NV007', N'Lê Văn Sĩ', '0987054321', 'levansi@gmail.com', N'60 Bạch Đằng, P.2, Q.Tân Bình, TP.HCM', 'Nam',N'Bảo Vệ');
select * from NHANVIEN

insert into DONHANG(MADONHANG,MAKHACHHANG,NGAYDATHANG,TRANGTHAI)
values('DH001','KH001','04-11-2023',N'Đã xử lý'),
	('DH003','KH002','2023-11-01',N'Chưa xử lý'),
	('DH004','KH003','2023-11-02',N'Đã xử lý'),
	('DH005','KH004','2023-11-03',N'Đã xử lý'),
	('DH006','KH005','2023-10-30',N'Chưa xử lý'),
	('DH007','KH006','2023-10-12',N'Đã xử lý'),
	('DH008','KH007','2023-10-04',N'Đã xử lý'),
	('DH009','KH008','2023-10-11',N'Chưa xử lý'),
	('DH0010','KH009','2023-10-27',N'Đã xử lý')
select * from DONHANG

insert into CHITIETDONHANG(MACHITIETDONHANG,MADONHANG,MASANPHAM,SOLUONG,KIEMTRATHANHTOAN)
values('CTDH001','DH001','SP001',2,1),
	('CTDH002','DH004','SP002',1,1),
	('CTDH003','DH003','SP003',3,1),
	('CTDH004','DH004','SP004',4,1),
	('CTDH005','DH005','SP005',5,1),
	('CTDH006','DH006','SP006',1,1),
	('CTDH007','DH007','SP007',3,1),
	('CTDH008','DH008','SP008',2,1),
	('CTDH009','DH009','SP009',3,1),
	('CTDH010','DH0010','SP010',2,1)
select * from CHITIETDONHANG

-- Dữ liệu cho bảng THANHTOANDONHANG
INSERT INTO THANHTOANDONHANG (MATHANHTOANDONHANG, MADONHANG, NGAYTHANHTOAN, TONGTIEN)
VALUES
('TT001', 'DH001', '2023-04-11', 10000000),
('TT002', 'DH004', '2023-11-02', 28000000),
('TT003', 'DH005', '2023-11-03', 35000000),
('TT004', 'DH007', '2023-10-12', 21000000),
('TT005', 'DH008', '2023-10-04', 5800000),
('TT006', 'DH0010', '2023-10-27',12000000);
select * from THANHTOANDONHANG
go
--------------------------Thủ tục và hàm người dùng định nghĩa-----------------------------
------------------------------------Tuấn Khải-----------------------------
-------Viết thủ tục thêm kho mới---------
create proc sp_ThemKho @MaKho char(10), @TenKho nvarchar(30),@DiaChiKho nvarchar(50), @SoDienThoaiKho varchar(15)
as
	if exists(select * from KHO where MAKHO = @MaKho)
		begin 
			print N'Kho này đã tồn tại'
			return
		end
	else 
		insert into KHO
		values(@MaKho, @TenKho, @DiaChiKho, 0, @SoDienThoaiKho)
select * from KHO
exec sp_ThemKho 'KHO06', N'Kho số 6','597 Âu cơ p10', '0987897653'
go
-------Viết thủ tục thêm nhập kho---------
create proc sp_ThemNhapKho @MaNhapKho char(10), @MaSP char(10), @MaKho char(10), @SoLuong int, @DonGia float,
			@NgayNhap date, @MaNCC char(10)  
as
	if exists(select * from NHAPKHO where MANHAPKHO = @MaNhapKho)
		begin 
			print N'Đã tồn tại'
			return
		end
	else 
		insert into NHAPKHO
		values(@MaNhapKho,  @MaSP,  @MaKho, @SoLuong, @DonGia, @NgayNhap, @MaNCC)
select * from KHO
select * from NHAPKHO
exec sp_ThemNhapKho 'NHAP006', 'SP006', 'KHO06', 100, 50000000, '2023-11-30', 'NCC003'
exec sp_ThemNhapKho 'NHAP007', 'SP004', 'KHO06', 100, 50000000, '2023-11-30', 'NCC003'
go
-------Viết thủ tục thêm xuất kho---------
create proc sp_ThemXuatKho @MaXuatKho char(10), @MaSP char(10), @MaKho char(10), @SoLuong int, @NgayXuat date  
as
	if exists(select * from XUATKHO where MAXUATKHO = @MaXuatKho)
		begin 
			print N'Đã tồn tại'
			return
		end
	else 
		insert into XUATKHO
		values(@MaXuatKho,  @MaKho ,@MaSP, @SoLuong, @NgayXuat)
select * from KHO
select * from XUATKHO
exec sp_ThemXuatKho 'XUAT6', 'SP001', 'KHO03', 100, 50000000, '2023-11-11'
--drop proc sp_ThemXuatKho
go
-------Thủ tục thêm nhà cung cấp------
create proc sp_ThemNCC @MaNCC char(10), @TenNCC nvarchar(30),@DiaChi nvarchar(50), @SoDienThoai varchar(15)
as
	if exists(select * from NHACUNGCAP where MANCC = @MaNCC)
		begin 
			print N'Nhà cung cấp này đã tồn tại'
			return
		end
	else 
		insert into NHACUNGCAP
		values(@MaNCC, @TenNCC, @DiaChi, @SoDienThoai)
go
exec sp_ThemNCC 'NCC006', N'Thế giới di động', N'111 Lê Trọng Tấn', '0749371371'
select * from NHACUNGCAP
--------------Thủ tục xóa kho-------------
CREATE PROCEDURE XoaKho
    @MaKho char(10)
AS
BEGIN
    -- Kiểm tra xem kho tồn tại hay không trước khi xóa
    IF EXISTS (SELECT * FROM KHO WHERE MaKho = @MaKho)
    BEGIN
        -- Xóa kho từ bảng dữ liệu
        DELETE FROM KHO WHERE MaKho = @MaKho
        PRINT 'Đã xóa kho thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy kho có mã kho này.'
    END
END

--------Thủ tục xóa nhập kho-----------
go
CREATE PROCEDURE XoaNhapKho
    @MaNhapKho char(10)
AS
BEGIN
    -- Kiểm tra xem mã nhập kho tồn tại hay không trước khi xóa
    IF EXISTS (SELECT * FROM NHAPKHO WHERE MANHAPKHO = @MaNhapKho)
    BEGIN
        -- Xóa nhập kho từ bảng dữ liệu
        DELETE FROM NHAPKHO WHERE MANHAPKHO = @MaNhapKho
        PRINT 'Đã xóa thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy mã nhập kho này.'
    END
END

--------Thủ tục xóa xuất kho-----------
go
CREATE PROCEDURE XoaXuatKho
    @MaXuatKho char(10)
AS
BEGIN
    -- Kiểm tra xem mã xuất kho tồn tại hay không trước khi xóa
    IF EXISTS (SELECT * FROM XUATKHO WHERE MAXUATKHO = @MaXuatKho)
    BEGIN
        -- Xóa xuất kho từ bảng dữ liệu
        DELETE FROM XUATKHO WHERE MAXUATKHO = @MaXuatKho
        PRINT 'Đã xóa thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy mã xuất kho này.'
    END
END
---------------Xóa nhà cung cấp--------------
go
CREATE PROCEDURE XoaNCC
    @MaNCC char(10)
AS
BEGIN
    -- Kiểm tra xem nhà cung cấp có tồn tại hay không trước khi xóa
    IF EXISTS (SELECT * FROM NHACUNGCAP WHERE MaNCC = @MaNCC)
    BEGIN
        -- Xóa kho từ bảng dữ liệu
        DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC
        PRINT 'Đã xóa thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy nhà cung cấp có mã kho này.'
    END
END 
--drop proc XoaNCC
----------------thủ tục sửa thông tin kho-------------
go
CREATE PROCEDURE SuaThongTinKho
    @MaKho char(10),
    @TenKho NVARCHAR(30),
    @DiaChiKho NVARCHAR(50),
    @SoDienThoai VARCHAR(15)
AS
BEGIN
    -- Kiểm tra xem kho có tồn tại không trước khi sửa thông tin
    IF EXISTS (SELECT * FROM KHO WHERE MaKho = @MaKho)
    BEGIN
        -- Cập nhật thông tin kho trong bảng dữ liệu
        UPDATE KHO
        SET TENKHO = @TenKho,
            DIACHIKHO = @DiaChiKho,
            SODIENTHOAIKHO = @SoDienThoai
        WHERE MaKho = @MaKho
        PRINT 'Đã cập nhật thông tin kho thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy kho có mã số này.'
    END
END
go
----------------thủ tục sửa thông tin nhập kho--------------
CREATE PROCEDURE SuaThongTinNhapKho
    @MaNhapKho char(10), 
	@MaSP char(10), 
	@MaKho char(10), 
	@SoLuong int, 
	@DonGia float,
	@NgayNhap date, 
	@MaNCC char(10) 
AS
BEGIN
    -- Kiểm tra xem mã nhập kho có tồn tại không trước khi sửa thông tin
    IF EXISTS (SELECT * FROM NHAPKHO WHERE MANHAPKHO = @MaNhapKho)
    BEGIN
        -- Cập nhật thông tin nhập kho trong bảng dữ liệu
        UPDATE NHAPKHO
        SET MASANPHAM = @MaSP,
            MAKHO = @MaKho,
            SOLUONG = @SoLuong,
			DONGIA = @DonGia,
			NGAYNHAP = @NgayNhap
        WHERE MaNhapKho = @MaNhapKho
        PRINT 'Đã cập nhật thông tin nhập kho thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy mã số này.'
    END
END
go
----------------thủ tục sửa thông tin xuất kho--------------
CREATE PROCEDURE SuaThongTinXuatKho
    @MaXuatKho char(10), 
	@MaSP char(10), 
	@MaKho char(10), 
	@SoLuong int, 
	@NgayXuat date 
AS
BEGIN
    -- Kiểm tra xem kho có tồn tại không trước khi sửa thông tin
    IF EXISTS (SELECT * FROM XUATKHO WHERE MAXUATKHO = @MaXuatKho)
    BEGIN
        -- Cập nhật thông tin kho trong bảng dữ liệu
        UPDATE XUATKHO
        SET MASANPHAM = @MaSP,
            MAKHO = @MaKho,
            SOLUONG = @SoLuong,
			NGAYXUAT = @NgayXuat
        WHERE MaXuatKho = @MaXuatKho
        PRINT 'Đã cập nhật thông tin xuất kho thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy mã số này.'
    END
END
go
-------------Sửa thông tin nhà cung cấp-----------
CREATE PROCEDURE SuaThongTinNhaCungCap
    @MaNCC char(10), 
	@TenNCC nvarchar(30), 
	@DiaChi nvarchar(50), 
	@SoDienThoai varchar(15)
AS
BEGIN
    -- Kiểm tra xem nhà cung cấp có tồn tại không trước khi sửa thông tin
    IF EXISTS (SELECT * FROM NHACUNGCAP WHERE MANCC = @MaNCC)
    BEGIN
        -- Cập nhật thông tin nhà cung cấp trong bảng dữ liệu
        UPDATE NHACUNGCAP
        SET MANCC = @MaNCC,
            TENNCC = @TenNCC,
            DIACHI = @DiaChi,
			SODIENTHOAI = @SoDienThoai
        WHERE MANCC = @MaNCC
        PRINT 'Đã cập nhật thông tin nhà cung cấp thành công.'
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy nhà cung cấp có mã số này.'
    END
END
go
------------Thủ tục tìm kiếm nhập kho-----------
CREATE FUNCTION TimKiemNhapKho
(
    @MaNhapKho CHAR(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM NhapKho
    WHERE MANHAPKHO = @MaNhapKho
);

------------Thủ tục tìm kiếm xuất kho-----------
CREATE FUNCTION TimKiemXuatKho
(
    @MaXuatKho CHAR(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM XuatKho
    WHERE MAXUATKHO = @MaXuatKho
);
go
--------------------------Minh Quang------------------------
create proc TongDoanhThuTrongNam
	@Nam int
as
	begin
		SELECT SUM(TONGTIEN) AS DOANHTHU
		FROM THANHTOANDONHANG
		WHERE YEAR(NGAYTHANHTOAN) = @Nam
end
GO
select * from THANHTOANDONHANG
--DROP PROC TongDoanhThuTrongNam
exec TongDoanhThuTrongNam 2023

--Danh sách 5 đơn hàng giá cao nhất trong tháng X năm xxxx
create proc top5donhangcaonhat2
	@Thang int,
	@Nam int
as
	begin
	SELECT TOP 5 MADONHANG, NGAYTHANHTOAN, TONGTIEN
	FROM THANHTOANDONHANG
	WHERE YEAR(NGAYTHANHTOAN) = @Nam and MONTH(NGAYTHANHTOAN) = @Thang
	ORDER BY TONGTIEN DESC
end
GO
exec top5donhangcaonhat2 10, 2023
--DROP PROC top5donhangcaonhat2
SELECT * FROM THANHTOANDONHANG
go
------------Thống kê tổng số lượng nhập kho X trong năm X----------------
CREATE PROCEDURE ThongKeNhapKhoTrongNam
    @MaKho char(10),
	@Thang int,
	@Nam int
AS
BEGIN
    SELECT SUM(SoLuong) AS TongLuongNhapKho
    FROM NhapKho
    WHERE MaKho = @MaKho and MONTH(NGAYNHAP) = @Thang and YEAR(NGAYNHAP) = @Nam
	--WHERE MONTH(NGAYNHAP) = @Thang and YEAR(NGAYNHAP) = @Nam
END
GO
EXEC ThongKeNhapKhoTrongNam 'KHO01',10 ,2023
--EXEC ThongKeNhapKhoTrongNam 10, 2023
--DROP PROC ThongKeNhapKhoTrongNam
SELECT * FROM NHAPKHO
go
-----Tính tổng số tiền cửa hàng thu được của tháng X trong năm X----
create proc tongdoanhthutheothang (@Thang int, @Nam int)
as
	begin
	SELECT MONTH(NGAYTHANHTOAN) AS THANG, YEAR(NGAYTHANHTOAN) AS NAM, SUM(TONGTIEN) AS DOANHTHU
	FROM THANHTOANDONHANG
	WHERE YEAR(NGAYTHANHTOAN) = @Nam and MONTH(NGAYTHANHTOAN) = @Thang
	GROUP BY MONTH(NGAYTHANHTOAN), YEAR(NGAYTHANHTOAN)
end
GO
-------------------------------------------
create proc tongdoanhthuspXtheothangnam3 (@Thang int, @Nam int, @MASP char(10))
as
	begin
	SELECT MONTH(NGAYTHANHTOAN) AS THANG, YEAR(NGAYTHANHTOAN) AS NAM, SUM(TONGTIEN) AS DOANHTHU, SANPHAM.MASANPHAM
	FROM THANHTOANDONHANG, CHITIETDONHANG, SANPHAM
	WHERE YEAR(NGAYTHANHTOAN) = @Nam and MONTH(NGAYTHANHTOAN) = @Thang and CHITIETDONHANG.MASANPHAM = @MASP
		and THANHTOANDONHANG.MADONHANG = CHITIETDONHANG.MADONHANG and CHITIETDONHANG.MASANPHAM =  SANPHAM.MASANPHAM
			GROUP BY MONTH(NGAYTHANHTOAN), YEAR(NGAYTHANHTOAN),SANPHAM.MASANPHAM
end
GO
EXEC tongdoanhthuspXtheothangnam3 10, 2023,'SP010'
	
select * from DONHANG
select * from CHITIETDONHANG
select * from THANHTOANDONHANG
go

	--GROUP BY MONTH(NGAYTHANHTOAN), YEAR(NGAYTHANHTOAN),SANPHAM.MASANPHAM
-------------------------Thống kê trạng thái đơn hàng hiện tại-------------------
CREATE PROCEDURE ThongKeTrangThaiDonHang
AS
BEGIN
    SELECT
        TRANGTHAI,
        COUNT(MADONHANG) AS SoLuongDonHang,
        STRING_AGG(MADONHANG, ', ') AS DanhSachMaDonHang
    FROM
        DONHANG
    GROUP BY
        TRANGTHAI
    ORDER BY
        SoLuongDonHang DESC;
END;
GO
--DROP PROC ThongKeTrangThaiDonHang
EXEC ThongKeTrangThaiDonHang
go
---------------------------Nguyễn Minh Tú----------------------------
-- Tạo thủ tục để thêm khách hàng mới và tự động tăng mã khách hàng
CREATE PROCEDURE AddCustomer
    @TenKhachHang NVARCHAR(30),
    @SoDienThoai CHAR(15),
    @Email VARCHAR(50),
    @DiaChi NVARCHAR(50),
    @GioiTinh NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    -- Biến để lưu trữ mã khách hàng mới
    DECLARE @NewCustomerID CHAR(10);

    -- Lấy mã khách hàng mới bằng cách tăng giá trị của mã khách hàng cao nhất lên 1
    SELECT @NewCustomerID = 'KH' + RIGHT('000' + CAST(ISNULL(SUBSTRING(MAX(MAKHACHHANG), 3, 3), 0) + 1 AS VARCHAR(3)), 3)
    FROM KHACHHANG;

    -- Thêm khách hàng mới vào bảng KHACHHANG
    INSERT INTO KHACHHANG (MAKHACHHANG, TENKHACHHANG, SODIENTHOAI, EMAIL, DIACHI, GIOITINH)
    VALUES (@NewCustomerID, @TenKhachHang, @SoDienThoai, @Email, @DiaChi, @GioiTinh);

    -- In thông báo và trả về mã khách hàng mới
    PRINT 'Khách hàng đã được thêm thành công. Mã khách hàng mới: ' + @NewCustomerID;
    SELECT @NewCustomerID AS NewCustomerID;
END;

-- Gọi thủ tục để thêm khách hàng mới
EXEC AddCustomer
    @TenKhachHang = N'Nguyễn Minh Tú',
    @SoDienThoai = '0223451689',
    @Email = 'nguyenvana@gmail.com',
    @DiaChi = N'140 Lê Trọng Tấn, P.Tây Thạnh, Q.Tân Phú, TP.HCM',
    @GioiTinh = N'Nam';
go
CREATE PROCEDURE ThemNhanVien
    @TenNV NVARCHAR(MAX),
    @SoDienThoai VARCHAR(15),
    @Email VARCHAR(MAX),
    @DiaChi NVARCHAR(MAX),
    @GioiTinh NVARCHAR(10),
    @ChucVu NVARCHAR(25)
AS
BEGIN
    DECLARE @MaNV CHAR(10)
    
    -- Tìm mã nhân viên lớn nhất
    SELECT @MaNV = ISNULL(MAX(MANHANVIEN), 'NV000')
    FROM NHANVIEN

    -- Trích xuất số từ mã nhân viên hiện tại và tăng giá trị lên 1
    DECLARE @SoTuMaCu INT
    SET @SoTuMaCu = CONVERT(INT, SUBSTRING(@MaNV, 3, 3))
    SET @SoTuMaCu = @SoTuMaCu + 1

    -- Tạo mã nhân viên mới với định dạng NVXXX
    SET @MaNV = 'NV' + RIGHT('000' + CAST(@SoTuMaCu AS VARCHAR(3)), 3)

    -- Thêm nhân viên mới vào bảng
    INSERT INTO NHANVIEN (MANHANVIEN, TENNHANVIEN, SODIENTHOAI, EMAIL, DIACHI, GIOITINH, CHUCVU)
    VALUES (@MaNV, @TenNV, @SoDienThoai, @Email, @DiaChi, @GioiTinh, @ChucVu)
END;
go
-------------------------
CREATE PROCEDURE SearchNhanVien
    @SearchTerm NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM NHANVIEN
    WHERE MANHANVIEN LIKE '%' + @SearchTerm + '%'
        OR TENNHANVIEN LIKE '%' + @SearchTerm + '%'
        OR SODIENTHOAI LIKE '%' + @SearchTerm + '%'
        OR EMAIL LIKE '%' + @SearchTerm + '%'
        OR DIACHI LIKE '%' + @SearchTerm + '%'
		OR CHUCVU LIKE '%' + @SearchTerm + '%'
END
---------------------------------tạo thủ tục tìm kiếm--------------------- 
CREATE PROCEDURE SearchKhachHang
    @SearchTerm NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM KHACHHANG
    WHERE MAKHACHHANG LIKE '%' + @SearchTerm + '%'
        OR TENKHACHHANG LIKE '%' + @SearchTerm + '%'
        OR SODIENTHOAI LIKE '%' + @SearchTerm + '%'
        OR EMAIL LIKE '%' + @SearchTerm + '%'
        OR DIACHI LIKE '%' + @SearchTerm + '%'
END
go
-------------------------Nguyễn Lê Khải-------------------------
--- procedure tìm kiếm
go
CREATE PROCEDURE SearchDonHang
    @SearchTerm NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM DONHANG
    WHERE MADONHANG LIKE '%' + @SearchTerm + '%'
        OR MAKHACHHANG LIKE '%' + @SearchTerm + '%'
        OR CONVERT(NVARCHAR(30), NGAYDATHANG, 120) LIKE '%' + @SearchTerm + '%'
        OR TRANGTHAI LIKE '%' + @SearchTerm + '%'
        OR CONVERT(NVARCHAR(20), TONGTIEN) LIKE '%' + @SearchTerm + '%'
        OR CONVERT(NVARCHAR(30), NGAYDATHANG, 103) LIKE '%' + @SearchTerm + '%';
END;


----proc thêm Đơn hàng
go
CREATE PROCEDURE InsertDonHang
    @MaDonHang CHAR(10),
    @MaKhachHang CHAR(10),
    @NgayDatHang DATETIME,
    @TrangThai NVARCHAR(20),
    @TongTien FLOAT
AS
BEGIN
    INSERT INTO DONHANG (MADONHANG, MAKHACHHANG, NGAYDATHANG, TRANGTHAI, TONGTIEN)
    VALUES (@MaDonHang, @MaKhachHang, @NgayDatHang, @TrangThai, @TongTien);
END;


----proc xóa Đơn hàng
go
CREATE PROCEDURE DeleteDonHang
    @MaDonHang CHAR(10)
AS
BEGIN
    DELETE FROM DONHANG
    WHERE MADONHANG = @MaDonHang;
END;

---proc cập nhật Đơn hàng
go
CREATE PROCEDURE UpdateDonHang
    @MaDonHang CHAR(10),
    @MaKhachHang CHAR(10),
    @NgayDatHang DATETIME,
    @TrangThai NVARCHAR(20),
    @TongTien FLOAT
AS
BEGIN
    UPDATE DONHANG
    SET MAKHACHHANG = @MaKhachHang,
        NGAYDATHANG = @NgayDatHang,
        TRANGTHAI = @TrangThai,
        TONGTIEN = @TongTien
    WHERE MADONHANG = @MaDonHang;
END;

---- hàm tính tổng tiền theo Mã khách hàng
go
CREATE FUNCTION GetTongTienByMaKhachHang
    (@MaKhachHang CHAR(10))
RETURNS FLOAT
AS
BEGIN
    DECLARE @TongTien FLOAT;

    SELECT @TongTien = SUM(TONGTIEN)
    FROM DONHANG
    WHERE MAKHACHHANG = @MaKhachHang;

    RETURN @TongTien;
END;

go
DECLARE @MaKhachHang CHAR(10) = 'KH001';
SELECT dbo.GetTongTienByMaKhachHang(@MaKhachHang) AS TongTien;
---------Nguyễn Tấn Lâm--------------
---------------FUNCTION-------------
-- Hàm này sẽ trả về thông tin chi tiết của một sản phẩm cùng với thông tin chi tiết của sản phẩm đó--
CREATE FUNCTION fc_LayThongTinChiTietSanPham
(
    @MaSanPham CHAR(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        SP.MaSanPham,
        SP.TenSanPham,
        CTSanPham.MaChiTietSanPham,
        CTSanPham.Gia,
        CTSanPham.MauSac,
        CTSanPham.MoTaSanPham,
        CTSanPham.HinhAnh
    FROM 
        SANPHAM SP
    JOIN 
        CHITIETSANPHAM CTSanPham ON SP.MaSanPham = CTSanPham.MaSanPham
    WHERE 
        SP.MaSanPham = @MaSanPham
);
-- Lấy thông tin chi tiết của sản phẩm có mã là 'SP006'
-- Gọi hàm
SELECT * FROM fc_LayThongTinChiTietSanPham('SP007');

--DROP FUNCTION fc_LayThongTinChiTietSanPham;

-- Hàm lọc danh sách sản phẩm theo tên sản phẩm
CREATE FUNCTION fc_LocDanhSachSanPhamTheoTenSP
(
    @TenSanPham NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        SP.MaSanPham,
        SP.TenSanPham,
        CTSanPham.Gia,
        CTSanPham.MauSac,
        CTSanPham.MoTaSanPham,
        CTSanPham.HinhAnh
    FROM 
        SANPHAM SP
    JOIN 
        CHITIETSANPHAM CTSanPham ON SP.MaSanPham = CTSanPham.MaSanPham
    WHERE 
        SP.TenSanPham = @TenSanPham
);

-- Gọi hàm để lọc danh sách sản phẩm theo tên sản phẩm 'Samsung'
SELECT * FROM fc_LocDanhSachSanPhamTheoTenSP('Samsung');


--DROP FUNCTION fc_DanhSachSanPhamTheoTenSP;

------------ Viết thủ tục thêm sản phẩm----

--DROP PROCEDURE sp_ThemSanPham;
--DROP PROCEDURE sp_XoaSanPham;
--DROP PROCEDURE sp_SuaSanPham;

CREATE PROCEDURE sp_ThemSanPham 
(
    @MaSanPham CHAR(10),
    @TenSanPham NVARCHAR(30),
    @MaChiTietSanPham CHAR(10),
    @Gia FLOAT,
    @MauSac NVARCHAR(MAX),
    @MoTaSanPham NVARCHAR(MAX),
    @HinhAnh VARCHAR(MAX)
)
AS
BEGIN
    IF EXISTS (SELECT * FROM SANPHAM WHERE MASANPHAM = @MaSanPham)
    BEGIN
        PRINT N'Sản phẩm này đã tồn tại';
        RETURN;
    END
    ELSE
        INSERT INTO SANPHAM (MASANPHAM, TENSANPHAM)
        VALUES (@MaSanPham, @TenSanPham);

    IF NOT EXISTS (SELECT * FROM CHITIETSANPHAM WHERE MACHITIETSANPHAM = @MaChiTietSanPham)
        INSERT INTO CHITIETSANPHAM (MACHITIETSANPHAM, MASANPHAM, TENSANPHAM, GIA, MAUSAC, MOTASANPHAM, HINHANH)
        VALUES (@MaChiTietSanPham, @MaSanPham, @TenSanPham, @Gia, @MauSac, @MoTaSanPham, @HinhAnh);
END;

	-- Gọi thủ tục và truyền các tham số cho sản phẩm có mã 'SP001'
EXEC sp_ThemSanPham 'SP001', 'Samsung', 'CTSP001', 5000000, N'Đen', N'Mô tả sản phẩm 1', 'image1.jpg';

-- Gọi thủ tục và truyền các tham số cho sản phẩm có mã 'SP011'
EXEC sp_ThemSanPham 'SP011', N'Smartphone Pro', 'CTSP011', 700000, N'Màu trắng', N'Mô tả sản phẩm mới', 'new_image.jpg';
--XOA
-- Xóa sản phẩm từ bảng CHITIETSANPHAM
DELETE FROM CHITIETSANPHAM WHERE MASANPHAM = 'SP011';
-- Xóa sản phẩm từ bảng SANPHAM
DELETE FROM SANPHAM WHERE MASANPHAM = 'SP011';
-- Hiển thị thông tin sản phẩm
SELECT * FROM SANPHAM;
SELECT * FROM CHITIETSANPHAM;


--- Viết thủ tục xóa sản phẩm----
CREATE PROCEDURE sp_XoaSanPham 
(
    @MaSanPham CHAR(10)
)
AS
BEGIN
    -- Xóa sản phẩm từ bảng CHITIETSANPHAM
    DELETE FROM CHITIETSANPHAM WHERE MASANPHAM = @MaSanPham;
    -- Xóa sản phẩm từ bảng SANPHAM
    DELETE FROM SANPHAM WHERE MASANPHAM = @MaSanPham;
END;

-- Thực hiện stored procedure sp_XoaSanPham
EXEC sp_XoaSanPham 'SP011';

-- Hiển thị thông tin sản phẩm sau khi xóa
SELECT * FROM SANPHAM;
SELECT * FROM CHITIETSANPHAM;


-----viết thủ tục sửa sản phẩm---

CREATE PROCEDURE sp_SuaSanPham 
(
    @MaSanPham CHAR(10),
    @TenSanPham NVARCHAR(30),
    @MaChiTietSanPham CHAR(10),
    @Gia FLOAT,
    @MauSac NVARCHAR(MAX),
    @MoTaSanPham NVARCHAR(MAX),
    @HinhAnh VARCHAR(MAX)
)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM SANPHAM WHERE MASANPHAM = @MaSanPham)
    BEGIN
        PRINT N'Sản phẩm không tồn tại';
        RETURN;
    END

    UPDATE SANPHAM
    SET TENSANPHAM = @TenSanPham
    WHERE MASANPHAM = @MaSanPham;

    UPDATE CHITIETSANPHAM
    SET MACHITIETSANPHAM = @MaChiTietSanPham,
        TENSANPHAM = @TenSanPham,
        GIA = @Gia,
        MAUSAC = @MauSac,
        MOTASANPHAM = @MoTaSanPham,
        HINHANH = @HinhAnh
    WHERE MASANPHAM = @MaSanPham;
END;

-- Thực hiện stored procedure sp_SuaSanPham
-- Gọi thủ tục và truyền các tham số cho sản phẩm có mã 'SP011'

EXEC sp_SuaSanPham 'SP011', N'(Updated)Smartphone Pro', 'CTSP011', 700000, N'Màu trắng', N'Mô tả sản phẩm cập nhật', 'updated_image.jpg';

-- Hiển thị thông tin sản phẩm sau khi sửa đổi
SELECT * FROM SANPHAM;
SELECT * FROM CHITIETSANPHAM;


 SELECT MASANPHAM, MACHITIETSANPHAM, TENSANPHAM, GIA, MAUSAC, MOTASANPHAM, HINHANH FROM CHITIETSANPHAM
	

