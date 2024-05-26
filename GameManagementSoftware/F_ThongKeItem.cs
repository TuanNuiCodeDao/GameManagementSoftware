using GameManagementSoftware.DTO;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GameManagementSoftware
{
    public partial class F_ThongKeItem : Form
    {
        private int id=0;
        private int page = 1;
        private int maxPage = 1;
        private long tong = 0;
        private List<InfoThongKe> lInfo;
        public F_ThongKeItem()
        {
            InitializeComponent();
            lbPage.Text = "1/1";
            tbTongSoLuong.Text = tong + "";
            lInfo=new List<InfoThongKe>();
        }

        private void F_ThongKeItem_Load(object sender, EventArgs e)
        {

        }

        void showData()
        {
            dgv.Rows.Clear();
            if(lInfo == null) return;

            int max = Math.Min(page * 500, lInfo.Count) - 1;
            lbPage.Text = page + "/"+ maxPage;
            tbTongSoLuong.Text = tong + "";

            int startRowIndex = Math.Max(0, (page - 1) * 500);
            for (int i = startRowIndex; i <= max; i++)
            {
                dgv.Rows.Add(i + 1, lInfo[i].IDPlayer, lInfo[i].IDAccount, lInfo[i].Name, lInfo[i].SoLuong);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page = Math.Max(page - 1, 1);
            showData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            page = Math.Min(page + 1, lInfo.Count / 500 + 1);
            showData();
        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbTuKhoa.Text = "";
        }

        private void checkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        string loadTruyVan()
        {
            string s = "SELECT * FROM player WHERE CAST(id AS CHAR) like '%" + 
                tbTuKhoa.Text + "%' OR CAST(account_id AS CHAR) like '%" +tbTuKhoa.Text.Replace("'","") + "%' OR name like '%"+tbTuKhoa.Text.Replace("'","")+"%'";

            return s;
        }

        int tinhSoLuongWin(string s)
        {
            int soLuong = 0;
            JArray dataArray = JArray.Parse(s);
            foreach (JObject dataObject in dataArray)
            {
                int tempId = Convert.ToInt16(dataObject["temp_id"]);
                if (tempId == id)
                {
                    soLuong+= Convert.ToInt32(dataObject["quantity"]);
                }

            }
            dataArray.Clear();

            return soLuong;
        }

        int tinhSoLuong(string s)
        {
            if (DataProvider.dangThongKe == "Mới") return tinhSoLuongWin(s);

            int soLuong = 0;
            JArray dataArray = JArray.Parse(s);
            foreach (JToken dataToken in dataArray)
            {
                JArray dataItem = JArray.Parse(dataToken.ToString());
                int tempId = Convert.ToInt16(dataItem[0]);
                if (tempId == id)
                {
                    soLuong += Convert.ToInt32(dataItem[1]);
                }
            }
            dataArray.Clear();


            return soLuong;
        }

        void readData(DataTable data)
        {
            lInfo = new List<InfoThongKe>();
            tong = 0;
            if (data == null) return;

            foreach(DataRow d in data.Rows)
            {
                int soLuong = tinhSoLuong(d["items_body"].ToString());
                soLuong += tinhSoLuong(d["items_bag"].ToString());
                soLuong += tinhSoLuong(d["items_box"].ToString());

                if (soLuong == 0) continue;
                InfoThongKe info = new InfoThongKe((int)d["id"], (int)d["account_id"], d["name"].ToString(),soLuong);
                tong += soLuong;

                int id = 0;
                while (id < lInfo.Count && info.SoLuong < lInfo[id].SoLuong) id++;

                if (id >= lInfo.Count) lInfo.Add(info);
                else lInfo.Insert(id, info);
            }
        }

        void loadData()
        {
            try
            {
                DataTable d = DataProvider.gI().ExecuteQuery(loadTruyVan());
                readData(d);
                page = 1;
                maxPage = lInfo.Count / 500 + 1;
                showData();
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
            }
        }

        private void tbItem_TextChanged(object sender, EventArgs e)
        {
            id = int.Parse(tbItem.Text);

            loadData();
        }

        private void tbItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemTemPlate, true);
            f.ShowDialog();
            if (f.IdSelect == -1) return;

            tbItem.Text = f.IdSelect+"";
        }
    }
}
