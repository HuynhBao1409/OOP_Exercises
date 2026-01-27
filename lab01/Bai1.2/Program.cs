/*
Viết chương trình nhập từ bàn phím hai số nguyên a, b và một ký tự ch.
Nếu:
- ch là "+" thì thực hiện phép tính a + b và in kết quả lên màn hình.
- ch là "–" thì thực hiện phép tính a - b và in kết quả lên màn hình.
- ch là "*" thì thực hiện phép tính a * b và in kết quả lên màn hình.
- ch là "/" thì thực hiện phép tính a / b và in kết quả lên màn hình. 
Lưu ý kiểm tra điều kiện của phép chia. Nếu b == 0 thì in ra thông báo "Error!"
*/

using System;

namespace Calculator
{
    class Program
    {
        public static void Main()
        {
            int a, b;
            bool readNum = false;

            //Ktra input so thu nhat, so thu 2
            do
            {
                Console.Write("Nhap so thu nhat: ");
                readNum = int.TryParse(Console.ReadLine(), out a);
            } while (!readNum);

            do
            {
                Console.Write("Nhap so thu hai: ");
                readNum = int.TryParse(Console.ReadLine(), out b);
            } while (!readNum);

            Console.Write("Nhap phep tinh (+,-,*,/): ");
            char ch = Console.ReadKey().KeyChar;

            //Ktra phep tinh va in ket qua
            switch (ch)
            {
                case '+': Console.WriteLine("\n{0}+{1}={2}", a, b, a + b); break;
                case '-': Console.WriteLine("\n{0} - {1} = {2}", a, b, a - b); break;
                case '*': Console.WriteLine("\n{0} * {1} = {2}", a, b, a * b); break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Khong chia duoc!!");
                    }
                    else
                    {
                        Console.WriteLine("\n {0}/{1}={2}", a, b, (double)a / b);
                    }
                    break;
                default: Console.WriteLine("\n Khong biet phep toan!"); break;
            }
        }
    }
}