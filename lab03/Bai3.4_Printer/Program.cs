using System;
using System.Collections.Generic;

class Printer
{
    protected string nhaSanXuat;
    protected double gia;

    public Printer()
    {
        nhaSanXuat = "";
        gia = 0;
    }

    public Printer(string nhaSanXuat, double gia)
    {
        this.nhaSanXuat = nhaSanXuat;
        this.gia = gia;
    }

    public string GetNhaSanXuat() { return nhaSanXuat; }
    public double GetGia() { return gia; }

    public virtual void Nhap()
    {
        Console.Write("  Nhà sản xuất: ");
        nhaSanXuat = Console.ReadLine();
        Console.Write("  Giá bán (triệu): ");
        gia = double.Parse(Console.ReadLine());
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"  Nhà sản xuất : {nhaSanXuat}");
        Console.WriteLine($"  Giá bán      : {gia} (triệu)");
    }
}

class LaserPrinter : Printer
{
    private string doPhanGiai;

    public LaserPrinter() : base()
    {
        doPhanGiai = "";
    }

    public LaserPrinter(string nhaSanXuat, double gia, string doPhanGiai) : base(nhaSanXuat, gia)
    {
        this.doPhanGiai = doPhanGiai;
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("  Độ phân giải (vd: 1200x1200): ");
        doPhanGiai = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"  Độ phân giải : {doPhanGiai}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Nhập số lượng máy in: ");
        int n = int.Parse(Console.ReadLine());

        List<LaserPrinter> ds = new List<LaserPrinter>();

        // Nhập danh sách
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n=== Máy in thứ {i + 1} ===");
            LaserPrinter lp = new LaserPrinter();
            lp.Nhap();
            ds.Add(lp);
        }

        // In danh sách
        Console.WriteLine("\n========== DANH SÁCH MÁY IN ==========");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\n[Máy in {i + 1}]");
            ds[i].Xuat();
        }

        // Tìm min/max
        LaserPrinter Min = ds[0];
        LaserPrinter Max = ds[0];
        foreach (LaserPrinter lp in ds)
        {
            if (lp.GetGia() < Min.GetGia()) Min = lp;
            if (lp.GetGia() > Max.GetGia()) Max = lp;
        }

        Console.WriteLine("\n========== MÁY IN GIÁ THẤP NHẤT ==========");
        Min.Xuat();

        Console.WriteLine("\n========== MÁY IN GIÁ CAO NHẤT ==========");
        Max.Xuat();

        // Lọc theo hãng
        Console.Write("\nNhập hãng cần lọc: ");
        string hang = Console.ReadLine();

        Console.WriteLine($"\n========== MÁY IN HÃNG {hang.ToUpper()} ==========");
        bool timThay = false;
        foreach (LaserPrinter lp in ds)
        {
            if (lp.GetNhaSanXuat().ToLower() == hang.ToLower())
            {
                lp.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
            Console.WriteLine($"  Không tìm thấy máy in hãng {hang}.");

        // Sắp xếp theo giá tăng dần
        ds.Sort((a, b) => a.GetGia().CompareTo(b.GetGia()));

        Console.WriteLine("\n========== DANH SÁCH SAU SẮP XẾP (GIÁ TĂNG DẦN) ==========");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\n[Máy in {i + 1}]");
            ds[i].Xuat();
        }

        Console.WriteLine("\nNhấn Enter để thoát...");
        Console.ReadLine();
    }
}