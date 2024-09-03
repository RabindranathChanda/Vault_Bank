<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="VAULT_BANK.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard - VAULT BANK</title>
    <link rel="stylesheet" href="Static/css/dashboard.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">
            <div class="logo">VAULT BANK</div>
            <ul>
                <li><a href="#" onclick="refreshPage()"><i class="fas fa-home"></i>Home</a></li>
                <li><a href="Profile.aspx"><i class="fas fa-user"></i>Profile</a></li>
                <li><a href="Withdraw.aspx"><i class="fas fa-hand-holding-usd"></i>Withdraw</a></li>
                <li><a href="DipositMoney.aspx"><i class="fas fa-donate"></i>Deposit</a></li>
                <li><a href="AllTransaction.aspx"><i class="fas fa-money-check-alt"></i>Transactions</a></li>
                <li><a href="#"><i class="fas fa-credit-card"></i>Payment Gateway</a></li>
                <li><a href="#"><i class="fas fa-wallet"></i>Accounts</a></li>
                <li><a href="#"><i class="fas fa-cog"></i>Settings</a></li>
            </ul>
        </div>
        <div class="main-content">
            <div class="header">
                <h2>Welcome,</h2>
                <div class="user-info">
                    <span>
                        <asp:Label ID="currentbal" runat="server" CssClass="curbal" Text=""></asp:Label> 
                    </span>
                    <span>
                        <asp:Label ID="upiIDlbl" runat="server" Text=""></asp:Label> 
                    </span>
                    <span><i class="fas fa-user-circle"></i>
                        <asp:Label ID="currentusr" runat="server" Text=""></asp:Label> 
                    </span>
                    <a href="#" onclick="destroySession()"><i class="fas fa-sign-out-alt"></i> Logout</a>

                </div>
            </div>
            
            <div class="content">
                <div class="card">
                    <h3>Account Balance</h3>
                    <p id="BalanceInfo" runat="server"></p>
                </div>
                <div class="card">
                    <h3>Recent Transactions</h3>
                    <ul>
                        <li>Deposit: $1,000</li>
                        <li>Withdrawal: $200</li>
                        <li>Transfer: $500</li>
                        <li>Payment: $300</li>
                        <li>Transfer: $150</li>
                    </ul>
                </div>
                <div class="card">
                    <h3>Withdraw Money</h3>
                    <asp:TextBox ID="withdrawAmount" runat="server" placeholder="Amount" CssClass="input-box"></asp:TextBox>
                    <asp:Button ID="withdrawBtn" runat="server" Text="Withdraw" CssClass="button" OnClick="WithdrawMoney_Click" />
                </div>
                <div class="card">
                    <h3>Deposit Money</h3>
                    <asp:TextBox ID="depositAmount" runat="server" placeholder="Amount" CssClass="input-box"></asp:TextBox>
                    <asp:Button ID="depositBtn" runat="server" Text="Deposit" CssClass="button" OnClick="DepositMoney_Click" />
                </div>
            </div>
        </div>
    </form>

    <script>
        function refreshPage() {
            window.location.reload();
        }
        function destroySession() {
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "Dashboard.aspx/DestroySession", true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    // Redirect to login page after session is destroyed
                    window.location.href = "Login.aspx";
                }
            };
            xhr.send();
        }
    </script>
</body>
</html>
