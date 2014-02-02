<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserList.aspx.vb" Inherits="GIT_Calculator.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource2" EmptyDataText="表示するデータ レコードがありません。" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True"></asp:CommandField>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>
                <asp:BoundField DataField="PassWord" HeaderText="PassWord" SortExpression="PassWord"></asp:BoundField>
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language"></asp:BoundField>
                <asp:BoundField DataField="ButtonType" HeaderText="ButtonType" SortExpression="ButtonType"></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:localDBConnection %>" DeleteCommand="DELETE FROM [User] WHERE [ID] = @ID" InsertCommand="INSERT INTO [User] ([ID], [PassWord], [Language], [ButtonType]) VALUES (@ID, @PassWord, @Language, @ButtonType)" SelectCommand="SELECT [ID], [PassWord], [Language], [ButtonType] FROM [User]" UpdateCommand="UPDATE [User] SET [PassWord] = @PassWord, [Language] = @Language, [ButtonType] = @ButtonType WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="String" />
                <asp:Parameter Name="PassWord" Type="String" />
                <asp:Parameter Name="Language" Type="Int32" />
                <asp:Parameter Name="ButtonType" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PassWord" Type="String" />
                <asp:Parameter Name="Language" Type="Int32" />
                <asp:Parameter Name="ButtonType" Type="Int32" />
                <asp:Parameter Name="ID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
