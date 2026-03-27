namespace Bai5._1_HinhTron
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblBanKinh;
        private System.Windows.Forms.TextBox txtBanKinh;
        private System.Windows.Forms.Button btnChuVi, btnDienTich, btnThoat;
        private System.Windows.Forms.TextBox txtKetQua;

        private void InitializeComponent()
        {
            lblBanKinh = new Label();
            txtBanKinh = new TextBox();
            btnChuVi = new Button();
            btnDienTich = new Button();
            btnThoat = new Button();
            txtKetQua = new TextBox();
            SuspendLayout();
            // 
            // lblBanKinh
            // 
            lblBanKinh.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblBanKinh.Location = new Point(36, 30);
            lblBanKinh.Name = "lblBanKinh";
            lblBanKinh.Size = new Size(250, 30);
            lblBanKinh.TabIndex = 0;
            lblBanKinh.Text = "Nhập bán kính hình tròn:";
            lblBanKinh.Click += lblBanKinh_Click;
            // 
            // txtBanKinh
            // 
            txtBanKinh.Font = new Font("Arial", 12F);
            txtBanKinh.Location = new Point(308, 27);
            txtBanKinh.Name = "txtBanKinh";
            txtBanKinh.Size = new Size(244, 30);
            txtBanKinh.TabIndex = 1;
            txtBanKinh.TextChanged += txtBanKinh_TextChanged;
            // 
            // btnChuVi
            // 
            btnChuVi.Location = new Point(56, 80);
            btnChuVi.Name = "btnChuVi";
            btnChuVi.Size = new Size(140, 40);
            btnChuVi.TabIndex = 2;
            btnChuVi.Text = "Chu vi";
            // 
            // btnDienTich
            // 
            btnDienTich.Location = new Point(248, 80);
            btnDienTich.Name = "btnDienTich";
            btnDienTich.Size = new Size(140, 40);
            btnDienTich.TabIndex = 3;
            btnDienTich.Text = "Diện tích";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(480, 80);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(140, 40);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            // 
            // txtKetQua
            // 
            txtKetQua.Font = new Font("Arial", 12F);
            txtKetQua.Location = new Point(20, 140);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(600, 100);
            txtKetQua.TabIndex = 5;
            // 
            // Form1
            // 
            ClientSize = new Size(660, 280);
            Controls.Add(lblBanKinh);
            Controls.Add(txtBanKinh);
            Controls.Add(btnChuVi);
            Controls.Add(btnDienTich);
            Controls.Add(btnThoat);
            Controls.Add(txtKetQua);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Tính chu vi, diện tích hình tròn";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
