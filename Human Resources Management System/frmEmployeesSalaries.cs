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
    public partial class frmEmployeesSalaries : Adjest
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        SqlDataAdapter daGetEmp;
        DataTable dtGetEmp;
        BindingSource EmployeesAllowncesBind = new BindingSource();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmEmployeesSalaries()
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
                string SqlString = @"INSERT INTO db_owner.Allowances (رقم_الموظف,اسم_الموظف)
                             SELECT DISTINCT EmpID,EmpName
                              FROM db_owner.Employees EID
                              WHERE
                             NOT EXISTS (SELECT * FROM db_owner.Allowances EmID
                             WHERE EID.EmpID = EmID.رقم_الموظف)";
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
                EmployeesAllowncesBind.DataSource = dtGetEmp;
                dgvSalaries.DataSource = EmployeesAllowncesBind;
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
                for (int index = 0; index < this.dgvSalaries.Columns.Count; index++)
                {
                    dgvSalaries.Columns[index].ReadOnly = true;
                }
                DataGridViewColumn Total = new DataGridViewColumn();
                Total.Name = "Total";
                Total.HeaderText = "المجموع";
                //Total.CellType = 
                this.dgvSalaries.Columns.Add(Total);
            //}
        
        }

        private void hRDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void hRDataSetBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        List<float> Allowances = new List<float>();

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {
            for (int index = 2; index < this.dgvSalaries.Columns.Count; index++)
            {
                dgvSalaries.Columns[index].ReadOnly = false;
            }
           
            this.btnUpdateAllowances.Enabled = false;
            this.btnSave.Enabled = true;
            this.dgvSalaries.Columns[0].Visible = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int index = 3; index < this.dgvSalaries.Columns.Count; index++)
            {
                dgvSalaries.Columns[index].ReadOnly = true;
            }
            //foreach (DataColumn dataColumn in dtGetEmp.Columns)
            //{
            //    if (dataColumn.ColumnName == "رقم الموظف")
            //        dataColumn.ColumnName = "EmpID";
            //    else if (dataColumn.ColumnName == "اسم الموظف")
            //        dataColumn.ColumnName = "EmployeeName";
            //    dataColumn.ColumnName = dataColumn.ColumnName.Replace(' ', '_');
            //}
            
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