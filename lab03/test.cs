using System;

class HinhVe
{
    public virtual double DienTich()
    {
        return 0;
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"DienTich: {DienTich():F2}");
    }
}

class HCN : HinhVe
{
    protected double dai;
    protected double rong;

    public HCN(double dai, double rong)
    {
        this.dai = dai;
        this.rong = rong;
    }

    public override double DienTich()
    {
        return dai * rong;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hình chữ nhật: ");
        Console.WriteLine("  Chiều dài : " + chieuDai);
        Console.WriteLine("  Chiều rộng: " + chieuRong);
        Console.WriteLine("  Diện tích : " + DienTich());
    }
}