﻿namespace BTL_QL_Dat_Phong_Khach_San
{
    partial class fHoaDon
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBoxTimKiem = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.txtMaHoaDonTim = new System.Windows.Forms.TextBox();
            this.labelDen = new System.Windows.Forms.Label();
            this.labelTu = new System.Windows.Forms.Label();
            this.labelMaHD = new System.Windows.Forms.Label();
            this.groupBoxChiTiet = new System.Windows.Forms.GroupBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.labelTong = new System.Windows.Forms.Label();
            this.txtNgayLap = new System.Windows.Forms.TextBox();
            this.labelNgayLap = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.labelMaHDChiTiet = new System.Windows.Forms.Label();
            this.groupBoxDanhSachHoaDon = new System.Windows.Forms.GroupBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.groupBoxDanhSachDichVu = new System.Windows.Forms.GroupBox();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBoxTimKiem.SuspendLayout();
            this.groupBoxChiTiet.SuspendLayout();
            this.groupBoxDanhSachHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.groupBoxDanhSachDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTimKiem
            // 
            this.groupBoxTimKiem.Controls.Add(this.btnLamMoi);
            this.groupBoxTimKiem.Controls.Add(this.btnTim);
            this.groupBoxTimKiem.Controls.Add(this.dtpDen);
            this.groupBoxTimKiem.Controls.Add(this.dtpTu);
            this.groupBoxTimKiem.Controls.Add(this.txtMaHoaDonTim);
            this.groupBoxTimKiem.Controls.Add(this.labelDen);
            this.groupBoxTimKiem.Controls.Add(this.labelTu);
            this.groupBoxTimKiem.Controls.Add(this.labelMaHD);
            this.groupBoxTimKiem.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTimKiem.Name = "groupBoxTimKiem";
            this.groupBoxTimKiem.Size = new System.Drawing.Size(200, 150);
            this.groupBoxTimKiem.TabIndex = 0;
            this.groupBoxTimKiem.TabStop = false;
            this.groupBoxTimKiem.Text = "Tìm kiếm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(100, 110);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(20, 110);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dtpDen
            // 
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.Location = new System.Drawing.Point(50, 80);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(130, 20);
            this.dtpDen.TabIndex = 5;
            // 
            // dtpTu
            // 
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.Location = new System.Drawing.Point(50, 50);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(130, 20);
            this.dtpTu.TabIndex = 4;
            // 
            // txtMaHoaDonTim
            // 
            this.txtMaHoaDonTim.Location = new System.Drawing.Point(50, 20);
            this.txtMaHoaDonTim.Name = "txtMaHoaDonTim";
            this.txtMaHoaDonTim.Size = new System.Drawing.Size(130, 20);
            this.txtMaHoaDonTim.TabIndex = 3;
            // 
            // labelDen
            // 
            this.labelDen.AutoSize = true;
            this.labelDen.Location = new System.Drawing.Point(20, 80);
            this.labelDen.Name = "labelDen";
            this.labelDen.Size = new System.Drawing.Size(30, 13);
            this.labelDen.TabIndex = 2;
            this.labelDen.Text = "Đến";
            // 
            // labelTu
            // 
            this.labelTu.AutoSize = true;
            this.labelTu.Location = new System.Drawing.Point(20, 50);
            this.labelTu.Name = "labelTu";
            this.labelTu.Size = new System.Drawing.Size(20, 13);
            this.labelTu.TabIndex = 1;
            this.labelTu.Text = "Từ";
            // 
            // labelMaHD
            // 
            this.labelMaHD.AutoSize = true;
            this.labelMaHD.Location = new System.Drawing.Point(20, 20);
            this.labelMaHD.Name = "labelMaHD";
            this.labelMaHD.Size = new System.Drawing.Size(40, 13);
            this.labelMaHD.TabIndex = 0;
            this.labelMaHD.Text = "Mã HD";
            // 
            // groupBoxChiTiet
            // 
            this.groupBoxChiTiet.Controls.Add(this.txtTong);
            this.groupBoxChiTiet.Controls.Add(this.labelTong);
            this.groupBoxChiTiet.Controls.Add(this.txtNgayLap);
            this.groupBoxChiTiet.Controls.Add(this.labelNgayLap);
            this.groupBoxChiTiet.Controls.Add(this.txtMaHoaDon);
            this.groupBoxChiTiet.Controls.Add(this.labelMaHDChiTiet);
            this.groupBoxChiTiet.Location = new System.Drawing.Point(12, 170);
            this.groupBoxChiTiet.Name = "groupBoxChiTiet";
            this.groupBoxChiTiet.Size = new System.Drawing.Size(200, 150);
            this.groupBoxChiTiet.TabIndex = 1;
            this.groupBoxChiTiet.TabStop = false;
            this.groupBoxChiTiet.Text = "Chi tiết hóa đơn";
            // 
            // txtTong
            // 
            this.txtTong.Location = new System.Drawing.Point(50, 110);
            this.txtTong.Name = "txtTong";
            this.txtTong.ReadOnly = true;
            this.txtTong.Size = new System.Drawing.Size(130, 20);
            this.txtTong.TabIndex = 5;
            // 
            // labelTong
            // 
            this.labelTong.AutoSize = true;
            this.labelTong.Location = new System.Drawing.Point(20, 110);
            this.labelTong.Name = "labelTong";
            this.labelTong.Size = new System.Drawing.Size(40, 13);
            this.labelTong.TabIndex = 4;
            this.labelTong.Text = "Tổng";
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.Location = new System.Drawing.Point(50, 80);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.Size = new System.Drawing.Size(130, 20);
            this.txtNgayLap.TabIndex = 3;
            // 
            // labelNgayLap
            // 
            this.labelNgayLap.AutoSize = true;
            this.labelNgayLap.Location = new System.Drawing.Point(20, 80);
            this.labelNgayLap.Name = "labelNgayLap";
            this.labelNgayLap.Size = new System.Drawing.Size(50, 13);
            this.labelNgayLap.TabIndex = 2;
            this.labelNgayLap.Text = "Ngày lập";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(50, 50);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.ReadOnly = true;
            this.txtMaHoaDon.Size = new System.Drawing.Size(130, 20);
            this.txtMaHoaDon.TabIndex = 1;
            // 
            // labelMaHDChiTiet
            // 
            this.labelMaHDChiTiet.AutoSize = true;
            this.labelMaHDChiTiet.Location = new System.Drawing.Point(20, 50);
            this.labelMaHDChiTiet.Name = "labelMaHDChiTiet";
            this.labelMaHDChiTiet.Size = new System.Drawing.Size(40, 13);
            this.labelMaHDChiTiet.TabIndex = 0;
            this.labelMaHDChiTiet.Text = "Mã HD";
            // 
            // groupBoxDanhSachHoaDon
            // 
            this.groupBoxDanhSachHoaDon.Controls.Add(this.dgvHoaDon);
            this.groupBoxDanhSachHoaDon.Location = new System.Drawing.Point(220, 12);
            this.groupBoxDanhSachHoaDon.Name = "groupBoxDanhSachHoaDon";
            this.groupBoxDanhSachHoaDon.Size = new System.Drawing.Size(550, 308);
            this.groupBoxDanhSachHoaDon.TabIndex = 2;
            this.groupBoxDanhSachHoaDon.TabStop = false;
            this.groupBoxDanhSachHoaDon.Text = "Danh sách hóa đơn";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(10, 20);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(530, 278);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);
            // 
            // groupBoxDanhSachDichVu
            // 
            this.groupBoxDanhSachDichVu.Controls.Add(this.dgvDichVu);
            this.groupBoxDanhSachDichVu.Location = new System.Drawing.Point(12, 330);
            this.groupBoxDanhSachDichVu.Name = "groupBoxDanhSachDichVu";
            this.groupBoxDanhSachDichVu.Size = new System.Drawing.Size(758, 150);
            this.groupBoxDanhSachDichVu.TabIndex = 3;
            this.groupBoxDanhSachDichVu.TabStop = false;
            this.groupBoxDanhSachDichVu.Text = "Danh sách dịch vụ";
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Location = new System.Drawing.Point(10, 20);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.Size = new System.Drawing.Size(738, 120);
            this.dgvDichVu.TabIndex = 0;
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Location = new System.Drawing.Point(590, 490);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(75, 23);
            this.btnInHoaDon.TabIndex = 4;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(690, 490);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // fHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.groupBoxDanhSachDichVu);
            this.Controls.Add(this.groupBoxDanhSachHoaDon);
            this.Controls.Add(this.groupBoxChiTiet);
            this.Controls.Add(this.groupBoxTimKiem);
            this.Name = "fHoaDon";
            this.Text = "Quản lý hóa đơn";
            this.groupBoxTimKiem.ResumeLayout(false);
            this.groupBoxTimKiem.PerformLayout();
            this.groupBoxChiTiet.ResumeLayout(false);
            this.groupBoxChiTiet.PerformLayout();
            this.groupBoxDanhSachHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.groupBoxDanhSachDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.TextBox txtMaHoaDonTim;
        private System.Windows.Forms.Label labelDen;
        private System.Windows.Forms.Label labelTu;
        private System.Windows.Forms.Label labelMaHD;
        private System.Windows.Forms.GroupBox groupBoxChiTiet;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Label labelTong;
        private System.Windows.Forms.TextBox txtNgayLap;
        private System.Windows.Forms.Label labelNgayLap;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label labelMaHDChiTiet;
        private System.Windows.Forms.GroupBox groupBoxDanhSachHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.GroupBox groupBoxDanhSachDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnDong;
    }
}