using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameManagementSoftware.DTO;
using Newtonsoft.Json.Linq;

namespace GameManagementSoftware
{
    public partial class F_ChucNangDacBiet : Form
    {
        public F_ChucNangDacBiet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa các tài khoản trống !", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataProvider.i.ExecuteQuery("DELETE FROM account WHERE NOT EXISTS (SELECT * FROM PLAYER WHERE player.account_id=account.id);");
                MessageBox.Show("Đã xóa thành công !","Thông báo");
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_DataTable f = new F_DataTable(DataProvider.TieuDe_ItemTemPlate, true);
            f.ShowDialog();
            if (f.IdSelect == -1) return;

            int id= f.IdSelect;
            string name = "";
            DataRow d1 = DataProvider.i.ExecuteQuery_Row("SELECT * FROM item_template WHERE id=" + id);
            if (d1 == null) return;
            name = (string)d1["name"];

            if (MessageBox.Show("Xác nhận thu hồi item "+name+" !", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataTable dt= DataProvider.i.ExecuteQuery("SELECT * FROM player");
                ThuHoi(dt,id);
                DataProvider.i.ExecuteQuery("DELETE FROM account WHERE NOT EXISTS (SELECT * FROM PLAYER WHERE player.account_id=account.id);");
                MessageBox.Show("Thu hồi item thành công !", "Thông báo");
            }
        }

        ItemsNgauNhien docData(string s,int id)
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

                    if(tempId== id)
                    {
                        ItemNgauNhien it = new ItemNgauNhien();
                        it.ID = -1;
                        it.SoLuong = 0;
                        it.ListThongSo = new List<ThongSo>();
                        it.TimeTAO = long.Parse(dataItem[3].ToString());

                        items.ListItemNgauNhien.Add(it);

                    }
                    else {
                        ItemNgauNhien it = new ItemNgauNhien();
                        it.ID = tempId;
                        it.SoLuong = int.Parse(dataItem[1].ToString());

                        JArray options = JArray.Parse(dataItem[2].ToString().Replace("\"", ""));
                        if (options != null)
                        {
                            foreach (var option in options)
                            {
                                JArray opt = JArray.Parse(option.ToString());
                                ThongSo ts = new ThongSo();
                                ts.ID = int.Parse(opt[0].ToString());
                                ts.HeSo = int.Parse(opt[1].ToString());
                                it.ListThongSo.Add(ts);
                            }
                        }
                        it.TimeTAO= long.Parse(dataItem[3].ToString());

                        items.ListItemNgauNhien.Add(it);
                    }
                }

                dataArray.Clear();

            }
            catch (Exception ex) { }

            return items;
        }


        string sauThuHoi(string s1,int id)
        {
            //MessageBox.Show(s1);
            ItemsNgauNhien i = docData(s1, id);
            string s = "[";

            bool k1 = false;
            foreach (ItemNgauNhien item in i.ListItemNgauNhien)
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
                s += item.TimeTAO + "]\"";
            }
            s += "]";
            //MessageBox.Show(s);

            return s;
        }

        void ThuHoi(DataTable data,int id)
        {
            if (data == null) return;

            foreach (DataRow d in data.Rows)
            {
                string items_body = sauThuHoi(d["items_body"].ToString(),id);
                string items_bag = sauThuHoi(d["items_bag"].ToString(),id);
                string items_box = sauThuHoi(d["items_box"].ToString(),id);

                DataProvider.i.ExecuteQuery("UPDATE player SET items_body='"+items_body+"',items_bag='"+items_bag+"',items_box='"+items_box+"' WHERE id=" + ((int)d["id"]));// 
                return;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tbTime.Text="Time hiện tại : " + ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
        }
    }
}
