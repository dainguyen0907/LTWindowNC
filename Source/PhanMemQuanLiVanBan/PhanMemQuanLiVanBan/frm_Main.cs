using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLiVanBan
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.dangnhap != null)
                Program.dangnhap.Close();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

            if (Program.Tennhanvien != null)
                lbl_tennv.Text = Program.Tennhanvien;
        }

        private void panelBuutton_SizeChanged(object sender, EventArgs e)
        {
            if (panelBuutton.Size.Height > 210 && panelBuutton.Size.Height <= 250)
            {
                panelBuutton.Size = new Size(269, 250);

                btn_timkiem.Visible = true;
                btn_timkiem_small.Visible = false;
                btn_qlvbnoibo_small.Visible = false;
                btn_qlvbnoibo.Visible = true;
                btn_qlvb_small.Visible = false;
                btn_qlvb.Visible = true;
                btn_hethong_small.Visible = false;
                btn_hethong.Visible = true;
                
            }
            else if (panelBuutton.Size.Height > 160 && panelBuutton.Size.Height <= 210)
            {
                panelBuutton.Size = new Size(269, 200);
                btn_timkiem.Visible = false;
                btn_timkiem_small.Visible = true;
                btn_qlvbnoibo_small.Visible = false;
                btn_qlvbnoibo.Visible = true;
                btn_qlvb_small.Visible = false;
                btn_qlvb.Visible = true;
                btn_hethong_small.Visible = false;
                btn_hethong.Visible = true;
            }
            else if (panelBuutton.Size.Height > 110 && panelBuutton.Size.Height <= 160)
            {
                panelBuutton.Size = new Size(269, 150);
                btn_timkiem.Visible = false;
                btn_timkiem_small.Visible = true;
                btn_qlvbnoibo_small.Visible = true;
                btn_qlvbnoibo.Visible = false;
                btn_qlvb_small.Visible = false;
                btn_qlvb.Visible = true;
                btn_hethong_small.Visible = false;
                btn_hethong.Visible = true;
            }
            else if (panelBuutton.Size.Height > 60 && panelBuutton.Size.Height <= 110)
            {
                panelBuutton.Size = new Size(269, 100);
                btn_timkiem.Visible = false;
                btn_timkiem_small.Visible = true;
                btn_qlvbnoibo_small.Visible = true;
                btn_qlvbnoibo.Visible = false;
                btn_qlvb_small.Visible = true;
                btn_qlvb.Visible = false;
                btn_hethong_small.Visible = false;
                btn_hethong.Visible = true;
            }
            else
            {
                btn_timkiem.Visible = false;
                btn_timkiem_small.Visible = true;
                btn_qlvbnoibo_small.Visible = true;
                btn_qlvbnoibo.Visible = false;
                btn_qlvb_small.Visible = true;
                btn_qlvb.Visible = false;
                btn_hethong_small.Visible = true;
                btn_hethong.Visible = false;
            }
        }

        

        

        

        

        
    }
}
