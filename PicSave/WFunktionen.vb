Module WFunktionen
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Function FileExists(ByVal FileName As String) As Boolean
        On Error Resume Next
        FileExists = Not CBool(GetAttr(FileName) And (vbDirectory Or vbVolume))
        On Error GoTo 0
    End Function

    Public Function Speichernunter() As String
        'Ordner suchen Dialog
        'Dialog definieren
        Dim d As New SaveFileDialog

        'Startpfad zuweisen
        d.Title = "Wählen sie aus wo die Datei gespeichert werden soll"

        'Dateienddung
        d.Filter = "Image [*.tif]|*.tif|Image [*.bmp]|*.bmp|Image [*.emf]|*.emf|Image [*.png]|*.png|Image [*.wmf]|*.wmf"

        'Abfrage, auf welche Art die Dialogbox beendet wird
        Dim ergebnis As DialogResult

        'Dialogbox anzeigen
        ergebnis = d.ShowDialog

        '...und jetzt das Ergebnis abfragen
        Select Case ergebnis

            'Der Dialog wurde mit Abbrechen beendet
            Case Windows.Forms.DialogResult.Cancel
                Speichernunter = "False"

                'Der Dialog wurde mit OK beendet
            Case Windows.Forms.DialogResult.OK

                Speichernunter = d.FileName

        End Select

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Function

    Public Function SpeichernunterOrdner() As String
        'Ordner suchen Dialog
        'Dialog definieren
        Dim d As New FolderBrowserDialog

        'Abfrage, auf welche Art die Dialogbox beendet wird
        Dim ergebnis As DialogResult

        'Dialogbox anzeigen
        ergebnis = d.ShowDialog

        '...und jetzt das Ergebnis abfragen
        Select Case ergebnis

            'Der Dialog wurde mit Abbrechen beendet
            Case Windows.Forms.DialogResult.Cancel
                SpeichernunterOrdner = "False"
                'Der Dialog wurde mit OK beendet
            Case Windows.Forms.DialogResult.OK

                SpeichernunterOrdner = d.SelectedPath

        End Select

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)

    End Function

    Public Function StringToByteArray(ByRef str As String) As Byte()
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Return enc.GetBytes(str)
    End Function

    Public Function ByteArrayToTextString(ByRef Barr() As Byte) As String
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Return enc.GetString(Barr)
    End Function


End Module
