namespace DrawShapes
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.grpShape = new System.Windows.Forms.GroupBox();
            this.rdoEllipse = new System.Windows.Forms.RadioButton();
            this.rdoRectangle = new System.Windows.Forms.RadioButton();

            this.grpShape.SuspendLayout();
            this.SuspendLayout();

            
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Location = new System.Drawing.Point(12, 12);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(450, 380);
            this.panelCanvas.TabIndex = 0;
            // Gán sự kiện chuột và paint
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);

            //  grpShape: GroupBox chọn loại hình 
            this.grpShape.Controls.Add(this.rdoEllipse);
            this.grpShape.Controls.Add(this.rdoRectangle);
            this.grpShape.Location = new System.Drawing.Point(475, 12);
            this.grpShape.Name = "grpShape";
            this.grpShape.Size = new System.Drawing.Size(120, 80);
            this.grpShape.TabIndex = 1;
            this.grpShape.TabStop = false;
            this.grpShape.Text = "Shape";

            //  rdoEllipse: radio "Ellipse" 
            this.rdoEllipse.AutoSize = true;
            this.rdoEllipse.Location = new System.Drawing.Point(15, 22);
            this.rdoEllipse.Name = "rdoEllipse";
            this.rdoEllipse.Size = new System.Drawing.Size(65, 20);
            this.rdoEllipse.TabIndex = 0;
            this.rdoEllipse.Text = "Ellipse";

            //  rdoRectangle: radio "Rectangle" (mặc định) 
            this.rdoRectangle.AutoSize = true;
            this.rdoRectangle.Checked = true;   
            this.rdoRectangle.Location = new System.Drawing.Point(15, 48);
            this.rdoRectangle.Name = "rdoRectangle";
            this.rdoRectangle.Size = new System.Drawing.Size(90, 20);
            this.rdoRectangle.TabIndex = 1;
            this.rdoRectangle.TabStop = true;
            this.rdoRectangle.Text = "Rectangle";

            //  Form1 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 405);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.grpShape);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw Shapes";

            this.grpShape.ResumeLayout(false);
            this.grpShape.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo biến cho các control
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.GroupBox grpShape;
        private System.Windows.Forms.RadioButton rdoEllipse;
        private System.Windows.Forms.RadioButton rdoRectangle;
    }
}