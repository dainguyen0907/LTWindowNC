using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLiVanBan
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.dangnhap != null)
                Program.dangnhap.Close();
        }

        private void btn_hethong_Click(object sender, EventArgs e)
        {
            group_chucnang.Text = "HỆ THỐNG";
            foreach (Control c in group_chucnang.Controls)
            {
                if (c is PanelControl)
                {
                    c.Visible = false;
                }
            }
            panel_hethong.Visible = true;
        }

        private void btn_qlvb_Click(object sender, EventArgs e)
        {
            group_chucnang.Text = "QUẢN LÍ VĂN BẢN";
            foreach (Control c in group_chucnang.Controls)
            {
                if (c is PanelControl)
                {
                    c.Visible = false;
                }
            }
            panel_vanban.Visible = true;
        }

        private void btn_qlvbnoibo_Click(object sender, EventArgs e)
        {
            group_chucnang.Text = "QUẢN LÍ VĂN BẢN NỘI BỘ";
            foreach (Control c in group_chucnang.Controls)
            {
                if (c is PanelControl)
                {
                    c.Visible = false;
                }
            }
            panel_vbnoibo.Visible = true;
        }

        private void btn_thongke_small_Click(object sender, EventArgs e)
        {
            group_chucnang.Text = "TÌM KIẾM - THỐNG KÊ";
            foreach (Control c in group_chucnang.Controls)
            {
                if (c is PanelControl)
                {
                    c.Visible = false;
                }
            }
            panel_thongke.Visible = true;
        }
    }
}
