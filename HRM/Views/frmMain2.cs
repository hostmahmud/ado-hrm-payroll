using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM.Views
{
    public partial class frmMain2 : Form
    {
        public frmMain2()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelEmpSubMenu.Visible = false;
            panelLeaveSubMenu.Visible = false;
            panelPayrollSubMenu.Visible = false;
        }
        
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelEmpSubMenu);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnMenuEmp_Click(object sender, EventArgs e)
        {
            showSubMenu(panelEmpSubMenu);
        }

        private void btnMenuDept_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDepartment());
        }

        private void btnMenuDesig_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDesignation());
        }

        private void btnMenuLeaveMgmt_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLeaveSubMenu);
        }

        private void btnMenuDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMain());
            hideSubMenu();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAddEmployee());
        }

        private void frmMain2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmListEmployee());

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelLeaveSubMenu);
        }

        private void btnMenuPayroll_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPayrollSubMenu);
        }

        private void btnMenuSetSalary_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageSalary());
        }

        private void btnMenuPayslip_Click(object sender, EventArgs e)
        {
            openChildForm(new frmPayslip());
        }

        private void btnAddLeaveType_Click(object sender, EventArgs e)
        {
            openChildForm(new frmLeaveType());
        }

        private void btnAddLeaveApplication_Click(object sender, EventArgs e)
        {
            openChildForm(new frmLeaveApplication());
        }
    }
}
