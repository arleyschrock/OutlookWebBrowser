using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookWebBrowser
{
    partial class BrowserRegion
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Appointment)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Contact)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Activity)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Post)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Task)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("OutlookWebBrowser.BrowserRegion")]
        public partial class BrowserRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void BrowserRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void BrowserRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void BrowserRegion_FormRegionClosed(object sender, System.EventArgs e)
        {

        }

        public static string DataPath
        {
            get
            {
                if (string.IsNullOrEmpty(_dataPath))
                {
                    var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    _dataPath = Path.Combine(docPath, "Outlook Files", "Outlook Web Browser");

                    try
                    {
                        if (!Directory.Exists(_dataPath))
                        {
                            Directory.CreateDirectory(_dataPath);
                        }
                    }
                    catch { }
                }
                return _dataPath;
            }
        }
        private static string _dataPath = null;
    }
}
