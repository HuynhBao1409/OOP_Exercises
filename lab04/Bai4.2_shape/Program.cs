using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Name { get; set; }
    public abstract double Area();
    public override string ToString() => $"{Name}: Area = {Area():F2}";
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
        Name = "Rectangle";
    }

    public override double Area() => Width * Height;
}

class Square : Rectangle
{
    public Square(double w) : base(w, w)
    {
        Name = "Square";
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
        Name = "Circle";
    }

    public override double Area() => Math.PI * radius * radius;
}

class Triangle : Shape
{
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        Name = "Triangle";
    }

    public override double Area()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        Console.Write("Nhập số hình vẽ: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Chọn loại hình (1: Rectangle, 2: Square, 3: Circle, 4: Triangle):");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Width Height: ");
                    var rParts = Console.ReadLine().Split();
                    shapes.Add(new Rectangle(double.Parse(rParts[0]), double.Parse(rParts[1])));
                    break;
                case 2:
                    Console.Write("Side: ");
                    shapes.Add(new Square(double.Parse(Console.ReadLine())));
                    break;
                case 3:
                    Console.Write("Radius: ");
                    shapes.Add(new Circle(double.Parse(Console.ReadLine())));
                    break;
                case 4:
                    Console.Write("a b c: ");
                    var tParts = Console.ReadLine().Split();
                    shapes.Add(new Triangle(double.Parse(tParts[0]), double.Parse(tParts[1]), double.Parse(tParts[2])));
                    break;
            }
        }

        // Hình có diện tích lớn nhất
        Shape largest = shapes[0];
        foreach (var s in shapes)
            if (s.Area() > largest.Area())
                largest = s;
        Console.WriteLine($"\nHình có diện tích lớn nhất: {largest}");

        // Sắp xếp giảm dần theo diện tích
        shapes.Sort((a, b) => b.Area().CompareTo(a.Area()));
        Console.WriteLine("\nDanh sách sắp xếp theo diện tích giảm dần:");
        foreach (var s in shapes)
            Console.WriteLine(s);
    }
}