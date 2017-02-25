Public Class SnakePart
    Public direction As String = "stop"
    Public X As Integer
    Public Y As Integer
    Sub New(ByVal d As String, ByVal x As Integer, ByVal y As Integer)
        Me.direction = d
        Me.X = x
        Me.Y = y
    End Sub

End Class
