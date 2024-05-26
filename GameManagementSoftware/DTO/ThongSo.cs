using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagementSoftware.DTO
{
    public class ThongSo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNgauNhien { get; set; }
        public int HeSo { get; set; }
        public int HeSoMax { get; set; }

        public ThongSo() { }

        public ThongSo(int iD,string name, bool isNgauNhien, int heSo, int heSoMax)
        {
            ID = iD;
            Name = name;
            IsNgauNhien = isNgauNhien;
            this.HeSo = heSo;
            this.HeSoMax = heSoMax;
        }
    }
}
