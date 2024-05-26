using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagementSoftware.DTO
{
    public class InfoThongKe
    {
        public int IDPlayer { get; set; }
        public int IDAccount { get; set; }
        public string Name { get; set; }
        public int SoLuong { get; set; }

        public InfoThongKe() { }

        public InfoThongKe(int iDPlayer, int iDAccount, string name, int soLuong)
        {
            IDPlayer = iDPlayer;
            IDAccount = iDAccount;
            Name = name;
            SoLuong = soLuong;
        }
    }
}
