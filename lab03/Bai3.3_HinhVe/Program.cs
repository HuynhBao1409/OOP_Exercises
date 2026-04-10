using System;

class HinhVe
{
    public virtual double DienTich() => 0;

    public virtual void Xuat()
    {
        Console.WriteLine($"Dien tich: {DienTich():F4}");
    }
}

class HinhChuNhat : HinhVe
{
    protected double dai, rong;

    public HinhChuNhat(double dai, double rong)
    {
        this.dai = dai;
        this.rong = rong;
    }

    public override double DienTich() => dai * rong;

    public override void Xuat()
    {
        Console.WriteLine("Hinh chu nhat");
        Console.WriteLine($"Chieu dai: {dai}");
        Console.WriteLine($"Chieu rong: {rong}");
        base.Xuat();
    }
}

class HinhVuong : HinhChuNhat
{
    public HinhVuong(double canh) : base(canh, canh) { }

    public override void Xuat()
    {
        Console.WriteLine("Hinh vuong");
        Console.WriteLine($"Canh: {dai}");
        Console.WriteLine($"Dien tich: {DienTich():F4}");
    }
}

class HinhTron : HinhVe
{
    private double r;

    public HinhTron(double r) { this.r = r; }

    public override double DienTich() => Math.PI * r * r;

    public override void Xuat()
    {
        Console.WriteLine("Hinh tron");
        Console.WriteLine($"Ban kinh: {r}");
        base.Xuat(); // Gọi HinhVe.Xuat() → in diện tích
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==== CHUONG TRINH CHON DIEN TICH ====");
        Console.WriteLine("1. Hinh chu nhat");
        Console.WriteLine("2. Hinh vuong");
        Console.WriteLine("3. Hinh tron");

        HinhVe hv = null;
        bool hopLe = false;

        do
        {
            Console.Write("Nhap lua chon (1/2/3): ");
            int loai = int.Parse(Console.ReadLine());

            if (loai == 1)
            {
                Console.Write("Nhap chieu dai: ");
                double dai = double.Parse(Console.ReadLine());
                Console.Write("Nhap chieu rong: ");
                double rong = double.Parse(Console.ReadLine());
                hv = new HinhChuNhat(dai, rong);
                hopLe = true;
            }
            else if (loai == 2)
            {
                Console.Write("Nhap do dai canh: ");
                double canh = double.Parse(Console.ReadLine());
                hv = new HinhVuong(canh);
                hopLe = true;
            }
            else if (loai == 3)
            {
                Console.Write("Nhap ban kinh: ");
                double r = double.Parse(Console.ReadLine());
                hv = new HinhTron(r);
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le, vui long nhap lai!");
            }
        } while (!hopLe);

        Console.WriteLine("\n=== Ket qua ===");
        hv.Xuat();
    }
}