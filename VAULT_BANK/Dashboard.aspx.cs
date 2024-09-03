using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VAULT_BANK
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["username"] != null)
            {
                currentusr.Text = FetchCurrentBalanceAndUpiIdUsingUserName().fullName;
                upiIDlbl.Text = FetchCurrentBalanceAndUpiIdUsingUserName().upiid;
                Session["upiid"] = upiIDlbl.Text;
                BalanceInfo.InnerText = "₹" + FetchCurrentBalanceAndUpiIdUsingUserName().balance.ToString();
                Session["CurrentBalance"] = FetchCurrentBalanceAndUpiIdUsingUserName().balance;
            }
            else if(Session["FullName"]!=null)
            {
                currentusr.Text = Session["FullName"].ToString();
                currentbal.Text = FetchCurrentBalanceAndUpiIdUsingFullName().balance.ToString();
                Session["CurrentBalance"] = FetchCurrentBalanceAndUpiIdUsingFullName().balance;
                upiIDlbl.Text = FetchCurrentBalanceAndUpiIdUsingFullName().upiid;
                Session["upiid"] = upiIDlbl.Text;

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
        // -----------
        private (int balance, string upiid, string fullName) FetchCurrentBalanceAndUpiIdUsingUserName()
        {
            // Initialize variables
            int balance = 0; // Use int directly instead of string
            string upiid = "";
            string fullName = "";

            // Check if the session variable is set
            if (Session["username"] == null)
            {
                throw new InvalidOperationException("Session username is not set.");
            }

            string userName = Session["username"].ToString();
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FullName, Current_Balance, UPI_ID FROM AC_HOLDERS_DETAILS WHERE Username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", userName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fullName = reader["FullName"].ToString();

                            // Ensure conversion from string to int is safe
                            if (int.TryParse(reader["Current_Balance"].ToString(), out int parsedBalance))
                            {
                                balance = parsedBalance;
                            }
                            else
                            {
                                throw new InvalidOperationException("Unable to parse Current_Balance to integer.");
                            }

                            upiid = reader["UPI_ID"].ToString();
                        }
                    }
                }
            }

            return (balance, upiid, fullName);
        }


        private (int balance, string upiid) FetchCurrentBalanceAndUpiIdUsingFullName()
        {
            // Initialize variables
            int balance = 0; // Use int directly
            string upiid = "";

            // Check if the session variable is set
            if (Session["FullName"] == null)
            {
                throw new InvalidOperationException("Session FullName is not set.");
            }

            string fullName = Session["FullName"].ToString();
            string connectionString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Current_Balance, UPI_ID FROM AC_HOLDERS_DETAILS WHERE FullName = @fullname";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullname", fullName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve data
                            if (int.TryParse(reader["Current_Balance"].ToString(), out int parsedBalance))
                            {
                                balance = parsedBalance;
                            }
                            else
                            {
                                throw new InvalidOperationException("Unable to parse Current_Balance to integer.");
                            }

                            upiid = reader["UPI_ID"].ToString();
                        }
                        else
                        {
                            // Handle the case where no data is returned
                            throw new InvalidOperationException("No records found for the given FullName.");
                        }
                    }
                }
            }

            return (balance, upiid);
        }



        protected void WithdrawMoney_Click(object sender, EventArgs e)
        {

        }

        protected void DepositMoney_Click(object sender, EventArgs e)
        {

        }



        [WebMethod]
        public static void DestroySession()
        {
            // Destroy the session
            HttpContext.Current.Session.Abandon();
        }
    }
}