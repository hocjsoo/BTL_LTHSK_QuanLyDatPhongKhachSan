using System;
using System.Collections.Generic;
using System.Data;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }

        private KhachHangDAO() { }

        // Lấy toàn bộ danh sách khách hàng
        public List<KhachHangDTO> GetListKhachHang()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = "SELECT * FROM KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO khachHang = new KhachHangDTO(item);
                list.Add(khachHang);
            }
            return list;
        }

        // Tìm kiếm khách hàng theo CCCD
        public List<KhachHangDTO> SearchKhachHangByCCCD(string soCCCD)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = string.Format("SELECT * FROM KhachHang WHERE SoCCCD LIKE N'%{0}%'", soCCCD);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO khachHang = new KhachHangDTO(item);
                list.Add(khachHang);
            }
            return list;
        }

        // Tìm kiếm khách hàng theo Họ tên
        public List<KhachHangDTO> SearchKhachHangByHoTen(string hoTen)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = string.Format("SELECT * FROM KhachHang WHERE HoTen LIKE N'%{0}%'", hoTen);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO khachHang = new KhachHangDTO(item);
                list.Add(khachHang);
            }
            return list;
        }

        // Thêm khách hàng
        public bool InsertKhachHang(string soCCCD, string hoTen, string soDienThoai, string email)
        {
            string query = string.Format("INSERT INTO KhachHang (SoCCCD, HoTen, SoDienThoai, Email) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')",
                soCCCD, hoTen, soDienThoai, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Sửa khách hàng
        public bool UpdateKhachHang(string soCCCD, string hoTen, string soDienThoai, string email)
        {
            string query = string.Format("UPDATE KhachHang SET HoTen = N'{0}', SoDienThoai = N'{1}', Email = N'{2}' WHERE SoCCCD = N'{3}'",
                hoTen, soDienThoai, email, soCCCD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Xóa khách hàng
        public bool DeleteKhachHang(string soCCCD)
        {
            // Kiểm tra tính toàn vẹn dữ liệu trước khi xóa
            string checkQuery = string.Format("SELECT COUNT(*) FROM DatPhong WHERE SoCCCDKhachHang = N'{0}' UNION ALL SELECT COUNT(*) FROM DangKyDichVu WHERE SoCCCDKhachHang = N'{0}'", soCCCD);
            DataTable checkData = DataProvider.Instance.ExecuteQuery(checkQuery);
            int totalCount = 0;
            foreach (DataRow row in checkData.Rows)
            {
                totalCount += Convert.ToInt32(row[0]);
            }

            if (totalCount > 0)
            {
                throw new Exception("Không thể xóa khách hàng vì khách hàng đã có giao dịch (đặt phòng hoặc dịch vụ)!");
            }

            string query = string.Format("DELETE FROM KhachHang WHERE SoCCCD = N'{0}'", soCCCD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}