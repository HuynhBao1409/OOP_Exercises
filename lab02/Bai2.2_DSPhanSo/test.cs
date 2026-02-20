// using System;

// class PhanSo
// {
//     private int _tuSo;
//     private int _mauSo;

//     public int TuSo
//     {
//         get { return _tuSo; }
//         set { _tuSo = value; }
//     }

//     public int _mauSo
//     {
//         get { return _mauSo; }
//         set
//         {
//             if (value != 0)
//             {
//                 _mauSo = value;
//             }
//             else
//             {
//                 Console.WriteLine("asdasdassd");
//                 _mauSo = 1;
//             }
//         }
//     }

//     private int TimUCLN(int a, int b)
//     {
//         a = Math.Abs(a);
//         b = Math.Abs(b);
//         while (b != 0)
//         {
//             int temp = b;
//             b = a % b;
//             a = temp;
//         }
//         return a;
//     }

//     public PhanSo()
//     {
//         _tuSo = 0;
//         _mauSo = 1;
//     }

//     public PhanSo(int ts, int ms)
//     {
//         _tuSo = ts;
//         if (ms != 0)
//         {
//             _mauSo = ms;
//         }
//         else
//         {
//             Console.WriteLine("Mau so khong the bang 0. Gan mac dinh = 1");
//             _mauSo = 1;
//         }
//     }

//     public PhanSo(PhanSo p)
//     {
//         _tuSo = p._tuSo;
//         _mauSo = p._mauSo;
//     }

//     public void Nhap()
//     {
//         Console.WriteLine("assddasda");
//         _tuSo = int.Parse(Console.ReadLine() ?? "0");

//         do
//         {
//             Console.WriteLine("Nasdasdas: ");
//             _mauSo = int.Parse(Console.ReadLine() ?? "1");

//             if (_mauSo == 0)
//             {
//                 Console.WriteLine("asdasdsa");
//             }
//         } while (_mauSo == 0);
//     }

//     public void Xuat()
//     {
//         if (_mauSo == 1)
//         {
//             Console.Write(_tuSo);
//         }
//         else if (_mauSo < 0)
//         {
//             Console.Write($"{-_tuSo}/{-_mauSo}");
//         }
//         else
//         {
//             Console.Write($"{_tuSo}/{_mauSo}");
//         }
//     }

//     public void ToiGian()
//     {
//         int ucln = TimUCLN(_tuSo, _mauSo);
//         _tuSo /= ucln;
//         _mauSo /= ucln;

//         if (_mauSo < 0)
//         {
//             _tuSo = -_tuSo;
//             _mauSo = -_mauSo;
//         }
//     }

//     public double LayGiaTri()
//     {
//         return (double)_tuSo / _mauSo;
//     }

//     public int SoSanh(PhanSo p)
//     {
//         double gt1 = this.LayGiaTri();
//         double gt2 = p.LayGiaTri();

//         if (gt1 < gt2)
//         {
//             return -1;
//         }
//         else if (gt1 > gt2)
//         {
//             return 1;
//         }
//         else
//         {
//             return 0;
//         }
//     }
// }

// class DSPhanSo
// {
//     private PhanSo[] _dsPS;
//     private int _size;

//     public int Size
//     {
//         get { return _size; }
//         set
//         {
//             _size = value;
//         }
//     }

//     public DSPhanSo()
//     {
//         _size = 0;
//         _dsPS = null;
//     }

//     public DSPhanSo(int n)
//     {
//         _size = n;
//         _dsPS = new PhanSo[n];
//         for (int i = 0; i < n; i++)
//         {
//             _dsPS[i] = new PhanSo();
//         }
//     }

//     public void Nhap()
//     {
//         Console.Write("sdadasd");
//         _size = int.Parse(Console.ReadLine() ?? "0");

//         _dsPS = new PhanSo[_size];

//         for (int i = 0; i < _size; i++)
//         {
//             Console.WriteLine($"asdasdsad{i + 1}");
//             _dsPS[i] = new PhanSo();
//             _dsPS[i].Nhap();
//             _dsPS[i].ToiGian();
//         }
//     }

//     public void Xuat()
//     {
//         if (_size == 0 || _dsPS == null)
//         {
//             Console.WriteLine("Danh sach rong!");
//             return;
//         }

//         Console.WriteLine($"sdadsa{_size}sadsada");
//         for(int i = 0; i < _size; i++)
//         {
//             Console.Write($"PS{i+1}= ");
//             _dsPS[i].Xuat();
//             Console.WriteLine();
//         }
//     }


//     public void SapXepTangDan()
//     {
//         if (_size == 0 || _dsPS == null)
//         {
//             return null;
//         }

//         for(int i = 0; i < _size - 1; i++)
//         {
//             for(int j = 0; j < _size - i - 1; j++)
//             {
//                 if (_dsPS[j].SoSanh(_dsPS[j + 1]) > 0)
//                 {
//                     PhanSo temp=_dsPS[j];
//                     _dsPS[j]=_dsPS[j+1];
//                     _dsPS[j+1]= temp;
//                 }
//             }
//         }
//     }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         DSPhanSo ds = new PhanSo();
//         ds.Nhap();
//         ds.Xuat();
//         PhanSo max = ds.TimMax();
//         if(max!= null)
//         {
//             max.Xuat();
//         }

//         ds.SapXepTangDan();
//         ds.Xuat();
//     }
// }