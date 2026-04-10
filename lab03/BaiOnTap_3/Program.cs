//  I. Cài đặt các lớp đối tượng (6đ)

// 1. Lớp SachGiao mô tả thông tin sách giáo khoa, gồm: (0.5đ)

// Fields: mã sách, tên sách, giá bìa.
// Properties tương ứng, ràng buộc khi set: (1đ)
// Mã sách đúng 8 ký tự.
// Tên sách độ dài > 0.
// Giá bìa > 0.
// Các phương thức: khởi tạo, Nhap(), Xuat(). (1.5đ)
// 2. Lớp SachNhapKhau kế thừa SachGiao, có thêm: (0.5đ)

// Fields: tỷ lệ thuế nhập khẩu (số thực), số lượng nhập. (0.5đ)
// Property tương ứng với tỷ lệ thuế, ràng buộc trong khoảng [0, 50]. (0.5đ)
// Phương thức khởi tạo, Nhap(), Xuat() override phương thức cùng tên lớp cơ sở. (1đ)
// Phương thức tính tổng thuế theo công thức: (1đ)
// Tổng thuế = Số lượng × Giá bìa × (Tỷ lệ thuế / 100)
// II. Chương trình chính (4đ)

// Nhập danh sách n sách nhập khẩu (2 ≤ n ≤ 50). (1đ)
// In ra danh sách vừa nhập kèm thông tin chi tiết. (1đ)
// In thông tin sách có tổng thuế cao nhất và thấp nhất. (1đ)
// Xóa các sách có mã trùng nhau, chỉ giữ lại sách đầu tiên. In danh sách sau xử lý. (1đ)

using System;
using System.Collections.Generic;

class SachGiao
{
    private string maSach;
    private string tenSach;
    private double giaBia;

    public string MaSach
    {
        get { return maSach; }
        set
        {
            if (value.Length == 8)
            {
                maSach = value;
            }
            else
            {
                Console.WriteLine("Ma sach phai co 8 ky tu");
            }
        }

    }

    public string TenSach
    {
        get { return tenSach; }
        set
        {
            if (value.Length > 0)
            {
                tenSach = value;
            }
            else
            {
                Console.WriteLine("Ten sach khong dc bo trong");
            }
        }
    }

    public double GiaBia
    {
        get { return giaBia; }
        set
        {
            if (value > 0)
            {
                giaBia = value;
            }
            else
            {
                Console.WriteLine("Gia bia khong dc de trong");
            }
        }
    }

    public SachGiao() { }

    public SachGiao(string maSach, string tenSach, double giaBia)
    {
        MaSach = maSach;
        TenSach = tenSach;
        GiaBia = giaBia;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap ma sach: ");
            MaSach = Console.ReadLine();
        } while (maSach == null);

        do
        {
            Console.Write("Nhap ten sach: ");
            TenSach = Console.ReadLine();
        } while (tenSach == null);
        bool hopLe = false;
        do
        {
            Console.Write("Nhap gia bia sach: ");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                GiaBia = nhap;
                hopLe = true;
            }

        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma sach: {MaSach}");
        Console.WriteLine($"Ten sach: {TenSach}");
        Console.WriteLine($"Gia bia: {GiaBia} vnd");
    }
}

class SachNhapKhau : SachGiao
{
    private double thueNhap;
    private int soLuong;

    public double ThueNhap
    {
        get { return thueNhap; }
        set
        {
            if (value >= 0 && value <= 50)
            {
                thueNhap = value;
            }
            else
            {
                Console.WriteLine("thue xuat phai tu[0-50]");
            }
        }
    }

    public int SoLuong
    {
        get { return soLuong; }
        set
        {
            if (value > 0)
            {
                soLuong = value;
            }
            else
            {
                Console.WriteLine("So luong phai lon hon 0");
            }
        }
    }


    public SachNhapKhau() : base()
    {

    }

    public SachNhapKhau(string maSach, string tenSach, double giaBia, double thueNhap, int soLuong) :
    base(maSach, tenSach, giaBia)
    {
        ThueNhap = thueNhap;
        SoLuong = soLuong;
    }

    public double TinhTongThue()
    {
        return SoLuong * GiaBia * (ThueNhap / 100);
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.WriteLine("Nhap so thue xuat: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 50)
            {
                ThueNhap = nhap;
                hopLe = true;
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.WriteLine("Nhap so luong nhap: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoLuong = nhap;
                hopLe = true;
            }
        } while (!hopLe);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Thue Xuat: {ThueNhap}");
        Console.WriteLine($"So luong: {SoLuong}");
        Console.WriteLine($"Tong Thue Xuat: {TinhTongThue():N0}");
    }
}


class Program
{
    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("Nhap so luong sach:");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 50)
            {
                Console.WriteLine("Loi so luong phai tu [2-50]");
            }
        } while (n < 2 || n > 50);

        List<SachNhapKhau> ds = new List<SachNhapKhau>();

        for (int i = 0; i < n; i++)
        {
            Console.Write($"\nSach {i + 1}: ");
            SachNhapKhau s = new SachNhapKhau();
            s.Nhap();
            ds.Add(s);
        }

        Console.WriteLine($"\nDanh sach co {n} sach");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.Write($"\nSach {i + 1}: ");
            ds[i].Xuat();
        }

        SachNhapKhau min = ds[0];
        SachNhapKhau max = ds[0];

        foreach (var s in ds)
        {
            if (s.TinhTongThue() < min.TinhTongThue())
            {
                min = s;
            }
            if (s.TinhTongThue() > max.TinhTongThue())
            {
                max = s;
            }
        }

        Console.WriteLine("\nSach co tong thue cao nhat");
        max.Xuat();
        Console.WriteLine("\nSach co tong thue thap nhat");
        min.Xuat();

        List<SachNhapKhau> dsKoTrung = new List<SachNhapKhau>();
        List<string> madaGap = new List<string>();
        foreach (var s in ds)
        {
            if (!madaGap.Contains(s.MaSach))
            {
                dsKoTrung.Add(s);
                madaGap.Add(s.MaSach);
            }
        }

        Console.WriteLine("Danh sach co cac ma khong trung");
        for (int i = 0; i < dsKoTrung.Count; i++)
        {
            Console.WriteLine($"\nSach{i + 1}");
            dsKoTrung[i].Xuat();
        }

        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();
    }
}


