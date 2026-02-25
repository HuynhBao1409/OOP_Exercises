// // 1. Cài đặt lớp Point mô tả các điểm trong mặt phẳng với các thuộc tính, phương thức sau
// // - Thuộc tính:
// // + x,y: tọa độ của điểm
// // - Phương thức:
// // + Hàm thiết lập khởi tạo tọa độ và màu cho điểm.
// // + Hàm Move(double dx, double xy) di chuyển điểm với khoảng cách tương ứng dx, dy.

// // 2. Chương trình chính:
// // - Khai báo một danh sách đối tượng điểm.
// // - In ra tọa độ của các điểm.
// // - Tìm điểm cách xa gốc tọa độ nhất.
// // - Tìm cặp điểm gần nhau nhất.
// using System;
// using System.Collections.Generic;

// class Point
// {
//     private double X{get;set;}
//     private double Y{get;set;}
//     public string Color{get;set;}

//     public Point(double x,double y, string color = "black")
//     {
//         X=x;
//         Y=y;
//         Color=color;
//     }

//     public void Move(double dx,double dy)
//     {
//         X+=dx;
//         Y+=dy;
//     }

//     public double KhoangCachDenDiem(Point diemKhac)
//     {
//         return Math.Sqrt(Math.Pow(X-diemKhac.X,2) + Math.Pow(Y-diemKhac,2));
//     }

//     public double KhoangCachDenGoc()
//     {
//         return Math.Sqrt(X*X + Y*Y);
//     }

//     public override string ToString()
//     {
//         return $"({X},{Y}) - mau: {Color}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Point> danhsachDiem = new List<Point>
//         {
//             new Point(1,2,"do"),
//             new Point(3,4, "xanh duong"),
//             new Point(3,7, "tim"),
//             new Point(1,9,"vang"),
//             new Point(-2,-4,"hong")
//         };

//         Console.WriteLine("asdasdas");
//         for(int i = 0; i < danhsachDiem; i++)
//         {
//             Console.WriteLine($"Diem {i + 1}: {danhsachDiem[i]}");
//         }

//         Point diemXaNhat = danhsachDiem[0];
//         foreach (var d in danhsachDiem)
//         {
//             if(d.KhoangCachDenGoc() > diemXaNhat.KhoangCachDenGoc())
//             {
//                 diemXaNhat = d;
//             }
//         }

//         Console.WriteLine($"Diem {diemXaNhat} - khoang cach: {diemXaNhat.KhoangCachDenGoc(): F2}");

//         Point diemA = danhsachDiem[0],diemB = danhsachDiem[1];
//         double khoangCachNhoNhat = diemA.KhoangCachDenDiem(diemB);

//         for(int i = 0; i < danhsachDiem.Count; i++)
//         {
//             for(int j = i + 1; j < danhsachDiem.Count; j++)
//             {
//                 double kc = danhsachDiem[i].KhoangCachDenDiem(danhsachDiem[j]);
//                 if (kc < khoangCachNhoNhat)
//                 {
//                     khoangCachNhoNhat=kc;
//                     diemA=danhsachDiem[i];
//                     diemB=danhsachDiem[j];
//                 }
//             }
//         }

//         Console.WriteLine($"dim a: {diemA}");
//         Console.WriteLine($"dim b: {diemB}");
//         Console.WriteLine($"Khoang cach: {khoangCachNhoNhat}:F2");
//     }
// }