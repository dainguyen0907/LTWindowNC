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
        static public frm_DangNhap dangnhap=null;
        static public frm_Main mainForm = null;
        static public string Tennhanvien;
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dangnhap = new frm_DangNhap();
            Application.Run(dangnhap);
        }
    }
}
