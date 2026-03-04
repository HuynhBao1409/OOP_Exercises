// 1. Xây dựng lớp DSPhanSo (Danh sách phân số) gồm có các thuộc tính, phương thức sau:
// 1.1. Thuộc tính
// Dữ liệu riêng:
// PhanSo _dsPS;
// int _size; // số phần tử
// Thuộc tính:
// DSPS
// Size

// 1.2. Phương thức
// - Nhập danh phân số.
// - In danh sách phân số.
// - Tìm phân số lớn nhất.
// - Sắp xếp danh sách phân số theo thứ tự tăng dần của giá trị phân số.

// 2. Chương trình chính
// - Khai báo 1 đối tượng danh sách phân số.
// - Nhập, xuất danh sách phân số.
// - In ra phân số lớn nhất.
// - In ra danh sách phân số theo thứ tự tăng dần của giá trị.
using System;

class PhanSo
{
    //Khai Bao ttinh private
    private int _tuSo;
    private int _mauSo;

    public int TuSo
    {
        get { return _tuSo; }
        set { _tuSo = value; }
    }

    public int MauSo
    {
        get { return _mauSo; }
        set
        {
            if (value != 0)
            {
                _mauSo = value;
            }
            else
            {
                Console.WriteLine("Mau so khong the bang 0. Gan mac dinh = 1");
                _mauSo = 1;
            }
        }
    }


    //Ham khoi tao khong can tham so
    public PhanSo()
    {
        _tuSo = 0;
        _mauSo = 1;
    }

    //Khoi tao Pso
    public PhanSo(int ts, int ms)
    {
        _tuSo = ts;
        if (ms != 0)
        {
            _mauSo = ms;
        }
        else
        {
            Console.WriteLine("Mau so khong the bang 0. Gan mac dinh = 1");
            _mauSo = 1;
        }
    }

    //Ham thiet lap sao chep
    public PhanSo(PhanSo p)
    {
        _tuSo = p._tuSo;
        _mauSo = p._mauSo;
    }

    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        _tuSo = int.Parse(Console.ReadLine() ?? "0");

        do
        {
            Console.Write("Nhap mau so: ");
            _mauSo = int.Parse(Console.ReadLine() ?? "1");

            if (_mauSo == 0)
            {
                Console.WriteLine("Mau so khong the = 0");
            }
        } while (_mauSo == 0);
    }

    public void Xuat()
    {
        if (_mauSo == 1)
        {
            Console.Write(_tuSo);
        }
        else if (_mauSo < 0)
        {
            Console.Write($"{-_tuSo}/{-_mauSo}");
        }
        else
        {
            Console.Write($"{_tuSo}/{_mauSo}");
        }
    }
    //Ham tim UCLN
    private int TimUCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    //Ham toi gian
    public void ToiGian()
    {
        int ucln = TimUCLN(_tuSo, _mauSo);
        _tuSo /= ucln;
        _mauSo /= ucln;

        //Day dau am ve tu so
        if (_mauSo < 0)
        {
            _tuSo = -_tuSo;
            _mauSo = -_mauSo;
        }
    }
    //Lay gia tri thuc cua phan so
    public double LayGiaTri()
    {
        return (double)_tuSo / _mauSo;
    }

    //So sanh phan tu (tra ve -1, 0, 1)
    public int SoSanh(PhanSo p)
    {
        double gt1 = this.LayGiaTri();
        double gt2 = p.LayGiaTri();

        if (gt1 < gt2)
        {
            return -1;
        }
        else if (gt1 > gt2)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

class DSPhanSo
{
    //Khai bao
    private PhanSo[] _dsPS;
    private int _size;

    public int Size
    {
        get { return _size; }
        set { _size = value; }
    }
    //Them Constructor ko tham so
    public DSPhanSo()
    {
        _size = 0;
        _dsPS = null;
    }
    //Ham Khoi tao co tham so
    public DSPhanSo(int n)
    {
        _size = n;
        _dsPS = new PhanSo[n];
        for (int i = 0; i < n; i++)
        {
            _dsPS[i] = new PhanSo();
        }
    }

    //Nhap danh sach phan so
    public void Nhap()
    {
        Console.Write("Nhap so luong phan so: ");
        _size = int.Parse(Console.ReadLine() ?? "0");

        _dsPS = new PhanSo[_size];

        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine($"\n--- Nhap phan so thu {i + 1} ---");
            _dsPS[i] = new PhanSo();
            _dsPS[i].Nhap();
            _dsPS[i].ToiGian();
        }
    }

    //In danh sach phan so
    public void Xuat()
    {
        if (_size == 0 || _dsPS == null)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        Console.WriteLine($"Danh sach co {_size} phan so: ");
        for (int i = 0; i < _size; i++)
        {
            Console.Write($"PS{i + 1} = ");
            _dsPS[i].Xuat();
            Console.WriteLine();
        }
    }

    //Tim phan so lon nhat
    public PhanSo TimMax()
    {
        if (_size == 0 || _dsPS == null)
        {
            Console.WriteLine("Danh sach Rong!");
            return null;
        }

        PhanSo max = _dsPS[0];
        for (int i = 1; i < _size; i++)
        {
            if (_dsPS[i].SoSanh(max) > 0)
            {
                max = _dsPS[i];
            }
        }
        return max;
    }

    //Sap Xep Tang Dan theo gia tri phan so
    public void SapXepTangDan()
    {
        if (_size == 0 || _dsPS == null)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        //Sap xep noi bot(bubble Sort)
        for (int i = 0; i < _size - 1; i++)
        {
            for (int j = 0; j < _size - i - 1; j++)
            {
                if (_dsPS[j].SoSanh(_dsPS[j + 1]) > 0)
                {
                    PhanSo temp = _dsPS[j];
                    _dsPS[j] = _dsPS[j + 1];
                    _dsPS[j + 1] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        DSPhanSo ds = new DSPhanSo();

        // Nhap danh sach phan so
        Console.WriteLine("========== NHAP DANH SACH PHAN SO ==========");
        ds.Nhap();

        // Xuat danh sach phan so
        Console.WriteLine("\n========== DANH SACH PHAN SO VUA NHAP ==========");
        ds.Xuat();

        // Tim va in phan so lon nhat
        Console.WriteLine("\n========== PHAN SO LON NHAT ==========");
        PhanSo max = ds.TimMax();
        if (max != null)
        {
            Console.Write("Phan tu lon nhat: ");
            max.Xuat();
            Console.WriteLine();
        }

        // Sap xep va in danh sach tang dan
        Console.WriteLine("\n========== SAP XEP TANG DAN ==========");
        ds.SapXepTangDan();
        Console.WriteLine("Danh sach sau khi sap xep: ");
        ds.Xuat();

        Console.WriteLine("\n\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}