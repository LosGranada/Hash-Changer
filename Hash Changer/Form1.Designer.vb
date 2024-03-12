<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MorphicSkin1 = New Hash_Changer.MorphicSkin()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MorphicSeparator2 = New Hash_Changer.MorphicSeparator()
        Me.MorphicSeparator1 = New Hash_Changer.MorphicSeparator()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MorphicCheckBox2 = New Hash_Changer.MorphicCheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MorphicCheckBox1 = New Hash_Changer.MorphicCheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MorphicButton2 = New Hash_Changer.MorphicButton()
        Me.MorphicButton1 = New Hash_Changer.MorphicButton()
        Me.MorphicSkin1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MorphicSkin1
        '
        Me.MorphicSkin1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.MorphicSkin1.Controls.Add(Me.Label7)
        Me.MorphicSkin1.Controls.Add(Me.Label5)
        Me.MorphicSkin1.Controls.Add(Me.Label2)
        Me.MorphicSkin1.Controls.Add(Me.PictureBox1)
        Me.MorphicSkin1.Controls.Add(Me.MorphicSeparator2)
        Me.MorphicSkin1.Controls.Add(Me.MorphicSeparator1)
        Me.MorphicSkin1.Controls.Add(Me.Label4)
        Me.MorphicSkin1.Controls.Add(Me.MorphicCheckBox2)
        Me.MorphicSkin1.Controls.Add(Me.Label3)
        Me.MorphicSkin1.Controls.Add(Me.Label10)
        Me.MorphicSkin1.Controls.Add(Me.MorphicCheckBox1)
        Me.MorphicSkin1.Controls.Add(Me.Label9)
        Me.MorphicSkin1.Controls.Add(Me.Label11)
        Me.MorphicSkin1.Controls.Add(Me.TextBox1)
        Me.MorphicSkin1.Controls.Add(Me.Label6)
        Me.MorphicSkin1.Controls.Add(Me.Label1)
        Me.MorphicSkin1.Controls.Add(Me.MorphicButton2)
        Me.MorphicSkin1.Controls.Add(Me.MorphicButton1)
        Me.MorphicSkin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MorphicSkin1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MorphicSkin1.HeaderFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MorphicSkin1.IconImage = Nothing
        Me.MorphicSkin1.Location = New System.Drawing.Point(0, 0)
        Me.MorphicSkin1.Name = "MorphicSkin1"
        Me.MorphicSkin1.Size = New System.Drawing.Size(413, 261)
        Me.MorphicSkin1.TabIndex = 0
        Me.MorphicSkin1.Text = "Hash Changer"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label7.Location = New System.Drawing.Point(365, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 15)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "SariN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label5.Location = New System.Drawing.Point(154, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "www.cheats4.me"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label2.Location = New System.Drawing.Point(12, 237)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "PC: "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 195)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(391, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'MorphicSeparator2
        '
        Me.MorphicSeparator2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MorphicSeparator2.Intensity = 40
        Me.MorphicSeparator2.LineColor = System.Drawing.Color.White
        Me.MorphicSeparator2.Location = New System.Drawing.Point(0, 149)
        Me.MorphicSeparator2.Name = "MorphicSeparator2"
        Me.MorphicSeparator2.Size = New System.Drawing.Size(422, 9)
        Me.MorphicSeparator2.TabIndex = 29
        Me.MorphicSeparator2.Text = "MorphicSeparator2"
        '
        'MorphicSeparator1
        '
        Me.MorphicSeparator1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MorphicSeparator1.Intensity = 40
        Me.MorphicSeparator1.LineColor = System.Drawing.Color.White
        Me.MorphicSeparator1.Location = New System.Drawing.Point(0, 108)
        Me.MorphicSeparator1.Name = "MorphicSeparator1"
        Me.MorphicSeparator1.Size = New System.Drawing.Size(422, 10)
        Me.MorphicSeparator1.TabIndex = 28
        Me.MorphicSeparator1.Text = "MorphicSeparator1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label4.Location = New System.Drawing.Point(12, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Name: "
        '
        'MorphicCheckBox2
        '
        Me.MorphicCheckBox2.Checked = False
        Me.MorphicCheckBox2.Enabled = False
        Me.MorphicCheckBox2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MorphicCheckBox2.Location = New System.Drawing.Point(292, 164)
        Me.MorphicCheckBox2.Name = "MorphicCheckBox2"
        Me.MorphicCheckBox2.Size = New System.Drawing.Size(111, 24)
        Me.MorphicCheckBox2.TabIndex = 3
        Me.MorphicCheckBox2.Text = "Change MD5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label3.Location = New System.Drawing.Point(12, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "File Size: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label10.Location = New System.Drawing.Point(75, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 15)
        Me.Label10.TabIndex = 14
        '
        'MorphicCheckBox1
        '
        Me.MorphicCheckBox1.Checked = False
        Me.MorphicCheckBox1.Enabled = False
        Me.MorphicCheckBox1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MorphicCheckBox1.Location = New System.Drawing.Point(12, 164)
        Me.MorphicCheckBox1.Name = "MorphicCheckBox1"
        Me.MorphicCheckBox1.Size = New System.Drawing.Size(129, 24)
        Me.MorphicCheckBox1.TabIndex = 2
        Me.MorphicCheckBox1.Text = "Change Name ->"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label9.Location = New System.Drawing.Point(75, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 15)
        Me.Label9.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label11.Location = New System.Drawing.Point(147, 169)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 15)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Label11"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(490, 307)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(380, 21)
        Me.TextBox1.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(88, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label1.Location = New System.Drawing.Point(12, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "MD5 Hash: "
        '
        'MorphicButton2
        '
        Me.MorphicButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MorphicButton2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.MorphicButton2.Location = New System.Drawing.Point(15, 48)
        Me.MorphicButton2.Name = "MorphicButton2"
        Me.MorphicButton2.Size = New System.Drawing.Size(180, 25)
        Me.MorphicButton2.TabIndex = 1
        Me.MorphicButton2.Text = "Open File"
        '
        'MorphicButton1
        '
        Me.MorphicButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MorphicButton1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.MorphicButton1.Location = New System.Drawing.Point(223, 48)
        Me.MorphicButton1.Name = "MorphicButton1"
        Me.MorphicButton1.Size = New System.Drawing.Size(180, 25)
        Me.MorphicButton1.TabIndex = 0
        Me.MorphicButton1.Text = "Change File"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 261)
        Me.Controls.Add(Me.MorphicSkin1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.MorphicSkin1.ResumeLayout(False)
        Me.MorphicSkin1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MorphicSkin1 As Hash_Changer.MorphicSkin
    Friend WithEvents MorphicButton1 As Hash_Changer.MorphicButton
    Friend WithEvents MorphicCheckBox2 As Hash_Changer.MorphicCheckBox
    Friend WithEvents MorphicCheckBox1 As Hash_Changer.MorphicCheckBox
    Friend WithEvents MorphicButton2 As Hash_Changer.MorphicButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MorphicSeparator2 As Hash_Changer.MorphicSeparator
    Friend WithEvents MorphicSeparator1 As Hash_Changer.MorphicSeparator
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
