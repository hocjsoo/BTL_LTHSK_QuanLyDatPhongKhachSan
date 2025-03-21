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
            txtTimTheoDienThoai.Clear();
            txtTimTheoEmail.Clear();
            selectedKhachHang = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string soCCCD = txtTimTheoCCCD.Text.Trim();
            string hoTen = txtTimTheoHoTen.Text.Trim();
            string soDienThoai = txtTimTheoDienThoai.Text.Trim();
            string email = txtTimTheoEmail.Text.Trim();

            List<KhachHangDTO> khachHangList = KhachHangDAO.Instance.SearchKhachHang(soCCCD, hoTen, soDienThoai, email);
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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Số CCCD, Họ Tên, Số Điện Thoại)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số CCCD (ví dụ: 9 hoặc 12 chữ số)
            if (!Regex.IsMatch(soCCCD, @"^\d{9}$|^\d{12}$"))
            {
                MessageBox.Show("Số CCCD phải là 9 hoặc 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số điện thoại (ví dụ: bắt đầu bằng 0 và có 10 chữ số)
            if (!Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và có 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng email (nếu có)
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng số CCCD
            if (KhachHangDAO.Instance.CheckKhachHangExists(soCCCD))
            {
                MessageBox.Show("Số CCCD đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                KhachHangDTO khachHang = new KhachHangDTO(soCCCD, hoTen, soDienThoai, email, DateTime.Now);
                if (KhachHangDAO.Instance.InsertKhachHang(khachHang))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhachHang();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedKhachHang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string soCCCD = txtSoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(soCCCD) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Số CCCD, Họ Tên, Số Điện Thoại)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số CCCD
            if (!Regex.IsMatch(soCCCD, @"^\d{9}$|^\d{12}$"))
            {
                MessageBox.Show("Số CCCD phải là 9 hoặc 12 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và có 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng email (nếu có)
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số CCCD có thay đổi không, nếu thay đổi thì kiểm tra trùng
            if (soCCCD != selectedKhachHang.SoCCCD && KhachHangDAO.Instance.CheckKhachHangExists(soCCCD))
            {
                MessageBox.Show("Số CCCD đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                KhachHangDTO khachHang = new KhachHangDTO(soCCCD, hoTen, soDienThoai, email, selectedKhachHang.NgayTao);
                if (KhachHangDAO.Instance.UpdateKhachHang(selectedKhachHang.SoCCCD, khachHang))
                {
                    MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhachHang();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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