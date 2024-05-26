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
    public partial class F_QL_DataTable : Form
    {
        DataTable d;
        int page;
        public F_QL_DataTable()
        {
            InitializeComponent();
            loadCBTable();
            page = 1;
            lbPage.Text = page + "";

            loadData();
        }

        void loadCBTable()
        {
            DataTable d1 = DataProvider.gI().ExecuteQuery("SHOW TABLES FROM "+ DataProvider.database+ ";");
            cbTable.Items.Clear();
            foreach (DataRow dr in d1.Rows)
            {
                cbTable.Items.Add(dr["Tables_in_"+ DataProvider.database].ToString());
            }

            if (cbTable.Items.Count > 0) cbTable.Text = cbTable.Items[0].ToString();
        }

        void loadData()
        {
            string truyVan = "SELECT * FROM " + cbTable.Text;
            d = DataProvider.gI().ExecuteQuery(truyVan, string.IsNullOrWhiteSpace(tbTuKhoa.Text) ? null : tbTuKhoa.Text);

            page = 1;
            showData();
        }

        void showData()
        {
            //if(d==null||d.Rows.Count<=0) return;

            int max = Math.Min(page * 500, d.Rows.Count) - 1;
            lbPage.Text = page + "";

            DataTable clonedTable = d.Clone();

            int startRowIndex = Math.Max(0, (page - 1) * 500);
            for (int i = startRowIndex; i <= max; i++)
            {
                clonedTable.ImportRow(d.Rows[i]);
            }

            DataView dataView = new DataView(clonedTable);
            dgv.DataSource = dataView;
        }

        string loadDieuKien()
        {
            if (string.IsNullOrWhiteSpace(tbTuKhoa.Text)) return null;

            

            return null;
        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            page = Math.Max(page - 1, 1);
            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page = Math.Min(page + 1, d.Rows.Count / 500 + 1);
            showData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbTuKhoa.Text = "";
        }

        private void F_DataTable_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTieuDe.Text = "Danh sách thông tin bảng " + cbTable.Text;
            loadData();
        }
    }
}
