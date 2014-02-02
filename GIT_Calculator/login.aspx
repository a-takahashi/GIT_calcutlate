<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="GIT_Calculator.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        <asp:TextBox ID="txt_ID" runat="server"></asp:TextBox>
        ID</div>
        <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
        パスワード<br />
        <asp:Button ID="btn_login" runat="server" Text="ログイン" />
        <asp:Button ID="btn_useradd" runat="server" Text="ユーザー登録" />


    </form>
</body>
</html>
