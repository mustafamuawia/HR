namespace HR_MS
{
    partial class frmAddDepartment
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
            this.btnCancelAddAdmin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tvHierarchicalTree = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewDepartment = new System.Windows.Forms.Button();
            this.lblAdminID = new System.Windows.Forms.Label();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.txtAdministrationID = new System.Windows.Forms.TextBox();
            this.txtAdministrationName = new System.Windows.Forms.TextBox();
            this.gbAddAdministration = new System.Windows.Forms.GroupBox();
            this.btnSaveAdmin = new System.Windows.Forms.Button();
            this.btnAddNewAdmin = new System.Windows.Forms.Button();
            this.gbAddDepartment = new System.Windows.Forms.GroupBox();
            this.cbAdministrations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.btnSaveDept = new System.Windows.Forms.Button();
            this.btnCancelAddDept = new System.Windows.Forms.Button();
            this.rbAddAdministration = new System.Windows.Forms.RadioButton();
            this.rbAddDepartment = new System.Windows.Forms.RadioButton();
            this.gbAddAdministration.SuspendLayout();
            this.gbAddDepartment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelAddAdmin
            // 
            this.btnCancelAddAdmin.Enabled = false;
            this.btnCancelAddAdmin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddAdmin.Location = new System.Drawing.Point(229, 87);
            this.btnCancelAddAdmin.Name = "btnCancelAddAdmin";
            this.btnCancelAddAdmin.Size = new System.Drawing.Size(91, 52);
            this.btnCancelAddAdmin.TabIndex = 6;
            this.btnCancelAddAdmin.Text = "إلغاء";
            this.btnCancelAddAdmin.UseVisualStyleBackColor = true;
            this.btnCancelAddAdmin.Click += new System.EventHandler(this.btnCancelAddAdmin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(454, 496);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 42);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tvHierarchicalTree
            // 
            this.tvHierarchicalTree.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvHierarchicalTree.Location = new System.Drawing.Point(570, 43);
            this.tvHierarchicalTree.Name = "tvHierarchicalTree";
            this.tvHierarchicalTree.Size = new System.Drawing.Size(274, 442);
            this.tvHierarchicalTree.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(677, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "الأقسام";
            // 
            // btnAddNewDepartment
            // 
            this.btnAddNewDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewDepartment.Location = new System.Drawing.Point(366, 119);
            this.btnAddNewDepartment.Name = "btnAddNewDepartment";
            this.btnAddNewDepartment.Size = new System.Drawing.Size(91, 48);
            this.btnAddNewDepartment.TabIndex = 5;
            this.btnAddNewDepartment.Text = "أضف قسم جديد";
            this.btnAddNewDepartment.UseVisualStyleBackColor = true;
            this.btnAddNewDepartment.Click += new System.EventHandler(this.btnAddNewDepartment_Click);
            // 
            // lblAdminID
            // 
            this.lblAdminID.AutoSize = true;
            this.lblAdminID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminID.Location = new System.Drawing.Point(404, 40);
            this.lblAdminID.Name = "lblAdminID";
            this.lblAdminID.Size = new System.Drawing.Size(83, 19);
            this.lblAdminID.TabIndex = 11;
            this.lblAdminID.Text = "رقم الإدارة:";
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.Location = new System.Drawing.Point(199, 40);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(90, 19);
            this.lblAdminName.TabIndex = 13;
            this.lblAdminName.Text = "اسم الإدارة:";
            // 
            // txtAdministrationID
            // 
            this.txtAdministrationID.Enabled = false;
            this.txtAdministrationID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdministrationID.Location = new System.Drawing.Point(348, 37);
            this.txtAdministrationID.Name = "txtAdministrationID";
            this.txtAdministrationID.Size = new System.Drawing.Size(50, 27);
            this.txtAdministrationID.TabIndex = 1;
            // 
            // txtAdministrationName
            // 
            this.txtAdministrationName.Enabled = false;
            this.txtAdministrationName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdministrationName.Location = new System.Drawing.Point(45, 37);
            this.txtAdministrationName.Name = "txtAdministrationName";
            this.txtAdministrationName.Size = new System.Drawing.Size(148, 27);
            this.txtAdministrationName.TabIndex = 2;
            // 
            // gbAddAdministration
            // 
            this.gbAddAdministration.Controls.Add(this.txtAdministrationName);
            this.gbAddAdministration.Controls.Add(this.lblAdminID);
            this.gbAddAdministration.Controls.Add(this.txtAdministrationID);
            this.gbAddAdministration.Controls.Add(this.lblAdminName);
            this.gbAddAdministration.Controls.Add(this.btnSaveAdmin);
            this.gbAddAdministration.Controls.Add(this.btnCancelAddAdmin);
            this.gbAddAdministration.Controls.Add(this.btnAddNewAdmin);
            this.gbAddAdministration.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbAddAdministration.Location = new System.Drawing.Point(12, 43);
            this.gbAddAdministration.Name = "gbAddAdministration";
            this.gbAddAdministration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbAddAdministration.Size = new System.Drawing.Size(515, 165);
            this.gbAddAdministration.TabIndex = 14;
            this.gbAddAdministration.TabStop = false;
            this.gbAddAdministration.Text = "إضافة إدارة";
            // 
            // btnSaveAdmin
            // 
            this.btnSaveAdmin.Enabled = false;
            this.btnSaveAdmin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAdmin.Location = new System.Drawing.Point(72, 84);
            this.btnSaveAdmin.Name = "btnSaveAdmin";
            this.btnSaveAdmin.Size = new System.Drawing.Size(91, 55);
            this.btnSaveAdmin.TabIndex = 7;
            this.btnSaveAdmin.Text = "حفظ";
            this.btnSaveAdmin.UseVisualStyleBackColor = true;
            this.btnSaveAdmin.Click += new System.EventHandler(this.btnSaveAdmin_Click);
            // 
            // btnAddNewAdmin
            // 
            this.btnAddNewAdmin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAdmin.Location = new System.Drawing.Point(366, 87);
            this.btnAddNewAdmin.Name = "btnAddNewAdmin";
            this.btnAddNewAdmin.Size = new System.Drawing.Size(91, 52);
            this.btnAddNewAdmin.TabIndex = 7;
            this.btnAddNewAdmin.Text = "أضف إدارة جديدة";
            this.btnAddNewAdmin.UseVisualStyleBackColor = true;
            this.btnAddNewAdmin.Click += new System.EventHandler(this.btnAddNewAdmin_Click);
            // 
            // gbAddDepartment
            // 
            this.gbAddDepartment.Controls.Add(this.cbAdministrations);
            this.gbAddDepartment.Controls.Add(this.label1);
            this.gbAddDepartment.Controls.Add(this.label7);
            this.gbAddDepartment.Controls.Add(this.label8);
            this.gbAddDepartment.Controls.Add(this.txtDepartmentID);
            this.gbAddDepartment.Controls.Add(this.txtDepartmentName);
            this.gbAddDepartment.Controls.Add(this.btnSaveDept);
            this.gbAddDepartment.Controls.Add(this.btnCancelAddDept);
            this.gbAddDepartment.Controls.Add(this.btnAddNewDepartment);
            this.gbAddDepartment.Enabled = false;
            this.gbAddDepartment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbAddDepartment.Location = new System.Drawing.Point(12, 272);
            this.gbAddDepartment.Name = "gbAddDepartment";
            this.gbAddDepartment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbAddDepartment.Size = new System.Drawing.Size(515, 182);
            this.gbAddDepartment.TabIndex = 14;
            this.gbAddDepartment.TabStop = false;
            this.gbAddDepartment.Text = "إضافة قسم";
            // 
            // cbAdministrations
            // 
            this.cbAdministrations.FormattingEnabled = true;
            this.cbAdministrations.Location = new System.Drawing.Point(72, 29);
            this.cbAdministrations.Name = "cbAdministrations";
            this.cbAdministrations.Size = new System.Drawing.Size(121, 27);
            this.cbAdministrations.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "رقم القسم:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "اسم الإدارة:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "اسم القسم:";
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Enabled = false;
            this.txtDepartmentID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentID.Location = new System.Drawing.Point(348, 26);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(50, 27);
            this.txtDepartmentID.TabIndex = 1;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartmentName.Location = new System.Drawing.Point(250, 71);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(148, 27);
            this.txtDepartmentName.TabIndex = 2;
            // 
            // btnSaveDept
            // 
            this.btnSaveDept.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDept.Location = new System.Drawing.Point(72, 119);
            this.btnSaveDept.Name = "btnSaveDept";
            this.btnSaveDept.Size = new System.Drawing.Size(91, 48);
            this.btnSaveDept.TabIndex = 7;
            this.btnSaveDept.Text = "حفظ";
            this.btnSaveDept.UseVisualStyleBackColor = true;
            this.btnSaveDept.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnCancelAddDept
            // 
            this.btnCancelAddDept.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddDept.Location = new System.Drawing.Point(229, 119);
            this.btnCancelAddDept.Name = "btnCancelAddDept";
            this.btnCancelAddDept.Size = new System.Drawing.Size(91, 48);
            this.btnCancelAddDept.TabIndex = 6;
            this.btnCancelAddDept.Text = "إلغاء";
            this.btnCancelAddDept.UseVisualStyleBackColor = true;
            this.btnCancelAddDept.Click += new System.EventHandler(this.btnCancelAddNewDepartment_Click);
            // 
            // rbAddAdministration
            // 
            this.rbAddAdministration.AutoSize = true;
            this.rbAddAdministration.Checked = true;
            this.rbAddAdministration.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbAddAdministration.Location = new System.Drawing.Point(37, 12);
            this.rbAddAdministration.Name = "rbAddAdministration";
            this.rbAddAdministration.Size = new System.Drawing.Size(98, 23);
            this.rbAddAdministration.TabIndex = 15;
            this.rbAddAdministration.TabStop = true;
            this.rbAddAdministration.Text = "إضافة إدارة";
            this.rbAddAdministration.UseVisualStyleBackColor = true;
            this.rbAddAdministration.CheckedChanged += new System.EventHandler(this.rbAddAdministration_CheckedChanged);
            // 
            // rbAddDepartment
            // 
            this.rbAddDepartment.AutoSize = true;
            this.rbAddDepartment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbAddDepartment.Location = new System.Drawing.Point(37, 243);
            this.rbAddDepartment.Name = "rbAddDepartment";
            this.rbAddDepartment.Size = new System.Drawing.Size(98, 23);
            this.rbAddDepartment.TabIndex = 15;
            this.rbAddDepartment.Text = "إضافة إدارة";
            this.rbAddDepartment.UseVisualStyleBackColor = true;
            this.rbAddDepartment.CheckedChanged += new System.EventHandler(this.rbAddDepartment_CheckedChanged);
            // 
            // frmAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 550);
            this.Controls.Add(this.rbAddDepartment);
            this.Controls.Add(this.rbAddAdministration);
            this.Controls.Add(this.gbAddDepartment);
            this.Controls.Add(this.gbAddAdministration);
            this.Controls.Add(this.tvHierarchicalTree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Name = "frmAddDepartment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "أضافة قسم";
            this.Load += new System.EventHandler(this.frmAddDepartment_Load);
            this.gbAddAdministration.ResumeLayout(false);
            this.gbAddAdministration.PerformLayout();
            this.gbAddDepartment.ResumeLayout(false);
            this.gbAddDepartment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelAddAdmin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TreeView tvHierarchicalTree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewDepartment;
        private System.Windows.Forms.Label lblAdminID;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.TextBox txtAdministrationID;
        private System.Windows.Forms.TextBox txtAdministrationName;
        private System.Windows.Forms.GroupBox gbAddAdministration;
        private System.Windows.Forms.Button btnAddNewAdmin;
        private System.Windows.Forms.GroupBox gbAddDepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Button btnSaveDept;
        private System.Windows.Forms.Button btnSaveAdmin;
        private System.Windows.Forms.Button btnCancelAddDept;
        private System.Windows.Forms.RadioButton rbAddAdministration;
        private System.Windows.Forms.RadioButton rbAddDepartment;
        private System.Windows.Forms.ComboBox cbAdministrations;
        private System.Windows.Forms.Label label1;
    }
}