Imports System.IO
Imports System.Security.Cryptography

Public Class Form1

    Function MD5hash(data() As Byte) As String
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim result As Byte() = md5.ComputeHash(data)
        Return BitConverter.ToString(result).Replace("-", "-")
    End Function
    Private Sub MorphicSkin1_Click(sender As Object, e As EventArgs) Handles MorphicSkin1.Click

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "PC: " & System.Environment.MachineName
        If MorphicCheckBox1.Checked = True Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
    End Sub

    Private Sub MorphicButton1_Click(sender As Object, e As EventArgs) Handles MorphicButton1.Click

        If MorphicCheckBox2.Checked = True Then
            IO.File.AppendAllText(OpenFileDialog1.FileName, Convert.ToChar(0).ToString)
            MsgBox("hash changed")
        End If

        If MorphicCheckBox1.Checked = True Then
            My.Computer.FileSystem.RenameFile(OpenFileDialog1.FileName, Label11.Text & ".exe")
            MsgBox("name changed")
        End If



    End Sub
    Public Function GenerateRandomString(ByRef lenStr As Integer, Optional ByVal upper As Boolean = False) As String

        Dim rand As New Random()

        Dim allowableChars() As Char = "αв¢∂єƒgнιנкℓмησρqяѕтυνωχуzﾑ乃乇ｷgんﾉﾌズﾚﾶ刀oｱq尺丂ｲu√wﾒﾘ乙".ToCharArray()
        Dim final As New System.Text.StringBuilder
        Do

            final.Append(allowableChars(rand.Next(0, allowableChars.Length)))
        Loop Until final.Length = lenStr
        Debug.WriteLine(final.Length)
        Return If(upper, final.ToString.ToUpper(), final.ToString)
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Text = GenerateRandomString(4, False) & "-" & GenerateRandomString(4, False)
    End Sub

    Private Sub MorphicButton2_Click(sender As Object, e As EventArgs) Handles MorphicButton2.Click
        With OpenFileDialog1
            .Filter = "Anwendung (*.exe)|*.exe"
            .FileName = ""
        End With

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label10.Text = OpenFileDialog1.SafeFileName
            TextBox1.Text = OpenFileDialog1.FileName
            Dim myHash As String = MD5hash(System.IO.File.ReadAllBytes(OpenFileDialog1.FileName))
            Label6.Text = myHash
            Dim information = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)
            MorphicButton1.Enabled = True
            MorphicCheckBox1.Enabled = True
            MorphicCheckBox2.Enabled = True
            Label9.Text = (information.Length & " Bytes")


        ElseIf OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then

        End If
    End Sub

    Private Sub MorphicCheckBox1_CheckedChanged(sender As Object) Handles MorphicCheckBox1.CheckedChanged
        If MorphicCheckBox1.Checked = True Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
    End Sub


    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        System.Diagnostics.Process.Start("www.cheats4.me")
    End Sub

    Private Sub MorphicCheckBox2_CheckedChanged(sender As Object) Handles MorphicCheckBox2.CheckedChanged

    End Sub
End Class
