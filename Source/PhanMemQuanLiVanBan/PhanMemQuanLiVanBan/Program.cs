using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLiVanBan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static frm_DangNhap dangnhap=null;
        static frm_Main main = null;
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dangnhap = new frm_DangNhap();
            Application.Run(dangnhap);
        }
    }
}
