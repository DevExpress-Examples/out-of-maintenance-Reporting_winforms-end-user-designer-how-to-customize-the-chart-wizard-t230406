using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace WindowsApplication2 {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }

        private void ShowDesigner() {
            XRDesignFormEx designer = new XRDesignFormEx();
            XtraReport r = new XtraReport();
            r.DesignerLoaded += new DesignerLoadedEventHandler(r_DesignerLoaded);
            designer.OpenReport(r);
            designer.ShowDialog();
        }
        private void r_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e) {
            IToolboxService ts = e.DesignerHost.GetService(typeof(IToolboxService)) as IToolboxService;
            RemoveStandardItem(ts);
            AddCustomControl(ts);
        }
        private static void AddCustomControl(IToolboxService ts) {
            ToolboxItem newItem = new ToolboxItem(typeof(CustomChartDesigner.CustomXRChart));
            newItem.DisplayName = "Custom Chart";
            ts.AddToolboxItem(newItem);
        }
        private static void RemoveStandardItem(IToolboxService ts) {
            ToolboxItemCollection items = ts.GetToolboxItems();
            ToolboxItem standardItem = items.OfType<ToolboxItem>().FirstOrDefault(x => String.Equals(x.DisplayName, "Chart"));
            if(standardItem != null) {
                ts.RemoveToolboxItem(standardItem);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            ShowDesigner();
        }
    }
}
