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
    public partial class frmDepartment : Form
    {
        public frmDepartment()
        {
            InitializeComponent();
            GetDeptId();
            rdoYes.Checked = true;
            showData();
            CustomColumn();
            styleGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                AddDepartment ad = new AddDepartment();
                ad.Id = Convert.ToInt32(txtId.Text);
                ad.Name = txtName.Text;
                if (rdoYes.Checked)
                {
                    ad.Status = 1;
                }
                else if (rdoNo.Checked)
                {
                    ad.Status = 0;
                }

                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "SELECT COUNT(*) FROM tbl_department WHERE id='"+ad.Id+"'";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    cmd.CommandText = "update tbl_department set name='"+ad.Name+"', status='"+ad.Status+"' where id="+ad.Id+"";
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Department ID " + ad.Id + " has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Text = "Save";

                    }
                    else
                    {
                        MessageBox.Show("Something wrong");
                    }
                }
                else
                {
                    cmd.CommandText = "INSERT INTO tbl_department VALUES('" + ad.Name + "'," + ad.Status + ")";
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Department ID " + ad.Id + " has been saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something wrong");
                    }
                }
                con.conClose();
                ClearAll();
                GetDeptId();
                showData();
            }
            

        }

        private void GetDeptId() 
        {
            
            Connection con = new Connection();
            con.DBCon();
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id FROM tbl_department ORDER BY Id DESC",Connection.conn))
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
        public void ClearAll() {
            txtName.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                txtErrorProvider.SetError(txtName,"Name can't be blank!");
            }
            else
            {
                e.Cancel = false;
                txtErrorProvider.SetError(txtName, "");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                txtName.BackColor = Color.Red;
                txtErrorProvider.SetError(txtName, "Only A to Z allowed!");
            }
            else 
            {
                e.Handled = false;
                txtName.BackColor = Color.White;
            }
        }

        private void showData() 
        {
            using (humanResourceManagement_DBEntities _ent = new humanResourceManagement_DBEntities())
            {
                List<Classes.AddDepartment> _dept = new List<AddDepartment>();
                _dept = _ent.tbl_department.Select(x => new AddDepartment
                {
                    Id = x.id,
                    Name=x.name,
                    Status=x.status
                }).ToList();
                dataGridView1.DataSource = _dept;
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
            dataGridView1.Columns.Add(update);

            //delete button
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = true;
            del.HeaderText = "Action";
            del.DataPropertyName = "Delete";
            del.Text = "Delete";
            del.Name = "Delete";
            del.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            del.FlatStyle = FlatStyle.Flat;
            del.DefaultCellStyle.BackColor = Color.Red;
            del.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns.Add(del);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)//update button click
            {
                int row;
                row = e.RowIndex;
                txtId.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                txtName.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                int stat = Convert.ToInt32(dataGridView1.Rows[row].Cells[4].Value);
                if (stat == 0)
                {
                    rdoNo.Checked = true;
                }
                else
                {
                    rdoYes.Checked = true;
                }
                btnSave.Text = "Update";
            }
            if (e.ColumnIndex == 1)//delete button click
            {
                int row;
                row = e.RowIndex;
                string Id = dataGridView1.Rows[row].Cells[2].Value.ToString();

                Connection con = new Connection();
                con.DBCon();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_department WHERE id=@id", Connection.conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        con.conClose();
                        MessageBox.Show("Record Deleted Successfully!");
                        ClearAll();
                        GetDeptId();
                        showData();
                    }
                }
            }
        }
    }
}
