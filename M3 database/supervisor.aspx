<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supervisor.aspx.cs" Inherits="Milestone3.supervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="sup.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="publication" class="loginbox2">
<%--                    <asp:TextBox ID="stuidpub"  runat ="server" CssClass="txtpass" placeholder="enter student id" />--%>
                    <asp:Button ID="pub" Text="view publication" CssClass="btnsubmit" runat="server" OnClick="pub_Click"/>


                    <asp:Label id="xx" Text="there is no publication for this id" CssClass="lblemail" runat ="server" visible="false" />


    </div>

    <div class="loginbox1">
                    <asp:Button ID="namesandyears" Text="view names and years" CssClass="btnsubmit" runat="server" OnClick="namesandyears_Click" />

                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Visible="False" >
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="firstName" ReadOnly="True" SortExpression="firstName" />
                                    <asp:BoundField DataField="lastName" HeaderText="lastName" ReadOnly="True" SortExpression="lastName" />
                                    <asp:BoundField DataField="years" HeaderText="years" ReadOnly="True" SortExpression="years" />
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="ViewSupStudentsYears" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="supervisorID" SessionField="user" Type="Int32" />
                                </SelectParameters>
                    </asp:SqlDataSource>
                            <asp:Label id="nostudents" Text="there is no students " CssClass="lblemail" runat ="server" visible="false" />
        
    </div>
        <div class="loginbox3">
                                        <asp:TextBox ID="serialno"  runat ="server" CssClass="txtpass" placeholder="enter thesis serial num" TextMode="Number" />
                            <asp:TextBox ID="defensedate" type="Date" runat ="server" CssClass="txtpass" placeholder="enter defense date" />
                            <asp:TextBox ID="location"  runat ="server" CssClass="txtpass" placeholder="enter defense location" />
                                    <asp:RadioButton id="Gucian" Text="Gucian" GroupName="RegularMenu1" runat="server" cssclass="Gucian" AutoPostBack="true" OnCheckedChanged="Gucian_CheckedChanged" />
                        <asp:RadioButton id="NonGucian" Text="nonGucian" GroupName="RegularMenu1" runat="server" cssclass="Gucian" AutoPostBack="true" OnCheckedChanged="NonGucian_CheckedChanged"  />
            <br />
            <br />
                                <asp:Button ID="add_defense" Text="ADD DEFENSE" CssClass="btnsubmit" runat="server" OnClick="add_defense_Click1"   />

            <br />
            <br />
                                        <asp:TextBox ID="add"  runat ="server" CssClass="txtpass" placeholder="enter examiner id" TextMode="Number" />

                                            <asp:Button ID="addex" Text="add examiner for this defense" CssClass="btnsubmit" runat="server" OnClick="addex_Click" enabled="false" />
            <br />
                                            <asp:Button ID="addnewex" Text="add new examiner" CssClass="Signup" runat="server" OnClick="addnewex_Click" enabled="false" />


        </div>

            

        <div class="loginbox4">
                                        <asp:TextBox ID="serialno2"  runat ="server" CssClass="txtpass" placeholder="enter thesis serial number" TextMode="Number"/>
                                        <asp:TextBox ID="progrepno"  runat ="server" CssClass="txtpass" placeholder="enter progress repot num" TextMode="Number" />
                                        <asp:TextBox ID="evaluation"  runat ="server" CssClass="txtpass" placeholder="enter the evaluation" />
            <br />
                                                        <asp:Button ID="addeval" Text="add evaluation" CssClass="btnsubmit" runat="server" OnClick="addeval_Click"  />
                                <asp:Label id="succ" Text="evaluation added successfully" CssClass="lblemail" runat ="server" visible="false" />
                    <asp:Label id="fail" Text=" evaluation must be between 0 and 3" CssClass="lblemail" runat ="server" visible="false" />


        </div>
           


        <div class="loginbox5">

                                       <asp:TextBox ID="canceltxt"  runat ="server" CssClass="txtpass" placeholder="enter thesis serial number" />
                                          <asp:Button ID="cancel" Text="cancel thesis" CssClass="btnsubmit" runat="server" OnClick="cancel_Click"   />
                                            <asp:Label id="del" Text="thesis canceled successfully" CssClass="lblemail" runat ="server" visible="false" />
                                             <asp:Label id="notdel" Text="thesis can not be canceled " CssClass="lblemail" runat ="server" visible="false" />



        </div>
    </form>
</body>
</html>
