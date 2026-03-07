using System;
using System.Collections.Generic;

class Xe
{
    protected string bienSo;
    protected int namSanXuat;
    protected double gia;

    public Xe()
    {
        bienSo = "";
        namSanXuat = 0;
        gia = 0;
    }

    public Xe(string bienSo, int namSanXuat, double gia)
    {
        this.bienSo = bienSo;
        this.namSanXuat = namSanXuat;
        this.gia = gia;
    }

    public string GetBienSo() { return bienSo; }
    public int GetNamSanXuat() { return namSanXuat; }
    public double GetGia() { return gia; }

    public virtual void Nhap()
    {
        Console.WriteLine("nasdsada");
        bienSo = Console.ReadLine();

        Console.WriteLine("nasdsada");
        namSanXuat = int.Parse(Console.ReadLine());
        Console.WriteLine("nasdsada");
        gia = double.Parse(Console.ReadLine());
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"asdas{bienSo}");
        Console.WriteLine($"asdas{namSanXuat}");
        Console.WriteLine($"asdas{gia}");
    }
}

class XeCon : Xe
{
    private int soCho;
    private string loaiXe;

    public XeCon() : base()
    {
        soCho = 0;
        loaiXe = "";
    }

    public XeCon(string bienSo, int namSanXuat, double gia, int soCho, string loaiXe)
    : base(bienSo, namSanXuat, gia)
    {
        this.soCho = soCho;
        this.loaiXe = loaiXe;
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("dsasa");
        soCho = int.Parse(Console.ReadLine());

        Console.Write("sadsadadasd");
        loaiXe = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($" Số chỗ ngồi : {soCho}");
        Console.WriteLine($" Loại xe     : {loaiXe}");
    }
}