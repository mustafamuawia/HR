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
    public partial class frmEmployeesDeductionsSecond : Adjust
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesDeductionsBind = new BindingSource();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmEmployeesDeductionsSecond()
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
            db_owner.Employees where EmpInsurance='0'";

            SqlDataAdapter daGetDialyEmoloyee = new SqlDataAdapter(sqlstringGetDialyEmoloyee, SqlConn);
            DataTable dtGetDialyEmoloyee = new DataTable();


            try
            {
                daGetDialyEmoloyee.Fill(dtGetDialyEmoloyee);
                for (int index = 1; index <= 12; index++)
                {
                    for (int mindex = 0; mindex < dtGetDialyEmoloyee.Rows.Count; mindex++)
                    {

                        string SqlString = @"INSERT INTO db_owner.DeductionsSecond (رقم_الموظف, اسم_الموظف, الشهر)
                        select '" + dtGetDialyEmoloyee.Rows[mindex]["EmpID"] + "'," +
                        @"'" + dtGetDialyEmoloyee.Rows[mindex]["EmpName"] + "'," +
                        @"'" + ArabicEgypt.DateTimeFormat.GetMonthName(index) + "' " +
                        @"where NOT EXISTS (SELECT * FROM db_owner.DeductionsSecond EmID " +
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
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(daGetEmp);

                // Populate a new data table and bind it to the BindingSource.
                daGetEmp.Fill(dtGetEmp);
                EmployeesDeductionsBind.DataSource = dtGetEmp;
                dgvDeductions.DataSource = EmployeesDeductionsBind;
                // Resize the DataGridView columns to fit the newly loaded content.
                //  dgvSalaries.AutoResizeColumns(
                //        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                int Year = DateTime.Now.Year;
                int MonthDays = DateTime.DaysInMonth(2013, cbMonths.Items.IndexOf(cbMonths.Text) + 1);
                for (int i = 0; i < dgvDeductions.Rows.Count; i++)
                {
                    SqlCommand sqlSetAbbcanceDeduction = new SqlCommand(@"update db_owner.DeductionsSecond set غياب_مرتب 
            =((SELECT COUNT(*) FROM db_owner.attendanceSecond where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                 @"and التاريخ between '" + new DateTime(Year, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 16) + "'" +
                    @"and  '" + new DateTime(2013, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), MonthDays) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select الجملة from db_owner.allowancesSecond
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/15)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'" +
                     @"update db_owner.DeductionsSecond set غياب_حافز 
            =((SELECT COUNT(*) FROM db_owner.attendanceSecond where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                 @"and التاريخ between '" + new DateTime(2013, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 1) + "'" +
                    @"and  '" + new DateTime(2013, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), 15) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select حافز_نصف_شهري from db_owner.allowancesSecond
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/15)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'" +
                 @"update db_owner.DeductionsSecond set غياب_بعذر 
            =((SELECT COUNT(*) FROM db_owner.attendanceSecond where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' " +
                  @"and التاريخ between '" + new DateTime(2013, Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1, 15) + "'" +
                    @"and  '" + new DateTime(2013, (Convert.ToInt32(this.cbMonths.Items.IndexOf(this.cbMonths.Text)) + 1), MonthDays) + "' " +
                   @" and غياب = 1) " +
                     @"* ((Select حافز_نصف_شهري from db_owner.allowancesSecond
            where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "')/30)) " +
                 @"where رقم_الموظف = '" + dgvDeductions.Rows[i].Cells[1].Value.ToString() + "' and الشهر = '" + this.cbMonths.Text + "'", SqlConn);
                    try
                    {
                        SqlConn.Open();
                        sqlSetAbbcanceDeduction.ExecuteNonQuery();

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
                    cross join db_owner.DeductionsSecond as a where a.رقم_الموظف=rs.empid
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
                    cross join db_owner.DeductionsSecond as a where a.رقم_الموظف=rs.empid
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
                for (int ColumnIndex = 5; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvDeductions.Columns[ColumnIndex].HeaderText != "استقطاع_نصف_الشهر")
                    {
                        if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                            total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                    }

                }
                dtGetEmp.Rows[index]["الجملة"] = total;
                this.dgvDeductions.Rows[index].Cells["الجملة"].Value = total;
                total = 0;
            }
            // Create a new data adapter based on the specified query.
            daGetEmp = new SqlDataAdapter(selectCommand, SqlConn);
            dtGetEmp = new DataTable();
            //// Create a command builder to generate SQL update, insert, and 
            //// delete commands based on selectCommand. These are used to 
            //// update the database.
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(daGetEmp);

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

            Tables.Add("DeductionsSecond");
            SqlCommand SqlComm = new SqlCommand();
           foreach (string tablename in Tables)
            {
                SqlComm.CommandText = @"UPDATE db_owner." + tablename + " " +
            @"SET اسم_الموظف = db_owner.Employees.EmpName
            FROM db_owner." + tablename + " " +
            @"INNER JOIN
            db_owner.Employees ON db_owner." + tablename + "" +
                @".رقم_الموظف = db_owner.Employees.EmpID";
                SqlComm.Connection = SqlConn;
                try
                {
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();
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
            GetData("select * from db_owner.DeductionsSecond where الشهر='" + this.cbMonths.Text + "'");

          
            //// Initialize FileID field
            //daGetEmp = new SqlDataAdapter(@"select * from db_owner.Allowances", SqlConn);
            //SqlCommandBuilder cbEmployee = new SqlCommandBuilder(daGetEmp);
            //dtGetEmp = new DataTable();
            //daGetEmp.Fill(dtGetEmp);
            //EmployeesAllowncesBind = new BindingSource();
            //EmployeesAllowncesBind.DataSource = dtGetEmp;
            //dgvSalaries.DataSource = EmployeesAllowncesBind;

            //foreach (DataColumn dataColumn in dtGetEmp.Columns)
            //{
            //    if (dataColumn.ColumnName == "EmpID")
            //        dataColumn.ColumnName = "رقم الموظف";
            //    else if (dataColumn.ColumnName == "EmployeeName")
            //        dataColumn.ColumnName = "اسم الموظف";
            //    dataColumn.ColumnName = dataColumn.ColumnName.Replace('_', ' ');

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
            
            for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
            {
                for (int ColumnIndex = 5; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvDeductions.Columns[ColumnIndex].HeaderText != "استقطاع_نصف_الشهر")
                    {
                    if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                        total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                    }

                }

                this.dgvDeductions.Rows[index].Cells["الجملة"].Value = total;
                total = 0;
            }
            this.dgvDeductions.Columns[4].DisplayIndex = this.dgvDeductions.Columns.Count - 1;
            //}
//            SqlDataAdapter daGetEmpBasicSalary = new SqlDataAdapter(@"select رقم_الموظف,المرتب_الأساسي 
//            from db_owner.Allowances", SqlConn);
//            DataTable dtGetEmpBasicSalary = new DataTable();
//            daGetEmpBasicSalary.Fill(dtGetEmpBasicSalary);
//            if (dtGetEmpBasicSalary.Rows.Count > 0)
//            {
//                for (int index = 0; index < dtGetEmpBasicSalary.Rows.Count; index++)
//                {
//                    DataRow EmpBasicSalaryRow = dtGetEmpBasicSalary.Rows[index];
//                    string SqlString;
//                    if (EmpBasicSalaryRow["المرتب_الأساسي"] == DBNull.Value)
//                    {
//                        SqlString = @"update db_owner.Deductions 
//                        set التأمين_الاجتماعي ='" + DBNull.Value + "' where db_owner.Deductions.رقم_الموظف='" + EmpBasicSalaryRow["رقم_الموظف"].ToString() + "' ";

//                    }
//                    else
//                    {
//                        double BasicSalary = Convert.ToDouble(EmpBasicSalaryRow["المرتب_الأساسي"].ToString());
//                        SqlString = @"update db_owner.Deductions 
//                        set التأمين_الاجتماعي ='" + (BasicSalary * 8 / 100) + "' " +
//                        @"where db_owner.Deductions.رقم_الموظف ='" + EmpBasicSalaryRow["رقم_الموظف"].ToString() + "' ";
//                    }
//                    SqlConn.Open();
//                    try
//                    {
//                        SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);

//                        SqlComm.ExecuteNonQuery();

//                        SqlComm.Dispose();
//                        SqlComm = null;
//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show(ex.Message.ToString());
//                    }
//                    finally
//                    {
//                        SqlConn.Close();
//                    }
//                }
//            }

        }

    
        List<float> Allowances = new List<float>();

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {
            for (int index = 4; index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = false;
            }

            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int index = 4; index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = true;
            }


            double total = 0;
            for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
            {
                for (int ColumnIndex = 5; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvDeductions.Columns[ColumnIndex].HeaderText != "استقطاع_نصف_الشهر")
                    {
                        if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                            total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                    }
                }

                this.dgvDeductions.Rows[index].Cells["الجملة"].Value = total;
                total = 0;
            }
            this.dgvDeductions.Columns[4].DisplayIndex = this.dgvDeductions.Columns.Count - 1;



            this.daGetEmp.Update((DataTable)this.EmployeesDeductionsBind.DataSource);
            GetData(this.daGetEmp.SelectCommand.CommandText);
            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnGetMonthSalary.Enabled = true;
        }

        private void btnGetMonthSalary_Click(object sender, EventArgs e)
        {
            GetData(@"SELECT * 
            from db_owner.DeductionsSecond where الشهر='" + this.cbMonths.Text + "'");
            this.btnUpdateAllowances.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnGetMonthSalary.Enabled = false;
        }
    }
}