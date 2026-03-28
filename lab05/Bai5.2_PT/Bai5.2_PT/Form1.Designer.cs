namespace Bai5._2_PT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblA, lblB, lblC, lblNghiem;
        private System.Windows.Forms.TextBox txtA, txtB, txtC, txtKetQua;
        private System.Windows.Forms.Button btnGiai, btnThoat;

        private void InitializeComponent()
        {
            lblA = new Label();
            lblB = new Label();
            lblC = new Label();
            lblNghiem = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtC = new TextBox();
            txtKetQua = new TextBox();
            btnGiai = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblA
            // 
            lblA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblA.Location = new Point(20, 20);
            lblA.Name = "lblA";
            lblA.Size = new Size(100, 25);
            lblA.TabIndex = 0;
            lblA.Text = "Nhập hệ số a";
            // 
            // lblB
            // 
            lblB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblB.Location = new Point(20, 55);
            lblB.Name = "lblB";
            lblB.Size = new Size(104, 25);
            lblB.TabIndex = 1;
            lblB.Text = "Nhập hệ số b";
            // 
            // lblC
            // 
            lblC.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblC.Location = new Point(20, 90);
            lblC.Name = "lblC";
            lblC.Size = new Size(100, 25);
            lblC.TabIndex = 2;
            lblC.Text = "Nhập hệ số c";
            // 
            // lblNghiem
            // 
            lblNghiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNghiem.Location = new Point(290, 20);
            lblNghiem.Name = "lblNghiem";
            lblNghiem.Size = new Size(200, 25);
            lblNghiem.TabIndex = 3;
            lblNghiem.Text = "Nghiệm của phương trình:";
            // 
            // txtA
            // 
            txtA.Location = new Point(130, 18);
            txtA.Name = "txtA";
            txtA.Size = new Size(120, 27);
            txtA.TabIndex = 4;
            // 
            // txtB
            // 
            txtB.Location = new Point(130, 53);
            txtB.Name = "txtB";
            txtB.Size = new Size(120, 27);
            txtB.TabIndex = 5;
            // 
            // txtC
            // 
            txtC.Location = new Point(130, 88);
            txtC.Name = "txtC";
            txtC.Size = new Size(120, 27);
            txtC.TabIndex = 6;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(290, 50);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(280, 115);
            txtKetQua.TabIndex = 7;
            // 
            // btnGiai
            // 
            btnGiai.Location = new Point(20, 130);
            btnGiai.Name = "btnGiai";
            btnGiai.Size = new Size(100, 35);
            btnGiai.TabIndex = 8;
            btnGiai.Text = "Giải";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(140, 130);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(100, 35);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Thoát";
            // 
            // Form1
            // 
            ClientSize = new Size(591, 214);
            Controls.Add(lblA);
            Controls.Add(lblB);
            Controls.Add(lblC);
            Controls.Add(lblNghiem);
            Controls.Add(txtA);
            Controls.Add(txtB);
            Controls.Add(txtC);
            Controls.Add(txtKetQua);
            Controls.Add(btnGiai);
            Controls.Add(btnThoat);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Giải phương trình bậc 2";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
