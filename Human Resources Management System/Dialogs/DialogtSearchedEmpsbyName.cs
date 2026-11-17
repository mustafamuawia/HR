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
    public partial class DialogtSearchedEmpsbyName : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        List<string> JobAndDept = new List<string>();

        //Get department name and job by using job ID
        string frm;
     
        public DialogtSearchedEmpsbyName(List<EmpName_Dept_Job> EmployeesMatchedNames)
        {
            InitializeComponent();
       

            for (int Index = 0; Index < EmployeesMatchedNames.Count; Index++)
            {
                dgvMatchedNames.Rows.Add(EmployeesMatchedNames[Index].EmpName,
                    EmployeesMatchedNames[Index].EmpDept, EmployeesMatchedNames[Index].EmpJob);
            }

        }

        public DialogtSearchedEmpsbyName(DataTable dtEmployees,string FormName)
        {
            InitializeComponent();
            for (int Index = 0; Index < dtEmployees.Rows.Count; Index++)
            {
                dgvMatchedNames.Rows.Add(Convert.ToString(dtEmployees.Rows[Index][1]),
                    Convert.ToString(dtEmployees.Rows[Index][2]), Convert.ToString(dtEmployees.Rows[Index][3])
                    , Convert.ToString(dtEmployees.Rows[Index][4]));
            }
            frm = FormName;
        }
        private void DialogEditJob_Load(object sender, EventArgs e)
        {


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (this.dgvMatchedNames.SelectedRows.Count > 0)
            {
                switch (frm)
                {
                    case "frmEditEmployeeFile":
                        {
                            frmEditEmployeeFile frmEditEmpFile = (frmEditEmployeeFile)Application.OpenForms["frmEditEmployeeFile"];
                            frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                            frmEditEmpFile.btnNameSearch_Click(sender, e);
                            this.Close();
                        }
                        break;
                    case "frmEditMedicalForm":
                        {
                            frmEditMedicalForm frmEditEmpFile = (frmEditMedicalForm)Application.OpenForms["frmEditMedicalForm"];
                            frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                            frmEditEmpFile.btnNameSearch_Click(sender, e);
                            this.Close();
                        }
                        break;

                    case "frmAddMedicalForm":
                        {
                            frmAddMedicalForm frmEditEmpFile = (frmAddMedicalForm)Application.OpenForms["frmMedicalForm"];
                            frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                            frmEditEmpFile.btnNameSearch_Click(sender, e);
                            this.Close();
                        }
                        break;
                    case "frmAddVacation":
                        {
                            frmAddVacation frmEditEmpFile = (frmAddVacation)Application.OpenForms["frmAddVacation"];
                            frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                            frmEditEmpFile.btnNameSearch_Click(sender, e);
                            this.Close();
                        }
                        break;
                
                }

            }
                //frmEditEmployeeFile frmEditEmpFile = (frmEditEmployeeFile)Application.OpenForms["frmEditEmployeeFile"];
                //frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                //frmEditEmpFile.btnNameSearch_Click(sender, e);
                //this.Close();
            
        }

        private void dgvMatchedNames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMatchedNames.SelectedRows.Count > 0)
            {
                switch (frm)
                {
                    case "frmEditEmployeeFile":
                        {
                            frmEditEmployeeFile frmEditEmpFile = (frmEditEmployeeFile)Application.OpenForms["frmEditEmployeeFile"];
                            frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                            frmEditEmpFile.btnNameSearch_Click(sender, e);
                            this.Close();
                        }
                        break;
                    case "frmEditMedicalForm":
                        {
                            frmEditMedicalForm frmEditEmpFile = (frmEditMedicalForm)Application.OpenForms["frmEditMedicalForm"];
                            frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                            frmEditEmpFile.btnNameSearch_Click(sender, e);
                            this.Close();
                        }
                        break;
                }

            }
            //if (this.dgvMatchedNames.SelectedRows.Count > 0)
            //{
            //    frmEditEmployeeFile frmEditEmpFile = (frmEditEmployeeFile)Application.OpenForms["frmEditEmployeeFile"];
            //    frmEditEmpFile.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
            //    frmEditEmpFile.btnNameSearch_Click(sender, e);
            //    this.Close();
            //}
        }
    }
}
