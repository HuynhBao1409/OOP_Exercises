using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Name { get; set; }

    public abstract double Area();

    public virtual void Xuat()
    {
        Console.WriteLine($"Ten: {Name}");
        Console.WriteLine($"Dien tich: {Area():F2}");
    }
}

class HCM : Shape
{
    private double width;
    private double height;

    public HCM(double width, double height)
    {
        this.width = width;
        this.height = height;
        Name = "HCM";
    }

    public override double Area()
    {
        return width * height;
    }

    public override void Xuat()
    {
        Console.WriteLine("HCM");
        Console.WriteLine($"Dai: {width}");
        Console.WriteLine($"Rong: {height}");
        Console.WriteLine($"Dien Tich: {Area():F2}");

    }
}

class HV : HCM
{
    public HV(double canh) : base(canh, canh)
    {
        Name = "HV";

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
    private double R;
    public Circle(double R)
    {
        this.R = R;
        Name = "HTT";
    }

    public override double Area()
    {
        return Math.PI * R * R;
    }

    public override void Xuat()
    {
        Console.WriteLine("  [Hinh Tron]");
        Console.WriteLine($"  Radius: {R}");
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
        Name = "Tam giac";
    }

    public override double Area()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public override void Xuat()
    {
        Console.WriteLine("tam giac");
        Console.WriteLine($"a= {a},b= {b},c= {c}");
        Console.WriteLine($"  Diện tích: {Area():F2}");
    }
}

class test
{
    static void Main()
    {
        List<Shape> ds = new List<Shape>();

        Console.Write("Nhap so hinh ve: ");
        int n=int.Parse(Console.ReadLine());

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Hình thứ {i + 1} ---");
            Console.WriteLine("Chọn loại hình (1:HCN, 2:HV, 3:Circle, 4:Triangle): ");
            int loai=int.Parse(Console.ReadLine());

            if (loai == 1)
            {
               Console.Write("Width: ");
                double w = double.Parse(Console.ReadLine());
                Console.Write("Height: ");
                double h = double.Parse(Console.ReadLine());

                 ds.Add(new HCM(w,h));
            }
            else if (loai == 2)
            {
                Console.Write("Side: ");
                double canh=double.Parse(Console.ReadLine());
                ds.Add(new HV(canh));
            }
             else if (loai == 3)
            {
                Console.Write("Radius: ");
                double r = double.Parse(Console.ReadLine());
                shapes.Add(new Circle(r));
            }else if (loai == 4)
            {
                Console.Write("a: ");
                double a=double.Parse(Console.ReadLine());
                Console.Write("b: ");
                double b=double.Parse(Console.ReadLine());
                Console.Write("c: ");
                double c=double.Parse(Console.ReadLine());

                ds.Add(new Triangle(a,b,c));
                //ds=new Triangle(a,b,c);
            }
        }

        for(int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nHinh {i+1}: ");
            ds[i].Xuat();
        }

        Shape max = ds[0];
        foreach(Shape s in ds)
        {
            if (s.Area() > max.Area())
            {
                max=s;
            }
        }
        Console.WriteLine($"\nHinh co dien tich lon nhat {max.Name} - dien tich: {max.Area():F2}");

        ds.Sort((a,b)=>b.Area().CompareTo(a.Area()));
        for(int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nHình #{i + 1}:");
            ds[i].Xuat();
        }
    }
}