using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    public partial class fDangKyDichVuMoi : Form
    {
        private string maNhanVien;
        private string soCCCDKhachHang;
        private List<DangKyDichVuDTO> danhSachDichVuDaChon;
        private string currentMaHoaDon;

        public fDangKyDichVuMoi(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien ?? "NV001"; // Mã nhân viên mặc định nếu null
            this.soCCCDKhachHang = null;
            this.danhSachDichVuDaChon = new List<DangKyDichVuDTO>();
            this.currentMaHoaDon = null;
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadLoaiDichVu();
            LoadPhuongThucThanhToan();
            LoadDanhSachDichVu();
            ClearForm();
        }

        private void LoadLoaiDichVu()
        {
            cbxLoaiDichVu.Items.AddRange(new[] { "", "Phòng", "Ăn uống", "Vệ sinh", "Vận chuyển" });
            cbxLoaiDichVu.SelectedIndex = 0;
        }

        private void LoadPhuongThucThanhToan()
        {
            cbxPhuongThucThanhToan.Items.AddRange(new[] { "Tiền mặt", "Thẻ", "Chuyển khoản" });
            cbxPhuongThucThanhToan.SelectedIndex = 0;
        }

        private void LoadDanhSachDichVu()
        {
            DataTable data = new DataTable();
            data.Columns.Add("MaDichVu", typeof(string));
            data.Columns.Add("TenDichVu", typeof(string));
            data.Columns.Add("GiaDichVu", typeof(decimal));
            data.Columns.Add("LoaiDichVu", typeof(string));

            foreach (DichVuDTO dichVu in DichVuDAO.Instance.GetListDichVu())
            {
                data.Rows.Add(dichVu.MaDichVu, dichVu.TenDichVu, dichVu.GiaDichVu, dichVu.LoaiDichVu);
            }

            dgvDichVu.DataSource = data;
            FormatDataGridView(dgvDichVu, new[] { "GiaDichVu" });
        }

        private void ClearForm()
        {
            txtTimTheoCCCD.Clear();
            txtTimTheoHoTen.Clear();
            txtHoTen.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtCCCD.Clear();
            txtKhachHang.Clear();
            cbxLoaiDichVu.SelectedIndex = 0;
            txtTenDichVu.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtSoTien.Clear();
            txtMaHD.Clear();
            LoadDanhSachDichVuDaChon();
            soCCCDKhachHang = null;
            danhSachDichVuDaChon.Clear();
            currentMaHoaDon = null;
        }

        private void btnTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            string soCCCD = txtTimTheoCCCD.Text.Trim();
            string hoTen = txtTimTheoHoTen.Text.Trim();

            if (string.IsNullOrEmpty(soCCCD) && string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin (CCCD hoặc Họ tên) để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var khachHangs = KhachHangDAO.Instance.SearchKhachHang(soCCCD, hoTen);
            if (khachHangs.Count > 0)
            {
                var khachHang = khachHangs[0];
                txtHoTen.Text = khachHang.HoTen;
                txtDienThoai.Text = khachHang.SoDienThoai;
                txtEmail.Text = khachHang.Email;
                txtCCCD.Text = khachHang.SoCCCD;
                soCCCDKhachHang = khachHang.SoCCCD;
                LoadDanhSachDichVuDaChon();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChonKhachHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soCCCDKhachHang))
            {
                MessageBox.Show("Vui lòng tìm khách hàng trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtKhachHang.Text = txtHoTen.Text;
        }

        private void btnTimKiemDichVu_Click(object sender, EventArgs e)
        {
            string loaiDichVu = cbxLoaiDichVu.Text;
            string tenDichVu = txtTenDichVu.Text.Trim();
            decimal donGia = 0;
            decimal.TryParse(txtDonGia.Text.Replace(",", ""), out donGia);

            DataTable data = new DataTable();
            data.Columns.Add("MaDichVu", typeof(string));
            data.Columns.Add("TenDichVu", typeof(string));
            data.Columns.Add("GiaDichVu", typeof(decimal));
            data.Columns.Add("LoaiDichVu", typeof(string));

            foreach (DichVuDTO dichVu in DichVuDAO.Instance.SearchDichVu("", tenDichVu))
            {
                if (string.IsNullOrEmpty(loaiDichVu) || loaiDichVu == "" || dichVu.LoaiDichVu == loaiDichVu)
                {
                    if (donGia == 0 || dichVu.GiaDichVu == donGia)
                    {
                        data.Rows.Add(dichVu.MaDichVu, dichVu.TenDichVu, dichVu.GiaDichVu, dichVu.LoaiDichVu);
                    }
                }
            }

            dgvDichVu.DataSource = data;
            FormatDataGridView(dgvDichVu, new[] { "GiaDichVu" });
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                cbxLoaiDichVu.Text = row.Cells["LoaiDichVu"].Value?.ToString() ?? "";
                txtTenDichVu.Text = row.Cells["TenDichVu"].Value?.ToString() ?? "";
                txtDonGia.Text = Convert.ToDecimal(row.Cells["GiaDichVu"].Value).ToString("N0");
            }
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soCCCDKhachHang))
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvDichVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvDichVu.SelectedRows[0];
            string maDichVu = row.Cells["MaDichVu"].Value?.ToString();
            if (string.IsNullOrEmpty(maDichVu))
            {
                MessageBox.Show("Dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (danhSachDichVuDaChon.Any(dv => dv.MaDichVu == maDichVu && dv.SoCCCDKhachHang == soCCCDKhachHang))
            {
                MessageBox.Show("Dịch vụ đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DichVuDTO dichVu = new DichVuDTO(row);
            decimal tongChiPhi = dichVu.GiaDichVu * soLuong;

            if (DangKyDichVuDAO.Instance.InsertDangKyDichVu(soCCCDKhachHang, dichVu.MaDichVu, maNhanVien, soLuong))
            {
                danhSachDichVuDaChon.Add(new DangKyDichVuDTO(soCCCDKhachHang, dichVu.MaDichVu, maNhanVien, soLuong, tongChiPhi, DateTime.Now));
                LoadDanhSachDichVuDaChon();
                CapNhatTongTien();
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachDichVuDaChon()
        {
            if (!string.IsNullOrEmpty(soCCCDKhachHang))
            {
                danhSachDichVuDaChon = DangKyDichVuDAO.Instance.GetDichVuByKhachHang(soCCCDKhachHang);
                DataTable data = new DataTable();
                data.Columns.Add("MaDichVu", typeof(string));
                data.Columns.Add("LoaiDichVu", typeof(string));
                data.Columns.Add("TenDichVu", typeof(string));
                data.Columns.Add("DonGia", typeof(decimal));
                data.Columns.Add("SoLuong", typeof(int));
                data.Columns.Add("TongChiPhi", typeof(decimal));

                foreach (DangKyDichVuDTO dichVu in danhSachDichVuDaChon)
                {
                    if (string.IsNullOrEmpty(dichVu.MaDichVu))
                    {
                        MessageBox.Show($"Dịch vụ với MaDichVu rỗng được tìm thấy cho khách hàng {soCCCDKhachHang}. Vui lòng kiểm tra dữ liệu trong bảng DangKyDichVu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    string loaiDichVu = GetLoaiDichVu(dichVu.MaDichVu);
                    string tenDichVu = GetTenDichVu(dichVu.MaDichVu);
                    decimal donGia = GetGiaDichVu(dichVu.MaDichVu);

                    if (string.IsNullOrEmpty(loaiDichVu) || string.IsNullOrEmpty(tenDichVu) || donGia == 0)
                    {
                        MessageBox.Show($"Dịch vụ {dichVu.MaDichVu} không tồn tại trong bảng DichVu. Vui lòng kiểm tra dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    decimal tongChiPhi = donGia * dichVu.SoLuong;
                    data.Rows.Add(dichVu.MaDichVu, loaiDichVu, tenDichVu, donGia, dichVu.SoLuong, tongChiPhi);
                }

                dgvDichVuDaChon.DataSource = data;
                FormatDataGridView(dgvDichVuDaChon, new[] { "DonGia", "TongChiPhi" });
            }
            else
            {
                dgvDichVuDaChon.DataSource = null;
            }
        }

        private string GetLoaiDichVu(string maDichVu)
        {
            if (string.IsNullOrEmpty(maDichVu))
            {
                return "";
            }

            string query = "SELECT LoaiDichVu FROM DichVu WHERE MaDichVu = @MaDichVu";
            object[] parameters = new object[] { maDichVu };
            var result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result?.ToString() ?? "";
        }

        private string GetTenDichVu(string maDichVu)
        {
            if (string.IsNullOrEmpty(maDichVu))
            {
                return "";
            }

            string query = "SELECT TenDichVu FROM DichVu WHERE MaDichVu = @MaDichVu";
            object[] parameters = new object[] { maDichVu };
            var result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result?.ToString() ?? "";
        }

        private decimal GetGiaDichVu(string maDichVu)
        {
            if (string.IsNullOrEmpty(maDichVu))
            {
                return 0;
            }

            string query = "SELECT GiaDichVu FROM DichVu WHERE MaDichVu = @MaDichVu";
            object[] parameters = new object[] { maDichVu };
            var result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (DangKyDichVuDTO dichVu in danhSachDichVuDaChon)
            {
                decimal donGia = GetGiaDichVu(dichVu.MaDichVu);
                tongTien += donGia * dichVu.SoLuong;
            }
            txtSoTien.Text = tongTien.ToString("N0");
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soCCCDKhachHang) || danhSachDichVuDaChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng và dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string phuongThuc = cbxPhuongThucThanhToan.Text;
            if (string.IsNullOrEmpty(phuongThuc))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal tongChiPhi = 0;
            foreach (DangKyDichVuDTO dichVu in danhSachDichVuDaChon)
            {
                decimal donGia = GetGiaDichVu(dichVu.MaDichVu);
                tongChiPhi += donGia * dichVu.SoLuong;
            }

            string maHoaDon = $"HD{DateTime.Now:yyyyMMddHHmmss}";
            var chiTietList = new List<ChiTietHoaDonDTO>();
            int index = 1;

            foreach (DangKyDichVuDTO dichVu in danhSachDichVuDaChon)
            {
                string loaiDichVu = GetLoaiDichVu(dichVu.MaDichVu);
                string tenDichVu = GetTenDichVu(dichVu.MaDichVu);
                decimal giaDichVu = GetGiaDichVu(dichVu.MaDichVu);

                if (string.IsNullOrEmpty(loaiDichVu) || string.IsNullOrEmpty(tenDichVu) || giaDichVu <= 0)
                {
                    MessageBox.Show($"Dịch vụ {dichVu.MaDichVu} không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maChiTiet = $"{maHoaDon}_{index++}";
                decimal tongChiPhiDichVu = giaDichVu * dichVu.SoLuong;
                chiTietList.Add(new ChiTietHoaDonDTO(maChiTiet, maHoaDon, dichVu.MaDichVu, dichVu.SoLuong, tongChiPhiDichVu));
            }

            // Giả sử khách hàng thanh toán đủ, nên TienThanhToan = TongChiPhi
            decimal tienThanhToan = tongChiPhi;
            var hoaDon = new HoaDonDTO(maHoaDon, soCCCDKhachHang, maNhanVien, tongChiPhi, tienThanhToan, phuongThuc, DateTime.Now, chiTietList);
            if (HoaDonDAO.Instance.InsertHoaDon(hoaDon))
            {
                foreach (var chiTiet in chiTietList)
                {
                    if (!HoaDonDAO.Instance.InsertChiTietHoaDon(chiTiet))
                    {
                        MessageBox.Show($"Không thể lưu chi tiết hóa đơn cho dịch vụ {chiTiet.MaDichVu}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                foreach (var dichVu in danhSachDichVuDaChon.ToList())
                {
                    if (DangKyDichVuDAO.Instance.DeleteDangKyDichVu(dichVu.SoCCCDKhachHang, dichVu.MaDichVu))
                    {
                        danhSachDichVuDaChon.Remove(dichVu);
                    }
                    else
                    {
                        MessageBox.Show($"Không thể xóa dịch vụ {dichVu.MaDichVu} khỏi đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                currentMaHoaDon = maHoaDon;
                txtMaHD.Text = maHoaDon;
                LoadDanhSachDichVuDaChon();
                CapNhatTongTien();
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaHoaDon))
            {
                MessageBox.Show("Vui lòng thanh toán trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy thông tin hóa đơn
                var hoaDon = HoaDonDAO.Instance.GetHoaDonByMaHoaDon(currentMaHoaDon);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo báo cáo
                ReportDocument report = new ReportDocument();
                string reportPath = Path.Combine(Application.StartupPath, "rptHoaDon.rpt");

                // Kiểm tra xem file báo cáo có tồn tại không
                if (!File.Exists(reportPath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file báo cáo tại: {reportPath}");
                }

                report.Load(reportPath);

                // Thiết lập thông tin kết nối cơ sở dữ liệu
                ConnectionInfo connectionInfo = new ConnectionInfo
                {
                    ServerName = "HocND",
                    DatabaseName = "BTL_QuanLyKS",
                    IntegratedSecurity = true
                };

                foreach (Table table in report.Database.Tables)
                {
                    TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                    tableLogOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogOnInfo);
                }

                // Truyền tham số vào báo cáo
                try
                {
                    report.SetParameterValue("MaHoaDon", currentMaHoaDon);
                }
                catch (Exception paramEx)
                {
                    MessageBox.Show($"Lỗi khi truyền tham số vào báo cáo: {paramEx.Message}\nKiểm tra xem tham số MaHoaDon có tồn tại trong báo cáo không.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị báo cáo trong một form mới
                Form reportForm = new Form
                {
                    Text = "Hóa đơn - " + currentMaHoaDon,
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
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (dgvDichVuDaChon.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDichVuDaChon.SelectedRows[0];
                string maDichVu = row.Cells["MaDichVu"].Value?.ToString();
                if (string.IsNullOrEmpty(maDichVu))
                {
                    MessageBox.Show("Dịch vụ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DangKyDichVuDTO dichVuToRemove = danhSachDichVuDaChon.FirstOrDefault(dv => dv.MaDichVu == maDichVu && dv.SoCCCDKhachHang == soCCCDKhachHang);
                if (dichVuToRemove != null)
                {
                    if (DangKyDichVuDAO.Instance.DeleteDangKyDichVu(dichVuToRemove.SoCCCDKhachHang, dichVuToRemove.MaDichVu))
                    {
                        danhSachDichVuDaChon.Remove(dichVuToRemove);
                        LoadDanhSachDichVuDaChon();
                        CapNhatTongTien();
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Xóa dịch vụ {maDichVu} thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
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
