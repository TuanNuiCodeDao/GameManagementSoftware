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
    public partial class F_NhapHeSoThongSo : Form
    {
        public int HeSo { get; set; }
        public int HeSoMax { get; set; }
        public bool DaThayDoi { get; set; }

        public F_NhapHeSoThongSo(bool isMax=true)
        {
            InitializeComponent();
            TopMost = true;
            HeSo = 1;
            HeSoMax = 1;
            DaThayDoi = false;

            if (!isMax)
            {
                numericUpDown2.Hide();
                label1.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DaThayDoi = true;
            this.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            HeSo = (int)numericUpDown1.Value;
            numericUpDown2.Value = HeSo;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            HeSoMax = (int)numericUpDown2.Value;
        }
    }
}
