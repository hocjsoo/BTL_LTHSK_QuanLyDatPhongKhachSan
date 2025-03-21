namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class ChiTietHoaDonDTO
    {
        public string MaChiTietHoaDon { get; set; }
        public string MaHoaDon { get; set; }
        public string MaDichVu { get; set; } // Thêm thuộc tính này
        public string LoaiDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal GiaDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal TongChiPhi { get; set; }

        public ChiTietHoaDonDTO(string maChiTietHoaDon, string maHoaDon, string maDichVu, string loaiDichVu, string tenDichVu, decimal giaDichVu, int soLuong, decimal tongChiPhi)
        {
            MaChiTietHoaDon = maChiTietHoaDon;
            MaHoaDon = maHoaDon;
            MaDichVu = maDichVu;
            LoaiDichVu = loaiDichVu;
            TenDichVu = tenDichVu;
            GiaDichVu = giaDichVu;
            SoLuong = soLuong;
            TongChiPhi = tongChiPhi;
        }
    }
}