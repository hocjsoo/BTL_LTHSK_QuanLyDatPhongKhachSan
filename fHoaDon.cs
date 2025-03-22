using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;

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

            try
            {
                // Lấy MaHoaDon từ dòng được chọn
                DataGridViewRow row = dgvHoaDon.SelectedRows[0];
                string maHoaDon = row.Cells["MaHoaDon"].Value.ToString();

                // Tạo đối tượng báo cáo
                ReportDocument report = new ReportDocument();
                string reportPath = Application.StartupPath + "\\rptHoaDon.rpt";
                report.Load(reportPath);

                // Thiết lập tham số MaHoaDon
                report.SetParameterValue("MaHoaDon", maHoaDon);

                // Tạo form mới để hiển thị báo cáo
                Form reportForm = new Form
                {
                    Text = "Hóa đơn - " + maHoaDon,
                    Size = new System.Drawing.Size(800, 600)
                };

                CrystalReportViewer viewer = new CrystalReportViewer
                {
                    Dock = DockStyle.Fill,
                    ReportSource = report,
                    ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                };

                reportForm.Controls.Add(viewer);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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