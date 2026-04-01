namespace TinhTienTaxi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Giải phóng tài nguyên khi form đóng
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Khai báo các control
            this.grpBangGia = new System.Windows.Forms.GroupBox();
            this.lblKm = new System.Windows.Forms.Label();
            this.txtKmInput = new System.Windows.Forms.TextBox();
            this.grpLoaiXe = new System.Windows.Forms.GroupBox();
            this.rdo7Cho = new System.Windows.Forms.RadioButton();
            this.rdo4Cho = new System.Windows.Forms.RadioButton();
            this.chkGiamGia = new System.Windows.Forms.CheckBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();

            //  GroupBox "Bảng giá" (bao toàn bộ form) 
            this.grpBangGia.SuspendLayout();
            this.grpLoaiXe.SuspendLayout();
            this.SuspendLayout();

            // --- grpBangGia ---
            this.grpBangGia.Controls.Add(this.lblKm);
            this.grpBangGia.Controls.Add(this.txtKmInput);
            this.grpBangGia.Controls.Add(this.grpLoaiXe);
            this.grpBangGia.Controls.Add(this.chkGiamGia);
            this.grpBangGia.Controls.Add(this.lblSoTien);
            this.grpBangGia.Controls.Add(this.lblResult);
            this.grpBangGia.Controls.Add(this.btnThoat);
            this.grpBangGia.Location = new System.Drawing.Point(12, 12);
            this.grpBangGia.Name = "grpBangGia";
            this.grpBangGia.Size = new System.Drawing.Size(410, 230);
            this.grpBangGia.TabIndex = 0;
            this.grpBangGia.TabStop = false;
            this.grpBangGia.Text = "Bảng giá";

            //  lblKm: nhãn "Quãng đường đi (km):" 
            this.lblKm.AutoSize = true;
            this.lblKm.Location = new System.Drawing.Point(20, 35);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(130, 16);
            this.lblKm.TabIndex = 0;
            this.lblKm.Text = "Quãng đường đi (km):";

            //  txtKmInput: ô nhập quãng đường 
            this.txtKmInput.Location = new System.Drawing.Point(220, 32);
            this.txtKmInput.Name = "txtKmInput";
            this.txtKmInput.Size = new System.Drawing.Size(160, 22);
            this.txtKmInput.TabIndex = 1;
            this.txtKmInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKmInput.TextChanged += new System.EventHandler(this.txtKmInput_TextChanged);

            //  grpLoaiXe: nhóm radio button loại xe 
            this.grpLoaiXe.Controls.Add(this.rdo7Cho);
            this.grpLoaiXe.Controls.Add(this.rdo4Cho);
            this.grpLoaiXe.Location = new System.Drawing.Point(20, 70);
            this.grpLoaiXe.Name = "grpLoaiXe";
            this.grpLoaiXe.Size = new System.Drawing.Size(230, 55);
            this.grpLoaiXe.TabIndex = 2;
            this.grpLoaiXe.TabStop = false;
            this.grpLoaiXe.Text = "Loại xe";

            //  rdo7Cho: radio "7 chỗ" 
            this.rdo7Cho.AutoSize = true;
            this.rdo7Cho.Checked = true;   // mặc định chọn 7 chỗ
            this.rdo7Cho.Location = new System.Drawing.Point(15, 22);
            this.rdo7Cho.Name = "rdo7Cho";
            this.rdo7Cho.Size = new System.Drawing.Size(65, 20);
            this.rdo7Cho.TabIndex = 0;
            this.rdo7Cho.TabStop = true;
            this.rdo7Cho.Text = "7 chỗ";
            this.rdo7Cho.CheckedChanged += new System.EventHandler(this.rdo7Cho_CheckedChanged);

            //  rdo4Cho: radio "4 chỗ" 
            this.rdo4Cho.AutoSize = true;
            this.rdo4Cho.Location = new System.Drawing.Point(110, 22);
            this.rdo4Cho.Name = "rdo4Cho";
            this.rdo4Cho.Size = new System.Drawing.Size(65, 20);
            this.rdo4Cho.TabIndex = 1;
            this.rdo4Cho.Text = "4 chỗ";
            this.rdo4Cho.CheckedChanged += new System.EventHandler(this.rdo4Cho_CheckedChanged);

            //  chkGiamGia: checkbox giảm giá 5% 
            this.chkGiamGia.AutoSize = true;
            this.chkGiamGia.Location = new System.Drawing.Point(265, 88);
            this.chkGiamGia.Name = "chkGiamGia";
            this.chkGiamGia.Size = new System.Drawing.Size(80, 20);
            this.chkGiamGia.TabIndex = 3;
            this.chkGiamGia.Text = "Giảm giá";
            this.chkGiamGia.CheckedChanged += new System.EventHandler(this.chkGiamGia_CheckedChanged);

            //  lblSoTien: nhãn "Số tiền thanh toán (VNĐ):" 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(20, 150);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(180, 16);
            this.lblSoTien.TabIndex = 4;
            this.lblSoTien.Text = "Số tiền thanh toán (VNĐ):";

            //  lblResult: hiển thị kết quả số tiền 
            this.lblResult.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(20, 178);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(260, 28);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "0";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);

            //  btnThoat: nút Thoát 
            this.btnThoat.Location = new System.Drawing.Point(295, 178);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 28);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //  Form1 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 255);
            this.Controls.Add(this.grpBangGia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính tiền taxi";

            this.grpLoaiXe.ResumeLayout(false);
            this.grpLoaiXe.PerformLayout();
            this.grpBangGia.ResumeLayout(false);
            this.grpBangGia.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo biến cho các control
        private System.Windows.Forms.GroupBox grpBangGia;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.TextBox txtKmInput;
        private System.Windows.Forms.GroupBox grpLoaiXe;
        private System.Windows.Forms.RadioButton rdo7Cho;
        private System.Windows.Forms.RadioButton rdo4Cho;
        private System.Windows.Forms.CheckBox chkGiamGia;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnThoat;
    }
}