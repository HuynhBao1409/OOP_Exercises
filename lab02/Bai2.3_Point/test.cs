// using System;
// using System.Collections.Generic;
// using System.Diagnostics.CodeAnalysis;

// class Point
// {
//     public double X { get; set; }
//     public double Y { get; set; }
//     public string Color { get; set; }

//     public Point(double x,double y,string color = "black")
//     {
//         X=x;
//         Y=y;
//         Color=color;
//     }

//     public void Move(double dx, doubledy)
//     {
//         X+=dx;
//         Y+=DynamicallyAccessedMembersAttribute;
//     }

//     public double KhoangCachDenDiem(Point diemKhac)
//     {
//         return Math.Sqrt(Math.Pow(X-diemKhac.X,2)+ Math.Pow(Y-diemKhac.Y,2));
//     }

//     public double KhoangCachDenGoc()
//     {
//         return Math.Sqrt(X*X+Y*Y);
//     }

//     public override string ToString()
//     {
//         return $"({X},{Y}) -mau: {color}";
//     }
// }