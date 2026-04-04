using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int tocDoPipe = 8;
        int diemSo = 0;
        bool dangNhan = false;
        float tocDoRoi = 0f;   

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                //dangNhan = true;
                tocDoRoi = -15f;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void xuLyNhanPhim(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                dangNhan = true;
        }

        private void xuLyThaPhim(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                dangNhan = false;
        }

        private void ketThucGame()
        {
            gameTimer.Stop();
            scoreText.Text += "  -  THUA RỒI!!!";
            btnRestart.Visible = true;
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            //// Tính velocity
            //if (dangNhan)
            //    tocDoRoi -= 5f;   // lực đẩy lên
            //else
            //    tocDoRoi += 15f;   // trọng lực

            //tocDoRoi = Math.Max(-15f, Math.Min(tocDoRoi, 15f)); // giới hạn velocity

            tocDoRoi += 0.8f;  // gia tốc trọng lực — tăng dần đều
            tocDoRoi = Math.Min(tocDoRoi, 12f);

            flappyBird.Top += (int)tocDoRoi;

            // Xoay bird theo velocity
            float goc = Math.Max(-30f, Math.Min(tocDoRoi * 4f, 90f));
            XoayBird(goc);

            pipeBottom.Left -= tocDoPipe;
            pipeTop.Left = pipeBottom.Left;

            scoreText.Text = "Điểm: " + diemSo;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                pipeTop.Left = 800;
                diemSo++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                ketThucGame();
            }

            if (diemSo > 5)
                tocDoPipe = 15;
        }

        private void XoayBird(float goc)
        {
            if (flappyBird.Image == null) return;

            Bitmap original = new Bitmap(
                Application.StartupPath + "\\Resources\\bird.png");

            Bitmap rotated = new Bitmap(original.Width, original.Height);
            rotated.SetResolution(original.HorizontalResolution, original.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotated))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TranslateTransform(original.Width / 2f, original.Height / 2f);
                g.RotateTransform(goc);
                g.TranslateTransform(-original.Width / 2f, -original.Height / 2f);
                g.DrawImage(original, new Point(0, 0));
            }

            flappyBird.Image = rotated;
            original.Dispose();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            diemSo = 0;
            tocDoPipe = 8;
            tocDoRoi = 0f;
            dangNhan = false;

            flappyBird.Top = 228;
            flappyBird.Left = 69;

            pipeBottom.Left = 800;
            pipeTop.Left = 800;

            btnRestart.Visible = false;
            gameTimer.Start();
            this.Focus();
        }
    }
}