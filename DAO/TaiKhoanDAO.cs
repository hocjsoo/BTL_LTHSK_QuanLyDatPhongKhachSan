using System;
using System.Collections.Generic;
using System.Data;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set { instance = value; }
        }

        private TaiKhoanDAO() { }

        // Lấy toàn bộ danh sách tài khoản
        public List<TaiKhoanDTO> GetListTaiKhoan()
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            string query = "SELECT * FROM TaiKhoan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO(item);
                list.Add(taiKhoan);
            }
            return list;
        }

        // Tìm kiếm tài khoản theo tên đăng nhập
        public List<TaiKhoanDTO> SearchTaiKhoanByTenDangNhap(string tenDangNhap)
        {
            List<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            string query = string.Format("SELECT * FROM TaiKhoan WHERE TenDangNhap LIKE N'%{0}%'", tenDangNhap);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO(item);
                list.Add(taiKhoan);
            }
            return list;
        }

        // Thêm tài khoản
        public bool InsertTaiKhoan(string tenDangNhap, string matKhau, string maNhanVien)
        {
            string query = string.Format("INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNhanVien) VALUES (N'{0}', N'{1}', N'{2}')",
                tenDangNhap, matKhau, maNhanVien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Sửa tài khoản
        public bool UpdateTaiKhoan(string tenDangNhap, string matKhau, string maNhanVien)
        {
            string query = string.Format("UPDATE TaiKhoan SET MatKhau = N'{0}', MaNhanVien = N'{1}' WHERE TenDangNhap = N'{2}'",
                matKhau, maNhanVien, tenDangNhap);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Xóa tài khoản
        public bool DeleteTaiKhoan(string tenDangNhap)
        {
            string query = string.Format("DELETE FROM TaiKhoan WHERE TenDangNhap = N'{0}'", tenDangNhap);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Lấy thông tin tài khoản theo TenDangNhap
        public TaiKhoanDTO GetTaiKhoanByTenDangNhap(string tenDangNhap)
        {
            string query = string.Format("SELECT * FROM TaiKhoan WHERE TenDangNhap = N'{0}'", tenDangNhap);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                return new TaiKhoanDTO(data.Rows[0]);
            }
            return null;
        }

        // Xác thực đăng nhập
        public TaiKhoanDTO Login(string tenDangNhap, string matKhau)
        {
            string query = string.Format("SELECT * FROM TaiKhoan WHERE TenDangNhap = N'{0}' AND MatKhau = N'{1}'", tenDangNhap, matKhau);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                return new TaiKhoanDTO(data.Rows[0]);
            }
            return null;
        }
    }
}