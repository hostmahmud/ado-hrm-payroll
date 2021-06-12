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

namespace HRM
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            new frmLogin().Show();
        }

        private void frmSignup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                Encryption en = new Encryption();
                password = en.encrypt(password);

                Connection con = new Connection();
                SqlTransaction transaction;
                con.DBCon();
                transaction = Connection.conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = transaction;
                    cmd.Connection = Connection.conn;
                    try
                    {
                        cmd.CommandText = "insert into tbl_admins values(@u,@p,@s)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("u", username));
                        cmd.Parameters.Add(new SqlParameter("p", password));
                        cmd.Parameters.Add(new SqlParameter("s", 1));
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Registration Successful. Press OK to login.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                        new frmLogin().Show();

                    }
                    catch (SqlException se)
                    {
                        switch (se.Number)
                        {
                            case 2627:
                                MessageBox.Show("Username must be unique.");
                                break;
                            default:
                                throw;
                        }
                        transaction.Rollback();
                    }
                    finally
                    {
                        con.conClose();
                    }
                }
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtUsername, "Username can't left blank");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(txtUsername, "");
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                txtUsername.BackColor = Color.Red;
            }
            else
            {
                e.Handled = false;
                txtUsername.BackColor = Color.White;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errProvider.SetError(txtPassword, "Password can't left blank");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(txtPassword, "");
            }
        }
    }
}
