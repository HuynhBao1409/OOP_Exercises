// Phần I (6đ)
// 1. Lớp abstract XeThue (2.5đ)
// Fields: biển số (string), hãng xe (string), số chỗ (int)
// Properties: biển số độ dài > 0, hãng xe độ dài > 0, số chỗ trong [2, 16]
// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhTienThue()
// 2. Lớp XeThueTuLai kế thừa XeThue (3.5đ)
// Fields bổ sung: giá thuê mỗi ngày (double), số ngày thuê (int), có bảo hiểm không (bool)
// Properties: giá thuê > 0, số ngày trong [1, 30]
// TinhTienThue():

// Tiền = Giá thuê × Số ngày
// Nếu có bảo hiểm: cộng thêm 200.000


// Phần II (4đ)

// (1đ) Nhập n xe (2 ≤ n ≤ 20)
// (0.5đ) In danh sách kèm tiền thuê
// (0.5đ) Tìm xe có tiền thuê cao nhất
// (1đ) Nhập số ngày, đếm xe có số ngày >= số vừa nhập, in tổng tiền nhóm đó
// (1đ) Sắp xếp theo tiền thuê giảm dần

using System;
using System.Collections.Generic;

abstract class XeThue
{
    private string bienSo;
    private string hangXe;
    private int soCho;

    public string BienSo
    {
        get { return bienSo; }
        set
        {
            if (value.Length > 0)
            {
                bienSo = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string HangXe
    {
        get { return hangXe; }
        set
        {
            if (value.Length > 0)
            {
                hangXe = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoCho
    {
        get { return soCho; }
        set
        {
            if (value >= 2 && value <= 16)
            {
                soCho = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public XeThue() { }
    public XeThue(string bienSo, string hangXe, int soCho)
    {
        BienSo = bienSo;
        HangXe = hangXe;
        SoCho = soCho;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap bien so: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                BienSo = nhap;
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
            Console.Write("Nhap hang xe: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                HangXe = nhap;
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
            Console.Write("Nhap so cho: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 2 && nhap <= 16)
            {
                SoCho = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public abstract double TinhTienThue();

    public virtual void Xuat()
    {
        Console.WriteLine($"Bien so: {BienSo}");
        Console.WriteLine($"Hang xe: {HangXe}");
        Console.WriteLine($"So Cho: {SoCho}");
    }
}

class XeThueTuLai : XeThue
{
    private double giaThue;
    private int soNgay;
    private bool baoHiem;

    public double GiaThue
    {
        get { return giaThue; }
        set
        {
            if (value > 0)
            {
                giaThue = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoNgay
    {
        get { return soNgay; }
        set
        {
            if (value >= 1 && value <= 30)
            {
                soNgay = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public bool BaoHiem
    {
        get { return baoHiem; }
        set { baoHiem = value; }
    }

    public XeThueTuLai() : base() { }
    public XeThueTuLai(string bienSo, string hangXe, int soCho, double giaThue, int soNgay, bool baoHiem)
    : base(bienSo, hangXe, soCho)
    {
        GiaThue = giaThue;
        SoNgay = soNgay;
        BaoHiem = baoHiem;
    }
    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap gia thue: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaThue = nhap;
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
            Console.Write("Nhap so ngay thue: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > +1 && nhap <= 30)
            {
                SoNgay = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
        Console.Write("Co bao hiem khong? (1| co - 2| khong): ");
        BaoHiem = Console.ReadLine() == "1";
    }

    public override double TinhTienThue()
    {
        double tien = GiaThue * SoNgay;
        if (BaoHiem)
        {
            return tien + 200000;
        }
        else
        {
            return tien;
        }
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Gia Thue: {GiaThue:N0} vnd");
        Console.WriteLine($"So ngay thue: {SoNgay:N0}");
        Console.WriteLine($"Co bao hiem?: {(BaoHiem ? "Co" : "Khong")}");
        Console.WriteLine($"Tien thue: {TinhTienThue():N0} vnd");
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

        List<XeThueTuLai> ds = new List<XeThueTuLai>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nXe {i + 1}");
            XeThueTuLai xe = new XeThueTuLai();
            xe.Nhap();
            ds.Add(xe);
        }

        Console.WriteLine("\nDANH SACH XE THUE");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nXe {i + 1}");
            ds[i].Xuat();
        }

        XeThueTuLai max = ds[0];
        foreach (var xe in ds)
        {
            if (xe.TinhTienThue() > max.TinhTienThue()) max = xe;
        }

        Console.WriteLine("\nXE CO GIA CAO NHAT");
        max.Xuat();

        Console.WriteLine("\nNhap so ngay thue: ");
        int thue = int.Parse(Console.ReadLine());
        int dem = 0;
        double tong = 0;

        foreach (var xe in ds)
        {
            if (xe.SoNgay >= thue)
            {
                dem++;
                tong += xe.TinhTienThue();
            }
        }
        if (dem == 0) Console.WriteLine("Ko tim thay");
        else
        {
            Console.WriteLine($"So xe: {dem}");
            Console.WriteLine($"Tong tien: {tong:N0} vnd");
        }

        ds.Sort((a, b) => b.TinhTienThue().CompareTo(a.TinhTienThue()));
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nXe {i + 1}");
            ds[i].Xuat();
        }
    }
}