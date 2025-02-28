using System;
using System.Data;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class KhachHangDTO
    {
        public string SoCCCD { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime NgayTao { get; set; }

        // Constructor nhận các tham số riêng lẻ
        public KhachHangDTO(string soCCCD, string hoTen, string soDienThoai, string email, DateTime ngayTao)
        {
            SoCCCD = soCCCD;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            Email = email;
            NgayTao = ngayTao;
        }

        // Constructor nhận DataRow (giống FoodDAO)
        public KhachHangDTO(DataRow row)
        {
            SoCCCD = row["SoCCCD"].ToString();
            HoTen = row["HoTen"].ToString();
            SoDienThoai = row["SoDienThoai"].ToString();
            Email = row["Email"].ToString();
            NgayTao = Convert.ToDateTime(row["NgayTao"]);
        }
    }
}