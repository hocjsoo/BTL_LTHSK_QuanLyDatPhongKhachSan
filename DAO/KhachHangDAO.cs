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

        public List<KhachHangDTO> SearchKhachHang(string soCCCD, string hoTen)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = "SELECT * FROM KhachHang WHERE 1=1";
            List<object> parameters = new List<object>();

            if (!string.IsNullOrEmpty(soCCCD))
            {
                query += " AND SoCCCD LIKE N'%' + @SoCCCD + '%'";
                parameters.Add(soCCCD);
            }
            if (!string.IsNullOrEmpty(hoTen))
            {
                query += " AND HoTen LIKE N'%' + @HoTen + '%'";
                parameters.Add(hoTen);
            }

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters.ToArray());
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
                string query = $"INSERT INTO KhachHang (SoCCCD, HoTen, SoDienThoai, Email, NgayTao) " +
                              $"VALUES (N'{khachHang.SoCCCD}', N'{khachHang.HoTen}', N'{khachHang.SoDienThoai}', " +
                              $"'{khachHang.Email}', '{khachHang.NgayTao:yyyy-MM-dd HH:mm:ss}')";
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
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(khachHang.SoCCCD) || string.IsNullOrEmpty(khachHang.HoTen) || string.IsNullOrEmpty(khachHang.SoDienThoai))
                {
                    throw new Exception("Số CCCD, Họ tên, Số điện thoại không được để trống!");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(khachHang.SoCCCD, @"^\d+$"))
                {
                    throw new Exception("Số CCCD chỉ được chứa số!");
                }

                if (khachHang.HoTen.Contains("'") || khachHang.HoTen.Contains(";"))
                {
                    throw new Exception("Họ tên không được chứa ký tự đặc biệt như ' hoặc ;!");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(khachHang.SoDienThoai, @"^\d+$"))
                {
                    throw new Exception("Số điện thoại chỉ được chứa số!");
                }

                if (!string.IsNullOrEmpty(khachHang.Email) && (khachHang.Email.Contains("'") || khachHang.Email.Contains(";")))
                {
                    throw new Exception("Email không được chứa ký tự đặc biệt như ' hoặc ;!");
                }

                if (string.IsNullOrEmpty(oldSoCCCD))
                {
                    throw new Exception("Số CCCD cũ không được để trống!");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(oldSoCCCD, @"^\d+$"))
                {
                    throw new Exception("Số CCCD cũ chỉ được chứa số!");
                }

                string query = $"UPDATE KhachHang SET " +
                              $"SoCCCD = N'{khachHang.SoCCCD}', " +
                              $"HoTen = N'{khachHang.HoTen}', " +
                              $"SoDienThoai = N'{khachHang.SoDienThoai}', " +
                              $"Email = '{khachHang.Email}' " +
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
                string query = "DELETE FROM KhachHang WHERE SoCCCD=@SoCCCD";
                object[] parameters = new object[] { soCCCD };
                return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
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
            string query = "SELECT COUNT(*) FROM DatPhong WHERE SoCCCDKhachHang=@SoCCCDKhachHang UNION ALL SELECT COUNT(*) FROM HoaDon WHERE SoCCCDKhachHang=@SoCCCDKhachHang";
            object[] parameters = new object[] { soCCCD, soCCCD };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
            foreach (DataRow row in data.Rows)
            {
                if ((int)row[0] > 0)
                    return true;
            }
            return false;
        }
    }
}