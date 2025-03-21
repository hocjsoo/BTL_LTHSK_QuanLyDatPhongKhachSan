using System;
using System.Collections.Generic;
using System.Data;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class PhongDAO
    {
        private static PhongDAO instance;

        public static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return instance; }
            private set { instance = value; }
        }

        private PhongDAO() { }

        public List<PhongDTO> GetListPhong()
        {
            List<PhongDTO> list = new List<PhongDTO>();
            string query = "SELECT * FROM Phong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new PhongDTO(row));
            }
            return list;
        }

        public List<PhongDTO> SearchPhong(string maPhong, string loaiPhong, string trangThai, int? tang = null, decimal? giaTu = null, decimal? giaDen = null)
        {
            List<PhongDTO> list = new List<PhongDTO>();
            string query = "SELECT * FROM Phong WHERE 1=1";
            if (!string.IsNullOrEmpty(maPhong))
                query += $" AND MaPhong LIKE N'%{maPhong}%'";
            if (!string.IsNullOrEmpty(loaiPhong) && loaiPhong != "")
                query += $" AND LoaiPhong = N'{loaiPhong}'";
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "")
                query += $" AND TrangThai = N'{trangThai}'";
            if (tang.HasValue && tang != 0)
                query += $" AND MaPhong LIKE N'P{tang}%'";
            if (giaTu.HasValue)
                query += $" AND GiaPhong >= {giaTu}";
            if (giaDen.HasValue)
                query += $" AND GiaPhong <= {giaDen}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new PhongDTO(row));
            }
            return list;
        }

        public List<PhongDTO> SearchPhong(string maPhong, string loaiPhong, string trangThai)
        {
            return SearchPhong(maPhong, loaiPhong, trangThai, null, null, null);
        }

        public bool InsertPhong(PhongDTO phong)
        {
            try
            {
                string query = $"INSERT INTO Phong (MaPhong, LoaiPhong, GiaPhong, TrangThai) " +
                              $"VALUES (N'{phong.MaPhong}', N'{phong.LoaiPhong}', {phong.GiaPhong}, N'{phong.TrangThai}')";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi thêm phòng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdatePhong(string oldMaPhong, PhongDTO phong)
        {
            try
            {
                string query = $"UPDATE Phong SET MaPhong = N'{phong.MaPhong}', LoaiPhong = N'{phong.LoaiPhong}', " +
                              $"GiaPhong = {phong.GiaPhong}, TrangThai = N'{phong.TrangThai}' " +
                              $"WHERE MaPhong = N'{oldMaPhong}'";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi sửa phòng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateTrangThaiPhong(string maPhong, string trangThai)
        {
            try
            {
                string query = $"UPDATE Phong SET TrangThai = N'{trangThai}' WHERE MaPhong = N'{maPhong}'";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi cập nhật trạng thái phòng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeletePhong(string maPhong)
        {
            try
            {
                string query = $"DELETE FROM Phong WHERE MaPhong = N'{maPhong}'";
                return DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi khi xóa phòng: {ex.Message}", "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckPhongExists(string maPhong)
        {
            string query = $"SELECT COUNT(*) FROM Phong WHERE MaPhong = N'{maPhong}'";
            return (int)DataProvider.Instance.ExecuteScalar(query) > 0;
        }

        public bool CheckPhongInUse(string maPhong)
        {
            string query = $"SELECT COUNT(*) FROM DatPhong WHERE MaPhong = N'{maPhong}' AND NgayTraPhong > GETDATE()";
            return (int)DataProvider.Instance.ExecuteScalar(query) > 0;
        }
    }
}