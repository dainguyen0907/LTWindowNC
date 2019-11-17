using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VanBanDiObject
    {
        public decimal id { get; set; }
        public String sovanban { get; set; }
        public String loaivanban { get; set; }
        public String sokyhieu { get; set; }
        public int sodi { get; set; }
        public DateTime ngaybanhanh { get; set; }
        public String noinhan { get; set; }
        public String trichyeu { get; set; }
    }
}
