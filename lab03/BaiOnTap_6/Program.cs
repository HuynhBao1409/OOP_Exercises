// I. Cài đặt các lớp đối tượng (6đ)

// 1. Lớp abstract MonHoc mô tả môn học, gồm: (0.5đ)

// Fields: mã môn (string), tên môn (string), số tín chỉ (int).
// Properties tương ứng, ràng buộc khi set: (1đ)
// Mã môn đúng 6 ký tự.
// Tên môn độ dài > 0.
// Số tín chỉ trong khoảng [1, 6].
// Các phương thức: khởi tạo, Nhap(), Xuat().
// Phương thức abstract: TinhHocPhi() trả về double. (1.5đ)
// 2. Lớp MonHocThucHanh kế thừa MonHoc, có thêm: (0.5đ)

// Fields: số buổi thực hành (int), phí phòng máy mỗi buổi (double). (0.5đ)
// Property số buổi thực hành ràng buộc > 0. (0.5đ)
// Override Nhap(), Xuat(), khởi tạo. (1đ)
// Implement TinhHocPhi() theo công thức: (1đ)
// Học phí = Số tín chỉ × 450.000 + Số buổi × Phí phòng máy
// II. Chương trình chính (4đ)

// Nhập danh sách n môn học thực hành (2 ≤ n ≤ 20). (1đ)
// In danh sách kèm học phí của từng môn. (1đ)
// Tính và in tổng học phí + học phí trung bình của cả danh sách. (1đ)
// Sắp xếp danh sách theo số tín chỉ tăng dần, in ra sau khi sắp xếp. (1đ)

using System;
using System.Collections.Generic;

abstract class MonHoc
{
    private string maMon;
    private string tenMon;
    private int tinChi;

    public string MaMon
    {
        get { return maMon; }
        set
        {
            if (value.Length == 6)
            {
                maMon = value;
            }
            else
            {
                Console.WriteLine("Loi ma mon hoc");
            }
        }
    }
    public string TenMon
    {
        get { return tenMon; }
        set
        {
            if (value.Length > 0)
            {
                tenMon = value;
            }
            else
            {
                Console.WriteLine("Loi ten mon hoc ko dc de trong");
            }
        }
    }
    public int TinChi
    {
        get { return tinChi; }
        set
        {
            if (value >= 1 && value <= 6)
            {
                tinChi = value;
            }
            else
            {
                Console.WriteLine("Loi so tin chi chi trong khoang [1-6]");
            }
        }
    }

    public MonHoc() { }
    public MonHoc(string maMon, string tenMon, int tinChi)
    {
        MaMon = maMon;
        TenMon = tenMon;
        TinChi = tinChi;
    }

    public abstract double TinhHocPhi();

    public virtual void Nhap()
    {

        do
        {
            Console.Write("Nhap ma mon: ");
            MaMon = Console.ReadLine();
        } while (maMon == null);
        do
        {
            Console.Write("Nhap ten mon: ");
            TenMon = Console.ReadLine();
        } while (tenMon == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nhap so tin chi: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 6)
            {
                TinChi = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so tin chi");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma Mon: {MaMon}");
        Console.WriteLine($"Ten Mon: {TenMon}");
        Console.WriteLine($"So tin chi: {TinChi}");
        Console.WriteLine($"Hoc phi: {TinhHocPhi():N0} vnd");
    }
}

class MonHocThucHanh : MonHoc
{
    private int soBuoi;
    private double phiPhong;

    public int SoBuoi
    {
        get { return soBuoi; }
        set
        {
            if (value > 0)
            {
                soBuoi = value;
            }
            else
            {
                Console.WriteLine("Loi so buoi thuc hanh phai lon hon 0");
            }
        }
    }
    public double PhiPhong
    {
        get { return phiPhong; }
        set
        {
            if (value > 0)
            {
                phiPhong = value;
            }
            else
            {
                Console.WriteLine("Loi so phi phong may phai lon hon 0");
            }
        }
    }

    public MonHocThucHanh() : base() { }
    public MonHocThucHanh(string maMon, string tenMon, int tinChi, int soBuoi, double phiPhong)
    : base(maMon, tenMon, tinChi)
    {
        SoBuoi = soBuoi;
        PhiPhong = phiPhong;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap so buoi thuc hanh: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoBuoi = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so buoi thuc hanh");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so phi buoi thuc hanh: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                PhiPhong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so phi buoi thuc hanh");
            }
        } while (!hopLe);
    }

    public override double TinhHocPhi()
    {
        return TinChi * 450000 + SoBuoi * PhiPhong;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So buoi: {SoBuoi}");
        Console.WriteLine($"Phi phong may: {PhiPhong}");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so mon hoc: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi so mon hoc");
            }
        } while (n < 2 || n > 20);

        List<MonHocThucHanh> ds = new List<MonHocThucHanh>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nMon hoc {i + 1}");
            MonHocThucHanh mh = new MonHocThucHanh();
            mh.Nhap();
            ds.Add(mh);
        }

        Console.WriteLine("\nDanh sach mon hoc");

        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nMon hoc {i + 1}");
            ds[i].Xuat();
        }
        double tongphi = 0;
        foreach (var mh in ds)
        {
            tongphi += mh.TinhHocPhi();
        }
        double trungBinh = tongphi / ds.Count;
        Console.WriteLine($"\nTong hoc phi cac mon: {tongphi:N0} vnd");
        Console.WriteLine($"\nTong trung binh hoc phi cac mon: {trungBinh:F2} vnd");

        ds.Sort((a, b) => a.TinChi.CompareTo(b.TinChi));

        Console.WriteLine("\nDanh sach sau khi sap xep");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nMon hoc {i + 1}");
            ds[i].Xuat();
        }
    }
}