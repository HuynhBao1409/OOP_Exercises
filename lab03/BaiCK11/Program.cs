// 1. Interface IPhuPhi (0.5đ)

// double TinhPhuPhi()

// 2. Lớp abstract CanHo (2.5đ)
// Fields: mã CH (string 6 ký tự), tên dự án (string > 0), diện tích (double > 0), ngày bàn giao (DateTime)

// static double GiaM2 = 30 (triệu/m²) — dùng chung cho tất cả

// TinhGiaBan():

// Bàn giao trước 2023: GiaM2 × 1.1
// Bàn giao trong 2023-2024: GiaM2 × 1.2
// Còn lại: GiaM2 × 1.35

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhTongGia()
// 3. Lớp CanHoChungCu kế thừa CanHo, implement IPhuPhi (3đ)
// Fields bổ sung: tầng (int trong [1, 50]), phí quản lý mỗi tháng (double > 0), số tháng đóng trước (int trong [1, 24])
// TinhPhuPhi():

// Phụ phí = Phí quản lý × Số tháng

// TinhTongGia():

// Tổng = Diện tích × TinhGiaBan() + TinhPhuPhi()


// Phần II (4đ)

// (1đ) Nhập n căn hộ (2 ≤ n ≤ 20), mã không được trùng
// (0.5đ) In danh sách kèm tổng giá từng căn
// (0.5đ) Tìm căn có tổng giá cao nhất và thấp nhất
// (1đ) Nhập tầng, xóa tất cả căn hộ có tầng đó khỏi danh sách, in danh sách sau xóa. Thông báo nếu không có
// (1đ) Sắp xếp theo tổng giá tăng dần. In ra sau sắp xếp

using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

interface IPhuPhi
{
    double TinhPhuPhi();
}

abstract class CanHo
{
    private string maCH;
    private string tenDuAn;
    private double dienTich;
    private DateTime ngayGiao;
    public static double GiaM2 = 30;

    public string MaCH
    {
        get { return maCH; }
        set
        {
            if (value.Length == 6)
            {
                maCH = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string TenDuAn
    {
        get { return tenDuAn; }
        set
        {
            if (value.Length > 0)
            {
                tenDuAn = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double DienTich
    {
        get { return dienTich; }
        set
        {
            if (value > 0)
            {
                dienTich = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public DateTime NgayGiao
    {
        get { return ngayGiao; }
        set { ngayGiao = value; }
    }

    public CanHo() { }
    public CanHo(string maCH, string tenDuAn, double dienTich, DateTime ngayGiao)
    {
        MaCH = maCH;
        TenDuAn = tenDuAn;
        DienTich = dienTich;
        NgayGiao = ngayGiao;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma CH: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaCH = nhap;
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
            Console.Write("Nhap ten du an: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenDuAn = nhap;
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
            Console.Write("Nhap dien tich (m^2): ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                DienTich = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        Console.Write("Nhap ngay giao(d/M/yyyy): ");
        NgayGiao = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);
    }

    public abstract double TinhTongGia();

    public double TinhGiaBan()
    {
        int namGiao = NgayGiao.Year;
        if (namGiao < 2023) return GiaM2 * 1.1;
        else if (namGiao <= 2024) return GiaM2 * 1.2;
        else return GiaM2 * 1.35;
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma can ho: {MaCH}");
        Console.WriteLine($"Ten du an: {TenDuAn}");
        Console.WriteLine($"Dien tich: {DienTich:F2} m^2");
        Console.WriteLine($"Ngay ban giao: {NgayGiao:dd/MM/yyyy}");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
    }
}

class CanHoChungCu : CanHo, IPhuPhi
{
    private int tang;
    private double phiQuanLy;
    private int soThangDong;

    public int Tang
    {
        get { return tang; }
        set
        {
            if (value >= 1 && value <= 50)
            {
                tang = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double PhiQuanLy
    {
        get { return phiQuanLy; }
        set
        {
            if (value > 0)
            {
                phiQuanLy = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoThangDong
    {
        get { return soThangDong; }
        set
        {
            if (value >= 1 && value <= 24)
            {
                soThangDong = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public CanHoChungCu() : base() { }
    public CanHoChungCu(string maCH, string tenDuAn, double dienTich, DateTime ngayGiao, int tang, double phiQuanLy, int soThangDong)
    : base(maCH, tenDuAn, dienTich, ngayGiao)
    {
        Tang = tang;
        PhiQuanLy = phiQuanLy;
        SoThangDong = soThangDong;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap so tang: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 50)
            {
                Tang = nhap;
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
            Console.Write("Nhap phi quan ly: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                PhiQuanLy = nhap;
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
            Console.Write("Nhap so thang dong truoc: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 24)
            {
                SoThangDong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public double TinhPhuPhi()
    {
        return PhiQuanLy * SoThangDong;
    }

    public override double TinhTongGia()
    {
        return DienTich * TinhGiaBan() + TinhPhuPhi();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Tang: {Tang}");
        Console.WriteLine($"Phi quan ly: {PhiQuanLy:N0} vnd ");
        Console.WriteLine($"so thang dong trc: {SoThangDong}");
        Console.WriteLine($"Phu phi: {TinhPhuPhi():N0} vnd");
        Console.WriteLine($"Tong gia: {TinhTongGia():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap n: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<CanHoChungCu> ds = new List<CanHoChungCu>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nCan ho {i + 1}");
            CanHoChungCu ch = new CanHoChungCu();
            bool maTrung;
            do
            {
                ch.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaCH == ch.MaCH)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung) Console.WriteLine("loi");
            } while (maTrung);
            ds.Add(ch);
        }

        Console.WriteLine("\nDANH SACH CAC CAN HO");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nCan ho {i + 1}");
            ds[i].Xuat();
        }

        CanHoChungCu min = ds[0];
        CanHoChungCu max = ds[0];
        foreach (var ch in ds)
        {
            if (ch.TinhTongGia() > max.TinhTongGia()) max = ch;
            if (ch.TinhTongGia() < min.TinhTongGia()) min = ch;
        }
        Console.WriteLine("\nDANH SACH CAC CAN HO Gia CAO NHAT");
        max.Xuat();
        Console.WriteLine("\nDANH SACH CAC CAN HO Gia THAP NHAT");
        min.Xuat();

        bool hopLe = false;
        int tangNhap = 0;
        do
        {
            Console.Write("\nNhap so tang can xoa: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 50)
            {
                tangNhap = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        int tangXoa = ds.RemoveAll(ch => ch.Tang == tangNhap);
        if (tangXoa == 0)
        {
            Console.WriteLine("\nKhong tim thay");
        }
        else
        {
            Console.WriteLine($"\nDA XOA {tangXoa} DANH SACH CAC CAN HO SAU KHI XOA TANG {tangNhap}");
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine($"\nCan ho {i + 1}");
                ds[i].Xuat();
            }
        }

        ds.Sort((a, b) => a.TinhTongGia().CompareTo(b.TinhTongGia()));
        Console.WriteLine($"\nDANH SACH CAC CAN HO SAU KHI SAP XEP TANG DAN");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nCan ho {i + 1}");
            ds[i].Xuat();
        }
    }
}