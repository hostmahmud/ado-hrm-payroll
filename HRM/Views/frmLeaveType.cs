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
    public partial class frmLeaveType : Form
    {
        public frmLeaveType()
        {
            InitializeComponent();
            rdoYes.Checked = true;
            GetId();
            ShowData();
            Load += frmLeaveType_Load;
            CustomColumn();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string name = txtName.Text;
                    int days = Convert.ToInt32(txtDays.Text);
                    int status = 0;
                    if (rdoYes.Checked)
                    {
                        status = 1;
                    }
                    else if (rdoNo.Checked)
                    {
                        status = 0;
                    }

                    Connection con = new Connection();
                    con.DBCon();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Connection.conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM tbl_leaveType WHERE id='" + id + "'";
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        cmd.CommandText = "update tbl_leaveType set Name='"+name+"',DaysPerYear="+days+",Status="+status+" where Id = "+id+"";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Leave type ID " + id + " has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Text = "Save";
                        }
                        else
                        {
                            MessageBox.Show("Something wrong");
                        }
                    }
                    else
                    {
                        cmd.CommandText = "insert into tbl_leaveType values('" + name + "'," + days + "," + status + ")";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Leave type ID " + id + " has been saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Something wrong");
                        }
                    }
                    con.conClose();
                    ClearAll();
                    GetId();
                    ShowData();
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                GC.Collect();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.BackColor = Color.Pink;
                errorProvider1.SetError(txtName, "Name can't be blank!");
            }
            else
            {
                e.Cancel = false;
                txtName.BackColor = Color.White;
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtDays_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDays.Text))
            {
                e.Cancel = true;
                txtDays.BackColor = Color.Pink;
                errorProvider1.SetError(txtDays, "Days can't be blank!");
            }
            else
            {
                e.Cancel = false;
                txtDays.BackColor = Color.White;
                errorProvider1.SetError(txtDays, "");
            }
        }
        private void GetId()
        {
            Connection con = new Connection();
            con.DBCon();
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id FROM tbl_leaveType ORDER BY Id DESC", Connection.conn))
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
        private void ShowData()
        {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;

            cmd.CommandText = "select id 'ID', Name, DaysPerYear 'Days per Year', IIF(Status>0,'Active','Inactive')'status' from tbl_leaveType";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adpt.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            con.conClose();

            GC.Collect();
        }
        public void ClearAll()
        {
            txtName.Clear();
            txtDays.Clear();
            rdoYes.Checked = true;
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
            update.FillWeight = 50;
            dataGridView1.Columns.Add(update);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int row = e.RowIndex;
                txtId.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                txtName.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                txtDays.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                string st = dataGridView1.Rows[row].Cells[4].Value.ToString();
                if (st == "Inactive")
                {
                    rdoNo.Checked = true;
                }
                else
                {
                    rdoYes.Checked = true;
                }
                btnSave.Text = "Update";
            }
        }

        private void frmLeaveType_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
