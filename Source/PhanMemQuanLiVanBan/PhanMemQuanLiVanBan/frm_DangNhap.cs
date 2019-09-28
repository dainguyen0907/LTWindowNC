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
        }
        //=========================================================================
        private void cbb_congty_DropDown(object sender, EventArgs e)// Đổ dữ liệu vào combobox công ty
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select TEN_CONG_TY from THONG_TIN_CONG_TY", Properties.Settings.Default.Connect);
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    cbb_congty.Items.Clear();
                    foreach (DataRow r in dt.Rows)
                        foreach (DataColumn c in dt.Columns)
                            cbb_congty.Items.Add(r[c]);
                    cbb_congty.SelectedIndex = 0;
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
            if(Status==1 || Status==2)
                MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!","Thông báo",MessageBoxButtons.OK);

        }
        //===========================================================================================
        private void btn_dangnhap_Click(object sender, EventArgs e)//Sự kiện đăng nhập
        {
            if (Status == 1 || Status == 2)
                MessageBox.Show("Kêt nối bị lỗi. Vui lòng thiết lập lại kết nối!", "Thông báo", MessageBoxButtons.OK);
            else
            {
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
                if(string.IsNullOrEmpty(txt_taikhoan.Text.Trim()))
                {
                    ProcessLogin();
                }
            }
        }
        //==========================================================================================
        private void ProcessLogin()
        {
        }

        
    }
}
