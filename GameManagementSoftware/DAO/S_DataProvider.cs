using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameManagementSoftware
{
    public class S_DataProvider
    {
        private static MySqlConnection connection;
        private static string server = "127.0.0.1";
        private static int port = 3306;
        public static string database = "";
        public static string username = "root";
        private static string password = "";
        //private static string server = "14.225.219.120";
        //private static int port = 3306;
        //private static string database = "new";
        //private static string username = "nro";
        //private static string password = "5FM2ge[lhnrRg1l-";



        public const string TieuDe_ItemTemPlate = "Danh sách Item template";
        public const string TieuDe_ItemOptionTemPlate = "Danh sách Thông số";

        public static S_DataProvider i;

        public static S_DataProvider gI()
        {
            if (i == null) i = new S_DataProvider();
            return i;
        }

        public S_DataProvider() { }

        public DataTable ExecuteQuery(string query, string dk = null)
        {
            try
            {
                string db = "Server=" + server + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);
                        //if(dk==null) 
                        return d;
                        //return locData(d,dk);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            return null;
        }
        public DataTable locData(DataTable d, string dk)
        {
            if (d == null || d.Rows.Count == 0) return null;
            dk = GetSimpleString(dk);
            DataTable d2 = new DataTable();
            foreach (DataRow row in d.Rows)
            {
                try
                {
                    StringBuilder result = new StringBuilder();

                    foreach (DataColumn col in d.Columns)
                    {
                        result.Append(row[col].ToString());
                    }

                    // Kết quả là chuỗi chứa tất cả giá trị từ mọi cột trong mỗi hàng
                    string finalResult = result.ToString();
                    if (IsHaveSameString(finalResult, dk)) d2.Rows.Add(row);
                }
                catch (Exception ex) { }
            }

            return d2;

        }
        public string getDinhDanhHangNghin(int i)
        {
            return String.Format("{0:###,###,##0}", i);
        }

        public DataRow ExecuteQuery_Row(string query)
        {
            try
            {
                string db = "Server=" + server + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);
                        if (d.Rows.Count > 0) return d.Rows[0];
                    }
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public int ExecuteQuery_None(string query)
        {
            try
            {
                string db = "Server=" + server + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

                using (MySqlConnection conn = new MySqlConnection(db))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable d = new DataTable();
                        adapter.Fill(d);
                        //MessageBox.Show(d.Rows[0]["ketqua"].ToString());
                        if (d.Rows.Count > 0) return int.Parse(d.Rows[0]["ketqua"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return 0;
        }

        public static string GetSimpleString(string text)
        {
            text = text.Trim();
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
        }

        public static bool IsHaveSameString(string str1, string str2)
        {
            //MessageBox.Show(str1);
            return GetSimpleString(str1).Contains(str2);
        }

        public int TinhSoLuongItem(int id)
        {
            return 0;
        }

        public int CountRowsInAccountTable()
        {
            int rowCount = 0;

            try
            {
                string query = "SELECT COUNT(*) FROM account";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Sử dụng ExecuteScalar để lấy giá trị đếm
                rowCount = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return rowCount;
        }
    }
}
