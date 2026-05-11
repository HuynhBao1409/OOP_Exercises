// 📝 ĐỀ LUYỆN CUỐI KỲ — LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG (C#)
// Thời gian: 75 phút | Được dùng tài liệu | Không trao đổi

// Phần I — Cài đặt các lớp (6đ)
// 1. Lớp abstract ChuyenBay (2.5đ)
// Fields: mã chuyến (string), điểm đến (string), số ghế (int)
// Properties ràng buộc:

// Mã chuyến: đúng 6 ký tự
// Điểm đến: độ dài > 0
// Số ghế: trong khoảng [10, 500]

// Phương thức: khởi tạo, Nhap(), Xuat(), abstract TinhDoanhThu()
// 2. Lớp ChuyenBayQuocTe kế thừa ChuyenBay (3.5đ)
// Fields bổ sung: giá vé (double), phụ thu nhiên liệu % (double), số ghế đã bán (int)
// Properties ràng buộc:

// Giá vé: > 0
// Phụ thu nhiên liệu: trong khoảng [0, 30]
// Số ghế đã bán: >= 0 và <= Số ghế

// TinhDoanhThu():

// Doanh thu = Số ghế đã bán × Giá vé × (1 + Phụ thu / 100)


// Phần II — Chương trình chính (4đ)

// (1đ) Nhập danh sách n chuyến bay (2 ≤ n ≤ 20), khi nhập nếu mã chuyến đã tồn tại thì báo lỗi và nhập lại mã khác
// (1đ) In toàn bộ danh sách kèm doanh thu và % đóng góp trên tổng doanh thu
// (0.5đ) Nhập khoảng doanh thu [min, max], in tất cả chuyến bay có doanh thu nằm trong khoảng đó. Thông báo nếu không có
// (0.5đ) Nhập mã chuyến, tìm thấy thì cho cập nhật lại số ghế đã bán. Thông báo nếu không tìm thấy
// (1đ) Sắp xếp theo doanh thu giảm dần, nếu bằng nhau thì theo điểm đến tăng dần. In ra sau sắp xếp

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Numerics;

abstract class ChuyenBay
{
    private string maChuyen;
    private string diemDen;
    private int soGhe;

