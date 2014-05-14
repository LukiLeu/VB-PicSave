<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class haupt
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lbl_Bild = New System.Windows.Forms.Label()
        Me.txt_Bild = New System.Windows.Forms.TextBox()
        Me.lbl_Datei = New System.Windows.Forms.Label()
        Me.txt_Datei = New System.Windows.Forms.TextBox()
        Me.btn_Encode = New System.Windows.Forms.Button()
        Me.grp_Encode = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Pass = New System.Windows.Forms.TextBox()
        Me.rdb_Enc_Step3 = New System.Windows.Forms.RadioButton()
        Me.lbl_SizeData = New System.Windows.Forms.Label()
        Me.rdb_Enc_Step2 = New System.Windows.Forms.RadioButton()
        Me.rdb_Enc_Step1 = New System.Windows.Forms.RadioButton()
        Me.btn_Search_FileEnc = New System.Windows.Forms.Button()
        Me.btn_Search_PicEnc = New System.Windows.Forms.Button()
        Me.lbl_MaxSize = New System.Windows.Forms.Label()
        Me.grp_Decode = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Pass_Dec = New System.Windows.Forms.TextBox()
        Me.rdb_Dec_Step3 = New System.Windows.Forms.RadioButton()
        Me.rdb_Dec_Step1 = New System.Windows.Forms.RadioButton()
        Me.rdb_Dec_Step2 = New System.Windows.Forms.RadioButton()
        Me.lbl_Bild_Size = New System.Windows.Forms.Label()
        Me.btn_SearchPic_Dec = New System.Windows.Forms.Button()
        Me.lbl_Bild_Name = New System.Windows.Forms.Label()
        Me.lbl_Bild_Dec = New System.Windows.Forms.Label()
        Me.txt_Bild_Dec = New System.Windows.Forms.TextBox()
        Me.btn_Decode = New System.Windows.Forms.Button()
        Me.pgr_haupt = New System.Windows.Forms.ProgressBar()
        Me.lbl_CPR1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AutoCheck = New System.Windows.Forms.Timer(Me.components)
        Me.Befehlszeilenparameter = New System.Windows.Forms.Button()
        Me.grp_Encode.SuspendLayout()
        Me.grp_Decode.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Bild
        '
        Me.lbl_Bild.AutoSize = True
        Me.lbl_Bild.Location = New System.Drawing.Point(6, 26)
        Me.lbl_Bild.Name = "lbl_Bild"
        Me.lbl_Bild.Size = New System.Drawing.Size(151, 13)
        Me.lbl_Bild.TabIndex = 0
        Me.lbl_Bild.Text = "Wählen sie das Grundbild aus:"
        '
        'txt_Bild
        '
        Me.txt_Bild.Location = New System.Drawing.Point(6, 42)
        Me.txt_Bild.Name = "txt_Bild"
        Me.txt_Bild.Size = New System.Drawing.Size(262, 20)
        Me.txt_Bild.TabIndex = 1
        '
        'lbl_Datei
        '
        Me.lbl_Datei.AutoSize = True
        Me.lbl_Datei.Location = New System.Drawing.Point(6, 103)
        Me.lbl_Datei.Name = "lbl_Datei"
        Me.lbl_Datei.Size = New System.Drawing.Size(221, 13)
        Me.lbl_Datei.TabIndex = 2
        Me.lbl_Datei.Text = "Wählen sie die zu verschlüsselnde Datei aus:"
        '
        'txt_Datei
        '
        Me.txt_Datei.Location = New System.Drawing.Point(9, 119)
        Me.txt_Datei.Name = "txt_Datei"
        Me.txt_Datei.Size = New System.Drawing.Size(262, 20)
        Me.txt_Datei.TabIndex = 3
        '
        'btn_Encode
        '
        Me.btn_Encode.Enabled = False
        Me.btn_Encode.Location = New System.Drawing.Point(9, 200)
        Me.btn_Encode.Name = "btn_Encode"
        Me.btn_Encode.Size = New System.Drawing.Size(371, 20)
        Me.btn_Encode.TabIndex = 4
        Me.btn_Encode.Text = "Verschlüsseln"
        Me.btn_Encode.UseVisualStyleBackColor = True
        '
        'grp_Encode
        '
        Me.grp_Encode.Controls.Add(Me.Label2)
        Me.grp_Encode.Controls.Add(Me.txt_Pass)
        Me.grp_Encode.Controls.Add(Me.rdb_Enc_Step3)
        Me.grp_Encode.Controls.Add(Me.lbl_SizeData)
        Me.grp_Encode.Controls.Add(Me.rdb_Enc_Step2)
        Me.grp_Encode.Controls.Add(Me.rdb_Enc_Step1)
        Me.grp_Encode.Controls.Add(Me.btn_Search_FileEnc)
        Me.grp_Encode.Controls.Add(Me.btn_Search_PicEnc)
        Me.grp_Encode.Controls.Add(Me.lbl_MaxSize)
        Me.grp_Encode.Controls.Add(Me.lbl_Bild)
        Me.grp_Encode.Controls.Add(Me.txt_Bild)
        Me.grp_Encode.Controls.Add(Me.lbl_Datei)
        Me.grp_Encode.Controls.Add(Me.txt_Datei)
        Me.grp_Encode.Controls.Add(Me.btn_Encode)
        Me.grp_Encode.Location = New System.Drawing.Point(12, 12)
        Me.grp_Encode.Name = "grp_Encode"
        Me.grp_Encode.Size = New System.Drawing.Size(389, 225)
        Me.grp_Encode.TabIndex = 8
        Me.grp_Encode.TabStop = False
        Me.grp_Encode.Text = "Verschlüsseln"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Passwort (freiwillig):"
        '
        'txt_Pass
        '
        Me.txt_Pass.Location = New System.Drawing.Point(9, 174)
        Me.txt_Pass.Name = "txt_Pass"
        Me.txt_Pass.Size = New System.Drawing.Size(371, 20)
        Me.txt_Pass.TabIndex = 14
        '
        'rdb_Enc_Step3
        '
        Me.rdb_Enc_Step3.AutoSize = True
        Me.rdb_Enc_Step3.Location = New System.Drawing.Point(243, 81)
        Me.rdb_Enc_Step3.Name = "rdb_Enc_Step3"
        Me.rdb_Enc_Step3.Size = New System.Drawing.Size(111, 17)
        Me.rdb_Enc_Step3.TabIndex = 13
        Me.rdb_Enc_Step3.Text = "Verschlüsselung 3"
        Me.rdb_Enc_Step3.UseVisualStyleBackColor = True
        '
        'lbl_SizeData
        '
        Me.lbl_SizeData.AutoSize = True
        Me.lbl_SizeData.Location = New System.Drawing.Point(6, 142)
        Me.lbl_SizeData.Name = "lbl_SizeData"
        Me.lbl_SizeData.Size = New System.Drawing.Size(122, 13)
        Me.lbl_SizeData.TabIndex = 12
        Me.lbl_SizeData.Text = "Keine Datei ausgewählt!"
        '
        'rdb_Enc_Step2
        '
        Me.rdb_Enc_Step2.AutoSize = True
        Me.rdb_Enc_Step2.Location = New System.Drawing.Point(126, 81)
        Me.rdb_Enc_Step2.Name = "rdb_Enc_Step2"
        Me.rdb_Enc_Step2.Size = New System.Drawing.Size(111, 17)
        Me.rdb_Enc_Step2.TabIndex = 11
        Me.rdb_Enc_Step2.Text = "Verschlüsselung 2"
        Me.rdb_Enc_Step2.UseVisualStyleBackColor = True
        '
        'rdb_Enc_Step1
        '
        Me.rdb_Enc_Step1.AutoSize = True
        Me.rdb_Enc_Step1.Checked = True
        Me.rdb_Enc_Step1.Location = New System.Drawing.Point(9, 81)
        Me.rdb_Enc_Step1.Name = "rdb_Enc_Step1"
        Me.rdb_Enc_Step1.Size = New System.Drawing.Size(111, 17)
        Me.rdb_Enc_Step1.TabIndex = 10
        Me.rdb_Enc_Step1.TabStop = True
        Me.rdb_Enc_Step1.Text = "Verschlüsselung 1"
        Me.rdb_Enc_Step1.UseVisualStyleBackColor = True
        '
        'btn_Search_FileEnc
        '
        Me.btn_Search_FileEnc.Location = New System.Drawing.Point(274, 119)
        Me.btn_Search_FileEnc.Name = "btn_Search_FileEnc"
        Me.btn_Search_FileEnc.Size = New System.Drawing.Size(106, 20)
        Me.btn_Search_FileEnc.TabIndex = 9
        Me.btn_Search_FileEnc.Text = "Durchsuchen"
        Me.btn_Search_FileEnc.UseVisualStyleBackColor = True
        '
        'btn_Search_PicEnc
        '
        Me.btn_Search_PicEnc.Location = New System.Drawing.Point(274, 42)
        Me.btn_Search_PicEnc.Name = "btn_Search_PicEnc"
        Me.btn_Search_PicEnc.Size = New System.Drawing.Size(106, 20)
        Me.btn_Search_PicEnc.TabIndex = 6
        Me.btn_Search_PicEnc.Text = "Durchsuchen"
        Me.btn_Search_PicEnc.UseVisualStyleBackColor = True
        '
        'lbl_MaxSize
        '
        Me.lbl_MaxSize.AutoSize = True
        Me.lbl_MaxSize.Location = New System.Drawing.Point(6, 65)
        Me.lbl_MaxSize.Name = "lbl_MaxSize"
        Me.lbl_MaxSize.Size = New System.Drawing.Size(108, 13)
        Me.lbl_MaxSize.TabIndex = 5
        Me.lbl_MaxSize.Text = "Kein Bild ausgewählt!"
        '
        'grp_Decode
        '
        Me.grp_Decode.Controls.Add(Me.Label3)
        Me.grp_Decode.Controls.Add(Me.txt_Pass_Dec)
        Me.grp_Decode.Controls.Add(Me.rdb_Dec_Step3)
        Me.grp_Decode.Controls.Add(Me.rdb_Dec_Step1)
        Me.grp_Decode.Controls.Add(Me.rdb_Dec_Step2)
        Me.grp_Decode.Controls.Add(Me.lbl_Bild_Size)
        Me.grp_Decode.Controls.Add(Me.btn_SearchPic_Dec)
        Me.grp_Decode.Controls.Add(Me.lbl_Bild_Name)
        Me.grp_Decode.Controls.Add(Me.lbl_Bild_Dec)
        Me.grp_Decode.Controls.Add(Me.txt_Bild_Dec)
        Me.grp_Decode.Controls.Add(Me.btn_Decode)
        Me.grp_Decode.Location = New System.Drawing.Point(407, 12)
        Me.grp_Decode.Name = "grp_Decode"
        Me.grp_Decode.Size = New System.Drawing.Size(389, 182)
        Me.grp_Decode.TabIndex = 9
        Me.grp_Decode.TabStop = False
        Me.grp_Decode.Text = "Entschlüsseln"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Passwort (falls vorhanden):"
        '
        'txt_Pass_Dec
        '
        Me.txt_Pass_Dec.Location = New System.Drawing.Point(6, 130)
        Me.txt_Pass_Dec.Name = "txt_Pass_Dec"
        Me.txt_Pass_Dec.Size = New System.Drawing.Size(371, 20)
        Me.txt_Pass_Dec.TabIndex = 16
        '
        'rdb_Dec_Step3
        '
        Me.rdb_Dec_Step3.AutoSize = True
        Me.rdb_Dec_Step3.Location = New System.Drawing.Point(237, 94)
        Me.rdb_Dec_Step3.Name = "rdb_Dec_Step3"
        Me.rdb_Dec_Step3.Size = New System.Drawing.Size(111, 17)
        Me.rdb_Dec_Step3.TabIndex = 13
        Me.rdb_Dec_Step3.Text = "Verschlüsselung 3"
        Me.rdb_Dec_Step3.UseVisualStyleBackColor = True
        '
        'rdb_Dec_Step1
        '
        Me.rdb_Dec_Step1.AutoSize = True
        Me.rdb_Dec_Step1.Checked = True
        Me.rdb_Dec_Step1.Location = New System.Drawing.Point(9, 94)
        Me.rdb_Dec_Step1.Name = "rdb_Dec_Step1"
        Me.rdb_Dec_Step1.Size = New System.Drawing.Size(111, 17)
        Me.rdb_Dec_Step1.TabIndex = 12
        Me.rdb_Dec_Step1.TabStop = True
        Me.rdb_Dec_Step1.Text = "Verschlüsselung 1"
        Me.rdb_Dec_Step1.UseVisualStyleBackColor = True
        '
        'rdb_Dec_Step2
        '
        Me.rdb_Dec_Step2.AutoSize = True
        Me.rdb_Dec_Step2.Location = New System.Drawing.Point(126, 94)
        Me.rdb_Dec_Step2.Name = "rdb_Dec_Step2"
        Me.rdb_Dec_Step2.Size = New System.Drawing.Size(111, 17)
        Me.rdb_Dec_Step2.TabIndex = 12
        Me.rdb_Dec_Step2.Text = "Verschlüsselung 2"
        Me.rdb_Dec_Step2.UseVisualStyleBackColor = True
        '
        'lbl_Bild_Size
        '
        Me.lbl_Bild_Size.AutoSize = True
        Me.lbl_Bild_Size.Location = New System.Drawing.Point(6, 78)
        Me.lbl_Bild_Size.Name = "lbl_Bild_Size"
        Me.lbl_Bild_Size.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Bild_Size.TabIndex = 7
        '
        'btn_SearchPic_Dec
        '
        Me.btn_SearchPic_Dec.Location = New System.Drawing.Point(274, 42)
        Me.btn_SearchPic_Dec.Name = "btn_SearchPic_Dec"
        Me.btn_SearchPic_Dec.Size = New System.Drawing.Size(106, 20)
        Me.btn_SearchPic_Dec.TabIndex = 6
        Me.btn_SearchPic_Dec.Text = "Durchsuchen"
        Me.btn_SearchPic_Dec.UseVisualStyleBackColor = True
        '
        'lbl_Bild_Name
        '
        Me.lbl_Bild_Name.AutoSize = True
        Me.lbl_Bild_Name.Location = New System.Drawing.Point(6, 65)
        Me.lbl_Bild_Name.Name = "lbl_Bild_Name"
        Me.lbl_Bild_Name.Size = New System.Drawing.Size(183, 13)
        Me.lbl_Bild_Name.TabIndex = 5
        Me.lbl_Bild_Name.Text = "Kein verschlüsseltes Bild ausgewählt!"
        '
        'lbl_Bild_Dec
        '
        Me.lbl_Bild_Dec.AutoSize = True
        Me.lbl_Bild_Dec.Location = New System.Drawing.Point(6, 26)
        Me.lbl_Bild_Dec.Name = "lbl_Bild_Dec"
        Me.lbl_Bild_Dec.Size = New System.Drawing.Size(195, 13)
        Me.lbl_Bild_Dec.TabIndex = 0
        Me.lbl_Bild_Dec.Text = "Wählen Sie das verschlüsselte Bild aus:"
        '
        'txt_Bild_Dec
        '
        Me.txt_Bild_Dec.Location = New System.Drawing.Point(6, 42)
        Me.txt_Bild_Dec.Name = "txt_Bild_Dec"
        Me.txt_Bild_Dec.Size = New System.Drawing.Size(262, 20)
        Me.txt_Bild_Dec.TabIndex = 1
        '
        'btn_Decode
        '
        Me.btn_Decode.Enabled = False
        Me.btn_Decode.Location = New System.Drawing.Point(6, 154)
        Me.btn_Decode.Name = "btn_Decode"
        Me.btn_Decode.Size = New System.Drawing.Size(371, 20)
        Me.btn_Decode.TabIndex = 4
        Me.btn_Decode.Text = "Entschlüsseln"
        Me.btn_Decode.UseVisualStyleBackColor = True
        '
        'pgr_haupt
        '
        Me.pgr_haupt.Location = New System.Drawing.Point(12, 243)
        Me.pgr_haupt.Name = "pgr_haupt"
        Me.pgr_haupt.Size = New System.Drawing.Size(784, 18)
        Me.pgr_haupt.TabIndex = 10
        '
        'lbl_CPR1
        '
        Me.lbl_CPR1.AutoSize = True
        Me.lbl_CPR1.Location = New System.Drawing.Point(719, 211)
        Me.lbl_CPR1.Name = "lbl_CPR1"
        Me.lbl_CPR1.Size = New System.Drawing.Size(77, 13)
        Me.lbl_CPR1.TabIndex = 11
        Me.lbl_CPR1.Text = "PicSave v. 1.4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(639, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "(c) 2013 by Lukas Leuenberger"
        '
        'AutoCheck
        '
        Me.AutoCheck.Interval = 1
        '
        'Befehlszeilenparameter
        '
        Me.Befehlszeilenparameter.Location = New System.Drawing.Point(407, 200)
        Me.Befehlszeilenparameter.Name = "Befehlszeilenparameter"
        Me.Befehlszeilenparameter.Size = New System.Drawing.Size(189, 37)
        Me.Befehlszeilenparameter.TabIndex = 13
        Me.Befehlszeilenparameter.Text = "Befehlszeilenparameter anzeigen"
        Me.Befehlszeilenparameter.UseVisualStyleBackColor = True
        '
        'haupt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 270)
        Me.Controls.Add(Me.Befehlszeilenparameter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_CPR1)
        Me.Controls.Add(Me.pgr_haupt)
        Me.Controls.Add(Me.grp_Decode)
        Me.Controls.Add(Me.grp_Encode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "haupt"
        Me.Text = "PicSave"
        Me.grp_Encode.ResumeLayout(False)
        Me.grp_Encode.PerformLayout()
        Me.grp_Decode.ResumeLayout(False)
        Me.grp_Decode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Bild As System.Windows.Forms.Label
    Friend WithEvents txt_Bild As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Datei As System.Windows.Forms.Label
    Friend WithEvents txt_Datei As System.Windows.Forms.TextBox
    Friend WithEvents btn_Encode As System.Windows.Forms.Button
    Friend WithEvents grp_Encode As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_MaxSize As System.Windows.Forms.Label
    Friend WithEvents btn_Search_PicEnc As System.Windows.Forms.Button
    Friend WithEvents btn_Search_FileEnc As System.Windows.Forms.Button
    Friend WithEvents grp_Decode As System.Windows.Forms.GroupBox
    Friend WithEvents btn_SearchPic_Dec As System.Windows.Forms.Button
    Friend WithEvents lbl_Bild_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Bild_Dec As System.Windows.Forms.Label
    Friend WithEvents txt_Bild_Dec As System.Windows.Forms.TextBox
    Friend WithEvents btn_Decode As System.Windows.Forms.Button
    Friend WithEvents pgr_haupt As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_Bild_Size As System.Windows.Forms.Label
    Friend WithEvents rdb_Enc_Step2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Enc_Step1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Dec_Step1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Dec_Step2 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_SizeData As System.Windows.Forms.Label
    Friend WithEvents lbl_CPR1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdb_Enc_Step3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Dec_Step3 As System.Windows.Forms.RadioButton
    Friend WithEvents AutoCheck As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Pass As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Pass_Dec As System.Windows.Forms.TextBox
    Friend WithEvents Befehlszeilenparameter As System.Windows.Forms.Button

End Class
