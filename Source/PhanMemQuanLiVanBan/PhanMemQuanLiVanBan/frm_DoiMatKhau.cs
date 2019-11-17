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
using MyTools;
namespace PhanMemQuanLiVanBan
{
    public partial class frm_DoiMatKhau : Form
    {
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        Business bussiness = new Business();
        Password ps = new Password();
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (txt_matkhau.Text.ToString().Trim() == "")
                MessageBox.Show("Hãy nhập mật khẩu cũ","THÔNG BÁO");
            else if (txt_matkhaumoi.Text.ToString().Trim() == "")
                MessageBox.Show("Hãy nhập mật khẩu mới", "THÔNG BÁO");
            else if (txt_xacnhanmatkhau.Text.ToString().Trim() == "")
                MessageBox.Show("Hãy nhập xác nhận mật khẩu mới", "THÔNG BÁO");
            else if (txt_matkhaumoi.Text != txt_xacnhanmatkhau.Text)
                MessageBox.Show("Mật khẩu xác nhận chưa đúng", "THÔNG BÁO");
            else
            {
                string mahoa=ps.MaHoaPassword(txt_matkhaumoi.Text.ToString());
                if(bussiness.DoiMatKhau(int.Parse(Program.Idnhanvien),mahoa))
                {
                    MessageBox.Show("Đổi mật khẩu thành công","THÔNG BÁO");
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại","THÔNG BÁO");
                }
                
            }
        }
    }
}
