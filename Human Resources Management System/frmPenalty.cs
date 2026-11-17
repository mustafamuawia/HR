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
    public partial class frmPenalty : Adjust
    {
        CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
                public Image PersonalPicture;
                public int EmpID;
                public int PanaltyID;
                double DeductionTotal;
        public frmPenalty()
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
            this.txtPanaltyID.Clear();
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

                //MessageBox.Show("يوجد أكثر من موظف بهذا الاسم");
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
                DialogSearchedEmpsbyNamePanalties DialogMatchedNames = new DialogSearchedEmpsbyNamePanalties(Employees);
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
            dtpDate.Value = DateTime.Now.Date;
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            this.txtDeductionTotal.Clear();
            this.txtMonthHalfDeduction.Clear();
            this.txtMonthEndDeduction.Clear();
            this.listView1.Items.Clear();
        }

        private void frmPenalty_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now.Date;
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        }

        private void btnAddPanalty_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetEmpID = new SqlDataAdapter("Select PanaltyID from db_Owner.Panalties", SqlConn);
            DataTable dtGetEmpID = new DataTable();
            daGetEmpID.Fill(dtGetEmpID);
            if (dtGetEmpID.Rows.Count == 0)
            {
                PanaltyID = 1;
            }
            else
            {
                PanaltyID = Convert.ToInt32(dtGetEmpID.Rows[dtGetEmpID.Rows.Count-1][0].ToString()) + 1;
            }

            foreach (Control ctrl in gbPersonalInformation.Controls)
            {
                //gbPersonalInformation.Enabled = false;
                if (ctrl.Name != this.btnSearch.Name)
                    ctrl.Enabled = false;
            }
            
            EnableInformationControls();
            ClearInformationControls();
            txtPanaltyID.Text = PanaltyID.ToString();
            this.btnAddPanalty.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (listView1.Items.Count == 0)
                MessageBox.Show("الرجاء إضافة جدولة للمخالفة");
            else if (MessageBox.Show("هل تود اضافة المخالفة الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string PanaltyInsert = @"insert into db_owner.Panalties
                    Values('" + this.txtPanaltyID.Text + "', " +
                               @"'" + this.txtFileID.Text + "', " +
                               @"'" + this.txtDeductionTotal.Text + "', " +
                                @"'" + this.dtpDate.Value.Date.ToShortDateString() + "', " +
                               @"'" + this.txtNote.Text + "')";

                    SqlConn.Open();
                    try
                    {
                        SqlCommand sqlPanaltyInsert = new SqlCommand(PanaltyInsert, SqlConn);

                        sqlPanaltyInsert.ExecuteNonQuery();
                        sqlPanaltyInsert.Dispose();

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
                        PanaltyInsert = @"insert into db_owner.PanaltiesDeductions
(Month,	MonthHalfDedction,	MonthEndDedction,	PanaltyID) 
                          Values('" + this.listView1.Items[index].SubItems[0].Text + "', " +
                              @"'" + this.listView1.Items[index].SubItems[1].Text + "', " +
                              @"'" + this.listView1.Items[index].SubItems[2].Text + "',"+
                             @"'" + this.txtPanaltyID.Text+ "')";

                    SqlConn.Open();
                    try
                    {
                        SqlCommand sqlPanaltyInsert = new SqlCommand(PanaltyInsert, SqlConn);

                        sqlPanaltyInsert.ExecuteNonQuery();
                        sqlPanaltyInsert.Dispose();

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
                    dtpDate.Value = DateTime.Now.Date;
                   
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
                    lv.SubItems.Add(Convert.ToDouble(txtMonthHalfDeduction.Text).ToString());
                if (txtMonthEndDeduction.Text == "")
                    lv.SubItems.Add("0");
                else
                    lv.SubItems.Add(Convert.ToDouble(txtMonthEndDeduction.Text).ToString());

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

    
    }
}
