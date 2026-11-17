namespace HR_MS
{
    partial class DialogEditLoanDeduction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMonths = new System.Windows.Forms.ComboBox();
            this.txtMonthEndDeduction = new System.Windows.Forms.TextBox();
            this.txtMonthHalfDeduction = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbMonths
            // 
            this.cbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonths.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbMonths.FormattingEnabled = true;
            this.cbMonths.Items.AddRange(new object[] {
            "يناير",
            "فبراير",
            "مارس",
            "ابريل",
            "مايو",
            "يونيو",
            "يوليو",
            "اغسطس",
            "سبتمبر",
            "اكتوبر",
            "نوفمبر",
            "ديسمبر"});
            this.cbMonths.Location = new System.Drawing.Point(185, 18);
            this.cbMonths.Name = "cbMonths";
            this.cbMonths.Size = new System.Drawing.Size(127, 27);
            this.cbMonths.TabIndex = 22;
            // 
            // txtMonthEndDeduction
            // 
            this.txtMonthEndDeduction.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMonthEndDeduction.ForeColor = System.Drawing.Color.Black;
            this.txtMonthEndDeduction.Location = new System.Drawing.Point(185, 95);
            this.txtMonthEndDeduction.Name = "txtMonthEndDeduction";
            this.txtMonthEndDeduction.Size = new System.Drawing.Size(104, 27);
            this.txtMonthEndDeduction.TabIndex = 20;
            this.txtMonthEndDeduction.Tag = "0";
            this.txtMonthEndDeduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthEndDeduction_KeyPress);
            // 
            // txtMonthHalfDeduction
            // 
            this.txtMonthHalfDeduction.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMonthHalfDeduction.ForeColor = System.Drawing.Color.Black;
            this.txtMonthHalfDeduction.Location = new System.Drawing.Point(185, 55);
            this.txtMonthHalfDeduction.Name = "txtMonthHalfDeduction";
            this.txtMonthHalfDeduction.Size = new System.Drawing.Size(104, 27);
            this.txtMonthHalfDeduction.TabIndex = 21;
            this.txtMonthHalfDeduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthHalfDeduction_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label16.Location = new System.Drawing.Point(27, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(149, 19);
            this.label16.TabIndex = 17;
            this.label16.Text = "استقطاع آخر الشهر:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label15.Location = new System.Drawing.Point(18, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 19);
            this.label15.TabIndex = 18;
            this.label15.Text = "استقطاع نصف الشهر:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label14.Location = new System.Drawing.Point(119, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 19);
            this.label14.TabIndex = 19;
            this.label14.Text = "الشهر:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(182, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 54);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(57, 147);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 54);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "حفظ";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DialogEditPanaltyDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbMonths);
            this.Controls.Add(this.txtMonthEndDeduction);
            this.Controls.Add(this.txtMonthHalfDeduction);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Name = "DialogEditLoanDeduction";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعديل استقطاع السلفية";
            this.Load += new System.EventHandler(this.DialogEditPanaltyDeduction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMonths;
        private System.Windows.Forms.TextBox txtMonthEndDeduction;
        private System.Windows.Forms.TextBox txtMonthHalfDeduction;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;

    }
}