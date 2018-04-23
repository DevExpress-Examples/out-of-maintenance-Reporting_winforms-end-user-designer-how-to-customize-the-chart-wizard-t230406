Imports System
Imports System.Collections.Generic
Imports System.Drawing.Design
Imports System.Linq
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner

Namespace WindowsApplication2
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub ShowDesigner()
            Dim designer As New XRDesignFormEx()
            Dim r As New XtraReport()
            AddHandler r.DesignerLoaded, AddressOf r_DesignerLoaded
            designer.OpenReport(r)
            designer.ShowDialog()
        End Sub
        Private Sub r_DesignerLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)
            Dim ts As IToolboxService = TryCast(e.DesignerHost.GetService(GetType(IToolboxService)), IToolboxService)
            RemoveStandardItem(ts)
            AddCustomControl(ts)
        End Sub
        Private Shared Sub AddCustomControl(ByVal ts As IToolboxService)
            Dim newItem As New ToolboxItem(GetType(CustomChartDesigner.CustomXRChart))
            newItem.DisplayName = "Custom Chart"
            ts.AddToolboxItem(newItem)
        End Sub
        Private Shared Sub RemoveStandardItem(ByVal ts As IToolboxService)
            Dim items As ToolboxItemCollection = ts.GetToolboxItems()
            Dim standardItem As ToolboxItem = items.OfType(Of ToolboxItem)().FirstOrDefault(Function(x) String.Equals(x.DisplayName, "Chart"))
            If standardItem IsNot Nothing Then
                ts.RemoveToolboxItem(standardItem)
            End If
        End Sub
        Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
            ShowDesigner()
        End Sub
    End Class
End Namespace
