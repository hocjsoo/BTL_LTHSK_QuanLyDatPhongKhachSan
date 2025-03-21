using System;
using System.Collections.Generic;
using System.Data;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;

        public static DichVuDAO Instance
        {
            get { if (instance == null) instance = new DichVuDAO(); return instance; }
            private set { instance = value; }
        }

        private DichVuDAO() { }

        public List<DichVuDTO> GetListDichVu()
        {
            List<DichVuDTO> list = new List<DichVuDTO>();
            string query = "SELECT * FROM DichVu";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DichVuDTO(row));
            }
            return list;
        }

        public List<DichVuDTO> SearchDichVu(string maDichVu, string tenDichVu)
        {
            List<DichVuDTO> list = new List<DichVuDTO>();
            string query = "SELECT * FROM DichVu WHERE 1=1";
            if (!string.IsNullOrEmpty(maDichVu)) query += $" AND MaDichVu LIKE N'%{maDichVu}%'";
            if (!string.IsNullOrEmpty(tenDichVu)) query += $" AND TenDichVu LIKE N'%{tenDichVu}%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DichVuDTO(row));
            }
            return list;
        }

        public bool InsertDichVu(string maDichVu, string tenDichVu, decimal giaDichVu, string loaiDichVu)
        {
            string query = $"INSERT INTO DichVu (MaDichVu, TenDichVu, GiaDichVu, LoaiDichVu) " +
                          $"VALUES (N'{maDichVu}', N'{tenDichVu}', {giaDichVu}, N'{loaiDichVu}')";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateDichVu(string maDichVu, string tenDichVu, decimal giaDichVu, string loaiDichVu)
        {
            string query = $"UPDATE DichVu SET TenDichVu = N'{tenDichVu}', GiaDichVu = {giaDichVu}, LoaiDichVu = N'{loaiDichVu}' " +
                          $"WHERE MaDichVu = N'{maDichVu}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteDichVu(string maDichVu)
        {
            string checkQuery = $"SELECT COUNT(*) FROM DangKyDichVu WHERE MaDichVu = N'{maDichVu}'";
            if (Convert.ToInt32(DataProvider.Instance.ExecuteScalar(checkQuery)) > 0) return false;

            string query = $"DELETE FROM DichVu WHERE MaDichVu = N'{maDichVu}'";
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}