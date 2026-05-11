// Phần I — Cài đặt các lớp (6đ)
// 1. Interface IThongKe (0.5đ)

// double TinhDoanhThu()
// void InBaoCao()

// 2. Lớp abstract KhachSan (2.5đ)
// Fields: mã KS (string), tên KS (string), số sao (int)
// Properties ràng buộc:

// Mã KS: đúng 6 ký tự
// Tên KS: độ dài > 0
// Số sao: trong khoảng [1, 5]

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhDoanhThu()
// 3. Lớp KhachSanNghiDuong kế thừa KhachSan, implement IThongKe (3đ)
// Fields bổ sung: số phòng đã đặt (int), giá phòng mỗi đêm (double), số đêm lưu trú (int)
// Properties ràng buộc:

// Số phòng đã đặt: > 0
// Giá phòng mỗi đêm: > 0
// Số đêm lưu trú: trong khoảng [1, 30]

// TinhDoanhThu():

// Doanh thu = Số phòng × Giá phòng × Số đêm

// InBaoCao(): In tên KS, số phòng, số đêm, doanh thu

// Phần II — Chương trình chính (4đ)

// (1đ) Nhập danh sách n khách sạn (2 ≤ n ≤ 20)
// (1đ) Gọi InBaoCao() cho từng khách sạn
// (0.5đ) Tìm khách sạn có doanh thu cao nhất
// (0.5đ) Lọc và in các khách sạn có số sao >= 4
// (1đ) Sắp xếp theo doanh thu giảm dần, nếu bằng nhau thì theo số sao tăng dần. In ra sau sắp xếp

using System;
using System.Collections.Generic;

interface IThongKe
{
    double TinhDoanhThu();
    void InBaoCao();
}

abstract class KhachSan
{
    private string maKS;
    private string tenKS;
    private int soSao;

    public string MaKS
    {
        get { return maKS; }
        set
        {
            if (value.Length == 6)
            {
                maKS = value;
            }
            else
            {
                Console.WriteLine("Loi ma ks!");
            }
        }
    }
    public string TenKS
    {
        get { return tenKS; }
        set
        {
            if (value.Length > 0)
            {
                tenKS = value;
            }
            else
            {
                Console.WriteLine("Loi ten ks!");
            }
        }
    }
    public int SoSao
    {
        get { return soSao; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                soSao = value;
            }
            else
            {
                Console.WriteLine("Loi so sao ks!");
            }
        }
    }
    public KhachSan() { }
    public KhachSan(string maKS, string tenKS, int soSao)
    {
        MaKS = maKS;
        TenKS = tenKS;
        SoSao = soSao;
    }
    public abstract double TinhDoanhThu();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma ks: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaKS = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi ma ks!");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap ten ks: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenKS = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi ten ks!");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so sao ks: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 5)
            {
                soSao = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so sao ks!");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma ks: {MaKS}");
        Console.WriteLine($"Ten ks: {TenKS}");
        Console.WriteLine($"So sao ks: {SoSao}");

    }
}

class KhachSanNghiDuong : KhachSan, IThongKe
{
    private int soPhong;
    private double giaPhong;
    private int soDem;

    public int SoPhong
    {
        get { return soPhong; }
        set
        {
            if (value > 0)
            {
                soPhong = value;
            }
            else
            {
                Console.WriteLine("Loi so phong ks!");
            }
        }
    }
    public double GiaPhong
    {
        get { return giaPhong; }
        set
        {
            if (value > 0)
            {
                giaPhong = value;
            }
            else
            {
                Console.WriteLine("Loi gia phong ks!");
            }
        }
    }
    public int SoDem
    {
        get { return soDem; }
        set
        {
            if (value >= 1 && value <= 30)
            {
                soDem = value;
            }
            else
            {
                Console.WriteLine("Loi so dem o ks!");
            }
        }
    }

    public KhachSanNghiDuong() : base() { }
    public KhachSanNghiDuong(string maKS, string tenKS, int soSao, int soPhong, double giaPhong, int soDem)
    : base(maKS, tenKS, soSao)
    {
        SoPhong = soPhong;
        GiaPhong = giaPhong;
        SoDem = soDem;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap so phong: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoPhong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so phong");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap gia phong: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaPhong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi gia phong");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so dem: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 30)
            {
                SoDem = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so dem o ks");
            }
        } while (!hopLe);
    }

    public override double TinhDoanhThu()
    {
        return SoPhong * GiaPhong * SoDem;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So phong: {SoPhong}");
        Console.WriteLine($"Gia phong: {GiaPhong}");
        Console.WriteLine($"So dem o lai: {SoDem}");
        Console.WriteLine($"Doanh thu ks: {TinhDoanhThu():N0} vnd");
    }

    public void InBaoCao()
    {
        Console.WriteLine($"Ten KS: {TenKS}");
        Console.WriteLine($"So phong: {SoPhong}");
        Console.WriteLine($"So dem: {SoDem}");
        Console.WriteLine($"Doanh thu ks: {TinhDoanhThu():N0} vnd");
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
                Console.WriteLine("Loi nhap so luong");
            }
        } while (n < 2 || n > 20);

        List<KhachSanNghiDuong> ds = new List<KhachSanNghiDuong>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nKhach san {i + 1}");
            KhachSanNghiDuong ks = new KhachSanNghiDuong();
            ks.Nhap();
            ds.Add(ks);
        }

        Console.WriteLine("\nDANH SACH KHACH SAN");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nKhach san {i + 1}");
            ds[i].InBaoCao();
        }

        KhachSanNghiDuong max = ds[0];
        foreach (var ks in ds)
        {
            if (ks.TinhDoanhThu() > max.TinhDoanhThu()) max = ks;
        }

        Console.WriteLine("\nKHACH SAN CO DOANH THU CAO NHAT");
        max.Xuat();

        bool timThay = false;
        Console.WriteLine("\nKHACH SAN CO TREN 4 SAO");
        foreach (var ks in ds)
        {
            if (ks.SoSao >= 4)
            {
                ks.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("\nKHONG TIM THAY KS TREN 4 SAO");
        }


        ds.Sort((a, b) =>
        {
            int kq = b.TinhDoanhThu().CompareTo(a.TinhDoanhThu());
            if (kq != 0)
            {
                return kq;
            }
            return a.SoSao.CompareTo(b.SoSao);
        });

        Console.WriteLine("\nDANH SACH KHACH SAN SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nKhach san {i + 1}");
            ds[i].InBaoCao();
        }
    }
}
