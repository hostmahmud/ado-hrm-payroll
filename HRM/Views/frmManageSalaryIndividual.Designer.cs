
namespace HRM.Views
{
    partial class frmManageSalaryIndividual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageSalaryIndividual));
            this.lblSalary = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblempid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAddDeduction = new FontAwesome.Sharp.IconButton();
            this.dgvDeduction = new System.Windows.Forms.DataGridView();
            this.btnAddDeduc = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvComission = new System.Windows.Forms.DataGridView();
            this.btnAddCom = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddAllowance = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAllowance = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeduction)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComission)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllowance)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSalary
            // 
            this.lblSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(294, 59);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(122, 23);
            this.lblSalary.TabIndex = 1;
            this.lblSalary.Text = "Salary Amount";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(294, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Basic Salary";
            // 
            // lblType
            // 
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(60, 59);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(122, 23);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Payslip Type";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Payslip Type";
            // 
            // lblempid
            // 
            this.lblempid.AutoSize = true;
            this.lblempid.Location = new System.Drawing.Point(407, 11);
            this.lblempid.Name = "lblempid";
            this.lblempid.Size = new System.Drawing.Size(35, 13);
            this.lblempid.TabIndex = 2;
            this.lblempid.Text = "label4";
            this.lblempid.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(4, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label8.Size = new System.Drawing.Size(523, 35);
            this.label8.TabIndex = 0;
            this.label8.Text = "Allowance";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1074, 556);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnAddDeduction);
            this.panel5.Controls.Add(this.dgvDeduction);
            this.panel5.Controls.Add(this.btnAddDeduc);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(547, 218);
            this.panel5.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(527, 207);
            this.panel5.TabIndex = 8;
            // 
            // btnAddDeduction
            // 
            this.btnAddDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddDeduction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDeduction.FlatAppearance.BorderSize = 0;
            this.btnAddDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDeduction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddDeduction.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAddDeduction.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddDeduction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddDeduction.IconSize = 35;
            this.btnAddDeduction.Location = new System.Drawing.Point(487, 1);
            this.btnAddDeduction.Name = "btnAddDeduction";
            this.btnAddDeduction.Padding = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.btnAddDeduction.Size = new System.Drawing.Size(37, 32);
            this.btnAddDeduction.TabIndex = 7;
            this.btnAddDeduction.UseVisualStyleBackColor = false;
            this.btnAddDeduction.Click += new System.EventHandler(this.btnAddDeduction_Click);
            // 
            // dgvDeduction
            // 
            this.dgvDeduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeduction.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeduction.Location = new System.Drawing.Point(4, 36);
            this.dgvDeduction.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvDeduction.Name = "dgvDeduction";
            this.dgvDeduction.Size = new System.Drawing.Size(523, 171);
            this.dgvDeduction.TabIndex = 7;
            this.dgvDeduction.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeduction_CellContentClick);
            // 
            // btnAddDeduc
            // 
            this.btnAddDeduc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddDeduc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDeduc.ForeColor = System.Drawing.Color.White;
            this.btnAddDeduc.Location = new System.Drawing.Point(4, 1);
            this.btnAddDeduc.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAddDeduc.Name = "btnAddDeduc";
            this.btnAddDeduc.Padding = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.btnAddDeduc.Size = new System.Drawing.Size(523, 35);
            this.btnAddDeduc.TabIndex = 6;
            this.btnAddDeduc.Text = "Deduction";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblempid);
            this.panel4.Controls.Add(this.dgvComission);
            this.panel4.Controls.Add(this.btnAddCom);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 218);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(537, 207);
            this.panel4.TabIndex = 7;
            // 
            // dgvComission
            // 
            this.dgvComission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComission.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvComission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComission.Location = new System.Drawing.Point(0, 35);
            this.dgvComission.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvComission.Name = "dgvComission";
            this.dgvComission.Size = new System.Drawing.Size(521, 172);
            this.dgvComission.TabIndex = 7;
            this.dgvComission.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComission_CellContentClick);
            // 
            // btnAddCom
            // 
            this.btnAddCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCom.FlatAppearance.BorderSize = 0;
            this.btnAddCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddCom.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAddCom.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddCom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddCom.IconSize = 35;
            this.btnAddCom.Location = new System.Drawing.Point(484, 1);
            this.btnAddCom.Name = "btnAddCom";
            this.btnAddCom.Padding = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.btnAddCom.Size = new System.Drawing.Size(37, 32);
            this.btnAddCom.TabIndex = 5;
            this.btnAddCom.UseVisualStyleBackColor = false;
            this.btnAddCom.Click += new System.EventHandler(this.btnAddCom_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(521, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Commission";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddAllowance);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(547, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 35);
            this.panel2.TabIndex = 6;
            // 
            // btnAddAllowance
            // 
            this.btnAddAllowance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddAllowance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAllowance.FlatAppearance.BorderSize = 0;
            this.btnAddAllowance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAllowance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddAllowance.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAddAllowance.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddAllowance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddAllowance.IconSize = 35;
            this.btnAddAllowance.Location = new System.Drawing.Point(490, 0);
            this.btnAddAllowance.Name = "btnAddAllowance";
            this.btnAddAllowance.Padding = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.btnAddAllowance.Size = new System.Drawing.Size(37, 32);
            this.btnAddAllowance.TabIndex = 5;
            this.btnAddAllowance.UseVisualStyleBackColor = false;
            this.btnAddAllowance.Click += new System.EventHandler(this.btnAddAllowance_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvAllowance);
            this.panel1.Location = new System.Drawing.Point(547, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 175);
            this.panel1.TabIndex = 4;
            // 
            // dgvAllowance
            // 
            this.dgvAllowance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllowance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvAllowance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllowance.Location = new System.Drawing.Point(4, 0);
            this.dgvAllowance.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dgvAllowance.Name = "dgvAllowance";
            this.dgvAllowance.Size = new System.Drawing.Size(523, 175);
            this.dgvAllowance.TabIndex = 3;
            this.dgvAllowance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllowance_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblSalary);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblType);
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(521, 175);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(521, 35);
            this.label4.TabIndex = 1;
            this.label4.Text = "Employee Basic Salary";
            // 
            // frmManageSalaryIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 425);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmManageSalaryIndividual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Set Employee Salary";
            this.Load += new System.EventHandler(this.frmManageSalaryIndividual_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeduction)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComission)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllowance)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblempid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnAddAllowance;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnAddCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvComission;
        private System.Windows.Forms.DataGridView dgvAllowance;
        private FontAwesome.Sharp.IconButton btnAddDeduction;
        private System.Windows.Forms.DataGridView dgvDeduction;
        private System.Windows.Forms.Label btnAddDeduc;
    }
}