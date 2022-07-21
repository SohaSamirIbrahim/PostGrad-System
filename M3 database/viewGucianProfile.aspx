<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewGucianProfile.aspx.cs"   Inherits="M3_database.viewGucianProfile" %>

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
           <li class="meeow"> My Profile</li>
           <li class="normal"> <a href="viewThesis.aspx" >My Theses</a></li>
           <li class="normal" ><a href="addfill.aspx"  >Add/fill Progress Report</a></li>
           <li class="normal" ><a href="addPub.aspx"  >add a publication</a></li>
         
       </ul>
                 
           </div>
          <div class ="loginbox2"> 
          <img src="../img/avatar7.png"  alt =" Alternative Text" class ="avatar"/>
            <style>
            .vl {
              border-left: 4px solid #009688;
              height: 100%;
            }
            </style>

            <div class="vl"></div>

        <form runat="server">
        <div class="text">
            <asp:Label ID="stufirstname" Text= "FirstName"  CssClass="lblcard" runat ="server" />

            <asp:Label  ID="stulastname" Text="lastname" CssClass="lblcard1"  runat="server" /> 
       <br /><br />
             <style>
            .vl2 {
              border-bottom: 1px solid #808080;
              width: 200%;
            }
            </style>

            <div class="vl2"></div>
            <br /><br />

            <asp:Label  ID="stufaculty" Text="faculty" CssClass="lblcard"  runat="server" />
            <asp:Label ID="stutype" Text="type" CssClass="lblcard1"  runat="server" />
        <br /><br /> 
            <style>
            .vl3 {
              border-bottom: 1px solid #808080;
              width: 200%;
            }
            </style>

            <div class="vl3"></div><br /><br />
      

            <asp:Label ID="stuaddress" Text="address" CssClass="lblcard" runat ="server" />
            <asp:Label ID="stuGPA" Text="GPA" CssClass="lblcard1"  runat="server" />
       <br /><br />
              <style>
            .vl4 {
              border-bottom: 1px solid #808080;
              width: 200%;
            }
            </style>

            <div class="vl4"></div><br /><br />
      

              <style>
            .vl5{
              border-bottom: 1px solid #808080;
              width: 200%;
            }
            </style>

            <div class="vl5"></div>
            <asp:Label ID="stuemail" Text="Email" CssClass="lblcard" runat ="server" />
            <asp:Label ID="underGradd" Text="UnderGradID" CssClass="lblcarde"  runat="server" />
         </div>
               <asp:Label ID="stuID" Text="StudentId" CssClass="lblcard2" runat ="server" />

         
              
            
        </form>
            </div>
    </div>
</body>
</html>
