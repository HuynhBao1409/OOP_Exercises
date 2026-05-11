using System;
using System.Collections.Generic;

abstract class HopDong
{
    private string maHD;
    private string tenKH;
    private int soThang;

    public string MaHD
    {
        get { return maHD; }
        set
        {
            if (value.Length == 6)
            {
                maHD = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public string TenKH
    {
        get { return tenKH; }
        set
        {
            if (value.Length > 0)
            {
                tenKH = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoThang
    {
        get { return soThang; }
        set
        {
            if (value >= 1 && value <= 36)
            {
                soThang = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public HopDong() { }
    public HopDong(string maHD, string tenKH, int soThang)
    {
        MaHD = maHD;
        TenKH = tenKH;
        SoThang = soThang;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma HD: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaHD = nhap;
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
            Console.Write("Nhap ten KH: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenKH = nhap;
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
            Console.Write("Nhap so thang: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 36)
            {
                SoThang = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }
    public abstract double TinhGiaTriHD();

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma HD: {MaHD}");
        Console.WriteLine($"Ten HD: {TenKH}");
        Console.WriteLine($"So thang: {SoThang}");
    }
}

class HopDongDichVu : HopDong
{
    private double phiDV;
    private int mucUT;
    private double tiLePhat;

    public double PhiDV
    {
        get { return phiDV; }
        set
        {
            if (value > 0)
            {
                phiDV = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int MucUT
    {
        get { return mucUT; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                mucUT = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double TiLePhat
    {
        get { return tiLePhat; }
        set
        {
            if (value >= 0 && value <= 50)
            {
                tiLePhat = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public HopDongDichVu() : base() { }
    public HopDongDichVu(string maHD, string tenKH, int soThang, double phiDV, int mucUT, double tiLePhat)
    : base(maHD, tenKH, soThang)
    {
        PhiDV = phiDV;
        MucUT = mucUT;
        TiLePhat = tiLePhat;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap phi dich vu: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                PhiDV = nhap;
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
            Console.Write("Nhap muc uu tien: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 5)
            {
                MucUT = nhap;
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
            Console.Write("Nhap ti le phat: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 50)
            {
                TiLePhat = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override double TinhGiaTriHD()
    {
        return PhiDV * SoThang;
    }
    public double TinhPhiHuy()
    {
        return TinhGiaTriHD() * TiLePhat / 100;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Phi dich vu: {PhiDV:N0} vnd");
        Console.WriteLine($"Muc do uu tien: {MucUT}");
        Console.WriteLine($"Ti le phat: {TiLePhat:F2} %");
        Console.WriteLine($"Gia tri HD: {TinhGiaTriHD():N0} vnd");
        Console.WriteLine($"Phi Phat HD: {TinhPhiHuy():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<HopDongDichVu> ds = new List<HopDongDichVu>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nHD {i + 1}");
            HopDongDichVu hd = new HopDongDichVu();
            hd.Nhap();
            ds.Add(hd);
        }

        Console.WriteLine($"\nDANH SACH CAC HOP DONG");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nHop Dong {i + 1}");
            ds[i].Xuat();
        }

        HopDongDichVu min = ds[0];
        HopDongDichVu max = ds[0];

        foreach (var hd in ds)
        {
            if (hd.TinhGiaTriHD() < min.TinhGiaTriHD()) min = hd;
            if (hd.TinhGiaTriHD() > max.TinhGiaTriHD()) max = hd;
        }

        Console.WriteLine($"\nHOP DONG CO GIA TRI CAO NHAT");
        max.Xuat();
        Console.WriteLine($"\nHOP DONG CO GIA TRI THAP NHAT");
        min.Xuat();

        Console.Write("\nNhap muc do uu tien: ");
        int ut = int.Parse(Console.ReadLine());
        int dem = 0;
        double tongGiaTri = 0;

        foreach (var hd in ds)
        {
            if (hd.MucUT == ut)
            {
                dem++;
                tongGiaTri += hd.TinhGiaTriHD();
            }
        }

        if (dem == 0)
        {
            Console.WriteLine("Ko co hop dong nao");
        }
        else
        {
            Console.WriteLine($"So hop dong muc {ut}: {dem}");
            Console.WriteLine($"Tong gia tri hop dong muc: {tongGiaTri:N0} vnd");
        }

        ds.Sort((a, b) => b.TinhGiaTriHD().CompareTo(a.TinhGiaTriHD()));
        Console.WriteLine($"\nDANH SACH CAC HOP DONG SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nHop Dong {i + 1}");
            ds[i].Xuat();
        }

        List<HopDongDichVu> dsmoi = new List<HopDongDichVu>();
        List<string> madagap = new List<string>();

        foreach (var hd in ds)
        {
            if (!madagap.Contains(hd.MaHD))
            {
                dsmoi.Add(hd);
                madagap.Add(hd.MaHD);
            }
        }

        Console.WriteLine($"\nDANH SACH CAC HOP DONG SAU KHI XOA TRUNG");
        for (int i = 0; i < dsmoi.Count; i++)
        {
            Console.WriteLine($"\nHop Dong {i + 1}");
            dsmoi[i].Xuat();
        }

    }
}