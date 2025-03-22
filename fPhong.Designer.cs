namespace BTL_QL_Dat_Phong_Khach_San
{
    partial class fPhong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtGiaDen = new System.Windows.Forms.TextBox();
            this.lblGiaDen = new System.Windows.Forms.Label();
            this.txtGiaTu = new System.Windows.Forms.TextBox();
            this.lblGiaTu = new System.Windows.Forms.Label();
            this.cbxTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbxTang = new System.Windows.Forms.ComboBox();
            this.lblTang = new System.Windows.Forms.Label();
            this.cbxLoaiPhong = new System.Windows.Forms.ComboBox();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtGiaPhong = new System.Windows.Forms.TextBox();
            this.lblGiaPhong = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.pnlPhong = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.gbTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Controls.Add(this.txtGiaDen);
            this.gbTimKiem.Controls.Add(this.lblGiaDen);
            this.gbTimKiem.Controls.Add(this.txtGiaTu);
            this.gbTimKiem.Controls.Add(this.lblGiaTu);
            this.gbTimKiem.Controls.Add(this.cbxTrangThai);
            this.gbTimKiem.Controls.Add(this.lblTrangThai);
            this.gbTimKiem.Controls.Add(this.cbxTang);
            this.gbTimKiem.Controls.Add(this.lblTang);
            this.gbTimKiem.Controls.Add(this.cbxLoaiPhong);
            this.gbTimKiem.Controls.Add(this.lblLoaiPhong);
            this.gbTimKiem.Controls.Add(this.txtTimKiem);
            this.gbTimKiem.Controls.Add(this.lblTimKiem);
            this.gbTimKiem.Location = new System.Drawing.Point(13, 12);
            this.gbTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTimKiem.Size = new System.Drawing.Size(965, 185);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm Kiếm Phòng";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(347, 111);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(133, 37);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtGiaDen
            // 
            this.txtGiaDen.Location = new System.Drawing.Point(627, 70);
            this.txtGiaDen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaDen.Name = "txtGiaDen";
            this.txtGiaDen.Size = new System.Drawing.Size(132, 22);
            this.txtGiaDen.TabIndex = 11;
            // 
            // lblGiaDen
            // 
            this.lblGiaDen.AutoSize = true;
            this.lblGiaDen.Location = new System.Drawing.Point(573, 74);
            this.lblGiaDen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiaDen.Name = "lblGiaDen";
            this.lblGiaDen.Size = new System.Drawing.Size(34, 16);
            this.lblGiaDen.TabIndex = 10;
            this.lblGiaDen.Text = "Đến:";
            // 
            // txtGiaTu
            // 
            this.txtGiaTu.Location = new System.Drawing.Point(427, 70);
            this.txtGiaTu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaTu.Name = "txtGiaTu";
            this.txtGiaTu.Size = new System.Drawing.Size(132, 22);
            this.txtGiaTu.TabIndex = 9;
            // 
            // lblGiaTu
            // 
            this.lblGiaTu.AutoSize = true;
            this.lblGiaTu.Location = new System.Drawing.Point(347, 74);
            this.lblGiaTu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiaTu.Name = "lblGiaTu";
            this.lblGiaTu.Size = new System.Drawing.Size(50, 16);
            this.lblGiaTu.TabIndex = 8;
            this.lblGiaTu.Text = "Giá Từ:";
            // 
            // cbxTrangThai
            // 
            this.cbxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTrangThai.FormattingEnabled = true;
            this.cbxTrangThai.Location = new System.Drawing.Point(133, 144);
            this.cbxTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTrangThai.Name = "cbxTrangThai";
            this.cbxTrangThai.Size = new System.Drawing.Size(199, 24);
            this.cbxTrangThai.TabIndex = 7;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(27, 148);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(76, 16);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trạng Thái:";
            // 
            // cbxTang
            // 
            this.cbxTang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTang.FormattingEnabled = true;
            this.cbxTang.Location = new System.Drawing.Point(133, 107);
            this.cbxTang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTang.Name = "cbxTang";
            this.cbxTang.Size = new System.Drawing.Size(199, 24);
            this.cbxTang.TabIndex = 5;
            // 
            // lblTang
            // 
            this.lblTang.AutoSize = true;
            this.lblTang.Location = new System.Drawing.Point(27, 111);
            this.lblTang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTang.Name = "lblTang";
            this.lblTang.Size = new System.Drawing.Size(42, 16);
            this.lblTang.TabIndex = 4;
            this.lblTang.Text = "Tầng:";
            // 
            // cbxLoaiPhong
            // 
            this.cbxLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoaiPhong.FormattingEnabled = true;
            this.cbxLoaiPhong.Location = new System.Drawing.Point(133, 70);
            this.cbxLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxLoaiPhong.Name = "cbxLoaiPhong";
            this.cbxLoaiPhong.Size = new System.Drawing.Size(199, 24);
            this.cbxLoaiPhong.TabIndex = 3;
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(27, 74);
            this.lblLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(78, 16);
            this.lblLoaiPhong.TabIndex = 2;
            this.lblLoaiPhong.Text = "Loại Phòng:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(133, 33);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(199, 22);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(27, 37);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(66, 16);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm Kiếm:";
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.btnXoa);
            this.gbThongTin.Controls.Add(this.btnSua);
            this.gbThongTin.Controls.Add(this.btnThem);
            this.gbThongTin.Controls.Add(this.txtGiaPhong);
            this.gbThongTin.Controls.Add(this.lblGiaPhong);
            this.gbThongTin.Controls.Add(this.txtMaPhong);
            this.gbThongTin.Controls.Add(this.lblMaPhong);
            this.gbThongTin.Location = new System.Drawing.Point(13, 209);
            this.gbThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbThongTin.Size = new System.Drawing.Size(400, 270);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông Tin Phòng";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(20, 218);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(133, 37);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(199, 153);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(133, 37);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 153);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(133, 37);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtGiaPhong
            // 
            this.txtGiaPhong.Location = new System.Drawing.Point(138, 86);
            this.txtGiaPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaPhong.Name = "txtGiaPhong";
            this.txtGiaPhong.Size = new System.Drawing.Size(199, 22);
            this.txtGiaPhong.TabIndex = 2;
            // 
            // lblGiaPhong
            // 
            this.lblGiaPhong.AutoSize = true;
            this.lblGiaPhong.Location = new System.Drawing.Point(32, 90);
            this.lblGiaPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiaPhong.Name = "lblGiaPhong";
            this.lblGiaPhong.Size = new System.Drawing.Size(73, 16);
            this.lblGiaPhong.TabIndex = 1;
            this.lblGiaPhong.Text = "Giá Phòng:";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(133, 33);
            this.txtMaPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(199, 22);
            this.txtMaPhong.TabIndex = 0;
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(27, 37);
            this.lblMaPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(71, 16);
            this.lblMaPhong.TabIndex = 0;
            this.lblMaPhong.Text = "Mã Phòng:";
            // 
            // pnlPhong
            // 
            this.pnlPhong.AutoScroll = true;
            this.pnlPhong.Location = new System.Drawing.Point(427, 209);
            this.pnlPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPhong.Name = "pnlPhong";
            this.pnlPhong.Size = new System.Drawing.Size(551, 340);
            this.pnlPhong.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(33, 512);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(133, 37);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(217, 512);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(133, 37);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // fPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 581);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.pnlPhong);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Phòng";
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtGiaDen;
        private System.Windows.Forms.Label lblGiaDen;
        private System.Windows.Forms.TextBox txtGiaTu;
        private System.Windows.Forms.Label lblGiaTu;
        private System.Windows.Forms.ComboBox cbxTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cbxTang;
        private System.Windows.Forms.Label lblTang;
        private System.Windows.Forms.ComboBox cbxLoaiPhong;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtGiaPhong;
        private System.Windows.Forms.Label lblGiaPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Panel pnlPhong;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
    }
}