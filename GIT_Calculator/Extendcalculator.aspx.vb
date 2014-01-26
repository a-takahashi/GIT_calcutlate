Public Class Extendcalculator
    Inherits calculator

    Public Overrides Function taxincluded(ByVal befortax As String)
        '親クラスの税金計算メソッドをオーバーライドして機能を変更します
        Dim taxrate As Integer = 8
        befortax = CStr(CInt(txt_monitor.Text) * ((100 + taxrate) / 100))
        Return befortax
    End Function

End Class