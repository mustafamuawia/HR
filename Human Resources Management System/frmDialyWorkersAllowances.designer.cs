namespace HR_MS
{
    partial class frmDialyWorkersAllowances
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAllowances = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdateAllowances = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetMonthSalaries = new System.Windows.Forms.Button();
            this.cbMonths = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllowances)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllowances
            // 
            this.dgvAllowances.AllowUserToAddRows = false;
            this.dgvAllowances.AllowUserToDeleteRows = false;
            this.dgvAllowances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAllowances.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllowances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllowances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllowances.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAllowances.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvAllowances.Location = new System.Drawing.Point(23, 12);
            this.dgvAllowances.MultiSelect = false;
            this.dgvAllowances.Name = "dgvAllowances";
            this.dgvAllowances.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAllowances.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllowances.RowTemplate.Height = 30;
            this.dgvAllowances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAllowances.Size = new System.Drawing.Size(609, 342);
            this.dgvAllowances.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(509, 437);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 37);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdateAllowances
            // 
            this.btnUpdateAllowances.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAllowances.Location = new System.Drawing.Point(60, 437);
            this.btnUpdateAllowances.Name = "btnUpdateAllowances";
            this.btnUpdateAllowances.Size = new System.Drawing.Size(127, 37);
            this.btnUpdateAllowances.TabIndex = 1;
            this.btnUpdateAllowances.Text = "تعديل";
            this.btnUpdateAllowances.UseVisualStyleBackColor = true;
            this.btnUpdateAllowances.Click += new System.EventHandler(this.btnUpdateAllowances_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(215, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetMonthSalaries
            // 
            this.btnGetMonthSalaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetMonthSalaries.Location = new System.Drawing.Point(215, 376);
            this.btnGetMonthSalaries.Name = "btnGetMonthSalaries";
            this.btnGetMonthSalaries.Size = new System.Drawing.Size(127, 37);
            this.btnGetMonthSalaries.TabIndex = 1;
            this.btnGetMonthSalaries.Text = "اختيار الشهر";
            this.btnGetMonthSalaries.UseVisualStyleBackColor = true;
            this.btnGetMonthSalaries.Click += new System.EventHandler(this.btnGetMonthSalaries_Click);
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
            this.cbMonths.Location = new System.Drawing.Point(66, 381);
            this.cbMonths.Name = "cbMonths";
            this.cbMonths.Size = new System.Drawing.Size(121, 27);
            this.cbMonths.TabIndex = 2;
            // 
            // frmDialyWorkersAllowances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 500);
            this.Controls.Add(this.cbMonths);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGetMonthSalaries);
            this.Controls.Add(this.btnUpdateAllowances);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvAllowances);
            this.Name = "frmDialyWorkersAllowances";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ضبط العلاوات";
            this.Load += new System.EventHandler(this.frmEmployeesSalaries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllowances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllowances;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdateAllowances;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetMonthSalaries;
        private System.Windows.Forms.ComboBox cbMonths;
    }
}