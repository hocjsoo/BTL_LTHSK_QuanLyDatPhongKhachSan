using BTL_QL_Dat_Phong_Khach_San.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fTaiKhoan: Form
    {
        private string maNhanVien;
        public fTaiKhoan(string maNhanVien)
        {
            InitializeComponent();

            this.maNhanVien = maNhanVien;

            LoadThongTinTaiKhoan();
            this.maNhanVien = maNhanVien;
        }
        private void LoadThongTinTaiKhoan()
        {
            string queryTaiKhoan = string.Format("SELECT * FROM TaiKhoan WHERE MaNhanVien = N'{0}'", maNhanVien);
            var dataTaiKhoan = DataProvider.Instance.ExecuteQuery(queryTaiKhoan);
            if (dataTaiKhoan.Rows.Count > 0)
            {
                var rowTaiKhoan = dataTaiKhoan.Rows[0];
                txtTenDangNhap.Text = rowTaiKhoan["TenDangNhap"].ToString();
                txtMaNhanVien.Text = rowTaiKhoan["MaNhanVien"].ToString();
            }

            var nhanVien = NhanVienDAO.Instance.GetNhanVienByMaNhanVien(maNhanVien); // Sửa từ LayThongTinNhanVien
            if (nhanVien != null)
            {
                txtHoTen.Text = nhanVien.HoTen;
                txtChucVu.Text = nhanVien.VaiTro;
            }
        }

        private void FormThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.ReadOnly = true;
            txtMaNhanVien.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtChucVu.ReadOnly = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
