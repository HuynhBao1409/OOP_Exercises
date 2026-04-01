using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawShapes
{
    // ===== Lớp cơ sở trừu tượng Shape =====
    abstract class Shape
    {
        // Tọa độ góc trên trái và góc dưới phải
        public int X1, Y1, X2, Y2;

        public Shape(int x1, int y1, int x2, int y2)
        {
            X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;
        }

        // Phương thức vẽ - đa hình (polymorphism)
        public abstract void Draw(Graphics g, Pen pen);

        // Phương thức tính diện tích - đa hình
        public abstract double DienTich();

        // Trả về Rectangle bao quanh hình (dùng để vẽ)
        protected Rectangle GetRect()
        {
            int x = Math.Min(X1, X2);
            int y = Math.Min(Y1, Y2);
            int w = Math.Abs(X2 - X1);
            int h = Math.Abs(Y2 - Y1);
            return new Rectangle(x, y, w, h);
        }
    }

    // ===== Lớp Ellipse (hình elip) =====
    class Ellipse : Shape
    {
        public Ellipse(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, GetRect());
        }

        public override double DienTich()
        {
            // Diện tích elip = PI * a * b (a, b là bán trục)
            double a = Math.Abs(X2 - X1) / 2.0;
            double b = Math.Abs(Y2 - Y1) / 2.0;
            return Math.PI * a * b;
        }
    }

    // ===== Lớp Rectangle (hình chữ nhật) =====
    class MyRectangle : Shape
    {
        public MyRectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, GetRect());
        }

        public override double DienTich()
        {
            // Diện tích = chiều rộng * chiều cao
            return Math.Abs(X2 - X1) * (double)Math.Abs(Y2 - Y1);
        }
    }

    // ===== Form chính =====
    public partial class Form1 : Form
    {
        // Danh sách lưu tất cả hình đã vẽ
        private List<Shape> danhSachHinh = new List<Shape>();

        // Tọa độ điểm bắt đầu khi nhấn chuột
        private int startX, startY;

        // Đang kéo chuột hay không
        private bool dangKeo = false;

        public Form1()
        {
            InitializeComponent();
            // Bật DoubleBuffer để vẽ mượt, không bị nhấp nháy
            this.panelCanvas.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(this.panelCanvas, true, null);
        }

        // Sự kiện chuột trên panel vẽ

        // Nhấn chuột: lưu điểm bắt đầu
        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
            dangKeo = true;
        }

        // Thả chuột: tạo hình mới và thêm vào danh sách
        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!dangKeo) return;
            dangKeo = false;

            // Bỏ qua nếu click mà không kéo (hình quá nhỏ)
            if (Math.Abs(e.X - startX) < 3 || Math.Abs(e.Y - startY) < 3) return;

            // Tạo hình theo loại đang chọn
            Shape hinh;
            if (rdoEllipse.Checked)
                hinh = new Ellipse(startX, startY, e.X, e.Y);
            else
                hinh = new MyRectangle(startX, startY, e.X, e.Y);

            danhSachHinh.Add(hinh);

            // Vẽ lại toàn bộ panel
            panelCanvas.Invalidate();
        }

        // Sự kiện Paint: vẽ lại tất cả hình
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Tìm hình có diện tích lớn nhất (polymorphism - DienTich())
            Shape hinhLonNhat = null;
            double dienTichMax = -1;
            foreach (Shape s in danhSachHinh)
            {
                double dt = s.DienTich();
                if (dt > dienTichMax)
                {
                    dienTichMax = dt;
                    hinhLonNhat = s;
                }
            }

            // Vẽ từng hình (polymorphism - Draw())
            foreach (Shape s in danhSachHinh)
            {
                // Hình lớn nhất tô màu đỏ, còn lại màu xanh
                Pen pen = (s == hinhLonNhat)
                    ? new Pen(Color.Red, 2)
                    : new Pen(Color.Blue, 2);

                s.Draw(g, pen);  // đa hình: tự gọi Draw đúng loại hình
                pen.Dispose();
            }
        }
    }
}