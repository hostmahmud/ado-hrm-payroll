using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace HRM
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Encryption en = new Encryption();
            string pass = en.encrypt(txtPassword.Text);

            Classes.Connection con = new Classes.Connection();
            con.DBCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Classes.Connection.conn;
            cmd.CommandText = "SELECT COUNT(*) FROM tbl_admins WHERE username='" + txtUsername.Text + "' AND password='" + pass + "' AND status=1";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new Views.frmMain2().Show();
            }
            else
                MessageBox.Show("Invalid username or password");

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
            lbldate.Text = DateTime.Now.ToString("MMM dd yyyy");
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            new frmSignup().Show();
        }

    }
}
