Imports System.ComponentModel
Imports System
Imports System.IO

Module Encode2
    'Backgoundworker
    Public WithEvents Encode As New BackgroundWorker
    Dim Erfolg_Enc As Boolean = False
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Function GetTheNextGGT(ByVal Color As Long, ByVal Mod2 As Long, ByVal Mod3 As Long) As Long
        Dim Erfolg As Long = 0

        If (Color < 105) Then

            For i = Color To 255
                Erfolg = 0

                If (Mod2 = 0 And i Mod 2 = 0) Then
                    Erfolg = Erfolg + 1
                ElseIf (Mod2 > 0 And i Mod 2 > 0) Then
                    Erfolg = Erfolg + 1
                End If

                If (Mod3 = 0 And i Mod 3 = 0) Then
                    Erfolg = Erfolg + 1
                ElseIf (Mod3 > 0 And i Mod 3 > 0) Then
                    Erfolg = Erfolg + 1
                End If

                If (Erfolg = 2) Then
                    GetTheNextGGT = i
                    Exit For
                End If
            Next

        Else

            For i = Color To 0 Step -1
                Erfolg = 0

                If (Mod2 = 0 And i Mod 2 = 0) Then
                    Erfolg = Erfolg + 1
                ElseIf (Mod2 > 0 And i Mod 2 > 0) Then
                    Erfolg = Erfolg + 1
                End If

                If (Mod3 = 0 And i Mod 3 = 0) Then
                    Erfolg = Erfolg + 1
                ElseIf (Mod3 > 0 And i Mod 3 > 0) Then
                    Erfolg = Erfolg + 1
                End If

                If (Erfolg = 2) Then
                    GetTheNextGGT = i
                    Exit For
                End If
            Next
        End If

    End Function

