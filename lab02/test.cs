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
        get { return _ts; }
        set
        {
            if (value != 0)
            {
                _ms = value;
            }
            else
            {
                Console.WriteLine("Mau so khong the bang 0. Gan mac dinh = 1");
                _ms = 1;
            }
        }
    }

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
            Console.WriteLine("sadsadsadas");
            _ms = 1;
        }
    }
    public PhanSo(PhanSo p)
    {
        _ts = p._ts;
        _ms = p._ms;
    }

    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        _ts = int.Parse(Console.ReadLine() ?? "0");

        do
        {
            Console.Write("Nhap mau so: ");
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
        else if (_mauSo < 0)
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
        if (_ms < 0)
        {
            _tuSo = -_tuSo;
            _mauSo = -_mauSo;
        }
    }

    public double LayGiaTri()
    {
        return (double)_ts / _ms;
    }

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
    private PhanSo[] _dsPS;
    private int _size;

    public int Size
    {
        get { return _size; }
        set { _size = value; }
    }

    public DSPhanSo()
    {
        _size = 0;
        _dsPS = null;
    }

    public DSPhanSo(int n)
    {
        _size = n;
        _dsPS = new PhanSo[n];
        for (int i = 0; i < n; i++)
        {
            _dsPS[i] = new PhanSo();
        }
    }

    public void Nhap()
    {
        Console.Write("Nhap so luong phan so: ");
        _size = int.Parse(Console.ReadLine());
        _dsPS = new PhanSo[_size];

        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine($"\n--- Nhap phan so thu {i + 1} ---");
            _dsPS[i] = new PhanSo();
            _dsPS[i].Nhap();
            _dsPS[i].ToiGian();
        }
    }

    public void Xuat()
    {
        if (_size == 0 || _dsPS == null)
        {
            return;
        }
        Console.WriteLine($"{_size}");
        for (int i = 0; i < _size; i++)
        {
            Console.Write($"Ps{i + 1}: ");
            _dsPS[i].Xuat();
            Console.WriteLine();
        }
    }

    public PhanSo TimMax()
    {
        if (_size == 0 || _dsPS == null)
        {
            return;
        }
        PhanSo max = _dsPS[0];
        for (int i = 0; i < _size; i++)
        {
            if (_dsPS[i].SoSanh(max) > 0)
            {
                max = _dsPS[i];
            }
            return max;
        }
    }

    public void SapXepTangDan()
    {
        if (_size == 0 || _dsPS == null)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }
        Array.Sort(_dsPS (a, b) => a.LayGiaTri().CompareTo(b.LayGiaTri()));

        // for(int i = 0; i < _size - 1; i++)
        // {
        //     for(int j = 0; j < _size - i - 1; j++)
        //     {
        //         if (_dsPS[i].SoSanh(_dsPS[i + 1]) > 0)
        //         {
        //             PhanSo temp=_dsPS[i];
        //             _dsPS[i]=_dsPS[i+1];
        //             _dsPS[i+1]=temp;
        //         }
        //     }
        // }
    }

}

class test
{
    static void Main(string[] args)
    {
        DSPhanSo ds = new DSPhanSo();

        ds.Nhap();
        ds.Xuat;

        PhanSo max = ds.TimMax();
        if (max != null)
        {
            max.Xuat();
            Console.WriteLine();
        }

        ds.SapXepTangDan();
        ds.Xuat();

    }
}