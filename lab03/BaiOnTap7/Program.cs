// I. Cài đặt các lớp đối tượng (6đ)
// 1. Lớp SinhVien mô tả thông tin sinh viên, gồm:

// Fields: MSSV, họ tên, GPA. (0.5đ)
// Properties tương ứng, ràng buộc khi set:

// MSSV đúng 8 ký tự
// họ tên độ dài > 0
// GPA trong khoảng [0.0, 4.0] (1đ)


// Các phương thức: khởi tạo, Nhap(), Xuat() (1.5đ)

// 2. Lớp SinhVienHocBong kế thừa SinhVien, có thêm:

// Fields: tên học bổng, số tiền học bổng (triệu đồng). (0.5đ)
// Property tương ứng với số tiền học bổng, ràng buộc > 0. (0.5đ)
// Phương thức khởi tạo, Nhap(), Xuat() ẩn phương thức cùng tên lớp cơ sở. (1đ)
// Phương thức tính mức học bổng thực nhận:
// Thực nhận = Số tiền × GPA / 4.0 (1đ)


// II. Chương trình chính (4đ)

// Nhập danh sách n sinh viên học bổng (2 ≤ n ≤ 40). (1đ)
// In danh sách vừa nhập và thông tin chi tiết. (1đ)
// In sinh viên có mức thực nhận cao nhất. (0.5đ)
// Nhập GPA tối thiểu, in tất cả sinh viên có GPA >= mức đó. (0.5đ)
// Sắp xếp danh sách theo GPA giảm dần, in ra. (1đ)


using System;
using System.Collections.Generic;

class SinhVien
{
    private string mssv;
    private string hoTen;
    private double gpa;

    public string MSSV
    {
        get { return mssv; }
        set
        {
            if (value.Length == 8)
            {
                mssv = value;
            }
            else
            {
                Console.WriteLine("Loi mssv phai = 8");
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
                Console.WriteLine("Loi ho ten ko dc de trong");
            }
        }
    }
    public double GPA
    {
        get { return gpa; }
        set
        {
            if (value >= 0.0 && value <= 4.0)
            {
                gpa = value;
            }
            else
            {
                Console.WriteLine("Loi GPA phai trong [0.0-4.0]");
            }
        }
    }

    public SinhVien() { }
    public SinhVien(string mssv, string hoTen, double gpa)
    {
        MSSV = mssv;
        HoTen = hoTen;
        GPA = gpa;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap MSSV: ");
            MSSV = Console.ReadLine();
        } while (mssv == null);

        do
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
        } while (hoTen == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nhap GPA: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 4.0)
            {
                GPA = nhap;
                hopLe = true;
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"MSSV: {MSSV}");
        Console.WriteLine($"Ho ten: {HoTen}");
        Console.WriteLine($"GPA: {GPA}");
    }
}

class SinhVienHocBong : SinhVien
{
    private string tenHocBong;
    private double tienHocBong;

    public string TenHocBong
    {
        get { return tenHocBong; }
        set
        {
            if (value.Length > 0)
            {
                tenHocBong = value;
            }
            else
            {
                Console.WriteLine("Loi loai hoc bong ko dc de trong");
            }
        }
    }
    public double TienHocBong
    {
        get { return tienHocBong; }
        set
        {
            if (value > 0)
            {
                tienHocBong = value;
            }
            else
            {
                Console.WriteLine("Loi tien hoc bong phai > 0");
            }
        }
    }

    public SinhVienHocBong() : base() { }
    public SinhVienHocBong(string mssv, string hoTen, double gpa, string tenHocBong, double tienHocBong)
    : base(mssv, hoTen, gpa)
    {
        TenHocBong = tenHocBong;
        TienHocBong = tienHocBong;
    }

    public new void Nhap() //de yeu cau an phuong thuc
    {
        base.Nhap();

        do
        {
            Console.Write($"Ten Hoc bong: ");
            TenHocBong = Console.ReadLine();
        } while (tenHocBong == null);

        bool hopLe = false;
        do
        {
            Console.Write("Số tiền học bổng (triệu): ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                TienHocBong = nhap;
                hopLe = true;
            }
        } while (!hopLe);
    }

    public double ThucNhan()
    {
        return TienHocBong * GPA / 4.0;
    }

    public new void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"  Học bổng    : {TenHocBong}");
        Console.WriteLine($"  Số tiền     : {TienHocBong:N0} triệu");
        Console.WriteLine($"  Thực nhận   : {ThucNhan():N0} triệu");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("Nhap so sinh vien: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 40)
            {
                Console.WriteLine("So luong sinh phai tu [2-40]");
            }
        } while (n < 2 || n > 40);

        List<SinhVienHocBong> ds = new List<SinhVienHocBong>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Sinh viên thứ {i + 1} ---");
            SinhVienHocBong sv = new SinhVienHocBong();
            sv.Nhap();
            ds.Add(sv);
        }

        Console.WriteLine("\n========== DANH SÁCH SINH VIÊN HỌC BỔNG ==========");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\n--- Sinh viên thứ {i + 1} ---");
            ds[i].Xuat();
        }

        SinhVienHocBong max = ds[0];
        foreach (var sv in ds)
        {
            if (sv.ThucNhan() > max.ThucNhan())
            {
                max = sv;
            }
        }

        Console.WriteLine("\n===== SINH VIÊN THỰC NHẬN CAO NHẤT =====");
        max.Xuat();

        bool hopLe = false;
        double gpaTT = 0;

        do
        {
            Console.Write("Nhap GPA toi thieu: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 4.0)
            {
                gpaTT = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Lỗi: GPA không hợp lệ!");
            }
        } while (!hopLe);

        Console.WriteLine($"\n===== SINH VIÊN CÓ GPA >= {gpaTT:F2} =====");
        bool timThay = false;
        foreach (var sv in ds)
        {
            if (sv.GPA >= gpaTT)
            {
                sv.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine($"Khong tim thay GPA >= {gpaTT}");
        }

        ds.Sort((a, b) => b.GPA.CompareTo(a.GPA));
        Console.WriteLine("\n===== DANH SÁCH SAU KHI SẮP XẾP GPA GIẢM DẦN =====");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\n--- Sinh viên thứ {i + 1} ---");
            ds[i].Xuat();
        }

        Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}