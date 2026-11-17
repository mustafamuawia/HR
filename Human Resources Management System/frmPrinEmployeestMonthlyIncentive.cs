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
    public partial class frmPrintEmployeesMonthlyIncentive : Form
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        List<EmployeesMonthlyIncentive> EmployeeMonthlyIncentive = new List<EmployeesMonthlyIncentive>();

        PrintDocument IncentivePrint = new PrintDocument();
        PaperSize PSize = new PaperSize("Just", 840, 1180);
       
        PrintPreviewDialog printPreview;

        int FieldsCount = 0;
        int PageNumber = 1;
        int CurrentPage = 1;

        double Total = 0;
        double MonthlyIncentiveTotal = 0;
        double SecondPartDeductionTotal = 0;

        int TotalPages = 0;

        //private void MyOwnSalariesPrintEvent(object sender, EventArgs e)
        //{
        //    PrintDialog pd = new PrintDialog();
        //    pd.Document = IncentivePrint;

        //    //printPreview.Document = RestaurantPrint;
            
        //    if (pd.ShowDialog() == DialogResult.OK)
        //    {
        //        IncentivePrint.Print();

        //    }
        //}
        private void MyOwnSalariesPrintEvent(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            //PrinterSettings psetting = new PrinterSettings
            //{
            //    FromPage = 2,
            //    ToPage = 2,
            //};
            pd.Document = IncentivePrint;

            pd.AllowCurrentPage = true;
            pd.AllowSomePages = true;
            //printPreview.Document = RestaurantPrint;
            pd.UseEXDialog = true;

            if (pd.ShowDialog() == DialogResult.OK)
            {

                if (pd.PrinterSettings.PrintRange == PrintRange.CurrentPage)
                {
                    pd.Document.PrintPage += new PrintPageEventHandler(SalariesSomePagesPrint_PrintPage);
                    //pd.Document.PrinterSettings = psetting;
                    pd.Document.PrintPage -= SalariesPrint_PrintPage;

                    pd.Document.Print();
                    pd.Document.PrintPage -= SalariesSomePagesPrint_PrintPage;
                    pd.Document.PrintPage += new PrintPageEventHandler(SalariesPrint_PrintPage);
                }
                else if (pd.PrinterSettings.PrintRange != PrintRange.CurrentPage)
                {

                    //pd.Document.PrintPage -= SalariesSomePagesPrint_PrintPage;
                    pd.Document.Print();
                    pd.Document.PrintPage -= SalariesPrint_PrintPage;
                }

            }
        }
        public frmPrintEmployeesMonthlyIncentive()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sqlSelectIncentive = string.Empty;
            SqlDataAdapter adGetIncentive;

            sqlSelectIncentive = @"SELECT db_owner.AllowancesFirst.رقم_الموظف, db_owner.AllowancesFirst.اسم_الموظف, 
            AllowancesFirst.حافز_نصف_شهري, (IsNull(DeductionsFirst.استقطاع_نصف_الشهر,0) +
            IsNull(DeductionsFirst.سلفيات_نصف_الشهر,0) + 
            IsNull(DeductionsFirst.مخالفات_نصف_الشهر,0)+
            IsNull(DeductionsFirst.غياب_حافز,0)+
            IsNull(DeductionsFirst.غياب_بعذر,0)) as استقطاع_نصف_الشهر
            FROM db_owner.AllowancesFirst INNER JOIN
            db_owner.DeductionsFirst ON db_owner.AllowancesFirst.رقم_الموظف = db_owner.DeductionsFirst.رقم_الموظف 
            where db_owner.AllowancesFirst.الشهر = '" + this.cbMonths.Text + "' "+
            @" and db_owner.DeductionsFirst.الشهر = '" + this.cbMonths.Text + "'  ";

            adGetIncentive = new SqlDataAdapter(sqlSelectIncentive, SqlConn);

            DataTable dtGetIncentive = new DataTable();
                adGetIncentive.Fill(dtGetIncentive);

                for (int index = 0; index < dtGetIncentive.Rows.Count; index++)
            {
                DataRow IncentiveRow = dtGetIncentive.Rows[index];
                EmployeesMonthlyIncentive EmpIncentive = new EmployeesMonthlyIncentive();

                EmpIncentive.EMPID = Convert.ToInt32(IncentiveRow[0]);

                EmpIncentive.EmployeeName = IncentiveRow[1].ToString();
                if (IncentiveRow[2] != DBNull.Value)
                    EmpIncentive.MonthlyIncentive = Convert.ToDouble(IncentiveRow[2]);
                else EmpIncentive.MonthlyIncentive = 0.00;
                if (IncentiveRow[3] != DBNull.Value)
                    EmpIncentive.SecondPartDeduction = Convert.ToDouble(IncentiveRow[3]);
                else EmpIncentive.SecondPartDeduction = 0.00;

                if (IncentiveRow[2] != DBNull.Value && IncentiveRow[3] != DBNull.Value)
                    EmpIncentive.NetMonthlyIncentive = (Convert.ToDouble(IncentiveRow[2])) - (Convert.ToDouble(IncentiveRow[3]));
                else if (IncentiveRow[2] != DBNull.Value && IncentiveRow[3] == DBNull.Value)
                    EmpIncentive.NetMonthlyIncentive = Convert.ToDouble(IncentiveRow[2]);
                else if (IncentiveRow[2] == DBNull.Value && IncentiveRow[3] != DBNull.Value)
                    EmpIncentive.NetMonthlyIncentive = 0 - Convert.ToDouble(IncentiveRow[3]);
                else EmpIncentive.NetMonthlyIncentive = 0.00;
                EmployeeMonthlyIncentive.Add(EmpIncentive);
            }
            printPreview = new PrintPreviewDialog();
            ToolStripButton Print = new ToolStripButton();
            Print.Text = "Print";

            if (EmployeeMonthlyIncentive.Count <= 15)
                TotalPages = 1;
            else if ((EmployeeMonthlyIncentive.Count % 15) == 0)
                TotalPages = (EmployeeMonthlyIncentive.Count / 15);
            else
                TotalPages = (EmployeeMonthlyIncentive.Count / 15) + 1;
            printPreview.Document = IncentivePrint;
            IncentivePrint.PrintPage += new PrintPageEventHandler(SalariesPrint_PrintPage);
            //Print.BackgroundImage = Properties.Resources.printericon;
            ((PrintPreviewControl)printPreview.Controls[0]).MouseWheel +=
                new MouseEventHandler(PrintPreviewControlMouseWheelEvent);

            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items[0].Dispose();
            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items.Insert(0, Print);

            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items[0].Click +=
                new EventHandler(MyOwnSalariesPrintEvent);
            printPreview.Document = IncentivePrint;
            ((Form)printPreview).RightToLeft = RightToLeft.Yes;
            ((Form)printPreview).RightToLeftLayout = true;
            ((Form)printPreview).WindowState = FormWindowState.Maximized;
            try
            {
                printPreview.ShowDialog();
                EmployeeMonthlyIncentive.Clear();
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
                MonthlyIncentiveTotal = 0;
                SecondPartDeductionTotal = 0;
                Total = 0;
                e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX + 550, Offset+ 20, strHeader);
                

                    string startdate = this.cbMonths.Text;
                    e.Graphics.DrawString(" حافز موظفي الفندق عن شهر " + startdate, new Font("Arial", 18, FontStyle.Bold),
                      new SolidBrush(Color.Black), startX + 560, 50 + Offset, strHeader);
                   
             //e.Graphics.DrawImage(newImage, 500, startY);
            }

          
            //strFormat.LineAlignment = StringAlignment.Center;

            Offset += 80;
            e.Graphics.DrawString("", new Font("Arial", 16, FontStyle.Bold),
                new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("الرقم".PadLeft(155),
                new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("اسم الموظف".PadLeft(135),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("الحافز".PadLeft(101),
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
          
            while (index < 15 && FieldsCount < EmployeeMonthlyIncentive.Count)
            {
                e.Graphics.DrawString((1+FieldsCount).ToString().PadLeft(205),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[FieldsCount].EmployeeName,
                     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX+930, startY + Offset, strFormat);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[FieldsCount].MonthlyIncentive.ToString("0,0.00", ArabicCulture).PadLeft(135),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[FieldsCount].SecondPartDeduction.ToString("0,0.00", ArabicCulture).PadLeft(110),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[FieldsCount].NetMonthlyIncentive.ToString("0,0.00", ArabicCulture).PadLeft(80),
                     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawLine(blackPen, point1, point2);
                point1.Y += 35;
                point2.Y += 35;
                Offset = Offset + 35;
                index++;
               
                MonthlyIncentiveTotal += Convert.ToDouble(EmployeeMonthlyIncentive[FieldsCount].MonthlyIncentive.ToString());
                SecondPartDeductionTotal += Convert.ToDouble(EmployeeMonthlyIncentive[FieldsCount].SecondPartDeduction.ToString());
                Total += Convert.ToDouble(EmployeeMonthlyIncentive[FieldsCount].NetMonthlyIncentive.ToString());
                
                FieldsCount++;
            }

            if (FieldsCount < EmployeeMonthlyIncentive.Count)
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
            e.Graphics.DrawString(MonthlyIncentiveTotal.ToString("0,0.00").PadLeft(135),
                              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(SecondPartDeductionTotal.ToString("0,0.00").PadLeft(110),
              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(Total.ToString("0,0.00").PadLeft(60),
                 new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            
            Offset = Offset + 20;

            Point pointUP = new Point(30, 130);
            Point pointDown = new Point(30, Offset+50);

            e.Graphics.DrawLine(blackPen, new Point(200, 130), new Point(200, Offset -5));
            e.Graphics.DrawLine(blackPen, new Point(350, 130), new Point(350, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(490, 130), new Point(490, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(610, 130), new Point(610, Offset +55));

            e.Graphics.DrawLine(blackPen, new Point(745, 130), new Point(745, Offset + 55));

            e.Graphics.DrawLine(blackPen, new Point(990, 130), new Point(990, Offset -5));

            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(1050, 130));
            e.Graphics.DrawLine(blackPen, new Point(30, Offset + 55), new Point(1050, Offset + 55));



            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));

          
         
        }
        private void frmPrintSalaries_Load(object sender, EventArgs e)
        {
            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            IncentivePrint.PrintPage += new PrintPageEventHandler(SalariesPrint_PrintPage);
            IncentivePrint.DefaultPageSettings.PaperSize = PSize;
            IncentivePrint.DefaultPageSettings.Landscape = true;
        }
        private void SalariesSomePagesPrint_PrintPage(Object sender, PrintPageEventArgs e)
        {
            //int index = 0;
            //if (CurrentPage ==1)
            //    index = 0;
            //else index = ;

            //FieldsCount = CurrentPage - 1;
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
            PageNumber = CurrentPage;

            e.Graphics.DrawString(("صفحة " + PageNumber + " من " + TotalPages).PadLeft(205),
             new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            e.Graphics.DrawString((DateTime.Today.ToString("d")).PadLeft(16), new Font("Arial", 12, FontStyle.Bold),
                new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            //PageNumber++;

            if (CurrentPage == 1)
            {
                Total = 0;
                MonthlyIncentiveTotal = 0;
                SecondPartDeductionTotal = 0;
                e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX + 550, Offset + 20, strHeader);


                string startdate = this.cbMonths.Text;
                e.Graphics.DrawString(" حافز موظفين الفندق عن شهر " + startdate, new Font("Arial", 18, FontStyle.Bold),
                  new SolidBrush(Color.Black), startX + 560, 50 + Offset, strHeader);

                //e.Graphics.DrawImage(newImage, 500, startY);
            }


            //strFormat.LineAlignment = StringAlignment.Center;

            Offset += 80;
            e.Graphics.DrawString("الرقم".PadLeft(155),
           new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("اسم الموظف".PadLeft(135),
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            e.Graphics.DrawString("المرتب".PadLeft(101),
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
            //e.Graphics.DrawString(Underline, new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);


            Pen blackPen = new Pen(Color.Black, 2);
            Point point1 = new Point(30, 215);
            Point point2 = new Point(1050, 215);
            e.Graphics.DrawLine(blackPen, new Point(30, 170), new Point(1050, 170));
            e.Graphics.DrawLine(blackPen, point1, point2);
            for (int i = 0; i < ((CurrentPage - 1) * 15) + 15; i++)
            {
                if (i >= EmployeeMonthlyIncentive.Count)
                    break;
                MonthlyIncentiveTotal += Convert.ToDouble(EmployeeMonthlyIncentive[i].MonthlyIncentive.ToString());
                SecondPartDeductionTotal += Convert.ToDouble(EmployeeMonthlyIncentive[i].SecondPartDeduction.ToString());

                Total += Convert.ToDouble(EmployeeMonthlyIncentive[i].NetMonthlyIncentive.ToString());
            }
            //FieldsCount = FieldsCount + 1;

            for (int index = ((CurrentPage - 1) * 15); index < ((CurrentPage - 1) * 15) + 15; index++)
            //while (index < (CurrentPage * 15 ) && index<EmployeeSalary.Count)
            {
                if (index >= EmployeeMonthlyIncentive.Count)
                    break;
                e.Graphics.DrawString((1 + index).ToString().PadLeft(205),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[index].EmployeeName,
                     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 930, startY + Offset, strFormat);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[index].MonthlyIncentive.ToString("0,0.00", ArabicCulture).PadLeft(135),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[index].SecondPartDeduction.ToString("0,0.00", ArabicCulture).PadLeft(110),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeMonthlyIncentive[index].NetMonthlyIncentive.ToString("0,0.00", ArabicCulture).PadLeft(80),
                     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawLine(blackPen, point1, point2);
                point1.Y += 35;
                point2.Y += 35;
                Offset = Offset + 35;
                //FieldsCount++;
            }




            Offset = Offset + 20;
            e.Graphics.DrawString("الجملـــــة",
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 900, startY + Offset, strFormat);
            e.Graphics.DrawString(MonthlyIncentiveTotal.ToString("0,0.00").PadLeft(135),
                              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(SecondPartDeductionTotal.ToString("0,0.00").PadLeft(110),
              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(Total.ToString("0,0.00").PadLeft(60),
                 new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.HasMorePages = false;
            //e.Graphics.DrawString("الجملـــــة",
            //    new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 900, startY + Offset, strFormat);
            //e.Graphics.DrawString(Total.ToString("0,0.00").PadLeft(35),
            //     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            FieldsCount = 0;
            PageNumber = 1;

            Total = 0;
            MonthlyIncentiveTotal = 0;
            SecondPartDeductionTotal = 0;
            Offset = Offset + 20;

            Point pointUP = new Point(30, 130);
            Point pointDown = new Point(30, Offset + 50);

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


            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));








            // Draw the bounding rectangle and a string for each 
            // StringFormat object.
            //     Rectangle displayRectangle =
            //new Rectangle(new Point(40, 40), new Size(80, 80));

            // Construct 2 new StringFormat objects



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
