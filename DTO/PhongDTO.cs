using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class PhongDTO
    {
        public string MaPhong { get; set; }
        public string LoaiPhong { get; set; }
        public decimal GiaPhong { get; set; }
        public int Tang { get; set; }
        public string TrangThai { get; set; }

        public PhongDTO(string maPhong, string loaiPhong, decimal giaPhong, int tang, string trangThai)
        {
            MaPhong = maPhong;
            LoaiPhong = loaiPhong;
            GiaPhong = giaPhong;
            Tang = tang;
            TrangThai = trangThai;
        }

        // Constructor nhận DataRow
        public PhongDTO(DataRow row)
        {
            MaPhong = row["MaPhong"].ToString();
            LoaiPhong = row["LoaiPhong"].ToString();
            GiaPhong = Convert.ToDecimal(row["GiaPhong"]);
            Tang = Convert.ToInt32(row["Tang"]);
            TrangThai = row["TrangThai"].ToString();
        }
    }
}