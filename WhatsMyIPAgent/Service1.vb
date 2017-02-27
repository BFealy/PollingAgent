Public Class Service1

    Dim sSource As String
    Dim sLog As String
    Dim sMachine As String

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        Timer1.Start()
        LogAMessage("OnStart")
        'Testing here that the web request method works, then need to get it inside the timer loop... or figure out what to do about it 
        'outside of OnStart
        Dim Str As System.IO.Stream
        Dim srRead As System.IO.StreamReader
        Dim strRepsonseString As String
        Dim req As System.Net.WebRequest = System.Net.WebRequest.Create("https://app.strongarm.io/whatismyip/")
        Dim resp As System.Net.WebResponse = req.GetResponse
        Str = resp.GetResponseStream
        srRead = New System.IO.StreamReader(Str)
        ' read all the text 
        strRepsonseString = srRead.ReadToEnd
        LogAMessage(strRepsonseString)

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Timer1.Stop()
    End Sub

    Sub LogAMessage(ByVal sEvent)
        sSource = "WhatsMyIPAgent"
        sLog = "Application"
        sMachine = "."

        sEvent = sEvent.ToString
        Dim ELog As New EventLog(sLog, sMachine, sSource)
        ELog.WriteEntry(sEvent)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Str As System.IO.Stream
        Dim srRead As System.IO.StreamReader
        Dim strRepsonseString As String

        LogAMessage("Tick")
        '        Try
        ' make a Web request
        Dim req As System.Net.WebRequest = System.Net.WebRequest.Create("https://app.strongarm.io/whatismyip/")
            Dim resp As System.Net.WebResponse = req.GetResponse
            Str = resp.GetResponseStream
            srRead = New System.IO.StreamReader(Str)
            ' read all the text 
            strRepsonseString = srRead.ReadToEnd
        LogAMessage(strRepsonseString)
        '       Catch ex As Exception
        '      strRepsonseString = "Unable to download content"
        '     LogAMessage(strRepsonseString & "Exception: " & ex.ToString)
        '    Finally
        '   ' Close Stream and StreamReader when done
        '  srRead.Close()
        ' Str.Close()
        'End Try
    End Sub
End Class
