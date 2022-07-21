<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addfillNon.aspx.cs" Inherits="M3_database.addfillNon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link href="Student.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
   <div class ="loginbox"> 
       <div class="navbar">  
       <img src="../img/guclogo.png"  alt =" Alternative Text" class ="logo"/>
       <ul>
           <li class="normal" ><a href="viewnonGucianProfile.aspx" >My Profile</a></li>
          <li class="normal"> <a href="viewNonThesis.aspx" >My Theses</a></li>
           <li class="normal" ><a href="courses.aspx"  >Courses</a></li>
                      <li class="meeow">Add/fill Progress Report</li>
           <li class="normal" ><a href="addPubNon.aspx"  >add a publication</a></li>
       </ul>
           </div>
        <div>
            <asp:Label Text="Thesis SerialNumber" CssClass="lblnamee"  runat="server" TextMode="Number" />
            <asp:TextBox ID="serial"  runat ="server" CssClass="txttypee" placeholder="Add Serialnumber" />
            <asp:Label Text="date" CssClass="lblname" runat ="server" />
            <asp:TextBox ID="datedef" runat="server" CssClass="cal" placeholder="address" TextMode="Date"/>
            <asp:Label Text="progressReportNo" CssClass="lblname"  runat="server" />
            <asp:TextBox ID="progressReportNo"  runat ="server" CssClass="txttype" placeholder="Enter progressReportNo" TextMode="Number"/>
             <asp:Button Text="Add Progress Report" CssClass="button3" runat="server" OnClick="Addprogress" />
                   <br />
                   <asp:Label ID="addprogerr1" Text="Kindly Enter Thesis Serialnumber" CssClass="lblnamee"  runat="server" ForeColor="Red"  Visible="false"/>
                   <asp:Label ID="addprogerr2" Text="Kindly Enter defense date" CssClass="lblnamee"  runat="server" ForeColor="Red"  Visible="false"/>
                   <asp:Label ID="addprogerr3" Text="Kindly Enter progressReportNo" CssClass="lblnamee"  runat="server" ForeColor="Red"  Visible="false"/>
                   <asp:Label ID="addprogerr4" Text="repeated data, you have a progress report with the same progress report number" CssClass="lblnamee"  runat="server" ForeColor="Red"  Visible="false"/>
                   <asp:Label ID="addprogerr5" Text="Invalid progress report number" CssClass="lblnamee"  runat="server" ForeColor="Red"  Visible="false"/>
                   <asp:Label ID="addprogerr6" Text="Invalid data" CssClass="lblnamee"  runat="server" ForeColor="Red"  Visible="false"/>


            </div>
       <br />
<br />
<br />

       <br />
       
           <asp:GridView ID="GridView1" CssClass="gridt" runat="server" Height="10%"
               OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="False"
               DataKeyNames="sid,no" DataSourceID="dr" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" >
               <Columns>
                   <asp:BoundField DataField="sid" HeaderText="sid" ReadOnly="True" SortExpression="sid" />
                   <asp:BoundField DataField="no" HeaderText="no" ReadOnly="True" SortExpression="no" />
                   <asp:BoundField DataField="date" HeaderText="date" ReadOnly="True" SortExpression="date" />
                   <asp:BoundField DataField="eval" HeaderText="eval" ReadOnly="True" SortExpression="eval" />
                   <asp:TemplateField HeaderText="state" SortExpression="state">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtname" Text='<%# Bind("state") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("state") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="description" SortExpression="description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txtemail" Text='<%# Bind("description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:BoundField DataField="thesisSerialNumber" ReadOnly="True" HeaderText="thesisSerialNumber" SortExpression="thesisSerialNumber" />
                   <asp:BoundField DataField="supid" HeaderText="supid" ReadOnly="True" SortExpression="supid" />
               
                    <asp:TemplateField >
                        <EditItemTemplate>
                            <asp:Button SortExpression="Button1" ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClick="Button1_Click"  />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="fill data" OnClick="Button1_Click1"  />
                        </ItemTemplate>
                        <ControlStyle CssClass="button2" />
                        <FooterStyle BackColor="#CC66FF" />
                   </asp:TemplateField>
               
                   
               </Columns>
           </asp:GridView>
       <asp:SqlDataSource ID="dr" runat="server" ConnectionString="<%$ ConnectionStrings:Milestone3 %>"
           SelectCommand="SELECT * FROM [nonGUCianProgressReport] WHERE ([sid] = @sid)"
             UpdateCommand="exec FillProgressReport @thesisSerialNo , @progressReportNo, @state , @description ,@studentID " InsertCommand="AddProgressReport" InsertCommandType="StoredProcedure"
            >
                <UpdateParameters>
                    <asp:SessionParameter Name="thesisSerialNo" SessionField="thesisserial" Type="Int32"/>
                    <asp:SessionParameter Name="progressReportNo" SessionField="progressno" Type="Int32" />
                    <asp:SessionParameter Name="state" SessionField="states1"   Type="Int32" />
                    <asp:SessionParameter Name="description" SessionField="description1" Type="String" />
                    <asp:SessionParameter Name="studentID" SessionField="user" Type="Int32" />
                    </UpdateParameters> 

                <InsertParameters>
                    <asp:Parameter Name="thesisSerialNo" Type="Int32" />
                    <asp:Parameter DbType="Date" Name="progressReportDate" />
                    <asp:Parameter Name="studentID" Type="Int32" />
                    <asp:Parameter Name="progressReportNo" Type="Int32" />
                </InsertParameters>

           <SelectParameters>
               <asp:SessionParameter Name="sid" SessionField="user" Type="Int32" />
           </SelectParameters>
       </asp:SqlDataSource>
       </div>
       </form>
</body>
</html>
