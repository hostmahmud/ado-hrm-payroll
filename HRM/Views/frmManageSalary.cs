using HRM.Classes;
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

namespace HRM.Views
{
    public partial class frmManageSalary : Form
    {
        public static string empid = "";
        public frmManageSalary()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;
            showData();
            CustomColumn();
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

            cmd.CommandText = "select distinct emp.id 'Employee ID',emp.name 'Name',desig.name 'Designation',emp.joinSalary 'Basic Salary',(emp.joinSalary+(select ISNULL(SUM(aAmount),0) as 'al' from tbl_empAllowance where empid=emp.id)+(select ISNULL(SUM(cAmount),0) as 'com' from tbl_empCommission where empid=emp.id)-(select ISNULL(SUM(dAmount),0) as 'ded' from tbl_empDeduction where empid=emp.id)) as 'Net Salary'from tbl_employee as emp join tbl_designation as desig on emp.desigID = desig.id left join tbl_empAllowance as al on al.empId = emp.id left join tbl_empCommission com on com.empId = emp.id left join tbl_empDeduction ded on ded.empid = emp.id order by[Employee ID] desc";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds, "emp");
            dataGridView1.DataSource = ds.Tables[0];
            con.conClose();

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 60;
            dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.DefaultCellStyle.ForeColor = Color.DarkBlue;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.AliceBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font= new Font("Arial", 15F, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 50;

        }
        private void CustomColumn()
        {
            //view button
            DataGridViewLinkColumn updateLink = new DataGridViewLinkColumn();
            updateLink.UseColumnTextForLinkValue = true;
            updateLink.HeaderText = "Action";
            updateLink.DataPropertyName = "View";
            updateLink.LinkBehavior = LinkBehavior.SystemDefault;
            updateLink.Text = "View";
            updateLink.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(updateLink);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)//update button click
            {
                int row;
                row = e.RowIndex;
                empid = Convert.ToString(dataGridView1.Rows[row].Cells[1].Value) ;
                frmManageSalaryIndividual mes = new frmManageSalaryIndividual();
                mes.Show();
            }
        }

        private void txtSearchText_TextChanged(object sender, EventArgs e)
        {
            string searchby = cmbSearchBy.Text;
            try
            {
                //this code is used to search Name on the basis of txttxtSearchItem.text
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("" + searchby + " like '%{0}%'", txtSearchText.Text.Trim().Replace("'", "''"));
            }
            catch (Exception) { }
        }
    }
}
