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
    public partial class frmPrintSalariesSecond : Form
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        List<SalarySummary> EmployeeSalary = new List<SalarySummary>();

        PrintDocument SalariesPrint = new PrintDocument();
        PaperSize PSize = new PaperSize("Just", 827, 1169);

        PrintPreviewDialog printPreview;

        int FieldsCount = 0;
        int PageNumber = 1;
        int CurrentPage=1;

        double Total = 0;
        double AllowancesTotal = 0;
        double DeductionsTotal = 0;

        int TotalPages = 0;

        private void MyOwnSalariesPrintEvent(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            //PrinterSettings psetting = new PrinterSettings
            //{
            //    FromPage = 2,
            //    ToPage = 2,
            //};
            pd.Document = SalariesPrint;

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
        public frmPrintSalariesSecond()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adGetSalary = new SqlDataAdapter(@"SELECT db_owner.AllowancesSecond.رقم_الموظف, db_owner.AllowancesSecond.اسم_الموظف, 
            AllowancesSecond.الجملة, (IsNull(DeductionsSecond.استقطاع_اخر_الشهر,0) +
            IsNull(DeductionsSecond.سلفيات_اخر_الشهر,0) + 
            IsNull(DeductionsSecond.مخالفات_اخر_الشهر,0)+
            IsNull(DeductionsSecond.غياب_مرتب,0)) as استقطاع_اخر_الشهر
            FROM db_owner.AllowancesSecond INNER JOIN
            db_owner.DeductionsSecond ON db_owner.AllowancesSecond.رقم_الموظف = db_owner.DeductionsSecond.رقم_الموظف 
            where db_owner.AllowancesSecond.الشهر = '" + this.cbMonths.Text + "' " +
            @" and db_owner.DeductionsSecond.الشهر = '" + this.cbMonths.Text + "'  ", SqlConn);

            DataTable dtGetSalary = new DataTable();
            adGetSalary.Fill(dtGetSalary);
            for (int index = 0; index < dtGetSalary.Rows.Count; index++)
            {
                DataRow SalaryRow = dtGetSalary.Rows[index];
                SalarySummary EmpSalary = new SalarySummary();

                EmpSalary.EMPID = Convert.ToInt32(SalaryRow[0]);

                EmpSalary.EmployeeName = SalaryRow[1].ToString();
                if (SalaryRow[2] != DBNull.Value)
                    EmpSalary.AllowancesTotal = Convert.ToDouble(SalaryRow[2]);
                else EmpSalary.AllowancesTotal = 0.00;
                if (SalaryRow[3] != DBNull.Value)
                    EmpSalary.DeductionsTotal = Convert.ToDouble(SalaryRow[3]);
                else EmpSalary.DeductionsTotal = 0.00;

                if (SalaryRow[2] != DBNull.Value && SalaryRow[3] != DBNull.Value)
                    EmpSalary.NetSalary = Convert.ToDouble(SalaryRow[2]) - Convert.ToDouble(SalaryRow[3]);
                else EmpSalary.NetSalary = 0.00;
                EmployeeSalary.Add(EmpSalary);
            }
            printPreview = new PrintPreviewDialog();
            ToolStripButton Print = new ToolStripButton();
            Print.Text = "Print";

            if (EmployeeSalary.Count <= 15)
                TotalPages = 1;
            else if ((EmployeeSalary.Count % 15) == 0)
                TotalPages = (EmployeeSalary.Count / 15);
            else
                TotalPages = (EmployeeSalary.Count / 15) + 1;
            printPreview.Document = SalariesPrint;
            SalariesPrint.PrintPage += new PrintPageEventHandler(SalariesPrint_PrintPage);
            //Print.BackgroundImage = Properties.Resources.printericon;
            ((PrintPreviewControl)printPreview.Controls[0]).MouseWheel +=
                new MouseEventHandler(PrintPreviewControlMouseWheelEvent);
            
            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items[0].Dispose();
            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items.Insert(0, Print);

            ((ToolStrip)printPreview.Controls["toolstrip1"]).Items[0].Click +=
                new EventHandler(MyOwnSalariesPrintEvent);
            
            //SalariesPrint.PrintPage -= SalariesSomePagesPrint_PrintPage;
            ((Form)printPreview).RightToLeft = RightToLeft.Yes;
            ((Form)printPreview).RightToLeftLayout = true;
            ((Form)printPreview).WindowState = FormWindowState.Maximized;
            //try
            //{
                printPreview.ShowDialog();
                EmployeeSalary.Clear();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error:" + ex.Message.ToString());
            //}

        }


        private void PrintPreviewControlMouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ((PrintPreviewControl)sender).StartPage = ((PrintPreviewControl)sender).StartPage + 1;
                CurrentPage = ((PrintPreviewControl)sender).StartPage + 1;
            }
            else if (e.Delta < 0 && ((PrintPreviewControl)sender).StartPage > 0)
            {
                ((PrintPreviewControl)sender).StartPage = ((PrintPreviewControl)sender).StartPage - 1;
                CurrentPage = ((PrintPreviewControl)sender).StartPage + 1;
            }
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

            //e.Graphics.DrawString(("صفحة " + PageNumber + " من " + TotalPages).PadLeft(215),
            //    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            //e.Graphics.DrawString((DateTime.Today.ToString("d")).PadLeft(16), new Font("Arial", 12, FontStyle.Bold),
            //    new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            //PageNumber++;

            //if (FieldsCount == 0)
            //{
            //    Total = 0;
            //    e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
            //        new SolidBrush(Color.Black), startX+550, Offset+50,strHeader);

            //    e.Graphics.DrawString("مرتبات العاملين عن شهر", new Font("Arial", 18, FontStyle.Bold),
            //       new SolidBrush(Color.Black), startX + 500, 20 + Offset, strHeader);
            //    e.Graphics.DrawString("(" + (DateTime.Now.DayOfWeek.ToString()) + ")",
            //         new Font("Arial", 18, FontStyle.Bold),
            //      new SolidBrush(Color.Black), startX + 420,  Offset+50, strHeader);


            //    //e.Graphics.DrawImage(newImage, 500, startY);
            //}


            ////strFormat.LineAlignment = StringAlignment.Center;

            //Offset += 70;
            //e.Graphics.DrawString("", new Font("Arial", 16, FontStyle.Bold),
            //    new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString("رقم الموظف".PadLeft(160),
            //    new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString("اسم الموظف".PadLeft(138),
            //   new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString("جملة المرتب".PadLeft(100),
            //    new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString("جملة الاستقطاعات".PadLeft(70),
            //   new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString("صافي المرتب".PadLeft(40),
            //   new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString("التوقيع".PadLeft(15),
            //   new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 45;
            ////e.Graphics.DrawString(Underline, new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);



            //Pen blackPen = new Pen(Color.Black, 2);

            //Point point1 = new Point(30,205);
            //Point point2 = new Point(1100,205);
            //e.Graphics.DrawLine(blackPen, new Point(30, 160), new Point(1100, 160));
            //e.Graphics.DrawLine(blackPen, point1, point2);
            ////point1.Y += 50;
            ////point2.Y += 50;
            ////e.Graphics.DrawLine(blackPen, point1, point2);
            //while (index < 15 && FieldsCount < EmployeeSalary.Count)
            //{
            //    e.Graphics.DrawString((1+FieldsCount).ToString().PadLeft(210),
            //        new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            //    e.Graphics.DrawString(EmployeeSalary[FieldsCount].EmployeeName,
            //         new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX+900, startY + Offset, strFormat);
            //    e.Graphics.DrawString(EmployeeSalary[FieldsCount].AllowancesTotal.ToString(ArabicCulture).PadLeft(130),
            //        new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            //    e.Graphics.DrawString(EmployeeSalary[FieldsCount].DeductionsTotal.ToString(ArabicCulture).PadLeft(85),
            //       new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            //    e.Graphics.DrawString(EmployeeSalary[FieldsCount].NetSalary.ToString(ArabicCulture).PadLeft(50),
            //         new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            //    e.Graphics.DrawLine(blackPen, point1, point2);
            //    point1.Y += 35;
            //    point2.Y += 35;
            //    Offset = Offset + 35;
            //    index++;
            //    Total += Convert.ToDouble(EmployeeSalary[FieldsCount].NetSalary.ToString());
            //    FieldsCount++;
            //}

            //if (FieldsCount < EmployeeSalary.Count)
            //{
            //    e.HasMorePages = true;
            //}
            //else
            //{
            //    e.HasMorePages = false;
            //    FieldsCount = 0;
            //    PageNumber = 1;
            //    index = 0;
            //}
            //Offset = Offset + 20;
            //e.Graphics.DrawString("الجملـــــة",  new Font("Arial", 18, FontStyle.Bold),
            //  new SolidBrush(Color.Black), startX, startY + Offset);
            //e.Graphics.DrawString(Total.ToString("0,0.00"), new Font("Arial", 16, FontStyle.Bold),
            //      new SolidBrush(Color.Black), startX+230, startY + Offset,Numbers);
            //Offset = Offset + 20;

            //Point pointUP = new Point(30, 120);
            //Point pointDown = new Point(30, Offset+50);

            //e.Graphics.DrawLine(blackPen, new Point(200, 130), new Point(200, Offset + 55));
            //e.Graphics.DrawLine(blackPen, new Point(350, 130), new Point(350, Offset + 55));
            //e.Graphics.DrawLine(blackPen, new Point(550, 130), new Point(550, Offset + 55));

            //e.Graphics.DrawLine(blackPen, new Point(730, 130), new Point(730, Offset + 55));

            //e.Graphics.DrawLine(blackPen, new Point(990, 130), new Point(990, Offset + 55));

            //e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(1050, 130));
            //e.Graphics.DrawLine(blackPen, new Point(30, Offset + 55), new Point(1050, Offset + 55));



            //e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            //e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));

            e.Graphics.DrawString(("صفحة " + PageNumber + " من " + TotalPages).PadLeft(205),
             new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            e.Graphics.DrawString((DateTime.Today.ToString("d")).PadLeft(16), new Font("Arial", 12, FontStyle.Bold),
                new SolidBrush(Color.Black), 10, 10 + Offset, Numbers);
            PageNumber++;

            if (FieldsCount == 0)
            {
                Total = 0;
                DeductionsTotal = 0;
                AllowancesTotal = 0;
                e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX + 550, Offset + 20, strHeader);


                string startdate = this.cbMonths.Text;
                e.Graphics.DrawString(" مرتب الموظفين المؤقتين بالفندق عن شهر " + startdate, new Font("Arial", 18, FontStyle.Bold),
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
            //e.Graphics.DrawLine(blackPen, point1, point2);
            //point1.Y += 50;
            //point2.Y += 50;
            //e.Graphics.DrawLine(blackPen, point1, point2);
            while (index < 15 && FieldsCount < EmployeeSalary.Count)
            {
                e.Graphics.DrawString("", new Font("Arial", 16, FontStyle.Bold),
             new SolidBrush(Color.Black), startX, startY + Offset);
                e.Graphics.DrawString((1 + FieldsCount).ToString().PadLeft(205),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].EmployeeName,
                     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 930, startY + Offset, strFormat);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].AllowancesTotal.ToString("0,0.00", ArabicCulture).PadLeft(135),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].DeductionsTotal.ToString("0,0.00", ArabicCulture).PadLeft(110),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[FieldsCount].NetSalary.ToString("0,0.00", ArabicCulture).PadLeft(80),
                     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawLine(blackPen, point1, point2);
                //e.Graphics.DrawString((1 + FieldsCount).ToString().PadLeft(205),
                //    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                //e.Graphics.DrawString(EmployeeSalary[FieldsCount].EmployeeName,
                //     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 900, startY + Offset, strFormat);
                //e.Graphics.DrawString(EmployeeSalary[FieldsCount].AllowancesTotal.ToString("n2", ArabicCulture).PadLeft(130),
                //    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                //e.Graphics.DrawString(EmployeeSalary[FieldsCount].DeductionsTotal.ToString("n2", ArabicCulture).PadLeft(85),
                //   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                //e.Graphics.DrawString(EmployeeSalary[FieldsCount].NetSalary.ToString("n2", ArabicCulture).PadLeft(50),
                //     new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawLine(blackPen, point1, point2);
                point1.Y += 35;
                point2.Y += 35;
                Offset = Offset + 35;
                index++;

                AllowancesTotal += Convert.ToDouble(EmployeeSalary[FieldsCount].AllowancesTotal.ToString());
                DeductionsTotal += Convert.ToDouble(EmployeeSalary[FieldsCount].DeductionsTotal.ToString());

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
                FieldsCount = 0;
            }
            Offset = Offset + 20;
            e.Graphics.DrawString("الجملـــــة",
               new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 900, startY + Offset, strFormat);
            e.Graphics.DrawString(AllowancesTotal.ToString("0,0.00").PadLeft(135),
                              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(DeductionsTotal.ToString("0,0.00").PadLeft(110),
              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(Total.ToString("0,0.00").PadLeft(60),
                 new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);

            //e.Graphics.DrawString("الجملـــــة",
            //    new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 900, startY + Offset, strFormat);
            //e.Graphics.DrawString(Total.ToString("0,0.00").PadLeft(35),
            //     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);

            Offset = Offset + 20;

            Point pointUP = new Point(30, 130);
            Point pointDown = new Point(30, Offset + 50);

            e.Graphics.DrawLine(blackPen, new Point(200, 130), new Point(200, Offset - 5));
            e.Graphics.DrawLine(blackPen, new Point(350, 130), new Point(350, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(490, 130), new Point(490, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(610, 130), new Point(610, Offset + 55));

            e.Graphics.DrawLine(blackPen, new Point(740, 130), new Point(740, Offset + 55));

            e.Graphics.DrawLine(blackPen, new Point(990, 130), new Point(990, Offset - 5));

            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(1050, 130));
            e.Graphics.DrawLine(blackPen, new Point(30, Offset + 55), new Point(1050, Offset + 55));



            e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));


            //e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            //e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));








            // Draw the bounding rectangle and a string for each 
            // StringFormat object.
            //     Rectangle displayRectangle =
            //new Rectangle(new Point(40, 40), new Size(80, 80));

            // Construct 2 new StringFormat objects



        }
        private void frmPrintSalariesSecond_Load(object sender, EventArgs e)
        {
            CultureInfo ArabicCulture = CultureInfo.CreateSpecificCulture("ar-EG");
            this.cbMonths.Text = ArabicCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            
            SalariesPrint.DefaultPageSettings.PaperSize = PSize;
            SalariesPrint.DefaultPageSettings.Landscape = true;
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
                DeductionsTotal = 0;
                AllowancesTotal = 0;
                e.Graphics.DrawString("فندق قصر ابشر", new Font("Arial", 18, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX + 550, Offset + 20, strHeader);


                string startdate = this.cbMonths.Text;
                e.Graphics.DrawString(" مرتب الموظفين المؤقتين بالفندق عن شهر " + startdate, new Font("Arial", 18, FontStyle.Bold),
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
                if (i >= EmployeeSalary.Count)
                    break;
                AllowancesTotal += Convert.ToDouble(EmployeeSalary[i].AllowancesTotal.ToString());
                DeductionsTotal += Convert.ToDouble(EmployeeSalary[i].DeductionsTotal.ToString());

                Total += Convert.ToDouble(EmployeeSalary[i].NetSalary.ToString());
            }
            //FieldsCount = FieldsCount + 1;

            for (int index=((CurrentPage-1) * 15);index<((CurrentPage-1) * 15)+15;index++)
            //while (index < (CurrentPage * 15 ) && index<EmployeeSalary.Count)
            {
                if (index >= EmployeeSalary.Count)
                    break;
                e.Graphics.DrawString((1 + index).ToString().PadLeft(205),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[index].EmployeeName,
                     new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Black), startX + 930, startY + Offset, strFormat);
                e.Graphics.DrawString(EmployeeSalary[index].AllowancesTotal.ToString("0,0.00", ArabicCulture).PadLeft(135),
                    new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[index].DeductionsTotal.ToString("0,0.00", ArabicCulture).PadLeft(110),
                   new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
                e.Graphics.DrawString(EmployeeSalary[index].NetSalary.ToString("0,0.00", ArabicCulture).PadLeft(80),
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
            e.Graphics.DrawString(AllowancesTotal.ToString("0,0.00").PadLeft(135),
                              new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset, Numbers);
            e.Graphics.DrawString(DeductionsTotal.ToString("0,0.00").PadLeft(110),
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
            DeductionsTotal = 0;
            AllowancesTotal = 0;
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


            //e.Graphics.DrawLine(blackPen, new Point(30, 130), new Point(30, Offset + 55));
            //e.Graphics.DrawLine(blackPen, new Point(1050, 130), new Point(1050, Offset + 55));








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