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
    public partial class frmDialyworkersSalaries : Form
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        List<DialyWorkersSalarySummary> EmployeeSalary = new List<DialyWorkersSalarySummary>();

        PrintDocument SalariesPrint = new PrintDocument();
        PaperSize PSize = new PaperSize("Just",827 ,1169);
       
        PrintPreviewDialog printPreview;

        int FieldsCount = 0;
        int PageNumber = 1;
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
        public frmDialyworkersSalaries()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adGetSalary = new SqlDataAdapter(@"SELECT  رقم_العامل, اسم_العامل, الأجر, الخصم, الجملة
            from db_owner.DialyWorkersSalaries where الشهر = '" +this.cbMonths.Text+"'", SqlConn);
            DataTable dtGetSalary = new DataTable();
            adGetSalary.Fill(dtGetSalary);
            for (int index = 0; index < dtGetSalary.Rows.Count; index++)
            {
                DataRow SalaryRow = dtGetSalary.Rows[index];
                DialyWorkersSalarySummary EmpSalary = new DialyWorkersSalarySummary();

                EmpSalary.EMPID = Convert.ToInt32(SalaryRow[0]);

                EmpSalary.EmployeeName = SalaryRow[1].ToString();
                if (SalaryRow[2] != DBNull.Value)
                    EmpSalary.Salary = Convert.ToDouble(SalaryRow[2])/3;
                else EmpSalary.Salary = 0.00;
                if (SalaryRow[3] != DBNull.Value)
                    EmpSalary.Deduction = Convert.ToDouble(SalaryRow[3])/3;
                else EmpSalary.Deduction = 0.00;

                if (SalaryRow[2] != DBNull.Value && SalaryRow[3] != DBNull.Value)
                    EmpSalary.NetSalary = (Convert.ToDouble(SalaryRow[2])/3) - (Convert.ToDouble(SalaryRow[3])/3);
                else EmpSalary.NetSalary = 0.00;
                EmployeeSalary.Add(EmpSalary);
            }
            printPreview = new PrintPreviewDialog();
            ToolStripButton Print = new ToolStripButton();
            Print.Text = "Print";

            TotalPages = (EmployeeSalary.Count / 15);
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
            StringFormat Numbers = new StringFormat();
            strFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            Numbers.SetDigitSubstitution(ArabicCulture.LCID, StringDigitSubstitute.National);

            e.Graphics.DrawString(("صفحة " + PageNumber + " من " + TotalPages).PadLeft(215),
                new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            e.Graphics.DrawString((DateTime.Today.ToString("d")).PadLeft(16), new Font("Arial", 12, FontStyle.Bold),
                new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            PageNumber++;
            
            if (FieldsCount == 0)
            {
                Total = 0;
                e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX+550, Offset+50,strHeader);
                
                e.Graphics.DrawString("مرتبات العاملين عن شهر", new Font("Arial", 18, FontStyle.Bold),
                   new SolidBrush(Color.Black), startX + 500, 20 + Offset, strHeader);
                e.Graphics.DrawString("(" + (DateTime.Now.DayOfWeek.ToString()) + ")",
                     new Font("Arial", 18, FontStyle.Bold),
                  new SolidBrush(Color.Black), startX + 420,  Offset+50, strHeader);
               

                //e.Graphics.DrawImage(newImage, 500, startY);
            }

          
            //strFormat.LineAlignment = StringAlignment.Center;

            Offset += 70;
            e.Graphics.DrawString("", new Font("Arial", 16, FontStyle.Bold),
                new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("رقم الموظف".PadLeft(160),
                new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("اسم الموظف".PadLeft(138),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("جملة المرتب".PadLeft(100),
                new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("جملة الاستقطاعات".PadLeft(70),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("صافي المرتب".PadLeft(40),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("التوقيع".PadLeft(15),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 45;
            //e.Graphics.DrawString(Underline, new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);



            Pen blackPen = new Pen(Color.Black, 2);
           
            Point point1 = new Point(30,205);
            Point point2 = new Point(1100,205);
            e.Graphics.DrawLine(blackPen, new Point(30, 160), new Point(1100, 160));
            e.Graphics.DrawLine(blackPen, point1, point2);
            //point1.Y += 50;
            //point2.Y += 50;
            //e.Graphics.DrawLine(blackPen, point1, point2);
            while (index < 15 && FieldsCount < EmployeeSalary.Count)
            {
                e.Graphics.DrawString((1+FieldsCount).ToString().PadLeft(210),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].EmployeeName,
                     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX+900, startY + Offset, strFormat);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].Salary.ToString("n2",ArabicCulture).PadLeft(130),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].Deduction.ToString("n2", ArabicCulture).PadLeft(85),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].NetSalary.ToString("n2", ArabicCulture).PadLeft(50),
                     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawLine(blackPen, point1, point2);
                point1.Y += 35;
                point2.Y += 35;
                Offset = Offset + 35;
                index++;
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
            e.Graphics.DrawString("الجملـــــة",  new Font("Arial", 18, FontStyle.Bold),
                new SolidBrush(Color.Black), startX+750, startY + Offset, strFormat);
            e.Graphics.DrawString(Total.ToString("0.00"), new Font("Arial", 16, FontStyle.Bold),
                  new SolidBrush(Color.Black), startX+230, startY + Offset,Numbers);
            Offset = Offset + 20;
            
            Point pointUP = new Point(30, 120);
            Point pointDown = new Point(30, Offset+50);

            e.Graphics.DrawLine(blackPen, new Point(200, 120), new Point(200, Offset-5 ));
            e.Graphics.DrawLine(blackPen, new Point(350, 120), new Point(350, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(550, 120), new Point(550, Offset-5 ));
            
            e.Graphics.DrawLine(blackPen, new Point(730, 120), new Point(730, Offset-5));

            e.Graphics.DrawLine(blackPen, new Point(990, 120), new Point(990, Offset-5));

            e.Graphics.DrawLine(blackPen, new Point(30, 120), new Point(1100, 120));
            e.Graphics.DrawLine(blackPen, new Point(30, Offset + 55), new Point(1100, Offset + 55));



            e.Graphics.DrawLine(blackPen, new Point(30, 120), new Point(30, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(1100, 120), new Point(1100, Offset + 55));
         

          


            
          
            // Draw the bounding rectangle and a string for each 
            // StringFormat object.
       //     Rectangle displayRectangle =
       //new Rectangle(new Point(40, 40), new Size(80, 80));

            // Construct 2 new StringFormat objects


          
        }
        private void frmPrintSalaries_Load(object sender, EventArgs e)
        {
            this.cbMonths.Text = this.cbMonths.Items[0].ToString();
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
