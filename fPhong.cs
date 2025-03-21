using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fPhong : Form
    {
        private string maNhanVien;
        private List<PhongDTO> danhSachPhong;
        private PhongDTO selectedPhong;

        public fPhong(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien ?? "NV001";
            this.danhSachPhong = new List<PhongDTO>();
            this.selectedPhong = null;
            LoadComboBoxLoaiPhong();
            LoadComboBoxTang();
            LoadComboBoxTrangThai();
            LoadPhong();
        }

        private void LoadPhong()
        {
            danhSachPhong = PhongDAO.Instance.GetListPhong();
            HienThiPhongTrongPanel(danhSachPhong);
            ClearFields();
        }

        private void LoadComboBoxLoaiPhong()
        {
            List<string> loaiPhongList = new List<string> { "", "Đơn", "Đôi", "Gia đình", "VIP", "Khác" };
            cbxLoaiPhong.DataSource = loaiPhongList;
            if (cbxLoaiPhong.Items.Count > 0)
                cbxLoaiPhong.SelectedIndex = 0;
        }

        private void LoadComboBoxTang()
        {
            List<int> tangList = new List<int> { 0, 1, 2, 3, 4, 5 };
            cbxTang.DataSource = tangList;
            if (cbxTang.Items.Count > 0)
                cbxTang.SelectedIndex = 0;
        }

        private void LoadComboBoxTrangThai()
        {
            List<string> trangThaiList = new List<string> { "", "Trống", "Đã đặt", "Đang sử dụng" };
            cbxTrangThai.DataSource = trangThaiList;
            if (cbxTrangThai.Items.Count > 0)
                cbxTrangThai.SelectedIndex = 0;
        }

        private void ClearFields()
        {
            txtMaPhong.Clear();
            txtGiaPhong.Clear();
            txtTimKiem.Clear();
            txtGiaTu.Clear();
            txtGiaDen.Clear();
            if (cbxLoaiPhong.Items.Count > 0)
                cbxLoaiPhong.SelectedIndex = 0;
            if (cbxTang.Items.Count > 0)
                cbxTang.SelectedIndex = 0;
            if (cbxTrangThai.Items.Count > 0)
                cbxTrangThai.SelectedIndex = 0;
            selectedPhong = null;
        }

        private void HienThiPhongTrongPanel(List<PhongDTO> phongList)
        {
            pnlPhong.Controls.Clear();
            int x = 10, y = 10;
            int panelWidth = 150, panelHeight = 100;
            int spacing = 10;

            foreach (PhongDTO phong in phongList)
            {
                Panel phongPanel = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Location = new Point(x, y),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = phong.TrangThai == "Trống" ? Color.LightGreen : Color.LightCoral,
                    Tag = phong
                };

                Label lblMaPhong = new Label
                {
                    Text = $"Phòng: {phong.MaPhong}",
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                Label lblLoaiPhong = new Label
                {
                    Text = $"Loại: {phong.LoaiPhong}",
                    Location = new Point(10, 30),
                    AutoSize = true
                };
                Label lblGiaPhong = new Label
                {
                    Text = $"Giá: {phong.GiaPhong:N0}",
                    Location = new Point(10, 50),
                    AutoSize = true
                };
                Label lblTrangThai = new Label
                {
                    Text = $"Trạng Thái: {phong.TrangThai}",
                    Location = new Point(10, 70),
                    AutoSize = true
                };

                phongPanel.Controls.Add(lblMaPhong);
                phongPanel.Controls.Add(lblLoaiPhong);
                phongPanel.Controls.Add(lblGiaPhong);
                phongPanel.Controls.Add(lblTrangThai);
                phongPanel.Click += PhongPanel_Click;

                pnlPhong.Controls.Add(phongPanel);

                x += panelWidth + spacing;
                if (x + panelWidth > pnlPhong.Width)
                {
                    x = 10;
                    y += panelHeight + spacing;
                }
            }
        }

        private void PhongPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            selectedPhong = panel.Tag as PhongDTO;
            txtMaPhong.Text = selectedPhong.MaPhong;
            cbxLoaiPhong.SelectedItem = selectedPhong.LoaiPhong;
            cbxTang.SelectedItem = int.Parse(selectedPhong.MaPhong.Substring(1, 1)); // Giả sử mã phòng có dạng P1xx
            txtGiaPhong.Text = selectedPhong.GiaPhong.ToString("N0");
            cbxTrangThai.SelectedItem = selectedPhong.TrangThai;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timKiem = txtTimKiem.Text.Trim();
            string loaiPhong = cbxLoaiPhong.SelectedItem?.ToString();
            int? tang = cbxTang.SelectedItem as int?;
            string trangThai = cbxTrangThai.SelectedItem?.ToString();
            decimal? giaTu = null, giaDen = null;

            if (!string.IsNullOrEmpty(txtGiaTu.Text) && decimal.TryParse(txtGiaTu.Text, out decimal giaTuValue))
                giaTu = giaTuValue;
            if (!string.IsNullOrEmpty(txtGiaDen.Text) && decimal.TryParse(txtGiaDen.Text, out decimal giaDenValue))
                giaDen = giaDenValue;

            List<PhongDTO> filteredPhong = PhongDAO.Instance.SearchPhong(timKiem, loaiPhong, trangThai, tang, giaTu, giaDen);
            HienThiPhongTrongPanel(filteredPhong);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim();
            string loaiPhong = cbxLoaiPhong.SelectedItem?.ToString();
            int tang = (int)cbxTang.SelectedItem;
            string trangThai = cbxTrangThai.SelectedItem?.ToString();
            if (!decimal.TryParse(txtGiaPhong.Text, out decimal giaPhong) || giaPhong <= 0)
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(loaiPhong) || string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mã phòng có tồn tại không
            if (PhongDAO.Instance.CheckPhongExists(maPhong))
            {
                MessageBox.Show("Mã phòng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PhongDTO phong = new PhongDTO(maPhong, loaiPhong, giaPhong, trangThai);
                if (PhongDAO.Instance.InsertPhong(phong))
                {
                    MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhong();
                }
                else
                {
                    MessageBox.Show("Thêm phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedPhong == null)
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maPhong = txtMaPhong.Text.Trim();
            string loaiPhong = cbxLoaiPhong.SelectedItem?.ToString();
            int tang = (int)cbxTang.SelectedItem;
            string trangThai = cbxTrangThai.SelectedItem?.ToString();
            if (!decimal.TryParse(txtGiaPhong.Text, out decimal giaPhong) || giaPhong <= 0)
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(loaiPhong) || string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mã phòng có thay đổi không, nếu thay đổi thì kiểm tra trùng
            if (maPhong != selectedPhong.MaPhong && PhongDAO.Instance.CheckPhongExists(maPhong))
            {
                MessageBox.Show("Mã phòng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PhongDTO phong = new PhongDTO(maPhong, loaiPhong, giaPhong, trangThai);
                if (PhongDAO.Instance.UpdatePhong(selectedPhong.MaPhong, phong))
                {
                    MessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhong();
                }
                else
                {
                    MessageBox.Show("Sửa phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedPhong == null)
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra phòng có đang được đặt không
            if (PhongDAO.Instance.CheckPhongInUse(selectedPhong.MaPhong))
            {
                MessageBox.Show("Phòng đang được đặt, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng {selectedPhong.MaPhong}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (PhongDAO.Instance.DeletePhong(selectedPhong.MaPhong))
                    {
                        MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPhong();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadPhong();
            MessageBox.Show("Đã làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}