<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="M3_database.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="AdminStyle.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class= "loginbox split left">
            <br />
             <h2> Choose What To Do:</h2>
            <ul style="list-style-type:none;">
               <li> <asp:Button Text="List Supervisors" CssClass="btnsubmit" runat="server" OnClick="supervisorList"/> </li>           
               <li> <asp:Button Text="List Theses" CssClass="btnsubmit" runat="server" OnClick="thesisList"/> </li>
               <li> <asp:Button Text="Count Ongoing Theses" CssClass="btnsubmit" runat="server" OnClick="thesisCount"/> </li>
               <li> <asp:Button Text="Issue Thesis Payment" CssClass="btnsubmit" runat="server" OnClick="thesisPayment"/> </li>
               <li> <asp:Button Text="Update Extension" CssClass="btnsubmit" runat="server" OnClick="updateExtension"/> </li>
               <li> <asp:Button Text="Issue Installment" CssClass="btnsubmit" runat="server" OnClick="issueInstallment"/> </li>

            </ul>

         </div>
       <asp:Panel ID="Panel1"  Visible="false" runat="server">

         <div class="loginbox split right" >

             <asp:GridView ID="ThesisView" CssClass="gridt" runat="server" AutoGenerateColumns="False" DataKeyNames="serialNumber" DataSourceID="SqlDataSource2" Visible="false" Height="266px" Width="700px">
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
                 </Columns>
             </asp:GridView>
       
            <asp:GridView ID="SupervisorView" CssClass="gridt" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Height="180px" Width="244px" Visible="false">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" InsertVisible="False" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="faculty" HeaderText="faculty" SortExpression="faculty" />
                </Columns>
            </asp:GridView>

             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="AdminViewAllTheses" SelectCommandType="StoredProcedure"> </asp:SqlDataSource>
    
            <h2> <asp:Label id="countNum" Text="" runat="server" Visible="false" /> </h2>

             
             <asp:Panel ID="paymentinfo"  Visible="false" runat="server">
                 <ul style="list-style-type:none;">
                     <li> <asp:TextBox ID="thSerialNum"  runat ="server" CssClass="txtpass" placeholder="Enter Thesis Serial Number" TextMode="Number"/></li>
                     <li> <asp:TextBox ID="amount"  runat ="server" CssClass="txtpass" placeholder="Enter payment amount" /> </li>
                     <li> <asp:TextBox ID="noOfInstall"  runat ="server" CssClass="txtpass" placeholder="Enter number of installments" TextMode="Number"/> </li>
                     <li> <asp:TextBox ID="percent"  runat ="server" CssClass="txtpass" placeholder="Enter fund percentage" /> </li>
                 </ul>
                 <asp:Button Text="Issue Payment" CssClass="Signup" runat="server" OnClick="IssuePayment" />
                 <br />

           </asp:Panel>
             <asp:Panel ID="extensionInfo"  Visible="false" runat="server">
                 <asp:TextBox ID="extension"  runat ="server" CssClass="txtpass" placeholder="Enter Thesis Serial Number" TextMode="Number" />
                 <asp:Button Text="Update" CssClass="Signup" runat="server" OnClick="extend" />
             </asp:Panel>

            <asp:Panel ID="installInfo"  Visible="false" runat="server">
              <ul style="list-style-type:none;">
                <li> <asp:TextBox ID="payId"  runat ="server" CssClass="txtpass" placeholder="Enter Payment ID" TextMode="Number"/> </li>
                <li> <asp:TextBox ID="date"  runat ="server" CssClass="txtpass" placeholder="Enter Installment Start Date" TextMode="Date" /> </li>
              </ul>
              <asp:Button Text="Issue Installment" CssClass="Signup" runat="server" OnClick="IssueInstallment" />
            </asp:Panel>

           <asp:Label id="wrong" CssClass="wronggg" Text="Unvalid Thesis Serial Number" runat="server" Visible="false" />
           <asp:Label id="missing" CssClass="wronggg" Text="Please Enter Missing Data" runat="server" Visible="false" />
           <asp:Label id="pymentinvalid" CssClass="wronggg" Text="Unvalid Payment ID" runat="server" Visible="false" />
           <asp:Label id="success" CssClass="success" Text="" runat="server" Visible="false" />

             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="AdminListSup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        </div> 
       </asp:Panel>


    </form>
</body>
</html>
