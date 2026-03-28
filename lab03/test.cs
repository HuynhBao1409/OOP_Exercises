using System;
using System.Collections.Generic;

class HangHoa
{
    protected double maHang;
    protected string tenHang;
    protected double donGia;

    public double MaHang
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
                Console.WriteLine("loi");
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
                Console.WriteLine("loi");
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
                Console.WriteLine("sad");
            }
        }
    }

    public HangHoa()
    {

    }

    public HangHoa(double maHang, string tenHang, double donGia)
    {
        this.maHang = maHang;
        this.tenHang = tenHang;
        this.donGia = donGia;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("asdasad");
            maHang = double.Parse(Console.ReadLine());
        } while (maHang == null);

        do
        {
            Console.Write("sdasdada");
            tenHang = Console.ReadLine();
        } while (tenHang == null);

        do
        {
            Console.Write("sadasd");
            donGia = double.Parse(Console.ReadLine());
        } while (donGia == 0);
    }
    public virtual void Xuat()
    {
        Console.WriteLine($"asdsa {maHang}");
        Console.WriteLine($"asdsa {tenHang}");
        Console.WriteLine($"asdsa {donGia:N0} vnd");
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
                Console.WriteLine("loi");
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
                Console.WriteLine("asdasdad");
            }
        }
    }

    public HangXK() : base()
    {

    }

    public HangXK(double maHang, string tenHang, double donGia, double thueSuat, int soLuong)
    : base(maHang, tenHang, donGia)
    {
        this.thueSuat = thueSuat;
        this.soLuong = soLuong;
    }

    public double TinhThue()
    {
        return soLuong * donGia * (thueSuat / 100);
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
                Console.WriteLine("  Lỗi: Thuế suất phải trong khoảng [0, 100]!");
            }
        } while (!hople);


        bool hople = false;

        do
        {
            Console.WriteLine("soluong:");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0)
            {
                soLuong = nhap;
                hople = true;
            }
            else
            {
                Console.WriteLine("  Lỗi: Số lượng phải là số nguyên >= 0!");
            }
        } while (!hople);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"{thueSuat}");
        Console.WriteLine($"{soLuong}");
        Console.WriteLine($"Tien thue {TinhThue():N0}");
    }
}

class test
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("sadsadas");
            int.Parse(Console.ReadLine());

            if (n < 2 || n > 100)
            {
                Console.WriteLine("lio vl");
            }
        } while (n < 2 || n > 100);

        List<HangXK> ds = new List<HangXK>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"asdsad{i + 1}");
            HangXK hang = new HangXK();
            hang.Nhap();
            ds.Add(hang);
        }

        Console.WriteLine("\n========== DANH SÁCH SẢN PHẨM XUẤT KHẨU ==========");
        for(int i = 0; i < ds.Count; i++)
        {
            Console.Write($"{i+1}");
            ds[i].Xuat();
            Console.WriteLine();
        }

        HangXK max= ds[0];
        foreach(var hang in ds)
        {
            if (hang.TinhThue() > max.TinhThue())
            {
                max=hang;
            }
        }
        max.Xuat();

        List<HangXK> dskotrung = new List<HangXK>();
        List<string> madaGap = new List<string>();

        foreach(var hang in ds)
        {
            if (!madaGap.Contains(hang.MaHang))
            {
                dskotrung.Add(hang);
                madaGap.Add(hang.MaHang);
            }

        }

        for(int i = 0; i < dskotrung; i++)
        {
            Console.WriteLine($"{i+1}");
            dskotrung[i].Xuat();
        }
    }
}