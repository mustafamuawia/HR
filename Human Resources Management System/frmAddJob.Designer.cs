namespace HR_MS
{
    partial class frmAddJob
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
            this.btnAddNewJob = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobID = new System.Windows.Forms.TextBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelEditing = new System.Windows.Forms.Button();
            this.tvHierarchicalTree = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAdministrations = new System.Windows.Forms.ComboBox();
            this.chbDepartment = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAddNewJob
            // 
            this.btnAddNewJob.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewJob.Location = new System.Drawing.Point(8, 439);
            this.btnAddNewJob.Name = "btnAddNewJob";
            this.btnAddNewJob.Size = new System.Drawing.Size(96, 63);
            this.btnAddNewJob.TabIndex = 0;
            this.btnAddNewJob.Text = "أضف وظيفة جديدة";
            this.btnAddNewJob.UseVisualStyleBackColor = true;
            this.btnAddNewJob.Click += new System.EventHandler(this.btnAddNewDepartment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(302, 439);
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
            this.label1.Location = new System.Drawing.Point(50, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "رقم الوظيفة:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "المسمى الوظيفي:";
            // 
            // txtJobID
            // 
            this.txtJobID.Enabled = false;
            this.txtJobID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobID.Location = new System.Drawing.Point(150, 56);
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Size = new System.Drawing.Size(148, 27);
            this.txtJobID.TabIndex = 3;
            // 
            // txtJobName
            // 
            this.txtJobName.Enabled = false;
            this.txtJobName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobName.Location = new System.Drawing.Point(150, 129);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(148, 27);
            this.txtJobName.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(205, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 63);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDepartments
            // 
            this.cbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartments.Enabled = false;
            this.cbDepartments.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(148, 304);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(148, 27);
            this.cbDepartments.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "اسم القسم:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(545, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "الوظائف";
            // 
            // btnCancelEditing
            // 
            this.btnCancelEditing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEditing.Location = new System.Drawing.Point(110, 439);
            this.btnCancelEditing.Name = "btnCancelEditing";
            this.btnCancelEditing.Size = new System.Drawing.Size(88, 63);
            this.btnCancelEditing.TabIndex = 0;
            this.btnCancelEditing.Text = "إلغاء";
            this.btnCancelEditing.UseVisualStyleBackColor = true;
            this.btnCancelEditing.Click += new System.EventHandler(this.btnCancelEditing_Click);
            // 
            // tvHierarchicalTree
            // 
            this.tvHierarchicalTree.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvHierarchicalTree.Location = new System.Drawing.Point(408, 54);
            this.tvHierarchicalTree.Name = "tvHierarchicalTree";
            this.tvHierarchicalTree.Size = new System.Drawing.Size(341, 448);
            this.tvHierarchicalTree.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "اسم الإدارة:";
            // 
            // cbAdministrations
            // 
            this.cbAdministrations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdministrations.Enabled = false;
            this.cbAdministrations.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdministrations.FormattingEnabled = true;
            this.cbAdministrations.Location = new System.Drawing.Point(148, 200);
            this.cbAdministrations.Name = "cbAdministrations";
            this.cbAdministrations.Size = new System.Drawing.Size(148, 27);
            this.cbAdministrations.TabIndex = 4;
            this.cbAdministrations.SelectedIndexChanged += new System.EventHandler(this.cbAdministration_SelectedIndexChanged);
            this.cbAdministrations.DropDown += new System.EventHandler(this.cbAdministration_DropDown);
            // 
            // chbDepartment
            // 
            this.chbDepartment.AutoSize = true;
            this.chbDepartment.Enabled = false;
            this.chbDepartment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chbDepartment.Location = new System.Drawing.Point(151, 258);
            this.chbDepartment.Name = "chbDepartment";
            this.chbDepartment.Size = new System.Drawing.Size(96, 23);
            this.chbDepartment.TabIndex = 6;
            this.chbDepartment.Text = "تابع لقسم";
            this.chbDepartment.UseVisualStyleBackColor = true;
            this.chbDepartment.CheckedChanged += new System.EventHandler(this.chbDepartment_CheckedChanged);
            // 
            // frmAddJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 524);
            this.Controls.Add(this.chbDepartment);
            this.Controls.Add(this.tvHierarchicalTree);
            this.Controls.Add(this.cbAdministrations);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtJobID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancelEditing);
            this.Controls.Add(this.btnAddNewJob);
            this.Name = "frmAddJob";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إضافة مسمى وظيفي";
            this.Load += new System.EventHandler(this.frmAddDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewJob;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobID;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelEditing;
        private System.Windows.Forms.TreeView tvHierarchicalTree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAdministrations;
        private System.Windows.Forms.CheckBox chbDepartment;
    }
}