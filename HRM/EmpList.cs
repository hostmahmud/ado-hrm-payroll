using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class EmpList : Form
    {
        public EmpList()
        {
            InitializeComponent();
            //Classes.Connection con = new Classes.Connection();
            //con.DBCon();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = Classes.Connection.conn;
            //cmd.CommandText = "select * from tbl_employee";
            //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adpt.Fill(ds);

            //string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            //ReportDocument rd = new ReportDocument();
            //rd.Load(path + "CrystalReport1.rpt");
            //rd.SetDataSource(ds.Tables["table"]);
            //crystalReportViewer1.ReportSource = rd;

            //rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,response,"")
        }
    }
}
