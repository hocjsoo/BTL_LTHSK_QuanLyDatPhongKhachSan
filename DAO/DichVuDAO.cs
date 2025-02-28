using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using BTL_QL_Dat_Phong_Khach_San.DAO;
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

            foreach (DataRow item in data.Rows)
            {
                DichVuDTO dichVu = new DichVuDTO(item);
                list.Add(dichVu);
            }
            return list;
        }

        public List<string> GetListLoaiDichVu()
        {
            List<string> list = new List<string>();
            string query = "SELECT DISTINCT LoaiDichVu FROM DichVu";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                list.Add(item["LoaiDichVu"].ToString());
            }
            return list;
        }

        public List<DichVuDTO> SearchDichVuByName(string tenDichVu)
        {
            List<DichVuDTO> list = new List<DichVuDTO>();
            string query = string.Format("SELECT * FROM DichVu WHERE TenDichVu LIKE N'%{0}%'", tenDichVu);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DichVuDTO dichVu = new DichVuDTO(item);
                list.Add(dichVu);
            }
            return list;
        }

        public List<DichVuDTO> SearchDichVuByLoai(string loaiDichVu)
        {
            List<DichVuDTO> list = new List<DichVuDTO>();
            string query = string.Format("SELECT * FROM DichVu WHERE LoaiDichVu = N'{0}'", loaiDichVu);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DichVuDTO dichVu = new DichVuDTO(item);
                list.Add(dichVu);
            }
            return list;
        }

        public bool InsertDichVu(string maDichVu, string tenDichVu, decimal giaDichVu, string loaiDichVu)
        {
            string giaDichVuStr = giaDichVu.ToString("F2", CultureInfo.InvariantCulture); // Chuyển decimal thành chuỗi với dấu chấm
            string query = string.Format("INSERT INTO DichVu (MaDichVu, TenDichVu, GiaDichVu, LoaiDichVu) VALUES (N'{0}', N'{1}', {2}, N'{3}')",
                maDichVu, tenDichVu, giaDichVuStr, loaiDichVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateDichVu(string maDichVu, string tenDichVu, decimal giaDichVu, string loaiDichVu)
        {
            string giaDichVuStr = giaDichVu.ToString("F2", CultureInfo.InvariantCulture); // Chuyển decimal thành chuỗi với dấu chấm
            string query = string.Format("UPDATE DichVu SET TenDichVu = N'{0}', GiaDichVu = {1}, LoaiDichVu = N'{2}' WHERE MaDichVu = N'{3}'",
                tenDichVu, giaDichVuStr, loaiDichVu, maDichVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteDichVu(string maDichVu)
        {
            string checkQuery = string.Format("SELECT COUNT(*) FROM DangKyDichVu WHERE MaDichVu = N'{0}'", maDichVu);
            object resultCheck = DataProvider.Instance.ExecuteScalar(checkQuery);
            int count = Convert.ToInt32(resultCheck);

            if (count > 0)
            {
                throw new Exception("Không thể xóa dịch vụ vì dịch vụ đã được sử dụng trong đăng ký dịch vụ!");
            }

            string query = string.Format("DELETE FROM DichVu WHERE MaDichVu = N'{0}'", maDichVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}