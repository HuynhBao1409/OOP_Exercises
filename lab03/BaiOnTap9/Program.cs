// 📝 ĐỀ THI GIỮA KỲ — LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG (C#)
// Thời gian: 75 phút | Được dùng tài liệu | Không trao đổi

// Phần I — Cài đặt các lớp đối tượng (6 điểm)

// 1. Lớp trừu tượng SinhVien (3đ)
// Fields: mã SV (string), họ tên (string). (0.5đ)
// Properties ràng buộc khi set: (1đ)
//   - Mã SV: đúng 8 ký tự
//   - Họ tên: độ dài > 0
// Phương thức: (1.5đ)
//   - Khởi tạo không tham số và có tham số
//   - Nhap(), Xuat()
//   - Trừu tượng: TinhDiemTB()

// 2. Lớp SinhVienIT kế thừa SinhVien (1.5đ)
// Fields bổ sung: điểm Java (double), điểm C# (double). (0.5đ)
// Properties ràng buộc: điểm trong khoảng [0, 10]. (0.5đ)
// Override Nhap(), Xuat(), TinhDiemTB(). (0.5đ)
//   TinhDiemTB = (DiemJava + DiemCSharp) / 2

// 3. Lớp SinhVienKinhTe kế thừa SinhVien (1.5đ)
// Fields bổ sung: điểm Marketing (double), điểm Kế Toán (double). (0.5đ)
// Properties ràng buộc: điểm trong khoảng [0, 10]. (0.5đ)
// Override Nhap(), Xuat(), TinhDiemTB(). (0.5đ)
//   TinhDiemTB = (2 × DiemMarketing + DiemKeToan) / 3

// Phần II — Chương trình chính (4 điểm)
// (1đ)   Nhập danh sách n sinh viên (2 ≤ n ≤ 20),
//         mỗi sinh viên chọn loại IT hoặc Kinh Tế rồi nhập thông tin.
// (1đ)   In toàn bộ danh sách kèm điểm TB từng sinh viên.
// (0.5đ) Tìm và in sinh viên có điểm TB cao nhất.
// (0.5đ) Nhập họ tên, tìm và in sinh viên có họ tên đó
//         (không phân biệt hoa thường). Thông báo nếu không tìm thấy.
// (1đ)   Sắp xếp theo điểm TB giảm dần,
//         nếu bằng nhau thì theo họ tên tăng dần (A-Z). In ra sau sắp xếp.
using System;
using System.Collections.Generic;

abstract class SinhVien
{
    private string maSV;
    private string hoTen;

    public string MaSV
    {
        get { return maSV; }
        set
        {
            if (value.Length == 8)
            {
                maSV = value;
            }
            else
            {
                Console.WriteLine("Ma sv phai dung 8 ky tu");
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
                Console.WriteLine("Ho ten sv khong dc bo trong");
            }
        }
    }

    public SinhVien() { }
    public SinhVien(string maSV, string hoTen)
    {
        MaSV = maSV;
        HoTen = hoTen;
    }

    public abstract double TinhDiemTB();

    public virtual void Nhap()
    {

        do
        {
            Console.Write("Nhap ma SV: ");
            MaSV = Console.ReadLine();
        } while (maSV == null);
        do
        {
            Console.Write("Nhap ho ten SV: ");
            HoTen = Console.ReadLine();
        } while (hoTen == null);
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma SV: {MaSV}");
        Console.WriteLine($"Ho ten SV: {HoTen}");
        Console.WriteLine($"Diem TB: {TinhDiemTB():N2}");
    }

}

class SinhVienIT : SinhVien
{
    private double diemJava;
    private double diemCSharp;

    public double DiemJava
    {
        get { return diemJava; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemJava = value;
            }
            else
            {
                Console.WriteLine("Diem Java ko dc de trong");
            }
        }
    }
    public double DiemCSharp
    {
        get { return diemCSharp; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemCSharp = value;
            }
            else
            {
                Console.WriteLine("Diem C# ko dc de trong");
            }
        }
    }

    public SinhVienIT() : base() { }
    public SinhVienIT(string maSV, string hoTen, double diemJava, double diemCSharp)
    : base(maSV, hoTen)
    {
        DiemJava = diemJava;
        DiemCSharp = diemCSharp;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Diem Java: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                DiemJava = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Diem C Sharp: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                DiemCSharp = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
    }

    public override double TinhDiemTB()
    {
        return (DiemJava + DiemCSharp) / 2;
    }

    public override void Xuat()
    {
        Console.WriteLine("[Sinh vien IT]");
        base.Xuat();
        Console.WriteLine($"Diem Java: {DiemJava}");
        Console.WriteLine($"Diem C Sharp: {DiemCSharp}");

    }

}
class SinhVienKinhTe : SinhVien
{
    private double diemMkt;
    private double diemKeToan;

