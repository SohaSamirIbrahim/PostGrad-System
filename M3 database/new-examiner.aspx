<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new-examiner.aspx.cs" Inherits="project1.new_examiner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="register-student.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginbox6">
                        <asp:Label Text="name" CssClass="lblname" runat ="server" />
            <asp:TextBox ID="name" runat="server" CssClass="txttype" placeholder="ENTER NAME" required="true"/>
       
            <br />
       
            <asp:Label Text="Email" CssClass="lblemail" runat ="server" />
            <asp:TextBox ID="email" runat="server" CssClass="txtemail" placeholder="Enter Email" required="true" />
            <asp:Label Text="Password" CssClass="lblpass"  runat="server" />
            <asp:TextBox ID="password"  runat ="server" CssClass="txtpass" placeholder="********" required="true" />

            <asp:Label Text="fieldOfWork" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="fieldOfWork"  runat ="server" CssClass="txttype" placeholder="field of work" required="true" />
            <br />
            <br />
            <asp:RadioButton ID="national" text="national" groupname="nationality" runat="server" CssClass="Gucian" OnCheckedChanged="national_CheckedChanged"  required="true"/>
            <asp:RadioButton ID="international" text="international" groupname="nationality" runat="server" CssClass="Gucian" OnCheckedChanged="international_CheckedChanged" required="true" />
            <br />
            <br />
                        <asp:Button Text="ADD" CssClass="Signup"  runat="server" OnClick="Unnamed5_Click"   />
            <br />

        </div>
    </form>
</body>
</html>
