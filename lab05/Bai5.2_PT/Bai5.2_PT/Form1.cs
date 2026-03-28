using System;
using System.Windows.Forms;
namespace Bai5._2_PT
{

        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();

                btnGiai.Click += (s, e) => {
                    if (!double.TryParse(txtA.Text, out double a) ||
                        !double.TryParse(txtB.Text, out double b) ||
                        !double.TryParse(txtC.Text, out double c))
                    {
                        MessageBox.Show("Hệ số không hợp lệ!");
                        return;
                    }

                    if (a == 0)
                    {
                        txtKetQua.Text = "Không phải phương trình bậc 2!";
                        return;
                    }

                    double delta = b * b - 4 * a * c;

                    if (delta < 0)
                        txtKetQua.Text = "Phương trình vô nghiệm";
                    else if (delta == 0)
                        txtKetQua.Text = $"Phương trình có nghiệm kép x = {(-b / (2 * a)):F3}";
                    else
                    {
                        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                        txtKetQua.Text = $"Phương trình có 2 nghiệm x1 = {x1:F3} x2 = {x2:F3}";
                    }
                };

                btnThoat.Click += (s, e) => Close();
            }
        }
}
