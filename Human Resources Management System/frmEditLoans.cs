using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
namespace HR_MS
{
    public partial class frmEditLoans : Adjust
    {
        CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
                public Image PersonalPicture;
                public int EmpID;
                public int LoanID;
                double DeductionTotal;
                public frmEditLoans()
        {
            InitializeComponent();
        }

        private Image ByteArrayToImage(byte[] ImageBytesFromDatabase)
        {
            MemoryStream ms = new MemoryStream(ImageBytesFromDatabase);
            Image PersonalPicture = Image.FromStream(ms);
            return PersonalPicture;
        }

        private void ClearInformationControls()
        {
            this.txtLoanID.Clear();
            listView1.Items.Clear();
     
       }
        
        private void btnNewFileIDSearch_Click(object sender, EventArgs e)
             {
                 this.txtEmpName.Clear();
                 this.txtFileID.Clear();
        }

        private void EnableInformationControls()
        {
            this.cbMonths.Enabled = true;
            this.listView1.Enabled = true;
            this.btnDeleteDeduction.Enabled = true;
            this.btnAddDedction.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnExit.Enabled = true;
            this.btnClear.Enabled = true;
            //this.dtpDate;
            //this.textBox1;
            this.txtMonthEndDeduction.Enabled = true;
            this.txtMonthHalfDeduction.Enabled = true;
            this.txtDeductionTotal.Enabled = true;
            this.btnAddPanalty.Enabled = true;
            this.txtNote.Enabled = true;
            this.btnCancel.Enabled = true;
        }
        private void DisableInformationControls()
        {
            this.cbMonths.Enabled = false;
            
            this.listView1.Enabled = false;
            this.btnDeleteDeduction.Enabled = false;
            this.btnAddDedction.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnExit.Enabled = false;
            this.btnClear.Enabled = false;
            //this.dtpDate;
            //this.textBox1;
            this.txtMonthEndDeduction.Enabled = false;
            this.txtMonthHalfDeduction.Enabled = false;
            this.txtDeductionTotal.Enabled = false;
            this.btnAddPanalty.Enabled = false;
            this.txtNote.Enabled = false;
        }

