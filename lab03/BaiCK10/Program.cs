// Phần I (6đ)
// 1. Interface IDanhGia (0.5đ)
// string XepLoai() — trả về chuỗi xếp loại
// void InBaoCao()
// 2. Lớp abstract KhoaHoc (2.5đ)
// Fields: mã KH (string 6 ký tự), tên KH (string > 0), số buổi (int trong [1, 60])
// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhHocPhi()
// 3. Lớp KhoaHocOnline kế thừa KhoaHoc, implement IDanhGia (3đ)
// Fields bổ sung: giá mỗi buổi (double > 0), số học viên (int > 0), tỉ lệ hoàn thành % (double trong [0, 100])
// TinhHocPhi():
// Học phí = Giá mỗi buổi × Số buổi
// XepLoai(): theo tỉ lệ hoàn thành:
// = 80: "Xuat sac"
// = 60: "Kha"
// = 40: "Trung binh"
// < 40: "Yeu"
// InBaoCao(): in tên KH, số HV, tỉ lệ hoàn thành, xếp loại, học phí
// Phần II (4đ)

// (1đ) Nhập n khóa học (2 ≤ n ≤ 20), mã không được trùng
// (0.5đ) Gọi InBaoCao() cho từng khóa
// (0.5đ) Tìm khóa có học phí cao nhất và thấp nhất
// (1đ) Nhập xếp loại cần tìm, đếm số khóa có xếp loại đó và in tổng học phí nhóm đó. Thông báo nếu không có
// (1đ) Sắp xếp theo tỉ lệ hoàn thành giảm dần, nếu bằng nhau thì theo học phí tăng dần
using System;
using System.Collections.Generic;

interface IDanhGia
{
    string XepLoai();
    void InBaoCao();
}

abstract class KhoaHoc
{
    private string maKH;
    private string tenKH;
    private int soBuoi;

    public string MaKH
    {
        get { return maKH; }
        set
        {
            if (value.Length == 6)
            {
                maKH = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string TenKH
    {
        get { return tenKH; }
        set
        {
            if (value.Length > 0)
            {
                tenKH = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoBuoi
    {
        get { return soBuoi; }
        set
        {
            if (value >= 1 && value <= 60)
            {
                soBuoi = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public KhoaHoc() { }
    public KhoaHoc(string maKH, string tenKH, int soBuoi)
    {
        MaKH = maKH;
        TenKH = tenKH;
        SoBuoi = soBuoi;
    }

    public abstract double TinhHocPhi();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma KH: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6) { MaKH = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap ten KH: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0) { TenKH = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so buoi: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 60)
            { SoBuoi = nhap; hopLe = true; }
            else Console.WriteLine("Loi");
        } while (!hopLe);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma KH: {MaKH}");
        Console.WriteLine($"Ten KH: {TenKH}");
        Console.WriteLine($"So buoi: {SoBuoi}");
    }
}

class KhoaHocOnline : KhoaHoc, IDanhGia
{
    private double giaMoiBuoi;
    private int soHV;
    private double tiLeHoanThanh;

    public double GiaMoiBuoi
    {
        get { return giaMoiBuoi; }
        set
        {
            if (value > 0) giaMoiBuoi = value;
            else Console.WriteLine("Loi");
        }
    }
    public int SoHV
    {
        get { return soHV; }
        set
        {
            if (value > 0) soHV = value;
            else Console.WriteLine("Loi");
        }
    }
    public double TiLeHoanThanh
    {
        get { return tiLeHoanThanh; }
        set
        {
            if (value >= 0 && value <= 100) tiLeHoanThanh = value;
            else Console.WriteLine("Loi");
        }
    }

    public KhoaHocOnline() : base() { }
    public KhoaHocOnline(string maKH, string tenKH, int soBuoi, double giaMoiBuoi, int soHV, double tiLeHoanThanh)
    : base(maKH, tenKH, soBuoi)
    {
        GiaMoiBuoi = giaMoiBuoi;
        SoHV = soHV;
        TiLeHoanThanh = tiLeHoanThanh;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap gia moi buoi: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaMoiBuoi = nhap;
                hopLe = true;
            }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap so hoc vien: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoHV = nhap;
                hopLe = true;
            }
            else Console.WriteLine("Loi");
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Nhap ti le hoan thanh: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 100)
            {
                TiLeHoanThanh = nhap;
                hopLe = true;
            }
            else Console.WriteLine("Loi");
        } while (!hopLe);
    }

    public override double TinhHocPhi()
    {
        return GiaMoiBuoi * SoBuoi;
    }

    public string XepLoai()
    {
        if (TiLeHoanThanh >= 80) return "Xuat sac";
        else if (TiLeHoanThanh >= 60) return "Kha";
        else if (TiLeHoanThanh >= 40) return "Trung binh";
        else return "Yeu";
    }

    public void InBaoCao()
    {
        Console.WriteLine($"Ten KH: {TenKH}");
        Console.WriteLine($"So HV: {SoHV}");
        Console.WriteLine($"Ti le hoan thanh: {TiLeHoanThanh}%");
        Console.WriteLine($"Xep loai: {XepLoai()}");
        Console.WriteLine($"Hoc phi: {TinhHocPhi():N0} vnd");
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Gia moi buoi: {GiaMoiBuoi:N0} vnd");
        Console.WriteLine($"So HV: {SoHV}");
        Console.WriteLine($"Ti le hoan thanh: {TiLeHoanThanh}%");
        Console.WriteLine($"Xep loai: {XepLoai()}");
        Console.WriteLine($"Hoc phi: {TinhHocPhi():N0} vnd");
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

        List<KhoaHocOnline> ds = new List<KhoaHocOnline>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nKhoa hoc {i + 1}");
            KhoaHocOnline kh = new KhoaHocOnline();
            bool maTrung;
            do
            {
                kh.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaKH == kh.MaKH)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung) Console.WriteLine("Ma trung nhap lai");
            } while (maTrung);
            ds.Add(kh);
        }

