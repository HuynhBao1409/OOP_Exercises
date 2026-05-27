//Phần I (6đ)Phần I (6đ)
// 1. Lớp Xe (2.5đ)
// Fields: dòng xe (Sedan, Hatchback, SUV,..) (string > 0), số chỗ ngồi (int > 0), ngày sản xuất (định dạng d/M/yyyy), giá sàn dùng chung cho tất cả các đối tượng lớp xe là 400
// Phương thức: khởi tạo, Nhap(), Xuat() thông tin xe, TinhGiaBan() theo công thức:
// Nếu năm sản xuất cách năm hiện tại > 2 năm: giá sàn × 1.15
// 2 ≥ Nếu năm sản xuất cách năm hiện tại > 1 năm: giá sàn × 1.3
// Các trường hợp còn lại: giá sàn × 1.5

// 2. Giao diện IPhi (0.5đ)
// Thuộc tính: phí trước bạ (số thực chỉ %, ví dụ 30% = 0.3, trong [0, 1])
// Phương thức: tính tiền phí trước bạ

// 3. Lớp XeVINFAST kế thừa lớp Xe, thực thi giao diện IPhi (3đ)
// Fields bổ sung: nơi đăng ký (Nha Trang, Ha Noi,..) (string > 0)
// Phương thức: Nhap(), Xuat() thông tin xe VINFAST, tính giá lăn bánh, biết: giá lăn bánh = giá bán xe + tiền phí trước bạ + phí đăng ký. 
//Biết:
// Tiền phí trước bạ: phí trước bạ × giá bán xe
// Phí đăng ký được tính như sau:
// Nếu nơi đăng ký là "Ha Noi": phí đăng ký là 12% giá bán xe
// Ở các tỉnh/thành khác: phí đăng ký là 10% giá bán xe

// Phần II (4đ)
// (1đ) Nhập n xe VINFAST (2 ≤ n ≤ 20)
// (0.5đ) Xuất thông tin toàn bộ danh sách
// (0.5đ) Tìm và xuất xe có giá lăn bánh cao nhất
// (1đ) Nhập dòng xe cần xóa, xóa tất cả xe có dòng xe đó khỏi danh sách và xuất danh sách còn lại. Thông báo nếu không tìm thấy
// (0.5đ) Xuất các xe đăng ký tại "Ha Noi". Thông báo nếu không có
// (0.5đ) Sắp xếp tăng dần theo giá lăn bánh và xuất danh sách

using System;
using System.Collections.Generic;

interface IPhi
{
    double PhiTruocBa { get; set; }
    double TinhPhiTruocBa();
}
class Xe
{
    private string dongXe;
    private int soChoNgoi;
    private DateTime ngaySX;
    public static double giaSan = 400;

    public string DongXe
    {
        get { return dongXe; }
        set
        {
            if (value.Length > 0)
            {
                dongXe = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoChoNgoi
    {
        get { return soChoNgoi; }
        set
        {
            if (value > 0)
            {
                soChoNgoi = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public DateTime NgaySX
    {
        get { return ngaySX; }
        set { ngaySX = value; }
    }

    public Xe() { }
    public Xe(string dongXe, int soChoNgoi, DateTime ngaySX)
    {
        DongXe = dongXe;
        SoChoNgoi = soChoNgoi;
        NgaySX = ngaySX;
    }

    public double TinhGiaBan()
    {
        int namCach = DateTime.Now.Year - NgaySX.Year;
        if (namCach > 2) return giaSan * 1.15;
        else if (namCach > 1) return giaSan * 1.3;
        else return giaSan * 1.5;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap dong xe: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                DongXe = nhap;
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
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoChoNgoi = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
        Console.Write("Nhap ngay san xuat(dd/mm/yyyy): ");
        NgaySX = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Dong xe: {DongXe}");
        Console.WriteLine($"So cho ngoi: {SoChoNgoi}");
        Console.WriteLine($"Ngay SX: {NgaySX:dd/MM/yyyy}");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
    }
}

class XeVINFAST : Xe, IPhi
{
    private string noiDKy;
    private double phiTruocBa;

    public string NoiDKy
    {
        get { return noiDKy; }
        set
        {
            if (value.Length > 0)
            {
                noiDKy = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double PhiTruocBa
    {
        get { return phiTruocBa; }
        set
        {
            if (value >= 0 && value <= 1)
            {
                phiTruocBa = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public XeVINFAST() : base() { }
    public XeVINFAST(string dongXe, int soChoNgoi, DateTime ngaySX, string noiDKy, double phiTruocBa)
    : base(dongXe, soChoNgoi, ngaySX)
    {
        NoiDKy = noiDKy;
        PhiTruocBa = phiTruocBa;
    }
    public double TinhPhiTruocBa()
    {
        return PhiTruocBa * TinhGiaBan();
    }
    public double TinhPhiDangKy()
    {
        if (NoiDKy == "Ha Noi") return 0.12 * TinhGiaBan();
        return 0.10 * TinhGiaBan();
    }

    public double GiaLanBanh()
    {
        return TinhGiaBan() + TinhPhiTruocBa() + TinhPhiDangKy();
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap noi dang ky: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                NoiDKy = nhap;
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
            Console.Write("Nhap phi trc ba(0-1 || vd:0.3%): ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 1)
            {
                PhiTruocBa = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Noi dang ky: {NoiDKy}");
        Console.WriteLine($"Phi truoc ba: {PhiTruocBa * 100}%");
        Console.WriteLine($"Tien PTB: {TinhPhiTruocBa():N0} vnd");
        Console.WriteLine($"Phi dang ky: {TinhPhiDangKy():N0} vnd");
        Console.WriteLine($"Gia lan banh: {GiaLanBanh():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap n(2-20): ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<XeVINFAST> ds = new List<XeVINFAST>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nXe VINFAST thu {i + 1}");
            XeVINFAST xe = new XeVINFAST();
            xe.Nhap();
            ds.Add(xe);
        }

        Console.WriteLine("\nDANH SACH XE VINFAST");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nXe {i + 1}");
            ds[i].Xuat();
        }

        XeVINFAST max = ds[0];
        foreach (var xe in ds)
        {
            if (xe.GiaLanBanh() > max.GiaLanBanh()) max = xe;
        }
        Console.WriteLine("\nXE GIA LAN BANH CAO NHAT");
        max.Xuat();

        bool hopLe2 = false;
        string dong = null;
        do
        {
            Console.Write("\nNhap dong xe can xoa: ");
            dong = Console.ReadLine();
            if (dong.Length > 0) hopLe2 = true;
            else Console.WriteLine("Loi");
        } while (!hopLe2);

        int soXoa = ds.RemoveAll(xe => xe.DongXe.ToLower() == dong.ToLower());
        if (soXoa == 0)
        {
            Console.WriteLine("Ko tim thay");
        }
        else
        {
            Console.WriteLine($"\n DA XOA {soXoa} xe.DANH SACH SAU KHI XOA {dong.ToUpper()}");
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine($"\nXe {i + 1}");
                ds[i].Xuat();
            }
        }

        Console.WriteLine("\nXE DANG KY TAI HA NOI");
        bool timThay = false;

        foreach (var xe in ds)
        {
            if (xe.NoiDKy == "Ha Noi")
            {
                xe.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine("Ko tim thay xe");
        }

        Console.WriteLine("\nDANH SACH SAU KHI SAP XEP TANG DAN THEO GIA LAN BANH");
        ds.Sort((a, b) => a.GiaLanBanh().CompareTo(b.GiaLanBanh()));
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nXe {i + 1}");
            ds[i].Xuat();
        }
    }
}