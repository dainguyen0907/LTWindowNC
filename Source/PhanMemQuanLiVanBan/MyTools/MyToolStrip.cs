using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using BLL;

namespace MyTools
{
    public partial class MyToolStrip : UserControl
    {
        DataGridView data = null;
        TextBox id = null;
        GroupBox group = null;
        Business bussiness = new Business();
        public MyToolStrip()
        {
            InitializeComponent();
        }
        
        public void SetToolStrip( DataGridView data, GroupBox group,TextBox id, bool them, bool xoa, bool luu)
        {
            if (them == true)

                btn_them.Visible = true;

            if (xoa == true)

                btn_xoa.Visible = true;

            if (luu == true)
                btn_luu.Visible = true;
            this.data = data;
            this.id=id;
            this.group = group;
        }

        private void btn_maytinh_Click(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            foreach (Control c in group.Controls)
            {
                if (c is Label)
                { }
                else
                    c.Text = "";
            }
            if (data.RowCount > 0)
            {
                int i = int.Parse(data.Rows[data.RowCount - 2].Cells[0].Value.ToString());
                id.Text = (i + 1).ToString();
            }
            else
            {
                id.Text = "0";
            }
        }

        private void btn_dongdau_Click(object sender, EventArgs e)
        {
            if (data.RowCount > 1)
            {
                if (data.CurrentRow != null)
                {
                    data.CurrentRow.Selected = false;
                    data.Rows[0].Selected = true;
                }
                else
                    data.Rows[0].Selected = true;
            }
        }

        private void btn_dongtruoc_Click(object sender, EventArgs e)
        {
            if (data.RowCount == 1)
                return;
            if (data.CurrentRow != null)
            {
                int d = data.CurrentCell.RowIndex;
                if (d>0)
                {
                    data.CurrentRow.Selected = false;
                    data.Rows[d - 1].Selected = true;
                }
            }
            else
                data.Rows[0].Selected = true;
            
        }

        private void btn_dongsau_Click(object sender, EventArgs e)
        {
            if (data.RowCount == 1)
                return;
            if (data.CurrentRow != null)
            {
                if (data.Rows[data.RowCount - 1].Selected != true)
                {
                    int d = data.CurrentCell.RowIndex;
                    data.CurrentRow.Selected = false;
                    data.Rows[d + 1].Selected = true;

                }
            }
            else
                data.Rows[0].Selected = true;
        }

        private void btn_dongcuoi_Click(object sender, EventArgs e)
        {
            if (data.RowCount == 1)
                return;
            if (data.CurrentRow != null)
            {
                data.CurrentRow.Selected = false;
                data.Rows[data.RowCount - 1].Selected = true;
            }
            else
                data.Rows[data.RowCount - 1].Selected = true;
            
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (data.RowCount > 1)
            {
                int position = data.CurrentCell.RowIndex;
                int id = int.Parse(data.Rows[position].Cells[0].Value.ToString());
                if (bussiness.xoaNhanVien(id))
                    MessageBox.Show("Bạn đã xóa thành công","THÔNG BÁO");
                else
                    MessageBox.Show("Xóa không thành công", "THÔNG BÁO");
                data.Refresh();
            }
            
        }

        private void btn_tailai_Click(object sender, EventArgs e)
        {
            data.Refresh();
        }
        public event EventHandler ButtonClick;
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(this, e);
            }
        }


    }
}