    public double DiemMkt
    {
        get { return diemMkt; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemMkt = value;
            }
            else
            {
                Console.WriteLine("Diem Mkt ko dc de trong");
            }
        }
    }
    public double DiemKeToan
    {
        get { return diemKeToan; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                diemKeToan = value;
            }
            else
            {
                Console.WriteLine("Diem ke toan ko dc de trong");
            }
        }
    }

    public SinhVienKinhTe() : base() { }
    public SinhVienKinhTe(string maSV, string hoTen, double diemMkt, double diemKeToan)
    : base(maSV, hoTen)
    {
        DiemMkt = diemMkt;
        DiemKeToan = diemKeToan;
    }

    public override void Nhap()
    {
        base.Nhap();
        bool hopLe = false;
        do
        {
            Console.Write("Diem Marketing: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                DiemMkt = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
        hopLe = false;
        do
        {
            Console.Write("Diem Ke toan: ");
            if (double.TryParse(Console.ReadLine(), out double nhap) && nhap >= 0.0 && nhap <= 10.0)
            {
                DiemKeToan = nhap;
                hopLe = true;
            }
            else
            {
                Console.WriteLine("Diem ko dc de trong");
            }
        } while (!hopLe);
    }

    public override double TinhDiemTB()
    {
        return (2 * DiemMkt + DiemKeToan) / 3;
    }

    public override void Xuat()
    {
        Console.WriteLine("[Sinh vien kinh te]");
        base.Xuat();
        Console.WriteLine($"Diem Mkt: {DiemMkt}");
        Console.WriteLine($"Diem ke toan: {DiemKeToan}");

    }

}

class Program
{
    static void Main()
    {
        List<SinhVien> ds = new List<SinhVien>();

        Console.Write("Nhap so luong sinh vien: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nSinhvien {i + 1}");
            Console.WriteLine("Chon: 1|sinh vien IT  2|sinh vien Kte");
            SinhVien sv = null;
            do
            {
                Console.Write("Chon 1/2: ");
                int loai = int.Parse(Console.ReadLine());

                if (loai == 1)
                {
                    sv = new SinhVienIT();
                }
                else if (loai == 2)
                {
                    sv = new SinhVienKinhTe();
                }
                else
                {
                    Console.WriteLine("Chi chon 1 hoac 2");
                }
            } while (sv == null);
            sv.Nhap();
            ds.Add(sv);
        }

        Console.WriteLine("\nDanh sach sinh vien");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSinhvien {i + 1}");
            ds[i].Xuat();
        }

        SinhVien max = ds[0];
        foreach (var sv in ds)
        {
            if (sv.TinhDiemTB() > max.TinhDiemTB()) max = sv;
        }

        Console.WriteLine("\nSinh vien co diem TB cao nhat");
        max.Xuat();
        //tim ten sv
        Console.Write("\nNhap ho ten: ");
        string hotenTK = Console.ReadLine();
        bool timThay = false;

        Console.WriteLine($"\nTHONG TIN SINH VIEN CO TEN {hotenTK.ToUpper()}");
        foreach (var sv in ds)
        {
            if (sv.HoTen.ToLower() == hotenTK.ToLower())
            {
                sv.Xuat();
                Console.WriteLine();
                timThay = true;
            }
        }
        if (!timThay)
        {
            Console.WriteLine($"\nKo tim thay ai ten {hotenTK.ToUpper()}");
        }

        ds.Sort((a, b) =>
        {
            int kq = b.TinhDiemTB().CompareTo(a.TinhDiemTB());//giam dan
            if (kq != 0)//neu ko bang nhau
            {
                return kq;
            }
            return a.HoTen.CompareTo(b.HoTen);//tang dan
        });
        Console.WriteLine("\nDANH SACH SAU KHI SAP XEP QUA 2 TIEU CHI");
        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"\nSinhvien {i + 1}");
            ds[i].Xuat();
        }

        Console.WriteLine("Nhap phim bat ky de thoat");
        Console.ReadKey();
    }
}