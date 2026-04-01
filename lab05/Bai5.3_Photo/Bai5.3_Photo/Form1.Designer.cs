using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace Bai5._3_Photo
{

    
        partial class Form1
        {
            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null)) components.Dispose();
                base.Dispose(disposing);
            }

            private System.Windows.Forms.PictureBox pictureBox;
            private System.Windows.Forms.Button btnOpen, btnClose;

        private void InitializeComponent()
        {
            pictureBox = new System.Windows.Forms.PictureBox();
            btnOpen = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            SuspendLayout();

            pictureBox.Location = new System.Drawing.Point(10, 10);
            pictureBox.Size = new System.Drawing.Size(550, 450);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            btnOpen.Text = "Open";
            btnOpen.Location = new System.Drawing.Point(590, 30);
            btnOpen.Size = new System.Drawing.Size(100, 35);

            btnClose.Text = "Close";
            btnClose.Location = new System.Drawing.Point(590, 90);
            btnClose.Size = new System.Drawing.Size(100, 35);

            ClientSize = new System.Drawing.Size(710, 470);
            Text = "Simple Photo Viewer";
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.AddRange(new System.Windows.Forms.Control[] { pictureBox, btnOpen, btnClose });
            ResumeLayout(false);
        }
    }
}

