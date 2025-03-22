using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class ChiTietHoaDonDTO
    {
        public string MaChiTietHoaDon { get; set; }
        public string MaHoaDon { get; set; }
        public string MaDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal TongChiPhi { get; set; }

        public ChiTietHoaDonDTO(string maChiTietHoaDon, string maHoaDon, string maDichVu, int soLuong, decimal tongChiPhi)
        {
            MaChiTietHoaDon = maChiTietHoaDon;
            MaHoaDon = maHoaDon;
            MaDichVu = maDichVu;
            SoLuong = soLuong;
            TongChiPhi = tongChiPhi;
        }

        public ChiTietHoaDonDTO(DataRow row)
        {
            MaChiTietHoaDon = row["MaChiTietHoaDon"].ToString();
            MaHoaDon = row["MaHoaDon"].ToString();
            MaDichVu = row["MaDichVu"].ToString();
            SoLuong = Convert.ToInt32(row["SoLuong"]);
            TongChiPhi = Convert.ToDecimal(row["TongChiPhi"]);
        }
    }
}