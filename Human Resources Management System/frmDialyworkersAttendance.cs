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
    public partial class frmDialyworkersAttendance : Adjust
    {
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesAttendanceBind = new BindingSource();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmDialyworkersAttendance()
        {
            InitializeComponent();
        }

        private void GetData(string selectCommand)
        {
           try
           {
                // Create a new data adapter based on the specified query.
                daGetEmp = new SqlDataAdapter(selectCommand, SqlConn);
                dtGetEmp = new DataTable();
                // Create a command builder to generate SQL update, insert, and 
                // delete commands based on selectCommand. These are used to 
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(daGetEmp);

                // Populate a new data table and bind it to the BindingSource.
                daGetEmp.Fill(dtGetEmp);
                EmployeesAttendanceBind.DataSource = dtGetEmp;
                dgvAttendance.DataSource = EmployeesAttendanceBind;
                // Resize the DataGridView columns to fit the newly loaded content.
                //  dgvSalaries.AutoResizeColumns(
                //        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message);
            }
        }
        private void frmDialyworkersAttendance_Load(object sender, EventArgs e)
        {
             CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            string sqlstringGetEmoloyees = @"select  EmpID, EmpName from
            db_owner.DialyWorkers";

            SqlDataAdapter daGetEmoloyees = new SqlDataAdapter(sqlstringGetEmoloyees, SqlConn);
            DataTable dtGetEmoloyees = new DataTable();

            var YearDays = (new DateTime(2013, 12, 31)) - (new DateTime(2013, 1, 1));


            try
            {
                daGetEmoloyees.Fill(dtGetEmoloyees);
                for (int index = 0; index <= YearDays.TotalDays; index++)
                {
                    for (int mindex = 0; mindex < dtGetEmoloyees.Rows.Count; mindex++)
                    {

//                        string SqlString = @"INSERT INTO db_owner.DialyWorkersAttendance (رقم_العامل, اسم_العامل, التاريخ)
//                        select '" + dtGetEmoloyees.Rows[mindex]["EmpID"] + "'," +
//                         @"'" + dtGetEmoloyees.Rows[mindex]["EmpName"] + "'," +
//                         @"'" + ArabicEgypt.DateTimeFormat.GetMonthName(index) + "' " +
//                         @"where NOT EXISTS (SELECT * FROM db_owner.DialyWorkersAttendance EmID " +
//                         @"WHERE EmID.رقم_العامل = '" + dtGetEmoloyees.Rows[mindex]["EmpID"] + "' " +
//                        @"and EmID.التاريخ = '" + new DateTime(2013, 1, 1).AddDays(index).ToShortDateString() + "')";


                        string SqlString = @"INSERT INTO db_owner.DialyWorkersAttendance (رقم_العامل, اسم_العامل, التاريخ)
                        select '" + dtGetEmoloyees.Rows[mindex]["EmpID"] + "'," +
                        @"'" + dtGetEmoloyees.Rows[mindex]["EmpName"] + "'," +
                        @"'" + new DateTime(2013, 1, 1).AddDays(index).ToShortDateString() + "' " +
                        @"where NOT EXISTS (SELECT * FROM db_owner.DialyWorkersAttendance EmID " +
                        @"WHERE EmID.رقم_العامل = '" + dtGetEmoloyees.Rows[mindex]["EmpID"] + "' " +
                        @"and EmID.التاريخ = @date)";


                        SqlConn.Open();
                        try
                        {
                        SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);
                        SqlComm.Parameters.AddWithValue("@date", new DateTime(2013, 1, 1).AddDays(index));
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                SqlConn.Close();
            }
                
            dtpDate.Value = DateTime.Today;
            GetData(@"SELECT * 
            from db_owner.DialyWorkersAttendance where التاريخ='" + dtpDate.Value.ToShortDateString() + "'");
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            GetData(@"SELECT * 
            from db_owner.DialyWorkersAttendance where التاريخ='" + dtpDate.Value.ToShortDateString() + "'");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.daGetEmp.Update((DataTable)this.EmployeesAttendanceBind.DataSource);
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
            //this.btnUpdateAllowances.Enabled = false;
            //this.btnSave.Enabled = false;
            //this.btnGetMonthSalary.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
       