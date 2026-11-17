namespace HR_MS
{
    partial class frmAddAdministration
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
            this.btnCancelAddNewDepartment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdministrationID = new System.Windows.Forms.TextBox();
            this.txtAdminstrationName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tvDepartments = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAdminDepartments = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChbSubDepartment = new System.Windows.Forms.CheckBox();
            this.btnAddNewDepartment = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelAddNewDepartment
            // 
            this.btnCancelAddNewDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddNewDepartment.Location = new System.Drawing.Point(110, 436);
            this.btnCancelAddNewDepartment.Name = "btnCancelAddNewDepartment";
            this.btnCancelAddNewDepartment.Size = new System.Drawing.Size(91, 63);
            this.btnCancelAddNewDepartment.TabIndex = 6;
            this.btnCancelAddNewDepartment.Text = "إلغاء";
            this.btnCancelAddNewDepartment.UseVisualStyleBackColor = true;
            this.btnCancelAddNewDepartment.Click += new System.EventHandler(this.btnCancelAddNewDepartment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(427, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 63);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "خروج";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "رقم الإدارة:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "اسم الإدارة:";
            // 
            // txtAdministrationID
            // 
            this.txtAdministrationID.Enabled = false;
            this.txtAdministrationID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdministrationID.Location = new System.Drawing.Point(201, 70);
            this.txtAdministrationID.Name = "txtAdministrationID";
            this.txtAdministrationID.Size = new System.Drawing.Size(148, 27);
            this.txtAdministrationID.TabIndex = 1;
            // 
            // txtAdminstrationName
            // 
            this.txtAdminstrationName.Enabled = false;
            this.txtAdminstrationName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminstrationName.Location = new System.Drawing.Point(201, 132);
            this.txtAdminstrationName.Name = "txtAdminstrationName";
            this.txtAdminstrationName.Size = new System.Drawing.Size(148, 27);
            this.txtAdminstrationName.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(217, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 63);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tvDepartments
            // 
            this.tvDepartments.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDepartments.Location = new System.Drawing.Point(524, 56);
            this.tvDepartments.Name = "tvDepartments";
            this.tvDepartments.Size = new System.Drawing.Size(274, 442);
            this.tvDepartments.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(629, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "الأقسام";
            // 
            // cbAdminDepartments
            // 
            this.cbAdminDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdminDepartments.Enabled = false;
            this.cbAdminDepartments.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdminDepartments.FormattingEnabled = true;
            this.cbAdminDepartments.Location = new System.Drawing.Point(201, 230);
            this.cbAdminDepartments.Name = "cbAdminDepartments";
            this.cbAdminDepartments.Size = new System.Drawing.Size(148, 27);
            this.cbAdminDepartments.TabIndex = 4;
            this.cbAdminDepartments.SelectedIndexChanged += new System.EventHandler(this.cbAdminDepartments_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "القسم المسئول:";
            // 
            // ChbSubDepartment
            // 
            this.ChbSubDepartment.AutoSize = true;
            this.ChbSubDepartment.Enabled = false;
            this.ChbSubDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbSubDepartment.Location = new System.Drawing.Point(201, 186);
            this.ChbSubDepartment.Name = "ChbSubDepartment";
            this.ChbSubDepartment.Size = new System.Drawing.Size(107, 23);
            this.ChbSubDepartment.TabIndex = 3;
            this.ChbSubDepartment.Text = "قسم فرعي";
            this.ChbSubDepartment.UseVisualStyleBackColor = true;
            this.ChbSubDepartment.CheckedChanged += new System.EventHandler(this.ChbSubDepartment_CheckedChanged);
            // 
            // btnAddNewDepartment
            // 
            this.btnAddNewDepartment.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewDepartment.Location = new System.Drawing.Point(8, 435);
            this.btnAddNewDepartment.Name = "btnAddNewDepartment";
            this.btnAddNewDepartment.Size = new System.Drawing.Size(91, 63);
            this.btnAddNewDepartment.TabIndex = 5;
            this.btnAddNewDepartment.Text = "أضف قسم جديد";
            this.btnAddNewDepartment.UseVisualStyleBackColor = true;
            this.btnAddNewDepartment.Click += new System.EventHandler(this.btnAddNewDepartment_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(321, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 63);
            this.button1.TabIndex = 8;
            this.button1.Text = "تعديل قسم";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAddAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 511);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ChbSubDepartment);
            this.Controls.Add(this.cbAdminDepartments);
            this.Controls.Add(this.tvDepartments);
            this.Controls.Add(this.txtAdminstrationName);
            this.Controls.Add(this.txtAdministrationID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNewDepartment);
            this.Controls.Add(this.btnCancelAddNewDepartment);
            this.Name = "frmAddAdministration";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "أضافة قسم";
            this.Load += new System.EventHandler(this.frmAddDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelAddNewDepartment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdministrationID;
        private System.Windows.Forms.TextBox txtAdminstrationName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView tvDepartments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAdminDepartments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChbSubDepartment;
        private System.Windows.Forms.Button btnAddNewDepartment;
        private System.Windows.Forms.Button button1;
    }
}