    public string MaChuyen
    {
        get { return maChuyen; }
        set
        {
            if (value.Length == 6)
            {
                maChuyen = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public string DiemDen
    {
        get { return diemDen; }
        set
        {
            if (value.Length > 0)
            {
                diemDen = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int SoGhe
    {
        get { return soGhe; }
        set
        {
            if (value >= 10 && value <= 500)
            {
                soGhe = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public ChuyenBay() { }
    public ChuyenBay(string maChuyen, string diemDen, int soGhe)
    {
        MaChuyen = maChuyen;
        DiemDen = diemDen;
        SoGhe = soGhe;
    }

    public virtual void Nhap()
    {
        bool hopLe = false;
        do
        {
            Console.Write("Nhap ma chuyen: ");
            string nhap = Console.ReadLine();
            if (nhap.Length == 6)
            {
                MaChuyen = nhap;
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
            Console.Write("Nhap diem den: ");
            string nhap = Console.ReadLine();
            if (nhap.Length > 0)
            {
                DiemDen = nhap;
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
            Console.Write("Nhap so ghe: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 10 && nhap <= 500)
            {
                SoGhe = nhap;
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
        Console.WriteLine($"Ma chuyen: {MaChuyen}");
        Console.WriteLine($"Diem den: {DiemDen}");
        Console.WriteLine($"So Ghe: {SoGhe}");
    }
}

class ChuyenBayQuocTe : ChuyenBay
{
    private double giaVe;
    private double phuThu;
    private int daBan;

    public double GiaVe
    {
        get { return giaVe; }
        set
        {
            if (value > 0)
            {
                giaVe = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public double PhuThu
    {
        get { return phuThu; }
        set
        {
            if (value >= 0 && value <= 30)
            {
                phuThu = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }
    public int DaBan
    {
        get { return daBan; }
        set
        {
            if (value >= 0 && value <= SoGhe)
            {
                daBan = value;
            }
            else
            {
                Console.WriteLine("Loi");
            }
        }
    }

    public ChuyenBayQuocTe() : base() { }
    public ChuyenBayQuocTe(string maChuyen, string diemDen, int soGhe, double giaVe, double phuThu, int daBan)
    : base(maChuyen, diemDen, soGhe)
    {
        GiaVe = giaVe;
        PhuThu = phuThu;
        DaBan = daBan;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Nhap gia ve: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap > 0)
            {
                GiaVe = nhap;
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
            Console.Write("Nhap phu thu: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0 && nhap <= 30)
            {
                PhuThu = nhap;
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
            Console.Write("Nhap so ghe da ban: ");
            if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0 && nhap <= SoGhe)
            {
                DaBan = nhap;
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
        return DaBan * GiaVe * (1 + PhuThu / 100);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Gia ve: {GiaVe:N0} vnd");
        Console.WriteLine($"Phu thu: {PhuThu} %");
        Console.WriteLine($"Ghe da ban: {DaBan}");
        Console.WriteLine($"Doanh Thu: {TinhDoanhThu():N0} vnd");
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

        List<ChuyenBayQuocTe> ds = new List<ChuyenBayQuocTe>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nChuyen bay {i + 1}");
            ChuyenBayQuocTe cb = new ChuyenBayQuocTe();
            bool maTrung;
            do
            {
                cb.Nhap();
                maTrung = false;
                foreach (var item in ds)
                {
                    if (item.MaChuyen == cb.MaChuyen)
                    {
                        maTrung = true;
                        break;
                    }
                }
                if (maTrung)
                {
                    Console.WriteLine("Loi ma chuyen trung nhap lai!");
                }
            } while (maTrung);
            ds.Add(cb);
        }


        double tong = 0;
        foreach (var cb in ds) tong += cb.TinhDoanhThu();

        Console.WriteLine("\nDANH SACH CHUYEN BAY");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nChuyen bay {i + 1}");
            ds[i].Xuat();
            double phanTram = ds[i].TinhDoanhThu() / tong * 100;
            Console.WriteLine($"Dong gop: {phanTram:F2}%");
        }

        Console.Write("Nhap doanh thu min: ");
        double min = double.Parse(Console.ReadLine());
        Console.Write("Nhap doanh thu max: ");
        double max = double.Parse(Console.ReadLine());
        bool timThay = false;

        Console.WriteLine($"\nCHUYEN BAY CO DOANH THU TRONG KHOANG [{min} va {max}]");
        foreach (var cb in ds)
        {
            if (cb.TinhDoanhThu() >= min && cb.TinhDoanhThu() <= max)
            {
                cb.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay) Console.WriteLine("KHONG CO CHUYEN BAY");

        Console.Write("Nhap ma chuyen: ");
        string ma = Console.ReadLine();
        timThay = false;
        foreach (var cb in ds)
        {
            if (cb.MaChuyen == ma)
            {
                bool hopLe = false;
                do
                {
                    Console.Write("Nhap so ghe da ban moi: ");
                    if (int.TryParse(Console.ReadLine(), out int nhap) && nhap >= 0 && nhap <= cb.SoGhe)
                    {
                        cb.DaBan = nhap;
                        hopLe = true;
                    }
                    else
                    {
                        Console.WriteLine("Loi");
                    }
                } while (!hopLe);
                timThay = true;
                break;
            }
        }
        if (!timThay) Console.WriteLine("\nKHONG TIM THAY MA CHUYEN");

        ds.Sort((a, b) =>
        {
            int kq = b.TinhDoanhThu().CompareTo(a.TinhDoanhThu());
            if (kq != 0)
            {
                return kq;
            }
            return a.DiemDen.CompareTo(b.DiemDen);
        });

        Console.WriteLine("\nDANH SACH CHUYEN BAY SAU KHI SAP XEP");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nChuyen bay {i + 1}");
            ds[i].Xuat();
        }

        //bonus cho dui
        //xoa trung ma chuyen
        // List<ChuyenBayQuocTe> dsmoi = new List<ChuyenBayQuocTe>();
        // List<string> maDaGap = new List<string>();

        // foreach (var cb in ds)
        // {
        //     if (!maDaGap.Contains(cb.MaChuyen))
        //     {
        //         dsmoi.Add(cb);
        //         maDaGap.Add(cb.MaChuyen);
        //     }
        // }

        // Console.WriteLine("\n===== DANH SÁCH SAU KHI XÓA TRÙNG MÃ =====");
        // for (int i = 0; i < dsmoi.Count; i++)
        // {
        //     Console.WriteLine($"\nChuyen bay {i + 1}");
        //     dsmoi[i].Xuat();
        // }
    }
}