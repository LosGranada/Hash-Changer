Imports System.Drawing.Drawing2D
Imports System.ComponentModel
 
Module Preferences
 
' Color that will be used to fill controls throughout the entire theme
' Intense bright colors will work the best
Public MainColor As Color = Color.Red
 
' Color of the border that will draw around the outside of most controls
Public BorderColor As Color = Color.FromArgb(30, 30, 30)
 
' Color of the text that will be drawn
Public TextColor As Color = Color.Silver
 
' Background color of container controls such as the form skin and groupbox
Public BackgroundColor As Color = Color.FromArgb(40, 40, 40)
 
' Background color of most controls
' Some controls have offset background colors for visual purposes
Public ControlBackColor As Color = Color.FromArgb(70, 70, 70)
 
' Background color of secondary controls such as the progress bar and textbox
Public SecondaryBackColor As Color = Color.FromArgb(35, 35, 35)
 
' Font style of the text that will appear on most controls
Public FontFamily As String = "Arial"
 
' Determines how round your controls will be.
' 0 = no rounding, 10 = maximum rounding
Public Rounding As Integer = 4
 
End Module
 
Class DrawingHelper
 
Enum RoundingStyle
All
Top
Bottom
Left
Right
TopRight
BottomRight
End Enum
 
Public Function RoundRect(ByVal rect As Rectangle, ByVal slope As Integer, Optional ByVal style As RoundingStyle = RoundingStyle.All) As GraphicsPath
 
Dim gp As GraphicsPath = New GraphicsPath()
Dim arcWidth As Integer = slope * 2
 
gp.StartFigure()
 
If slope = 0 Then
gp.AddRectangle(rect)
gp.CloseAllFigures()
Return gp
End If
 
Select Case style
Case RoundingStyle.All
gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
Case RoundingStyle.Top
gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
gp.AddLine(New Point(rect.X + rect.Width, rect.Y + rect.Height), New Point(rect.X, rect.Y + rect.Height))
Case RoundingStyle.Bottom
gp.AddLine(New Point(rect.X, rect.Y), New Point(rect.X + rect.Width, rect.Y))
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
Case RoundingStyle.Left
gp.AddArc(New Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90)
gp.AddLine(New Point(rect.X + rect.Width, rect.Y), New Point(rect.X + rect.Width, rect.Y + rect.Height))
gp.AddArc(New Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90)
Case RoundingStyle.Right
gp.AddLine(New Point(rect.X, rect.Y + rect.Height), New Point(rect.X, rect.Y))
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
Case RoundingStyle.TopRight
gp.AddLine(New Point(rect.X, rect.Y + 1), New Point(rect.X, rect.Y))
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90)
gp.AddLine(New Point(rect.X + rect.Width, rect.Y + rect.Height - 1), New Point(rect.X + rect.Width, rect.Y + rect.Height))
gp.AddLine(New Point(rect.X + 1, rect.Y + rect.Height), New Point(rect.X, rect.Y + rect.Height))
Case RoundingStyle.BottomRight
gp.AddLine(New Point(rect.X, rect.Y + 1), New Point(rect.X, rect.Y))
gp.AddLine(New Point(rect.X + rect.Width - 1, rect.Y), New Point(rect.X + rect.Width, rect.Y))
gp.AddArc(New Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90)
gp.AddLine(New Point(rect.X + 1, rect.Y + rect.Height), New Point(rect.X, rect.Y + rect.Height))
End Select
 
gp.CloseAllFigures()
 
Return gp
 
End Function
 
Enum ColorAdjustmentType
Lighten
Darken
End Enum
 
Public Function AdjustColor(ByVal c As Color, ByVal intensity As Integer, ByVal adjustment As ColorAdjustmentType, Optional ByVal keepAlpha As Boolean = True) As Color
 
Dim r, g, b As Integer
 
If intensity < 1 Then
intensity = 1
ElseIf intensity > 255 Then
intensity = 255
End If
 
If adjustment = ColorAdjustmentType.Lighten Then
r = IncrementValue(c.R, intensity)
g = IncrementValue(c.G, intensity)
b = IncrementValue(c.B, intensity)
Else
r = DecrementValue(c.R, intensity)
g = DecrementValue(c.G, intensity)
b = DecrementValue(c.B, intensity)
End If
 
