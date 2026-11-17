using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_MS
{
    public partial class frmEmployeeOfficialDocuments : Adjust
    {
        int EmpID;
        int EmployeeDrivingLicenceID;
        int EmployeeNationalIdentityID;
        int EmployeeIdentityCardID;
        int EmployeePassportID;
        int EmployeeBirthCertificateID;
        int EmployeeNationalityID;
        int EmpoyeesMilitryServiceRealseID;
        string EmpName;

        List<OfficialDocuments> OfficialDocs = new List<OfficialDocuments>();
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        OfficialDocuments IdentityCardList, NationalIdent;
        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
            return ms.ToArray();
        }

        public void db_InsertationOfficialDocument(OfficialDocuments OfficlalDocument)
        {
            switch (OfficlalDocument.DocType)
            {
                case "NationalIdentification":
                    if (MessageBox.Show("هل تود إضافة الرقم الوطني إلى سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlIns = "INSERT INTO db_owner.EmpNationalIdentityDoc " +
                                @"(EmpNationalIdentityID, EmpNationalIdentityDocID ,EmpID," +
                                @"EmpNationalIdentityDocIssueDate,EmpNationalIdentityDocIssuePlace," +
                                @"EmpNationalIdentityDocPicture) " +
                                @" VALUES (@ID,@DocID, @EmpID,@IssueDate , " +
                                @"@IssuePlace,@Picure)";

                        SqlConn.Open();
                        try
                        {
                            SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                            cmdIns.Parameters.AddWithValue("@ID", EmployeeNationalIdentityID);
                            cmdIns.Parameters.AddWithValue("@DocID", OfficlalDocument.DocID);
                            cmdIns.Parameters.AddWithValue("@EmpID", EmpID);
                            cmdIns.Parameters.AddWithValue("@IssueDate", OfficlalDocument.DocIssueDate);
                            cmdIns.Parameters.AddWithValue("@IssuePlace", OfficlalDocument.IssuePlace);
                            cmdIns.Parameters.AddWithValue("@Picure", imageToByteArray(OfficlalDocument.DocPicture[0]));

                            cmdIns.ExecuteNonQuery();

                            cmdIns.Parameters.Clear();

                            cmdIns.Dispose();
                            cmdIns = null;

                            MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {
                            SqlConn.Close();

                        }
                    }
                    break;
                case "IdentityCard":
                    {
                        if (MessageBox.Show("هل تود إضافة البطاقة الشخصية إلى سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sqlIns = "INSERT INTO db_owner.EmployeesIdentityCardDocs " +
                                    @"(EmpIdentityCardID, EmpIdentityCardDocID ,EmpID," +
                                    @"EmpIdentityCardIssueDate,EmpIdentityCardExpDate," +
                                    @"EmpIdentityCardIssuePlace," +
                                    @"EmpIdentityCardFacePicture,EmpIdentityCardBackPicture) " +
                                    @" VALUES (@ID,@DocID ,@EmpID, @IssueDate ,@ExpDate, " +
                                    @"@IssuePlace,@FacePicure,@BackPicure)";

                            SqlConn.Open();
                            try
                            {
                                SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                                cmdIns.Parameters.AddWithValue("@ID", EmployeeIdentityCardID);
                                cmdIns.Parameters.AddWithValue("@DocID", OfficlalDocument.DocID);
                                cmdIns.Parameters.AddWithValue("@EmpID", EmpID);
                                cmdIns.Parameters.AddWithValue("@IssueDate", OfficlalDocument.DocIssueDate);
                                cmdIns.Parameters.AddWithValue("@ExpDate", OfficlalDocument.DocExpDate);
                                cmdIns.Parameters.AddWithValue("@IssuePlace", OfficlalDocument.IssuePlace);
                                cmdIns.Parameters.AddWithValue("@FacePicure", imageToByteArray(OfficlalDocument.DocPicture[0]));
                                cmdIns.Parameters.AddWithValue("@BackPicure", imageToByteArray(OfficlalDocument.DocPicture[1]));

                                cmdIns.ExecuteNonQuery();

                                cmdIns.Parameters.Clear();
                                //cmdIns.CommandText = "SELECT @@IDENTITY";

                                cmdIns.Dispose();
                                cmdIns = null;

                                MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            finally
                            {
                                SqlConn.Close();

                            }
                        }
                        break;
                    }
            }
        }
        public void InitializeEmployeeDrivingLicenceID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpDrivLicID = new SqlDataAdapter("Select EmpDrivingLicenceID from db_Owner.EmployeesDrivingLicenceDocs", SqlConn);
            DataTable dtGetEmpDrivLicID = new DataTable();
            daGetEmpDrivLicID.Fill(dtGetEmpDrivLicID);
            if (dtGetEmpDrivLicID.Rows.Count == 0)
            {
                EmployeeDrivingLicenceID = 1;
            }
            else
            {
                EmployeeDrivingLicenceID = Convert.ToInt32(dtGetEmpDrivLicID.Rows[dtGetEmpDrivLicID.Rows.Count - 1][0].ToString()) + 1;
            }
        }

        public void InitializeEmployeePassportID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpPassportID = new SqlDataAdapter("Select EmployeesPassportsID from db_Owner.EmployeesPassports", SqlConn);
            DataTable dtGetEmpPassportID = new DataTable();
            daGetEmpPassportID.Fill(dtGetEmpPassportID);
            if (dtGetEmpPassportID.Rows.Count == 0)
            {
                EmployeePassportID = 1;
            }
            else
            {
                EmployeePassportID = Convert.ToInt32(dtGetEmpPassportID.Rows[dtGetEmpPassportID.Rows.Count - 1][0].ToString()) + 1;
            }
        }


        public void InitializeEmployeeNationalIdentityID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpNatIdentID = new SqlDataAdapter("Select EmpNationalIdentityID from db_Owner.EmpNationalIdentityDoc", SqlConn);
            DataTable dtGetEmpNatIdentID = new DataTable();
            daGetEmpNatIdentID.Fill(dtGetEmpNatIdentID);
            if (dtGetEmpNatIdentID.Rows.Count == 0)
            {
                EmployeeNationalIdentityID = 1;
            }
            else
            {
                EmployeeNationalIdentityID = Convert.ToInt32(dtGetEmpNatIdentID.Rows[dtGetEmpNatIdentID.Rows.Count - 1][0].ToString()) + 1;
            }
        }

        public void InitializeEmployeeIdentityCardID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpIdentCardID = new SqlDataAdapter("Select EmpIdentityCardID from db_Owner.EmployeesIdentityCardDocs", SqlConn);
            DataTable dtGetEmpIdentCardID = new DataTable();
            daGetEmpIdentCardID.Fill(dtGetEmpIdentCardID);
            if (dtGetEmpIdentCardID.Rows.Count == 0)
            {
                EmployeeIdentityCardID = 1;
            }
            else
            {
                EmployeeIdentityCardID = Convert.ToInt32(dtGetEmpIdentCardID.Rows[dtGetEmpIdentCardID.Rows.Count - 1][0].ToString()) + 1;
            }
        }

        public void InitializeEmployeeNationalityID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpoyeeNatID = new SqlDataAdapter("Select EmpNationalityID from db_Owner.EmpoyeesNationalityDoc", SqlConn);
            DataTable dtGetEmpoyeeNatID = new DataTable();
            daGetEmpoyeeNatID.Fill(dtGetEmpoyeeNatID);
            if (dtGetEmpoyeeNatID.Rows.Count == 0)
            {
                EmployeeNationalityID = 1;
            }
            else
            {
                EmployeeNationalityID = Convert.ToInt32(dtGetEmpoyeeNatID.Rows[dtGetEmpoyeeNatID.Rows.Count - 1][0].ToString()) + 1;
            }
        }

        public void InitializeEmployeesMilitryServiceRealseID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpMilitryServRelID = new SqlDataAdapter("Select EmpNationalityID from db_Owner.EmployeesMilitryServiceRealseDocs", SqlConn);
            DataTable dtGetEmpMilitryServRelID = new DataTable();
            daGetEmpMilitryServRelID.Fill(dtGetEmpMilitryServRelID);
            if (dtGetEmpMilitryServRelID.Rows.Count == 0)
            {
                EmpoyeesMilitryServiceRealseID = 1;
            }
            else
            {
                EmpoyeesMilitryServiceRealseID = Convert.ToInt32(dtGetEmpMilitryServRelID.Rows[dtGetEmpMilitryServRelID.Rows.Count - 1][0].ToString()) + 1;
            }
        }

        public void InitializeEmployeeBirthCertificateID()
        {
            //Initialize DocumentsIdentifications

            SqlDataAdapter daGetEmpBirthCertID = new SqlDataAdapter("Select EmpBirthCertificateID from db_Owner.EmployeesBirthCertificates", SqlConn);
            DataTable dtGetEmpBirthCertID = new DataTable();
            daGetEmpBirthCertID.Fill(dtGetEmpBirthCertID);
            if (dtGetEmpBirthCertID.Rows.Count == 0)
            {
                EmployeeBirthCertificateID = 1;
            }
            else
            {
                EmployeeBirthCertificateID = Convert.ToInt32(dtGetEmpBirthCertID.Rows[dtGetEmpBirthCertID.Rows.Count - 1][0].ToString()) + 1;
            }
        }

        public frmEmployeeOfficialDocuments(int EmployeeID, string EmployeeName)
        {
            InitializeComponent();
            this.EmpID = EmployeeID;
            this.EmpName = EmployeeName;
        }

        private void frmEmployeeOfficialDocuments_Load(object sender, EventArgs e)
        {
            InitializeEmployeeNationalIdentityID();
            InitializeEmployeeIdentityCardID();
            this.txtFileID.Text = EmpID.ToString();
            this.txtEmpName.Text = EmpName;
            this.tabDocumentDetails.Controls["NationalityDoc"].Visible = false;
            this.MedicalCard.Dispose();
            this.NationalityDoc.Dispose();
            this.Passport.Dispose();
            this.DrivingLicence.Dispose();
            this.BirthCertificate.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int Index = 0; Index < this.OfficialDocs.Count; Index++)
            {
                db_InsertationOfficialDocument(this.OfficialDocs[Index]);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NationalIdentification_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtNatID.Enabled = false;
            this.dtpNatIDDocIssueDate.Enabled = false;
            this.txtNatIDIssuePlace.Enabled = false;
        }

        private void btnAddNatID_Click(object sender, EventArgs e)
        {

            if (OfficialDocs.Contains(NationalIdent))
            {
                for (int i = 0; i < OfficialDocs.Count; i++)
                {
                    if (OfficialDocs[i].DocType == "NationalIdentification")
                    {
                        OfficialDocs[i].DocType = "NationalIdentification";
                        OfficialDocs[i].DocID = this.txtNatID.Text;
                        OfficialDocs[i].DocIssueDate = this.dtpNatIDDocIssueDate.Value;
                        OfficialDocs[i].IssuePlace = this.txtNatIDIssuePlace.Text;
                        OfficialDocs[i].DocPicture[0]= this.picbNatIDPicture.Image;
                    }
                }
            }
               
            else 
            {
                NationalIdent = new OfficialDocuments();
                NationalIdent.DocType = "NationalIdentification";
                NationalIdent.DocID = this.txtNatID.Text;
                NationalIdent.DocIssueDate = this.dtpNatIDDocIssueDate.Value;
                NationalIdent.IssuePlace = this.txtNatIDIssuePlace.Text;
                NationalIdent.DocPicture[0] = this.picbNatIDPicture.Image;
                OfficialDocs.Add(NationalIdent);
            }
            this.txtNatID.Enabled = false;
            this.dtpNatIDDocIssueDate.Enabled = false;
            this.txtNatIDIssuePlace.Enabled = false;
            this.btnAddNatIDPicture.Enabled = false;
            this.btnAddNatID.Enabled = false;
            this.btnُEditNatID.Enabled = true;
        }

        private void btnAddNatIDPicture_Click(object sender, EventArgs e)
        {
            DialogNationalIdentificationDocScan DialogNatIdentDocScan = new DialogNationalIdentificationDocScan(true);
            DialogNatIdentDocScan.ShowDialog();
        }

        private void btnAddIdentityCardFacePicture_Click(object sender, EventArgs e)
        {
            DialogIdentityCardDocScan DialogIDCardDocScan = new DialogIdentityCardDocScan(true);
            DialogIDCardDocScan.ShowDialog();
        }

        private void btnAddIdentityCard_Click(object sender, EventArgs e)
        {

            if (OfficialDocs.Contains(IdentityCardList))
            {
                for (int i = 0; i < OfficialDocs.Count; i++)
                {
                    if (OfficialDocs[i].DocType == "IdentityCard")
                    {
                        OfficialDocs[i].DocType = "IdentityCard";
                        OfficialDocs[i].DocID = this.txtIdentityCardID.Text;
                        OfficialDocs[i].DocIssueDate = this.dtpIdentityCardIssueDate.Value;
                        OfficialDocs[i].DocExpDate = this.dtpIdentityCardExpDate.Value;
                        OfficialDocs[i].IssuePlace = this.txtIdentityCardIssuePlace.Text;
                        OfficialDocs[i].DocPicture[0] = this.picbIdentityCardFacePicture.Image;
                        OfficialDocs[i].DocPicture[1] = this.picbIdentityCardBackPicture.Image;
                    }
                }
            }
            else
            {
                IdentityCardList = new OfficialDocuments();
                IdentityCardList.DocType = "IdentityCard";
                IdentityCardList.DocID = this.txtIdentityCardID.Text;
                IdentityCardList.DocIssueDate = this.dtpIdentityCardIssueDate.Value;
                IdentityCardList.DocExpDate = this.dtpIdentityCardExpDate.Value;
                IdentityCardList.IssuePlace = this.txtIdentityCardIssuePlace.Text;
                IdentityCardList.DocPicture[0] = this.picbIdentityCardFacePicture.Image;
                IdentityCardList.DocPicture[1] = this.picbIdentityCardFacePicture.Image;
                OfficialDocs.Add(IdentityCardList);
            }

            this.txtIdentityCardID.Enabled = false;
            this.dtpIdentityCardIssueDate.Enabled = false;
            this.dtpIdentityCardExpDate.Enabled = false;
            this.txtIdentityCardIssuePlace.Enabled = false;
            this.btnAddIdentityCardPicture.Enabled = false;
            this.btnAddIdentityCard.Enabled = false;
            this.btnEditIdentityCard.Enabled = true;


        }

        private void btnAddNatDoc_Click(object sender, EventArgs e)
        {

        }

        private void btnُEditNatID_Click(object sender, EventArgs e)
        {
            this.txtNatID.Enabled = true;
            this.dtpNatIDDocIssueDate.Enabled = true;
            this.txtNatIDIssuePlace.Enabled = true;
            this.btnAddNatIDPicture.Enabled = true;
            this.btnAddNatID.Enabled = true;
            this.btnُEditNatID.Enabled = false;
        }

        private void btnEditIdentityCard_Click(object sender, EventArgs e)
        {
            this.txtIdentityCardID.Enabled = true;
            this.dtpIdentityCardIssueDate.Enabled = true;
            this.dtpIdentityCardExpDate.Enabled = true;
            this.txtIdentityCardIssuePlace.Enabled = true;
            this.btnAddIdentityCardPicture.Enabled = true;
            this.btnAddIdentityCard.Enabled = true;
            this.btnEditIdentityCard.Enabled = false;
        }
    }
}