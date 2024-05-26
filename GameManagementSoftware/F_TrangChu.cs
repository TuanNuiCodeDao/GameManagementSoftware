using GameManagementSoftware.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace GameManagementSoftware
{
    public partial class F_TrangChu : Form
    {
        private int page = 1;
        private int maxPage = 1;
        private long tong = 0;
        private List<InfoThongKe> lInfo;
        public F_TrangChu()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            DataTable d = DataProvider.gI().ExecuteQuery("SELECT * FROM player;");
            readData(d);
            showData();
            tbSoLuongAcc.Text = DataProvider.i.getDinhDanhHangNghin(DataProvider.i.ExecuteQuery_None("Select count(*) as ketqua from account;"));
            tbSoLuongAccMTV.Text = DataProvider.i.getDinhDanhHangNghin(DataProvider.i.ExecuteQuery_None("Select count(*) as ketqua from account where active=1;"));
            tbSoLuongNguoiChoi.Text = DataProvider.i.getDinhDanhHangNghin(DataProvider.i.ExecuteQuery_None("Select count(*) as ketqua from player;"));
            tbTongNap.Text = DataProvider.i.getDinhDanhHangNghin(DataProvider.i.ExecuteQuery_None("Select sum(tongnap) as ketqua from account;"));
            tbTongDu.Text = DataProvider.i.getDinhDanhHangNghin(DataProvider.i.ExecuteQuery_None("Select sum(vnd) as ketqua from account;"));
            //tbSoLuongNguoiChoi.Text = DataProvider.i.getDinhDanhHangNghin(DataProvider.i.ExecuteQuery_None("Select count(*) as ketqua from player;"));
        }

        int tinhSoLuongWin(string s)
        {
            int soLuong = 0;
            JArray dataArray = JArray.Parse(s);
            foreach (JObject dataObject in dataArray)
            {
                int tempId = Convert.ToInt16(dataObject["temp_id"]);
                if (tempId == 457)
                {
                    soLuong += Convert.ToInt32(dataObject["quantity"]);
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
                if (tempId == 457)
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

            foreach (DataRow d in data.Rows)
            {
                int soLuong = tinhSoLuong(d["items_body"].ToString());
                soLuong += tinhSoLuong(d["items_bag"].ToString());
                soLuong += tinhSoLuong(d["items_box"].ToString());

                if (soLuong == 0) continue;
                InfoThongKe info = new InfoThongKe((int)d["id"], (int)d["account_id"], d["name"].ToString(), soLuong);
                tong += soLuong;
                int id = 0;
                while (id < lInfo.Count && info.SoLuong < lInfo[id].SoLuong) id++;

                if (id >= lInfo.Count) lInfo.Add(info);
                else lInfo.Insert(id, info);
            }
        }

        private void F_TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void showData()
        {
            dgv.Rows.Clear();
            if (lInfo == null) return;

            int max = Math.Min(page * 500, lInfo.Count) - 1;
            lbPage.Text = page + "/" + maxPage;
            tbSoThoiVang.Text = tong + "";

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
    }
}
