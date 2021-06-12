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
    public partial class frmAddAllowance : Form
    {//frmManageSalaryIndividual.aempid
        public frmAddAllowance(frmManageSalaryIndividual msi)
        {
            InitializeComponent();
            msi1 = msi;
            cmbOption.Text = "--Select Option--";
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        frmManageSalaryIndividual msi1;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void raiseUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(frmManageSalaryIndividual.aempid);
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                
                Connection con = new Connection();
                con.DBCon();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Connection.conn;
                    cmd.CommandText = "insert into tbl_empAllowance values(@empid,@option,@title,@amount)";
                    cmd.Parameters.AddWithValue("@empid", id);
                    cmd.Parameters.AddWithValue("@option", cmbOption.Text);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.conClose();
                    this.Close();
                    raiseUpdate();
                }
            }
        }        
    }
}
