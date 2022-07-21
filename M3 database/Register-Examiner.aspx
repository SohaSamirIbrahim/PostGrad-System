<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register-Examiner.aspx.cs" Inherits="M3_database.Register_Examiner" %>

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
            <asp:Label Text="name" CssClass="lblname" runat ="server" />
            <asp:TextBox ID="name" runat="server" CssClass="txttype" placeholder="ENTER NAME" required="true"/>
       
            <br />
       
            <asp:Label Text="Email" CssClass="lblemail" runat ="server" />
            <asp:TextBox ID="email" runat="server" CssClass="txtemail" placeholder="Enter Email" required="true" TextMode="Email" />
            <asp:Label Text="Password" CssClass="lblpass"  runat="server" />
            <asp:TextBox ID="password"  runat ="server" CssClass="txtpass" placeholder="********" required="true" />

            <asp:Label Text="fieldOfWork" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="fieldOfWork"  runat ="server" CssClass="txttype" placeholder="field of work" required="true" />
            <br />
            <br />
            <asp:RadioButton ID="national" text="national" groupname="nationality" runat="server" CssClass="Gucian" OnCheckedChanged="national_CheckedChanged" required="true"/>
            <asp:RadioButton ID="international" text="international" groupname="nationality" runat="server" CssClass="Gucian" OnCheckedChanged="international_CheckedChanged" />
            <br />                    
            <asp:Label ID="radioUnchecked" Text="Please check one of the nationalities" CssClass="wronggg"  runat="server" Visible="false"/>
            <br />
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
