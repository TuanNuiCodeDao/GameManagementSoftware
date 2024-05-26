using GameManagementSoftware.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManagementSoftware
{
    public partial class F_TaoQuaTOP : Form
    {
        ItemsNgauNhien i;
        string ketQua;
        bool isLoadItem = false;
        bool isLoadThongSo = false;

        public F_TaoQuaTOP()
        {
            InitializeComponent();
            i = new ItemsNgauNhien();
            ketQua = "";

            showThongTinListItem();
        }

        void showThongTinListItem()
        {
            isLoadItem = true;
            tbSTTItem.Text = "";

            int stt = 0;
            dgvItem.Rows.Clear();
            foreach (ItemNgauNhien it in i.ListItemNgauNhien)
            {
                stt++;
                dgvItem.Rows.Add(stt, it.ID, it.SoLuong, it.Name);
            }
            isLoadItem = false;
        }

        void showThongTinListThongSo()
        {
            int id = -1;
            try
            {
                id = int.Parse(tbSTTItem.Text);
            }
            catch (Exception ex)
            {
                return;
            }
            isLoadThongSo = true;
            ItemNgauNhien it = i.ListItemNgauNhien[id - 1];
            int stt = 0;
            dgvThongSo.Rows.Clear();
            foreach (ThongSo ts in it.ListThongSo)
            {
                stt++;
                dgvThongSo.Rows.Add(stt, ts.ID,ts.HeSo, ts.Name.Replace("#", ts.HeSo + ""));
            }
            isLoadThongSo = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_ShowText f = new F_ShowText(ketQua);
            f.ShowDialog();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    F_NhapInfoItemNgauNhien f1 = new F_NhapInfoItemNgauNhien(true, false);
                    f1.ShowDialog();

                    if (f1.DaThayDoi)
                    {
                        int index = int.Parse(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1;
                        ItemNgauNhien it = i.ListItemNgauNhien[index];
                        it.SoLuong = f1.SoLuong;
                        it.TiLe = f1.TiLe;

                        i.ListItemNgauNhien[index] = it;
                    }
                }
                else
                {
                    F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemTemPlate, true);
                    f.ShowDialog();
                    if (f.IdSelect == -1) return;

                    DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_template where id = " + f.IdSelect);
                    if (d == null) return;

                    ItemNgauNhien it = new ItemNgauNhien();
                    it.ID = f.IdSelect;
                    it.Name = d["name"].ToString();

                    F_NhapInfoItemNgauNhien f1 = new F_NhapInfoItemNgauNhien();
                    f1.ShowDialog();

                    it.SoLuong = f1.SoLuong;
                    it.TiLe = f1.TiLe;

                    int stt = int.Parse(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString());
                    i.ListItemNgauNhien.RemoveAt(stt - 1);

                    int id = 0;
                    while (id < i.ListItemNgauNhien.Count && it.TiLe < i.ListItemNgauNhien[id].TiLe) id++;

                    if (id >= i.ListItemNgauNhien.Count) i.ListItemNgauNhien.Add(it);
                    else i.ListItemNgauNhien.Insert(id, it);
                }

                showThongTinListItem();
            }
            catch { }
        }

        private void dgvThongSo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSTTItem.Text)) return;
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                int idIt = int.Parse(tbSTTItem.Text);

                if (e.ColumnIndex == 2)
                {
                    F_NhapHeSoThongSo f1 = new F_NhapHeSoThongSo(false);
                    f1.ShowDialog();

                    if (f1.DaThayDoi)
                    {
                        int index = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1;
                        ThongSo ts = i.ListItemNgauNhien[idIt - 1].ListThongSo[index];
                        ts.HeSo = f1.HeSo;
                        ts.HeSoMax = f1.HeSoMax;
                        ts.IsNgauNhien = ts.HeSo != ts.HeSoMax;

                        i.ListItemNgauNhien[idIt - 1].ListThongSo[index] = ts;
                    }
                }
                else
                {
                    F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemOptionTemPlate, true);
                    f.ShowDialog();
                    if (f.IdSelect == -1) return;

                    DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_option_template where id = " + f.IdSelect);
                    if (d == null) return;

                    ThongSo ts = new ThongSo();
                    ts.ID = f.IdSelect;
                    ts.Name = d["name"].ToString();

                    F_NhapHeSoThongSo f1 = new F_NhapHeSoThongSo(false);
                    f1.ShowDialog();

                    ts.HeSo = f1.HeSo;
                    ts.HeSoMax = f1.HeSoMax;
                    ts.IsNgauNhien = ts.HeSo != ts.HeSoMax;

                    int stt = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[0].Value.ToString());
                    i.ListItemNgauNhien[idIt - 1].ListThongSo[stt - 1] = ts;
                }

                showThongTinListThongSo();
            }
            catch { }
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                tbSTTItem.Text = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                showThongTinListThongSo();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemTemPlate, true);
            f.ShowDialog();
            if (f.IdSelect == -1) return;

            DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_template where id = " + f.IdSelect);
            if (d == null) return;

            ItemNgauNhien it = new ItemNgauNhien();
            it.ID = f.IdSelect;
            it.Name = d["name"].ToString();

            F_NhapInfoItemNgauNhien f1 = new F_NhapInfoItemNgauNhien(true, false);
            f1.ShowDialog();

            it.SoLuong = f1.SoLuong;
            it.TiLe = f1.TiLe;

            int id = 0;
            while (id < i.ListItemNgauNhien.Count && it.TiLe < i.ListItemNgauNhien[id].TiLe) id++;

            if (id >= i.ListItemNgauNhien.Count) i.ListItemNgauNhien.Add(it);
            else i.ListItemNgauNhien.Insert(id, it);

            showThongTinListItem();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSTTItem.Text)) return;
            F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemOptionTemPlate, true);
            f.ShowDialog();
            if (f.IdSelect == -1) return;

            DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_option_template where id = " + f.IdSelect);
            if (d == null) return;

            ThongSo ts = new ThongSo();
            ts.ID = f.IdSelect;
            ts.Name = d["name"].ToString();

            F_NhapHeSoThongSo f1 = new F_NhapHeSoThongSo(false);
            f1.ShowDialog();

            ts.HeSo = f1.HeSo;
            ts.HeSoMax = f1.HeSoMax;
            ts.IsNgauNhien = ts.HeSo != ts.HeSoMax;

            int idIt = int.Parse(tbSTTItem.Text);
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(ts);

            showThongTinListThongSo();
        }

        string tongHop()
        {
            string s = "[";

            bool k1 = false;
            foreach (ItemNgauNhien item in i.ListItemNgauNhien)
            {
                if (item.ID != -1)
                {
                    if (k1) s += ",";
                    k1 = true;
                    s += "\"[" + item.ID + "," + item.SoLuong + ",\\\"[";

                    bool k2 = false;
                    foreach (ThongSo io in item.ListThongSo)
                    {
                        if (k2) s += ",";
                        k2 = true;

                        s += "\\\\\\\"[" + io.ID + "," + io.HeSo + "]\\\\\\\"";
                    }

                    s += "]\\\",";
                    s += ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds) + "]\"";
                }
            }
            s += "]";

            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ketQua = tongHop();
            F_ShowText f = new F_ShowText(ketQua);
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            F_ShowText f = new F_ShowText(ketQua);
            f.ShowDialog();

            i = loadFromData(f.Text);
            showThongTinListItem();
            tbSTTItem.Text = "";
        }

        ItemsNgauNhien loadFromData(string s)
        {
            ItemsNgauNhien items = new ItemsNgauNhien();
            try
            {
                JArray dataArray = JArray.Parse(s);
                if (dataArray == null)
                    return null;

                foreach (var dataObject in dataArray)
                {
                    JArray dataItem = JArray.Parse(dataObject.ToString());
                    int tempId = int.Parse(dataItem[0].ToString());

                    if (tempId != -1)
                    {
                        ItemNgauNhien it = new ItemNgauNhien();
                        it.ID= tempId;
                        DataRow d1 = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_template where id = " + it.ID);
                        if (d1 == null) continue;
                        it.Name = d1["name"].ToString();
                        it.SoLuong=int.Parse(dataItem[1].ToString());

                        JArray options = JArray.Parse(dataItem[2].ToString().Replace("\"", ""));
                        if (options != null)
                        {
                            foreach (var option in options)
                            {
                                JArray opt = JArray.Parse(option.ToString());
                                ThongSo ts = new ThongSo();
                                ts.ID = int.Parse(opt[0].ToString());
                                DataRow d2 = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_option_template where id = " + ts.ID);
                                if (d2 == null) continue;

                                ts.Name = d2["name"].ToString();
                                ts.HeSo = int.Parse(opt[1].ToString());
                                it.ListThongSo.Add(ts);
                            }
                        }

                        items.ListItemNgauNhien.Add(it);
                    }
                }

                dataArray.Clear();

            }
            catch (Exception ex) { }

            return items;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSTTItem.Text)) return;

            try
            {
                int idIt = int.Parse(tbSTTItem.Text) - 1;
                if (idIt >= i.ListItemNgauNhien.Count) return;
                i.ListItemNgauNhien.RemoveAt(idIt);

                tbSTTItem.Text = "";

                showThongTinListItem();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSTTTS.Text)) return;
            if (string.IsNullOrEmpty(tbSTTItem.Text)) return;

            try
            {
                int idIt = int.Parse(tbSTTItem.Text) - 1;
                if (idIt >= i.ListItemNgauNhien.Count) return;
                int idTs = int.Parse(tbSTTTS.Text) - 1;
                if (idTs >= i.ListItemNgauNhien[idIt].ListThongSo.Count) return;
                i.ListItemNgauNhien[idIt].ListThongSo.RemoveAt(idTs);

                tbSTTTS.Text = "";

                showThongTinListThongSo();
            }
            catch { }
        }

        private void dgvThongSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                tbSTTTS.Text = dgvThongSo.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThongSo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoadThongSo) return;

            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                if (string.IsNullOrEmpty(tbSTTItem.Text)) return;
                int idIt = int.Parse(tbSTTItem.Text) - 1;
                if (idIt >= i.ListItemNgauNhien.Count) return;

                int idTs = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1;
                if (idTs >= i.ListItemNgauNhien[idIt].ListThongSo.Count) return;

                if (e.ColumnIndex == 1)
                {
                    ThongSo ts = i.ListItemNgauNhien[idIt].ListThongSo[idTs];

                    int id = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[1].Value.ToString());
                    ts.ID = id;
                    DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_option_template where id = " + ts.ID);
                    if (d == null) return;

                    ts.Name = d["name"].ToString();
                    i.ListItemNgauNhien[idIt].ListThongSo[idTs] = ts;
                }
                else if (e.ColumnIndex == 2)
                {
                    ThongSo ts = i.ListItemNgauNhien[idIt].ListThongSo[idTs];

                    int heSo = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[2].Value.ToString());
                    ts.HeSo = heSo;
                    ts.HeSoMax = heSo;
                    i.ListItemNgauNhien[idIt].ListThongSo[idTs] = ts;
                }
                else return;

                showThongTinListThongSo();
            }
            catch { }
        }

        private void dgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoadItem) return;

            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                int idIt = int.Parse(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1;
                if (idIt >= i.ListItemNgauNhien.Count) return;

                if (e.ColumnIndex == 1)
                {
                    ItemNgauNhien it = i.ListItemNgauNhien[idIt];

                    int id = int.Parse(dgvItem.Rows[e.RowIndex].Cells[1].Value.ToString());
                    it.ID = id;
                    DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_template where id = " + it.ID);
                    if (d == null) return;

                    it.Name = d["name"].ToString();
                    i.ListItemNgauNhien[idIt] = it;
                }
                else if (e.ColumnIndex == 2)
                {
                    ItemNgauNhien it = i.ListItemNgauNhien[idIt];

                    int id = int.Parse(dgvItem.Rows[e.RowIndex].Cells[2].Value.ToString());
                    it.SoLuong = id;
                    i.ListItemNgauNhien[idIt] = it;
                }
                else if (e.ColumnIndex == 3)
                {
                    ItemNgauNhien it = i.ListItemNgauNhien[idIt];

                    int id = int.Parse(dgvItem.Rows[e.RowIndex].Cells[3].Value.ToString());
                    it.TiLe = id;
                    i.ListItemNgauNhien.RemoveAt(idIt);

                    int index = 0;
                    while (index < i.ListItemNgauNhien.Count && it.TiLe < i.ListItemNgauNhien[index].TiLe) index++;

                    if (index >= i.ListItemNgauNhien.Count) i.ListItemNgauNhien.Add(it);
                    else i.ListItemNgauNhien.Insert(index, it);
                }
                else return;

                showThongTinListItem();
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSTTItem.Text)) return;

            int idIt = int.Parse(tbSTTItem.Text);
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(50, "Sức đánh+#%", true, 1, 1));
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(77, "HP+#%", true, 1, 1));
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(103, "KI +#%", true, 1, 1));
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(93, "HSD # ngày", true, 1, 1));

            showThongTinListThongSo();
        }

        private void F_TaoQuaTOP_Load(object sender, EventArgs e)
        {

        }
    }
}
