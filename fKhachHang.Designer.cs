namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    partial class fKhachHang
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
            this.txtTimTheoEmail = new System.Windows.Forms.TextBox();
            this.lblTimTheoEmail = new System.Windows.Forms.Label();
            this.txtTimTheoDienThoai = new System.Windows.Forms.TextBox();
            this.lblTimTheoDienThoai = new System.Windows.Forms.Label();
            this.txtTimTheoHoTen = new System.Windows.Forms.TextBox();
            this.lblTimTheoHoTen = new System.Windows.Forms.Label();
            this.txtTimTheoCCCD = new System.Windows.Forms.TextBox();
            this.lblTimTheoCCCD = new System.Windows.Forms.Label();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtSoCCCD = new System.Windows.Forms.TextBox();
            this.lblSoCCCD = new System.Windows.Forms.Label();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.gbTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Controls.Add(this.txtTimTheoEmail);
            this.gbTimKiem.Controls.Add(this.lblTimTheoEmail);
            this.gbTimKiem.Controls.Add(this.txtTimTheoDienThoai);
            this.gbTimKiem.Controls.Add(this.lblTimTheoDienThoai);
            this.gbTimKiem.Controls.Add(this.txtTimTheoHoTen);
            this.gbTimKiem.Controls.Add(this.lblTimTheoHoTen);
            this.gbTimKiem.Controls.Add(this.txtTimTheoCCCD);
            this.gbTimKiem.Controls.Add(this.lblTimTheoCCCD);
            this.gbTimKiem.Location = new System.Drawing.Point(10, 10);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(780, 150);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm Kiếm Khách Hàng";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(260, 60);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimTheoEmail
            // 
            this.txtTimTheoEmail.Location = new System.Drawing.Point(100, 117);
            this.txtTimTheoEmail.Name = "txtTimTheoEmail";
            this.txtTimTheoEmail.Size = new System.Drawing.Size(150, 20);
            this.txtTimTheoEmail.TabIndex = 7;
            // 
            // lblTimTheoEmail
            // 
            this.lblTimTheoEmail.AutoSize = true;
            this.lblTimTheoEmail.Location = new System.Drawing.Point(20, 120);
            this.lblTimTheoEmail.Name = "lblTimTheoEmail";
            this.lblTimTheoEmail.Size = new System.Drawing.Size(38, 13);
            this.lblTimTheoEmail.TabIndex = 6;
            this.lblTimTheoEmail.Text = "Email:";
            // 
            // txtTimTheoDienThoai
            // 
            this.txtTimTheoDienThoai.Location = new System.Drawing.Point(100, 87);
            this.txtTimTheoDienThoai.Name = "txtTimTheoDienThoai";
            this.txtTimTheoDienThoai.Size = new System.Drawing.Size(150, 20);
            this.txtTimTheoDienThoai.TabIndex = 5;
            // 
            // lblTimTheoDienThoai
            // 
            this.lblTimTheoDienThoai.AutoSize = true;
            this.lblTimTheoDienThoai.Location = new System.Drawing.Point(20, 90);
            this.lblTimTheoDienThoai.Name = "lblTimTheoDienThoai";
            this.lblTimTheoDienThoai.Size = new System.Drawing.Size(82, 13);
            this.lblTimTheoDienThoai.TabIndex = 4;
            this.lblTimTheoDienThoai.Text = "Số Điện Thoại:";
            // 
            // txtTimTheoHoTen
            // 
            this.txtTimTheoHoTen.Location = new System.Drawing.Point(100, 57);
            this.txtTimTheoHoTen.Name = "txtTimTheoHoTen";
            this.txtTimTheoHoTen.Size = new System.Drawing.Size(150, 20);
            this.txtTimTheoHoTen.TabIndex = 3;
            // 
            // lblTimTheoHoTen
            // 
            this.lblTimTheoHoTen.AutoSize = true;
            this.lblTimTheoHoTen.Location = new System.Drawing.Point(20, 60);
            this.lblTimTheoHoTen.Name = "lblTimTheoHoTen";
            this.lblTimTheoHoTen.Size = new System.Drawing.Size(46, 13);
            this.lblTimTheoHoTen.TabIndex = 2;
            this.lblTimTheoHoTen.Text = "Họ Tên:";
            // 
            // txtTimTheoCCCD
            // 
            this.txtTimTheoCCCD.Location = new System.Drawing.Point(100, 27);
            this.txtTimTheoCCCD.Name = "txtTimTheoCCCD";
            this.txtTimTheoCCCD.Size = new System.Drawing.Size(150, 20);
            this.txtTimTheoCCCD.TabIndex = 1;
            // 
            // lblTimTheoCCCD
            // 
            this.lblTimTheoCCCD.AutoSize = true;
            this.lblTimTheoCCCD.Location = new System.Drawing.Point(20, 30);
            this.lblTimTheoCCCD.Name = "lblTimTheoCCCD";
            this.lblTimTheoCCCD.Size = new System.Drawing.Size(62, 13);
            this.lblTimTheoCCCD.TabIndex = 0;
            this.lblTimTheoCCCD.Text = "Số CCCD:";
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.btnXoa);
            this.gbThongTin.Controls.Add(this.btnSua);
            this.gbThongTin.Controls.Add(this.btnThem);
            this.gbThongTin.Controls.Add(this.txtEmail);
            this.gbThongTin.Controls.Add(this.lblEmail);
            this.gbThongTin.Controls.Add(this.txtSoDienThoai);
            this.gbThongTin.Controls.Add(this.lblSoDienThoai);
            this.gbThongTin.Controls.Add(this.txtHoTen);
            this.gbThongTin.Controls.Add(this.lblHoTen);
            this.gbThongTin.Controls.Add(this.txtSoCCCD);
            this.gbThongTin.Controls.Add(this.lblSoCCCD);
            this.gbThongTin.Location = new System.Drawing.Point(10, 170);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(780, 150);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông Tin Khách Hàng";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(260, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(260, 80);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(260, 40);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(100, 87);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(150, 20);
            this.txtSoDienThoai.TabIndex = 4;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(20, 90);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(82, 13);
            this.lblSoDienThoai.TabIndex = 3;
            this.lblSoDienThoai.Text = "Số Điện Thoại:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(100, 57);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 20);
            this.txtHoTen.TabIndex = 2;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(20, 60);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(46, 13);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // txtSoCCCD
            // 
            this.txtSoCCCD.Location = new System.Drawing.Point(100, 27);
            this.txtSoCCCD.Name = "txtSoCCCD";
            this.txtSoCCCD.Size = new System.Drawing.Size(150, 20);
            this.txtSoCCCD.TabIndex = 0;
            // 
            // lblSoCCCD
            // 
            this.lblSoCCCD.AutoSize = true;
            this.lblSoCCCD.Location = new System.Drawing.Point(20, 30);
            this.lblSoCCCD.Name = "lblSoCCCD";
            this.lblSoCCCD.Size = new System.Drawing.Size(62, 13);
            this.lblSoCCCD.TabIndex = 0;
            this.lblSoCCCD.Text = "Số CCCD:";
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(10, 330);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.Size = new System.Drawing.Size(780, 220);
            this.dgvKhachHang.TabIndex = 2;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(550, 560);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(660, 560);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "fKhachHang";
            this.Text = "Quản Lý Khách Hàng";
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimTheoEmail;
        private System.Windows.Forms.Label lblTimTheoEmail;
        private System.Windows.Forms.TextBox txtTimTheoDienThoai;
        private System.Windows.Forms.Label lblTimTheoDienThoai;
        private System.Windows.Forms.TextBox txtTimTheoHoTen;
        private System.Windows.Forms.Label lblTimTheoHoTen;
        private System.Windows.Forms.TextBox txtTimTheoCCCD;
        private System.Windows.Forms.Label lblTimTheoCCCD;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtSoCCCD;
        private System.Windows.Forms.Label lblSoCCCD;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
    }
}