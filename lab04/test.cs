using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Name { get; set; }
    public abstract double Area();

    public virtual void Xuat()
    {
        Console.WriteLine($"Ten {Name}");
        Console.WriteLine($"DT: {Area():F2}");
    }
}

class HCM : Shape
{
    protected double width;
    protected double height;

    public HCM(double width, double height)
    {
        this.width = width;
        this.height = height;
        Name = "HCM";
    }

    public override double Area()
    {
        width* height;
    }

    public override void Xuat()
    {
        Console.WriteLine("  [Hinh Chu Nhat]");
        Console.WriteLine($"  Width : {width}");
        Console.WriteLine($"  Height: {height}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class HV : HCM
{
    public HV(double w) : base(w, w)
    {
        Name = "HV";
    }

    public override void Xuat()
    {
        Console.WriteLine("[HV]");
        Console.WriteLine($"Canh {width}");
        Console.WriteLine($"DT: {Area():F2}");
    }
}
class HT : Shape
{
    private double r;
    public HT(double r)
    {
        this.r = r;
        Name = "HT";
    }
}

class TG : Shape
{
    private double a, b, c;
    public TG(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        Name = "TG";
    }

    public override double Area()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public override void Xuat()
    {
        Console.WriteLine($"[TG]");
        Console.WriteLine($"a={a}, b={b}, c={c}");
        Console.WriteLine($"DT: {Area():F2}");
    }
}

class test
{
    static void Main()
    {
        List<Shape> shape = new List<Shape>();

        Console.Write("Nhap so hinh ve");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n hinh {i + 1}");
            Console.WriteLine($"chon hinh");
            int loai = int.Parse(Console.ReadLine());

            if (loai == 1)
            {
                Console.Write("with:");
                double w = double.Parse(Console.ReadLine());
                Console.Write("Height: ");
                double h = double.Parse(Console.ReadLine());

                shape.Add(new HCM(w, h));
            }
            else if (loai == 2)
            {
                Console.WriteLine("Sile: ");
                double s = double.Parse(Console.ReadLine());
                shape.Add(new HV(s));
            }
            else if (loai == 3)
            {
                Console.WriteLine("HT: ");
                double r = double.Parse(Console.ReadLine());
                shape.Add(new HT());
            }
            else if (loai == 4)
            {
                Console.WriteLine("a: ");
                double a=double.Parse(Console.ReadLine());
                Console.WriteLine("b: ");
                double b=double.Parse(Console.ReadLine());
                Console.WriteLine("c: ");
                double c=double.Parse(Console.ReadLine());
                shape.Add(new HT(a,b,c));

            }
        }

        Console.WriteLine("\nDanh sach hinh ve");
        for(int i = 0; i < shape.Count; i++)
        {
            Console.WriteLine($"\nHinh{i+1}");
            shape[i].Xuat();
        }

        Shape max=shape[0];
        foreach(Shape s in shape)
        {
            if (s.Area() > max.Area())
            {
                max=s;
            }
        }
        Console.WriteLine($"Lon nhat- {max.Name}-{max.Area():F2}");

        shape.Sort((a,b)=>b.Area().CompareTo(a.Area()));

        for(int i; i < shape.Count; i++)
        {
            Console.WriteLine($"\nHinh{i+1}");
            shape[i].Xuat();
        }
    }
}