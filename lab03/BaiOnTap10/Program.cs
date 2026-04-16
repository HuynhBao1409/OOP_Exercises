// Phần I — Cài đặt các lớp đối tượng (6 điểm)
// 1. Lớp SanPham (3đ)
// Fields: mã sản phẩm (string), tên sản phẩm (string), giá nhập (double). (0.5đ)
// Properties ràng buộc khi set: (1đ)

// Mã sản phẩm: đúng 6 ký tự
// Tên sản phẩm: độ dài > 0
// Giá nhập: > 0

// Phương thức: (1.5đ)

// Khởi tạo không tham số và có tham số
// Nhap(), Xuat()


// 2. Lớp SanPhamKhuyenMai kế thừa SanPham (3đ)
// Fields bổ sung: tên chương trình khuyến mãi (string), phần trăm giảm giá (double). (0.5đ)
// Property ràng buộc: (0.5đ)

// Phần trăm giảm giá trong khoảng [0, 70] (không được giảm quá 70%)

// Phương thức: override Nhap(), Xuat(), khởi tạo. (1đ)
// Phương thức TinhGiaBan(): (1đ)
// Giá bán = Giá nhập × (1 - % giảm / 100)

// Ví dụ: giá nhập 200.000đ, giảm 30% → giá bán = 140.000đ


// Phần II — Chương trình chính (4 điểm)

// (1đ) Nhập danh sách n sản phẩm khuyến mãi (2 ≤ n ≤ 50).
// (1đ) In toàn bộ danh sách kèm giá bán thực tế của từng sản phẩm.
// (1đ) Nhập tên chương trình KM cần tìm, in tất cả sản phẩm thuộc chương trình đó (không phân biệt hoa thường). Thông báo nếu không tìm thấy.
// (0.5đ) Tính và in tổng doanh thu dự kiến (tổng giá bán của tất cả sản phẩm).
// (0.5đ) Sắp xếp danh sách theo % giảm giá tăng dần, in ra sau khi sắp xếp.

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
                Console.WriteLine("Loi:MaSP phai ==6");
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
                Console.WriteLine("Loi: ten san pham ko dc de trong");
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
                Console.WriteLine("Loi: gia san pham ko dc de trong");
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

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Ma San pham: ");
            MaSP = Console.ReadLine();
        } while (maSP == null);
        do
        {
            Console.Write("Ten San pham: ");
            TenSP = Console.ReadLine();
        } while (tenSP == null);

        bool hopLe = false;
        do
        {
            Console.Write("Gia san pham: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                Gia = nhap;
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
        Console.WriteLine($"Ma san pham: {MaSP}");
        Console.WriteLine($"Ten san pham: {TenSP}");
        Console.WriteLine($"Gia san pham: {Gia}");
    }

}

class SanPhamKhuyenMai : SanPham
{
    private string tenSale;
    private double phanTram;

    public string TenSale
    {
        get { return tenSale; }
        set
        {
            if (value.Length > 0)
            {
                tenSale = value;
            }
            else
            {
                Console.WriteLine("Loi:ten KM ko dc bo trong");
            }
        }
    }
    public double PhanTram
    {
        get { return phanTram; }
        set
        {
            if (value >= 0 && value <= 70)
            {
                phanTram = value;
            }
            else
            {
                Console.WriteLine("Loi: Phan tram ko dc bo trong");
            }
        }
    }

    public SanPhamKhuyenMai() : base() { }
    public SanPhamKhuyenMai(string maSP, string tenSP, double gia, string tenSale, double phanTram)
    : base(maSP, tenSP, gia)
    {
        TenSale = tenSale;
        PhanTram = phanTram;
    }

    public double TinhGiaBan()
    {
        return Gia * (1 - PhanTram / 100);
    }

    public override void Nhap()
    {
        base.Nhap();
        do
        {
            Console.Write("Ten khuyen mai: ");
            TenSale = Console.ReadLine();
        } while (tenSale == null);

        bool hopLe = false;
        do
        {
            Console.Write("Phan tram giam gia: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 70)
            {
                PhanTram = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi: Pham tram giam phai tu [0-70]");
            }
        } while (!hopLe);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Ten chuong trinh Sale: {TenSale}");
        Console.WriteLine($"Phan tram Sale: {PhanTram}%");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong san pham: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 50)
            {
                Console.WriteLine("So luong phai tu [2-50]");
            }
        } while (n < 2 || n > 50);

        List<SanPhamKhuyenMai> ds = new List<SanPhamKhuyenMai>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            SanPhamKhuyenMai sp = new SanPhamKhuyenMai();
            sp.Nhap();
            ds.Add(sp);
        }

        Console.WriteLine("\nDanh sach san pham");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            ds[i].Xuat();
        }

        Console.Write("Nhap ten chuong trinh can tim: ");
        string sale = Console.ReadLine();

        bool timThay = false;
        Console.WriteLine($"\nDanh sach chuong trinh {sale.ToUpper()} can tim");
        foreach (var sp in ds)
        {
            if (sp.TenSale.ToLower() == sale.ToLower())
            {
                sp.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine($"Khong tim thay chuong trinh {sale}");
        }

        double tongtien = 0;
        foreach (var sp in ds)
        {
            tongtien += sp.TinhGiaBan();
        }
        Console.WriteLine($"\nTong doanh thu du kien: {tongtien:N0} vnd");

        ds.Sort((a, b) => a.PhanTram.CompareTo(b.PhanTram));
        Console.WriteLine("\nDanh sach san pham co % giam gia tu thap den cao");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            ds[i].Xuat();
        }
        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();
    }
}