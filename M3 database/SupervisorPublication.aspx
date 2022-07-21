<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorPublication.aspx.cs" Inherits="M3_database.SupervisorPublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="sup.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="loginbox">


        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="ViewAStudentPublications" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="StudentID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:TextBox ID="stuidpub"  runat ="server" CssClass="txtpass" placeholder="enter student id" TextMode="Number" />
        <asp:Button ID="view" Text="View" CssClass="btnsubmit" runat="server" OnClick="viewPub"/>
        <br />
         <asp:Label id="xx" Text="there is no publication for this id" CssClass="wronggg" runat ="server" visible="false" />

        <asp:GridView ID="GridView1" cssClass="gridt" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Visible="False" ForeColor="#333333" GridLines="None" Width="16px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="title" HeaderText="title" ReadOnly="True" SortExpression="title" />
                <asp:BoundField DataField="dateOfPublication" HeaderText="dateOfPublication" ReadOnly="True" SortExpression="dateOfPublication" />
                <asp:BoundField DataField="place" HeaderText="place" ReadOnly="True" SortExpression="place" />
                <asp:CheckBoxField DataField="accepted" HeaderText="accepted" ReadOnly="True" SortExpression="accepted" />
                <asp:BoundField DataField="host" HeaderText="host" ReadOnly="True" SortExpression="host" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

        </div>
    </form>
</body>
</html>
