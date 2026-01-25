//Tinh tien dien
/*
Viết chương trình tính tiền điện phải trả dựa vào số kWh tiêu thụ và bảng giá.

Bảng giá:
Số kWh <= 100: 2000 đ/kWh
Từ kWh thứ 101 đến 150: 2500 đ/kWh
Từ kWh thứ 151 trở đi 3000 đ/kWh
Nếu số kWh tiêu thụ vượt quá 300 thì cộng thêm 10% tiền phải trả.

Input: Số kWh tiêu thụ
Output: Số tiền phải thanh toán (VND)
*/

using System;

namespace TinhTienDien
{
    class Program
    {
        //Khai bao
        const int Muc1 = 100, Muc2 = 150, Muc3 = 300;
        const int Gia1 = 2000, Gia2 = 2500, Gia3 = 3000;
        static void Main()
        {
            int kWh = 0;
            double soTien = 0;
            bool Nhaphople = false;
            //ktra dau vao
            do
            {
                //Nhap so kwh
                Console.Write("Nhap so kWh: ");
                string input = Console.ReadLine();

                //Ktra input
                if (int.TryParse(input, out kWh))
                {
                    if (kWh >= 0)
                    {
                        Nhaphople = true;
                    }
                    else
                    {
                        Console.WriteLine("Nhap lai >0 !!");
                    }
                }
                else
                {
                    Console.WriteLine("Ko hop le");
                }
            } while (!Nhaphople);

            //Tinh tien dien

            if (kWh <= 100)
            {
                soTien = kWh * Gia1;
            }
            else if (kWh <= 150)
            {
                soTien = Muc1 * Gia1 + (kWh - Muc1) * Gia2;
            }
            else if (kWh <= 300)
            {
                soTien = Muc1 * Gia1 + (Muc2 - Muc1) * Gia2 + (kWh - Muc2) * Gia3;
            }
            //Neu cao hon 300 tang 10% gia tien
            else
            {
                soTien = (Muc1 * Gia1 + (Muc2 - Muc1) * Gia2 + (kWh - Muc2) * Gia3) * 1.1;
            }

            //Output
            Console.WriteLine("So kWh: {0}, Tong so tien: {1:N0} (vnd)", kWh, soTien);
        }

    }
}