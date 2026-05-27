// Phần I (6đ)
// 1. Interface IKhuyenMai (0.5đ)

// double TinhGiaSauKM()
// void InThongTin()

// 2. Lớp abstract SanPham (2.5đ)
// Fields: mã SP (string 6 ký tự), tên SP (string > 0), giá nhập (double > 0), hạn sử dụng (DateTime)
// TinhGiaBan() — không abstract, tính theo số ngày còn hạn:

// Còn hơn 30 ngày: giá nhập × 1.4
// Còn 15-30 ngày: giá nhập × 1.2
// Dưới 15 ngày: giá nhập × 1.05

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhLoiNhuan()
// 3. Lớp SanPhamSieuThi kế thừa SanPham, implement IKhuyenMai (3đ)
// Fields bổ sung: số lượng tồn (int > 0), mã vùng (string: "HN"/"HCM"/"DN"), giảm giá % (double trong [0, 40])
// TinhLoiNhuan():

// Lợi nhuận = (TinhGiaBan() - Giá nhập) × Số lượng

// TinhGiaSauKM():

// Giá sau KM = TinhGiaBan() × (1 - Giảm giá / 100)

// InThongTin(): in tên SP, hạn SD, giá bán, giá sau KM, lợi nhuận

// Phần II (4đ)

// (1đ) Nhập n sản phẩm (2 ≤ n ≤ 20), mã không được trùng
// (0.5đ) Gọi InThongTin() cho từng SP
// (0.5đ) Tìm SP có lợi nhuận cao nhất
// (1đ) Nhập mã vùng, in tất cả SP thuộc vùng đó kèm tổng lợi nhuận nhóm. Thông báo nếu không có
// (1đ) Sắp xếp theo giá sau KM tăng dần. In ra sau sắp xếp

interface IKhuyenMai
{
    double TinhGiaSauKM();
    void InThongTin();
}

abstract class SanPham
{
    private string maSP;
    private string tenSP;
    private double giaNhap;
    private DateTime hSD;

    public string MaSP
    {
        get { return maSP; }
        set
        {
            if (value.Length == 6)
            {
                maSP = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string TenSP
    {
        get { return tenSP; }
        set
        {
            if (value.Length > 0)
            {
                tenSP = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double GiaNhap
    {
        get { return giaNhap; }
        set
        {
            if (value > 0)
            {
                giaNhap = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public DateTime HSD
    {
        get { return hSD; }
        set { hSD = value; }
    }

    public SanPham() { }
    public SanPham(string maSP, string tenSP, double giaNhap, DateTime hSD)
    {
        MaSP = maSP;
        TenSP = tenSP;
        GiaNhap = giaNhap;
        HSD = hSD;
    }

    public abstract double TinhLoiNhuan();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma san pham: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaSP = nhap;
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
            Console.Write("Nhap ten san pham: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenSP = nhap;
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
            Console.Write("Nhap gia nhap san pham: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaNhap = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        Console.Write("Nhap HSD(d/M/yyyy): ");
        HSD = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);
    }

    public double TinhGiaBan()
    {
        int ngayConLai = (HSD - DateTime.Now).Days;
        if (ngayConLai > 30) return GiaNhap * 1.4;
        else if (ngayConLai >= 15) return GiaNhap * 1.2;
        else return GiaNhap * 1.05;
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma sp: {MaSP}");
        Console.WriteLine($"Ten sp: {TenSP}");
        Console.WriteLine($"Gia nhap sp: {GiaNhap}");
        Console.WriteLine($"HSD: {HSD:dd/MM/yyyy}");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
    }
}

class SanPhamSieuThi : SanPham, IKhuyenMai
{
    private int soLuong;
    private string maVung;
    private double giamGia;

    public int SoLuong
    {
        get { return soLuong; }
        set
        {
            if (value > 0)
            {
                soLuong = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string MaVung
    {
        get { return maVung; }
        set
        {
            if (value == "HN" || value == "HCM" || value == "DN")
            {
                maVung = value;
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
            if (value >= 0 && value <= 40)
            {
                giamGia = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public SanPhamSieuThi() : base() { }
    public SanPhamSieuThi(string maSP, string tenSP, double giaNhap, DateTime hSD, int soLuong, string maVung, double giamGia)
    : base(maSP, tenSP, giaNhap, hSD)
    {
        SoLuong = soLuong;
        MaVung = maVung;
        GiamGia = giamGia;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap so luong ton: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap > 0)
            {
                SoLuong = nhap;
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
            Console.Write("Nhap ma vung (HN/HCM/DN): ");
            string nhap = Console.ReadLine().ToUpper();
            if (nhap == "HN" || nhap == "HCM" || nhap == "DN")
            {
                MaVung = nhap;
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
            Console.Write("Nhap giam gia: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 40)
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
    public override double TinhLoiNhuan()
    {
        return (TinhGiaBan() - GiaNhap) * SoLuong;
    }

    public double TinhGiaSauKM()
    {
        return TinhGiaBan() * (1 - GiamGia / 100);
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So luong ton: {SoLuong}");
        Console.WriteLine($"Ma Vung: {MaVung}");
        Console.WriteLine($"Giam gia: {GiamGia}");
        Console.WriteLine($"Gia sau KM: {TinhGiaSauKM():N0} vnd");
        Console.WriteLine($"Loi nhuan: {TinhLoiNhuan():N0} vnd");
    }
    public void InThongTin()
    {
        Console.WriteLine($"Ten SP: {TenSP}");
        Console.WriteLine($"HSD: {HSD:dd/MM/yyyy}");
        Console.WriteLine($"Gia ban: {TinhGiaBan():N0} vnd");
        Console.WriteLine($"Gia sau KM: {TinhGiaSauKM():N0} vnd");
        Console.WriteLine($"Loi nhuan: {TinhLoiNhuan():N0} vnd");
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

        List<SanPhamSieuThi> ds = new List<SanPhamSieuThi>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSan Pham {i + 1}");
            SanPhamSieuThi sp = new SanPhamSieuThi();
            bool maTrung;
            do
            {
                sp.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaSP == sp.MaSP)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung) Console.WriteLine("Ko de trung ma");
            } while (maTrung);
            ds.Add(sp);
        }

        Console.WriteLine("\nDANH SACH CAC SAN PHAM");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            ds[i].InThongTin();
        }

        SanPhamSieuThi max = ds[0];
        foreach (var sp in ds)
        {
            if (sp.TinhLoiNhuan() > max.TinhLoiNhuan()) max = sp;
        }
        Console.WriteLine("\nSAN PHAM CO GIA CAO NHAT");
        max.Xuat();

        bool hopLe = false;
        string ma = null;
        do
        {
            Console.Write("\nNhap ma vung: ");
            ma = Console.ReadLine().ToUpper();
            if (ma == "HN" || ma == "HCM" || ma == "DN")
            {
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
        Console.WriteLine($"\nSAN PHAM CO MA VUNG O {ma.ToUpper()}");
        bool timThay = false;
        double tong = 0;
        foreach (var sp in ds)
        {
            if (sp.MaVung.ToUpper() == ma)
            {
                sp.Xuat();
                tong += sp.TinhLoiNhuan();
                timThay = true;
            }
        }

        if (!timThay) Console.WriteLine("Khong co SP vung nay");
        else Console.WriteLine($"Tong loi nhuan: {tong:N0} vnd");

        ds.Sort((a, b) => a.TinhGiaSauKM().CompareTo(b.TinhGiaSauKM()));
        Console.WriteLine("\nDANH SACH CAC SAN PHAM SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSan pham {i + 1}");
            ds[i].InThongTin();
        }
    }
}