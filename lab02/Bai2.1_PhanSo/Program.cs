using System;

class PhanSo
{
    //Khai Bao ttinh private
    private int _tuSo;
    private int _mauSo;

    //Ttinh TuSo
    public int TuSo
    {
        get { return _tuSo; }
        set { _tuSo = value; }
    }

    //Ttinh MauSo
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

    //Ham khoi tao khong tham so
    public PhanSo()
    {
        _tuSo = 0;
        _mauSo = 1;
    }

    //Ham khoi tao Pso
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

    //Nhap phan so 
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

    //In phan so
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

    //Toi gian phan so
    public void ToiGian()
    {
        int ucln = TimUCLN(_tuSo, _mauSo);
        _tuSo /= ucln;
        _mauSo /= ucln;

        //Dua dau am ve tu so
        if (_mauSo < 0)
        {
            _tuSo = -_tuSo;
            _mauSo = -_mauSo;
        }
    }

    //Cong phan so
    public PhanSo Cong(PhanSo p)
    {
        PhanSo kq = new PhanSo();
        kq._tuSo = _tuSo * p._mauSo + p._tuSo * _mauSo;
        kq._mauSo = _mauSo * p._mauSo;
        kq.ToiGian();
        return kq;
    }

    //Tru phan so
    public PhanSo Tru(PhanSo p)
    {
        PhanSo kq = new PhanSo();
        kq._tuSo = _tuSo * p._mauSo - p._tuSo * _mauSo;
        kq._mauSo = _mauSo * p._mauSo;
        kq.ToiGian();
        return kq;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //Khai bao 2 doi tuong phan so
        PhanSo ps1 = new PhanSo();
        PhanSo ps2 = new PhanSo();

        //Nhap phan so
        Console.WriteLine("========== NHAP PHAN SO 1 ==========");
        ps1.Nhap();

        Console.WriteLine("\n========== NHAP PHAN SO 2 ==========");
        ps2.Nhap();

        //Xuat phan so
        Console.WriteLine("\n========== XUAT PHAN SO  ==========");
        Console.Write("Phan So 1: ");
        ps1.Xuat();
        Console.WriteLine();

        Console.Write("Phan so 2: ");
        ps2.Xuat();
        Console.WriteLine();

        //Toi gian Phan so
        ps1.ToiGian();
        ps2.ToiGian();

        Console.WriteLine("\n========== PHAN SO SAU KHI TOI GIAN ==========");
        Console.Write("Phan so 1 toi gian: ");
        ps1.Xuat();
        Console.WriteLine();

        Console.Write("Phan so 2 toi gian: ");
        ps2.Xuat();
        Console.WriteLine();

        // Tính tổng và hiệu các phân số
        Console.WriteLine("\n========== TINH TOAN ==========");
        PhanSo tong = ps1.Cong(ps2);
        Console.Write("Tong: ");
        ps1.Xuat();
        Console.Write(" + ");
        ps2.Xuat();
        Console.Write(" = ");
        tong.Xuat();
        Console.WriteLine();

        PhanSo hieu = ps1.Tru(ps2);
        Console.Write("Hieu: ");
        ps1.Xuat();
        Console.Write(" - ");
        ps2.Xuat();
        Console.Write(" = ");
        hieu.Xuat();
        Console.WriteLine();

        Console.ReadKey();
    }
}