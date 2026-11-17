namespace HR_MS
{
    partial class frmPrintDialyworkersSalaries
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
            this.cbMonths = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.rbFirst = new System.Windows.Forms.RadioButton();
            this.rbThird = new System.Windows.Forms.RadioButton();
            this.rbSecond = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
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
            this.cbMonths.Location = new System.Drawing.Point(117, 35);
            this.cbMonths.Name = "cbMonths";
            this.cbMonths.Size = new System.Drawing.Size(127, 27);
            this.cbMonths.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnPrint.Location = new System.Drawing.Point(48, 175);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 46);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(38, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "الشهر:";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnExit.Location = new System.Drawing.Point(205, 175);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 46);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbFirst
            // 
            this.rbFirst.AutoSize = true;
            this.rbFirst.Checked = true;
            this.rbFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbFirst.Location = new System.Drawing.Point(59, 77);
            this.rbFirst.Name = "rbFirst";
            this.rbFirst.Size = new System.Drawing.Size(85, 24);
            this.rbFirst.TabIndex = 3;
            this.rbFirst.TabStop = true;
            this.rbFirst.Text = "بداية الشهر";
            this.rbFirst.UseVisualStyleBackColor = true;
            // 
            // rbThird
            // 
            this.rbThird.AutoSize = true;
            this.rbThird.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbThird.Location = new System.Drawing.Point(59, 137);
            this.rbThird.Name = "rbThird";
            this.rbThird.Size = new System.Drawing.Size(81, 24);
            this.rbThird.TabIndex = 3;
            this.rbThird.Text = "آخر الشهر";
            this.rbThird.UseVisualStyleBackColor = true;
            // 
            // rbSecond
            // 
            this.rbSecond.AutoSize = true;
            this.rbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbSecond.Location = new System.Drawing.Point(59, 107);
            this.rbSecond.Name = "rbSecond";
            this.rbSecond.Size = new System.Drawing.Size(101, 24);
            this.rbSecond.TabIndex = 3;
            this.rbSecond.Text = "منتصف الشهر";
            this.rbSecond.UseVisualStyleBackColor = true;
            // 
            // frmDialyworkersSalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 233);
            this.Controls.Add(this.rbSecond);
            this.Controls.Add(this.rbThird);
            this.Controls.Add(this.rbFirst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbMonths);
            this.Name = "frmDialyworkersSalaries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "طباعة المرتبات";
            this.Load += new System.EventHandler(this.frmPrintSalaries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMonths;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rbFirst;
        private System.Windows.Forms.RadioButton rbThird;
        private System.Windows.Forms.RadioButton rbSecond;
    }
}