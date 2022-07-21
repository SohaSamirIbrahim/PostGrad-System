<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="type.aspx.cs" Inherits="M3_database.type" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="type.css" rel="stylesheet" />

</head>
<body>
 
           <div class ="loginbox"> 
   
            <form runat="server">             
             <asp:ImageButton src="img/Student.png" ID="ImageButton1" runat="server" Height="400px" Width="400px" OnClick="Student" CSSCLASS="TYPE1"/>
              <asp:ImageButton src="img/supervisor.png" ID="ImageButton2" runat="server" Height="400px" Width="400px" OnClick="supervisor" CSSCLASS="TYPE2" />
             <asp:ImageButton src="img/examiner.png" ID="ImageButton3" runat="server" Height="400px" Width="400px" OnClick="examiner" CSSCLASS="TYPE3"/>
          
        </form>
      </div>
</body>
</html>
