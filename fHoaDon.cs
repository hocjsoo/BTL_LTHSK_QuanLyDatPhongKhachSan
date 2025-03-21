using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fHoaDon : Form
    {
        private string maNhanVien;

        public fHoaDon(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            LoadHoaDon();
        }

        // Tải danh sách hóa đơn
        private void LoadHoaDon()
        {
            List<HoaDonDTO> listHoaDon = HoaDonDAO.Instance.GetListHoaDon();
            dgvHoaDon.DataSource = listHoaDon;
            dgvHoaDon.Columns["MaNhanVien"].Visible = false;
            ClearInputs();
        }

        // Tìm kiếm hóa đơn
        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDonTim.Text;
            DateTime tuNgay = dtpTu.Value;
            DateTime denNgay = dtpDen.Value;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày 'Từ' phải nhỏ hơn hoặc bằng ngày 'Đến'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<HoaDonDTO> listHoaDon = HoaDonDAO.Instance.SearchHoaDon(maHoaDon, tuNgay, denNgay);
            dgvHoaDon.DataSource = listHoaDon;
            ClearInputs();
        }

        // Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDonTim.Clear();
            dtpTu.Value = DateTime.Now;
            dtpDen.Value = DateTime.Now;
            LoadHoaDon();
            dgvDichVu.DataSource = null;
        }

        // Sự kiện khi chọn một dòng trong DataGridView hóa đơn
        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvHoaDon.SelectedRows[0];
                txtMaHoaDon.Text = row.Cells["MaHoaDon"].Value.ToString();
                txtNgayLap.Text = Convert.ToDateTime(row.Cells["NgayLapHoaDon"].Value).ToString("dd/MM/yyyy HH:mm:ss");
                txtTong.Text = row.Cells["TongChiPhi"].Value.ToString();

                // Tải danh sách dịch vụ liên quan dựa trên MaHoaDon
                string maHoaDon = row.Cells["MaHoaDon"].Value.ToString();
                DataTable dichVuData = HoaDonDAO.Instance.GetDichVuByMaHoaDon(maHoaDon);
                dgvDichVu.DataSource = dichVuData;
            }
        }

        // In hóa đơn
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvHoaDon.SelectedRows[0];
            string maHoaDon = row.Cells["MaHoaDon"].Value.ToString();
            var hoaDon = HoaDonDAO.Instance.GetHoaDonByMaHoaDon(maHoaDon);
            if (hoaDon != null)
            {
                string noiDung = $"HÓA ĐƠN\nMã HĐ: {hoaDon.MaHoaDon}\nKhách hàng: {hoaDon.SoCCCDKhachHang}\n" +
                                $"Nhân viên: {hoaDon.MaNhanVien}\nTổng chi phí: {hoaDon.TongChiPhi:N0}\n" +
                                $"Thanh toán: {hoaDon.TienThanhToan:N0}\nPhương thức: {hoaDon.PhuongThucThanhToan}\n" +
                                $"Ngày lập: {hoaDon.NgayLapHoaDon:dd/MM/yyyy HH:mm:ss}\n\nChi tiết:\n";
                DataTable dichVuData = HoaDonDAO.Instance.GetDichVuByMaHoaDon(maHoaDon);
                foreach (DataRow dichVuRow in dichVuData.Rows)
                {
                    noiDung += $"{dichVuRow["TenDichVu"]}: {dichVuRow["TongChiPhi"]:N0} (Số lượng: {dichVuRow["SoLuong"]})\n";
                }
                MessageBox.Show(noiDung, "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đóng form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Xóa các ô nhập liệu
        private void ClearInputs()
        {
            txtMaHoaDon.Clear();
            txtNgayLap.Clear();
            txtTong.Clear();
            dgvDichVu.DataSource = null;
        }
    }
}