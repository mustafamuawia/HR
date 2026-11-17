namespace HR_MS
{
    partial class frmDatabaseSettings
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
            this.lblServerName = new System.Windows.Forms.Label();
            this.cbServerName = new System.Windows.Forms.ComboBox();
            this.btnConnectionTest = new System.Windows.Forms.Button();
            this.cbDataBases = new System.Windows.Forms.ComboBox();
            this.lblDataBases = new System.Windows.Forms.Label();
            this.btnGetDatabaseServers = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInistanceName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(53, 37);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblServerName.Size = new System.Drawing.Size(99, 19);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "اسم المخدم:";
            // 
            // cbServerName
            // 
            this.cbServerName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbServerName.FormattingEnabled = true;
            this.cbServerName.Location = new System.Drawing.Point(163, 37);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbServerName.Size = new System.Drawing.Size(175, 27);
            this.cbServerName.TabIndex = 1;
            this.cbServerName.SelectedIndexChanged += new System.EventHandler(this.cbServerName_SelectedIndexChanged);
            // 
            // btnConnectionTest
            // 
            this.btnConnectionTest.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConnectionTest.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectionTest.Location = new System.Drawing.Point(370, 120);
            this.btnConnectionTest.Name = "btnConnectionTest";
            this.btnConnectionTest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnConnectionTest.Size = new System.Drawing.Size(145, 27);
            this.btnConnectionTest.TabIndex = 4;
            this.btnConnectionTest.Text = "اختبار الاتصال";
            this.btnConnectionTest.UseVisualStyleBackColor = true;
            this.btnConnectionTest.Click += new System.EventHandler(this.btnConnectionTest_Click);
            // 
            // cbDataBases
            // 
            this.cbDataBases.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataBases.FormattingEnabled = true;
            this.cbDataBases.Location = new System.Drawing.Point(163, 120);
            this.cbDataBases.Name = "cbDataBases";
            this.cbDataBases.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDataBases.Size = new System.Drawing.Size(175, 27);
            this.cbDataBases.TabIndex = 3;
            this.cbDataBases.SelectedIndexChanged += new System.EventHandler(this.cbDataBases_SelectedIndexChanged);
            this.cbDataBases.DropDown += new System.EventHandler(this.cbDataBases_DropDown);
            // 
            // lblDataBases
            // 
            this.lblDataBases.AutoSize = true;
            this.lblDataBases.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBases.Location = new System.Drawing.Point(53, 120);
            this.lblDataBases.Name = "lblDataBases";
            this.lblDataBases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDataBases.Size = new System.Drawing.Size(104, 19);
            this.lblDataBases.TabIndex = 3;
            this.lblDataBases.Text = "قواعد البيانات:";
            // 
            // btnGetDatabaseServers
            // 
            this.btnGetDatabaseServers.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGetDatabaseServers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetDatabaseServers.Location = new System.Drawing.Point(370, 34);
            this.btnGetDatabaseServers.Name = "btnGetDatabaseServers";
            this.btnGetDatabaseServers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGetDatabaseServers.Size = new System.Drawing.Size(145, 27);
            this.btnGetDatabaseServers.TabIndex = 2;
            this.btnGetDatabaseServers.Text = "ابحث عن المخدم";
            this.btnGetDatabaseServers.UseVisualStyleBackColor = true;
            this.btnGetDatabaseServers.Click += new System.EventHandler(this.btnGetDatabaseServers_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(145, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(129, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "حفظ الإعدادات";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(322, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(129, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 80);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المثيل:";
            // 
            // cbInistanceName
            // 
            this.cbInistanceName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInistanceName.FormattingEnabled = true;
            this.cbInistanceName.Location = new System.Drawing.Point(163, 80);
            this.cbInistanceName.Name = "cbInistanceName";
            this.cbInistanceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbInistanceName.Size = new System.Drawing.Size(175, 27);
            this.cbInistanceName.TabIndex = 3;
            this.cbInistanceName.SelectedIndexChanged += new System.EventHandler(this.cbInistanceName_SelectedIndexChanged);
            // 
            // frmDatabaseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGetDatabaseServers);
            this.Controls.Add(this.cbDataBases);
            this.Controls.Add(this.lblDataBases);
            this.Controls.Add(this.btnConnectionTest);
            this.Controls.Add(this.cbInistanceName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbServerName);
            this.Controls.Add(this.lblServerName);
            this.Name = "frmDatabaseSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إعدادات قواعد البيانات";
            this.Load += new System.EventHandler(this.frmDatabaseSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.ComboBox cbServerName;
        private System.Windows.Forms.Button btnConnectionTest;
        private System.Windows.Forms.ComboBox cbDataBases;
        private System.Windows.Forms.Label lblDataBases;
        private System.Windows.Forms.Button btnGetDatabaseServers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInistanceName;
    }
}