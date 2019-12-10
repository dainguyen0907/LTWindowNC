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
using System.IO;
using System.Threading;
using MyTools;
namespace PhanMemQuanLiVanBan
{
    
    public partial class frm_Main : Form
    {
        
        public frm_Main()
        {
            InitializeComponent();
        }
        private Password ps = new Password();
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
            LoadSoVanBan(2019);

        }

        private void btn_loaivanban_Click(object sender, EventArgs e)
        {
            ShowTab(tab_loaivanban);
            LoadLoaiVanBan();
        }

        private void btn_noibanhanh_Click(object sender, EventArgs e)
        {
            ShowTab(tab_noibanhanh);
            LoadNoiBanHanh();
        }

        private void btn_vanbanden_Click(object sender, EventArgs e)
        {
            ShowTab(tab_vanbanden);
            LoadVanBanDenMoi();
        }

        private void btn_vanbandi_Click(object sender, EventArgs e)
        {
            ShowTab(tab_vanbandi);
            LoadVanBanDiMoi();
        }

        private void btn_dsvanbanden_Click(object sender, EventArgs e)
        {
            ShowTab(tab_ds_vanbanden);
            loadVanBanDen(DateTime.Today, DateTime.Today);
        }

        private void btn_dsvanbandi_Click(object sender, EventArgs e)
        {
            ShowTab(tab_ds_vanbandi);
            loadVanBanDi(DateTime.Today, DateTime.Today);
        }

        private void btn_phongban_Click(object sender, EventArgs e)
        {
            ShowTab(tab_phongban);
            LoadPhongBan();
        }

        private void btn_vbnb_Click(object sender, EventArgs e)
        {
            ShowTab(tab_vanbannoibo);
            LoadVanBanNoiBoMoi();
        }

        private void btn_dsvbnb_Click(object sender, EventArgs e)
        {
            ShowTab(tab_ds_vanbannoibo);
            LoadVanBanNoiBo(DateTime.Today, DateTime.Today);
        }

        private void tk_vanbandi_Click(object sender, EventArgs e)
        {
            ShowTab(tab_tk_vanbandi);
            loadComboboxTKVBDi();
        }

        private void tk_vanbanden_Click(object sender, EventArgs e)
        {
            ShowTab(tab_tk_vanbanden);
            loadComboboxTKVBDen();
        }

        private void tk_vanbannoibo_Click(object sender, EventArgs e)
        {
            ShowTab(tab_tk_vanbannoibo);
            loadComboboxTKVBNB();
        }

        private void btn_capnhatuser_Click(object sender, EventArgs e)
        {
            ShowTab(tab_nhanvien);
            LoadGridViewNhanVien();
        }

        private void btn_phanquyen_Click(object sender, EventArgs e)
        {
            ShowTab(tab_phanquyen);
            LoadComboboxPhanQuyen();
        }

        private void btn_thongtincty_Click(object sender, EventArgs e)
        {
            ShowTab(tab_thongtin);
            LoadThongTinChung();
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
            txt_tendangnhap.Text = Program.Idnhanvien;
            if (Program.Idnhanvien == "-1")
            {
                foreach (Control bt in panel_hethong.Controls)
                {
                   bt.Enabled = true;
                }
                foreach (Control bt in panel_thongke.Controls)
                {
                    bt.Enabled = true;
                }
                foreach (Control bt in panel_vanban.Controls)
                {
                    bt.Enabled = true;
                }
                foreach (Control bt in panel_vbnoibo.Controls)
                {
                    bt.Enabled = true;
                }
            }
            else
            {
                foreach (String c in bussiness.getquyen(int.Parse(Program.Idnhanvien)))
                {
                    bool flag = false;
                    foreach (Control bt in panel_hethong.Controls)
                    {
                        if (bt is SimpleButton && bt.Tag.ToString() == c)
                        {
                            bt.Enabled = true;
                            flag = true;
                            break;
                         }
                    }
                    foreach (Control bt in panel_thongke.Controls)
                    {
                        if (flag == true)
                            break;
                        if (bt is SimpleButton && bt.Tag.ToString() == c)
                        {
                            flag = true;
                            bt.Enabled = true;
                            break;
                        }
                    }
                    foreach (Control bt in panel_vanban.Controls)
                    {
                        if (flag == true)
                            break;
                        if (bt is SimpleButton && bt.Tag.ToString() == c)
                        {
                            flag = true;
                            bt.Enabled = true;
                            break;
                        }
                    }
                    foreach (Control bt in panel_vbnoibo.Controls)
                    {
                        if (flag == true)
                            break;
                        if (bt is SimpleButton && bt.Tag.ToString() == c)
                        {
                            bt.Enabled = true;
                            break;
                        }
                    }
                }
            }
            
        }


        // Tab Nhân viên =========================================================================================================

