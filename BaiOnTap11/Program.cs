// Phần I — Cài đặt các lớp đối tượng (6 điểm)
// 1. Lớp ChuongTrinhTV (3đ)
// Fields: mã chương trình (string), tên chương trình (string), thời lượng phút (int). (0.5đ)
// Properties ràng buộc khi set: (1đ)

// Mã chương trình: đúng 7 ký tự
// Tên chương trình: độ dài > 0
// Thời lượng: > 0

// Phương thức: (1.5đ)

// Khởi tạo không tham số và có tham số
// Nhap(), Xuat()


// 2. Lớp ChuongTrinhQuangCao kế thừa ChuongTrinhTV (3đ)
// Fields bổ sung: tên nhãn hàng (string), giá quảng cáo mỗi giây (double). (0.5đ)
// Property ràng buộc: (0.5đ)

// Giá mỗi giây: > 0

// Phương thức: ẩn (new) Nhap(), Xuat(), khởi tạo. (1đ)
// Phương thức TinhChiPhi(): (1đ)
// Chi phí = Thời lượng × 60 × Giá mỗi giây

// Ví dụ: 2 phút × 60 × 500.000đ/giây = 60.000.000đ


// Phần II — Chương trình chính (4 điểm)

// (1đ) Nhập danh sách n chương trình quảng cáo (2 ≤ n ≤ 30).
// (1đ) In toàn bộ danh sách kèm chi phí từng chương trình.
// (0.5đ) In chương trình có chi phí cao nhất.
// (0.5đ) Nhập tên nhãn hàng, in tất cả chương trình của nhãn hàng đó (không phân biệt hoa thường). Thông báo nếu không tìm thấy.
// (1đ) Xóa các chương trình trùng mã, chỉ giữ lại cái đầu tiên. In danh sách sau xử lý.

using System;
using System.Collections.Generic;

class ChuongTrinhTV
{
    private string maCT;
    private string tenCT;
    private int thoiLuong;

    public string MaCT
    {
        get { return maCT; }
        set
        {
            if (value.Length == 7)
            {
                maCT = value;
            }
            else
            {
                Console.WriteLine("Ma chuong trinh phai dung 7 ky tu!");
            }
        }
    }
    public string TenCT
    {
        get { return tenCT; }
        set
        {
            if (value.Length > 0)
            {
                tenCT = value;
            }
            else
            {
                Console.WriteLine("Ten chuong trinh ko dc de trong!");
            }
        }
    }
    public int ThoiLuong
    {
        get { return thoiLuong; }
        set
        {
            if (value > 0)
            {
                thoiLuong = value;
            }
            else
            {
                Console.WriteLine("thoi luong chuong trinh ko dc de trong!");
            }
        }
    }
    public ChuongTrinhTV() { }
    public ChuongTrinhTV(string maCT, string tenCT, int thoiLuong)
    {
        MaCT = maCT;
        TenCT = tenCT;
        ThoiLuong = thoiLuong;
    }

    public virtual void Nhap()
    {
        // ✅ Rõ ràng hơn
        bool hopLe = false;
        do
        {
            Console.Write("Ma chuong trinh (7 ky tu): ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 7)
            {
                MaCT = nhap;
                hopLe = true;
            }
            else
                Console.WriteLine("Loi: Ma phai dung 7 ky tu!");
        } while (!hopLe);

        do
        {
            Console.Write("Ten chuong trinh: ");
            TenCT = Console.ReadLine();
        } while (tenCT == null);

        hopLe = false;
        do
        {
            Console.Write("Thoi luong(phut): ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                ThoiLuong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Thoi luong chuong trinh ko dc de trong!");
            }
        } while (!hopLe);


    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma chuong trinh: {MaCT}");
        Console.WriteLine($"Ten chuong trinh: {TenCT}");
        Console.WriteLine($"Thoi luong chuong trinh: {ThoiLuong} phut");
    }
}

class ChuongTrinhQuangCao : ChuongTrinhTV
{
    private string tenNhan;
    private double giaQC;

    public string TenNhan
    {
        get { return tenNhan; }
        set
        {
            if (value.Length > 0)
            {
                tenNhan = value;
            }
            else
            {
                Console.WriteLine("Ten nhan hang ko dc bo trong!");
            }
        }
    }
    public double GiaQC
    {
        get { return giaQC; }
        set
        {
            if (value > 0)
            {
                giaQC = value;
            }
            else
            {
                Console.WriteLine("gia quan cao ko dc bo trong!");
            }
        }
    }

    public ChuongTrinhQuangCao() : base() { }
    public ChuongTrinhQuangCao(string maCT, string tenCT, int thoiLuong, string tenNhan, double giaQC)
    : base(maCT, tenCT, thoiLuong)
    {
        TenNhan = tenNhan;
        GiaQC = giaQC;
    }

    public new void Nhap()
    {
        base.Nhap();
        do
        {
            Console.Write("Ten nhan hang: ");
            TenNhan = Console.ReadLine();
        } while (tenNhan == null);

        bool hopLe = false;
        do
        {
            Console.Write("Gia quang cao(moi giay): ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaQC = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Gia quang cao ko dc de trong!");
            }
        } while (!hopLe);
    }

    public double TinhChiPhi()
    {
        return ThoiLuong * 60 * GiaQC;
    }

    public new void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Ten nhan hang: {tenNhan}");
        Console.WriteLine($"Gia moi giay: {GiaQC}/s");
        Console.WriteLine($"Chi phi: {TinhChiPhi():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong quang cao: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 30)
            {
                Console.WriteLine("Loi so luong quang cao");
            }
        } while (n < 2 || n > 30);

        List<ChuongTrinhQuangCao> ds = new List<ChuongTrinhQuangCao>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nQuang cao {i + 1}");
            ChuongTrinhQuangCao ct = new ChuongTrinhQuangCao();
            ct.Nhap();
            ds.Add(ct);
        }

        Console.WriteLine("\nDanh sach chuong trinh quang cao");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nQuang cao {i + 1}");
            ds[i].Xuat();
        }

        ChuongTrinhQuangCao max = ds[0];
        foreach (var ct in ds)
        {
            if (ct.TinhChiPhi() > max.TinhChiPhi()) max = ct;
        }

        Console.WriteLine("\nChuong trinh quang cao co chi phi cao nhat");
        max.Xuat();

        Console.Write("Nhap nhan hang can tim: ");
        string ten = Console.ReadLine();

        bool timThay = false;

        Console.WriteLine($"\nChuong trinh quang cao cua nhan hang {ten.ToUpper()}");
        foreach (var ct in ds)
        {
            if (ct.TenNhan.ToLower() == ten.ToLower())
            {
                ct.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine($"\nKo tim thay nhan hang {ten.ToUpper()}");
        }

        List<ChuongTrinhQuangCao> dskotrung = new List<ChuongTrinhQuangCao>();
        List<string> madaGap = new List<string>();

        foreach (var ct in ds)
        {
            if (!madaGap.Contains(ct.MaCT))
            {
                dskotrung.Add(ct);
                madaGap.Add(ct.MaCT);
            }
        }

        Console.WriteLine("\nDanh sach chuong trinh quang cao sau khi xu ly");
        for (int i = 0; i < dskotrung.Count; i++)
        {
            Console.WriteLine($"\nQuang cao {i + 1}");
            dskotrung[i].Xuat();
        }

        Console.WriteLine("\nNhan phim bat ky de thoat");
        Console.ReadKey();
    }
}