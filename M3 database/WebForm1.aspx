<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="M3_database.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
        

<head runat="server">
    <title></title>
</head>
<body>
    
        <form id="form1" runat="server">
            <br />
            <br />
            Hazoum<br />
    
        <asp:SqlDataSource  ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostGradOffice2ConnectionString %>" SelectCommand="SELECT * FROM [PostGradUser]" OnSelecting="SqlDataSource1_Selecting"> </asp:SqlDataSource>
            <br />
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </form>
</body>
</html>
