using System;
using System.Windows.Forms;

namespace TinhTienTaxi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hàm tính tiền dựa vào quãng đường và loại xe
        private double TinhTien(double km, bool la7cho)
        {
            double tien = 0;

            // Giá mở cửa (0 - 1 km đầu)
            double giaMoCua = la7cho ? 17000 : 15000;
            // Giá từ km 2 đến km 5
            double gia2den5 = la7cho ? 15000 : 13500;
            // Giá từ km 6 đến km 100
            double gia6den100 = la7cho ? 12000 : 11000;
            // Giá từ km 101 trở đi
            double giaTren100 = la7cho ? 11000 : 10000;

            if (km <= 1)
            {
                // Trong khoảng 0 - 1 km: tính giá mở cửa
                tien = giaMoCua;
            }
            else if (km <= 5)
            {
                // 1 km đầu + phần còn lại (km 2 -> km hiện tại)
                tien = giaMoCua + (km - 1) * gia2den5;
            }
            else if (km <= 100)
            {
                // 1 km đầu + 4 km tiếp (km 2-5) + phần còn lại (km 6 -> km hiện tại)
                tien = giaMoCua + 4 * gia2den5 + (km - 5) * gia6den100;
            }
            else
            {
                // 1 km đầu + 4 km (2-5) + 95 km (6-100) + phần còn lại từ km 101
                tien = giaMoCua + 4 * gia2den5 + 95 * gia6den100 + (km - 100) * giaTren100;
            }

            return tien;
        }

        // Sự kiện nhập quãng đường hoặc thay đổi lựa chọn -> tự động tính
        private void TinhVaHienThi()
        {
            // Kiểm tra quãng đường có hợp lệ không
            if (!double.TryParse(txtKmInput.Text, out double km) || km < 0)
            {
                lblResult.Text = "0";
                return;
            }

            // Xác định loại xe (radio button)
            bool la7cho = rdo7Cho.Checked;

            // Tính tiền
            double tien = TinhTien(km, la7cho);

            // Áp dụng giảm giá 5% nếu checkbox được chọn
            if (chkGiamGia.Checked)
                tien *= 0.95;

            // Hiển thị kết quả (làm tròn)
            lblResult.Text = ((long)tien).ToString();
        }

        // Sự kiện khi nội dung TextBox thay đổi
        private void txtKmInput_TextChanged(object sender, EventArgs e)
        {
            TinhVaHienThi();
        }

        // Sự kiện khi chọn loại xe 7 chỗ
        private void rdo7Cho_CheckedChanged(object sender, EventArgs e)
        {
            TinhVaHienThi();
        }

        // Sự kiện khi chọn loại xe 4 chỗ
        private void rdo4Cho_CheckedChanged(object sender, EventArgs e)
        {
            TinhVaHienThi();
        }

        // Sự kiện khi tick/bỏ tick checkbox Giảm giá
        private void chkGiamGia_CheckedChanged(object sender, EventArgs e)
        {
            TinhVaHienThi();
        }

        // Nút Thoát - đóng ứng dụng
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}