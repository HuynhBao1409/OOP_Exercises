// 1. Cài đặt lớp Circle mô tả các hình tròn, với các thuộc tính, phương thức sau
// - Thuộc tính:
// + r: bán kính
// + c: tâm hình tròn, với c là đối tượng của lớp Point đã cài đặt ở Bài 2.3
// - Phương thức:
// + Hàm thiết lập khởi tạo hình tròn.
// + Hàm Area() tính diện tích hình tròn.
// + Hàm Move(double dx, double xy) di chuyển hình tròn với khoảng cách tương ứng dx, dy.

// 2. Chương trình chính
// - Khởi tạo một vài đối tượng hình tròn và sử dụng các phương thức đã cài đặt để kiểm tra kết quả.

using System;
using System.Collections.Generic;

class Point
{
    private double X { get; set; }
    private double Y { get; set; }

    //Khởi tạo hàm tọa độ
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    //Di chuyển điểm theo k/cách dx, dy
    public void Move(double dx, double dy)
    {
        X += dx;
        Y += dy;
    }
    // Tính khoảng cách từ điểm hiện tại đến một điểm bất kỳ khác
    public double KhoangCachDenDiem(Point diemKhac)
    {
        return Math.Sqrt(Math.Pow(X - diemKhac.X, 2) + Math.Pow(Y - diemKhac.Y, 2));
    }
    // Tính khoảng cách từ điểm đến gốc tọa độ O(0,0)
    public double KhoangCachDenGoc()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }

}

class Circle
{
    public double R { get; set; }// bán kính
    public Point C { get; set; } // tâm hình tròn

    // Hàm thiết lập: nhận bán kính và đối tượng Point làm tâm
    public Circle(double r, Point c)
    {
        R = r;
        C = c;
    }

    // Hàm thiết lập tiện lợi: nhận bán kính và tọa độ x, y
    public Circle(double r, double x, double y)
    {
        R = r;
        C = new Point(x, y);
    }

    // Tính diện tích
    public double Area()
    {
        return Math.PI * R * R;
    }

    // Di chuyển hình tròn (thực chất là di chuyển tâm)
    public void Move(double dx, double dy)
    {
        C.Move(dx, dy); //tai sdung Move
    }

    public override string ToString()
    {
        return $"Hình Tròn [Tâm: {C}, Bán Kính: {R}]";
    }
}
class Program
{
    static void Main()
    {
        List<Circle> dSHinhTron = new List<Circle>
        {
            new Circle(5, new Point(0,0)),
            new Circle(3, new Point(3,5)),
            new Circle(7, new Point(2,4)),
            new Circle(4, new Point(1,6)),
        };

        Console.WriteLine("===Danh sách hình tròn===");
        foreach (var ht in dSHinhTron)
        {
            Console.WriteLine($"{ht} - Diện tích: {ht.Area():F2}");
        }

        Console.WriteLine("===Di chuyển hình tròn 1===");
        dSHinhTron[0].Move(3, 6);
        Console.WriteLine($"Sau khi di chuyển: {dSHinhTron[0]}");

        //Tìm hình tròn có diện tích lớn nhất
        Circle htLonNhat = dSHinhTron[0];
        foreach (var ht in dSHinhTron)
        {
            if (ht.Area() > htLonNhat.Area())
            {
                htLonNhat = ht;
            }
        }

        Console.WriteLine("\n=== HÌNH TRÒN CÓ DIỆN TÍCH LỚN NHẤT ===");
        Console.WriteLine($"{htLonNhat} - Diện tích: {htLonNhat.Area():F2}");
    }
}