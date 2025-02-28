using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using BTL_QL_Dat_Phong_Khach_San.DAO;
using BTL_QL_Dat_Phong_Khach_San.DTO;
using System.Globalization;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fPhong : Form
    {
        private string maNhanVien;
        private List<PhongDTO> danhSachPhong;

        public fPhong(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
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
            List<string> trangThaiList = new List<string> { "", "Trống", "Đã đặt" };
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
            txtMaPhong.ReadOnly = false;
        }

        private void HienThiPhongTrongPanel(List<PhongDTO> phongList)
        {
            pnlPhong.Controls.Clear(); // Xóa các control cũ trong Panel
            int x = 10, y = 10, width = 100, height = 80, padding = 10;

            foreach (PhongDTO phong in phongList)
            {
                Button btnPhong = new Button
                {
                    Text = $"{phong.MaPhong}\n{phong.LoaiPhong}\n{phong.GiaPhong:N0}\n{phong.TrangThai}\nTầng: {phong.Tang}", // Hiển thị đầy đủ thông tin
                    Size = new Size(width, height),
                    Location = new Point(x, y),
                    Tag = phong // Lưu thông tin phòng vào Tag để sử dụng sau
                };

                // Đổi màu nền dựa trên trạng thái
                if (phong.TrangThai == "Trống")
                    btnPhong.BackColor = Color.LightGreen;
                else
                    btnPhong.BackColor = Color.LightCoral;

                btnPhong.Click += BtnPhong_Click;
                pnlPhong.Controls.Add(btnPhong);

                x += width + padding;
                if (x + width > pnlPhong.Width)
                {
                    x = 10;
                    y += height + padding;
                }
            }
        }

        private void BtnPhong_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            PhongDTO phong = btn.Tag as PhongDTO;

            txtMaPhong.Text = phong.MaPhong;
            cbxLoaiPhong.Text = phong.LoaiPhong;
            txtGiaPhong.Text = phong.GiaPhong.ToString();
            cbxTang.Text = phong.Tang.ToString();
            cbxTrangThai.Text = phong.TrangThai;
            txtMaPhong.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim();
            string loaiPhong = cbxLoaiPhong.Text.Trim();
            string giaPhongText = txtGiaPhong.Text.Trim();
            int tang = (int)cbxTang.SelectedItem;
            string trangThai = cbxTrangThai.Text.Trim();

            if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(loaiPhong) || string.IsNullOrEmpty(giaPhongText) || string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã phòng, loại phòng, giá phòng và trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaPhongText, out decimal giaPhong) || giaPhong < 0)
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PhongDAO.Instance.InsertPhong(maPhong, loaiPhong, giaPhong, tang, trangThai))
            {
                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhong();
            }
            else
            {
                MessageBox.Show("Thêm phòng thất bại! Mã phòng có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim();
            string loaiPhong = cbxLoaiPhong.Text.Trim();
            string giaPhongText = txtGiaPhong.Text.Trim();
            int tang = (int)cbxTang.SelectedItem;
            string trangThai = cbxTrangThai.Text.Trim();

            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaPhongText, out decimal giaPhong) || giaPhong < 0)
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PhongDAO.Instance.UpdatePhong(maPhong, loaiPhong, giaPhong, tang, trangThai))
            {
                MessageBox.Show("Sửa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhong();
            }
            else
            {
                MessageBox.Show("Sửa phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim();

            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (PhongDAO.Instance.DeletePhong(maPhong))
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
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maPhong = txtTimKiem.Text.Trim();
            string loaiPhong = cbxLoaiPhong.Text.Trim();
            string giaTuText = txtGiaTu.Text.Trim();
            string giaDenText = txtGiaDen.Text.Trim();
            int? tang = cbxTang.SelectedIndex > 0 ? (int?)cbxTang.SelectedItem : null;
            string trangThai = cbxTrangThai.Text.Trim();

            decimal? giaTu = null, giaDen = null;

            // Xử lý định dạng giá, chấp nhận cả dấu phẩy và dấu chấm
            if (!string.IsNullOrEmpty(giaTuText))
            {
                giaTuText = giaTuText.Replace(",", "."); // Chuyển dấu phẩy thành dấu chấm
                if (!decimal.TryParse(giaTuText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal giaTuValue) || giaTuValue < 0)
                {
                    MessageBox.Show("Giá từ không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                giaTu = giaTuValue;
            }

            if (!string.IsNullOrEmpty(giaDenText))
            {
                giaDenText = giaDenText.Replace(",", "."); // Chuyển dấu phẩy thành dấu chấm
                if (!decimal.TryParse(giaDenText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal giaDenValue) || giaDenValue < 0)
                {
                    MessageBox.Show("Giá đến không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                giaDen = giaDenValue;
            }

            if (giaTu.HasValue && giaDen.HasValue && giaTu > giaDen)
            {
                MessageBox.Show("Giá từ phải nhỏ hơn hoặc bằng giá đến!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<PhongDTO> danhSach = PhongDAO.Instance.SearchPhong(maPhong, loaiPhong, giaTu, giaDen, tang, trangThai);
            HienThiPhongTrongPanel(danhSach);

            if (danhSach.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}