using System;
using System.Collections.Generic;

class HangHoa
{
    private string maHang;
    private string tenHang;
    private double donGia;

    public string MaHang
    {
        get { return maHang; }
        set
        {
            if (value.Length == 10)
            {
                maHang = value;
            }
            else
            {
                Console.WriteLine("asd");
            }
        }
    }
    public string TenHang
    {
        get { return tenHang; }
        set
        {
            if (value.Length > 0)
            {
                tenHang = value;
            }
            else
            {
                Console.WriteLine("Lỗi: Tên hàng không được để trống!");
            }
        }
    }

    public double DonGia
    {
        get { return donGia; }
        set
        {
            if (value > 0)
            {
                donGia = value;
            }
            else
            {
                Console.WriteLine("  Lỗi: Đơn giá phải lớn hơn 0!");
            }
        }
    }

    public HangHoa() { }

    public HangHoa(string maHang, string tenHang, double donGia)
    {
        MaHang = maHang;
        TenHang = tenHang;
        DonGia = donGia;
    }

    public virtual void Nhap()
    {
        do
        {
            Console.Write("Mã hàng (10 ký tự): ");
            MaHang = Console.ReadLine();
        } while (maHang == null);

        do
        {
            Console.Write("  Tên hàng: ");
            TenHang = Console.ReadLine();
        } while (tenHang == null);

        bool hople = false;
        do
        {
            Console.Write("  Đơn giá: ");
            if (double.TryParse(Console.ReadLine(), out double nhap))
            {
                DonGia = nhap;
                hople = true;
            }
            else
            {
                Console.WriteLine("  Lỗi: Đơn giá phải là số!");
            }
        } while (!hople);
    }
    public virtual void Xuat()
    {
        Console.WriteLine($"  Mã hàng  : {MaHang}");
        Console.WriteLine($"  Tên hàng : {TenHang}");
        Console.WriteLine($"  Đơn giá  : {DonGia:N0} VNĐ");
    }
}

// //ĐỀ ÔN TẬP GK(Khóa trước)

// I. Cài đặt các lớp đối tượng (6đ)
// 1. Lớp HangHoa mô tả thông tin hàng hóa, gồm các thành phần:
//  ∙ Các dữ liệu riêng (fields): mã hàng, tên hàng, đơn giá. (0.5đ)
//  ∙ Các thuộc tính (properties) tương ứng với dữ liệu riêng, trong đó khi gán giá trị (set) ràng buộc:
// mã hàng đúng 10 ký tự, tên hàng có độ dài > 0, đơn giá > 0. (1đ)
//  ∙ Các phương thức: khởi tạo, nhập, xuất thông tin hàng. (1.5đ)
// 2. Lớp HangXK mô tả lớp hàng xuất khẩu, kế thừa lớp HangHoa và có thêm các thành phần:
//  ∙ Dữ liệu riêng: % thuế xuất khẩu (số thực), số lượng. (0.5đ)
//  ∙ Thuộc tính tương ứng với mức thuế, ràng buộc giá trị trong khoảng [0, 100]. (0.5đ)
//  ∙ Các phương thức khởi tạo, nhập, xuất ẩn phương thức cùng tên của lớp cơ sở. (1đ)
//  ∙ Phương thức tính thuế theo công thức:
// Thuế = Số lượng × Đơn giá × Thuế xuất khẩu (1đ)

// II. Chương trình chính (4đ)
//  ∙ Nhập (hoặc tạo) danh sách n sản phẩm xuất khẩu (2 <= n <= 100). (1đ)
//  ∙ In danh sách vừa nhập và thông tin chi tiết. (1đ)
//  ∙ In thông tin sản phẩm có tổng thuế cao nhất. (1đ)
//  ∙ Xóa các sản phẩm có mã trùng nhau chỉ giữ lại sản phẩm đầu, in ra danh sách sau xử lý. (1đ)
