using System;
using System.Collections.Generic;
using System.Security.Cryptography;

abstract class PhuongTien
{
    private string bienSo;
    private int namSanXuat;
    private double soKM;

    public string BienSo
    {
        get { return bienSo; }
        set
        {
            if (value.Length > 0)
            {
                bienSo = value;
            }
            else
            {
                Console.WriteLine("asd");
            }
        }
    }
    public int NamSanXuat
    {
        get { return namSanXuat; }
        set
        {
            if (value >= 1900 && value <= 2025)
            {
                namSanXuat = value;
            }
            else
            {
                Console.WriteLine("asd");
            }
        }
    }
    public double SoKM
    {
        get { return soKM; }
        set
        {
            if (value >= 0)
            {
                soKM = value;
            }
            else
            {
                Console.WriteLine("asd");
            }
        }
    }

    public PhuongTien() { }
    public PhuongTien(string bienSo, int namSanXuat, double soKM)
    {
        BienSo = bienSo;
        NamSanXuat = namSanXuat;
        SoKM = soKM;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap bien so: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                BienSo = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nhap nam sx: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1900 && nhap <= 2025)
            {
                NamSanXuat = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nhap so KM: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0)
            {
                SoKM = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public abstract double TinhPhiBaoHiem();

    public virtual void Xuat()
    {
        Console.WriteLine($"Bien so: {BienSo}");
        Console.WriteLine($"Nam san xuat: {NamSanXuat}");
        Console.WriteLine($"So km: {SoKM} km");
        Console.WriteLine($"Tien bao hiem: {TinhPhiBaoHiem():N0} vnd");
    }
}

class OTo : PhuongTien
{
    private int soCho;
    private string loaiNhienLieu;

    public int SoCho
    {
        get { return soCho; }
        set
        {
            if (value >= 2 && value <= 16)
            {
                soCho = value;
            }
            else
            {
                Console.WriteLine("loi ");
            }
        }
    }
    public string LoaiNhienLieu
    {
        get { return loaiNhienLieu; }
        set
        {
            if (value.Length > 0)
            {
                loaiNhienLieu = value;
            }
            else
            {
                Console.WriteLine("loi ");
            }
        }
    }

    public OTo() : base() { }
    public OTo(string bienSo, int namSanXuat, double soKM, int soCho, string loaiNhienLieu)
    : base(bienSo, namSanXuat, soKM)
    {
        SoCho = soCho;
        LoaiNhienLieu = loaiNhienLieu;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.WriteLine("Nhap so cho");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 2 && nhap <= 16)
            {
                SoCho = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nhap sloai nhien lieu (xang/dau/dien): ");
            string nhap = Console.ReadLine().ToLower();
            if (nhap == "xang" || nhap == "dau" || nhap == "dien")
            {
                LoaiNhienLieu = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override double TinhPhiBaoHiem()
    {
        return SoCho * 500000 + SoKM * 100;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So cho: {SoCho} cho");
        Console.WriteLine($"Nhien lieu: {loaiNhienLieu}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong oto: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi nhap so luong!");
            }
        } while (n < 2 || n > 20);

        List<OTo> ds = new List<OTo>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nOto {i + 1}");
            OTo o = new OTo();
            o.Nhap();
            ds.Add(o);
        }

        Console.WriteLine("\nDANH SACH PHUONG TIEN");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nOto {i + 1}");
            ds[i].Xuat();
        }

        OTo max = ds[0];
        OTo min = ds[0];

        foreach (var o in ds)
        {
            if (o.TinhPhiBaoHiem() > max.TinhPhiBaoHiem())
            {
                max = o;
            }
            if (o.TinhPhiBaoHiem() < min.TinhPhiBaoHiem())
            {
                min = o;
            }

        }

        Console.WriteLine("\n========== XE PHI BAO HIEM CAO NHAT ==========");
        max.Xuat();
        Console.WriteLine("\n========== XE PHI BAO HIEM THAP NHAT ==========");
        min.Xuat();

        Console.WriteLine("\nDANH SACH CAC XE DUNG DIEN");
        bool timThay = false;

        foreach (var o in ds)
        {
            if (o.LoaiNhienLieu == "dien")
            {
                o.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Loi ko tim thay xe");
        }
        //xoa trung
        List<OTo> dsKoTrung = new List<OTo>();
        List<string> bienDaGap = new List<string>();

        foreach (var o in ds)
        {
            if (!bienDaGap.Contains(o.BienSo))
            {
                dsKoTrung.Add(o);
                bienDaGap.Add(o.BienSo);
            }
        }

        Console.WriteLine("\nDANH SACH SAU KHI XOA TRUNG");
        for (int i = 0; i < dsKoTrung.Count; i++)
        {
            Console.WriteLine($"\nOto {i + 1}");
            dsKoTrung[i].Xuat();
        }
    }
}