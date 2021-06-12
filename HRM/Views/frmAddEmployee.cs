using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRM.Classes;

namespace HRM.Views
{
    public partial class frmAddEmployee : Form
    {
        Connection con = new Connection();
        public frmAddEmployee()
        {
            InitializeComponent();
            GetEmpId();
            GetDepartment();
            cmbGender.DataSource = Enum.GetValues(typeof(EGender));
            cmbCity.DataSource = Enum.GetValues(typeof(ECity));
            cmbCounry.DataSource = Enum.GetValues(typeof(ECountry));
            getStatus();
            btnSave.Enabled = false;
            btnSave.Cursor = Cursors.No;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                AddEmployee ae = new AddEmployee();
                ae.Name = txtName.Text;
                ae.Nid = txtNid.Text;
                ae.FatherName = txtFatherName.Text;
                ae.Dob = txtDob.Value.ToShortDateString();
                ae.Gender = cmbGender.Text;
                ae.Email = txtEmail.Text;
                ae.Address = txtAddress.Text;
                ae.City = cmbCity.Text;
                ae.Country = cmbCounry.Text;
                ae.DesigId = Convert.ToInt32(cmbDesignation.SelectedValue);
                ae.DeptId = (cmbDepartment.SelectedIndex) + 1;
                ae.JoinDate = txtJoinDate.Value.ToShortDateString();
                ae.JoinSalary = Convert.ToDecimal(txtJoinSalary.Text);

                //bank info
                ae.BankAccName = txtBankAccName.Text;
                ae.BankAccNumber = txtBankAccNumber.Text;
                ae.BankName = txtBankName.Text;
                ae.BankBranch = txtBankBranch.Text;

                //photo
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string fileExt = System.IO.Path.GetExtension(openFileDialog1.FileName);
                ae.Photo = "\\empImages\\" + ae.Nid + fileExt;
                if (ae.Photo == null)
                {
                    MessageBox.Show("Please select a valid image.");
                }
                
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "sp_insertEmployeeAndStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name",SqlDbType.VarChar,20).Value=ae.Name;
                cmd.Parameters.Add("@father", SqlDbType.VarChar,50).Value=ae.FatherName;
                cmd.Parameters.Add("@dob",SqlDbType.DateTime).Value=ae.Dob;
                cmd.Parameters.Add("@gender",SqlDbType.VarChar,10).Value=ae.Gender;
                cmd.Parameters.Add("@email",SqlDbType.VarChar,50).Value=ae.Email;
                cmd.Parameters.Add("@address",SqlDbType.VarChar,100).Value=ae.Address;
                cmd.Parameters.Add("@city",SqlDbType.VarChar,20).Value=ae.City;
                cmd.Parameters.Add("@country",SqlDbType.VarChar,25).Value=ae.Country;
                cmd.Parameters.Add("@nid",SqlDbType.Char,13).Value=ae.Nid;
                cmd.Parameters.Add("@photo",SqlDbType.VarChar,200).Value=ae.Photo;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value=ae.DeptId;
                cmd.Parameters.Add("@desigID", SqlDbType.Int).Value=ae.DesigId;
                cmd.Parameters.Add("@joinDate", SqlDbType.Date).Value=ae.JoinDate;
                cmd.Parameters.Add("@joinSalary", SqlDbType.Money).Value=ae.JoinSalary;
                cmd.Parameters.Add("@bankAccountName", SqlDbType.VarChar,50).Value=ae.BankAccName;
                cmd.Parameters.Add("@bankAccountNumber", SqlDbType.VarChar,20).Value=ae.BankAccNumber;
                cmd.Parameters.Add("@bankName", SqlDbType.VarChar,50).Value=ae.BankName;
                cmd.Parameters.Add("@bankBranch", SqlDbType.VarChar,30).Value=ae.BankBranch;
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value=txtEmpId.Text;
                cmd.Parameters.Add("@statusid", SqlDbType.Int).Value=cmbStatus.SelectedValue;
                
                cmd.ExecuteNonQuery();

                //upload image to folder
                System.IO.File.Copy(openFileDialog1.FileName, path+ "\\empImages\\" + ae.Nid + fileExt);

