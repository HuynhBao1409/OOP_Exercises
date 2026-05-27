// Phần I (6đ)
// 1. Interface IBenhVien (0.5đ)

// double TinhVienPhi()
// void InPhieuKham()

// 2. Lớp abstract BenhNhan (2.5đ)
// Fields:

// Mã BN: string, đúng 6 ký tự
// Họ tên: string, độ dài > 0
// Tuổi: int, trong khoảng [1, 120]
// Ngày nhập viện: DateTime

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhVienPhi()
// 3. Lớp BenhNhanNoiTru kế thừa BenhNhan, implement IBenhVien (3đ)
// Fields bổ sung:

// Số ngày nằm viện: int, trong khoảng [1, 365]
// Phí giường mỗi ngày: double, > 0 (ví dụ: 500.000 đ/ngày)
// Loại phòng: string, chỉ nhận "A"/"B"/"C"

// Công thức tính viện phí:
// Viện phí = Số ngày × Phí giường
// Nếu phòng A: nhân thêm hệ số 2.0
// Nếu phòng B: nhân thêm hệ số 1.5
// Nếu phòng C: nhân thêm hệ số 1.0
// Ví dụ: 3 ngày, phí giường 500k, phòng A
// → 3 × 500.000 × 2.0 = 3.000.000đ
// InPhieuKham(): in họ tên, ngày nhập viện, số ngày, loại phòng, viện phí

// Phần II (4đ)

// (1đ) Nhập n bệnh nhân (2 ≤ n ≤ 20), mã không được trùng
// (0.5đ) Gọi InPhieuKham() cho từng bệnh nhân
// (0.5đ) Tìm bệnh nhân có viện phí cao nhất và thấp nhất
// (1đ) Nhập loại phòng (A/B/C), đếm số BN trong phòng đó, tính tổng viện phí và in từng BN kèm % đóng góp. Thông báo nếu không có
// (1đ) Nhập mã BN, tìm thấy thì cập nhật lại số ngày nằm viện. Thông báo nếu không tìm thấy

using System;
using System.Collections.Generic;

interface IBenhVien
{
    double TinhVienPhi();
    void InPhieuKham();
}

abstract class BenhNhan
{
    private string maBN;
    private string hoTen;
    private int tuoi;
    private DateTime ngayNhapVien;

