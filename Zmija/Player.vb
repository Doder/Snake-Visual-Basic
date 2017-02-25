Public Class Player
    Public x As Integer
    Public y As Integer
    Public moveDirection As String
    Private canChangeDirection As Boolean
    Dim Generator As System.Random = New System.Random()
    Public snakeParts As New LinkedList(Of SnakePart)

    Sub New()
        setRandomPosition()
        moveDirection = "stop"
        canChangeDirection = True
    End Sub


    Sub setRandomPosition()
        Dim randomX As Integer = generateRandomNumber(1, 14) * 30
        Dim randomY As Integer = generateRandomNumber(1, 14) * 30
        x = randomX
        y = randomY
    End Sub

    Sub Draw(ByVal G As Graphics)
        G.FillRectangle(Brushes.DarkGreen, Me.x, Me.y, 28, 28)
        For Each sp In snakeParts
            G.FillRectangle(Brushes.Green, sp.X, sp.Y, 28, 28)
        Next sp

    End Sub

    Public Function generateRandomNumber(ByVal a As Integer, ByVal b As Integer) As Integer
        Return Generator.Next(a, b + 1)
    End Function

    Sub Move()

        Select Case moveDirection
            Case "up"
                y = y - 30
            Case "down"
                y = y + 30
            Case "right"
                x = x + 30
            Case "left"
                x = x - 30

        End Select



        For Each sp In snakeParts
            Select Case sp.direction
                Case "up"
                    sp.Y = sp.Y - 30
                Case "down"
                    sp.Y = sp.Y + 30
                Case "right"
                    sp.X = sp.X + 30
                Case "left"
                    sp.X = sp.X - 30

            End Select
        Next sp


        canChangeDirection = True
        'change directions

        Dim cur As LinkedListNode(Of SnakePart) = snakeParts.Last
        If cur IsNot Nothing Then
            Do Until cur.Previous Is Nothing
                cur.Value.direction = cur.Previous.Value.direction
                cur = cur.Previous
            Loop
        End If

        Dim frst As LinkedListNode(Of SnakePart) = snakeParts.First
        If frst IsNot Nothing Then
            frst.Value.direction = moveDirection
        End If


    End Sub

    Sub changeDirection(ByVal d As String)

        If canChangeDirection = True Then
            canChangeDirection = False
            moveDirection = d

        End If

    End Sub

End Class
