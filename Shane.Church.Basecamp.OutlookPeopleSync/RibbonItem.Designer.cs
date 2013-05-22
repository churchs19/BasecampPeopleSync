namespace Shane.Church.Basecamp.OutlookPeopleSync
{
	partial class RibbonItem : Microsoft.Office.Tools.Ribbon.RibbonBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public RibbonItem()
			: base(Globals.Factory.GetRibbonFactory())
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tab1 = this.Factory.CreateRibbonTab();
			this.groupBasecamp = this.Factory.CreateRibbonGroup();
			this.buttonBasecampSync = this.Factory.CreateRibbonButton();
			this.buttonSettings = this.Factory.CreateRibbonButton();
			this.buttonAbout = this.Factory.CreateRibbonButton();
			this.tab1.SuspendLayout();
			this.groupBasecamp.SuspendLayout();
			// 
			// tab1
			// 
			this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.tab1.Groups.Add(this.groupBasecamp);
			this.tab1.Label = "TabAddIns";
			this.tab1.Name = "tab1";
			// 
			// groupBasecamp
			// 
			this.groupBasecamp.Items.Add(this.buttonBasecampSync);
			this.groupBasecamp.Items.Add(this.buttonSettings);
			this.groupBasecamp.Items.Add(this.buttonAbout);
			this.groupBasecamp.Label = "Basecamp";
			this.groupBasecamp.Name = "groupBasecamp";
			// 
			// buttonBasecampSync
			// 
			this.buttonBasecampSync.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonBasecampSync.Image = global::Shane.Church.Basecamp.OutlookPeopleSync.Properties.Resources.BasecampSync48;
			this.buttonBasecampSync.Label = "Sync";
			this.buttonBasecampSync.Name = "buttonBasecampSync";
			this.buttonBasecampSync.ShowImage = true;
			this.buttonBasecampSync.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonBasecampSync_Click);
			// 
			// buttonSettings
			// 
			this.buttonSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonSettings.Image = global::Shane.Church.Basecamp.OutlookPeopleSync.Properties.Resources.BasecampSettings48;
			this.buttonSettings.Label = "Settings";
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.ShowImage = true;
			this.buttonSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonSettings_Click);
			// 
			// buttonAbout
			// 
			this.buttonAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.buttonAbout.Image = global::Shane.Church.Basecamp.OutlookPeopleSync.Properties.Resources.BasecampAbout48;
			this.buttonAbout.Label = "About";
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.ShowImage = true;
			this.buttonAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonAbout_Click);
			// 
			// RibbonItem
			// 
			this.Name = "RibbonItem";
			this.RibbonType = "Microsoft.Outlook.Contact, Microsoft.Outlook.Explorer";
			this.Tabs.Add(this.tab1);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonItem_Load);
			this.tab1.ResumeLayout(false);
			this.tab1.PerformLayout();
			this.groupBasecamp.ResumeLayout(false);
			this.groupBasecamp.PerformLayout();

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupBasecamp;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonBasecampSync;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonSettings;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonAbout;
	}

	partial class ThisRibbonCollection
	{
		internal RibbonItem RibbonItem
		{
			get { return this.GetRibbon<RibbonItem>(); }
		}
	}
}
