using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QL_Dat_Phong_Khach_San
{
    public partial class fDatPhong: Form
    {
        public fDatPhong(string maNhanVien)
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fInBienNhan f = new fInBienNhan();
           
            f.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
