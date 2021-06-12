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
    public partial class frmManageSalaryIndividual : Form
    {
        public static string empidd = "";
        public static string aempid = "";
        public static string id = "";
        public frmManageSalaryIndividual()
        {
            InitializeComponent();
            getBasicSalary();

        }

        private void frmManageSalaryIndividual_Load(object sender, EventArgs e)
        {
            //load allowance
            dgvAllowance.DataSource = BindSource();
            CustomColumnAllowance();
            dgvAllowance.Columns[0].Visible = false;
            
            //load commission
            dgvComission.DataSource = BindSourceCommission();
            CustomColumnCommission();
            dgvComission.Columns[0].Visible = false;

            // load deduction
            dgvDeduction.DataSource = BindSourceDeduction();
            CustomColumnDeduction();
            dgvDeduction.Columns[0].Visible = false;

        }

        private void getBasicSalary() 
        {
            empidd = frmManageSalary.empid;
            lblempid.Text = empidd;
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "SELECT * FROM tbl_employee WHERE id=" + empidd + "";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblType.Text = "Monthly payslip";
                lblSalary.Text = dr.GetValue(14).ToString();

            }

            con.conClose();
        }
        //allowance
        public DataTable BindSource()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "select id,aOption 'Tax Option',aTitle 'Title',aAmount 'Amount' from tbl_empAllowance where empId=" + frmManageSalary.empid + "";
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.conClose();
            //design datagrid view
            this.dgvAllowance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvAllowance.ColumnHeadersHeight = 30;
            dgvAllowance.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvAllowance.DefaultCellStyle.ForeColor = Color.DarkBlue;

            dgvAllowance.EnableHeadersVisualStyles = false;
            dgvAllowance.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvAllowance.ColumnHeadersDefaultCellStyle.ForeColor = Color.AliceBlue;
            dgvAllowance.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            return dt;
            
        }
        //commission
        public DataTable BindSourceCommission()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "sp_selectEmpCommission";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", frmManageSalary.empid);
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.conClose();
            //design datagrid view
            dgvComission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvComission.ColumnHeadersHeight = 30;
            dgvComission.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvComission.DefaultCellStyle.ForeColor = Color.DarkBlue;

            dgvComission.EnableHeadersVisualStyles = false;
            dgvComission.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvComission.ColumnHeadersDefaultCellStyle.ForeColor = Color.AliceBlue;
            dgvComission.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            return dt;
        }
        public DataTable BindSourceDeduction()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "sp_selectEmpDeduction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", frmManageSalary.empid);
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.conClose();
            //design datagrid view
            dgvDeduction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDeduction.ColumnHeadersHeight = 30;
            dgvDeduction.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvDeduction.DefaultCellStyle.ForeColor = Color.DarkBlue;

            dgvDeduction.EnableHeadersVisualStyles = false;
            dgvDeduction.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvDeduction.ColumnHeadersDefaultCellStyle.ForeColor = Color.AliceBlue;
            dgvDeduction.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            return dt;
        }
        private void CustomColumnAllowance() 
        {
            //add delete button
            DataGridViewLinkColumn delink = new DataGridViewLinkColumn();
            delink.UseColumnTextForLinkValue = true;
            delink.HeaderText = "Delete";
            delink.DataPropertyName = "Delete";
            delink.LinkBehavior = LinkBehavior.SystemDefault;
            delink.Text = "Delete";
            dgvAllowance.Columns.Add(delink);
        }
        private void CustomColumnCommission()
        {
            //add delete button
            DataGridViewLinkColumn comdel = new DataGridViewLinkColumn();
            comdel.UseColumnTextForLinkValue = true;
            comdel.HeaderText = "Delete";
            comdel.DataPropertyName = "Delete";
            comdel.LinkBehavior = LinkBehavior.SystemDefault;
            comdel.Text = "Delete";
            dgvComission.Columns.Add(comdel);
        }
        private void CustomColumnDeduction()
        {
            //add delete button
            DataGridViewLinkColumn deddel = new DataGridViewLinkColumn();
            deddel.UseColumnTextForLinkValue = true;
            deddel.HeaderText = "Delete";
            deddel.DataPropertyName = "Delete";
            deddel.LinkBehavior = LinkBehavior.SystemDefault;
            deddel.Text = "Delete";
            dgvDeduction.Columns.Add(deddel);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAllowance_Click(object sender, EventArgs e)
        {
            aempid = lblempid.Text;
            frmAddAllowance aa = new frmAddAllowance(this);
            aa.UpdateEventHandler += F2_UpdateEventHandler1;
            aa.ShowDialog();
        }
        private void btnAddCom_Click(object sender, EventArgs e)
        {
            aempid = lblempid.Text;
            frmAddCommission ac = new frmAddCommission(this);
            ac.UpdateEventHandler += F2_UpdateEventHandler2;
            ac.ShowDialog();
        }
        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            aempid = lblempid.Text;
            frmAddDeduction ad = new frmAddDeduction(this);
            ad.UpdateEventHandler += F2_UpdateEventHandler3;
            ad.ShowDialog();
        }
        //allowance
        private void F2_UpdateEventHandler1(object sender, frmAddAllowance.UpdateEventArgs args)
        {
            dgvAllowance.Columns.Clear();
            dgvAllowance.DataSource = BindSource();
            CustomColumnAllowance();
            dgvAllowance.Columns[0].Visible = false;
        }
        //commission
        private void F2_UpdateEventHandler2(object sender, frmAddCommission.UpdateEventArgs args)
        {
            dgvComission.Columns.Clear();
            dgvComission.DataSource = BindSourceCommission();
            CustomColumnCommission();
            dgvComission.Columns[0].Visible = false;
        }
        //deduction
        private void F2_UpdateEventHandler3(object sender, frmAddDeduction.UpdateEventArgs args)
        {
            dgvDeduction.Columns.Clear();
            dgvDeduction.DataSource = BindSourceDeduction();
            CustomColumnDeduction();
            dgvDeduction.Columns[0].Visible = false;
        }

        private void dgvAllowance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)//delete button click
            {
                int row;
                row = e.RowIndex;
                id = Convert.ToString(dgvAllowance.Rows[row].Cells[0].Value);

                //delete record
                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "sp_deleteAllowance";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Deleted!");
                }
                con.conClose();

                //refresh datagridview
                dgvAllowance.Columns.Clear();
                dgvAllowance.DataSource = BindSource();
                dgvAllowance.Columns[0].Visible = false;
                CustomColumnAllowance();
            }
        }

        private void dgvComission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 4)//delete button click
            {
                int row;
                row = e.RowIndex;
                id = Convert.ToString(dgvComission.Rows[row].Cells[0].Value);

                //delete record
                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "sp_deleteEmpCommission";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Deleted!");
                }
                con.conClose();

                //refresh datagridview
                dgvComission.Columns.Clear();
                dgvComission.DataSource = BindSourceCommission();
                dgvComission.Columns[0].Visible = false;
                CustomColumnCommission();
            }
        }

        private void dgvDeduction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)//delete button click
            {
                int row;
                row = e.RowIndex;
                id = Convert.ToString(dgvDeduction.Rows[row].Cells[0].Value);

                //delete record
                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "sp_deleteEmpDeduction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Record Deleted!");
                }
                con.conClose();

                //refresh datagridview
                dgvDeduction.Columns.Clear();
                dgvDeduction.DataSource = BindSourceDeduction();
                dgvDeduction.Columns[0].Visible = false;

                CustomColumnDeduction();
            }
        }
    }
}
