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
    public partial class frm_reportVBNB : Form
    {
        DateTime date_from = DateTime.Parse("1/1/1000");
        DateTime date_to = DateTime.Parse("1/1/1000");
        public frm_reportVBNB()
        {
            InitializeComponent();
        }
        public frm_reportVBNB(DateTime date_from,DateTime date_to)
        {
            InitializeComponent();
            this.date_from = date_from;
            this.date_to = date_to;
        }
        private void frm_reportVBNB_Load(object sender, EventArgs e)
        {
            ReportVBNB rp = new ReportVBNB();
            rp.SetParameterValue("date_from", date_from);
            rp.SetParameterValue("date_to", date_to);
            string[] connect = Properties.Settings.Default.Connect.ToString().Split(';');
            string server = connect[0].Substring(12);
            string database = connect[1].Substring(16);
            string user = connect[2].Substring(8);
            string pass = connect[3].Substring(4);
            rp.SetDatabaseLogon(user, pass, server, database);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }
    }
}