                MessageBox.Show("Employee saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.conClose();
                GetEmpId();
                ClearAll();
            }

        }
        private void GetEmpId()
        {
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "SELECT TOP 1 id FROM tbl_employee ORDER BY id DESC";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                int id = Convert.ToInt32(dt.Rows[0]["id"]);
                txtEmpId.Text = (id + 1).ToString();
            }
            else
            {
                txtEmpId.Text = "101";
            }
            con.conClose();
        }
        public void GetDepartment()
        {
            try
            {
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "select name, id from tbl_department where Status=1";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds, "Dept");

                cmbDepartment.DisplayMember = "name";
                cmbDepartment.ValueMember = "id";
                cmbDepartment.DataSource = ds.Tables["Dept"];

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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtName, "Name can't left blank");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(txtName, "");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                txtName.BackColor = Color.Red;
                
                MessageBox.Show("Only A to Z allowed!", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
                txtName.BackColor = Color.White;
            }
        }

        private void txtFatherName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtFatherName, "Father name can't left blank");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(txtFatherName, "");
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                txtFatherName.BackColor = Color.Red;
                MessageBox.Show("Only A to Z allowed!", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
                txtFatherName.BackColor = Color.White;
            }
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) ||e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                cmbGender.BackColor = Color.Red;
                MessageBox.Show("Please select options from dropdown", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
                cmbGender.BackColor = Color.White;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtEmail, "Email can't left blank");
            }
            else
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(txtEmail.Text);
                if (match.Success)
                {
                    e.Cancel = false;
                    errProvider.SetError(txtEmail, "");
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Invalid email address", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtAddress, "Address can't left blank");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(txtAddress, "");
            }
        }

        private void txtNid_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNid.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtNid, "NID number can't left blank");
            }
            else
            {
                if (txtNid.Text.Length == 13)
                {
                    con.DBCon();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Connection.conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM tbl_employee WHERE nationalIDNo='" + txtNid.Text + "'";
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        e.Cancel = true;
                        errProvider.SetError(txtNid, "NID already exist. Please choose a different NID number.");
                    }
                    else 
                    {
                        e.Cancel = false;
                        errProvider.SetError(txtNid, "");
                    }
                    
                }
                else 
                {
                    e.Cancel = true;
                    errProvider.SetError(txtNid, "Please enter 13 digit NID number");
                }

                
            }
        }

        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select image to be uploaded.";
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        picEmpProfile.Image = new Bitmap(openFileDialog1.FileName);
                        picEmpProfile.SizeMode = PictureBoxSizeMode.StretchImage;

                        btnSave.Enabled = true;
                        btnSave.Cursor = Cursors.Hand;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearAll()
        {
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            txtName.Clear();
            txtFatherName.Clear();
            txtDob.Text = "";
            cmbGender.Text = "Male";
            txtEmail.Clear();
            txtAddress.Clear();
            cmbCity.Text = "Dhaka";
            cmbCounry.Text = "Bangladesh";
            txtNid.Clear();
            picEmpProfile.ImageLocation = path + "\\empImages\\placeholder-profile.png";
            cmbDesignation.Text = "";
            cmbDepartment.Text = "";
            txtJoinDate.Text = "";
            txtJoinSalary.Clear();
            txtBankAccName.Clear();
            txtBankAccNumber.Clear();
            txtBankName.Clear();
            txtBankBranch.Clear();
            btnSave.Enabled = false;
            btnSave.Cursor = Cursors.No;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int si = selectedIndex + 1;

            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "select desig.id,desig.name from tbl_designation as desig where desig.deptId = " + si + "";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            adpt.Fill(ds1, "desig");

            cmbDesignation.DisplayMember = "name";
            cmbDesignation.ValueMember = "id";
            cmbDesignation.DataSource = ds1.Tables["desig"];

            con.conClose();
        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptsi = cmbDepartment.SelectedIndex + 1;

            ComboBox cmb = (ComboBox)sender;
            string desigId = cmb.SelectedValue.ToString();

            con.DBCon();

            SqlCommand cmds = new SqlCommand();
            cmds.Connection = Connection.conn;
            cmds.CommandText = "SELECT salaryAmount FROM tbl_designation where deptId="+deptsi+" and id='"+desigId+"'";
            SqlDataAdapter adpts = new SqlDataAdapter(cmds);
            DataTable dt2 = new DataTable();
            adpts.Fill(dt2);

            if (dt2.Rows.Count == 1)
            {
                decimal salary = Convert.ToDecimal(dt2.Rows[0]["salaryAmount"]);
                txtJoinSalary.Text = decimal.Round(salary, 2, MidpointRounding.AwayFromZero).ToString();
            }
            else
            {
                txtJoinSalary.Text = "Error occured!";
            }
        }
        private void getStatus() 
        {
            try
            {
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "select Name, id from tbl_status";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds, "status");

                cmbStatus.DisplayMember = "Name";
                cmbStatus.ValueMember = "id";
                cmbStatus.DataSource = ds.Tables["status"];

                con.conClose();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

    }
}
