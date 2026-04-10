// I. Cài đặt lớp (6 điểm)
// 1. Lớp DienThoai

// Xây dựng lớp mô tả điện thoại gồm:

// Thuộc tính:
//  hangSanXuat (string)
//  giaBan (double, > 0)
// Yêu cầu:
//  Constructor không tham số và có tham số
//  Phương thức Nhap()
//  Phương thức Xuat()
// 2. Lớp SmartPhone kế thừa DienThoai
//  Thuộc tính thêm:
//  ram (int, > 0)
//  boNho (int, > 0)
// Yêu cầu:
//  Constructor
//  Override Nhap() và Xuat()
// II. Chương trình chính (4 điểm)
//  Nhập danh sách n smartphone (n > 0)
//  In danh sách ra màn hình
//  Tìm smartphone có giá cao nhất
//  Nhập 1 hãng → in ra các điện thoại thuộc hãng đó
//  Sắp xếp danh sách theo RAM giảm dần

using System;
using System.Collections.Generic;

class DienThoai
{
    private string hangSanXuat;
    private double giaBan;

    public string HangSanXuat
    {
        get { return hangSanXuat; }
        set
        {

            if (value.Length > 0)
            {
                hangSanXuat = value;
            }
            else
            {
                Console.WriteLine("Hang sx ko dc de trong");
            }
        }
    }

    public double GiaBan
    {
        get { return giaBan; }
        set
        {
            if (value > 0)
            {
                giaBan = value;
            }
            else
            {
                Console.WriteLine("gia ban ko dc de trong");
            }
        }
    }

    public DienThoai() { }

    public DienThoai(string hangSanXuat, double giaBan)
    {
        HangSanXuat = hangSanXuat;
        GiaBan = giaBan;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Nhap hang: ");
            HangSanXuat = Console.ReadLine();
        } while (hangSanXuat == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nhap Gia ban: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaBan = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi gia ban");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Hang SX: {HangSanXuat}");
        Console.WriteLine($"Gia ban: {GiaBan:N0} vnd");
    }
}

class SmartPhone : DienThoai
{
    private int ram;
    private int boNho;

    public int Ram
    {
        get { return ram; }
        set
        {
            if (value > 0)
            {
                ram = value;
            }
            else
            {
                Console.WriteLine("Ram ko dc de trong");
            }
        }
    }
    public int BoNho
    {
        get { return boNho; }
        set
        {
            if (value > 0)
            {
                boNho = value;
            }
            else
            {
                Console.WriteLine("Bo nho ko dc de trong");
            }
        }
    }

    public SmartPhone() : base() { }
    public SmartPhone(string hangSanXuat, double giaBan, int ram, int boNho)
    : base(hangSanXuat, giaBan)
    {
        Ram = ram;
        BoNho = boNho;
    }

    public override void Nhap()
    {
        base.Nhap();
        do
        {
            Console.Write("Nhap Ram: ");
            Ram = int.Parse(Console.ReadLine());
        } while (ram == 0);
        do
        {
            Console.Write("Nhap bo nho: ");
            BoNho = int.Parse(Console.ReadLine());
        } while (boNho == 0);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Ram: {Ram} GB");
        Console.WriteLine($"Bo nho: {boNho} GB");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        bool hopLe = false;
        do
        {
            Console.Write("Nhap so luong dien thoai: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                n = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Ko dc bo trong");
            }
        } while (!hopLe);

        List<SmartPhone> ds = new List<SmartPhone>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nDien thoai {i + 1}");
            SmartPhone phone = new SmartPhone();
            phone.Nhap();
            ds.Add(phone);
        }
        Console.WriteLine("\n=== Danh sach dien thoai ===");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nDien thoai {i + 1}");
            ds[i].Xuat();
        }

        SmartPhone max = ds[0];
        foreach (var phone in ds)
        {
            if (phone.GiaBan > max.GiaBan) max = phone;
        }

        Console.WriteLine("\n=== Dien thoai co gia cao nhat ===");
        max.Xuat();

        Console.Write("\nNhap hang can tim: ");
        string hang = Console.ReadLine();

        bool timThay = false;

        Console.WriteLine($"\n===Hang dien thoai {hang.ToUpper()} can tim ===");
        foreach (var phone in ds)
        {
            if (phone.HangSanXuat.ToLower() == hang.ToLower())
            {
                phone.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine($"Ko tim thay {hang}");
        }

        ds.Sort((a, b) => b.Ram.CompareTo(a.Ram));

        Console.WriteLine("\n=== Danh sach dien thoai co RAM giam dan ===");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nDien thoai {i + 1}");
            ds[i].Xuat();
        }

        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();

    }
}