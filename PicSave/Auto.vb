Imports System
Imports System.IO

Module Auto
    Public Automatic As Boolean = False

    Public Sub AutoEncrypt(ByVal Input As String, ByVal InputPicture As String, ByVal Output As String, ByVal Security As Integer, ByVal Password As String)
        'testen ob verschlüsselt werden kann
        If (FileExists(Input) And FileExists(InputPicture)) Then
            Dim img As Bitmap
            img = Image.FromFile(InputPicture)

            Dim Multiplicator As Long = 0

            If (Security = 1) Then
                Multiplicator = 6
            ElseIf (Security = 2) Then
                Multiplicator = 9
            ElseIf (Security = 3) Then
                Multiplicator = 12
            Else
                MsgBox("Geben sie eine gültige Verschlüsselungsstärke an (1-3).", vbOKOnly, "Fehler")
                haupt.Close()
                Exit Sub
            End If

            Dim EncBildSize2 As Double
            EncBildSize2 = img.Height * img.Width * Multiplicator / 8

            Dim EncDataSize2 As Double
            Dim CheckFile As New FileInfo(Input)
            EncDataSize2 = CheckFile.Length

            img.Dispose()
            img = Nothing

            If (EncBildSize2 > EncDataSize2 And Not EncBildSize2 = 0 And Not EncDataSize2 = 0) Then
                'Start
                haupt.grp_Encode.Enabled = False
                haupt.grp_Decode.Enabled = False
                haupt.Befehlszeilenparameter.Enabled = False

                Automatic = True

                If (Security = 1) = True Then
                    Encode2.Encode.RunWorkerAsync(New Object() {InputPicture, Input, Output, Password})
                ElseIf (Security = 2) Then
                    Encode3.Encode3.RunWorkerAsync(New Object() {InputPicture, Input, Output, Password})
                ElseIf (Security = 3) Then
                    Encode4.Encode4.RunWorkerAsync(New Object() {InputPicture, Input, Output, Password})
                End If
            Else
                'Fehler
                MsgBox("Die Datei ist zu gross. Versuchen sie die Verschlüsselung zu erhöhen oder wählen sie ein anderes Bild.", vbOKOnly, "Fehler")
                haupt.Close()
                Exit Sub
            End If


        Else
            MsgBox("Sie haben kein gültiges Bild oder keine gültige Datei angegeben.", vbOKOnly, "Fehler")
            haupt.Close()
            Exit Sub
        End If
    End Sub

    Public Sub AutoDecrypt(ByVal Input As String, ByVal Output As String, ByVal Security As Integer, ByVal Password As String)
        Dim Dateiname As String = ""
        Dim Dateisize As Long = 0
        Dim Passwort As String = ""

        Automatic = True

        If (FileExists(Input)) Then
            haupt.grp_Encode.Enabled = False
            haupt.grp_Decode.Enabled = False
            haupt.Befehlszeilenparameter.Enabled = False

            If (Security = 1) Then
                If (GetFileInfo2(Input, Dateiname, Dateisize, Passwort) = True) Then
                    If (Password = Passwort) Then
                        Decode2.Decode.RunWorkerAsync(New Object() {Input, Output})
                    Else
                        MsgBox("Das Passwort stimmt nicht.", vbOKOnly, "Fehler")
                        haupt.Close()
                        Exit Sub
                    End If
                Else
                    MsgBox("Sie haben kein verschlüsseltes Bild angegeben oder die Verschlüsselungsstärke stimmt nicht.", vbOKOnly, "Fehler")
                    haupt.Close()
                    Exit Sub
                End If
                ElseIf (Security = 2) Then
                    If (GetFileInfo3(Input, Dateiname, Dateisize, Passwort) = True) Then
                    If (Password = Passwort) Then
                        Decode3.Decode3.RunWorkerAsync(New Object() {Input, Output})
                    Else
                        MsgBox("Das Passwort stimmt nicht.", vbOKOnly, "Fehler")
                        haupt.Close()
                        Exit Sub
                    End If
                    Else
                        MsgBox("Sie haben kein verschlüsseltes Bild angegeben oder die Verschlüsselungsstärke stimmt nicht.", vbOKOnly, "Fehler")
                        haupt.Close()
                        Exit Sub
                    End If

                ElseIf (Security = 3) Then
                    If (GetFileInfo4(Input, Dateiname, Dateisize, Passwort) = True) Then
                    If (Password = Passwort) Then
                        Decode4.Decode4.RunWorkerAsync(New Object() {Input, Output})
                    Else
                        MsgBox("Das Passwort stimmt nicht.", vbOKOnly, "Fehler")
                        haupt.Close()
                        Exit Sub
                    End If
                    Else
                        MsgBox("Sie haben kein verschlüsseltes Bild angegeben oder die Verschlüsselungsstärke stimmt nicht.", vbOKOnly, "Fehler")
                        haupt.Close()
                        Exit Sub
                    End If
                Else
                    MsgBox("Geben sie eine gültige Verschlüsselungsstärke an (1-3).", vbOKOnly, "Fehler")
                    haupt.Close()
                    Exit Sub
                End If
            Else
                MsgBox("Sie haben kein gültiges Bild angegeben.", vbOKOnly, "Fehler")
                haupt.Close()
                Exit Sub
            End If
    End Sub

    Sub AutoHilfe()
        MsgBox("Folgende Befehlszeilenparameter gibt es:" & vbNewLine _
                & "/d                       " & vbTab & vbTab & "Verschlüsselung" & vbNewLine _
                & "/e                       " & vbTab & vbTab & "Entschlüsselung" & vbNewLine _
                & "/i:<Pfad>                " & vbTab & vbTab & "Geben Sie hier den Pfad zur" & vbNewLine & vbTab & vbTab & vbTab & "verschlüsselnden Datei" & vbNewLine & vbTab & vbTab & vbTab & "(Verschlüsselung) oder zum" & vbNewLine & vbTab & vbTab & vbTab & "entschlüsselnden Bild (Entschlüsselung)" & vbNewLine & vbTab & vbTab & vbTab & "an." & vbNewLine _
                & "/o:<Pfad>                " & vbTab & vbTab & "Geben Sie hier den Pfad zur Zieldatei" & vbNewLine & vbTab & vbTab & vbTab & "(Verschlüsselung) oder zum" & vbNewLine & vbTab & vbTab & vbTab & "Ausgabeordner (Entschlüsselung) an." & vbNewLine _
                & "/b:<Pfad>                " & vbTab & vbTab & "Geben Sie hier den Pfad zum" & vbNewLine & vbTab & vbTab & vbTab & "Grundbild an (Nur Verschlüsselung)." & vbNewLine _
                & "/s:<Verschlüsselung>     " & vbTab & "Geben Sie an wie stark dass" & vbNewLine & vbTab & vbTab & vbTab & "verschlüsselt werden soll (1-3)." & vbNewLine _
                & "/p:<Passwort>            " & vbTab & "Geben Sie hier ein Passwort ein, falls sie" & vbNewLine & vbTab & vbTab & vbTab & "die verschlüsselte Datei mit einem" & vbNewLine & vbTab & vbTab & vbTab & "Passwort sichern wollen (optional)." & vbNewLine _
                & "/h                       " & vbTab & vbTab & "Starten Sie diese Anwendung versteckt." _
                , MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Befehszeilenparameter")
    End Sub

End Module