        public void btnNameSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetEmpFilebyName = new SqlDataAdapter("SELECT  EmpID,EmpName," +
             @"EmpGender, EmpJobID, EmpNationality," +
             @"EmpAddress, EmpMobilePhoneNo, EmpEmailAddress," +
             @"EmpPicture, EmpHiringDateID, EmpStatus " +
             @"FROM  db_owner.Employees where EmpName LIKE ('%" + this.txtEmpName.Text + "%')", SqlConn);
            DataTable dtGetEmpFilebyName = new DataTable();
            daGetEmpFilebyName.Fill(dtGetEmpFilebyName);
            if (dtGetEmpFilebyName.Rows.Count == 1)
            {
                //GetDepartmentAndJob(Convert.ToInt32(dtGetEmpFilebyName.Rows[0]["EmpJobID"]));
                this.EmpID = (int)dtGetEmpFilebyName.Rows[0]["EmpId"];
                this.txtFileID.Text = dtGetEmpFilebyName.Rows[0]["EmpID"].ToString();
                this.txtEmpName.Text = dtGetEmpFilebyName.Rows[0]["EmpName"].ToString();
                this.picbPersonalPicure.Image = ByteArrayToImage((byte[])dtGetEmpFilebyName.Rows[0]["EmpPicture"]);
                string SqlComm = @"SELECT JobDepartmentID, JobAdministarionID
                    FROM Jobs 
                    where jobid ='" + dtGetEmpFilebyName.Rows[0]["EmpJobID"].ToString() + "'";
                SqlDataAdapter daGetAdministrationdAndDepartment = new SqlDataAdapter(SqlComm, SqlConn);
                DataTable dtGetAdministrationdAndDepartment = new DataTable();
                daGetAdministrationdAndDepartment.Fill(dtGetAdministrationdAndDepartment);
                if (dtGetAdministrationdAndDepartment.Rows.Count != 0)
                {
                                     
                    if (dtGetAdministrationdAndDepartment.Rows[0]["JobDepartmentID"] != DBNull.Value
                        && dtGetAdministrationdAndDepartment.Rows[0]["JobAdministarionID"] == DBNull.Value)
                    {
                        string sqlSelect = @"SELECT Departments.DeptName, Administrations.AdministrationName, 
                            Jobs.JobName FROM Administrations INNER JOIN
                            Departments ON Administrations.AdministrationID = Departments.AdminDepID INNER JOIN
                            Jobs ON Departments.DeptID = Jobs.JobDepartmentID
                           where jobid ='" + dtGetEmpFilebyName.Rows[0]["EmpJobID"].ToString() + "' ";
                        daGetAdministrationdAndDepartment = new SqlDataAdapter(sqlSelect, SqlConn);
                        dtGetAdministrationdAndDepartment = new DataTable();
                        daGetAdministrationdAndDepartment.Fill(dtGetAdministrationdAndDepartment);


                        DataRow JobAdministrationDepartment = dtGetAdministrationdAndDepartment.Rows[0];
                    }
                    else if (dtGetAdministrationdAndDepartment.Rows[0]["JobDepartmentID"] == DBNull.Value
                        && dtGetAdministrationdAndDepartment.Rows[0]["JobAdministarionID"] != DBNull.Value)
                    {
                        string sqlSelect = @"SELECT Jobs.JobName, Administrations.AdministrationName
                            FROM Jobs INNER JOIN
                            Administrations ON Jobs.JobAdministarionID = Administrations.AdministrationID
                            where jobid ='" + dtGetEmpFilebyName.Rows[0]["EmpJobID"].ToString() + "' ";
                        daGetAdministrationdAndDepartment = new SqlDataAdapter(sqlSelect, SqlConn);
                        dtGetAdministrationdAndDepartment = new DataTable();
                        daGetAdministrationdAndDepartment.Fill(dtGetAdministrationdAndDepartment);

                        DataRow JobAdministrationDepartment;
                        if (dtGetAdministrationdAndDepartment.Rows.Count != 0)
                        {
                            JobAdministrationDepartment = dtGetAdministrationdAndDepartment.Rows[0];
                            //this.cbSubDepartments.Text = JobAdministrationDepartment["DeptName"].ToString();
                        }
                    }
                }
                //if (dtGetAdministrationdAndDepartment.Rows.Count != 0)
                //{
                //    this.cbAdministrations.Text = dtGetAdministrationdAndDepartment.Rows[0]["DeptName"].ToString();
                //    this.cbJob.Text = dtGetAdministrationdAndDepartment.Rows[0]["JobName"].ToString();
                //}


                //Disable Controls
                this.txtEmpName.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnSearch.Enabled = true;
                this.btnFileIDSearch.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnSearch.Enabled = true;
                this.txtEmpName.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnAddPanalty.Enabled = true;
            }
            else if (dtGetEmpFilebyName.Rows.Count > 1)
            {
                List<EmpName_Dept_Job> Employees = new List<EmpName_Dept_Job>();

                foreach (DataRow EmpRow in dtGetEmpFilebyName.Rows)
                {
                    string SqlComm = @"SELECT db_owner.Jobs.JobName, db_owner.Departments.DeptName
                        FROM db_owner.Employees INNER JOIN
                        db_owner.Jobs ON db_owner.Employees.EmpJobID = db_owner.Jobs.JobID INNER JOIN
                        db_owner.Departments ON db_owner.Jobs.JobDepartmentID
                        = db_owner.Departments.DeptID 
                        where EmpName='" + EmpRow["EmpName"].ToString() + "'";
                    SqlDataAdapter daGetDepartment = new SqlDataAdapter(SqlComm, SqlConn);
                    DataTable dtGetDepartment = new DataTable();
                    daGetDepartment.Fill(dtGetDepartment);
                    EmpName_Dept_Job Emp = new EmpName_Dept_Job();
                    Emp.EmpName = EmpRow["EmpName"].ToString();
                    if (dtGetDepartment.Rows.Count != 0)
                    {
                        Emp.EmpDept = dtGetDepartment.Rows[0]["DeptName"].ToString();
                        Emp.EmpJob = dtGetDepartment.Rows[0]["JobName"].ToString();
                    }
                    Employees.Add(Emp);
                }
                DialogEditSearchedEmpsbyNameLoans DialogMatchedNames = new DialogEditSearchedEmpsbyNameLoans(Employees);
                DialogMatchedNames.ShowDialog();
                Employees.Clear();
            }


            else MessageBox.Show("لا يوجد موظف بهذا الاسم");
        }

