using System;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.Forms;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fMain : Form
    {
        private string maNhanVien;

        public fMain(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
        }

    

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            fDatPhong f = new fDatPhong(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            fNhanPhong f = new fNhanPhong(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            fKhachHang form = new fKhachHang(); // Truyền MaNhanVien
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnQLDichVu_Click(object sender, EventArgs e)
        {
            fDichVu f = new fDichVu(); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            fPhong f = new fPhong(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e) // Đặt lại tên nút thành btnDangKyDichVu
        {
            fDangKyDichVu f = new fDangKyDichVu(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnTKDoanhThu_Click(object sender, EventArgs e)
        {
            fDoanhThu f = new fDoanhThu(maNhanVien); // Truyền MaNhanVien
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTaiKhoan form = new fTaiKhoan(maNhanVien);
            form.ShowDialog();
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}