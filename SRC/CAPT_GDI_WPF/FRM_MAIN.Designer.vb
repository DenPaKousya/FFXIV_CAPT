﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_MAIN
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
        Me.components = New System.ComponentModel.Container()
        Me.NTI_TASK = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CMS_MENU = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSM_CAPT_ONE = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_CAPT = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_OVERLAY = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_ROTATE = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_TRIM = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_LOGO = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_SETTING = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_EXIT = New System.Windows.Forms.ToolStripMenuItem()
        Me.TIM_CHECK_PROCESS = New System.Windows.Forms.Timer(Me.components)
        Me.TSM_BLANK = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSS1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_THUMBNAIL = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_MENU.SuspendLayout()
        Me.SuspendLayout()
        '
        'NTI_TASK
        '
        Me.NTI_TASK.ContextMenuStrip = Me.CMS_MENU
        Me.NTI_TASK.Visible = True
        '
        'CMS_MENU
        '
        Me.CMS_MENU.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CMS_MENU.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_CAPT_ONE, Me.TSM_CAPT, Me.TSS1, Me.TSM_OVERLAY, Me.TSM_ROTATE, Me.TSM_TRIM, Me.TSM_LOGO, Me.TSM_THUMBNAIL, Me.TSS2, Me.TSM_SETTING, Me.TSS3, Me.TSM_EXIT, Me.TSS4, Me.TSM_BLANK})
        Me.CMS_MENU.Name = "CMS_MENU"
        Me.CMS_MENU.Size = New System.Drawing.Size(149, 248)
        '
        'TSM_CAPT_ONE
        '
        Me.TSM_CAPT_ONE.Name = "TSM_CAPT_ONE"
        Me.TSM_CAPT_ONE.Size = New System.Drawing.Size(160, 22)
        Me.TSM_CAPT_ONE.Text = "撮影"
        '
        'TSM_CAPT
        '
        Me.TSM_CAPT.Name = "TSM_CAPT"
        Me.TSM_CAPT.Size = New System.Drawing.Size(160, 22)
        Me.TSM_CAPT.Text = "連続撮影"
        '
        'TSM_OVERLAY
        '
        Me.TSM_OVERLAY.Name = "TSM_OVERLAY"
        Me.TSM_OVERLAY.Size = New System.Drawing.Size(160, 22)
        Me.TSM_OVERLAY.Text = "オーバーレイ"
        '
        'TSM_ROTATE
        '
        Me.TSM_ROTATE.Name = "TSM_ROTATE"
        Me.TSM_ROTATE.Size = New System.Drawing.Size(160, 22)
        Me.TSM_ROTATE.Text = "回転イメージ"
        '
        'TSM_TRIM
        '
        Me.TSM_TRIM.Name = "TSM_TRIM"
        Me.TSM_TRIM.Size = New System.Drawing.Size(160, 22)
        Me.TSM_TRIM.Text = "トリミング"
        '
        'TSM_LOGO
        '
        Me.TSM_LOGO.Name = "TSM_LOGO"
        Me.TSM_LOGO.Size = New System.Drawing.Size(160, 22)
        Me.TSM_LOGO.Text = "ロゴ"
        '
        'TSS2
        '
        Me.TSS2.Name = "TSS2"
        Me.TSS2.Size = New System.Drawing.Size(157, 6)
        '
        'TSM_SETTING
        '
        Me.TSM_SETTING.Name = "TSM_SETTING"
        Me.TSM_SETTING.Size = New System.Drawing.Size(160, 22)
        Me.TSM_SETTING.Text = "設定"
        '
        'TSS3
        '
        Me.TSS3.Name = "TSS3"
        Me.TSS3.Size = New System.Drawing.Size(157, 6)
        '
        'TSM_EXIT
        '
        Me.TSM_EXIT.Name = "TSM_EXIT"
        Me.TSM_EXIT.Size = New System.Drawing.Size(160, 22)
        Me.TSM_EXIT.Text = "終了"
        '
        'TIM_CHECK_PROCESS
        '
        Me.TIM_CHECK_PROCESS.Enabled = True
        Me.TIM_CHECK_PROCESS.Interval = 500
        '
        'TSM_BLANK
        '
        Me.TSM_BLANK.Name = "TSM_BLANK"
        Me.TSM_BLANK.Size = New System.Drawing.Size(160, 22)
        '
        'TSS4
        '
        Me.TSS4.Name = "TSS4"
        Me.TSS4.Size = New System.Drawing.Size(157, 6)
        '
        'TSS1
        '
        Me.TSS1.Name = "TSS1"
        Me.TSS1.Size = New System.Drawing.Size(157, 6)
        '
        'TSM_THUMBNAIL
        '
        Me.TSM_THUMBNAIL.Name = "TSM_THUMBNAIL"
        Me.TSM_THUMBNAIL.Size = New System.Drawing.Size(148, 22)
        Me.TSM_THUMBNAIL.Text = "サムネイル"
        '
        'FRM_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(120, 23)
        Me.ControlBox = False
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_MAIN"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.CMS_MENU.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NTI_TASK As NotifyIcon
    Friend WithEvents CMS_MENU As ContextMenuStrip
    Friend WithEvents TSM_EXIT As ToolStripMenuItem
    Friend WithEvents TSS3 As ToolStripSeparator
    Friend WithEvents TSM_CAPT_ONE As ToolStripMenuItem
    Friend WithEvents TSM_CAPT As ToolStripMenuItem
    Friend WithEvents TSS2 As ToolStripSeparator
    Friend WithEvents TSM_SETTING As ToolStripMenuItem
    Friend WithEvents TIM_CHECK_PROCESS As Timer
    Friend WithEvents TSM_OVERLAY As ToolStripMenuItem
    Friend WithEvents TSM_ROTATE As ToolStripMenuItem
    Friend WithEvents TSM_TRIM As ToolStripMenuItem
    Friend WithEvents TSM_LOGO As ToolStripMenuItem
    Friend WithEvents TSS1 As ToolStripSeparator
    Friend WithEvents TSS4 As ToolStripSeparator
    Friend WithEvents TSM_BLANK As ToolStripMenuItem
    Friend WithEvents TSM_THUMBNAIL As ToolStripMenuItem
End Class
