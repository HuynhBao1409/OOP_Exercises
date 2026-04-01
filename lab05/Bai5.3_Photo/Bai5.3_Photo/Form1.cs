namespace Bai5._3_Photo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnOpen.Click += (s, e) =>
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image File|*jpg;*jpeg;*.png;*.bmp;*.gif";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = System.Drawing.Image.FromFile(dlg.FileName);
                }
            };

            btnClose.Click += (s, e) => Close();
        }

    }
}
