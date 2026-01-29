/*
Một loại vi trùng cứ sau mỗi giờ lại nhân đôi. Hỏi ban đầu có n con vi trùng thì sau h giờ số lượng là bao nhiêu?

Input:
- Số lượng vi trùng ban đầu (con)
- Khoảng thời gian (giờ).

Output: Số lượng vi trùng sau khoảng thời gian đã cho.
*/
using System;
class Program
{
    static void Main()
    {
        //So luong virus ban dau
        Console.Write("Nhap so luong vi trung ban dau: ");
        int vr = int.Parse(Console.ReadLine());

        if (vr <= 0)
        {
            Console.WriteLine("So luong phai >= 0");
            return;
        }

        //Nhap khoang time
        Console.Write("Nhap thoi gian (gio): ");
        int time = int.Parse(Console.ReadLine());

        if (time <= 0)
        {
            Console.WriteLine("Thoi gian phai >= 0");
            return;
        }

        //tinh so luong virus sau time 
        //CT: quantity=vr * 2^time
        long quantity = (long)(vr * Math.Pow(2, time));

        Console.WriteLine($"So luong vi trung trong {time} la: {quantity}");
    }

}