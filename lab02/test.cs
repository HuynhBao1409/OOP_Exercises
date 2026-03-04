using System;

class PhanSo
{
    private int _ts;
    private int _ms;

    public int TuSo
    {
        get { return _ts; }
        set { _ts = value; }
    }

    public int MauSo
    {
        get { return _ms; }
        set
        {
            if (value != 0)
            {
                _ms = value;
            }
            else
            {
                Console.WriteLine("sadasdsadsa");
                _ms = 1;
            }
        }
    }

    public PhanSo()
    {
        _ts = 0;
        _ms = 1;
    }

    public PhanSo(int ts, int ms)
    {
        _ts = ts;
        if (ms != 0)
        {
            _ms = ms;
        }
        else
        {
            Console.WriteLine("sadasdsadsa");
            _ms = 1;
        }
    }

    public PhanSo(PhanSo p)
    {
        _ts = p._ts;
        _ms = p._ms;
    }

    public int TimUCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
    }

    public void Nhap()
    {
        Console.Write("asdas: ");
        _ts = int.Parse(Console.ReadLine() ?? "0");

        do
        {
            Console.Write("asdas: ");
            _ms = int.Parse(Console.ReadLine() ?? "1");

            if (_ms == 0)
            {
                Console.WriteLine("Mau so khong the = 0");
            }
        } while (_ms == 0);
    }

    public void Xuat()
    {
        if (_ms == 1)
        {
            Console.Write(_ts);
        }
        else if (_ms < 0)
        {
            Console.Write($"{-_tuSo}/{-_mauSo}");
        }
        else
        {
            Console.Write($"{_tuSo}/{_mauSo}");
        }
    }

    public void ToiGian()
    {
        int ucln = TimUCLN(_ts, _ms);
        _ts /= ucln;
        _ms /= ucln;

        if (_mauSo < 0)
        {
            _tuSo = -_tuSo;
            _mauSo = -_mauSo;
        }
    }
}