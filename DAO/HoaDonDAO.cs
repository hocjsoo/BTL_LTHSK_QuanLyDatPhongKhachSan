using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        private HoaDonDAO() { }

        // Lấy danh sách hóa đơn
        public List<HoaDonDTO> GetListHoaDon()
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string query = "SELECT * FROM HoaDon";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new HoaDonDTO(row));
            }
            return list;
        }

        // Lấy hóa đơn theo MaHoaDon
        public HoaDonDTO GetHoaDonByMaHoaDon(string maHoaDon)
        {
            string query = $"SELECT * FROM HoaDon WHERE MaHoaDon = N'{maHoaDon}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return new HoaDonDTO(data.Rows[0]);
            }
            return null;
        }

        // Thêm hóa đơn mới
        public bool InsertHoaDon(HoaDonDTO hoaDon)
        {
            try
            {
                string query = $"INSERT INTO HoaDon (MaHoaDon, SoCCCDKhachHang, MaNhanVien, TongChiPhi, TienThanhToan, " +
                              $"PhuongThucThanhToan, NgayLapHoaDon) " +
                              $"VALUES (N'{hoaDon.MaHoaDon}', N'{hoaDon.SoCCCDKhachHang}', N'{hoaDon.MaNhanVien}', {hoaDon.TongChiPhi}, {hoaDon.TienThanhToan}, " +
                              $"N'{hoaDon.PhuongThucThanhToan}', '{hoaDon.NgayLapHoaDon:yyyy-MM-dd HH:mm:ss}')";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thêm chi tiết hóa đơn
        public bool InsertChiTietHoaDon(ChiTietHoaDonDTO chiTiet)
        {
            try
            {
                string query = $"INSERT INTO ChiTietHoaDon (MaChiTietHoaDon, MaHoaDon, MaDichVu, SoLuong, TongChiPhi) " +
                              $"VALUES (N'{chiTiet.MaChiTietHoaDon}', N'{chiTiet.MaHoaDon}', N'{chiTiet.MaDichVu}', {chiTiet.SoLuong}, {chiTiet.TongChiPhi})";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Tìm kiếm hóa đơn theo mã và khoảng thời gian
        public List<HoaDonDTO> SearchHoaDon(string maHoaDon, DateTime tuNgay, DateTime denNgay)
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string query = $"SELECT * FROM HoaDon WHERE NgayLapHoaDon BETWEEN '{tuNgay:yyyy-MM-dd}' AND '{denNgay:yyyy-MM-dd}'";
            if (!string.IsNullOrEmpty(maHoaDon))
            {
                query += $" AND MaHoaDon = N'{maHoaDon}'";
            }
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new HoaDonDTO(row));
            }
            return list;
        }

        // Lấy danh sách dịch vụ theo MaHoaDon
        public DataTable GetDichVuByMaHoaDon(string maHoaDon)
        {
            string query = $"SELECT cthd.MaDichVu, dv.TenDichVu, cthd.SoLuong, cthd.TongChiPhi " +
                          $"FROM ChiTietHoaDon cthd " +
                          $"JOIN DichVu dv ON cthd.MaDichVu = dv.MaDichVu " +
                          $"WHERE cthd.MaHoaDon = N'{maHoaDon}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}