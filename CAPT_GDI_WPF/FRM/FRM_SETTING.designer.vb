﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.TBC_SETTING = New System.Windows.Forms.TabControl()
        Me.TBP_KEYBORD = New System.Windows.Forms.TabPage()
        Me.grpHOT_KEY = New System.Windows.Forms.GroupBox()
        Me.pnlHOT_KEY_CAPT_ONE_SNS = New System.Windows.Forms.Panel()
        Me.cmbHOT_MASK_CAPT_ONE_SNS = New System.Windows.Forms.ComboBox()
        Me.cmbHOT_KEY_CAPT_ONE_SNS = New System.Windows.Forms.ComboBox()
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE = New System.Windows.Forms.Label()
        Me.pnlHOT_KEY_ROTATE = New System.Windows.Forms.Panel()
        Me.cmbHOT_MASK_ROTATE = New System.Windows.Forms.ComboBox()
        Me.cmbHOT_KEY_ROTATE = New System.Windows.Forms.ComboBox()
        Me.lblHOT_KEY_ROTATE_GUIDE = New System.Windows.Forms.Label()
        Me.pnlHOT_KEY_CHANGE_COMPOSITION = New System.Windows.Forms.Panel()
        Me.cmbHOT_MASK_CHANGE_COMPOSITION = New System.Windows.Forms.ComboBox()
        Me.cmbHOT_KEY_CHANGE_COMPOSITION = New System.Windows.Forms.ComboBox()
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE = New System.Windows.Forms.Label()
        Me.pnlHOT_KEY_CAPT = New System.Windows.Forms.Panel()
        Me.cmbHOT_MASK_CAPT = New System.Windows.Forms.ComboBox()
        Me.cmbHOT_KEY_CAPT = New System.Windows.Forms.ComboBox()
        Me.lblHOT_KEY_CAPT_GUIDE = New System.Windows.Forms.Label()
        Me.pnlHOT_KEY_CAPT_ONE = New System.Windows.Forms.Panel()
        Me.cmbHOT_MASK_CAPT_ONE = New System.Windows.Forms.ComboBox()
        Me.cmbHOT_KEY_CAPT_ONE = New System.Windows.Forms.ComboBox()
        Me.lblHOT_KEY_CAPT_ONE_GUIDE = New System.Windows.Forms.Label()
        Me.TBP_JOYPAD = New System.Windows.Forms.TabPage()
        Me.groJOY_STICK = New System.Windows.Forms.GroupBox()
        Me.pnlPAD_CAPT_ONE_SNS = New System.Windows.Forms.Panel()
        Me.cmbJOY_MOD_CAPT_ONE_SNS = New System.Windows.Forms.ComboBox()
        Me.lblPAD_CAPT_ONE_SNS_GUIDE = New System.Windows.Forms.Label()
        Me.cmbPAD_CAPT_ONE_SNS = New System.Windows.Forms.ComboBox()
        Me.pnlPAD_VIEW_ROTATE = New System.Windows.Forms.Panel()
        Me.cmbJOY_MOD_VIEW_ROTATE = New System.Windows.Forms.ComboBox()
        Me.cmbPAD_VIEW_ROTATE = New System.Windows.Forms.ComboBox()
        Me.lblPAD_ROTATE_GUIDE = New System.Windows.Forms.Label()
        Me.pnlPAD_VIEW_COMPOSITION = New System.Windows.Forms.Panel()
        Me.cmbJOY_MOD_VIEW_OVERLAY = New System.Windows.Forms.ComboBox()
        Me.cmbPAD_VIEW_OVERLAY = New System.Windows.Forms.ComboBox()
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE = New System.Windows.Forms.Label()
        Me.pnlPAD_CAPT = New System.Windows.Forms.Panel()
        Me.cmbJOY_MOD_CAPT = New System.Windows.Forms.ComboBox()
        Me.cmbPAD_CAPT = New System.Windows.Forms.ComboBox()
        Me.lblPAD_CAPT_GUIDE = New System.Windows.Forms.Label()
        Me.pnlPAD_USE = New System.Windows.Forms.Panel()
        Me.cmbKIND_JOY_STICK = New System.Windows.Forms.ComboBox()
        Me.lblKIND_JOY_STICK_GUIDE = New System.Windows.Forms.Label()
        Me.pnlPAD_CAPT_ONE = New System.Windows.Forms.Panel()
        Me.cmbJOY_MOD_CAPT_ONE = New System.Windows.Forms.ComboBox()
        Me.lblPAD_CAPT_ONE_GUIDE = New System.Windows.Forms.Label()
        Me.cmbPAD_CAPT_ONE = New System.Windows.Forms.ComboBox()
        Me.TBP_OVERLAY = New System.Windows.Forms.TabPage()
        Me.grpOVERLAY_THUMBNAIL = New System.Windows.Forms.GroupBox()
        Me.grpOVERLAY_THUMBNAIL_COUNT = New System.Windows.Forms.Panel()
        Me.nudOVERLAY_THUMBNAIL_COUNT = New System.Windows.Forms.NumericUpDown()
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE = New System.Windows.Forms.Label()
        Me.grpOVERLAY_COMPOSITION = New System.Windows.Forms.GroupBox()
        Me.pnlOVERLAY_COMPOSITION_TYPE = New System.Windows.Forms.Panel()
        Me.cmbOVERLAY_COMPOSITION_TYPE = New System.Windows.Forms.ComboBox()
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE = New System.Windows.Forms.Label()
        Me.grpOVERLAY_VISIBLE = New System.Windows.Forms.GroupBox()
        Me.pnlOVERLAY_VISBLE_SHORTCUT = New System.Windows.Forms.Panel()
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT = New System.Windows.Forms.ComboBox()
        Me.chkOVERLAY_VISBLE_SHORTCUT = New System.Windows.Forms.CheckBox()
        Me.pnlOVERLAY_VISBLE_THUMBNAIL = New System.Windows.Forms.Panel()
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL = New System.Windows.Forms.ComboBox()
        Me.chkOVERLAY_VISBLE_THUMBNAIL = New System.Windows.Forms.CheckBox()
        Me.pnlOVERLAY_VISBLE_HISTOGRAM = New System.Windows.Forms.Panel()
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM = New System.Windows.Forms.ComboBox()
        Me.chkOVERLAY_VISBLE_HISTOGRAM = New System.Windows.Forms.CheckBox()
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM = New System.Windows.Forms.Panel()
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM = New System.Windows.Forms.ComboBox()
        Me.chkOVERLAY_VISBLE_CAPT_PARAM = New System.Windows.Forms.CheckBox()
        Me.pnlOVERLAY_VISBLE_COMPOSITION = New System.Windows.Forms.Panel()
        Me.chkOVERLAY_VISBLE_COMPOSITION = New System.Windows.Forms.CheckBox()
        Me.TBP_ROTATE = New System.Windows.Forms.TabPage()
        Me.grpROTATE_SIZE = New System.Windows.Forms.GroupBox()
        Me.btnROTATE_SIZE_INIT = New System.Windows.Forms.Button()
        Me.pnlROTATE_SIZE_H = New System.Windows.Forms.Panel()
        Me.lblROTATE_SIZE_H_GUIDE = New System.Windows.Forms.Label()
        Me.txtROTATE_SIZE_H = New System.Windows.Forms.TextBox()
        Me.pnlROTATE_SIZE_W = New System.Windows.Forms.Panel()
        Me.lblROTATE_SIZE_W_GUIDE = New System.Windows.Forms.Label()
        Me.txtROTATE_SIZE_W = New System.Windows.Forms.TextBox()
        Me.grpROTATE_POSITION = New System.Windows.Forms.GroupBox()
        Me.btnROTATE_POSITION_INIT = New System.Windows.Forms.Button()
        Me.pnlROTATE_POSITION_Y = New System.Windows.Forms.Panel()
        Me.lblROTATE_POSITION_Y_GUIDE = New System.Windows.Forms.Label()
        Me.txtROTATE_POSITION_Y = New System.Windows.Forms.TextBox()
        Me.pnlROTATE_POSITION_X = New System.Windows.Forms.Panel()
        Me.lblROTATE_POSITION_X_GUIDE = New System.Windows.Forms.Label()
        Me.txtROTATE_POSITION_X = New System.Windows.Forms.TextBox()
        Me.TBP_LOGO = New System.Windows.Forms.TabPage()
        Me.PNL_PATH_LOGO_FILE = New System.Windows.Forms.Panel()
        Me.TXT_PATH_LOGO_FILE = New System.Windows.Forms.TextBox()
        Me.LBL_PATH_LOGO_FILE_GUIDE = New System.Windows.Forms.Label()
        Me.BTN_REF_PATH_LOGO_FILE = New System.Windows.Forms.Button()
        Me.TBP_SAVE = New System.Windows.Forms.TabPage()
        Me.pnlNAME_FILE = New System.Windows.Forms.Panel()
        Me.txtPATH_SAVE_FILE_NAME = New System.Windows.Forms.TextBox()
        Me.lblPATH_SAVE_FILE_NAME_GUIDE = New System.Windows.Forms.Label()
        Me.pnlNAME_FOLDER = New System.Windows.Forms.Panel()
        Me.txtPATH_SAVE_FOLDER_NAME = New System.Windows.Forms.TextBox()
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE = New System.Windows.Forms.Label()
        Me.pnlINDEX_FILE = New System.Windows.Forms.Panel()
        Me.txtIMAGE_INDEX = New System.Windows.Forms.TextBox()
        Me.lblIMAGE_INDEX_GUIDE = New System.Windows.Forms.Label()
        Me.pnlIMAGE_FORMAT = New System.Windows.Forms.Panel()
        Me.chkCOPYRIGHT = New System.Windows.Forms.CheckBox()
        Me.cmbIMAGE_FORMAT = New System.Windows.Forms.ComboBox()
        Me.lblIMAGE_FORMAT_GUIDE = New System.Windows.Forms.Label()
        Me.pnlPATH_SAVE = New System.Windows.Forms.Panel()
        Me.btnOPEN_DIR = New System.Windows.Forms.Button()
        Me.lblPATH_SAVE_GUIDE = New System.Windows.Forms.Label()
        Me.btnPATH_SAVE_REF = New System.Windows.Forms.Button()
        Me.txtPATH_SAVE = New System.Windows.Forms.TextBox()
        Me.TBP_CAPT = New System.Windows.Forms.TabPage()
        Me.pnlSEBD_KEYS_WAIT = New System.Windows.Forms.Panel()
        Me.cmbSEND_KEY = New System.Windows.Forms.ComboBox()
        Me.lblINTERVAL_SEND_KEY_UNIT = New System.Windows.Forms.Label()
        Me.lblSEND_KEY_GUIDE = New System.Windows.Forms.Label()
        Me.txtINTERVAL_SEND_KEY = New System.Windows.Forms.TextBox()
        Me.pnlSOUND_CAPUTRE = New System.Windows.Forms.Panel()
        Me.chkSOUND_CAPTURE = New System.Windows.Forms.CheckBox()
        Me.pnlTIMER_CAPTURE = New System.Windows.Forms.Panel()
        Me.lblTIMER_CAPTURE_UNIT = New System.Windows.Forms.Label()
        Me.lblTIMER_CAPTURE_GUIDE = New System.Windows.Forms.Label()
        Me.txtTIMER_CAPTURE = New System.Windows.Forms.TextBox()
        Me.pnlINTERVAL_CAPTURE = New System.Windows.Forms.Panel()
        Me.lblINTERVAL_CAPTURE_UNIT = New System.Windows.Forms.Label()
        Me.lblINTERVAL_CAPTURE_GUIDE = New System.Windows.Forms.Label()
        Me.txtINTERVAL_CAPTURE = New System.Windows.Forms.TextBox()
        Me.pnlCOUNT_CAPTURE = New System.Windows.Forms.Panel()
        Me.lblCOUNT_CAPTURE_UNIT = New System.Windows.Forms.Label()
        Me.lblCOUNT_CAPTURE_GUIDE = New System.Windows.Forms.Label()
        Me.txtCOUNT_CAPTURE = New System.Windows.Forms.TextBox()
        Me.TBP_LIGHT = New System.Windows.Forms.TabPage()
        Me.GRP_LIGHT = New System.Windows.Forms.GroupBox()
        Me.pnlLIGHT_ROTATE = New System.Windows.Forms.Panel()
        Me.LBL_LIGHT_ROTATE_UD_UNIT = New System.Windows.Forms.Label()
        Me.CMB_LIGHT_ROTATE_UD = New System.Windows.Forms.ComboBox()
        Me.LBL_LIGHT_ROTATE_UD_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_LIGHT_ROTATE_UD = New System.Windows.Forms.TextBox()
        Me.pnlLIGHT_DISTANCE = New System.Windows.Forms.Panel()
        Me.LBL_LIGHT_DISTANCE_UNIT = New System.Windows.Forms.Label()
        Me.CMB_LIGHT_DISTANCE = New System.Windows.Forms.ComboBox()
        Me.LBL_LIGHT_DISTANCE_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_LIGHT_DISTANCE = New System.Windows.Forms.TextBox()
        Me.PNL_ROTATE_LR = New System.Windows.Forms.Panel()
        Me.LBL_LIGHT_ROTATE_LR_UNIT = New System.Windows.Forms.Label()
        Me.CMB_LIGHT_ROTATE_LR = New System.Windows.Forms.ComboBox()
        Me.LBL_LIGHT_ROTATE_LR_GUIDE = New System.Windows.Forms.Label()
        Me.TXT_LIGHT_ROTATE_LR = New System.Windows.Forms.TextBox()
        Me.btnINIT_SETTINGS = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.fbdPATH_SAVE = New System.Windows.Forms.FolderBrowserDialog()
        Me.GRP_ROTATE_BUTTON_SETTING = New System.Windows.Forms.GroupBox()
        Me.PNL_ROTATE_BUTTON_SENSITIVITY = New System.Windows.Forms.Panel()
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE = New System.Windows.Forms.Label()
        Me.CMB_ROTATE_BUTTON_SIZE = New System.Windows.Forms.ComboBox()
        Me.CMB_ROTATE_BUTTON_SENSITIVITY = New System.Windows.Forms.ComboBox()
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT = New System.Windows.Forms.Label()
        Me.TBC_SETTING.SuspendLayout()
        Me.TBP_KEYBORD.SuspendLayout()
        Me.grpHOT_KEY.SuspendLayout()
        Me.pnlHOT_KEY_CAPT_ONE_SNS.SuspendLayout()
        Me.pnlHOT_KEY_ROTATE.SuspendLayout()
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.SuspendLayout()
        Me.pnlHOT_KEY_CAPT.SuspendLayout()
        Me.pnlHOT_KEY_CAPT_ONE.SuspendLayout()
        Me.TBP_JOYPAD.SuspendLayout()
        Me.groJOY_STICK.SuspendLayout()
        Me.pnlPAD_CAPT_ONE_SNS.SuspendLayout()
        Me.pnlPAD_VIEW_ROTATE.SuspendLayout()
        Me.pnlPAD_VIEW_COMPOSITION.SuspendLayout()
        Me.pnlPAD_CAPT.SuspendLayout()
        Me.pnlPAD_USE.SuspendLayout()
        Me.pnlPAD_CAPT_ONE.SuspendLayout()
        Me.TBP_OVERLAY.SuspendLayout()
        Me.grpOVERLAY_THUMBNAIL.SuspendLayout()
        Me.grpOVERLAY_THUMBNAIL_COUNT.SuspendLayout()
        CType(Me.nudOVERLAY_THUMBNAIL_COUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOVERLAY_COMPOSITION.SuspendLayout()
        Me.pnlOVERLAY_COMPOSITION_TYPE.SuspendLayout()
        Me.grpOVERLAY_VISIBLE.SuspendLayout()
        Me.pnlOVERLAY_VISBLE_SHORTCUT.SuspendLayout()
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.SuspendLayout()
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.SuspendLayout()
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.SuspendLayout()
        Me.pnlOVERLAY_VISBLE_COMPOSITION.SuspendLayout()
        Me.TBP_ROTATE.SuspendLayout()
        Me.grpROTATE_SIZE.SuspendLayout()
        Me.pnlROTATE_SIZE_H.SuspendLayout()
        Me.pnlROTATE_SIZE_W.SuspendLayout()
        Me.grpROTATE_POSITION.SuspendLayout()
        Me.pnlROTATE_POSITION_Y.SuspendLayout()
        Me.pnlROTATE_POSITION_X.SuspendLayout()
        Me.TBP_LOGO.SuspendLayout()
        Me.PNL_PATH_LOGO_FILE.SuspendLayout()
        Me.TBP_SAVE.SuspendLayout()
        Me.pnlNAME_FILE.SuspendLayout()
        Me.pnlNAME_FOLDER.SuspendLayout()
        Me.pnlINDEX_FILE.SuspendLayout()
        Me.pnlIMAGE_FORMAT.SuspendLayout()
        Me.pnlPATH_SAVE.SuspendLayout()
        Me.TBP_CAPT.SuspendLayout()
        Me.pnlSEBD_KEYS_WAIT.SuspendLayout()
        Me.pnlSOUND_CAPUTRE.SuspendLayout()
        Me.pnlTIMER_CAPTURE.SuspendLayout()
        Me.pnlINTERVAL_CAPTURE.SuspendLayout()
        Me.pnlCOUNT_CAPTURE.SuspendLayout()
        Me.TBP_LIGHT.SuspendLayout()
        Me.GRP_LIGHT.SuspendLayout()
        Me.pnlLIGHT_ROTATE.SuspendLayout()
        Me.pnlLIGHT_DISTANCE.SuspendLayout()
        Me.PNL_ROTATE_LR.SuspendLayout()
        Me.GRP_ROTATE_BUTTON_SETTING.SuspendLayout()
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TBC_SETTING
        '
        Me.TBC_SETTING.Controls.Add(Me.TBP_KEYBORD)
        Me.TBC_SETTING.Controls.Add(Me.TBP_JOYPAD)
        Me.TBC_SETTING.Controls.Add(Me.TBP_OVERLAY)
        Me.TBC_SETTING.Controls.Add(Me.TBP_ROTATE)
        Me.TBC_SETTING.Controls.Add(Me.TBP_LOGO)
        Me.TBC_SETTING.Controls.Add(Me.TBP_SAVE)
        Me.TBC_SETTING.Controls.Add(Me.TBP_CAPT)
        Me.TBC_SETTING.Controls.Add(Me.TBP_LIGHT)
        Me.TBC_SETTING.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TBC_SETTING.Location = New System.Drawing.Point(5, 5)
        Me.TBC_SETTING.Name = "TBC_SETTING"
        Me.TBC_SETTING.SelectedIndex = 0
        Me.TBC_SETTING.Size = New System.Drawing.Size(370, 350)
        Me.TBC_SETTING.TabIndex = 0
        '
        'TBP_KEYBORD
        '
        Me.TBP_KEYBORD.BackColor = System.Drawing.Color.White
        Me.TBP_KEYBORD.Controls.Add(Me.grpHOT_KEY)
        Me.TBP_KEYBORD.Location = New System.Drawing.Point(4, 27)
        Me.TBP_KEYBORD.Name = "TBP_KEYBORD"
        Me.TBP_KEYBORD.Padding = New System.Windows.Forms.Padding(3)
        Me.TBP_KEYBORD.Size = New System.Drawing.Size(362, 319)
        Me.TBP_KEYBORD.TabIndex = 0
        Me.TBP_KEYBORD.Text = "キーボード"
        '
        'grpHOT_KEY
        '
        Me.grpHOT_KEY.Controls.Add(Me.pnlHOT_KEY_CAPT_ONE_SNS)
        Me.grpHOT_KEY.Controls.Add(Me.pnlHOT_KEY_ROTATE)
        Me.grpHOT_KEY.Controls.Add(Me.pnlHOT_KEY_CHANGE_COMPOSITION)
        Me.grpHOT_KEY.Controls.Add(Me.pnlHOT_KEY_CAPT)
        Me.grpHOT_KEY.Controls.Add(Me.pnlHOT_KEY_CAPT_ONE)
        Me.grpHOT_KEY.Location = New System.Drawing.Point(5, 5)
        Me.grpHOT_KEY.Name = "grpHOT_KEY"
        Me.grpHOT_KEY.Size = New System.Drawing.Size(350, 200)
        Me.grpHOT_KEY.TabIndex = 0
        Me.grpHOT_KEY.TabStop = False
        Me.grpHOT_KEY.Text = "ホットキー"
        '
        'pnlHOT_KEY_CAPT_ONE_SNS
        '
        Me.pnlHOT_KEY_CAPT_ONE_SNS.Controls.Add(Me.cmbHOT_MASK_CAPT_ONE_SNS)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.Controls.Add(Me.cmbHOT_KEY_CAPT_ONE_SNS)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.Controls.Add(Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.Location = New System.Drawing.Point(5, 55)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.Name = "pnlHOT_KEY_CAPT_ONE_SNS"
        Me.pnlHOT_KEY_CAPT_ONE_SNS.Size = New System.Drawing.Size(335, 30)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.TabIndex = 4
        '
        'cmbHOT_MASK_CAPT_ONE_SNS
        '
        Me.cmbHOT_MASK_CAPT_ONE_SNS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_MASK_CAPT_ONE_SNS.FormattingEnabled = True
        Me.cmbHOT_MASK_CAPT_ONE_SNS.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.cmbHOT_MASK_CAPT_ONE_SNS.Location = New System.Drawing.Point(90, 2)
        Me.cmbHOT_MASK_CAPT_ONE_SNS.Name = "cmbHOT_MASK_CAPT_ONE_SNS"
        Me.cmbHOT_MASK_CAPT_ONE_SNS.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_MASK_CAPT_ONE_SNS.TabIndex = 8
        '
        'cmbHOT_KEY_CAPT_ONE_SNS
        '
        Me.cmbHOT_KEY_CAPT_ONE_SNS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_KEY_CAPT_ONE_SNS.FormattingEnabled = True
        Me.cmbHOT_KEY_CAPT_ONE_SNS.Items.AddRange(New Object() {"未指定", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"})
        Me.cmbHOT_KEY_CAPT_ONE_SNS.Location = New System.Drawing.Point(170, 2)
        Me.cmbHOT_KEY_CAPT_ONE_SNS.Name = "cmbHOT_KEY_CAPT_ONE_SNS"
        Me.cmbHOT_KEY_CAPT_ONE_SNS.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_KEY_CAPT_ONE_SNS.TabIndex = 6
        '
        'lblHOT_KEY_CAPT_ONE_SNS_GUIDE
        '
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE.AutoSize = True
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE.Name = "lblHOT_KEY_CAPT_ONE_SNS_GUIDE"
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE.Size = New System.Drawing.Size(79, 18)
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE.TabIndex = 7
        Me.lblHOT_KEY_CAPT_ONE_SNS_GUIDE.Text = "撮影(SNS向)"
        '
        'pnlHOT_KEY_ROTATE
        '
        Me.pnlHOT_KEY_ROTATE.Controls.Add(Me.cmbHOT_MASK_ROTATE)
        Me.pnlHOT_KEY_ROTATE.Controls.Add(Me.cmbHOT_KEY_ROTATE)
        Me.pnlHOT_KEY_ROTATE.Controls.Add(Me.lblHOT_KEY_ROTATE_GUIDE)
        Me.pnlHOT_KEY_ROTATE.Location = New System.Drawing.Point(5, 160)
        Me.pnlHOT_KEY_ROTATE.Name = "pnlHOT_KEY_ROTATE"
        Me.pnlHOT_KEY_ROTATE.Size = New System.Drawing.Size(335, 30)
        Me.pnlHOT_KEY_ROTATE.TabIndex = 3
        '
        'cmbHOT_MASK_ROTATE
        '
        Me.cmbHOT_MASK_ROTATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_MASK_ROTATE.FormattingEnabled = True
        Me.cmbHOT_MASK_ROTATE.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.cmbHOT_MASK_ROTATE.Location = New System.Drawing.Point(90, 2)
        Me.cmbHOT_MASK_ROTATE.Name = "cmbHOT_MASK_ROTATE"
        Me.cmbHOT_MASK_ROTATE.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_MASK_ROTATE.TabIndex = 9
        '
        'cmbHOT_KEY_ROTATE
        '
        Me.cmbHOT_KEY_ROTATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_KEY_ROTATE.FormattingEnabled = True
        Me.cmbHOT_KEY_ROTATE.Items.AddRange(New Object() {"未指定", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"})
        Me.cmbHOT_KEY_ROTATE.Location = New System.Drawing.Point(170, 1)
        Me.cmbHOT_KEY_ROTATE.Name = "cmbHOT_KEY_ROTATE"
        Me.cmbHOT_KEY_ROTATE.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_KEY_ROTATE.TabIndex = 2
        '
        'lblHOT_KEY_ROTATE_GUIDE
        '
        Me.lblHOT_KEY_ROTATE_GUIDE.AutoSize = True
        Me.lblHOT_KEY_ROTATE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblHOT_KEY_ROTATE_GUIDE.Name = "lblHOT_KEY_ROTATE_GUIDE"
        Me.lblHOT_KEY_ROTATE_GUIDE.Size = New System.Drawing.Size(80, 18)
        Me.lblHOT_KEY_ROTATE_GUIDE.TabIndex = 0
        Me.lblHOT_KEY_ROTATE_GUIDE.Text = "回転イメージ"
        '
        'pnlHOT_KEY_CHANGE_COMPOSITION
        '
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.Controls.Add(Me.cmbHOT_MASK_CHANGE_COMPOSITION)
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.Controls.Add(Me.cmbHOT_KEY_CHANGE_COMPOSITION)
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.Controls.Add(Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE)
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.Location = New System.Drawing.Point(5, 125)
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.Name = "pnlHOT_KEY_CHANGE_COMPOSITION"
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.Size = New System.Drawing.Size(335, 30)
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.TabIndex = 2
        '
        'cmbHOT_MASK_CHANGE_COMPOSITION
        '
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.FormattingEnabled = True
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.Location = New System.Drawing.Point(90, 2)
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.Name = "cmbHOT_MASK_CHANGE_COMPOSITION"
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_MASK_CHANGE_COMPOSITION.TabIndex = 9
        '
        'cmbHOT_KEY_CHANGE_COMPOSITION
        '
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.FormattingEnabled = True
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.Items.AddRange(New Object() {"未指定", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"})
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.Location = New System.Drawing.Point(170, 1)
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.Name = "cmbHOT_KEY_CHANGE_COMPOSITION"
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_KEY_CHANGE_COMPOSITION.TabIndex = 2
        '
        'lblHOT_KEY_CHANGE_COMPOSITION_GUIDE
        '
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE.AutoSize = True
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE.Name = "lblHOT_KEY_CHANGE_COMPOSITION_GUIDE"
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE.Size = New System.Drawing.Size(80, 18)
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE.TabIndex = 0
        Me.lblHOT_KEY_CHANGE_COMPOSITION_GUIDE.Text = "オーバーレイ"
        '
        'pnlHOT_KEY_CAPT
        '
        Me.pnlHOT_KEY_CAPT.Controls.Add(Me.cmbHOT_MASK_CAPT)
        Me.pnlHOT_KEY_CAPT.Controls.Add(Me.cmbHOT_KEY_CAPT)
        Me.pnlHOT_KEY_CAPT.Controls.Add(Me.lblHOT_KEY_CAPT_GUIDE)
        Me.pnlHOT_KEY_CAPT.Location = New System.Drawing.Point(5, 90)
        Me.pnlHOT_KEY_CAPT.Name = "pnlHOT_KEY_CAPT"
        Me.pnlHOT_KEY_CAPT.Size = New System.Drawing.Size(335, 30)
        Me.pnlHOT_KEY_CAPT.TabIndex = 1
        '
        'cmbHOT_MASK_CAPT
        '
        Me.cmbHOT_MASK_CAPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_MASK_CAPT.FormattingEnabled = True
        Me.cmbHOT_MASK_CAPT.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.cmbHOT_MASK_CAPT.Location = New System.Drawing.Point(90, 2)
        Me.cmbHOT_MASK_CAPT.Name = "cmbHOT_MASK_CAPT"
        Me.cmbHOT_MASK_CAPT.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_MASK_CAPT.TabIndex = 9
        '
        'cmbHOT_KEY_CAPT
        '
        Me.cmbHOT_KEY_CAPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_KEY_CAPT.FormattingEnabled = True
        Me.cmbHOT_KEY_CAPT.Items.AddRange(New Object() {"未指定", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"})
        Me.cmbHOT_KEY_CAPT.Location = New System.Drawing.Point(170, 2)
        Me.cmbHOT_KEY_CAPT.Name = "cmbHOT_KEY_CAPT"
        Me.cmbHOT_KEY_CAPT.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_KEY_CAPT.TabIndex = 6
        '
        'lblHOT_KEY_CAPT_GUIDE
        '
        Me.lblHOT_KEY_CAPT_GUIDE.AutoSize = True
        Me.lblHOT_KEY_CAPT_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblHOT_KEY_CAPT_GUIDE.Name = "lblHOT_KEY_CAPT_GUIDE"
        Me.lblHOT_KEY_CAPT_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblHOT_KEY_CAPT_GUIDE.TabIndex = 7
        Me.lblHOT_KEY_CAPT_GUIDE.Text = "連続撮影"
        '
        'pnlHOT_KEY_CAPT_ONE
        '
        Me.pnlHOT_KEY_CAPT_ONE.Controls.Add(Me.cmbHOT_MASK_CAPT_ONE)
        Me.pnlHOT_KEY_CAPT_ONE.Controls.Add(Me.cmbHOT_KEY_CAPT_ONE)
        Me.pnlHOT_KEY_CAPT_ONE.Controls.Add(Me.lblHOT_KEY_CAPT_ONE_GUIDE)
        Me.pnlHOT_KEY_CAPT_ONE.Location = New System.Drawing.Point(5, 20)
        Me.pnlHOT_KEY_CAPT_ONE.Name = "pnlHOT_KEY_CAPT_ONE"
        Me.pnlHOT_KEY_CAPT_ONE.Size = New System.Drawing.Size(335, 30)
        Me.pnlHOT_KEY_CAPT_ONE.TabIndex = 0
        '
        'cmbHOT_MASK_CAPT_ONE
        '
        Me.cmbHOT_MASK_CAPT_ONE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_MASK_CAPT_ONE.FormattingEnabled = True
        Me.cmbHOT_MASK_CAPT_ONE.Items.AddRange(New Object() {"未指定", "Alt", "Ctrl", "Shift"})
        Me.cmbHOT_MASK_CAPT_ONE.Location = New System.Drawing.Point(90, 2)
        Me.cmbHOT_MASK_CAPT_ONE.Name = "cmbHOT_MASK_CAPT_ONE"
        Me.cmbHOT_MASK_CAPT_ONE.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_MASK_CAPT_ONE.TabIndex = 8
        '
        'cmbHOT_KEY_CAPT_ONE
        '
        Me.cmbHOT_KEY_CAPT_ONE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHOT_KEY_CAPT_ONE.FormattingEnabled = True
        Me.cmbHOT_KEY_CAPT_ONE.Items.AddRange(New Object() {"未指定", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"})
        Me.cmbHOT_KEY_CAPT_ONE.Location = New System.Drawing.Point(170, 2)
        Me.cmbHOT_KEY_CAPT_ONE.Name = "cmbHOT_KEY_CAPT_ONE"
        Me.cmbHOT_KEY_CAPT_ONE.Size = New System.Drawing.Size(75, 26)
        Me.cmbHOT_KEY_CAPT_ONE.TabIndex = 6
        '
        'lblHOT_KEY_CAPT_ONE_GUIDE
        '
        Me.lblHOT_KEY_CAPT_ONE_GUIDE.AutoSize = True
        Me.lblHOT_KEY_CAPT_ONE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblHOT_KEY_CAPT_ONE_GUIDE.Name = "lblHOT_KEY_CAPT_ONE_GUIDE"
        Me.lblHOT_KEY_CAPT_ONE_GUIDE.Size = New System.Drawing.Size(32, 18)
        Me.lblHOT_KEY_CAPT_ONE_GUIDE.TabIndex = 7
        Me.lblHOT_KEY_CAPT_ONE_GUIDE.Text = "撮影"
        '
        'TBP_JOYPAD
        '
        Me.TBP_JOYPAD.Controls.Add(Me.groJOY_STICK)
        Me.TBP_JOYPAD.Location = New System.Drawing.Point(4, 27)
        Me.TBP_JOYPAD.Name = "TBP_JOYPAD"
        Me.TBP_JOYPAD.Size = New System.Drawing.Size(362, 319)
        Me.TBP_JOYPAD.TabIndex = 6
        Me.TBP_JOYPAD.Text = "ゲームパッド"
        Me.TBP_JOYPAD.UseVisualStyleBackColor = True
        '
        'groJOY_STICK
        '
        Me.groJOY_STICK.Controls.Add(Me.pnlPAD_CAPT_ONE_SNS)
        Me.groJOY_STICK.Controls.Add(Me.pnlPAD_VIEW_ROTATE)
        Me.groJOY_STICK.Controls.Add(Me.pnlPAD_VIEW_COMPOSITION)
        Me.groJOY_STICK.Controls.Add(Me.pnlPAD_CAPT)
        Me.groJOY_STICK.Controls.Add(Me.pnlPAD_USE)
        Me.groJOY_STICK.Controls.Add(Me.pnlPAD_CAPT_ONE)
        Me.groJOY_STICK.Location = New System.Drawing.Point(5, 5)
        Me.groJOY_STICK.Name = "groJOY_STICK"
        Me.groJOY_STICK.Size = New System.Drawing.Size(350, 230)
        Me.groJOY_STICK.TabIndex = 1
        Me.groJOY_STICK.TabStop = False
        Me.groJOY_STICK.Text = "ボタン割当"
        '
        'pnlPAD_CAPT_ONE_SNS
        '
        Me.pnlPAD_CAPT_ONE_SNS.Controls.Add(Me.cmbJOY_MOD_CAPT_ONE_SNS)
        Me.pnlPAD_CAPT_ONE_SNS.Controls.Add(Me.lblPAD_CAPT_ONE_SNS_GUIDE)
        Me.pnlPAD_CAPT_ONE_SNS.Controls.Add(Me.cmbPAD_CAPT_ONE_SNS)
        Me.pnlPAD_CAPT_ONE_SNS.Location = New System.Drawing.Point(5, 90)
        Me.pnlPAD_CAPT_ONE_SNS.Name = "pnlPAD_CAPT_ONE_SNS"
        Me.pnlPAD_CAPT_ONE_SNS.Size = New System.Drawing.Size(335, 30)
        Me.pnlPAD_CAPT_ONE_SNS.TabIndex = 6
        '
        'cmbJOY_MOD_CAPT_ONE_SNS
        '
        Me.cmbJOY_MOD_CAPT_ONE_SNS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJOY_MOD_CAPT_ONE_SNS.FormattingEnabled = True
        Me.cmbJOY_MOD_CAPT_ONE_SNS.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbJOY_MOD_CAPT_ONE_SNS.Location = New System.Drawing.Point(90, 2)
        Me.cmbJOY_MOD_CAPT_ONE_SNS.Name = "cmbJOY_MOD_CAPT_ONE_SNS"
        Me.cmbJOY_MOD_CAPT_ONE_SNS.Size = New System.Drawing.Size(90, 26)
        Me.cmbJOY_MOD_CAPT_ONE_SNS.TabIndex = 14
        '
        'lblPAD_CAPT_ONE_SNS_GUIDE
        '
        Me.lblPAD_CAPT_ONE_SNS_GUIDE.AutoSize = True
        Me.lblPAD_CAPT_ONE_SNS_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPAD_CAPT_ONE_SNS_GUIDE.Name = "lblPAD_CAPT_ONE_SNS_GUIDE"
        Me.lblPAD_CAPT_ONE_SNS_GUIDE.Size = New System.Drawing.Size(79, 18)
        Me.lblPAD_CAPT_ONE_SNS_GUIDE.TabIndex = 13
        Me.lblPAD_CAPT_ONE_SNS_GUIDE.Text = "撮影(SNS向)"
        '
        'cmbPAD_CAPT_ONE_SNS
        '
        Me.cmbPAD_CAPT_ONE_SNS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAD_CAPT_ONE_SNS.FormattingEnabled = True
        Me.cmbPAD_CAPT_ONE_SNS.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbPAD_CAPT_ONE_SNS.Location = New System.Drawing.Point(200, 2)
        Me.cmbPAD_CAPT_ONE_SNS.Name = "cmbPAD_CAPT_ONE_SNS"
        Me.cmbPAD_CAPT_ONE_SNS.Size = New System.Drawing.Size(90, 26)
        Me.cmbPAD_CAPT_ONE_SNS.TabIndex = 10
        '
        'pnlPAD_VIEW_ROTATE
        '
        Me.pnlPAD_VIEW_ROTATE.Controls.Add(Me.cmbJOY_MOD_VIEW_ROTATE)
        Me.pnlPAD_VIEW_ROTATE.Controls.Add(Me.cmbPAD_VIEW_ROTATE)
        Me.pnlPAD_VIEW_ROTATE.Controls.Add(Me.lblPAD_ROTATE_GUIDE)
        Me.pnlPAD_VIEW_ROTATE.Location = New System.Drawing.Point(5, 195)
        Me.pnlPAD_VIEW_ROTATE.Name = "pnlPAD_VIEW_ROTATE"
        Me.pnlPAD_VIEW_ROTATE.Size = New System.Drawing.Size(335, 30)
        Me.pnlPAD_VIEW_ROTATE.TabIndex = 5
        '
        'cmbJOY_MOD_VIEW_ROTATE
        '
        Me.cmbJOY_MOD_VIEW_ROTATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJOY_MOD_VIEW_ROTATE.FormattingEnabled = True
        Me.cmbJOY_MOD_VIEW_ROTATE.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbJOY_MOD_VIEW_ROTATE.Location = New System.Drawing.Point(90, 2)
        Me.cmbJOY_MOD_VIEW_ROTATE.Name = "cmbJOY_MOD_VIEW_ROTATE"
        Me.cmbJOY_MOD_VIEW_ROTATE.Size = New System.Drawing.Size(90, 26)
        Me.cmbJOY_MOD_VIEW_ROTATE.TabIndex = 9
        '
        'cmbPAD_VIEW_ROTATE
        '
        Me.cmbPAD_VIEW_ROTATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAD_VIEW_ROTATE.FormattingEnabled = True
        Me.cmbPAD_VIEW_ROTATE.Items.AddRange(New Object() {"未指定", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"})
        Me.cmbPAD_VIEW_ROTATE.Location = New System.Drawing.Point(200, 2)
        Me.cmbPAD_VIEW_ROTATE.Name = "cmbPAD_VIEW_ROTATE"
        Me.cmbPAD_VIEW_ROTATE.Size = New System.Drawing.Size(90, 26)
        Me.cmbPAD_VIEW_ROTATE.TabIndex = 2
        '
        'lblPAD_ROTATE_GUIDE
        '
        Me.lblPAD_ROTATE_GUIDE.AutoSize = True
        Me.lblPAD_ROTATE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPAD_ROTATE_GUIDE.Name = "lblPAD_ROTATE_GUIDE"
        Me.lblPAD_ROTATE_GUIDE.Size = New System.Drawing.Size(80, 18)
        Me.lblPAD_ROTATE_GUIDE.TabIndex = 0
        Me.lblPAD_ROTATE_GUIDE.Text = "回転イメージ"
        '
        'pnlPAD_VIEW_COMPOSITION
        '
        Me.pnlPAD_VIEW_COMPOSITION.Controls.Add(Me.cmbJOY_MOD_VIEW_OVERLAY)
        Me.pnlPAD_VIEW_COMPOSITION.Controls.Add(Me.cmbPAD_VIEW_OVERLAY)
        Me.pnlPAD_VIEW_COMPOSITION.Controls.Add(Me.lblPAD_CHANGE_COMPOSITION_GUIDE)
        Me.pnlPAD_VIEW_COMPOSITION.Location = New System.Drawing.Point(5, 160)
        Me.pnlPAD_VIEW_COMPOSITION.Name = "pnlPAD_VIEW_COMPOSITION"
        Me.pnlPAD_VIEW_COMPOSITION.Size = New System.Drawing.Size(335, 30)
        Me.pnlPAD_VIEW_COMPOSITION.TabIndex = 3
        '
        'cmbJOY_MOD_VIEW_OVERLAY
        '
        Me.cmbJOY_MOD_VIEW_OVERLAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJOY_MOD_VIEW_OVERLAY.FormattingEnabled = True
        Me.cmbJOY_MOD_VIEW_OVERLAY.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbJOY_MOD_VIEW_OVERLAY.Location = New System.Drawing.Point(90, 2)
        Me.cmbJOY_MOD_VIEW_OVERLAY.Name = "cmbJOY_MOD_VIEW_OVERLAY"
        Me.cmbJOY_MOD_VIEW_OVERLAY.Size = New System.Drawing.Size(90, 26)
        Me.cmbJOY_MOD_VIEW_OVERLAY.TabIndex = 9
        '
        'cmbPAD_VIEW_OVERLAY
        '
        Me.cmbPAD_VIEW_OVERLAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAD_VIEW_OVERLAY.FormattingEnabled = True
        Me.cmbPAD_VIEW_OVERLAY.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbPAD_VIEW_OVERLAY.Location = New System.Drawing.Point(200, 2)
        Me.cmbPAD_VIEW_OVERLAY.Name = "cmbPAD_VIEW_OVERLAY"
        Me.cmbPAD_VIEW_OVERLAY.Size = New System.Drawing.Size(90, 26)
        Me.cmbPAD_VIEW_OVERLAY.TabIndex = 2
        '
        'lblPAD_CHANGE_COMPOSITION_GUIDE
        '
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE.AutoSize = True
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE.Name = "lblPAD_CHANGE_COMPOSITION_GUIDE"
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE.Size = New System.Drawing.Size(80, 18)
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE.TabIndex = 0
        Me.lblPAD_CHANGE_COMPOSITION_GUIDE.Text = "オーバーレイ"
        '
        'pnlPAD_CAPT
        '
        Me.pnlPAD_CAPT.Controls.Add(Me.cmbJOY_MOD_CAPT)
        Me.pnlPAD_CAPT.Controls.Add(Me.cmbPAD_CAPT)
        Me.pnlPAD_CAPT.Controls.Add(Me.lblPAD_CAPT_GUIDE)
        Me.pnlPAD_CAPT.Location = New System.Drawing.Point(5, 125)
        Me.pnlPAD_CAPT.Name = "pnlPAD_CAPT"
        Me.pnlPAD_CAPT.Size = New System.Drawing.Size(335, 30)
        Me.pnlPAD_CAPT.TabIndex = 4
        '
        'cmbJOY_MOD_CAPT
        '
        Me.cmbJOY_MOD_CAPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJOY_MOD_CAPT.FormattingEnabled = True
        Me.cmbJOY_MOD_CAPT.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbJOY_MOD_CAPT.Location = New System.Drawing.Point(90, 2)
        Me.cmbJOY_MOD_CAPT.Name = "cmbJOY_MOD_CAPT"
        Me.cmbJOY_MOD_CAPT.Size = New System.Drawing.Size(90, 26)
        Me.cmbJOY_MOD_CAPT.TabIndex = 9
        '
        'cmbPAD_CAPT
        '
        Me.cmbPAD_CAPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAD_CAPT.FormattingEnabled = True
        Me.cmbPAD_CAPT.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbPAD_CAPT.Location = New System.Drawing.Point(200, 2)
        Me.cmbPAD_CAPT.Name = "cmbPAD_CAPT"
        Me.cmbPAD_CAPT.Size = New System.Drawing.Size(90, 26)
        Me.cmbPAD_CAPT.TabIndex = 6
        '
        'lblPAD_CAPT_GUIDE
        '
        Me.lblPAD_CAPT_GUIDE.AutoSize = True
        Me.lblPAD_CAPT_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPAD_CAPT_GUIDE.Name = "lblPAD_CAPT_GUIDE"
        Me.lblPAD_CAPT_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblPAD_CAPT_GUIDE.TabIndex = 7
        Me.lblPAD_CAPT_GUIDE.Text = "連続撮影"
        '
        'pnlPAD_USE
        '
        Me.pnlPAD_USE.Controls.Add(Me.cmbKIND_JOY_STICK)
        Me.pnlPAD_USE.Controls.Add(Me.lblKIND_JOY_STICK_GUIDE)
        Me.pnlPAD_USE.Location = New System.Drawing.Point(5, 20)
        Me.pnlPAD_USE.Name = "pnlPAD_USE"
        Me.pnlPAD_USE.Size = New System.Drawing.Size(335, 30)
        Me.pnlPAD_USE.TabIndex = 0
        '
        'cmbKIND_JOY_STICK
        '
        Me.cmbKIND_JOY_STICK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKIND_JOY_STICK.DropDownWidth = 300
        Me.cmbKIND_JOY_STICK.FormattingEnabled = True
        Me.cmbKIND_JOY_STICK.Items.AddRange(New Object() {"使用しない", "標準コントローラー", "DUALSHOCK®4 USB Wireless Adaptor"})
        Me.cmbKIND_JOY_STICK.Location = New System.Drawing.Point(90, 2)
        Me.cmbKIND_JOY_STICK.Name = "cmbKIND_JOY_STICK"
        Me.cmbKIND_JOY_STICK.Size = New System.Drawing.Size(240, 26)
        Me.cmbKIND_JOY_STICK.TabIndex = 9
        '
        'lblKIND_JOY_STICK_GUIDE
        '
        Me.lblKIND_JOY_STICK_GUIDE.AutoSize = True
        Me.lblKIND_JOY_STICK_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblKIND_JOY_STICK_GUIDE.Name = "lblKIND_JOY_STICK_GUIDE"
        Me.lblKIND_JOY_STICK_GUIDE.Size = New System.Drawing.Size(32, 18)
        Me.lblKIND_JOY_STICK_GUIDE.TabIndex = 8
        Me.lblKIND_JOY_STICK_GUIDE.Text = "種類"
        '
        'pnlPAD_CAPT_ONE
        '
        Me.pnlPAD_CAPT_ONE.Controls.Add(Me.cmbJOY_MOD_CAPT_ONE)
        Me.pnlPAD_CAPT_ONE.Controls.Add(Me.lblPAD_CAPT_ONE_GUIDE)
        Me.pnlPAD_CAPT_ONE.Controls.Add(Me.cmbPAD_CAPT_ONE)
        Me.pnlPAD_CAPT_ONE.Location = New System.Drawing.Point(5, 55)
        Me.pnlPAD_CAPT_ONE.Name = "pnlPAD_CAPT_ONE"
        Me.pnlPAD_CAPT_ONE.Size = New System.Drawing.Size(335, 30)
        Me.pnlPAD_CAPT_ONE.TabIndex = 2
        '
        'cmbJOY_MOD_CAPT_ONE
        '
        Me.cmbJOY_MOD_CAPT_ONE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJOY_MOD_CAPT_ONE.FormattingEnabled = True
        Me.cmbJOY_MOD_CAPT_ONE.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbJOY_MOD_CAPT_ONE.Location = New System.Drawing.Point(90, 2)
        Me.cmbJOY_MOD_CAPT_ONE.Name = "cmbJOY_MOD_CAPT_ONE"
        Me.cmbJOY_MOD_CAPT_ONE.Size = New System.Drawing.Size(90, 26)
        Me.cmbJOY_MOD_CAPT_ONE.TabIndex = 14
        '
        'lblPAD_CAPT_ONE_GUIDE
        '
        Me.lblPAD_CAPT_ONE_GUIDE.AutoSize = True
        Me.lblPAD_CAPT_ONE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPAD_CAPT_ONE_GUIDE.Name = "lblPAD_CAPT_ONE_GUIDE"
        Me.lblPAD_CAPT_ONE_GUIDE.Size = New System.Drawing.Size(32, 18)
        Me.lblPAD_CAPT_ONE_GUIDE.TabIndex = 13
        Me.lblPAD_CAPT_ONE_GUIDE.Text = "撮影"
        '
        'cmbPAD_CAPT_ONE
        '
        Me.cmbPAD_CAPT_ONE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAD_CAPT_ONE.FormattingEnabled = True
        Me.cmbPAD_CAPT_ONE.Items.AddRange(New Object() {"未指定", "ボタン01", "ボタン02", "ボタン03", "ボタン04", "ボタン05", "ボタン06", "ボタン07", "ボタン08", "ボタン09", "ボタン10", "ボタン11", "ボタン12", "ボタン13", "ボタン14", "ボタン15", "ボタン16"})
        Me.cmbPAD_CAPT_ONE.Location = New System.Drawing.Point(200, 2)
        Me.cmbPAD_CAPT_ONE.Name = "cmbPAD_CAPT_ONE"
        Me.cmbPAD_CAPT_ONE.Size = New System.Drawing.Size(90, 26)
        Me.cmbPAD_CAPT_ONE.TabIndex = 10
        '
        'TBP_OVERLAY
        '
        Me.TBP_OVERLAY.Controls.Add(Me.grpOVERLAY_THUMBNAIL)
        Me.TBP_OVERLAY.Controls.Add(Me.grpOVERLAY_COMPOSITION)
        Me.TBP_OVERLAY.Controls.Add(Me.grpOVERLAY_VISIBLE)
        Me.TBP_OVERLAY.Location = New System.Drawing.Point(4, 27)
        Me.TBP_OVERLAY.Name = "TBP_OVERLAY"
        Me.TBP_OVERLAY.Size = New System.Drawing.Size(362, 319)
        Me.TBP_OVERLAY.TabIndex = 3
        Me.TBP_OVERLAY.Text = "オーバーレイ"
        Me.TBP_OVERLAY.UseVisualStyleBackColor = True
        '
        'grpOVERLAY_THUMBNAIL
        '
        Me.grpOVERLAY_THUMBNAIL.Controls.Add(Me.grpOVERLAY_THUMBNAIL_COUNT)
        Me.grpOVERLAY_THUMBNAIL.Enabled = False
        Me.grpOVERLAY_THUMBNAIL.Location = New System.Drawing.Point(185, 210)
        Me.grpOVERLAY_THUMBNAIL.Name = "grpOVERLAY_THUMBNAIL"
        Me.grpOVERLAY_THUMBNAIL.Size = New System.Drawing.Size(170, 60)
        Me.grpOVERLAY_THUMBNAIL.TabIndex = 2
        Me.grpOVERLAY_THUMBNAIL.TabStop = False
        Me.grpOVERLAY_THUMBNAIL.Text = "サムネイル"
        '
        'grpOVERLAY_THUMBNAIL_COUNT
        '
        Me.grpOVERLAY_THUMBNAIL_COUNT.Controls.Add(Me.nudOVERLAY_THUMBNAIL_COUNT)
        Me.grpOVERLAY_THUMBNAIL_COUNT.Controls.Add(Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE)
        Me.grpOVERLAY_THUMBNAIL_COUNT.Location = New System.Drawing.Point(5, 20)
        Me.grpOVERLAY_THUMBNAIL_COUNT.Name = "grpOVERLAY_THUMBNAIL_COUNT"
        Me.grpOVERLAY_THUMBNAIL_COUNT.Size = New System.Drawing.Size(160, 30)
        Me.grpOVERLAY_THUMBNAIL_COUNT.TabIndex = 1
        '
        'nudOVERLAY_THUMBNAIL_COUNT
        '
        Me.nudOVERLAY_THUMBNAIL_COUNT.Location = New System.Drawing.Point(80, 2)
        Me.nudOVERLAY_THUMBNAIL_COUNT.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudOVERLAY_THUMBNAIL_COUNT.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudOVERLAY_THUMBNAIL_COUNT.Name = "nudOVERLAY_THUMBNAIL_COUNT"
        Me.nudOVERLAY_THUMBNAIL_COUNT.Size = New System.Drawing.Size(75, 25)
        Me.nudOVERLAY_THUMBNAIL_COUNT.TabIndex = 10
        Me.nudOVERLAY_THUMBNAIL_COUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudOVERLAY_THUMBNAIL_COUNT.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lblOVERLAY_THUMBNAIL_COUNT_GUIDE
        '
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE.AutoSize = True
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE.Name = "lblOVERLAY_THUMBNAIL_COUNT_GUIDE"
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE.Size = New System.Drawing.Size(44, 18)
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE.TabIndex = 7
        Me.lblOVERLAY_THUMBNAIL_COUNT_GUIDE.Text = "表示数"
        '
        'grpOVERLAY_COMPOSITION
        '
        Me.grpOVERLAY_COMPOSITION.Controls.Add(Me.pnlOVERLAY_COMPOSITION_TYPE)
        Me.grpOVERLAY_COMPOSITION.Location = New System.Drawing.Point(5, 210)
        Me.grpOVERLAY_COMPOSITION.Name = "grpOVERLAY_COMPOSITION"
        Me.grpOVERLAY_COMPOSITION.Size = New System.Drawing.Size(170, 60)
        Me.grpOVERLAY_COMPOSITION.TabIndex = 1
        Me.grpOVERLAY_COMPOSITION.TabStop = False
        Me.grpOVERLAY_COMPOSITION.Text = "構図補助"
        '
        'pnlOVERLAY_COMPOSITION_TYPE
        '
        Me.pnlOVERLAY_COMPOSITION_TYPE.Controls.Add(Me.cmbOVERLAY_COMPOSITION_TYPE)
        Me.pnlOVERLAY_COMPOSITION_TYPE.Controls.Add(Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE)
        Me.pnlOVERLAY_COMPOSITION_TYPE.Location = New System.Drawing.Point(5, 20)
        Me.pnlOVERLAY_COMPOSITION_TYPE.Name = "pnlOVERLAY_COMPOSITION_TYPE"
        Me.pnlOVERLAY_COMPOSITION_TYPE.Size = New System.Drawing.Size(160, 30)
        Me.pnlOVERLAY_COMPOSITION_TYPE.TabIndex = 1
        '
        'cmbOVERLAY_COMPOSITION_TYPE
        '
        Me.cmbOVERLAY_COMPOSITION_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOVERLAY_COMPOSITION_TYPE.FormattingEnabled = True
        Me.cmbOVERLAY_COMPOSITION_TYPE.Items.AddRange(New Object() {"2分割", "3分割", "4分割", "3分割(φ)", "16対9", "3対2", "黄金螺旋1", "黄金螺旋2", "黄金螺旋3", "黄金螺旋4"})
        Me.cmbOVERLAY_COMPOSITION_TYPE.Location = New System.Drawing.Point(50, 2)
        Me.cmbOVERLAY_COMPOSITION_TYPE.Name = "cmbOVERLAY_COMPOSITION_TYPE"
        Me.cmbOVERLAY_COMPOSITION_TYPE.Size = New System.Drawing.Size(105, 26)
        Me.cmbOVERLAY_COMPOSITION_TYPE.TabIndex = 6
        '
        'lblOVERLAY_COMPOSITION_TYPE_GUIDE
        '
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE.AutoSize = True
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE.Name = "lblOVERLAY_COMPOSITION_TYPE_GUIDE"
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE.Size = New System.Drawing.Size(44, 18)
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE.TabIndex = 7
        Me.lblOVERLAY_COMPOSITION_TYPE_GUIDE.Text = "タイプ"
        '
        'grpOVERLAY_VISIBLE
        '
        Me.grpOVERLAY_VISIBLE.Controls.Add(Me.pnlOVERLAY_VISBLE_SHORTCUT)
        Me.grpOVERLAY_VISIBLE.Controls.Add(Me.pnlOVERLAY_VISBLE_THUMBNAIL)
        Me.grpOVERLAY_VISIBLE.Controls.Add(Me.pnlOVERLAY_VISBLE_HISTOGRAM)
        Me.grpOVERLAY_VISIBLE.Controls.Add(Me.pnlOVERLAY_VISBLE_CAPT_PARAM)
        Me.grpOVERLAY_VISIBLE.Controls.Add(Me.pnlOVERLAY_VISBLE_COMPOSITION)
        Me.grpOVERLAY_VISIBLE.Location = New System.Drawing.Point(5, 5)
        Me.grpOVERLAY_VISIBLE.Name = "grpOVERLAY_VISIBLE"
        Me.grpOVERLAY_VISIBLE.Size = New System.Drawing.Size(350, 200)
        Me.grpOVERLAY_VISIBLE.TabIndex = 0
        Me.grpOVERLAY_VISIBLE.TabStop = False
        Me.grpOVERLAY_VISIBLE.Text = "表示"
        '
        'pnlOVERLAY_VISBLE_SHORTCUT
        '
        Me.pnlOVERLAY_VISBLE_SHORTCUT.Controls.Add(Me.cmbOVERLAY_ALIGNMENT_SHORTCUT)
        Me.pnlOVERLAY_VISBLE_SHORTCUT.Controls.Add(Me.chkOVERLAY_VISBLE_SHORTCUT)
        Me.pnlOVERLAY_VISBLE_SHORTCUT.Location = New System.Drawing.Point(5, 20)
        Me.pnlOVERLAY_VISBLE_SHORTCUT.Name = "pnlOVERLAY_VISBLE_SHORTCUT"
        Me.pnlOVERLAY_VISBLE_SHORTCUT.Size = New System.Drawing.Size(335, 30)
        Me.pnlOVERLAY_VISBLE_SHORTCUT.TabIndex = 5
        '
        'cmbOVERLAY_ALIGNMENT_SHORTCUT
        '
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.FormattingEnabled = True
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.Items.AddRange(New Object() {"左上", "右上", "左下", "右下"})
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.Location = New System.Drawing.Point(130, 2)
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.Name = "cmbOVERLAY_ALIGNMENT_SHORTCUT"
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.Size = New System.Drawing.Size(75, 26)
        Me.cmbOVERLAY_ALIGNMENT_SHORTCUT.TabIndex = 11
        '
        'chkOVERLAY_VISBLE_SHORTCUT
        '
        Me.chkOVERLAY_VISBLE_SHORTCUT.AutoSize = True
        Me.chkOVERLAY_VISBLE_SHORTCUT.Checked = True
        Me.chkOVERLAY_VISBLE_SHORTCUT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOVERLAY_VISBLE_SHORTCUT.Enabled = False
        Me.chkOVERLAY_VISBLE_SHORTCUT.Location = New System.Drawing.Point(5, 4)
        Me.chkOVERLAY_VISBLE_SHORTCUT.Name = "chkOVERLAY_VISBLE_SHORTCUT"
        Me.chkOVERLAY_VISBLE_SHORTCUT.Size = New System.Drawing.Size(111, 22)
        Me.chkOVERLAY_VISBLE_SHORTCUT.TabIndex = 10
        Me.chkOVERLAY_VISBLE_SHORTCUT.Text = "ショートカット"
        Me.chkOVERLAY_VISBLE_SHORTCUT.UseVisualStyleBackColor = True
        '
        'pnlOVERLAY_VISBLE_THUMBNAIL
        '
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.Controls.Add(Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL)
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.Controls.Add(Me.chkOVERLAY_VISBLE_THUMBNAIL)
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.Location = New System.Drawing.Point(5, 125)
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.Name = "pnlOVERLAY_VISBLE_THUMBNAIL"
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.Size = New System.Drawing.Size(335, 30)
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.TabIndex = 4
        '
        'cmbOVERLAY_ALIGNMENT_THUMBNAIL
        '
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.FormattingEnabled = True
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.Items.AddRange(New Object() {"左上", "右上", "左下", "右下"})
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.Location = New System.Drawing.Point(130, 2)
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.Name = "cmbOVERLAY_ALIGNMENT_THUMBNAIL"
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.Size = New System.Drawing.Size(75, 26)
        Me.cmbOVERLAY_ALIGNMENT_THUMBNAIL.TabIndex = 13
        '
        'chkOVERLAY_VISBLE_THUMBNAIL
        '
        Me.chkOVERLAY_VISBLE_THUMBNAIL.AutoSize = True
        Me.chkOVERLAY_VISBLE_THUMBNAIL.Checked = True
        Me.chkOVERLAY_VISBLE_THUMBNAIL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOVERLAY_VISBLE_THUMBNAIL.Location = New System.Drawing.Point(5, 4)
        Me.chkOVERLAY_VISBLE_THUMBNAIL.Name = "chkOVERLAY_VISBLE_THUMBNAIL"
        Me.chkOVERLAY_VISBLE_THUMBNAIL.Size = New System.Drawing.Size(87, 22)
        Me.chkOVERLAY_VISBLE_THUMBNAIL.TabIndex = 10
        Me.chkOVERLAY_VISBLE_THUMBNAIL.Text = "サムネイル"
        Me.chkOVERLAY_VISBLE_THUMBNAIL.UseVisualStyleBackColor = True
        '
        'pnlOVERLAY_VISBLE_HISTOGRAM
        '
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.Controls.Add(Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM)
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.Controls.Add(Me.chkOVERLAY_VISBLE_HISTOGRAM)
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.Location = New System.Drawing.Point(5, 90)
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.Name = "pnlOVERLAY_VISBLE_HISTOGRAM"
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.Size = New System.Drawing.Size(335, 30)
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.TabIndex = 2
        '
        'cmbOVERLAY_ALIGNMENT_HISTOGRAM
        '
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.FormattingEnabled = True
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.Items.AddRange(New Object() {"左上", "右上", "左下", "右下"})
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.Location = New System.Drawing.Point(130, 2)
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.Name = "cmbOVERLAY_ALIGNMENT_HISTOGRAM"
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.Size = New System.Drawing.Size(75, 26)
        Me.cmbOVERLAY_ALIGNMENT_HISTOGRAM.TabIndex = 13
        '
        'chkOVERLAY_VISBLE_HISTOGRAM
        '
        Me.chkOVERLAY_VISBLE_HISTOGRAM.AutoSize = True
        Me.chkOVERLAY_VISBLE_HISTOGRAM.Checked = True
        Me.chkOVERLAY_VISBLE_HISTOGRAM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOVERLAY_VISBLE_HISTOGRAM.Location = New System.Drawing.Point(5, 4)
        Me.chkOVERLAY_VISBLE_HISTOGRAM.Name = "chkOVERLAY_VISBLE_HISTOGRAM"
        Me.chkOVERLAY_VISBLE_HISTOGRAM.Size = New System.Drawing.Size(99, 22)
        Me.chkOVERLAY_VISBLE_HISTOGRAM.TabIndex = 10
        Me.chkOVERLAY_VISBLE_HISTOGRAM.Text = "ヒストグラム"
        Me.chkOVERLAY_VISBLE_HISTOGRAM.UseVisualStyleBackColor = True
        '
        'pnlOVERLAY_VISBLE_CAPT_PARAM
        '
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.Controls.Add(Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM)
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.Controls.Add(Me.chkOVERLAY_VISBLE_CAPT_PARAM)
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.Location = New System.Drawing.Point(5, 55)
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.Name = "pnlOVERLAY_VISBLE_CAPT_PARAM"
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.Size = New System.Drawing.Size(335, 30)
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.TabIndex = 1
        '
        'cmbOVERLAY_ALIGNMENT_CAPT_PARAM
        '
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.FormattingEnabled = True
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.Items.AddRange(New Object() {"左上", "右上", "左下", "右下"})
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.Location = New System.Drawing.Point(130, 2)
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.Name = "cmbOVERLAY_ALIGNMENT_CAPT_PARAM"
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.Size = New System.Drawing.Size(75, 26)
        Me.cmbOVERLAY_ALIGNMENT_CAPT_PARAM.TabIndex = 12
        '
        'chkOVERLAY_VISBLE_CAPT_PARAM
        '
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.AutoSize = True
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.Checked = True
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.Location = New System.Drawing.Point(5, 4)
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.Name = "chkOVERLAY_VISBLE_CAPT_PARAM"
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.Size = New System.Drawing.Size(123, 22)
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.TabIndex = 10
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.Text = "パラメータ・状態"
        Me.chkOVERLAY_VISBLE_CAPT_PARAM.UseVisualStyleBackColor = True
        '
        'pnlOVERLAY_VISBLE_COMPOSITION
        '
        Me.pnlOVERLAY_VISBLE_COMPOSITION.Controls.Add(Me.chkOVERLAY_VISBLE_COMPOSITION)
        Me.pnlOVERLAY_VISBLE_COMPOSITION.Location = New System.Drawing.Point(5, 160)
        Me.pnlOVERLAY_VISBLE_COMPOSITION.Name = "pnlOVERLAY_VISBLE_COMPOSITION"
        Me.pnlOVERLAY_VISBLE_COMPOSITION.Size = New System.Drawing.Size(335, 30)
        Me.pnlOVERLAY_VISBLE_COMPOSITION.TabIndex = 0
        '
        'chkOVERLAY_VISBLE_COMPOSITION
        '
        Me.chkOVERLAY_VISBLE_COMPOSITION.AutoSize = True
        Me.chkOVERLAY_VISBLE_COMPOSITION.Checked = True
        Me.chkOVERLAY_VISBLE_COMPOSITION.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOVERLAY_VISBLE_COMPOSITION.Location = New System.Drawing.Point(5, 4)
        Me.chkOVERLAY_VISBLE_COMPOSITION.Name = "chkOVERLAY_VISBLE_COMPOSITION"
        Me.chkOVERLAY_VISBLE_COMPOSITION.Size = New System.Drawing.Size(75, 22)
        Me.chkOVERLAY_VISBLE_COMPOSITION.TabIndex = 10
        Me.chkOVERLAY_VISBLE_COMPOSITION.Text = "構図補助"
        Me.chkOVERLAY_VISBLE_COMPOSITION.UseVisualStyleBackColor = True
        '
        'TBP_ROTATE
        '
        Me.TBP_ROTATE.Controls.Add(Me.GRP_ROTATE_BUTTON_SETTING)
        Me.TBP_ROTATE.Controls.Add(Me.grpROTATE_SIZE)
        Me.TBP_ROTATE.Controls.Add(Me.grpROTATE_POSITION)
        Me.TBP_ROTATE.Location = New System.Drawing.Point(4, 27)
        Me.TBP_ROTATE.Name = "TBP_ROTATE"
        Me.TBP_ROTATE.Size = New System.Drawing.Size(362, 319)
        Me.TBP_ROTATE.TabIndex = 4
        Me.TBP_ROTATE.Text = "回転イメージ"
        Me.TBP_ROTATE.UseVisualStyleBackColor = True
        '
        'grpROTATE_SIZE
        '
        Me.grpROTATE_SIZE.Controls.Add(Me.btnROTATE_SIZE_INIT)
        Me.grpROTATE_SIZE.Controls.Add(Me.pnlROTATE_SIZE_H)
        Me.grpROTATE_SIZE.Controls.Add(Me.pnlROTATE_SIZE_W)
        Me.grpROTATE_SIZE.Location = New System.Drawing.Point(5, 70)
        Me.grpROTATE_SIZE.Name = "grpROTATE_SIZE"
        Me.grpROTATE_SIZE.Size = New System.Drawing.Size(350, 60)
        Me.grpROTATE_SIZE.TabIndex = 2
        Me.grpROTATE_SIZE.TabStop = False
        Me.grpROTATE_SIZE.Text = "サイズ"
        '
        'btnROTATE_SIZE_INIT
        '
        Me.btnROTATE_SIZE_INIT.Location = New System.Drawing.Point(290, 22)
        Me.btnROTATE_SIZE_INIT.Name = "btnROTATE_SIZE_INIT"
        Me.btnROTATE_SIZE_INIT.Size = New System.Drawing.Size(55, 25)
        Me.btnROTATE_SIZE_INIT.TabIndex = 3
        Me.btnROTATE_SIZE_INIT.Text = "初期化"
        Me.btnROTATE_SIZE_INIT.UseVisualStyleBackColor = True
        '
        'pnlROTATE_SIZE_H
        '
        Me.pnlROTATE_SIZE_H.Controls.Add(Me.lblROTATE_SIZE_H_GUIDE)
        Me.pnlROTATE_SIZE_H.Controls.Add(Me.txtROTATE_SIZE_H)
        Me.pnlROTATE_SIZE_H.Location = New System.Drawing.Point(150, 20)
        Me.pnlROTATE_SIZE_H.Name = "pnlROTATE_SIZE_H"
        Me.pnlROTATE_SIZE_H.Size = New System.Drawing.Size(130, 30)
        Me.pnlROTATE_SIZE_H.TabIndex = 1
        '
        'lblROTATE_SIZE_H_GUIDE
        '
        Me.lblROTATE_SIZE_H_GUIDE.AutoSize = True
        Me.lblROTATE_SIZE_H_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblROTATE_SIZE_H_GUIDE.Name = "lblROTATE_SIZE_H_GUIDE"
        Me.lblROTATE_SIZE_H_GUIDE.Size = New System.Drawing.Size(17, 18)
        Me.lblROTATE_SIZE_H_GUIDE.TabIndex = 4
        Me.lblROTATE_SIZE_H_GUIDE.Text = "H"
        '
        'txtROTATE_SIZE_H
        '
        Me.txtROTATE_SIZE_H.Location = New System.Drawing.Point(30, 3)
        Me.txtROTATE_SIZE_H.MaxLength = 6
        Me.txtROTATE_SIZE_H.Name = "txtROTATE_SIZE_H"
        Me.txtROTATE_SIZE_H.Size = New System.Drawing.Size(90, 25)
        Me.txtROTATE_SIZE_H.TabIndex = 5
        Me.txtROTATE_SIZE_H.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlROTATE_SIZE_W
        '
        Me.pnlROTATE_SIZE_W.Controls.Add(Me.lblROTATE_SIZE_W_GUIDE)
        Me.pnlROTATE_SIZE_W.Controls.Add(Me.txtROTATE_SIZE_W)
        Me.pnlROTATE_SIZE_W.Location = New System.Drawing.Point(5, 20)
        Me.pnlROTATE_SIZE_W.Name = "pnlROTATE_SIZE_W"
        Me.pnlROTATE_SIZE_W.Size = New System.Drawing.Size(130, 30)
        Me.pnlROTATE_SIZE_W.TabIndex = 0
        '
        'lblROTATE_SIZE_W_GUIDE
        '
        Me.lblROTATE_SIZE_W_GUIDE.AutoSize = True
        Me.lblROTATE_SIZE_W_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblROTATE_SIZE_W_GUIDE.Name = "lblROTATE_SIZE_W_GUIDE"
        Me.lblROTATE_SIZE_W_GUIDE.Size = New System.Drawing.Size(20, 18)
        Me.lblROTATE_SIZE_W_GUIDE.TabIndex = 2
        Me.lblROTATE_SIZE_W_GUIDE.Text = "W"
        '
        'txtROTATE_SIZE_W
        '
        Me.txtROTATE_SIZE_W.Location = New System.Drawing.Point(30, 3)
        Me.txtROTATE_SIZE_W.MaxLength = 6
        Me.txtROTATE_SIZE_W.Name = "txtROTATE_SIZE_W"
        Me.txtROTATE_SIZE_W.Size = New System.Drawing.Size(90, 25)
        Me.txtROTATE_SIZE_W.TabIndex = 3
        Me.txtROTATE_SIZE_W.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpROTATE_POSITION
        '
        Me.grpROTATE_POSITION.Controls.Add(Me.btnROTATE_POSITION_INIT)
        Me.grpROTATE_POSITION.Controls.Add(Me.pnlROTATE_POSITION_Y)
        Me.grpROTATE_POSITION.Controls.Add(Me.pnlROTATE_POSITION_X)
        Me.grpROTATE_POSITION.Location = New System.Drawing.Point(5, 5)
        Me.grpROTATE_POSITION.Name = "grpROTATE_POSITION"
        Me.grpROTATE_POSITION.Size = New System.Drawing.Size(350, 60)
        Me.grpROTATE_POSITION.TabIndex = 1
        Me.grpROTATE_POSITION.TabStop = False
        Me.grpROTATE_POSITION.Text = "位置"
        '
        'btnROTATE_POSITION_INIT
        '
        Me.btnROTATE_POSITION_INIT.Location = New System.Drawing.Point(290, 22)
        Me.btnROTATE_POSITION_INIT.Name = "btnROTATE_POSITION_INIT"
        Me.btnROTATE_POSITION_INIT.Size = New System.Drawing.Size(55, 25)
        Me.btnROTATE_POSITION_INIT.TabIndex = 3
        Me.btnROTATE_POSITION_INIT.Text = "初期化"
        Me.btnROTATE_POSITION_INIT.UseVisualStyleBackColor = True
        '
        'pnlROTATE_POSITION_Y
        '
        Me.pnlROTATE_POSITION_Y.Controls.Add(Me.lblROTATE_POSITION_Y_GUIDE)
        Me.pnlROTATE_POSITION_Y.Controls.Add(Me.txtROTATE_POSITION_Y)
        Me.pnlROTATE_POSITION_Y.Location = New System.Drawing.Point(150, 20)
        Me.pnlROTATE_POSITION_Y.Name = "pnlROTATE_POSITION_Y"
        Me.pnlROTATE_POSITION_Y.Size = New System.Drawing.Size(130, 30)
        Me.pnlROTATE_POSITION_Y.TabIndex = 1
        '
        'lblROTATE_POSITION_Y_GUIDE
        '
        Me.lblROTATE_POSITION_Y_GUIDE.AutoSize = True
        Me.lblROTATE_POSITION_Y_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblROTATE_POSITION_Y_GUIDE.Name = "lblROTATE_POSITION_Y_GUIDE"
        Me.lblROTATE_POSITION_Y_GUIDE.Size = New System.Drawing.Size(15, 18)
        Me.lblROTATE_POSITION_Y_GUIDE.TabIndex = 4
        Me.lblROTATE_POSITION_Y_GUIDE.Text = "y"
        '
        'txtROTATE_POSITION_Y
        '
        Me.txtROTATE_POSITION_Y.Location = New System.Drawing.Point(30, 3)
        Me.txtROTATE_POSITION_Y.MaxLength = 6
        Me.txtROTATE_POSITION_Y.Name = "txtROTATE_POSITION_Y"
        Me.txtROTATE_POSITION_Y.Size = New System.Drawing.Size(90, 25)
        Me.txtROTATE_POSITION_Y.TabIndex = 5
        Me.txtROTATE_POSITION_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlROTATE_POSITION_X
        '
        Me.pnlROTATE_POSITION_X.Controls.Add(Me.lblROTATE_POSITION_X_GUIDE)
        Me.pnlROTATE_POSITION_X.Controls.Add(Me.txtROTATE_POSITION_X)
        Me.pnlROTATE_POSITION_X.Location = New System.Drawing.Point(5, 20)
        Me.pnlROTATE_POSITION_X.Name = "pnlROTATE_POSITION_X"
        Me.pnlROTATE_POSITION_X.Size = New System.Drawing.Size(130, 30)
        Me.pnlROTATE_POSITION_X.TabIndex = 0
        '
        'lblROTATE_POSITION_X_GUIDE
        '
        Me.lblROTATE_POSITION_X_GUIDE.AutoSize = True
        Me.lblROTATE_POSITION_X_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblROTATE_POSITION_X_GUIDE.Name = "lblROTATE_POSITION_X_GUIDE"
        Me.lblROTATE_POSITION_X_GUIDE.Size = New System.Drawing.Size(15, 18)
        Me.lblROTATE_POSITION_X_GUIDE.TabIndex = 2
        Me.lblROTATE_POSITION_X_GUIDE.Text = "x"
        '
        'txtROTATE_POSITION_X
        '
        Me.txtROTATE_POSITION_X.Location = New System.Drawing.Point(30, 3)
        Me.txtROTATE_POSITION_X.MaxLength = 6
        Me.txtROTATE_POSITION_X.Name = "txtROTATE_POSITION_X"
        Me.txtROTATE_POSITION_X.Size = New System.Drawing.Size(90, 25)
        Me.txtROTATE_POSITION_X.TabIndex = 3
        Me.txtROTATE_POSITION_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TBP_LOGO
        '
        Me.TBP_LOGO.Controls.Add(Me.PNL_PATH_LOGO_FILE)
        Me.TBP_LOGO.Location = New System.Drawing.Point(4, 27)
        Me.TBP_LOGO.Name = "TBP_LOGO"
        Me.TBP_LOGO.Size = New System.Drawing.Size(362, 319)
        Me.TBP_LOGO.TabIndex = 7
        Me.TBP_LOGO.Text = "ロゴ"
        Me.TBP_LOGO.UseVisualStyleBackColor = True
        '
        'PNL_PATH_LOGO_FILE
        '
        Me.PNL_PATH_LOGO_FILE.Controls.Add(Me.TXT_PATH_LOGO_FILE)
        Me.PNL_PATH_LOGO_FILE.Controls.Add(Me.LBL_PATH_LOGO_FILE_GUIDE)
        Me.PNL_PATH_LOGO_FILE.Controls.Add(Me.BTN_REF_PATH_LOGO_FILE)
        Me.PNL_PATH_LOGO_FILE.Location = New System.Drawing.Point(5, 5)
        Me.PNL_PATH_LOGO_FILE.Name = "PNL_PATH_LOGO_FILE"
        Me.PNL_PATH_LOGO_FILE.Size = New System.Drawing.Size(350, 30)
        Me.PNL_PATH_LOGO_FILE.TabIndex = 3
        '
        'TXT_PATH_LOGO_FILE
        '
        Me.TXT_PATH_LOGO_FILE.Location = New System.Drawing.Point(85, 3)
        Me.TXT_PATH_LOGO_FILE.MaxLength = 255
        Me.TXT_PATH_LOGO_FILE.Name = "TXT_PATH_LOGO_FILE"
        Me.TXT_PATH_LOGO_FILE.Size = New System.Drawing.Size(180, 25)
        Me.TXT_PATH_LOGO_FILE.TabIndex = 4
        '
        'LBL_PATH_LOGO_FILE_GUIDE
        '
        Me.LBL_PATH_LOGO_FILE_GUIDE.AutoSize = True
        Me.LBL_PATH_LOGO_FILE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_PATH_LOGO_FILE_GUIDE.Name = "LBL_PATH_LOGO_FILE_GUIDE"
        Me.LBL_PATH_LOGO_FILE_GUIDE.Size = New System.Drawing.Size(80, 18)
        Me.LBL_PATH_LOGO_FILE_GUIDE.TabIndex = 0
        Me.LBL_PATH_LOGO_FILE_GUIDE.Text = "ロゴイメージ"
        '
        'BTN_REF_PATH_LOGO_FILE
        '
        Me.BTN_REF_PATH_LOGO_FILE.Location = New System.Drawing.Point(265, 3)
        Me.BTN_REF_PATH_LOGO_FILE.Name = "BTN_REF_PATH_LOGO_FILE"
        Me.BTN_REF_PATH_LOGO_FILE.Size = New System.Drawing.Size(40, 25)
        Me.BTN_REF_PATH_LOGO_FILE.TabIndex = 2
        Me.BTN_REF_PATH_LOGO_FILE.Text = "参照"
        Me.BTN_REF_PATH_LOGO_FILE.UseVisualStyleBackColor = True
        '
        'TBP_SAVE
        '
        Me.TBP_SAVE.Controls.Add(Me.pnlNAME_FILE)
        Me.TBP_SAVE.Controls.Add(Me.pnlNAME_FOLDER)
        Me.TBP_SAVE.Controls.Add(Me.pnlINDEX_FILE)
        Me.TBP_SAVE.Controls.Add(Me.pnlIMAGE_FORMAT)
        Me.TBP_SAVE.Controls.Add(Me.pnlPATH_SAVE)
        Me.TBP_SAVE.Location = New System.Drawing.Point(4, 27)
        Me.TBP_SAVE.Name = "TBP_SAVE"
        Me.TBP_SAVE.Padding = New System.Windows.Forms.Padding(3)
        Me.TBP_SAVE.Size = New System.Drawing.Size(362, 319)
        Me.TBP_SAVE.TabIndex = 1
        Me.TBP_SAVE.Text = "保存"
        Me.TBP_SAVE.UseVisualStyleBackColor = True
        '
        'pnlNAME_FILE
        '
        Me.pnlNAME_FILE.Controls.Add(Me.txtPATH_SAVE_FILE_NAME)
        Me.pnlNAME_FILE.Controls.Add(Me.lblPATH_SAVE_FILE_NAME_GUIDE)
        Me.pnlNAME_FILE.Location = New System.Drawing.Point(6, 75)
        Me.pnlNAME_FILE.Name = "pnlNAME_FILE"
        Me.pnlNAME_FILE.Size = New System.Drawing.Size(350, 30)
        Me.pnlNAME_FILE.TabIndex = 2
        '
        'txtPATH_SAVE_FILE_NAME
        '
        Me.txtPATH_SAVE_FILE_NAME.Location = New System.Drawing.Point(85, 3)
        Me.txtPATH_SAVE_FILE_NAME.MaxLength = 100
        Me.txtPATH_SAVE_FILE_NAME.Name = "txtPATH_SAVE_FILE_NAME"
        Me.txtPATH_SAVE_FILE_NAME.Size = New System.Drawing.Size(180, 25)
        Me.txtPATH_SAVE_FILE_NAME.TabIndex = 2
        '
        'lblPATH_SAVE_FILE_NAME_GUIDE
        '
        Me.lblPATH_SAVE_FILE_NAME_GUIDE.AutoSize = True
        Me.lblPATH_SAVE_FILE_NAME_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPATH_SAVE_FILE_NAME_GUIDE.Name = "lblPATH_SAVE_FILE_NAME_GUIDE"
        Me.lblPATH_SAVE_FILE_NAME_GUIDE.Size = New System.Drawing.Size(68, 18)
        Me.lblPATH_SAVE_FILE_NAME_GUIDE.TabIndex = 0
        Me.lblPATH_SAVE_FILE_NAME_GUIDE.Text = "ファイル名"
        '
        'pnlNAME_FOLDER
        '
        Me.pnlNAME_FOLDER.Controls.Add(Me.txtPATH_SAVE_FOLDER_NAME)
        Me.pnlNAME_FOLDER.Controls.Add(Me.lblPATH_SAVE_FOLDER_NAME_GUIDE)
        Me.pnlNAME_FOLDER.Location = New System.Drawing.Point(5, 40)
        Me.pnlNAME_FOLDER.Name = "pnlNAME_FOLDER"
        Me.pnlNAME_FOLDER.Size = New System.Drawing.Size(350, 30)
        Me.pnlNAME_FOLDER.TabIndex = 1
        '
        'txtPATH_SAVE_FOLDER_NAME
        '
        Me.txtPATH_SAVE_FOLDER_NAME.Location = New System.Drawing.Point(85, 3)
        Me.txtPATH_SAVE_FOLDER_NAME.MaxLength = 100
        Me.txtPATH_SAVE_FOLDER_NAME.Name = "txtPATH_SAVE_FOLDER_NAME"
        Me.txtPATH_SAVE_FOLDER_NAME.Size = New System.Drawing.Size(180, 25)
        Me.txtPATH_SAVE_FOLDER_NAME.TabIndex = 2
        '
        'lblPATH_SAVE_FOLDER_NAME_GUIDE
        '
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE.AutoSize = True
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE.Name = "lblPATH_SAVE_FOLDER_NAME_GUIDE"
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE.Size = New System.Drawing.Size(68, 18)
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE.TabIndex = 0
        Me.lblPATH_SAVE_FOLDER_NAME_GUIDE.Text = "フォルダ名"
        '
        'pnlINDEX_FILE
        '
        Me.pnlINDEX_FILE.Controls.Add(Me.txtIMAGE_INDEX)
        Me.pnlINDEX_FILE.Controls.Add(Me.lblIMAGE_INDEX_GUIDE)
        Me.pnlINDEX_FILE.Location = New System.Drawing.Point(5, 110)
        Me.pnlINDEX_FILE.Name = "pnlINDEX_FILE"
        Me.pnlINDEX_FILE.Size = New System.Drawing.Size(350, 30)
        Me.pnlINDEX_FILE.TabIndex = 3
        '
        'txtIMAGE_INDEX
        '
        Me.txtIMAGE_INDEX.Location = New System.Drawing.Point(85, 3)
        Me.txtIMAGE_INDEX.MaxLength = 5
        Me.txtIMAGE_INDEX.Name = "txtIMAGE_INDEX"
        Me.txtIMAGE_INDEX.Size = New System.Drawing.Size(100, 25)
        Me.txtIMAGE_INDEX.TabIndex = 2
        Me.txtIMAGE_INDEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIMAGE_INDEX_GUIDE
        '
        Me.lblIMAGE_INDEX_GUIDE.AutoSize = True
        Me.lblIMAGE_INDEX_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblIMAGE_INDEX_GUIDE.Name = "lblIMAGE_INDEX_GUIDE"
        Me.lblIMAGE_INDEX_GUIDE.Size = New System.Drawing.Size(80, 18)
        Me.lblIMAGE_INDEX_GUIDE.TabIndex = 0
        Me.lblIMAGE_INDEX_GUIDE.Text = "インデックス"
        '
        'pnlIMAGE_FORMAT
        '
        Me.pnlIMAGE_FORMAT.Controls.Add(Me.chkCOPYRIGHT)
        Me.pnlIMAGE_FORMAT.Controls.Add(Me.cmbIMAGE_FORMAT)
        Me.pnlIMAGE_FORMAT.Controls.Add(Me.lblIMAGE_FORMAT_GUIDE)
        Me.pnlIMAGE_FORMAT.Location = New System.Drawing.Point(5, 145)
        Me.pnlIMAGE_FORMAT.Name = "pnlIMAGE_FORMAT"
        Me.pnlIMAGE_FORMAT.Size = New System.Drawing.Size(350, 30)
        Me.pnlIMAGE_FORMAT.TabIndex = 4
        '
        'chkCOPYRIGHT
        '
        Me.chkCOPYRIGHT.AutoSize = True
        Me.chkCOPYRIGHT.Location = New System.Drawing.Point(160, 4)
        Me.chkCOPYRIGHT.Name = "chkCOPYRIGHT"
        Me.chkCOPYRIGHT.Size = New System.Drawing.Size(99, 22)
        Me.chkCOPYRIGHT.TabIndex = 2
        Me.chkCOPYRIGHT.Text = "コピーライト"
        Me.chkCOPYRIGHT.UseVisualStyleBackColor = True
        '
        'cmbIMAGE_FORMAT
        '
        Me.cmbIMAGE_FORMAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIMAGE_FORMAT.FormattingEnabled = True
        Me.cmbIMAGE_FORMAT.Items.AddRange(New Object() {"PNG", "JPEG", "TIFF"})
        Me.cmbIMAGE_FORMAT.Location = New System.Drawing.Point(85, 2)
        Me.cmbIMAGE_FORMAT.Name = "cmbIMAGE_FORMAT"
        Me.cmbIMAGE_FORMAT.Size = New System.Drawing.Size(60, 26)
        Me.cmbIMAGE_FORMAT.TabIndex = 1
        '
        'lblIMAGE_FORMAT_GUIDE
        '
        Me.lblIMAGE_FORMAT_GUIDE.AutoSize = True
        Me.lblIMAGE_FORMAT_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblIMAGE_FORMAT_GUIDE.Name = "lblIMAGE_FORMAT_GUIDE"
        Me.lblIMAGE_FORMAT_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblIMAGE_FORMAT_GUIDE.TabIndex = 0
        Me.lblIMAGE_FORMAT_GUIDE.Text = "保存形式"
        '
        'pnlPATH_SAVE
        '
        Me.pnlPATH_SAVE.Controls.Add(Me.btnOPEN_DIR)
        Me.pnlPATH_SAVE.Controls.Add(Me.lblPATH_SAVE_GUIDE)
        Me.pnlPATH_SAVE.Controls.Add(Me.btnPATH_SAVE_REF)
        Me.pnlPATH_SAVE.Controls.Add(Me.txtPATH_SAVE)
        Me.pnlPATH_SAVE.Location = New System.Drawing.Point(5, 5)
        Me.pnlPATH_SAVE.Name = "pnlPATH_SAVE"
        Me.pnlPATH_SAVE.Size = New System.Drawing.Size(350, 30)
        Me.pnlPATH_SAVE.TabIndex = 0
        '
        'btnOPEN_DIR
        '
        Me.btnOPEN_DIR.Location = New System.Drawing.Point(305, 3)
        Me.btnOPEN_DIR.Name = "btnOPEN_DIR"
        Me.btnOPEN_DIR.Size = New System.Drawing.Size(40, 25)
        Me.btnOPEN_DIR.TabIndex = 3
        Me.btnOPEN_DIR.Text = "開く"
        Me.btnOPEN_DIR.UseVisualStyleBackColor = True
        '
        'lblPATH_SAVE_GUIDE
        '
        Me.lblPATH_SAVE_GUIDE.AutoSize = True
        Me.lblPATH_SAVE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.lblPATH_SAVE_GUIDE.Name = "lblPATH_SAVE_GUIDE"
        Me.lblPATH_SAVE_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblPATH_SAVE_GUIDE.TabIndex = 0
        Me.lblPATH_SAVE_GUIDE.Text = "保存場所"
        '
        'btnPATH_SAVE_REF
        '
        Me.btnPATH_SAVE_REF.Location = New System.Drawing.Point(265, 3)
        Me.btnPATH_SAVE_REF.Name = "btnPATH_SAVE_REF"
        Me.btnPATH_SAVE_REF.Size = New System.Drawing.Size(40, 25)
        Me.btnPATH_SAVE_REF.TabIndex = 2
        Me.btnPATH_SAVE_REF.Text = "参照"
        Me.btnPATH_SAVE_REF.UseVisualStyleBackColor = True
        '
        'txtPATH_SAVE
        '
        Me.txtPATH_SAVE.Location = New System.Drawing.Point(85, 3)
        Me.txtPATH_SAVE.MaxLength = 255
        Me.txtPATH_SAVE.Name = "txtPATH_SAVE"
        Me.txtPATH_SAVE.Size = New System.Drawing.Size(180, 25)
        Me.txtPATH_SAVE.TabIndex = 1
        '
        'TBP_CAPT
        '
        Me.TBP_CAPT.Controls.Add(Me.pnlSEBD_KEYS_WAIT)
        Me.TBP_CAPT.Controls.Add(Me.pnlSOUND_CAPUTRE)
        Me.TBP_CAPT.Controls.Add(Me.pnlTIMER_CAPTURE)
        Me.TBP_CAPT.Controls.Add(Me.pnlINTERVAL_CAPTURE)
        Me.TBP_CAPT.Controls.Add(Me.pnlCOUNT_CAPTURE)
        Me.TBP_CAPT.Location = New System.Drawing.Point(4, 27)
        Me.TBP_CAPT.Name = "TBP_CAPT"
        Me.TBP_CAPT.Size = New System.Drawing.Size(362, 319)
        Me.TBP_CAPT.TabIndex = 2
        Me.TBP_CAPT.Text = "撮影"
        Me.TBP_CAPT.UseVisualStyleBackColor = True
        '
        'pnlSEBD_KEYS_WAIT
        '
        Me.pnlSEBD_KEYS_WAIT.Controls.Add(Me.cmbSEND_KEY)
        Me.pnlSEBD_KEYS_WAIT.Controls.Add(Me.lblINTERVAL_SEND_KEY_UNIT)
        Me.pnlSEBD_KEYS_WAIT.Controls.Add(Me.lblSEND_KEY_GUIDE)
        Me.pnlSEBD_KEYS_WAIT.Controls.Add(Me.txtINTERVAL_SEND_KEY)
        Me.pnlSEBD_KEYS_WAIT.Location = New System.Drawing.Point(5, 145)
        Me.pnlSEBD_KEYS_WAIT.Name = "pnlSEBD_KEYS_WAIT"
        Me.pnlSEBD_KEYS_WAIT.Size = New System.Drawing.Size(200, 30)
        Me.pnlSEBD_KEYS_WAIT.TabIndex = 9
        '
        'cmbSEND_KEY
        '
        Me.cmbSEND_KEY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSEND_KEY.FormattingEnabled = True
        Me.cmbSEND_KEY.Items.AddRange(New Object() {"無し", "←", "↑", "→", "↓", "W", "A", "S", "D"})
        Me.cmbSEND_KEY.Location = New System.Drawing.Point(60, 2)
        Me.cmbSEND_KEY.Name = "cmbSEND_KEY"
        Me.cmbSEND_KEY.Size = New System.Drawing.Size(60, 26)
        Me.cmbSEND_KEY.TabIndex = 3
        '
        'lblINTERVAL_SEND_KEY_UNIT
        '
        Me.lblINTERVAL_SEND_KEY_UNIT.AutoSize = True
        Me.lblINTERVAL_SEND_KEY_UNIT.Location = New System.Drawing.Point(170, 6)
        Me.lblINTERVAL_SEND_KEY_UNIT.Name = "lblINTERVAL_SEND_KEY_UNIT"
        Me.lblINTERVAL_SEND_KEY_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.lblINTERVAL_SEND_KEY_UNIT.TabIndex = 2
        Me.lblINTERVAL_SEND_KEY_UNIT.Text = "ms"
        '
        'lblSEND_KEY_GUIDE
        '
        Me.lblSEND_KEY_GUIDE.AutoSize = True
        Me.lblSEND_KEY_GUIDE.Location = New System.Drawing.Point(3, 6)
        Me.lblSEND_KEY_GUIDE.Name = "lblSEND_KEY_GUIDE"
        Me.lblSEND_KEY_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblSEND_KEY_GUIDE.TabIndex = 0
        Me.lblSEND_KEY_GUIDE.Text = "キー送信"
        '
        'txtINTERVAL_SEND_KEY
        '
        Me.txtINTERVAL_SEND_KEY.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtINTERVAL_SEND_KEY.Location = New System.Drawing.Point(130, 2)
        Me.txtINTERVAL_SEND_KEY.MaxLength = 5
        Me.txtINTERVAL_SEND_KEY.Name = "txtINTERVAL_SEND_KEY"
        Me.txtINTERVAL_SEND_KEY.Size = New System.Drawing.Size(40, 25)
        Me.txtINTERVAL_SEND_KEY.TabIndex = 1
        Me.txtINTERVAL_SEND_KEY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlSOUND_CAPUTRE
        '
        Me.pnlSOUND_CAPUTRE.Controls.Add(Me.chkSOUND_CAPTURE)
        Me.pnlSOUND_CAPUTRE.Location = New System.Drawing.Point(5, 5)
        Me.pnlSOUND_CAPUTRE.Name = "pnlSOUND_CAPUTRE"
        Me.pnlSOUND_CAPUTRE.Size = New System.Drawing.Size(150, 30)
        Me.pnlSOUND_CAPUTRE.TabIndex = 8
        '
        'chkSOUND_CAPTURE
        '
        Me.chkSOUND_CAPTURE.AutoSize = True
        Me.chkSOUND_CAPTURE.Location = New System.Drawing.Point(5, 4)
        Me.chkSOUND_CAPTURE.Name = "chkSOUND_CAPTURE"
        Me.chkSOUND_CAPTURE.Size = New System.Drawing.Size(63, 22)
        Me.chkSOUND_CAPTURE.TabIndex = 1
        Me.chkSOUND_CAPTURE.Text = "撮影音"
        Me.chkSOUND_CAPTURE.UseVisualStyleBackColor = True
        '
        'pnlTIMER_CAPTURE
        '
        Me.pnlTIMER_CAPTURE.Controls.Add(Me.lblTIMER_CAPTURE_UNIT)
        Me.pnlTIMER_CAPTURE.Controls.Add(Me.lblTIMER_CAPTURE_GUIDE)
        Me.pnlTIMER_CAPTURE.Controls.Add(Me.txtTIMER_CAPTURE)
        Me.pnlTIMER_CAPTURE.Location = New System.Drawing.Point(5, 75)
        Me.pnlTIMER_CAPTURE.Name = "pnlTIMER_CAPTURE"
        Me.pnlTIMER_CAPTURE.Size = New System.Drawing.Size(150, 30)
        Me.pnlTIMER_CAPTURE.TabIndex = 6
        '
        'lblTIMER_CAPTURE_UNIT
        '
        Me.lblTIMER_CAPTURE_UNIT.AutoSize = True
        Me.lblTIMER_CAPTURE_UNIT.Location = New System.Drawing.Point(100, 6)
        Me.lblTIMER_CAPTURE_UNIT.Name = "lblTIMER_CAPTURE_UNIT"
        Me.lblTIMER_CAPTURE_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.lblTIMER_CAPTURE_UNIT.TabIndex = 2
        Me.lblTIMER_CAPTURE_UNIT.Text = "ms"
        '
        'lblTIMER_CAPTURE_GUIDE
        '
        Me.lblTIMER_CAPTURE_GUIDE.AutoSize = True
        Me.lblTIMER_CAPTURE_GUIDE.Location = New System.Drawing.Point(3, 6)
        Me.lblTIMER_CAPTURE_GUIDE.Name = "lblTIMER_CAPTURE_GUIDE"
        Me.lblTIMER_CAPTURE_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblTIMER_CAPTURE_GUIDE.TabIndex = 0
        Me.lblTIMER_CAPTURE_GUIDE.Text = "タイマー"
        '
        'txtTIMER_CAPTURE
        '
        Me.txtTIMER_CAPTURE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTIMER_CAPTURE.Location = New System.Drawing.Point(60, 2)
        Me.txtTIMER_CAPTURE.MaxLength = 5
        Me.txtTIMER_CAPTURE.Name = "txtTIMER_CAPTURE"
        Me.txtTIMER_CAPTURE.Size = New System.Drawing.Size(40, 25)
        Me.txtTIMER_CAPTURE.TabIndex = 1
        Me.txtTIMER_CAPTURE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlINTERVAL_CAPTURE
        '
        Me.pnlINTERVAL_CAPTURE.Controls.Add(Me.lblINTERVAL_CAPTURE_UNIT)
        Me.pnlINTERVAL_CAPTURE.Controls.Add(Me.lblINTERVAL_CAPTURE_GUIDE)
        Me.pnlINTERVAL_CAPTURE.Controls.Add(Me.txtINTERVAL_CAPTURE)
        Me.pnlINTERVAL_CAPTURE.Location = New System.Drawing.Point(5, 110)
        Me.pnlINTERVAL_CAPTURE.Name = "pnlINTERVAL_CAPTURE"
        Me.pnlINTERVAL_CAPTURE.Size = New System.Drawing.Size(150, 30)
        Me.pnlINTERVAL_CAPTURE.TabIndex = 7
        '
        'lblINTERVAL_CAPTURE_UNIT
        '
        Me.lblINTERVAL_CAPTURE_UNIT.AutoSize = True
        Me.lblINTERVAL_CAPTURE_UNIT.Location = New System.Drawing.Point(100, 6)
        Me.lblINTERVAL_CAPTURE_UNIT.Name = "lblINTERVAL_CAPTURE_UNIT"
        Me.lblINTERVAL_CAPTURE_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.lblINTERVAL_CAPTURE_UNIT.TabIndex = 2
        Me.lblINTERVAL_CAPTURE_UNIT.Text = "ms"
        '
        'lblINTERVAL_CAPTURE_GUIDE
        '
        Me.lblINTERVAL_CAPTURE_GUIDE.AutoSize = True
        Me.lblINTERVAL_CAPTURE_GUIDE.Location = New System.Drawing.Point(3, 6)
        Me.lblINTERVAL_CAPTURE_GUIDE.Name = "lblINTERVAL_CAPTURE_GUIDE"
        Me.lblINTERVAL_CAPTURE_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblINTERVAL_CAPTURE_GUIDE.TabIndex = 0
        Me.lblINTERVAL_CAPTURE_GUIDE.Text = "撮影間隔"
        '
        'txtINTERVAL_CAPTURE
        '
        Me.txtINTERVAL_CAPTURE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtINTERVAL_CAPTURE.Location = New System.Drawing.Point(60, 2)
        Me.txtINTERVAL_CAPTURE.MaxLength = 5
        Me.txtINTERVAL_CAPTURE.Name = "txtINTERVAL_CAPTURE"
        Me.txtINTERVAL_CAPTURE.Size = New System.Drawing.Size(40, 25)
        Me.txtINTERVAL_CAPTURE.TabIndex = 1
        Me.txtINTERVAL_CAPTURE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlCOUNT_CAPTURE
        '
        Me.pnlCOUNT_CAPTURE.Controls.Add(Me.lblCOUNT_CAPTURE_UNIT)
        Me.pnlCOUNT_CAPTURE.Controls.Add(Me.lblCOUNT_CAPTURE_GUIDE)
        Me.pnlCOUNT_CAPTURE.Controls.Add(Me.txtCOUNT_CAPTURE)
        Me.pnlCOUNT_CAPTURE.Location = New System.Drawing.Point(5, 40)
        Me.pnlCOUNT_CAPTURE.Name = "pnlCOUNT_CAPTURE"
        Me.pnlCOUNT_CAPTURE.Size = New System.Drawing.Size(150, 30)
        Me.pnlCOUNT_CAPTURE.TabIndex = 5
        '
        'lblCOUNT_CAPTURE_UNIT
        '
        Me.lblCOUNT_CAPTURE_UNIT.AutoSize = True
        Me.lblCOUNT_CAPTURE_UNIT.Location = New System.Drawing.Point(100, 6)
        Me.lblCOUNT_CAPTURE_UNIT.Name = "lblCOUNT_CAPTURE_UNIT"
        Me.lblCOUNT_CAPTURE_UNIT.Size = New System.Drawing.Size(20, 18)
        Me.lblCOUNT_CAPTURE_UNIT.TabIndex = 2
        Me.lblCOUNT_CAPTURE_UNIT.Text = "枚"
        '
        'lblCOUNT_CAPTURE_GUIDE
        '
        Me.lblCOUNT_CAPTURE_GUIDE.AutoSize = True
        Me.lblCOUNT_CAPTURE_GUIDE.Location = New System.Drawing.Point(3, 6)
        Me.lblCOUNT_CAPTURE_GUIDE.Name = "lblCOUNT_CAPTURE_GUIDE"
        Me.lblCOUNT_CAPTURE_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.lblCOUNT_CAPTURE_GUIDE.TabIndex = 0
        Me.lblCOUNT_CAPTURE_GUIDE.Text = "撮影枚数"
        '
        'txtCOUNT_CAPTURE
        '
        Me.txtCOUNT_CAPTURE.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCOUNT_CAPTURE.Location = New System.Drawing.Point(60, 2)
        Me.txtCOUNT_CAPTURE.MaxLength = 4
        Me.txtCOUNT_CAPTURE.Name = "txtCOUNT_CAPTURE"
        Me.txtCOUNT_CAPTURE.Size = New System.Drawing.Size(40, 25)
        Me.txtCOUNT_CAPTURE.TabIndex = 1
        Me.txtCOUNT_CAPTURE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TBP_LIGHT
        '
        Me.TBP_LIGHT.Controls.Add(Me.GRP_LIGHT)
        Me.TBP_LIGHT.Location = New System.Drawing.Point(4, 27)
        Me.TBP_LIGHT.Name = "TBP_LIGHT"
        Me.TBP_LIGHT.Size = New System.Drawing.Size(362, 319)
        Me.TBP_LIGHT.TabIndex = 5
        Me.TBP_LIGHT.Text = "ライト"
        Me.TBP_LIGHT.UseVisualStyleBackColor = True
        '
        'GRP_LIGHT
        '
        Me.GRP_LIGHT.Controls.Add(Me.pnlLIGHT_ROTATE)
        Me.GRP_LIGHT.Controls.Add(Me.pnlLIGHT_DISTANCE)
        Me.GRP_LIGHT.Controls.Add(Me.PNL_ROTATE_LR)
        Me.GRP_LIGHT.Location = New System.Drawing.Point(10, 10)
        Me.GRP_LIGHT.Name = "GRP_LIGHT"
        Me.GRP_LIGHT.Size = New System.Drawing.Size(350, 130)
        Me.GRP_LIGHT.TabIndex = 2
        Me.GRP_LIGHT.TabStop = False
        Me.GRP_LIGHT.Text = "ライト1"
        '
        'pnlLIGHT_ROTATE
        '
        Me.pnlLIGHT_ROTATE.Controls.Add(Me.LBL_LIGHT_ROTATE_UD_UNIT)
        Me.pnlLIGHT_ROTATE.Controls.Add(Me.CMB_LIGHT_ROTATE_UD)
        Me.pnlLIGHT_ROTATE.Controls.Add(Me.LBL_LIGHT_ROTATE_UD_GUIDE)
        Me.pnlLIGHT_ROTATE.Controls.Add(Me.TXT_LIGHT_ROTATE_UD)
        Me.pnlLIGHT_ROTATE.Location = New System.Drawing.Point(5, 90)
        Me.pnlLIGHT_ROTATE.Name = "pnlLIGHT_ROTATE"
        Me.pnlLIGHT_ROTATE.Size = New System.Drawing.Size(300, 30)
        Me.pnlLIGHT_ROTATE.TabIndex = 2
        '
        'LBL_LIGHT_ROTATE_UD_UNIT
        '
        Me.LBL_LIGHT_ROTATE_UD_UNIT.AutoSize = True
        Me.LBL_LIGHT_ROTATE_UD_UNIT.Location = New System.Drawing.Point(205, 6)
        Me.LBL_LIGHT_ROTATE_UD_UNIT.Name = "LBL_LIGHT_ROTATE_UD_UNIT"
        Me.LBL_LIGHT_ROTATE_UD_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.LBL_LIGHT_ROTATE_UD_UNIT.TabIndex = 5
        Me.LBL_LIGHT_ROTATE_UD_UNIT.Text = "ms"
        '
        'CMB_LIGHT_ROTATE_UD
        '
        Me.CMB_LIGHT_ROTATE_UD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_LIGHT_ROTATE_UD.FormattingEnabled = True
        Me.CMB_LIGHT_ROTATE_UD.Items.AddRange(New Object() {"↑", "↓"})
        Me.CMB_LIGHT_ROTATE_UD.Location = New System.Drawing.Point(70, 2)
        Me.CMB_LIGHT_ROTATE_UD.Name = "CMB_LIGHT_ROTATE_UD"
        Me.CMB_LIGHT_ROTATE_UD.Size = New System.Drawing.Size(80, 26)
        Me.CMB_LIGHT_ROTATE_UD.TabIndex = 4
        '
        'LBL_LIGHT_ROTATE_UD_GUIDE
        '
        Me.LBL_LIGHT_ROTATE_UD_GUIDE.AutoSize = True
        Me.LBL_LIGHT_ROTATE_UD_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_LIGHT_ROTATE_UD_GUIDE.Name = "LBL_LIGHT_ROTATE_UD_GUIDE"
        Me.LBL_LIGHT_ROTATE_UD_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.LBL_LIGHT_ROTATE_UD_GUIDE.TabIndex = 2
        Me.LBL_LIGHT_ROTATE_UD_GUIDE.Text = "角度↑↓"
        '
        'TXT_LIGHT_ROTATE_UD
        '
        Me.TXT_LIGHT_ROTATE_UD.Location = New System.Drawing.Point(160, 2)
        Me.TXT_LIGHT_ROTATE_UD.MaxLength = 6
        Me.TXT_LIGHT_ROTATE_UD.Name = "TXT_LIGHT_ROTATE_UD"
        Me.TXT_LIGHT_ROTATE_UD.Size = New System.Drawing.Size(40, 25)
        Me.TXT_LIGHT_ROTATE_UD.TabIndex = 3
        Me.TXT_LIGHT_ROTATE_UD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlLIGHT_DISTANCE
        '
        Me.pnlLIGHT_DISTANCE.Controls.Add(Me.LBL_LIGHT_DISTANCE_UNIT)
        Me.pnlLIGHT_DISTANCE.Controls.Add(Me.CMB_LIGHT_DISTANCE)
        Me.pnlLIGHT_DISTANCE.Controls.Add(Me.LBL_LIGHT_DISTANCE_GUIDE)
        Me.pnlLIGHT_DISTANCE.Controls.Add(Me.TXT_LIGHT_DISTANCE)
        Me.pnlLIGHT_DISTANCE.Location = New System.Drawing.Point(5, 55)
        Me.pnlLIGHT_DISTANCE.Name = "pnlLIGHT_DISTANCE"
        Me.pnlLIGHT_DISTANCE.Size = New System.Drawing.Size(300, 30)
        Me.pnlLIGHT_DISTANCE.TabIndex = 1
        '
        'LBL_LIGHT_DISTANCE_UNIT
        '
        Me.LBL_LIGHT_DISTANCE_UNIT.AutoSize = True
        Me.LBL_LIGHT_DISTANCE_UNIT.Location = New System.Drawing.Point(205, 6)
        Me.LBL_LIGHT_DISTANCE_UNIT.Name = "LBL_LIGHT_DISTANCE_UNIT"
        Me.LBL_LIGHT_DISTANCE_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.LBL_LIGHT_DISTANCE_UNIT.TabIndex = 5
        Me.LBL_LIGHT_DISTANCE_UNIT.Text = "ms"
        '
        'CMB_LIGHT_DISTANCE
        '
        Me.CMB_LIGHT_DISTANCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_LIGHT_DISTANCE.FormattingEnabled = True
        Me.CMB_LIGHT_DISTANCE.Items.AddRange(New Object() {"PgUP", "PgDn"})
        Me.CMB_LIGHT_DISTANCE.Location = New System.Drawing.Point(70, 2)
        Me.CMB_LIGHT_DISTANCE.Name = "CMB_LIGHT_DISTANCE"
        Me.CMB_LIGHT_DISTANCE.Size = New System.Drawing.Size(80, 26)
        Me.CMB_LIGHT_DISTANCE.TabIndex = 4
        '
        'LBL_LIGHT_DISTANCE_GUIDE
        '
        Me.LBL_LIGHT_DISTANCE_GUIDE.AutoSize = True
        Me.LBL_LIGHT_DISTANCE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_LIGHT_DISTANCE_GUIDE.Name = "LBL_LIGHT_DISTANCE_GUIDE"
        Me.LBL_LIGHT_DISTANCE_GUIDE.Size = New System.Drawing.Size(32, 18)
        Me.LBL_LIGHT_DISTANCE_GUIDE.TabIndex = 2
        Me.LBL_LIGHT_DISTANCE_GUIDE.Text = "距離"
        '
        'TXT_LIGHT_DISTANCE
        '
        Me.TXT_LIGHT_DISTANCE.Location = New System.Drawing.Point(160, 2)
        Me.TXT_LIGHT_DISTANCE.MaxLength = 6
        Me.TXT_LIGHT_DISTANCE.Name = "TXT_LIGHT_DISTANCE"
        Me.TXT_LIGHT_DISTANCE.Size = New System.Drawing.Size(40, 25)
        Me.TXT_LIGHT_DISTANCE.TabIndex = 3
        Me.TXT_LIGHT_DISTANCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PNL_ROTATE_LR
        '
        Me.PNL_ROTATE_LR.Controls.Add(Me.LBL_LIGHT_ROTATE_LR_UNIT)
        Me.PNL_ROTATE_LR.Controls.Add(Me.CMB_LIGHT_ROTATE_LR)
        Me.PNL_ROTATE_LR.Controls.Add(Me.LBL_LIGHT_ROTATE_LR_GUIDE)
        Me.PNL_ROTATE_LR.Controls.Add(Me.TXT_LIGHT_ROTATE_LR)
        Me.PNL_ROTATE_LR.Location = New System.Drawing.Point(5, 20)
        Me.PNL_ROTATE_LR.Name = "PNL_ROTATE_LR"
        Me.PNL_ROTATE_LR.Size = New System.Drawing.Size(300, 30)
        Me.PNL_ROTATE_LR.TabIndex = 0
        '
        'LBL_LIGHT_ROTATE_LR_UNIT
        '
        Me.LBL_LIGHT_ROTATE_LR_UNIT.AutoSize = True
        Me.LBL_LIGHT_ROTATE_LR_UNIT.Location = New System.Drawing.Point(205, 6)
        Me.LBL_LIGHT_ROTATE_LR_UNIT.Name = "LBL_LIGHT_ROTATE_LR_UNIT"
        Me.LBL_LIGHT_ROTATE_LR_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.LBL_LIGHT_ROTATE_LR_UNIT.TabIndex = 5
        Me.LBL_LIGHT_ROTATE_LR_UNIT.Text = "ms"
        '
        'CMB_LIGHT_ROTATE_LR
        '
        Me.CMB_LIGHT_ROTATE_LR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_LIGHT_ROTATE_LR.FormattingEnabled = True
        Me.CMB_LIGHT_ROTATE_LR.Items.AddRange(New Object() {"←", "→"})
        Me.CMB_LIGHT_ROTATE_LR.Location = New System.Drawing.Point(70, 2)
        Me.CMB_LIGHT_ROTATE_LR.Name = "CMB_LIGHT_ROTATE_LR"
        Me.CMB_LIGHT_ROTATE_LR.Size = New System.Drawing.Size(80, 26)
        Me.CMB_LIGHT_ROTATE_LR.TabIndex = 4
        '
        'LBL_LIGHT_ROTATE_LR_GUIDE
        '
        Me.LBL_LIGHT_ROTATE_LR_GUIDE.AutoSize = True
        Me.LBL_LIGHT_ROTATE_LR_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_LIGHT_ROTATE_LR_GUIDE.Name = "LBL_LIGHT_ROTATE_LR_GUIDE"
        Me.LBL_LIGHT_ROTATE_LR_GUIDE.Size = New System.Drawing.Size(56, 18)
        Me.LBL_LIGHT_ROTATE_LR_GUIDE.TabIndex = 2
        Me.LBL_LIGHT_ROTATE_LR_GUIDE.Text = "角度←→"
        '
        'TXT_LIGHT_ROTATE_LR
        '
        Me.TXT_LIGHT_ROTATE_LR.Location = New System.Drawing.Point(160, 2)
        Me.TXT_LIGHT_ROTATE_LR.MaxLength = 6
        Me.TXT_LIGHT_ROTATE_LR.Name = "TXT_LIGHT_ROTATE_LR"
        Me.TXT_LIGHT_ROTATE_LR.Size = New System.Drawing.Size(40, 25)
        Me.TXT_LIGHT_ROTATE_LR.TabIndex = 3
        Me.TXT_LIGHT_ROTATE_LR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnINIT_SETTINGS
        '
        Me.btnINIT_SETTINGS.Location = New System.Drawing.Point(290, 360)
        Me.btnINIT_SETTINGS.Name = "btnINIT_SETTINGS"
        Me.btnINIT_SETTINGS.Size = New System.Drawing.Size(80, 25)
        Me.btnINIT_SETTINGS.TabIndex = 4
        Me.btnINIT_SETTINGS.Text = "全て初期化"
        Me.btnINIT_SETTINGS.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(120, 360)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 25)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCANCEL.Location = New System.Drawing.Point(205, 360)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 25)
        Me.btnCANCEL.TabIndex = 6
        Me.btnCANCEL.Text = "キャンセル"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'fbdPATH_SAVE
        '
        Me.fbdPATH_SAVE.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'GRP_ROTATE_BUTTON_SETTING
        '
        Me.GRP_ROTATE_BUTTON_SETTING.Controls.Add(Me.PNL_ROTATE_BUTTON_SENSITIVITY)
        Me.GRP_ROTATE_BUTTON_SETTING.Controls.Add(Me.Panel2)
        Me.GRP_ROTATE_BUTTON_SETTING.Location = New System.Drawing.Point(5, 130)
        Me.GRP_ROTATE_BUTTON_SETTING.Name = "GRP_ROTATE_BUTTON_SETTING"
        Me.GRP_ROTATE_BUTTON_SETTING.Size = New System.Drawing.Size(350, 60)
        Me.GRP_ROTATE_BUTTON_SETTING.TabIndex = 3
        Me.GRP_ROTATE_BUTTON_SETTING.TabStop = False
        Me.GRP_ROTATE_BUTTON_SETTING.Text = "ボタン"
        '
        'PNL_ROTATE_BUTTON_SENSITIVITY
        '
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.Controls.Add(Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.Controls.Add(Me.CMB_ROTATE_BUTTON_SENSITIVITY)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.Controls.Add(Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.Location = New System.Drawing.Point(150, 20)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.Name = "PNL_ROTATE_BUTTON_SENSITIVITY"
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.Size = New System.Drawing.Size(130, 30)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.TabIndex = 1
        '
        'LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE
        '
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE.AutoSize = True
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE.Name = "LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE"
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE.Size = New System.Drawing.Size(32, 18)
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE.TabIndex = 4
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE.Text = "感度"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CMB_ROTATE_BUTTON_SIZE)
        Me.Panel2.Controls.Add(Me.LBL_ROTATE_BUTTON_SIZE_GUIDE)
        Me.Panel2.Location = New System.Drawing.Point(5, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(130, 30)
        Me.Panel2.TabIndex = 0
        '
        'LBL_ROTATE_BUTTON_SIZE_GUIDE
        '
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE.AutoSize = True
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE.Location = New System.Drawing.Point(5, 6)
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE.Name = "LBL_ROTATE_BUTTON_SIZE_GUIDE"
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE.Size = New System.Drawing.Size(44, 18)
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE.TabIndex = 2
        Me.LBL_ROTATE_BUTTON_SIZE_GUIDE.Text = "サイズ"
        '
        'CMB_ROTATE_BUTTON_SIZE
        '
        Me.CMB_ROTATE_BUTTON_SIZE.FormattingEnabled = True
        Me.CMB_ROTATE_BUTTON_SIZE.Items.AddRange(New Object() {"32", "64", "96", "128"})
        Me.CMB_ROTATE_BUTTON_SIZE.Location = New System.Drawing.Point(50, 2)
        Me.CMB_ROTATE_BUTTON_SIZE.Name = "CMB_ROTATE_BUTTON_SIZE"
        Me.CMB_ROTATE_BUTTON_SIZE.Size = New System.Drawing.Size(70, 26)
        Me.CMB_ROTATE_BUTTON_SIZE.TabIndex = 5
        '
        'CMB_ROTATE_BUTTON_SENSITIVITY
        '
        Me.CMB_ROTATE_BUTTON_SENSITIVITY.FormattingEnabled = True
        Me.CMB_ROTATE_BUTTON_SENSITIVITY.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "60", "70", "80", "90", "100"})
        Me.CMB_ROTATE_BUTTON_SENSITIVITY.Location = New System.Drawing.Point(40, 2)
        Me.CMB_ROTATE_BUTTON_SENSITIVITY.Name = "CMB_ROTATE_BUTTON_SENSITIVITY"
        Me.CMB_ROTATE_BUTTON_SENSITIVITY.Size = New System.Drawing.Size(60, 26)
        Me.CMB_ROTATE_BUTTON_SENSITIVITY.TabIndex = 6
        '
        'LBL_ROTATE_BUTTON_SENSITIVITY_UNIT
        '
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT.AutoSize = True
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT.Location = New System.Drawing.Point(100, 6)
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT.Name = "LBL_ROTATE_BUTTON_SENSITIVITY_UNIT"
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT.Size = New System.Drawing.Size(26, 18)
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT.TabIndex = 7
        Me.LBL_ROTATE_BUTTON_SENSITIVITY_UNIT.Text = "ms"
        '
        'FRM_SETTING
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCANCEL
        Me.ClientSize = New System.Drawing.Size(374, 391)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnINIT_SETTINGS)
        Me.Controls.Add(Me.TBC_SETTING)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_SETTING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "設定"
        Me.TBC_SETTING.ResumeLayout(False)
        Me.TBP_KEYBORD.ResumeLayout(False)
        Me.grpHOT_KEY.ResumeLayout(False)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.ResumeLayout(False)
        Me.pnlHOT_KEY_CAPT_ONE_SNS.PerformLayout()
        Me.pnlHOT_KEY_ROTATE.ResumeLayout(False)
        Me.pnlHOT_KEY_ROTATE.PerformLayout()
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.ResumeLayout(False)
        Me.pnlHOT_KEY_CHANGE_COMPOSITION.PerformLayout()
        Me.pnlHOT_KEY_CAPT.ResumeLayout(False)
        Me.pnlHOT_KEY_CAPT.PerformLayout()
        Me.pnlHOT_KEY_CAPT_ONE.ResumeLayout(False)
        Me.pnlHOT_KEY_CAPT_ONE.PerformLayout()
        Me.TBP_JOYPAD.ResumeLayout(False)
        Me.groJOY_STICK.ResumeLayout(False)
        Me.pnlPAD_CAPT_ONE_SNS.ResumeLayout(False)
        Me.pnlPAD_CAPT_ONE_SNS.PerformLayout()
        Me.pnlPAD_VIEW_ROTATE.ResumeLayout(False)
        Me.pnlPAD_VIEW_ROTATE.PerformLayout()
        Me.pnlPAD_VIEW_COMPOSITION.ResumeLayout(False)
        Me.pnlPAD_VIEW_COMPOSITION.PerformLayout()
        Me.pnlPAD_CAPT.ResumeLayout(False)
        Me.pnlPAD_CAPT.PerformLayout()
        Me.pnlPAD_USE.ResumeLayout(False)
        Me.pnlPAD_USE.PerformLayout()
        Me.pnlPAD_CAPT_ONE.ResumeLayout(False)
        Me.pnlPAD_CAPT_ONE.PerformLayout()
        Me.TBP_OVERLAY.ResumeLayout(False)
        Me.grpOVERLAY_THUMBNAIL.ResumeLayout(False)
        Me.grpOVERLAY_THUMBNAIL_COUNT.ResumeLayout(False)
        Me.grpOVERLAY_THUMBNAIL_COUNT.PerformLayout()
        CType(Me.nudOVERLAY_THUMBNAIL_COUNT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOVERLAY_COMPOSITION.ResumeLayout(False)
        Me.pnlOVERLAY_COMPOSITION_TYPE.ResumeLayout(False)
        Me.pnlOVERLAY_COMPOSITION_TYPE.PerformLayout()
        Me.grpOVERLAY_VISIBLE.ResumeLayout(False)
        Me.pnlOVERLAY_VISBLE_SHORTCUT.ResumeLayout(False)
        Me.pnlOVERLAY_VISBLE_SHORTCUT.PerformLayout()
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.ResumeLayout(False)
        Me.pnlOVERLAY_VISBLE_THUMBNAIL.PerformLayout()
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.ResumeLayout(False)
        Me.pnlOVERLAY_VISBLE_HISTOGRAM.PerformLayout()
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.ResumeLayout(False)
        Me.pnlOVERLAY_VISBLE_CAPT_PARAM.PerformLayout()
        Me.pnlOVERLAY_VISBLE_COMPOSITION.ResumeLayout(False)
        Me.pnlOVERLAY_VISBLE_COMPOSITION.PerformLayout()
        Me.TBP_ROTATE.ResumeLayout(False)
        Me.grpROTATE_SIZE.ResumeLayout(False)
        Me.pnlROTATE_SIZE_H.ResumeLayout(False)
        Me.pnlROTATE_SIZE_H.PerformLayout()
        Me.pnlROTATE_SIZE_W.ResumeLayout(False)
        Me.pnlROTATE_SIZE_W.PerformLayout()
        Me.grpROTATE_POSITION.ResumeLayout(False)
        Me.pnlROTATE_POSITION_Y.ResumeLayout(False)
        Me.pnlROTATE_POSITION_Y.PerformLayout()
        Me.pnlROTATE_POSITION_X.ResumeLayout(False)
        Me.pnlROTATE_POSITION_X.PerformLayout()
        Me.TBP_LOGO.ResumeLayout(False)
        Me.PNL_PATH_LOGO_FILE.ResumeLayout(False)
        Me.PNL_PATH_LOGO_FILE.PerformLayout()
        Me.TBP_SAVE.ResumeLayout(False)
        Me.pnlNAME_FILE.ResumeLayout(False)
        Me.pnlNAME_FILE.PerformLayout()
        Me.pnlNAME_FOLDER.ResumeLayout(False)
        Me.pnlNAME_FOLDER.PerformLayout()
        Me.pnlINDEX_FILE.ResumeLayout(False)
        Me.pnlINDEX_FILE.PerformLayout()
        Me.pnlIMAGE_FORMAT.ResumeLayout(False)
        Me.pnlIMAGE_FORMAT.PerformLayout()
        Me.pnlPATH_SAVE.ResumeLayout(False)
        Me.pnlPATH_SAVE.PerformLayout()
        Me.TBP_CAPT.ResumeLayout(False)
        Me.pnlSEBD_KEYS_WAIT.ResumeLayout(False)
        Me.pnlSEBD_KEYS_WAIT.PerformLayout()
        Me.pnlSOUND_CAPUTRE.ResumeLayout(False)
        Me.pnlSOUND_CAPUTRE.PerformLayout()
        Me.pnlTIMER_CAPTURE.ResumeLayout(False)
        Me.pnlTIMER_CAPTURE.PerformLayout()
        Me.pnlINTERVAL_CAPTURE.ResumeLayout(False)
        Me.pnlINTERVAL_CAPTURE.PerformLayout()
        Me.pnlCOUNT_CAPTURE.ResumeLayout(False)
        Me.pnlCOUNT_CAPTURE.PerformLayout()
        Me.TBP_LIGHT.ResumeLayout(False)
        Me.GRP_LIGHT.ResumeLayout(False)
        Me.pnlLIGHT_ROTATE.ResumeLayout(False)
        Me.pnlLIGHT_ROTATE.PerformLayout()
        Me.pnlLIGHT_DISTANCE.ResumeLayout(False)
        Me.pnlLIGHT_DISTANCE.PerformLayout()
        Me.PNL_ROTATE_LR.ResumeLayout(False)
        Me.PNL_ROTATE_LR.PerformLayout()
        Me.GRP_ROTATE_BUTTON_SETTING.ResumeLayout(False)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.ResumeLayout(False)
        Me.PNL_ROTATE_BUTTON_SENSITIVITY.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TBC_SETTING As System.Windows.Forms.TabControl
    Friend WithEvents TBP_KEYBORD As TabPage
    Friend WithEvents TBP_CAPT As TabPage
    Friend WithEvents TBP_SAVE As TabPage
    Friend WithEvents pnlIMAGE_FORMAT As System.Windows.Forms.Panel
    Friend WithEvents cmbIMAGE_FORMAT As System.Windows.Forms.ComboBox
    Friend WithEvents lblIMAGE_FORMAT_GUIDE As System.Windows.Forms.Label
    Friend WithEvents pnlPATH_SAVE As System.Windows.Forms.Panel
    Friend WithEvents btnOPEN_DIR As System.Windows.Forms.Button
    Friend WithEvents lblPATH_SAVE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents btnPATH_SAVE_REF As System.Windows.Forms.Button
    Friend WithEvents txtPATH_SAVE As System.Windows.Forms.TextBox
    Friend WithEvents pnlSOUND_CAPUTRE As System.Windows.Forms.Panel
    Friend WithEvents chkSOUND_CAPTURE As System.Windows.Forms.CheckBox
    Friend WithEvents pnlTIMER_CAPTURE As System.Windows.Forms.Panel
    Friend WithEvents lblTIMER_CAPTURE_UNIT As System.Windows.Forms.Label
    Friend WithEvents lblTIMER_CAPTURE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtTIMER_CAPTURE As System.Windows.Forms.TextBox
    Friend WithEvents pnlINTERVAL_CAPTURE As System.Windows.Forms.Panel
    Friend WithEvents lblINTERVAL_CAPTURE_UNIT As System.Windows.Forms.Label
    Friend WithEvents lblINTERVAL_CAPTURE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtINTERVAL_CAPTURE As System.Windows.Forms.TextBox
    Friend WithEvents pnlCOUNT_CAPTURE As System.Windows.Forms.Panel
    Friend WithEvents lblCOUNT_CAPTURE_UNIT As System.Windows.Forms.Label
    Friend WithEvents lblCOUNT_CAPTURE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtCOUNT_CAPTURE As System.Windows.Forms.TextBox
    Friend WithEvents grpHOT_KEY As System.Windows.Forms.GroupBox
    Friend WithEvents pnlHOT_KEY_CAPT_ONE As System.Windows.Forms.Panel
    Friend WithEvents cmbHOT_KEY_CAPT_ONE As System.Windows.Forms.ComboBox
    Friend WithEvents lblHOT_KEY_CAPT_ONE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents pnlHOT_KEY_CAPT As System.Windows.Forms.Panel
    Friend WithEvents cmbHOT_KEY_CAPT As System.Windows.Forms.ComboBox
    Friend WithEvents lblHOT_KEY_CAPT_GUIDE As System.Windows.Forms.Label
    Friend WithEvents btnINIT_SETTINGS As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents fbdPATH_SAVE As FolderBrowserDialog
    Friend WithEvents pnlINDEX_FILE As System.Windows.Forms.Panel
    Friend WithEvents txtIMAGE_INDEX As System.Windows.Forms.TextBox
    Friend WithEvents lblIMAGE_INDEX_GUIDE As System.Windows.Forms.Label
    Friend WithEvents pnlNAME_FOLDER As System.Windows.Forms.Panel
    Friend WithEvents txtPATH_SAVE_FOLDER_NAME As System.Windows.Forms.TextBox
    Friend WithEvents lblPATH_SAVE_FOLDER_NAME_GUIDE As System.Windows.Forms.Label
    Friend WithEvents pnlNAME_FILE As System.Windows.Forms.Panel
    Friend WithEvents txtPATH_SAVE_FILE_NAME As System.Windows.Forms.TextBox
    Friend WithEvents lblPATH_SAVE_FILE_NAME_GUIDE As System.Windows.Forms.Label
    Friend WithEvents pnlHOT_KEY_CHANGE_COMPOSITION As System.Windows.Forms.Panel
    Friend WithEvents cmbHOT_KEY_CHANGE_COMPOSITION As System.Windows.Forms.ComboBox
    Friend WithEvents lblHOT_KEY_CHANGE_COMPOSITION_GUIDE As System.Windows.Forms.Label
    Friend WithEvents TBP_OVERLAY As TabPage
    Friend WithEvents grpOVERLAY_VISIBLE As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOVERLAY_VISBLE_COMPOSITION As System.Windows.Forms.Panel
    Friend WithEvents chkOVERLAY_VISBLE_COMPOSITION As System.Windows.Forms.CheckBox
    Friend WithEvents pnlOVERLAY_VISBLE_THUMBNAIL As System.Windows.Forms.Panel
    Friend WithEvents chkOVERLAY_VISBLE_THUMBNAIL As System.Windows.Forms.CheckBox
    Friend WithEvents pnlOVERLAY_VISBLE_HISTOGRAM As System.Windows.Forms.Panel
    Friend WithEvents chkOVERLAY_VISBLE_HISTOGRAM As System.Windows.Forms.CheckBox
    Friend WithEvents pnlOVERLAY_VISBLE_CAPT_PARAM As System.Windows.Forms.Panel
    Friend WithEvents chkOVERLAY_VISBLE_CAPT_PARAM As System.Windows.Forms.CheckBox
    Friend WithEvents grpOVERLAY_COMPOSITION As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOVERLAY_COMPOSITION_TYPE As System.Windows.Forms.Panel
    Friend WithEvents cmbOVERLAY_COMPOSITION_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents lblOVERLAY_COMPOSITION_TYPE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents grpOVERLAY_THUMBNAIL As System.Windows.Forms.GroupBox
    Friend WithEvents grpOVERLAY_THUMBNAIL_COUNT As System.Windows.Forms.Panel
    Friend WithEvents lblOVERLAY_THUMBNAIL_COUNT_GUIDE As System.Windows.Forms.Label
    Friend WithEvents nudOVERLAY_THUMBNAIL_COUNT As NumericUpDown
    Friend WithEvents TBP_ROTATE As TabPage
    Friend WithEvents grpROTATE_POSITION As System.Windows.Forms.GroupBox
    Friend WithEvents pnlROTATE_POSITION_Y As System.Windows.Forms.Panel
    Friend WithEvents pnlROTATE_POSITION_X As System.Windows.Forms.Panel
    Friend WithEvents lblROTATE_POSITION_X_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtROTATE_POSITION_X As System.Windows.Forms.TextBox
    Friend WithEvents lblROTATE_POSITION_Y_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtROTATE_POSITION_Y As System.Windows.Forms.TextBox
    Friend WithEvents btnROTATE_POSITION_INIT As System.Windows.Forms.Button
    Friend WithEvents grpROTATE_SIZE As System.Windows.Forms.GroupBox
    Friend WithEvents btnROTATE_SIZE_INIT As System.Windows.Forms.Button
    Friend WithEvents pnlROTATE_SIZE_H As System.Windows.Forms.Panel
    Friend WithEvents lblROTATE_SIZE_H_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtROTATE_SIZE_H As System.Windows.Forms.TextBox
    Friend WithEvents pnlROTATE_SIZE_W As System.Windows.Forms.Panel
    Friend WithEvents lblROTATE_SIZE_W_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtROTATE_SIZE_W As System.Windows.Forms.TextBox
    Friend WithEvents pnlHOT_KEY_ROTATE As System.Windows.Forms.Panel
    Friend WithEvents cmbHOT_KEY_ROTATE As System.Windows.Forms.ComboBox
    Friend WithEvents lblHOT_KEY_ROTATE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents pnlSEBD_KEYS_WAIT As System.Windows.Forms.Panel
    Friend WithEvents lblINTERVAL_SEND_KEY_UNIT As System.Windows.Forms.Label
    Friend WithEvents lblSEND_KEY_GUIDE As System.Windows.Forms.Label
    Friend WithEvents txtINTERVAL_SEND_KEY As System.Windows.Forms.TextBox
    Friend WithEvents cmbSEND_KEY As System.Windows.Forms.ComboBox
    Friend WithEvents chkCOPYRIGHT As System.Windows.Forms.CheckBox
    Friend WithEvents pnlOVERLAY_VISBLE_SHORTCUT As System.Windows.Forms.Panel
    Friend WithEvents chkOVERLAY_VISBLE_SHORTCUT As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOVERLAY_ALIGNMENT_SHORTCUT As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOVERLAY_ALIGNMENT_CAPT_PARAM As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOVERLAY_ALIGNMENT_THUMBNAIL As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOVERLAY_ALIGNMENT_HISTOGRAM As System.Windows.Forms.ComboBox
    Friend WithEvents TBP_LIGHT As System.Windows.Forms.TabPage
    Friend WithEvents GRP_LIGHT As System.Windows.Forms.GroupBox
    Friend WithEvents PNL_ROTATE_LR As System.Windows.Forms.Panel
    Friend WithEvents LBL_LIGHT_ROTATE_LR_GUIDE As System.Windows.Forms.Label
    Friend WithEvents TXT_LIGHT_ROTATE_LR As System.Windows.Forms.TextBox
    Friend WithEvents CMB_LIGHT_ROTATE_LR As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_LIGHT_ROTATE_LR_UNIT As System.Windows.Forms.Label
    Friend WithEvents pnlLIGHT_DISTANCE As System.Windows.Forms.Panel
    Friend WithEvents LBL_LIGHT_DISTANCE_UNIT As System.Windows.Forms.Label
    Friend WithEvents CMB_LIGHT_DISTANCE As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_LIGHT_DISTANCE_GUIDE As System.Windows.Forms.Label
    Friend WithEvents TXT_LIGHT_DISTANCE As System.Windows.Forms.TextBox
    Friend WithEvents pnlLIGHT_ROTATE As System.Windows.Forms.Panel
    Friend WithEvents LBL_LIGHT_ROTATE_UD_UNIT As System.Windows.Forms.Label
    Friend WithEvents CMB_LIGHT_ROTATE_UD As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_LIGHT_ROTATE_UD_GUIDE As System.Windows.Forms.Label
    Friend WithEvents TXT_LIGHT_ROTATE_UD As System.Windows.Forms.TextBox
    Friend WithEvents cmbHOT_MASK_CAPT_ONE As Forms.ComboBox
    Friend WithEvents cmbHOT_MASK_ROTATE As Forms.ComboBox
    Friend WithEvents cmbHOT_MASK_CHANGE_COMPOSITION As Forms.ComboBox
    Friend WithEvents cmbHOT_MASK_CAPT As Forms.ComboBox
    Friend WithEvents TBP_JOYPAD As TabPage
    Friend WithEvents groJOY_STICK As Forms.GroupBox
    Friend WithEvents pnlPAD_VIEW_ROTATE As Forms.Panel
    Friend WithEvents cmbPAD_VIEW_ROTATE As Forms.ComboBox
    Friend WithEvents lblPAD_ROTATE_GUIDE As Forms.Label
    Friend WithEvents pnlPAD_VIEW_COMPOSITION As Forms.Panel
    Friend WithEvents cmbPAD_VIEW_OVERLAY As Forms.ComboBox
    Friend WithEvents lblPAD_CHANGE_COMPOSITION_GUIDE As Forms.Label
    Friend WithEvents pnlPAD_CAPT As Forms.Panel
    Friend WithEvents cmbPAD_CAPT As Forms.ComboBox
    Friend WithEvents lblPAD_CAPT_GUIDE As Forms.Label
    Friend WithEvents pnlPAD_USE As Forms.Panel
    Friend WithEvents pnlPAD_CAPT_ONE As Forms.Panel
    Friend WithEvents lblPAD_CAPT_ONE_GUIDE As Forms.Label
    Friend WithEvents cmbPAD_CAPT_ONE As Forms.ComboBox
    Friend WithEvents lblKIND_JOY_STICK_GUIDE As Forms.Label
    Friend WithEvents cmbKIND_JOY_STICK As Forms.ComboBox
    Friend WithEvents cmbJOY_MOD_VIEW_ROTATE As Forms.ComboBox
    Friend WithEvents cmbJOY_MOD_VIEW_OVERLAY As Forms.ComboBox
    Friend WithEvents cmbJOY_MOD_CAPT As Forms.ComboBox
    Friend WithEvents cmbJOY_MOD_CAPT_ONE As Forms.ComboBox
    Friend WithEvents pnlPAD_CAPT_ONE_SNS As Forms.Panel
    Friend WithEvents cmbJOY_MOD_CAPT_ONE_SNS As Forms.ComboBox
    Friend WithEvents lblPAD_CAPT_ONE_SNS_GUIDE As Forms.Label
    Friend WithEvents cmbPAD_CAPT_ONE_SNS As Forms.ComboBox
    Friend WithEvents pnlHOT_KEY_CAPT_ONE_SNS As Forms.Panel
    Friend WithEvents cmbHOT_MASK_CAPT_ONE_SNS As Forms.ComboBox
    Friend WithEvents cmbHOT_KEY_CAPT_ONE_SNS As Forms.ComboBox
    Friend WithEvents lblHOT_KEY_CAPT_ONE_SNS_GUIDE As Forms.Label
    Friend WithEvents TBP_LOGO As TabPage
    Friend WithEvents PNL_PATH_LOGO_FILE As Forms.Panel
    Friend WithEvents TXT_PATH_LOGO_FILE As Forms.TextBox
    Friend WithEvents LBL_PATH_LOGO_FILE_GUIDE As Forms.Label
    Friend WithEvents BTN_REF_PATH_LOGO_FILE As Forms.Button
    Friend WithEvents GRP_ROTATE_BUTTON_SETTING As Forms.GroupBox
    Friend WithEvents PNL_ROTATE_BUTTON_SENSITIVITY As Forms.Panel
    Friend WithEvents LBL_ROTATE_BUTTON_SENSITIVITY_GUIDE As Forms.Label
    Friend WithEvents Panel2 As Forms.Panel
    Friend WithEvents CMB_ROTATE_BUTTON_SIZE As Forms.ComboBox
    Friend WithEvents LBL_ROTATE_BUTTON_SIZE_GUIDE As Forms.Label
    Friend WithEvents CMB_ROTATE_BUTTON_SENSITIVITY As Forms.ComboBox
    Friend WithEvents LBL_ROTATE_BUTTON_SENSITIVITY_UNIT As Forms.Label
End Class
