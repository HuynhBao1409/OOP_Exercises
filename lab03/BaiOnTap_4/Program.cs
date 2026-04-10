// I. Cài đặt các lớp đối tượng (6đ)

// 1. Lớp NhanVien mô tả thông tin nhân viên, gồm: (0.5đ)

// Fields: mã NV, họ tên, lương cơ bản.
// Properties tương ứng, ràng buộc khi set: (1đ)
// Mã NV đúng 6 ký tự.
// Họ tên độ dài > 0.
// Lương cơ bản > 0.
// Các phương thức: khởi tạo, Nhap(), Xuat(), virtual TinhLuong() trả về lương cơ bản. (1.5đ)
// 2. Lớp NhanVienTangCa kế thừa NhanVien, có thêm: (0.5đ)

// Fields: số giờ tăng ca, hệ số tăng ca (số thực). (0.5đ)
// Property hệ số tăng ca ràng buộc trong khoảng [1.5, 3.0]. (0.5đ)
// Override Nhap(), Xuat(), khởi tạo. (1đ)
// Override TinhLuong() theo công thức: (1đ)
// Lương = Lương cơ bản + Số giờ tăng ca × Hệ số tăng ca × 50.000
// II. Chương trình chính (4đ)

// Nhập danh sách n nhân viên tăng ca (2 ≤ n ≤ 30). (1đ)
// In danh sách kèm lương thực nhận của từng người. (1đ)
// Tìm và in nhân viên có lương cao nhất. (0.5đ)
// Tính và in lương trung bình của cả danh sách. (0.5đ)
// Sắp xếp danh sách theo lương giảm dần, in ra sau khi sắp xếp. (1đ)

using System;
using System.Collections.Generic;

class NhanVien
{
    private string maNV;
    private string tenNV;
    private double luongCoBan;

    public string MaNV
    {
        get { return maNV; }
        set
        {
            if (value.Length == 6)
            {
                maNV = value;
            }
            else
            {
                Console.WriteLine("Ma nv phai dung 6 ky tu");
            }
        }
    }
    public string TenNV
    {
        get { return tenNV; }
        set
        {
            if (value.Length > 0)
            {
                tenNV = value;
            }
            else
            {
                Console.WriteLine("Ten nv khong duoc de trong");
            }
        }
    }
    public double LuongCoBan
    {
        get { return luongCoBan; }
        set
        {
            if (value > 0)
            {
                luongCoBan = value;
            }
            else
            {
                Console.WriteLine("Luong co ban ko dc am");
            }
        }
    }

    public NhanVien() { }

    public NhanVien(string maNV, string tenNV, double luongCoBan)
    {
        MaNV = maNV;
        TenNV = tenNV;
        LuongCoBan = luongCoBan;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap ma NV: ");
            MaNV = Console.ReadLine();
        } while (maNV == null);
        do
        {
            Console.Write("Nhap ten NV: ");
            TenNV = Console.ReadLine();
        } while (tenNV == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nhap luong co ban: ");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                LuongCoBan = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Luong ko dc am va phai la so");
            }
        } while (!hopLe);
    }

    public virtual double TinhLuong()
    {
        return luongCoBan;
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma NV: {MaNV}");
        Console.WriteLine($"Ten NV: {TenNV}");
        Console.WriteLine($"Luong co ban NV: {LuongCoBan} vnd");
        Console.WriteLine($"Luong thuc te NV: {TinhLuong():N0} vnd");
    }
}

class NhanVienTangCa : NhanVien
{
    private double soGio;
    private double heSoOT;

    public double SoGio
    {
        get { return soGio; }
        set
        {
            if (value >= 0)
            {
                soGio = value;
            }
            else
            {
                Console.WriteLine("So gio OT ko dc am");
            }
        }
    }

    public double HeSoOT
    {
        get { return heSoOT; }
        set
        {
            if (value >= 1.5 && value <= 3.0)
            {
                heSoOT = value;
            }
            else
            {
                Console.WriteLine("He so OT phai trong [1.5-3.0]");
            }
        }
    }
    public NhanVienTangCa() : base() { }

    public NhanVienTangCa(string maNV, string tenNV, double luongCoBan, double soGio, double heSoOT)
    : base(maNV, tenNV, luongCoBan)
    {
        SoGio = soGio;
        HeSoOT = heSoOT;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap so gio OT: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0)
            {
                SoGio = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so gio OT");
            }
        } while (!hopLe);

        hopLe = false;
        do
        {
            Console.Write("Nhap he so OT: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 1.5 && nhap <= 3.0)
            {
                HeSoOT = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi he so OT");
            }

        } while (!hopLe);
    }

    public override double TinhLuong()
    {
        return LuongCoBan + (SoGio * HeSoOT * 50000);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So gio OT: {SoGio}");
        Console.WriteLine($"He so OT: {HeSoOT}");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("Nhap so luong NV: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 30)
            {
                Console.WriteLine("Nhap so luong nhan vien [2-30]");
            }
        } while (n < 2 || n > 30);

        List<NhanVienTangCa> ds = new List<NhanVienTangCa>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhan Vien {i + 1}");
            NhanVienTangCa nv = new NhanVienTangCa();
            nv.Nhap();
            ds.Add(nv);
        }

        Console.WriteLine($"\nDanh sach cho {n} nhan vien");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nNhan Vien {i + 1}");
            ds[i].Xuat();
        }

        NhanVienTangCa max = ds[0];

        foreach (var nv in ds)
        {
            if (nv.TinhLuong() > max.TinhLuong())
            {
                max = nv;
            }
        }
        Console.WriteLine("\n Nhan vien co muc luong cao nhat");
        max.Xuat();

        double tongLuong = 0;
        foreach (var nv in ds)
        {
            tongLuong += nv.TinhLuong();
        }
        double trungBinh = tongLuong / ds.Count;
        Console.WriteLine($"\n Luong trung binh");
        Console.WriteLine($"Luong TB: {trungBinh:N0} vnd");

        ds.Sort((a, b) => b.TinhLuong().CompareTo(a.TinhLuong()));
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nNhan Vien {i + 1}");
            ds[i].Xuat();
        }

        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();
    }
}