using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HRM.Classes;

namespace HRM.Views
{
    public partial class frmListEmployee : Form
    {

        public static string empid = "";
        DataSet ds;
        SqlDataAdapter adpt;
        public frmListEmployee()
        {
            InitializeComponent();
            cmbShowLimit.Text = "5";
            showData();
            CustomColumn();
            styleGridView();
            cmbSearchBy.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showData()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;

            cmd.CommandText = "select emp.id,emp.photo,emp.name,emp.email,desig.name 'designation' from tbl_employee as emp join tbl_designation as desig on emp.desigID = desig.id order by id desc";

            adpt = new SqlDataAdapter(cmd);
            ds = new DataSet();

            if (cmbShowLimit.Text == "All")
            {
                adpt.Fill(ds, "members");
            }
            else
            {
                adpt.Fill(ds, 0, Convert.ToInt32(cmbShowLimit.Text), "members");
            }

            //picture field
            ds.Tables["members"].Columns.Add(new DataColumn("Picture", Type.GetType("System.Byte[]")));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["Picture"] = File.ReadAllBytes(dr["photo"].ToString());
            }
            //dt.Columns.Remove("photo");
            ds.Tables[0].Columns.Remove("photo");

            dataGridView1.DataSource = ds.Tables[0];

            con.conClose();
            GC.Collect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)//update button click
            {
                int row;
                row = e.RowIndex;
                empid = Convert.ToString(dataGridView1.Rows[row].Cells[1].Value);
                frmUpdateEmp upd = new frmUpdateEmp();
                upd.Show();

            }
        }
        private void CustomColumn()
        {
            //add edit button
            DataGridViewLinkColumn updateLink = new DataGridViewLinkColumn();
            updateLink.UseColumnTextForLinkValue = true;
            updateLink.HeaderText = "Update";
            updateLink.DataPropertyName = "update";
            updateLink.LinkBehavior = LinkBehavior.SystemDefault;
            updateLink.Text = "Update";
            updateLink.DisplayIndex = 0;
            dataGridView1.Columns.Add(updateLink);


            //adjust column width and color
            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 25;
            dataGridView1.Columns[2].FillWeight = 25;
            dataGridView1.Columns[3].FillWeight = 20;
            dataGridView1.Columns[4].FillWeight = 25;
            dataGridView1.Columns[5].FillWeight = 10;

        }

        private void cmbShowLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "select emp.id,emp.photo,emp.name,emp.email,desig.name 'designation' from tbl_employee as emp join tbl_designation as desig on emp.desigID = desig.id order by id desc";

            adpt = new SqlDataAdapter(cmd);
            ds = new DataSet();

            if (cmbShowLimit.Text == "All")
            {
                adpt.Fill(ds, "members");
            }
            else
            {
                adpt.Fill(ds, 0, Convert.ToInt32(cmbShowLimit.Text), "members");
            }

            //picture field
            ds.Tables["members"].Columns.Add(new DataColumn("Picture", Type.GetType("System.Byte[]")));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["Picture"] = File.ReadAllBytes(dr["photo"].ToString());
            }
            ds.Tables[0].Columns.Remove("photo");

            dataGridView1.DataSource = ds.Tables[0];
            
            con.conClose();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.pdf|(Pdf File)";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path + @"\CrystalReport1.rpt");
                CrystalReport1 c1 = new CrystalReport1();
                c1.ReportAppServer = cryRpt.ToString();

                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, saveFileDialog1.FileName + ".pdf");
                
                MessageBox.Show("Report Exported Succesfully..");

            }
            else
            {
                MessageBox.Show("Error occured!");
            }
        }
        private void styleGridView() 
        {
            dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.DefaultCellStyle.ForeColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            string searchby = cmbSearchBy.Text;
            try
            {
                //this code is used to search Name on the basis of txttxtSearchItem.text
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format(""+searchby+" like '%{0}%'", txtSearchText.Text.Trim().Replace("'", "''"));
            }
            catch (Exception) { }
        }
    }
}
