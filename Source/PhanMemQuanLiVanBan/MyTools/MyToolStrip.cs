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
            try
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            }
            catch
            {
                MessageBox.Show("Không thể mở máy tính!","THÔNG BÁO");
            }
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
                int i = int.Parse(data.Rows[data.RowCount - 1].Cells[0].Value.ToString());
                id.Text = (i + 1).ToString();
            }
            else
            {
                id.Text = "0";
            }
        }

        private void btn_dongdau_Click(object sender, EventArgs e)
        {
            if (data.RowCount >1)
            {
                if (data.CurrentRow != null)
                {
                    int m = data.CurrentCell.ColumnIndex;
                    data.CurrentRow.Selected = false;
                    data.CurrentCell = data.Rows[0].Cells[m];
                    data.CurrentCell.Selected = true;
                }
                else
                    data.Rows[0].Selected = true;
            }
        }

        private void btn_dongtruoc_Click(object sender, EventArgs e)
        {
            if (data.RowCount <=1)
                return;
            if (data.CurrentRow != null)
            {
                int d = data.CurrentCell.RowIndex;
                int m = data.CurrentCell.ColumnIndex;
                if (d>0)
                {
                    data.CurrentRow.Selected = false;
                    data.CurrentCell = data.Rows[d - 1].Cells[m];
                    data.CurrentRow.Selected = true;
                }
            }
            else
                data.Rows[0].Selected = true;
            
        }

        private void btn_dongsau_Click(object sender, EventArgs e)
        {
            if (data.RowCount <=1)
                return;
            if (data.CurrentRow != null)
            {
                if (data.CurrentCell.RowIndex!=data.RowCount-1)
                {
                    int d = data.CurrentCell.RowIndex;
                    int m = data.CurrentCell.ColumnIndex;
                    data.CurrentRow.Selected = false;
                    data.CurrentCell = data.Rows[d + 1].Cells[m];
                    data.CurrentRow.Selected = true;

                }
            }
            else
                data.Rows[0].Selected = true;
        }

        private void btn_dongcuoi_Click(object sender, EventArgs e)
        {
            if (data.RowCount <=1)
                return;
            if (data.CurrentRow != null)
            {
                int m = data.CurrentCell.ColumnIndex;
                data.CurrentRow.Selected = false;
                data.CurrentCell = data.Rows[data.RowCount - 1].Cells[m];
                data.CurrentCell.Selected = true;
            }
            else
                data.Rows[data.RowCount].Selected = true;
            
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (this.ButtonXoa != null)
            {
                this.ButtonXoa(this, e);
            }
        }

        private void btn_tailai_Click(object sender, EventArgs e)
        {
            if (this.ButtonRefesh != null)
            {
                this.ButtonRefesh(this, e);
            }
        }
        public event EventHandler ButtonClick, ButtonRefesh,ButtonXoa;
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(this, e);
            }
        }

        private void btn_xuatexcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "excel";

                for (int i = 1; i < data.Columns.Count + 1; i++)
                {
                    if (data.Columns[i - 1].Visible == true)
                    {
                        worksheet.Cells[1, i] = data.Columns[i - 1].HeaderText;
                    }
                }

                for (int i = 0; i < data.RowCount; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        if (data.Columns[j].Visible == true)
                        {
                            if (data.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                }
                var SaveFileDialog = new SaveFileDialog();
                SaveFileDialog.FileName = "output";
                SaveFileDialog.DefaultExt = ".xlsx";
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    workbook.SaveAs(SaveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                app.Quit();
            }
            catch
            {
                MessageBox.Show("Không thể xuất file excel", "THÔNG BÁO");
            }
        }

        


    }
}
