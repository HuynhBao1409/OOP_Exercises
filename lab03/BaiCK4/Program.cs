// Phần I — Cài đặt các lớp (6đ)
// 1. Lớp abstract SanPham (2.5đ)
// Fields: mã SP (string), tên SP (string), số lượng tồn kho (int)
// Properties ràng buộc:

// Mã SP: đúng 6 ký tự
// Tên SP: độ dài > 0
// Số lượng tồn kho: >= 0

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhDoanhThu()
// 2. Lớp SanPhamNhapKhau kế thừa SanPham (3.5đ)
// Fields bổ sung: giá nhập (double), tỉ lệ lợi nhuận % (double), thuế nhập khẩu % (double)
// Properties ràng buộc:

// Giá nhập: > 0
// Tỉ lệ lợi nhuận: trong khoảng [5, 80]
// Thuế nhập khẩu: trong khoảng [0, 40]

// Override Nhap(), Xuat(), TinhDoanhThu():

// Giá bán = Giá nhập × (1 + Lợi nhuận/100) + Giá nhập × Thuế/100
// Doanh thu = Số lượng × Giá bán


// Phần II — Chương trình chính (4đ)

// (1đ) Nhập danh sách n sản phẩm (2 ≤ n ≤ 20)
// (1đ) In toàn bộ danh sách kèm doanh thu từng sản phẩm
// (0.5đ) Tính và in tổng doanh thu + doanh thu trung bình
// (0.5đ) Lọc và in các sản phẩm có tồn kho = 0 (hết hàng). Thông báo nếu không có
// (1đ) Sắp xếp theo doanh thu giảm dần, nếu bằng nhau thì theo tên SP tăng dần. In ra sau sắp xếp
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

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma sp: ");
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
            Console.Write("Nhap ten sp: ");
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
            Console.Write("Nhap so luong ton kho: ");
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

    public abstract double TinhDoanhThu();

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
            Console.Write("Nhap loi nhuan: ");
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
            Console.Write("Nhap so luong: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<SanPhamNhapKhau> ds = new List<SanPhamNhapKhau>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSan Pham {i + 1}");
            SanPhamNhapKhau sp = new SanPhamNhapKhau();
            sp.Nhap();
            ds.Add(sp);
        }

        Console.WriteLine($"\nDANH SACH SAN PHAM");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan Pham {i + 1}");
            ds[i].Xuat();
        }

        double tong = 0;
        foreach (var sp in ds)
        {
            tong += sp.TinhDoanhThu();
        }
        double tb = tong / ds.Count;

        Console.WriteLine($"\nTONG DOANH THU: {tong:N0} - TRUNG BINH: {tb:N0}");

        Console.WriteLine($"\nDANH SACH SAN PHAM HET HANG");
        bool timThay = false;
        foreach (var sp in ds)
        {
            if (sp.SoLuong == 0)
            {
                sp.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("KHONG CO SO LUONG HET HANG");
        }

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
    }
}

