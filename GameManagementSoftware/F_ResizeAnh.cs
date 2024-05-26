using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManagementSoftware
{
    public partial class F_ResizeAnh : Form
    {
        public F_ResizeAnh()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbNoiLuu.Text))
            {
                MessageBox.Show("Thư mục lưu không tồn tại !");
                return;
            }

            if (flPn.Controls.Count < 1)
            {
                MessageBox.Show("Chưa có file X4 nào !");
                return;
            }

            string parthX1 = tbNoiLuu.Text + "\\x1";
            string parthX2 = tbNoiLuu.Text + "\\x2";
            string parthX3 = tbNoiLuu.Text + "\\x3";
            string parthX4 = tbNoiLuu.Text + "\\x4";
            if (!Directory.Exists(parthX1))
            {
                Directory.CreateDirectory(parthX1);
            }
            else
            {
                Console.WriteLine("Hãy là trống thư mục lưu trước !", "Thông báo");
                return;
            }
            if (!Directory.Exists(parthX2))
            {
                Directory.CreateDirectory(parthX2);
            }
            else
            {
                Console.WriteLine("Hãy là trống thư mục lưu trước !", "Thông báo");
                return;
            }
            if (!Directory.Exists(parthX3))
            {
                Directory.CreateDirectory(parthX3);
            }
            else
            {
                Console.WriteLine("Hãy là trống thư mục lưu trước !", "Thông báo");
                return;
            }
            if (!Directory.Exists(parthX4))
            {
                Directory.CreateDirectory(parthX4);
            }
            else
            {
                Console.WriteLine("Hãy là trống thư mục lưu trước !", "Thông báo");
                return;
            }
            foreach (PictureBox p in flPn.Controls)
            {
                try
                {
                    Image i= p.Image;
                    Size newSizeX4 = new Size((int)(i.Width), (int)(i.Height));
                    Size newSizeX3 = new Size((int)(i.Width * 0.75), (int)(i.Height * 0.75));
                    Size newSizeX2 = new Size((int)(i.Width * 0.5), (int)(i.Height * 0.5));
                    Size newSizeX1 = new Size((int)(i.Width * 0.25), (int)(i.Height * 0.25));

                    // Tạo bitmap cho từng kích thước mới
                    using (Bitmap x4Image = new Bitmap(newSizeX4.Width, newSizeX4.Height))
                    using (Bitmap x3Image = new Bitmap(newSizeX3.Width, newSizeX3.Height))
                    using (Bitmap x2Image = new Bitmap(newSizeX2.Width, newSizeX2.Height))
                    using (Bitmap x1Image = new Bitmap(newSizeX1.Width, newSizeX1.Height))
                    {
                        // Vẽ lại hình ảnh theo kích thước mới
                        using (Graphics graphicsX4 = Graphics.FromImage(x4Image))
                        using (Graphics graphicsX3 = Graphics.FromImage(x3Image))
                        using (Graphics graphicsX2 = Graphics.FromImage(x2Image))
                        using (Graphics graphicsX1 = Graphics.FromImage(x1Image))
                        {
                            graphicsX4.DrawImage(i, new Rectangle(0, 0, newSizeX4.Width, newSizeX4.Height));
                            graphicsX3.DrawImage(i, new Rectangle(0, 0, newSizeX3.Width, newSizeX3.Height));
                            graphicsX2.DrawImage(i, new Rectangle(0, 0, newSizeX2.Width, newSizeX2.Height));
                            graphicsX1.DrawImage(i, new Rectangle(0, 0, newSizeX1.Width, newSizeX1.Height));
                        }

                        // Lưu các phiên bản với kích thước mới
                        x4Image.Save(parthX4 +"\\" + Path.GetFileName(p.Tag.ToString()), ImageFormat.Png);
                        x3Image.Save(parthX3 + "\\" + Path.GetFileName(p.Tag.ToString()), ImageFormat.Png);
                        x2Image.Save(parthX2 + "\\" + Path.GetFileName(p.Tag.ToString()) , ImageFormat.Png);
                        x1Image.Save(parthX1 + "\\" + Path.GetFileName(p.Tag.ToString()) , ImageFormat.Png);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thực hiện với ảnh "+ Path.GetFileName(p.Tag.ToString()));
                }
                
            }
            MessageBox.Show("Resize thành công !");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.Description = "Chọn nơi lưu";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbNoiLuu.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Chọn ảnh X4 (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;
            int dem = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                flPn.Controls.Clear();
                string[] selectedFilePaths = openFileDialog.FileNames;
                foreach (string filePath in selectedFilePaths)
                {
                    PictureBox p = new PictureBox() { Width = 75, Height = 110 };
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.MouseDoubleClick += pictureBox_DClick;
                    p.Tag = filePath;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Image = Image.FromFile(filePath);
                    flPn.Controls.Add(p);dem++;
                    if (dem == 200) break;
                }
            }
        }

        public void pictureBox_DClick(object sender, EventArgs e)
        {
            try
            {
                flPn.Controls.Remove(sender as PictureBox);
            }
            catch (Exception ex) { }
        }
    }
}
