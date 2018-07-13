' This code is written by JelleWho
' 

Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel
Public Class Serial_Data



    'Put above this line your own strings

    '==================================================
    '==================================================
    '==========          Core V7.1           ==========
    '==================================================
    '==================================================
    Dim RecievedText As String
    Dim StartBit As String = "["
    Dim StopBit As String = "]"
    Dim MSGBoxName As String
    Dim MSG As String
    Dim myPort As Array
    Dim ArduinoAnswer As String
    Dim ButtonSelected As String
    Dim PrefUSB As String

    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data
    'Action - when closing application
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ButtonConnectDisconnect.Text = "Disconnect" Then
            Threading.Thread.Sleep(100) ' 1000 milliseconds = 1 second
            Disconnect()               ' disconnect arduino, Tried to fix the Frees here
            Threading.Thread.Sleep(100) ' 1000 milliseconds = 1 second
        End If
    End Sub
    'Action - (when) Starting up
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadUSB()
        MSGBoxName = "JelleWho"
        ButtonConnectDisconnect.Select()
        StartBit = StartChar.Text
        StopBit = StopChar.Text
        RunOnStartup()
    End Sub
    'Button - Reload USB
    Private Sub ComboBoxPoort_USBIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUSB.Click
        ReloadUSB()
    End Sub
    'Code   - Reload USB
    Sub ReloadUSB()
        PrefUSB = ComboBoxUSB.SelectedItem
        ComboBoxUSB.Items.Clear()
        On Error GoTo ErrHand
        myPort = IO.Ports.SerialPort.GetPortNames()
        ComboBoxUSB.Items.AddRange(myPort)
        ComboBoxUSB.SelectionStart.ToString()
        ComboBoxUSB.SelectedItem = PrefUSB
        If ComboBoxUSB.SelectedItem = "" Then   'Try autoselect an port
            ComboBoxUSB.SelectedItem = "COM10"
            ComboBoxUSB.SelectedItem = "COM9"
            ComboBoxUSB.SelectedItem = "COM8"
            ComboBoxUSB.SelectedItem = "COM7"
            ComboBoxUSB.SelectedItem = "COM6"
            ComboBoxUSB.SelectedItem = "COM5"
            ComboBoxUSB.SelectedItem = "COM4"
            ComboBoxUSB.SelectedItem = "COM3"
            ComboBoxUSB.SelectedItem = "COM2"
            ComboBoxUSB.SelectedItem = "COM1"
            ComboBoxUSB.SelectedItem = "COM0"
        End If
ErrHand:
    End Sub
    'Button - Send
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        SerialSend(TextBoxInput.Text)
    End Sub
    'Button - Enter Pressed (Send)
    Private Sub TextBoxInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SerialSend(TextBoxInput.Text)
        End If
    End Sub
    'Code   - Serial send
    Sub SerialSend(Text As String)
        TextBoxInput.Text = ""
        On Error GoTo ErrHand
        SerialPort1.Write(Text)
        RichTextBoxInput.Text &= Text + Chr(13)
        Exit Sub
ErrHand:
        MsgBox("You couldn't resist to remove the cable didn't you?", , MSGBoxName)
        Disconnect()
    End Sub
    'Button - Connect and Disconnect
    Private Sub ButtonButtonConnectDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConnectDisconnect.Click
        If ButtonConnectDisconnect.Text = "Connect" Then
            'Connect
            Connect()
        Else
            'Disconnect
            ButtonConnectDisconnect.Text = "Connect"
            ButtonConnectDisconnect.ForeColor = Color.Green
            Disconnect()
        End If
    End Sub
    'Code   - Connect
    Sub Connect()
        If ComboBoxUSB.Text <> "" Then
            On Error GoTo ErrHand
            ''SerialPort1.Close()
            SerialPort1.PortName = ComboBoxUSB.Text
            SerialPort1.BaudRate = 9600

            'Added the next lines
            SerialPort1.DataBits = 8
            SerialPort1.Parity = Parity.None
            SerialPort1.StopBits = StopBits.One
            SerialPort1.Handshake = Handshake.None
            SerialPort1.Encoding = System.Text.Encoding.Default
            SerialPort1.ReadTimeout = 1

            SerialPort1.Open()
            ComboBoxUSB.Enabled = False
            ButtonSend.Enabled = True
            TextBoxInput.Enabled = True
            ButtonConnectDisconnect.Text = "Disconnect"
            ButtonConnectDisconnect.ForeColor = Color.Red
            TextBoxInput.Select()
            RunOnConnect()
        Else
            MsgBox("I can not connect to nothing! what where you thinking..." + Chr(13) + "Please give me a COM poort to connect to, before letting me try to connect to it", , MSGBoxName)
            ReloadUSB()
        End If
        Exit Sub
