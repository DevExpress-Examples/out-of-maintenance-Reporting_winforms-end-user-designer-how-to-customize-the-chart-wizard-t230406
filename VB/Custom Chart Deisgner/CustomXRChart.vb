Imports System
Imports System.Collections.Generic
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraCharts.Wizard
Imports System.ComponentModel.Design

Namespace CustomChartDesigner
    <XRDesigner("CustomChartDesigner.CustomXRChartDesigner")> _
    Public Class CustomXRChart
        Inherits XRChart

        Public Sub New()
            MyBase.New()
        End Sub
    End Class
    Friend Class CustomXRChartDesigner
        Inherits XRChartDesigner

        Public Sub New()
            MyBase.New()
        End Sub
        Protected Overrides Function CreateWizard(ByVal chart As XRChart, ByVal designerHost As IDesignerHost) As ChartWizard
            Dim wizard As ChartWizard = MyBase.CreateWizard(chart, designerHost)
            CustomizeWizard(wizard)
            Return wizard
        End Function
        Private Sub CustomizeWizard(ByVal wizard As ChartWizard)
            'set title
            wizard.Caption = "My company title"
            'set icon
            wizard.Icon = GetCustomLogo()
        End Sub
        Private Function GetCustomLogo() As System.Drawing.Icon
            Return My.Resources.AppIcon
        End Function
    End Class
End Namespace
