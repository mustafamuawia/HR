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
    public partial class DialogLoansSearch : Adjust
    {
        CultureInfo ArabicEgypt = new CultureInfo("en-US");
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        public DialogLoansSearch(DataTable Loans)
        {
            InitializeComponent();
            foreach (DataRow LoanRow in Loans.Rows)
            {
                string strGetLoans = @"SELECT Loans.LoanID, Employees.EmpName, Loans.Date,
                Loans.DeductionsTotal, Loans.Note
                FROM Employees INNER JOIN
                Loans ON Employees.EmpID = Loans.EmpID
                where Loans.LoanID= '" + LoanRow["LoanID"].ToString() + "'";

                SqlDataAdapter daGetLoans = new SqlDataAdapter(strGetLoans, SqlConn);
                DataTable dtGetLoans = new DataTable();
                daGetLoans.Fill(dtGetLoans);
                for (int i=0;i<dtGetLoans.Rows.Count;i++)
                {
                    DataRow row = dtGetLoans.Rows[i];
                    dgvMatchedNames.Rows.Add(row["LoanID"].ToString(), row["EmpName"].ToString(),
                    DateTime.Parse(row["Date"].ToString()).ToShortDateString(), double.Parse(row["DeductionsTotal"].ToString()).ToString("0,0.00", ArabicEgypt), row["Note"].ToString());
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dgvMatchedNames.SelectedRows.Count > 0)
            {
                frmEditLoans frmEdtLoans = (frmEditLoans)Application.OpenForms["frmEditLoans"];
                SqlDataAdapter daGetLoanDeductions = new SqlDataAdapter(@"Select Month,MonthHalfDedction
                ,MonthEndDedction
            from db_Owner.LoansDeductions
            where LoanID= '" + dgvMatchedNames.SelectedRows[0].Cells[0].Value.ToString()+ "'", SqlConn);
                DataTable dtGetLoanDeductions = new DataTable();
                daGetLoanDeductions.Fill(dtGetLoanDeductions);
                for (int i = 0; i < dtGetLoanDeductions.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(dtGetLoanDeductions.Rows[i]["Month"].ToString());
                    lv.SubItems.Add(double.Parse(dtGetLoanDeductions.Rows[i]["MonthHalfDedction"].ToString()).ToString("0,0.00", ArabicEgypt));
                    lv.SubItems.Add(double.Parse(dtGetLoanDeductions.Rows[i]["MonthEndDedction"].ToString()).ToString("0,0.00", ArabicEgypt));
                    frmEdtLoans.listView1.Items.Add(lv);
                }
                frmEdtLoans.dtpDate.Value = Convert.ToDateTime(dgvMatchedNames.SelectedRows[0].Cells[2].Value);
                frmEdtLoans.LoanID = Convert.ToInt32(dgvMatchedNames.SelectedRows[0].Cells[0].Value.ToString());
                frmEdtLoans.txtLoanID.Text = Convert.ToInt32(dgvMatchedNames.SelectedRows[0].Cells[0].Value).ToString();
                frmEdtLoans.txtDeductionTotal.Text = dgvMatchedNames.SelectedRows[0].Cells[3].Value.ToString();
                frmEdtLoans.txtNote.Text = dgvMatchedNames.SelectedRows[0].Cells[4].Value.ToString();
                frmEdtLoans.btnNameSearch_Click(sender, e);
                frmEdtLoans.btnEditLoan.Enabled = true;
                this.Close();
            }
        }

        private void DialogLoansSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
