using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VAULT_BANK
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialization code, if needed
            }
        }
        protected void NextButton_Click(object sender, EventArgs e)
        {
            form1.Attributes["class"] = "secActive";
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            form1.Attributes["class"] = form1.Attributes["class"].Replace("secActive", "").Trim();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            if (IsValidForm())
            {
                try
                {
                    SaveToDatabase();
                    string fullName = fnametbx.Text;
                    Session["FullName"] = fullName;
                    string username = GenerateUsername(fullName);
                    string password = GeneratePassword();
                    Session["upiid"] = GenerateUpiId(mobnotbx.Text);

                    SendEmail(emailtbx.Text, username, password);
                    SaveLoginDetails(username,password);
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    // Log error and show message
                    Console.WriteLine(ex.Message);
                    // Display a message to the user
                }
            }
        }
        private bool IsValidForm()
        {
            // Validate form data
            return !string.IsNullOrWhiteSpace(fnametbx.Text) &&
                   DateTime.TryParse(dobtbx.Text, out _) &&
                   !string.IsNullOrWhiteSpace(emailtbx.Text) &&
                   Select1.SelectedIndex > 0 &&
                   int.TryParse(totalmemberstbx.Text, out _) &&
                   !string.IsNullOrWhiteSpace(mobnotbx.Text);
        }

        private void SaveToDatabase()
        {
            //string connectionString = WebConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AC_HOLDERS_DETAILS (FullName, DateOfBirth, Email, MobileNumber, Gender, Occupation, " +
                               "FatherName, MotherName, SpouseName, TotalMembers, HomeMobileNumber, RelationWithFamily, " +
                               "AddressType, Nationality, State, District, Address, PinCode, IDType, IDNumber, IssuedCountry, UPI_ID, Username, Current_Balance) " +
                               "VALUES (@FullName, @DateOfBirth, @Email, @MobileNumber, @Gender, @Occupation, " +
                               "@FatherName, @MotherName, @SpouseName, @TotalMembers, @HomeMobileNumber, @RelationWithFamily, " +
                               "@AddressType, @Nationality, @State, @District, @Address, @PinCode, @IDType, @IDNumber, @IssuedCountry, @UPI, @UN, @CB)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fnametbx.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dobtbx.Text); 
                    command.Parameters.AddWithValue("@Email", emailtbx.Text);
                    command.Parameters.AddWithValue("@MobileNumber", mobnotbx.Text);
                    command.Parameters.AddWithValue("@Gender", Select1.SelectedValue);
                    command.Parameters.AddWithValue("@Occupation", occupationtbx.Text);
                    command.Parameters.AddWithValue("@FatherName", fathersnametbx.Text);
                    command.Parameters.AddWithValue("@MotherName", mothersnametbx.Text);
                    command.Parameters.AddWithValue("@SpouseName", spousenametbx.Text);
                    command.Parameters.AddWithValue("@TotalMembers", totalmemberstbx.Text);
                    command.Parameters.AddWithValue("@HomeMobileNumber", fmobnotbx.Text);
                    command.Parameters.AddWithValue("@RelationWithFamily", relationtbx.Text);
                    command.Parameters.AddWithValue("@AddressType", addtypetbx.Text);
                    command.Parameters.AddWithValue("@Nationality", nationalitytbx.Text);
                    command.Parameters.AddWithValue("@State", statetbx.Text);
                    command.Parameters.AddWithValue("@District", districttbx.Text);
                    command.Parameters.AddWithValue("@Address", addresstbx.Text);
                    command.Parameters.AddWithValue("@PinCode", pincodetbx.Text);
                    command.Parameters.AddWithValue("@IDType", idtypetbx.Text);
                    command.Parameters.AddWithValue("@IDNumber", idnumbertbx.Text);
                    command.Parameters.AddWithValue("@UN", GenerateUsername(fnametbx.Text));
                    command.Parameters.AddWithValue("@IssuedCountry", idcountrytbx.Text);
                    command.Parameters.AddWithValue("@UPI", GenerateUpiId(mobnotbx.Text));
                    int a = 00;
                    command.Parameters.AddWithValue("@CB", a);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private string GenerateUpiId(string userPhoneNumber)
        {
            return $"{userPhoneNumber}@vault";
        }
        public static string GenerateUsername(string fullName)
        {
            string[] names = fullName.Split(' ');
            string username = names[0].ToLower() + "_normal_user@vaultb.com";
            return username;
        }

        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            var passwordChars = new char[15];

            for (int i = 0; i < passwordChars.Length; i++)
            {
                passwordChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(passwordChars);
        }
        public void SaveLoginDetails(string username, string password)
        {
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";
            string query = "INSERT INTO Normal_Users (Username, Password) VALUES (@Username, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Login details saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
        public static void SendEmail(string toEmail, string username, string password)
        {
            string fromEmail = "yourmail@gmail.com";
            string emailPassword = "aaaa bbbb cccc dddd"; // Use an App Password for Gmail
            string subject = "AUTOGENERATED VAULT BANK - LOGIN DETAILS";
            string body = $"Username: {username}\nPassword: {password}";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, emailPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

    }
}