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
    public partial class AllTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["upiid"]!=null)
                {
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
                string query = "SELECT UPIID, DateTime, Particulars, DebitAmt, CreditAmt, Remarks FROM Transactions WHERE UPIID = @UPIID ORDER BY id DESC";

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
    }
}