using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VAULT_BANK
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["FullName"] == null)
                {
                    try
                    {
                        CreateUserSessionForFullNameIfNotAvailable();
                        LoadUserProfile();
                    }
                    catch (Exception ex) 
                    {
                        string errorMessage = ex.Message.Replace("'", "\\'");
                        Response.Write($"<script>alert('{errorMessage}');</script>");
                    }
                }
                else
                {
                    LoadUserProfile();
                }
            }
        }

        private void CreateUserSessionForFullNameIfNotAvailable()
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Something Went Wrong... LOGIN AGAIN!');</script>");
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                string username = Session["username"].ToString();
                string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT FullName FROM AC_HOLDERS_DETAILS WHERE Username=@username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            Session["FullName"] = reader["FullName"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            UpdateProfile();
        }
        private void LoadUserProfile()
        {
            if (Session["FullName"] == null)
            {
                // Handle the case when the session is not set, e.g., redirect to login page
                Response.Redirect("Login.aspx");
                return;
            }

            string fullName = Session["FullName"].ToString();
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM AC_HOLDERS_DETAILS WHERE FullName=@FullName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        FullName.Text = reader["FullName"].ToString();
                        DateOfBirth.Text = Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd");
                        Email.Text = reader["Email"].ToString();
                        MobileNumber.Text = reader["MobileNumber"].ToString();
                        Gender.Text = reader["Gender"].ToString();
                        Occupation.Text = reader["Occupation"].ToString();
                        FatherName.Text = reader["FatherName"].ToString();
                        MotherName.Text = reader["MotherName"].ToString();
                        SpouseName.Text = reader["SpouseName"].ToString();
                        TotalMembers.Text = reader["TotalMembers"].ToString();
                        HomeMobileNumber.Text = reader["HomeMobileNumber"].ToString();
                        RelationWithFamily.Text = reader["RelationWithFamily"].ToString();
                        AddressType.Text = reader["AddressType"].ToString();
                        Nationality.Text = reader["Nationality"].ToString();
                        State.Text = reader["State"].ToString();
                        District.Text = reader["District"].ToString();
                        Address.Text = reader["Address"].ToString();
                        PinCode.Text = reader["PinCode"].ToString();
                        IDType.Text = reader["IDType"].ToString();
                        IDNumber.Text = reader["IDNumber"].ToString();
                        IssuedCountry.Text = reader["IssuedCountry"].ToString();
                        UPI.Text = reader["UPI_ID"].ToString();
                    }
                    reader.Close();
                }
            }
        }


        private void UpdateProfile()
        {
            if (Session["FullName"] == null)
            {
                // Handle the case when the session is not set, e.g., redirect to login page
                Response.Redirect("Login.aspx");
                return;
            }

            string fullName = Session["FullName"].ToString();
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE AC_HOLDERS_DETAILS SET 
                             FullName=@FullName, DateOfBirth=@DateOfBirth, Email=@Email, 
                             MobileNumber=@MobileNumber, Gender=@Gender, Occupation=@Occupation, 
                             FatherName=@FatherName, MotherName=@MotherName, SpouseName=@SpouseName, 
                             TotalMembers=@TotalMembers, HomeMobileNumber=@HomeMobileNumber, 
                             RelationWithFamily=@RelationWithFamily, AddressType=@AddressType, 
                             Nationality=@Nationality, State=@State, District=@District, 
                             Address=@Address, PinCode=@PinCode, IDType=@IDType, IDNumber=@IDNumber, 
                             IssuedCountry=@IssuedCountry, UPI_ID=@upi WHERE FullName=@SessionFullName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", FullName.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth.Text);
                    command.Parameters.AddWithValue("@Email", Email.Text);
                    command.Parameters.AddWithValue("@MobileNumber", MobileNumber.Text);
                    command.Parameters.AddWithValue("@Gender", Gender.Text);
                    command.Parameters.AddWithValue("@Occupation", Occupation.Text);
                    command.Parameters.AddWithValue("@FatherName", FatherName.Text);
                    command.Parameters.AddWithValue("@MotherName", MotherName.Text);
                    command.Parameters.AddWithValue("@SpouseName", SpouseName.Text);
                    command.Parameters.AddWithValue("@TotalMembers", TotalMembers.Text);
                    command.Parameters.AddWithValue("@HomeMobileNumber", HomeMobileNumber.Text);
                    command.Parameters.AddWithValue("@RelationWithFamily", RelationWithFamily.Text);
                    command.Parameters.AddWithValue("@AddressType", AddressType.Text);
                    command.Parameters.AddWithValue("@Nationality", Nationality.Text);
                    command.Parameters.AddWithValue("@State", State.Text);
                    command.Parameters.AddWithValue("@District", District.Text);
                    command.Parameters.AddWithValue("@Address", Address.Text);
                    command.Parameters.AddWithValue("@PinCode", PinCode.Text);
                    command.Parameters.AddWithValue("@IDType", IDType.Text);
                    command.Parameters.AddWithValue("@IDNumber", IDNumber.Text);
                    command.Parameters.AddWithValue("@IssuedCountry", IssuedCountry.Text);
                    command.Parameters.AddWithValue("@upi", UPI.Text);
                    command.Parameters.AddWithValue("@SessionFullName", fullName);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Show success message
            Response.Write("<script>alert('Profile updated successfully.');</script>");
        }

    }
}
