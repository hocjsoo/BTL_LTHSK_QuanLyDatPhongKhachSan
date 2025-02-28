using System;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class DatPhongDTO
    {
        public string MaDatPhong { get; set; }
        public string SoCCCDKhachHang { get; set; }
        public string MaPhong { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayNhanPhong { get; set; }
        public DateTime NgayTraPhongDuKien { get; set; }
        public decimal TongChiPhi { get; set; }
        public decimal TienDatCoc { get; set; }
        public DateTime NgayDatPhong { get; set; }

        public DatPhongDTO(string maDatPhong, string soCCCDKhachHang, string maPhong, string maNhanVien,
                           DateTime ngayNhanPhong, DateTime ngayTraPhongDuKien, decimal tongChiPhi,
                           decimal tienDatCoc, DateTime ngayDatPhong)
        {
            MaDatPhong = maDatPhong;
            SoCCCDKhachHang = soCCCDKhachHang;
            MaPhong = maPhong;
            MaNhanVien = maNhanVien;
            NgayNhanPhong = ngayNhanPhong;
            NgayTraPhongDuKien = ngayTraPhongDuKien;
            TongChiPhi = tongChiPhi;
            TienDatCoc = tienDatCoc;
            NgayDatPhong = ngayDatPhong;
        }
    }
}