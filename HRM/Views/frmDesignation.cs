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
using HRM.Classes;

namespace HRM.Views
{
    public partial class frmDesignation : Form
    {
        public frmDesignation()
        {
            InitializeComponent();
            GetDesigId();
            GetDepartments();
            rdoYes.Checked = true;
            ShowData();
            Load += frmDesignation_Load;
            CustomColumn();
            styleGridView();
        }
        private void frmDesignation_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[5].Width = 60;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
            GC.Collect();
        }
        private void GetDesigId()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "SELECT TOP 1 Id FROM tbl_designation ORDER BY Id DESC";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                int id = Convert.ToInt32(dt.Rows[0]["Id"]);
                txtId.Text = (id + 1).ToString();
            }
            else
            {
                txtId.Text = "1";
            }
            con.conClose();
            GC.Collect();
        }
        public void GetDepartments() {
            try
            {
                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "select Name, Id from tbl_department where Status=1";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds, "Dept");

                cmbDept.DisplayMember = "Name";
                cmbDept.ValueMember = "Id";
                cmbDept.DataSource = ds.Tables["Dept"];

                con.conClose();
                GC.Collect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ShowData()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;

            cmd.CommandText = "SELECT desig.id 'ID',desig.name 'Name',desig.salaryAmount 'Salary',dept.name 'Department', IIF(desig.status >0 ,'Active','Inactive') 'Status' FROM tbl_designation as desig join tbl_department as dept on dept.id = desig.deptId";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adpt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            con.conClose();

            GC.Collect();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                AddDesignation ad = new AddDesignation();
                ad.Id = Convert.ToInt32(txtId.Text);
                ad.Name = txtName.Text;
                ad.DeptId = Convert.ToInt32(cmbDept.SelectedIndex + 1);
                ad.Salary = Convert.ToDecimal(txtSalary.Text);
                if (rdoYes.Checked)
                {
                    ad.Status = 1;
                }
                else if (rdoNo.Checked)
                {
                    ad.Status = 0;
                }

                Connection con = new Connection();
                SqlTransaction transaction;
                con.DBCon();
                transaction = Connection.conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = transaction;
                    cmd.Connection = Connection.conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM tbl_designation WHERE id='" + ad.Id + "'";
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    try
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            cmd.CommandText = "UPDATE tbl_designation SET name=@name,deptId=@deptid,salaryAmount=@salary,status=@status WHERE id = @id";
                            btnSave.Text = "Save";
                        }
                        else
                        {
                            cmd.CommandText = "insert into tbl_designation values(@name,@deptid,@salary,@status)";
                        }
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("id",ad.Id));
                        cmd.Parameters.Add(new SqlParameter("name", ad.Name));
                        cmd.Parameters.Add(new SqlParameter("deptid", ad.DeptId));
                        cmd.Parameters.Add(new SqlParameter("salary", ad.Salary));
                        cmd.Parameters.Add(new SqlParameter("status", ad.Status));
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Operation Successful.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        con.conClose();
                    }
                }
                
                ClearAll();
                GetDesigId();
                ShowData();
                GC.Collect();
            }
        }
        public void ClearAll()
        {
            txtName.Clear();
            cmbDept.Text = "";
            txtSalary.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                txtName.BackColor = Color.Red;
                errorProvider1.SetError(txtName, "Name can't left blank");
            }
            else
            {
                txtName.BackColor = Color.White;
                e.Cancel = false;
            }
        }

        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalary.Text))
            {
                e.Cancel = true;
                txtSalary.Focus();
                txtSalary.BackColor = Color.Red;
                errorProvider1.SetError(txtSalary,"Salary can't left blank");
            }
            else
            {
                txtSalary.BackColor = Color.White;
                e.Cancel = false;
            }
        }


        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                txtSalary.BackColor = Color.Red;
                errorProvider1.SetError(txtSalary, "Only 0-9 allowed");
            }
            else
            {
                e.Handled = false;
                txtSalary.BackColor = Color.White;
            }
        }
        private void CustomColumn()
        {
            //update button
            DataGridViewButtonColumn update = new DataGridViewButtonColumn();
            update.UseColumnTextForButtonValue = true;
            update.HeaderText = "Action";
            update.DataPropertyName = "Update";
            update.Text = "Update";
            update.Name = "Update";
            update.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            update.FlatStyle = FlatStyle.Flat;
            update.DefaultCellStyle.BackColor = Color.Coral;
            update.DefaultCellStyle.ForeColor = Color.White;
            update.FillWeight=50;
            dataGridView1.Columns.Add(update);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int row = e.RowIndex;
                txtId.Text= dataGridView1.Rows[row].Cells[1].Value.ToString();
                txtName.Text= dataGridView1.Rows[row].Cells[2].Value.ToString();
                cmbDept.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
                txtSalary.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                string stat = dataGridView1.Rows[row].Cells[5].Value.ToString();
                if (stat == "Active")
                {
                    rdoYes.Checked = true;
                }
                else if (stat=="Inactive")
                {
                    rdoNo.Checked = true;
                }
                btnSave.Text = "Update";
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
    }
}
