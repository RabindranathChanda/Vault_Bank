<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdraw.aspx.cs" Inherits="VAULT_BANK.Withdraw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Withdraw Money - VAULT BANK</title>
    <link rel="stylesheet" href="Static/css/dipositmoney.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">
            <div class="logo">VAULT BANK</div>
            <ul>
                <li><a href="Dashboard.aspx" ><i class="fas fa-home"></i> Home</a></li>
                <li><a href="Profile.aspx" ><i class="fas fa-user"></i> Profile</a></li>
                <li><a href="#" onclick="refreshPage()"><i class="fas fa-hand-holding-usd"></i> Withdraw</a></li>
                <li><a href="DipositMoney.aspx"><i class="fas fa-donate"></i> Deposit</a></li>
                <li><a href="AllTransaction.aspx"><i class="fas fa-money-check-alt"></i> Transactions</a></li>
                <li><a href="PaymentGateway.aspx"><i class="fas fa-credit-card"></i> Payment Gateway</a></li>
                <li><a href="Accounts.aspx"><i class="fas fa-wallet"></i> Accounts</a></li>
                <li><a href="Settings.aspx"><i class="fas fa-cog"></i> Settings</a></li>
            </ul>
        </div>

        <div class="main-content">
            <div class="header">
                <h2>Withdraw Money</h2>
            </div>
            <div class="content">
                <div class="card">
                    <h3>Withdraw Money</h3>
                    <asp:TextBox ID="withdrawAmount" runat="server" placeholder="Amount" CssClass="input-box"></asp:TextBox>
                    <asp:Button ID="withdrawBtn" runat="server" Text="Withdraw" CssClass="button" OnClick="Withdraw_Click" />
                </div>
                <div class="card">
                    <h3>Account Balance</h3>
                    <p id="BalanceInfo" runat="server"></p>
                </div>
            </div>
            <div class="card">
                <h3>Recent Transactions</h3>
                <asp:GridView ID="TransactionGridView" runat="server" CssClass="transaction-grid" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="UPIID" HeaderText="UPI ID" />
                        <asp:BoundField DataField="DateTime" HeaderText="Date & Time" />
                        <asp:BoundField DataField="Particulars" HeaderText="Particulars" />
                        <asp:BoundField DataField="DebitAmt" HeaderText="Amt(Dr.)" />
                        <asp:BoundField DataField="CreditAmt" HeaderText="Amt(Cr.)" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="showAllTransactionsBtn" runat="server" Text="Show All Transactions" CssClass="button" OnClick="ShowAllTransactions_Click" />
            </div>
        </div>
    </form>
    <script>
    function refreshPage() {
        window.location.reload();
    }
    </script>
</body>
</html>