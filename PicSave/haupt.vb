Imports System
Imports System.IO
Imports System.ComponentModel

Public Class haupt

    Public EncBildSize As Long = 0
    Public EncDataSize As Long = 0
    Public Passwort As String = ""

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Private Sub btn_Encode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Encode.Click

        Dim Pfad As String = Speichernunter()
        If Pfad = "False" Then
            Exit Sub
        End If

        Me.grp_Encode.Enabled = False
        Me.grp_Decode.Enabled = False
        Me.Befehlszeilenparameter.Enabled = False

        If Me.rdb_Enc_Step1.Checked = True Then
            Encode2.Encode.RunWorkerAsync(New Object() {Me.txt_Bild.Text, Me.txt_Datei.Text, Pfad, Me.txt_Pass.Text})
        ElseIf (Me.rdb_Enc_Step2.Checked = True) Then
            Encode3.Encode3.RunWorkerAsync(New Object() {Me.txt_Bild.Text, Me.txt_Datei.Text, Pfad, Me.txt_Pass.Text})
        ElseIf (Me.rdb_Enc_Step3.Checked = True) Then
            Encode4.Encode4.RunWorkerAsync(New Object() {Me.txt_Bild.Text, Me.txt_Datei.Text, Pfad, Me.txt_Pass.Text})
        End If

        Me.DoubleBuffered = True

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub btn_Search_PicEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search_PicEnc.Click
        'Ordner suchen Dialog
        'Dialog definieren
        Dim d As New OpenFileDialog

        'Startpfad zuweisen
        d.InitialDirectory = Me.txt_Bild.Text
        d.Multiselect = False
        d.CheckFileExists = True
        d.CheckPathExists = True
        d.Title = "Wählen sie ihr Grundbild aus"
        d.Filter = "Images|*.jpg;*.jpeg;*.gif;*.bmp;*.png|Sonstige|*.*"

        'Abfrage, auf welche Art die Dialogbox beendet wird
        Dim ergebnis As DialogResult

        'Dialogbox anzeigen
        ergebnis = d.ShowDialog

        '...und jetzt das Ergebnis abfragen
        Select Case ergebnis

            'Der Dialog wurde mit Abbrechen beendet
            Case Windows.Forms.DialogResult.Cancel

                'Der Dialog wurde mit OK beendet
            Case Windows.Forms.DialogResult.OK

                Me.txt_Bild.Text = d.FileName

        End Select

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub btn_Search_FileEnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search_FileEnc.Click
        'Ordner suchen Dialog
        'Dialog definieren
        Dim d As New OpenFileDialog

        'Startpfad zuweisen
        d.InitialDirectory = Me.txt_Datei.Text
        d.Multiselect = False
        d.CheckFileExists = True
        d.CheckPathExists = True
        d.Title = "Wählen sie ihre zu verschlüsselnde Datei aus"
        d.Filter = "Sonstige|*.*"

        'Abfrage, auf welche Art die Dialogbox beendet wird
        Dim ergebnis As DialogResult

        'Dialogbox anzeigen
        ergebnis = d.ShowDialog

        '...und jetzt das Ergebnis abfragen
        Select Case ergebnis

            'Der Dialog wurde mit Abbrechen beendet
            Case Windows.Forms.DialogResult.Cancel

                'Der Dialog wurde mit OK beendet
            Case Windows.Forms.DialogResult.OK

                Me.txt_Datei.Text = d.FileName

        End Select

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub txt_Bild_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Bild.TextChanged
        If (FileExists(Me.txt_Bild.Text)) Then
            Dim img As Bitmap
            img = Image.FromFile(Me.txt_Bild.Text)

            Dim Multiplicator As Long = 0

            If (Me.rdb_Enc_Step1.Checked = True) Then

                Multiplicator = 6
            ElseIf (Me.rdb_Enc_Step2.Checked = True) Then
                Multiplicator = 9

            ElseIf (Me.rdb_Enc_Step3.Checked = True) Then
                Multiplicator = 12
            End If

            Dim Pixel As Long = img.Height * img.Width
            Dim MB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 / 1024)
            Dim KB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 - 1024 * MB)
            Dim B As Long = Math.Floor((Pixel * Multiplicator) / 8 - 1024 * 1024 * MB - 1024 * KB)

            Me.lbl_MaxSize.Text = "Maximale Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

            EncBildSize = Pixel * Multiplicator / 8

            If (EncBildSize > EncDataSize And Not EncBildSize = 0 And Not EncDataSize = 0) Then
                Me.btn_Encode.Enabled = True
            Else
                Me.btn_Encode.Enabled = False
            End If

            img.Dispose()
            img = Nothing

        Else
            EncBildSize = 0

            Me.lbl_MaxSize.Text = "Kein Bild ausgewählt!"
            Me.btn_Encode.Enabled = False
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub haupt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Backgroundworker
        Encode2.Encode.WorkerReportsProgress = True
        Encode2.Encode.WorkerSupportsCancellation = True
        Encode3.Encode3.WorkerReportsProgress = True
        Encode3.Encode3.WorkerSupportsCancellation = True
        Encode4.Encode4.WorkerReportsProgress = True
        Encode4.Encode4.WorkerSupportsCancellation = True
        Decode2.Decode.WorkerReportsProgress = True
        Decode2.Decode.WorkerSupportsCancellation = True
        Decode3.Decode3.WorkerReportsProgress = True
        Decode3.Decode3.WorkerSupportsCancellation = True
        Decode4.Decode4.WorkerReportsProgress = True
        Decode4.Decode4.WorkerSupportsCancellation = True

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        'Timer starten um testen ob Automodus
        Me.AutoCheck.Start()
    End Sub

    Private Sub btn_Decode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Decode.Click

        If (Not Passwort = Me.txt_Pass_Dec.Text) Then
            MsgBox("Das Passwort stimmt nicht!", vbOKOnly, "Falsches Passwort")
            Exit Sub
        End If

        Dim Pfad As String = SpeichernunterOrdner()
        If Pfad = "False" Then
            Exit Sub
        End If

        Me.grp_Encode.Enabled = False
        Me.grp_Decode.Enabled = False
        Me.Befehlszeilenparameter.Enabled = False

        If (rdb_Dec_Step1.Checked = True) Then
            Decode2.Decode.RunWorkerAsync(New Object() {Me.txt_Bild_Dec.Text, Pfad})
        ElseIf (rdb_Dec_Step2.Checked = True) Then
            Decode3.Decode3.RunWorkerAsync(New Object() {Me.txt_Bild_Dec.Text, Pfad})
        ElseIf (rdb_Dec_Step3.Checked = True) Then
            Decode4.Decode4.RunWorkerAsync(New Object() {Me.txt_Bild_Dec.Text, Pfad})
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub btn_SearchPic_Dec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SearchPic_Dec.Click
        'Ordner suchen Dialog
        'Dialog definieren
        Dim d As New OpenFileDialog

        'Startpfad zuweisen
        d.InitialDirectory = Me.txt_Bild_Dec.Text
        d.Multiselect = False
        d.CheckFileExists = True
        d.CheckPathExists = True
        d.Title = "Wählen sie ihr verschlüsseltes Bild aus"
        d.Filter = "Images [*.tif]|*.tif;*.bmp;*.emf;*.png;*.wmf"

        'Abfrage, auf welche Art die Dialogbox beendet wird
        Dim ergebnis As DialogResult

        'Dialogbox anzeigen
        ergebnis = d.ShowDialog

        '...und jetzt das Ergebnis abfragen
        Select Case ergebnis

            'Der Dialog wurde mit Abbrechen beendet
            Case Windows.Forms.DialogResult.Cancel

                'Der Dialog wurde mit OK beendet
            Case Windows.Forms.DialogResult.OK

                Me.txt_Bild_Dec.Text = d.FileName

        End Select

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub txt_Bild_Dec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Bild_Dec.TextChanged
        Dim Dateiname As String = ""
        Dim Dateisize As Long = 0

        If (FileExists(Me.txt_Bild_Dec.Text)) Then
            If (Me.rdb_Dec_Step1.Checked = True) Then
                If (GetFileInfo2(Me.txt_Bild_Dec.Text, Dateiname, Dateisize, Passwort) = True) Then
                    Me.lbl_Bild_Name.Text = "Dateiname: " & Dateiname

                    Dim MB As Long = Math.Floor(Dateisize / 1024 / 1024)
                    Dim KB As Long = Math.Floor(Dateisize / 1024 - 1024 * MB)
                    Dim B As Long = Math.Floor(Dateisize - 1024 * 1024 * MB - 1024 * KB)

                    Me.lbl_Bild_Size.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                    Me.btn_Decode.Enabled = True
                Else
                    Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
                    Me.lbl_Bild_Size.Text = ""

                    Me.btn_Decode.Enabled = False
                End If
            ElseIf (Me.rdb_Dec_Step2.Checked = True) Then
                If (GetFileInfo3(Me.txt_Bild_Dec.Text, Dateiname, Dateisize, Passwort) = True) Then
                    Me.lbl_Bild_Name.Text = "Dateiname: " & Dateiname

                    Dim MB As Long = Math.Floor(Dateisize / 1024 / 1024)
                    Dim KB As Long = Math.Floor(Dateisize / 1024 - 1024 * MB)
                    Dim B As Long = Math.Floor(Dateisize - 1024 * 1024 * MB - 1024 * KB)

                    Me.lbl_Bild_Size.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                    Me.btn_Decode.Enabled = True
                Else
                    Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
                    Me.lbl_Bild_Size.Text = ""

                    Me.btn_Decode.Enabled = False
                End If

            ElseIf (Me.rdb_Dec_Step3.Checked = True) Then
                If (GetFileInfo4(Me.txt_Bild_Dec.Text, Dateiname, Dateisize, Passwort) = True) Then
                    Me.lbl_Bild_Name.Text = "Dateiname: " & Dateiname

                    Dim MB As Long = Math.Floor(Dateisize / 1024 / 1024)
                    Dim KB As Long = Math.Floor(Dateisize / 1024 - 1024 * MB)
                    Dim B As Long = Math.Floor(Dateisize - 1024 * 1024 * MB - 1024 * KB)

                    Me.lbl_Bild_Size.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                    Me.btn_Decode.Enabled = True
                Else
                    Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
                    Me.lbl_Bild_Size.Text = ""

                    Me.btn_Decode.Enabled = False
                End If
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub txt_Datei_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Datei.TextChanged
        If (FileExists(Me.txt_Datei.Text)) Then
            Dim CheckFile As New FileInfo(Me.txt_Datei.Text)
            Dim DataBytes As Long = CheckFile.Length

            Dim MB As Long = Math.Floor(DataBytes / 1024 / 1024)
            Dim KB As Long = Math.Floor(DataBytes / 1024 - 1024 * MB)
            Dim B As Long = Math.Floor(DataBytes - 1024 * 1024 * MB - 1024 * KB)

            Me.lbl_SizeData.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

            EncDataSize = DataBytes

            If (EncBildSize > EncDataSize And Not EncBildSize = 0 And Not EncDataSize = 0) Then
                Me.btn_Encode.Enabled = True
            Else
                Me.btn_Encode.Enabled = False
            End If
        Else
            EncDataSize = 0

            Me.lbl_SizeData.Text = "Keine Datei ausgewählt!"
            Me.btn_Encode.Enabled = False
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub rdb_Enc_Step1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Enc_Step1.CheckedChanged
        If Me.rdb_Enc_Step1.Checked = True Then
            If (FileExists(Me.txt_Bild.Text)) Then
                Dim img As Bitmap
                img = Image.FromFile(Me.txt_Bild.Text)

                Dim Multiplicator As Long = 6

                Dim Pixel As Long = img.Height * img.Width
                Dim MB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 / 1024)
                Dim KB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 - 1024 * MB)
                Dim B As Long = Math.Floor((Pixel * Multiplicator) / 8 - 1024 * 1024 * MB - 1024 * KB)

                Me.lbl_MaxSize.Text = "Maximale Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                EncBildSize = Pixel * Multiplicator / 8

                If (EncBildSize > EncDataSize And Not EncBildSize = 0 And Not EncDataSize = 0) Then
                    Me.btn_Encode.Enabled = True
                Else
                    Me.btn_Encode.Enabled = False
                End If

                img.Dispose()
                img = Nothing

            Else
                EncBildSize = 0

                Me.lbl_MaxSize.Text = "Kein Bild ausgewählt!"
                Me.btn_Encode.Enabled = False
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub rdb_Enc_Step2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Enc_Step2.CheckedChanged
        If Me.rdb_Enc_Step2.Checked = True Then
            If (FileExists(Me.txt_Bild.Text)) Then
                Dim img As Bitmap
                img = Image.FromFile(Me.txt_Bild.Text)

                Dim Multiplicator As Long = 9

                Dim Pixel As Long = img.Height * img.Width
                Dim MB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 / 1024)
                Dim KB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 - 1024 * MB)
                Dim B As Long = Math.Floor((Pixel * Multiplicator) / 8 - 1024 * 1024 * MB - 1024 * KB)

                Me.lbl_MaxSize.Text = "Maximale Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                EncBildSize = Pixel * Multiplicator / 8

                If (EncBildSize > EncDataSize And Not EncBildSize = 0 And Not EncDataSize = 0) Then
                    Me.btn_Encode.Enabled = True
                Else
                    Me.btn_Encode.Enabled = False
                End If

                img.Dispose()
                img = Nothing

            Else
                EncBildSize = 0

                Me.lbl_MaxSize.Text = "Kein Bild ausgewählt!"
                Me.btn_Encode.Enabled = False
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub rdb_Dec_Step1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Dec_Step1.CheckedChanged
        Dim Dateiname As String = ""
        Dim Dateisize As Long = 0

        If (FileExists(Me.txt_Bild_Dec.Text)) Then
            If (Me.rdb_Dec_Step1.Checked = True) Then
                If (GetFileInfo2(Me.txt_Bild_Dec.Text, Dateiname, Dateisize, Passwort) = True) Then
                    Me.lbl_Bild_Name.Text = "Dateiname: " & Dateiname

                    Dim MB As Long = Math.Floor(Dateisize / 1024 / 1024)
                    Dim KB As Long = Math.Floor(Dateisize / 1024 - 1024 * MB)
                    Dim B As Long = Math.Floor(Dateisize - 1024 * 1024 * MB - 1024 * KB)

                    Me.lbl_Bild_Size.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                    Me.btn_Decode.Enabled = True
                Else
                    Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
                    Me.lbl_Bild_Size.Text = ""

                    Me.btn_Decode.Enabled = False
                End If
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub rdb_Dec_Step2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Dec_Step2.CheckedChanged
        Dim Dateiname As String = ""
        Dim Dateisize As Long = 0

        If (FileExists(Me.txt_Bild_Dec.Text)) Then
            If (Me.rdb_Dec_Step2.Checked = True) Then
                If (GetFileInfo3(Me.txt_Bild_Dec.Text, Dateiname, Dateisize, Passwort) = True) Then
                    Me.lbl_Bild_Name.Text = "Dateiname: " & Dateiname

                    Dim MB As Long = Math.Floor(Dateisize / 1024 / 1024)
                    Dim KB As Long = Math.Floor(Dateisize / 1024 - 1024 * MB)
                    Dim B As Long = Math.Floor(Dateisize - 1024 * 1024 * MB - 1024 * KB)

                    Me.lbl_Bild_Size.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                    Me.btn_Decode.Enabled = True
                Else
                    Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
                    Me.lbl_Bild_Size.Text = ""

                    Me.btn_Decode.Enabled = False
                End If
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub rdb_Enc_Step3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Enc_Step3.CheckedChanged
        If Me.rdb_Enc_Step3.Checked = True Then
            If (FileExists(Me.txt_Bild.Text)) Then
                Dim img As Bitmap
                img = Image.FromFile(Me.txt_Bild.Text)

                Dim Multiplicator As Long = 12

                Dim Pixel As Long = img.Height * img.Width
                Dim MB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 / 1024)
                Dim KB As Long = Math.Floor((Pixel * Multiplicator) / 8 / 1024 - 1024 * MB)
                Dim B As Long = Math.Floor((Pixel * Multiplicator) / 8 - 1024 * 1024 * MB - 1024 * KB)

                Me.lbl_MaxSize.Text = "Maximale Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                EncBildSize = Pixel * Multiplicator / 8

                If (EncBildSize > EncDataSize And Not EncBildSize = 0 And Not EncDataSize = 0) Then
                    Me.btn_Encode.Enabled = True
                Else
                    Me.btn_Encode.Enabled = False
                End If

                img.Dispose()
                img = Nothing

            Else
                EncBildSize = 0

                Me.lbl_MaxSize.Text = "Kein Bild ausgewählt!"
                Me.btn_Encode.Enabled = False
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub rdb_Dec_Step3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_Dec_Step3.CheckedChanged
        Dim Dateiname As String = ""
        Dim Dateisize As Long = 0

        If (FileExists(Me.txt_Bild_Dec.Text)) Then
            If (Me.rdb_Dec_Step3.Checked = True) Then
                If (GetFileInfo4(Me.txt_Bild_Dec.Text, Dateiname, Dateisize, Passwort) = True) Then
                    Me.lbl_Bild_Name.Text = "Dateiname: " & Dateiname

                    Dim MB As Long = Math.Floor(Dateisize / 1024 / 1024)
                    Dim KB As Long = Math.Floor(Dateisize / 1024 - 1024 * MB)
                    Dim B As Long = Math.Floor(Dateisize - 1024 * 1024 * MB - 1024 * KB)

                    Me.lbl_Bild_Size.Text = "Dateigrösse: " & MB & " MB " & KB & " KB " & B & " B"

                    Me.btn_Decode.Enabled = True
                Else
                    Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
                    Me.lbl_Bild_Size.Text = ""

                    Me.btn_Decode.Enabled = False
                End If
            End If
        End If

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Sub

    Private Sub AutoCheck_Tick(sender As System.Object, e As System.EventArgs) Handles AutoCheck.Tick
        Me.AutoCheck.Stop()

        'Testen ob Argumente übergeben wurden
        Dim arguments As String() = Environment.GetCommandLineArgs()

        'Testen ob Argument vorhanden
        If (arguments.Length > 1) Then
            'Auswerten
            Dim resultd As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/d"))
            Dim resulte As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/e"))
            Dim resulth As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/h"))
            Dim resulti As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/i"))
            Dim resulto As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/o"))
            Dim results As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/s"))
            Dim resultb As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/b"))
            Dim resultp As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/p"))
            Dim resultf As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/f"))
            Dim resulthilfe As String() = Array.FindAll(arguments, Function(s) s.ToLower().StartsWith("/?"))
            Dim resultpass(2) As String

            'Testen ob unsichtbar gestartet wird
            If (resulth.Length > 0) Then
                Me.ShowInTaskbar = False
                Me.Visible = False
            End If

            'Testen ob Hilfe
            If (resulthilfe.Length > 0) Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                AutoHilfe()
                Me.Close()
            End If

            Me.DoubleBuffered = True

            'Testen ob ein Passwort vorhanden ist
            If (resultp.Length = 0) Then
                resultpass(0) = "/p:"
            Else
                resultpass(0) = resultp(0)
            End If

            'Testen ob verschlüsselt wird
            If (resulte.Length > 0) Then
                Try
                    AutoEncrypt(Strings.Right(resulti(0), resulti(0).Length - 3), Strings.Right(resultb(0), resultb(0).Length - 3), Strings.Right(resulto(0), resulto(0).Length - 3), Strings.Right(results(0), results(0).Length - 3), Strings.Right(resultpass(0), resultpass(0).Length - 3))
                Catch
                    MsgBox("Geben sie alle benötigten Daten an. (/i /b /o /s)", vbOKOnly, "Fehler")
                    Me.Close()
                End Try

                'Testen ob Daten ingefüllt werden
                If (resultf.Length > 0) Then
                    Me.txt_Bild.Text = Strings.Right(resultb(0), resultb(0).Length - 3)
                    Me.txt_Datei.Text = Strings.Right(resulti(0), resulti(0).Length - 3)
                    Me.txt_Pass.Text = Strings.Right(resultpass(0), resultpass(0).Length - 3)
                    Select Case Strings.Right(results(0), results(0).Length - 3).ToString
                        Case "1"
                            Me.rdb_Enc_Step1.Checked = True
                        Case "2"
                            Me.rdb_Enc_Step2.Checked = True
                        Case "3"
                            Me.rdb_Enc_Step3.Checked = True
                    End Select
                End If

                'Testen ob entschlüsselt wird
            ElseIf (resultd.Length > 0) Then
                Try
                    AutoDecrypt(Strings.Right(resulti(0), resulti(0).Length - 3), Strings.Right(resulto(0), resulto(0).Length - 3), Strings.Right(results(0), results(0).Length - 3), Strings.Right(resultpass(0), resultpass(0).Length - 3))
                Catch
                    MsgBox("Geben sie alle benötigten Daten an. (/i /o /s)", vbOKOnly, "Fehler")
                    Me.Close()
                End Try

                'Testen ob Daten ingefüllt werden
                If (resultf.Length > 0) Then
                    Me.txt_Bild_Dec.Text = Strings.Right(resulti(0), resulti(0).Length - 3)
                    Me.txt_Pass_Dec.Text = Strings.Right(resultpass(0), resultpass(0).Length - 3)
                    Select Case Strings.Right(results(0), results(0).Length - 3).ToString
                        Case "1"
                            Me.rdb_Dec_Step1.Checked = True
                        Case "2"
                            Me.rdb_Dec_Step2.Checked = True
                        Case "3"
                            Me.rdb_Dec_Step3.Checked = True
                    End Select
                End If

                'Fehler
            Else
                MsgBox("Geben sie an ob sie verschlüsseln oder entschlüsseln wollen.", vbOKOnly, "Fehler")
                Me.Close()
            End If

        End If
    End Sub

    Private Sub Befehlszeilenparameter_Click(sender As System.Object, e As System.EventArgs) Handles Befehlszeilenparameter.Click
        AutoHilfe()
    End Sub

End Class
