using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawShapes
{
    abstract class Shape
    {
        public int X1, Y1, X2, Y2;

        public Shape(int x1, int y1, int x2, int y2)
        {
            X1 = x1; Y1 = y1; X2 = x2; Y2 = y2;
        }

        public abstract void Draw(Graphics g, Pen pen);
        public abstract double DienTich();

        protected Rectangle GetRect()
        {
            int x = Math.Min(X1, X2);
            int y = Math.Min(Y1, Y2);
            int w = Math.Abs(X2 - X1);
            int h = Math.Abs(Y2 - Y1);
            return new Rectangle(x, y, w, h);
        }
    }

    class Ellipse : Shape
    {
        public Ellipse(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, GetRect());
        }

        public override double DienTich()
        {
            double a = Math.Abs(X2 - X1) / 2.0;
            double b = Math.Abs(Y2 - Y1) / 2.0;
            return Math.PI * a * b;
        }
    }

    class MyRectangle : Shape
    {
        public MyRectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, GetRect());
        }

        public override double DienTich()
        {
            return Math.Abs(X2 - X1) * (double)Math.Abs(Y2 - Y1);
        }
    }

    public partial class Form1 : Form
    {
        private List<Shape> danhSachHinh = new List<Shape>();
        private int startX, startY;
        private int currentX, currentY;
        private bool dangKeo = false;

        public Form1()
        {
            InitializeComponent();
            this.panelCanvas.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(this.panelCanvas, true, null);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
            currentX = e.X;
            currentY = e.Y;
            dangKeo = true;
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dangKeo) return;
            currentX = e.X;
            currentY = e.Y;
            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!dangKeo) return;
            dangKeo = false;

            if (Math.Abs(e.X - startX) < 3 || Math.Abs(e.Y - startY) < 3) return;

            Shape hinh;
            if (rdoEllipse.Checked)
                hinh = new Ellipse(startX, startY, e.X, e.Y);
            else
                hinh = new MyRectangle(startX, startY, e.X, e.Y);

            danhSachHinh.Add(hinh);
            panelCanvas.Invalidate();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Tìm hình có diện tích lớn nhất
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

            // Vẽ tất cả hình đã lưu
            foreach (Shape s in danhSachHinh)
            {
                Pen pen = (s == hinhLonNhat)
                    ? new Pen(Color.Red, 2)
                    : new Pen(Color.Blue, 2);
                s.Draw(g, pen);
                pen.Dispose();
            }

            // Vẽ preview hình đang kéo (nét đứt xám)
            if (dangKeo)
            {
                int x = Math.Min(startX, currentX);
                int y = Math.Min(startY, currentY);
                int w = Math.Abs(currentX - startX);
                int h = Math.Abs(currentY - startY);

                if (w > 0 && h > 0)
                {
                    Rectangle previewRect = new Rectangle(x, y, w, h);
                    using (Pen previewPen = new Pen(Color.Gray, 1))
                    {
                        previewPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        if (rdoEllipse.Checked)
                            g.DrawEllipse(previewPen, previewRect);
                        else
                            g.DrawRectangle(previewPen, previewRect);
                    }
                }
            }
        }
    }
}