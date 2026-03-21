// //ĐỀ ÔN TẬP GK(Khóa trước)

// I. Cài đặt các lớp đối tượng (6đ)
// 1. Lớp HangHoa mô tả thông tin hàng hóa, gồm các thành phần:
//  ∙ Các dữ liệu riêng (fields): mã hàng, tên hàng, đơn giá. (0.5đ)
//  ∙ Các thuộc tính (properties) tương ứng với dữ liệu riêng, trong đó khi gán giá trị (set) ràng buộc:
// mã hàng đúng 10 ký tự, tên hàng có độ dài > 0, đơn giá > 0. (1đ)
//  ∙ Các phương thức: khởi tạo, nhập, xuất thông tin hàng. (1.5đ)
// 2. Lớp HangXK mô tả lớp hàng xuất khẩu, kế thừa lớp HangHoa và có thêm các thành phần:
//  ∙ Dữ liệu riêng: % thuế xuất khẩu (số thực), số lượng. (0.5đ)
//  ∙ Thuộc tính tương ứng với mức thuế, ràng buộc giá trị trong khoảng [0, 100]. (0.5đ)
//  ∙ Các phương thức khởi tạo, nhập, xuất ẩn phương thức cùng tên của lớp cơ sở. (1đ)
//  ∙ Phương thức tính thuế theo công thức:
// Thuế = Số lượng × Đơn giá × Thuế xuất khẩu (1đ)

// II. Chương trình chính (4đ)
//  ∙ Nhập (hoặc tạo) danh sách n sản phẩm xuất khẩu (2 <= n <= 100). (1đ)
//  ∙ In danh sách vừa nhập và thông tin chi tiết. (1đ)
//  ∙ In thông tin sản phẩm có tổng thuế cao nhất. (1đ)
//  ∙ Xóa các sản phẩm có mã trùng nhau chỉ giữ lại sản phẩm đầu, in ra danh sách sau xử lý. (1đ)

using System;
using System.Collections.Generic;


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
                Console.WriteLine("Lỗi: Mã hàng phải đúng 10 ký tự!");
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
                Console.WriteLine("Lỗi: Tên hàng không được để trống!");
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

    public HangHoa() { }

    public HangHoa(string maHang, string tenHang, double donGia)
    {
        MaHang = maHang;
        TenHang = tenHang;
        DonGia = donGia;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("  Mã hàng (10 ký tự): ");
            MaHang = Console.ReadLine();
        } while (maHang == null);

        do
        {
            Console.Write("  Tên hàng: ");
            TenHang = Console.ReadLine();
        } while (tenHang == null);

        do
        {
            Console.Write("  Đơn giá: ");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                DonGia = nhap;
            }
            else
            {
                Console.WriteLine("  Lỗi: Đơn giá phải là số!");
            }
        } while (donGia == 0);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"  Mã hàng  : {MaHang}");
        Console.WriteLine($"  Tên hàng : {TenHang}");
        Console.WriteLine($"  Đơn giá  : {DonGia:N0} VNĐ");
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
                Console.WriteLine("  Lỗi: Thuế suất phải trong khoảng [0, 100]!");
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
                Console.WriteLine("  Lỗi: Số lượng không được âm!");
            }
        }
    }

    public HangXK() : base() { }

    public HangXK(string maHang, string tenHang, double donGia, double thueSuat, int soLuong)
    : base(maHang, tenHang, donGia)
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
        // thueSuat mặc định 0 hợp lệ luôn → dùng flag
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
        // soLuong mặc định 0 hợp lệ luôn → dùng flag
        hople = false;
        do
        {
            Console.Write("  Số lượng: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0)
            {
                SoLuong = nhap;
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
        Console.WriteLine($"  Số lượng     : {SoLuong}");
        Console.WriteLine($"  Thuế suất XK : {ThueSuat}%");
        Console.WriteLine($"  Tiền thuế    : {TinhThue():N0} VNĐ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int n = 0;
        do
        {
            Console.Write("Nhập số sản phẩm (2 - 100): ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 100)
            {
                Console.WriteLine("Lỗi: n phải từ 2 đến 100!");
            }
        } while (n < 2 || n > 100);

        //Nhap danh sach
        List<HangXK> ds = new List<HangXK>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập sản phẩm thứ {i + 1} ---");
            HangXK h = new HangXK();
            h.Nhap();
            ds.Add(h);
        }

        //In danh sach
        Console.WriteLine("\n========== DANH SÁCH SẢN PHẨM XUẤT KHẨU ==========");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSản phẩm {i + 1}:");
            ds[i].Xuat();
            Console.WriteLine();
        }

        //Tim san pham co thue cao nhat
        HangXK max = ds[0];
        foreach (var h in ds)
        {
            if (h.TinhThue() > max.TinhThue())
            {
                max = h;
            }
        }
        Console.WriteLine("\n===== SẢN PHẨM CÓ TỔNG THUẾ CAO NHẤT =====");
        max.Xuat();

        //Xoa trung lap ma,giu cai dau
        List<HangXK> dsKhongTrung = new List<HangXK>();
        List<string> maDaGap = new List<string>();

        foreach (var h in ds)
        {
            if (!maDaGap.Contains(h.MaHang))
            {
                dsKhongTrung.Add(h);
                maDaGap.Add(h.MaHang);
            }
        }

        Console.WriteLine("\n===== DANH SÁCH SAU KHI XÓA TRÙNG MÃ =====");
        for (int i = 0; i < dsKhongTrung.Count; i++)
        {
            Console.WriteLine($"\nSản phẩm {i + 1}:");
            dsKhongTrung[i].Xuat();
            Console.WriteLine();
        }

        Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}