using System;
using System.Collections.Generic;

abstract class SanPham
{
    private string maSP;
    private string tenSP;
    private int soLuong;

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
                Console.WriteLine("Loi");
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
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoLuong
    {
        get { return soLuong; }
        set
        {
            if (value >= 0)
            {
                soLuong = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public SanPham() { }
    public SanPham(string maSP, string tenSP, int soLuong)
    {
        MaSP = maSP;
        TenSP = tenSP;
        SoLuong = soLuong;
    }

    public abstract double TinhDoanhThu();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Ma SP: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaSP = nhap;
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
            Console.Write("Ten SP: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenSP = nhap;
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
            Console.Write("So luong ton: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0)
            {
                SoLuong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma SP: {MaSP}");
        Console.WriteLine($"Ten SP: {TenSP}");
        Console.WriteLine($"So luong ton SP: {SoLuong}");
    }
}

class SanPhamNhapKhau : SanPham
{
    private double giaNhap;
    private double loiNhuan;
    private double thueNhap;

    public double GiaNhap
    {
        get { return giaNhap; }
        set
        {
            if (value > 0)
            {
                giaNhap = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double LoiNhuan
    {
        get { return loiNhuan; }
        set
        {
            if (value >= 5 && value <= 80)
            {
                loiNhuan = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double ThueNhap
    {
        get { return thueNhap; }
        set
        {
            if (value >= 0 && value <= 40)
            {
                thueNhap = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public SanPhamNhapKhau() : base() { }
    public SanPhamNhapKhau(string maSP, string tenSP, int soLuong, double giaNhap, double loiNhuan, double thueNhap)
    : base(maSP, tenSP, soLuong)
    {
        GiaNhap = giaNhap;
        LoiNhuan = loiNhuan;
        ThueNhap = thueNhap;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap gia nhap: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaNhap = nhap;
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
            Console.Write("Nhap ti le loi nhuan: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 5 && nhap <= 80)
            {
                LoiNhuan = nhap;
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
            Console.Write("Nhap thue nhap khau: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 40)
            {
                ThueNhap = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override double TinhDoanhThu()
    {
        double giaBan = GiaNhap * (1 + LoiNhuan / 100) + GiaNhap * ThueNhap / 100;
        return SoLuong * giaBan;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Gia nhap: {GiaNhap:N0} vnd");
        Console.WriteLine($"Loi nhuan: {LoiNhuan} %");
        Console.WriteLine($"Thue Nhap: {ThueNhap} %");
        Console.WriteLine($"Doanh Thu: {TinhDoanhThu():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap n: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<SanPhamNhapKhau> ds = new List<SanPhamNhapKhau>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSP {i + 1}");
            SanPhamNhapKhau sp = new SanPhamNhapKhau();
            sp.Nhap();
            ds.Add(sp);
        }

        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSP {i + 1}");
            ds[i].Xuat();
        }

        double tong = 0;
        foreach (var sp in ds)
        {
            tong += sp.TinhDoanhThu();
        }

        double trungBinh = tong / ds.Count;

        Console.WriteLine($"\nTONG DOANH THU: {tong:N0} - TRUNG BINH: {trungBinh:N0}");

        Console.WriteLine($"\nDANH SACH SAN PHAM HET HANG");
        bool timThay = false;
        foreach (var sp in ds)
        {
            if (sp.SoLuong == 0)
            {
                timThay = true;
                sp.Xuat();
                Console.WriteLine();
            }
        }
        if (!timThay) Console.WriteLine("ko tim thay");

        ds.Sort((a, b) =>
        {
            int kq = b.TinhDoanhThu().CompareTo(a.TinhDoanhThu());
            if (kq != 0)
            {
                return kq;
            }
            return a.TenSP.CompareTo(b.TenSP);
        });

        Console.WriteLine($"\nDANH SACH SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan Pham {i + 1}");
            ds[i].Xuat();
        }

        List<SanPhamNhapKhau> dsMoi = new List<SanPhamNhapKhau>();
        List<string> maDaGap = new List<string>();

        foreach (var sp in ds)
        {
            if (!maDaGap.Contains(sp.MaSP))
            {
                dsMoi.Add(sp);
                maDaGap.Add(sp.MaSP);
            }
        }

        Console.WriteLine($"\nDANH SACH SAU KHI Xoa");
        for (int i = 0; i < dsMoi.Count; i++)
        {
            Console.WriteLine($"\nSan Pham {i + 1}");
            dsMoi[i].Xuat();
        }
    }
}