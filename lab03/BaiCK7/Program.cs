
// Phần I — Cài đặt các lớp (6đ)
// 1. Lớp abstract GoiTap (2.5đ)
// Fields: mã gói (string), tên gói (string), số buổi mỗi tuần (int)
// Properties ràng buộc:

// Mã gói: đúng 6 ký tự
// Tên gói: độ dài > 0
// Số buổi mỗi tuần: trong khoảng [1, 7]

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhHocPhi()
// 2. Lớp GoiTapCaNhan kế thừa GoiTap (3.5đ)
// Fields bổ sung: phí mỗi buổi (double), số tuần đăng ký (int), có HLV riêng không (bool)
// Properties ràng buộc:

// Phí mỗi buổi: > 0
// Số tuần đăng ký: trong khoảng [1, 52]

// TinhHocPhi():

// Học phí = Phí mỗi buổi × Số buổi mỗi tuần × Số tuần
// Nếu có HLV riêng: cộng thêm 500.000


// Phần II — Chương trình chính (4đ)

// (1đ) Nhập danh sách n gói tập (2 ≤ n ≤ 20), khi nhập nếu mã gói đã tồn tại thì báo lỗi và nhập lại
// (0.5đ) In toàn bộ danh sách kèm học phí từng gói
// (0.5đ) Tính và in tổng doanh thu và học phí trung bình
// (0.5đ) Nhập số tuần, đếm số gói có số tuần đăng ký lớn hơn số tuần vừa nhập và in tổng học phí của nhóm đó. Thông báo nếu không có
// (0.5đ) Nhập tên gói, tìm và in thông tin gói đó (không phân biệt hoa thường). Thông báo nếu không tìm thấy
// (1đ) Sắp xếp theo học phí tăng dần. In ra sau sắp xếp

using System;
using System.Collections.Generic;

abstract class GoiTap
{
    private string maGoi;
    private string tenGoi;
    private int soBuoi;

    public string MaGoi
    {
        get { return maGoi; }
        set
        {
            if (value.Length == 6) maGoi = value;
            else Console.WriteLine("Loi");
        }
    }
    public string TenGoi
    {
        get { return tenGoi; }
        set
        {
            if (value.Length > 0) tenGoi = value;
            else Console.WriteLine("Loi");
        }
    }
    public int SoBuoi
    {
        get { return soBuoi; }
        set
        {
            if (value >= 1 && value <= 7) soBuoi = value;
            else Console.WriteLine("Loi");
        }
    }

    public GoiTap() { }
    public GoiTap(string maGoi, string tenGoi, int soBuoi)
    {
        MaGoi = maGoi;
        TenGoi = tenGoi;
        SoBuoi = soBuoi;
    }

    public abstract double TinhHocPhi();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma goi: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6) { MaGoi = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap ten goi: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0) { TenGoi = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so buoi moi tuan: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 7)
            { SoBuoi = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma goi: {MaGoi}");
        Console.WriteLine($"Ten goi: {TenGoi}");
        Console.WriteLine($"So buoi moi tuan: {SoBuoi}");
    }
}

class GoiTapCaNhan : GoiTap
{
    private double phiMoiBuoi;
    private int soTuan;
    private bool coHLV;

    public double PhiMoiBuoi
    {
        get { return phiMoiBuoi; }
        set
        {
            if (value > 0) phiMoiBuoi = value;
            else Console.WriteLine("Loi");
        }
    }
    public int SoTuan
    {
        get { return soTuan; }
        set
        {
            if (value >= 1 && value <= 52) soTuan = value;
            else Console.WriteLine("Loi");
        }
    }
    public bool CoHLV
    {
        get { return coHLV; }
        set { coHLV = value; }
    }

    public GoiTapCaNhan() : base() { }
    public GoiTapCaNhan(string maGoi, string tenGoi, int soBuoi, double phiMoiBuoi, int soTuan, bool coHLV)
    : base(maGoi, tenGoi, soBuoi)
    {
        PhiMoiBuoi = phiMoiBuoi;
        SoTuan = soTuan;
        CoHLV = coHLV;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap phi moi buoi: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            { PhiMoiBuoi = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so tuan: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 52)
            { SoTuan = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);


        Console.Write("CO HLV rieng khong? (1.Co || 2.Khong): ");
        CoHLV = Console.ReadLine() == "1";
    }

    public override double TinhHocPhi()
    {
        double phi = PhiMoiBuoi * SoBuoi * SoTuan;
        if (CoHLV)
        {
            return phi + 500000;
        }
        else
        {
            return phi;
        }
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Phi moi buoi: {PhiMoiBuoi:N0} vnd");
        Console.WriteLine($"So tuan: {SoTuan}");
        Console.WriteLine($"HLV ?: {(CoHLV ? "Co" : "Khong")}");
        Console.WriteLine($"Hoc phi: {TinhHocPhi():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong goi: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<GoiTapCaNhan> ds = new List<GoiTapCaNhan>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nGoi so {i + 1}");
            GoiTapCaNhan g = new GoiTapCaNhan();
            bool maTrung;
            do
            {
                g.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaGoi == g.MaGoi)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung)
                {
                    Console.WriteLine("Ma trung nhap lai!");
                }
            } while (maTrung);
            ds.Add(g);
        }

        Console.WriteLine("\nDANH SACH CAC GOI TAP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nGoi so {i + 1}");
            ds[i].Xuat();
        }

        double tong = 0;
        foreach (var g in ds)
        {
            tong += g.TinhHocPhi();
        }

        double tb = tong / ds.Count;
        Console.WriteLine($"\nTong doanh thu: {tong:N0} vnd | Hoc phi TB: {tb:N0} vnd");

        Console.Write("\nNhap so tuan: ");
        int tuan = int.Parse(Console.ReadLine());
        int dem = 0;
        tong = 0;
        foreach (var g in ds)
        {
            if (g.SoTuan > tuan)
            {
                dem++;
                tong += g.TinhHocPhi();
            }
        }

        if (dem == 0)
        {
            Console.WriteLine("Khong co goi nao!");
        }
        else
        {
            Console.WriteLine($"So goi co so tuan > {tuan} la: {dem}");
            Console.WriteLine($"Tong hoc phi: {tong:N0} vnd");
        }

        Console.Write("\nNhap ten goi: ");
        string tengoi = Console.ReadLine().ToLower();
        bool timThay = false;

        Console.WriteLine($"\nTHONG TIN HOC PHI CUA GOI {tengoi.ToUpper()}");
        foreach (var g in ds)
        {
            if (g.TenGoi.ToLower() == tengoi)
            {
                g.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("KHONG TIM THAY GOI");
        }

        Console.WriteLine("\nDANH SACH CAC GOI TAP SAU KHI SAP XEP");
        ds.Sort((a, b) => a.TinhHocPhi().CompareTo(b.TinhHocPhi()));
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nGoi so {i + 1}");
            ds[i].Xuat();
        }
    }
}