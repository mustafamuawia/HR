namespace HR_MS
{
    partial class frmLoans
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
            this.gbPersonalInformation = new System.Windows.Forms.GroupBox();
            this.btnNameSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnFileIDSearch = new System.Windows.Forms.Button();
            this.picbPersonalPicure = new System.Windows.Forms.PictureBox();
            this.txtFileID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIncentive = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.txtManagement = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddPanalty = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoanID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDeductionTotal = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.MonthName = new System.Windows.Forms.ColumnHeader();
            this.MonthHalf = new System.Windows.Forms.ColumnHeader();
            this.MonthEnd = new System.Windows.Forms.ColumnHeader();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbMonths = new System.Windows.Forms.ComboBox();
            this.txtMonthHalfDeduction = new System.Windows.Forms.TextBox();
            this.txtMonthEndDeduction = new System.Windows.Forms.TextBox();
            this.btnAddDedction = new System.Windows.Forms.Button();
            this.btnDeleteDeduction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbPersonalInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPersonalPicure)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPersonalInformation
            // 
            this.gbPersonalInformation.Controls.Add(this.btnNameSearch);
            this.gbPersonalInformation.Controls.Add(this.btnSearch);
            this.gbPersonalInformation.Controls.Add(this.btnFileIDSearch);
            this.gbPersonalInformation.Controls.Add(this.picbPersonalPicure);
            this.gbPersonalInformation.Controls.Add(this.txtFileID);
            this.gbPersonalInformation.Controls.Add(this.label1);
            this.gbPersonalInformation.Controls.Add(this.txtIncentive);
            this.gbPersonalInformation.Controls.Add(this.txtSalary);
            this.gbPersonalInformation.Controls.Add(this.txtJob);
            this.gbPersonalInformation.Controls.Add(this.txtManagement);
            this.gbPersonalInformation.Controls.Add(this.label9);
            this.gbPersonalInformation.Controls.Add(this.txtDepartment);
            this.gbPersonalInformation.Controls.Add(this.label11);
            this.gbPersonalInformation.Controls.Add(this.label10);
            this.gbPersonalInformation.Controls.Add(this.label7);
            this.gbPersonalInformation.Controls.Add(this.label8);
            this.gbPersonalInformation.Controls.Add(this.txtEmpName);
            this.gbPersonalInformation.Controls.Add(this.label6);
            this.gbPersonalInformation.Controls.Add(this.label2);
            this.gbPersonalInformation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonalInformation.Location = new System.Drawing.Point(12, 54);
            this.gbPersonalInformation.Name = "gbPersonalInformation";
            this.gbPersonalInformation.Size = new System.Drawing.Size(796, 184);
            this.gbPersonalInformation.TabIndex = 8;
            this.gbPersonalInformation.TabStop = false;
            this.gbPersonalInformation.Text = "بيانات الموظف";
            // 
            // btnNameSearch
            // 
            this.btnNameSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNameSearch.Location = new System.Drawing.Point(367, 65);
            this.btnNameSearch.Name = "btnNameSearch";
            this.btnNameSearch.Size = new System.Drawing.Size(61, 32);
            this.btnNameSearch.TabIndex = 10;
            this.btnNameSearch.Text = "بحث";
            this.btnNameSearch.UseVisualStyleBackColor = true;
            this.btnNameSearch.Click += new System.EventHandler(this.btnNameSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(338, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 30);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "بحث جديد";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnFileIDSearch
            // 
            this.btnFileIDSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileIDSearch.Location = new System.Drawing.Point(473, 29);
            this.btnFileIDSearch.Name = "btnFileIDSearch";
            this.btnFileIDSearch.Size = new System.Drawing.Size(61, 28);
            this.btnFileIDSearch.TabIndex = 10;
            this.btnFileIDSearch.Text = "بحث";
            this.btnFileIDSearch.UseVisualStyleBackColor = true;
            this.btnFileIDSearch.Click += new System.EventHandler(this.btnFileIDSearch_Click);
            // 
            // picbPersonalPicure
            // 
            this.picbPersonalPicure.ErrorImage = null;
            this.picbPersonalPicure.Image = global::HR_MS.Properties.Resources.Picture;
            this.picbPersonalPicure.InitialImage = global::HR_MS.Properties.Resources.Picture;
            this.picbPersonalPicure.Location = new System.Drawing.Point(6, 15);
            this.picbPersonalPicure.Name = "picbPersonalPicure";
            this.picbPersonalPicure.Size = new System.Drawing.Size(124, 144);
            this.picbPersonalPicure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbPersonalPicure.TabIndex = 14;
            this.picbPersonalPicure.TabStop = false;
            // 
            // txtFileID
            // 
            this.txtFileID.ForeColor = System.Drawing.Color.Red;
            this.txtFileID.Location = new System.Drawing.Point(541, 31);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.Size = new System.Drawing.Size(122, 27);
            this.txtFileID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم الملف:";
            // 
            // txtIncentive
            // 
            this.txtIncentive.Enabled = false;
            this.txtIncentive.Location = new System.Drawing.Point(234, 139);
            this.txtIncentive.Name = "txtIncentive";
            this.txtIncentive.Size = new System.Drawing.Size(104, 27);
            this.txtIncentive.TabIndex = 2;
            // 
            // txtSalary
            // 
            this.txtSalary.Enabled = false;
            this.txtSalary.Location = new System.Drawing.Point(558, 136);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(104, 27);
            this.txtSalary.TabIndex = 2;
            // 
            // txtJob
            // 
            this.txtJob.Enabled = false;
            this.txtJob.Location = new System.Drawing.Point(362, 103);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(104, 27);
            this.txtJob.TabIndex = 2;
            // 
            // txtManagement
            // 
            this.txtManagement.Enabled = false;
            this.txtManagement.Location = new System.Drawing.Point(559, 103);
            this.txtManagement.Name = "txtManagement";
            this.txtManagement.Size = new System.Drawing.Size(104, 27);
            this.txtManagement.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "الحافز الشهري:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(172, 106);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(104, 27);
            this.txtDepartment.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(474, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "الوظيفة:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(671, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "الإدارة:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(667, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "الإدارة:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(666, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "جملة المرتب:";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(434, 70);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(229, 27);
            this.txtEmpName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "القسم:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "اسم الموظف:";
            // 
            // btnAddPanalty
            // 
            this.btnAddPanalty.Enabled = false;
            this.btnAddPanalty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPanalty.Location = new System.Drawing.Point(105, 468);
            this.btnAddPanalty.Name = "btnAddPanalty";
            this.btnAddPanalty.Size = new System.Drawing.Size(90, 54);
            this.btnAddPanalty.TabIndex = 10;
            this.btnAddPanalty.Text = "إضافة سلفية";
            this.btnAddPanalty.UseVisualStyleBackColor = true;
            this.btnAddPanalty.Click += new System.EventHandler(this.btnAddPanalty_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(82, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "التاريخ:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(145, 21);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(121, 27);
            this.dtpDate.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(214, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 54);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(546, 468);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 54);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(324, 468);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 54);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "أفرغ الحقول";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(38, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "رقم المخالفة:";
            // 
            // txtLoanID
            // 
            this.txtLoanID.Enabled = false;
            this.txtLoanID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLoanID.ForeColor = System.Drawing.Color.Black;
            this.txtLoanID.Location = new System.Drawing.Point(151, 244);
            this.txtLoanID.Name = "txtLoanID";
            this.txtLoanID.Size = new System.Drawing.Size(122, 27);
            this.txtLoanID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label5.Location = new System.Drawing.Point(63, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "ملاحظات:";
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.Location = new System.Drawing.Point(151, 423);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(290, 27);
            this.txtNote.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.Location = new System.Drawing.Point(293, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "جملة مبلغ الاستقطاع:";
            // 
            // txtDeductionTotal
            // 
            this.txtDeductionTotal.Enabled = false;
            this.txtDeductionTotal.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDeductionTotal.ForeColor = System.Drawing.Color.Black;
            this.txtDeductionTotal.Location = new System.Drawing.Point(470, 244);
            this.txtDeductionTotal.Name = "txtDeductionTotal";
            this.txtDeductionTotal.Size = new System.Drawing.Size(104, 27);
            this.txtDeductionTotal.TabIndex = 1;
            this.txtDeductionTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeductionTotal_KeyPress);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonthName,
            this.MonthHalf,
            this.MonthEnd});
            this.listView1.Enabled = false;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(470, 288);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(332, 150);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // MonthName
            // 
            this.MonthName.DisplayIndex = 2;
            this.MonthName.Text = "الشهر";
            // 
            // MonthHalf
            // 
            this.MonthHalf.Text = "ملبلغ نصف الشهر";
            this.MonthHalf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonthHalf.Width = 145;
            // 
            // MonthEnd
            // 
            this.MonthEnd.DisplayIndex = 0;
            this.MonthEnd.Text = "مبلغ آخر الشهر";
            this.MonthEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MonthEnd.Width = 123;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label13.Location = new System.Drawing.Point(333, 288);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "جدولة الاستقطاع:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label14.Location = new System.Drawing.Point(128, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "الشهر:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label15.Location = new System.Drawing.Point(27, 342);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 19);
            this.label15.TabIndex = 0;
            this.label15.Text = "استقطاع نصف الشهر:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label16.Location = new System.Drawing.Point(36, 385);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(149, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = "استقطاع آخر الشهر:";
            // 
            // cbMonths
            // 
            this.cbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonths.Enabled = false;
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
            this.cbMonths.Location = new System.Drawing.Point(194, 305);
            this.cbMonths.Name = "cbMonths";
            this.cbMonths.Size = new System.Drawing.Size(127, 27);
            this.cbMonths.TabIndex = 16;
            // 
            // txtMonthHalfDeduction
            // 
            this.txtMonthHalfDeduction.Enabled = false;
            this.txtMonthHalfDeduction.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMonthHalfDeduction.ForeColor = System.Drawing.Color.Black;
            this.txtMonthHalfDeduction.Location = new System.Drawing.Point(194, 342);
            this.txtMonthHalfDeduction.Name = "txtMonthHalfDeduction";
            this.txtMonthHalfDeduction.Size = new System.Drawing.Size(104, 27);
            this.txtMonthHalfDeduction.TabIndex = 1;
            this.txtMonthHalfDeduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthHalfDeduction_KeyPress);
            // 
            // txtMonthEndDeduction
            // 
            this.txtMonthEndDeduction.Enabled = false;
            this.txtMonthEndDeduction.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMonthEndDeduction.ForeColor = System.Drawing.Color.Black;
            this.txtMonthEndDeduction.Location = new System.Drawing.Point(194, 382);
            this.txtMonthEndDeduction.Name = "txtMonthEndDeduction";
            this.txtMonthEndDeduction.Size = new System.Drawing.Size(104, 27);
            this.txtMonthEndDeduction.TabIndex = 1;
            this.txtMonthEndDeduction.Tag = "0";
            this.txtMonthEndDeduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthEndDeduction_KeyPress);
            // 
            // btnAddDedction
            // 
            this.btnAddDedction.Enabled = false;
            this.btnAddDedction.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDedction.Location = new System.Drawing.Point(357, 322);
            this.btnAddDedction.Name = "btnAddDedction";
            this.btnAddDedction.Size = new System.Drawing.Size(107, 27);
            this.btnAddDedction.TabIndex = 14;
            this.btnAddDedction.Text = "إضافة";
            this.btnAddDedction.UseVisualStyleBackColor = true;
            this.btnAddDedction.Click += new System.EventHandler(this.btnAddDedction_Click);
            // 
            // btnDeleteDeduction
            // 
            this.btnDeleteDeduction.Enabled = false;
            this.btnDeleteDeduction.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDeduction.Location = new System.Drawing.Point(357, 377);
            this.btnDeleteDeduction.Name = "btnDeleteDeduction";
            this.btnDeleteDeduction.Size = new System.Drawing.Size(107, 27);
            this.btnDeleteDeduction.TabIndex = 14;
            this.btnDeleteDeduction.Text = "حذف";
            this.btnDeleteDeduction.UseVisualStyleBackColor = true;
            this.btnDeleteDeduction.Click += new System.EventHandler(this.btnDeleteDeduction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(435, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 54);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 534);
            this.Controls.Add(this.cbMonths);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnDeleteDeduction);
            this.Controls.Add(this.btnAddDedction);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMonthEndDeduction);
            this.Controls.Add(this.txtMonthHalfDeduction);
            this.Controls.Add(this.txtDeductionTotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLoanID);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddPanalty);
            this.Controls.Add(this.gbPersonalInformation);
            this.Controls.Add(this.label3);
            this.Name = "frmLoans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "السلفيات";
            this.Load += new System.EventHandler(this.frmPenalty_Load);
            this.gbPersonalInformation.ResumeLayout(false);
            this.gbPersonalInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPersonalPicure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPersonalInformation;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFileIDSearch;
        public System.Windows.Forms.PictureBox picbPersonalPicure;
        private System.Windows.Forms.TextBox txtFileID;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddPanalty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoanID;
        public System.Windows.Forms.TextBox txtIncentive;
        public System.Windows.Forms.TextBox txtSalary;
        public System.Windows.Forms.TextBox txtManagement;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDeductionTotal;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader MonthName;
        private System.Windows.Forms.ColumnHeader MonthHalf;
        private System.Windows.Forms.ColumnHeader MonthEnd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbMonths;
        private System.Windows.Forms.TextBox txtMonthHalfDeduction;
        private System.Windows.Forms.TextBox txtMonthEndDeduction;
        private System.Windows.Forms.Button btnAddDedction;
        private System.Windows.Forms.Button btnDeleteDeduction;
        public System.Windows.Forms.Button btnNameSearch;
        private System.Windows.Forms.Button btnCancel;

    }
}