<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="calculator.aspx.vb" Inherits="GIT_Calculator.calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="Label1" runat="server" Text="電卓税率5%"></asp:Label>
     <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   
   <ContentTemplate>

        <asp:TextBox ID="txt_monitor" runat="server" Height="29px" Width="179px" 
            ReadOnly="True" Font-Bold="True" Font-Size="X-Large"></asp:TextBox>

    <table>

        <tr>
            <td colspan="2"><asp:Button ID="bt_clear" runat="server" Height="40px" Text="CR" 
                    Width="85px" Font-Size="X-Large"/></td>
            <td><asp:Button ID="bt_delete" runat="server" Height="40px" Text="削除" Width="40px"/></td>
            <td><asp:Button ID="bt_tax" runat="server" Height="40px" Text="税込" Width="40px"/></td>
        </tr>

        <tr>  
            <td><asp:Button ID="btn_7" runat="server" Text="7" Height="40px" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="seven"/></td>
            <td><asp:Button ID="btn_8" runat="server" Text="8" Height="40px" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="eight"/></td>
            <td><asp:Button ID="btn_9" runat="server" Text="9" Height="40px" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="nine"/></td>
            <td><asp:Button ID="btn_divided" runat="server" Text="÷" Height="40px" Width="40px" 
                    Font-Size="X-Large" CommandName="symbol" CommandArgument="divided"/></td>
       </tr>

        <tr>
            <td><asp:Button ID="btn_4" runat="server" Height="40px" Text="4" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="four"/></td>
            <td><asp:Button ID="btn_5" runat="server" Height="40px" Text="5" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="five"/></td>
            <td><asp:Button ID="btn_6" runat="server" Height="40px" Text="6" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="six" /></td>
            <td><asp:Button ID="btn_multiplied" runat="server" Height="40px" Text="×" 
                    Width="40px" Font-Size="X-Large" CommandName="symbol" 
                    CommandArgument="multiplied" /></td>
       </tr>

        <tr>
            <td><asp:Button ID="btn_1" runat="server" Height="40px" Text="1" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="one" /></td>
            <td><asp:Button ID="btn_2" runat="server" Height="40px" Text="2" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="two" /></td>
            <td><asp:Button ID="btn_3" runat="server" Height="40px" Text="3" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="three" /></td>
            <td><asp:Button ID="btn_minus" runat="server" Height="40px" Text="-" Width="40px" 
                    Font-Size="X-Large" CommandName="symbol" CommandArgument="minus" /></td>
        </tr>

        <tr>
            <td><asp:Button ID="btn_point" runat="server" Height="40px" Text="." Width="40px" 
                    Font-Size="X-Large" CommandName="point" CommandArgument="point" /></td>
            <td><asp:Button ID="btn_0" runat="server" Height="40px" Text="0" Width="40px" 
                    Font-Size="X-Large" CommandName="figures" CommandArgument="zero" /></td>
            <td><asp:Button ID="btn_equal" runat="server" Height="40px" Text="=" Width="40px" Font-Size="X-Large" /></td>
            <td><asp:Button ID="btn_plus" runat="server" Height="40px" Text="+" Width="40px" 
                    Font-Size="X-Large" CommandName="symbol" CommandArgument="plus" /></td>
        </tr>

    </table>

    </ContentTemplate>

         </asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
