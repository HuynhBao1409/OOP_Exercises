using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

class HangHoa
{
    private string maHang;
    private string tenHang;
    private double donGia;

    public string MaHang
    {
        get { return maHang; }
        set
        {
            if (value.Length == 10)
            {
                maHang = value;
            }
            else
            {
                Console.WriteLine("asddasas");
            }
        }
    }

    public string TenHang
    {
        get { return tenHang; }
        set
        {
            if (value.Length > 0)
            {
                tenHang = value;
            }
            else
            {
                Console.WriteLine("asdasd");
            }
        }
    }
    public double DonGia
    {
        get { return donGia; }
        set
        {
            if (value > 0)
            {
                donGia = value;
            }
            else
            {
                Console.WriteLine("  Lỗi: Đơn giá phải lớn hơn 0!");
            }
        }
    }

    public HangHoa()
    {

    }

    publMic HangHoa(string maHang, string tenHang, double donGia)
    {
        MaHang = maHang;
        TenHang = tenHang;
        DonGia = donGia;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("sadsada");
            MaHang = Console.ReadLine();
        } while (maHang == null);
        do
        {
            Console.Write("sadsada");
            TenHang = Console.ReadLine();
        } while (tenHang == null);
        do
        {
            Console.Write("sadsada");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                DonGia = nhap;
            }
        } while (donGia == 0);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"MH: {MaHang}");
        Console.WriteLine($"TH: {TenHang}");
        Console.WriteLine($"DG: {DonGia}");
    }
}

class HangXK : HangHoa
{
    private double thueSuat;
    private int soLuong;

    public double ThueSuat
    {
        get { return thueSuat; }
        set
        {
            if (value >= 0 && value <= 100)
            {
                thueSuat = value;
            }
            else
            {
                Console.WriteLine("asdasdasdsaasdf");
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
                Console.WriteLine("asssdasd");
            }
        }
    }

    public HangXK() : base() { }

    public HangXK(string maHang, string tenHang, double donGia, double thueSuat, int soLuong) :
    base(maHang, tenHang, donGia)
    {
        ThueSuat = thueSuat;
        SoLuong = soLuong;
    }

    public double TinhThue()
    {
        return SoLuong * DonGia * (ThueSuat / 100);
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hople = false;

        do
        {
            Console.Write("  Thuế suất XK (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 100)
            {
                ThueSuat = nhap;
                hople = true;
            }
            else
            {
                Console.WriteLine("asdasda");
            }
        } while (!hople);

        bool hople = false;

        do
        {
            Console.Write("  So luong: ");
            if (double.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0)
            {
                SoLuong = nhap;
                hople = true;
            }
            else
            {
                Console.WriteLine("asdasda");
            }
        } while (!hople);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So luong: {SoLuong}");
        Console.WriteLine($"Thue: {ThueSuat}");
        Console.WriteLine($"Tien thue: {TinhThue():NO}");
    }
}

class test
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("nhap sp");
            n = int.Parse(Console.ReadLine());
            if (n < 2 || n > 100)
            {
                Console.WriteLine("loi");
            }
        } while (n < 2 || n > 100);

        List<HangXK> ds = new List<HangXK>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhap san phan{i + 1}: ");
            HangXK h = new HangXK();
            h.Nhap();
            ds.Add(h);
        }

        Console.WriteLine($"danh sp");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.Write($"sp{i + 1}: ");
            ds[i].Xuat();
            Console.WriteLine();
        }


        HangXK max = ds[0];
        foreach (HangXK h in ds)
        {
            if (h.TinhThue() > max.TinhThue())
            {
                max = h;
            }
        }

        Console.WriteLine($"San pham co thue cao nhat: {max}");
        max.Xuat();

        ds.Sort((a, b) => a.TinhThue().CompareTo(b.TinhThue()));

        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"San Pham{i + 1}: ");
            ds[i].Xuat();
        }


        List<HangXK> dskotrung = new List<HangXK>();
        List<string> madagap = new List<string>();

        foreach (var h in ds)
        {
            if (!madagap.Contains(h.MaHang))
            {
                dskotrung.Add(h);
                madagap.Add(h.MaHang);
            }
        }

        Console.WriteLine("\n===== DANH SÁCH SAU KHI XÓA TRÙNG MÃ =====");
        for (int i = 0; i < dskotrung.Count; i++)
        {
            Console.WriteLine($"sanPham{i + 1}: ");
            dskotrung[i].Xuat();
        }

    }
}