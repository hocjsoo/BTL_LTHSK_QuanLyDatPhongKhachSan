using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        private NhanVienDAO() { }

        // Lấy toàn bộ danh sách nhân viên
        public List<NhanVienDTO> GetListNhanVien()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string query = "SELECT * FROM NhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO nhanVien = new NhanVienDTO(item);
                list.Add(nhanVien);
            }
            return list;
        }

        // Tìm kiếm nhân viên theo họ tên
        public List<NhanVienDTO> SearchNhanVienByHoTen(string hoTen)
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string query = string.Format("SELECT * FROM NhanVien WHERE HoTen LIKE N'%{0}%'", hoTen);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO nhanVien = new NhanVienDTO(item);
                list.Add(nhanVien);
            }
            return list;
        }

        // Thêm nhân viên
        public bool InsertNhanVien(string maNhanVien, string hoTen, string soDienThoai, string email,
                                   string vaiTro, DateTime ngayVaoLam, string gioiTinh, string soCCCD, string diaChi)
        {
            string ngayVaoLamStr = ngayVaoLam.ToString("yyyy-MM-dd HH:mm:ss");
            string query = string.Format("INSERT INTO NhanVien (MaNhanVien, HoTen, SoDienThoai, Email, VaiTro, NgayVaoLam, GioiTinh, SoCCCD, DiaChi) " +
                                        "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', '{5}', N'{6}', N'{7}', N'{8}')",
                maNhanVien, hoTen, soDienThoai, email, vaiTro, ngayVaoLamStr, gioiTinh, soCCCD, diaChi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Sửa nhân viên
        public bool UpdateNhanVien(string maNhanVien, string hoTen, string soDienThoai, string email,
                                   string vaiTro, DateTime ngayVaoLam, string gioiTinh, string soCCCD, string diaChi)
        {
            string ngayVaoLamStr = ngayVaoLam.ToString("yyyy-MM-dd HH:mm:ss");
            string query = string.Format("UPDATE NhanVien SET HoTen = N'{0}', SoDienThoai = N'{1}', Email = N'{2}', VaiTro = N'{3}', " +
                                        "NgayVaoLam = '{4}', GioiTinh = N'{5}', SoCCCD = N'{6}', DiaChi = N'{7}' WHERE MaNhanVien = N'{8}'",
                hoTen, soDienThoai, email, vaiTro, ngayVaoLamStr, gioiTinh, soCCCD, diaChi, maNhanVien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Xóa nhân viên
        public bool DeleteNhanVien(string maNhanVien)
        {
            string checkQuery = string.Format("SELECT COUNT(*) FROM TaiKhoan WHERE MaNhanVien = N'{0}' UNION ALL " +
                                              "SELECT COUNT(*) FROM DatPhong WHERE MaNhanVien = N'{0}' UNION ALL " +
                                              "SELECT COUNT(*) FROM DangKyDichVu WHERE MaNhanVien = N'{0}' UNION ALL " +
                                              "SELECT COUNT(*) FROM HoaDon WHERE MaNhanVien = N'{0}'", maNhanVien);
            DataTable checkData = DataProvider.Instance.ExecuteQuery(checkQuery);
            int totalCount = 0;
            foreach (DataRow row in checkData.Rows)
            {
                totalCount += Convert.ToInt32(row[0]);
            }

            if (totalCount > 0)
            {
                throw new Exception("Không thể xóa nhân viên vì nhân viên đã có giao dịch hoặc tài khoản liên quan!");
            }

            string query = string.Format("DELETE FROM NhanVien WHERE MaNhanVien = N'{0}'", maNhanVien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Lấy thông tin nhân viên theo MaNhanVien
        public NhanVienDTO GetNhanVienByMaNhanVien(string maNhanVien)
        {
            string query = string.Format("SELECT * FROM NhanVien WHERE MaNhanVien = N'{0}'", maNhanVien);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                return new NhanVienDTO(data.Rows[0]);
            }
            return null;
        }
    }
}