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
    public partial class frmDialyWorkersAllowances : Adjust
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesAllowncesBind = new BindingSource();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmDialyWorkersAllowances()
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
            db_owner.DialyWorkers";

            SqlDataAdapter daGetDialyEmoloyee = new SqlDataAdapter(sqlstringGetDialyEmoloyee,SqlConn);
            DataTable dtGetDialyEmoloyee = new DataTable();
           

            try
            {
                daGetDialyEmoloyee.Fill(dtGetDialyEmoloyee);
                for (int index = 1; index <= 12; index++)
                {
                for (int mindex = 0; mindex < dtGetDialyEmoloyee.Rows.Count; mindex++)
                {
                   
                        string SqlString = @"INSERT INTO db_owner.DialyWorkersSalaries (رقم_العامل, اسم_العامل, الشهر)
                        select '" + dtGetDialyEmoloyee.Rows[mindex]["EmpID"] + "'," +
                        @"'" + dtGetDialyEmoloyee.Rows[mindex]["EmpName"] + "'," +
                        @"'"+ArabicEgypt.DateTimeFormat.GetMonthName(index)+"' "+
                        @"where NOT EXISTS (SELECT * FROM db_owner.DialyWorkersSalaries EmID "+
                        @"WHERE EmID.رقم_العامل = '" + dtGetDialyEmoloyee.Rows[mindex]["EmpID"] + "' " +
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
                EmployeesAllowncesBind.DataSource = dtGetEmp;
                dgvAllowances.DataSource = EmployeesAllowncesBind;
                // Resize the DataGridView columns to fit the newly loaded content.
                //  dgvSalaries.AutoResizeColumns(
                //        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                for (int index = 0; index < dgvAllowances.Rows.Count; index++)
                {
                    string strGetAbbsanceDays = @"select id from db_owner.DialyWorkersAttendance
            where التاريخ between '" + new DateTime(2013, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1, 1) + "' " +
                   @"and '" + new DateTime(2013, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1, 10) + "' " +
                   @"and رقم_العامل = '" + dgvAllowances[1, index].Value.ToString() + "' " +
                    @"and غياب = 'true'";
                    SqlDataAdapter dasqlGetAbbsanceDays = new SqlDataAdapter(strGetAbbsanceDays, SqlConn);
                    DataTable dtsqlGetAbbsanceDays = new DataTable();
                    dasqlGetAbbsanceDays.Fill(dtsqlGetAbbsanceDays);
                    if (this.dgvAllowances.Rows[index].Cells["الأجر"].Value == DBNull.Value)
                       dtGetEmp.Rows[index]["غياب_اول_الشهر"] = dtsqlGetAbbsanceDays.Rows.Count * 0;
                        //this.dgvAllowances.Rows[index].Cells["غياب_اول_الشهر"].Value = dtsqlGetAbbsanceDays.Rows.Count * 0;
                    else
                    {
                        dtGetEmp.Rows[index]["غياب_اول_الشهر"] = dtsqlGetAbbsanceDays.Rows.Count *
                        (Convert.ToDouble(this.dgvAllowances.Rows[index].Cells["الأجر"].Value));
                        //this.dgvAllowances.Rows[index].Cells["غياب_اول_الشهر"].Value = dtsqlGetAbbsanceDays.Rows.Count *
                        //(Convert.ToInt32(this.dgvAllowances.Rows[index].Cells["الأجر"].Value));
                    }

                    strGetAbbsanceDays = @"select id from db_owner.DialyWorkersAttendance
            where التاريخ between '" + new DateTime(2013, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1, 11) + "' " +
                  @"and '" + new DateTime(2013, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1, 20) + "' " +
                  @"and رقم_العامل = '" + dgvAllowances[1, index].Value.ToString() + "' " +
                   @"and غياب = 'true'";
                    dasqlGetAbbsanceDays = new SqlDataAdapter(strGetAbbsanceDays, SqlConn);
                    dtsqlGetAbbsanceDays = new DataTable();
                    dasqlGetAbbsanceDays.Fill(dtsqlGetAbbsanceDays);
                    if (this.dgvAllowances.Rows[index].Cells["الأجر"].Value == DBNull.Value)
                        dtGetEmp.Rows[index]["غياب_منتصف_الشهر"] = dtsqlGetAbbsanceDays.Rows.Count * 0;
                    else
                    {
                        dtGetEmp.Rows[index]["غياب_منتصف_الشهر"] = dtsqlGetAbbsanceDays.Rows.Count *
                        (Convert.ToDouble(this.dgvAllowances.Rows[index].Cells["الأجر"].Value));
                    }

                    strGetAbbsanceDays = @"select id from db_owner.DialyWorkersAttendance
            where التاريخ between '" + new DateTime(2013, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1, 21) + "' " +
                  @"and '" + new DateTime(2013, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1, DateTime.DaysInMonth(DateTime.Now.Year, this.cbMonths.Items.IndexOf(this.cbMonths.Text) + 1)) + "' " +
                  @"and رقم_العامل = '" + dgvAllowances[1, index].Value.ToString() + "' " +
                   @"and غياب  = 'true'";
                    dasqlGetAbbsanceDays = new SqlDataAdapter(strGetAbbsanceDays, SqlConn);
                    dtsqlGetAbbsanceDays = new DataTable();
                    dasqlGetAbbsanceDays.Fill(dtsqlGetAbbsanceDays);
                    if (this.dgvAllowances.Rows[index].Cells["الأجر"].Value == DBNull.Value)
                        dtGetEmp.Rows[index]["غياب_اخر_الشهر"]= dtsqlGetAbbsanceDays.Rows.Count * 0;
                    else
                    {
                        dtGetEmp.Rows[index]["غياب_اخر_الشهر"] = dtsqlGetAbbsanceDays.Rows.Count *
                        (Convert.ToDouble(this.dgvAllowances.Rows[index].Cells["الأجر"].Value));
                    }
                }
                this.daGetEmp.Update((DataTable)this.EmployeesAllowncesBind.DataSource);
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message);
            }

        }

        private void frmEmployeesSalaries_Load(object sender, EventArgs e)
        {

            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            GetData(@"SELECT * 
            from db_owner.DialyWorkersSalaries where الشهر='" + this.cbMonths.Text + "'");
            ////// Initialize FileID field
            ////daGetEmp = new SqlDataAdapter(@"select * from db_owner.Allowances", SqlConn);
            ////SqlCommandBuilder cbEmployee = new SqlCommandBuilder(daGetEmp);
            ////dtGetEmp = new DataTable();
            ////daGetEmp.Fill(dtGetEmp);
            ////EmployeesAllowncesBind = new BindingSource();
            ////EmployeesAllowncesBind.DataSource = dtGetEmp;
            ////dgvSalaries.DataSource = EmployeesAllowncesBind;

            ////foreach (DataColumn dataColumn in dtGetEmp.Columns)
            ////{
            ////    if (dataColumn.ColumnName == "EmpID")
            ////        dataColumn.ColumnName = "رقم الموظف";
            ////    else if (dataColumn.ColumnName == "EmployeeName")
            ////        dataColumn.ColumnName = "اسم الموظف";
            ////    dataColumn.ColumnName = dataColumn.ColumnName.Replace('_', ' ');
            this.dgvAllowances.Columns[0].Visible = false;
            double total = 0;

            for (int index = 0; index < this.dgvAllowances.Columns.Count; index++)
            {
                dgvAllowances.Columns[index].ReadOnly = true;
            }

            for (int index = 4; index < this.dgvAllowances.Columns.Count; index++)
            {
                dgvAllowances.Columns[index].DefaultCellStyle.Format = "N2";
                dgvAllowances.Columns[index].DefaultCellStyle.NullValue = "0.00";
            }


            //for (int index = 0; index < this.dgvAllowances.Rows.Count; index++)
            //{
            //    if (this.dgvAllowances.Rows[index].Cells[4].Value != DBNull.Value)
            //        total = Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[4].Value);
            //    for (int ColumnIndex = 5; ColumnIndex < this.dgvAllowances.Columns.Count-2; ColumnIndex++)
            //    {

            //        if (this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
            //                total -= Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value);
            //    }
            //    //if (this.dgvAllowances.Rows[index].Cells[4].Value != DBNull.Value
            //    //    && this.dgvAllowances.Rows[index].Cells[5].Value != DBNull.Value)
            //    //{
            //    //    total = Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[4].Value)
            //    //                   - Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[5].Value);
            //    //}
            //    //else if (this.dgvAllowances.Rows[index].Cells[4].Value != DBNull.Value
            //    //    && this.dgvAllowances.Rows[index].Cells[5].Value == DBNull.Value)
            //    //{
            //    //    total = Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[4].Value);
            //    //}
            //    //else if (this.dgvAllowances.Rows[index].Cells[4].Value == DBNull.Value
            //    //    && this.dgvAllowances.Rows[index].Cells[5].Value != DBNull.Value)
            //    //{
            //    //    total = 0 - Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[5].Value);
            //    //}
            //    this.dgvAllowances.Rows[index].Cells["الجملة"].Value = total;
            //    total = 0;
           

        }

        

        List<float> Allowances = new List<float>();

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {

            for (int index = 4; index < this.dgvAllowances.Columns.Count; index++)
            {
                dgvAllowances.Columns[index].ReadOnly = false;
            }

            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnGetMonthSalaries.Enabled = false;
            //this.dgvAllowances.Columns[0].Visible = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 4; i < this.dgvAllowances.Columns.Count; i++)
            {
                dgvAllowances.Columns[i].ReadOnly = true;
            }
//            foreach (DataColumn dataColumn in dtGetEmp.Columns)
//            {
//                if (dataColumn.ColumnName == "رقم الموظف")
//                    dataColumn.ColumnName = "EmpID";
//                else if (dataColumn.ColumnName == "اسم الموظف")
//                    dataColumn.ColumnName = "EmployeeName";
//                dataColumn.ColumnName = dataColumn.ColumnName.Replace(' ', '_');
//            }
//            SqlDataAdapter daGetEmpBasicSalary = new SqlDataAdapter(@"select رقم_الموظف,المرتب_الأساسي 
//            from db_owner.Allowances", SqlConn);
//            DataTable dtGetEmpBasicSalary = new DataTable();
//            daGetEmpBasicSalary.Fill(dtGetEmpBasicSalary);
//            if (dtGetEmpBasicSalary.Rows.Count > 0)
//            {
//                for (int index = 0; index < dtGetEmpBasicSalary.Rows.Count; index++)
//                {
//                    string SqlString;
//                    DataRow EmpBasicSalaryRow = dtGetEmpBasicSalary.Rows[index];
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

            //double total = 0;
            //for (int index = 0; index < this.dgvAllowances.Rows.Count; index++)
            //{
            //    if (this.dgvAllowances.Rows[index].Cells[4].Value != DBNull.Value)
            //        total = Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[4].Value);
            //    for (int ColumnIndex = 4; ColumnIndex < this.dgvAllowances.Columns.Count - 2; ColumnIndex++)
            //    {

            //        if (this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
            //            total -= Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value);
            //    }
            //    this.dgvAllowances.Rows[index].Cells["الجملة"].Value = total;
            //    total = 0;
            //}
            
            //this.dgvAllowances.Columns[4].DisplayIndex = this.dgvAllowances.Columns.Count - 1;

            this.daGetEmp.Update((DataTable)this.EmployeesAllowncesBind.DataSource);
//            foreach (DataColumn dataColumn in dtGetEmp.Columns)
//            {
//                if (dataColumn.ColumnName == "EmpID")
//                    dataColumn.ColumnName = "رقم الموظف";
//                else if (dataColumn.ColumnName == "EmployeeName")
//                    dataColumn.ColumnName = "اسم الموظف";
//                dataColumn.ColumnName = dataColumn.ColumnName.Replace('_', ' ');
//                for (int index = 0; index < this.dgvSalaries.Columns.Count; index++)
//                {
//                    dgvSalaries.Columns[index].ReadOnly = true;
//                }
//            }
//            GetData(this.daGetEmp.SelectCommand.CommandText);
            this.btnUpdateAllowances.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnGetMonthSalaries.Enabled = true;
        }

        private void btnGetMonthSalaries_Click(object sender, EventArgs e)
        {
            GetData(@"SELECT * 
            from db_owner.DialyWorkersSalaries where الشهر='" + this.cbMonths.Text + "'");
        }
    }
}