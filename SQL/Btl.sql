

-- Tạo cơ sở dữ liệu mới
CREATE DATABASE BTL_QuanLyKS;
GO

-- Sử dụng cơ sở dữ liệu
USE BTL_QuanLyKS;
GO

-- 1. Tạo bảng KhachHang (Khách hàng)
CREATE TABLE KhachHang (
    SoCCCD VARCHAR(12) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    NgayTao DATETIME DEFAULT GETDATE()
);

-- 2. Tạo bảng NhanVien (Nhân viên)
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    VaiTro NVARCHAR(50),
    NgayVaoLam DATETIME DEFAULT GETDATE()
);

-- 3. Tạo bảng TaiKhoan (Tài khoản đăng nhập)
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(100) NOT NULL,
    MaNhanVien VARCHAR(10) NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- 4. Tạo bảng Phong (Phòng)
CREATE TABLE Phong (
    MaPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50) NOT NULL,
    GiaPhong DECIMAL(18,2) NOT NULL,
    Tang INT
);

-- 5. Tạo bảng DichVu (Dịch vụ) - Bỏ ChiTietDichVu
CREATE TABLE DichVu (
    MaDichVu VARCHAR(10) PRIMARY KEY,
    TenDichVu NVARCHAR(100) NOT NULL,
    GiaDichVu DECIMAL(18,2) NOT NULL,
    LoaiDichVu NVARCHAR(50)
);

-- 6. Tạo bảng DatPhong (Đặt phòng)
CREATE TABLE DatPhong (
    MaDatPhong VARCHAR(20) PRIMARY KEY,
    SoCCCDKhachHang VARCHAR(12) NOT NULL,
    MaPhong VARCHAR(10) NOT NULL,
    MaNhanVien VARCHAR(10),
    NgayNhanPhong DATETIME NOT NULL,
    NgayTraPhongDuKien DATETIME NOT NULL,
    TongChiPhi DECIMAL(18,2),
    TienDatCoc DECIMAL(18,2) DEFAULT 0,
    NgayDatPhong DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SoCCCDKhachHang) REFERENCES KhachHang(SoCCCD),
    FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- 7. Tạo bảng DangKyDichVu (Đăng ký dịch vụ)
CREATE TABLE DangKyDichVu (
    SoCCCDKhachHang VARCHAR(12) NOT NULL,
    MaDichVu VARCHAR(10) NOT NULL,
    MaNhanVien VARCHAR(10),
    SoLuong INT NOT NULL,
    TongChiPhi DECIMAL(18,2) NOT NULL,
    NgayDangKy DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (SoCCCDKhachHang, MaDichVu),
    FOREIGN KEY (SoCCCDKhachHang) REFERENCES KhachHang(SoCCCD),
    FOREIGN KEY (MaDichVu) REFERENCES DichVu(MaDichVu),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- 8. Tạo bảng HoaDon (Hóa đơn)
CREATE TABLE HoaDon (
    MaHoaDon VARCHAR(20) PRIMARY KEY,
    SoCCCDKhachHang VARCHAR(12) NOT NULL,
    MaNhanVien VARCHAR(10),
    TongChiPhi DECIMAL(18,2) NOT NULL,
    TienThanhToan DECIMAL(18,2) NOT NULL,
    PhuongThucThanhToan NVARCHAR(50),
    NgayLapHoaDon DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SoCCCDKhachHang) REFERENCES KhachHang(SoCCCD),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- 9. Tạo bảng ChiTietHoaDon (Chi tiết hóa đơn)
CREATE TABLE ChiTietHoaDon (
    MaHoaDon VARCHAR(20) NOT NULL,
    MaChiTiet VARCHAR(20) NOT NULL,
    LoaiChiTiet NVARCHAR(20) NOT NULL,
    TongChiPhi DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHoaDon, MaChiTiet),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
);

-- Thêm dữ liệu mẫu

-- KhachHang
INSERT INTO KhachHang (SoCCCD, HoTen, SoDienThoai, Email) VALUES 
('123456789', N'Nguyễn Văn A', '0901234567', 'nva@gmail.com'),
('987654321', N'Trần Thị B', '0912345678', 'ttb@gmail.com');

-- NhanVien
INSERT INTO NhanVien (MaNhanVien, HoTen, SoDienThoai, Email, VaiTro, NgayVaoLam) VALUES 
('NV001', N'Nguyễn Văn X', '0901234567', 'nvx@gmail.com', N'Lễ tân', '2023-01-01'),
('NV002', N'Trần Thị Y', '0912345678', 'tty@gmail.com', N'Quản lý', '2023-02-01');

