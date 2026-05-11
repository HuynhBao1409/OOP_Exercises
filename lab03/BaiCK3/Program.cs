// Phần I — Cài đặt các lớp (6đ)
// 1. Lớp abstract MonAn (3đ)
// Fields: mã món (string), tên món (string), giá gốc (double)
// Properties ràng buộc:

// Mã món: đúng 6 ký tự
// Tên món: độ dài > 0
// Giá gốc: > 0

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhGiaBan()
// 2. Lớp MonAnComBo kế thừa MonAn (1.5đ)
// Fields bổ sung: số món trong combo (int), tỉ lệ giảm giá % (double)
// Properties ràng buộc:

// Số món trong combo: trong khoảng [2, 10]
// Tỉ lệ giảm giá: trong khoảng [0, 50]

// Override Nhap(), Xuat(), TinhGiaBan():

// Giá bán = Giá gốc × Số món × (1 - Tỉ lệ giảm / 100)

// 3. Lớp MonAnDacBiet kế thừa MonAn (1.5đ)
// Fields bổ sung: phụ phí phục vụ (double), có nến/hoa trang trí không (bool)
// Properties ràng buộc:

// Phụ phí phục vụ: >= 0

// Override Nhap(), Xuat(), TinhGiaBan():

// Giá bán = Giá gốc + Phụ phí
// Nếu có trang trí: cộng thêm 50.000


// Phần II — Chương trình chính (4đ)

// (1đ) Nhập danh sách n món ăn (2 ≤ n ≤ 20), mỗi món chọn loại 1. Combo hoặc 2. Đặc biệt rồi nhập thông tin
// (1đ) In toàn bộ danh sách kèm giá bán từng món
// (0.5đ) Tính và in tổng doanh thu + giá bán trung bình
// (0.5đ) Tìm món có giá bán cao nhất và thấp nhất
// (1đ) Sắp xếp theo giá bán giảm dần, nếu bằng nhau thì theo tên món tăng dần (A-Z). In ra sau sắp xếp
using System;
using System.Collections.Generic;

abstract class MonAn
{
    private string maMon;
    private string tenMon;
    private double giaGoc;

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
                Console.WriteLine("loi");
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
                Console.WriteLine("loi");
            }
        }
    }
    public double GiaGoc
    {
        get { return giaGoc; }
        set
        {
            if (value > 0)
            {
                giaGoc = value;
            }
            else
            {
                Console.WriteLine("loi");
            }
        }
    }

    public MonAn() { }
    public MonAn(string maMon, string tenMon, double giaGoc)
    {
        MaMon = maMon;
        TenMon = tenMon;
        GiaGoc = giaGoc;
    }

    public abstract double TinhGiaBan();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("nhap ma mon: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaMon = nhap;
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
            Console.Write("nhap ten mon: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenMon = nhap;
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
            Console.Write("nhap gia mon: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaGoc = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"ma mon: {MaMon}");
        Console.WriteLine($"ten mon: {TenMon}");
        Console.WriteLine($"gia goc: {GiaGoc}");
    }
}

class MonAnComBo : MonAn
{
    private int soMon;
    private double giamGia;

    public int SoMon
    {
        get { return soMon; }
        set
        {
            if (value >= 2 && value <= 10)
            {
                soMon = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double GiamGia
    {
        get { return giamGia; }
        set
        {
            if (value >= 0 && value <= 50)
            {
                giamGia = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public MonAnComBo() : base() { }
    public MonAnComBo(string maMon, string tenMon, double giaGoc, int soMon, double giamGia)
    : base(maMon, tenMon, giaGoc)
    {
        SoMon = soMon;
        GiamGia = giamGia;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("nhap so mon: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 2 && nhap <= 10)
            {
                SoMon = nhap;
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
            Console.Write("nhap giam gia: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 50)
            {
                GiamGia = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override double TinhGiaBan()
    {
        return GiaGoc * SoMon * (1 - GiamGia / 100);
    }

    public override void Xuat()
    {
        Console.WriteLine("[Mon combo]");
        base.Xuat();
        Console.WriteLine($"so mon: {SoMon}");
        Console.WriteLine($"giam gia: {GiamGia}");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
    }
}

class MonAnDacBiet : MonAn
{
    private double phuPhi;
    private bool trangTri;

    public double PhuPhi
    {
        get { return phuPhi; }
        set
        {
            if (value >= 0)
            {
                phuPhi = value;
            }
            else
            {
                Console.WriteLine("loi");
            }
        }
    }
    public bool TrangTri
    {
        get { return trangTri; }
        set { trangTri = value; }
    }

    public MonAnDacBiet() : base() { }
    public MonAnDacBiet(string maMon, string tenMon, double giaGoc, double phuPhi, bool trangTri)
    : base(maMon, tenMon, giaGoc)
    {
        PhuPhi = phuPhi;
        TrangTri = trangTri;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.WriteLine("nhap phu phi: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0)
            {
                PhuPhi = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("loi");
            }
        } while (!hopLe);

        Console.WriteLine("co trang tri ko? (1|co hoac 2|ko): ");
        TrangTri = Console.ReadLine() == "1";

    }

    public override double TinhGiaBan()
    {
        if (TrangTri)
        {
            return GiaGoc + PhuPhi + 50000;
        }
        else
        {
            return GiaGoc + PhuPhi;
        }
    }

    public override void Xuat()
    {
        Console.WriteLine("[Mon an dac biet]");
        base.Xuat();
        Console.WriteLine($"phu phi: {PhuPhi}");
        Console.WriteLine($"co trang tri: {(TrangTri ? "co" : "khong")}");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("nhap so luong: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<MonAn> ds = new List<MonAn>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nMon {i + 1}");
            Console.WriteLine($"chon: 1|combo 2|dac biet");
            MonAn ma = null;
            do
            {
                Console.Write($"chon 1 trong 2: ");
                int loai = int.Parse(Console.ReadLine());
                if (loai == 1)
                {
                    ma = new MonAnComBo();
                }
                else if (loai == 2)
                {
                    ma = new MonAnDacBiet();
                }
                else
                {
                    Console.WriteLine("loi chi chon 1 trong 2");
                }
            } while (ma == null);
            ma.Nhap();
            ds.Add(ma);
        }

        Console.WriteLine("\nDANH SACH MON AN");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nMon {i + 1}");
            ds[i].Xuat();
        }

        double tong = 0;
        foreach (var ma in ds)
        {
            tong += ma.TinhGiaBan();
        }
        double trungBinh = tong / ds.Count;
        Console.WriteLine($"tong doanh thu : {tong:N0} vnd");
        Console.WriteLine($"doanh thu TB: {trungBinh:N0} vnd");

        MonAn max = ds[0];
        MonAn min = ds[0];

        foreach (var ma in ds)
        {
            if (ma.TinhGiaBan() > max.TinhGiaBan()) max = ma;
            if (ma.TinhGiaBan() < min.TinhGiaBan()) min = ma;
        }

        Console.WriteLine($"\nMON CO GIA CAO NHAT");
        max.Xuat();
        Console.WriteLine($"\nMON CO GIA THAP NHAT");
        min.Xuat();

        Console.WriteLine("\nDANH SACH MON AN SAU KHI SAP XEP");
        ds.Sort((a, b) =>
        {
            int kq = b.TinhGiaBan().CompareTo(a.TinhGiaBan());
            if (kq != 0)
            {
                return kq;
            }
            return a.TenMon.CompareTo(b.TenMon);
        });

        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nMon {i + 1}");
            ds[i].Xuat();
        }
    }
}