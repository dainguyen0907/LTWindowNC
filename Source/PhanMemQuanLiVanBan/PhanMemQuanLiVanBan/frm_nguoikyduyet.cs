using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace PhanMemQuanLiVanBan
{
    public partial class frm_nguoikyduyet : Form
    {
        public frm_nguoikyduyet()
        {
            InitializeComponent();
        }
        Business bussiness = new Business();
        private void frm_nguoikyduyet_Load(object sender, EventArgs e)
        {
            string[] tt = bussiness.getThietLapThongTin();
            txt_nguoiky.Text = tt[0];
            txt_nguoiduyet.Text = tt[2];
            txt_nguoigui.Text = tt[1];
            txt_nguoinhan.Text = tt[3];
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string ngky = txt_nguoiky.Text.ToString();
            string nggui = txt_nguoigui.Text.ToString();
            string ngnhan = txt_nguoinhan.Text.ToString();
            string ngduyet = txt_nguoiduyet.Text.ToString();
            if (bussiness.UpdateThongTin(ngky, nggui, ngduyet, ngnhan))
                MessageBox.Show("THIẾT LẬP THÔNG TIN THÀNH CÔNG", "THÔNG BÁO");
            else
                MessageBox.Show("THIẾT LẬP THÔNG TIN THẤT BẠI", "THÔNG BÁO");
        }
    }
}
