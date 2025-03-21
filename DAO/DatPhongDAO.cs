using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class DatPhongDAO
    {
        private static DatPhongDAO instance;

        public static DatPhongDAO Instance
        {
            get { if (instance == null) instance = new DatPhongDAO(); return instance; }
            private set { instance = value; }
        }

        private DatPhongDAO() { }

        public List<DatPhongDTO> GetListDatPhongByKhachHang(string soCCCD)
        {
            List<DatPhongDTO> list = new List<DatPhongDTO>();
            string query = "SELECT * FROM DatPhong WHERE SoCCCDKhachHang = @SoCCCD";
            object[] parameters = new object[] { soCCCD };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DatPhongDTO(row));
            }
            return list;
        }

        public bool InsertDatPhong(string maDatPhong, string soCCCDKhachHang, string maPhong, string maNhanVien,
            DateTime ngayDatPhong, DateTime ngayNhanPhong, DateTime ngayTraPhongDuKien, DateTime? ngayTraPhong,
            decimal tongChiPhi, decimal tienDatCoc)
        {
            try
            {
                // Sử dụng chuỗi thô với giá trị chèn trực tiếp
                string ngayTraPhongValue = ngayTraPhong.HasValue ? $"'{ngayTraPhong.Value:yyyy-MM-dd HH:mm:ss}'" : "NULL";
                string query = $"INSERT INTO DatPhong (MaDatPhong, SoCCCDKhachHang, MaPhong, MaNhanVien, NgayDatPhong, " +
                              $"NgayNhanPhong, NgayTraPhongDuKien, NgayTraPhong, TongChiPhi, TienDatCoc, TrangThaiThanhToan) " +
                              $"VALUES (N'{maDatPhong}', N'{soCCCDKhachHang}', N'{maPhong}', N'{maNhanVien}', " +
                              $"'{ngayDatPhong:yyyy-MM-dd HH:mm:ss}', '{ngayNhanPhong:yyyy-MM-dd HH:mm:ss}', " +
                              $"'{ngayTraPhongDuKien:yyyy-MM-dd HH:mm:ss}', {ngayTraPhongValue}, {tongChiPhi}, {tienDatCoc}, 0)";

                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateTrangThaiThanhToan(string maDatPhong, bool trangThaiThanhToan, DateTime? ngayTraPhong = null)
        {
            try
            {
                string query = "UPDATE DatPhong SET TrangThaiThanhToan = @TrangThaiThanhToan";
                if (ngayTraPhong.HasValue)
                {
                    query += " , NgayTraPhong = @NgayTraPhong";
                }
                query += " WHERE MaDatPhong = @MaDatPhong";

                object[] parameters;
                if (ngayTraPhong.HasValue)
                {
                    parameters = new object[] { trangThaiThanhToan, ngayTraPhong.Value, maDatPhong };
                }
                else
                {
                    parameters = new object[] { trangThaiThanhToan, maDatPhong };
                }

                return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi cập nhật trạng thái thanh toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CancelDatPhong(string maDatPhong, string maPhong)
        {
            try
            {
                string query = "DELETE FROM DatPhong WHERE MaDatPhong = @MaDatPhong AND MaPhong = @MaPhong";
                object[] parameters = new object[] { maDatPhong, maPhong };
                return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi hủy đặt phòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}