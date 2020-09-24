Public Class FRM_MAIN

#Region "初期化・終了処理"
    Private Sub SUB_CTRL_NEW_INIT()
        Me.Icon = My.Resources.MAIN
        Me.NTI_TASK.Icon = My.Resources._32px
    End Sub

    Private Sub SUB_CTRL_VIEW_INIT()

    End Sub
    Private Sub SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub SUB_CTRL_VIEW_FIN()
    End Sub

    Private Sub SUB_CTRL_DISPOSED_FIN() '画面破棄時の追記処理(Dispose時)
    End Sub
#End Region

#Region "実行処理群"
    Private Sub SUB_END()
        NTI_TASK.Visible = False
        Call SUB_MAIN_END()
    End Sub

    Private Sub SUB_VIEW_SETTING()
        Call SUB_CALL_SETTING(Me)
    End Sub

    Private Sub SUB_SET_PROCESS(ByVal blnENABLED As Boolean)
        Dim strTEXT As String

        If blnENABLED Then
            strTEXT = ""
            strTEXT &= "FFXIVプロセスを確認しました。" & System.Environment.NewLine
            strTEXT &= "プロセスID：" & PRC_TARGET.Id & System.Environment.NewLine
        Else
            strTEXT = ""
            strTEXT = "FFXIVプロセスを探索しています..." & System.Environment.NewLine
        End If

        NTI_TASK.Text = strTEXT
        Call SUB_CMS_ENABLED(blnENABLED)
    End Sub

    Private Sub SUB_CMS_ENABLED(ByVal BLN_ENABLED As Boolean)

    End Sub

#End Region

#Region "NEW"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Call SUB_CTRL_NEW_INIT()
    End Sub
#End Region

#Region "イベント-タイマー"
    Private Sub TIM_CHECK_PROCESS_Tick(sender As Object, e As EventArgs) Handles TIM_CHECK_PROCESS.Tick
        If PRC_TARGET Is Nothing Then
            Call SUB_SET_PROCESS(False)
        Else
            Call SUB_SET_PROCESS(True)
        End If


    End Sub
#End Region

#Region "イベント-クリック"

    Private Sub TSM_SETTING_Click(sender As Object, e As EventArgs) Handles TSM_SETTING.Click
        Call SUB_VIEW_SETTING()
    End Sub

    Private Sub TSM_EXIT_Click(sender As Object, e As EventArgs) Handles TSM_EXIT.Click
        Call SUB_END()
    End Sub
#End Region

    Private Sub FRM_MAIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call SUB_CTRL_VIEW_INIT()
        Call SUB_CTRL_VALUE_INIT()
    End Sub

    Private Sub FRM_MAIN_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Call SUB_CTRL_VIEW_FIN()
    End Sub
End Class