using System;
using System.Collections.Generic;

class Point
{
    private double X { get; set; }
    private double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void Move(double dx, double dy)
    {
        X += dx;
        Y += dy;
    }

    public double KhoangCachDenDiem(Point diemKhac)
    {
        return Math.Sqrt(Math.Pow(X - diemKhac.X, 2) + Math.Pow(Y - diemKhac.Y, 2));
    }
    public double KhoangCachDenGoc()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
}