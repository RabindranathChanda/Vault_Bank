<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllTransaction.aspx.cs" Inherits="VAULT_BANK.AllTransaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>All Transactions - VAULT BANK</title>
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
                <li><a href="Withdraw.aspx"><i class="fas fa-hand-holding-usd"></i> Withdraw</a></li>
                <li><a href="DipositMoney.aspx"><i class="fas fa-donate"></i> Deposit</a></li>
                <li><a href="#" onclick="refreshPage()"><i class="fas fa-money-check-alt"></i> Transactions</a></li>
                <li><a href="PaymentGateway.aspx"><i class="fas fa-credit-card"></i> Payment Gateway</a></li>
                <li><a href="Accounts.aspx"><i class="fas fa-wallet"></i> Accounts</a></li>
                <li><a href="Settings.aspx"><i class="fas fa-cog"></i> Settings</a></li>
            </ul>
        </div>

        <div class="main-content">
            <div class="header">
                <h2>All Transactions</h2>
            </div>         
            <div class="card">
                <h3>Recent Transactions</h3>
                <asp:GridView ID="TransactionGridView" runat="server" CssClass="transaction-grid" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="DateTime" HeaderText="Date & Time" />
                        <asp:BoundField DataField="UPIID" HeaderText="UPI ID" />
                        <asp:BoundField DataField="Particulars" HeaderText="Particulars" />
                        <asp:BoundField DataField="DebitAmt" HeaderText="Amt(Dr.)" />
                        <asp:BoundField DataField="CreditAmt" HeaderText="Amt(Cr.)" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                    </Columns>
                </asp:GridView>                
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