If keepAlpha Then
Return Color.FromArgb(c.A, r, g, b)
Else
Return Color.FromArgb(255, r, g, b)
End If
 
End Function
 
Private Function IncrementValue(ByVal initialValue As Integer, ByVal intensity As Integer, Optional ByVal maximum As Integer = 255)
If initialValue + intensity < maximum Then
Return initialValue + intensity
Else
Return maximum
End If
End Function
 
Private Function DecrementValue(ByVal initialValue As Integer, ByVal intensity As Integer, Optional ByVal minimum As Integer = 0)
If initialValue - intensity > minimum Then
Return initialValue - intensity
Else
Return minimum
End If
End Function
 
Public Function CodeToImage(ByVal Code As String) As Image
Return Image.FromStream(New System.IO.MemoryStream(Convert.FromBase64String(Code)))
End Function
 
Public Function GrayScale(ByVal rgb As Integer) As Color
Return Color.FromArgb(rgb, rgb, rgb)
End Function
 
Public Sub DrawCenteredString(g As Graphics, text As String, font As Font, brush As Brush, rect As Rectangle, Optional shadow As Boolean = False, Optional yOffset As Integer = 0)
 
Dim textSize As SizeF = g.MeasureString(text, font)
Dim textX As Integer = rect.X + (rect.Width / 2) - (textSize.Width / 2)
Dim textY As Integer = rect.Y + (rect.Height / 2) - (textSize.Height / 2) + yOffset
 
If shadow Then g.DrawString(text, font, Brushes.Black, textX + 1, textY + 1)
g.DrawString(text, font, brush, textX, textY + 1)
 
End Sub
 
Public Function ResizeRect(rect As Rectangle, difference As Integer) As Rectangle
Return New Rectangle(rect.X + difference, rect.Y + difference, rect.Width - (difference * 2), rect.Height - (difference * 2))
End Function
 
End Class
 
Class MorphicSkin
Inherits ContainerControl
 
Private g As Graphics
Private dh As New DrawingHelper
 
Private moveHeight As Integer = 40
Private formCanMove As Boolean
Private mouseX, mouseY As Integer
Private minRect, exitRect As Rectangle
Private overMin, overExit As Boolean
 
Private _headerFont As Font
Private _iconImage As Image
 
Public Property HeaderFont As Font
Get
Return _headerFont
End Get
Set(value As Font)
_headerFont = value
Invalidate()
End Set
End Property
 
Public Property IconImage As Image
Get
Return _iconImage
End Get
Set(value As Image)
_iconImage = value
Invalidate()
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Font = New Font("Arial", 9)
BackColor = BackgroundColor
HeaderFont = New Font("Arial", 12, FontStyle.Bold)
End Sub
 
Protected Overrides Sub CreateHandle()
MyBase.CreateHandle()
FindForm().TransparencyKey = Color.Fuchsia
FindForm().FormBorderStyle = FormBorderStyle.None
Dock = DockStyle.Fill
BackColor = BackgroundColor
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.Clear(FindForm().TransparencyKey)
 
Dim boundsRect As New Rectangle(0, 0, Width - 1, Height - 1)
Dim boundsPath As GraphicsPath = dh.RoundRect(boundsRect, Rounding)
g.FillPath(New SolidBrush(BackgroundColor), boundsPath)
 
