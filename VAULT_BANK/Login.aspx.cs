using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VAULT_BANK;

namespace VAULT_BANK
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void signBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = unametbx.Text;
            string password = passtbx.Text;
            if (Session["username"]==null)
            {
                Session["username"]=username;
            }

            if (IsValidUser(username, password))
            {
                // Redirect to dashboard
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                // Display error message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid username or password');", true);
            }
        }
        private bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            // Update connection string as needed
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Normal_Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    isValid = count > 0;
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine(ex.Message);
                }
            }

            return isValid;
        }

    }
}