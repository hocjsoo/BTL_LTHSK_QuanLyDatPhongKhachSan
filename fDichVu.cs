using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    public partial class fDichVu : Form
    {
        private DichVuDTO selectedDichVu;

        public fDichVu()
        {
            InitializeComponent();
            selectedDichVu = null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadDanhSachDichVu();
            LoadLoaiDichVu();
            ClearForm();
        }

        private void LoadLoaiDichVu()
        {
            cbxLoaiDichVu.Items.AddRange(new string[] { "", "Phòng", "Ăn uống", "Vệ sinh", "Vận chuyển" });
            cbxLoaiDichVu.SelectedIndex = 0;
        }

        private void LoadDanhSachDichVu()
        {
            List<DichVuDTO> dichVuList = DichVuDAO.Instance.GetListDichVu();
            dgvDichVu.DataSource = dichVuList;
            FormatDataGridView(dgvDichVu, new string[] { "GiaDichVu" });
        }

        private void ClearForm()
        {
            txtMaDichVu.Clear();
            txtTenDichVu.Clear();
            txtGiaDichVu.Clear();
            cbxLoaiDichVu.SelectedIndex = 0;
            selectedDichVu = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDichVu = txtTimTheoMaDichVu.Text.Trim();
            string tenDichVu = txtTimTheoTenDichVu.Text.Trim();

            List<DichVuDTO> dichVuList = DichVuDAO.Instance.SearchDichVu(maDichVu, tenDichVu);
            dgvDichVu.DataSource = dichVuList;
            FormatDataGridView(dgvDichVu, new string[] { "GiaDichVu" });

            if (dichVuList.Count == 0)
                MessageBox.Show("Không tìm thấy dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maDichVu = txtMaDichVu.Text.Trim();
            string tenDichVu = txtTenDichVu.Text.Trim();
            if (!decimal.TryParse(txtGiaDichVu.Text.Replace(",", ""), out decimal giaDichVu) || giaDichVu <= 0)
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string loaiDichVu = cbxLoaiDichVu.Text;

            if (string.IsNullOrEmpty(maDichVu) || string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(loaiDichVu) || loaiDichVu == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DichVuDAO.Instance.InsertDichVu(maDichVu, tenDichVu, giaDichVu, loaiDichVu))
            {
                LoadDanhSachDichVu();
                ClearForm();
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại! Mã dịch vụ đã tồn tại hoặc lỗi khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedDichVu == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenDichVu = txtTenDichVu.Text.Trim();
            if (!decimal.TryParse(txtGiaDichVu.Text.Replace(",", ""), out decimal giaDichVu) || giaDichVu <= 0)
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string loaiDichVu = cbxLoaiDichVu.Text;

            if (string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(loaiDichVu) || loaiDichVu == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DichVuDAO.Instance.UpdateDichVu(selectedDichVu.MaDichVu, tenDichVu, giaDichVu, loaiDichVu))
            {
                LoadDanhSachDichVu();
                ClearForm();
                MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedDichVu == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DichVuDAO.Instance.DeleteDichVu(selectedDichVu.MaDichVu))
                {
                    LoadDanhSachDichVu();
                    ClearForm();
                    MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa dịch vụ thất bại! Dịch vụ đã được đăng ký.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDichVu();
            MessageBox.Show("Đã làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Tạo đối tượng DichVuDTO từ dữ liệu trong DataGridViewRow
                selectedDichVu = new DichVuDTO(
                    row.Cells["MaDichVu"].Value?.ToString() ?? "",
                    row.Cells["TenDichVu"].Value?.ToString() ?? "",
                    Convert.ToDecimal(row.Cells["GiaDichVu"].Value ?? 0),
                    row.Cells["LoaiDichVu"].Value?.ToString() ?? ""
                );
                txtMaDichVu.Text = selectedDichVu.MaDichVu;
                txtTenDichVu.Text = selectedDichVu.TenDichVu;
                txtGiaDichVu.Text = selectedDichVu.GiaDichVu.ToString("N0");
                cbxLoaiDichVu.Text = selectedDichVu.LoaiDichVu;
            }
        }

        private void FormatDataGridView(DataGridView dgv, string[] columnsToFormat)
        {
            foreach (var column in columnsToFormat)
            {
                if (dgv.Columns[column] != null)
                    dgv.Columns[column].DefaultCellStyle.Format = "N0";
            }
        }
    }
}