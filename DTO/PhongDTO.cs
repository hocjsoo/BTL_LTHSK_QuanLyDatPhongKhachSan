using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class PhongDTO
    {
        public string MaPhong { get; set; }
        public string LoaiPhong { get; set; }
        public decimal GiaPhong { get; set; }
        public string TrangThai { get; set; }

        public PhongDTO(string maPhong, string loaiPhong, decimal giaPhong, string trangThai)
        {
            MaPhong = maPhong;
            LoaiPhong = loaiPhong;
            GiaPhong = giaPhong;
            TrangThai = trangThai;
        }

        public PhongDTO(DataRow row)
        {
            MaPhong = row["MaPhong"].ToString();
            LoaiPhong = row["LoaiPhong"].ToString();
            GiaPhong = Convert.ToDecimal(row["GiaPhong"]);
            TrangThai = row["TrangThai"].ToString();
        }
    }
}