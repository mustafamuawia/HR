using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace HR_MS
{
    public partial class frmEmployeesDeductionsFirst : Adjust
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesDeductionsBind = new BindingSource();
        SqlCommandBuilder commandBuilder;
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmEmployeesDeductionsFirst()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetData(string selectCommand)
        {
            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            string sqlstringGetDialyEmoloyee = @"select  EmpID, EmpName from
            db_owner.Employees where EmpInsurance='1'";

            SqlDataAdapter daGetDialyEmoloyee = new SqlDataAdapter(sqlstringGetDialyEmoloyee, SqlConn);
            DataTable dtGetDialyEmoloyee = new DataTable();


            try
            {
                daGetDialyEmoloyee.Fill(dtGetDialyEmoloyee);
                for (int index = 1; index <= 12; index++)
                {
                    for (int mindex = 0; mindex < dtGetDialyEmoloyee.Rows.Count; mindex++)
                    {

                        string SqlString = @"INSERT INTO db_owner.DeductionsFirst (رقم_الموظف, اسم_الموظف, الشهر)
                        select '" + dtGetDialyEmoloyee.Rows[mindex]["EmpID"] + "'," +
                        @"'" + dtGetDialyEmoloyee.Rows[mindex]["EmpName"] + "'," +
                        @"'" + ArabicEgypt.DateTimeFormat.GetMonthName(index) + "' " +
                        @"where NOT EXISTS (SELECT * FROM db_owner.DeductionsFirst EmID " +
                        @"WHERE EmID.رقم_الموظف = '" + dtGetDialyEmoloyee.Rows[mindex]["EmpID"] + "' " +
                        @"and EmID.الشهر = '" + ArabicEgypt.DateTimeFormat.GetMonthName(index) + "')";


                        SqlConn.Open();
                        try
                        {
                            SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);

                            SqlComm.ExecuteNonQuery();

                            SqlComm.Dispose();
                            SqlComm = null;
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {
                            SqlConn.Close();
                        }
                    }
                }

                // Create a new data adapter based on the specified query.
                daGetEmp = new SqlDataAdapter(selectCommand, SqlConn);
                dtGetEmp = new DataTable();
                // Create a command builder to generate SQL update, insert, and 
                // delete commands based on selectCommand. These are used to 
                // update the database.
                commandBuilder = new SqlCommandBuilder(daGetEmp);

                // Populate a new data table and bind it to the BindingSource.
                daGetEmp.Fill(dtGetEmp);
                EmployeesDeductionsBind.DataSource = dtGetEmp;
                dgvDeductions.DataSource = EmployeesDeductionsBind;
                // Resize the DataGridView columns to fit the newly loaded content.
                //  dgvSalaries.AutoResizeColumns(
                //        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

                int Year = DateTime.Now.Year;
                int LastYear = Year - 1;
                int NextYear = Year + 1;
             

                int Month = Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1;
                int NextMonth = 0;
                int PreviousMonth = 0;

                //if (Month == 1)
                //    ;
                
                int MonthDays = DateTime.DaysInMonth(Year, cbMonths.Items.IndexOf(cbMonths.Text) + 1);
                for (int i = 0; i < dgvDeductions.Rows.Count; i++)
                {
                    SqlCommand sqlSetAbbsanceDeduction = new SqlCommand(@"update db_owner.DeductionsFirst set غياب_مرتب 
            =((SELECT COUNT(*) FROM db_owner.attendanceFirst where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                 @"and التاريخ between '" + new DateTime(Year, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 16) + "'" +
                    @"and  '" + new DateTime(Year, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), MonthDays) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select الجملة from db_owner.allowancesFirst
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/15)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'" +
                 @"update db_owner.DeductionsFirst set غياب_حافز_اداء 
            =((SELECT COUNT(*) FROM db_owner.attendanceFirst where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                 @"and التاريخ between '" + new DateTime(Year, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 16) + "'" +
                    @"and  '" + new DateTime(Year, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), MonthDays) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select حافز_اداء from db_owner.allowancesFirst
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/15)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'" +
                     @"update db_owner.DeductionsFirst set غياب_حافز 
            =((SELECT COUNT(*) FROM db_owner.attendanceFirst where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                 @"and التاريخ between '" + new DateTime(Year, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 1) + "'" +
                    @"and  '" + new DateTime(Year, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), 15) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select حافز_نصف_شهري from db_owner.allowancesFirst
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/15)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'" +
                 @"update db_owner.DeductionsFirst set غياب_بعذر 
            =((SELECT COUNT(*) FROM db_owner.attendanceFirst where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                  @"and التاريخ between '" + new DateTime(Year, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 15) + "'" +
                    @"and  '" + new DateTime(Year, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), MonthDays) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select حافز_نصف_شهري from db_owner.allowancesFirst
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/30)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'", SqlConn);
                    try
                    {
                        SqlConn.Open();
                        sqlSetAbbsanceDeduction.ExecuteNonQuery();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        SqlConn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand sqlSetLoansDeductions = new SqlCommand(@"update a set
                    a.سلفيات_نصف_الشهر = rs.HalfMonth,
                    a.سلفيات_اخر_الشهر = rs.EndMonth
                    from 
                    (select  sum(b.MonthHalfDedction) HalfMonth,
                    sum(b.MonthEndDedction) EndMonth,a.empid,b.month
                    FROM db_owner.Loans a
                    inner join db_owner.LoansDeductions b
                    on a.LoanID = b.LoanID
                    GROUP BY a.empid,b.month)rs 
                    cross join db_owner.DeductionsFirst as a where a.رقم_الموظف=rs.empid
                    and a.الشهر = rs.month", SqlConn);

            SqlCommand sqlSetPanaltiesDeductions = new SqlCommand(@"update a set
                    a.مخالفات_نصف_الشهر = rs.HalfMonth,
                    a.مخالفات_اخر_الشهر = rs.EndMonth
                    from 
                    (select  sum(b.MonthHalfDedction) HalfMonth,
                    sum(b.MonthEndDedction) EndMonth,a.empid,b.month
                    FROM db_owner.Panalties a
                    inner join db_owner.PanaltiesDeductions b
                    on a.PanaltyID = b.PanaltyID
                    GROUP BY a.empid,b.month)rs 
                    cross join db_owner.DeductionsFirst as a where a.رقم_الموظف=rs.empid
                    and a.الشهر = rs.month", SqlConn);
            try
            {
                SqlConn.Open();
                sqlSetLoansDeductions.ExecuteNonQuery();
                sqlSetPanaltiesDeductions.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SqlConn.Close();
            }
            double total = 0;
            for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
            {
                for (int ColumnIndex = 6; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvDeductions.Columns[ColumnIndex].HeaderText != "استقطاع_نصف_الشهر"
                        && this.dgvDeductions.Columns[ColumnIndex].HeaderText != "سلفيات_نصف_الشهر"
                        && this.dgvDeductions.Columns[ColumnIndex].HeaderText != "مخالفات_نصف_الشهر")
                        
                    {
                        if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                            total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                    }

                }
                dtGetEmp.Rows[index]["الجملة"] = total;
                               total = 0;
            }
            //this.daGetEmp.Update((DataTable)this.EmployeesDeductionsBind.DataSource);
            // Create a new data adapter based on the specified query.
            daGetEmp = new SqlDataAdapter(selectCommand, SqlConn);
            dtGetEmp = new DataTable();
            //// Create a command builder to generate SQL update, insert, and 
            //// delete commands based on selectCommand. These are used to 
            //// update the database.
            commandBuilder = new SqlCommandBuilder(daGetEmp);
            
            //// Populate a new data table and bind it to the BindingSource.
            daGetEmp.Fill(dtGetEmp);
            EmployeesDeductionsBind.DataSource = dtGetEmp;
            dgvDeductions.DataSource = EmployeesDeductionsBind;
            // Resize the DataGridView columns to fit the newly loaded content.
            //  dgvSalaries.AutoResizeColumns(
            //        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            
        }

        private void frmEmployeesSalaries_Load(object sender, EventArgs e)
        {
            List<string> Tables = new List<string>();

            Tables.Add("DeductionsFirst");

            System.Data.SqlClient.SqlConnection SqlConn = new System.Data.SqlClient.SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
            System.Data.SqlClient.SqlCommand SqlComm1 = new System.Data.SqlClient.SqlCommand();
            foreach (string tablename in Tables)
            {
                SqlComm1.CommandText = @"UPDATE db_owner." + tablename + " " +
            @"SET اسم_الموظف = db_owner.Employees.EmpName
            FROM db_owner." + tablename + " " +
            @"INNER JOIN
            db_owner.Employees ON db_owner." + tablename + "" +
                @".رقم_الموظف = db_owner.Employees.EmpID";
                SqlComm1.Connection = SqlConn;
                try
                {
                    SqlConn.Open();
                    SqlComm1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    SqlConn.Close();
                }
            }
            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            GetData("select * from db_owner.DeductionsFirst where الشهر='" + this.cbMonths.Text + "'");
         
   
            double total = 0;

            for (int index = 0; index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = true;
            }

            for (int index = 4; index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].DefaultCellStyle.Format = "N2";
                dgvDeductions.Columns[index].DefaultCellStyle.NullValue = "0.00";
            }
            
          
                    string SqlString;

                        SqlString = @"UPDATE db_owner.DeductionsFirst
                        SET التأمين_الاجتماعي = ((AllowancesFirst.الجملة) * 8/100)
                        FROM db_owner.DeductionsFirst CROSS JOIN
                        db_owner.AllowancesFirst
                        where db_owner.AllowancesFirst.رقم_الموظف = db_owner.DeductionsFirst.رقم_الموظف
                        and db_owner.DeductionsFirst.الشهر = db_owner.AllowancesFirst.الشهر";
                        
                    SqlConn.Open();
                    try
                    {
                        SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);

                        SqlComm.ExecuteNonQuery();

                        SqlComm.Dispose();
                        SqlComm = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        SqlConn.Close();
                    }

            

                  for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
                  {
                      for (int ColumnIndex = 6; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                      {
                          if (this.dgvDeductions.Columns[ColumnIndex].HeaderText != "استقطاع_نصف_الشهر"
                       && this.dgvDeductions.Columns[ColumnIndex].HeaderText != "سلفيات_نصف_الشهر"
                       && this.dgvDeductions.Columns[ColumnIndex].HeaderText != "مخالفات_نصف_الشهر")
                          {
                              if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                                  total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                          }

                      }

                      this.dgvDeductions.Rows[index].Cells["الجملة"].Value = total;
                      total = 0;
                  }
                  //this.dgvDeductions.Columns[4].DisplayIndex = this.dgvDeductions.Columns.Count - 1;
                  //this.daGetEmp.Update((DataTable)this.EmployeesDeductionsBind.DataSource);
        }

    
        List<float> Allowances = new List<float>();

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {
            for (int index = 5; index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = false;
            }

            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int index = 5 ;index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = true;
            }

            
                    double total = 0;
            for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
            {
                for (int ColumnIndex = 6; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvDeductions.Columns[ColumnIndex].HeaderText != "استقطاع_نصف_الشهر"
                        && this.dgvDeductions.Columns[ColumnIndex].HeaderText != "سلفيات_نصف_الشهر"
                        && this.dgvDeductions.Columns[ColumnIndex].HeaderText != "مخالفات_نصف_الشهر")
                    {
                    if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                            total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                    }
                 
                }
                this.dgvDeductions.Rows[index].Cells["الجملة"].Value = total;
                total = 0;
                
            }




            //this.dgvDeductions.Columns[4].DisplayIndex = this.dgvDeductions.Columns.Count - 1;
            this.daGetEmp.Update((DataTable)this.EmployeesDeductionsBind.DataSource);
            GetData(this.daGetEmp.SelectCommand.CommandText);
         
            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnGetMonthSalary.Enabled = true;
        }

        private void btnGetMonthSalary_Click(object sender, EventArgs e)
        {
            GetData(@"SELECT * 
            from db_owner.DeductionsFirst where الشهر='" + this.cbMonths.Text + "'");
            this.btnUpdateAllowances.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnGetMonthSalary.Enabled = false;
        }
    }
}