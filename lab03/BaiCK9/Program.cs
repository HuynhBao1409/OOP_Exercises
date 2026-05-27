// Phần I (6đ)
// 1. Interface IBaoCao (0.5đ)

// double TinhDoanhThu()
// void InBaoCao()

// 2. Lớp abstract ToaNha (2.5đ)
// Fields: mã TN (string 6 ký tự), tên TN (string > 0), số tầng (int trong [1, 50])
// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhDoanhThu()
// 3. Lớp ToaNhaVanPhong kế thừa ToaNha, implement IBaoCao (3đ)
// Fields bổ sung: giá thuê mỗi tầng (double > 0), số tầng đã thuê (int >= 0 và <= số tầng), tỉ lệ dịch vụ % (double trong [0, 20])
// TinhDoanhThu():

// Doanh thu = Số tầng đã thuê × Giá thuê × (1 + Tỉ lệ DV / 100)

// InBaoCao(): in tên TN, số tầng đã thuê, tỉ lệ DV, doanh thu

// Phần II (4đ)

// (1đ) Nhập n tòa nhà (2 ≤ n ≤ 20), mã không được trùng
// (0.5đ) Gọi InBaoCao() cho từng tòa nhà
// (0.5đ) Tìm tòa nhà có doanh thu cao nhất
// (1đ) Nhập tên tòa nhà, tìm theo 3 ký tự đầu (không phân biệt hoa thường), in ra nếu tìm thấy. Thông báo nếu không có
// (1đ) Sắp xếp theo doanh thu giảm dần

using System;
using System.Collections.Generic;
using System.Reflection.Emit;

interface IBaoCao
{
    double TinhDoanhThu();
    void InBaoCao();
}

abstract class ToaNha
{
    private string maTN;
    private string tenTN;
    private int soTang;

    public string MaTN
    {
        get { return maTN; }
        set
        {
            if (value.Length == 6)
            {
                maTN = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string TenTN
    {
        get { return tenTN; }
        set
        {
            if (value.Length > 0)
            {
                tenTN = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoTang
    {
        get { return soTang; }
        set
        {
            if (value >= 1 && value <= 50)
            {
                soTang = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public ToaNha() { }
    public ToaNha(string maTN, string tenTN, int soTang)
    {
        MaTN = maTN;
        TenTN = tenTN;
        SoTang = soTang;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma TN: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaTN = nhap;
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
            Console.Write("Nhap ten TN: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenTN = nhap;
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
            Console.Write("Nhap so tang: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 50)
            {
                SoTang = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public abstract double TinhDoanhThu();

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma toa nha: {MaTN}");
        Console.WriteLine($"Ten toa nha: {TenTN}");
        Console.WriteLine($"So tang: {SoTang}");
    }
}

class ToaNhaVanPhong : ToaNha, IBaoCao
{
    private double giaThue;
    private int tangThue;
    private double dichVu;

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
    public int TangThue
    {
        get { return tangThue; }
        set
        {
            if (value >= 0 && value <= SoTang)
            {
                tangThue = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double DichVu
    {
        get { return dichVu; }
        set
        {
            if (value >= 0 && value <= 20)
            {
                dichVu = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public ToaNhaVanPhong() : base() { }
    public ToaNhaVanPhong(string maTN, string tenTN, int soTang, double giaThue, int tangThue, double dichVu)
    : base(maTN, tenTN, soTang)
    {
        GiaThue = giaThue;
        TangThue = tangThue;
        DichVu = dichVu;
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
            Console.Write("Nhap so tang thue: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0 && nhap <= SoTang)
            {
                TangThue = nhap;
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
            Console.Write("Nhap ti le dich vu: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 20)
            {
                DichVu = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override double TinhDoanhThu()
    {
        return TangThue * GiaThue * (1 + DichVu / 100);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Gia thue: {GiaThue:N0} vnd");
        Console.WriteLine($"So tang thue: {TangThue}");
        Console.WriteLine($"Ti le: {DichVu:F2} %");
        Console.WriteLine($"Doanh thu: {TinhDoanhThu():N0} %");
    }
    public void InBaoCao()
    {
        Console.WriteLine($"[Bao cao]");
        Console.WriteLine($"Ten toa nha: {TenTN}");
        Console.WriteLine($"So tang thue: {TangThue}");
        Console.WriteLine($"Ti le: {DichVu:F2} %");
        Console.WriteLine($"Doanh thu: {TinhDoanhThu():N0} %");
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

        List<ToaNhaVanPhong> ds = new List<ToaNhaVanPhong>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nToa {i + 1}");
            ToaNhaVanPhong vp = new ToaNhaVanPhong();
            bool maTrung;
            do
            {
                vp.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaTN == vp.MaTN)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung) Console.WriteLine("Ma trung nhap lai");
            } while (maTrung);
            ds.Add(vp);
        }

        Console.WriteLine("\nDANH SACH TOA NHA");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nToa {i + 1}");
            ds[i].InBaoCao();
        }

        ToaNhaVanPhong max = ds[0];
        foreach (var vp in ds)
        {
            if (vp.TinhDoanhThu() > max.TinhDoanhThu()) max = vp;
        }

        Console.WriteLine("\nTOA NHA CO DOANH THU CAO NHAT");
        max.Xuat();

        Console.Write("Nhap ten toa nha(3 ky tu dau): ");
        string ma = Console.ReadLine().ToLower();
        bool timThay = false;

        foreach (var vp in ds)
        {
            if (vp.TenTN.ToLower().StartsWith(ma))
            {
                vp.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("\nKhong tim thay");
        }

        ds.Sort((a, b) => b.TinhDoanhThu().CompareTo(a.TinhDoanhThu()));
        Console.WriteLine("\nDANH SACH TOA NHA SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nToa {i + 1}");
            ds[i].InBaoCao();
        }
    }
}