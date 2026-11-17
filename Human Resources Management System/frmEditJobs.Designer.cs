namespace HR_MS
{
    partial class frmEditJobs
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobID = new System.Windows.Forms.TextBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tvJobs = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAdminJobs = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditJob = new System.Windows.Forms.Button();
            this.btnCancelEditJob = new System.Windows.Forms.Button();
            this.cbAdministrations = new System.Windows.Forms.ComboBox();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chbIsDepartmentJob = new System.Windows.Forms.CheckBox();
            this.btnDeleteJob = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(339, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 63);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "خروج";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "رقم الوظيفة:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "المسمى الوظيفي:";
            // 
            // txtJobID
            // 
            this.txtJobID.Enabled = false;
            this.txtJobID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobID.Location = new System.Drawing.Point(228, 66);
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Size = new System.Drawing.Size(148, 27);
            this.txtJobID.TabIndex = 3;
            // 
            // txtJobName
            // 
            this.txtJobName.Enabled = false;
            this.txtJobName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobName.Location = new System.Drawing.Point(228, 279);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(148, 27);
            this.txtJobName.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(145, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 63);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tvJobs
            // 
            this.tvJobs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvJobs.Location = new System.Drawing.Point(529, 64);
            this.tvJobs.Name = "tvJobs";
            this.tvJobs.Size = new System.Drawing.Size(341, 448);
            this.tvJobs.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(676, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "الوظائف";
            // 
            // cbAdminJobs
            // 
            this.cbAdminJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdminJobs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdminJobs.FormattingEnabled = true;
            this.cbAdminJobs.Location = new System.Drawing.Point(228, 173);
            this.cbAdminJobs.Name = "cbAdminJobs";
            this.cbAdminJobs.Size = new System.Drawing.Size(148, 27);
            this.cbAdminJobs.TabIndex = 4;
            this.cbAdminJobs.SelectedIndexChanged += new System.EventHandler(this.cbAllJobs_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "اسم الوظيفة الجديد:";
            // 
            // btnEditJob
            // 
            this.btnEditJob.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditJob.Location = new System.Drawing.Point(182, 223);
            this.btnEditJob.Name = "btnEditJob";
            this.btnEditJob.Size = new System.Drawing.Size(101, 36);
            this.btnEditJob.TabIndex = 7;
            this.btnEditJob.Text = "تعديل";
            this.btnEditJob.UseVisualStyleBackColor = true;
            this.btnEditJob.Click += new System.EventHandler(this.btnEditJob_Click);
            // 
            // btnCancelEditJob
            // 
            this.btnCancelEditJob.Enabled = false;
            this.btnCancelEditJob.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEditJob.Location = new System.Drawing.Point(329, 223);
            this.btnCancelEditJob.Name = "btnCancelEditJob";
            this.btnCancelEditJob.Size = new System.Drawing.Size(101, 36);
            this.btnCancelEditJob.TabIndex = 6;
            this.btnCancelEditJob.Text = "إلغاء التعديل";
            this.btnCancelEditJob.UseVisualStyleBackColor = true;
            this.btnCancelEditJob.Click += new System.EventHandler(this.btnCancelEditJob_Click);
            // 
            // cbAdministrations
            // 
            this.cbAdministrations.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdministrations.FormattingEnabled = true;
            this.cbAdministrations.Location = new System.Drawing.Point(228, 117);
            this.cbAdministrations.Name = "cbAdministrations";
            this.cbAdministrations.Size = new System.Drawing.Size(148, 27);
            this.cbAdministrations.TabIndex = 10;
            this.cbAdministrations.SelectedIndexChanged += new System.EventHandler(this.cbAdministrations_SelectedIndexChanged);
            // 
            // cbDepartments
            // 
            this.cbDepartments.Enabled = false;
            this.cbDepartments.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(228, 373);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(148, 27);
            this.cbDepartments.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "اسم الإدارة:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(106, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "اسم القسم:";
            // 
            // chbIsDepartmentJob
            // 
            this.chbIsDepartmentJob.AutoSize = true;
            this.chbIsDepartmentJob.Enabled = false;
            this.chbIsDepartmentJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbIsDepartmentJob.Location = new System.Drawing.Point(228, 327);
            this.chbIsDepartmentJob.Name = "chbIsDepartmentJob";
            this.chbIsDepartmentJob.Size = new System.Drawing.Size(73, 24);
            this.chbIsDepartmentJob.TabIndex = 12;
            this.chbIsDepartmentJob.Text = "يتبع لقسم";
            this.chbIsDepartmentJob.UseVisualStyleBackColor = true;
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.Enabled = false;
            this.btnDeleteJob.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteJob.Location = new System.Drawing.Point(399, 167);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(101, 36);
            this.btnDeleteJob.TabIndex = 6;
            this.btnDeleteJob.Text = "حذف ";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            // 
            // frmEditJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 524);
            this.Controls.Add(this.chbIsDepartmentJob);
            this.Controls.Add(this.cbAdministrations);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEditJob);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.btnCancelEditJob);
            this.Controls.Add(this.tvJobs);
            this.Controls.Add(this.cbAdminJobs);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.txtJobID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmEditJobs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعديل وظيفة";
            this.Load += new System.EventHandler(this.frmEditJobs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobID;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView tvJobs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAdminJobs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditJob;
        private System.Windows.Forms.Button btnCancelEditJob;
        private System.Windows.Forms.ComboBox cbAdministrations;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbIsDepartmentJob;
        private System.Windows.Forms.Button btnDeleteJob;
    }
}