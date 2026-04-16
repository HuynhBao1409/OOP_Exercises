// Phần I — 6 điểm
// 1. Interface IThongKe (0.5đ)
// - double TinhDoanhThu()
// - void InBaoCao()
// 2. Lớp abstract CuaHang (2.5đ)
// Fields: mã cửa hàng (string), tên cửa hàng (string), số năm hoạt động (int). (0.5đ)
// Properties ràng buộc: (0.75đ)

// Mã cửa hàng: đúng 6 ký tự
// Tên cửa hàng: độ dài > 0
// Số năm hoạt động: >= 1

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhDoanhThu(). (1.25đ)
// 3. Lớp CuaHangOnline kế thừa CuaHang, implement IThongKe (3đ)
// Fields bổ sung: số đơn hàng (int), doanh thu mỗi đơn (double), tỉ lệ hoàn hàng % (double). (0.5đ)
// Properties ràng buộc: (0.5đ)

// Số đơn hàng: > 0
// Doanh thu mỗi đơn: > 0
// Tỉ lệ hoàn hàng: trong khoảng [0, 30]

// Phương thức: override Nhap(), Xuat(), khởi tạo. (1đ)
// TinhDoanhThu(): (0.5đ)
// Doanh thu = Số đơn × Doanh thu mỗi đơn × (1 - Tỉ lệ hoàn / 100)
// InBaoCao() từ interface: (0.5đ)
// In: tên cửa hàng, số đơn, tỉ lệ hoàn, doanh thu thực

// Phần II — 4 điểm

// (1đ) Nhập danh sách n cửa hàng online (2 ≤ n ≤ 20).
// (1đ) Gọi InBaoCao() cho từng cửa hàng.
// (0.5đ) Tìm cửa hàng có doanh thu cao nhất.
// (0.5đ) Lọc và in các cửa hàng có tỉ lệ hoàn hàng <= 5%.
// (1đ) Sắp xếp theo doanh thu giảm dần, nếu bằng nhau thì theo số năm hoạt động tăng dần. In ra sau sắp xếp.
using System;
using System.Collections.Generic;

interface IThongKe // chỉ khai báo, không có thân hàm
{
    double TinhDoanhThu();
    void InBaoCao();
}

abstract class CuaHang
{
    private string maCH;
    private string tenCH;
    private int soNamHD;

    public string MaCH
    {
        get { return maCH; }
        set
        {
            if (value.Length == 6)
            {
                maCH = value;
            }
            else
            {
                Console.WriteLine("Ma CH phai dung 6 ky tu");
            }
        }
    }
    public string TenCH
    {
        get { return tenCH; }
        set
        {
            if (value.Length > 0)
            {
                tenCH = value;
            }
            else
            {
                Console.WriteLine("Tne CH phai dung hon 1 ky tu");
            }
        }
    }
    public int SoNamHD
    {
        get { return soNamHD; }
        set
        {
            if (value >= 1)
            {
                soNamHD = value;
            }
            else
            {
                Console.WriteLine("So nam hoat dong phai lon hon 0");
            }
        }
    }

    public CuaHang() { }
    public CuaHang(string maCH, string tenCH, int soNamHD)
    {
        MaCH = maCH;
        TenCH = tenCH;
        SoNamHD = soNamHD;
    }

