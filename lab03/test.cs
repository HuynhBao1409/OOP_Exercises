using System;
using System.Collections.Generic;

class Xe
{
    protected string bienSo;
    protected int namSanXuat;
    protected double gia;

    public Xe()
    {

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
        Console.Write(" Nhập biển số xe (vd: 79A-12345): ");
        bienSo = Console.ReadLine();

        Console.Write(" Nhập năm sản xuất: ");
        namSanXuat = int.Parse(Console.ReadLine());

        Console.Write(" Nhập giá tiền: ");
        gia = double.Parse(Console.ReadLine());
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Biển số: {bienSo}");
        Console.WriteLine($" Năm sản xuất: {namSanXuat}");
        Console.WriteLine($" Giá tiền: {gia}");
    }
}

class XeCon : Xe
{
    private int soCho;
    private string loaiXe;

    public XeCon() : base()
    {

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
        Console.Write(" Nhập số chỗ: ");
        soCho = int.Parse(Console.ReadLine());

        Console.Write("  Nhập loại xe (sedan/SUV/bán tải): ");
        loaiXe = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Số chỗ ngồi : {soCho}");
        Console.WriteLine($" Loại xe     : {loaiXe}");
    }
}