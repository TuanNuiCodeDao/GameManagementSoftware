using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagementSoftware.DTO
{
    public class ItemsNgauNhien
    {
        public int ID { get; set; }
        public List<ItemNgauNhien> ListItemNgauNhien { get; set; }
        public int Tong { get; set; }
        public string GhiChu { get; set; }

        public ItemsNgauNhien() {
            ListItemNgauNhien=new List<ItemNgauNhien>();
            GhiChu = "Trống";
        }

        public ItemsNgauNhien(int iD, List<ItemNgauNhien> listItemNgauNhien, int tong)
        {
            ID = iD;
            ListItemNgauNhien = listItemNgauNhien;
            Tong = tong;
            GhiChu = "Trống";
        }
    }
}
