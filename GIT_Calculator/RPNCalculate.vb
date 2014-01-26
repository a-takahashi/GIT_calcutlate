Public Class RPNCalculate

    Public Shared Function ConvertRPN(ByVal fomulate As String)
        Dim txtLen As Integer = fomulate.Length
        Dim tempString As String = "" '項、演算子の一時保存用です
        Dim InputQueue As New Queue 'テキストボックスに入力された式を保存しているキューです
        Dim ItemStack As New Stack '逆ポーランド式に変換する際に演算子を保管しておくスタックです
        Dim RPNQueue As New Queue 'このキューにInputQueueとInteStackを使って逆ポーランド式を作ります


        '文字列になっている式を、項単位で区切ってキューに入れていきます。
        '文字列を一文字ずつ見ていきます
        '例えば"5+10+8"という式なら⇒[5,+,1,0,+,8]に分解された後⇒[5,+,10,+,8]に置き換えてキューに入れています。
        For i = 1 To txtLen
            If Mid(fomulate, i, 1) = "0" Or
               Mid(fomulate, i, 1) = "1" Or
               Mid(fomulate, i, 1) = "2" Or
               Mid(fomulate, i, 1) = "3" Or
               Mid(fomulate, i, 1) = "4" Or
               Mid(fomulate, i, 1) = "5" Or
               Mid(fomulate, i, 1) = "6" Or
               Mid(fomulate, i, 1) = "7" Or
               Mid(fomulate, i, 1) = "8" Or
               Mid(fomulate, i, 1) = "9" Or
               Mid(fomulate, i, 1) = "." Then
                tempString = tempString + Mid(fomulate, i, 1)
                If (i = txtLen) Then
                    InputQueue.Enqueue(CDbl(tempString))
                End If
            Else
                InputQueue.Enqueue(CDbl(tempString))
                InputQueue.Enqueue(Mid(fomulate, i, 1))
                tempString = Nothing
            End If
        Next

        '逆ポーランド式への並び替えを行っています。
        'こちらのアルゴリズムを参考にしました「http://www.di.takuma-ct.ac.jp/~miyatake/open/calc/calcsimu.html」
        While InputQueue.Count > 0
            '式項と演算子を一つずつ見ていきます。
            If CStr(InputQueue.Peek) = "+" Or CStr(InputQueue.Peek) = "-" Or CStr(InputQueue.Peek) = "*" Or CStr(InputQueue.Peek) = "/" Then
                '演算子の場合はスタックに入れます
                ItemStack.Push(InputQueue.Dequeue)
            Else
                '項の場合はそのまま逆ポーランドと作るキューに入れます。
                RPNQueue.Enqueue(InputQueue.Dequeue)
            End If

            '演算子の優先度によって逆ポーランドのキューに入れるタイミングが違います。
            '優先度：積=商>和=差
            '各キュー、スタックが空の時は、エラーになるので処理を行いません。
            If ItemStack.Count <> 0 And InputQueue.Count <> 0 Then
                '演算子を保管しておくスタックは先頭の値の優先度より低いものが来たときのみ、スタックに積まれます。
                '先頭の値より優先度が低いもの、同じものが次に入ってくる場合、スタックの中身をすべて逆ポーランドのキューに移動します。
                If (CStr(ItemStack.Peek) = "*" Or CStr(ItemStack.Peek) = "/") And (CStr(InputQueue.Peek) = "+" Or CStr(InputQueue.Peek) = "-") Or (CStr(ItemStack.Peek) = "+" Or CStr(ItemStack.Peek) = "-") And (CStr(InputQueue.Peek) = "+" Or CStr(InputQueue.Peek) = "-") Then
                    While ItemStack.Count <> 0
                        RPNQueue.Enqueue(ItemStack.Pop)
                    End While
                End If
            End If

        End While

        '演算子を保管しておくスタックに要素が残っていた場合は、最後に逆ポーランドのキューにすべて移動させます。
        While ItemStack.Count <> 0
            RPNQueue.Enqueue(ItemStack.Pop)
        End While

        '出来上がった逆ポーランドのキューを返します。
        Return RPNQueue

    End Function



    Public Shared Function calculateRPN(ByVal fomulateRPN As Queue)
        Dim tempdouble1 As Double '項の一時保存用です
        Dim tempdouble2 As Double '項の一時保存用です
        Dim answerSatck As New Stack '計算の過程を格納していくスタックです。スタックの要素が1つになった時が計算の答えです。
        Dim answerinteger As Double '計算式の答えを入れます。戻り値です


        '逆ポーランド式の式を計算します。
        '参考にしたアルゴリズムです「http://7ujm.net/etc/calcstart.html」
        While fomulateRPN.Count > 0

            '順番に逆ポーランドのキューから値を取り出して、演算子が出てきた場合にその都度計算を行います。
            Select Case CStr(fomulateRPN.Peek)
                Case "+"
                    fomulateRPN.Dequeue()
                    tempdouble1 = CDbl(answerSatck.Pop)
                    tempdouble2 = CDbl(answerSatck.Pop)
                    answerSatck.Push(tempdouble2 + tempdouble1)
                Case "-"
                    fomulateRPN.Dequeue()
                    tempdouble1 = CDbl(answerSatck.Pop)
                    tempdouble2 = CDbl(answerSatck.Pop)
                    answerSatck.Push(tempdouble2 - tempdouble1)
                Case "*"
                    fomulateRPN.Dequeue()
                    tempdouble1 = CDbl(answerSatck.Pop)
                    tempdouble2 = CDbl(answerSatck.Pop)
                    answerSatck.Push(tempdouble2 * tempdouble1)
                Case "/"
                    fomulateRPN.Dequeue()
                    tempdouble1 = CDbl(answerSatck.Pop)
                    tempdouble2 = CDbl(answerSatck.Pop)
                    answerSatck.Push(tempdouble2 / tempdouble1)
                Case Else
                    answerSatck.Push(fomulateRPN.Dequeue)
            End Select

        End While

        'スタックの中に残った最後の一つが式の答えです
        answerinteger = answerSatck.Pop

        '答えを返します
        Return answerinteger

    End Function


End Class
