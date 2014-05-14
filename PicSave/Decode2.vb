Imports System.ComponentModel
Imports System
Imports System.IO

Module Decode2
    'Backgoundworker
    Public WithEvents Decode As New BackgroundWorker
    Dim Erfolg_Dec As Boolean = False
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

#Region "BackGroundWorker Events"
    Public Sub Decode_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Decode.DoWork
        Dim img As Bitmap
        img = Image.FromFile(e.Argument(0))

        Dim fp As New FastPixel(img)

        Dim Pixel As Long = img.Height * img.Width
        Dim xPixel As Long = 0
        Dim yPixel As Long = 0
        Dim Color As Long = 1

        Dim DataByte As Byte

        Dim FarbeR As Long
        Dim FarbeG As Long
        Dim FarbeB As Long

        Dim Daten(200) As Byte

        Dim zaehler As Long = 0

        Dim i As Long = 0

        Erfolg_Dec = False

        fp.Lock()

        FarbeR = fp.GetPixel(xPixel, yPixel).R
        FarbeG = fp.GetPixel(xPixel, yPixel).G
        FarbeB = fp.GetPixel(xPixel, yPixel).B

        While Not zaehler = 4 And i < 200

            DataByte = 0

            For f = 0 To 7

                Select Case Color

                    Case 1
                        If (FarbeR Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 2
                        If (Not FarbeR Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 3
                        If (FarbeG Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 4
                        If (Not FarbeG Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 5
                        If (FarbeB Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 6
                        If (Not FarbeB Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 7
                        Color = 0

                        f = f - 1

                        xPixel = xPixel + 1

                        If (xPixel = fp.Width) Then
                            xPixel = 0
                            yPixel = yPixel + 1
                        End If

                        FarbeR = fp.GetPixel(xPixel, yPixel).R
                        FarbeG = fp.GetPixel(xPixel, yPixel).G
                        FarbeB = fp.GetPixel(xPixel, yPixel).B
                End Select

                Color = Color + 1
            Next

            Daten(i) = DataByte

            Try
                If (Daten(i) = 86 And Daten(i - 1) = 83 And Daten(i - 2) = 67 And Daten(i - 3) = 80) Then
                    zaehler = zaehler + 1
                End If
            Catch
            End Try

            i = i + 1
        End While

        If (i > 199) Then
            MsgBox("Fehler! Das Bild enthält keine verschlüsselten Daten!", MsgBoxStyle.Information, "Keine Daten")
            Decode.CancelAsync()
            Exit Sub
        End If

        Dim Text As String = ByteArrayToTextString(Daten)

        Text = Right(Text, Text.Length - 4)

        Dim Dateiname As String = Left(Text, InStr(Text, "PCSV") - 1)

        Text = Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Dim Size As Long = Left(Text, InStr(Text, "PCSV") - 1)

        Dim fsSource As FileStream = New FileStream(e.Argument(1) & "\" & Dateiname, FileMode.Create, FileAccess.Write)

        Dim Data(1000001) As Byte

        For i = 0 To Size - 1

            'Fortschritt
            If (i Mod 5120 = 0) Then
                Decode.ReportProgress(i, Size)
            End If

            DataByte = 0

            For f = 0 To 7

                Select Case Color
                    Case 1
                        If (FarbeR Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 2
                        If (Not FarbeR Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 3
                        If (FarbeG Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 4
                        If (Not FarbeG Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 5
                        If (FarbeB Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 6
                        If (Not FarbeB Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 7
                        Color = 0

                        f = f - 1

                        xPixel = xPixel + 1

                        If (xPixel = fp.Width) Then
                            xPixel = 0
                            yPixel = yPixel + 1
                        End If

                        FarbeR = fp.GetPixel(xPixel, yPixel).R
                        FarbeG = fp.GetPixel(xPixel, yPixel).G
                        FarbeB = fp.GetPixel(xPixel, yPixel).B

                End Select

                Color = Color + 1
            Next

            If (i Mod 1000000 = 0 And Not i = 0) Then
                fsSource.Write(Data, 0, 1000000)
            End If

            Data(i Mod 1000000) = DataByte

        Next

        fp.Unlock(True)

        fsSource.Write(Data, 0, i Mod 1000000)

        fsSource.Close()

        Erfolg_Dec = True

        img.Dispose()
        img = Nothing

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Decode.CancelAsync()
    End Sub

    Public Sub Decode_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Decode.ProgressChanged
        haupt.pgr_haupt.Maximum = e.UserState
        haupt.pgr_haupt.Value = e.ProgressPercentage
    End Sub

    Public Sub Decode_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Decode.RunWorkerCompleted
        haupt.grp_Encode.Enabled = True
        haupt.grp_Decode.Enabled = True
        haupt.Befehlszeilenparameter.Enabled = True
        haupt.pgr_haupt.Value = 0
        If (Automatic = False) Then
            If (Erfolg_Dec = True) Then
                MsgBox("Die Datei wurde erfolgreich entschlüsselt!", MsgBoxStyle.Information, "Erfolgreich entschlüsselt")
            End If
        Else
            haupt.Close()
        End If
    End Sub
#End Region

End Module
