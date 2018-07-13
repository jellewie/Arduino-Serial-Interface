<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Serial_Data
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Serial_Data))
        Me.Errors = New System.Windows.Forms.Label()
        Me.AA = New System.Windows.Forms.Label()
        Me.RichTextBoxInput = New System.Windows.Forms.RichTextBox()
        Me.RichTextBoxOutput = New System.Windows.Forms.RichTextBox()
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.ComboBoxUSB = New System.Windows.Forms.ComboBox()
        Me.TextBoxInput = New System.Windows.Forms.TextBox()
        Me.ButtonConnectDisconnect = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.AutoScroll = New System.Windows.Forms.CheckBox()
        Me.Errors2 = New System.Windows.Forms.Label()
        Me.RichTextBoxOutputb = New System.Windows.Forms.RichTextBox()
        Me.StartChar = New System.Windows.Forms.TextBox()
        Me.StopChar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Errors
        '
        resources.ApplyResources(Me.Errors, "Errors")
        Me.Errors.Cursor = System.Windows.Forms.Cursors.Default
        Me.Errors.ForeColor = System.Drawing.Color.Red
        Me.Errors.Name = "Errors"
        '
        'AA
        '
        resources.ApplyResources(Me.AA, "AA")
        Me.AA.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.AA.Name = "AA"
        Me.AA.UseWaitCursor = True
        '
        'RichTextBoxInput
        '
        resources.ApplyResources(Me.RichTextBoxInput, "RichTextBoxInput")
        Me.RichTextBoxInput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichTextBoxInput.Name = "RichTextBoxInput"
        Me.RichTextBoxInput.ReadOnly = True
        Me.RichTextBoxInput.TabStop = False
        '
        'RichTextBoxOutput
        '
        resources.ApplyResources(Me.RichTextBoxOutput, "RichTextBoxOutput")
        Me.RichTextBoxOutput.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichTextBoxOutput.Name = "RichTextBoxOutput"
        Me.RichTextBoxOutput.ReadOnly = True
        Me.RichTextBoxOutput.TabStop = False
        '
        'ButtonSend
        '
        Me.ButtonSend.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.ButtonSend, "ButtonSend")
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.UseVisualStyleBackColor = True
        '
        'ComboBoxUSB
        '
        Me.ComboBoxUSB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBoxUSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBoxUSB, "ComboBoxUSB")
        Me.ComboBoxUSB.FormattingEnabled = True
        Me.ComboBoxUSB.Name = "ComboBoxUSB"
        '
        'TextBoxInput
        '
        Me.TextBoxInput.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.TextBoxInput, "TextBoxInput")
        Me.TextBoxInput.Name = "TextBoxInput"
        '
        'ButtonConnectDisconnect
        '
        Me.ButtonConnectDisconnect.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.ButtonConnectDisconnect, "ButtonConnectDisconnect")
        Me.ButtonConnectDisconnect.ForeColor = System.Drawing.Color.Green
        Me.ButtonConnectDisconnect.Name = "ButtonConnectDisconnect"
        Me.ButtonConnectDisconnect.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM6"
        '
        'AutoScroll
        '
        resources.ApplyResources(Me.AutoScroll, "AutoScroll")
        Me.AutoScroll.Checked = True
        Me.AutoScroll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoScroll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AutoScroll.Name = "AutoScroll"
        Me.AutoScroll.UseMnemonic = False
        Me.AutoScroll.UseVisualStyleBackColor = True
        '
        'Errors2
        '
        resources.ApplyResources(Me.Errors2, "Errors2")
        Me.Errors2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Errors2.ForeColor = System.Drawing.Color.Red
        Me.Errors2.Name = "Errors2"
        '
        'RichTextBoxOutputb
        '
        resources.ApplyResources(Me.RichTextBoxOutputb, "RichTextBoxOutputb")
        Me.RichTextBoxOutputb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichTextBoxOutputb.Name = "RichTextBoxOutputb"
        Me.RichTextBoxOutputb.ReadOnly = True
        Me.RichTextBoxOutputb.TabStop = False
        '
        'StartChar
        '
        Me.StartChar.AcceptsReturn = True
        Me.StartChar.AcceptsTab = True
        Me.StartChar.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.StartChar, "StartChar")
        Me.StartChar.Name = "StartChar"
        '
        'StopChar
        '
        Me.StopChar.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.StopChar, "StopChar")
        Me.StopChar.Name = "StopChar"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Serial_Data
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StopChar)
        Me.Controls.Add(Me.StartChar)
        Me.Controls.Add(Me.RichTextBoxOutputb)
        Me.Controls.Add(Me.Errors2)
        Me.Controls.Add(Me.Errors)
        Me.Controls.Add(Me.AA)
        Me.Controls.Add(Me.RichTextBoxInput)
        Me.Controls.Add(Me.RichTextBoxOutput)
        Me.Controls.Add(Me.ButtonSend)
        Me.Controls.Add(Me.ComboBoxUSB)
        Me.Controls.Add(Me.TextBoxInput)
        Me.Controls.Add(Me.ButtonConnectDisconnect)
        Me.Controls.Add(Me.AutoScroll)
        Me.Name = "Serial_Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Errors As Label
    Friend WithEvents AA As Label
    Public WithEvents RichTextBoxInput As RichTextBox
    Public WithEvents RichTextBoxOutput As RichTextBox
    Friend WithEvents ButtonSend As Button
    Friend WithEvents ComboBoxUSB As ComboBox
    Friend WithEvents TextBoxInput As TextBox
    Friend WithEvents ButtonConnectDisconnect As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents AutoScroll As CheckBox
    Friend WithEvents Errors2 As Label
    Public WithEvents RichTextBoxOutputb As RichTextBox
    Friend WithEvents StartChar As TextBox
    Friend WithEvents StopChar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
#Disable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
#Enable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
End Class
