using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    public partial class fDatPhong : Form
    {
        private string maNhanVien;
        private string soCCCDKhachHang;
        private List<DatPhongDTO> danhSachDatPhong;

        public fDatPhong(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = string.IsNullOrEmpty(maNhanVien) ? "NV001" : maNhanVien;
            this.soCCCDKhachHang = null;
            this.danhSachDatPhong = new List<DatPhongDTO>();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadComboboxData();
            LoadDanhSachPhong();
            dtpNgayTraPhong.Value = DateTime.Now.AddDays(1);
            ClearCustomerInfo();
        }

        private void LoadComboboxData()
        {
            cbxLoaiPhong.Items.Clear();
            cbxLoaiPhong.Items.AddRange(new[] { "", "Phòng đơn", "Phòng đôi", "Phòng VIP" });
            cbxLoaiPhong.SelectedIndex = 0;

            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.AddRange(new[] { "", "Trống", "Đã đặt", "Đang sử dụng" });
            cbxTrangThai.SelectedIndex = 0;
        }

        private void LoadDanhSachPhong()
        {
            try
            {
                var phongList = PhongDAO.Instance.GetListPhong();
                dgvPhong.DataSource = null;
                dgvPhong.Columns.Clear();
                dgvPhong.Columns.Add("MaPhong", "Mã phòng");
                dgvPhong.Columns.Add("LoaiPhong", "Loại phòng");
                dgvPhong.Columns.Add("GiaPhong", "Giá phòng");
                dgvPhong.Columns.Add("TrangThai", "Trạng thái");

                foreach (var phong in phongList)
                {
                    dgvPhong.Rows.Add(phong.MaPhong, phong.LoaiPhong, phong.GiaPhong.ToString("N0"), phong.TrangThai);
                }
                FormatDataGridView(dgvPhong, new[] { "GiaPhong" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomerInfo()
        {
            txtSoCCCD.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            soCCCDKhachHang = null;
            LoadDanhSachDatPhong();
        }

        private void LoadDanhSachDatPhong()
        {
            try
            {
                if (!string.IsNullOrEmpty(soCCCDKhachHang))
                {
                    danhSachDatPhong = DatPhongDAO.Instance.GetListDatPhongByKhachHang(soCCCDKhachHang);
                    dgvDatPhong.DataSource = null;
                    dgvDatPhong.Columns.Clear();
                    dgvDatPhong.Columns.Add("MaDatPhong", "Mã đặt phòng");
                    dgvDatPhong.Columns.Add("MaPhong", "Mã phòng");
                    dgvDatPhong.Columns.Add("LoaiPhong", "Loại phòng");
                    dgvDatPhong.Columns.Add("NgayDatPhong", "Ngày đặt");
                    dgvDatPhong.Columns.Add("NgayNhanPhong", "Ngày nhận");
                    dgvDatPhong.Columns.Add("NgayTraPhongDuKien", "Ngày trả dự kiến");
                    dgvDatPhong.Columns.Add("NgayTraPhong", "Ngày trả");
                    dgvDatPhong.Columns.Add("TongChiPhi", "Tổng chi phí");
                    dgvDatPhong.Columns.Add("TienDatCoc", "Tiền đặt cọc");
                    dgvDatPhong.Columns.Add("TrangThaiThanhToan", "Trạng thái thanh toán");

                    foreach (var datPhong in danhSachDatPhong)
                    {
                        string loaiPhong = GetLoaiPhong(datPhong.MaPhong);
                        DateTime ngayTraPhong = datPhong.NgayTraPhong ?? DateTime.MinValue;
                        dgvDatPhong.Rows.Add(datPhong.MaDatPhong, datPhong.MaPhong, loaiPhong, datPhong.NgayDatPhong,
                            datPhong.NgayNhanPhong, datPhong.NgayTraPhongDuKien, ngayTraPhong, datPhong.TongChiPhi.ToString("N0"),
                            datPhong.TienDatCoc.ToString("N0"), datPhong.TrangThaiThanhToan ? "Đã thanh toán" : "Chưa thanh toán");
                    }
                    FormatDataGridView(dgvDatPhong, new[] { "TongChiPhi", "TienDatCoc" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLoaiPhong(string maPhong)
        {
            try
            {
                string query = $"SELECT LoaiPhong FROM Phong WHERE MaPhong = '{maPhong}'";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                return data.Rows.Count > 0 ? data.Rows[0]["LoaiPhong"].ToString() : "Không xác định";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Không xác định";
            }
        }

        private decimal GetGiaPhong(string maPhong)
        {
            try
            {
                string query = $"SELECT GiaPhong FROM Phong WHERE MaPhong = '{maPhong}'";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                return data.Rows.Count > 0 ? Convert.ToDecimal(data.Rows[0]["GiaPhong"]) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy giá phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void FormatDataGridView(DataGridView dgv, string[] columnsToFormat)
        {
            foreach (string column in columnsToFormat)
            {
                dgv.Columns[column].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCD.Text.Trim();
            if (string.IsNullOrEmpty(soCCCD))
            {
                MessageBox.Show("Vui lòng nhập số CCCD!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = $"SELECT * FROM KhachHang WHERE SoCCCD = '{soCCCD}'";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                if (data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    soCCCDKhachHang = soCCCD;
                    LoadDanhSachDatPhong();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(soCCCD) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Số CCCD, Họ tên, Số điện thoại)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                KhachHangDTO khachHang = new KhachHangDTO(soCCCD, hoTen, soDienThoai, email, DateTime.Now);
                if (KhachHangDAO.Instance.InsertKhachHang(khachHang))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    soCCCDKhachHang = soCCCD;
                    LoadDanhSachDatPhong();
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

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soCCCDKhachHang))
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvPhong.SelectedRows[0];
            string maPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";
            DateTime ngayDatPhong = DateTime.Now;
            DateTime ngayNhanPhong = DateTime.Now.AddHours(2);
            DateTime ngayTraPhongDuKien = dtpNgayTraPhong.Value;

            if (ngayTraPhongDuKien <= ngayNhanPhong)
            {
                MessageBox.Show("Ngày trả phòng dự kiến phải sau ngày nhận phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maDatPhong = $"DP{DateTime.Now:yyyyMMddHHmmss}";
            TimeSpan soNgay = ngayTraPhongDuKien - ngayNhanPhong;
            decimal giaPhong = Convert.ToDecimal(row.Cells["GiaPhong"].Value);
            decimal tongChiPhi = giaPhong * (decimal)soNgay.Days;
            decimal tienDatCoc = 0;

            try
            {
                if (DatPhongDAO.Instance.InsertDatPhong(maDatPhong, soCCCDKhachHang, maPhong, maNhanVien,
                    ngayDatPhong, ngayNhanPhong, ngayTraPhongDuKien, null, tongChiPhi, tienDatCoc))
                {
                    if (PhongDAO.Instance.UpdateTrangThaiPhong(maPhong, "Đã đặt"))
                    {
                        danhSachDatPhong.Add(new DatPhongDTO(maDatPhong, soCCCDKhachHang, maPhong, maNhanVien,
                            ngayDatPhong, ngayNhanPhong, ngayTraPhongDuKien, null, tongChiPhi, tienDatCoc, false));

                        string hoaDon = TaoHoaDon(maDatPhong, soCCCDKhachHang, maPhong, ngayDatPhong, ngayNhanPhong,
                            ngayTraPhongDuKien, tongChiPhi, tienDatCoc);
                        MessageBox.Show(hoaDon, "Hóa đơn đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachDatPhong();
                        LoadDanhSachPhong();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoHoaDon(string maDatPhong, string soCCCDKhachHang, string maPhong,
            DateTime ngayDatPhong, DateTime ngayNhanPhong, DateTime ngayTraPhongDuKien,
            decimal tongChiPhi, decimal tienDatCoc)
        {
            try
            {
                string queryKhachHang = $"SELECT HoTen, SoDienThoai FROM KhachHang WHERE SoCCCD = '{soCCCDKhachHang}'";
                DataTable khachHangData = DataProvider.Instance.ExecuteQuery(queryKhachHang);
                string hoTen = khachHangData.Rows.Count > 0 ? khachHangData.Rows[0]["HoTen"].ToString() : "Không xác định";
                string soDienThoai = khachHangData.Rows.Count > 0 ? khachHangData.Rows[0]["SoDienThoai"].ToString() : "Không xác định";

                string loaiPhong = GetLoaiPhong(maPhong);
                decimal giaPhong = GetGiaPhong(maPhong);
                TimeSpan soNgay = ngayTraPhongDuKien - ngayNhanPhong;

                return $"===== HÓA ĐƠN ĐẶT PHÒNG =====\n\n" +
                       $"Mã đặt phòng: {maDatPhong}\n" +
                       $"Tên khách hàng: {hoTen}\n" +
                       $"Số CCCD: {soCCCDKhachHang}\n" +
                       $"Số điện thoại: {soDienThoai}\n\n" +
                       $"Phòng: {maPhong}\n" +
                       $"Loại phòng: {loaiPhong}\n" +
                       $"Giá phòng: {giaPhong:N0} VNĐ/ngày\n\n" +
                       $"Ngày đặt phòng: {ngayDatPhong:dd/MM/yyyy HH:mm:ss}\n" +
                       $"Ngày nhận phòng: {ngayNhanPhong:dd/MM/yyyy HH:mm:ss}\n" +
                       $"Ngày trả phòng dự kiến: {ngayTraPhongDuKien:dd/MM/yyyy HH:mm:ss}\n" +
                       $"Số ngày: {soNgay.Days} ngày\n\n" +
                       $"Tổng chi phí: {tongChiPhi:N0} VNĐ\n" +
                       $"Tiền đặt cọc: {tienDatCoc:N0} VNĐ\n" +
                       $"Số tiền cần thanh toán: {(tongChiPhi - tienDatCoc):N0} VNĐ\n\n" +
                       $"Ngày lập hóa đơn: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                       "=============================";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Không thể tạo hóa đơn!";
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đặt phòng để xem hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvDatPhong.SelectedRows[0];
                string maDatPhong = row.Cells["MaDatPhong"].Value?.ToString() ?? "";
                DateTime ngayDatPhong = Convert.ToDateTime(row.Cells["NgayDatPhong"].Value);
                DateTime ngayNhanPhong = Convert.ToDateTime(row.Cells["NgayNhanPhong"].Value);
                DateTime ngayTraPhongDuKien = Convert.ToDateTime(row.Cells["NgayTraPhongDuKien"].Value);
                decimal tongChiPhi = Convert.ToDecimal(row.Cells["TongChiPhi"].Value);
                decimal tienDatCoc = Convert.ToDecimal(row.Cells["TienDatCoc"].Value);

                string hoaDon = TaoHoaDon(maDatPhong, soCCCDKhachHang, row.Cells["MaPhong"].Value.ToString(),
                    ngayDatPhong, ngayNhanPhong, ngayTraPhongDuKien, tongChiPhi, tienDatCoc);
                MessageBox.Show(hoaDon, "Hóa đơn đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đặt phòng để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvDatPhong.SelectedRows[0];
                string maDatPhong = row.Cells["MaDatPhong"].Value?.ToString() ?? "";
                decimal tongChiPhi = Convert.ToDecimal(row.Cells["TongChiPhi"].Value);
                decimal tienDatCoc = Convert.ToDecimal(row.Cells["TienDatCoc"].Value);
                bool isPaid = row.Cells["TrangThaiThanhToan"].Value.ToString() == "Đã thanh toán";

                if (isPaid)
                {
                    MessageBox.Show("Phòng này đã được thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal soTienConLai = tongChiPhi - tienDatCoc;
                DialogResult result = MessageBox.Show($"Số tiền cần thanh toán: {soTienConLai:N0} VNĐ\nBạn có muốn thanh toán không?",
                    "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DateTime ngayTraPhong = Convert.ToDateTime(row.Cells["NgayTraPhongDuKien"].Value);
                    if (DatPhongDAO.Instance.UpdateTrangThaiThanhToan(maDatPhong, true, ngayTraPhong))
                    {
                        string maPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";
                        if (PhongDAO.Instance.UpdateTrangThaiPhong(maPhong, "Trống"))
                        {
                            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachDatPhong();
                            LoadDanhSachPhong();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật trạng thái phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyDatPhong_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đặt phòng để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvDatPhong.SelectedRows[0];
                string maDatPhong = row.Cells["MaDatPhong"].Value?.ToString() ?? "";
                string maPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";

                if (DatPhongDAO.Instance.CancelDatPhong(maDatPhong, maPhong))
                {
                    if (PhongDAO.Instance.UpdateTrangThaiPhong(maPhong, "Trống"))
                    {
                        MessageBox.Show("Hủy đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachDatPhong();
                        LoadDanhSachPhong();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hủy đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemPhong_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiPhong = cbxLoaiPhong.SelectedItem?.ToString();
                string trangThai = cbxTrangThai.SelectedItem?.ToString();

                var phongList = PhongDAO.Instance.GetListPhong();
                dgvPhong.DataSource = null;
                dgvPhong.Columns.Clear();
                dgvPhong.Columns.Add("MaPhong", "Mã phòng");
                dgvPhong.Columns.Add("LoaiPhong", "Loại phòng");
                dgvPhong.Columns.Add("GiaPhong", "Giá phòng");
                dgvPhong.Columns.Add("TrangThai", "Trạng thái");

                foreach (var phong in phongList)
                {
                    bool matchLoaiPhong = string.IsNullOrEmpty(loaiPhong) || phong.LoaiPhong == loaiPhong;
                    bool matchTrangThai = string.IsNullOrEmpty(trangThai) || phong.TrangThai == trangThai;
                    if (matchLoaiPhong && matchTrangThai)
                    {
                        dgvPhong.Rows.Add(phong.MaPhong, phong.LoaiPhong, phong.GiaPhong.ToString("N0"), phong.TrangThai);
                    }
                }
                FormatDataGridView(dgvPhong, new[] { "GiaPhong" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}