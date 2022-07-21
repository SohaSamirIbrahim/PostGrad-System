<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="M3_database.login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login1.css" rel="stylesheet" />
</head>
<body>
       <div class ="loginbox"> 
       <img src="img/user.png" alt =" Alternative Text" class ="user"/> 
        <h2>Log In Here</h2>
        <form runat="server">
            <asp:Label Text="Email" CssClass="lblemail" runat ="server" />
            <asp:TextBox ID="txt_username" runat="server" CssClass="txtemail" placeholder="Enter Email" TextMode="Email" />
            <asp:Label Text="Password" CssClass="lblpass"  runat="server" />
            <asp:TextBox ID="txt_password"  runat ="server" CssClass="txtpass" placeholder="********" TextMode="Password"/>
            <asp:Button Text="Sign In" CssClass="btnsubmit" runat="server" OnClick="signin"/>
             <asp:Button Text="Register" CssClass="Signup"  runat="server" OnClick="hazoum" />
            <br />
            <asp:Label ID="wrong" Text="wrong email or password" CssClass="wronggg"  runat="server" Visible="false"/>
        </form>
    </div>
</body>
</html>
