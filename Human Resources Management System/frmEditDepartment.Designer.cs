namespace HR_MS
{
    partial class frmEditDepartment
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
            this.btnEcit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewDepartmentName = new System.Windows.Forms.TextBox();
            this.tvHierarchicalTree = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAllAdministrations = new System.Windows.Forms.ComboBox();
            this.gbAdministrations = new System.Windows.Forms.GroupBox();
            this.txtNewAdminName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditAdministrationName = new System.Windows.Forms.Button();
            this.btnCancelEditAdminName = new System.Windows.Forms.Button();
            this.btnSaveAdministraion = new System.Windows.Forms.Button();
            this.btnDelAdministration = new System.Windows.Forms.Button();
            this.gbDepartments = new System.Windows.Forms.GroupBox();
            this.btnEditDeptAdmin = new System.Windows.Forms.Button();
            this.btnSaveDepartment = new System.Windows.Forms.Button();
            this.btnCalcelEditDept = new System.Windows.Forms.Button();
            this.btnEditDeptName = new System.Windows.Forms.Button();
            this.cbNewAdministration = new System.Windows.Forms.ComboBox();
            this.cbAdministrations = new System.Windows.Forms.ComboBox();
            this.rbDepartments = new System.Windows.Forms.RadioButton();
            this.rbAdministrations = new System.Windows.Forms.RadioButton();
            this.gbAdministrations.SuspendLayout();
            this.gbDepartments.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEcit
            // 
            this.btnEcit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEcit.Location = new System.Drawing.Point(344, 615);
            this.btnEcit.Name = "btnEcit";
            this.btnEcit.Size = new System.Drawing.Size(91, 38);
            this.btnEcit.TabIndex = 1;
            this.btnEcit.Text = "خروج";
            this.btnEcit.UseVisualStyleBackColor = true;
            this.btnEcit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "الأقسام:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "الإدارات:";
            // 
            // txtNewDepartmentName
            // 
            this.txtNewDepartmentName.Enabled = false;
            this.txtNewDepartmentName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewDepartmentName.Location = new System.Drawing.Point(121, 209);
            this.txtNewDepartmentName.Name = "txtNewDepartmentName";
            this.txtNewDepartmentName.Size = new System.Drawing.Size(148, 27);
            this.txtNewDepartmentName.TabIndex = 3;
            // 
            // tvHierarchicalTree
            // 
            this.tvHierarchicalTree.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvHierarchicalTree.Location = new System.Drawing.Point(447, 55);
            this.tvHierarchicalTree.Name = "tvHierarchicalTree";
            this.tvHierarchicalTree.Size = new System.Drawing.Size(274, 554);
            this.tvHierarchicalTree.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(517, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "الإدارات والأقسام";
            // 
            // cbDepartments
            // 
            this.cbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartments.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(121, 74);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(148, 27);
            this.cbDepartments.TabIndex = 5;
            this.cbDepartments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAllAdministrations_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "الإدارة الجديدة:";
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDepartment.Location = new System.Drawing.Point(7, 68);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(101, 36);
            this.btnDeleteDepartment.TabIndex = 0;
            this.btnDeleteDepartment.Text = "حذف";
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            this.btnDeleteDepartment.Visible = false;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.btnEditDepartment_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "الاسم الجديد:";
            // 
            // cbAllAdministrations
            // 
            this.cbAllAdministrations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAllAdministrations.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAllAdministrations.FormattingEnabled = true;
            this.cbAllAdministrations.Location = new System.Drawing.Point(121, 53);
            this.cbAllAdministrations.Name = "cbAllAdministrations";
            this.cbAllAdministrations.Size = new System.Drawing.Size(148, 27);
            this.cbAllAdministrations.TabIndex = 5;
            this.cbAllAdministrations.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAllAdministrations_KeyPress);
            // 
            // gbAdministrations
            // 
            this.gbAdministrations.Controls.Add(this.txtNewAdminName);
            this.gbAdministrations.Controls.Add(this.cbAllAdministrations);
            this.gbAdministrations.Controls.Add(this.label7);
            this.gbAdministrations.Controls.Add(this.label6);
            this.gbAdministrations.Controls.Add(this.btnEditAdministrationName);
            this.gbAdministrations.Controls.Add(this.btnCancelEditAdminName);
            this.gbAdministrations.Controls.Add(this.btnSaveAdministraion);
            this.gbAdministrations.Controls.Add(this.btnDelAdministration);
            this.gbAdministrations.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbAdministrations.Location = new System.Drawing.Point(12, 55);
            this.gbAdministrations.Name = "gbAdministrations";
            this.gbAdministrations.Size = new System.Drawing.Size(423, 225);
            this.gbAdministrations.TabIndex = 6;
            this.gbAdministrations.TabStop = false;
            this.gbAdministrations.Text = "تعديل الإدارات";
            // 
            // txtNewAdminName
            // 
            this.txtNewAdminName.Enabled = false;
            this.txtNewAdminName.Location = new System.Drawing.Point(116, 138);
            this.txtNewAdminName.Name = "txtNewAdminName";
            this.txtNewAdminName.Size = new System.Drawing.Size(148, 27);
            this.txtNewAdminName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(284, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "الإدارات:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(270, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "اسم الإدارة الجديد:";
            // 
            // btnEditAdministrationName
            // 
            this.btnEditAdministrationName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAdministrationName.Location = new System.Drawing.Point(199, 96);
            this.btnEditAdministrationName.Name = "btnEditAdministrationName";
            this.btnEditAdministrationName.Size = new System.Drawing.Size(101, 36);
            this.btnEditAdministrationName.TabIndex = 0;
            this.btnEditAdministrationName.Text = "تعديل الاسم";
            this.btnEditAdministrationName.UseVisualStyleBackColor = true;
            this.btnEditAdministrationName.Click += new System.EventHandler(this.btnEditAdministrationName_Click);
            // 
            // btnCancelEditAdminName
            // 
            this.btnCancelEditAdminName.Enabled = false;
            this.btnCancelEditAdminName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEditAdminName.Location = new System.Drawing.Point(72, 96);
            this.btnCancelEditAdminName.Name = "btnCancelEditAdminName";
            this.btnCancelEditAdminName.Size = new System.Drawing.Size(101, 36);
            this.btnCancelEditAdminName.TabIndex = 0;
            this.btnCancelEditAdminName.Text = "إلغاء التعديل";
            this.btnCancelEditAdminName.UseVisualStyleBackColor = true;
            this.btnCancelEditAdminName.Click += new System.EventHandler(this.btnCancelEditAdminName_Click);
            // 
            // btnSaveAdministraion
            // 
            this.btnSaveAdministraion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAdministraion.Location = new System.Drawing.Point(145, 179);
            this.btnSaveAdministraion.Name = "btnSaveAdministraion";
            this.btnSaveAdministraion.Size = new System.Drawing.Size(91, 40);
            this.btnSaveAdministraion.TabIndex = 0;
            this.btnSaveAdministraion.Text = "حفظ";
            this.btnSaveAdministraion.UseVisualStyleBackColor = true;
            this.btnSaveAdministraion.Click += new System.EventHandler(this.btnSaveAdministraion_Click);
            // 
            // btnDelAdministration
            // 
            this.btnDelAdministration.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelAdministration.Location = new System.Drawing.Point(6, 47);
            this.btnDelAdministration.Name = "btnDelAdministration";
            this.btnDelAdministration.Size = new System.Drawing.Size(101, 36);
            this.btnDelAdministration.TabIndex = 0;
            this.btnDelAdministration.Text = "حذف";
            this.btnDelAdministration.UseVisualStyleBackColor = true;
            this.btnDelAdministration.Visible = false;
            this.btnDelAdministration.Click += new System.EventHandler(this.btnDelAdministration_Click);
            // 
            // gbDepartments
            // 
            this.gbDepartments.Controls.Add(this.btnEditDeptAdmin);
            this.gbDepartments.Controls.Add(this.btnSaveDepartment);
            this.gbDepartments.Controls.Add(this.btnCalcelEditDept);
            this.gbDepartments.Controls.Add(this.btnEditDeptName);
            this.gbDepartments.Controls.Add(this.cbNewAdministration);
            this.gbDepartments.Controls.Add(this.cbAdministrations);
            this.gbDepartments.Controls.Add(this.cbDepartments);
            this.gbDepartments.Controls.Add(this.label1);
            this.gbDepartments.Controls.Add(this.label4);
            this.gbDepartments.Controls.Add(this.txtNewDepartmentName);
            this.gbDepartments.Controls.Add(this.btnDeleteDepartment);
            this.gbDepartments.Controls.Add(this.label5);
            this.gbDepartments.Controls.Add(this.label2);
            this.gbDepartments.Enabled = false;
            this.gbDepartments.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbDepartments.Location = new System.Drawing.Point(21, 321);
            this.gbDepartments.Name = "gbDepartments";
            this.gbDepartments.Size = new System.Drawing.Size(414, 288);
            this.gbDepartments.TabIndex = 6;
            this.gbDepartments.TabStop = false;
            this.gbDepartments.Text = "تعديل الأقسام";
            // 
            // btnEditDeptAdmin
            // 
            this.btnEditDeptAdmin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeptAdmin.Location = new System.Drawing.Point(150, 120);
            this.btnEditDeptAdmin.Name = "btnEditDeptAdmin";
            this.btnEditDeptAdmin.Size = new System.Drawing.Size(101, 36);
            this.btnEditDeptAdmin.TabIndex = 0;
            this.btnEditDeptAdmin.Text = "تغير الإدارة";
            this.btnEditDeptAdmin.UseVisualStyleBackColor = true;
            this.btnEditDeptAdmin.Click += new System.EventHandler(this.btnEditDeptAdmin_Click);
            // 
            // btnSaveDepartment
            // 
            this.btnSaveDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDepartment.Location = new System.Drawing.Point(150, 242);
            this.btnSaveDepartment.Name = "btnSaveDepartment";
            this.btnSaveDepartment.Size = new System.Drawing.Size(91, 40);
            this.btnSaveDepartment.TabIndex = 0;
            this.btnSaveDepartment.Text = "حفظ";
            this.btnSaveDepartment.UseVisualStyleBackColor = true;
            this.btnSaveDepartment.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnCalcelEditDept
            // 
            this.btnCalcelEditDept.Enabled = false;
            this.btnCalcelEditDept.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcelEditDept.Location = new System.Drawing.Point(6, 120);
            this.btnCalcelEditDept.Name = "btnCalcelEditDept";
            this.btnCalcelEditDept.Size = new System.Drawing.Size(101, 36);
            this.btnCalcelEditDept.TabIndex = 0;
            this.btnCalcelEditDept.Text = "إلغاء التعديل";
            this.btnCalcelEditDept.UseVisualStyleBackColor = true;
            this.btnCalcelEditDept.Click += new System.EventHandler(this.btnCalcelEditDept_Click);
            // 
            // btnEditDeptName
            // 
            this.btnEditDeptName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDeptName.Location = new System.Drawing.Point(284, 120);
            this.btnEditDeptName.Name = "btnEditDeptName";
            this.btnEditDeptName.Size = new System.Drawing.Size(101, 36);
            this.btnEditDeptName.TabIndex = 0;
            this.btnEditDeptName.Text = "تعديل الاسم";
            this.btnEditDeptName.UseVisualStyleBackColor = true;
            this.btnEditDeptName.Click += new System.EventHandler(this.btnEditDeptName_Click);
            // 
            // cbNewAdministration
            // 
            this.cbNewAdministration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewAdministration.Enabled = false;
            this.cbNewAdministration.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNewAdministration.FormattingEnabled = true;
            this.cbNewAdministration.Location = new System.Drawing.Point(121, 166);
            this.cbNewAdministration.Name = "cbNewAdministration";
            this.cbNewAdministration.Size = new System.Drawing.Size(148, 27);
            this.cbNewAdministration.TabIndex = 5;
            this.cbNewAdministration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAllAdministrations_KeyPress);
            // 
            // cbAdministrations
            // 
            this.cbAdministrations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdministrations.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdministrations.FormattingEnabled = true;
            this.cbAdministrations.Location = new System.Drawing.Point(121, 26);
            this.cbAdministrations.Name = "cbAdministrations";
            this.cbAdministrations.Size = new System.Drawing.Size(148, 27);
            this.cbAdministrations.TabIndex = 5;
            this.cbAdministrations.SelectedIndexChanged += new System.EventHandler(this.cbAdministrations_SelectedIndexChanged);
            this.cbAdministrations.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAllAdministrations_KeyPress);
            // 
            // rbDepartments
            // 
            this.rbDepartments.AutoSize = true;
            this.rbDepartments.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbDepartments.Location = new System.Drawing.Point(29, 298);
            this.rbDepartments.Name = "rbDepartments";
            this.rbDepartments.Size = new System.Drawing.Size(121, 23);
            this.rbDepartments.TabIndex = 7;
            this.rbDepartments.Text = "تعديل الأقسام";
            this.rbDepartments.UseVisualStyleBackColor = true;
            this.rbDepartments.CheckedChanged += new System.EventHandler(this.rbDepartments_CheckedChanged);
            // 
            // rbAdministrations
            // 
            this.rbAdministrations.AutoSize = true;
            this.rbAdministrations.Checked = true;
            this.rbAdministrations.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbAdministrations.Location = new System.Drawing.Point(29, 30);
            this.rbAdministrations.Name = "rbAdministrations";
            this.rbAdministrations.Size = new System.Drawing.Size(117, 23);
            this.rbAdministrations.TabIndex = 7;
            this.rbAdministrations.TabStop = true;
            this.rbAdministrations.Text = "تعديل الإدارات";
            this.rbAdministrations.UseVisualStyleBackColor = true;
            this.rbAdministrations.CheckedChanged += new System.EventHandler(this.rbAdministrations_CheckedChanged);
            // 
            // frmEditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 664);
            this.Controls.Add(this.rbAdministrations);
            this.Controls.Add(this.rbDepartments);
            this.Controls.Add(this.gbDepartments);
            this.Controls.Add(this.gbAdministrations);
            this.Controls.Add(this.tvHierarchicalTree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEcit);
            this.Name = "frmEditDepartment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تعديل الأقسام";
            this.Load += new System.EventHandler(this.frmAddDepartment_Load);
            this.gbAdministrations.ResumeLayout(false);
            this.gbAdministrations.PerformLayout();
            this.gbDepartments.ResumeLayout(false);
            this.gbDepartments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEcit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewDepartmentName;
        private System.Windows.Forms.TreeView tvHierarchicalTree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAllAdministrations;
        private System.Windows.Forms.GroupBox gbAdministrations;
        private System.Windows.Forms.TextBox txtNewAdminName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditAdministrationName;
        private System.Windows.Forms.Button btnCancelEditAdminName;
        private System.Windows.Forms.Button btnSaveAdministraion;
        private System.Windows.Forms.GroupBox gbDepartments;
        private System.Windows.Forms.Button btnEditDeptName;
        private System.Windows.Forms.Button btnCalcelEditDept;
        private System.Windows.Forms.Button btnSaveDepartment;
        private System.Windows.Forms.Button btnDelAdministration;
        private System.Windows.Forms.Button btnEditDeptAdmin;
        private System.Windows.Forms.RadioButton rbDepartments;
        private System.Windows.Forms.RadioButton rbAdministrations;
        private System.Windows.Forms.ComboBox cbAdministrations;
        private System.Windows.Forms.ComboBox cbNewAdministration;
    }
}