Public Class splashScreen
    Private Sub splashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private fadeInTimer As Timer
    Private fadeOutTimer As Timer
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Opacity = 0.9 ' Start with 0 opacity

        ' Start the fade-in timer
        fadeInTimer = New Timer()
        fadeInTimer.Interval = 500 ' Adjust the interval as needed
        AddHandler fadeInTimer.Tick, AddressOf FadeInTimer_Tick
        fadeInTimer.Start()
    End Sub

    Private Sub FadeInTimer_Tick(sender As Object, e As EventArgs)
        If Opacity >= 1 Then
            ' Stop the fade-in timer
            fadeInTimer.Stop()

            ' Start the fade-out timer
            fadeOutTimer = New Timer()
            fadeOutTimer.Interval = 50 ' Adjust the interval as needed
            AddHandler fadeOutTimer.Tick, AddressOf FadeOutTimer_Tick
            fadeOutTimer.Start()
        Else
            Opacity += 0.05 ' Adjust the opacity increment as needed
        End If
    End Sub

    Private Sub FadeOutTimer_Tick(sender As Object, e As EventArgs)
        If Opacity <= 0 Then
            ' Stop the fade-out timer and close the form
            fadeOutTimer.Stop()
            Close()
        Else
            Opacity -= 0.05 ' Adjust the opacity decrement as needed
        End If
    End Sub
End Class