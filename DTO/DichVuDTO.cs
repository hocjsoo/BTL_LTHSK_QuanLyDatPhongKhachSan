using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_QL_Dat_Phong_Khach_San.DTO
{
    public class DichVuDTO
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal GiaDichVu { get; set; }
        public string LoaiDichVu { get; set; }

        public DichVuDTO(string maDichVu, string tenDichVu, decimal giaDichVu, string loaiDichVu)
        {
            MaDichVu = maDichVu;
            TenDichVu = tenDichVu;
            GiaDichVu = giaDichVu;
            LoaiDichVu = loaiDichVu;
        }

        public DichVuDTO(DataRow row)
        {
            MaDichVu = row["MaDichVu"].ToString();
            TenDichVu = row["TenDichVu"].ToString();
            GiaDichVu = Convert.ToDecimal(row["GiaDichVu"]);
            LoaiDichVu = row["LoaiDichVu"].ToString();
        }

        public DichVuDTO(DataGridViewRow row)
        {
            MaDichVu = row.Cells["MaDichVu"].Value?.ToString() ?? "";
            TenDichVu = row.Cells["TenDichVu"].Value?.ToString() ?? "";
            GiaDichVu = row.Cells["GiaDichVu"].Value != null ? Convert.ToDecimal(row.Cells["GiaDichVu"].Value) : 0;
            LoaiDichVu = row.Cells["LoaiDichVu"].Value?.ToString() ?? "";
        }
    }
}