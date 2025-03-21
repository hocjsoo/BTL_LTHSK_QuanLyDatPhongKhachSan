using System;
using System.Collections.Generic;
using System.Data;

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
        public List<ChiTietHoaDonDTO> ChiTietHoaDons { get; set; }

        public HoaDonDTO() { ChiTietHoaDons = new List<ChiTietHoaDonDTO>(); }

        public HoaDonDTO(DataRow row)
        {
            MaHoaDon = row["MaHoaDon"].ToString();
            SoCCCDKhachHang = row["SoCCCDKhachHang"].ToString();
            MaNhanVien = row["MaNhanVien"].ToString();
            TongChiPhi = Convert.ToDecimal(row["TongChiPhi"]);
            TienThanhToan = Convert.ToDecimal(row["TienThanhToan"]);
            PhuongThucThanhToan = row["PhuongThucThanhToan"].ToString();
            NgayLapHoaDon = Convert.ToDateTime(row["NgayLapHoaDon"]);
            ChiTietHoaDons = new List<ChiTietHoaDonDTO>();
        }

        public HoaDonDTO(string maHoaDon, string soCCCDKhachHang, string maNhanVien, decimal tongChiPhi, decimal tienThanhToan, string phuongThucThanhToan, DateTime ngayLapHoaDon, List<ChiTietHoaDonDTO> chiTietHoaDons = null)
        {
            MaHoaDon = maHoaDon;
            SoCCCDKhachHang = soCCCDKhachHang;
            MaNhanVien = maNhanVien;
            TongChiPhi = tongChiPhi;
            TienThanhToan = tienThanhToan;
            PhuongThucThanhToan = phuongThucThanhToan;
            NgayLapHoaDon = ngayLapHoaDon;
            ChiTietHoaDons = chiTietHoaDons ?? new List<ChiTietHoaDonDTO>();
        }
    }
}