#Region "BackGroundWorker Events"
    Public Sub Encode_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Encode.DoWork
        Dim img As Bitmap
        img = Image.FromFile(e.Argument(0))

        Dim fp As New FastPixel(img)

        Dim Pixel As Long = img.Height * img.Width
        Dim xPixel As Long = 0
        Dim yPixel As Long = 0
        Dim Color As Long = 0
        Dim CheckFile As New FileInfo(e.Argument(1))
        Dim DataBytes As Long = CheckFile.Length

        Dim DataByte As Byte

        Dim FarbeR As Long
        Dim FarbeG As Long
        Dim FarbeB As Long

        Dim Mod2 As Long = 0
        Dim Mod3 As Long = 0
        Dim Mod5 As Long = 0

        Erfolg_Enc = False

        If ((Pixel * 9) / 8 < DataBytes) Then
            MsgBox("Das Bild ist zu klein! (Zu wenig Speicher)", MsgBoxStyle.Information, "Bild zu klein!")
            Encode.CancelAsync()
            Exit Sub
        End If

        Dim fsSource As FileStream = New FileStream(e.Argument(1), FileMode.Open, FileAccess.Read)

        Dim CountBytes As Long = My.Computer.FileSystem.ReadAllBytes(e.Argument(1)).Length

        Dim DataName As String = e.Argument(1)

        While InStr(DataName, "\")
            DataName = Right(DataName, Len(DataName) - InStr(DataName, "\"))
        End While

        Dim Daten() As Byte = StringToByteArray("PCSV" & DataName & "PCSV" & My.Computer.FileSystem.ReadAllBytes(e.Argument(1)).Length & "PCSV" & e.Argument(3) & "PCSV")

        fp.Lock()

        Dim Bildsize As Integer = fp.Width

        For i = 1 To Daten.Length

            DataByte = Daten(i - 1)
            For f = 0 To 7

                Select Case Color
                    Case 0
                        FarbeR = fp.GetPixel(xPixel, yPixel).R

                        Mod2 = DataByte And (2 ^ f)

                    Case 1
                        Mod3 = DataByte And (2 ^ f)

                        FarbeR = GetTheNextGGT(FarbeR, Mod2, Mod3)

                    Case 2
                        FarbeG = fp.GetPixel(xPixel, yPixel).G

                        Mod2 = DataByte And (2 ^ f)

                    Case 3
                        Mod3 = DataByte And (2 ^ f)

                        FarbeG = GetTheNextGGT(FarbeG, Mod2, Mod3)

                    Case 4
                        FarbeB = fp.GetPixel(xPixel, yPixel).B

                        Mod2 = DataByte And (2 ^ f)

                    Case 5
                        Mod3 = DataByte And (2 ^ f)

                        FarbeB = GetTheNextGGT(FarbeB, Mod2, Mod3)
                End Select

                Color = Color + 1

                If (Color = 6) Then
                    fp.SetPixel(xPixel, yPixel, System.Drawing.Color.FromArgb(FarbeR, FarbeG, FarbeB))

                    Color = 0

                    xPixel = xPixel + 1

                    If (xPixel = Bildsize) Then
                        xPixel = 0
                        yPixel = yPixel + 1
                    End If
                End If
            Next
        Next

        Dim Data(1000001) As Byte
        fsSource.Read(Data, 0, 1000000)

        For i = 0 To My.Computer.FileSystem.ReadAllBytes(e.Argument(1)).Length - 1
            'Fortschritt
            If (i Mod 1024 = 0) Then
                Encode.ReportProgress(i, CountBytes)
            End If

            If (i Mod 1000000 = 0 And Not i = 0) Then
                fsSource.Read(Data, 0, 1000000)
            End If

            DataByte = Data(i Mod 1000000)

            For f = 0 To 7

                Select Case Color
                    Case 0
                        FarbeR = fp.GetPixel(xPixel, yPixel).R

                        Mod2 = DataByte And (2 ^ f)

                    Case 1
                        Mod3 = DataByte And (2 ^ f)

                        FarbeR = GetTheNextGGT(FarbeR, Mod2, Mod3)

                    Case 2
                        FarbeG = fp.GetPixel(xPixel, yPixel).G

                        Mod2 = DataByte And (2 ^ f)

                    Case 3
                        Mod3 = DataByte And (2 ^ f)

                        FarbeG = GetTheNextGGT(FarbeG, Mod2, Mod3)

                    Case 4
                        FarbeB = fp.GetPixel(xPixel, yPixel).B

                        Mod2 = DataByte And (2 ^ f)

                    Case 5
                        Mod3 = DataByte And (2 ^ f)

                        FarbeB = GetTheNextGGT(FarbeB, Mod2, Mod3)

                End Select

                Color = Color + 1

                If (Color = 6) Then
                    fp.SetPixel(xPixel, yPixel, System.Drawing.Color.FromArgb(FarbeR, FarbeG, FarbeB))

                    Color = 0

                    xPixel = xPixel + 1

                    If (xPixel = Bildsize) Then
                        xPixel = 0
                        yPixel = yPixel + 1
                    End If
                End If
            Next
        Next

        fp.SetPixel(xPixel, yPixel, System.Drawing.Color.FromArgb(FarbeR, FarbeG, FarbeB))

        fp.Unlock(True)

        If (Right(e.Argument(2), 3) = "tif") Then
            img.Save(e.Argument(2), System.Drawing.Imaging.ImageFormat.Tiff)
        ElseIf (Right(e.Argument(2), 3) = "bmp") Then
            img.Save(e.Argument(2), System.Drawing.Imaging.ImageFormat.Bmp)
        ElseIf (Right(e.Argument(2), 3) = "emf") Then
            img.Save(e.Argument(2), System.Drawing.Imaging.ImageFormat.Emf)
        ElseIf (Right(e.Argument(2), 3) = "png") Then
            img.Save(e.Argument(2), System.Drawing.Imaging.ImageFormat.Png)
        Else
            img.Save(e.Argument(2), System.Drawing.Imaging.ImageFormat.Wmf)
        End If

        Erfolg_Enc = True
        Encode.CancelAsync()

        img.Dispose()
        img = Nothing

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        fsSource.Close()
    End Sub

    Public Sub Encode_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Encode.ProgressChanged
        haupt.pgr_haupt.Maximum = e.UserState
        haupt.pgr_haupt.Value = e.ProgressPercentage
    End Sub

    Public Sub Encode_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Encode.RunWorkerCompleted
        haupt.grp_Encode.Enabled = True
        haupt.grp_Decode.Enabled = True
        haupt.Befehlszeilenparameter.Enabled = True
        haupt.pgr_haupt.Value = 0
        If (Automatic = False) Then
            If (Erfolg_Enc = True) Then
                MsgBox("Die Datei wurde erfolgreich verschlüsselt!", MsgBoxStyle.Information, "Erfolgreich verschlüsselt")
            End If
        Else
            haupt.Close()
        End If
    End Sub
#End Region

End Module
