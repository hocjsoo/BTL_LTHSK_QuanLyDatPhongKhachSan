using System;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class HoaDonDTO
    {
        public string MaHoaDon { get; set; }
        public string SoCCCDKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public decimal TongChiPhi { get; set; }
        public decimal TienThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DateTime NgayLapHoaDon { get; set; }

        public HoaDonDTO(string maHoaDon, string soCCCDKhachHang, string maNhanVien,
                         decimal tongChiPhi, decimal tienThanhToan, string phuongThucThanhToan,
                         DateTime ngayLapHoaDon)
        {
            MaHoaDon = maHoaDon;
            SoCCCDKhachHang = soCCCDKhachHang;
            MaNhanVien = maNhanVien;
            TongChiPhi = tongChiPhi;
            TienThanhToan = tienThanhToan;
            PhuongThucThanhToan = phuongThucThanhToan;
            NgayLapHoaDon = ngayLapHoaDon;
        }
    }
}