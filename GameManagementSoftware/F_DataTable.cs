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
    public partial class F_DataTable : Form
    {
        DataTable d;
        private string tieuDe;
        int page;
        bool isSelect;
        public int IdSelect {get;set;}
        public F_DataTable(string tieuDe, bool isSelect=false)
        {
            InitializeComponent();
            this.tieuDe = tieuDe;
            lbTieuDe.Text = tieuDe;
            page = 1;
            lbPage.Text = page + "";

            IdSelect = -1;
            this.isSelect = isSelect;

            loadData();
        }

        void loadData(string s=null)
        {
            if (s == null)
            {
                string truyVan = loadTruyVan();
                if (tieuDe == DataProvider.TieuDe_ItemTemPlate) truyVan+= " WHERE NAME LIKE '%"+tbTuKhoa.Text.Replace("'","")+"%'";
                if (tieuDe == DataProvider.TieuDe_ItemOptionTemPlate) truyVan += " WHERE NAME LIKE '%" + tbTuKhoa.Text.Replace("'", "") + "%'";

                //MessageBox.Show(truyVan);
                d = DataProvider.gI().ExecuteQuery(truyVan);
            }
            else
                
            d = DataProvider.gI().ExecuteQuery(s,string.IsNullOrWhiteSpace(tbTuKhoa.Text)?null: tbTuKhoa.Text);

            page = 1;
            showData();
        }

        void showData()
        {
            //if(d==null||d.Rows.Count<=0) return;

            int max=Math.Min(page*500,d.Rows.Count)-1;
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

        string loadTruyVan()
        {
            if (tieuDe == DataProvider.TieuDe_ItemTemPlate) return "SELECT * FROM item_template";
            if (tieuDe == DataProvider.TieuDe_ItemOptionTemPlate) return "SELECT * FROM item_option_template";

            return null;
        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string truyVan = loadTruyVan();
            truyVan += " where CAST(id AS CHAR) like '%" + tbID.Text + "%'";
            loadData(truyVan);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            page=Math.Max(page-1,1);
            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page = Math.Min(page + 1, d.Rows.Count/500+1);
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
            if (!isSelect) return;

            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                IdSelect = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                Close();
            }
            catch(Exception ex) { }
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            string truyVan = loadTruyVan();
            truyVan += " where CAST(id AS CHAR) like '%"+tbID.Text+"%'";
            loadData(truyVan);
        }
    }
}
