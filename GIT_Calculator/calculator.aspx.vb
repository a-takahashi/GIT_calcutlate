Public Class calculator
    Inherits System.Web.UI.Page
    Dim monitorText As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_equal_Click(sender As Object, e As EventArgs) Handles btn_equal.Click

        Dim RPNQueue As New Queue
        Dim answer As Double
        Dim passString As String
        Dim trimchar() As Char = {"+", "-", "*", "/"}

        '念のため空白を削除
        passString = Trim(txt_monitor.Text)

        'ただしい式に変換
        passString = passString.Trim(trimchar)

        '文字列を逆ポーランド式の並びに変更します。
        'RPNQueue = Conection_RPNconvert.ConvertRPN(passString)
        RPNQueue = RPNCalculate.ConvertRPN(passString)

        '逆ポーランド式の計算式を計算します。
        'answer = Conection_RPNcalculate.calculateRPN(RPNQueue)
        answer = RPNCalculate.calculateRPN(RPNQueue)

        txt_monitor.Text = CStr(answer)

    End Sub


    Protected Sub bt_delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bt_delete.Click
        '左から順番に1文字ずつ消していきます。
        If txt_monitor.Text.Length >= 1 Then
            txt_monitor.Text = Left(txt_monitor.Text, txt_monitor.Text.Length - 1)
        Else
            Microsoft.VisualBasic.MsgBox("削除する文字列がありません")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bt_clear.Click
        '表示されている内容を削除します
        monitorText = ""
        txt_monitor.Text = ""
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim CurrentDir As String = System.IO.Directory.GetCurrentDirectory()
        Response.Redirect("~/Extendcalculator.aspx")
    End Sub

    Public Overridable Sub bt_tax_Click(sender As Object, e As EventArgs) Handles bt_tax.Click
        '演算子が含まれている場合は、税込処理は行えません
        If txt_monitor.Text.Contains("+") Or txt_monitor.Text.Contains("-") Or txt_monitor.Text.Contains("*") Or txt_monitor.Text.Contains("/") Then
            Microsoft.VisualBasic.MsgBox("式に対してこの動作は行えません")
        Else
            txt_monitor.Text = taxincluded(txt_monitor.Text)
        End If
    End Sub

    Public Overridable Function taxincluded(ByVal befortax As String)
        '税率5%を追加するファンクションです
        Dim taxrate As Integer = 5
        befortax = CStr(CInt(txt_monitor.Text) * ((100 + taxrate) / 100))
        Return befortax
    End Function

    Protected Sub operation_command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles btn_1.Command, btn_2.Command, btn_0.Command, btn_3.Command, btn_4.Command, btn_5.Command, btn_6.Command, btn_7.Command, btn_8.Command, btn_9.Command, btn_point.Command, btn_divided.Command, btn_multiplied.Command, btn_minus.Command, btn_plus.Command

        '数字ボタン押下時
        If e.CommandName = "figures" Then
            Select Case e.CommandArgument
                Case "one"
                    txt_monitor.Text = txt_monitor.Text + "1"
                Case "two"
                    txt_monitor.Text = txt_monitor.Text + "2"
                Case "three"
                    txt_monitor.Text = txt_monitor.Text + "3"
                Case "four"
                    txt_monitor.Text = txt_monitor.Text + "4"
                Case "five"
                    txt_monitor.Text = txt_monitor.Text + "5"
                Case "six"
                    txt_monitor.Text = txt_monitor.Text + "6"
                Case "seven"
                    txt_monitor.Text = txt_monitor.Text + "7"
                Case "eight"
                    txt_monitor.Text = txt_monitor.Text + "8"
                Case "nine"
                    txt_monitor.Text = txt_monitor.Text + "9"
                Case "zero"
                    txt_monitor.Text = txt_monitor.Text + "0"
                Case "point"
                    txt_monitor.Text = txt_monitor.Text + "."
            End Select
            '演算記号のボタン押下時
        ElseIf e.CommandName = "symbol" Then
            Select Case e.CommandArgument
                Case "plus"
                    If Strings.Right(txt_monitor.Text, 1) <> "+" And Strings.Right(txt_monitor.Text, 1) <> "-" And Strings.Right(txt_monitor.Text, 1) <> "*" And Strings.Right(txt_monitor.Text, 1) <> "/" Then
                        monitorText = txt_monitor.Text + "+"
                        txt_monitor.Text = monitorText
                    Else
                        Microsoft.VisualBasic.MsgBox("演算子を続けて入力することはできません")
                    End If
                Case "minus"
                    If Strings.Right(txt_monitor.Text, 1) <> "+" And Strings.Right(txt_monitor.Text, 1) <> "-" And Strings.Right(txt_monitor.Text, 1) <> "*" And Strings.Right(txt_monitor.Text, 1) <> "/" Then
                        monitorText = txt_monitor.Text + "-"
                        txt_monitor.Text = monitorText
                    Else
                        Microsoft.VisualBasic.MsgBox("演算子を続けて入力することはできません")
                    End If
                Case "multiplied"
                    If Strings.Right(txt_monitor.Text, 1) <> "+" And Strings.Right(txt_monitor.Text, 1) <> "-" And Strings.Right(txt_monitor.Text, 1) <> "*" And Strings.Right(txt_monitor.Text, 1) <> "/" Then
                        monitorText = txt_monitor.Text + "*"
                        txt_monitor.Text = monitorText
                    Else
                        Microsoft.VisualBasic.MsgBox("演算子を続けて入力することはできません")
                    End If
                Case "divided"
                    If Strings.Right(txt_monitor.Text, 1) <> "+" And Strings.Right(txt_monitor.Text, 1) <> "-" And Strings.Right(txt_monitor.Text, 1) <> "*" And Strings.Right(txt_monitor.Text, 1) <> "/" Then
                        monitorText = txt_monitor.Text + "/"
                        txt_monitor.Text = monitorText
                    Else
                        Microsoft.VisualBasic.MsgBox("演算子を続けて入力することはできません")
                    End If
            End Select
        End If
    End Sub
End Class