Imports System.Data.SqlClient

Public Class UserAdd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim UserName As String = txt_name.Text
        Dim Password As String = txt_pass.Text
        Dim Language As Integer = ddl_language.SelectedValue
        Dim ButtonType As Integer = ddl_buttontype.SelectedValue

        Dim DBconnection As New System.Data.SqlClient.SqlConnection
        Dim SQLcommand As New System.Data.SqlClient.SqlCommand
        SQLcommand.Connection = DBconnection

        'ローカルのDBへ接続。windows認証です
        DBconnection.ConnectionString = "Server=AKIRA\SQLEXPRESS;integrated security=SSPI;initial catalog = TEST"
        'INSERT文です
        SQLcommand.CommandText = "INSERT INTO [User](ID,PassWord,Language,ButtonType) VALUES('" & UserName & "','" & Password & "'," & Language & "," & ButtonType & ")"

        DBconnection.Open()
        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        DBconnection.Close()

    End Sub

    Protected Sub btn_return_Click(sender As Object, e As EventArgs) Handles btn_return.Click
        Session.Clear() '念のためセッションクリア
        Response.Redirect("~/login.aspx") 'ログイン画面へ戻る
    End Sub

    Protected Sub btn_Userlist_Click(sender As Object, e As EventArgs) Handles btn_Userlist.Click
        Response.Redirect("~/UserList.aspx") 'テスト用です
    End Sub
End Class