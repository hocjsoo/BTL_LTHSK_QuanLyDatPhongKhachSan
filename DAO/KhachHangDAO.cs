using System;
using System.Collections.Generic;
using System.Data;
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

        public List<KhachHangDTO> GetListKhachHang()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = "SELECT * FROM KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new KhachHangDTO(row));
            }
            return list;
        }

        public List<KhachHangDTO> SearchKhachHang(string soCCCD, string hoTen, string soDienThoai, string email)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = "SELECT * FROM KhachHang WHERE 1=1";
            if (!string.IsNullOrEmpty(soCCCD))
                query += $" AND SoCCCD LIKE N'%{soCCCD}%'";
            if (!string.IsNullOrEmpty(hoTen))
                query += $" AND HoTen LIKE N'%{hoTen}%'";
            if (!string.IsNullOrEmpty(soDienThoai))
                query += $" AND SoDienThoai LIKE N'%{soDienThoai}%'";
            if (!string.IsNullOrEmpty(email))
                query += $" AND Email LIKE N'%{email}%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new KhachHangDTO(row));
            }
            return list;
        }

        public bool InsertKhachHang(KhachHangDTO khachHang)
        {
            try
            {
                string ngayTaoFormatted = khachHang.NgayTao.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"INSERT INTO KhachHang (SoCCCD, HoTen, SoDienThoai, Email, NgayTao) " +
                              $"VALUES (N'{khachHang.SoCCCD}', N'{khachHang.HoTen}', N'{khachHang.SoDienThoai}', " +
                              $"N'{khachHang.Email}', '{ngayTaoFormatted}')";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateKhachHang(string oldSoCCCD, KhachHangDTO khachHang)
        {
            try
            {
                string query = $"UPDATE KhachHang SET SoCCCD = N'{khachHang.SoCCCD}', HoTen = N'{khachHang.HoTen}', " +
                              $"SoDienThoai = N'{khachHang.SoDienThoai}', Email = N'{khachHang.Email}' " +
                              $"WHERE SoCCCD = N'{oldSoCCCD}'";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi sửa khách hàng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteKhachHang(string soCCCD)
        {
            try
            {
                string query = $"DELETE FROM KhachHang WHERE SoCCCD = N'{soCCCD}'";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckKhachHangExists(string soCCCD)
        {
            string query = $"SELECT COUNT(*) FROM KhachHang WHERE SoCCCD = N'{soCCCD}'";
            return (int)DataProvider.Instance.ExecuteScalar(query) > 0;
        }

        public bool CheckKhachHangInUse(string soCCCD)
        {
            string query = $"SELECT COUNT(*) FROM DatPhong WHERE SoCCCDKhachHang = N'{soCCCD}' " +
                          $"UNION ALL " +
                          $"SELECT COUNT(*) FROM HoaDon WHERE SoCCCDKhachHang = N'{soCCCD}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                if ((int)row[0] > 0)
                    return true;
            }
            return false;
        }
    }
}