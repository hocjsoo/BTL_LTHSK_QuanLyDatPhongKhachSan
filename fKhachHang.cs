using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fKhachHang : Form
    {
        private string maNhanVien;

        public fKhachHang(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            List<KhachHangDTO> danhSach = KhachHangDAO.Instance.GetListKhachHang();
            dgvKhachHang.DataSource = danhSach;
            ClearFields();
        }

        private void ClearFields()
        {
            txtSoCCCD.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTimKiem.Clear();
            txtSoCCCD.ReadOnly = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(soCCCD) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ CCCD và họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KhachHangDAO.Instance.InsertKhachHang(soCCCD, hoTen, soDienThoai, email))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại! CCCD có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(soCCCD))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KhachHangDAO.Instance.UpdateKhachHang(soCCCD, hoTen, soDienThoai, email))
            {
                MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCD.Text.Trim();

            if (string.IsNullOrEmpty(soCCCD))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (KhachHangDAO.Instance.DeleteKhachHang(soCCCD))
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timKiem = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(timKiem))
            {
                LoadKhachHang();
                return;
            }

            // Tìm theo CCCD trước
            List<KhachHangDTO> danhSach = KhachHangDAO.Instance.SearchKhachHangByCCCD(timKiem);
            if (danhSach.Count == 0)
            {
                // Nếu không tìm thấy theo CCCD, tìm theo HoTen
                danhSach = KhachHangDAO.Instance.SearchKhachHangByHoTen(timKiem);
            }

            dgvKhachHang.DataSource = danhSach;
            if (danhSach.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtSoCCCD.Text = row.Cells["SoCCCD"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoCCCD.ReadOnly = true;
            }
        }
    }
}