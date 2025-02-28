namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class ChiTietHoaDonDTO
    {
        public string MaHoaDon { get; set; }
        public string MaChiTiet { get; set; }
        public string LoaiChiTiet { get; set; }
        public decimal TongChiPhi { get; set; }

        public ChiTietHoaDonDTO(string maHoaDon, string maChiTiet, string loaiChiTiet, decimal tongChiPhi)
        {
            MaHoaDon = maHoaDon;
            MaChiTiet = maChiTiet;
            LoaiChiTiet = loaiChiTiet;
            TongChiPhi = tongChiPhi;
        }
    }
}