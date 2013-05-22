using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace Shane.Church.Basecamp.OutlookPeopleSync
{
    public partial class OutlookPeopleSync
    {

		private void OutlookPeopleSync_Startup(object sender, System.EventArgs e)
        {
        }

		private void OutlookPeopleSync_Shutdown(object sender, System.EventArgs e)
        {
        }

		protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
		{
			return Globals.Factory.GetRibbonFactory().CreateRibbonManager(
				new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new RibbonItem() });
		}


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
			this.Startup += new System.EventHandler(OutlookPeopleSync_Startup);
			this.Shutdown += new System.EventHandler(OutlookPeopleSync_Shutdown);
        }
        
        #endregion
    }
}
