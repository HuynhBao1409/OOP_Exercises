// Xây dựng lớp HinhVe (hình vẽ) làm lớp cơ sở cho các loại hình vẽ cụ thể. 
//Trong lớp HinhVe cài đặt phương thức ảo DienTich() trả về diện tích của hình.

// - Xây dựng các lớp hình chữ nhật, hình tròn kế thừa lớp HinhVe, còn lớp hình vuông kế thừa lớp hình chữ nhật.
// - Viết chương trình cho phép nhập vào một trong các hình kể trên. Tính và in ra diện tích của hình đó.
using System;

class HinhVe
{
    // Phương thức ảo DienTich()
    public virtual double DienTich()
    {
        return 0;
    }

    public virtual void Xuat()
    {
        Console.WriteLine("Diện tích" + DienTich());
    }
}

// LỚP HÌNH CHỮ NHẬT - kế thừa HinhVe
class HinhChuNhat : HinhVe
{
    protected double chieuDai;
    protected double chieuRong;

    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        this.chieuDai = chieuDai;
        this.chieuRong = chieuRong;
    }

    // Override DienTich: S = dài x rộng
    public override double DienTich()
    {
        return chieuDai * chieuRong;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hình chữ nhật: ");
        Console.WriteLine("  Chiều dài : " + chieuDai);
        Console.WriteLine("  Chiều rộng: " + chieuRong);
        Console.WriteLine("  Diện tích : " + DienTich());
    }
}

// LỚP HÌNH VUÔNG - kế thừa HinhChuNhat
class HinhVuong : HinhChuNhat
{
    public HinhVuong(double canh) : base(canh, canh)
    {
    }

    // DienTich() kế thừa từ HinhChuNhat
    // S = cạnh x cạnh = dài x rộng

    public override void Xuat()
    {
        Console.WriteLine("Hình vuông:");
        Console.WriteLine($"  Cạnh     : {chieuDai}");
        Console.WriteLine($"  Diện tích: {DienTich()}");
    }
}


// LỚP HÌNH TRÒN - kế thừa HinhVe
class HinhTron : HinhVe
{
    private double R;
    public HinhTron(double R)
    {
        this.R = R;
    }

    // Override DienTich: S = PI x r^2
    public override double DienTich()
    {
        return Math.PI * R * R;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hình tròn");
        Console.WriteLine("Bán kính: " + R);
        Console.WriteLine("Diện tích: " + Math.Round(DienTich(), 4));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==== CHƯƠNG TRÌNH CHỌN DIỆN TÍCH ====");
        Console.WriteLine("Chọn loại hình:");
        Console.WriteLine("  1. Hình chữ nhật");
        Console.WriteLine("  2. Hình vuông");
        Console.WriteLine("  3. Hình tròn");
        Console.Write("Nhập lựa chọn (1/2/3): ");
        int loai = int.Parse(Console.ReadLine());

        HinhVe hv;
        if (loai == 1)
        {
            // Nhập hình chữ nhật
            Console.Write("Nhập chiều dài: ");
            double dai = double.Parse(Console.ReadLine());

            Console.Write("Nhập chiều rộng: ");
            double rong = double.Parse(Console.ReadLine());

            hv = new HinhChuNhat(dai, rong);
        }
        else if (loai == 2)
        {
            // Nhập hình vuông
            Console.Write("Nhập độ dài cạnh: ");
            double canh = double.Parse(Console.ReadLine());

            hv = new HinhVuong(canh);
        }
        else if (loai == 3)
        {
            // Nhập hình tròn
            Console.Write("Nhập bán kính: ");
            double r = double.Parse(Console.ReadLine());

            hv = new HinhTron(r);
        }
        else
        {
            Console.WriteLine("Lựa chọn không hợp lệ!");
            return;
        }

        Console.WriteLine("\n==== Kết quả ====");
        hv.Xuat();

        Console.WriteLine("\nNhấn Enter để thoát...");
        Console.ReadLine();
    }
}