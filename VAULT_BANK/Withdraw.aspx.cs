using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VAULT_BANK
{
    public partial class Withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CurrentBalance"] != null && Session["upiid"] != null)
                {
                    BalanceInfo.InnerText = Session["CurrentBalance"].ToString();
                    LoadTransactions();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        private void LoadTransactions()
        {
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
        protected void Withdraw_Click(object sender, EventArgs e)
        {
            int amttowd = Convert.ToInt32(withdrawAmount.Text);
            try
            {
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
                    insertCmd.Parameters.AddWithValue("@Particulars", "Amount Withdraw from Bank");
                    insertCmd.Parameters.AddWithValue("@DebitAmt", amttowd); // No debit amount
                    insertCmd.Parameters.AddWithValue("@CreditAmt", DBNull.Value);
                    insertCmd.Parameters.AddWithValue("@Remarks", "Withdraw");
                    insertCmd.ExecuteNonQuery();

                    // Update the account balance
                    string updateQuery = "UPDATE AC_HOLDERS_DETAILS SET Current_Balance = @Balance WHERE UPI_ID = @UPIID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Balance", Convert.ToInt32(currentBalance - amttowd));
                    updateCmd.Parameters.AddWithValue("@UPIID", upiId);

                    updateCmd.ExecuteNonQuery();
                }

                // Update the session and display a success message
                Session["CurrentBalance"] = (currentBalance - amttowd).ToString();
                // Reload transactions and update the balance display
                BalanceInfo.InnerText = Session["CurrentBalance"].ToString();
                LoadTransactions();
            }
            catch (Exception ex)
            {
                // Handle errors and display the error message
                Response.Write($"Error: {ex.Message}");
            }

        }

        protected void ShowAllTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllTransaction.aspx");
        }
    }
}