using System;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class DangKyDichVuDTO
    {
        public string SoCCCDKhachHang { get; set; }
        public string MaDichVu { get; set; }
        public string MaNhanVien { get; set; }
        public int SoLuong { get; set; }
        public decimal TongChiPhi { get; set; }
        public DateTime NgayDangKy { get; set; }

        public DangKyDichVuDTO(string soCCCDKhachHang, string maDichVu, string maNhanVien, int soLuong, decimal tongChiPhi, DateTime ngayDangKy)
        {
            SoCCCDKhachHang = soCCCDKhachHang;
            MaDichVu = maDichVu;
            MaNhanVien = maNhanVien;
            SoLuong = soLuong;
            TongChiPhi = tongChiPhi;
            NgayDangKy = ngayDangKy;
        }
    }
}