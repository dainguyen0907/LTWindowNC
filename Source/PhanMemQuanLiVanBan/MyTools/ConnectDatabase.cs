﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MyTools
{
    public partial class ConnectDatabase : UserControl
    {
        public ConnectDatabase()
        {
            InitializeComponent();
        }
        private Form parent=null;
        public void AddForm(Form parent)
        {
            this.parent = parent;
        }
        private void cbb_server_DropDown(object sender, EventArgs e)// Đổ các server lên comcobox
        {
            DataTable dt = GetServerName();
            cbb_server.Items.Clear();
            foreach (DataRow d in dt.Rows)
                foreach (DataColumn c in dt.Columns)
                    cbb_server.Items.Add(d[c]);
        }


        private DataTable GetServerName()// Lấy server trong SQL
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable data = instance.GetDataSources();
            return data;
        }


        private void btn_cancel_Click(object sender, EventArgs e)//thoát cửa sổ
        {
            if(this.parent!=null)
                parent.Close();
        }

        public string kq="";
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cbb_server.Text != "" && txt_user.Text != "" && txt_password.Text != ""&& cbb_database.Text!="")
                kq = "Data Source =" + cbb_server.Text + "; Initial Catalog= "+cbb_database.Text+"; User ID=" + txt_user.Text + ";pwd=" + txt_password.Text + "";
            if (this.parent != null)
                parent.Close();
        }

        private void cbb_database_DropDown(object sender, EventArgs e)
        {
            if (CheckBeforeSearchDBN())
            {
                cbb_database.Items.Clear();
                DataTable dt = getDatabaseName(cbb_server.Text, txt_user.Text, txt_password.Text);
                if (dt == null)
                {
                    MessageBox.Show("Thông tin chưa chính xác!", "Thông báo");
                    return;
                }
                foreach (DataRow r in dt.Rows)
                    foreach (DataColumn d in dt.Columns)
                        cbb_database.Items.Add(r[d]);

            }
        }

        private bool CheckBeforeSearchDBN()// Kiểm tra thông tin trước khi load combobox database
        {
            if (cbb_server.Text == "" || txt_user.Text == "" || txt_password.Text == "")
                return false;
            return true;
        }

        private DataTable getDatabaseName(string ServerName, string User, String Password)//Lấy tên database
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select name From sys.databases","Data Source ="+ServerName+"; Initial Catalog= master; User ID="+User+ ";pwd="+Password+"");
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            return dt;
        }
    }
}