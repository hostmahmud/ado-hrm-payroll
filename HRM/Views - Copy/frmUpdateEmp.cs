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
using HRM.Views;

namespace HRM.Views
{
    public partial class frmUpdateEmp : Form
    {
        public frmUpdateEmp()
        {
            InitializeComponent();
            cmbGender.DataSource = Enum.GetValues(typeof(EGender));
            cmbCity.DataSource = Enum.GetValues(typeof(ECity));
            cmbCounry.DataSource = Enum.GetValues(typeof(ECountry));
            GetDepartment();
            GetDesignation();
            showData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showData() {
            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "SELECT * FROM tbl_employee WHERE id=" + frmListEmployee.empid + "";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtEmpId.Text = dr.GetValue(0).ToString();
                txtName.Text = dr.GetValue(1).ToString();
                txtFatherName.Text = dr.GetValue(2).ToString();
                txtDob.Text = dr.GetValue(3).ToString();
                cmbGender.Text = dr.GetValue(4).ToString();
                txtEmail.Text = dr.GetValue(5).ToString();
                txtAddress.Text = dr.GetValue(6).ToString();
                cmbCity.Text = dr.GetValue(7).ToString();
                cmbCounry.Text = dr.GetValue(8).ToString();
                txtNid.Text = dr.GetValue(9).ToString();

                //photo
                picEmpProfile.Image = new Bitmap(dr.GetValue(10).ToString());
                picEmpProfile.SizeMode = PictureBoxSizeMode.StretchImage;

                label22.Enabled = false;
                label22.Text = dr.GetValue(10).ToString();

                cmbDesignation.SelectedIndex = Convert.ToInt32(dr.GetValue(12)) - 1;
                cmbDepartment.SelectedIndex = Convert.ToInt32(dr.GetValue(11)) - 1;
                
                txtJoinDate.Text = dr.GetValue(13).ToString();
                txtJoinSalary.Text = dr.GetValue(14).ToString();

                //logins
                txtUsername.Text = dr.GetValue(15).ToString();
                txtPassword.Text = dr.GetValue(16).ToString();

                //bank info
                txtBankAccName.Text = dr.GetValue(17).ToString();
                txtBankAccNumber.Text = dr.GetValue(18).ToString();
                txtBankName.Text = dr.GetValue(19).ToString();
                txtBankBranch.Text = dr.GetValue(20).ToString();


            }

            con.conClose();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.DBCon();

            //photo
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string fileExt = System.IO.Path.GetExtension(openFileDialog1.FileName);
            string Photo = path + "\\empImages\\" + txtNid.Text + DateTime.Today.Hour.ToString() +DateTime.Today.Second.ToString() + fileExt;
            if (fileExt == "")
            {
                Photo = label22.Text;
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "UPDATE tbl_employee SET name = @name, fatherName = @fathername, birthDate = @dob, gender = @gender, email = @email, address = @address, city = @city, country = @country, nationalIDNo = @nid, photo = @pic, deptId = @deptid, desigID = @desigid, joinDate = @joindate, joinSalary = @salary, username = @uname, password = @pass, bankAccountName = @baname, bankAccountNumber = @accnumber, bankName = @bname, bankBranch = @branchname WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", txtEmpId.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@fathername", txtFatherName.Text);
            cmd.Parameters.AddWithValue("@dob", txtDob.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@city", cmbCity.Text);
            cmd.Parameters.AddWithValue("@country", cmbCounry.Text);
            cmd.Parameters.AddWithValue("@nid", txtNid.Text);
            cmd.Parameters.AddWithValue("@pic", Photo);
            cmd.Parameters.AddWithValue("@deptid", cmbDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@desigid", cmbDesignation.SelectedValue);
            cmd.Parameters.AddWithValue("@joindate", txtJoinDate.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@salary", txtJoinSalary.Text);
            cmd.Parameters.AddWithValue("@uname", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            cmd.Parameters.AddWithValue("@baname", txtBankAccName.Text);
            cmd.Parameters.AddWithValue("@accnumber", txtBankAccNumber.Text);
            cmd.Parameters.AddWithValue("@bname", txtBankName.Text);
            cmd.Parameters.AddWithValue("@branchname", txtBankBranch.Text);

            //upload image to folder
            if (fileExt != "") {
                System.IO.File.Copy(openFileDialog1.FileName, Photo);
            }
                

            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Updated Successfully");
            
            con.conClose();

            frmListEmployee le = new frmListEmployee();
            le.Refresh();
            this.Close();


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
        public void GetDepartment()
        {
            try
            {
                Connection con = new Connection();
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

                con.conClose();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        public void GetDesignation()
        {
            try
            {
                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "select name, id from tbl_designation where Status=1";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds, "Desig");

                cmbDesignation.DisplayMember = "name";
                cmbDesignation.ValueMember = "id";
                cmbDesignation.DataSource = ds.Tables["Desig"];

                con.conClose();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptsi = cmbDepartment.SelectedIndex + 1;

            ComboBox cmb = (ComboBox)sender;
            string desigId = cmb.SelectedValue.ToString();


            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmds = new SqlCommand();
            cmds.Connection = Connection.conn;
            cmds.CommandText = "SELECT salaryAmount FROM tbl_designation where deptId=" + deptsi + " and id='" + desigId + "'";
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
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            int si = selectedIndex + 1;

            Connection con = new Connection();
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

    }
}