-- TaiKhoan
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNhanVien) VALUES 
('nhanvien1', 'password123', 'NV001'),
('nhanvien2', 'password456', 'NV002');

-- Phong
INSERT INTO Phong (MaPhong, LoaiPhong, GiaPhong, Tang) VALUES 
('101', N'Đơn', 500000, 1),
('102', N'Đôi', 800000, 1),
('201', N'VIP', 1500000, 2);

-- DichVu
INSERT INTO DichVu (MaDichVu, TenDichVu, GiaDichVu, LoaiDichVu) VALUES 
('DV001', N'Ăn sáng', 50000, N'Ăn uống'),
('DV002', N'Giặt ủi', 100000, N'Vệ sinh'),
('DV003', N'Đưa đón sân bay', 300000, N'Vận chuyển');

-- DatPhong
INSERT INTO DatPhong (MaDatPhong, SoCCCDKhachHang, MaPhong, MaNhanVien, NgayNhanPhong, NgayTraPhongDuKien, TongChiPhi) VALUES 
('BK20250227123456', '123456789', '101', 'NV001', '2025-02-27 14:00', '2025-02-28 12:00', 500000),
('BK20250226123457', '987654321', '102', 'NV002', '2025-02-26 14:00', '2025-02-27 12:00', 800000);

-- DangKyDichVu
INSERT INTO DangKyDichVu (SoCCCDKhachHang, MaDichVu, MaNhanVien, SoLuong, TongChiPhi) VALUES 
('123456789', 'DV001', 'NV001', 2, 100000), -- Ăn sáng x 2
('123456789', 'DV002', 'NV001', 1, 100000), -- Giặt ủi x 1
('987654321', 'DV003', 'NV002', 1, 300000); -- Đưa đón sân bay x 1

-- HoaDon
INSERT INTO HoaDon (MaHoaDon, SoCCCDKhachHang, MaNhanVien, TongChiPhi, TienThanhToan, PhuongThucThanhToan) VALUES 
('HD20250227123456', '123456789', 'NV001', 700000, 700000, N'Tiền mặt'),
('HD20250226123457', '987654321', 'NV002', 1100000, 1100000, N'Thẻ');

-- ChiTietHoaDon
INSERT INTO ChiTietHoaDon (MaHoaDon, MaChiTiet, LoaiChiTiet, TongChiPhi) VALUES 
('HD20250227123456', 'BK20250227123456', N'Đặt phòng', 500000),
('HD20250227123456', '123456789_DV001', N'Dịch vụ', 100000),
('HD20250227123456', '123456789_DV002', N'Dịch vụ', 100000),
('HD20250226123457', 'BK20250226123457', N'Đặt phòng', 800000),
('HD20250226123457', '987654321_DV003', N'Dịch vụ', 300000);


-- Thêm cột GioiTinh vào bảng NhanVien
ALTER TABLE NhanVien
ADD GioiTinh NVARCHAR(10);

-- Cập nhật dữ liệu mẫu cho cột GioiTinh
UPDATE NhanVien SET GioiTinh = N'Nam' WHERE MaNhanVien = 'NV001';
UPDATE NhanVien SET GioiTinh = N'Nữ' WHERE MaNhanVien = 'NV002';

-- Thêm cột SoCCCD và DiaChi vào bảng NhanVien
ALTER TABLE NhanVien
ADD SoCCCD VARCHAR(12),
    DiaChi NVARCHAR(200);

-- Cập nhật dữ liệu mẫu cho cột SoCCCD và DiaChi
UPDATE NhanVien SET SoCCCD = '111111111', DiaChi = N'123 Đường A, Quận 1, TP.HCM' WHERE MaNhanVien = 'NV001';
UPDATE NhanVien SET SoCCCD = '222222222', DiaChi = N'456 Đường B, Quận 2, TP.HCM' WHERE MaNhanVien = 'NV002';

-- Thêm cột TrangThai vào bảng Phong
ALTER TABLE Phong
ADD TrangThai NVARCHAR(20) DEFAULT N'Trống';

-- Cập nhật dữ liệu mẫu cho cột TrangThai
UPDATE Phong SET TrangThai = N'Trống' WHERE MaPhong IN ('101', '102', '201');

select * from dbo.DangKyDichVu
select * from dbo.DatPhong
select * from dbo.DichVu
select * from dbo.HoaDon
select * from dbo.KhachHang
select * from dbo.NhanVien
select * from dbo.Phong
select * from dbo.TaiKhoan
select * from dbo.ChiTietHoaDon