using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Name { get; set; }
    public abstract double Area();

    public virtual void Xuat()
    {
        Console.WriteLine($"  Tên: {Name}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class Rectangle : Shape
{
    protected double width;
    protected double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
        Name = "Hinh Chu Nhat";
    }

    public override double Area() => width * height;

    public override void Xuat()
    {
        Console.WriteLine("  [Hinh Chu Nhat]");
        Console.WriteLine($"  Width : {width}");
        Console.WriteLine($"  Height: {height}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class Square : Rectangle
{
    public Square(double w) : base(w, w)
    {
        Name = "Hinh Vuong";
    }

    public override void Xuat()
    {
        Console.WriteLine("  [Hinh Vuong]");
        Console.WriteLine($"  Cạnh: {width}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
        Name = "Hinh Vuong";
    }

    public override double Area() => Math.PI * radius * radius;

    public override void Xuat()
    {
        Console.WriteLine("  [Hinh Tron]");
        Console.WriteLine($"  Radius: {radius}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class Triangle : Shape
{
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        Name = "Tam Giac";
    }

    public override double Area()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public override void Xuat()
    {
        Console.WriteLine("  [Tam Giac]");
        Console.WriteLine($"  a={a}, b={b}, c={c}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Shape> shapes = new List<Shape>();

        Console.Write("Nhập số hình vẽ: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Hình thứ {i + 1} ---");
            Console.WriteLine("Chọn loại hình (1:HCN, 2:HV, 3:Circle, 4:Triangle): ");
            int loai = int.Parse(Console.ReadLine());

            if (loai == 1)
            {
                Console.Write("Width: ");
                double w = double.Parse(Console.ReadLine());
                Console.Write("Height: ");
                double h = double.Parse(Console.ReadLine());
                shapes.Add(new Rectangle(w, h));
            }
            else if (loai == 2)
            {
                Console.Write("Side: ");
                double s = double.Parse(Console.ReadLine());
                shapes.Add(new Square(s));
            }
            else if (loai == 3)
            {
                Console.Write("Radius: ");
                double r = double.Parse(Console.ReadLine());
                shapes.Add(new Circle(r));
            }
            else if (loai == 4)
            {
                Console.Write("a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c: ");
                double c = double.Parse(Console.ReadLine());
                shapes.Add(new Triangle(a, b, c));
            }
        }

        // In danh sách
        Console.WriteLine("\n========== Danh sách hình vẽ ==========");
        for (int i = 0; i < shapes.Count; i++)
        {
            Console.WriteLine($"\nHình #{i + 1}:");
            shapes[i].Xuat();
        }

        // Tìm hình lớn nhất
        Shape largest = shapes[0];
        foreach (Shape s in shapes)
            if (s.Area() > largest.Area())
                largest = s;
        Console.WriteLine($"\nHình có diện tích lớn nhất: {largest.Name} - {largest.Area():F2}");

        // Sắp xếp giảm dần
        shapes.Sort((a, b) => b.Area().CompareTo(a.Area()));
        Console.WriteLine("\n==== Danh sách sau khi sắp xếp (giảm dần) ====");
        for (int i = 0; i < shapes.Count; i++)
        {
            Console.WriteLine($"\nHình #{i + 1}:");
            shapes[i].Xuat();
        }
    }
}