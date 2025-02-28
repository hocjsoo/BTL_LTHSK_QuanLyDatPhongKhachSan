using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string GioiTinh { get; set; }
        public string SoCCCD { get; set; }
        public string DiaChi { get; set; }

        public NhanVienDTO(string maNhanVien, string hoTen, string soDienThoai, string email, string vaiTro,
                           DateTime ngayVaoLam, string gioiTinh, string soCCCD, string diaChi)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            Email = email;
            VaiTro = vaiTro;
            NgayVaoLam = ngayVaoLam;
            GioiTinh = gioiTinh;
            SoCCCD = soCCCD;
            DiaChi = diaChi;
        }

        // Constructor nhận DataRow
        public NhanVienDTO(DataRow row)
        {
            MaNhanVien = row["MaNhanVien"].ToString();
            HoTen = row["HoTen"].ToString();
            SoDienThoai = row["SoDienThoai"].ToString();
            Email = row["Email"].ToString();
            VaiTro = row["VaiTro"].ToString();
            NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]);
            GioiTinh = row["GioiTinh"].ToString();
            SoCCCD = row["SoCCCD"].ToString();
            DiaChi = row["DiaChi"].ToString();
        }
    }
}