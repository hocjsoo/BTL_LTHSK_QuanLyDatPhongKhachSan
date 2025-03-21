using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    public partial class fDangKyDichVu : Form
    {
        private string maNhanVien;
        private string soCCCDKhachHang;
        private List<DangKyDichVuDTO> danhSachDichVuDaChon;
        private string currentMaHoaDon;

        public fDangKyDichVu(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien ?? "NV001";
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string soCCCD = txtTimTheoCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            var khachHangs = KhachHangDAO.Instance.SearchKhachHang(soCCCD, hoTen, soDienThoai, email);
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

        private void btnThemKhachHang_Click(object sender, EventArgs e)
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
                    string loaiDichVu = GetLoaiDichVu(dichVu.MaDichVu);
                    string tenDichVu = GetTenDichVu(dichVu.MaDichVu);
                    decimal donGia = GetGiaDichVu(dichVu.MaDichVu);
                    data.Rows.Add(dichVu.MaDichVu, loaiDichVu, tenDichVu, donGia, dichVu.SoLuong, dichVu.TongChiPhi);
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
            string query = $"SELECT LoaiDichVu FROM DichVu WHERE MaDichVu = N'{maDichVu}'";
            var result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString() ?? "";
        }

        private string GetTenDichVu(string maDichVu)
        {
            string query = $"SELECT TenDichVu FROM DichVu WHERE MaDichVu = N'{maDichVu}'";
            var result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString() ?? "";
        }

        private decimal GetGiaDichVu(string maDichVu)
        {
            string query = $"SELECT GiaDichVu FROM DichVu WHERE MaDichVu = N'{maDichVu}'";
            var result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (DangKyDichVuDTO dichVu in danhSachDichVuDaChon)
            {
                tongTien += dichVu.TongChiPhi;
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

            if (!decimal.TryParse(txtSoTien.Text.Replace(",", ""), out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal tongChiPhi = 0;
            foreach (DangKyDichVuDTO dichVu in danhSachDichVuDaChon)
            {
                tongChiPhi += dichVu.TongChiPhi;
            }
            if (soTien < tongChiPhi)
            {
                MessageBox.Show("Số tiền thanh toán không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                chiTietList.Add(new ChiTietHoaDonDTO(maChiTiet, maHoaDon, dichVu.MaDichVu, loaiDichVu, tenDichVu, giaDichVu, dichVu.SoLuong, dichVu.TongChiPhi));
            }

            var hoaDon = new HoaDonDTO(maHoaDon, soCCCDKhachHang, maNhanVien, tongChiPhi, soTien, phuongThuc, DateTime.Now, chiTietList);
            if (HoaDonDAO.Instance.InsertHoaDon(hoaDon))
            {
                // Lưu chi tiết hóa đơn vào bảng ChiTietHoaDon
                foreach (var chiTiet in chiTietList)
                {
                    if (!HoaDonDAO.Instance.InsertChiTietHoaDon(chiTiet))
                    {
                        MessageBox.Show($"Không thể lưu chi tiết hóa đơn cho dịch vụ {chiTiet.MaDichVu}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Xóa các dịch vụ đã đăng ký sau khi lưu vào ChiTietHoaDon
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
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaHoaDon))
            {
                MessageBox.Show("Vui lòng thanh toán trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var hoaDon = HoaDonDAO.Instance.GetHoaDonByMaHoaDon(currentMaHoaDon);
            if (hoaDon != null)
            {
                string noiDung = $"BIÊN NHẬN\nMã HĐ: {hoaDon.MaHoaDon}\nKhách hàng: {hoaDon.SoCCCDKhachHang}\n" +
                                $"Nhân viên: {hoaDon.MaNhanVien}\nTổng chi phí: {hoaDon.TongChiPhi:N0}\n" +
                                $"Thanh toán: {hoaDon.TienThanhToan:N0}\nPhương thức: {hoaDon.PhuongThucThanhToan}\n" +
                                $"Ngày lập: {hoaDon.NgayLapHoaDon:dd/MM/yyyy HH:mm:ss}\n\nChi tiết:\n";
                foreach (ChiTietHoaDonDTO chiTiet in hoaDon.ChiTietHoaDons)
                {
                    noiDung += $"{chiTiet.LoaiDichVu} - {chiTiet.TenDichVu}: {chiTiet.TongChiPhi:N0} (Giá: {chiTiet.GiaDichVu:N0}, Số lượng: {chiTiet.SoLuong})\n";
                }
                MessageBox.Show(noiDung, "In biên nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
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