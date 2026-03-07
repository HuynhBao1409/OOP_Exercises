// Một Công ty có hai loại nhân viên: Nhân viên văn phòng và Nhân viên sản xuất. 
// Mỗi nhân viên cần quản lý các thông tin sau: Họ tên, ngày sinh, lương.
// Công ty cần tính lương cho nhân viên như sau:
// - Đối với nhân viên sản xuất: Lương = lương căn bản + số sản phẩm * 5.000
// - Đối với nhân viên văn phòng: Lương = số ngày làm việc * 100.000
// Yêu cầu:
// - Cài đặt các lớp Nhân viên, Nhân viên văn phòng, Nhân viên sản xuất; 
// trong đó các lớp Nhân viên văn phòng, Nhân viên sản xuất kế thừa lớp Nhân viên.
// - Chương trình chính:
// + Nhập danh sách n nhân viên, mỗi nhân viên thuộc 1 trong 2 loại: Nhân viên văn phòng hoặc Nhân viên sản xuất.
// + In ra danh sách nhân viên kèm thông tin chi tiết.
// + Sắp xếp danh sách nhân viên theo thứ tự giảm dần của lương và in ra màn hình.

using System;
using System.Collections.Generic;

class NhanVien
{
    protected string hoTen;
    protected DateTime ngaySinh;
    protected double luong;

    public NhanVien()
    {

    }

    public NhanVien(string hoTen, DateTime ngaySinh)
    {
        this.hoTen = hoTen;
        this.ngaySinh = ngaySinh;
        this.luong = 0;
    }

    public string GetHoTen() { return hoTen; }
    public DateTime GetNgaySinh() { return ngaySinh; }
    public double GetLuong() { return luong; }

    //Nhập thông tin cơ bản
    public virtual void Nhap()
    {
        Console.WriteLine("  Họ tên: ");
        hoTen = Console.ReadLine();
        Console.WriteLine("  Ngày sinh (dd/MM/yyyy): ");
        ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
    }
    //Tính lương(override ở lớp con)
    public virtual void TinhLuong()
    {

    }

    public virtual void Xuat()
    {
        Console.WriteLine($"  Họ tên  : {hoTen}");
        Console.WriteLine($"  Ngày sinh  : {ngaySinh}");
        Console.WriteLine($"  Lương  : {luong:N0} vnd");
    }
}
//Lớp con: Nhân viên văn phòng
class NhanVienVanPhong : NhanVien
{
    private int soNgayLamViec;
    public NhanVienVanPhong()
    {
        soNgayLamViec = 0;
    }

    public NhanVienVanPhong(string hoTen, DateTime ngaySinh, int soNgayLamViec)
    : base(hoTen, ngaySinh)
    {
        this.soNgayLamViec = soNgayLamViec;
        TinhLuong();
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write(" Số ngày làm việc: ");
        soNgayLamViec = int.Parse(Console.ReadLine());
        TinhLuong();
    }

    //Tính lương= số ngày làm việc * 100000
    public override void TinhLuong()
    {
        luong = soNgayLamViec * 100000;
    }

    public override void Xuat()
    {
        Console.WriteLine("  [Nhân viên văn phòng]");
        base.Xuat();
        Console.WriteLine($"  Số ngày làm việc: {soNgayLamViec}");
    }
}

class NhanVienSanXuat : NhanVien
{
    private double luongCanBan;
    private int soSanPham;

    public NhanVienSanXuat()
    {

    }

    public NhanVienSanXuat(string hoTen, DateTime ngaysinh, double luongCanBan, int soSanPham)
    : base(hoTen, ngaysinh)
    {
        this.luongCanBan = luongCanBan;
        this.soSanPham = soSanPham;
        TinhLuong();
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("  Lương cơ bản: ");
        luongCanBan = double.Parse(Console.ReadLine());
        Console.WriteLine("  Số sản phẩm: ");
        soSanPham = int.Parse(Console.ReadLine());
        TinhLuong();
    }

    //Lương = lương cơ bản + số sản phẩm *5000
    public override void TinhLuong()
    {
        luong = luongCanBan + soSanPham * 5000;
    }

    public override void Xuat()
    {
        Console.WriteLine("  [Nhân viên sản xuất]");
        base.Xuat();
        Console.WriteLine($"  Lương căn bản: {luongCanBan:N0} vnd");
        Console.WriteLine($"  Số sản phẩm: {soSanPham}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<NhanVien> danhsach = new List<NhanVien>();

        Console.Write("Nhập số lượng nhân viên: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhân viên thứ {i + 1} ---");
            Console.WriteLine("Loại nhân viên: 1 - Văn phòng | 2- Sản xuất");
            Console.Write("Chọn loại: ");
            int loai = int.Parse(Console.ReadLine());

            NhanVien nv;
            if (loai == 1)
            {
                nv = new NhanVienVanPhong();
            }
            else
            {
                nv = new NhanVienSanXuat();
            }
            nv.Nhap();
            danhsach.Add(nv);
        }

        //In danh sach nhan vien
        Console.WriteLine("\n========== Danh sách nhân viên ==========");
        for (int i = 0; i < danhsach.Count; i++)
        {
            Console.WriteLine($"\nNhân viên #{i + 1}: ");
            danhsach[i].Xuat();
        }

        //Sap xep giam dan theo luong
        for (int i = 0; i < danhsach.Count - 1; i++)
        {
            for (int j = 0; j < danhsach.Count - i - 1; j++)
            {
                if (danhsach[j].GetLuong() < danhsach[j + 1].GetLuong())
                {
                    NhanVien temp = danhsach[j];
                    danhsach[j] = danhsach[j + 1];
                    danhsach[j + 1] = temp;
                }
            }
        }


        //In danh sach sau khi sap xep
        Console.WriteLine("\n==== Danh sách sau khi sắp xếp (lương giảm dần) ====");
        for (int i = 0; i < danhsach.Count; i++)
        {
            Console.WriteLine($"\nNhân viên #{i + 1}: ");
            danhsach[i].Xuat();
        }

        Console.WriteLine("\nNhấn Enter để thoát...");
        Console.ReadLine();
    }
}