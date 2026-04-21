// 📝 ĐỀ THI GIỮA KỲ — LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG (C#)
// Thời gian: 75 phút | Được dùng tài liệu | Không trao đổi

// Phần I — Cài đặt các lớp đối tượng (6 điểm)
// 1. Lớp CauThu (3đ)
// Fields: mã cầu thủ (string), họ tên (string), quốc tịch (string). (0.5đ)
// Properties ràng buộc khi set: (1đ)

// Mã cầu thủ: đúng 6 ký tự
// Họ tên: độ dài > 0
// Quốc tịch: độ dài > 0

// Phương thức: (1.5đ)

// Khởi tạo không tham số và có tham số
// Nhap(), Xuat()


// 2. Lớp CauThuChuyenNhuong kế thừa CauThu (3đ)
// Fields bổ sung: tên câu lạc bộ (string), phí chuyển nhượng (double, đơn vị triệu euro), số năm hợp đồng (int). (0.5đ)
// Properties ràng buộc: (0.5đ)

// Phí chuyển nhượng: > 0
// Số năm hợp đồng: trong khoảng [1, 5]

// Phương thức: override Nhap(), Xuat(), khởi tạo. (1đ)
// Phương thức TinhTongChiPhi(): (1đ)
// Tổng chi phí = Phí chuyển nhượng + Số năm × Phí chuyển nhượng × 0.15

// Lương hàng năm = 15% phí chuyển nhượng. Ví dụ: phí 100 triệu, 3 năm → 100 + 3×100×0.15 = 145 triệu euro


// Phần II — Chương trình chính (4 điểm)

// (1đ) Nhập danh sách n cầu thủ chuyển nhượng (2 ≤ n ≤ 20).
// (1đ) In toàn bộ danh sách kèm tổng chi phí từng cầu thủ.
// (0.5đ) Tìm và in cầu thủ có tổng chi phí cao nhất.
// (0.5đ) Nhập tên câu lạc bộ, in tất cả cầu thủ thuộc CLB đó (không phân biệt hoa thường). Thông báo nếu không tìm thấy.
// (1đ) Sắp xếp theo phí chuyển nhượng giảm dần, nếu bằng nhau thì theo số năm hợp đồng tăng dần. In ra sau sắp xếp.
using System;
using System.Collections.Generic;

class CauThu
{
    private string maCT;
    private string hoTen;
    private string quocTich;

    public string MaCT
    {
        get { return maCT; }
        set
        {
            if (value.Length == 6)
            {
                maCT = value;
            }
            else
            {
                Console.WriteLine("Loi! ma ct");
            }
        }
    }
    public string HoTen
    {
        get { return hoTen; }
        set
        {
            if (value.Length > 0)
            {
                hoTen = value;
            }
            else
            {
                Console.WriteLine("Loi! ho ten ct");
            }
        }
    }
    public string QuocTich
    {
        get { return quocTich; }
        set
        {
            if (value.Length > 0)
            {
                quocTich = value;
            }
            else
            {
                Console.WriteLine("Loi! quoc tich ct");
            }
        }
    }

    public CauThu() { }
    public CauThu(string maCT, string hoTen, string quocTich)
    {
        MaCT = maCT;
        HoTen = hoTen;
        QuocTich = quocTich;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma ct: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaCT = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi! ma ct");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nhap ho ten ct: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                HoTen = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi! ho ten ct");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap quoc tich ct: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                QuocTich = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi! quoc tich ct");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma cau thu: {MaCT}");
        Console.WriteLine($"Ho ten cau thu: {HoTen}");
        Console.WriteLine($"Quoc tich cau thu: {QuocTich}");
    }
}

class CauThuChuyenNhuong : CauThu
{
    private string tenCLB;
    private double phiChuyen;
    private int namHD;

    public string TenCLB
    {
        get { return tenCLB; }
        set
        {
            if (value.Length > 0)
            {
                tenCLB = value;
            }
            else
            {
                Console.WriteLine("Loi! ten CLB");
            }
        }
    }

    public double PhiChuyen
    {
        get { return phiChuyen; }
        set
        {
            if (value > 0)
            {
                phiChuyen = value;
            }
            else
            {
                Console.WriteLine("Loi! phi chuyen CLB");
            }
        }
    }

    public int NamHD
    {
        get { return namHD; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                namHD = value;
            }
            else
            {
                Console.WriteLine("Loi! nam hoat dong CLB");
            }
        }
    }

    public CauThuChuyenNhuong() : base() { }
    public CauThuChuyenNhuong(string maCT, string hoTen, string quocTich, string tenCLB, double phiChuyen, int namHD)
    : base(maCT, hoTen, quocTich)
    {
        TenCLB = tenCLB;
        PhiChuyen = phiChuyen;
        NamHD = namHD;
    }

    public override void Nhap()
    {
        base.Nhap();
        do
        {
            Console.Write("Ten cau lac bo: ");
            TenCLB = Console.ReadLine();
        } while (tenCLB == null);

        bool hopLe = false;
        do
        {
            Console.Write("Phi chuyen nhuong: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                PhiChuyen = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi! phi chuyen CLB");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nam hoat dong: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 5)
            {
                NamHD = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi! nam hoat dong CLB");
            }
        } while (!hopLe);


    }

    public double TinhTongChiPhi()
    {
        return PhiChuyen + NamHD * PhiChuyen * 0.15;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Ten CLB: {TenCLB}");
        Console.WriteLine($"Phi chuyen CLB: {PhiChuyen} euro");
        Console.WriteLine($"Nam hoat dong CLB: {NamHD}");
        Console.WriteLine($"Tong chi phi: {TinhTongChiPhi():N0} euro");
    }

}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong cau thu: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi nhap so luong");
            }
        } while (n < 2 || n > 20);

        List<CauThuChuyenNhuong> ds = new List<CauThuChuyenNhuong>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nCau thu {i + 1}");
            CauThuChuyenNhuong ct = new CauThuChuyenNhuong();
            ct.Nhap();
            ds.Add(ct);
        }

        Console.WriteLine("\nDANH SACH CAU THU");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nCau thu {i + 1}");
            ds[i].Xuat();
        }

        CauThuChuyenNhuong max = ds[0];
        foreach (var ct in ds)
        {
            if (ct.TinhTongChiPhi() > max.TinhTongChiPhi())
            {
                max = ct;
            }
        }

        Console.WriteLine("\nCAU THU CO CHI PHI CAO NHAT");
        max.Xuat();

        Console.Write("\nNhap ten clb: ");
        string clb = Console.ReadLine();
        bool timThay = false;

        Console.WriteLine($"\nCAU THU CO TRONG CLB {clb.ToUpper()}");
        foreach (var ct in ds)
        {
            if (ct.TenCLB.ToLower() == clb.ToLower())
            {
                ct.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("\nKo tim thay!");
        }

        ds.Sort((a, b) =>
        {
            int kq = b.PhiChuyen.CompareTo(a.PhiChuyen);
            if (kq != 0)
            {
                return kq;
            }
            return a.NamHD.CompareTo(b.NamHD);
        });
        Console.WriteLine("\nDANH SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nCau thu {i + 1}");
            ds[i].Xuat();
        }

        Console.WriteLine("\n Nhap phim bat ky de thoat!");
        Console.ReadKey();
    }
}