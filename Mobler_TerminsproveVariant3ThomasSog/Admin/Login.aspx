<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<%@ Register Src="~/WUC/WUC_LoginForm.ascx" TagPrefix="uc1" TagName="WUC_LoginForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<title></title>
     <!-- Bootstrap -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Styles/MyStyleSheet.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WUC_LoginForm runat="server" id="WUC_LoginForm" />
    </div>
    </form>
</body>
</html>
