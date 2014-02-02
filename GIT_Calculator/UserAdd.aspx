<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserAdd.aspx.vb" Inherits="GIT_Calculator.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table>
            <tr>
                <td>
                    ユーザー名</td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    パスワード</td>
                <td>
                    <asp:TextBox ID="txt_pass" runat="server"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td>
                    言語:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_language" runat="server" Height="16px" Width="60px">
                        <asp:ListItem Value="1">日本語</asp:ListItem>
                        <asp:ListItem Value="2">英語</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    ボタンタイプ:
                </td>
                <td>
                    <asp:DropDownList ID="ddl_buttontype" runat="server">
                        <asp:ListItem Value="1">タイプ１</asp:ListItem>
                        <asp:ListItem Value="2">タイプ２</asp:ListItem>
                        <asp:ListItem Value="3">タイプ３</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btn_add" runat="server" Text="登録" Width="80px" />
                </td>
                <td>
                    <asp:Button ID="btn_return" runat="server" Text="戻る" Width="80px" />
                </td>
                <td>
                    <asp:Button ID="btn_Userlist" runat="server" Text="一覧(確認用)" />
                </td>

            </tr>


        </table>




    </div>
    </form>
</body>
</html>
