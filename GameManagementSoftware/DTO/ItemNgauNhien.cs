using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagementSoftware.DTO
{
    public class ItemNgauNhien
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ThongSo> ListThongSo { get; set; }
        public int SoLuong { get; set; }
        public int TiLe { get; set; }
        public long TimeTAO { get; set; }

        public ItemNgauNhien() {
            ListThongSo=new List<ThongSo>();

            TimeTAO = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public ItemNgauNhien(int iD,string name, List<ThongSo> lThongSo, int soLuong, int tiLe)
        {
            ID = iD;
            Name = name;
            this.ListThongSo = lThongSo;
            SoLuong = soLuong;
            TiLe = tiLe;
        }
    }
}
