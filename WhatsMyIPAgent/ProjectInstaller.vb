Imports System.ComponentModel
Imports System.Configuration.Install

Public Class ProjectInstaller

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent
        Dim sSource As String
        Dim sLog As String
        Dim sMachine As String

        sSource = "WhatsMyIPAgent"
        sLog = "Application"
        sMachine = "."

        Dim mySourceData As EventSourceCreationData = New EventSourceCreationData("", "")
        Dim registerSource As Boolean = True

        mySourceData.Source = sSource
        mySourceData.LogName = sLog
        mySourceData.MachineName = sMachine

        If Not System.Diagnostics.EventLog.SourceExists(sSource, sMachine) Then
            Diagnostics.EventLog.CreateEventSource(mySourceData)
        End If

    End Sub

End Class
