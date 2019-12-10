using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionString
    {
        public void setConnectionString(string connectionString)
        {
            DAL.Properties.Settings.Default["QUAN_LY_VAN_BANConnectionString"] = connectionString;
            DAL.Properties.Settings.Default.Save();
        }
    }
}
