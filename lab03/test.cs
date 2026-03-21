using System;
using System.Collections.Generic;

class HinhVe
{
    public virtual double DienTich()
    {
        return 0;
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Dt: {DienTich()}");
    }
}

class HinhChuNhat : HinhVe
{
    protected double chieuDai;
    protected double chieuRong;

    public HinhChuNhat()
    {

    }
    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        this.chieuDai = chieuDai;
        this.chieuRong = chieuRong;
    }

    public override double DienTich()
    {
        return chieuDai * chieuRong;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hình chữ nhật: ");
        Console.WriteLine("  Chiều dài : " + chieuDai);
        Console.WriteLine("  Chiều rộng: " + chieuRong);
        Console.WriteLine("  Diện tích : " + DienTich());
    }
}

class HinhVuong : HinhChuNhat
{
    public HinhVuong(double canh) : base(canh, canh)
    {

    }

    public override void Xuat()
    {
        Console.WriteLine("Hình vuông:");
        Console.WriteLine($"  Cạnh     : {chieuDai}");
        Console.WriteLine($"  Diện tích: {DienTich()}");
    }
}

class HinhTron : HinhVe
{
    protected double R;
    public HinhTron()
    {

    }
    public HinhTron(double R)
    {
        this.R = R;
    }

    public override double DienTich()
    {
        return Math.PI * R * R;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hình tròn");
        Console.WriteLine($"BK: {R}");
        Console.WriteLine($"Diện tích: {Math.Round(DienTich(), 4)}");
    }
}

class test
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==== CHƯƠNG TRÌNH CHỌN DIỆN TÍCH ====");
        Console.WriteLine("Chọn loại hình:");
        Console.WriteLine("  1. Hình chữ nhật");
        Console.WriteLine("  2. Hình vuông");
        Console.WriteLine("  3. Hình tròn");
        Console.Write("Nhập lựa chọn (1/2/3): ");
        int loai = int.Parse(Console.ReadLine());

        HinhVe hv;
        if (loai == 1)
        {
            // Nhập hình chữ nhật
            Console.Write("Nhập chiều dài: ");
            double dai = double.Parse(Console.ReadLine());

            Console.Write("Nhập chiều rộng: ");
            double rong = double.Parse(Console.ReadLine());
            hv = new HinhChuNhat(dai, rong);
        }
        else if (loai == 2)
        {

            // Nhập hình vuông
            Console.Write("Nhập độ dài cạnh: ");
            double canh = double.Parse(Console.ReadLine());

            hv = new HinhVuong(canh);
        }
        else if (loai == 3)
        {
            // Nhập hình tròn
            Console.Write("Nhập bán kính: ");
            double bankinh = double.Parse(Console.ReadLine());

            hv = new HinhTron(bankinh);
        }

        Console.WriteLine("\n==== Kết quả ====");
        hv.Xuat();
    }
}