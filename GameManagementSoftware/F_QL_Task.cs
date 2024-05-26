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
    public partial class F_QL_Task : Form
    {
        public F_QL_Task()
        {
            InitializeComponent();
            load();
            tbNoiDung.MouseWheel += tbCu_MouseWheel;
        }
        private void tbCu_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            if (delta > 0) tbNoiDung.Font = new Font(tbNoiDung.Font.FontFamily, tbNoiDung.Font.Size + 1, tbNoiDung.Font.Style);
            else tbNoiDung.Font = new Font(tbNoiDung.Font.FontFamily, tbNoiDung.Font.Size - 1, tbNoiDung.Font.Style);
        }

        void load()
        {
            loadCBTrangThai();
            loadData();
        }
        void loadData()
        {
            DataTable d = S_DataProvider.gI().ExecuteQuery("SELECT * FROM task ORDER BY trangthai ASC;");
            int stt = 0;
            dgv.Rows.Clear();
            foreach (DataRow r in d.Rows)
            {
                stt++;
                dgv.Rows.Add(stt, (int)r["id"], ((DateTime)r["time"]).ToString("dd/MM/yyyy HH:mm"), (int)r["trangthai"] == 0 ? "Đang tiến hành" : "Đã hoàn thành",
                    r["chude"].ToString(), r["noidung"].ToString());
            }
        }

        void loadCBTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Đang tiến hành");
            cbTrangThai.Items.Add("Đã hoàn thành");
            cbTrangThai.Text="Đang tiến hành";
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChuDe.Text))
            {
                MessageBox.Show("Chủ đề không được để trống","Thông báo");
                return;
            }

            if (S_DataProvider.gI().ExecuteQuery_None("SELECT COUNT(*) as ketqua FROM task WHERE chude like '" + tbChuDe.Text+"';")>0)
            {
                MessageBox.Show("Chủ đề đã tồn tại", "Thông báo");
                return;
            }

            S_DataProvider.gI().ExecuteQuery("INSERT INTO task(chude,noidung) VALUES('"+tbChuDe.Text+"','"+tbNoiDung.Text+"');");

            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChuDe.Text))
            {
                MessageBox.Show("Chủ đề không được để trống", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("Hãy chọn tiến trình cần sửa trước !", "Nhắc nhở");
                return;
            }
            DataRow r = S_DataProvider.gI().ExecuteQuery_Row("SELECT * from task where id=" + tbID.Text);
            if (r == null)
            {
                MessageBox.Show("Hãy chọn tiến trình cần sửa trước !", "Nhắc nhở");
                return;
            }

            if (S_DataProvider.gI().ExecuteQuery_None("SELECT COUNT(*) as ketqua FROM task WHERE chude like '" + tbChuDe.Text + "'  AND id!="+tbID.Text+";") > 0)
            {
                MessageBox.Show("Chủ đề đã tồn tại", "Thông báo");
                return;
            }

            S_DataProvider.gI().ExecuteQuery("UPDATE task SET chude='"+tbChuDe.Text+"',noidung='"
                +tbNoiDung.Text+"',trangthai="+(cbTrangThai.Text== "Đang tiến hành"?0:1) +" where id=" + tbID.Text);
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("Hãy chọn tiến trình cần xóa trước !", "Nhắc nhở");
                return;
            }
            DataRow r = S_DataProvider.gI().ExecuteQuery_Row("SELECT chude from task where id=" + tbID.Text);
            if (r==null)
            {
                MessageBox.Show("Hãy chọn tiến trình cần xóa trước !", "Nhắc nhở");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa tiến trình '" + r["chude"].ToString() + "' ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                S_DataProvider.gI().ExecuteQuery_Row("DELETE from task where id=" + tbID.Text);
                tbID.Text = "";
                loadData();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbID.Text = Convert.ToString(dgv.Rows[e.RowIndex].Cells[1].Value);
                tbTime.Text = Convert.ToString(dgv.Rows[e.RowIndex].Cells[2].Value);
                cbTrangThai.Text = Convert.ToString(dgv.Rows[e.RowIndex].Cells[3].Value);
                tbChuDe.Text = Convert.ToString(dgv.Rows[e.RowIndex].Cells[4].Value);
                tbNoiDung.Text = Convert.ToString(dgv.Rows[e.RowIndex].Cells[5].Value);
            }
            catch
            {
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbTrangThai.Text == "Đang tiến hành") cbTrangThai.ForeColor = Color.OrangeRed;
            //else cbTrangThai.ForeColor = Color.Green;
        }

        private void cbTrangThai_TextChanged(object sender, EventArgs e)
        {
            //if(cbTrangThai.Text== "Đang tiến hành") cbTrangThai.BackColor = Color.OrangeRed;
            //else cbTrangThai.BackColor = Color.Green;
        }
    }
}
