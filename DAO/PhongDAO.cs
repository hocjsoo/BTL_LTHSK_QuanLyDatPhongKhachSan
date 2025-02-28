using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using BTL_QL_Dat_Phong_Khach_San.DAO;
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

        // Lấy toàn bộ danh sách phòng
        public List<PhongDTO> GetListPhong()
        {
            List<PhongDTO> list = new List<PhongDTO>();
            string query = "SELECT * FROM Phong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PhongDTO phong = new PhongDTO(item);
                list.Add(phong);
            }
            return list;
        }

        // Tìm kiếm phòng theo mã, loại, giá, tầng, và trạng thái
        public List<PhongDTO> SearchPhong(string maPhong, string loaiPhong, decimal? giaTu, decimal? giaDen, int? tang, string trangThai)
        {
            List<PhongDTO> list = new List<PhongDTO>();
            string query = "SELECT * FROM Phong WHERE 1=1";

            if (!string.IsNullOrEmpty(maPhong))
                query += string.Format(" AND MaPhong LIKE N'%{0}%'", maPhong);
            if (!string.IsNullOrEmpty(loaiPhong))
                query += string.Format(" AND LoaiPhong = N'{0}'", loaiPhong);
            if (giaTu.HasValue)
                query += string.Format(" AND GiaPhong >= {0}", giaTu.Value.ToString("F2", CultureInfo.InvariantCulture));
            if (giaDen.HasValue)
                query += string.Format(" AND GiaPhong <= {0}", giaDen.Value.ToString("F2", CultureInfo.InvariantCulture));
            if (tang.HasValue)
                query += string.Format(" AND Tang = {0}", tang.Value);
            if (!string.IsNullOrEmpty(trangThai))
                query += string.Format(" AND TrangThai = N'{0}'", trangThai);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                PhongDTO phong = new PhongDTO(item);
                list.Add(phong);
            }
            return list;
        }

        // Thêm phòng
        public bool InsertPhong(string maPhong, string loaiPhong, decimal giaPhong, int tang, string trangThai)
        {
            string giaPhongStr = giaPhong.ToString("F2", CultureInfo.InvariantCulture);
            string query = string.Format("INSERT INTO Phong (MaPhong, LoaiPhong, GiaPhong, Tang, TrangThai) VALUES (N'{0}', N'{1}', {2}, {3}, N'{4}')",
                maPhong, loaiPhong, giaPhongStr, tang, trangThai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Sửa phòng
        public bool UpdatePhong(string maPhong, string loaiPhong, decimal giaPhong, int tang, string trangThai)
        {
            string giaPhongStr = giaPhong.ToString("F2", CultureInfo.InvariantCulture);
            string query = string.Format("UPDATE Phong SET LoaiPhong = N'{0}', GiaPhong = {1}, Tang = {2}, TrangThai = N'{3}' WHERE MaPhong = N'{4}'",
                loaiPhong, giaPhongStr, tang, trangThai, maPhong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Xóa phòng
        public bool DeletePhong(string maPhong)
        {
            string checkQuery = string.Format("SELECT COUNT(*) FROM DatPhong WHERE MaPhong = N'{0}'", maPhong);
            object resultCheck = DataProvider.Instance.ExecuteScalar(checkQuery);
            int count = Convert.ToInt32(resultCheck);

            if (count > 0)
            {
                throw new Exception("Không thể xóa phòng vì phòng đã được đặt!");
            }

            string query = string.Format("DELETE FROM Phong WHERE MaPhong = N'{0}'", maPhong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Lấy thông tin phòng theo MaPhong
        public PhongDTO GetPhongByMaPhong(string maPhong)
        {
            string query = string.Format("SELECT * FROM Phong WHERE MaPhong = N'{0}'", maPhong);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                return new PhongDTO(data.Rows[0]);
            }
            return null;
        }
    }
}