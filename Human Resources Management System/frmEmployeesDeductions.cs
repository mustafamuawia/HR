using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HR_MS
{
    public partial class frmEmployeesDeductions : Adjest
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesDeductionsBind = new BindingSource();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmEmployeesDeductions()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetData(string selectCommand)
        {
            try
            {
                string SqlString = @"INSERT INTO db_owner.Deductions (رقم_الموظف,اسم_الموظف)
                             SELECT DISTINCT EmpID,EmpName
                             FROM db_owner.Employees EID
                             WHERE
                             NOT EXISTS (SELECT * FROM db_owner.Deductions EmID
                             WHERE EID.EmpID = EmID.رقم_الموظف)"; ;
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmEmployeesSalaries_Load(object sender, EventArgs e)
        {

            GetData("select * from db_owner.Deductions");
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

            for (int index = 2; index < this.dgvDeductions.Columns.Count; index++)
            {
                dgvDeductions.Columns[index].DefaultCellStyle.Format = "N2";
                dgvDeductions.Columns[index].DefaultCellStyle.NullValue = "0.00";
            }
            
            for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
            {
                for (int ColumnIndex = 3; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                    //if (this.dgvSalaries.Rows[index].HeaderCell.Value != "حافز_نصف_الشهر")
                    //{
                    if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                        total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);
                    //}

                }
              
                this.dgvDeductions.Rows[index].Cells[2].Value = total;
                total = 0;
            }
            this.dgvDeductions.Columns[2].DisplayIndex = this.dgvDeductions.Columns.Count - 1;
            //}
            SqlDataAdapter daGetEmpBasicSalary = new SqlDataAdapter(@"select رقم_الموظف,المرتب_الأساسي 
            from db_owner.Allowances", SqlConn);
            DataTable dtGetEmpBasicSalary = new DataTable();
            daGetEmpBasicSalary.Fill(dtGetEmpBasicSalary);
            if (dtGetEmpBasicSalary.Rows.Count > 0)
            {
                for (int index = 0; index < dtGetEmpBasicSalary.Rows.Count; index++)
                {
                    DataRow EmpBasicSalaryRow = dtGetEmpBasicSalary.Rows[index];
                    string SqlString;
                    if (EmpBasicSalaryRow["المرتب_الأساسي"] == DBNull.Value)
                    {
                        SqlString = @"update db_owner.Deductions 
                        set التأمين_الاجتماعي ='" + DBNull.Value + "' where db_owner.Deductions.رقم_الموظف='" + EmpBasicSalaryRow["رقم_الموظف"].ToString() + "' ";

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

        }

    
        List<float> Allowances = new List<float>();

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {
            for (int index =3; index < this.dgvDeductions.Columns.Count-1; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = false;
            }

            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int index = 3; index < this.dgvDeductions.Columns.Count-1; index++)
            {
                dgvDeductions.Columns[index].ReadOnly = true;
            }
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
                        set التأمين_الاجتماعي ='" + DBNull.Value + "' where db_owner.Deductions.رقم_الموظف='" + EmpBasicSalaryRow["رقم_الموظف"].ToString() + "' ";

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
            for (int index = 0; index < this.dgvDeductions.Rows.Count; index++)
            {
                for (int ColumnIndex = 3; ColumnIndex < this.dgvDeductions.Columns.Count; ColumnIndex++)
                {
                   
                    if (this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value != DBNull.Value)
                        total += Convert.ToDouble(this.dgvDeductions.Rows[index].Cells[ColumnIndex].Value);

                }

                this.dgvDeductions.Rows[index].Cells[2].Value = total;
                total = 0;
            }
            this.dgvDeductions.Columns[2].DisplayIndex = this.dgvDeductions.Columns.Count - 1;


            this.daGetEmp.Update((DataTable)this.EmployeesDeductionsBind.DataSource);
            
            GetData(this.daGetEmp.SelectCommand.CommandText);
            this.btnUpdateAllowances.Enabled = true;
            this.btnSave.Enabled = false;
        }
    }
}