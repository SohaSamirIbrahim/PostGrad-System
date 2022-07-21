<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner-login.aspx.cs" Inherits="M3_database.Examiner_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Examiner-login.css" rel="stylesheet" />
</head>
<body>
       <div class ="loginbox"> 

     <div class="navbar">  
       <img src="../img/guclogo.png"  alt =" Alternative Text" class ="logo"/>
       <ul>
           <li class="normal" ><a href="ViewExaminerProfile.aspx" >My Profile</a></li>
           <li class="meeow" >Defense Control Panel</li>
           <li class="normal" ><a href="Search.aspx"  >Search</a></li>
       </ul>
           </div>   
    <form id="form1" runat="server">
    <!--
        <div class ="viewprofilediv">
            <asp:Button runat="server" Text="View" ID="ExaminarViewProfile" OnClick="ExaminarViewProfile_Click" CssClass="buttons" />

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="viewExaminer" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="id" SessionField="user" Type="Int32" />
                    </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="viewEaminarProfile" runat="server" visible="False"  AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="fieldOfWork" HeaderText="fieldOfWork" SortExpression="fieldOfWork" />
                    <asp:CheckBoxField DataField="isNational" HeaderText="isNational" SortExpression="isNational" />
                </Columns>
            </asp:GridView>

        <asp:Button ID="editProfile" runat="server" Text="edit" OnClick="editProfile_Click" CssClass="buttons"/>
       
        <asp:panel ID ="editProf" Visible="false" runat ="server">
            <asp:Label ID="Label1" runat="server" Text="name" CssClass="labelname"></asp:Label>
            <asp:TextBox ID="newname" runat="server" placeholder="enter name" CssClass="texttype"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Field of work" CssClass="labelname"></asp:Label>
            <asp:TextBox ID="field" runat="server" placeholder="enter field of work" CssClass="texttype"></asp:TextBox>
        </p>
            <asp:Button ID="submitedit" runat="server" Text="Submit" OnClick="submit_Click" CssClass="buttons"/>
        
        </asp:panel>
    </div>
    -->

        <div class ="viewdefensesdiv">

        <br />
        <asp:Label ID="Label3" runat="server" Text="Attended defenses" CssClass="labelname"></asp:Label>
        <br />
        <asp:Button ID="viewEverything" runat="server" Text="View" OnClick="viewEverything_Click" CssClass="button3"/>
    
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="viewEverythingExaminer" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="user" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="viewEverythinggrid" CssClass="gridt" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Visible="False">
            <Columns>
                <asp:BoundField DataField="thesisTitle" HeaderText="thesisTitle" ReadOnly="True" SortExpression="thesisTitle" />
                <asp:BoundField DataField="SupervisorName" HeaderText="SupervisorName" ReadOnly="True" SortExpression="SupervisorName" />
                <asp:BoundField DataField="studentname" HeaderText="studentname" ReadOnly="True" SortExpression="studentname" />
            </Columns>
        </asp:GridView>
        
       <p>
           <br />
           <asp:Label ID="Label4" runat="server" Text="Defense" CssClass="labelname"></asp:Label>
           <br />
        <asp:Button ID="addcomment" runat="server" Text="Add comment" OnClick="addcomment_Click" CssClass="button3"/>
        </p>
        <asp:panel ID ="addcomentfordefense" Visible="false" runat ="server">
        <p>
            <asp:TextBox ID="serialno" runat="server" TextMode="Number" placeholder="enter thesis serial number" CssClass="texttype" ></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="date" runat="server" TextMode="DateTime" placeholder="enter defense date" CssClass="texttype"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="comment" runat="server" style="margin-top: 0px" placeholder="enter comment" CssClass="texttype"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="submitcomment" runat="server" Text="submit" OnClick="submitcomment_Click" CssClass="button3"/>
            <asp:Button ID="back1" runat="server" Text="Back" OnClick="goBackCom" CssClass="button3" Visible="false"/>

            </p>
            
    </asp:panel>
            <br />
           <p> 
            <asp:Button ID="addgrade" runat="server" Text="Add grade" OnClick="addgrade_Click" CssClass="button3"/>
       </p>
            <asp:panel ID ="addgradefordefense" Visible="false" runat ="server">
        <p>
            
            <asp:TextBox ID="serialgrade" runat="server" TextMode="Number" placeholder="enter thesis serial number" CssClass="texttype"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="dategrade" runat="server" TextMode="DateTime" placeholder="enter defense date" CssClass="texttype"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="grade" runat="server" style="margin-top: 0px" placeholder="enter grade" CssClass="texttype"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="submitgrade" runat="server" Text="submit" OnClick="submitgrade_Click" CssClass="button3"/>
            <asp:Button ID="back2" runat="server" Text="Back" OnClick="goBackGrade" CssClass="button3" Visible="false"/>
        </p>
        <asp:Label id="Success" Text="" runat="server" Visible="false" />

               
    </asp:panel>
          
    </div>
   <!--     
    <div class ="searchdiv">

        <asp:TextBox ID="word" runat="server" placeholder="Enter key word" CssClass="texttype"></asp:TextBox>

        <asp:Button ID="search" runat="server" Text="search" OnClick="search_Click" CssClass="buttons"/>

        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>" SelectCommand="search" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="word" SessionField="word1" Type="String" />
                <asp:SessionParameter Name="id" SessionField="user" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="searchgrid" runat="server" visible="False" AutoGenerateColumns="False" DataKeyNames="serialNumber,date,serialNo,examinerId" DataSourceID="SqlDataSource3">
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
   -->
        </form>
           </div>
</body>
</html>