ErrHand:
        MsgBox("The COM Port your trying to use, does not seems to work anymore" + Chr(13) + "Did you remove the cable again?", , MSGBoxName)
        ReloadUSB()
        ButtonConnectDisconnect.Select()
    End Sub
    'Code   - Disconnect
    Sub Disconnect()
        RunOnDisconnect()
        ComboBoxUSB.Enabled = True
        ButtonSend.Enabled = False
        TextBoxInput.Enabled = False
        ButtonConnectDisconnect.Text = "Connect"
        ButtonConnectDisconnect.ForeColor = Color.Green
        ButtonConnectDisconnect.Select()
        On Error GoTo ErrHand
        SerialPort1.Close()
        Exit Sub
ErrHand:
        ReloadUSB()
    End Sub
    'Action - Recieved serial data
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        System.Threading.Thread.Sleep(10)    'Minimal 4
        ReceivedText(SerialPort1.ReadExisting())
    End Sub
    'Code   - Recieved serial data
    Private Sub ReceivedText(ByVal [text] As String) 'input from ReadExisting
        If Me.RichTextBoxOutput.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            RecievedText = RecievedText + [text]
            Dim A = 10
            'Cut end send if we have a valid command "<StartBit> <some random data> <StopBit>"
            Do While InStr(1, RecievedText, StartBit) > 0 And InStr(2, RecievedText, StopBit) > 0 And A > 0
                A = A - 1
                Dim StartBitPos = InStr(1, RecievedText, StartBit)
                Dim StopBitPos = InStr(2, RecievedText, StopBit)
                If (StopBitPos > StartBitPos) Then
                    Dim TheText = Microsoft.VisualBasic.Left(RecievedText, StopBitPos - 1)
                    Dim TheText2 = Microsoft.VisualBasic.Right(TheText, StopBitPos - 1 - StartBitPos)
                    RecievedText = Microsoft.VisualBasic.Right(RecievedText, Microsoft.VisualBasic.Len(RecievedText) - StopBitPos)
                    RunOnDataRecieved(TheText2)
                    RichTextBoxOutputb.Text &= TheText2 + Chr(13)
                Else
                    RecievedText = Microsoft.VisualBasic.Right(RecievedText, Microsoft.VisualBasic.Len(RecievedText) - StopBitPos)
                End If
            Loop
            Me.RichTextBoxOutput.Text &= [text] 'append text to all past command list
            If AutoScroll.Checked = True Then
                RichTextBoxOutput.SelectionStart = RichTextBoxOutput.TextLength
                RichTextBoxOutput.ScrollToCaret()
                RichTextBoxInput.SelectionStart = RichTextBoxInput.TextLength
                RichTextBoxInput.ScrollToCaret()
                RichTextBoxOutputb.SelectionStart = RichTextBoxOutputb.TextLength
                RichTextBoxOutputb.ScrollToCaret()
            End If
        End If
        Exit Sub
    End Sub
    'Button - Clear output
    Private Sub RichTextBoxOutput_DoubleClick(sender As Object, e As EventArgs) Handles RichTextBoxOutput.DoubleClick
        RichTextBoxOutput.Text = ""
    End Sub
    'Button - Clear Outputb
    Private Sub RichTextBoxOutputb_DoubleClick(sender As Object, e As EventArgs) Handles RichTextBoxOutputb.DoubleClick
        RichTextBoxOutputb.Text = ""
    End Sub
    'Button - Clear inputbox
    Private Sub RichTextBoxInput_DoubleClick(sender As Object, e As EventArgs) Handles RichTextBoxInput.DoubleClick
        RichTextBoxInput.Text = ""
    End Sub
    'Button - Update startbit
    Private Sub StartChar_TextChanged(sender As Object, e As EventArgs) Handles StartChar.TextChanged
        StartBit = StartChar.Text
    End Sub
    'Button - Update Stoptbit
    Private Sub StopChar_TextChanged(sender As Object, e As EventArgs) Handles StopChar.TextChanged
        StopBit = StopChar.Text
    End Sub
    '==================================================
    '==================================================
    '==========          Your Codes          ==========
    '==================================================
    '==================================================
    'Action - (when) starting up
    Sub RunOnStartup()
        'Connect()
        'if you enable the above line (by removing the ' char) it will try to auto connect on startup
    End Sub
    'Action - (when) Connect
    Sub RunOnConnect()

    End Sub
    'Action - (when) Disconnect
    Sub RunOnDisconnect()

    End Sub
    'Action - (when) Serial data recieved
    Sub RunOnDataRecieved(Text As String)
        'the "Text" is the (valid) data recieved
    End Sub
    '==================================================
    '==================================================
    '==========          More Codes          ==========
    '==================================================
    '==================================================

End Class
