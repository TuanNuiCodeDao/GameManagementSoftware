using GameManagementSoftware.DTO;
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
    public partial class F_TaoItemsNgauNhien : Form
    {
        ItemsNgauNhien i;
        string ketQua;
        bool isLoadItem = false;
        bool isLoadThongSo = false;

        public F_TaoItemsNgauNhien()
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
            int tong = 0;
            foreach (ItemNgauNhien it in i.ListItemNgauNhien)
            {
                stt++;
                tong += it.TiLe;
                dgvItem.Rows.Add(stt, it.ID, it.SoLuong, it.TiLe, it.Name);
            }

            tbHeSoTiLe.Text = tong+"";
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
                dgvThongSo.Rows.Add(stt, ts.ID,ts.HeSo,ts.HeSoMax, ts.Name.Replace("#", (ts.IsNgauNhien ? (" (Từ " + ts.HeSo + " đến " + ts.HeSoMax + ") ") : " " + ts.HeSo + " ")));
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

                if (e.ColumnIndex == 2|| e.ColumnIndex == 3)
                {
                    F_NhapInfoItemNgauNhien f1 = new F_NhapInfoItemNgauNhien();
                    f1.ShowDialog();

                    if (f1.DaThayDoi)
                    {
                        int index = int.Parse(dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString())-1;
                        ItemNgauNhien it = i.ListItemNgauNhien[index];
                        it.SoLuong = f1.SoLuong;
                        it.TiLe= f1.TiLe;

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
                    F_NhapHeSoThongSo f1 = new F_NhapHeSoThongSo();
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

                    F_NhapHeSoThongSo f1 = new F_NhapHeSoThongSo();
                    f1.ShowDialog();

                    ts.HeSo = f1.HeSo;
                    ts.HeSoMax = f1.HeSoMax;
                    ts.IsNgauNhien = ts.HeSo != ts.HeSoMax;

                    int stt = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[0].Value.ToString());
                    i.ListItemNgauNhien[idIt-1].ListThongSo[stt - 1] = ts;
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

            F_NhapInfoItemNgauNhien f1 = new F_NhapInfoItemNgauNhien();
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
            if(string.IsNullOrEmpty(tbSTTItem.Text)) return;
            F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemOptionTemPlate, true);
            f.ShowDialog();
            if (f.IdSelect == -1) return;

            DataRow d = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_option_template where id = " + f.IdSelect);
            if (d == null) return;

            ThongSo ts = new ThongSo();
            ts.ID = f.IdSelect;
            ts.Name = d["name"].ToString();

            F_NhapHeSoThongSo f1 = new F_NhapHeSoThongSo();
            f1.ShowDialog();

            ts.HeSo = f1.HeSo;
            ts.HeSoMax = f1.HeSoMax;
            ts.IsNgauNhien = ts.HeSo != ts.HeSoMax;

            int idIt = int.Parse(tbSTTItem.Text);
            i.ListItemNgauNhien[idIt-1].ListThongSo.Add(ts);

            showThongTinListThongSo();
        }

        string tongHop()
        {
            string s = "";
            foreach(ItemNgauNhien it in i.ListItemNgauNhien)
            {
                if (!string.IsNullOrWhiteSpace(s)) s += "...";
                s += it.ID + " " + it.SoLuong + " " + it.TiLe + "$";
                bool isHas = false;
                foreach(ThongSo ts in it.ListThongSo)
                {
                    if (isHas) s += ",";
                    s += ts.ID + " " + ts.HeSo;
                    if (ts.IsNgauNhien) s += "->" + ts.HeSoMax;
                    isHas = true;
                }
            }

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
                string[] s2 = s.Split(new string[] { "..." }, StringSplitOptions.None);
                foreach (string s3 in s2)
                {
                    string[] s4 = s3.Split(new string[] { "$" },2, StringSplitOptions.None);
                    //if(s4==null||s4.Length<1)
                    ItemNgauNhien it= new ItemNgauNhien();
                    string[] s5 = s4[0].Split(new string[] { " " }, StringSplitOptions.None);
                    it.ID = int.Parse(s5[0]);
                    it.SoLuong = int.Parse(s5[1]);
                    it.TiLe = int.Parse(s5[2]);
                    DataRow d1 = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_template where id = " + it.ID);
                    if (d1 == null) continue;
                    it.Name = d1["name"].ToString();

                    string[] s6 = s4[1].Split(new string[] { "," }, StringSplitOptions.None);
                    foreach(string s7 in s6)
                    {
                        if(string.IsNullOrEmpty(s7)) continue;
                        string[] s8 = s7.Split(new string[] { " " }, StringSplitOptions.None);
                        ThongSo ts=new ThongSo();
                        ts.ID= int.Parse(s8[0]);
                        DataRow d2 = DataProvider.gI().ExecuteQuery_Row("SELECT name from item_option_template where id = " + ts.ID);
                        if (d2 == null) continue;
                        ts.Name = d2["name"].ToString();

                        string[] s9 = s8[1].Split(new string[] { "->" }, StringSplitOptions.None);
                        if (s9.Length == 2)
                        {
                            ts.IsNgauNhien = true;
                            ts.HeSo = int.Parse(s9[0]);
                            ts.HeSoMax = int.Parse(s9[1]);
                        }
                        else
                        {
                            ts.IsNgauNhien = false;
                            ts.HeSo = int.Parse(s9[0]);
                        }

                        it.ListThongSo.Add(ts);
                    }

                    int id = 0;
                    while (id < items.ListItemNgauNhien.Count && it.TiLe < items.ListItemNgauNhien[id].TiLe) id++;

                    if (id >= items.ListItemNgauNhien.Count) items.ListItemNgauNhien.Add(it);
                    else items.ListItemNgauNhien.Insert(id, it);
                }
            }catch (Exception ex) { }

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
                int idIt = int.Parse(tbSTTItem.Text)-1;
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

                    int min = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[2].Value.ToString());
                    ts.HeSo = min;
                    if (ts.HeSoMax < ts.HeSo) ts.HeSoMax= ts.HeSo;
                    i.ListItemNgauNhien[idIt].ListThongSo[idTs] = ts;
                }
                else if (e.ColumnIndex == 3)
                {
                    ThongSo ts = i.ListItemNgauNhien[idIt].ListThongSo[idTs];

                    int max = int.Parse(dgvThongSo.Rows[e.RowIndex].Cells[3].Value.ToString());
                    ts.HeSoMax = max;
                    if (ts.HeSoMax < ts.HeSo) ts.HeSo=ts.HeSoMax;
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
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(50, "Sức đánh+#%", true,1,1));
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(77, "HP+#%", true, 1, 1));
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(103, "KI +#%", true, 1, 1));
            i.ListItemNgauNhien[idIt - 1].ListThongSo.Add(new ThongSo(93, "HSD # ngày", true, 1, 1));

            showThongTinListThongSo();
        }
    }
}
