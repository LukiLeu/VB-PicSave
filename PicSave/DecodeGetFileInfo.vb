Imports System.ComponentModel
Imports System
Imports System.IO

Module DecodeGetFileInfo
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Function GetFileInfo4(ByVal Datei As String, ByRef Dateiname As String, ByRef Dateisize As Long, ByRef Password As String) As Boolean
        Dim img As Bitmap
        img = Image.FromFile(Datei)
        Dim Pixel As Long = img.Height * img.Width
        Dim xPixel As Long = 0
        Dim yPixel As Long = 0
        Dim Color As Long = 0

        Dim DataByte As Byte

        Dim FarbeR As Long
        Dim FarbeG As Long
        Dim FarbeB As Long

        Dim Daten(200) As Byte

        Dim zaehler As Long = 0

        Dim i As Long = 0

        While Not zaehler = 4
            DataByte = 0
            For f = 0 To 7
                FarbeR = img.GetPixel(xPixel, yPixel).R
                FarbeG = img.GetPixel(xPixel, yPixel).G
                FarbeB = img.GetPixel(xPixel, yPixel).B

                Select Case Color
                    Case 0
                        If (FarbeR Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 1
                        If (Not FarbeR Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 2
                        If (Not FarbeR Mod 5 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 3
                        If (Not FarbeR Mod 7 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 4
                        If (FarbeG Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 5
                        If (Not FarbeG Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 6
                        If (Not FarbeG Mod 5 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 7
                        If (Not FarbeG Mod 7 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 8
                        If (FarbeB Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 9
                        If (Not FarbeB Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 10
                        If (Not FarbeB Mod 5 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 11
                        If (Not FarbeB Mod 7 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If
                End Select

                Color = Color + 1

                If (Color = 12) Then
                    Color = 0

                    xPixel = xPixel + 1

                    If (xPixel = img.Width) Then
                        xPixel = 0
                        yPixel = yPixel + 1
                    End If
                End If
            Next

            Daten(i) = DataByte

            Try
                If (Daten(i) = 86 And Daten(i - 1) = 83 And Daten(i - 2) = 67 And Daten(i - 3) = 80) Then
                    zaehler = zaehler + 1
                End If
            Catch
            End Try

            If (i > 199) Then
                GetFileInfo4 = False
                Exit Function
            End If

            i = i + 1
        End While

        Dim Text As String = ByteArrayToTextString(Daten)

        Text = Strings.Right(Text, Text.Length - 4)

        Dateiname = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        Text = Strings.Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Dateisize = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        Text = Strings.Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Password = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        GetFileInfo4 = True

        img.Dispose()
        img = Nothing

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Function


    Public Function GetFileInfo3(ByVal Datei As String, ByRef Dateiname As String, ByRef Dateisize As Long, ByRef Password As String) As Boolean
        Dim img As Bitmap
        img = Image.FromFile(Datei)
        Dim Pixel As Long = img.Height * img.Width
        Dim xPixel As Long = 0
        Dim yPixel As Long = 0
        Dim Color As Long = 0

        Dim DataByte As Byte

        Dim FarbeR As Long
        Dim FarbeG As Long
        Dim FarbeB As Long

        Dim Daten(200) As Byte

        Dim zaehler As Long = 0

        Dim i As Long = 0

        While Not zaehler = 4
            DataByte = 0
            For f = 0 To 7
                FarbeR = img.GetPixel(xPixel, yPixel).R
                FarbeG = img.GetPixel(xPixel, yPixel).G
                FarbeB = img.GetPixel(xPixel, yPixel).B

                Select Case Color
                    Case 0
                        If (FarbeR Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 1
                        If (Not FarbeR Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 2
                        If (Not FarbeR Mod 5 = 0) Then
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
                        If (Not FarbeG Mod 5 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 6
                        If (FarbeB Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 7
                        If (Not FarbeB Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 8
                        If (Not FarbeB Mod 5 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If
                End Select

                Color = Color + 1

                If (Color = 9) Then
                    Color = 0

                    xPixel = xPixel + 1

                    If (xPixel = img.Width) Then
                        xPixel = 0
                        yPixel = yPixel + 1
                    End If
                End If
            Next

            Daten(i) = DataByte

            Try
                If (Daten(i) = 86 And Daten(i - 1) = 83 And Daten(i - 2) = 67 And Daten(i - 3) = 80) Then
                    zaehler = zaehler + 1
                End If
            Catch
            End Try

            If (i > 199) Then
                GetFileInfo3 = False
                Exit Function
            End If

            i = i + 1
        End While

        Dim Text As String = ByteArrayToTextString(Daten)

        Text = Strings.Right(Text, Text.Length - 4)

        Dateiname = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        Text = Strings.Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Dateisize = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        Text = Strings.Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Password = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        GetFileInfo3 = True

        img.Dispose()
        img = Nothing

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Function

    Public Function GetFileInfo2(ByVal Datei As String, ByRef Dateiname As String, ByRef Dateisize As Long, ByRef Password As String) As Boolean
        Dim img As Bitmap
        img = Image.FromFile(Datei)
        Dim Pixel As Long = img.Height * img.Width
        Dim xPixel As Long = 0
        Dim yPixel As Long = 0
        Dim Color As Long = 0

        Dim DataByte As Byte

        Dim FarbeR As Long
        Dim FarbeG As Long
        Dim FarbeB As Long

        Dim Daten(200) As Byte

        Dim zaehler As Long = 0

        Dim i As Long = 0

        While Not zaehler = 4
            DataByte = 0
            For f = 0 To 7
                FarbeR = img.GetPixel(xPixel, yPixel).R
                FarbeG = img.GetPixel(xPixel, yPixel).G
                FarbeB = img.GetPixel(xPixel, yPixel).B

                Select Case Color
                    Case 0
                        If (FarbeR Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 1
                        If (Not FarbeR Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 2
                        If (FarbeG Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 3
                        If (Not FarbeG Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 4
                        If (FarbeB Mod 2 = 1) Then
                            DataByte = DataByte + (2 ^ f)
                        End If

                    Case 5
                        If (Not FarbeB Mod 3 = 0) Then
                            DataByte = DataByte + (2 ^ f)
                        End If
                End Select

                Color = Color + 1

                If (Color = 6) Then
                    Color = 0

                    xPixel = xPixel + 1

                    If (xPixel = img.Width) Then
                        xPixel = 0
                        yPixel = yPixel + 1
                    End If
                End If
            Next

            Daten(i) = DataByte

            Try
                If (Daten(i) = 86 And Daten(i - 1) = 83 And Daten(i - 2) = 67 And Daten(i - 3) = 80) Then
                    zaehler = zaehler + 1
                End If
            Catch
            End Try

            If (i > 199) Then
                GetFileInfo2 = False
                Exit Function
            End If

            i = i + 1
        End While

        Dim Text As String = ByteArrayToTextString(Daten)

        Text = Strings.Right(Text, Text.Length - 4)

        Dateiname = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        Text = Strings.Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Dateisize = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        Text = Strings.Right(Text, Text.Length - InStr(Text, "PCSV") - 3)

        Password = Strings.Left(Text, InStr(Text, "PCSV") - 1)

        GetFileInfo2 = True

        img.Dispose()
        img = Nothing

        Dim Mem As Process
        Mem = Process.GetCurrentProcess()
        SetProcessWorkingSetSize(Mem.Handle, -1, -1)
    End Function


End Module
