<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="M3_database.courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="Student.css" rel="stylesheet" />
</head>
<body>
   <div class ="loginbox"> 
        
       <div class="navbar">  
       <img src="img/guclogo.png"  alt =" Alternative Text" class ="logo"/>
       <ul>
           <li class="normal" ><a href="viewnonGucianProfile.aspx" >My Profile</a></li>
            <li class="normal"> <a href="viewNonThesis.aspx" >My Theses</a></li>
           <li class="meeow" >Courses</li>
           <li class="normal" ><a href="addfillNon.aspx"  >Add/fill Progress Report</a></li>
           <li class="normal" ><a href="addPubNon.aspx"  >add a publication</a></li>
         
       </ul>
                 
           </div>
       
        <form runat="server">
            <asp:GridView ID="GridView2" cssclass="gridt" runat="server" AutoGenerateColumns="False" Width="1269px" DataKeyNames="id" DataSourceID="SqlDataSource1" Height="70px" >
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                    <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:post3 %>" SelectCommand="studentlistcourses" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="studentID" SessionField="user" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            </form>
    </div>
</body>
</html>