namespace Shane.Church.Basecamp.OutlookPeopleSync
{
	partial class BasecampSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasecampSettings));
			this.labelBasecampUrl = new System.Windows.Forms.Label();
			this.labelAPIKey = new System.Windows.Forms.Label();
			this.textBoxBasecampUrl = new System.Windows.Forms.TextBox();
			this.textBoxAPIKey = new System.Windows.Forms.TextBox();
			this.labelBasecamphqCom = new System.Windows.Forms.Label();
			this.labelHttps = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelCompanyToSync = new System.Windows.Forms.Label();
			this.comboBoxCompanyToSync = new System.Windows.Forms.ComboBox();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.pictureBoxAPIKeyHelp = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).BeginInit();
			this.SuspendLayout();
			// 
			// labelBasecampUrl
			// 
			this.labelBasecampUrl.AutoSize = true;
			this.labelBasecampUrl.Location = new System.Drawing.Point(13, 16);
			this.labelBasecampUrl.Name = "labelBasecampUrl";
			this.labelBasecampUrl.Size = new System.Drawing.Size(85, 13);
			this.labelBasecampUrl.TabIndex = 0;
			this.labelBasecampUrl.Text = "Basecamp URL:";
			// 
			// labelAPIKey
			// 
			this.labelAPIKey.AutoSize = true;
			this.labelAPIKey.Location = new System.Drawing.Point(13, 43);
			this.labelAPIKey.Name = "labelAPIKey";
			this.labelAPIKey.Size = new System.Drawing.Size(48, 13);
			this.labelAPIKey.TabIndex = 1;
			this.labelAPIKey.Text = "API Key:";
			// 
			// textBoxBasecampUrl
			// 
			this.textBoxBasecampUrl.Location = new System.Drawing.Point(164, 13);
			this.textBoxBasecampUrl.Name = "textBoxBasecampUrl";
			this.textBoxBasecampUrl.Size = new System.Drawing.Size(161, 20);
			this.textBoxBasecampUrl.TabIndex = 0;
			this.textBoxBasecampUrl.TextChanged += new System.EventHandler(this.textBoxBasecampUrl_TextChanged);
			// 
			// textBoxAPIKey
			// 
			this.textBoxAPIKey.Location = new System.Drawing.Point(124, 40);
			this.textBoxAPIKey.Name = "textBoxAPIKey";
			this.textBoxAPIKey.Size = new System.Drawing.Size(303, 20);
			this.textBoxAPIKey.TabIndex = 1;
			this.textBoxAPIKey.TextChanged += new System.EventHandler(this.textBoxAPIKey_TextChanged);
			// 
			// labelBasecamphqCom
			// 
			this.labelBasecamphqCom.AutoSize = true;
			this.labelBasecamphqCom.Location = new System.Drawing.Point(331, 16);
			this.labelBasecamphqCom.Name = "labelBasecamphqCom";
			this.labelBasecamphqCom.Size = new System.Drawing.Size(94, 13);
			this.labelBasecamphqCom.TabIndex = 4;
			this.labelBasecamphqCom.Text = ".basecamphq.com";
			// 
			// labelHttps
			// 
			this.labelHttps.AutoSize = true;
			this.labelHttps.Location = new System.Drawing.Point(121, 16);
			this.labelHttps.Name = "labelHttps";
			this.labelHttps.Size = new System.Drawing.Size(43, 13);
			this.labelHttps.TabIndex = 5;
			this.labelHttps.Text = "https://";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(350, 122);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "O&K";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(269, 122);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelCompanyToSync
			// 
			this.labelCompanyToSync.AutoSize = true;
			this.labelCompanyToSync.Location = new System.Drawing.Point(13, 98);
			this.labelCompanyToSync.Name = "labelCompanyToSync";
			this.labelCompanyToSync.Size = new System.Drawing.Size(93, 13);
			this.labelCompanyToSync.TabIndex = 8;
			this.labelCompanyToSync.Text = "Company to Sync:";
			// 
			// comboBoxCompanyToSync
			// 
			this.comboBoxCompanyToSync.DisplayMember = "Name";
			this.comboBoxCompanyToSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCompanyToSync.FormattingEnabled = true;
			this.comboBoxCompanyToSync.Location = new System.Drawing.Point(124, 95);
			this.comboBoxCompanyToSync.Name = "comboBoxCompanyToSync";
			this.comboBoxCompanyToSync.Size = new System.Drawing.Size(301, 21);
			this.comboBoxCompanyToSync.TabIndex = 3;
			this.comboBoxCompanyToSync.ValueMember = "Id";
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(352, 66);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdate.TabIndex = 2;
			this.buttonUpdate.Text = "&Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// pictureBoxAPIKeyHelp
			// 
			this.pictureBoxAPIKeyHelp.Image = global::Shane.Church.Basecamp.OutlookPeopleSync.Properties.Resources._109_AllAnnotations_Help_16x16_72;
			this.pictureBoxAPIKeyHelp.Location = new System.Drawing.Point(67, 40);
			this.pictureBoxAPIKeyHelp.Name = "pictureBoxAPIKeyHelp";
			this.pictureBoxAPIKeyHelp.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxAPIKeyHelp.TabIndex = 9;
			this.pictureBoxAPIKeyHelp.TabStop = false;
			this.pictureBoxAPIKeyHelp.Click += new System.EventHandler(this.pictureBoxAPIKeyHelp_Click);
			// 
			// BasecampSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 154);
			this.Controls.Add(this.pictureBoxAPIKeyHelp);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.comboBoxCompanyToSync);
			this.Controls.Add(this.labelCompanyToSync);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelHttps);
			this.Controls.Add(this.labelBasecamphqCom);
			this.Controls.Add(this.textBoxAPIKey);
			this.Controls.Add(this.textBoxBasecampUrl);
			this.Controls.Add(this.labelAPIKey);
			this.Controls.Add(this.labelBasecampUrl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BasecampSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Basecamp Settings";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelBasecampUrl;
		private System.Windows.Forms.Label labelAPIKey;
		private System.Windows.Forms.TextBox textBoxBasecampUrl;
		private System.Windows.Forms.TextBox textBoxAPIKey;
		private System.Windows.Forms.Label labelBasecamphqCom;
		private System.Windows.Forms.Label labelHttps;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelCompanyToSync;
		private System.Windows.Forms.ComboBox comboBoxCompanyToSync;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.PictureBox pictureBoxAPIKeyHelp;
	}
}