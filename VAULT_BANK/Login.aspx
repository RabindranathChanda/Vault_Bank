<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VAULT_BANK.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN - VAULT BANK Pvt. Ltd.</title>
    <link rel="stylesheet" href="Static/css/login.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"/>
</head>
<body>
    <div class="container">
        <div class="screen">
            <div class="screen__content">
                <div class="bank-logo">
                    <img class="vault-logo" src="Static/img/vaulttran.png" alt="VAULT BANK PVT. LTD."/>
                </div><br/><br/>
                    <form id="form1" runat="server" class="login">
                        <asp:TextBox ID="unametbx" runat="server" placeholder="Username or Email" Cssclass="login__input"></asp:TextBox><br/><br/>
                        <asp:TextBox ID="passtbx" runat="server" placeholder="Password" Cssclass="login__input" TextMode="Password"></asp:TextBox>

                    <asp:Button ID="loginBtn" runat="server" class="button login__submit" Text="Log In Now" OnClick="loginBtn_Click" />
                    <asp:Button ID="signBtn" runat="server" class="button login__submit" Text="Sign Up Now" OnClick="signBtn_Click" /> 
                    </form>
                <div class="social-login">
                    <h3>log in via</h3>
                    <div class="social-icons">
                        <a href="#" class="social-login__icon far fa-envelope-open"></a>
                        <a href="#" class="social-login__icon fab fa-facebook"></a>
                        <a href="#" class="social-login__icon fab fa-twitter"></a>
                    </div>
                </div>
            </div>
            <div class="screen__background">
                <span class="screen__background__shape screen__background__shape4"></span>
                <span class="screen__background__shape screen__background__shape3"></span>		
                <span class="screen__background__shape screen__background__shape2"></span>
                <span class="screen__background__shape screen__background__shape1"></span>
            </div>		
        </div>
    </div>

</body>
</html>
