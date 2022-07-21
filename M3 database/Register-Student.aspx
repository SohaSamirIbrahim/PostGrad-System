<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register-Student.aspx.cs" Inherits="M3_database.Register_Student" %>

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

        <form id="form1" runat="server">
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
            <asp:Label Text="address" CssClass="lblname" runat ="server" />
            <asp:TextBox ID="address" runat="server" CssClass="txttype" placeholder="address" required="true"/>
            <br />
            <asp:Label Text="GPA" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="GPA"  runat ="server" CssClass="txttype" placeholder="Enter your GPA " required="true"/>
                    <asp:TextBox ID="phone"  runat="server" CssClass="txttype" placeholder="phone number" required="true" />
                 <asp:Button ID="phoneplus" runat="server" OnClick="Phoneplus" Text="+" CssClass="plus"  />
                  <div id="Div1" runat="server" visible="true" class="mobile"></div>
                  <div id="a" runat="server" visible="true" class="mobile"></div>

             <br />
            <br />
                        <asp:RadioButton id="Gucian" Text="Gucian" GroupName="RegularMenu" runat="server" cssclass="Gucian" AutoPostBack="true" OnCheckedChanged="GucianU"/>
                        <asp:RadioButton id="NonGucian" Text="nonGucian" GroupName="RegularMenu" runat="server" cssclass="Gucian" AutoPostBack="true" OnCheckedChanged="nonGucian" />
            <br />
                        <asp:Label ID="radioUnchecked" Text="Please check Guican or NonGucian" CssClass="wronggg"  runat="server" Visible="false"/>

            <br />
            <asp:Label ID="underGradd" Text="UnderGrad ID" CssClass="lblname"  runat="server" Visible="false"/>
            <asp:TextBox ID="UnderGradID"  runat ="server" CssClass="txttype" placeholder="UnderGrad ID " Visible="false" required="true" TextMode="Number"/>
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
            <br />

            <br />

                 </form>
    </div>
       </body>
</html>