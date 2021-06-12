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
    public partial class frmLeaveApplication : Form
    {
        Connection con = new Connection();
        public frmLeaveApplication()
        {
            InitializeComponent();
            GetDeptId();
            GetEmpList();
            GetLeaveType();
            LoadStatus();
            ShowData();
            CustomColumn();
            txtId.Enabled = false;

        }
        public void GetEmpList()
        {
            try
            {
                con.DBCon();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Connection.conn;
                    cmd.CommandText = "SELECT id, name from tbl_employee";
                    using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            adpt.Fill(ds, "Emp");
                            cmbEmpName.DisplayMember = "name";
                            cmbEmpName.ValueMember = "id";
                            cmbEmpName.DataSource = ds.Tables["Emp"];
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                con.conClose();
            }
        }
        public void GetLeaveType()
        {
            try
            {
                con.DBCon();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Connection.conn;
                    cmd.CommandText = "SELECT Id, Name from tbl_leaveType";
                    using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            adpt.Fill(ds, "lt");
                            cmbLeaveType.DisplayMember = "Name";
                            cmbLeaveType.ValueMember = "Id";
                            cmbLeaveType.DataSource = ds.Tables["lt"];
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                con.conClose();
            }
        }

        public void LoadStatus()
        {
            SortedDictionary<string, int> status = new SortedDictionary<string, int>
            {
                {"Pending", 1},
                {"Approved", 2},
                {"Rejected", 3}
            };
            cmbStatus.DataSource = new BindingSource(status, null);
            cmbStatus.DisplayMember = "Key";
            cmbStatus.ValueMember = "Value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int eid = Convert.ToInt32(cmbEmpName.SelectedValue);
            int lid = Convert.ToInt32(cmbLeaveType.SelectedValue);
            string sid = cmbStatus.Text;

            SqlTransaction transaction;
            con.DBCon();
            transaction = Connection.conn.BeginTransaction();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Transaction = transaction;
                cmd.Connection = Connection.conn;
                cmd.CommandText = "SELECT COUNT(*) FROM tbl_employeeLeave WHERE id='" + txtId.Text + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                try
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        cmd.CommandText = "UPDATE tbl_employeeLeave SET empId=@eid,leaveId=@lid,leaveReason=@reason,leaveDays=@totalDays,fromDate=@from,toDate=@to,leaveIssueDate=@today,status=@status WHERE id=@id";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO tbl_employeeLeave VALUES(@eid,@lid,@reason,@totalDays,@from,@to,@today,@status)";
                    } 
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("id", txtId.Text));
                    cmd.Parameters.Add(new SqlParameter("eid", eid));
                    cmd.Parameters.Add(new SqlParameter("lid", lid));
                    cmd.Parameters.Add(new SqlParameter("reason", txtReason.Text));
                    cmd.Parameters.Add(new SqlParameter("totalDays",txttotalLeaveDays.Text));
                    cmd.Parameters.Add(new SqlParameter("from", dateFrom.Value.ToShortDateString()));
                    cmd.Parameters.Add(new SqlParameter("to", dateTo.Value.ToShortDateString()));
                    cmd.Parameters.Add(new SqlParameter("today", DateTime.Today.ToShortDateString()));
                    cmd.Parameters.Add(new SqlParameter("status", sid));
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Operation successful.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    btnSave.Text = "Save";
                    cmbEmpName.Enabled = true;
                    ShowData();
                    con.conClose();
                    ClearAll();
                }
            }
        }
        public void ClearAll()
        {
            txttotalLeaveDays.Clear();
            txtReason.Clear();
            cmbStatus.Text = "Approved";
        }
        public void ShowData()
        {
            con.DBCon();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Connection.conn;
                cmd.CommandText = "SELECT el.id, emp.name,lt.Name,el.leaveReason,el.leaveDays'Days',el.fromDate,el.toDate,el.status FROM tbl_employeeLeave AS el inner join tbl_employee as emp on emp.id = el.empId inner join tbl_leaveType as lt on lt.Id = el.leaveId order by el.id desc";
                using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
                {
                    using (DataSet ds = new DataSet())
                    {
                        adpt.Fill(ds, "leaveApplication");
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                        con.conClose();
                    }
                }
            }
        }
        private void GetDeptId()
        {
            con.DBCon();
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id FROM tbl_employeeLeave ORDER BY Id DESC", Connection.conn))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
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
                    }

                }

            }

            con.conClose();
        }
        private void CustomColumn()
        {
            //add update button
            DataGridViewButtonColumn updateLink = new DataGridViewButtonColumn();
            updateLink.UseColumnTextForButtonValue = true;
            updateLink.HeaderText = "Update";
            updateLink.DataPropertyName = "update";
            updateLink.Text = "Update";
            updateLink.FlatStyle = FlatStyle.Flat;
            updateLink.DefaultCellStyle.BackColor = Color.Brown;
            updateLink.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns.Add(updateLink);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)//update button click
            {
                int row;
                row = e.RowIndex;

                txtId.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                cmbEmpName.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                cmbLeaveType.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                txtReason.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
                txttotalLeaveDays.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
                dateFrom.Text = dataGridView1.Rows[row].Cells[6].Value.ToString();
                dateTo.Text = dataGridView1.Rows[row].Cells[7].Value.ToString();
                cmbStatus.Text = dataGridView1.Rows[row].Cells[8].Value.ToString();
                btnSave.Text = "Update";
                cmbEmpName.Enabled = false;
            }
        }

    }
}
