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
    public partial class frm_KetNoiDatabase : Form
    {
        public frm_KetNoiDatabase()
        {
            InitializeComponent();
            connectDatabase1.AddForm(this);
        }
        
        private void frm_KetNoiDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectDatabase1.kq == "")
            {
                if (MessageBox.Show("Kết nối chưa thành công! Bạn vẫn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                PhanMemQuanLiVanBan.Properties.Settings.Default.Connect = connectDatabase1.kq;
                PhanMemQuanLiVanBan.Properties.Settings.Default.Save();
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void frm_KetNoiDatabase_Load(object sender, EventArgs e)
        {

        }

       
    }
}
