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

namespace GameManagementSoftware
{
    public partial class F_ConvertPart : Form
    {
        public F_ConvertPart()
        {
            InitializeComponent();
            tbIn.MouseWheel += tbIn_MouseWheel;
            tbOut.MouseWheel += tbOut_MouseWheel;
        }

        private void tbIn_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            if (delta > 0) tbIn.Font = new Font(tbIn.Font.FontFamily, tbIn.Font.Size + 1, tbIn.Font.Style);
            else tbIn.Font = new Font(tbIn.Font.FontFamily, tbIn.Font.Size - 1, tbIn.Font.Style);
        }

        private void tbOut_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            if (delta > 0) tbOut.Font = new Font(tbOut.Font.FontFamily, tbOut.Font.Size + 1, tbOut.Font.Style);
            else tbOut.Font = new Font(tbOut.Font.FontFamily, tbOut.Font.Size - 1, tbOut.Font.Style);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbIn.Text))
            {
                MessageBox.Show("Dữ liệu đầu vào trống !", "Thông báo");
                return;
            }

            string s = tbIn.Text;
            int i = 0;
            string t = "[";
            while (i < s.Length - 1)
            {
                if (s[i] == 'i')
                {
                    if (t != "[") t += ",";
                    t += "[";
                    int j = i + 4;
                    while (s[j] != ',' && j < s.Length)
                    {
                        t += s[j];
                        j++;
                    }
                    j += 6;
                    t += ",";
                    while (s[j] != ',' && j < s.Length)
                    {
                        t += s[j];
                        j++;
                    }
                    j += 6;
                    t += ",";
                    while (s[j] != '}' && j < s.Length)
                    {
                        t += s[j];
                        j++;
                    }
                    t += "]";
                    j += 4;
                    i = j;
                }
                else i++;
            }
            t += "]";
            tbOut.Text = t;
        }

        private void tbIn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbIn.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbIn.Text))
            {
                MessageBox.Show("Dữ liệu đầu vào trống !", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbBegin.Text))
            {
                MessageBox.Show("Dữ liệu begin trống !", "Thông báo");
                return;
            }

            int begin=int.Parse(tbBegin.Text);
            tbIn.Text= tbIn.Text.Replace(" ", "");
            string s=tbIn.Text;
            int i = 0;
            string t = "";
            while (i < s.Length)
            {
                if ((s[i] < '0' || s[i] > '9') || (i>0&&s[i-1]!='['))
                {
                    t += s[i];
                    i++;
                }
                else
                {
                    t += begin.ToString();
                    begin++;
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9') i++;
                }
            }

            tbOut.Text = t;
        }

        private void tbOut_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbOut_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbOut.Text=tbIn.Text.Replace(tb1.Text, tb2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbIn.Text))
            {
                MessageBox.Show("Dữ liệu đầu vào trống !", "Thông báo");
                return;
            }

            string s = tbIn.Text.Replace(" ","");
            string t = "[";
            JArray dataArray = JArray.Parse(s.Replace("\"", ""));
            foreach (var item in dataArray)
            {
                if (t != "[") t += ",";
                JArray pd = JArray.Parse(item.ToString());
                t += "{\"dx\":"+ pd[1] + ",\"dy\":"+ pd[2] + ",\"icon\":"+ pd[0] + "}";
                pd.Clear();
            }
            t += "]";
            //int i = 0;
            //string t = "[";
            //while (i < s.Length - 1)
            //{
            //    if (s[i] == '[')
            //    {
            //        if (t != "[") t += ",";

            //        t += "{\"dx\":";
            //        int j = i + 1;
            //        while (j < s.Length && s[j] >='0'&& s[j] <='9')
            //        {
            //            t += s[j];
            //            j++;
            //        }

            //        t += ",\"dy\":";
            //        j++;
            //        while (j < s.Length && s[j] >= '0' && s[j] <= '9')
            //        {
            //            t += s[j];
            //            j++;
            //        }

            //        t += ",\"icon\":";
            //        j++;
            //        while (j < s.Length && s[j] >= '0' && s[j] <= '9')
            //        {
            //            t += s[j];
            //            j++;
            //        }

            //        t += "}";
            //        j += 1;
            //        i = j;
            //    }
            //    else i++;
            //}
            //t += "]";
            tbOut.Text = t;
        }
    }
}
