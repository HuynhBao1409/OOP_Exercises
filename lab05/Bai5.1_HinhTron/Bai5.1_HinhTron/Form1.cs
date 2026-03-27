using System;
using System.Windows.Forms;

namespace Bai5._1_HinhTron
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnChuVi.Click += (s, e) =>
            {
                if (double.TryParse(txtBanKinh.Text, out double r))
                    txtKetQua.Text = $"Chu vi hình tròn = {2 * Math.PI * r:F5}";
                else
                    MessageBox.Show("Bán kính không hợp lệ!");
            };

            btnDienTich.Click += (s, e) =>
            {
                if (double.TryParse(txtBanKinh.Text, out double r))
                    txtKetQua.Text = $"Diện tích hình tròn = {Math.PI * r * r:F5}";
                else
                    MessageBox.Show("Bán kính không hợp lệ!");
            };

            btnThoat.Click += (s, e) => Close();
        }

        private void lblBanKinh_Click(object sender, EventArgs e)
        {

        }

        private void txtBanKinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
