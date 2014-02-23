Imports System.Data.SqlClient

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim loginflg As Boolean = False
        Dim UserArray As New List(Of String)
        Dim PassWordArray As New List(Of String)
        Dim ID As String = txt_ID.Text
        Dim Password As String = txt_password.Text

        Dim DBconnection As New System.Data.SqlClient.SqlConnection
        DBconnection.ConnectionString = "Server=AKIRA\SQLEXPRESS;integrated security=SSPI;initial catalog = TEST"

        'ユーザーIDの一覧を取得するSQLを準備します
        Dim UserSelectCommand As New System.Data.SqlClient.SqlCommand
        UserSelectCommand.CommandText = "SELECT ID from [User]"
        UserSelectCommand.Connection = DBconnection

        'パスワードの一覧を取得するSQLを準備します
        Dim PassWordSelectCommand As New System.Data.SqlClient.SqlCommand
        PassWordSelectCommand.CommandText = "SELECT PassWord from [User]"
        PassWordSelectCommand.Connection = DBconnection

        DBconnection.Open()

        'ユーザーIDを取得し、配列に入れていきます
        Using readUser As SqlDataReader = UserSelectCommand.ExecuteReader()
            If readUser.HasRows = True Then
                While readUser.Read()
                    UserArray.Add(CStr(readUser("ID")))
                End While
            End If
        End Using

        'パスワードも取得して配列に入れていきます
        Using readPassWord As SqlDataReader = PassWordSelectCommand.ExecuteReader()
            If readPassWord.HasRows = True Then
                While readPassWord.Read()
                    PassWordArray.Add(CStr(readPassWord("PassWord")))
                End While
            End If
        End Using
        UserSelectCommand.Dispose() 'リソースの解放
        PassWordSelectCommand.Dispose() 'リソースの解放
        DBconnection.Close()

        'ログインを行う時の判定をしています。
        For i As Integer = 0 To UserArray.Count - 1
            If UserArray(i) = ID And PassWordArray(i) = Password Then
                Session("ID") = UserArray(i) 'I入力したIDをセッションに保存しておきます。
                loginflg = True 'IDとパスワードが一致した場合にログインできるように。
                Exit For
            End If
        Next

        '入力されたユーザーのIDを基に、選択された言語を取得します。
        Dim LanguageSelectCommand As New System.Data.SqlClient.SqlCommand
        LanguageSelectCommand.CommandText = "SELECT Language from [User] WHERE ID = '" & Session("ID") & "' "
        LanguageSelectCommand.Connection = DBconnection
        Dim LanguageType As Integer = 1

        DBconnection.Open()
        LanguageType = LanguageSelectCommand.ExecuteScalar
        LanguageSelectCommand.Dispose() 'リソースの解放
        DBconnection.Close()

        Session("language") = LanguageType

        If loginflg = True Then
            Select Case LanguageType
                Case 1
                    Microsoft.VisualBasic.MsgBox("ようこそ!") '日本語の時
                Case 2
                    Microsoft.VisualBasic.MsgBox("Welcome!") '英語の時
            End Select

            Response.Redirect("~/calculator.aspx") '電卓の画面へ
        Else
            Microsoft.VisualBasic.MsgBox("IDとパスワードが一致しませんでした")
            Session.Clear()
            PassWordArray.Clear()
            UserArray.Clear()
        End If


    End Sub

    Protected Sub btn_useradd_Click(sender As Object, e As EventArgs) Handles btn_useradd.Click
        Response.Redirect("~/UserAdd.aspx")
    End Sub
End Class