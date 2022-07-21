<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="M3_database.Register" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" />
</head>
<body>
       <div class ="loginbox"> 
       <img src="img/user.png" alt =" Alternative Text" class ="user"/> 
        <h2>Log In Here</h2>
        <form runat="server">
            <asp:Label Text="Email" CssClass="lblemail" runat ="server" />
            <asp:TextBox ID="txt_username" runat="server" CssClass="txtemail" placeholder="Enter Email" />
            <asp:Label Text="Password" CssClass="lblpass"  runat="server" />
            <asp:TextBox ID="txt_password"  runat ="server" CssClass="txtpass" placeholder="********" />
             <asp:Button Text="Sign Up" CssClass="Signup"  runat="server"  />
            

        </form>
    </div>
</body>
</html>
