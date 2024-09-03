<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VAULT_BANK.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration of New User</title>
    <link rel="stylesheet" href="Static/css/register.css"/>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css"/>
</head>
<body>
    <div class="container">
        <header>
            Registration            
        </header>
        <form id="form1" runat="server">  
            <div class="form first">
                <div class="details personal">
                    <span class="title">Personal Details</span>
                    <div class="fields">
                             
                         
                        <div class="input-field">
                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Full Name *"></asp:Label>
                            <asp:TextBox ID="fnametbx" runat="server" placeholder="Enter your name"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Date of Birth *"></asp:Label>
                            <asp:TextBox ID="dobtbx" runat="server" placeholder="Enter birth date" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="Email *"></asp:Label>
                            <asp:TextBox ID="emailtbx" runat="server" placeholder="Enter your email" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Mobile Number *"></asp:Label>
                            <asp:TextBox ID="mobnotbx" runat="server" placeholder="Enter mobile number" TextMode="Number"></asp:TextBox>

                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label5" CssClass="label" runat="server" Text="Gender *"></asp:Label>
                            <asp:DropDownList ID="Select1" CssClass="select" runat="server">
                                <asp:ListItem Text="Select gender" Value="" />
                                <asp:ListItem Text="Male" Value="Male" />
                                <asp:ListItem Text="Female" Value="Female" />
                                <asp:ListItem Text="Others" Value="Others" />
                            </asp:DropDownList>


                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label6" CssClass="label" runat="server" Text="Occupation *"></asp:Label>
                            <asp:TextBox ID="occupationtbx" runat="server" placeholder="Enter your occupation"></asp:TextBox>
                        </div>
                    </div>                    
                </div>
                <div class="details family">
                    <span class="title">Family Details</span>
                    <div class="fields">
                        <div class="input-field">
                            <asp:Label ID="Label7" CssClass="label" runat="server" Text="Father Name *"></asp:Label>
                            <asp:TextBox ID="fathersnametbx" runat="server" placeholder="Enter father name"></asp:TextBox>

                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label8" CssClass="label" runat="server" Text="Mother Name *"></asp:Label>
                            <asp:TextBox ID="mothersnametbx" runat="server" placeholder="Enter mother name"></asp:TextBox>
                        </div>                        
                        <div class="input-field">
                            <asp:Label ID="Label9" CssClass="label" runat="server" Text="Spouse Name *"></asp:Label>
                            <asp:TextBox ID="spousenametbx" runat="server" placeholder="Enter spouse name"></asp:TextBox>
                        </div>       
                        <div class="input-field">
                            <asp:Label ID="Label10" CssClass="label" runat="server" Text="Total Members *"></asp:Label>
                            <asp:TextBox ID="totalmemberstbx" runat="server" placeholder="Total Member. ex.3" TextMode="Number"></asp:TextBox>
                        </div> 
                        <div class="input-field">                            
                            <asp:Label ID="Label11" CssClass="label" runat="server" Text="Home Mobile Number *"></asp:Label>
                            <asp:TextBox ID="fmobnotbx" runat="server" placeholder="Enter Mobile Number" TextMode="Number"></asp:TextBox>
                        </div> 
                        <div class="input-field">
                            <asp:Label ID="Label12" CssClass="label" runat="server" Text="Relation With Family *"></asp:Label>
                            <asp:TextBox ID="relationtbx" runat="server" placeholder="eg. Elder Son/Daugh"></asp:TextBox>
                        </div>                  
                    </div>                   
                    <asp:Button ID="NextButton" runat="server" CssClass="backBtn" Text="Next" OnClick="NextButton_Click" />
                </div>                 
            </div>
            <div class="form second">
                <div class="details address">
                    <span class="title">Address Details</span>
                    <div class="fields">
                        <div class="input-field">
                            <asp:Label ID="Label13" CssClass="label" runat="server" Text="Address Type *"></asp:Label>
                            <asp:TextBox ID="addtypetbx" runat="server" placeholder="Permanent or Temporary"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label14" CssClass="label" runat="server" Text="Nationality *"></asp:Label>
                            <asp:TextBox ID="nationalitytbx" runat="server" placeholder="Enter nationality"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label15" CssClass="label" runat="server" Text="State *"></asp:Label>
                            <asp:TextBox ID="statetbx" runat="server" placeholder="Enter your state"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label16" CssClass="label" runat="server" Text="District *"></asp:Label>
                            <asp:TextBox ID="districttbx" runat="server" placeholder="Enter your district"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label17" CssClass="label" runat="server" Text="Address *"></asp:Label>
                            <asp:TextBox ID="addresstbx" runat="server" placeholder="Enter address"></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label18" CssClass="label" runat="server" Text="Pin Code *"></asp:Label>
                            <asp:TextBox ID="pincodetbx" runat="server" placeholder="Enter pin code" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="details ID">
                    <span class="title">Identity Details</span>
                    <div class="fields">
                        <div class="input-field">
                            <asp:Label ID="Label19" CssClass="label" runat="server" Text="ID Type"></asp:Label>
                            <asp:TextBox ID="idtypetbx" runat="server" placeholder="eg. Aadhaar / Pan Card" ></asp:TextBox>
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label20" CssClass="label" runat="server" Text="ID Number"></asp:Label>
                            <asp:TextBox ID="idnumbertbx" runat="server" placeholder="eg. Aadhaar / Pan Card Number" TextMode="Number" ></asp:TextBox>                            
                        </div>
                        <div class="input-field">
                            <asp:Label ID="Label21" CssClass="label" runat="server" Text="Issued Country"></asp:Label>
                            <asp:TextBox ID="idcountrytbx" runat="server" placeholder="Enter issued Country"></asp:TextBox>
                        </div>                        
                    </div>                   
                    <div class="buttons">
                        <asp:Button ID="BackButton" runat="server" CssClass="backBtn" Text="Back" OnClick="BackButton_Click" />
                        <asp:Button ID="SubmitButton" runat="server" CssClass="backBtn" Text="Submit" OnClick="SubmitButton_Click" />
                    </div>
                </div>                 
            </div>
        </form>
    </div>
    <script src="Static/js/register.js"></script>
</body>
</html>
