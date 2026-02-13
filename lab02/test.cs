//FIle này là để làm nháp hoặc làm lại bài trc đó
using System;

class PhanSo
{
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
                Console.WriteLine("Mau so khong the bang 0");
                _mauSo = 1;
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
        _tuSo = 0;
        _mauSo = 1;
    }

    public PhanSo(int ts, int ms)
    {
        _tuSo = ts;
        if (ms != 0)
        {
            _mauSo = ms;
        }
        else
        {
            Console.WriteLine("Mau so khong the bang 0");
            _mauSo = 1;
        }
    }

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
            Console.WriteLine("Nhap mau so: ");
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
            Console.Write($"{-_tuSo}/{-_mauSo}");
        }
    }

    public void ToiGian()
    {
        int ucln = TimUCLN(_tuSo, _mauSo);
        _tuSo /= ucln;
        _mauSo /= ucln;

        if (_mauSo < 0)
        {
            _tuSo = -_tuSo;
            _mauSo = -_mauSo;
        }
    }


    public PhanSo Cong(PhanSo p)
    {
        PhanSo kq = new PhanSo();
        kq._tuSo = _tuSo * p._mauSo + p._tuSo * _mauSo;
        kq._mauSo = _mauSo * p._mauSo;
        kq.ToiGian();
        return kq;
    }

    public PhanSo Tru(PhanSo p)
    {
        PhanSo kq = new PhanSo();
        kq._tuSo = _tuSo * p._mauSo - p._tuSo * _mauSo;
        kq._mauSo = _mauSo * p._mauSo;
        kq.ToiGian();
        return kq;
    }


}