// I. Cài đặt các lớp đối tượng (6đ)1. Lớp KhachSan mô tả thông tin khách sạn, gồm:

// Fields: mã khách sạn, tên khách sạn, giá phòng/đêm. (0.5đ)
// Properties tương ứng, ràng buộc khi set:

// mã khách sạn đúng 6 ký tự
// tên khách sạn độ dài > 0
// giá phòng > 0 (1đ)


// Các phương thức: khởi tạo, Nhap(), Xuat() (1.5đ)
// 2. Lớp PhongVIP kế thừa KhachSan, có thêm:

// Fields: số sao (nguyên, 1-5), số đêm đặt phòng. (0.5đ)
// Property tương ứng với số sao, ràng buộc trong khoảng [1, 5]. (0.5đ)
// Phương thức khởi tạo, Nhap(), Xuat() ẩn phương thức cùng tên lớp cơ sở. (1đ)
// Phương thức tính tổng tiền:
// Tổng tiền = Số đêm × Giá phòng × Số sao (1đ)
// II. Chương trình chính (4đ)

// Nhập danh sách n phòng VIP (2 ≤ n ≤ 30). (1đ)
// In danh sách vừa nhập và thông tin chi tiết. (1đ)
// In thông tin phòng có tổng tiền cao nhất và thấp nhất. (1đ)
// Sắp xếp danh sách theo tổng tiền tăng dần, in ra danh sách sau sắp xếp. (1đ)
using System;
using System.Collections.Generic;

class KhachSan
{
    private string maKS;
    private string tenKS;
    private double giaPhong;

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
                Console.WriteLine("Ma khach san phai co 6 ky tu");
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
                Console.WriteLine("Ten khach san khong duoc de trong");
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
                Console.WriteLine("Gia phong khong duoc de trong");
            }
        }
    }

    public KhachSan() { }

    public KhachSan(string maKS, string tenKS, double giaPhong)
    {
        MaKS = maKS;
        TenKS = tenKS;
        GiaPhong = giaPhong;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.WriteLine("Ma khach san: ");
            MaKS = Console.ReadLine();
        } while (maKS == null);

        do
        {
            Console.WriteLine("Ten khach san: ");
            TenKS = Console.ReadLine();
        } while (tenKS == null);
        do
        {

            Console.WriteLine("Gia phong/dem: ");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                GiaPhong = nhap;
            }
            else
            {
                Console.WriteLine("Loi gia phai la so");
            }

        } while (giaPhong == 0);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma Khach san: {MaKS}");
        Console.WriteLine($"Ten Khach san: {TenKS}");
        Console.WriteLine($"Gia phong/dem : {GiaPhong:N0} vnd/dem");
    }
}

class PhongVIP : KhachSan
{
    private int soSao;
    private int soDem;

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
                Console.WriteLine("So sao khach san phai tu [1-5]");
            }
        }
    }

    public int SoDem
    {
        get { return soDem; }
        set
        {
            if (value > 0)
                soDem = value;
            else
                Console.WriteLine("Loi so dem phai lon hon 0");
        }
    }

    public PhongVIP() : base()
    {

    }

    public PhongVIP(string maKS, string tenKS, double giaPhong, int soSao, int soDem)
    : base(maKS, tenKS, giaPhong)
    {
        SoSao = soSao;
        SoDem = soDem;
    }

    public double TinhTongTien()
    {
        return SoDem * GiaPhong * SoSao;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;

        do
        {
            Console.Write("So sao [1-5]: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 5)
            {
                SoSao = nhap;
                hopLe = true;
            }
            else
                Console.WriteLine("Loi so sao phai trong khoang [1-5]");
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("So dem dat phong: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoDem = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so dem phai lon hon 0");
            }
        } while (!hopLe);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So Sao: {SoSao}");
        Console.WriteLine($"So Dem: {SoDem}");
        Console.WriteLine($"Tong tien: {TinhTongTien():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.WriteLine("Nhap so phong Vip [2-30]");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 30)
            {
                Console.WriteLine("Loi so phong vip phai tu 2-30");
            }
        } while (n < 2 || n > 30);

        List<PhongVIP> ds = new List<PhongVIP>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nPhong Vip {i + 1}: ");
            PhongVIP p = new PhongVIP();
            p.Nhap();
            ds.Add(p);
        }

        Console.WriteLine($"\nDanh sach phong Vip co {n} phong");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nPhong Vip {i + 1}: ");
            ds[i].Xuat();
        }

        PhongVIP min = ds[0];
        PhongVIP max = ds[0];

        foreach (var p in ds)
        {
            if (p.TinhTongTien() < min.TinhTongTien()) min = p;
            if (p.TinhTongTien() > max.TinhTongTien()) max = p;
        }

        Console.WriteLine("\n===== PHONG CO TONG TIEN CAO NHAT =====");
        max.Xuat();

        Console.WriteLine("\n===== PHONG CO TONG TIEN THAP NHAT =====");
        min.Xuat();

        ds.Sort((a, b) => a.TinhTongTien().CompareTo(b.TinhTongTien()));

        Console.WriteLine("\n===== DANH SACH SAU SAP XEP (TANG DAN) =====");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nPhong {i + 1}:");
            ds[i].Xuat();
        }
        Console.WriteLine("\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}