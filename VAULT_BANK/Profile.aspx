<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="VAULT_BANK.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Profile - VAULT BANK</title>
    <link rel="stylesheet" href="Static/css/profile.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">
            <div class="logo">VAULT BANK</div>
            <ul>
                <li><a href="Dashboard.aspx"><i class="fas fa-home"></i>Home</a></li>
                <li><a href="#" onclick="refreshPage()"><i class="fas fa-user"></i>Profile</a></li>
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
                <h2>User Profile</h2>
            </div>
            <div class="profile-form">
                <asp:Label ID="FullNameLabel" runat="server" Text="Full Name" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="FullName" runat="server" CssClass="input-box" Placeholder="Full Name"></asp:TextBox>

                <asp:Label ID="DateOfBirthLabel" runat="server" Text="Date of Birth" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="DateOfBirth" runat="server" CssClass="input-box" Placeholder="Date of Birth"></asp:TextBox>

                <asp:Label ID="EmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Email" runat="server" CssClass="input-box" Placeholder="Email"></asp:TextBox>

                <asp:Label ID="MobileNumberLabel" runat="server" Text="Mobile Number" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="MobileNumber" runat="server" CssClass="input-box" Placeholder="Mobile Number"></asp:TextBox>

                <asp:Label ID="GenderLabel" runat="server" Text="Gender" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Gender" runat="server" CssClass="input-box" Placeholder="Gender"></asp:TextBox>

                <asp:Label ID="OccupationLabel" runat="server" Text="Occupation" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Occupation" runat="server" CssClass="input-box" Placeholder="Occupation"></asp:TextBox>

                <asp:Label ID="FatherNameLabel" runat="server" Text="Father's Name" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="FatherName" runat="server" CssClass="input-box" Placeholder="Father's Name"></asp:TextBox>

                <asp:Label ID="MotherNameLabel" runat="server" Text="Mother's Name" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="MotherName" runat="server" CssClass="input-box" Placeholder="Mother's Name"></asp:TextBox>

                <asp:Label ID="SpouseNameLabel" runat="server" Text="Spouse's Name" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="SpouseName" runat="server" CssClass="input-box" Placeholder="Spouse's Name"></asp:TextBox>

                <asp:Label ID="TotalMembersLabel" runat="server" Text="Total Members" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TotalMembers" runat="server" CssClass="input-box" Placeholder="Total Members"></asp:TextBox>

                <asp:Label ID="HomeMobileNumberLabel" runat="server" Text="Home Mobile Number" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="HomeMobileNumber" runat="server" CssClass="input-box" Placeholder="Home Mobile Number"></asp:TextBox>

                <asp:Label ID="RelationWithFamilyLabel" runat="server" Text="Relation With Family" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="RelationWithFamily" runat="server" CssClass="input-box" Placeholder="Relation With Family"></asp:TextBox>

                <asp:Label ID="AddressTypeLabel" runat="server" Text="Address Type" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="AddressType" runat="server" CssClass="input-box" Placeholder="Address Type"></asp:TextBox>

                <asp:Label ID="NationalityLabel" runat="server" Text="Nationality" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Nationality" runat="server" CssClass="input-box" Placeholder="Nationality"></asp:TextBox>

                <asp:Label ID="StateLabel" runat="server" Text="State" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="State" runat="server" CssClass="input-box" Placeholder="State"></asp:TextBox>

                <asp:Label ID="DistrictLabel" runat="server" Text="District" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="District" runat="server" CssClass="input-box" Placeholder="District"></asp:TextBox>

                <asp:Label ID="AddressLabel" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="Address" runat="server" CssClass="input-box" Placeholder="Address"></asp:TextBox>

                <asp:Label ID="PinCodeLabel" runat="server" Text="Pin Code" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="PinCode" runat="server" CssClass="input-box" Placeholder="Pin Code"></asp:TextBox>

                <asp:Label ID="IDTypeLabel" runat="server" Text="ID Type" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="IDType" runat="server" CssClass="input-box" Placeholder="ID Type"></asp:TextBox>

                <asp:Label ID="IDNumberLabel" runat="server" Text="ID Number" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="IDNumber" runat="server" CssClass="input-box" Placeholder="ID Number"></asp:TextBox>

                <asp:Label ID="IssuedCountryLabel" runat="server" Text="Issued Country" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="IssuedCountry" runat="server" CssClass="input-box" Placeholder="Issued Country"></asp:TextBox>
                
                <asp:Label ID="UPI_ID" runat="server" Text="UPI_ID" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="UPI" runat="server" CssClass="input-box" ReadOnly="true" Placeholder="UPI_ID"></asp:TextBox>

                <asp:Button ID="SaveBtn" runat="server" Text="Save Changes" CssClass="button" OnClick="SaveBtn_Click" />
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