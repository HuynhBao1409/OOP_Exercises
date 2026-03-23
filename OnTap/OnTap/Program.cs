using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnTap
{
    class NhanVien
    {
        protected string hoTen;
        protected DateTime ngaySinh;
        protected double luong;

        public NhanVien() { }

        public NhanVien(string hoTen, DateTime ngaySinh)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.luong = 0;
        }

        public string GetHoTen() { return hoTen; }
        public DateTime GetNgaySinh() { return ngaySinh; }
        public double GetLuong() { return luong; }

        public virtual void Nhap()
        {
            Console.WriteLine("  Họ tên: ");
            hoTen = Console.ReadLine();
            Console.WriteLine("  Ngày sinh (dd/MM/yyyy): ");
            ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        public virtual void TinhLuong() { }

        public virtual void Xuat()
        {
            Console.WriteLine($"  Họ tên  : {hoTen}");
            Console.WriteLine($"  Ngày sinh  : {ngaySinh}");
            Console.WriteLine($"  Lương  : {luong:N0} vnd");
        }
    }

    class NhanVienVanPhong : NhanVien
    {
        private int soNgayLam;

        public NhanVienVanPhong():base() { }

        public NhanVienVanPhong(string hoTen,DateTime ngaySinh, int soNgayLam):
            base(hoTen,ngaySinh)
        {
            this.soNgayLam = soNgayLam;
            TinhLuong();
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write(" Số ngày làm việc: ");
            soNgayLam = int.Parse(Console.ReadLine());
            TinhLuong();
        }

        public override void TinhLuong()
        {
            luong = soNgayLam * 100000;
        }

        public override void Xuat()
        {
            Console.WriteLine("  [Nhân viên văn phòng]");
            base.Xuat();
            Console.WriteLine($" Số ngày làm việc: {soNgayLam}");
        }
    }

    class NhanVienSX : NhanVien
    {
        protected double luongCoBan;
        protected int soSP;

        public NhanVienSX() : base() { }

        public NhanVienSX(string hoTen,DateTime ngaySinh, double luongCoBan, int soSP):base(hoTen,ngaySinh)
        {
            this.luongCoBan = luongCoBan;
            this.soSP = soSP;
            TinhLuong();
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("  Lương cơ bản: ");
            luongCoBan = double.Parse(Console.ReadLine());
            Console.WriteLine("  Số sản phẩm: ");
            soSP = int.Parse(Console.ReadLine());
            TinhLuong();
        }

        public override void TinhLuong()
        {
            luong = luongCoBan * soSP * 5000;
        }
        public override void Xuat()
        {
            Console.WriteLine("  [Nhân viên sản xuất]");
            base.Xuat();
            Console.WriteLine($"  Lương căn bản: {luongCoBan:N0} vnd");
            Console.WriteLine($"  Số sản phẩm: {soSP}");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<NhanVien> ds = new List<NhanVien>();
            Console.Write("Nhập số lượng nhân viên: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhân viên thứ {i + 1} ---");
                Console.WriteLine("Loại nhân viên: 1 - Văn phòng | 2- Sản xuất");
                Console.Write("Chọn loại: ");
                int loai = int.Parse(Console.ReadLine());
                NhanVien nv;
                if (loai == 1)
                {
                    nv = new NhanVienVanPhong();
                }else 
                {
                    nv = new NhanVienSX();
                }
                nv.Nhap();
                ds.Add(nv);
            }

            Console.WriteLine("\n========== Danh sách nhân viên ==========");
            for(int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine($"\n NV {i + 1}= ");
                ds[i].Xuat();
            }

            ds.Sort((a, b) => b.GetLuong().CompareTo(a.GetLuong()));
            Console.WriteLine("\n==== Danh sách sau khi sắp xếp (lương giảm dần) ====");

            for (int i = 0; i < ds.Count; i++)
            {
               Console.WriteLine($"\nNhân viên #{i + 1}: ");
                ds[i].Xuat();
            }
        }
    }

}
