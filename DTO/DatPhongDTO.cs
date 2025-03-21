using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class DatPhongDTO
    {
        public string MaDatPhong { get; set; }
        public string SoCCCDKhachHang { get; set; }
        public string MaPhong { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayNhanPhong { get; set; }
        public DateTime NgayTraPhongDuKien { get; set; }
        public DateTime? NgayTraPhong { get; set; } // Nullable
        public decimal TongChiPhi { get; set; }
        public decimal TienDatCoc { get; set; }
        public bool TrangThaiThanhToan { get; set; }

        public DatPhongDTO(string maDatPhong, string soCCCDKhachHang, string maPhong, string maNhanVien,
            DateTime ngayDatPhong, DateTime ngayNhanPhong, DateTime ngayTraPhongDuKien, DateTime? ngayTraPhong,
            decimal tongChiPhi, decimal tienDatCoc, bool trangThaiThanhToan)
        {
            MaDatPhong = maDatPhong;
            SoCCCDKhachHang = soCCCDKhachHang;
            MaPhong = maPhong;
            MaNhanVien = maNhanVien;
            NgayDatPhong = ngayDatPhong;
            NgayNhanPhong = ngayNhanPhong;
            NgayTraPhongDuKien = ngayTraPhongDuKien;
            NgayTraPhong = ngayTraPhong;
            TongChiPhi = tongChiPhi;
            TienDatCoc = tienDatCoc;
            TrangThaiThanhToan = trangThaiThanhToan;
        }

        public DatPhongDTO(DataRow row)
        {
            MaDatPhong = row["MaDatPhong"].ToString();
            SoCCCDKhachHang = row["SoCCCDKhachHang"].ToString();
            MaPhong = row["MaPhong"].ToString();
            MaNhanVien = row["MaNhanVien"].ToString();
            NgayDatPhong = Convert.ToDateTime(row["NgayDatPhong"]);
            NgayNhanPhong = Convert.ToDateTime(row["NgayNhanPhong"]);
            NgayTraPhongDuKien = Convert.ToDateTime(row["NgayTraPhongDuKien"]);
            NgayTraPhong = row["NgayTraPhong"] != DBNull.Value ? (DateTime?)row["NgayTraPhong"] : null;
            TongChiPhi = row["TongChiPhi"] != DBNull.Value ? Convert.ToDecimal(row["TongChiPhi"]) : 0;
            TienDatCoc = row["TienDatCoc"] != DBNull.Value ? Convert.ToDecimal(row["TienDatCoc"]) : 0;
            TrangThaiThanhToan = row["TrangThaiThanhToan"] != DBNull.Value && Convert.ToBoolean(row["TrangThaiThanhToan"]);
        }
    }
}