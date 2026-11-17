using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace HR_MS
{
    public partial class DialogEditLoanDeduction : Adjust
    {
        CultureInfo ArabicEgypt = new CultureInfo("ar-EG");
        public DialogEditLoanDeduction(string Month, string MonthHalfDeduction, string MonthEndDeduction)
        {
            InitializeComponent();
            this.cbMonths.Text = Month;
            this.txtMonthHalfDeduction.Text = MonthHalfDeduction.ToString();
            this.txtMonthEndDeduction.Text = MonthEndDeduction.ToString();
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

        private void DialogEditPanaltyDeduction_Load(object sender, EventArgs e)
        {
            this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frmEditLoans frmEdtLoans = (frmEditLoans)Application.OpenForms["frmEditLoans"];
            frmEdtLoans.listView1.SelectedItems[0].Text = this.cbMonths.Text;
            frmEdtLoans.listView1.SelectedItems[0].SubItems[1].Text = this.txtMonthHalfDeduction.Text;
            frmEdtLoans.listView1.SelectedItems[0].SubItems[2].Text = this.txtMonthEndDeduction.Text;
            this.Close();
        }
    }
}
