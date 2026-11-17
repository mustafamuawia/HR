using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;

namespace HR_MS
{
    public partial class frmPrintDialyworkersSalaries : Form
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        List<DialyWorkersSalarySummary> EmployeeSalary = new List<DialyWorkersSalarySummary>();

        PrintDocument SalariesPrint = new PrintDocument();
        PaperSize PSize = new PaperSize("Just", 840, 1180);
       
        PrintPreviewDialog printPreview;

        int FieldsCount = 0;
        int PageNumber = 1;

        double SalariesTotal = 0;
        double DeductionsTotal = 0;
        double Total = 0;

        int TotalPages = 0;

        private void MyOwnSalariesPrintEvent(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = SalariesPrint;

            //printPreview.Document = RestaurantPrint;
            
            if (pd.ShowDialog() == DialogResult.OK)
            {
                SalariesPrint.Print();

            }
        }
        public frmPrintDialyworkersSalaries()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int MonthDays = 0;
            int Days = 0;
            string sqlSelectSalary = string.Empty;
            SqlDataAdapter adGetSalary;
            if (rbFirst.Checked)
            {
                sqlSelectSalary = @"SELECT   رقم_العامل, اسم_العامل, الأجر, خصم_أول_الشهر, غياب_اول_الشهر
                from db_owner.DialyWorkersSalaries where الشهر = '" + this.cbMonths.Text + "'";
                Days = 10;
               //adGetSalary = 
            }
            else if (rbSecond.Checked)
            {
                sqlSelectSalary = @"SELECT   رقم_العامل, اسم_العامل, الأجر, خصم_منتصف_الشهر, غياب_منتصف_الشهر
                from db_owner.DialyWorkersSalaries where الشهر = '" + this.cbMonths.Text + "'";
                Days = 10;
            }
            else if (rbThird.Checked)
            {
                sqlSelectSalary = @"SELECT   رقم_العامل, اسم_العامل, الأجر, خصم_آخر_الشهر, غياب_اخر_الشهر
                from db_owner.DialyWorkersSalaries where الشهر = '" + this.cbMonths.Text + "'";
                MonthDays = DateTime.DaysInMonth(2013, cbMonths.Items.IndexOf(cbMonths.Text) + 1);
                Days = MonthDays - 20;
            }
                adGetSalary = new SqlDataAdapter(sqlSelectSalary, SqlConn);

                DataTable dtGetSalary = new DataTable();
                adGetSalary.Fill(dtGetSalary);
            
            for (int index = 0; index < dtGetSalary.Rows.Count; index++)
            {
                DataRow SalaryRow = dtGetSalary.Rows[index];
                DialyWorkersSalarySummary EmpSalary = new DialyWorkersSalarySummary();

                EmpSalary.EMPID = Convert.ToInt32(SalaryRow[0]);

                EmpSalary.EmployeeName = SalaryRow[1].ToString();
                if (SalaryRow[2] != DBNull.Value)
                    EmpSalary.Salary = Convert.ToDouble(SalaryRow[2])*Days;
                else EmpSalary.Salary = 0.00;
                if (SalaryRow[3] != DBNull.Value)
                    EmpSalary.Deduction = Convert.ToDouble(SalaryRow[3]);
                else EmpSalary.Deduction = 0.00;
                if (SalaryRow[4] != DBNull.Value)
                    EmpSalary.AttendanceDeduction = Convert.ToDouble(SalaryRow[4]);
                else EmpSalary.AttendanceDeduction = 0.00;

                //if (SalaryRow[2] != DBNull.Value && SalaryRow[3] != DBNull.Value
                //    && SalaryRow[4] != DBNull.Value)
                //    EmpSalary.NetSalary = (Convert.ToDouble(SalaryRow[2]) * Days) - 
                //        (Convert.ToDouble(SalaryRow[3])) -
                //        (Convert.ToDouble(SalaryRow[4]));
                //else if (SalaryRow[2] != DBNull.Value && SalaryRow[3] == DBNull.Value
                //    && SalaryRow[4] == DBNull.Value)
                //    EmpSalary.NetSalary = Convert.ToDouble(SalaryRow[2]) * Days;
                //else if (SalaryRow[2] == DBNull.Value && SalaryRow[3] != DBNull.Value)
                //    EmpSalary.NetSalary = 0 - Convert.ToDouble(SalaryRow[3]) * Days;
                //else if (SalaryRow[2] == DBNull.Value && SalaryRow[3] != DBNull.Value
                //    && SalaryRow[4] == DBNull.Value)
                //EmpSalary.NetSalary = 0 - Convert.ToDouble(SalaryRow[3]) * Days;
                //else 
                EmpSalary.NetSalary = EmpSalary.Salary - (EmpSalary.Deduction + EmpSalary.AttendanceDeduction);
                EmployeeSalary.Add(EmpSalary);
            }
            printPreview = new PrintPreviewDialog();
            ToolStripButton Print = new ToolStripButton();
            Print.Text = "Print";

