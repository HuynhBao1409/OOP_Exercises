// Xây dựng lớp Xe gồm các thuộc tính: Biển số (vd: 79A-12345), năm sản xuất (vd: 2019), giá (đơn vị tính: triệu đồng).
// Xây dựng lớp XeCon kế thừa lớp Xe và có thêm thuộc tính: số chỗ ngồi, loại xe (sedal/SUV/bán tải).
// Yêu cầu:
// a) Cài đặt các lớp với các phương thức sau:
// - Phương thức thiết lập có tham số và không có tham số.
// - Phương thức Nhap() để nhập thông tin xe.
// - Phương thức Xuat() để in thông tin xe.
// b) Nhập danh sách n xe con (0 - In ra danh sách xe và thông số kèm theo.
// - Tìm xe có giá thấp nhất, cao nhất.
// - Nhập 2 chữ số đầu biển số (ví dụ 79), in ra tất cả xe thuộc tỉnh có biển số đó.
// - Sắp xếp danh sách xe theo thứ tự tăng dần của năm sản xuất, in ra danh sách sau sắp xếp.

using System;
using System.Collections.Generic;

class Xe
{
    protected string bienSo;// Biển số xe (vd: 79A-12345)
    protected int namSanXuat;      // Năm sản xuất
    protected double gia;          // Giá xe (đơn vị: triệu đồng)

    //thiết lập không có tham số.
    public Xe()
    {
        bienSo = "";
        namSanXuat = 0;
        gia = 0;
    }
    //thiết lập có tham số 
    public Xe(string bienSo, int namSanXuat, double gia)
    {
        this.bienSo = bienSo;
        this.namSanXuat = namSanXuat;
        this.gia = gia;
    }

    // Phương thức lấy biển số (dùng để tìm kiếm theo tỉnh)
    public string GetBienSo() { return bienSo; }
    // Phương thức lấy năm sản xuất (dùng để sắp xếp)
    public int GetNamSanXuat() { return namSanXuat; }
    // Phương thức lấy giá (dùng để so sánh tìm min/max)
    public double GetGia() { return gia; }

    public virtual void Nhap()
    {
        Console.Write(" Nhập biển số xe (vd: 79A-12345): ");
        bienSo = Console.ReadLine();

        Console.Write(" Nhập năm sản xuất: ");
        namSanXuat = int.Parse(Console.ReadLine());

        Console.Write(" Nhập giá tiền: ");
        gia = double.Parse(Console.ReadLine());
    }

    public virtual void Xuat()
    {
        Console.WriteLine($" Biển số: {bienSo}");
        Console.WriteLine($" Năm sản xuất: {namSanXuat}");
        Console.WriteLine($" Giá tiền: {gia}");
    }
}

class XeCon : Xe
{
    private int soCho;
    private string loaiXe;

    // Phương thức thiết lập KHÔNG có tham số
    public XeCon() : base()
    {
        soCho = 0;
        loaiXe = "";
    }
    // Phương thức thiết lập có tham số
    public XeCon(string bienSo, int namSanXuat, double gia, int soCho, string loaiXe)
    : base(bienSo, namSanXuat, gia)
    {
        this.soCho = soCho;
        this.loaiXe = loaiXe;
    }

    // Override phương thức Nhap() để nhập thêm thông tin của XeCon
    public override void Nhap()
    {
        base.Nhap(); // Gọi Nhap() của lớp cha để nhập biển số, năm SX, giá
        Console.Write(" Nhập số chỗ: ");
        soCho = int.Parse(Console.ReadLine());

        Console.Write("  Nhập loại xe (sedan/SUV/bán tải): ");
        loaiXe = Console.ReadLine();
    }

    // Override phương thức Xuat() để in thêm thông tin của XeCon
    public override void Xuat()
    {
        base.Xuat();// Gọi Xuat() của lớp cha để in biển số, năm SX, giá
        Console.WriteLine($" Số chỗ ngồi : {soCho}");
        Console.WriteLine($" Loại xe     : {loaiXe}");

    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<XeCon> danhSach = new List<XeCon>();

        //Nhap danh sach
        Console.WriteLine("Nhập số lượng xe con (n > 0): ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhập thông tin xe thứ {i + 1} ---");
            XeCon xe = new XeCon();
            xe.Nhap();
            danhSach.Add(xe);
        }

        //a.In danh sach xe
        Console.WriteLine("\n========== DANH SÁCH XE CON ==========");
        for (int i = 0; i < danhSach.Count; i++)
        {
            Console.WriteLine($"\n[Xe {i + 1}]");
            danhSach[i].Xuat();
        }

        //Tìm xe có giá thấp nhất
        XeCon xeMinGia = danhSach[0];
        XeCon xeMaxGia = danhSach[0];

        foreach (XeCon xe in danhSach)
        {
            if (xe.GetGia() < xeMinGia.GetGia())
            {
                xeMinGia = xe;
            }
            if (xe.GetGia() > xeMaxGia.GetGia())
            {
                xeMaxGia = xe;
            }
        }
        Console.WriteLine("\n========== XE GIÁ THẤP NHẤT ==========");
        xeMinGia.Xuat();

        Console.WriteLine("\n========== XE GIÁ CAO NHẤT ==========");
        xeMaxGia.Xuat();

        //c. Tìm xe có 2 chữ số đầu biển số
        Console.Write("\nNhập 2 chữ số đầu biển số cần tìm (vd: 79): ");
        string maTinh = Console.ReadLine();

        Console.WriteLine($"\n========== XE CÓ BIỂN SỐ TỈNH {maTinh} ==========");
        bool TimThay = false;
        foreach (XeCon xe in danhSach)
        {
            // Kiểm tra biển số bắt đầu bằng mã tỉnh
            if (xe.GetBienSo().StartsWith(maTinh))
            {
                xe.Xuat();
                Console.WriteLine();
                TimThay = true;
            }
        }
        if (!TimThay)
        {
            Console.WriteLine($"Không tìm thấy xe nào có biển số tỉnh {maTinh}.");
        }

        //d.Sắp xếp theo năm sản xuât tăng dần
        //hoặc dùng static void SapXep(){
        //a.OrdeBy(p=>p); == sắp xếp tăng dần
        //a.OroderByDescending(p=>p)  === sắp xếp giảm dần
        //}

        for (int i = 0; i < danhSach.Count - 1; i++)
        {
            for (int j = 0; j < danhSach.Count - i - 1; j++)
            {
                if (danhSach[j].GetNamSanXuat() > danhSach[j + 1].GetNamSanXuat())
                {
                    // Hoán đổi vị trí hai xe
                    XeCon temp = danhSach[j];
                    danhSach[j] = danhSach[j + 1];
                    danhSach[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("\n========== DANH SÁCH SAU KHI SẮP XẾP (NĂM SX TĂNG DẦN) ==========");
        for (int i = 0; i < danhSach.Count; i++)
        {
            Console.Write($"\nXe [{i + 1}] ");
            danhSach[i].Xuat();
        }
        Console.WriteLine("\nNhấn Enter để thoát...");
        Console.ReadLine();

    }
}

