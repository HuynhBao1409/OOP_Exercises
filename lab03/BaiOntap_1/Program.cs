// ĐỀ THI THỬ GIỮA KỲ
// I. Cài đặt các lớp đối tượng (6đ)
// 1. Lớp SanPham mô tả thông tin sản phẩm, gồm:

// Các fields: mã sản phẩm, tên sản phẩm, giá nhập. (0.5đ)
// Properties tương ứng, ràng buộc khi set:

// mã sản phẩm đúng 8 ký tự
// tên sản phẩm độ dài > 0
// giá nhập > 0 (1đ)


// Các phương thức: khởi tạo, Nhap(), Xuat() (1.5đ)

// 2. Lớp SanPhamKhuyenMai kế thừa SanPham, có thêm:

// Fields: % giảm giá (số thực), số lượng tồn kho. (0.5đ)
// Property tương ứng với % giảm giá, ràng buộc trong khoảng [0, 100]. (0.5đ)
// Phương thức khởi tạo, Nhap(), Xuat() ẩn phương thức cùng tên lớp cơ sở. (1đ)
// Phương thức tính tiền tiết kiệm:
// Tiết kiệm = Số lượng × Giá nhập × (% giảm giá / 100) (1đ)


// II. Chương trình chính (4đ)

// Nhập danh sách n sản phẩm khuyến mãi (2 ≤ n ≤ 50). (1đ)
// In danh sách vừa nhập và thông tin chi tiết. (1đ)
// In thông tin sản phẩm có tiền tiết kiệm cao nhất. (1đ)
// Xóa các sản phẩm có tên trùng nhau, chỉ giữ lại sản phẩm đầu tiên. In danh sách sau xử lý. (1đ)

using System;
using System.Collections.Generic;

class SanPham
{
    private string maSP;
    private string tenSP;
    private double giaNhap;

    public string MaSP
    {
        get { return maSP; }
        set
        {
            if (value.Length == 8)
            {
                maSP = value;
            }
            else
            {
                Console.WriteLine("Loi phai co dung 8 ky tu");
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
                Console.WriteLine("Loi nhap ten san pham");
            }
        }
    }

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
                Console.WriteLine("Loi gia phai lon hon 0");
            }
        }
    }

    public SanPham()
    {

    }

    public SanPham(string maSP, string tenSP, double giaNhap)
    {
        MaSP = maSP;
        TenSP = tenSP;
        GiaNhap = giaNhap;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap ma san pham: ");
            MaSP = Console.ReadLine();
        } while (maSP == null);

        do
        {
            Console.Write("Ten san pham: ");
            TenSP = Console.ReadLine();
        } while (tenSP == null);

        do
        {
            Console.Write("Nhap gia san pham: ");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                GiaNhap = nhap;
            }
            else
            {
                Console.WriteLine("Loi gia san pham phai la so");
            }
        } while (giaNhap == 0);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma san pham: {MaSP}");
        Console.WriteLine($"Ten san pham: {tenSP}");
        Console.WriteLine($"Gia nhap: {GiaNhap:N0} vnd");
    }
}

class SanPhamKhuyenMai : SanPham
{
    private double giamGia;
    private int soLuong;

    public double GiamGia
    {
        get { return giamGia; }
        set
        {
            if (value >= 0 && value <= 100)
            {
                giamGia = value;
            }
            else
            {
                Console.WriteLine("Loi giam gia phai trong [0-100]");
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
                Console.WriteLine("Loi so luong khong duoc < 0");
            }
        }
    }

    public SanPhamKhuyenMai() : base() { }

    public SanPhamKhuyenMai(string maSP, string tenSP, double giaNhap, double giamGia, int soLuong)
    : base(maSP, tenSP, giaNhap)
    {
        GiamGia = giamGia;
        SoLuong = soLuong;
    }

    public double TinhTietKiem()
    {
        return SoLuong * GiaNhap * (GiamGia / 100);
    }

    public override void Nhap()
    {
        base.Nhap();

        bool hopLe = false;

        do
        {
            Console.Write("Nhap Giam gia: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 100)
            {
                GiamGia = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi giam gia phai trong khoang [0-100]");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nhap so luong san pham: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0)
            {
                SoLuong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so luong phai la so duong");
            }
        } while (!hopLe);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So luong: {SoLuong}");
        Console.WriteLine($"Giam gia: {GiamGia}%");
        Console.WriteLine($"Tien tiet kie: {TinhTietKiem():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("Nhap so san pham: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 50)
            {
                Console.WriteLine("Loi luong san pham phai tu 2-50");
            }
        } while (n < 2 || n > 50);

        List<SanPhamKhuyenMai> ds = new List<SanPhamKhuyenMai>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}: ");
            SanPhamKhuyenMai sp = new SanPhamKhuyenMai();
            sp.Nhap();
            ds.Add(sp);
        }

        Console.WriteLine("\nDanh sach cac san pham");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}: ");
            ds[i].Xuat();
        }

        SanPhamKhuyenMai max = ds[0];
        foreach (var sp in ds)
        {
            if (sp.TinhTietKiem() > max.TinhTietKiem())
            {
                max = sp;
            }
        }
        Console.WriteLine("\nSan pham co tien tiet kiem cao nhat");
        max.Xuat();


        List<SanPhamKhuyenMai> dsKoTrung = new List<SanPhamKhuyenMai>();
        List<string> tenDaGap = new List<string>();

        foreach (var sp in ds)
        {
            if (!tenDaGap.Contains(sp.TenSP))
            {
                dsKoTrung.Add(sp);
                tenDaGap.Add(sp.TenSP);
            }
        }

        Console.WriteLine("\n Danh sach sau khi xoa trung ten");
        for (int i = 0; i < dsKoTrung.Count; i++)
        {
            Console.WriteLine($"San Pham {i + 1}: ");
            dsKoTrung[i].Xuat();
        }

        Console.WriteLine("\nNhan phim bat ky de thoat");
        Console.ReadKey();
    }
}