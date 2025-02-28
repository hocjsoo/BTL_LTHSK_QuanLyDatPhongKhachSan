using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fInBienNhan: Form
    {
        public fInBienNhan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveReceiptAsImage();
        }
        private void SaveReceiptAsImage()
        {
            // Tạo một Bitmap với kích thước cố định (ví dụ: 400x600 px)
            using (Bitmap bitmap = new Bitmap(400, 600))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Thiết lập nền trắng
                    g.Clear(Color.White);

                    // Thiết lập font chữ
                    Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                    Font regularFont = new Font("Arial", 12);

                    // Vị trí bắt đầu
                    int x = 50; // Lề trái
                    int y = 50; // Lề trên

                    // Vẽ nội dung lên Bitmap
                    g.DrawString("BIÊN NHẬN ĐẶT PHÒNG", titleFont, Brushes.Black, x, y);
                    y += 50;
                    g.DrawString($"Mã đặt phòng: {textBox1.Text}", regularFont, Brushes.Black, x, y);
                    y += 25;
                    g.DrawString($"Khách hàng: {textBox2.Text}", regularFont, Brushes.Black, x, y);
                    y += 25;
                    g.DrawString($"Phòng: {textBox3.Text}", regularFont, Brushes.Black, x, y);
                    y += 25;
                    g.DrawString($"Thời gian: {textBox4.Text}", regularFont, Brushes.Black, x, y);
                    y += 25;
                    g.DrawString($"Tổng chi phí: {textBox5.Text}", regularFont, Brushes.Black, x, y);
                    y += 25;
                    g.DrawString($"Thanh toán: {textBox6.Text}", regularFont, Brushes.Black, x, y);
                }

                // Đường dẫn lưu file (ví dụ: thư mục "Receipts" trong ổ D)
                string folderPath = @"C:\Users\ADMIN\OneDrive\Hình ảnh\Thư mục mới (5)";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath); // Tạo thư mục nếu chưa có
                }

                // Tạo tên file duy nhất (dùng mã đặt phòng + timestamp)
                string fileName = $"Receipt_{textBox1.Text}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.png";
                string filePath = Path.Combine(folderPath, fileName);

                // Lưu ảnh
                bitmap.Save(filePath, ImageFormat.Png);

                // Thông báo thành công
                MessageBox.Show($"Hóa đơn đã được lưu tại: {filePath}");
            }
        }
    }
}
