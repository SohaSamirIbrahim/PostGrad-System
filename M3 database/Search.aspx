<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="M3_database.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Search.css" rel="stylesheet" />
</head>
<body>

     <div class ="loginbox"> 
       <div class="navbar">  
       <img src="../img/guclogo.png"  alt =" Alternative Text" class ="logo"/>
       <ul>
           <li class="normal" ><a href="ViewExaminerProfile.aspx" >My Profile</a></li>
           <li class="normal" ><a href="Examiner-login.aspx" >Defense Control Panel</a></li>
           <li class="meeow" >Search</li>
       </ul>
           </div>

    <form id="form1" runat="server">
         <div class ="searchdiv">

        <asp:TextBox ID="word" runat="server" placeholder="Enter key word" CssClass="txtname"></asp:TextBox>

        <asp:Button ID="search" runat="server" Text="search" OnClick="search_Click" CssClass="button2"/>
        <asp:Button ID="Back" runat="server" Text="Back" CssClass="button2" OnClick="Back_Click"/>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="search1" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="word" SessionField="word1" Type="String" />
                <asp:SessionParameter Name="id" SessionField="user" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
             
        <asp:GridView ID="searchgrid" runat="server" visible="False" CssClass="gridt" AutoGenerateColumns="False" DataKeyNames="serialNumber,date,serialNo,examinerId" DataSourceID="SqlDataSource3">
            <Columns>
                <asp:BoundField DataField="serialNumber" HeaderText="serialNumber" InsertVisible="False" ReadOnly="True" SortExpression="serialNumber" />
                <asp:BoundField DataField="field" HeaderText="field" SortExpression="field" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="startDate" HeaderText="startDate" SortExpression="startDate" />
                <asp:BoundField DataField="endDate" HeaderText="endDate" SortExpression="endDate" />
                <asp:BoundField DataField="defenseDate" HeaderText="defenseDate" SortExpression="defenseDate" />
                <asp:BoundField DataField="years" HeaderText="years" ReadOnly="True" SortExpression="years" />
                <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
                <asp:BoundField DataField="payment_id" HeaderText="payment_id" SortExpression="payment_id" />
                <asp:BoundField DataField="noOfExtensions" HeaderText="noOfExtensions" SortExpression="noOfExtensions" />
                <asp:BoundField DataField="date" HeaderText="date" ReadOnly="True" SortExpression="date" />
                <asp:BoundField DataField="serialNo" HeaderText="serialNo" ReadOnly="True" SortExpression="serialNo" />
                <asp:BoundField DataField="examinerId" HeaderText="examinerId" ReadOnly="True" SortExpression="examinerId" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
            </Columns>
        </asp:GridView>
     </div>
   
    </form>
           </div>
</body>
</html>
