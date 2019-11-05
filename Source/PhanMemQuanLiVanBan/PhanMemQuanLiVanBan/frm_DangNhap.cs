using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace PhanMemQuanLiVanBan
{
    public partial class frm_DangNhap : Form
    {
        private int Status = Check_Config();

        public frm_DangNhap()
        {
            InitializeComponent();
        }
        private void btn_ketnoi_Click(object sender, EventArgs e)
        {
            frm_KetNoiDatabase database = new frm_KetNoiDatabase();
            database.ShowDialog();
            cbb_congty_DropDown(sender, e);
        }
        //=========================================================================
        private void cbb_congty_DropDown(object sender, EventArgs e)// Đổ dữ liệu vào combobox công ty
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select ID_CONG_TY,TEN_CONG_TY from THONG_TIN_CONG_TY", Properties.Settings.Default.Connect);
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    cbb_congty.DataSource = null;
                    cbb_congty.DataSource = dt;
                    cbb_congty.DisplayMember = "TEN_CONG_TY";
                    cbb_congty.ValueMember = "ID_CONG_TY";
                }
                
            }
            catch
            {
                MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!", "Thông báo", MessageBoxButtons.OK);
            }
            
        }
        //=======================================================================================
        static private int Check_Config()// Kiểm tra chuỗi kết nối
        {
            if (Properties.Settings.Default.Connect == string.Empty)
                return 1;// Chuỗi cấu hình không tồn tại
            SqlConnection _Sqlconn = new
            SqlConnection(Properties.Settings.Default.Connect);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }
        //======================================================================================
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            if (Status == 1 || Status == 2)
                MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!", "Thông báo", MessageBoxButtons.OK);
            cbb_congty_DropDown(sender, e);

        }
        //===========================================================================================
        private void btn_dangnhap_Click(object sender, EventArgs e)//Sự kiện đăng nhập
        {
            if (Status == 1 || Status == 2)
                MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!", "Thông báo", MessageBoxButtons.OK);
            else
            {
                if (string.IsNullOrEmpty(cbb_congty.Text))
                {
                    MessageBox.Show("Hãy chọn công ty", "Thông báo", MessageBoxButtons.OK);
                    this.txt_taikhoan.Focus();
                    return;
                }
                if(string.IsNullOrEmpty(txt_taikhoan.Text.Trim()))
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    this.txt_taikhoan.Focus();
                    return;
                }
                if(string.IsNullOrEmpty(txt_matkhau.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    this.txt_taikhoan.Focus();
                    return;
                }
                if(Status==0)
                {
                    ProcessLogin();
                }
            }
        }
        //==========================================================================================
        private void ProcessLogin()
        {
            int result;
            result = check_User(txt_taikhoan.Text, txt_matkhau.Text);
            if (result == 0)
            {
                MessageBox.Show("Tài khoản hay mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK);
                txt_matkhau.Text = "";
                return;
            }
            else if (check_Enabale(txt_taikhoan.Text) == 0)
            {
                MessageBox.Show("Tài khoản đã bạ khóa!", "Thông báo", MessageBoxButtons.OK);
                txt_matkhau.Text = "";
                return;
            }
            else
            {
                Program.id_congty = cbb_congty.SelectedValue.ToString();
                Program.mainForm = new frm_Main();
                this.Hide();
                Program.mainForm.Show();

            }
        }
        //=============================================================================================
        private int check_User(string user, string pass)//Kiểm tra tài khoản
        {
            if (Status == 0)
            {
                DataTable dt = new DataTable();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SALE_NHAN_VIEN WHERE MA_NHAN_VIEN='" + txt_taikhoan.Text + "' and MAT_KHAU = '" + txt_matkhau.Text + "'", PhanMemQuanLiVanBan.Properties.Settings.Default.Connect);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Program.Tennhanvien = dt.Rows[0][2].ToString();
                        return 1;// Hợp lệ
                    }
                }
                catch
                {
                    return 0;// Không tồn tại
                }

            }
            return 0;// không tồn tại
        }
        //================================================================================================
        private int check_Enabale(String user)
        {
            DataTable dt = new DataTable();
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SALE_NHAN_VIEN WHERE MA_NHAN_VIEN='" + txt_taikhoan.Text + "' and NGHI_VIEC = 1", PhanMemQuanLiVanBan.Properties.Settings.Default.Connect);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Program.Tennhanvien = dt.Rows[0][2].ToString();
                        return 0;// Hợp lệ
                    }
                }
                catch
                {
                    return 1;
                }
                return 1;

        }
        
    }
}
