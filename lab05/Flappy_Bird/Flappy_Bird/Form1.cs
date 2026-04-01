using System;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int tocDoPipe = 8;
        int trongLuc = 15;
        int diemSo = 0;
        bool dangNhan = false;

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
                dangNhan = true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void xuLyNhanPhim(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                trongLuc = -15;
                dangNhan = true;
            }
        }

        private void xuLyThaPhim(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                trongLuc = 15;
                dangNhan = false;
            }
        }

        private void ketThucGame()
        {
            gameTimer.Stop();
            scoreText.Text += "  -  THUA RỒI!!!";
            btnRestart.Visible = true;
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (dangNhan)
                trongLuc = -15;
            else
                trongLuc = 15;

            flappyBird.Top += trongLuc;

            // 2 ống di chuyển cùng nhau
            pipeBottom.Left -= tocDoPipe;
            pipeTop.Left = pipeBottom.Left;

            scoreText.Text = "Điểm: " + diemSo;

            // Reset cả 2 ống cùng lúc
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

        private void btnRestart_Click(object sender, EventArgs e)
        {
            diemSo = 0;
            tocDoPipe = 8;
            trongLuc = 15;
            dangNhan = false;

            flappyBird.Top = 228;
            flappyBird.Left = 69;

            // Reset 2 ống về cùng vị trí
            pipeBottom.Left = 800;
            pipeTop.Left = 800;

            btnRestart.Visible = false;
            gameTimer.Start();
            this.Focus();
        }
    }
}