        private void ToolStrip_nhanvien_Load(object sender, EventArgs e)
        {
            mts_nhanvien.SetToolStrip(dgv_nhanvien, gb_nhanvien, txt_nv_id, true, true, true);
            mts_nhanvien.ButtonClick += new EventHandler(XuLyButtonLuuNhanVien);
            mts_nhanvien.ButtonRefesh+= new EventHandler(XuLyRefeshNhanVien);
            mts_nhanvien.ButtonXoa += new EventHandler(XuLyXoaNhanVien);
        }
        private void XuLyXoaNhanVien(object sender, EventArgs e)
        {
            if (dgv_nhanvien.RowCount >0)
            {
                int position = dgv_nhanvien.CurrentCell.RowIndex;
                int id = int.Parse(dgv_nhanvien.Rows[position].Cells[0].Value.ToString());
                if (bussiness.checkexsistQuyen(id))
                {
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
                    return;
                }
                if (bussiness.xoaNhanVien(id))
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công! Đã xảy ra lỗi trong quá trình xóa.", "THÔNG BÁO");
            }
            LoadGridViewNhanVien();
        }
        private void XuLyRefeshNhanVien(object sennder, EventArgs e)
        {
            LoadGridViewNhanVien();
        }
        private void XuLyButtonLuuNhanVien(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_nv_id.Text))
            {
                int id=int.Parse(txt_nv_id.Text);
                bool nghiviec=false;
                if(cbb_nv_nghiviec.SelectedIndex==0)
                    nghiviec=true;
                String manhanvien=txt_nv_manv.Text.ToString().Trim();
                String matkhau=ps.MaHoaPassword(txt_nv_matkhau.Text.ToString().Trim());
                String tennhanvien=txt_nv_tennv.Text.ToString().Trim();
                int id_congty=int.Parse(Program.id_congty);
                if (manhanvien == "")
                {
                    MessageBox.Show("Hãy nhập tài khoản!", "THÔNG BÁO");
                }
                else if (matkhau == "")
                {
                    MessageBox.Show("Hãy nhập mật khẩu", "THÔNG BÁO");
                }
                else if (bussiness.timNhanVien(id))
                {
                    if (bussiness.suaNhanVien(id, manhanvien, tennhanvien, matkhau, nghiviec))
                        MessageBox.Show("Cập nhật nhân viên thành công","THÔNG BÁO");
                    else
                        MessageBox.Show("Cập nhật nhân viên thất bại","THÔNG BÁO");
                }
                else
                {
                    if (!bussiness.timNhanVien(manhanvien))
                    {
                        if (bussiness.themNhanVien(id, manhanvien, tennhanvien, matkhau, id_congty))
                        {
                            MessageBox.Show("Thêm nhân viên thành công", "THÔNG BÁO");
                            LoadGridViewNhanVien();
                        }
                        else
                            MessageBox.Show("Thêm nhân viên thất bại", "THÔNG BÁO");
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại, hãy tạo tài khoản khác!","THÔNG BÁO");
                    }
                }
            }
            
        }
        private void LoadGridViewNhanVien()
        {
            dgv_nhanvien.DataSource = bussiness.getNhanVien();
        }

        private void dgv_nhanvien_SelectionChanged(object sender, EventArgs e)
        {
            int d = dgv_nhanvien.CurrentCell.RowIndex;
            if (d >= 0&& d< dgv_nhanvien.RowCount)
            {
                txt_nv_id.Text = dgv_nhanvien.Rows[d].Cells["ID_NHAN_VIEN"].Value.ToString();
                if (dgv_nhanvien.Rows[d].Cells["HO_TEN"].Value != null)
                {
                    txt_nv_tennv.Text = dgv_nhanvien.Rows[d].Cells["HO_TEN"].Value.ToString();
                }
                if (dgv_nhanvien.Rows[d].Cells["MA_NHAN_VIEN"].Value != null)
                {
                    txt_nv_manv.Text = dgv_nhanvien.Rows[d].Cells["MA_NHAN_VIEN"].Value.ToString();
                }
                if (dgv_nhanvien.Rows[d].Cells["NGHI_VIEC"].Value == null)
                {
                    cbb_nv_nghiviec.SelectedIndex = 1;
                    return;
                }
                  if(dgv_nhanvien.Rows[d].Cells["NGHI_VIEC"].Value.ToString()!="True")
                    cbb_nv_nghiviec.SelectedIndex = 1;
                   else
                    cbb_nv_nghiviec.SelectedIndex= 0;
                  return;
            }
        }


        // tab Thông tin chung =================================================================================================
        private void LoadThongTinChung()
        {
            var kq = bussiness.getThongTinChung(int.Parse(Program.id_congty));
            foreach (var tt in kq)
            {
                txt_thongtin_diachi.Text = tt.DIA_CHI;
                txt_thongtin_email.Text = tt.EMAIL;
                txt_thongtin_fax.Text = tt.FAX;
                txt_thongtin_ghichu.Text = tt.MO_TA;
                txt_thongtin_linhvuc.Text = tt.LINH_VUC;
                txt_thongtin_mathue.Text = tt.MA_SO_THUE;
                txt_thongtin_sdt.Text = tt.DIEN_THOAI;
                txt_thongtin_ten.Text = tt.TEN_CONG_TY;
                txt_thongtin_website.Text = tt.WEBSITE;
                MemoryStream memory = new MemoryStream(tt.LO_GO.ToArray());
                Image img = Image.FromStream(memory);
                if (img == null)
                    return;
                pictureBox1.Image = img;
            }
            
        }

        private void btn_thongtin_luu_Click(object sender, EventArgs e)
        {
            String ten = txt_thongtin_ten.Text.ToString().Trim();
            String diachi = txt_thongtin_diachi.Text.ToString().Trim();
            String dienthoai = txt_thongtin_sdt.Text.ToString().Trim();
            String fax = txt_thongtin_fax.Text.ToString().Trim();
            String email = txt_thongtin_email.Text.ToString().Trim();
            String website = txt_thongtin_website.Text.ToString().Trim();
            String masothue = txt_thongtin_mathue.Text.ToString().Trim();
            String linhvuc = txt_thongtin_linhvuc.Text.ToString().Trim();
            String mota = txt_thongtin_ghichu.Text.ToString().Trim();
            String[] thongtin = { ten, diachi,dienthoai,fax,website,email,masothue,linhvuc,mota};
            if (ten == "")
            {
                MessageBox.Show("Hãy nhập tên công ty", "THÔNG BÁO");
            }
            else if (bussiness.suaThongTin(int.Parse(Program.id_congty), thongtin))
            {
                MessageBox.Show("Cập nhật thành công", "THÔNG BÁO");
                LoadThongTinChung();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống.\nCập nhật thất bại!", "THÔNG BÁO");
            }

        }

        private void btn_thongtin_thoat_Click(object sender, EventArgs e)
        {
            tab_thongtin.PageVisible = false;
        }
        


        //tab loại văn bản ================================================================================================
        private void LoadLoaiVanBan()
        {
            dgv_loaivanban.DataSource = bussiness.getLoaiVanBan();
        }

        private void mts_loaivanban_Load(object sender, EventArgs e)
        {
            mts_loaivanban.SetToolStrip(dgv_loaivanban, gb_loaivanban, txt_loaivanban_id, true, true, true);
            mts_loaivanban.ButtonRefesh += new EventHandler(XuLyRefeshLoaiVanBan);
            mts_loaivanban.ButtonXoa += new EventHandler(XuLyXoaLoaiVanBan);
            mts_loaivanban.ButtonClick += new EventHandler(XuLyLuuLoaiVanBan);
            
        }

        private void XuLyLuuLoaiVanBan(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_loaivanban_id.Text))
            {
                int id = int.Parse(txt_loaivanban_id.Text);
                String maloaivanban = txt_loaivanban_maloai.Text.ToString().Trim();
                String tenloai = txt_loaivanban_tenloai.Text.ToString().Trim();
                String mota = txt_loaivanban_ghichu.Text.ToString().Trim();
                if (maloaivanban == "")
                {
                    MessageBox.Show("Hãy nhập mã loại", "THÔNG BÁO");
                }
                else if (tenloai == "")
                {
                    MessageBox.Show("Hãy nhập tên loại", "THÔNG BÁO");
                }
                else if (bussiness.timLoaiVanBan(id))
                {
                    if (bussiness.suaLoaiVanBan(id,maloaivanban,tenloai,mota))
                        MessageBox.Show("Cập nhật loại văn bản thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
                }
                else
                {
                    if (bussiness.themLoaiVanBan(id,maloaivanban,tenloai,mota))
                        MessageBox.Show("Thêm loại văn bản thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Thêm loại văn bản thất bại", "THÔNG BÁO");

                }
            }
            LoadLoaiVanBan();
        }
        private void XuLyXoaLoaiVanBan(object sender, EventArgs e)
        {
            if (dgv_loaivanban.RowCount >0)
            {
                int position = dgv_loaivanban.CurrentCell.RowIndex;
                int id = int.Parse(dgv_loaivanban.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoaLoaiVanBan(id))
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công", "THÔNG BÁO");
            }
            LoadLoaiVanBan();
        }

        private void XuLyRefeshLoaiVanBan(object sender, EventArgs e)
        {
            LoadLoaiVanBan();
        }
        private void dgv_loaivanban_SelectionChanged(object sender, EventArgs e)
        {
            int d = dgv_loaivanban.CurrentCell.RowIndex;
            if (d >= 0 && d < dgv_loaivanban.RowCount)
            {
                txt_loaivanban_id.Text = dgv_loaivanban.Rows[d].Cells["ID_LOAI_VAN_BAN"].Value.ToString();
                if (dgv_loaivanban.Rows[d].Cells["TEN_LOAI_VAN_BAN"].Value != null)
                {
                    txt_loaivanban_tenloai.Text = dgv_loaivanban.Rows[d].Cells["TEN_LOAI_VAN_BAN"].Value.ToString();
                }
                if (dgv_loaivanban.Rows[d].Cells["MA_LOAI_VAN_BAN"].Value != null)
                {
                    txt_loaivanban_maloai.Text = dgv_loaivanban.Rows[d].Cells["MA_LOAI_VAN_BAN"].Value.ToString();
                }
                if (dgv_loaivanban.Rows[d].Cells["MO_TA"].Value != null)
                {
                    txt_loaivanban_ghichu.Text = dgv_loaivanban.Rows[d].Cells["MO_TA"].Value.ToString();
                }
                return;
            }
        }
        //tab  Nơi ban hành ===========================================================================
        private void myToolStrip1_Load(object sender, EventArgs e)
        {
            mts_noibanhanh.SetToolStrip(dgv_noibanhanh, gb_noibanhanh, txt_noibanhanh_id, true, true, true);
            mts_noibanhanh.ButtonClick += new EventHandler(XuLySuaNoiBanHanh);
            mts_noibanhanh.ButtonRefesh += new EventHandler(XuLyRefeshNoiBanHanh);
            mts_noibanhanh.ButtonXoa += new EventHandler(XuLyXoaNoiBanHanh);
        }
        private void XuLyRefeshNoiBanHanh(object sender, EventArgs e)
        {
            LoadNoiBanHanh();
        }
        private void XuLyXoaNoiBanHanh(object sender, EventArgs e)
        {
            if (dgv_noibanhanh.RowCount > 0)
            {
                int position = dgv_noibanhanh.CurrentCell.RowIndex;
                int id = int.Parse(dgv_noibanhanh.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoaNoiBanHanh(id))
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
            }
            LoadNoiBanHanh();
        }
        private void XuLySuaNoiBanHanh(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_noibanhanh_id.Text))
            {
                int id = int.Parse(txt_noibanhanh_id.Text);
                String tennbh = txt_noibanhanh_ten.Text.ToString().Trim();
                String mota = txt_noibanhanh_mota.Text.ToString().Trim();
                if (tennbh == "")
                {
                    MessageBox.Show("Hãy nhập tên nơi ban hành", "THÔNG BÁO");
                }
                else if (bussiness.timNoiBanHanh(id))
                {
                    if (bussiness.suaNoiBanHanh(id, tennbh, mota))
                        MessageBox.Show("Cập nhật nơi ban hành thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Cập nhật nơi ban hành thất bại", "THÔNG BÁO");
                }
                else
                {
                    if (bussiness.themNoiBanHanh(id, tennbh, mota))
                        MessageBox.Show("Thêm nơi ban hành thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Thêm nơi ban hành thất bại", "THÔNG BÁO");

                }
            }
            LoadNoiBanHanh();
        }

        private void LoadNoiBanHanh()
        {
            dgv_noibanhanh.DataSource = bussiness.getNoiBanHanh();
        }

        private void dgv_noibanhanh_SelectionChanged(object sender, EventArgs e)
        {
            int d = dgv_noibanhanh.CurrentCell.RowIndex;
            if (d >= 0 && d < dgv_noibanhanh.RowCount)
            {
                txt_noibanhanh_id.Text = dgv_noibanhanh.Rows[d].Cells["ID_NOI_BAN_HANH"].Value.ToString();
                if (dgv_noibanhanh.Rows[d].Cells["NOI_BAN_HANH1"].Value != null)
                {
                    txt_noibanhanh_ten.Text = dgv_noibanhanh.Rows[d].Cells["NOI_BAN_HANH1"].Value.ToString();
                }
                if (dgv_noibanhanh.Rows[d].Cells["MO_TA_NBH"].Value != null)
                {
                    txt_noibanhanh_mota.Text = dgv_noibanhanh.Rows[d].Cells["MO_TA_NBH"].Value.ToString();
                }
                return;
            }
        }
        //Phòng ban============================================================

        private void LoadPhongBan()
        {
            dgv_phongban.DataSource = bussiness.getPhongBan();
        }

        private void mts_phongban_Load(object sender, EventArgs e)
        {

            mts_phongban.SetToolStrip(dgv_phongban, gb_phongban, txt_phongban_id, true, true, true);
            mts_phongban.ButtonClick += new EventHandler(XuLySuaPhongBan);
            mts_phongban.ButtonRefesh += new EventHandler(XuLyRefeshPhongBan);
            mts_phongban.ButtonXoa += new EventHandler(XuLyXoaPhongBan);
        }
        private void XuLyRefeshPhongBan(object sender, EventArgs e)
        {
            LoadPhongBan();
        }
        private void XuLyXoaPhongBan(object sender, EventArgs e)
        {
            if (dgv_phongban.RowCount >0)
            {
                int position = dgv_phongban.CurrentCell.RowIndex;
                int id = int.Parse(dgv_phongban.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoaPhongBan(id))
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
            }
            LoadPhongBan();
        }
        private void XuLySuaPhongBan(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_phongban_id.Text))
            {
                int id = int.Parse(txt_phongban_id.Text);
                String tennbh = txt_phongban_ten.Text.ToString().Trim();
                if (tennbh == "")
                {
                    MessageBox.Show("Hãy nhập tên phòng ban", "THÔNG BÁO");
                }
                else if (bussiness.timPhongBan(id))
                {
                    if (bussiness.suaPhongBan(id, tennbh))
                        MessageBox.Show("Cập nhật nơi ban hành thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Cập nhật nơi ban hành thất bại", "THÔNG BÁO");
                }
                else
                {
                    if (bussiness.themPhongBan(id, tennbh))
                        MessageBox.Show("Thêm nơi ban hành thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Thêm nơi ban hành thất bại", "THÔNG BÁO");

                }
            }
            LoadPhongBan();
        }
        private void dgv_phongban_SelectionChanged(object sender, EventArgs e)
        {
            int d = dgv_phongban.CurrentCell.RowIndex;
            if (d >= 0 && d < dgv_phongban.RowCount)
            {
                txt_phongban_id.Text = dgv_phongban.Rows[d].Cells["ID_PHONG_BAN"].Value.ToString();
                if (dgv_phongban.Rows[d].Cells["TEN_PHONG_BAN"].Value != null)
                {
                    txt_phongban_ten.Text = dgv_phongban.Rows[d].Cells["TEN_PHONG_BAN"].Value.ToString();
                }
                return;
            }
        }

        //Sổ văn bản==============================================================================
        private void LoadSoVanBan(int nam)
        {
            cbb_nam.SelectedIndex = nam-1990;
            dgv_sovanban_hide.DataSource = bussiness.getsovanban();
            dgv_sovanban.DataSource = bussiness.getsovanban(nam);
        }

        private void cbb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSoVanBan(1990 + cbb_nam.SelectedIndex);
        }

        private void mts_sovanban_Load(object sender, EventArgs e)
        {
            mts_sovanban.SetToolStrip(dgv_sovanban_hide, gb_sovanban, txt_sovanban_id, true, true, true);
            mts_sovanban.ButtonRefesh += new EventHandler(XuLyRefeshSoVanBan);
            mts_sovanban.ButtonXoa += new EventHandler(XuLyXoaSoVanBan);
            mts_sovanban.ButtonClick += new EventHandler(XuLySuaSoVanBan);
        }
        private void XuLyRefeshSoVanBan(object sender, EventArgs e)
        {
            LoadSoVanBan(2019);
        }
        private void XuLyXoaSoVanBan(object sender, EventArgs e)
        {
            if (dgv_sovanban.RowCount >0)
            {
                int position = dgv_sovanban.CurrentCell.RowIndex;
                int id = int.Parse(dgv_sovanban.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoasovanban(id))
                {
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                    tab_vanbanden.PageVisible = false;
                }
                else
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
            }
            LoadSoVanBan(2019);
        }
        private void XuLySuaSoVanBan(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_sovanban_id.Text))
            {
                int id = int.Parse(txt_sovanban_id.Text);
                String tennbh = txt_sovanban_tensvb.Text.ToString().Trim();
                int nam = cbb_nam.SelectedIndex + 1990;
                bool loai = false;
                if (chk_soden.Checked == true)
                    loai = true;
                if (tennbh == "")
                {
                    MessageBox.Show("Hãy nhập tên sổ văn bản", "THÔNG BÁO");
                }
                else if (bussiness.timsovanban(id))
                {
                    if (bussiness.suasovanban(id, tennbh,loai,nam))
                        MessageBox.Show("Cập nhật sổ văn bản thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Cập nhật sổ văn bản thất bại", "THÔNG BÁO");
                }
                else
                {
                    if (bussiness.themsovanban(id, tennbh,loai,nam))
                        MessageBox.Show("Thêm sổ văn bản thành công", "THÔNG BÁO");
                    else
                        MessageBox.Show("Thêm sổ văn bản thất bại", "THÔNG BÁO");

                }
            }
            LoadSoVanBan(2019);
        }
        private void dgv_sovanban_SelectionChanged(object sender, EventArgs e)
        {
            int d = dgv_sovanban.CurrentCell.RowIndex;
            if (d >= 0 && d < dgv_sovanban.RowCount)
            {
                txt_sovanban_id.Text = dgv_sovanban.Rows[d].Cells["ID_SO_VAN_BAN"].Value.ToString();
                if (dgv_sovanban.Rows[d].Cells["TEN_SO_VAN_BAN"].Value != null)
                {
                    txt_sovanban_tensvb.Text = dgv_sovanban.Rows[d].Cells["TEN_SO_VAN_BAN"].Value.ToString();
                }
                if (dgv_sovanban.Rows[d].Cells["LOAI_SO_DI_DEN"].Value == null)
                {
                    chk_soden.Checked = false;
                    return;
                }
                if (dgv_sovanban.Rows[d].Cells["LOAI_SO_DI_DEN"].Value.ToString() == "False")
                    chk_soden.Checked = false;
                else
                    chk_soden.Checked = true;
                return;
            }
        }

        //Danh sách văn bản đến================================================================================
        private void loadVanBanDen(DateTime date_from, DateTime date_to)
        {
            dgv_dsvbden.DataSource=bussiness.getvanbanden(date_from, date_to);
        }

        private void dtp_dsvbden_from_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_dsvbden_from.Value > dtp_dsvbden_to.Value)
                dtp_dsvbden_to.Value = dtp_dsvbden_from.Value;
            loadVanBanDen(dtp_dsvbden_from.Value, dtp_dsvbden_to.Value);
        }

        private void mts_ds_vanbanden_Load(object sender, EventArgs e)
        {
            mts_ds_vanbanden.SetToolStrip(dgv_dsvbden, null, null, false, true, false);
            mts_ds_vanbanden.ButtonXoa += new EventHandler(XuLyXoaVanBanDen);
            mts_ds_vanbanden.ButtonRefesh += new EventHandler(XuLyLoadVanBanDen);
        }
        private void XuLyLoadVanBanDen(object sender, EventArgs e)
        {
            loadVanBanDen(dtp_dsvbden_from.Value,dtp_dsvbden_to.Value);
        }
        private void XuLyXoaVanBanDen(object sender, EventArgs e)
        {
            if (dgv_dsvbden.RowCount >0)
            {
                int position = dgv_dsvbden.CurrentCell.RowIndex;
                int id = int.Parse(dgv_dsvbden.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoavanbanden(id))
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
            }
            loadVanBanDen(dtp_dsvbden_from.Value, dtp_dsvbden_to.Value);
        }

        private void LoadVanBanDenMoi()
        {
            foreach (Control c in gb_vbden.Controls)
            {
                if (c is Label || c is Button)
                {
                }
                else
                {
                    c.Text = "";
                }
            }
            txt_vbden_noidung.Text = "";
            txt_vbden_trichyeu.Text = "";
            txt_vbden_id.Text = (bussiness.getMaxIDVanBanDen()+1).ToString();
            string[] nguoi = bussiness.getThietLapThongTin();
            txt_vbden_ngky.Text = nguoi[0];
            txt_vbden_ngduyet.Text = nguoi[2];
            txt_vbden_ngnhan.Text = nguoi[3];
            txt_vbden_sokyhieu.Text = txt_vbden_id.Text + "/";
            LoadComboboxVBDen();
            gb_vbden_file.Enabled = false;
        }

        private void LoadComboboxVBDen()
        {
            cbb_vbden_loaivb.DataSource = bussiness.getLoaiVanBan();
            cbb_vbden_loaivb.DisplayMember = "TEN_LOAI_VAN_BAN";
            cbb_vbden_loaivb.ValueMember = "ID_LOAI_VAN_BAN";
            cbb_vbden_noibh.DataSource = bussiness.getNoiBanHanh();
            cbb_vbden_noibh.DisplayMember = "NOI_BAN_HANH1";
            cbb_vbden_noibh.ValueMember = "ID_NOI_BAN_HANH";
            var dict = new Dictionary<int, string>();
            foreach (DAL.SO_VAN_BAN svb in bussiness.getsovanban(true))
            {
                dict.Add(int.Parse(svb.ID_SO_VAN_BAN.ToString()),svb.NAM.ToString()+"/" +svb.TEN_SO_VAN_BAN.ToString());
            }
            cbb_vbden_svb.DataSource = dict.ToList();
            cbb_vbden_svb.DisplayMember = "Value";
            cbb_vbden_svb.ValueMember = "Key";
        }
        private void btn_dsvbden_taomoi_Click(object sender, EventArgs e)
        {
            if (btn_vanbanden.Enabled == true)
            {
                ShowTab(tab_vanbanden);
                LoadVanBanDenMoi();
            }
            else
            {
                MessageBox.Show("Bạn không được cấp quyền truy cập", "THÔNG BÁO");
            }
        }

        private void btn_dsvbden_sua_Click(object sender, EventArgs e)
        {
            if (btn_vanbanden.Enabled == true)
            {
                if (dgv_dsvbden.RowCount > 0)
                {
                    ShowTab(tab_vanbanden);
                    loadVanBanDen(int.Parse(dgv_dsvbden.CurrentRow.Cells[0].Value.ToString()));
                    loadFileVanBanDen();
                }
            }
            else
            {
                MessageBox.Show("Bạn không được cấp quyền truy cập", "THÔNG BÁO");
            }
        }

        private void dtp_dsvbden_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_dsvbden_from.Value > dtp_dsvbden_to.Value)
                dtp_dsvbden_from.Value = dtp_dsvbden_to.Value;
            loadVanBanDen(dtp_dsvbden_from.Value, dtp_dsvbden_to.Value);
        }
        private void btn_vbden_add_Click(object sender, EventArgs e)
        {
            LoadVanBanDenMoi();
        }
        private void btn_vdben_luu_Click(object sender, EventArgs e)
        {
            if (bussiness.timvanbanden(int.Parse(txt_vbden_id.Text)))
            {
                if (cbb_vbden_loaivb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn loại văn bản", "THÔNG BÁO");
                else if (cbb_vbden_noibh.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn nơi ban hành", "THÔNG BÁO");
                else if (cbb_vbden_svb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn sổ văn bản", "THÔNG BÁO");
                else
                {
                    int id = int.Parse(txt_vbden_id.Text);
                    int svb = int.Parse(cbb_vbden_svb.SelectedValue.ToString());
                    int lvb = int.Parse(cbb_vbden_loaivb.SelectedValue.ToString());
                    int dvd = int.Parse(cbb_vbden_noibh.SelectedValue.ToString());
                    DateTime ngden = dtp_vbden_ngayden.Value;
                    DateTime ngbanhanh = dtp_vbden_ngaybanhanh.Value;
                    string sokyhieu = txt_vbden_sokyhieu.Text.Trim();
                    string soden = (txt_vbden_soden.Text.Trim() == "" ? "0" : txt_vbden_soden.Text.Trim());
                    string trichyeu = txt_vbden_trichyeu.Text;
                    string ghichu = txt_vbden_noidung.Text;
                    string ngnhan = txt_vbden_ngnhan.Text;
                    string ngky = txt_vbden_ngky.Text;
                    string ngduyet = txt_vbden_ngduyet.Text;
                    string sotrang = txt_vbden_sotrang.Text.Trim();
                    int[] _id = { svb, lvb, dvd };
                    string[] _thongtin = { sokyhieu, soden, trichyeu, ghichu, ngnhan, ngky, ngduyet, sotrang };
                    DateTime[] _ngay = { ngbanhanh, ngden };
                    if (sokyhieu == "")
                    {
                        MessageBox.Show("Hãy nhập số ký hiệu", "THÔNG BÁO");
                    }
                    else if (sotrang == "")
                    {
                        MessageBox.Show("Hãy nhập số trang", "THÔNG BÁO");
                    }
                    else if (ngnhan == "")
                    {
                        MessageBox.Show("Hãy nhập tên người nhận", "THÔNG BÁO");
                    }
                    else if (ngky == "")
                    {
                        MessageBox.Show("Hãy nhập tên người ký", "THÔNG BÁO");
                    }
                    else if (ngduyet == "")
                    {
                        MessageBox.Show("Hãy nhập tên người duyệt", "THÔNG BÁO");
                    }
                    else if (bussiness.SuaVanBanDen(id,_id, _thongtin, _ngay))
                    {
                        MessageBox.Show("Cập nhật thành công", "THÔNG BÁO");
                        gb_vbden_file.Enabled = true;
                    }
                    else
                        MessageBox.Show("Cập nhật thất bại", "THÔNG BÁO");
                }
            }
            else
            {
                if (cbb_vbden_loaivb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn loại văn bản", "THÔNG BÁO");
                else if (cbb_vbden_noibh.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn nơi ban hành", "THÔNG BÁO");
                else if (cbb_vbden_svb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn sổ văn bản", "THÔNG BÁO");
                else
                {
                    int id = int.Parse(txt_vbden_id.Text);
                    int svb = int.Parse(cbb_vbden_svb.SelectedValue.ToString());
                    int lvb = int.Parse(cbb_vbden_loaivb.SelectedValue.ToString());
                    int dvd = int.Parse(cbb_vbden_noibh.SelectedValue.ToString());
                    DateTime ngden = dtp_vbden_ngayden.Value;
                    DateTime ngbanhanh = dtp_vbden_ngaybanhanh.Value;
                    string sokyhieu = txt_vbden_sokyhieu.Text.Trim();
                    string soden = (txt_vbden_soden.Text.Trim() == "" ? "0" : txt_vbden_soden.Text.Trim());
                    string trichyeu = txt_vbden_trichyeu.Text;
                    string ghichu = txt_vbden_noidung.Text;
                    string ngnhan = txt_vbden_ngnhan.Text;
                    string ngky = txt_vbden_ngky.Text;
                    string ngduyet = txt_vbden_ngduyet.Text;
                    string sotrang = txt_vbden_sotrang.Text.Trim();
                    int[] _id = { id, svb, lvb, dvd };
                    string[] _thongtin = { sokyhieu, soden, trichyeu, ghichu, ngnhan, ngky, ngduyet, sotrang };
                    DateTime[] _ngay = { ngbanhanh, ngden }; 
                    if (sokyhieu == "")
                    {
                        MessageBox.Show("Hãy nhập số ký hiệu", "THÔNG BÁO");
                    }
                    else if (sotrang == "")
                    {
                        MessageBox.Show("Hãy nhập số trang", "THÔNG BÁO");
                    }
                    else if (ngnhan == "")
                    {
                        MessageBox.Show("Hãy nhập tên người nhận", "THÔNG BÁO");
                    }
                    else if (ngky == "")
                    {
                        MessageBox.Show("Hãy nhập tên người ký", "THÔNG BÁO");
                    }
                    else if (ngduyet == "")
                    {
                        MessageBox.Show("Hãy nhập tên người duyệt", "THÔNG BÁO");
                    }
                    else if (bussiness.ThemVanBanDen(_id, _thongtin, _ngay))
                    {
                        MessageBox.Show("Thêm thành công", "THÔNG BÁO");
                        gb_vbden_file.Enabled = true;
                    }
                    else
                        MessageBox.Show("Thêm thất bại", "THÔNG BÁO");
                }
            }
            
        }

        public void loadVanBanDen(int id)
        {
            LoadComboboxVBDen();
            DAL.VAN_BAN_DEN vbd = bussiness.timthongtinvanbanden(id);
            if (vbd != null)
            {
                txt_vbden_id.Text = vbd.ID_VAN_BAN_DEN.ToString();
                cbb_vbden_loaivb.SelectedValue = vbd.ID_LOAI_VAN_BAN;
                cbb_vbden_noibh.SelectedValue = vbd.ID_DON_VI_DEN;
                cbb_vbden_svb.SelectedValue= int.Parse(vbd.ID_SO_VAN_BAN.ToString());
                txt_vbden_ngduyet.Text = vbd.NGUOI_DUYET_VAN_BAN.ToString();
                txt_vbden_ngky.Text = vbd.NGUOI_KY_VAN_BAN.ToString();
                txt_vbden_ngnhan.Text = vbd.NGUOI_NHAN_VAN_BAN.ToString();
                txt_vbden_noidung.Text = vbd.GHI_CHU.ToString();
                txt_vbden_soden.Text = vbd.SO_DEN.ToString();
                txt_vbden_sokyhieu.Text = vbd.SO_KY_HIEU.ToString();
                txt_vbden_sotrang.Text = vbd.SO_TRANG.ToString();
                txt_vbden_trichyeu.Text = vbd.TRICH_YEU.ToString();
                dtp_vbden_ngaybanhanh.Value = DateTime.Parse(vbd.NGAY_BAN_HANH.ToString());
                dtp_vbden_ngayden.Value =DateTime.Parse( vbd.NGAY_DEN.ToString());
                gb_vbden_file.Enabled = true;
            }
        }
        private void txt_vbden_soden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void loadFileVanBanDen()
        {
            dgv_vbden_file.DataSource = bussiness.getFileVBDen(int.Parse(dgv_dsvbden.CurrentRow.Cells[0].Value.ToString()));
        }
        private void btn_vbden_addfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string filename = fd.FileName;
                    bussiness.ThemFileVBDen(int.Parse(txt_vbden_id.Text), filename);
                    MessageBox.Show("Thêm file thành công","THÔNG BÁO");
                    loadFileVanBanDen();
                }
            }
        }

        private void btn_vbden_deletefile_Click(object sender, EventArgs e)
        {
            if (dgv_vbden_file.RowCount > 0)
            {
                bussiness.XoaFileVBDen(int.Parse(dgv_vbden_file.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("Xóa file thành công", "THÔNG BÁO");
                loadFileVanBanDen();
            }
        }
        private void btn_vbden_readfile_Click(object sender, EventArgs e)
        {
            if (dgv_vbden_file.RowCount > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(@dgv_vbden_file.CurrentRow.Cells["TEN_TAI_LIEU"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Đọc file thất bại! File không tồn tại ở vị trí cũ", "THÔNG BÁO");
                }
            }
        }
        //Danh sách văn bản đi=======================================================================
        private void loadVanBanDi(DateTime date_from, DateTime date_to)
        {
            dgv_dsvanbandi.DataSource = bussiness.getVanBanDi(date_from, date_to);
        }

        private void mts_dsvbdi_Load(object sender, EventArgs e)
        {
            mts_dsvbdi.SetToolStrip(dgv_dsvanbandi, null, null, false, true, false);
            mts_dsvbdi.ButtonXoa += new EventHandler(XuLyXoaVanBanDi);
        }
        private void XuLyXoaVanBanDi(object sender, EventArgs e)
        {
            if (dgv_dsvanbandi.RowCount >0)
            {
                int position = dgv_dsvanbandi.CurrentCell.RowIndex;
                int id = int.Parse(dgv_dsvanbandi.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoaVanBanDi(id))
                {
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                    tab_vanbandi.PageVisible = false;
                }
                else
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
            }
            loadVanBanDi(dtp_dsvbdi_from.Value, dtp_dsvbdi_to.Value);
        }

        private void LoadVanBanDiMoi()
        {
            foreach (Control c in gb_vbdi.Controls)
            {
                if (c is Label || c is Button)
                {
                }
                else
                {
                    c.Text = "";
                }
            }
            txt_vbdi_noidung.Text = "";
            txt_vbdi_trichyeu.Text = "";
            txt_vbdi_id.Text = (bussiness.getMaxIDVanBanDi() + 1).ToString();
            string[] nguoi = bussiness.getThietLapThongTin();
            txt_vbdi_ngky.Text = nguoi[0];
            txt_vbdi_ngduyet.Text = nguoi[2];
            txt_vbdi_nggui.Text = nguoi[1];
            txt_vbdi_sokyhieu.Text = txt_vbdi_id.Text + "/";
            LoadComboboxVBdi();
            gb_vbdi_file.Enabled = false;
        }

        private void LoadComboboxVBdi()
        {
            cbb_vbdi_lvb.DataSource = bussiness.getLoaiVanBan();
            cbb_vbdi_lvb.DisplayMember = "TEN_LOAI_VAN_BAN";
            cbb_vbdi_lvb.ValueMember = "ID_LOAI_VAN_BAN";
            var dict = new Dictionary<int, string>();
            foreach (DAL.SO_VAN_BAN svb in bussiness.getsovanban(false))
            {
                dict.Add(int.Parse(svb.ID_SO_VAN_BAN.ToString()), svb.NAM.ToString() + "/" + svb.TEN_SO_VAN_BAN.ToString());
            }
            cbb_vbdi_svb.DataSource = dict.ToList();
            cbb_vbdi_svb.DisplayMember = "Value";
            cbb_vbdi_svb.ValueMember = "Key";
        }

        private void dtp_dsvbdi_from_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_dsvbdi_from.Value > dtp_dsvbdi_to.Value)
            {
                dtp_dsvbdi_to.Value = dtp_dsvbdi_from.Value;
                
            }
            loadVanBanDi(dtp_dsvbdi_from.Value, dtp_dsvbdi_to.Value);
        }

        private void dtp_dsvbdi_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_dsvbdi_from.Value > dtp_dsvbdi_to.Value)
            {
                dtp_dsvbdi_from.Value = dtp_dsvbdi_to.Value;
            }
            loadVanBanDi(dtp_dsvbdi_from.Value, dtp_dsvbdi_to.Value);
        }

        private void btn_dsvbdi_taomoi_Click(object sender, EventArgs e)
        {
            if(btn_vanbandi.Enabled==true)
            {
                ShowTab(tab_vanbandi);
                LoadVanBanDiMoi();
            }
            else
            {
                MessageBox.Show("Bạn không được cấp quyền truy cập", "THÔNG BÁO");
            }
        }

        private void btn_dsvbdi_sua_Click(object sender, EventArgs e)
        {
            if (btn_vanbandi.Enabled == true)
            {
                if (dgv_dsvanbandi.RowCount > 0)
                {
                    ShowTab(tab_vanbandi);
                    loadVanBanDi(int.Parse(dgv_dsvanbandi.CurrentRow.Cells[0].Value.ToString()));
                    loadFileVanBanDi();
                }
            }
            else
            {
                MessageBox.Show("Bạn không được cấp quyền truy cập", "THÔNG BÁO");
            }
            
        }
        private void btn_vbdi_add_Click(object sender, EventArgs e)
        {
            LoadVanBanDiMoi();
        }
        public void loadVanBanDi(int id)
        {
            LoadComboboxVBdi();
            DAL.VAN_BAN_DI vbd = bussiness.timthongtinVanBanDi(id);
            if (vbd != null)
            {
                txt_vbdi_id.Text = vbd.ID_VAN_BAN.ToString();
                cbb_vbdi_lvb.SelectedValue = vbd.ID_LOAI_VAN_BAN;
                cbb_vbdi_svb.SelectedValue = int.Parse(vbd.ID_SO_VAN_BAN.ToString());
                txt_vbdi_nggui.Text = vbd.NGUOI_GUI_VAN_BAN.ToString();
                txt_vbdi_ngky.Text = vbd.NGUOI_KY_VAN_BAN.ToString();
                txt_vbdi_ngduyet.Text = vbd.NGUOI_DUYET_VAN_BAN.ToString();
                txt_vbdi_noidung.Text = vbd.GHI_CHU.ToString();
                txt_vbdi_sodi.Text = vbd.SO_DI.ToString();
                txt_vbdi_sokyhieu.Text = vbd.SO_KY_HIEU.ToString();
                txt_vbdi_sotrang.Text = vbd.SO_TRANG.ToString();
                txt_vbdi_trichyeu.Text = vbd.TRICH_YEU.ToString();
                txt_vbdi_noinhan.Text = vbd.NOI_NHAN;
                txt_vbdi_slban.Text = vbd.SO_LUONG_BAN.ToString();
                dtp_vbdi_ngaybh.Value = DateTime.Parse(vbd.NGAY_BAN_HANH.ToString());
                gb_vbdi_file.Enabled = true;
            }
        }
        private void btn_vbdi_luu_Click(object sender, EventArgs e)
        {
            if (bussiness.timVanBanDi(int.Parse(txt_vbdi_id.Text)))
            {
                if (cbb_vbdi_lvb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn loại văn bản", "THÔNG BÁO");
                else if (cbb_vbdi_svb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn sổ văn bản", "THÔNG BÁO");
                else
                {
                    int id = int.Parse(txt_vbdi_id.Text);
                    int svb = int.Parse(cbb_vbdi_svb.SelectedValue.ToString());
                    int lvb = int.Parse(cbb_vbdi_lvb.SelectedValue.ToString());
                    DateTime ngbanhanh = dtp_vbdi_ngaybh.Value;
                    string sokyhieu = txt_vbdi_sokyhieu.Text.Trim();
                    string soDi = (txt_vbdi_sodi.Text.Trim() == "" ? "0" : txt_vbdi_sodi.Text.Trim());
                    string trichyeu = txt_vbdi_trichyeu.Text;
                    string ghichu = txt_vbdi_noidung.Text;
                    string nggui = txt_vbdi_nggui.Text;
                    string ngky = txt_vbdi_ngky.Text;
                    string noinhan=txt_vbdi_noinhan.Text;
                    string soluong=(txt_vbdi_slban.Text.Trim()==""?"0":txt_vbdi_slban.Text);
                    string ngduyet = txt_vbdi_ngduyet.Text;
                    string sotrang = txt_vbdi_sotrang.Text.Trim();
                    int[] _id = { svb, lvb };
                    string[] _thongtin = { sokyhieu, soDi, trichyeu, ghichu, ngky, ngky, ngduyet, sotrang,soluong,noinhan };
                    if (sokyhieu == "")
                    {
                        MessageBox.Show("Hãy nhập số ký hiệu", "THÔNG BÁO");
                    }
                    else if (noinhan == "")
                    {
                        MessageBox.Show("Hãy nhập nơi nhận", "THÔNG BÁO");
                    }
                    else if (sotrang == "")
                    {
                        MessageBox.Show("Hãy nhập số trang", "THÔNG BÁO");
                    }
                    else if (ngduyet == "")
                    {
                        MessageBox.Show("Hãy nhập Tên người duyệt", "THÔNG BÁO");
                    }
                    else if (nggui == "")
                    {
                        MessageBox.Show("Hãy nhập tên người gửi", "THÔNG BÁO");
                    }
                    else if (ngky == "")
                    {
                        MessageBox.Show("Hãy nhập tên người ký", "THÔNG BÁO");
                    }
                    else if (bussiness.SuaVanBanDi(id,_id,_thongtin,ngbanhanh))
                    {
                        MessageBox.Show("Cập nhật thành công", "THÔNG BÁO");
                        gb_vbdi_file.Enabled = true;
                    }
                    else
                        MessageBox.Show("Cập nhật thất bại", "THÔNG BÁO");
                }
            }
            else
            {
                if (cbb_vbdi_lvb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn loại văn bản", "THÔNG BÁO");
                else if (cbb_vbdi_svb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn sổ văn bản", "THÔNG BÁO");
                else
                {
                    int id = int.Parse(txt_vbdi_id.Text);
                    int svb = int.Parse(cbb_vbdi_svb.SelectedValue.ToString());
                    int lvb = int.Parse(cbb_vbdi_lvb.SelectedValue.ToString());
                    DateTime ngbanhanh = dtp_vbdi_ngaybh.Value;
                    string sokyhieu = txt_vbdi_sokyhieu.Text.Trim();
                    string soDi = (txt_vbdi_sodi.Text.Trim() == "" ? "0" : txt_vbdi_sodi.Text.Trim());
                    string trichyeu = txt_vbdi_trichyeu.Text;
                    string ghichu = txt_vbdi_noidung.Text;
                    string nggui = txt_vbdi_nggui.Text;
                    string ngky = txt_vbdi_ngky.Text;
                    string noinhan=txt_vbdi_noinhan.Text;
                    string soluong = (txt_vbdi_slban.Text.Trim() == "" ? "0" : txt_vbdi_slban.Text);
                    string ngduyet = txt_vbdi_ngduyet.Text;
                    string sotrang = txt_vbdi_sotrang.Text.Trim();
                    int[] _id = { id, svb, lvb };
                    string[] _thongtin = { sokyhieu, soDi, trichyeu, ghichu, nggui, ngky, ngduyet, sotrang,soluong,noinhan };
                    if (sokyhieu == "")
                    {
                        MessageBox.Show("Hãy nhập số ký hiệu", "THÔNG BÁO");
                    }
                    else if (noinhan == "")
                    {
                        MessageBox.Show("Hãy nhập nơi nhận", "THÔNG BÁO");
                    }
                    else if (sotrang == "")
                    {
                        MessageBox.Show("Hãy nhập số trang", "THÔNG BÁO");
                    }
                    else if (ngduyet == "")
                    {
                        MessageBox.Show("Hãy nhập Tên người duyệt", "THÔNG BÁO");
                    }
                    else if (nggui == "")
                    {
                        MessageBox.Show("Hãy nhập tên người gửi", "THÔNG BÁO");
                    }
                    else if (ngky == "")
                    {
                        MessageBox.Show("Hãy nhập tên người ký", "THÔNG BÁO");
                    }
                    else if (bussiness.ThemVanBanDi(_id,_thongtin,ngbanhanh))
                    {
                        MessageBox.Show("Thêm thành công", "THÔNG BÁO");
                        gb_vbdi_file.Enabled = true;
                    }
                    else
                        MessageBox.Show("Thêm thất bại", "THÔNG BÁO");
                }
            }
        }
        private void txt_vbdi_slban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txt_vbdi_sodi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //File Văn bản đi===============
        private void loadFileVanBanDi()
        {
            dgv_vdi_file.DataSource = bussiness.getFileVBDi(int.Parse(dgv_dsvanbandi.CurrentRow.Cells[0].Value.ToString()));
        }
        private void btn_vbDi_addfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string filename = fd.FileName;
                    bussiness.ThemFileVBDi(int.Parse(txt_vbdi_id.Text), filename);
                    MessageBox.Show("Thêm file thành công", "THÔNG BÁO");
                    loadFileVanBanDi();
                }
            }
        }

        private void btn_vbDi_deletefile_Click(object sender, EventArgs e)
        {
            if (dgv_vdi_file.RowCount > 0)
            {
                bussiness.XoaFileVBDi(int.Parse(dgv_vdi_file.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("Xóa file thành công", "THÔNG BÁO");
                loadFileVanBanDi();
            }
        }
        private void btn_vbDi_readfile_Click(object sender, EventArgs e)
        {
            if (dgv_vdi_file.RowCount > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(@dgv_vdi_file.CurrentRow.Cells["TEN_TAI_LIEU_VBD"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Đọc file thất bại! File không tồn tại ở vị trí cũ", "THÔNG BÁO");
                }
            }
        }
        //Danh sách văn bản nội bộ.=============================================================================
        private void LoadVanBanNoiBo(DateTime date_from,DateTime date_to)
        {
            dgv_dsvbnoibo.DataSource = bussiness.getVanBanNoiBo(date_from, date_to);
        }

        private void mts_dsvanbannoibo_Load(object sender, EventArgs e)
        {
            mts_dsvanbannoibo.SetToolStrip(dgv_dsvbnoibo, null, null, false, true, false);
            mts_dsvanbannoibo.ButtonXoa+= new EventHandler(XuLyXoaVanBanNoiBo);
        }
        private void XuLyXoaVanBanNoiBo(object sender, EventArgs e)
        {
            if (dgv_dsvbnoibo.RowCount >0)
            {
                int position = dgv_dsvbnoibo.CurrentCell.RowIndex;
                int id = int.Parse(dgv_dsvbnoibo.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoaVanBanNoiBo(id))
                    MessageBox.Show("Bạn đã xóa thành công", "THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công!\n Hãy đảm bảo thông tin chưa tham chiếu đến đối tượng khác.", "THÔNG BÁO");
            }
            LoadVanBanNoiBo(dtp_dsvbnb_to.Value, dtp_dsvbnb_from.Value);
        }

        private void dtp_dsvbnb_from_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_dsvbnb_from.Value > dtp_dsvbnb_to.Value)
            {
                dtp_dsvbnb_to.Value = dtp_dsvbnb_from.Value;
            }
            LoadVanBanNoiBo(dtp_dsvbnb_from.Value, dtp_dsvbnb_to.Value);
        }

        private void dtp_dsvbnb_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_dsvbnb_from.Value > dtp_dsvbnb_to.Value)
            {
                dtp_dsvbnb_from.Value = dtp_dsvbnb_to.Value;
            }
            LoadVanBanNoiBo(dtp_dsvbnb_from.Value, dtp_dsvbnb_to.Value);
        }
        private void LoadVanBanNoiBoMoi()
        {
            foreach (Control c in gb_vbnoibo.Controls)
            {
                if (c is Label || c is Button)
                {
                }
                else
                {
                    c.Text = "";
                }
            }
            txt_vbnb_noidung.Text = "";
            txt_vbnb_trichyeu.Text = "";
            txt_vbnb_id.Text = (bussiness.getMaxIDVanBanNoiBo() + 1).ToString();
            string[] nguoi = bussiness.getThietLapThongTin();
            txt_vbnb_ngky.Text = nguoi[0];
            txt_vbnb_ngduyet.Text = nguoi[2];
            txt_vbnb_ngnhan.Text = nguoi[3];
            txt_vbnb_sokyhieu.Text = txt_vbnb_id.Text + "/";
            LoadComboboxVBNoiBo();
            gb_vnbn_file.Enabled = false;
        }

        private void LoadComboboxVBNoiBo()
        {
            cbb_vbnb_lvb.DataSource = bussiness.getLoaiVanBan();
            cbb_vbnb_lvb.DisplayMember = "TEN_LOAI_VAN_BAN";
            cbb_vbnb_lvb.ValueMember = "ID_LOAI_VAN_BAN";
            cbb_vbnb_phongbh.DataSource = bussiness.getPhongBan();
            cbb_vbnb_phongbh.DisplayMember = "TEN_PHONG_BAN";
            cbb_vbnb_phongbh.ValueMember = "ID_PHONG_BAN";
            cbb_vbnb_phongbn.DataSource = bussiness.getPhongBan();
            cbb_vbnb_phongbn.DisplayMember = "TEN_PHONG_BAN";
            cbb_vbnb_phongbn.ValueMember = "ID_PHONG_BAN";
        }

        private void btn_vbnb_add_Click(object sender, EventArgs e)
        {
            LoadVanBanDenMoi();
        }

        private void btn_vbnb_luu_Click(object sender, EventArgs e)
        {
            if (bussiness.timVanBanNoiBo(int.Parse(txt_vbnb_id.Text)))
            {
                if (cbb_vbnb_lvb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn loại văn bản", "THÔNG BÁO");
                else if (cbb_vbnb_phongbh.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn phòng ban hành", "THÔNG BÁO");
                else if (cbb_vbnb_phongbn.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn phòng ban nhận", "THÔNG BÁO");
                else
                {
                    int id = int.Parse(txt_vbnb_id.Text);
                    int lvb = int.Parse(cbb_vbnb_lvb.SelectedValue.ToString());
                    int pbh = int.Parse(cbb_vbnb_phongbh.SelectedValue.ToString());
                    int pbn = int.Parse(cbb_vbnb_phongbn.SelectedValue.ToString());
                    DateTime ngbanhanh = dtp_vbnb_ngaybh.Value;
                    string sokyhieu = txt_vbnb_sokyhieu.Text.Trim();
                    string tenvanban = txt_vbnb_tenvb.Text;
                    string trichyeu = txt_vbnb_trichyeu.Text;
                    string ghichu = txt_vbnb_noidung.Text;
                    string ngnhan = txt_vbnb_ngnhan.Text;
                    string ngky = txt_vbnb_ngky.Text;
                    string ngduyet = txt_vbnb_ngduyet.Text;
                    int[] _id = {lvb, pbh,pbn };
                    string[] _thongtin = { sokyhieu, tenvanban, trichyeu, ghichu, ngnhan, ngky, ngduyet};
                    if (tenvanban == "")
                    {
                        MessageBox.Show("Hãy nhập tên văn bản", "THÔNG BÁO");
                    }
                    else if (sokyhieu == "")
                        {
                            MessageBox.Show("Hãy nhập số ký hiệu", "THÔNG BÁO");
                        }
                    else if (ngky == "")
                    {
                        MessageBox.Show("Hãy nhập tên người ký", "THÔNG BÁO");
                    }
                    else if (ngduyet == "")
                    {
                        MessageBox.Show("Hãy nhập tên người duyệt", "THÔNG BÁO");
                    }
                    else if (ngnhan == "")
                    {
                        MessageBox.Show("Hãy nhập tên người nhận", "THÔNG BÁO");
                    }
                    else if (bussiness.SuaVanBanNoiBo(id,_id,_thongtin,ngbanhanh))
                    {
                        MessageBox.Show("Cập nhật thành công", "THÔNG BÁO");
                        gb_vnbn_file.Enabled = true;
                    }
                    else
                        MessageBox.Show("Cập nhật thất bại", "THÔNG BÁO");
                }
            }
            else
            {
                if (cbb_vbnb_lvb.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn loại văn bản", "THÔNG BÁO");
                else if (cbb_vbnb_phongbh.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn phòng ban hành", "THÔNG BÁO");
                else if (cbb_vbnb_phongbn.SelectedIndex < 0)
                    MessageBox.Show("Chưa chọn phòng ban nhận", "THÔNG BÁO");
                else
                {
                    int id = int.Parse(txt_vbnb_id.Text);
                    int lvb = int.Parse(cbb_vbnb_lvb.SelectedValue.ToString());
                    int pbh = int.Parse(cbb_vbnb_phongbh.SelectedValue.ToString());
                    int pbn = int.Parse(cbb_vbnb_phongbn.SelectedValue.ToString());
                    DateTime ngbanhanh = dtp_vbnb_ngaybh.Value;
                    string sokyhieu = txt_vbnb_sokyhieu.Text.Trim();
                    string tenvanban = txt_vbnb_tenvb.Text;
                    string trichyeu = txt_vbnb_trichyeu.Text;
                    string ghichu = txt_vbnb_noidung.Text;
                    string ngnhan = txt_vbnb_ngnhan.Text;
                    string ngky = txt_vbnb_ngky.Text;
                    string ngduyet = txt_vbnb_ngduyet.Text;
                    int[] _id = {id,lvb, pbh,pbn };
                    string[] _thongtin = { sokyhieu, tenvanban, trichyeu, ghichu, ngnhan, ngky, ngduyet};
                    if (tenvanban == "")
                    {
                        MessageBox.Show("Hãy nhập tên văn bản", "THÔNG BÁO");
                    }
                    else if (sokyhieu == "")
                    {
                        MessageBox.Show("Hãy nhập số ký hiệu", "THÔNG BÁO");
                    }
                    else if (ngky == "")
                    {
                        MessageBox.Show("Hãy nhập tên người ký", "THÔNG BÁO");
                    }
                    else if (ngduyet == "")
                    {
                        MessageBox.Show("Hãy nhập tên người duyệt", "THÔNG BÁO");
                    }
                    else if (ngnhan == "")
                    {
                        MessageBox.Show("Hãy nhập tên người nhận", "THÔNG BÁO");
                    }
                    else if (bussiness.ThemVanBanNoiBo(_id, _thongtin, ngbanhanh))
                    {
                        MessageBox.Show("Thêm thành công", "THÔNG BÁO");
                        gb_vnbn_file.Enabled = true;
                    }
                    else
                        MessageBox.Show("Thêm thất bại", "THÔNG BÁO");
                }
            }
        }

        public void loadVanBanNoiBo(int id)
        {
            LoadComboboxVBNoiBo();
            DAL.VAN_BAN_NOI_BO vbd = bussiness.timthongtinVanBanNoiBo(id);
            if (vbd != null)
            {
                txt_vbnb_id.Text = vbd.ID_VAN_BAN_NOI_BO.ToString();
                cbb_vbnb_lvb.SelectedValue = vbd.ID_LOAI_VAN_BAN;
                cbb_vbnb_phongbh.SelectedValue = vbd.ID_PHONG_BAN_BAN_HANH;
                cbb_vbnb_phongbn.SelectedValue = vbd.ID_PHONG_BAN_NHAN;
                txt_vbnb_ngnhan.Text = vbd.NGUOI_NHAN_VAN_BAN.ToString();
                txt_vbnb_ngky.Text = vbd.NGUOI_KY_VAN_BAN.ToString();
                txt_vbnb_ngduyet.Text = vbd.NGUOI_DUYET_VAN_BAN.ToString();
                txt_vbnb_trichyeu.Text = vbd.TRICH_YEU;
                txt_vbnb_noidung.Text = vbd.GHI_CHU.ToString();
                txt_vbnb_tenvb.Text = vbd.TEN_VAN_BAN.ToString();
                txt_vbnb_sokyhieu.Text = vbd.SO_KY_HIEU.ToString();
                dtp_vbnb_ngaybh.Value = DateTime.Parse(vbd.NGAY_BAN_HANH.ToString());
                gb_vnbn_file.Enabled = true;
            }
        }
        private void btn_dsvbnb_taomoi_Click(object sender, EventArgs e)
        {
            if (btn_vbnb.Enabled == true)
            {
                ShowTab(tab_vanbannoibo);
                LoadVanBanNoiBoMoi();
            }
            else
            {
                MessageBox.Show("Bạn không được cấp quyền truy cập", "THÔNG BÁO");
            }
        }
        private void btn_dsvbnb_sua_Click(object sender, EventArgs e)
        {
            if (btn_vbnb.Enabled == true)
            {
                if (dgv_dsvbnoibo.RowCount > 0)
                {
                    ShowTab(tab_vanbannoibo);
                    loadVanBanNoiBo(int.Parse(dgv_dsvbnoibo.CurrentRow.Cells["ID_VBNB"].Value.ToString()));
                    loadFileVanBanNoiBo();
                }
            }
            else
            {
                MessageBox.Show("Bạn không được cấp quyền truy cập", "THÔNG BÁO");
            }
        }
        private void loadFileVanBanNoiBo()
        {
            dgv_vbnb_file.DataSource = bussiness.getFileVBNoiBo(int.Parse(dgv_dsvbnoibo.CurrentRow.Cells["ID_VBNB"].Value.ToString()));
        }
        private void btn_vbNoiBo_addfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string filename = fd.FileName;
                    bussiness.ThemFileVBNoiBo(int.Parse(txt_vbnb_id.Text), filename);
                    MessageBox.Show("Thêm file thành công", "THÔNG BÁO");
                    loadFileVanBanNoiBo();
                }
            }
        }

        private void btn_vbNoiBo_deletefile_Click(object sender, EventArgs e)
        {
            if (dgv_vbnb_file.RowCount > 0)
            {
                bussiness.XoaFileVBNoiBo(int.Parse(dgv_vbnb_file.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("Xóa file thành công", "THÔNG BÁO");
                loadFileVanBanNoiBo();
            }
        }
        private void btn_vbNoiBo_readfile_Click(object sender, EventArgs e)
        {
            if (dgv_vbnb_file.RowCount > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(@dgv_vbnb_file.CurrentRow.Cells["TEN_TAI_LIEU_VBNB"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Đọc file thất bại! File không tồn tại ở vị trí cũ", "THÔNG BÁO");
                }
            }
        }
        //Phân quyền=====================================================================================
        private void LoadComboboxPhanQuyen()
        {
            cbb_phanquyen_nv.DataSource = bussiness.getNhanVien();
            cbb_phanquyen_nv.DisplayMember = "MA_NHAN_VIEN";
            cbb_phanquyen_nv.ValueMember = "ID_NHAN_VIEN";
        }
        private void LoadPhanQuyen()
        {
            if(cbb_phanquyen_nv.SelectedIndex>=0)
                dgv_phanquyen.DataSource = bussiness.getPhanQuyen(int.Parse(cbb_phanquyen_nv.SelectedValue.ToString()));
        }

        
        //Chức năng=====================================================================================
        private void btn_dangnhaplai_Click(object sender, EventArgs e)
        {
            if (Program.dangnhap == null || Program.dangnhap.IsDisposed)
            {
                Program.dangnhap = new frm_DangNhap();
            }
            this.Hide();
            Program.dangnhap.Show();
        }

        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            foreach (XtraTabPage c in tabControl.TabPages)
            {
                if (c.PageVisible == true)
                    c.PageVisible = false;
            }
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.ShowDialog();
        }

        private void btn_phanquyen_tim_Click(object sender, EventArgs e)
        {
            if (cbb_phanquyen_nv.SelectedIndex >= 0)
            {
                LoadPhanQuyen();
            }
        }

        private void chk_tatcaquyen_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tatcaquyen.Checked == true)
            {
                foreach (DataGridViewRow r in dgv_phanquyen.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[2];
                    chk.Value = true;
                }
            }
        }

        private void mts_phanquyen_Load(object sender, EventArgs e)
        {
            mts_phanquyen.SetToolStrip(dgv_phanquyen, null, null, false, false, true);
            mts_phanquyen.ButtonClick += mts_phanquyen_ButtonClick;
        }

        void mts_phanquyen_ButtonClick(object sender, EventArgs e)
        {
            if (dgv_phanquyen.DataSource!=null)
            {

                if (bussiness.checkexsistQuyen(int.Parse(cbb_phanquyen_nv.SelectedValue.ToString())))
                {
                    foreach (DataGridViewRow d in dgv_phanquyen.Rows)
                    {
                        if (!bussiness.updateQuyen(int.Parse(cbb_phanquyen_nv.SelectedValue.ToString()), int.Parse(d.Cells[0].Value.ToString()),(bool)d.Cells[2].Value))
                        {
                            MessageBox.Show("Có lỗi trong quá trình sửa", "THÔNG BÁO");
                            return;
                        }
                    }
                    MessageBox.Show("Cập nhật thành công","THÔNG BÁO");
                    LoadPhanQuyen();
                }
                else
                {
                    dgv_phanquyen.Rows[0].Cells[0].Selected = true;
                    foreach (DataGridViewRow d in dgv_phanquyen.Rows)
                    {
                        if (!bussiness.ThemQuyen(int.Parse(cbb_phanquyen_nv.SelectedValue.ToString()), int.Parse(d.Cells[0].Value.ToString()), (bool)d.Cells[2].Value))
                        {
                            MessageBox.Show("Có lỗi trong quá trình thêm", "THÔNG BÁO");
                            return;
                        }
                    }
                    MessageBox.Show("Cập nhật thành công", "THÔNG BÁO");
                    LoadPhanQuyen();
                }
            }
        }

        private void btn_huyquyen_Click(object sender, EventArgs e)
        {
            if (dgv_phanquyen.DataSource != null && cbb_phanquyen_nv.Items.Count!=0)
            {
                if (bussiness.checkexsistQuyen(int.Parse(cbb_phanquyen_nv.SelectedValue.ToString())))
                {
                    foreach (DataGridViewRow d in dgv_phanquyen.Rows)
                    {
                        if (!bussiness.XoaQuyen(int.Parse(cbb_phanquyen_nv.SelectedValue.ToString()), int.Parse(d.Cells[0].Value.ToString())))
                        {
                            MessageBox.Show("Có lỗi trong quá trình sửa", "THÔNG BÁO");
                            return;
                        }
                    }
                    MessageBox.Show("Đã hủy thành công", "THÔNG BÁO");
                    LoadPhanQuyen();
                }
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (XtraTabPage c in tabControl.TabPages)
            {
                if (c.PageVisible == true)
                    c.PageVisible = false;
            }
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.ShowDialog();
        }

        private void btn_nguoikyduyet_Click(object sender, EventArgs e)
        {
            foreach (XtraTabPage c in tabControl.TabPages)
            {
                if (c.PageVisible == true)
                    c.PageVisible = false;
            }
            frm_nguoikyduyet frm = new frm_nguoikyduyet();
            frm.ShowDialog();
        }
        //Thống kê văn bản đi=============================================================
        private void mts_tk_vbdi_Load(object sender, EventArgs e)
        {
            mts_tk_vbdi.SetToolStrip(dgv_tk_vbdi, null, null, false, false, false);
        }

        private void btn_tk_vbdi_tim_Click(object sender, EventArgs e)
        {
            int[] id = { int.Parse(cbb_tk_vbdi_lvb.SelectedValue.ToString()), int.Parse(cbb_tk_vbdi_svb.SelectedValue.ToString()) };
            string[] tt={txt_tk_vbdi_sokyhieu.Text,txt_tk_vbdi_noinhan.Text,txt_tk_vbdi_trichyeu.Text};
            dgv_tk_vbdi.DataSource = bussiness.getThongKeVBDi(dtp_tk_vbdi_from.Value, dtp_tk_vbdi_to.Value, id, tt);
        }
        
        private void loadComboboxTKVBDi()
        {
            var svb = new Dictionary<int, string>();
            svb.Add(-1, "--Chọn giá trị--");
            foreach (DAL.SO_VAN_BAN so in bussiness.getsovanban(false))
            {
                svb.Add(int.Parse(so.ID_SO_VAN_BAN.ToString()), so.NAM.ToString() + "/" + so.TEN_SO_VAN_BAN.ToString());
            }
            cbb_tk_vbdi_svb.DataSource = svb.ToList();
            cbb_tk_vbdi_svb.DisplayMember = "Value";
            cbb_tk_vbdi_svb.ValueMember = "Key";

            var lvb = new Dictionary<int, string>();
            lvb.Add(-1, "--Chọn giá trị--");
            foreach (DAL.LOAI_VAN_BAN so in bussiness.getLoaiVanBan())
            {
                lvb.Add(int.Parse(so.ID_LOAI_VAN_BAN.ToString()), so.TEN_LOAI_VAN_BAN.ToString());
            }
            cbb_tk_vbdi_lvb.DataSource = lvb.ToList();
            cbb_tk_vbdi_lvb.DisplayMember = "Value";
            cbb_tk_vbdi_lvb.ValueMember = "Key";
        }

        private void btn_tk_vbdi_in_Click(object sender, EventArgs e)
        {
            frm_reportVBDi form = new frm_reportVBDi(dtp_tk_vbdi_from.Value, dtp_tk_vbdi_to.Value);
            form.ShowDialog();
        }
        private void dtp_tk_vbdi_from_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_tk_vbdi_from.Value > dtp_tk_vbdi_to.Value)
            {
                dtp_tk_vbdi_to.Value = dtp_tk_vbdi_from.Value;
            }
        }

        private void dtp_tk_vbdi_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_tk_vbdi_from.Value > dtp_tk_vbdi_to.Value)
            {
                dtp_tk_vbdi_from.Value = dtp_tk_vbdi_to.Value;
            }
        }
        //Thống kê văn bản đến=======================================================

        private void mts_tk_vbden_Load(object sender, EventArgs e)
        {
            mts_tk_vbden.SetToolStrip(dgv_tk_vbden, null, null, false, false, false);
        }

        private void loadComboboxTKVBDen()
        {
            var svb = new Dictionary<int, string>();
            svb.Add(-1, "--Chọn giá trị--");
            foreach (DAL.SO_VAN_BAN so in bussiness.getsovanban(false))
            {
                svb.Add(int.Parse(so.ID_SO_VAN_BAN.ToString()), so.NAM.ToString() + "/" + so.TEN_SO_VAN_BAN.ToString());
            }
            cbb_tk_vbden_svb.DataSource = svb.ToList();
            cbb_tk_vbden_svb.DisplayMember = "Value";
            cbb_tk_vbden_svb.ValueMember = "Key";

            var lvb = new Dictionary<int, string>();
            lvb.Add(-1, "--Chọn giá trị--");
            foreach (DAL.LOAI_VAN_BAN so in bussiness.getLoaiVanBan())
            {
                lvb.Add(int.Parse(so.ID_LOAI_VAN_BAN.ToString()), so.TEN_LOAI_VAN_BAN.ToString());
            }
            cbb_tk_vbden_lvb.DataSource = lvb.ToList();
            cbb_tk_vbden_lvb.DisplayMember = "Value";
            cbb_tk_vbden_lvb.ValueMember = "Key";

            var nbh = new Dictionary<int, string>();
            nbh.Add(-1, "--Chọn giá trị--");
            foreach (DAL.NOI_BAN_HANH so in bussiness.getNoiBanHanh())
            {
                nbh.Add(int.Parse(so.ID_NOI_BAN_HANH.ToString()), so.NOI_BAN_HANH1.ToString());
            }
            cbb_tk_vbden_nbh.DataSource = nbh.ToList();
            cbb_tk_vbden_nbh.DisplayMember = "Value";
            cbb_tk_vbden_nbh.ValueMember = "Key";
        }

        private void btn_tk_vbden_tim_Click(object sender, EventArgs e)
        {
            int[] id = { int.Parse(cbb_tk_vbden_svb.SelectedValue.ToString()), int.Parse(cbb_tk_vbden_lvb.SelectedValue.ToString()), int.Parse(cbb_tk_vbden_nbh.SelectedValue.ToString()) };
            string[] tt = { txt_tk_vbden_sokyhieu.Text, txt_tk_vbden_trichyeu.Text };
            dgv_tk_vbden.DataSource = bussiness.getThongKeVBDen(dtp_tk_vbden_from.Value, dtp_tk_vbden_to.Value, id, tt);
        }
        private void btn_tk_vbden_in_Click(object sender, EventArgs e)
        {
            frm_reportVBDen form = new frm_reportVBDen(dtp_tk_vbden_from.Value,dtp_tk_vbden_to.Value);
            form.ShowDialog();
        }
        
        private void dtp_tk_vbden_from_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_tk_vbden_from.Value > dtp_tk_vbden_to.Value)
            {
                dtp_tk_vbden_to.Value = dtp_tk_vbden_from.Value;
            }
        }

        private void dtp_tk_vbden_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_tk_vbden_from.Value > dtp_tk_vbden_to.Value)
            {
                dtp_tk_vbden_from.Value = dtp_tk_vbden_to.Value;
            }
        }
        //Thống kê văn bản nội bộ====================================================
        private void mts_tk_vbnb_Load(object sender, EventArgs e)
        {
            mts_tk_vbnb.SetToolStrip(dgv_tk_vbnb, null, null, false, false, false);
        }

        private void loadComboboxTKVBNB()
        {
          
            var lvb = new Dictionary<int, string>();
            lvb.Add(-1, "--Chọn giá trị--");
            foreach (DAL.LOAI_VAN_BAN so in bussiness.getLoaiVanBan())
            {
                lvb.Add(int.Parse(so.ID_LOAI_VAN_BAN.ToString()), so.TEN_LOAI_VAN_BAN.ToString());
            }
            cbb_tk_vbnb_lvb.DataSource = lvb.ToList();
            cbb_tk_vbnb_lvb.DisplayMember = "Value";
            cbb_tk_vbnb_lvb.ValueMember = "Key";

            var nbh = new Dictionary<int, string>();
            nbh.Add(-1, "--Chọn giá trị--");
            foreach (DAL.PHONG_BAN so in bussiness.getPhongBan())
            {
                nbh.Add(int.Parse(so.ID_PHONG_BAN.ToString()), so.TEN_PHONG_BAN.ToString());
            }
            cbb_tk_vbnb_pbh.DataSource = nbh.ToList();
            cbb_tk_vbnb_pbh.DisplayMember = "Value";
            cbb_tk_vbnb_pbh.ValueMember = "Key";

            cbb_tk_vbnb_pbn.DataSource = nbh.ToList();
            cbb_tk_vbnb_pbn.DisplayMember = "Value";
            cbb_tk_vbnb_pbn.ValueMember = "Key";
        }

        private void btn_tk_vbnb_tim_Click(object sender, EventArgs e)
        {
            int[] id = { int.Parse(cbb_tk_vbnb_lvb.SelectedValue.ToString()), int.Parse(cbb_tk_vbnb_pbh.SelectedValue.ToString()), int.Parse(cbb_tk_vbnb_pbn.SelectedValue.ToString()) };
            string[] tt = { txt_tk_vbnb_sokyhieu.Text,txt_tk_vbnb_tenvb.Text, txt_tk_vbnb_trichyeu.Text };
            dgv_tk_vbnb.DataSource = bussiness.getThongKeVBNB(dtp_tk_vbnb_from.Value, dtp_tk_vbnb_to.Value, id, tt);
        }

        private void btn_tk_vbnb_in_Click(object sender, EventArgs e)
        {
            frm_reportVBNB frm = new frm_reportVBNB(dtp_tk_vbnb_from.Value,dtp_tk_vbnb_to.Value);
            frm.ShowDialog();
        }

        private void dtp_tk_vbnb_from_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_tk_vbnb_from.Value > dtp_tk_vbnb_to.Value)
            {
                dtp_tk_vbnb_to.Value = dtp_tk_vbnb_from.Value;
            }
        }

        private void dtp_tk_vbnb_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_tk_vbnb_from.Value > dtp_tk_vbnb_to.Value)
            {
                dtp_tk_vbnb_from.Value = dtp_tk_vbnb_to.Value;
            }
        }

        

        


        

        

        


        


        

        

        

        

        


        

        

    }
}
