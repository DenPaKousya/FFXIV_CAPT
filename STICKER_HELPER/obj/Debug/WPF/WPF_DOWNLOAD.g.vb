﻿#ExternalChecksum("..\..\..\WPF\WPF_DOWNLOAD.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","2B2F4656B0FAA3035C371CE63676892FDF548CE6034A6D99E205FD122B0670EA")
'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports STICKER_HELPER
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''WPF_DOWNLOAD
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class WPF_DOWNLOAD
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",12)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TXT_URL_CSV As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",13)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BTN_VIEW_LIST As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",18)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents DGV_LIST As System.Windows.Controls.DataGrid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",21)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents GRP_TASK As System.Windows.Controls.GroupBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",23)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents LBL_GUIDE As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",24)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BTN_OK As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",25)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BTN_CANCEL As System.Windows.Controls.Button
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/STICKER_HELPER;component/wpf/wpf_download.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\WPF\WPF_DOWNLOAD.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.TXT_URL_CSV = CType(target,System.Windows.Controls.TextBox)
            Return
        End If
        If (connectionId = 2) Then
            Me.BTN_VIEW_LIST = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 3) Then
            Me.DGV_LIST = CType(target,System.Windows.Controls.DataGrid)
            Return
        End If
        If (connectionId = 4) Then
            Me.GRP_TASK = CType(target,System.Windows.Controls.GroupBox)
            Return
        End If
        If (connectionId = 5) Then
            Me.LBL_GUIDE = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 6) Then
            Me.BTN_OK = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 7) Then
            Me.BTN_CANCEL = CType(target,System.Windows.Controls.Button)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class