    public string MaBN
    {
        get { return maBN; }
        set
        {
            if (value.Length == 6)
            {
                maBN = value;
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
    public int Tuoi
    {
        get { return tuoi; }
        set
        {
            if (value >= 1 && value <= 120)
            {
                tuoi = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public DateTime NgayNhapVien
    {
        get { return ngayNhapVien; }
        set
        {
            ngayNhapVien = value;
        }
    }

    public BenhNhan() { }
    public BenhNhan(string maBN, string hoTen, int tuoi, DateTime ngayNhapVien)
    {
        MaBN = maBN;
        HoTen = hoTen;
        Tuoi = tuoi;
        NgayNhapVien = ngayNhapVien;
    }

    public abstract double TinhVienPhi();

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma BN: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaBN = nhap;
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
            Console.Write("Nhap ho ten: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                HoTen = nhap;
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
            Console.Write("Nhap tuoi [1-120]: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 120)
            {
                Tuoi = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        Console.Write("Nhap ngay nhap vien: ");
        NgayNhapVien = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", null);

    }

    public virtual void InPhieuKham()
    {
        Console.WriteLine($"Ma BN: {MaBN}");
        Console.WriteLine($"Ho ten BN: {HoTen}");
        Console.WriteLine($"Tuoi: {Tuoi}");
        Console.WriteLine($"Ngay nhap vien: {NgayNhapVien:dd/MM/yyyy}");
    }
}

class BenhNhanNoiTru : BenhNhan, IBenhVien
{
    private int ngayNamVien;
    private double phiGiuong;
    private string loaiPhong;

    public int NgayNamVien
    {
        get { return ngayNamVien; }
        set
        {
            if (value >= 1 && value <= 365)
            {
                ngayNamVien = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double PhiGiuong
    {
        get { return phiGiuong; }
        set
        {
            if (value > 0)
            {
                phiGiuong = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string LoaiPhong
    {
        get { return loaiPhong; }
        set
        {
            if (value == "A" || value == "B" || value == "C")
            {
                loaiPhong = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public BenhNhanNoiTru() : base() { }
    public BenhNhanNoiTru(string maBN, string hoTen, int tuoi, DateTime ngayNhapVien, int ngayNamVien, double phiGiuong, string loaiPhong)
    : base(maBN, hoTen, tuoi, ngayNhapVien)
    {
        NgayNamVien = ngayNamVien;
        PhiGiuong = phiGiuong;
        LoaiPhong = loaiPhong;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ngay nam vien: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 365)
            {
                NgayNamVien = nhap;
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
            Console.Write("Nhap phi giuong: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                PhiGiuong = nhap;
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
            Console.Write("Nhap loai phong: ");
            string nhap = Console.ReadLine().ToUpper();
            if (nhap == "A" || nhap == "B" || nhap == "C")
            {
                LoaiPhong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);
    }

    public override double TinhVienPhi()
    {
        double vienPhi = NgayNamVien * PhiGiuong;
        if (LoaiPhong == "A") return vienPhi * 2.0;
        else if (LoaiPhong == "B") return vienPhi * 1.5;
        else return vienPhi * 1.0;
    }

    public override void InPhieuKham() //luoi viet them cai xuat cho lamf 1 lun
    {
        base.InPhieuKham();
        Console.WriteLine($"So ngay nam vien: {NgayNamVien} ngay");
        Console.WriteLine($"Phi giuong: {PhiGiuong:N0} vnd");
        Console.WriteLine($"Loai phong: {LoaiPhong}");
        Console.WriteLine($"Vien phi: {TinhVienPhi():N0} vnd");
    }
}

class Program
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Nhap n[2-20]: ");
            int.TryParse(Console.ReadLine(), out n);
            if (n < 2 || n > 20)
            {
                Console.WriteLine("Loi");
            }
        } while (n < 2 || n > 20);

        List<BenhNhanNoiTru> ds = new List<BenhNhanNoiTru>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nBenh nhan {i + 1}");
            BenhNhanNoiTru bn = new BenhNhanNoiTru();
            bool maTrung;
            do
            {
                maTrung = false;
                bn.Nhap();
                foreach (var item in ds)
                {
                    if (item.MaBN == bn.MaBN)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung) Console.WriteLine("ma trung");
            } while (maTrung);
            ds.Add(bn);
        }

        Console.WriteLine("\nDANH SACH BENH NHAN");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nBenh nhan {i + 1}");
            ds[i].InPhieuKham();
        }

        BenhNhanNoiTru min = ds[0];
        BenhNhanNoiTru max = ds[0];

        foreach (var bn in ds)
        {
            if (bn.TinhVienPhi() > max.TinhVienPhi()) max = bn;
            if (bn.TinhVienPhi() < min.TinhVienPhi()) min = bn;
        }

        Console.WriteLine("\nBENH NHAN CO TIEN PHI CAO NHAT");
        max.InPhieuKham();
        Console.WriteLine("\nBENH NHAN CO TIEN PHI THAP NHAT");
        min.InPhieuKham();

        string phong = null;
        bool hopLe = false;
        do
        {
            Console.Write("\nNhap loai phong can tim: ");
            string nhap = Console.ReadLine().ToUpper();
            if (nhap == "A" || nhap == "B" || nhap == "C")
            {
                phong = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        double tong = 0;
        foreach (var bn in ds)
        {
            if (bn.LoaiPhong == phong)
            {
                tong += bn.TinhVienPhi();
            }
        }

        int dem = 0;
        double phamTram = 0;
        foreach (var bn in ds)
        {
            if (bn.LoaiPhong == phong)
            {
                dem++;
                bn.InPhieuKham();
                phamTram = bn.TinhVienPhi() / tong * 100;
                Console.WriteLine($"Dong gop: {phamTram:F2}%");
                Console.WriteLine();
            }
        }
        if (dem == 0)
        {
            Console.WriteLine("\nKo tim thay!");
        }
        else
        {
            Console.WriteLine($"Co {dem} benh nhan trong phong {phong}| tong vien phi: {tong:N0} vnd");
        }

        hopLe = false;
        string matim = null;
        do
        {
            Console.Write("\nNhap ma BN can tim: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                matim = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        } while (!hopLe);

        bool timThay = false;
        foreach (var bn in ds)
        {
            if (bn.MaBN == matim)
            {
                hopLe = false;
                do
                {
                    Console.Write("Nhap ngay nam vien: ");
                    if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 1 && nhap <= 365)
                    {
                        bn.NgayNamVien = nhap;
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
        if (!timThay) Console.WriteLine("Khong tim thay!");

        Console.WriteLine("\nDANH SACH BENH NHAN SAU KHI CAP NHAT");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nBenh nhan {i + 1}");
            ds[i].InPhieuKham();
        }
    }
}