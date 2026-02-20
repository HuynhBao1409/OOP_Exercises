// 1. Cài đặt lớp Point mô tả các điểm trong mặt phẳng với các thuộc tính, phương thức sau
// - Thuộc tính:
// + x,y: tọa độ của điểm
// - Phương thức:
// + Hàm thiết lập khởi tạo tọa độ và màu cho điểm.
// + Hàm Move(double dx, double xy) di chuyển điểm với khoảng cách tương ứng dx, dy.

// 2. Chương trình chính:
// - Khai báo một danh sách đối tượng điểm.
// - In ra tọa độ của các điểm.
// - Tìm điểm cách xa gốc tọa độ nhất.
// - Tìm cặp điểm gần nhau nhất.

using System;
using System.Collections.Generic;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Color { get; set; }

    //Hàm thiết lập: Khởi tạo tọa độ,màu cho đỉm
    public Point(double x, double y, string color = "black")
    {
        X = x;
        Y = y;
        Color = color;
    }
    //Di chuyển theo dx, dy
    public void Move(double dx, double dy)
    {
        X += dx;
        Y += dy;
    }

    //Tinh khoang cach giua 2 diem bat ky
    public double KhoangCachDenDiem(Point diemKhac)
    {
        return Math.Sqrt(Math.Pow(X - diemKhac.X, 2) + Math.Pow(Y - diemKhac.Y, 2));
    }

    //Tinh khoang cách từ đỉm đến tọa độ 0(0,0)
    public double KhoangCachDenGoc()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    //Hiển thị thông tin điểm
    public override string ToString()
    {
        return $"({X}, {Y}) - màu: {Color}";
    }
}

class Program
{
    static void Main()
    {
        //Khai bao cac dim
        List<Point> danhSachDiem = new List<Point>
        {
            new Point(1, 2,"đỏ"),
            new Point(3, 4, "xanh dương"),
            new Point(-3, 2, "xanh lá"),
            new Point(0, 5, "vàng"),
            new Point(2, 7, "tím")
        };

        //In tọa độ tất cả các đỉm
        Console.WriteLine("==DANH SÁCH CÁC ĐIỂM==");
        for (int i = 0; i < danhSachDiem.Count; i++)
        {
            Console.WriteLine($"Điểm {i + 1}: {danhSachDiem[i]}");
        }
        //Tim Đỉm có khoảng cách xa gốc tọa đô nhất
        Point diemXaNhat = danhSachDiem[0];
        foreach (var d in danhSachDiem)
        {
            if (d.KhoangCachDenGoc() > diemXaNhat.KhoangCachDenGoc())
            {
                diemXaNhat = d;
            }
        }
        Console.WriteLine("\n===ĐIỂM XA GỐC TỌA ĐỘ NHẤT===");
        Console.WriteLine($"Điểm {diemXaNhat} - khoảng cách: {diemXaNhat.KhoangCachDenGoc():F2}");

        // Tìm cặp điểm gần nhau nhất bằng cách so sánh tất cả các cặp O(n²)
        Point diemA = danhSachDiem[0], diemB = danhSachDiem[1];
        double khoangCachNhoNhat = diemA.KhoangCachDenDiem(diemB);

        for (int i = 0; i < danhSachDiem.Count; i++)
        {
            for (int j = i + 1; j < danhSachDiem.Count; j++)
            {
                double kc = danhSachDiem[i].KhoangCachDenDiem(danhSachDiem[j]);
                if (kc < khoangCachNhoNhat)
                {
                    khoangCachNhoNhat = kc;
                    diemA = danhSachDiem[i];
                    diemB = danhSachDiem[j];
                }
            }
        }

        Console.WriteLine("\n=== CẶP ĐIỂM GẦN NHAU NHẤT ===");
        Console.WriteLine($"Điểm A: {diemA}");
        Console.WriteLine($"Điểm B: {diemB}");
        Console.WriteLine($"Khoảng cách: {khoangCachNhoNhat:F2}");
    }
}