using System;
using System.Collections.Generic;

class SanPham
{
    private string maSP;
    private string tenSP;
    private double gia;

    public string MaSP
    {
        get { return maSP; }
        set
        {
            if (value.Length == 6)
            {
                maSP = value;
            }
            else
            {
                Console.WriteLine("Loi: ");
            }
        }
    }
    public string TenSP
    {
        get { return tenSP; }
        set
        {
            if (value.Length > 0)
            {
                tenSP = value;
            }
            else
            {
                Console.WriteLine("Loi: ");
            }
        }
    }
    public double Gia
    {
        get { return gia; }
        set
        {
            if (value > 0)
            {
                gia = value;
            }
            else
            {
                Console.WriteLine("Loi: ");
            }
        }
    }

    public SanPham() { }
    public SanPham(string maSP, string tenSP, double gia)
    {
        MaSP = maSP;
        TenSP = tenSP;
        Gia = gia;
    }

    //nhap
    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap ma sp: ");
            MaSP = Console.ReadLine();
        } while (maSP == null);
        do
        {
            Console.Write("Nhap ten sp: ");
            TenSP = Console.ReadLine();
        } while (tenSP == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nhap gia: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                Gia = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi nhap: ");
            }
        } while (!hopLe);
    }

    //Xuat
    public virtual void Xuat()
    {
        Console.WriteLine($"MA SP: {MaSP}");
        Console.WriteLine($"TEN SP: {TenSP}");
        Console.WriteLine($"GIA SP: {Gia} vnd");
    }
}

class SPKhuyenMai : SanPham
{
    private string tenCT;
    private double phanTram;

    public string TenCT
    {
        get { return tenCT; }
        set
        {
            if (value.Length > 0)
            {
                tenCT = value;
            }
            else
            {
                Console.WriteLine("Loi: ");
            }
        }
    }
    public double PhanTram
    {
        get { return phanTram; }
        set
        {
            if (value >= 0.0 && value <= 70.0)
            {
                phanTram = value;
            }
            else
            {
                Console.WriteLine("Loi: %");
            }
        }
    }

    public SPKhuyenMai() : base() { }
    public SPKhuyenMai(string maSP, string tenSP, double gia, string tenCT, double phanTram)
    : base(maSP, tenSP, gia)
    {
        TenCT = tenCT;
        PhanTram = phanTram;
    }

    public override void Nhap()
    {
        base.Nhap();
        do
        {
            Console.Write("Nhap ten chuong trinh: ");
            TenCT = Console.ReadLine();
        } while (tenCT == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nhap phan tram: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 70.0)
            {
                PhanTram = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi: %");
            }
        } while (!hopLe);
    }

    public double TinhGiaBan()
    {
        return Gia * (1 - PhanTram / 100);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"TEN CHUONG TRINH: {TenCT}");
        Console.WriteLine($"PHAN TRAM GIAM: {PhanTram}%");
        Console.WriteLine($"GIA BAN: {TinhGiaBan():N0} vnd");
    }
}

class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Write("Nhap so luong san pham: ");
            int n = int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 50)
            {
                Console.WriteLine("Loi so luong");
            }
        } while (n < 2 || n > 50);

        List<SPKhuyenMai> ds = new List<SPKhuyenMai>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            SPKhuyenMai sp = new SPKhuyenMai();
            sp.Nhap();
            ds.Add(sp);
        }
        //in
        Console.WriteLine("\nDANH SACH SAN PHAM");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            ds[i].Xuat();
        }

        //Tim ct
        Console.Write("Nhap ten chuong trinh: ");
        string ct = Console.ReadLine();
        bool timThay = false;

        Console.WriteLine($"SAN PHAM CO TRONG CHUONG TRINH {ct.ToUpper()}");
        foreach (var sp in ds)
        {
            if (sp.TenCT.ToLower() == ct.ToLower())
            {
                sp.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Khong tim thay ten chuong trinh");
        }

        //Tinh tong
        double tongTien = 0;
        foreach (var sp in ds)
        {
            tongTien += sp.TinhGiaBan();
        }
        double trungBinh = tongTien / ds.Count;
        Console.WriteLine($"\nTONG DOANH THU DU KIEN: {tongTien:N0} vnd");
        Console.WriteLine($"\nTONG DOANH THU TRUNG BINH: {trungBinh:N0} vnd");

        //Sap xep
        ds.Sort((a, b) => b.PhanTram.CompareTo(a.PhanTram));
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSAN PHAM {i + 1}");
            ds[i].Xuat();
        }

        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();
    }
}
