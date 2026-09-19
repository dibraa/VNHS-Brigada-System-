using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BrigadaEskwela_SoftwareDevelopment_II
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        //Global Connection String
        string cs = Global.Connection;


        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            FRM_StudentRegistration student = new FRM_StudentRegistration();
            student.ShowDialog();
        }

        //SUBMIT Student Registration
        public void StudentInformation()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_01_StudentInformation (Lname, Fname, Mname, Suffix, Gender, Birthdate, Religion, Mother_Tongue, BelongTo_IP, BelongTo_4Ps, ID_No, PSA_No, LRN_No, ContactNo, City_Municipality, Barangay, Region, Province, Subdivision, StreetNo) VALUES (@Lname, @Fname, @Mname, @Suffix, @Gender, @Birthdate, @Religion, @Mother_Tongue, @BelongTo_IP, @BelongTo_4Ps, @ID_No, @PSA_No, @LRN_No, @ContactNo, @City_Municipality, @Baranggay, @Region, @Province, @Subdivision, @StreetNo)");
                cmd.Connection = con;
                con.Open();
                // @Lname, @Fname, @Mname, @Suffix, @Gender, @Birthdate, @Religion, @Mother_Tongue, @BelongTo_IP, @BelongTo_4Ps, @ID_No, @PSA_No, @LRN_No, @ContactNo, @City_Municipality, @Baranggay, @Region, @Province, @Subdivision, @StreetNo)");
                cmd.Parameters.AddWithValue("@Lname", Lname.Text);
                cmd.Parameters.AddWithValue("@Fname", Fname.Text);
                cmd.Parameters.AddWithValue("@Mname", Mname.Text);
                cmd.Parameters.AddWithValue("@Suffix", Suffix.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender.Text);
                cmd.Parameters.AddWithValue("@Birthdate", Bday.Text);

                cmd.Parameters.AddWithValue("@Religion", Religion.Text);
                cmd.Parameters.AddWithValue("@Mother_Tongue", Mtongue.Text);
                cmd.Parameters.AddWithValue("@BelongTo_IP", Belong2IP.Text);
                cmd.Parameters.AddWithValue("@BelongTo_4Ps", BelongTo4Ps.Text);
                cmd.Parameters.AddWithValue("@ID_No", ID_Number.Text);

                cmd.Parameters.AddWithValue("@PSA_No", PSA_Number.Text);
                cmd.Parameters.AddWithValue("@LRN_No", LRN_Number.Text);
                cmd.Parameters.AddWithValue("@ContactNo", Contact.Text);
               
                cmd.Parameters.AddWithValue("@City_Municipality", CityCMBS.Text);
                cmd.Parameters.AddWithValue("@Baranggay", Barangay.Text);
                cmd.Parameters.AddWithValue("@Region", RegionCMBS.Text);
                cmd.Parameters.AddWithValue("@Province", ProvinceCMBS.Text);
                cmd.Parameters.AddWithValue("@Subdivision", Subdivision.Text);
                cmd.Parameters.AddWithValue("@StreetNo", StreetNo.Text);

                cmd.ExecuteNonQuery();
                con.Close();

            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }

        }
        //END SUBMIT Student Information

        //SUBMIT Student Registraion
        public void StudentRegistration()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_02_StudentRegistration (INSERT INTO TBL_01_StudentInformation (Lname, Fname, Mname, Suffix, Gender, Birthdate, Religion, Mother_Tongue, BelongTo_IP, BelongTo_4Ps, ID_No, PSA_No, LRN_No, ContactNo, City_Municipality, Barangay, Region, Province, Subdivision, StreetNo, LearnerStatus, PrevSchool, SchoolType, SY_Graduated, GradeLevel, SY_ToEnroll, Track, Strand, Specialization, UserName, Password) VALUES (@LearnerStatus, @PrevSchool, @SchoolType, @SY_Graduated, @GradeLevel, @SY_ToEnroll, @Track, @Strand, @Specialization, @UserName, @Password)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Lname", Lname.Text);
                cmd.Parameters.AddWithValue("@Fname", Fname.Text);
                cmd.Parameters.AddWithValue("@Mname", Mname.Text);
                cmd.Parameters.AddWithValue("@Suffix", Suffix.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender.Text);
                cmd.Parameters.AddWithValue("@Birthdate", Bday.Text);

                cmd.Parameters.AddWithValue("@Religion", Religion.Text);
                cmd.Parameters.AddWithValue("@Mother_Tongue", Mtongue.Text);
                cmd.Parameters.AddWithValue("@BelongTo_IP", Belong2IP.Text);
                cmd.Parameters.AddWithValue("@BelongTo_4Ps", BelongTo4Ps.Text);
                cmd.Parameters.AddWithValue("@ID_No", ID_Number.Text);

                cmd.Parameters.AddWithValue("@PSA_No", PSA_Number.Text);
                cmd.Parameters.AddWithValue("@LRN_No", LRN_Number.Text);
                cmd.Parameters.AddWithValue("@ContactNo", Contact.Text);

                cmd.Parameters.AddWithValue("@City_Municipality", CityCMBS.Text);
                cmd.Parameters.AddWithValue("@Baranggay", Barangay.Text);
                cmd.Parameters.AddWithValue("@Region", RegionCMBS.Text);
                cmd.Parameters.AddWithValue("@Province", ProvinceCMBS.Text);
                cmd.Parameters.AddWithValue("@Subdivision", Subdivision.Text);
                cmd.Parameters.AddWithValue("@StreetNo", StreetNo.Text);



                cmd.Parameters.AddWithValue("@LearnerStatus", LearnerStatsCMBS.Text);
                cmd.Parameters.AddWithValue("@PrevSchool", PrevSchool.Text);
                cmd.Parameters.AddWithValue("@SchoolType", SchType_cmbs.Text);
                cmd.Parameters.AddWithValue("@SY_Graduated", SyGraduatedCMBS.Text);
                cmd.Parameters.AddWithValue("@GradeLevel", GradeLevelCMBS.Text);

                cmd.Parameters.AddWithValue("@SY_ToEnroll", SyToEnrollCMBS.Text);
                cmd.Parameters.AddWithValue("@Track", TrackCMBS.Text);
                cmd.Parameters.AddWithValue("@Strand", StrandCMBS.Text);
                cmd.Parameters.AddWithValue("@Specialization ", SpecializedCMBS.Text);

                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password ", Password.Text);
                    

           
                



            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }
        } //END SUBMIT Student Registration




        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void RegBTN_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_01_StudentInformation (SchoolYear_ID, UserID,Lname, Fname, Mname, Suffix, Gender, Birthdate, Religion, Mother_Tongue, BelongTo_IP, BelongTo_4Ps, ID_No, PSA_No, LRN_No, ContactNo, City_Municipality, Barangay, Region, Province, Subdivision, StreetNo, LearnerStatus, PrevSchool, SchoolType, SY_Graduated, GradeLevel, SY_ToEnroll, Track, Strand, Specialization, UserName, Password, Student_Status) VALUES (@SchoolYear_ID,@UserID,@Lname, @Fname, @Mname, @Suffix, @Gender, @Birthdate, @Religion, @Mother_Tongue, @BelongTo_IP, @BelongTo_4Ps, @ID_No, @PSA_No, @LRN_No, @ContactNo, @City_Municipality, @Baranggay, @Region, @Province, @Subdivision, @StreetNo,@LearnerStatus, @PrevSchool, @SchoolType, @SY_Graduated, @GradeLevel, @SY_ToEnroll, @Track, @Strand, @Specialization, @UserName, @Password,@Student_Status)");
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Lname", Lname.Text);
                cmd.Parameters.AddWithValue("@Fname", Fname.Text);
                cmd.Parameters.AddWithValue("@Mname", Mname.Text);
                cmd.Parameters.AddWithValue("@Suffix", Suffix.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender.Text);
                cmd.Parameters.AddWithValue("@Birthdate", Bday.Text);

                cmd.Parameters.AddWithValue("@Religion", Religion.Text);
                cmd.Parameters.AddWithValue("@Mother_Tongue", Mtongue.Text);
                cmd.Parameters.AddWithValue("@BelongTo_IP", Belong2IP.Text);
                cmd.Parameters.AddWithValue("@BelongTo_4Ps", BelongTo4Ps.Text);
                cmd.Parameters.AddWithValue("@ID_No", ID_Number.Text);

                cmd.Parameters.AddWithValue("@PSA_No", PSA_Number.Text);
                cmd.Parameters.AddWithValue("@LRN_No", LRN_Number.Text);
                cmd.Parameters.AddWithValue("@ContactNo", Contact.Text);

                cmd.Parameters.AddWithValue("@City_Municipality", CityCMBS.Text);
                cmd.Parameters.AddWithValue("@Baranggay", Barangay.Text);
                cmd.Parameters.AddWithValue("@Region", RegionCMBS.Text);
                cmd.Parameters.AddWithValue("@Province", ProvinceCMBS.Text);
                cmd.Parameters.AddWithValue("@Subdivision", Subdivision.Text);
                cmd.Parameters.AddWithValue("@StreetNo", StreetNo.Text);



                cmd.Parameters.AddWithValue("@LearnerStatus", LearnerStatsCMBS.Text);
                cmd.Parameters.AddWithValue("@PrevSchool", PrevSchool.Text);
                cmd.Parameters.AddWithValue("@SchoolType", SchType_cmbs.Text);
                cmd.Parameters.AddWithValue("@SY_Graduated", SyGraduatedCMBS.Text);
                cmd.Parameters.AddWithValue("@GradeLevel", GradeLevelCMBS.Text);

                cmd.Parameters.AddWithValue("@SY_ToEnroll", SyToEnrollCMBS.Text);
                cmd.Parameters.AddWithValue("@Track", TrackCMBS.Text);
                cmd.Parameters.AddWithValue("@Strand", StrandCMBS.Text);
                cmd.Parameters.AddWithValue("@Specialization ", SpecializedCMBS.Text);

                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password ", Password.Text);

               string status = "1";
               cmd.Parameters.AddWithValue("@Student_Status", status);
               cmd.Parameters.AddWithValue("@SchoolYear_ID", Global.SchoolYearID);
               cmd.Parameters.AddWithValue("@UserID", Global.UserID);

                if (Password.Text.Trim().Equals(ConfirmPassword.Text, StringComparison.Ordinal))
                {
                    MessageBox.Show(Lname.Text + " " + Mname.Text + " " + Fname.Text + " " + " Successfully added!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmd.ExecuteNonQuery();
                    con.Close();

                   


                    Lname.Text = "";
                    Fname.Text = "";
                    Mname.Text = "";
                    Suffix.Text = "";
                    Gender.Text = "";
                    Bday.Text = "";
                    Religion.Text = "";
                    Mtongue.Text = "";
                    Belong2IP.Text = "";
                    BelongTo4Ps.Text = "";
                    ID_Number.Text = "";
                    PSA_Number.Text = "";
                    LRN_Number.Text = "";
                    Contact.Text = "";
                    CityCMBS.Text = "";
                    Barangay.Text = "";
                    RegionCMBS.Text = "";
                    ProvinceCMBS.Text = "";
                    Subdivision.Text = "";
                    StreetNo.Text = "";
                    LearnerStatsCMBS.Text = "";
                    PrevSchool.Text = "";
                    SchType_cmbs.Text = "";
                    SyGraduatedCMBS.Text = "";
                    GradeLevelCMBS.Text = "";
                    SyToEnrollCMBS.Text = "";
                    TrackCMBS.Text = "";
                    StrandCMBS.Text = "";
                    SpecializedCMBS.Text = "";
                    Username.Text = "";
                    Password.Text = "";
                    ConfirmPassword.Text = "";


                    //if (Lname.Text.Trim().Equals(" ", StringComparison.Ordinal) || Mname.Text.Trim().Equals(" ", StringComparison.Ordinal) || Fname.Text.Trim().Equals(" ", StringComparison.Ordinal))
                    //{
                    //    MessageBox.Show("No Saved Data. Please do not leave a blank in the form. Write N/A if form is Not Applicable", "No Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Password is not the same", "Could not Add Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfirmPassword.Text = "";
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving new student in error " + ex.Message);
            }

          


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
