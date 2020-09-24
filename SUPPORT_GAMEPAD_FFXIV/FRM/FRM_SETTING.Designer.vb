<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_SETTING
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnINIT_SETTINGS = New System.Windows.Forms.Button()
        Me.TBC_SETTING = New System.Windows.Forms.TabControl()
        Me.TBP_GAMEPAD = New System.Windows.Forms.TabPage()
        Me.GRP_GAMEPAD_ALLOCATION = New System.Windows.Forms.GroupBox()
        Me.PNL_GAMEPAD_ALLOCATION_04 = New System.Windows.Forms.Panel()
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02 = New System.Windows.Forms.ComboBox()
        Me.PNL_GAMEPAD_ALLOCATION_03 = New System.Windows.Forms.Panel()
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02 = New System.Windows.Forms.ComboBox()
        Me.PNL_GAMEPAD_ALLOCATION_02 = New System.Windows.Forms.Panel()
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02 = New System.Windows.Forms.ComboBox()
        Me.PNL_GAMEPAD_ALLOCATION_01 = New System.Windows.Forms.Panel()
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01 = New System.Windows.Forms.ComboBox()
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01 = New System.Windows.Forms.ComboBox()
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE = New System.Windows.Forms.Label()
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02 = New System.Windows.Forms.ComboBox()
        Me.GRP_GAMEPAD_SET = New System.Windows.Forms.GroupBox()
        Me.PNL_KIND_GAMEPAD = New System.Windows.Forms.Panel()
        Me.CMB_KIND_GAMEPAD = New System.Windows.Forms.ComboBox()
        Me.lblKIND_GAMEPAD_GUIDE = New System.Windows.Forms.Label()
        Me.TBP_TEST = New System.Windows.Forms.TabPage()
        Me.GRP_TEST = New System.Windows.Forms.GroupBox()
        Me.PNL_TEST_OPERATION_MOUSE = New System.Windows.Forms.Panel()
        Me.TXT_TEST_OPERATION_MOUSE_Y = New System.Windows.Forms.TextBox()
        Me.TXT_TEST_OPERATION_MOUSE_X = New System.Windows.Forms.TextBox()
        Me.LBL_TEST_OPERATION_MOUSE_NAME = New System.Windows.Forms.Label()
        Me.BTN_TEST_OPERATION_MOUSE = New System.Windows.Forms.Button()
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_TEST_SEND_STR = New System.Windows.Forms.Panel()
        Me.TXT_TEST_SEND_STR = New System.Windows.Forms.TextBox()
        Me.LBL_TEST_SEND_STR_NAME = New System.Windows.Forms.Label()
        Me.BTN_TEST_SEND_STR = New System.Windows.Forms.Button()
        Me.LBL_TEST_SEND_STR_GUIDE = New System.Windows.Forms.Label()
        Me.PNL_TEST_SEND_KEY = New System.Windows.Forms.Panel()
        Me.LBL_TEST_SEND_KEY_NAME = New System.Windows.Forms.Label()
        Me.BTN_TEST_SEND_KEY = New System.Windows.Forms.Button()
        Me.LBL_TEST_SEND_KEY_GUIDE = New System.Windows.Forms.Label()
        Me.TBC_SETTING.SuspendLayout()
        Me.TBP_GAMEPAD.SuspendLayout()
        Me.GRP_GAMEPAD_ALLOCATION.SuspendLayout()
        Me.PNL_GAMEPAD_ALLOCATION_04.SuspendLayout()
        Me.PNL_GAMEPAD_ALLOCATION_03.SuspendLayout()
        Me.PNL_GAMEPAD_ALLOCATION_02.SuspendLayout()
        Me.PNL_GAMEPAD_ALLOCATION_01.SuspendLayout()
        Me.GRP_GAMEPAD_SET.SuspendLayout()
        Me.PNL_KIND_GAMEPAD.SuspendLayout()
        Me.TBP_TEST.SuspendLayout()
        Me.GRP_TEST.SuspendLayout()
        Me.PNL_TEST_OPERATION_MOUSE.SuspendLayout()
        Me.PNL_TEST_SEND_STR.SuspendLayout()
        Me.PNL_TEST_SEND_KEY.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCANCEL
        '
        Me.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCANCEL.Location = New System.Drawing.Point(315, 360)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 25)
        Me.btnCANCEL.TabIndex = 9
        Me.btnCANCEL.Text = "キャンセル"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(230, 360)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 25)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnINIT_SETTINGS
        '
        Me.btnINIT_SETTINGS.Location = New System.Drawing.Point(400, 360)
        Me.btnINIT_SETTINGS.Name = "btnINIT_SETTINGS"
        Me.btnINIT_SETTINGS.Size = New System.Drawing.Size(80, 25)
        Me.btnINIT_SETTINGS.TabIndex = 7
        Me.btnINIT_SETTINGS.Text = "全て初期化"
        Me.btnINIT_SETTINGS.UseVisualStyleBackColor = True
        '
        'TBC_SETTING
        '
        Me.TBC_SETTING.Controls.Add(Me.TBP_GAMEPAD)
        Me.TBC_SETTING.Controls.Add(Me.TBP_TEST)
        Me.TBC_SETTING.Location = New System.Drawing.Point(5, 5)
        Me.TBC_SETTING.Name = "TBC_SETTING"
        Me.TBC_SETTING.SelectedIndex = 0
        Me.TBC_SETTING.Size = New System.Drawing.Size(480, 350)
        Me.TBC_SETTING.TabIndex = 10
        '
        'TBP_GAMEPAD
        '
        Me.TBP_GAMEPAD.Controls.Add(Me.GRP_GAMEPAD_ALLOCATION)
        Me.TBP_GAMEPAD.Controls.Add(Me.GRP_GAMEPAD_SET)
        Me.TBP_GAMEPAD.Location = New System.Drawing.Point(4, 27)
        Me.TBP_GAMEPAD.Name = "TBP_GAMEPAD"
        Me.TBP_GAMEPAD.Padding = New System.Windows.Forms.Padding(3)
        Me.TBP_GAMEPAD.Size = New System.Drawing.Size(472, 319)
        Me.TBP_GAMEPAD.TabIndex = 0
        Me.TBP_GAMEPAD.Text = "ゲームパッド"
        Me.TBP_GAMEPAD.UseVisualStyleBackColor = True
        '
        'GRP_GAMEPAD_ALLOCATION
        '
        Me.GRP_GAMEPAD_ALLOCATION.Controls.Add(Me.PNL_GAMEPAD_ALLOCATION_04)
        Me.GRP_GAMEPAD_ALLOCATION.Controls.Add(Me.PNL_GAMEPAD_ALLOCATION_03)
        Me.GRP_GAMEPAD_ALLOCATION.Controls.Add(Me.PNL_GAMEPAD_ALLOCATION_02)
        Me.GRP_GAMEPAD_ALLOCATION.Controls.Add(Me.PNL_GAMEPAD_ALLOCATION_01)
        Me.GRP_GAMEPAD_ALLOCATION.Location = New System.Drawing.Point(5, 70)
        Me.GRP_GAMEPAD_ALLOCATION.Name = "GRP_GAMEPAD_ALLOCATION"
        Me.GRP_GAMEPAD_ALLOCATION.Size = New System.Drawing.Size(460, 240)
        Me.GRP_GAMEPAD_ALLOCATION.TabIndex = 1
        Me.GRP_GAMEPAD_ALLOCATION.TabStop = False
        Me.GRP_GAMEPAD_ALLOCATION.Text = "割り当て"
        '
        'PNL_GAMEPAD_ALLOCATION_04
        '
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03)
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_04_ARROW)
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02)
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01)
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01)
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE)
        Me.PNL_GAMEPAD_ALLOCATION_04.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02)
        Me.PNL_GAMEPAD_ALLOCATION_04.Location = New System.Drawing.Point(5, 125)
        Me.PNL_GAMEPAD_ALLOCATION_04.Name = "PNL_GAMEPAD_ALLOCATION_04"
        Me.PNL_GAMEPAD_ALLOCATION_04.Size = New System.Drawing.Size(445, 30)
        Me.PNL_GAMEPAD_ALLOCATION_04.TabIndex = 7
        '
        'CMB_GAMEPAD_ALLOCATION_04_BUTTON_03
        '
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.Location = New System.Drawing.Point(190, 2)
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.Name = "CMB_GAMEPAD_ALLOCATION_04_BUTTON_03"
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_03.TabIndex = 18
        '
        'LBL_GAMEPAD_ALLOCATION_04_ARROW
        '
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW.Location = New System.Drawing.Point(265, 6)
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW.Name = "LBL_GAMEPAD_ALLOCATION_04_ARROW"
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW.Size = New System.Drawing.Size(20, 18)
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW.TabIndex = 17
        Me.LBL_GAMEPAD_ALLOCATION_04_ARROW.Text = "⇒"
        '
        'CMB_GAMEPAD_ALLOCATION_04_KEY_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.Items.AddRange(New Object() {"未指定", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "^"})
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.Location = New System.Drawing.Point(370, 2)
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.Name = "CMB_GAMEPAD_ALLOCATION_04_KEY_02"
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_02.TabIndex = 16
        '
        'CMB_GAMEPAD_ALLOCATION_04_KEY_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.Location = New System.Drawing.Point(290, 2)
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.Name = "CMB_GAMEPAD_ALLOCATION_04_KEY_01"
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_04_KEY_01.TabIndex = 15
        '
        'CMB_GAMEPAD_ALLOCATION_04_BUTTON_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.Location = New System.Drawing.Point(30, 2)
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.Name = "CMB_GAMEPAD_ALLOCATION_04_BUTTON_01"
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_01.TabIndex = 14
        '
        'LBL_GAMEPAD_ALLOCATION_04_GUIDE
        '
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE.Name = "LBL_GAMEPAD_ALLOCATION_04_GUIDE"
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE.Size = New System.Drawing.Size(22, 18)
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE.TabIndex = 13
        Me.LBL_GAMEPAD_ALLOCATION_04_GUIDE.Text = "04"
        '
        'CMB_GAMEPAD_ALLOCATION_04_BUTTON_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.Location = New System.Drawing.Point(110, 2)
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.Name = "CMB_GAMEPAD_ALLOCATION_04_BUTTON_02"
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_04_BUTTON_02.TabIndex = 10
        '
        'PNL_GAMEPAD_ALLOCATION_03
        '
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03)
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_03_ARROW)
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02)
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01)
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01)
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE)
        Me.PNL_GAMEPAD_ALLOCATION_03.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02)
        Me.PNL_GAMEPAD_ALLOCATION_03.Location = New System.Drawing.Point(5, 90)
        Me.PNL_GAMEPAD_ALLOCATION_03.Name = "PNL_GAMEPAD_ALLOCATION_03"
        Me.PNL_GAMEPAD_ALLOCATION_03.Size = New System.Drawing.Size(445, 30)
        Me.PNL_GAMEPAD_ALLOCATION_03.TabIndex = 6
        '
        'CMB_GAMEPAD_ALLOCATION_03_BUTTON_03
        '
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.Location = New System.Drawing.Point(190, 2)
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.Name = "CMB_GAMEPAD_ALLOCATION_03_BUTTON_03"
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_03.TabIndex = 18
        '
        'LBL_GAMEPAD_ALLOCATION_03_ARROW
        '
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW.Location = New System.Drawing.Point(265, 6)
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW.Name = "LBL_GAMEPAD_ALLOCATION_03_ARROW"
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW.Size = New System.Drawing.Size(20, 18)
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW.TabIndex = 17
        Me.LBL_GAMEPAD_ALLOCATION_03_ARROW.Text = "⇒"
        '
        'CMB_GAMEPAD_ALLOCATION_03_KEY_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.Items.AddRange(New Object() {"未指定", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "^"})
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.Location = New System.Drawing.Point(370, 2)
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.Name = "CMB_GAMEPAD_ALLOCATION_03_KEY_02"
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_02.TabIndex = 16
        '
        'CMB_GAMEPAD_ALLOCATION_03_KEY_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.Location = New System.Drawing.Point(290, 2)
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.Name = "CMB_GAMEPAD_ALLOCATION_03_KEY_01"
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_03_KEY_01.TabIndex = 15
        '
        'CMB_GAMEPAD_ALLOCATION_03_BUTTON_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.Location = New System.Drawing.Point(30, 2)
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.Name = "CMB_GAMEPAD_ALLOCATION_03_BUTTON_01"
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_01.TabIndex = 14
        '
        'LBL_GAMEPAD_ALLOCATION_03_GUIDE
        '
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE.Name = "LBL_GAMEPAD_ALLOCATION_03_GUIDE"
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE.Size = New System.Drawing.Size(22, 18)
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE.TabIndex = 13
        Me.LBL_GAMEPAD_ALLOCATION_03_GUIDE.Text = "03"
        '
        'CMB_GAMEPAD_ALLOCATION_03_BUTTON_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.Location = New System.Drawing.Point(110, 2)
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.Name = "CMB_GAMEPAD_ALLOCATION_03_BUTTON_02"
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_03_BUTTON_02.TabIndex = 10
        '
        'PNL_GAMEPAD_ALLOCATION_02
        '
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03)
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_02_ARROW)
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02)
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01)
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01)
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE)
        Me.PNL_GAMEPAD_ALLOCATION_02.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02)
        Me.PNL_GAMEPAD_ALLOCATION_02.Location = New System.Drawing.Point(5, 55)
        Me.PNL_GAMEPAD_ALLOCATION_02.Name = "PNL_GAMEPAD_ALLOCATION_02"
        Me.PNL_GAMEPAD_ALLOCATION_02.Size = New System.Drawing.Size(445, 30)
        Me.PNL_GAMEPAD_ALLOCATION_02.TabIndex = 5
        '
        'CMB_GAMEPAD_ALLOCATION_02_BUTTON_03
        '
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.Location = New System.Drawing.Point(190, 2)
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.Name = "CMB_GAMEPAD_ALLOCATION_02_BUTTON_03"
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_03.TabIndex = 18
        '
        'LBL_GAMEPAD_ALLOCATION_02_ARROW
        '
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW.Location = New System.Drawing.Point(265, 6)
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW.Name = "LBL_GAMEPAD_ALLOCATION_02_ARROW"
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW.Size = New System.Drawing.Size(20, 18)
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW.TabIndex = 17
        Me.LBL_GAMEPAD_ALLOCATION_02_ARROW.Text = "⇒"
        '
        'CMB_GAMEPAD_ALLOCATION_02_KEY_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.Items.AddRange(New Object() {"未指定", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "^"})
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.Location = New System.Drawing.Point(370, 2)
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.Name = "CMB_GAMEPAD_ALLOCATION_02_KEY_02"
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_02.TabIndex = 16
        '
        'CMB_GAMEPAD_ALLOCATION_02_KEY_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.Location = New System.Drawing.Point(290, 2)
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.Name = "CMB_GAMEPAD_ALLOCATION_02_KEY_01"
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_02_KEY_01.TabIndex = 15
        '
        'CMB_GAMEPAD_ALLOCATION_02_BUTTON_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.Location = New System.Drawing.Point(30, 2)
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.Name = "CMB_GAMEPAD_ALLOCATION_02_BUTTON_01"
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_01.TabIndex = 14
        '
        'LBL_GAMEPAD_ALLOCATION_02_GUIDE
        '
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE.Name = "LBL_GAMEPAD_ALLOCATION_02_GUIDE"
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE.Size = New System.Drawing.Size(22, 18)
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE.TabIndex = 13
        Me.LBL_GAMEPAD_ALLOCATION_02_GUIDE.Text = "02"
        '
        'CMB_GAMEPAD_ALLOCATION_02_BUTTON_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.Location = New System.Drawing.Point(110, 2)
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.Name = "CMB_GAMEPAD_ALLOCATION_02_BUTTON_02"
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_02_BUTTON_02.TabIndex = 10
        '
        'PNL_GAMEPAD_ALLOCATION_01
        '
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03)
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_01_ARROW)
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02)
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01)
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01)
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE)
        Me.PNL_GAMEPAD_ALLOCATION_01.Controls.Add(Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02)
        Me.PNL_GAMEPAD_ALLOCATION_01.Location = New System.Drawing.Point(5, 20)
        Me.PNL_GAMEPAD_ALLOCATION_01.Name = "PNL_GAMEPAD_ALLOCATION_01"
        Me.PNL_GAMEPAD_ALLOCATION_01.Size = New System.Drawing.Size(445, 30)
        Me.PNL_GAMEPAD_ALLOCATION_01.TabIndex = 3
        '
        'CMB_GAMEPAD_ALLOCATION_01_BUTTON_03
        '
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.Location = New System.Drawing.Point(190, 2)
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.Name = "CMB_GAMEPAD_ALLOCATION_01_BUTTON_03"
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_03.TabIndex = 18
        '
        'LBL_GAMEPAD_ALLOCATION_01_ARROW
        '
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW.Location = New System.Drawing.Point(265, 6)
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW.Name = "LBL_GAMEPAD_ALLOCATION_01_ARROW"
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW.Size = New System.Drawing.Size(20, 18)
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW.TabIndex = 17
        Me.LBL_GAMEPAD_ALLOCATION_01_ARROW.Text = "⇒"
        '
        'CMB_GAMEPAD_ALLOCATION_01_KEY_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.Items.AddRange(New Object() {"未指定", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "^"})
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.Location = New System.Drawing.Point(370, 2)
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.Name = "CMB_GAMEPAD_ALLOCATION_01_KEY_02"
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_02.TabIndex = 16
        '
        'CMB_GAMEPAD_ALLOCATION_01_KEY_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.Location = New System.Drawing.Point(290, 2)
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.Name = "CMB_GAMEPAD_ALLOCATION_01_KEY_01"
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_01_KEY_01.TabIndex = 15
        '
        'CMB_GAMEPAD_ALLOCATION_01_BUTTON_01
        '
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.Location = New System.Drawing.Point(30, 2)
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.Name = "CMB_GAMEPAD_ALLOCATION_01_BUTTON_01"
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_01.TabIndex = 14
        '
        'LBL_GAMEPAD_ALLOCATION_01_GUIDE
        '
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE.AutoSize = True
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE.Name = "LBL_GAMEPAD_ALLOCATION_01_GUIDE"
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE.Size = New System.Drawing.Size(22, 18)
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE.TabIndex = 13
        Me.LBL_GAMEPAD_ALLOCATION_01_GUIDE.Text = "01"
        '
        'CMB_GAMEPAD_ALLOCATION_01_BUTTON_02
        '
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.FormattingEnabled = True
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.Location = New System.Drawing.Point(110, 2)
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.Name = "CMB_GAMEPAD_ALLOCATION_01_BUTTON_02"
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.Size = New System.Drawing.Size(70, 26)
        Me.CMB_GAMEPAD_ALLOCATION_01_BUTTON_02.TabIndex = 10
        '
        'GRP_GAMEPAD_SET
        '
        Me.GRP_GAMEPAD_SET.Controls.Add(Me.PNL_KIND_GAMEPAD)
        Me.GRP_GAMEPAD_SET.Location = New System.Drawing.Point(6, 6)
        Me.GRP_GAMEPAD_SET.Name = "GRP_GAMEPAD_SET"
        Me.GRP_GAMEPAD_SET.Size = New System.Drawing.Size(460, 60)
        Me.GRP_GAMEPAD_SET.TabIndex = 0
        Me.GRP_GAMEPAD_SET.TabStop = False
        '
        'PNL_KIND_GAMEPAD
        '
        Me.PNL_KIND_GAMEPAD.Controls.Add(Me.CMB_KIND_GAMEPAD)
        Me.PNL_KIND_GAMEPAD.Controls.Add(Me.lblKIND_GAMEPAD_GUIDE)
        Me.PNL_KIND_GAMEPAD.Location = New System.Drawing.Point(5, 20)
        Me.PNL_KIND_GAMEPAD.Name = "PNL_KIND_GAMEPAD"
        Me.PNL_KIND_GAMEPAD.Size = New System.Drawing.Size(445, 30)
        Me.PNL_KIND_GAMEPAD.TabIndex = 1
        '
        'CMB_KIND_GAMEPAD
        '
        Me.CMB_KIND_GAMEPAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_KIND_GAMEPAD.DropDownWidth = 300
        Me.CMB_KIND_GAMEPAD.FormattingEnabled = True
        Me.CMB_KIND_GAMEPAD.Items.AddRange(New Object() {"使用しない", "標準コントローラー", "DUALSHOCK®4 USB Wireless Adaptor"})
        Me.CMB_KIND_GAMEPAD.Location = New System.Drawing.Point(40, 2)
        Me.CMB_KIND_GAMEPAD.Name = "CMB_KIND_GAMEPAD"
        Me.CMB_KIND_GAMEPAD.Size = New System.Drawing.Size(400, 26)
        Me.CMB_KIND_GAMEPAD.TabIndex = 9
        '
        'lblKIND_GAMEPAD_GUIDE
        '
        Me.lblKIND_GAMEPAD_GUIDE.AutoSize = True
        Me.lblKIND_GAMEPAD_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblKIND_GAMEPAD_GUIDE.Name = "lblKIND_GAMEPAD_GUIDE"
        Me.lblKIND_GAMEPAD_GUIDE.Size = New System.Drawing.Size(32, 18)
        Me.lblKIND_GAMEPAD_GUIDE.TabIndex = 8
        Me.lblKIND_GAMEPAD_GUIDE.Text = "種類"
        '
        'TBP_TEST
        '
        Me.TBP_TEST.Controls.Add(Me.GRP_TEST)
        Me.TBP_TEST.Location = New System.Drawing.Point(4, 27)
        Me.TBP_TEST.Name = "TBP_TEST"
        Me.TBP_TEST.Size = New System.Drawing.Size(472, 319)
        Me.TBP_TEST.TabIndex = 1
        Me.TBP_TEST.Text = "動作テスト"
        Me.TBP_TEST.UseVisualStyleBackColor = True
        '
        'GRP_TEST
        '
        Me.GRP_TEST.Controls.Add(Me.PNL_TEST_OPERATION_MOUSE)
        Me.GRP_TEST.Controls.Add(Me.PNL_TEST_SEND_STR)
        Me.GRP_TEST.Controls.Add(Me.PNL_TEST_SEND_KEY)
        Me.GRP_TEST.Location = New System.Drawing.Point(6, 6)
        Me.GRP_TEST.Name = "GRP_TEST"
        Me.GRP_TEST.Size = New System.Drawing.Size(460, 300)
        Me.GRP_TEST.TabIndex = 1
        Me.GRP_TEST.TabStop = False
        '
        'PNL_TEST_OPERATION_MOUSE
        '
        Me.PNL_TEST_OPERATION_MOUSE.Controls.Add(Me.TXT_TEST_OPERATION_MOUSE_Y)
        Me.PNL_TEST_OPERATION_MOUSE.Controls.Add(Me.TXT_TEST_OPERATION_MOUSE_X)
        Me.PNL_TEST_OPERATION_MOUSE.Controls.Add(Me.LBL_TEST_OPERATION_MOUSE_NAME)
        Me.PNL_TEST_OPERATION_MOUSE.Controls.Add(Me.BTN_TEST_OPERATION_MOUSE)
        Me.PNL_TEST_OPERATION_MOUSE.Controls.Add(Me.LBL_TEST_OPERATION_MOUSE_GUIDE)
        Me.PNL_TEST_OPERATION_MOUSE.Location = New System.Drawing.Point(5, 90)
        Me.PNL_TEST_OPERATION_MOUSE.Name = "PNL_TEST_OPERATION_MOUSE"
        Me.PNL_TEST_OPERATION_MOUSE.Size = New System.Drawing.Size(445, 30)
        Me.PNL_TEST_OPERATION_MOUSE.TabIndex = 3
        '
        'TXT_TEST_OPERATION_MOUSE_Y
        '
        Me.TXT_TEST_OPERATION_MOUSE_Y.Location = New System.Drawing.Point(150, 3)
        Me.TXT_TEST_OPERATION_MOUSE_Y.MaxLength = 100
        Me.TXT_TEST_OPERATION_MOUSE_Y.Name = "TXT_TEST_OPERATION_MOUSE_Y"
        Me.TXT_TEST_OPERATION_MOUSE_Y.Size = New System.Drawing.Size(40, 25)
        Me.TXT_TEST_OPERATION_MOUSE_Y.TabIndex = 2
        '
        'TXT_TEST_OPERATION_MOUSE_X
        '
        Me.TXT_TEST_OPERATION_MOUSE_X.Location = New System.Drawing.Point(110, 3)
        Me.TXT_TEST_OPERATION_MOUSE_X.MaxLength = 100
        Me.TXT_TEST_OPERATION_MOUSE_X.Name = "TXT_TEST_OPERATION_MOUSE_X"
        Me.TXT_TEST_OPERATION_MOUSE_X.Size = New System.Drawing.Size(40, 25)
        Me.TXT_TEST_OPERATION_MOUSE_X.TabIndex = 1
        '
        'LBL_TEST_OPERATION_MOUSE_NAME
        '
        Me.LBL_TEST_OPERATION_MOUSE_NAME.AutoSize = True
        Me.LBL_TEST_OPERATION_MOUSE_NAME.Location = New System.Drawing.Point(250, 6)
        Me.LBL_TEST_OPERATION_MOUSE_NAME.Name = "LBL_TEST_OPERATION_MOUSE_NAME"
        Me.LBL_TEST_OPERATION_MOUSE_NAME.Size = New System.Drawing.Size(188, 18)
        Me.LBL_TEST_OPERATION_MOUSE_NAME.TabIndex = 4
        Me.LBL_TEST_OPERATION_MOUSE_NAME.Text = "設定位置にマウスを移動します。"
        '
        'BTN_TEST_OPERATION_MOUSE
        '
        Me.BTN_TEST_OPERATION_MOUSE.Location = New System.Drawing.Point(190, 3)
        Me.BTN_TEST_OPERATION_MOUSE.Name = "BTN_TEST_OPERATION_MOUSE"
        Me.BTN_TEST_OPERATION_MOUSE.Size = New System.Drawing.Size(60, 25)
        Me.BTN_TEST_OPERATION_MOUSE.TabIndex = 3
        Me.BTN_TEST_OPERATION_MOUSE.Text = "移動"
        Me.BTN_TEST_OPERATION_MOUSE.UseVisualStyleBackColor = True
        '
        'LBL_TEST_OPERATION_MOUSE_GUIDE
        '
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE.AutoSize = True
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE.Name = "LBL_TEST_OPERATION_MOUSE_GUIDE"
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE.Size = New System.Drawing.Size(104, 18)
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE.TabIndex = 0
        Me.LBL_TEST_OPERATION_MOUSE_GUIDE.Text = "マウス操作テスト"
        '
        'PNL_TEST_SEND_STR
        '
        Me.PNL_TEST_SEND_STR.Controls.Add(Me.TXT_TEST_SEND_STR)
        Me.PNL_TEST_SEND_STR.Controls.Add(Me.LBL_TEST_SEND_STR_NAME)
        Me.PNL_TEST_SEND_STR.Controls.Add(Me.BTN_TEST_SEND_STR)
        Me.PNL_TEST_SEND_STR.Controls.Add(Me.LBL_TEST_SEND_STR_GUIDE)
        Me.PNL_TEST_SEND_STR.Location = New System.Drawing.Point(5, 55)
        Me.PNL_TEST_SEND_STR.Name = "PNL_TEST_SEND_STR"
        Me.PNL_TEST_SEND_STR.Size = New System.Drawing.Size(445, 30)
        Me.PNL_TEST_SEND_STR.TabIndex = 2
        '
        'TXT_TEST_SEND_STR
        '
        Me.TXT_TEST_SEND_STR.Location = New System.Drawing.Point(110, 3)
        Me.TXT_TEST_SEND_STR.MaxLength = 100
        Me.TXT_TEST_SEND_STR.Name = "TXT_TEST_SEND_STR"
        Me.TXT_TEST_SEND_STR.Size = New System.Drawing.Size(70, 25)
        Me.TXT_TEST_SEND_STR.TabIndex = 1
        '
        'LBL_TEST_SEND_STR_NAME
        '
        Me.LBL_TEST_SEND_STR_NAME.AutoSize = True
        Me.LBL_TEST_SEND_STR_NAME.Location = New System.Drawing.Point(240, 6)
        Me.LBL_TEST_SEND_STR_NAME.Name = "LBL_TEST_SEND_STR_NAME"
        Me.LBL_TEST_SEND_STR_NAME.Size = New System.Drawing.Size(200, 18)
        Me.LBL_TEST_SEND_STR_NAME.TabIndex = 3
        Me.LBL_TEST_SEND_STR_NAME.Text = "チャット欄に文字列を送信します。"
        '
        'BTN_TEST_SEND_STR
        '
        Me.BTN_TEST_SEND_STR.Location = New System.Drawing.Point(180, 3)
        Me.BTN_TEST_SEND_STR.Name = "BTN_TEST_SEND_STR"
        Me.BTN_TEST_SEND_STR.Size = New System.Drawing.Size(60, 25)
        Me.BTN_TEST_SEND_STR.TabIndex = 2
        Me.BTN_TEST_SEND_STR.Text = "送信"
        Me.BTN_TEST_SEND_STR.UseVisualStyleBackColor = True
        '
        'LBL_TEST_SEND_STR_GUIDE
        '
        Me.LBL_TEST_SEND_STR_GUIDE.AutoSize = True
        Me.LBL_TEST_SEND_STR_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_TEST_SEND_STR_GUIDE.Name = "LBL_TEST_SEND_STR_GUIDE"
        Me.LBL_TEST_SEND_STR_GUIDE.Size = New System.Drawing.Size(104, 18)
        Me.LBL_TEST_SEND_STR_GUIDE.TabIndex = 0
        Me.LBL_TEST_SEND_STR_GUIDE.Text = "文字列送信テスト"
        '
        'PNL_TEST_SEND_KEY
        '
        Me.PNL_TEST_SEND_KEY.Controls.Add(Me.LBL_TEST_SEND_KEY_NAME)
        Me.PNL_TEST_SEND_KEY.Controls.Add(Me.BTN_TEST_SEND_KEY)
        Me.PNL_TEST_SEND_KEY.Controls.Add(Me.LBL_TEST_SEND_KEY_GUIDE)
        Me.PNL_TEST_SEND_KEY.Location = New System.Drawing.Point(5, 20)
        Me.PNL_TEST_SEND_KEY.Name = "PNL_TEST_SEND_KEY"
        Me.PNL_TEST_SEND_KEY.Size = New System.Drawing.Size(445, 30)
        Me.PNL_TEST_SEND_KEY.TabIndex = 1
        '
        'LBL_TEST_SEND_KEY_NAME
        '
        Me.LBL_TEST_SEND_KEY_NAME.AutoSize = True
        Me.LBL_TEST_SEND_KEY_NAME.Location = New System.Drawing.Point(185, 6)
        Me.LBL_TEST_SEND_KEY_NAME.Name = "LBL_TEST_SEND_KEY_NAME"
        Me.LBL_TEST_SEND_KEY_NAME.Size = New System.Drawing.Size(147, 18)
        Me.LBL_TEST_SEND_KEY_NAME.TabIndex = 2
        Me.LBL_TEST_SEND_KEY_NAME.Text = "キー「1」を送信します。"
        '
        'BTN_TEST_SEND_KEY
        '
        Me.BTN_TEST_SEND_KEY.Location = New System.Drawing.Point(110, 3)
        Me.BTN_TEST_SEND_KEY.Name = "BTN_TEST_SEND_KEY"
        Me.BTN_TEST_SEND_KEY.Size = New System.Drawing.Size(60, 25)
        Me.BTN_TEST_SEND_KEY.TabIndex = 1
        Me.BTN_TEST_SEND_KEY.Text = "送信"
        Me.BTN_TEST_SEND_KEY.UseVisualStyleBackColor = True
        '
        'LBL_TEST_SEND_KEY_GUIDE
        '
        Me.LBL_TEST_SEND_KEY_GUIDE.AutoSize = True
        Me.LBL_TEST_SEND_KEY_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_TEST_SEND_KEY_GUIDE.Name = "LBL_TEST_SEND_KEY_GUIDE"
        Me.LBL_TEST_SEND_KEY_GUIDE.Size = New System.Drawing.Size(92, 18)
        Me.LBL_TEST_SEND_KEY_GUIDE.TabIndex = 0
        Me.LBL_TEST_SEND_KEY_GUIDE.Text = "キー送信テスト"
        '
        'FRM_SETTING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 391)
        Me.Controls.Add(Me.TBC_SETTING)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnINIT_SETTINGS)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FRM_SETTING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "設定"
        Me.TBC_SETTING.ResumeLayout(False)
        Me.TBP_GAMEPAD.ResumeLayout(False)
        Me.GRP_GAMEPAD_ALLOCATION.ResumeLayout(False)
        Me.PNL_GAMEPAD_ALLOCATION_04.ResumeLayout(False)
        Me.PNL_GAMEPAD_ALLOCATION_04.PerformLayout()
        Me.PNL_GAMEPAD_ALLOCATION_03.ResumeLayout(False)
        Me.PNL_GAMEPAD_ALLOCATION_03.PerformLayout()
        Me.PNL_GAMEPAD_ALLOCATION_02.ResumeLayout(False)
        Me.PNL_GAMEPAD_ALLOCATION_02.PerformLayout()
        Me.PNL_GAMEPAD_ALLOCATION_01.ResumeLayout(False)
        Me.PNL_GAMEPAD_ALLOCATION_01.PerformLayout()
        Me.GRP_GAMEPAD_SET.ResumeLayout(False)
        Me.PNL_KIND_GAMEPAD.ResumeLayout(False)
        Me.PNL_KIND_GAMEPAD.PerformLayout()
        Me.TBP_TEST.ResumeLayout(False)
        Me.GRP_TEST.ResumeLayout(False)
        Me.PNL_TEST_OPERATION_MOUSE.ResumeLayout(False)
        Me.PNL_TEST_OPERATION_MOUSE.PerformLayout()
        Me.PNL_TEST_SEND_STR.ResumeLayout(False)
        Me.PNL_TEST_SEND_STR.PerformLayout()
        Me.PNL_TEST_SEND_KEY.ResumeLayout(False)
        Me.PNL_TEST_SEND_KEY.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCANCEL As Forms.Button
    Friend WithEvents btnOK As Forms.Button
    Friend WithEvents btnINIT_SETTINGS As Forms.Button
    Friend WithEvents TBC_SETTING As Forms.TabControl
    Friend WithEvents TBP_GAMEPAD As Forms.TabPage
    Friend WithEvents GRP_GAMEPAD_SET As Forms.GroupBox
    Friend WithEvents PNL_KIND_GAMEPAD As Forms.Panel
    Friend WithEvents CMB_KIND_GAMEPAD As Forms.ComboBox
    Friend WithEvents lblKIND_GAMEPAD_GUIDE As Forms.Label
    Friend WithEvents GRP_GAMEPAD_ALLOCATION As Forms.GroupBox
    Friend WithEvents PNL_GAMEPAD_ALLOCATION_01 As Forms.Panel
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_01_BUTTON_01 As Forms.ComboBox
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_01_GUIDE As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_01_BUTTON_02 As Forms.ComboBox
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_01_ARROW As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_01_KEY_02 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_01_KEY_01 As Forms.ComboBox
    Friend WithEvents PNL_GAMEPAD_ALLOCATION_02 As Forms.Panel
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_02_ARROW As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_02_KEY_02 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_02_KEY_01 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_02_BUTTON_01 As Forms.ComboBox
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_02_GUIDE As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_02_BUTTON_02 As Forms.ComboBox
    Friend WithEvents PNL_GAMEPAD_ALLOCATION_03 As Forms.Panel
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_03_ARROW As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_03_KEY_02 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_03_KEY_01 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_03_BUTTON_01 As Forms.ComboBox
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_03_GUIDE As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_03_BUTTON_02 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_01_BUTTON_03 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_03_BUTTON_03 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_02_BUTTON_03 As Forms.ComboBox
    Friend WithEvents PNL_GAMEPAD_ALLOCATION_04 As Forms.Panel
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_04_BUTTON_03 As Forms.ComboBox
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_04_ARROW As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_04_KEY_02 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_04_KEY_01 As Forms.ComboBox
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_04_BUTTON_01 As Forms.ComboBox
    Friend WithEvents LBL_GAMEPAD_ALLOCATION_04_GUIDE As Forms.Label
    Friend WithEvents CMB_GAMEPAD_ALLOCATION_04_BUTTON_02 As Forms.ComboBox
    Friend WithEvents TBP_TEST As Forms.TabPage
    Friend WithEvents GRP_TEST As Forms.GroupBox
    Friend WithEvents PNL_TEST_SEND_KEY As Forms.Panel
    Friend WithEvents LBL_TEST_SEND_KEY_GUIDE As Forms.Label
    Friend WithEvents BTN_TEST_SEND_KEY As Forms.Button
    Friend WithEvents LBL_TEST_SEND_KEY_NAME As Forms.Label
    Friend WithEvents PNL_TEST_SEND_STR As Forms.Panel
    Friend WithEvents LBL_TEST_SEND_STR_NAME As Forms.Label
    Friend WithEvents BTN_TEST_SEND_STR As Forms.Button
    Friend WithEvents LBL_TEST_SEND_STR_GUIDE As Forms.Label
    Friend WithEvents TXT_TEST_SEND_STR As Forms.TextBox
    Friend WithEvents PNL_TEST_OPERATION_MOUSE As Forms.Panel
    Friend WithEvents TXT_TEST_OPERATION_MOUSE_X As Forms.TextBox
    Friend WithEvents LBL_TEST_OPERATION_MOUSE_NAME As Forms.Label
    Friend WithEvents BTN_TEST_OPERATION_MOUSE As Forms.Button
    Friend WithEvents LBL_TEST_OPERATION_MOUSE_GUIDE As Forms.Label
    Friend WithEvents TXT_TEST_OPERATION_MOUSE_Y As Forms.TextBox
End Class
