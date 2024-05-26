namespace GameManagementSoftware
{
    partial class F_NhapInfoItemNgauNhien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_NhapInfoItemNgauNhien));
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.nudTiLe = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiLe)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(244, 12);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(175, 30);
            this.nudSoLuong.TabIndex = 131;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.nudSoLuong_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(29, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 24);
            this.label20.TabIndex = 130;
            this.label20.Text = "Số lượng";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(292, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 37);
            this.button2.TabIndex = 129;
            this.button2.Text = "Xong";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nudTiLe
            // 
            this.nudTiLe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTiLe.Location = new System.Drawing.Point(244, 48);
            this.nudTiLe.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudTiLe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTiLe.Name = "nudTiLe";
            this.nudTiLe.Size = new System.Drawing.Size(175, 30);
            this.nudTiLe.TabIndex = 133;
            this.nudTiLe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTiLe.ValueChanged += new System.EventHandler(this.nudTiLe_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 132;
            this.label1.Text = "Tỉ lệ";
            // 
            // F_NhapInfoItemNgauNhien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(464, 142);
            this.Controls.Add(this.nudTiLe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_NhapInfoItemNgauNhien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin Item ngẫu nhiên";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTiLe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudTiLe;
        private System.Windows.Forms.Label label1;
    }
}