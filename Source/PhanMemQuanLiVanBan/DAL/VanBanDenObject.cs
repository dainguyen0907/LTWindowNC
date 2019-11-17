using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VanBanDenObject
    {
        public decimal id { get; set; }
        public String sovanban { get; set; }
        public String loaivanban { get; set; }
        public String sokyhieu { get; set; }
        public int soden { get; set; }
        public DateTime ngaybanhanh { get; set; }
        public DateTime ngayden { get; set; }
        public String donvigui { get; set; }
        public String trichyeu { get; set; }
    }
}
