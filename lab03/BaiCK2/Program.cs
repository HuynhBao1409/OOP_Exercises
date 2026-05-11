// Phần I — Cài đặt các lớp (6đ)
// 1. Interface IXepLoai (0.5đ)
// string XepLoai() — trả về chuỗi xếp loại
// void InThongTin()

// 2. Lớp abstract VanDongVien (2.5đ)
// Fields: mã VĐV (string), họ tên (string), quốc gia (string)
// Properties ràng buộc:
// Mã VĐV: đúng 6 ký tự
// Họ tên: độ dài > 0
// Quốc gia: độ dài > 0
// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhDiemTong()

// 3. Lớp VanDongVienBoi kế thừa VanDongVien, implement IXepLoai (3đ)
// Fields bổ sung: thời gian bơi (double, đơn vị giây), số lần phạm quy (int), hệ số cự ly (double)
// Properties ràng buộc:
// Thời gian bơi: > 0
// Số lần phạm quy: trong khoảng [0, 3]
// Hệ số cự ly: trong khoảng [1.0, 3.0]
// TinhDiemTong():
// Điểm = 1000 / Thời gian × Hệ số cự ly − Số lần phạm quy × 5
// XepLoai(): trả về chuỗi theo điểm tổng:
// = 80: "Vang"
// = 60: "Bac"
// = 40: "Dong"
// < 40: "Khong dat"
// InThongTin(): in họ tên, thời gian, điểm tổng, xếp loại

// Phần II — Chương trình chính (4đ)

// (1đ) Nhập danh sách n vận động viên bơi (2 ≤ n ≤ 20)
// (1đ) Gọi InThongTin() cho từng VĐV
// (0.5đ) Tìm VĐV có điểm tổng cao nhất và thấp nhất
// (0.5đ) Nhập tên quốc gia, lọc và in tất cả VĐV thuộc quốc gia đó (không phân biệt hoa thường). Thông báo nếu không tìm thấy
// (1đ) Sắp xếp theo điểm tổng giảm dần, nếu bằng nhau thì theo thời gian bơi tăng dần. In ra sau sắp xếp

using System;
using System.Collections.Generic;

interface IXepLoai
{
    string XepLoai();
    void InThongTin();
}

abstract class VanDongVien
{
    private string maVDV;
    private string hoTen;
    private string quocGia;

    public string MaVDV
    {
        get { return maVDV; }
        set
        {
            if (value.Length == 6)
            {
                maVDV = value;
            }
            else
            {
                Console.WriteLine("Loi");
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
                Console.WriteLine("Loi");
            }
        }
    }
    public string QuocGia
    {
        get { return quocGia; }
        set
        {
            if (value.Length > 0)
            {
                quocGia = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public VanDongVien() { }
    public VanDongVien(string maVDV, string hoTen, string quocGia)
    {
        MaVDV = maVDV;
        HoTen = hoTen;
        QuocGia = quocGia;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("ma vdv: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaVDV = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("ho ten vdv: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                HoTen = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("quoc gia vdv: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                QuocGia = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
    }

    public abstract double TinhDiemTong();

    public virtual void Xuat()
    {
        Console.WriteLine($"ma vdv: {MaVDV}");
        Console.WriteLine($"ho ten vdv: {HoTen}");
        Console.WriteLine($"quoc gia: {QuocGia}");

    }
}

class VanDongVienBoi : VanDongVien, IXepLoai
{
    private double thoiGian;
    private int phamQuy;
    private double cuLy;

    public double ThoiGian
    {
        get { return thoiGian; }
        set
        {
            if (value > 0)
            {
                thoiGian = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int PhamQuy
    {
        get { return phamQuy; }
        set
        {
            if (value >= 0 && value <= 3)
            {
                phamQuy = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double CuLy
    {
        get { return cuLy; }
        set
        {
            if (value >= 1.0 && value <= 3.0)
            {
                cuLy = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public VanDongVienBoi() : base() { }
    public VanDongVienBoi(string maVDV, string hoTen, string quocGia, double thoiGian, int phamQuy, double cuLy)
    : base(maVDV, hoTen, quocGia)
    {
        ThoiGian = thoiGian;
        PhamQuy = phamQuy;
        CuLy = cuLy;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("nhap thoi gian boi: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                ThoiGian = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("nhap so lan pham loi: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0 && nhap <= 3)
            {
                PhamQuy = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("nhap cu ly: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 1.0 && nhap <= 3.0)
            {
                CuLy = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
    }

    public override double TinhDiemTong()
    {
        return (1000 / ThoiGian * CuLy) - (PhamQuy * 5);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"thoi gian: {ThoiGian}s");
        Console.WriteLine($"pham loi: {PhamQuy} lan");
        Console.WriteLine($"Cu ly: {CuLy}");
        Console.WriteLine($"Tong diem: {TinhDiemTong():F2}");
    }

    public string XepLoai()
    {
        double diem = TinhDiemTong();
        if (diem >= 80) return "vang";
        else if (diem >= 60) return "bac";
        else if (diem >= 40) return "dong";
        else return "ko dat";
    }

    public void InThongTin()
    {
        Console.WriteLine($"ho ten: {HoTen}");
        Console.WriteLine($"thoi gian: {ThoiGian}s");
        Console.WriteLine($"Tong diem: {TinhDiemTong():F2}");
        Console.WriteLine($"Xep loai: {XepLoai()}");
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
                Console.WriteLine("Loi ");
            }
        } while (n < 2 || n > 20);
        List<VanDongVienBoi> ds = new List<VanDongVienBoi>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nVan dong vien {i + 1}");
            VanDongVienBoi vdv = new VanDongVienBoi();
            vdv.Nhap();
            ds.Add(vdv);
        }

        Console.WriteLine("\nDANH SACH VAN DONG VIEN");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nVDV {i + 1}");
            ds[i].Xuat();
        }

        VanDongVienBoi max = ds[0], min = ds[0];
        foreach (var vdv in ds)
        {
            if (vdv.TinhDiemTong() > max.TinhDiemTong()) max = vdv;
            if (vdv.TinhDiemTong() < min.TinhDiemTong()) min = vdv;
        }
        Console.WriteLine("\nVDV DIEM CAO NHAT");
        max.InThongTin();
        Console.WriteLine("\nVDV DIEM THAP NHAT");
        min.InThongTin();
        Console.Write("\nNhap quoc gia: ");
        string qg = Console.ReadLine();
        bool timThay = false;
        Console.WriteLine($"\nVDV THUOC QUOC GIA {qg.ToUpper()}");
        foreach (var vdv in ds)
        {
            if (vdv.QuocGia.ToLower() == qg.ToLower())
            {
                vdv.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay) Console.WriteLine("Khong tim thay!");

        ds.Sort((a, b) =>
        {
            int kq = b.TinhDiemTong().CompareTo(a.TinhDiemTong());
            if (kq != 0)
            {
                return kq;
            }
            return a.ThoiGian.CompareTo(b.ThoiGian);
        });
        Console.WriteLine("\nDANH SACH SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nVDV {i + 1}");
            ds[i].Xuat();
        }
    }
}