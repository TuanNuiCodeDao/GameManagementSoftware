using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManagementSoftware
{
    public partial class F_Chinh : Form
    {
        private Form formCon;
        public F_Chinh()
        {
            InitializeComponent();
            load();
        }

        void load()
        {
           // if (true) return;
            try
            {
                string id = S_DataProvider.gI().ExecuteQuery_Row("SELECT * FROM ghichu WHERE id=1;")["data"].ToString();
                if (id == "0") OpenChildForm(new F_TrangChu());
                else if (id == "1") OpenChildForm(new F_TaoItemsNgauNhien());
                else if (id == "2") OpenChildForm(new F_TrangChu());
                else if (id == "3") OpenChildForm(new F_ThongKeItem());
                else if (id == "4") OpenChildForm(new F_ConvertPart());
                else if (id == "5") OpenChildForm(new F_TaoQuaTOP());
                else if (id == "6") OpenChildForm(new F_QL_DataTable());
                else if (id == "7") OpenChildForm(new F_ChucNangDacBiet());
                else if (id == "8") OpenChildForm(new F_QL_Task());
                else if (id == "9") OpenChildForm(new F_DataTable(DataProvider.TieuDe_ItemTemPlate));
                else if (id == "10") OpenChildForm(new F_DataTable(DataProvider.TieuDe_ItemOptionTemPlate));
                //else if (id == "11") OpenChildForm(new F_TaoItemNgauNhien_S());
                else OpenChildForm(new F_TrangChu());
            }
            catch (Exception e)
            {
                MessageBox.Show("Cơ sở dữ liệu không phù hợp !", "Thông báo");
                F_Setting f = new F_Setting();
                f.ShowDialog();
            }
        }

        private void OpenChildForm(Form childForm)
        {
            try
            {
                if (formCon != null)
                {
                    formCon.Close();
                }
                formCon = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pnBody.Controls.Add(childForm);
                pnBody.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }catch(Exception e)
            {
                MessageBox.Show("Cơ sở dữ liệu không phù hợp !", "Thông báo");
                F_Setting f = new F_Setting();
                f.ShowDialog();
            }
        }

        void updateTableOpen(int i)
        {
            S_DataProvider.gI().ExecuteQuery("UPDATE ghichu set data= '"+i+"'  where id=1;");
        }

        private void quảnLýChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(1);
            OpenChildForm(new F_TaoItemsNgauNhien());
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Chinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát chương trình ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void TrangChuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateTableOpen(0);
            OpenChildForm(new F_TrangChu());
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void danhSáchItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(9);
            OpenChildForm(new F_DataTable(DataProvider.TieuDe_ItemTemPlate));
        }

        private void danhSáchThôngSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(10);
            OpenChildForm(new F_DataTable(DataProvider.TieuDe_ItemOptionTemPlate));
        }

        private void qLyPhanLoaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(3);
            OpenChildForm(new F_ThongKeItem());
        }

        private void qLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(4);
            OpenChildForm(new F_ConvertPart());
        }

        private void qLyXeDangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(5);
            OpenChildForm(new F_TaoQuaTOP());
        }

        private void qlLichSuNapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(6);
            OpenChildForm(new F_QL_DataTable());
        }

        private void quảnLýHóaĐơnGửiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(7);
            OpenChildForm(new F_ChucNangDacBiet());
        }

        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTableOpen(8);
            OpenChildForm(new F_QL_Task());
        }

        private void qLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Setting f=new F_Setting();
            f.ShowDialog();
        }

        private void tạoListItemMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void resizeẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ResizeAnh f=new F_ResizeAnh();
            f.ShowDialog();
        }

        private void qLChucNangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ResizeAnh f = new F_ResizeAnh();
            f.ShowDialog();
        }
    }
}
