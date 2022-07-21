<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addpubNon.aspx.cs" Inherits="M3_database.addpubNon" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link href="Student.css" rel="stylesheet" />
</head>
<body>
   <div class ="loginbox"> 
       <div class="navbar">  
       <img src="../img/guclogo.png"  alt =" Alternative Text" class ="logo"/>
       <ul>
             <li class="normal" ><a href="viewnonGucianProfile.aspx" >My Profile</a></li>
            <li class="normal"> <a href="viewNonThesis.aspx" >My Theses</a></li>
           <li class="normal" ><a href="courses.aspx"  >Courses</a></li>
           <li class="normal" ><a href="addfillNon.aspx"  >Add/fill Progress Report</a></li>
           <li class="meeow" >  add a publication </li>
       </ul>
           </div>

        <form runat="server">
            <div>
            <asp:Label Text="title" CssClass="lblname"  runat="server"  />
            <asp:TextBox ID="title"  runat ="server" CssClass="txttype" placeholder="Enter title" required="true" />
            <asp:Label Text="pubDate" CssClass="lblname" runat ="server" />
            <asp:TextBox ID="pubDate" runat="server" CssClass="cal" placeholder="Publication date" TextMode="Date" required="true"/>

                <asp:Label Text="host" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="host"  runat ="server" CssClass="txttype" placeholder="Enter Host name" required="true" />
                <asp:CheckBox ID="CheckBox1" Text="accepted" runat="server" CssClass="check"/>
                <br />
                <asp:Label Text="place" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="place"  runat ="server" CssClass="txttype" placeholder="place" required="true" />
       <asp:Label Text="Thesis SerialNumber" CssClass="lblname"  runat="server" />
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="title2" DataValueField="title2" CssClass="drop" required="true">

                </asp:DropDownList>
               
               

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="liststudentongoing" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="" Name="studentID" SessionField="user" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Button Text="Add publication" CssClass="button3" runat="server"  onclick="addpub"/>
                   <br />
                            <asp:Label ID="pubadded" Text="Publication added Successfully ✔️" CssClass="lblname" ForeColor="#00ff00"  runat="server" visible="false"/>
                            <asp:Label ID="pubfailed" Text="publication couldn't be added, please re-check the data you entered" CssClass="lblname" ForeColor="Red"  runat="server" visible="false"/>


          </div>

            </form>
    </div>
</body>
</html>
