using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string MaNhanVien { get; set; }

        public TaiKhoanDTO(string tenDangNhap, string matKhau, string maNhanVien)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaNhanVien = maNhanVien;
        }

        // Constructor nhận DataRow
        public TaiKhoanDTO(DataRow row)
        {
            TenDangNhap = row["TenDangNhap"].ToString();
            MatKhau = row["MatKhau"].ToString();
            MaNhanVien = row["MaNhanVien"].ToString();
        }
    }
}