            TotalPages = (EmployeeSalary.Count / 15)+1;
            //Print.BackgroundImage = Properties.Resources.printericon;
            ((PrintPreviewControl)printPreview.Controls[0]).MouseWheel +=
                new MouseEventHandler(PrintPreviewControlMouseWheelEvent);

            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items[0].Dispose();
            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items.Insert(0, Print);

            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items[0].Click +=
                new EventHandler(MyOwnSalariesPrintEvent);
            printPreview.Document = SalariesPrint;
            ((Form)printPreview).RightToLeft = RightToLeft.Yes;
            ((Form)printPreview).RightToLeftLayout = true;
            ((Form)printPreview).WindowState = FormWindowState.Maximized;
            try
            {
                printPreview.ShowDialog();
                EmployeeSalary.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString());
            }

        }


        private void PrintPreviewControlMouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ((PrintPreviewControl)sender).StartPage = ((PrintPreviewControl)sender).StartPage + 1;
            else if (e.Delta < 0 && ((PrintPreviewControl)sender).StartPage > 0)
                ((PrintPreviewControl)sender).StartPage = ((PrintPreviewControl)sender).StartPage - 1;
        }

        private void SalariesPrint_PrintPage(Object sender, PrintPageEventArgs e)
        {
            int index = 0;
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);
            float fontHeight = font.GetHeight();
            CultureInfo ArabicCulture = CultureInfo.CreateSpecificCulture("ar-EG");
            int startX = 40;
            int startY = 40;
            int Offset = 20;
            //Image newImage = Image.FromFile("AbbasherLogo.png");

            StringFormat strFormat = new StringFormat();
            StringFormat strHeader = new StringFormat();
            strHeader.Alignment = StringAlignment.Center;
            //strFormat.Alignment = StringAlignment.Far;
            StringFormat Number = new StringFormat();
            strFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            Number.SetDigitSubstitution(ArabicCulture.LCID, StringDigitSubstitute.National);
            Number.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            StringFormat Numbers = new StringFormat();
            strFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            Numbers.SetDigitSubstitution(ArabicCulture.LCID, StringDigitSubstitute.National);

            e.Graphics.DrawString(("صفحة " + PageNumber + " من " + TotalPages).PadLeft(205),
                new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            e.Graphics.DrawString((DateTime.Today.ToString("d")).PadLeft(16), new Font("Arial", 12, FontStyle.Bold),
                new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            PageNumber++;
            
            if (FieldsCount == 0)
            {
                SalariesTotal = 0;
                DeductionsTotal = 0;
                Total = 0;
                e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX + 550, Offset+ 20, strHeader);
                e.Graphics.DrawString("أجر عمال اليومية العاملين بالفندق عن  الفترة من", new Font("Arial", 18, FontStyle.Bold),
                      new SolidBrush(Color.Black), startX + 560, 50 + Offset, strHeader);

                if (rbFirst.Checked)
                {
                    string startdate = @"1 / " + (this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString().TrimStart(new Char[] { '0' }) + " / 2013 ";
                    string to = " وحتى ";
                    string enddate = @"10 / " + (this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString().TrimStart(new Char[] { '0' }) + " / 2013 ";
                    e.Graphics.DrawString(startdate+to+enddate,
                         new Font("Arial", 12, FontStyle.Bold),
                      new SolidBrush(Color.Black), startX + 680, 30 + Offset + 50,Number);

                 }
                else if (rbSecond.Checked)
                {
                    string startdate = @"11 / " + (this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString().TrimStart(new Char[] { '0' }) + " / 2013 ";
                    string to = " وحتى ";
                    string enddate = @"20 / " + (this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString().TrimStart(new Char[] { '0' }) + " / 2013 ";
                    e.Graphics.DrawString(startdate + to + enddate,
                         new Font("Arial", 12, FontStyle.Bold),
                      new SolidBrush(Color.Black), startX + 680, 30 + Offset + 50, Number);
                }
                else if (rbThird.Checked)
                {
                    string startdate = @"21 / " + (this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString().TrimStart(new Char[] { '0' }) + " / 2013 ";
                    string to = " وحتى ";
                    string enddate = DateTime.DaysInMonth(DateTime.Now.Year, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString()+" / " + (this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1).ToString().TrimStart(new Char[] { '0' }) + " / 2013 ";
                    e.Graphics.DrawString(startdate + to + enddate,
                         new Font("Arial", 12, FontStyle.Bold),
                      new SolidBrush(Color.Black), startX + 680, 30 + Offset + 50, Number);
                }
                //e.Graphics.DrawImage(newImage, 500, startY);
            }

          
            //strFormat.LineAlignment = StringAlignment.Center;

            Offset += 80;
            e.Graphics.DrawString("", new Font("Arial", 16, FontStyle.Bold),
            new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("الرقم".PadLeft(155),
                new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("اسم العامل".PadLeft(135),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("الأجر".PadLeft(101),
                new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("الاستقطاع".PadLeft(85),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("الصافي".PadLeft(60),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("التوقيع".PadLeft(40),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("ملاحظـــات".PadLeft(15),
            new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
         
            Offset = Offset + 45;



            Pen blackPen = new Pen(Color.Black, 2);
           
            Point point1 = new Point(30,215);
            Point point2 = new Point(1050,215);
            e.Graphics.DrawLine(blackPen, new Point(30, 170), new Point(1050, 170));
            while (index < 15 && FieldsCount < EmployeeSalary.Count)
            {
                e.Graphics.DrawString((1 + FieldsCount).ToString().PadLeft(205),
                 new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].EmployeeName,
                     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 930, startY + Offset, strFormat);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].Salary.ToString("0,0.00", ArabicCulture).PadLeft(135),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString((EmployeeSalary[FieldsCount].Deduction+EmployeeSalary[FieldsCount].AttendanceDeduction).ToString("0,0.00", ArabicCulture).PadLeft(110)
                    ,new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].NetSalary.ToString("0,0.00", ArabicCulture).PadLeft(80),
                     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawLine(blackPen, point1, point2);
                point1.Y += 35;
                point2.Y += 35;
                Offset = Offset + 35;
                index++;
                SalariesTotal += Convert.ToDouble(EmployeeSalary[FieldsCount].Salary.ToString());
                DeductionsTotal += Convert.ToDouble(EmployeeSalary[FieldsCount].Deduction.ToString())
                    + Convert.ToDouble(EmployeeSalary[FieldsCount].AttendanceDeduction.ToString());
                Total += Convert.ToDouble(EmployeeSalary[FieldsCount].NetSalary.ToString());
                FieldsCount++;
            }

            if (FieldsCount < EmployeeSalary.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                FieldsCount = 0;
                PageNumber = 1;
                index = 0;
            }
            Offset = Offset + 20;
            e.Graphics.DrawString("الجملـــــة",
                new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 900, startY + Offset, strFormat);
            e.Graphics.DrawString(SalariesTotal.ToString("0,0.00").PadLeft(135),
                              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(DeductionsTotal.ToString("0,0.00").PadLeft(110),
              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(Total.ToString("0,0.00").PadLeft(60),
                 new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            
            Offset = Offset + 20;

            Point pointUP = new Point(30, 130);
            Point pointDown = new Point(30, Offset+50);

            e.Graphics.DrawLine(blackPen, new Point(200, 130), new Point(200, Offset - 5));
            e.Graphics.DrawLine(blackPen, new Point(350, 130), new Point(350, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(490, 130), new Point(490, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(610, 130), new Point(610, Offset + 55));

            e.Graphics.DrawLine(blackPen, new Point(745, 130), new Point(745, Offset + 55));

            e.Graphics.DrawLine(blackPen, new Point(990, 130), new Point(990, Offset - 5));

            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(1050, 130));
            e.Graphics.DrawLine(blackPen, new Point(30, Offset + 55), new Point(1050, Offset + 55));



            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));

        }
        private void frmPrintSalaries_Load(object sender, EventArgs e)
        {
            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            SalariesPrint.PrintPage += new PrintPageEventHandler(SalariesPrint_PrintPage);
            SalariesPrint.DefaultPageSettings.PaperSize = PSize;
            SalariesPrint.DefaultPageSettings.Landscape = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
