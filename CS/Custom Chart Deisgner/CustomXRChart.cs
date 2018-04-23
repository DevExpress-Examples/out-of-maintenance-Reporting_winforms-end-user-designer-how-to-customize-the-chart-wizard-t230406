using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Design;
using DevExpress.XtraCharts.Wizard;
using System.ComponentModel.Design;

namespace CustomChartDesigner {
    [XRDesigner("CustomChartDesigner.CustomXRChartDesigner")]
    public class CustomXRChart : XRChart {
        public CustomXRChart()
            : base() {
        }
    }
    internal class CustomXRChartDesigner : XRChartDesigner {
        public CustomXRChartDesigner()
            : base() {
        }
        protected override ChartWizard CreateWizard(XRChart chart, IDesignerHost designerHost) {
            ChartWizard wizard = base.CreateWizard(chart, designerHost);
            CustomizeWizard(wizard);
            return wizard;
        }
        private void CustomizeWizard(ChartWizard wizard) {
            //set title
            wizard.Caption = "My company title";
            //set icon
            wizard.Icon = GetCustomLogo();
        }
        private System.Drawing.Icon GetCustomLogo() {
            return WindowsApplication2.Properties.Resources.AppIcon;
        }
    }
}
