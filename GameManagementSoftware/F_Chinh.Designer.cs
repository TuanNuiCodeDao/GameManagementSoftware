namespace GameManagementSoftware
{
    partial class F_Chinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Chinh));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TrangChuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.qLChucNangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyNhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchThôngSốToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyPhanLoaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyKhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyXeDangKyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qlLichSuNapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnGửiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnTong = new System.Windows.Forms.Panel();
            this.pnBody = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnTong.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrangChuToolStripMenuItem1,
            this.qLChucNangToolStripMenuItem,
            this.thoátToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1555, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // TrangChuToolStripMenuItem1
            // 
            this.TrangChuToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.TrangChuToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TrangChuToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangChuToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("TrangChuToolStripMenuItem1.Image")));
            this.TrangChuToolStripMenuItem1.Name = "TrangChuToolStripMenuItem1";
            this.TrangChuToolStripMenuItem1.Size = new System.Drawing.Size(140, 28);
            this.TrangChuToolStripMenuItem1.Text = "Trang chủ";
            this.TrangChuToolStripMenuItem1.Click += new System.EventHandler(this.TrangChuToolStripMenuItem1_Click);
            // 
            // qLChucNangToolStripMenuItem
            // 
            this.qLChucNangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýChứcVụToolStripMenuItem,
            this.qLyNhanVienToolStripMenuItem,
            this.qLyPhanLoaiToolStripMenuItem,
            this.qLyKhachHangToolStripMenuItem,
            this.qLyXeDangKyToolStripMenuItem,
            this.qlLichSuNapToolStripMenuItem,
            this.quảnLýHóaĐơnGửiToolStripMenuItem,
            this.quảnLýLươngToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.supperToolStripMenuItem});
            this.qLChucNangToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qLChucNangToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("qLChucNangToolStripMenuItem.Image")));
            this.qLChucNangToolStripMenuItem.Name = "qLChucNangToolStripMenuItem";
            this.qLChucNangToolStripMenuItem.Size = new System.Drawing.Size(148, 28);
            this.qLChucNangToolStripMenuItem.Text = "Chức năng";
            this.qLChucNangToolStripMenuItem.Click += new System.EventHandler(this.qLChucNangToolStripMenuItem_Click);
            // 
            // quảnLýChứcVụToolStripMenuItem
            // 
            this.quảnLýChứcVụToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.sửa_chữa;
            this.quảnLýChứcVụToolStripMenuItem.Name = "quảnLýChứcVụToolStripMenuItem";
            this.quảnLýChứcVụToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.quảnLýChứcVụToolStripMenuItem.Text = "Tạo List Items ngẫu nhiên";
            this.quảnLýChứcVụToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChứcVụToolStripMenuItem_Click);
            // 
            // qLyNhanVienToolStripMenuItem
            // 
            this.qLyNhanVienToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchItemToolStripMenuItem,
            this.danhSáchThôngSốToolStripMenuItem});
            this.qLyNhanVienToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.Nền_phần_mềm;
            this.qLyNhanVienToolStripMenuItem.Name = "qLyNhanVienToolStripMenuItem";
            this.qLyNhanVienToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.qLyNhanVienToolStripMenuItem.Text = "Quản lý Thông tin";
            this.qLyNhanVienToolStripMenuItem.Click += new System.EventHandler(this.qLyNhanVienToolStripMenuItem_Click);
            // 
            // danhSáchItemToolStripMenuItem
            // 
            this.danhSáchItemToolStripMenuItem.Name = "danhSáchItemToolStripMenuItem";
            this.danhSáchItemToolStripMenuItem.Size = new System.Drawing.Size(290, 28);
            this.danhSáchItemToolStripMenuItem.Text = "Danh sách Item";
            this.danhSáchItemToolStripMenuItem.Click += new System.EventHandler(this.danhSáchItemToolStripMenuItem_Click);
            // 
            // danhSáchThôngSốToolStripMenuItem
            // 
            this.danhSáchThôngSốToolStripMenuItem.Name = "danhSáchThôngSốToolStripMenuItem";
            this.danhSáchThôngSốToolStripMenuItem.Size = new System.Drawing.Size(290, 28);
            this.danhSáchThôngSốToolStripMenuItem.Text = "Danh sách Thông số";
            this.danhSáchThôngSốToolStripMenuItem.Click += new System.EventHandler(this.danhSáchThôngSốToolStripMenuItem_Click);
            // 
            // qLyPhanLoaiToolStripMenuItem
            // 
            this.qLyPhanLoaiToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.packup;
            this.qLyPhanLoaiToolStripMenuItem.Name = "qLyPhanLoaiToolStripMenuItem";
            this.qLyPhanLoaiToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.qLyPhanLoaiToolStripMenuItem.Text = "Thống kê Item";
            this.qLyPhanLoaiToolStripMenuItem.Click += new System.EventHandler(this.qLyPhanLoaiToolStripMenuItem_Click);
            // 
            // qLyKhachHangToolStripMenuItem
            // 
            this.qLyKhachHangToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.change;
            this.qLyKhachHangToolStripMenuItem.Name = "qLyKhachHangToolStripMenuItem";
            this.qLyKhachHangToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.qLyKhachHangToolStripMenuItem.Text = "Convert Part";
            this.qLyKhachHangToolStripMenuItem.Click += new System.EventHandler(this.qLyKhachHangToolStripMenuItem_Click);
            // 
            // qLyXeDangKyToolStripMenuItem
            // 
            this.qLyXeDangKyToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.Add;
            this.qLyXeDangKyToolStripMenuItem.Name = "qLyXeDangKyToolStripMenuItem";
            this.qLyXeDangKyToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.qLyXeDangKyToolStripMenuItem.Text = "Tạo quà TOP";
            this.qLyXeDangKyToolStripMenuItem.Click += new System.EventHandler(this.qLyXeDangKyToolStripMenuItem_Click);
            // 
            // qlLichSuNapToolStripMenuItem
            // 
            this.qlLichSuNapToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.quản_lý_bán_hàng;
            this.qlLichSuNapToolStripMenuItem.Name = "qlLichSuNapToolStripMenuItem";
            this.qlLichSuNapToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.qlLichSuNapToolStripMenuItem.Text = "Quản lý Table";
            this.qlLichSuNapToolStripMenuItem.Click += new System.EventHandler(this.qlLichSuNapToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnGửiToolStripMenuItem
            // 
            this.quảnLýHóaĐơnGửiToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.changeSever;
            this.quảnLýHóaĐơnGửiToolStripMenuItem.Name = "quảnLýHóaĐơnGửiToolStripMenuItem";
            this.quảnLýHóaĐơnGửiToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.quảnLýHóaĐơnGửiToolStripMenuItem.Text = "Chức năng đặc biệt";
            this.quảnLýHóaĐơnGửiToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnGửiToolStripMenuItem_Click);
            // 
            // quảnLýLươngToolStripMenuItem
            // 
            this.quảnLýLươngToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.GO;
            this.quảnLýLươngToolStripMenuItem.Name = "quảnLýLươngToolStripMenuItem";
            this.quảnLýLươngToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.quảnLýLươngToolStripMenuItem.Text = "Quản lý Task";
            this.quảnLýLươngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLươngToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.setting;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.settingToolStripMenuItem.Text = "Settings";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // supperToolStripMenuItem
            // 
            this.supperToolStripMenuItem.Image = global::GameManagementSoftware.Properties.Resources.Replace1;
            this.supperToolStripMenuItem.Name = "supperToolStripMenuItem";
            this.supperToolStripMenuItem.Size = new System.Drawing.Size(339, 28);
            this.supperToolStripMenuItem.Text = "Resize ảnh";
            this.supperToolStripMenuItem.Click += new System.EventHandler(this.supperToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem1
            // 
            this.thoátToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.thoátToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.thoátToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátToolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            this.thoátToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("thoátToolStripMenuItem1.Image")));
            this.thoátToolStripMenuItem1.Name = "thoátToolStripMenuItem1";
            this.thoátToolStripMenuItem1.Size = new System.Drawing.Size(99, 28);
            this.thoátToolStripMenuItem1.Text = "Thoát";
            this.thoátToolStripMenuItem1.Click += new System.EventHandler(this.thoátToolStripMenuItem1_Click);
            // 
            // pnTong
            // 
            this.pnTong.BackColor = System.Drawing.Color.Gray;
            this.pnTong.Controls.Add(this.pnBody);
            this.pnTong.Controls.Add(this.menuStrip1);
            this.pnTong.Location = new System.Drawing.Point(3, 2);
            this.pnTong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTong.Name = "pnTong";
            this.pnTong.Size = new System.Drawing.Size(1555, 783);
            this.pnTong.TabIndex = 1;
            // 
            // pnBody
            // 
            this.pnBody.BackColor = System.Drawing.Color.White;
            this.pnBody.Location = new System.Drawing.Point(11, 34);
            this.pnBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1533, 740);
            this.pnBody.TabIndex = 2;
            // 
            // F_Chinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 786);
            this.Controls.Add(this.pnTong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "F_Chinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Chinh_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnTong.ResumeLayout(false);
            this.pnTong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLươngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnGửiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qlLichSuNapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyXeDangKyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyKhachHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyPhanLoaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyNhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýChứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLChucNangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrangChuToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem1;
        private System.Windows.Forms.Panel pnTong;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.ToolStripMenuItem danhSáchItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchThôngSốToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supperToolStripMenuItem;
    }
}

