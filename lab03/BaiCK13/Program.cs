// Phần I (6đ)
// 1. Interface IVanChuyen (0.5đ)

// double TinhPhiVC()
// void InHoaDon()

// 2. Lớp abstract DonHang (2.5đ)
// Fields: mã ĐH (string 6 ký tự), tên khách (string > 0), khối lượng kg (double > 0), ngày đặt (DateTime)
// TinhGiaCoSo() — không abstract:

// Đặt trong vòng 7 ngày gần nhất: khối lượng × 25.000
// Đặt trong vòng 30 ngày: khối lượng × 20.000
// Lâu hơn: khối lượng × 15.000

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhPhiVC()
// 3. Lớp DonHangNhanh kế thừa DonHang, implement IVanChuyen (3đ)
// Fields bổ sung: mã tuyến (string: "NB"/"NS"/"BB"), phụ phí xa (double >= 0), có giao tận nơi không (bool)
// TinhPhiVC():

// Phí = TinhGiaCoSo() + Phụ phí xa
// Nếu giao tận nơi: cộng thêm 30.000

// InHoaDon(): in tên khách, ngày đặt, khối lượng, phí VC, mã tuyến

// Phần II (4đ)

// (1đ) Nhập n đơn hàng (2 ≤ n ≤ 20), mã không được trùng
// (0.5đ) Gọi InHoaDon() cho từng đơn
// (0.5đ) Tìm đơn có phí VC cao nhất và thấp nhất
// (1đ) Nhập mã tuyến, đếm số đơn và tính tổng phí tuyến đó. In từng đơn kèm % đóng góp trên tổng. Thông báo nếu không có
// (1đ) Nhập mã đơn, tìm thấy thì cập nhật lại khối lượng. Thông báo nếu không tìm thấy

using System.Reflection.Metadata;

interface IVanChuyen
{
    double TinhPhiVC();
    void InHoaDon();
}

abstract class DonHang
{
    private string maDH;
    private string tenKH;
    private double khoiLuong;
    private DateTime ngayDat;

