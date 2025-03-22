using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    public partial class fKhachHang : Form
    {
        private KhachHangDTO selectedKhachHang;

        public fKhachHang()
        {
            InitializeComponent();
            selectedKhachHang = null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadDanhSachKhachHang();
            ClearForm();
        }

        private void LoadDanhSachKhachHang()
        {
            List<KhachHangDTO> khachHangList = KhachHangDAO.Instance.GetListKhachHang();
            dgvKhachHang.DataSource = khachHangList;
            FormatDataGridView(dgvKhachHang, new string[] { });
        }

        private void ClearForm()
        {
            txtSoCCCD.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTimTheoCCCD.Clear();
            txtTimTheoHoTen.Clear();
            selectedKhachHang = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string soCCCD = txtTimTheoCCCD.Text.Trim();
            string hoTen = txtTimTheoHoTen.Text.Trim();

            List<KhachHangDTO> khachHangList = KhachHangDAO.Instance.SearchKhachHang(soCCCD, hoTen);
            dgvKhachHang.DataSource = khachHangList;
            FormatDataGridView(dgvKhachHang, new string[] { });

            if (khachHangList.Count == 0)
                MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(soCCCD) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng (Số CCCD, Họ tên, Số điện thoại)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số CCCD (chỉ chứa số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(soCCCD, @"^\d+$"))
            {
                MessageBox.Show("Số CCCD chỉ được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra họ tên (không chứa ký tự nguy hiểm)
            if (hoTen.Contains("'") || hoTen.Contains(";"))
            {
                MessageBox.Show("Họ tên không được chứa ký tự đặc biệt như ' hoặc ;!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số điện thoại (chỉ chứa số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra email (nếu có)
            if (!string.IsNullOrEmpty(email) && (email.Contains("'") || email.Contains(";")))
            {
                MessageBox.Show("Email không được chứa ký tự đặc biệt như ' hoặc ;!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem khách hàng đã tồn tại chưa
            if (KhachHangDAO.Instance.CheckKhachHangExists(soCCCD))
            {
                MessageBox.Show("Khách hàng với số CCCD này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng KhachHangDTO
            KhachHangDTO khachHang = new KhachHangDTO(
                soCCCD,
                hoTen,
                soDienThoai,
                email,
                DateTime.Now
            );

            // Thêm khách hàng
            if (KhachHangDAO.Instance.InsertKhachHang(khachHang))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView không
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy số CCCD cũ từ hàng được chọn
            string oldSoCCCD = dgvKhachHang.SelectedRows[0].Cells["SoCCCD"].Value.ToString();

            // Lấy dữ liệu mới từ các TextBox
            string soCCCD = txtSoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim(); // Giả sử bạn có TextBox cho email

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(soCCCD) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng (Số CCCD, Họ tên, Số điện thoại)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số CCCD (chỉ chứa số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(soCCCD, @"^\d+$"))
            {
                MessageBox.Show("Số CCCD chỉ được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số CCCD cũ (chỉ chứa số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(oldSoCCCD, @"^\d+$"))
            {
                MessageBox.Show("Số CCCD cũ không hợp lệ (chỉ được chứa số)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra họ tên (không chứa ký tự nguy hiểm)
            if (hoTen.Contains("'") || hoTen.Contains(";"))
            {
                MessageBox.Show("Họ tên không được chứa ký tự đặc biệt như ' hoặc ;!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số điện thoại (chỉ chứa số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra email (nếu có)
            if (!string.IsNullOrEmpty(email) && (email.Contains("'") || email.Contains(";")))
            {
                MessageBox.Show("Email không được chứa ký tự đặc biệt như ' hoặc ;!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem số CCCD mới đã tồn tại chưa (nếu số CCCD thay đổi)
            if (soCCCD != oldSoCCCD && KhachHangDAO.Instance.CheckKhachHangExists(soCCCD))
            {
                MessageBox.Show("Số CCCD mới đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng KhachHangDTO
            KhachHangDTO khachHang = new KhachHangDTO(
                soCCCD,
                hoTen,
                soDienThoai,
                email,
                DateTime.Now // Có thể giữ nguyên ngày tạo cũ nếu cần
            );

            // Sửa khách hàng
            if (KhachHangDAO.Instance.UpdateKhachHang(oldSoCCCD, khachHang))
            {
                MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachKhachHang();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra khách hàng có liên quan đến đặt phòng hoặc hóa đơn không
            if (KhachHangDAO.Instance.CheckKhachHangInUse(selectedKhachHang.SoCCCD))
            {
                MessageBox.Show("Khách hàng đang có đặt phòng hoặc hóa đơn, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {selectedKhachHang.HoTen}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (KhachHangDAO.Instance.DeleteKhachHang(selectedKhachHang.SoCCCD))
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhachHang();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                selectedKhachHang = new KhachHangDTO(
                    row.Cells["SoCCCD"].Value.ToString(),
                    row.Cells["HoTen"].Value.ToString(),
                    row.Cells["SoDienThoai"].Value.ToString(),
                    row.Cells["Email"].Value.ToString(),
                    Convert.ToDateTime(row.Cells["NgayTao"].Value)
                );
                txtSoCCCD.Text = selectedKhachHang.SoCCCD;
                txtHoTen.Text = selectedKhachHang.HoTen;
                txtSoDienThoai.Text = selectedKhachHang.SoDienThoai;
                txtEmail.Text = selectedKhachHang.Email;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachKhachHang();
            MessageBox.Show("Đã làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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