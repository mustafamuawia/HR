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
    public partial class frmEmployeesAllowances : Adjest
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesAllowncesBind = new BindingSource();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmEmployeesAllowances()
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
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message);
            }
        }

        private void frmEmployeesSalaries_Load(object sender, EventArgs e)
        {
            this.cbMonths.Text = this.cbMonths.Items[0].ToString();
            GetData("select * from db_owner.Allowances");
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

            for (int index = 0; index < this.dgvAllowances.Columns.Count; index++)
            {
                dgvAllowances.Columns[index].ReadOnly = true;
            }

            for (int index = 2; index < this.dgvAllowances.Columns.Count; index++)
            {
                dgvAllowances.Columns[index].DefaultCellStyle.Format = "N2";
                dgvAllowances.Columns[index].DefaultCellStyle.NullValue = "0.00";
            }


            for (int index = 0; index < this.dgvAllowances.Rows.Count; index++)
            {
                for (int ColumnIndex = 3; ColumnIndex < this.dgvAllowances.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvAllowances.Columns[ColumnIndex].HeaderText != "حافز_نصف_شهري")
                    {
                        if (this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                            total += Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value);
                    }

                }

                this.dgvAllowances.Rows[index].Cells[2].Value = total;
                total = 0;
            }
            this.dgvAllowances.Columns[2].DisplayIndex = this.dgvAllowances.Columns.Count - 1;
            //}

        }

        List<float> Allowances = new List<float>();

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {
            for (int index = 3; index < this.dgvAllowances.Columns.Count; index++)
            {
                dgvAllowances.Columns[index].ReadOnly = false;
            }

            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = true;
            this.dgvAllowances.Columns[0].Visible = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 3; i < this.dgvAllowances.Columns.Count; i++)
            {
                dgvAllowances.Columns[i].ReadOnly = true;
            }
            //foreach (DataColumn dataColumn in dtGetEmp.Columns)
            //{
            //    if (dataColumn.ColumnName == "رقم الموظف")
            //        dataColumn.ColumnName = "EmpID";
            //    else if (dataColumn.ColumnName == "اسم الموظف")
            //        dataColumn.ColumnName = "EmployeeName";
            //    dataColumn.ColumnName = dataColumn.ColumnName.Replace(' ', '_');
            //}
            SqlDataAdapter daGetEmpBasicSalary = new SqlDataAdapter(@"select رقم_الموظف,المرتب_الأساسي 
            from db_owner.Allowances", SqlConn);
            DataTable dtGetEmpBasicSalary = new DataTable();
            daGetEmpBasicSalary.Fill(dtGetEmpBasicSalary);
            if (dtGetEmpBasicSalary.Rows.Count > 0)
            {
                for (int index = 0; index < dtGetEmpBasicSalary.Rows.Count; index++)
                {
                    string SqlString;
                    DataRow EmpBasicSalaryRow = dtGetEmpBasicSalary.Rows[index];
                    if (EmpBasicSalaryRow["المرتب_الأساسي"] == DBNull.Value)
                    {
                        SqlString = @"update db_owner.Deductions 
                        set التأمين_الاجتماعي ='"+DBNull.Value+"' where db_owner.Deductions.رقم_الموظف='" + EmpBasicSalaryRow["رقم_الموظف"].ToString() + "' ";
                        
                    }
                    else
                    {
                        double BasicSalary = Convert.ToDouble(EmpBasicSalaryRow["المرتب_الأساسي"].ToString());
                        SqlString = @"update db_owner.Deductions 
                        set التأمين_الاجتماعي ='" + (BasicSalary * 8 / 100) + "' " +
                        @"where db_owner.Deductions.رقم_الموظف ='" + EmpBasicSalaryRow["رقم_الموظف"].ToString() + "' ";
                    }
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

            double total = 0;
            for (int index = 0; index < this.dgvAllowances.Rows.Count; index++)
            {
                for (int ColumnIndex = 3; ColumnIndex < this.dgvAllowances.Columns.Count; ColumnIndex++)
                {
                    if (this.dgvAllowances.Columns[ColumnIndex].HeaderText != "حافز_نصف_شهري")
                    {
                        if (this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                            total += Convert.ToDouble(this.dgvAllowances.Rows[index].Cells[ColumnIndex].Value);
                    }
                }

                this.dgvAllowances.Rows[index].Cells[2].Value = total;
                total = 0;
            }
            this.dgvAllowances.Columns[2].DisplayIndex = this.dgvAllowances.Columns.Count - 1;

            this.daGetEmp.Update((DataTable)this.EmployeesAllowncesBind.DataSource);
            //foreach (DataColumn dataColumn in dtGetEmp.Columns)
            //{
            //    if (dataColumn.ColumnName == "EmpID")
            //        dataColumn.ColumnName = "رقم الموظف";
            //    else if (dataColumn.ColumnName == "EmployeeName")
            //        dataColumn.ColumnName = "اسم الموظف";
            //    dataColumn.ColumnName = dataColumn.ColumnName.Replace('_', ' ');
            //    for (int index = 0; index < this.dgvSalaries.Columns.Count; index++)
            //    {
            //        dgvSalaries.Columns[index].ReadOnly = true;
            //    }
            //}
            GetData(this.daGetEmp.SelectCommand.CommandText);
            this.btnUpdateAllowances.Enabled = true;
            this.btnSave.Enabled = false;
        }

       
    }
}