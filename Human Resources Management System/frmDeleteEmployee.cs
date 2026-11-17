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
    public partial class frmDeleteEmployee : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        SqlDataAdapter adGetEmployee;
        DataTable dtGetEmployee;
        int EmpID;

        public frmDeleteEmployee()
        {
            InitializeComponent();
        }

        private void InitialListViewEmployees()
        {
            this.listView1.Items.Clear();
            adGetEmployee = new SqlDataAdapter(@"select EmpID,EmpName from db_owner.Employees", SqlConn);
            dtGetEmployee = new DataTable();
            try
            {
                adGetEmployee.Fill(dtGetEmployee);
                if (dtGetEmployee.Rows.Count > 0)
                {

                    for (int index = 0; index < dtGetEmployee.Rows.Count; index++)
                    {
                        DataRow EmployeeRow = dtGetEmployee.Rows[index];
                        ListViewItem Employee = new ListViewItem(EmployeeRow["EmpID"].ToString());
                        Employee.SubItems.Add(EmployeeRow["EmpName"].ToString());
                        listView1.Items.Add(Employee);
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("لم يتم الحذف" + ex.Message.ToString(), "خطأ", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
            finally
            {
                adGetEmployee.Dispose();
                dtGetEmployee.Dispose();
                SqlConn.Close();
            }
        }

        private void frmDeleteEmployee_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now.Date;
            InitialListViewEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.EmpID = Convert.ToInt32(this.listView1.SelectedItems[0].Text);
            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            if (MessageBox.Show("هل تود حذف الموظف", "تنبيه", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand sqlCommArchiveInsert = new SqlCommand(@"INSERT INTO EmployeesArchive
                (EmpID, EmpName, EmpGender, EmpJobID, EmpNationalityID, EmpAddress, EmpPhoneNo,
                EmpMobilePhoneNo, EmpPicture, EmpHiringDate,EmpEndDate,Reason)
                ((SELECT EmpID, EmpName, EmpGender, EmpJobID, EmpNationalityID, EmpAddress,
                EmpPhoneNo, EmpMobilePhoneNo, EmpPicture, EmpHiringDateID
                FROM Employees where empid ='" + this.EmpID + "' ) " +
                @",'"+this.dtpEndDate.Value+"','"+this.txtDeleteReason.Text+"')", SqlConn);

                
                SqlCommand sqlCommDeleteAllowancesfirst;
                SqlCommand sqlCommDeleteAllowancessecond;
                SqlCommand sqlCommDeletDeductions1st;
                SqlCommand sqlCommDeletDeductions2nd;

                int HiringMonth = dtpHireDate.Value.Month;
                int EndMonth = dtpEndDate.Value.Month;
                for (int i = 1; i < HiringMonth; i++)
                {

                sqlCommDeleteAllowancesfirst = new SqlCommand(@"
                Delete from db_owner.AllowancesFirst 
                where رقم_الموظف='" + this.EmpID + "' " +
                    @"and الشهر= '"+ArabicEgypt.DateTimeFormat.GetMonthName(i)+"'", SqlConn);

                sqlCommDeleteAllowancessecond = new SqlCommand(@"
                Delete from db_owner.AllowancesSecond 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);

                sqlCommDeletDeductions1st = new SqlCommand(@"
                Delete from db_owner.DeductionsFirst
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);

                sqlCommDeletDeductions2nd = new SqlCommand(@"
                Delete from db_owner.DeductionsSecond 
                 where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);


                SqlConn.Open();
                sqlCommDeleteAllowancesfirst.ExecuteNonQuery();
                sqlCommDeleteAllowancessecond.ExecuteNonQuery();
                sqlCommDeletDeductions1st.ExecuteNonQuery();
                sqlCommDeletDeductions2nd.ExecuteNonQuery();
                SqlConn.Close();
                InitialListViewEmployees();
                }

                for (int i = EndMonth + 1; i <= 12; i++)
                {
                    
                
                    sqlCommDeleteAllowancesfirst = new SqlCommand(@"
                Delete from db_owner.AllowancesFirst 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);
               
                    sqlCommDeleteAllowancessecond = new SqlCommand(@"
                Delete from db_owner.AllowancesSecond 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);
                
                    sqlCommDeletDeductions1st = new SqlCommand(@"
                Delete from db_owner.DeductionsFirst 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);
                
                    sqlCommDeletDeductions2nd = new SqlCommand(@"
                Delete from db_owner.DeductionsSecond 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);



                    SqlConn.Open();
                    sqlCommDeleteAllowancesfirst.ExecuteNonQuery();
                    sqlCommDeleteAllowancessecond.ExecuteNonQuery();
                    sqlCommDeletDeductions1st.ExecuteNonQuery();
                    sqlCommDeletDeductions2nd.ExecuteNonQuery();
                    SqlConn.Close();
                    InitialListViewEmployees();
                }

                sqlCommDeleteAllowancesfirst = new SqlCommand(@"
                ALTER TABLE AllowancesFirst NOCHECK CONSTRAINT ALL
                 ALTER TABLE AllowancesSecond NOCHECK CONSTRAINT ALL
                 ALTER TABLE DeductionsFirst NOCHECK CONSTRAINT ALL
                 ALTER TABLE DeductionsSecond NOCHECK CONSTRAINT ALL
                delete from employees where empid ='" + this.EmpID + "' " +
                @"ALTER TABLE AllowancesFirst CHECK CONSTRAINT ALL
                ALTER TABLE AllowancesSecond CHECK CONSTRAINT ALL
                ALTER TABLE DeductionsFirst CHECK CONSTRAINT ALL
                ALTER TABLE DeductionsSecond CHECK CONSTRAINT ALL

                ", SqlConn);
                try
                {
                    SqlConn.Open();
                    sqlCommDeleteAllowancesfirst.ExecuteNonQuery();
                  InitialListViewEmployees();
                    MessageBox.Show("تم الحذف", "تنبيه", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("لم يتم الحذف" + ex.Message.ToString(), "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
                finally
                {
                 
                    SqlConn.Close();
                }

                DateTime HiringDate = dtpHireDate.Value.AddDays(-1);
                DateTime EndDate = dtpEndDate.Value.AddDays(1);

                SqlCommand sqlCommDeletAttendance1st = new SqlCommand(@"
                Delete from db_owner.AttendanceFirst 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and التاريخ between '"+new DateTime(2013,1,1)+"' and "+
                 @"'"+HiringDate.Date+"' "+
                @"Delete from db_owner.AttendanceFirst 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and التاريخ between '" + EndDate.Date + "' and " +
                 @"'" + new DateTime(2013, 12, 31) + "'", SqlConn);

                SqlCommand sqlCommDeletAttendance2nd = new SqlCommand(@"
                Delete from db_owner.AttendanceSecond
          where رقم_الموظف='" + this.EmpID + "' " +
                @"and التاريخ between '" + new DateTime(2013, 1, 1) + "' and " +
                 @"'" + HiringDate.Date + "' " +
                @"Delete from db_owner.AttendanceSecond 
                where رقم_الموظف='" + this.EmpID + "' " +
                @"and التاريخ between '" + EndDate.Date + "' and " +
                 @"'" + new DateTime(2013, 12, 31) + "'", SqlConn);

               try
                {
                    SqlConn.Open();
                    sqlCommDeletAttendance1st.ExecuteNonQuery();
                    sqlCommDeletAttendance2nd.ExecuteNonQuery();
              InitialListViewEmployees();
                    MessageBox.Show("تم الحذف", "تنبيه", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("لم يتم الحذف" + ex.Message.ToString(), "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
                finally
                {
                    sqlCommDeletAttendance1st.Dispose();
                    sqlCommDeletAttendance2nd.Dispose();
                  
                    SqlConn.Close();
                }
            }
            //            SELECT 
            //    -- add these two columns:
            //    [Schema] = OBJECT_SCHEMA_NAME(pt.parent_object_id),
            //    [Table] = OBJECT_NAME(pt.parent_object_id),
            //    FK = OBJECT_NAME(pt.constraint_object_id),
            //    Referencing_col = pc.name, 
            //    Referenced_col = rc.name
            //FROM sys.foreign_key_columns AS pt
            //INNER JOIN sys.columns AS pc
            //ON pt.parent_object_id = pc.[object_id]
            //AND pt.parent_column_id = pc.column_id
            //INNER JOIN sys.columns AS rc
            //ON pt.referenced_column_id = rc.column_id
            //AND pt.referenced_object_id = rc.[object_id]
            //WHERE pt.referenced_object_id = OBJECT_ID('Hr.db_owner.Employees');
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                txtFileID.Text = this.listView1.SelectedItems[0].Text;
                txtEmployeeName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                adGetEmployee = new SqlDataAdapter(@"select EmpHiringDateID from db_owner.Employees
            where EmpID = '" + txtFileID.Text + "'", SqlConn);
                dtGetEmployee = new DataTable();
                try
                {
                    adGetEmployee.Fill(dtGetEmployee);
                    DataRow EmployeeRow = dtGetEmployee.Rows[0];
                    dtpHireDate.Value = Convert.ToDateTime(EmployeeRow[0]);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
                finally
                {
                    adGetEmployee.Dispose();
                    dtGetEmployee.Dispose();
                    SqlConn.Close();
                }
            }
        }
    }
}