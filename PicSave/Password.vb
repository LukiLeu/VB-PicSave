Module Password
    Public Function EncodeString(ByVal strToEncode As String, _
  ByVal strPassword As String) As String

        Dim strResult As String
        Dim i As Long
        Dim cfc() As Long

        ReDim cfc(0 To Len(strPassword))

        For i = 1 To UBound(cfc)
            cfc(i) = Asc(Right(strPassword, _
              Len(strPassword) - i + 1))
        Next i

        For i = 1 To Len(strToEncode)
            strResult = strResult & _
              Chr(addToIndex(Asc(Right(strToEncode, _
              Len(strToEncode) - i + 1)), VirtPos(i, cfc)))
        Next i

        EncodeString = strResult
    End Function
    ' Text in Verbindung mit einem Passwort entschlüsseln

    Public Function DecodeString(ByVal strToDecode As String, _
      ByVal strPassword As String) As String

        Dim strResult As String
        Dim i As Long
        Dim cfc() As Long
        Dim ttc()

        ReDim cfc(0 To Len(strPassword))
        ReDim ttc(0 To Len(strToDecode))

        For i = 1 To UBound(cfc)
            cfc(i) = Asc(Right(strPassword, _
              Len(strPassword) - i + 1))
        Next i

        For i = 1 To Len(strToDecode)
            strResult = strResult & _
              Chr(GetOfIndex(Asc(Right(strToDecode, _
              Len(strToDecode) - i + 1)), VirtPos(i, cfc)))
        Next i

        DecodeString = strResult
    End Function
    ' Hilfsfunktionen

    Private Function VirtPos(ByVal i As Long, _
      ByVal a() As Long) As Long

        If i > UBound(a) Then
            VirtPos = VirtPos(i - UBound(a), a)
        Else
            VirtPos = a(i)
        End If
    End Function

    Private Function addToIndex(ByVal i As Long, _
      ByVal j As Long) As Long

        If i + j > 255 Then
            addToIndex = i + j - 255
        Else
            addToIndex = i + j
        End If
    End Function

    Private Function GetOfIndex(ByVal i As Long, _
      ByVal j As Long) As Long

        If i - j < 0 Then
            GetOfIndex = i - j + 255
        Else
            GetOfIndex = i - j
        End If
    End Function
End Module
