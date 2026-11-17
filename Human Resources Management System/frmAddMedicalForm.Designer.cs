namespace HR_MS
{
    partial class frmAddMedicalForm
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.gbPersonalInformation = new System.Windows.Forms.GroupBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNameSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnFileIDSearch = new System.Windows.Forms.Button();
            this.picbPersonalPicure = new System.Windows.Forms.PictureBox();
            this.txtFileID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.txtAdministration = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMedicalFormID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddMedicalForm = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbPersonalInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPersonalPicure)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(326, 251);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(121, 27);
            this.dtpDate.TabIndex = 14;
            // 
            // gbPersonalInformation
            // 
            this.gbPersonalInformation.Controls.Add(this.txtDepartment);
            this.gbPersonalInformation.Controls.Add(this.label5);
            this.gbPersonalInformation.Controls.Add(this.label4);
            this.gbPersonalInformation.Controls.Add(this.btnNameSearch);
            this.gbPersonalInformation.Controls.Add(this.btnSearch);
            this.gbPersonalInformation.Controls.Add(this.btnFileIDSearch);
            this.gbPersonalInformation.Controls.Add(this.picbPersonalPicure);
            this.gbPersonalInformation.Controls.Add(this.txtFileID);
            this.gbPersonalInformation.Controls.Add(this.label1);
            this.gbPersonalInformation.Controls.Add(this.txtJob);
            this.gbPersonalInformation.Controls.Add(this.txtAdministration);
            this.gbPersonalInformation.Controls.Add(this.label11);
            this.gbPersonalInformation.Controls.Add(this.label10);
            this.gbPersonalInformation.Controls.Add(this.label7);
            this.gbPersonalInformation.Controls.Add(this.txtEmpName);
            this.gbPersonalInformation.Controls.Add(this.label2);
            this.gbPersonalInformation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonalInformation.Location = new System.Drawing.Point(12, 12);
            this.gbPersonalInformation.Name = "gbPersonalInformation";
            this.gbPersonalInformation.Size = new System.Drawing.Size(610, 223);
            this.gbPersonalInformation.TabIndex = 13;
            this.gbPersonalInformation.TabStop = false;
            this.gbPersonalInformation.Text = "بيانات الموظف";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(383, 189);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(103, 27);
            this.txtDepartment.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "القسم:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "الإدارة:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNameSearch
            // 
            this.btnNameSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNameSearch.Location = new System.Drawing.Point(187, 90);
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
            this.btnSearch.Location = new System.Drawing.Point(162, 42);
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
            this.btnFileIDSearch.Location = new System.Drawing.Point(297, 42);
            this.btnFileIDSearch.Name = "btnFileIDSearch";
            this.btnFileIDSearch.Size = new System.Drawing.Size(61, 28);
            this.btnFileIDSearch.TabIndex = 10;
            this.btnFileIDSearch.Text = "بحث";
            this.btnFileIDSearch.UseVisualStyleBackColor = true;
            // 
            // picbPersonalPicure
            // 
            this.picbPersonalPicure.ErrorImage = null;
            this.picbPersonalPicure.Image = global::HR_MS.Properties.Resources.Picture;
            this.picbPersonalPicure.InitialImage = global::HR_MS.Properties.Resources.Picture;
            this.picbPersonalPicure.Location = new System.Drawing.Point(16, 25);
            this.picbPersonalPicure.Name = "picbPersonalPicure";
            this.picbPersonalPicure.Size = new System.Drawing.Size(124, 144);
            this.picbPersonalPicure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbPersonalPicure.TabIndex = 14;
            this.picbPersonalPicure.TabStop = false;
            // 
            // txtFileID
            // 
            this.txtFileID.ForeColor = System.Drawing.Color.Red;
            this.txtFileID.Location = new System.Drawing.Point(365, 44);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.Size = new System.Drawing.Size(122, 27);
            this.txtFileID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم الملف:";
            // 
            // txtJob
            // 
            this.txtJob.Enabled = false;
            this.txtJob.Location = new System.Drawing.Point(187, 142);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(104, 27);
            this.txtJob.TabIndex = 2;
            // 
            // txtAdministration
            // 
            this.txtAdministration.Enabled = false;
            this.txtAdministration.Location = new System.Drawing.Point(384, 142);
            this.txtAdministration.Name = "txtAdministration";
            this.txtAdministration.Size = new System.Drawing.Size(103, 27);
            this.txtAdministration.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "الوظيفة:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(496, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "الإدارة:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "الإدارة:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(259, 94);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(229, 27);
            this.txtEmpName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "اسم الموظف:";
            // 
            // txtMedicalFormID
            // 
            this.txtMedicalFormID.Enabled = false;
            this.txtMedicalFormID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMedicalFormID.Location = new System.Drawing.Point(135, 256);
            this.txtMedicalFormID.Name = "txtMedicalFormID";
            this.txtMedicalFormID.Size = new System.Drawing.Size(103, 27);
            this.txtMedicalFormID.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Location = new System.Drawing.Point(35, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "رقم الأورنيك:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(264, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "التاريخ:";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(385, 392);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 54);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(288, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 54);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(191, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 54);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddMedicalForm
            // 
            this.btnAddMedicalForm.Enabled = false;
            this.btnAddMedicalForm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMedicalForm.Location = new System.Drawing.Point(95, 392);
            this.btnAddMedicalForm.Name = "btnAddMedicalForm";
            this.btnAddMedicalForm.Size = new System.Drawing.Size(90, 54);
            this.btnAddMedicalForm.TabIndex = 15;
            this.btnAddMedicalForm.Text = "إضافة";
            this.btnAddMedicalForm.UseVisualStyleBackColor = true;
            this.btnAddMedicalForm.Click += new System.EventHandler(this.btnAddMedicalForm_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.Enabled = false;
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNotes.Location = new System.Drawing.Point(136, 310);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(311, 62);
            this.txtNotes.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label8.Location = new System.Drawing.Point(53, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "ملاحظات:";
            // 
            // frmMedicalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 484);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddMedicalForm);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.gbPersonalInformation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMedicalFormID);
            this.Controls.Add(this.label6);
            this.Name = "frmMedicalForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة أورنيك طبي";
            this.Load += new System.EventHandler(this.frmMedicalForm_Load);
            this.gbPersonalInformation.ResumeLayout(false);
            this.gbPersonalInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPersonalPicure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox gbPersonalInformation;
        public System.Windows.Forms.Button btnNameSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFileIDSearch;
        public System.Windows.Forms.PictureBox picbPersonalPicure;
        private System.Windows.Forms.TextBox txtFileID;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtJob;
        public System.Windows.Forms.TextBox txtAdministration;
        public System.Windows.Forms.TextBox txtMedicalFormID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddMedicalForm;
        public System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}