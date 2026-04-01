namespace Flappy_Bird
{
    partial class Form1
    {
        /// <summary>
        /// Biến designer bắt buộc.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Dọn dẹp tài nguyên đang sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu cần giải phóng tài nguyên managed; ngược lại là false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Phương thức bắt buộc để hỗ trợ Designer - không chỉnh sửa
        /// nội dung phương thức này bằng trình soạn thảo mã.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pipeTop = new PictureBox();
            pipeBottom = new PictureBox();
            flappyBird = new PictureBox();
            ground = new PictureBox();
            scoreText = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            btnRestart = new Button();
            ((System.ComponentModel.ISupportInitialize)pipeTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pipeBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)flappyBird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ground).BeginInit();
            SuspendLayout();
            // 
            // pipeTop
            // 
            pipeTop.Image = Image.FromFile(Application.StartupPath + "\\Resources\\pipedown.png");
            pipeTop.Location = new Point(800, -68);
            pipeTop.Margin = new Padding(4, 3, 4, 3);
            pipeTop.Name = "pipeTop";
            pipeTop.Size = new Size(117, 307);
            pipeTop.SizeMode = PictureBoxSizeMode.StretchImage;
            pipeTop.TabIndex = 0;
            pipeTop.TabStop = false;
            // 
            // pipeBottom
            // 
            pipeBottom.Image = Image.FromFile(Application.StartupPath + "\\Resources\\pipe.png");
            pipeBottom.Location = new Point(800, 482);
            pipeBottom.Margin = new Padding(4, 3, 4, 3);
            pipeBottom.Name = "pipeBottom";
            pipeBottom.Size = new Size(127, 330);
            pipeBottom.SizeMode = PictureBoxSizeMode.StretchImage;
            pipeBottom.TabIndex = 1;
            pipeBottom.TabStop = false;
            // 
            // flappyBird
            // 
            flappyBird.Image = Image.FromFile(Application.StartupPath + "\\Resources\\bird.png");
            flappyBird.Location = new Point(80, 263);
            flappyBird.Margin = new Padding(4, 3, 4, 3);
            flappyBird.Name = "flappyBird";
            flappyBird.Size = new Size(96, 80);
            flappyBird.SizeMode = PictureBoxSizeMode.StretchImage;
            flappyBird.TabIndex = 2;
            flappyBird.TabStop = false;
            // 
            // ground
            // 
            ground.Image = Image.FromFile(Application.StartupPath + "\\Resources\\ground.png");
            ground.Location = new Point(-19, 730);
            ground.Margin = new Padding(4, 3, 4, 3);
            ground.Name = "ground";
            ground.Size = new Size(764, 145);
            ground.SizeMode = PictureBoxSizeMode.StretchImage;
            ground.TabIndex = 3;
            ground.TabStop = false;
            // 
            // scoreText
            // 
            scoreText.AutoSize = true;
            scoreText.BackColor = Color.Moccasin;
            scoreText.Font = new Font("Arial Narrow", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scoreText.Location = new Point(211, 763);
            scoreText.Margin = new Padding(4, 0, 4, 0);
            scoreText.Name = "scoreText";
            scoreText.Size = new Size(115, 37);
            scoreText.TabIndex = 4;
            scoreText.Text = "Điểm: 0";
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimerEvent;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.Orange;
            btnRestart.Font = new Font("Arial Narrow", 18F, FontStyle.Bold);
            btnRestart.ForeColor = Color.White;
            btnRestart.Location = new Point(229, 346);
            btnRestart.Margin = new Padding(4, 3, 4, 3);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(233, 69);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Chơi lại";
            btnRestart.UseVisualStyleBackColor = false;
            btnRestart.Visible = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aqua;
            ClientSize = new Size(726, 816);
            Controls.Add(scoreText);
            Controls.Add(flappyBird);
            Controls.Add(ground);
            Controls.Add(pipeBottom);
            Controls.Add(pipeTop);
            Controls.Add(btnRestart);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Flappy Bird - Trò chơi";
            KeyDown += xuLyNhanPhim;
            KeyUp += xuLyThaPhim;
            ((System.ComponentModel.ISupportInitialize)pipeTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pipeBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)flappyBird).EndInit();
            ((System.ComponentModel.ISupportInitialize)ground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private System.Windows.Forms.PictureBox pipeTop;
        private System.Windows.Forms.PictureBox pipeBottom;
        private System.Windows.Forms.PictureBox flappyBird;
        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button btnRestart;
    }
}