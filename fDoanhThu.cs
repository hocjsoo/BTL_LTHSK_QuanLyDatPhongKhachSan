using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BTL_QL_Dat_Phong_Khach_San.Forms
{
    public partial class fDoanhThu : Form
    {
        public fDoanhThu()
        {
            InitializeComponent();
            dtpTuNgay.Value = DateTime.Now.AddDays(-30); // Mặc định 30 ngày trước
            dtpDenNgay.Value = DateTime.Now; // Mặc định là ngày hiện tại
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày 'Từ' phải nhỏ hơn hoặc bằng ngày 'Đến'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo đối tượng báo cáo
                CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                string reportPath = Application.StartupPath + "\\rptDoanhThu.rpt";
                report.Load(reportPath);

                // Thiết lập tham số cho báo cáo
                report.SetParameterValue("TuNgay", dtpTuNgay.Value);
                report.SetParameterValue("DenNgay", dtpDenNgay.Value);

                // Gán báo cáo cho CrystalReportViewer
                crvDoanhThu.ReportSource = report;
                crvDoanhThu.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}