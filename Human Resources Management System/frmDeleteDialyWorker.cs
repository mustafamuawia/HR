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
    public partial class frmDeleteDialyWorker : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        SqlDataAdapter adGetEmployee;
        DataTable dtGetEmployee;
        int EmpID;

        public frmDeleteDialyWorker()
        {
            InitializeComponent();
        }

        private void InitialListViewEmployees()
        {
            listView1.Items.Clear();
            adGetEmployee = new SqlDataAdapter(@"select EmpID,EmpName from db_owner.DialyWorkers", SqlConn);
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

                MessageBox.Show(ex.Message);
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
            CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
            if (MessageBox.Show("هل تود حذف الموظف", "تنبيه", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.EmpID  =  Convert.ToInt32(this.listView1.SelectedItems[0].Text);
                SqlCommand sqlCommArchiveInsert = new SqlCommand(@"INSERT INTO DialyWorkersArchive
                (EmpID, EmpName, EmpGender, EmpJobID, EmpNationalityID, EmpAddress, EmpPhoneNo,
                EmpMobilePhoneNo, EmpPicture, EmpHiringDate,EmpEndDate,Reason)
                ((SELECT EmpID, EmpName, EmpGender, EmpJobID, EmpNationalityID, EmpAddress,
                EmpPhoneNo, EmpMobilePhoneNo, EmpPicture, EmpHiringDateID
                FROM DialyWorkers where empid ='" +  this.EmpID + "' ) " +
                @",'"+this.dtpEndDate.Value+"','"+this.txtDeleteReason.Text+"')", SqlConn);

                
                SqlCommand sqlCommDeleteSalaries;
              

                int HiringMonth = dtpHireDate.Value.Month;
                int EndMonth = dtpEndDate.Value.Month;
                for (int i = 1; i < HiringMonth; i++)
                {

                sqlCommDeleteSalaries = new SqlCommand(@"
                Delete from db_owner.DialyWorkersSalaries 
                where رقم_العامل='" + this.EmpID  + "' "+
                    @"and الشهر= '"+ArabicEgypt.DateTimeFormat.GetMonthName(i)+"'", SqlConn);

           

                SqlConn.Open();
                sqlCommDeleteSalaries.ExecuteNonQuery();
                SqlConn.Close();
                
                }

                for (int i = EndMonth + 1; i <= 12; i++)
                {
                    
                
                    sqlCommDeleteSalaries = new SqlCommand(@"
                Delete from db_owner.DialyWorkersSalaries 
                where رقم_العامل='" + this.EmpID  + "' " +
                @"and الشهر= '" + ArabicEgypt.DateTimeFormat.GetMonthName(i) + "'", SqlConn);
               
             


                    SqlConn.Open();
                    sqlCommDeleteSalaries.ExecuteNonQuery();
                    SqlConn.Close();
                    
                }

                sqlCommDeleteSalaries = new SqlCommand(@"
                 ALTER TABLE DialyWorkersSalaries NOCHECK CONSTRAINT ALL
                ALTER TABLE DialyWorkersAttendance NOCHECK CONSTRAINT ALL
                delete from DialyWorkers where empid ='" + this.EmpID  + "' " +
                @"ALTER TABLE DialyWorkersSalaries CHECK CONSTRAINT ALL
                ALTER TABLE DialyWorkersAttendance CHECK CONSTRAINT ALL", SqlConn);
                try
                {
                    SqlConn.Open();
                    sqlCommDeleteSalaries.ExecuteNonQuery();

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

                SqlCommand sqlCommDeleteDialyWorkersAttendance = new SqlCommand(@"
                Delete from db_owner.DialyWorkersAttendance 
                where رقم_العامل='" + this.EmpID  + "' "+
                @"and التاريخ between '"+new DateTime(2013,1,1)+"' and "+
                 @"'"+HiringDate.Date+"' "+
                @"Delete from db_owner.DialyWorkersAttendance 
                where رقم_العامل='" + this.EmpID + "' " +
                @"and التاريخ between '" + EndDate.Date + "' and " +
                 @"'" + new DateTime(2013, 12, 31) + "'", SqlConn);

             
               try
                {
                    SqlConn.Open();
                    sqlCommDeleteDialyWorkersAttendance.ExecuteNonQuery();
              InitialListViewEmployees();
                   
                }
                catch (Exception ex)
                {

                    MessageBox.Show("لم يتم الحذف" + ex.Message.ToString(), "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
                finally
                {
                    sqlCommDeleteDialyWorkersAttendance.Dispose();
                  
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
                adGetEmployee = new SqlDataAdapter(@"select EmpHiringDateID from db_owner.DialyWorkers
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