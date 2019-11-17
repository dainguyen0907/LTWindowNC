using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VanBanNoiBoObject
    {
        public decimal id { get; set; }
        public String tenvanban { set; get; }
        public String loaivanban { get; set; }
        public String sokyhieu { get; set; }
        public DateTime ngaybanhanh { get; set; }
        public String phongbanhanh { get; set; }
        public String phongbannhan { get; set; }
        public String trichyeu { get; set; }
    }
}
