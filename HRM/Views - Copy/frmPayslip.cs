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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace HRM.Views
{
    public partial class frmPayslip : Form
    {
        public frmPayslip()
        {
            InitializeComponent();
            cmbYear.Text = "2021";
            cmbMonth.Text = "January";

            cmbYearCreatePayslip.Text = "2021";
            cmbMonthCreatePayslip.Text = "January";
        }

        private void showData()
        {
            int month = cmbMonth.SelectedIndex + 1;

            Connection con = new Connection();
            con.DBCon();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;

            cmd.CommandText = "select ps.id 'ID', ps.empId 'Employee ID',emp.name 'Name',ps.salary 'Salary',ps.netSalary 'Net Salary',IIF(status='1','Paid','Unpaid') 'Status' from tbl_empPayslip as ps join tbl_employee as emp on emp.id = ps.empId where YEAR(ps.createdAt)= "+cmbYear.Text+" and MONTH(ps.createdAt)= "+month+"";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adpt.Fill(ds, "members");
            
            dataGridView1.DataSource = ds.Tables[0];

            con.conClose();
        }

        private void CustomColumn()
        {
            //pay button
            DataGridViewButtonColumn btnPay = new DataGridViewButtonColumn();
            btnPay.UseColumnTextForButtonValue = true;
            btnPay.HeaderText = "Action";
            btnPay.DataPropertyName = "Pay";
            btnPay.Text = "Pay";
            btnPay.Name = "Pay";
            btnPay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(btnPay);

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            showData();
            CustomColumn();
        }

        private void btnCreatePayslip_Click(object sender, EventArgs e)
        {
            int month = cmbMonthCreatePayslip.SelectedIndex + 1;
            int year = Convert.ToInt32(cmbYearCreatePayslip.Text);
            string my = Convert.ToDateTime(year + "/" + month + "/" + DateTime.Now.Day).ToShortDateString();


            Connection con = new Connection();
            con.DBCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection.conn;
            cmd.CommandText = "SELECT COUNT(*) FROM tbl_empPayslip WHERE YEAR(createdAt)="+cmbYearCreatePayslip.Text+" and MONTH(createdAt)="+month+"";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            if (Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                MessageBox.Show("Payslip for this month already created!");
            }
            else
            {
                cmd.CommandText = "insert into tbl_empPayslip select emp.id,emp.joinSalary,(emp.joinSalary+(select ISNULL(SUM(aAmount),0) as 'al' from tbl_empAllowance where empid=emp.id)+(select ISNULL(SUM(cAmount),0) as 'com' from tbl_empCommission where empid=emp.id)-(select ISNULL(SUM(dAmount),0) as 'ded' from tbl_empDeduction where empid=emp.id)) as 'Net Salary',0,'"+my+"',null,null from tbl_employee as emp";
                if (cmd.ExecuteNonQuery() > 0) 
                {
                    MessageBox.Show("Playslip created.");
                }

            }

            con.conClose();

            dataGridView1.Columns.Clear();
            showData();
            CustomColumn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)//pay button click
            {
                int row;
                row = e.RowIndex;
                string psid = Convert.ToString(dataGridView1.Rows[row].Cells[0].Value);

                Connection con = new Connection();
                con.DBCon();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connection.conn;
                cmd.CommandText = "select ps.salary, ps.netSalary, ps.status, e.name,d.name 'dname' from tbl_empPayslip ps join tbl_employee as e on e.id = ps.empId join tbl_department as d on d.id = e.deptId where ps.id = " + psid+"";
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["status"].ToString() == "1")
                    {
                        MessageBox.Show("Salary for this payslip already paid!");
                    }
                    else
                    {
                        cmd.CommandText = "update tbl_empPayslip set status=1,paidAt=GETDATE(),updatedAt=GETDATE() where id = " + psid + "";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Paid successfully");
                        }
                        dataGridView1.Columns.Clear();
                        showData();
                        CustomColumn();

                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        //generate pdf invoice
                        using (PdfDocument document = new PdfDocument())
                        {
                            string al = "0.00";
                            string com = "0.00";
                            string ded = "0.00";
                            string empid = Convert.ToString(dataGridView1.Rows[row].Cells[1].Value);
                            //get allowance
                            cmd.CommandText = "select ISNULL(SUM(aAmount),0) 'al' from tbl_empAllowance where empId="+empid+"";
                            SqlDataAdapter adpt1 = new SqlDataAdapter(cmd);
                            DataTable dt1 = new DataTable();
                            adpt1.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                al = dt1.Rows[0]["al"].ToString();
                            }

                            //get commission
                            cmd.CommandText = "select ISNULL(SUM(cAmount),0) 'com' from tbl_empCommission where empId="+empid+"";
                            SqlDataAdapter adpt2 = new SqlDataAdapter(cmd);
                            DataTable dt2 = new DataTable();
                            adpt2.Fill(dt2);
                            if (dt2.Rows.Count > 0)
                            {
                                com = dt2.Rows[0]["com"].ToString();
                            }
                            //get deduction
                            cmd.CommandText = "select ISNULL(SUM(dAmount),0) 'ded' from tbl_empDeduction where empId=" + empid + "";
                            SqlDataAdapter adpt3 = new SqlDataAdapter(cmd);
                            DataTable dt3 = new DataTable();
                            adpt3.Fill(dt3);
                            if (dt3.Rows.Count > 0)
                            {
                                ded = dt3.Rows[0]["ded"].ToString();
                            }

                            //Adds page settings
                            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
                            document.PageSettings.Margins.All = 50;
                            //Adds a page to the document
                            PdfPage page = document.Pages.Add();
                            PdfGraphics graphics = page.Graphics;

                            //Loads the image from disk
                            PdfImage image = PdfImage.FromFile(path + @"\Resources\isdb-pdf-logo.png");
                            RectangleF bounds = new RectangleF(55, 10, 150, 55);
                            //Draws the image to the PDF page
                            page.Graphics.DrawImage(image, bounds);

                            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
                            bounds = new RectangleF(0, bounds.Bottom + 30, graphics.ClientSize.Width, 30);
                            //Draws a rectangle to place the heading in that region.
                            graphics.DrawRectangle(solidBrush, bounds);
                            //Creates a font for adding the heading in the page
                            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
                            //Creates a text element to add the invoice number
                            PdfTextElement element = new PdfTextElement("Employee Monthly Payslip", subHeadingFont);
                            element.Brush = PdfBrushes.White;

                            //Draws the heading on the page
                            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
                            string currentDate = "Pay Date " + DateTime.Now.ToString("MM/dd/yyyy");
                            //Measures the width of the text to place it in the correct location
                            SizeF textSize = subHeadingFont.MeasureString(currentDate);
                            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
                            //Draws the date by using DrawString method
                            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
                            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
                            
                            //Creates text elements to add the address and draw it to the page.
                            element = new PdfTextElement("Name: "+ dt.Rows[0]["name"].ToString() + Environment.NewLine + "Department: "+ dt.Rows[0]["dname"].ToString() + ""+Environment.NewLine+ "Salary Date : "+ DateTime.Now.ToString("MM/dd/yyyy") + "", timesRoman);
                            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 10));

                            //Create salary parts.
                            element = new PdfTextElement("\t\t Basic Salary: \t" + dt.Rows[0]["salary"].ToString() + Environment.NewLine + "\t\t Allowance: \t" + al + Environment.NewLine + "\t\t Commission: \t" + com + "" + Environment.NewLine + "\t\t Deduction : \t" + ded + Environment.NewLine+Environment.NewLine+ "\t\t Net Salary: \t" + dt.Rows[0]["netSalary"].ToString()+"", timesRoman);
                            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 50));

                            //Add the footer template at the bottom
                            PdfPageTemplateElement footer = AddFooter(document);
                            document.Template.Bottom = footer;


                            saveFileDialog1.Filter = "*.pdf|(Pdf File)";
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                //Saves and closes the document.
                                document.Save(saveFileDialog1.FileName + ".pdf");
                                MessageBox.Show("Payslip saved as pdf.");
                            }

                            document.Close(true);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Something wrong");
                }
                con.conClose();

            }
        }
        private static PdfPageTemplateElement AddFooter(PdfDocument doc)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);
            PdfFont pdfFont = new PdfStandardFont(PdfFontFamily.Helvetica, 7, PdfFontStyle.Italic);

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);

            //Draw some lines in the footer
            pen = new PdfPen(Color.DarkGray, 0.7f);
            footer.Graphics.DrawLine(pen, 0, 0, 100, 0);
            pen = new PdfPen(Color.DarkGray, 2f);
            footer.Graphics.DrawLine(pen, 0, footer.Height, footer.Width, footer.Height);

            //Draw multi-line text 
            string text = "Accountant Signature";
            footer.Graphics.DrawString(text, pdfFont, PdfBrushes.Black, new RectangleF(0, 20, doc.Pages[0].GetClientSize().Width, 30));

            return footer;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
