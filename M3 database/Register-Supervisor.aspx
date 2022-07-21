<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register-Supervisor.aspx.cs" Inherits="M3_database.Register_Supervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="register-student.css" rel="stylesheet" />

</head>
<body>
   
        <div class ="loginbox"> 
       <img src="img/user.png" alt =" Alternative Text" class ="user"/> 
        <h2>Register Here</h2>

        <form id="form2" runat="server">
            <asp:Label Text="firstname" CssClass="lblname" runat ="server" />
            <asp:TextBox ID="firstname" runat="server" CssClass="txttype" placeholder="First Name" required="true"/>
            <asp:Label Text="lastname" CssClass="lblname"  runat="server" /> 
            <asp:TextBox ID="lastname"  runat ="server" CssClass="txttype" placeholder="Last Name" required="true"/>
       
            <asp:Label Text="Email" CssClass="lblemail" runat ="server" />
            <asp:TextBox ID="email" runat="server" CssClass="txtemail" placeholder="Enter Email" required="true" TextMode="Email" />
            <asp:Label Text="Password" CssClass="lblpass"  runat="server" />
            <asp:TextBox ID="password"  runat ="server" CssClass="txtpass" placeholder="********" required="true" />

            <asp:Label Text="faculty" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="faculty"  runat ="server" CssClass="txttype" placeholder="faculty name" required="true" />
     
            <br />
                        <asp:Button Text="Sign Up" CssClass="Signup"  runat="server" OnClick="signupclick"  />
            <br />
            <br />
                                <asp:Label ID="wrong" Text="An account already exists with this email address" CssClass="wronggg"  runat="server" Visible="false"/>
            <br />
            <br />
            <br />
            <div class="navbar">  

    <asp:Panel ID="Exists" runat="server" Visible="false">
        <ul>
           <li class="normal"> <a href="login.aspx" >Sign in instead?</a></li>
       </ul>

    </asp:Panel>
                </div>

                 </form>
    </div>

</body>
</html>