        Console.WriteLine("\nBAO CAO KHOA HOC TUNG KHOA");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nKhoa hoc {i + 1}");
            ds[i].InBaoCao();
        }

        KhoaHocOnline min = ds[0];
        KhoaHocOnline max = ds[0];

        foreach (var kh in ds)
        {
            if (kh.TinhHocPhi() < min.TinhHocPhi()) min = kh;
            if (kh.TinhHocPhi() > max.TinhHocPhi()) max = kh;
        }

        Console.WriteLine("\nKHOA HOC CO GIA CAO NHAT");
        max.Xuat();
        Console.WriteLine("\nKHOA HOC CO GIA THAP NHAT");
        min.Xuat();

        bool hopLe = false;
        string xl = null;
        do
        {
            Console.Write("\nNhap xep loai: ");
            xl = Console.ReadLine().ToLower();
            if (xl == "xuat sac" || xl == "kha" || xl == "trung binh" || xl == "yeu")
            {
                hopLe = true; // chỉ cần flag
            }
            else
            {
                Console.WriteLine("Nhap dung ten xep loai!");
            }
        } while (!hopLe);
        int dem = 0;
        double tong = 0;

        foreach (var kh in ds)
        {
            if (kh.XepLoai().ToLower() == xl)
            {
                dem++;
                tong += kh.TinhHocPhi();
            }
        }
        if (dem == 0) Console.WriteLine("Khong co xep loai o khoa hoc day");
        else
        {
            Console.WriteLine($"\nKhoa hoc co {xl}: {dem}");
            Console.WriteLine($"Tong hoc phi: {tong:N0} vnd");
        }

        ds.Sort((a, b) =>
        {
            int kq = b.TiLeHoanThanh.CompareTo(a.TiLeHoanThanh);
            if (kq != 0)
            {
                return kq;
            }
            return a.TinhHocPhi().CompareTo(b.TinhHocPhi());
        });

        Console.WriteLine("\nBAO CAO KHOA HOC TUNG KHOA SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nKhoa hoc {i + 1}");
            ds[i].InBaoCao();
        }
    }
}