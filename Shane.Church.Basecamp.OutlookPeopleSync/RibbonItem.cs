using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Shane.Church.Basecamp.OutlookPeopleSync.Properties;

namespace Shane.Church.Basecamp.OutlookPeopleSync
{
	public partial class RibbonItem
	{
		private Outlook.Application Application { get; set; }
		private void RibbonItem_Load(object sender, RibbonUIEventArgs e)
		{
			try
			{
				UpdateSyncButtonEnabled();
			}
			catch (System.Configuration.ConfigurationErrorsException cex)
			{
				var config = ((System.Configuration.ConfigurationErrorsException)cex.InnerException).Filename;
				File.Delete(config);
				MessageBox.Show(config);
			}
		}

		private void buttonBasecampSync_Click(object sender, RibbonControlEventArgs e)
		{
			this.Application = e.Control.Context.Application as Outlook.Application;
			BasecampSync sync = new BasecampSync(this.Application);
			sync.ShowDialog();
		}

		private void buttonSettings_Click(object sender, RibbonControlEventArgs e)
		{
			BasecampSettings settingsForm = new BasecampSettings(Settings.Default.BasecampURL, Settings.Default.APIKey, Settings.Default.CompanyId);
			if (settingsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				//Save Settings
				Settings.Default.APIKey = settingsForm.APIKey;
				Settings.Default.BasecampURL = settingsForm.BasecampURL;
				Settings.Default.CompanyId = settingsForm.CompanyId;
				Settings.Default.Save();
				UpdateSyncButtonEnabled();
			}
		}

		private void UpdateSyncButtonEnabled()
		{
			if (string.IsNullOrEmpty(Settings.Default.APIKey) || string.IsNullOrEmpty(Settings.Default.BasecampURL) || (Settings.Default.CompanyId == 0))
			{
				buttonBasecampSync.Enabled = false;
			}
			else
			{
				buttonBasecampSync.Enabled = true;
			}
		}

		private void buttonAbout_Click(object sender, RibbonControlEventArgs e)
		{
			new AboutBasecampSync().ShowDialog();
		}
	}
}
