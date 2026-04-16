using System;
using System.Collections.Generic;

abstract class SinhVien
{
    private string maSV;
    private string hoTen;

    public string MaSV
    {
        get { return maSV; }
        set
        {
            if (value.Length == 8)
            {
                maSV = value;
            }
            else
            {
                Console.WriteLine("Ma sv phai dung 8 ky tu");
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
                Console.WriteLine("Ho ten sv khong dc bo trong");
            }
        }
    }

    public SinhVien() { }
    public SinhVien(string maSV, string hoTen)
    {
        MaSV = maSV;
        HoTen = hoTen;
    }

    public abstract double TinhDiemTB();

    public virtual void Nhap()
    {

        do
        {
            Console.Write("Nhap ma SV: ");
            MaSV = Console.ReadLine();
        } while (maSV == null);
        do
        {
            Console.Write("Nhap ho ten SV: ");
            HoTen = Console.ReadLine();
        } while (hoTen == null);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma SV: {MaSV}");
        Console.WriteLine($"Ho ten SV: {HoTen}");
        Console.WriteLine($"Diem TB: {TinhDiemTB():N2}");
    }

}

class SinhVienIT : SinhVien
{
    private double diemJava;
    private double diemCSharp;

    public double DiemJava
    {
        get { return diemJava; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemJava = value;
            }
            else
            {
                Console.WriteLine("Diem Java ko dc de trong");
            }
        }
    }
    public double DiemCSharp
    {
        get { return diemCSharp; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemCSharp = value;
            }
            else
            {
                Console.WriteLine("Diem C# ko dc de trong");
            }
        }
    }

    public SinhVienIT() : base() { }
    public SinhVienIT(string maSV, string hoTen, double diemJava, double diemCSharp)
    : base(maSV, hoTen)
    {
        DiemJava = diemJava;
        DiemCSharp = diemCSharp;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Diem Java: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                DiemJava = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Diem C Sharp: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                DiemCSharp = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
    }

    public override double TinhDiemTB()
    {
        return (DiemJava + DiemCSharp) / 2;
    }

    public override void Xuat()
    {
        Console.WriteLine("[Sinh vien IT]");
        base.Xuat();
        Console.WriteLine($"Diem Java: {DiemJava}");
        Console.WriteLine($"Diem C Sharp: {DiemCSharp}");

    }

}
class SinhVienKinhTe : SinhVien
{
    private double diemMkt;
    private double diemKeToan;

    public double DiemMkt
    {
        get { return diemMkt; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemMkt = value;
            }
            else
            {
                Console.WriteLine("Diem Mkt ko dc de trong");
            }
        }
    }
    public double DiemKeToan
    {
        get { return diemKeToan; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemKeToan = value;
            }
            else
            {
                Console.WriteLine("Diem ke toan ko dc de trong");
            }
        }
    }

    public SinhVienKinhTe() : base() { }
    public SinhVienKinhTe(string maSV, string hoTen, double diemMkt, double diemKeToan)
    : base(maSV, hoTen)
    {
        DiemKeToan = diemKeToan;
        DiemMkt = diemMkt;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Diem Marketing: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                diemMkt = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Diem Ke toan: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                diemKeToan = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
    }

    public override double TinhDiemTB()
    {
        return (2 * DiemMkt + DiemKeToan) / 3;
    }

    public override void Xuat()
    {
        Console.WriteLine("[Sinh vien kinh te]");
        base.Xuat();
        Console.WriteLine($"Diem Mkt: {DiemMkt}");
        Console.WriteLine($"Diem ke toan: {DiemKeToan}");

    }

}

class Program
{
    static void Main()
    {
        List<SinhVien> ds = new List<SinhVien>();

        Console.Write("Nhap so luong sinh vien: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSinhvien {i + 1}");
            Console.WriteLine("Chon: 1|sinh vien IT  2|sinh vien Kte");
            Console.Write("Chon 1/2: ");
            int loai = int.Parse(Console.ReadLine());

            SinhVien sv = null;
            do
            {

                if (loai == 1)
                {
                    sv = new SinhVienIT();
                }
                else if (loai == 2)
                {
                    sv = new SinhVienKinhTe();
                }
                else
                {
                    Console.WriteLine("Chi chon 1 hoac 2");
                }
            } while (sv == null);
            sv.Nhap();
            ds.Add(sv);
        }

        Console.WriteLine("\nDanh sach sinh vien");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSinhvien {i + 1}");
            ds[i].Xuat();
        }

        SinhVien max = ds[0];
        foreach (var sv in ds)
        {
            if (sv.TinhDiemTB() > max.TinhDiemTB()) max = sv;
        }

        Console.WriteLine("\nSinh vien co diem TB cao nhat");
        max.Xuat();


        Console.WriteLine("\nDanh sach sinh vien co diem TB giam dan");
        ds.Sort((a, b) => b.TinhDiemTB().CompareTo(a.TinhDiemTB()));
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSinhvien {i + 1}");
            ds[i].Xuat();
        }

        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();
    }
}