        private void btnFileIDSearch_Click(object sender, EventArgs e)
        {
            if (this.txtFileID.Text == "") MessageBox.Show("الرجاء إضافة رقم الملف للبحث عنه");
            else
            {
                SqlDataAdapter daGetEmpFilebyID = new SqlDataAdapter("SELECT EmpID," +
                    @"EmpName, EmpGender," +
                    @"EmpNationality, EmpAddress," +
                    @"EmpMobilePhoneNo, EmpEmailAddress, " +
                    @"EmpPicture, EmpHiringDateID " +
                    @" FROM db_owner.Employees " +
                    @"where EmpID =" + this.txtFileID.Text + "", SqlConn);
                DataTable dtGetEmpFilebyID = new DataTable();
                daGetEmpFilebyID.Fill(dtGetEmpFilebyID);
                if (dtGetEmpFilebyID.Rows.Count == 1)
                {
                    this.EmpID = (int)dtGetEmpFilebyID.Rows[0]["EmpId"];
                    this.txtFileID.Enabled = false;

                    this.txtEmpName.Text = dtGetEmpFilebyID.Rows[0]["EmpName"].ToString();
                 
                    string SqlComm = @"SELECT db_owner.Jobs.JobName, db_owner.Departments.DeptName
                        FROM db_owner.Employees INNER JOIN
                        db_owner.Jobs ON db_owner.Employees.EmpJobID = db_owner.Jobs.JobID INNER JOIN
                        db_owner.Departments ON db_owner.Jobs.JobDepartmentID
                        = db_owner.Departments.DeptID 
                        where EmpID=" + dtGetEmpFilebyID.Rows[0]["EmpId"].ToString() + "";
                    SqlDataAdapter daGetDepartment = new SqlDataAdapter(SqlComm, SqlConn);
                    DataTable dtGetDepartment = new DataTable();
                    daGetDepartment.Fill(dtGetDepartment);
                   
                    this.picbPersonalPicure.Image = ByteArrayToImage((byte[])dtGetEmpFilebyID.Rows[0]["EmpPicture"]);
                    this.txtEmpName.Enabled = false;
                    this.txtFileID.Clear();
                    this.txtEmpName.Clear();
                    this.txtIncentive.Clear();
                    this.btnNameSearch.Enabled = false;
                    this.btnSearch.Enabled = true;
                    this.btnAddPanalty.Enabled = true;
                }
                else MessageBox.Show("لا يوجد ملف بهذا الرقم");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearInformationControls();
            this.picbPersonalPicure.Image = Properties.Resources.Picture;
            this.txtFileID.Enabled = true;
            this.txtFileID.Clear();
            this.btnNameSearch.Enabled = true;
            this.btnFileIDSearch.Enabled = true;
            this.txtEmpName.Enabled = true;
            this.txtEmpName.Clear();
            this.PersonalPicture = null;
            this.btnSearch.Enabled = false;
            this.btnAddPanalty.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnCancel.Enabled = false;
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            this.txtDeductionTotal.Clear();
            this.txtMonthHalfDeduction.Clear();
            this.txtMonthEndDeduction.Clear();
            this.listView1.Items.Clear();
        }

        private void frmPenalty_Load(object sender, EventArgs e)
        {
        }

        private void btnAddPanalty_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetLoanID = new SqlDataAdapter(@"Select LoanID,Date,DeductionsTotal,Note
            from db_Owner.loans
            where EmpID= '" +this.EmpID.ToString()+"'", SqlConn);
            DataTable dtGetLoanID = new DataTable();
            daGetLoanID.Fill(dtGetLoanID);
            if (dtGetLoanID.Rows.Count == 1)
            {
                this.LoanID = (int)dtGetLoanID.Rows[0]["LoanID"];
                this.txtLoanID.Text = LoanID.ToString();
                this.txtNote.Text = dtGetLoanID.Rows[0]["LoanID"].ToString();
                this.txtDeductionTotal.Text = dtGetLoanID.Rows[0]["DeductionsTotal"].ToString();
                this.dtpDate.Value = Convert.ToDateTime(dtGetLoanID.Rows[0]["Date"]).Date;

                SqlDataAdapter daGetPanaltyDeductions = new SqlDataAdapter(@"Select Month,MonthHalfDedction
                ,MonthEndDedction
            from db_Owner.LoansDeductions
            where LoanID= '" + dtGetLoanID.Rows[0]["LoanID"].ToString() + "'", SqlConn);
                DataTable dtGetPanaltyDeductions = new DataTable();
                daGetPanaltyDeductions.Fill(dtGetPanaltyDeductions);
                for (int i = 0; i < dtGetPanaltyDeductions.Rows.Count;i++)
                {
                    ListViewItem lv = new ListViewItem(dtGetPanaltyDeductions.Rows[i]["Month"].ToString());
                    lv.SubItems.Add(dtGetPanaltyDeductions.Rows[i]["MonthHalfDedction"].ToString());
                    lv.SubItems.Add(dtGetPanaltyDeductions.Rows[i]["MonthEndDedction"].ToString());
                    listView1.Items.Add(lv);
                }
                    
                    
                this.txtEmpName.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnSearch.Enabled = true;
                this.btnFileIDSearch.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnSearch.Enabled = true;
                this.txtEmpName.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnAddPanalty.Enabled = true;
                this.btnEditLoan.Enabled = true;
            }
            else if (dtGetLoanID.Rows.Count > 1)
            {
                DialogLoansSearch DialogMatchedNamesLoans = new DialogLoansSearch(dtGetLoanID);
                DialogMatchedNamesLoans.ShowDialog();
                
            }


            else MessageBox.Show("لا توجد مخالفات");
            //EnableInformationControls();
            //ClearInformationControls();
            //txtLoanID.Text = LoanID.ToString();
            //this.btnAddPanalty.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (listView1.Items.Count == 0)
                MessageBox.Show("الرجاء إضافة جدولة للمخالفة");
            else if (MessageBox.Show("هل تود تعديل المخالفة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string strDeletePanalty = @"delete from db_owner.LoansDeductions where LoanID = '" + LoanID + "'";
                    SqlCommand sqlDeletePanalty = new SqlCommand(strDeletePanalty, SqlConn);
                    try
                    {
                        SqlConn.Open();
                        sqlDeletePanalty.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        SqlConn.Close();
                    }

                    for (int index = 0; index < listView1.Items.Count; index++)
                    {
                        string sqlIns = @"insert into db_owner.LoansDeductions
                    Values('" + this.listView1.Items[index].SubItems[0].Text + "', " +
                                   @"'" + this.listView1.Items[index].SubItems[1].Text + "', " +
                                @"'" + this.listView1.Items[index].SubItems[2].Text + "', " +
                                 @"'" + this.txtLoanID.Text + "')";

                        SqlConn.Open();
                        try
                        {
                            SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);

                            cmdIns.ExecuteNonQuery();
                            cmdIns.Dispose();

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
                    this.btnAddPanalty.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.btnClear.Enabled = false;
                    this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                    this.txtDeductionTotal.Clear();
                    this.txtMonthHalfDeduction.Clear();
                    this.txtMonthEndDeduction.Clear();
                    this.listView1.Items.Clear();
                    gbPersonalInformation.Enabled = true;
                    MessageBox.Show("تم الحفظ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
            

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInformationControls();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddDedction_Click(object sender, EventArgs e)
        {
            DeductionTotal = 0;
            if (txtMonthHalfDeduction.Text == "" && txtMonthEndDeduction.Text == "")
            {
                MessageBox.Show("الرجاء تحديد مبالغ الاستقطاع");
                txtMonthHalfDeduction.Focus();
            }
            else
            {
                ListViewItem lv = new ListViewItem(this.cbMonths.Text);
                if (txtMonthHalfDeduction.Text == "")
                    lv.SubItems.Add("0");
                else
                    lv.SubItems.Add(Convert.ToInt32(txtMonthHalfDeduction.Text).ToString());
                if (txtMonthEndDeduction.Text == "")
                    lv.SubItems.Add("0");
                else
                    lv.SubItems.Add(Convert.ToInt32(txtMonthEndDeduction.Text).ToString());

                listView1.Items.Add(lv);
                int index = this.cbMonths.Items.IndexOf(this.cbMonths.Text);
                if (this.cbMonths.Text != "ديسمبر")
                {
                    this.cbMonths.Text = this.cbMonths.Items[index + 1].ToString();
                }

                for (int i = 0; i < listView1.Items.Count; i++)
                {

                    DeductionTotal += Convert.ToDouble(listView1.Items[i].SubItems[1].Text);
                    DeductionTotal += Convert.ToDouble(listView1.Items[i].SubItems[2].Text);
                }
                this.txtDeductionTotal.Text = DeductionTotal.ToString();
            }
        }

        private void btnDeleteDeduction_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count !=0)
                listView1.SelectedItems[0].Remove();
        }

        private void txtMonthHalfDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.')
                if (e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMonthEndDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.')
                if (e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDeductionTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.')
                if (e.Handled = !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnAddDedction.Enabled = false;
            this.btnDeleteDeduction.Enabled = false;
            this.btnAddPanalty.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnDeleteDeduction.Enabled = false;
            this.btnClear.Enabled = false;
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            this.txtDeductionTotal.Text = "";
            this.txtMonthHalfDeduction.Text = "";
            this.txtMonthEndDeduction.Text = "";
            this.listView1.Items.Clear();
        }

        private void btnEditDeductions_Click(object sender, EventArgs e)
        {
            DialogEditLoanDeduction EditPanaltyDeduction = new DialogEditLoanDeduction(
                this.listView1.SelectedItems[0].Text,
            this.listView1.SelectedItems[0].SubItems[1].Text,
            this.listView1.SelectedItems[0].SubItems[2].Text);
            EditPanaltyDeduction.ShowDialog();
        }

        private void btnEditPanalty_Click(object sender, EventArgs e)
        {
            this.btnAddDedction.Enabled = true;
            this.btnDeleteDeduction.Enabled = true;
            this.btnAddPanalty.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnClear.Enabled = true;
            this.btnDeleteDeduction.Enabled = true;
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            //this.txtDeductionTotal.Enabled = true;
            this.cbMonths.Enabled = true;
            this.btnEditDeductions.Enabled = true;
            this.txtMonthHalfDeduction.Enabled = true;
            this.txtMonthEndDeduction.Enabled = true;
            this.listView1.Enabled = true;
        }

    
    }
}