    public string MaDH
    {
        get { return maDH; }
        set
        {
            if (value.Length == 6)
            {
                maDH = value;
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
    public double KhoiLuong
    {
        get { return khoiLuong; }
        set
        {
            if (value > 0)
            {
                khoiLuong = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public DateTime NgayDat
    {
        get { return ngayDat; }
        set
        {
            ngayDat = value;
        }
    }

    public DonHang() { }
    public DonHang(string maDH, string tenKH, double khoiLuong, DateTime ngayDat)
    {
        MaDH = maDH;
        TenKH = tenKH;
        KhoiLuong = khoiLuong;
        NgayDat = ngayDat;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma DH: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaDH = nhap;
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
            Console.Write("Nhap ten khach: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                TenKH = nhap;
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
            Console.Write("Nhap khoi luong (kg): ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                KhoiLuong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        Console.Write("Nhap ngay dat (dd/mm/yyyy): ");
        NgayDat = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);
    }

    public double TinhGiaCoSo()
    {
        int ngayConLai = (DateTime.Now - NgayDat).Days;
        if (ngayConLai <= 7) return KhoiLuong * 25000;
        else if (ngayConLai <= 30) return KhoiLuong * 20000;
        else return KhoiLuong * 15000;
    }

    public abstract double TinhPhiVC();

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma DH: {MaDH}");
        Console.WriteLine($"Ten khach dat DH: {TenKH}");
        Console.WriteLine($"Khoi luong: {KhoiLuong}");
        Console.WriteLine($"Ngay dat: {NgayDat:dd/MM/yyyy}");
        Console.WriteLine($"Gia co so: {TinhGiaCoSo():N0} vnd");
    }
}

class DonHangNhanh : DonHang, IVanChuyen
{
    private string maTuyen;
    private double phuPhi;
    private bool giaoTanNoi;

    public string MaTuyen
    {
        get { return maTuyen; }
        set
        {
            if (value == "NB" || value == "NS" || value == "BB")
            {
                maTuyen = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
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
                Console.WriteLine("Loi");
            }
        }
    }

    public bool GiaoTanNoi
    {
        get { return giaoTanNoi; }
        set { giaoTanNoi = value; }
    }

    public DonHangNhanh() : base() { }
    public DonHangNhanh(string maDH, string tenKH, double khoiLuong, DateTime ngayDat, string maTuyen, double phuPhi, bool giaoTanNoi)
    : base(maDH, tenKH, khoiLuong, ngayDat)
    {
        MaTuyen = maTuyen;
        PhuPhi = phuPhi;
        GiaoTanNoi = giaoTanNoi;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma tuyen: ");
            MaTuyen = Console.ReadLine().ToUpper();
            if (MaTuyen == "NB" || MaTuyen == "NS" || MaTuyen == "BB")
            {

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
            Console.Write("Nhap phu phi: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0)
            {
                PhuPhi = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        Console.Write("Co giao hang tan noi? [1:Co || 2:Khong]: ");
        GiaoTanNoi = Console.ReadLine() == "1";
    }

    public override double TinhPhiVC()
    {
        double phi = TinhGiaCoSo() + PhuPhi;
        if (GiaoTanNoi)
        {
            return phi + 30000;
        }
        else
        {
            return phi;
        }
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Ma Tuyen: {MaTuyen}");
        Console.WriteLine($"Phu phi: {PhuPhi:N0} vnd");
        Console.WriteLine($"Co giao?: {(GiaoTanNoi ? "Co" : "Khong")}");
        Console.WriteLine($"Phi VC: {TinhPhiVC():N0} vnd");
    }

    public void InHoaDon()
    {
        Console.WriteLine($"Ten khach dat DH: {TenKH}");
        Console.WriteLine($"Khoi luong: {KhoiLuong}");
        Console.WriteLine($"Ngay dat: {NgayDat:dd/MM/yyyy}");
        Console.WriteLine($"Ma Tuyen: {MaTuyen}");
        Console.WriteLine($"Phi VC: {TinhPhiVC():N0} vnd");
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
            if (n < 2 || n > 20) Console.WriteLine("Loi");
        } while (n < 2 || n > 20);

        List<DonHangNhanh> ds = new List<DonHangNhanh>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nDon hang {i + 1}");
            DonHangNhanh dh = new DonHangNhanh();
            bool maTrung;
            do
            {
                dh.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaDH == dh.MaDH)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung) Console.WriteLine("Ma trung nhap lai!");
            } while (maTrung);
            ds.Add(dh);
        }

        Console.WriteLine("\nHOA DON CAC DON HANG");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nDon hang {i + 1}");
            ds[i].InHoaDon();
        }

        DonHangNhanh max = ds[0];
        DonHangNhanh min = ds[0];

        foreach (var dh in ds)
        {
            if (dh.TinhPhiVC() > max.TinhPhiVC()) max = dh;
            if (dh.TinhPhiVC() < min.TinhPhiVC()) min = dh;
        }
        Console.WriteLine("\nDON HANG PHI CAO NHAT");
        max.InHoaDon();
        Console.WriteLine("\nDON HANG PHI THAP NHAT");
        min.InHoaDon();

        bool hopLe = false;
        string ma = null;
        do
        {
            Console.Write("\nNhap ma tuyen (NB/NS/BB): ");
            ma = Console.ReadLine().ToUpper();
            if (ma == "NB" || ma == "NS" || ma == "BB")
            {
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        double tong = 0;
        double phamTram = 0;
        int dem = 0;

        foreach (var dh in ds)
        {
            if (dh.MaTuyen == ma) tong += dh.TinhPhiVC();
        }

        foreach (var dh in ds)
        {
            if (dh.MaTuyen == ma)
            {
                dem++;
                dh.InHoaDon();
                phamTram = dh.TinhPhiVC() / tong * 100;
                Console.WriteLine($"Dong gop: {phamTram:F2}%");
                Console.WriteLine();
            }
        }
        if (dem == 0) Console.WriteLine("\nKhong co");
        else
        {
            Console.WriteLine($"\nSO DON CUA MA TUYEN {ma}");
            Console.WriteLine($"So don: {dem} | Tong phi: {tong:N0} vnd");
        }

        hopLe = false;
        string maD = null;
        do
        {
            Console.Write("\nNhap ma don hang: ");
            maD = Console.ReadLine();
            if (maD.Length == 6)
            {
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        bool timThay = false;

        foreach (var dh in ds)
        {
            if (dh.MaDH == maD)
            {
                hopLe = false;
                do
                {
                    Console.Write("Nhap khoi luong moi: ");
                    if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
                    {
                        dh.KhoiLuong = nhap;
                        hopLe = true;
                    }
                    else
                    {
                        Console.WriteLine("Loi");
                    }
                } while (!hopLe);
                Console.WriteLine("Cap nhat thanh cong!");
                timThay = true;
                break;
            }
        }
        if (!timThay) Console.WriteLine("Khong tim thay ma don hang!");

        Console.WriteLine("\nHOA DON CAC DON HANG MOI");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nDon hang {i + 1}");
            ds[i].InHoaDon();
        }
    }
}