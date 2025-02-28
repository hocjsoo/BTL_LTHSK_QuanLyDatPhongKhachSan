using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;
using System.Linq;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fDichVu : Form
    {
        private string maNhanVien;

        public fDichVu(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            LoadComboBoxLoaiDichVu(); // Tải ComboBox trước
            LoadDichVu(); // Sau đó tải danh sách dịch vụ
        }

        private void LoadDichVu()
        {
            List<DichVuDTO> danhSach = DichVuDAO.Instance.GetListDichVu();
            dgvDichVu.DataSource = danhSach;
            ClearFields();
        }

        private void LoadComboBoxLoaiDichVu()
        {
            List<string> loaiDichVuList = DichVuDAO.Instance.GetListLoaiDichVu();
            loaiDichVuList.Insert(0, ""); // Thêm tùy chọn trống

            // Gán DataSource cho cả hai ComboBox
            cbxLoaiDichVu.DataSource = loaiDichVuList;
            cbxTimKiemLoai.DataSource = new List<string>(loaiDichVuList);

            // Đặt SelectedIndex sau khi DataSource đã được gán
            cbxLoaiDichVu.SelectedIndex = 0;
            cbxTimKiemLoai.SelectedIndex = 0;
        }

        private void ClearFields()
        {
            txtMaDichVu.Clear();
            txtTenDichVu.Clear();
            txtGiaDichVu.Clear();
            txtTimKiemTen.Clear();

            // Chỉ gán SelectedIndex nếu DataSource đã được gán
            if (cbxLoaiDichVu.Items.Count > 0)
                cbxLoaiDichVu.SelectedIndex = 0;
            if (cbxTimKiemLoai.Items.Count > 0)
                cbxTimKiemLoai.SelectedIndex = 0;

            txtMaDichVu.ReadOnly = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDichVu.Text.Trim();
            string tenDichVu = txtTenDichVu.Text.Trim();
            string giaDichVuText = txtGiaDichVu.Text.Trim();
            string loaiDichVu = cbxLoaiDichVu.Text.Trim();

            if (string.IsNullOrEmpty(maDichVu) || string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(giaDichVuText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã dịch vụ, tên dịch vụ và giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaDichVuText, out decimal giaDichVu) || giaDichVu < 0)
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DichVuDAO.Instance.InsertDichVu(maDichVu, tenDichVu, giaDichVu, loaiDichVu))
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDichVu();
                LoadComboBoxLoaiDichVu(); // Cập nhật lại ComboBox
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại! Mã dịch vụ có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDichVu.Text.Trim();
            string tenDichVu = txtTenDichVu.Text.Trim();
            string giaDichVuText = txtGiaDichVu.Text.Trim();
            string loaiDichVu = cbxLoaiDichVu.Text.Trim();

            if (string.IsNullOrEmpty(maDichVu))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaDichVuText, out decimal giaDichVu) || giaDichVu < 0)
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DichVuDAO.Instance.UpdateDichVu(maDichVu, tenDichVu, giaDichVu, loaiDichVu))
            {
                MessageBox.Show("Sửa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDichVu();
                LoadComboBoxLoaiDichVu(); // Cập nhật lại ComboBox
            }
            else
            {
                MessageBox.Show("Sửa dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDichVu.Text.Trim();

            if (string.IsNullOrEmpty(maDichVu))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (DichVuDAO.Instance.DeleteDichVu(maDichVu))
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDichVu();
                        LoadComboBoxLoaiDichVu(); // Cập nhật lại ComboBox
                    }
                    else
                    {
                        MessageBox.Show("Xóa dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string tenDichVu = txtTimKiemTen.Text.Trim();
            string loaiDichVu = cbxTimKiemLoai.Text.Trim();

            List<DichVuDTO> danhSach = DichVuDAO.Instance.GetListDichVu();

            if (!string.IsNullOrEmpty(tenDichVu))
            {
                danhSach = DichVuDAO.Instance.SearchDichVuByName(tenDichVu);
            }

            if (!string.IsNullOrEmpty(loaiDichVu))
            {
                danhSach = danhSach.Where(d => d.LoaiDichVu == loaiDichVu).ToList();
            }

            if (danhSach.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dịch vụ nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvDichVu.DataSource = danhSach;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDichVu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                txtMaDichVu.Text = row.Cells["MaDichVu"].Value.ToString();
                txtTenDichVu.Text = row.Cells["TenDichVu"].Value.ToString();
                txtGiaDichVu.Text = row.Cells["GiaDichVu"].Value.ToString();
                cbxLoaiDichVu.Text = row.Cells["LoaiDichVu"].Value.ToString();
                txtMaDichVu.ReadOnly = true;
            }
        }
    }
}