    public abstract double TinhDoanhThu();

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap ma CH: ");
            MaCH = Console.ReadLine();
        } while (maCH == null);
        do
        {
            Console.Write("Nhap ten CH: ");
            TenCH = Console.ReadLine();
        } while (tenCH == null);

        bool hopLe = false;
        do
        {
            Console.Write("So nam hoat dong: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1)
            {
                SoNamHD = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("So nam phai lon hon 0");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma CH: {MaCH}");
        Console.WriteLine($"Ten CH: {TenCH}");
        Console.WriteLine($"So nam hoat dong CH: {SoNamHD} nam");
        Console.WriteLine($"Doanh thu: {TinhDoanhThu():N0} vnd");
    }
}


class CuaHangOnline : CuaHang, IThongKe // kế thừa CuaHang VÀ implement IThongKe
{
    private int soDonHang;
    private double giaDon;
    private double tiLeHoan;

    public int SoDonHang
    {
        get { return soDonHang; }
        set
        {
            if (value > 0)
            {
                soDonHang = value;
            }
            else
            {
                Console.WriteLine("Loi So don hang phai lon hon 0");
            }
        }
    }
    public double GiaDon
    {
        get { return giaDon; }
        set
        {
            if (value > 0)
            {
                giaDon = value;
            }
            else
            {
                Console.WriteLine("Loi gia don hang phai lon hon 0");
            }
        }
    }
    public double TiLeHoan
    {
        get { return tiLeHoan; }
        set
        {
            if (value >= 0 && value <= 30)
            {
                tiLeHoan = value;
            }
            else
            {
                Console.WriteLine("Loi ti le hoan hang phai tu [0-30]");
            }
        }
    }

    public CuaHangOnline() : base() { }
    public CuaHangOnline(string maCH, string tenCH, int soNamHD, int soDonHang, double giaDon, double tiLeHoan)
    : base(maCH, tenCH, soNamHD)
    {
        SoDonHang = soDonHang;
        GiaDon = giaDon;
        TiLeHoan = tiLeHoan;
    }

    public override void Nhap()
    {
        base.Nhap();

        bool hopLe = false;
        do
        {
            Console.Write("So don hang: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoDonHang = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("So don hang phai lon hon 0");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Doanh thu moi don: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaDon = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Doanh thu moi don phai lon hon 0");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Ti le hoan hang: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 30)
            {
                TiLeHoan = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Ty le hoan don phai tu [0-30]");
            }
        } while (!hopLe);
    }

    public override double TinhDoanhThu()
    {
        return SoDonHang * GiaDon * (1 - TiLeHoan / 100);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So don hang: {SoDonHang} don");
        Console.WriteLine($"Doanh thu moi don hang: {GiaDon:N0} vnd");
        Console.WriteLine($"Ti le hoan hang: {TiLeHoan}%");
    }
    //in bao cao
    public void InBaoCao()
    {
        Console.WriteLine($"\n=== Bao cao doanh thu ===");
        Console.WriteLine($"Cua hang: {TenCH}");
        Console.WriteLine($"So don hang: {SoDonHang}");
        Console.WriteLine($"Ti le hoan hang: {TiLeHoan}%");
        Console.WriteLine($"Doanh thu: {TinhDoanhThu():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong cua hang: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("So luong cua hang phai tu [0-20]");
            }
        } while (n < 2 || n > 20);

        List<CuaHangOnline> ds = new List<CuaHangOnline>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nCua hang {i + 1}");
            CuaHangOnline ch = new CuaHangOnline();
            ch.Nhap();
            ds.Add(ch);
        }

        Console.WriteLine("\n===Bao cao doanh thu cac cua hang===");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nCua hang {i + 1}");
            ds[i].InBaoCao();
        }

        CuaHangOnline max = ds[0];
        foreach (var ch in ds)
        {
            if (ch.TinhDoanhThu() > max.TinhDoanhThu()) max = ch;
        }

        Console.WriteLine("\n=== doanh thu cua hang cao nhat===");
        max.Xuat();
        //ty le hoan <=5%
        int hoan = 5;

        bool timThay = false;
        Console.WriteLine("\n=== Cac hang co ty le hoan hang <= 5% ===");
        foreach (var ch in ds)
        {
            if (ch.TiLeHoan <= hoan)
            {
                ch.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay) Console.WriteLine("Ko tim thay cua hang co ti le hoan hang <= 5%");


        //Sap xep

        ds.Sort((a, b) =>
        {
            int KQ = b.TinhDoanhThu().CompareTo(a.TinhDoanhThu());
            if (KQ != 0)
            {
                return KQ;
            }
            return a.SoNamHD.CompareTo(b.SoNamHD);
        });

        Console.WriteLine("\n===Sap Xep ===");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nCua hang {i + 1}");
            ds[i].Xuat();
        }

    }
}
