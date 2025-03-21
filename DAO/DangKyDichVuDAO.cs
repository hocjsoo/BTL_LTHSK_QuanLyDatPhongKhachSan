using System;
using System.Collections.Generic;
using System.Data;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class DangKyDichVuDAO
    {
        private static DangKyDichVuDAO instance;

        public static DangKyDichVuDAO Instance
        {
            get { if (instance == null) instance = new DangKyDichVuDAO(); return instance; }
            private set { instance = value; }
        }

        private DangKyDichVuDAO() { }

        public List<DangKyDichVuDTO> GetDichVuByKhachHang(string soCCCDKhachHang)
        {
            List<DangKyDichVuDTO> list = new List<DangKyDichVuDTO>();
            string query = $"SELECT * FROM DangKyDichVu WHERE SoCCCDKhachHang = N'{soCCCDKhachHang}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                string maDichVu = row["MaDichVu"].ToString();
                string maNhanVien = row["MaNhanVien"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal tongChiPhi = Convert.ToDecimal(row["TongChiPhi"]);
                DateTime ngayDangKy = Convert.ToDateTime(row["NgayDangKy"]);
                list.Add(new DangKyDichVuDTO(soCCCDKhachHang, maDichVu, maNhanVien, soLuong, tongChiPhi, ngayDangKy));
            }
            return list;
        }

        public bool InsertDangKyDichVu(string soCCCDKhachHang, string maDichVu, string maNhanVien, int soLuong)
        {
            // Kiểm tra dữ liệu đầu vào để tránh lỗi SQL Injection cơ bản
            if (soCCCDKhachHang.Contains("'") || maDichVu.Contains("'") || maNhanVien.Contains("'"))
            {
                System.Windows.Forms.MessageBox.Show("Dữ liệu đầu vào chứa ký tự không hợp lệ!", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            // Lấy giá dịch vụ
            string queryGia = $"SELECT GiaDichVu FROM DichVu WHERE MaDichVu = N'{maDichVu}'";
            object giaObj = DataProvider.Instance.ExecuteScalar(queryGia);
            if (giaObj == null)
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy dịch vụ!", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            decimal giaDichVu = Convert.ToDecimal(giaObj);
            decimal tongChiPhi = giaDichVu * soLuong;

            // Định dạng tongChiPhi để đảm bảo dùng dấu . thay vì dấu , (phù hợp với SQL Server)
            string tongChiPhiFormatted = tongChiPhi.ToString(System.Globalization.CultureInfo.InvariantCulture);

            // Tạo câu lệnh INSERT
            string query = $"INSERT INTO DangKyDichVu (SoCCCDKhachHang, MaDichVu, MaNhanVien, SoLuong, TongChiPhi, NgayDangKy) " +
                          $"VALUES (N'{soCCCDKhachHang}', N'{maDichVu}', N'{maNhanVien}', {soLuong}, {tongChiPhiFormatted}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";

            try
            {
                int rowsAffected = DataProvider.Instance.ExecuteNonQuery(query);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi thêm dịch vụ: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteDangKyDichVu(string soCCCDKhachHang, string maDichVu)
        {
            string query = $"DELETE FROM DangKyDichVu WHERE SoCCCDKhachHang = N'{soCCCDKhachHang}' AND MaDichVu = N'{maDichVu}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}