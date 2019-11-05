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
using DevExpress.XtraBars.Docking;
using DevExpress.XtraTab;
using System.Data.Linq;
using BLL;

namespace PhanMemQuanLiVanBan
{
    public partial class frm_Main : Form
    {
        
        public frm_Main()
        {
            InitializeComponent();
        }
        private Business bussiness = new Business();
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

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dock_chucnag.Visibility == DockVisibility.Hidden)
                dock_chucnag.Visibility = DockVisibility.Visible;
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dock_thongtin.Visibility == DockVisibility.Hidden || dock_thongtin.Visibility == DockVisibility.AutoHide)
                dock_thongtin.Visibility = DockVisibility.Visible;
        }

        private void panelControl1_SizeChanged(object sender, EventArgs e)
        {
            if (panelControl1.Height >= 210)
            {
                panelControl1.Size = new Size(293, 250);
                foreach (Control c in panelControl2.Controls)
                {
                    if (c is SimpleButton)
                        c.Visible = false;
                }
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is SimpleButton)
                        c.Visible = true;
                }
            }
            else if (panelControl1.Size.Height < 210 && panelControl1.Height >= 160)
            {
                panelControl1.Size = new Size(293, 200);
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is SimpleButton)
                        if (c.Name != "btn_thongke")
                            c.Visible = true;
                        else
                            c.Visible = false;
                    
                }
                foreach (Control c in panelControl2.Controls)
                {
                    if (c is SimpleButton)
                        if (c.Name != "btn_thongke_small")
                            c.Visible = false;
                        else
                            c.Visible = true;
                }
            }
            else if (panelControl1.Size.Height < 160 && panelControl1.Height >= 110)
            {
                panelControl1.Size = new Size(293, 150);
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is SimpleButton)
                        if (c.Name != "btn_thongke" && c.Name != "btn_qlvbnoibo")
                            c.Visible = true;
                        else
                            c.Visible = false;
                }
                foreach (Control c in panelControl2.Controls)
                {
                    if (c is SimpleButton)
                        if (c.Name != "btn_thongke_small" && c.Name != "btn_qlvbnoibo_small")
                            c.Visible = false;
                        else
                            c.Visible = true;
                }
            }
            else if (panelControl1.Size.Height < 110 && panelControl1.Height >= 60)
            {
                panelControl1.Size = new Size(293, 100);
                foreach (Control c in panelControl2.Controls)
                {
                    if (c is SimpleButton)
                        if (c.Name != "btn_hethong_small")
                            c.Visible = true;
                        else
                            c.Visible = false;
                }
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is SimpleButton)
                        if (c.Name != "btn_hethong")
                            c.Visible = false;
                        else
                            c.Visible = true;
                }
                
            }
            else
            {
                foreach (Control c in panelControl2.Controls)
                {
                    if (c is SimpleButton)
                        c.Visible = true;
                }
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is SimpleButton)
                        c.Visible = false;
                }
            }
        }

        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            if(tabControl.SelectedTabPageIndex>-1)
                tabControl.SelectedTabPage.PageVisible = false;
        }

        private void ShowTab(XtraTabPage tagPage )
        {
            if (tagPage.PageVisible == true)
                tabControl.SelectedTabPage = tagPage;
            else
            {
                tagPage.PageVisible = true;
                tabControl.SelectedTabPage = tagPage;
            }
        }

        private void btn_sovanban_Click(object sender, EventArgs e)
        {
            ShowTab(tab_sovanban);

        }

        private void btn_loaivanban_Click(object sender, EventArgs e)
        {
            ShowTab(tab_loaivanban);
        }

        private void btn_noibanhanh_Click(object sender, EventArgs e)
        {
            ShowTab(tab_noibanhanh);
        }

        private void btn_vanbanden_Click(object sender, EventArgs e)
        {
            ShowTab(tab_vanbanden);
        }

        private void btn_vanbandi_Click(object sender, EventArgs e)
        {
            ShowTab(tab_vanbandi);
        }

        private void btn_dsvanbanden_Click(object sender, EventArgs e)
        {
            ShowTab(tab_ds_vanbanden);
        }

        private void btn_dsvanbandi_Click(object sender, EventArgs e)
        {
            ShowTab(tab_ds_vanbandi);
        }

        private void btn_phongban_Click(object sender, EventArgs e)
        {
            ShowTab(tab_phongban);
        }

        private void btn_vbnb_Click(object sender, EventArgs e)
        {
            ShowTab(tab_vanbannoibo);
        }

        private void btn_dsvbnb_Click(object sender, EventArgs e)
        {
            ShowTab(tab_ds_vanbannoibo);
        }

        private void tk_vanbandi_Click(object sender, EventArgs e)
        {
            ShowTab(tab_tk_vanbandi);
        }

        private void tk_vanbanden_Click(object sender, EventArgs e)
        {
            ShowTab(tab_tk_vanbanden);
        }

        private void tk_vanbannoibo_Click(object sender, EventArgs e)
        {
            ShowTab(tab_tk_vanbannoibo);
        }

        private void btn_capnhatuser_Click(object sender, EventArgs e)
        {
            ShowTab(tab_nhanvien);
        }

        private void btn_phanquyen_Click(object sender, EventArgs e)
        {
            ShowTab(tab_phanquyen);
        }

        private void btn_thongtincty_Click(object sender, EventArgs e)
        {
            ShowTab(tab_thongtin);
        }

        private void đăngNhậpLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.dangnhap == null || Program.dangnhap.IsDisposed)
            {
                Program.dangnhap = new frm_DangNhap();
            }
            this.Hide();
            Program.dangnhap.Show();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            txt_tendangnhap.Text = Program.Tennhanvien;
            LoadGridViewNhanVien();
        }


        

        private void ToolStrip_nhanvien_Load(object sender, EventArgs e)
        {
            mts_nhanvien.SetToolStrip(dgv_nhanvien, gb_nhanvien, txt_nv_id, true, true, true);
            mts_nhanvien.ButtonClick += new EventHandler(XuLyButtonLuu);
        }

        private void XuLyButtonLuu(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_nv_id.Text))
            {
                int id=int.Parse(txt_nv_id.Text);
                bool nghiviec=false;
                if(cbb_nv_nghiviec.SelectedIndex==0)
                    nghiviec=true;
                String manhanvien=txt_nv_manv.Text.ToString().Trim();
                String matkhau=txt_nv_matkhau.Text.ToString().Trim();
                String tennhanvien=txt_nv_tennv.Text.ToString().Trim();
                int id_congty=int.Parse(Program.id_congty);
                if (bussiness.timNhanVien(id))
                {
                    if (bussiness.suaNhanVien(id, manhanvien, tennhanvien, matkhau, nghiviec))
                        MessageBox.Show("Cập nhật nhân viên thành công","THÔNG BÁO");
                    else
                        MessageBox.Show("Cập nhật nhân viên thất bại","THÔNG BÁO");
                }
                else
                {
                    if(bussiness.themNhanVien(id, manhanvien, tennhanvien, matkhau, id_congty))
                        MessageBox.Show("Thêm nhân viên thành công","THÔNG BÁO");
                    else
                        MessageBox.Show("Thêm nhân viên thất bại","THÔNG BÁO");

                }
            }
            dgv_nhanvien.Refresh();
        }
        private void LoadGridViewNhanVien()
        {
            dgv_nhanvien.DataSource = bussiness.getNhanVien();
            dgv_nhanvien.Columns["IS_ADMIN"].Visible = false;
            dgv_nhanvien.Columns["ID_CONG_TY"].Visible = false;
            dgv_nhanvien.Columns["NGHI_VIEC"].Visible = false;
            dgv_nhanvien.Columns["THONG_TIN_CONG_TY"].Visible = false;
            dgv_nhanvien.Columns["MAT_KHAU"].Visible = false;
            dgv_nhanvien.Columns["ID_NHAN_VIEN"].HeaderText = "ID nhân viên";
            dgv_nhanvien.Columns["MA_NHAN_VIEN"].HeaderText = "Mã nhân viên";
            dgv_nhanvien.Columns["HO_TEN"].HeaderText = "Tên nhân viên";
        }

        private void dgv_nhanvien_SelectionChanged(object sender, EventArgs e)
        {
            int d = dgv_nhanvien.CurrentCell.RowIndex;
            if (d >= 0&& d< dgv_nhanvien.RowCount-1)
            {
                txt_nv_id.Text = dgv_nhanvien.Rows[d].Cells["ID_NHAN_VIEN"].Value.ToString();
                txt_nv_tennv.Text = dgv_nhanvien.Rows[d].Cells["HO_TEN"].Value.ToString();
                txt_nv_manv.Text = dgv_nhanvien.Rows[d].Cells["MA_NHAN_VIEN"].Value.ToString();
                if (dgv_nhanvien.Rows[d].Cells["NGHI_VIEC"].Value == null)
                {
                    cbb_nv_nghiviec.SelectedIndex = 1;
                    return;
                }
                  if(dgv_nhanvien.Rows[d].Cells["NGHI_VIEC"].Value.ToString()!="true")
                    cbb_nv_nghiviec.SelectedIndex = 1;
                   else
                    cbb_nv_nghiviec.SelectedIndex= 0;
                  return;
            }
        }
        

    }
}
