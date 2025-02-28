using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fNhanVien : Form
    {
        private string maNhanVien;

        public fNhanVien(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            LoadComboBoxVaiTro();
            LoadComboBoxGioiTinh();
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            List<NhanVienDTO> danhSach = NhanVienDAO.Instance.GetListNhanVien();
            dgvNhanVien.DataSource = danhSach;
            ClearFields();
        }

        private void LoadComboBoxVaiTro()
        {
            List<string> vaiTroList = new List<string> { "", "Lễ tân", "Quản lý", "Buồng phòng", "Kế toán", "Khác" };
            cbxVaiTro.DataSource = vaiTroList;
            if (cbxVaiTro.Items.Count > 0)
                cbxVaiTro.SelectedIndex = 0;
        }

        private void LoadComboBoxGioiTinh()
        {
            List<string> gioiTinhList = new List<string> { "", "Nam", "Nữ", "Khác" };
            cbxGioiTinh.DataSource = gioiTinhList;
            if (cbxGioiTinh.Items.Count > 0)
                cbxGioiTinh.SelectedIndex = 0;
        }

        private void ClearFields()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtSoCCCD.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            dtpNgayVaoLam.Value = DateTime.Now;
            if (cbxVaiTro.Items.Count > 0)
                cbxVaiTro.SelectedIndex = 0;
            if (cbxGioiTinh.Items.Count > 0)
                cbxGioiTinh.SelectedIndex = 0;
            txtMaNhanVien.ReadOnly = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNhanVienMoi = txtMaNhanVien.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string vaiTro = cbxVaiTro.Text.Trim();
            DateTime ngayVaoLam = dtpNgayVaoLam.Value;
            string gioiTinh = cbxGioiTinh.Text.Trim();
            string soCCCD = txtSoCCCD.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(maNhanVienMoi) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(soCCCD))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã nhân viên, họ tên, giới tính và CCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm nhân viên
            if (NhanVienDAO.Instance.InsertNhanVien(maNhanVienMoi, hoTen, soDienThoai, email, vaiTro, ngayVaoLam, gioiTinh, soCCCD, diaChi))
            {
                // Tự động tạo tài khoản
                string tenDangNhap = "nv" + maNhanVienMoi; // Ví dụ: nvNV003
                string matKhau = "123456"; // Mật khẩu mặc định
                if (TaiKhoanDAO.Instance.InsertTaiKhoan(tenDangNhap, matKhau, maNhanVienMoi))
                {
                    MessageBox.Show("Thêm nhân viên và tài khoản thành công!\nTên đăng nhập: " + tenDangNhap + "\nMật khẩu: " + matKhau,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thành công nhưng tạo tài khoản thất bại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại! Mã nhân viên hoặc CCCD có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNhanVienMoi = txtMaNhanVien.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string vaiTro = cbxVaiTro.Text.Trim();
            DateTime ngayVaoLam = dtpNgayVaoLam.Value;
            string gioiTinh = cbxGioiTinh.Text.Trim();
            string soCCCD = txtSoCCCD.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string checkQuery = string.Format("SELECT COUNT(*) FROM NhanVien WHERE SoCCCD = N'{0}'", soCCCD);
object result = DataProvider.Instance.ExecuteScalar(checkQuery);
if (Convert.ToInt32(result) > 0)
{
    MessageBox.Show("CCCD đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}

            if (string.IsNullOrEmpty(maNhanVienMoi))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sửa thông tin nhân viên
            if (NhanVienDAO.Instance.UpdateNhanVien(maNhanVienMoi, hoTen, soDienThoai, email, vaiTro, ngayVaoLam, gioiTinh, soCCCD, diaChi))
            {
                // Kiểm tra xem nhân viên đã có tài khoản chưa
                string tenDangNhap = "nv" + maNhanVienMoi;
                var taiKhoan = TaiKhoanDAO.Instance.GetTaiKhoanByTenDangNhap(tenDangNhap);
                if (taiKhoan == null)
                {
                    // Nếu chưa có, tạo mới
                    string matKhau = "123456";
                    if (TaiKhoanDAO.Instance.InsertTaiKhoan(tenDangNhap, matKhau, maNhanVienMoi))
                    {
                        MessageBox.Show("Sửa nhân viên và tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhân viên thành công nhưng tạo tài khoản thất bại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Nếu đã có, cập nhật MaNhanVien (trường hợp đổi MaNhanVien, nhưng ở đây không áp dụng vì MaNhanVien là khóa chính)
                    MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNhanVienMoi = txtMaNhanVien.Text.Trim();

            if (string.IsNullOrEmpty(maNhanVienMoi))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (maNhanVienMoi == this.maNhanVien)
            {
                MessageBox.Show("Không thể xóa nhân viên đang đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa tài khoản trước (nếu có)
                    string tenDangNhap = "nv" + maNhanVienMoi;
                    var taiKhoan = TaiKhoanDAO.Instance.GetTaiKhoanByTenDangNhap(tenDangNhap);
                    if (taiKhoan != null)
                    {
                        TaiKhoanDAO.Instance.DeleteTaiKhoan(tenDangNhap);
                    }

                    if (NhanVienDAO.Instance.DeleteNhanVien(maNhanVienMoi))
                    {
                        MessageBox.Show("Xóa nhân viên và tài khoản (nếu có) thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LoadNhanVien();
                return;
            }

            List<NhanVienDTO> danhSach = NhanVienDAO.Instance.SearchNhanVienByHoTen(timKiem);
            dgvNhanVien.DataSource = danhSach;

            if (danhSach.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cbxVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
                cbxGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtSoCCCD.Text = row.Cells["SoCCCD"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtMaNhanVien.ReadOnly = true;
            }
        }
    }
}