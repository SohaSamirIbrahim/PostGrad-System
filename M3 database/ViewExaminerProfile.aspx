<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewExaminerProfile.aspx.cs" Inherits="M3_database.ViewExaminerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Examiner.css" rel="stylesheet" />

</head>
<body>
    <div class ="loginbox"> 
       <div class="navbar">  
       <img src="../img/guclogo.png"  alt =" Alternative Text" class ="logo"/>
       <ul>
           <li class="meeow" > My Profile</></li>
           <li class="normal" ><a href="Examiner-login.aspx" >Defense Control Panel</a></li>
           <li class="normal" ><a href="Search.aspx" >Search</a></li>
       </ul>
           </div>

   <div class ="loginbox2"> 
          <img src="../img/avatar8.png"  alt =" Alternative Text" class ="avatar"/>
            <style>
            .vl {
              border-left: 4px solid #ed4e13;
              height: 100%;
            }
            </style>

            <div class="vl"></div>

        <form runat="server">
        <div class="text">
          <asp:Label ID="Label1" Text= "Name: "  CssClass="lblcard" runat ="server" />
            <asp:Label ID="name" Text= "Name"  CssClass="lblcard" runat ="server" />
            <asp:TextBox ID="newname" visible="false" runat="server" placeholder="Enter new name" CssClass="txtname2"></asp:TextBox>
             <style>
            .vl2 {
            }
            </style>
            <div class="vl2"></div>

              <br />
             <asp:Label  ID="Label2" Text="Field of work :  " CssClass="lblcard"  runat="server" />    
            <asp:Label  ID="fieldOfwork" Text="Field of work" CssClass="lblcard"  runat="server" />
            <asp:TextBox ID="field" runat="server" visible="false" placeholder="Enter new field" CssClass="txtname2"></asp:TextBox>

            
            <style>
            .vl3 {
             
            }
            </style>
            <div class="vl3"></div>
      <br />

            <asp:Label ID="National" Text="National" CssClass="lblcard" runat ="server" />
            <asp:checkbox ID ="Nationalcheck" runat="server" Enabled="false" /> 
       <br /><br />
              <style>
            .vl4 {
          
            }
            </style>

            <div class="vl4"></div><br />
                 <asp:Label ID="Label3" Text="Email: " CssClass="lblcard" runat ="server" />
            <asp:Label ID="ExaminerEmail" Text="Email" CssClass="lblcard" runat ="server" />
         </div>


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="viewExaminer" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="id" SessionField="user" Type="Int32" />
                    </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="viewEaminarProfile" Visible="false" runat="server"   AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="fieldOfWork" HeaderText="fieldOfWork" SortExpression="fieldOfWork" />
                    <asp:BoundField DataField="isNational" HeaderText="isNational" />
                </Columns>
            </asp:GridView>
         
              
        <div>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
             <asp:Label ID="Label4" Text="ID:" CssClass="lblcard2" runat ="server" />
            <asp:Label ID="ExamID" Text="xxxx" CssClass="lblcard3" runat ="server" />
            <br />
            <asp:Button ID="Button_edit"  Text="Edit data" OnClick="editProfile_Click" runat="server" CssClass="button4"/>
          <asp:Button ID="submitedit" visible="false" runat="server" Text="Submit" OnClick="submit_Click" CssClass="button4"/>

        </div>
            
        </form>
            </div>
    </div>
</body>
</html>
