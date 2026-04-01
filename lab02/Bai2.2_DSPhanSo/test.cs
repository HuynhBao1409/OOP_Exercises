//Ban update Bai2.2

using System;
using System.Collections.Generic;

class PhanSo
{
    private int _ts;
    private int _ms;

    public int TuSo
    {
        get { return _ts; }
        set { _ts = value; }
    }

    public int MauSo
    {
        get { return _ms; }
        set
        {
            if (value != 0)
                _ms = value;
            else
                Console.WriteLine("Mau so khong the bang 0. Gan mac dinh = 1");
        }
    }

    public PhanSo() { }

    public PhanSo(int ts, int ms)
    {
        _ts = ts;
        if (ms != 0)
            _ms = ms;
        else
        {
            Console.WriteLine("Mau so khong the bang 0. Gan mac dinh = 1");
            _ms = 1;
        }
    }

    public PhanSo(PhanSo p)
    {
        _ts = p._ts;
        _ms = p._ms;
    }

    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        _ts = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Nhap mau so: ");
            _ms = int.Parse(Console.ReadLine());
            if (_ms == 0) Console.WriteLine("Mau so khong the = 0");
        } while (_ms == 0);
    }

    public void Xuat()
    {
        if (_ms == 1)
            Console.Write(_ts);
        else if (_ms < 0)
            Console.Write($"{-_ts}/{-_ms}");
        else
            Console.Write($"{_ts}/{_ms}");
    }

    public double LayGiaTri()
    {
        return (double)_ts / _ms;
    }

    private int TimUCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int tem = b;
            b = a % b;
            a = tem;
        }
        return a;
    }

    public void ToiGian()
    {
        int ucln = TimUCLN(_ts, _ms);
        _ts /= ucln;
        _ms /= ucln;

        if (_ms < 0)
        {
            _ts = -_ts;
            _ms = -_ms;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<PhanSo> ds = new List<PhanSo>();

        Console.Write("Nhap so luong phan so: ");
        int n = int.Parse(Console.ReadLine());

        // Nhap
        Console.WriteLine("========== NHAP DANH SACH PHAN SO ==========");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhap phan so thu {i + 1} ---");
            PhanSo ps = new PhanSo();
            ps.Nhap();
            ps.ToiGian();
            ds.Add(ps);
        }

        // Xuat
        Console.WriteLine("\n========== DANH SACH PHAN SO VUA NHAP ==========");
        Console.WriteLine($"Danh sach co {n} phan so: ");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.Write($"PS{i + 1} = ");
            ds[i].Xuat();
            Console.WriteLine();
        }

        // Tim max
        Console.WriteLine("\n========== PHAN SO LON NHAT ==========");
        PhanSo max = ds[0];
        foreach (PhanSo ps in ds)
        {
            if (ps.LayGiaTri() > max.LayGiaTri())
                max = ps;
        }
        Console.Write("Phan tu lon nhat: ");
        max.Xuat();
        Console.WriteLine();

        // Sap xep tang dan
        ds.Sort((a, b) => a.LayGiaTri().CompareTo(b.LayGiaTri()));
        Console.WriteLine("\n========== SAP XEP TANG DAN ==========");
        Console.WriteLine("Danh sach sau khi sap xep: ");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.Write($"PS{i + 1} = ");
            ds[i].Xuat();
            Console.WriteLine();
        }

        Console.WriteLine("\n\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}