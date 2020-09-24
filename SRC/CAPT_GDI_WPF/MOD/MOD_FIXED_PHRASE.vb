Friend Module MOD_FIXED_PHRASE

#Region "モジュール用・定数"
    Private Const CST_YEAR As String = "\YYYY"
    Private Const CST_MONTH As String = "\MM"
    Private Const CST_DAY As String = "\DD"
    Private Const CST_HOUR As String = "\HH"
    Private Const CST_MINUTE As String = "\mm"
    Private Const CST_SECOND As String = "\SS"
    Private Const CST_INDEX As String = "\INDEX"
#End Region

#Region "モジュール用・変数"
    Private datPARM_DATE_BASE As DateTime
    Private intPARM_INDEX As Integer
#End Region

    Public Sub SUB_FIXED_PHRASE_INIT(ByVal datDATE_BASE As DateTime, ByVal intINDEX As Integer)
        datPARM_DATE_BASE = datDATE_BASE
        intPARM_INDEX = intINDEX
    End Sub

    Public Function FUNC_GET_FIXED_PHRASE(ByVal strBASE As String) As String
        Dim strTEMP As String
        Dim strRET As String

        Dim strYEAR As String
        Dim strMONTH As String
        Dim strDAY As String
        Dim strHOUR As String
        Dim strMINUTE As String
        Dim strSECOND As String
        Dim strINDEX As String

        strRET = ""

        strYEAR = MOD_CODE_TOOL.Format(datPARM_DATE_BASE.Year, "0000")
        strMONTH = MOD_CODE_TOOL.Format(datPARM_DATE_BASE.Month, "00")
        strDAY = MOD_CODE_TOOL.Format(datPARM_DATE_BASE.Day, "00")
        strHOUR = MOD_CODE_TOOL.Format(datPARM_DATE_BASE.Hour, "00")
        strMINUTE = MOD_CODE_TOOL.Format(datPARM_DATE_BASE.Minute, "00")
        strSECOND = MOD_CODE_TOOL.Format(datPARM_DATE_BASE.Second, "00")
        strINDEX = MOD_CODE_TOOL.Format(intPARM_INDEX, "00000")

        strTEMP = strBASE
        strTEMP = strTEMP.Replace(CST_YEAR, strYEAR)
        strTEMP = strTEMP.Replace(CST_MONTH, strMONTH)
        strTEMP = strTEMP.Replace(CST_DAY, strDAY)
        strTEMP = strTEMP.Replace(CST_HOUR, strHOUR)
        strTEMP = strTEMP.Replace(CST_MINUTE, strMINUTE)
        strTEMP = strTEMP.Replace(CST_SECOND, strSECOND)
        strTEMP = strTEMP.Replace(CST_INDEX, strINDEX)

        strTEMP = strTEMP.Replace("\", "")

        strRET = strTEMP

        Return strRET
    End Function
End Module
