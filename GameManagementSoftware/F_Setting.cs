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
    public partial class F_Setting : Form
    {
        public F_Setting()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            tbDBNameGame.Text = DataProvider.database;
            tbDBNameNote.Text = S_DataProvider.database;
            loadCBDangThongKe();
        }

        void loadCBDangThongKe()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Cũ");
            cbTrangThai.Items.Add("Mới");
            if(DataProvider.dangThongKe=="Cũ") cbTrangThai.Text = "Cũ";
            else cbTrangThai.Text = "Mới";
        }

        private void button2_Click(object sender, EventArgs e)
        {
             DataProvider.database= tbDBNameGame.Text;
             S_DataProvider.database= tbDBNameNote.Text;
             DataProvider.dangThongKe= cbTrangThai.Text;
             DataProvider.gI().saveInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
