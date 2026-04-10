// 1. Lớp abstract PhuongTien mô tả phương tiện giao thông, gồm: (0.5đ)

// Fields: biển số (string), năm sản xuất (int), số km đã đi (double).
// Properties tương ứng, ràng buộc khi set: (1đ)
// Biển số độ dài > 0.
// Năm sản xuất trong khoảng [1900, 2025].
// Số km đã đi >= 0.
// Các phương thức: khởi tạo, Nhap(), Xuat().
// Phương thức abstract: TinhPhiBaoHiem() trả về double. (1.5đ)
// 2. Lớp OTo kế thừa PhuongTien, có thêm: (0.5đ)

// Fields: số chỗ ngồi (int), loại nhiên liệu (string: xăng/dầu/điện). (0.5đ)
// Property số chỗ ngồi ràng buộc trong khoảng [2, 16]. (0.5đ)
// Override Nhap(), Xuat(), khởi tạo. (1đ)
// Implement TinhPhiBaoHiem() theo công thức: (1đ)
// Phí = Số chỗ ngồi × 500.000 + Số km đã đi × 100
// II. Chương trình chính (4đ)

// Nhập danh sách n ô tô (2 ≤ n ≤ 20). (1đ)
// In danh sách kèm phí bảo hiểm của từng xe. (1đ)
// Tìm xe có phí bảo hiểm cao nhất và thấp nhất. (1đ)
// Lọc và in các xe dùng nhiên liệu điện. (1đ)

using System;
using System.Collections.Generic;

abstract class PhuongTien //abstract lớp trừu tượng
{
    private string bienSo;
    private int namSanXuat;
    private double soKM;

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
                Console.WriteLine("Loi: Bien so khong dc de trong");
            }
        }
    }
    public int NamSanXuat
    {
        get { return namSanXuat; }
        set
        {
            if (value >= 1900 && value <= 2025)
            {
                namSanXuat = value;
            }
            else
            {
                Console.WriteLine("Loi: Nam san xuat phai tu[1900-2025]");
            }
        }
    }
    public double SoKM
    {
        get { return soKM; }
        set
        {
            if (value >= 0)
            {
                soKM = value;
            }
            else
            {
                Console.WriteLine("Loi: So KM khong dc de trong");
            }
        }
    }

    public PhuongTien() { }

    public PhuongTien(string bienSo, int namSanXuat, double soKM)
    {
        BienSo = bienSo;
        NamSanXuat = namSanXuat;
        SoKM = soKM;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Bien so: ");
            BienSo = Console.ReadLine();
        } while (bienSo == null);

        bool hopLe = false;
        do
        {
            Console.Write("Nam san xuat: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1900 && nhap <= 2025)
            {
                NamSanXuat = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi nam san xuat");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("So KM da di: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0)
            {
                SoKM = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi so KM");
            }
        } while (!hopLe);
    }

    public abstract double TinhPhiBaoHiem();

    public virtual void Xuat()
    {
        Console.WriteLine($"Bien so: {BienSo}");
        Console.WriteLine($"Nam SX: {NamSanXuat}");
        Console.WriteLine($"So Km: {SoKM:N0} km");
        Console.WriteLine($"Phi bao hiem: {TinhPhiBaoHiem():N0} vnd");
    }
}

class OTo : PhuongTien
{
    private int soCho;
    private string loaiNhienLieu;

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
                Console.WriteLine("So cho ko dc de trong");
            }
        }
    }
    public string LoaiNhienLieu
    {
        get { return loaiNhienLieu; }
        set
        {
            if (value.Length > 0)
            {
                loaiNhienLieu = value;
            }
            else
            {
                Console.WriteLine("Loai nhien lieu ko dc de trong");
            }
        }
    }

    public OTo() : base() { }

    public OTo(string bienSo, int namSanXuat, double soKM, int soCho, string loaiNhienLieu)
    : base(bienSo, namSanXuat, soKM)
    {
        SoCho = soCho;
        LoaiNhienLieu = loaiNhienLieu;
    }

    public override double TinhPhiBaoHiem()
    {
        return SoCho * 500000 + SoKM * 100;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("So cho: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 2 && nhap <= 16)
            {
                SoCho = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi: so cho [2-16]");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Loai nhien lieu (xang/dau/dien): ");
            string nhap = Console.ReadLine().ToLower();
            if (nhap == "xang" || nhap == "dau" || nhap == "dien")
            {
                LoaiNhienLieu = nhap;
                hopLe = true;
            }
            else
                Console.WriteLine("  Loi: chi chap nhan xang/dau/dien!");
        } while (!hopLe);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So cho: {SoCho}");
        Console.WriteLine($"Loai nhien lieu: {LoaiNhienLieu}");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap so luong Oto: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("So luong phai tu [2-20]");
            }
        } while (n < 2 || n > 20);

        List<OTo> ds = new List<OTo>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n Oto{i + 1} ");
            OTo o = new OTo();
            o.Nhap();
            ds.Add(o);
        }

        Console.WriteLine("\n========== DANH SACH O TO ==========");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\n Oto{i + 1}");
            ds[i].Xuat();
        }

        OTo min = ds[0];
        OTo max = ds[0];

        foreach (var o in ds)
        {
            if (o.TinhPhiBaoHiem() < min.TinhPhiBaoHiem()) min = o;
            if (o.TinhPhiBaoHiem() > max.TinhPhiBaoHiem()) max = o;
        }

        Console.WriteLine("\n========== XE PHI BAO HIEM CAO NHAT ==========");
        max.Xuat();
        Console.WriteLine("\n========== XE PHI BAO HIEM THAP NHAT ==========");
        min.Xuat();

        Console.WriteLine("\n========== XE DUNG NHIEN LIEU DIEN ==========");
        bool timThay = false;

        foreach (var o in ds)
        {
            if (o.LoaiNhienLieu == "dien")
            {
                o.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Ko tim thay xe dung nhien lieu dien");
        }

        Console.WriteLine("\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}