Dim headerRect As New Rectangle(0, 0, Width - 1, moveHeight)
Dim headerPath As GraphicsPath = dh.RoundRect(headerRect, Rounding, DrawingHelper.RoundingStyle.Top)
Dim headerBrush As New LinearGradientBrush(headerRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(headerBrush, headerPath)
headerBrush.Dispose()
 
If IconImage IsNot Nothing Then
Dim iconRect As New Rectangle(8, 8, moveHeight - 16, moveHeight - 16)
g.DrawImage(IconImage, iconRect)
End If
 
If Not overExit Then
g.DrawString("r", New Font("Marlett", 12, FontStyle.Bold), New SolidBrush(BorderColor), New Point(Width - 32, 13))
Else
g.DrawString("r", New Font("Marlett", 12, FontStyle.Bold), New SolidBrush(dh.AdjustColor(BorderColor, 120, DrawingHelper.ColorAdjustmentType.Lighten)), New Point(Width - 32, 13))
End If
 
If Not overMin Then
g.DrawString("0", New Font("Marlett", 14, FontStyle.Bold), New SolidBrush(BorderColor), New Point(Width - 54, 9))
Else
g.DrawString("0", New Font("Marlett", 14, FontStyle.Bold), New SolidBrush(dh.AdjustColor(BorderColor, 120, DrawingHelper.ColorAdjustmentType.Lighten)), New Point(Width - 54, 9))
End If
 
exitRect = New Rectangle(Width - 32, 9, 21, 21)
minRect = New Rectangle(Width - 54, 9, 21, 21)
 
dh.DrawCenteredString(g, Text, HeaderFont, New SolidBrush(TextColor), headerRect, False, 1)
 
Dim borderPen As New Pen(BorderColor)
g.DrawPath(borderPen, headerPath)
g.DrawPath(borderPen, boundsPath)
borderPen.Dispose()
 
End Sub
 
Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
MyBase.OnMouseMove(e)
If e.Y <= moveHeight Then
 
If minRect.Contains(e.Location) Then
overMin = True
Else
overMin = False
End If
 
If exitRect.Contains(e.Location) Then
overExit = True
Else
overExit = False
End If
 
If formCanMove = True Then FindForm.Location = MousePosition - New Point(mouseX, mouseY)
 
Invalidate()
 
End If
End Sub
 
Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
MyBase.OnMouseDown(e)
mouseX = e.X
mouseY = e.Y
If e.Y <= moveHeight AndAlso Not overExit AndAlso Not overMin Then formCanMove = True
End Sub
 
Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
MyBase.OnMouseUp(e)
formCanMove = False
End Sub
 
Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
MyBase.OnMouseClick(e)
 
If overMin Then
FindForm().WindowState = FormWindowState.Minimized
overMin = False
Invalidate()
End If
 
If overExit Then FindForm().Close()
 
End Sub
 
End Class
 
Class MorphicButton
Inherits Control
 
Private g As Graphics
Private dh As New DrawingHelper
 
Enum MouseState
None
Over
Down
End Enum
 
Private state As MouseState = MouseState.None
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Cursor = Cursors.Hand
Font = New Font(FontFamily, 10)
Size = New Size(100, 40)
End Sub
 
Protected Overrides Sub CreateHandle()
Font = New Font(FontFamily, Font.Size)
MyBase.CreateHandle()
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.Clear(Parent.BackColor)
g.SmoothingMode = SmoothingMode.HighQuality
 
Dim boundsRect As New Rectangle(0, 0, Width - 1, Height - 1)
Dim boundsPath As GraphicsPath = dh.RoundRect(boundsRect, Rounding)
 
Dim backBrush As New LinearGradientBrush(boundsRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(backBrush, boundsPath)
backBrush.Dispose()
 
Dim brushIntensity As Integer = 0
 
If state = MouseState.Over Then
brushIntensity = 20
ElseIf state = MouseState.Down Then
brushIntensity = 50
End If
 
Dim screenBrush As New SolidBrush(Color.FromArgb(brushIntensity, MainColor))
g.FillPath(screenBrush, boundsPath)
screenBrush.Dispose()
 
g.DrawPath(New Pen(BorderColor), boundsPath)
 
dh.DrawCenteredString(g, Text, Font, New SolidBrush(TextColor), boundsRect)
 
End Sub
 
Protected Overrides Sub OnMouseEnter(e As EventArgs)
state = MouseState.Over
Invalidate()
MyBase.OnMouseEnter(e)
End Sub
 
Protected Overrides Sub OnMouseLeave(e As EventArgs)
state = MouseState.None
Invalidate()
MyBase.OnMouseLeave(e)
End Sub
 
Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
state = MouseState.Down
Invalidate()
MyBase.OnMouseDown(e)
End Sub
 
Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
state = MouseState.Over
Invalidate()
MyBase.OnMouseUp(e)
End Sub
 
Protected Overrides Sub OnTextChanged(e As EventArgs)
Invalidate()
MyBase.OnTextChanged(e)
End Sub
 
End Class
 
Class MorphicSeparator
Inherits Control
 
Private g As Graphics
 
Private _lineColor As Color
Private _intensity As Integer = 40
 
Public Property LineColor As Color
Get
Return _lineColor
End Get
Set(value As Color)
_lineColor = value
Invalidate()
End Set
End Property
 
Public Property Intensity As Integer
Get
Return _intensity
End Get
Set(value As Integer)
_intensity = value
Invalidate()
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Size = New Size(260, 9)
LineColor = Color.White
End Sub
 
Protected Overrides Sub CreateHandle()
Font = New Font(FontFamily, Font.Size)
MyBase.CreateHandle()
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.SmoothingMode = SmoothingMode.HighQuality
g.Clear(Parent.BackColor)
 
Dim p1 As New Point(0, (Height - 1) / 2)
Dim p2 As New Point(Width - 1, (Height - 1) / 2)
 
Dim lineBlend As New ColorBlend(3)
lineBlend.Colors = {Color.Transparent, Color.FromArgb(_intensity, _lineColor), Color.Transparent}
lineBlend.Positions = {0.0F, 0.5F, 1.0F}
 
Dim lineBrush As New LinearGradientBrush(p1, p2, Color.Transparent, Color.Transparent)
lineBrush.InterpolationColors = lineBlend
 
g.DrawLine(New Pen(lineBrush), p1, p2)
 
End Sub
 
End Class
 
<DefaultEvent("CheckedChanged")> Class MorphicCheckBox
Inherits Control
 
Event CheckedChanged(sender As Object)
 
Private g As Graphics
Private dh As New DrawingHelper
 
Private checkMark As Image = dh.CodeToImage("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAADESURBVDhPxZIhCgJRFEU/ImIcXMZgEDGKwWQwGlyDQcQdmA0yyRWYXIIrmGhyAWIQs0nkex7eAcOIz6IHTpg79/6ZgQl/IcaY4FiX38GwjwccKvLBwJzjCVuKfTCoYIZnTBX7YGCu8YodxX4YLdEYKfLDaPrcxpWiciikuMWZIst6eMM91hSXQ2GDBQNs4BHtgLZq76FUxxyNHRYHZqp8hnIT7Yl3W8IFE932weD1UyaK/TCy39TeYoFVxX5shF1d/oIQHijh1y3sO6VaAAAAAElFTkSuQmCC")
 
Private mouseOver As Boolean
Private checkRect As Rectangle
Private _checked As Boolean
 
Public Property Checked As Boolean
Get
Return _checked
End Get
Set(value As Boolean)
_checked = value
Invalidate()
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Size = New Size(150, 24)
Font = New Font(FontFamily, 9)
End Sub
 
Protected Overrides Sub CreateHandle()
Font = New Font(FontFamily, Font.Size)
MyBase.CreateHandle()
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.SmoothingMode = SmoothingMode.HighQuality
g.Clear(Parent.BackColor)
 
checkRect = New Rectangle(2, 2, Height - 5, Height - 5)
Dim checkPath As GraphicsPath = dh.RoundRect(checkRect, Rounding)
 
Dim backBrush As New LinearGradientBrush(checkRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(backBrush, checkPath)
backBrush.Dispose()
 
Dim brushIntensity As Integer = 0
 
If Checked Then
brushIntensity = 50
ElseIf mouseOver Then
brushIntensity = 20
End If
 
Dim screenBrush As New SolidBrush(Color.FromArgb(brushIntensity, MainColor))
g.FillPath(screenBrush, checkPath)
screenBrush.Dispose()
 
g.DrawPath(New Pen(BorderColor), checkPath)
 
If _checked Then g.DrawImage(checkMark, 7, 1)
 
Dim textSize As SizeF = g.MeasureString(Text, Font)
Dim textX As Integer = Height + 2
Dim textY As Integer = (Height / 2) - (textSize.Height / 2)
g.DrawString(Text, Font, New SolidBrush(TextColor), textX, textY)
 
End Sub
 
Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
If checkRect.Contains(New Point(e.X, e.Y)) Then
Checked = Not Checked
RaiseEvent CheckedChanged(Me)
End If
MyBase.OnMouseDown(e)
End Sub
 
Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
mouseOver = checkRect.Contains(e.Location)
Invalidate()
MyBase.OnMouseMove(e)
End Sub
 
Protected Overrides Sub OnMouseLeave(e As EventArgs)
mouseOver = False
Invalidate()
MyBase.OnMouseLeave(e)
End Sub
 
Protected Overrides Sub OnTextChanged(e As EventArgs)
Invalidate()
MyBase.OnTextChanged(e)
End Sub
 
End Class
 
<DefaultEvent("CheckedChanged")> Class MorphicRadioButton
Inherits Control
 
Event CheckedChanged(sender As Object)
 
Private dh As New DrawingHelper
Private g As Graphics
 
Private checkRect As Rectangle
Private mouseOver As Boolean
 
Private _checked As Boolean
 
Public Property Checked As Boolean
Get
Return _checked
End Get
Set(value As Boolean)
_checked = value
Invalidate()
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Size = New Size(150, 24)
Font = New Font(FontFamily, 9)
End Sub
 
Protected Overrides Sub CreateHandle()
Font = New Font(FontFamily, Font.Size)
MyBase.CreateHandle()
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.SmoothingMode = SmoothingMode.HighQuality
g.Clear(Parent.BackColor)
 
checkRect = New Rectangle(2, 2, Height - 5, Height - 5)
 
Dim backBrush As New LinearGradientBrush(checkRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillEllipse(backBrush, checkRect)
backBrush.Dispose()
 
Dim brushIntensity As Integer = 0
 
If Checked Then
brushIntensity = 50
ElseIf mouseOver Then
brushIntensity = 20
End If
 
Dim screenBrush As New SolidBrush(Color.FromArgb(brushIntensity, MainColor))
g.FillEllipse(screenBrush, checkRect)
screenBrush.Dispose()
 
If _checked Then g.FillEllipse(New SolidBrush(TextColor), dh.ResizeRect(checkRect, 7))
 
g.DrawEllipse(New Pen(BorderColor), checkRect)
 
Dim textSize As SizeF = g.MeasureString(Text, Font)
Dim textX As Integer = Height + 2
Dim textY As Integer = (Height / 2) - (textSize.Height / 2)
g.DrawString(Text, Font, New SolidBrush(TextColor), textX, textY)
 
End Sub
 
Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
MyBase.OnMouseDown(e)
 
If checkRect.Contains(New Point(e.X, e.Y)) Then
If Not Checked Then
For Each c As Control In Parent.Controls
If TypeOf c Is MorphicRadioButton AndAlso c IsNot Me Then DirectCast(c, MorphicRadioButton).Checked = False
Next
Checked = True
RaiseEvent CheckedChanged(Me)
End If
End If
 
End Sub
 
Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
mouseOver = checkRect.Contains(e.Location)
Invalidate()
MyBase.OnMouseMove(e)
End Sub
 
Protected Overrides Sub OnMouseLeave(e As EventArgs)
mouseOver = False
Invalidate()
MyBase.OnMouseLeave(e)
End Sub
 
Protected Overrides Sub OnTextChanged(e As EventArgs)
Invalidate()
MyBase.OnTextChanged(e)
End Sub
 
End Class
 
<DefaultEvent("ValueChanged")> Class MorphicProgressBar
Inherits Control
 
Event ValueChanged(sender As Object)
 
Private dh As New DrawingHelper
Private g As Graphics
 
Private _value As Integer
Private _maximum As Integer
 
Public Property Value As Integer
Get
Return _value
End Get
Set(value As Integer)
If _value > _maximum Then
_value = Maximum
ElseIf _value < 0 Then
_value = 0
End If
If Not value = _value Then RaiseEvent ValueChanged(Me)
_value = value
Invalidate()
End Set
End Property
 
Public Property Maximum As Integer
Get
Return _maximum
End Get
Set(value As Integer)
If _value > value Then _value = value
_maximum = value
Invalidate()
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Size = New Size(280, 40)
Font = New Font(FontFamily, 10)
Maximum = 100
End Sub
 
Protected Overrides Sub CreateHandle()
Font = New Font(FontFamily, Font.Size)
MyBase.CreateHandle()
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.SmoothingMode = SmoothingMode.HighQuality
g.Clear(Parent.BackColor)
 
Dim percent As Single = (_value / _maximum)
 
Dim boundsRect As New Rectangle(0, 0, Width - 1, Height - 1)
Dim boundsPath As GraphicsPath = dh.RoundRect(boundsRect, Rounding)
 
Dim backBrush As New LinearGradientBrush(boundsRect, dh.AdjustColor(SecondaryBackColor, 5, DrawingHelper.ColorAdjustmentType.Darken), SecondaryBackColor, 90.0F)
g.FillPath(backBrush, boundsPath)
backBrush.Dispose()
 
If _value > 0 Then
 
Dim barRect As New Rectangle(0, 0, CInt((Width / _maximum) * _value) - 1, Height - 1)
 
If barRect.Width > (Rounding * 2) Then
 
Dim barPath As GraphicsPath = dh.RoundRect(barRect, Rounding)
Dim barBrush As New LinearGradientBrush(barRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(barBrush, barPath)
barBrush.Dispose()
 
Dim screenBrush As New SolidBrush(Color.FromArgb(50 * percent, MainColor))
g.FillPath(screenBrush, barPath)
screenBrush.Dispose()
 
g.DrawPath(New Pen(BorderColor), barPath)
 
End If
 
End If
 
Dim percentStr As String = (percent * 100).ToString() & "%"
dh.DrawCenteredString(g, percentStr, Font, New SolidBrush(TextColor), boundsRect, False)
 
g.DrawPath(New Pen(BorderColor), boundsPath)
 
End Sub
 
End Class
 
Class MorphicTabControl
Inherits TabControl
 
Private g As Graphics
Private dh As New DrawingHelper
 
Private tabRects As New List(Of Rectangle)
Private overTab As Integer = -1
 
Private _tabFont As Font
 
Public Property TabFont As Font
Get
Return _tabFont
End Get
Set(value As Font)
_tabFont = value
Invalidate()
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Size = New Size(500, 300)
TabFont = New Font(FontFamily, 10)
End Sub
 
Protected Overrides Sub CreateHandle()
MyBase.CreateHandle()
 
DrawMode = TabDrawMode.OwnerDrawFixed
SizeMode = TabSizeMode.Fixed
Alignment = TabAlignment.Left
ItemSize = New Size(60, 180)
 
TabFont = New Font(FontFamily, TabFont.Size)
 
End Sub
 
Protected Overrides Sub OnPaint(e As PaintEventArgs)
 
g = e.Graphics
g.Clear(BackgroundColor)
g.SmoothingMode = SmoothingMode.HighQuality
 
tabRects.Clear()
 
For i As Integer = 0 To TabCount - 1
 
Dim baseRect As Rectangle = GetTabRect(i)
Dim tabRect As New Rectangle(baseRect.X + 4, baseRect.Y + 4, baseRect.Width - 8, baseRect.Height - 8)
tabRects.Add(tabRect)
Dim tabPath As GraphicsPath = dh.RoundRect(tabRect, Rounding)
 
Dim backBrush As New LinearGradientBrush(tabRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(backBrush, tabPath)
backBrush.Dispose()
 
Dim brushIntensity As Integer = 0
 
If i = SelectedIndex Then
brushIntensity = 50
ElseIf i = overTab Then
brushIntensity = 20
End If
 
Dim screenBrush As New SolidBrush(Color.FromArgb(brushIntensity, MainColor))
g.FillPath(screenBrush, tabPath)
screenBrush.Dispose()
 
g.DrawPath(New Pen(BorderColor), tabPath)
 
Dim textY As Integer = tabRect.Y + (tabRect.Height / 2) - (g.MeasureString(TabPages(i).Text, TabFont).Height / 2)
g.DrawString(TabPages(i).Text, TabFont, New SolidBrush(TextColor), 16, textY)
 
Try : TabPages(i).BackColor = BackgroundColor : Catch : End Try
 
Next
 
End Sub
 
Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
overTab = GetMouseOverTabIndex(e.Location)
Invalidate()
MyBase.OnMouseMove(e)
End Sub
 
Protected Overrides Sub OnMouseLeave(e As EventArgs)
overTab = -1
Invalidate()
MyBase.OnMouseLeave(e)
End Sub
 
Private Function GetMouseOverTabIndex(mouseLocation As Point) As Integer
Try
For i As Integer = 0 To TabCount - 1
If tabRects(i).Contains(mouseLocation) Then Return i
Next
Catch
Return -1
End Try
Return -1
End Function
 
End Class
 
<DefaultEvent("TextChanged")> Class MorphicTextBox
Inherits Control
 
Private dh As New DrawingHelper
Private g As Graphics
 
Private _maxLength As Integer = 32767
Public Property MaxLength() As Integer
Get
Return _maxLength
End Get
Set(ByVal value As Integer)
_maxLength = value
If Base IsNot Nothing Then
Base.MaxLength = value
End If
End Set
End Property
 
Private _readOnly As Boolean
Public Property [ReadOnly]() As Boolean
Get
Return _readOnly
End Get
Set(ByVal value As Boolean)
_readOnly = value
If Base IsNot Nothing Then
Base.ReadOnly = value
End If
End Set
End Property
 
Private _useSystemPasswordChar As Boolean
Public Property UseSystemPasswordChar() As Boolean
Get
Return _useSystemPasswordChar
End Get
Set(ByVal value As Boolean)
_useSystemPasswordChar = value
If Base IsNot Nothing Then
Base.UseSystemPasswordChar = value
End If
End Set
End Property
 
Private _multiline As Boolean
Property Multiline() As Boolean
Get
Return _multiline
End Get
Set(ByVal value As Boolean)
_multiline = value
If Base IsNot Nothing Then
Base.Multiline = value
 
If value Then
Base.Height = Height - 11
Else
Height = Base.Height + 11
End If
End If
End Set
End Property
 
Public Overrides Property Text() As String
Get
Return MyBase.Text
End Get
Set(ByVal value As String)
MyBase.Text = value
If Base IsNot Nothing Then
Base.Text = value
End If
End Set
End Property
 
Public Overrides Property Font() As Font
Get
Return MyBase.Font
End Get
Set(ByVal value As Font)
MyBase.Font = value
If Base IsNot Nothing Then
Base.Font = value
Base.Location = New Point(3, 5)
Base.Width = Width - 6
End If
End Set
End Property
 
Protected Overrides Sub OnCreateControl()
MyBase.OnCreateControl()
If Not Controls.Contains(Base) Then
Controls.Add(Base)
End If
End Sub
 
Private Base As TextBox
 
Sub New()
 
Font = New Font(FontFamily, 9)
Cursor = Cursors.IBeam
 
Base = New TextBox
Base.Font = Font
Base.Text = Text
Base.ForeColor = TextColor
Base.MaxLength = _maxLength
Base.Multiline = _multiline
Base.ReadOnly = _readOnly
Base.UseSystemPasswordChar = _useSystemPasswordChar
Base.BorderStyle = BorderStyle.None
Base.Location = New Point(5, 5)
Base.Width = Width - 10
 
If _multiline Then
Base.Height = Height - 11
Else
Height = Base.Height + 11
End If
 
AddHandler Base.TextChanged, AddressOf OnBaseTextChanged
AddHandler Base.KeyDown, AddressOf OnBaseKeyDown
 
End Sub
 
Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
MyBase.OnPaint(e)
 
g = e.Graphics
 
g.SmoothingMode = SmoothingMode.HighQuality
g.Clear(Parent.BackColor)
 
Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
Dim mainPath As GraphicsPath = dh.RoundRect(mainRect, Rounding)
g.FillPath(New SolidBrush(SecondaryBackColor), mainPath)
g.DrawPath(New Pen(BorderColor), mainPath)
 
Base.BackColor = SecondaryBackColor
 
End Sub
 
Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
Text = Base.Text
End Sub
 
Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
If e.Control AndAlso e.KeyCode = Keys.A Then
Base.SelectAll()
e.SuppressKeyPress = True
End If
End Sub
 
Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
<Category("Options")> _
Property TextAlign() As HorizontalAlignment
Get
Return _TextAlign
End Get
Set(ByVal value As HorizontalAlignment)
_TextAlign = value
If Base IsNot Nothing Then
Base.TextAlign = value
End If
End Set
End Property
 
Protected Overrides Sub OnResize(ByVal e As EventArgs)
Base.Location = New Point(6, 6)
 
Base.Width = Width - 10
Base.Height = Height - 11
 
If Not _multiline Then Size = New Size(Width, Base.Height + 12)
 
MyBase.OnResize(e)
End Sub
 
Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
MyBase.OnMouseDown(e)
Base.SelectionStart = Base.TextLength
Base.Focus()
End Sub
 
End Class
 
<DefaultEvent("Scroll")> Class MorphicTrackBar
Inherits Control
 
Event Scroll(ByVal sender As Object)
 
Private dh As New DrawingHelper
Private g As Graphics
 
Private trackX As Integer
Private trackWidth As Integer
Private trackRect As Rectangle
Private trackDown, overTrack As Boolean
Private _minimum, _maximum As Integer
Private _value As Integer
 
Property Minimum() As Integer
Get
Return _minimum
End Get
Set(ByVal value As Integer)
If value < 0 Then
Throw New Exception("Property value is not valid.")
End If
 
_minimum = value
If value > _value Then _value = value
If value > _maximum Then _maximum = value
Invalidate()
End Set
End Property
 
Property Maximum() As Integer
Get
Return _maximum
End Get
Set(ByVal value As Integer)
If value < 0 Then
Throw New Exception("Property value is not valid.")
End If
 
_maximum = value
If value < _value Then _value = value
If value < _minimum Then _minimum = value
Invalidate()
End Set
End Property
 
Property Value() As Integer
Get
Return _value
End Get
Set(ByVal value As Integer)
If value = _value Then Return
 
If value > _maximum OrElse value < _minimum Then
Throw New Exception("Property value is not valid.")
End If
 
_value = value
Invalidate()
 
RaiseEvent Scroll(Me)
End Set
End Property
 
Sub New()
SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
Size = New Size(200, 24)
Maximum = 10
End Sub
 
Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
 
g = e.Graphics
g.SmoothingMode = SmoothingMode.HighQuality
g.Clear(Parent.BackColor)
 
Dim slope As Integer = ((Height - 12) / 2)
trackWidth = Height - 14
 
Dim barRect As New Rectangle(0, 6, Width - 1, Height - 12)
Dim barPath As GraphicsPath = dh.RoundRect(barRect, slope)
Dim barBrush As New LinearGradientBrush(barRect, ControlBackColor, dh.AdjustColor(ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(barBrush, barPath)
barBrush.Dispose()
 
trackX = CInt((_value - _minimum) / (_maximum - _minimum) * (Width - trackWidth - 1))
 
If _value > 0 Then
Dim filledBarRect As New Rectangle(0, barRect.Y, trackX + (trackWidth / 2), barRect.Height)
Dim filledBarPath As GraphicsPath = dh.RoundRect(filledBarRect, slope)
Dim filledBarBrush As New SolidBrush(Color.FromArgb(50, MainColor))
g.FillPath(filledBarBrush, filledBarPath)
filledBarBrush.Dispose()
End If
 
g.DrawPath(New Pen(BorderColor), barPath)
 
trackRect = New Rectangle(trackX, 0, trackWidth, Height - 1)
Dim trackPath As GraphicsPath = dh.RoundRect(trackRect, Rounding)
Dim trackBrush As New LinearGradientBrush(trackRect, TextColor, dh.AdjustColor(TextColor, 50, DrawingHelper.ColorAdjustmentType.Darken), 90.0F)
g.FillPath(trackBrush, trackPath)
trackBrush.Dispose()
If overTrack Then g.FillPath(New SolidBrush(Color.FromArgb(35, MainColor)), trackPath)
g.DrawPath(New Pen(BorderColor), trackPath)
 
End Sub
 
Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
 
If e.Button = Windows.Forms.MouseButtons.Left Then
trackX = CInt((_value - _minimum) / (_maximum - _minimum) * (Width - trackWidth - 1))
trackRect = New Rectangle(trackX, 0, trackWidth, Height - 1)
trackDown = trackRect.Contains(e.Location)
End If
 
MyBase.OnMouseDown(e)
 
End Sub
 
Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
 
If trackDown AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
Value = _minimum + CInt((_maximum - _minimum) * (e.X / Width))
End If
 
If trackRect.Contains(e.Location) Or trackDown Then
overTrack = True
Else
overTrack = False
End If
 
Invalidate()
 
MyBase.OnMouseMove(e)
 
End Sub
 
Protected Overrides Sub OnMouseLeave(e As EventArgs)
 
overTrack = False
Invalidate()
 
MyBase.OnMouseLeave(e)
 
End Sub
 
Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
 
trackDown = False
overTrack = trackRect.Contains(e.Location)
Invalidate()
 
MyBase.OnMouseUp(e)
 
End Sub
 
End Class 