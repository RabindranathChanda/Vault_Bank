using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VAULT_BANK
{
    public partial class DipositMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactions();
            }
        }
        private void LoadTransactions()
        {
            if (Session["upiid"]==null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (Session["CurrentBalance"]==null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            else
            {
                BalanceInfo.InnerText = "₹" + Session["CurrentBalance"].ToString();
            }

            string upiId = Session["upiid"].ToString(); 
            string connString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT TOP 5 UPIID, DateTime, Particulars, DebitAmt, CreditAmt, Remarks FROM Transactions WHERE UPIID = @UPIID ORDER BY id DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UPIID", upiId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TransactionGridView.DataSource = dt;
                    TransactionGridView.DataBind();
                }
                else
                {
                    // Optional: Display a message if no data is found
                    TransactionGridView.DataSource = null;
                    TransactionGridView.DataBind();
                }
            }
        }        
        

        protected void ShowAllTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllTransaction.aspx");
        }

        protected void DipositMoney_Click(object sender, EventArgs e)
        {
            int amttodip = Convert.ToInt32(dipositAmount.Text);
            try
            {
                // Ensure the UPIID and current balance are present in the session
                if (Session["upiid"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                if (Session["CurrentBalance"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                string upiId = Session["upiid"].ToString();
                int currentBalance = Convert.ToInt32(Session["CurrentBalance"]);


                // Update the database
                string connString = "Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=VAULT_BANK;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Insert a new transaction record
                    string insertQuery = "INSERT INTO Transactions (UPIID, DateTime, Particulars, DebitAmt, CreditAmt, Remarks) VALUES (@UPIID, @DateTime, @Particulars, @DebitAmt, @CreditAmt, @Remarks)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@UPIID", upiId);
                    insertCmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@Particulars", "Amount Deposit to Bank");
                    insertCmd.Parameters.AddWithValue("@DebitAmt", DBNull.Value); // No debit amount
                    insertCmd.Parameters.AddWithValue("@CreditAmt", amttodip);
                    insertCmd.Parameters.AddWithValue("@Remarks", "Deposit");

                    insertCmd.ExecuteNonQuery();

                    // Update the account balance
                    string updateQuery = "UPDATE AC_HOLDERS_DETAILS SET Current_Balance = @Balance WHERE UPI_ID = @UPIID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Balance", Convert.ToInt32(currentBalance + amttodip));
                    updateCmd.Parameters.AddWithValue("@UPIID", upiId);

                    updateCmd.ExecuteNonQuery();
                }

                // Update the session and display a success message
                Session["CurrentBalance"] = (currentBalance + amttodip).ToString();
                // Reload transactions and update the balance display
                LoadTransactions();
            }
            catch (Exception ex)
            {
                // Handle errors and display the error message
                Response.Write($"Error: {ex.Message}");
            }


        }
    }
}