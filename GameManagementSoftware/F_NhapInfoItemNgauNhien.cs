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
    public partial class F_NhapInfoItemNgauNhien : Form
    {
        public int SoLuong { get; set; }
        public int TiLe { get; set; }
        public bool DaThayDoi { get; set; }
        public F_NhapInfoItemNgauNhien(bool soLuong=true,bool tile=true)
        {
            InitializeComponent();
            SoLuong = 1;
            TiLe = 1;
            DaThayDoi= false;
            if(!soLuong)
            {
                nudSoLuong.Hide();
                label20.Hide();
            }

            if (!tile)
            {
                nudTiLe.Hide();
                label1.Hide();
            }
        }

        private void nudTiLe_ValueChanged(object sender, EventArgs e)
        {
            TiLe = (int)nudTiLe.Value;
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            SoLuong = (int)nudSoLuong.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DaThayDoi = true;
            this.Close();
        }
    }
}
