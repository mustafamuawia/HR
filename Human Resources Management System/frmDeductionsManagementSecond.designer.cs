namespace HR_MS
{
    partial class frmDeductionsManagementSecond
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
            this.cbDeductions = new System.Windows.Forms.ComboBox();
            this.txtAllowanceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbDeductions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewAllowanceName = new System.Windows.Forms.TextBox();
            this.btnDeleteAllowance = new System.Windows.Forms.Button();
            this.btnEditAllowanceName = new System.Windows.Forms.Button();
            this.btnSaveEditAllowance = new System.Windows.Forms.Button();
            this.rbAddAllowance = new System.Windows.Forms.RadioButton();
            this.rbEditAllowance = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDeductions
            // 
            this.cbDeductions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeductions.Enabled = false;
            this.cbDeductions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDeductions.FormattingEnabled = true;
            this.cbDeductions.Location = new System.Drawing.Point(193, 302);
            this.cbDeductions.Name = "cbDeductions";
            this.cbDeductions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDeductions.Size = new System.Drawing.Size(148, 27);
            this.cbDeductions.TabIndex = 18;
            this.cbDeductions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDeductions_KeyPress);
            this.cbDeductions.DropDown += new System.EventHandler(this.cbDeductions_DropDown);
            // 
            // txtAllowanceName
            // 
            this.txtAllowanceName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllowanceName.Location = new System.Drawing.Point(193, 90);
            this.txtAllowanceName.Name = "txtAllowanceName";
            this.txtAllowanceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllowanceName.Size = new System.Drawing.Size(148, 27);
            this.txtAllowanceName.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 357);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "الاسم الجديد:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 98);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "بند الاستقطاع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 302);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "بند الاستقطاع";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(451, 471);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 45);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(222, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(101, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbDeductions
            // 
            this.lbDeductions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeductions.FormattingEnabled = true;
            this.lbDeductions.ItemHeight = 19;
            this.lbDeductions.Location = new System.Drawing.Point(563, 39);
            this.lbDeductions.Name = "lbDeductions";
            this.lbDeductions.Size = new System.Drawing.Size(281, 479);
            this.lbDeductions.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(684, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "الاستقطاعات";
            // 
            // txtNewAllowanceName
            // 
            this.txtNewAllowanceName.Enabled = false;
            this.txtNewAllowanceName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAllowanceName.Location = new System.Drawing.Point(193, 349);
            this.txtNewAllowanceName.Name = "txtNewAllowanceName";
            this.txtNewAllowanceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewAllowanceName.Size = new System.Drawing.Size(148, 27);
            this.txtNewAllowanceName.TabIndex = 15;
            // 
            // btnDeleteAllowance
            // 
            this.btnDeleteAllowance.Enabled = false;
            this.btnDeleteAllowance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAllowance.Location = new System.Drawing.Point(356, 293);
            this.btnDeleteAllowance.Name = "btnDeleteAllowance";
            this.btnDeleteAllowance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDeleteAllowance.Size = new System.Drawing.Size(160, 36);
            this.btnDeleteAllowance.TabIndex = 9;
            this.btnDeleteAllowance.Text = "حذف البند";
            this.btnDeleteAllowance.UseVisualStyleBackColor = true;
            this.btnDeleteAllowance.Click += new System.EventHandler(this.btnDeleteAllowance_Click);
            // 
            // btnEditAllowanceName
            // 
            this.btnEditAllowanceName.Enabled = false;
            this.btnEditAllowanceName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAllowanceName.Location = new System.Drawing.Point(356, 348);
            this.btnEditAllowanceName.Name = "btnEditAllowanceName";
            this.btnEditAllowanceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditAllowanceName.Size = new System.Drawing.Size(160, 36);
            this.btnEditAllowanceName.TabIndex = 8;
            this.btnEditAllowanceName.Text = "تعديل اسم البند";
            this.btnEditAllowanceName.UseVisualStyleBackColor = true;
            this.btnEditAllowanceName.Click += new System.EventHandler(this.btnEditAllowanceName_Click);
            // 
            // btnSaveEditAllowance
            // 
            this.btnSaveEditAllowance.Enabled = false;
            this.btnSaveEditAllowance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEditAllowance.Location = new System.Drawing.Point(292, 406);
            this.btnSaveEditAllowance.Name = "btnSaveEditAllowance";
            this.btnSaveEditAllowance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveEditAllowance.Size = new System.Drawing.Size(101, 36);
            this.btnSaveEditAllowance.TabIndex = 7;
            this.btnSaveEditAllowance.Text = "حفظ";
            this.btnSaveEditAllowance.UseVisualStyleBackColor = true;
            this.btnSaveEditAllowance.Click += new System.EventHandler(this.btnSaveEditAllowance_Click);
            // 
            // rbAddAllowance
            // 
            this.rbAddAllowance.AutoSize = true;
            this.rbAddAllowance.Checked = true;
            this.rbAddAllowance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAddAllowance.Location = new System.Drawing.Point(52, 27);
            this.rbAddAllowance.Name = "rbAddAllowance";
            this.rbAddAllowance.Size = new System.Drawing.Size(153, 23);
            this.rbAddAllowance.TabIndex = 24;
            this.rbAddAllowance.TabStop = true;
            this.rbAddAllowance.Text = "إضافة بند استقطاع";
            this.rbAddAllowance.UseVisualStyleBackColor = true;
            this.rbAddAllowance.CheckedChanged += new System.EventHandler(this.rbAddAllowance_CheckedChanged);
            // 
            // rbEditAllowance
            // 
            this.rbEditAllowance.AutoSize = true;
            this.rbEditAllowance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEditAllowance.Location = new System.Drawing.Point(38, 258);
            this.rbEditAllowance.Name = "rbEditAllowance";
            this.rbEditAllowance.Size = new System.Drawing.Size(163, 23);
            this.rbEditAllowance.TabIndex = 24;
            this.rbEditAllowance.Text = "تعديل بند الاستقطاع";
            this.rbEditAllowance.UseVisualStyleBackColor = true;
            this.rbEditAllowance.CheckedChanged += new System.EventHandler(this.rbEditAllowance_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(91, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(160, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "إلغاء تعديل الاسم";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDeductionsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 528);
            this.Controls.Add(this.txtAllowanceName);
            this.Controls.Add(this.txtNewAllowanceName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbEditAllowance);
            this.Controls.Add(this.cbDeductions);
            this.Controls.Add(this.rbAddAllowance);
            this.Controls.Add(this.btnDeleteAllowance);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEditAllowanceName);
            this.Controls.Add(this.btnSaveEditAllowance);
            this.Controls.Add(this.lbDeductions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "frmDeductionsManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إدارة الاستقطاعات";
            this.Load += new System.EventHandler(this.frmDeductionsManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDeductions;
        private System.Windows.Forms.TextBox txtAllowanceName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lbDeductions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveEditAllowance;
        private System.Windows.Forms.RadioButton rbAddAllowance;
        private System.Windows.Forms.RadioButton rbEditAllowance;
        private System.Windows.Forms.Button btnEditAllowanceName;
        private System.Windows.Forms.TextBox txtNewAllowanceName;
        private System.Windows.Forms.Button btnDeleteAllowance;
        private System.Windows.Forms.Button btnCancel;
    }
}