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
    public partial class F_ShowText : Form
    {
        public string Text;
        
        public F_ShowText(string text)
        {
            InitializeComponent();
            Text = text;
            tbText.Text = text;
            tbText.MouseWheel += tbCu_MouseWheel;
        }

        private void tbCu_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            if (delta > 0) tbText.Font = new Font(tbText.Font.FontFamily, tbText.Font.Size + 1, tbText.Font.Style);
            else tbText.Font = new Font(tbText.Font.FontFamily, tbText.Font.Size - 1, tbText.Font.Style);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textFromClipboard = Clipboard.GetText();

            if (!string.IsNullOrEmpty(textFromClipboard))
            {
                tbText.Text = textFromClipboard;
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbText.Text)) Clipboard.SetText(tbText.Text);
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            Text=tbText.Text;
        }
    }
}
