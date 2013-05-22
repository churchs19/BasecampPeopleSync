using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Shane.Church.Basecamp.OutlookPeopleSync
{
	public partial class BasecampSettings : Form
	{
		private int _companyId = 0;

		public string BasecampURL
		{
			get
			{
				return this.textBoxBasecampUrl.Text;
			}
			set
			{
				this.textBoxBasecampUrl.Text = value;
			}
		}

		public string APIKey
		{
			get
			{
				return this.textBoxAPIKey.Text;
			}
			set
			{
				this.textBoxAPIKey.Text = value;
			}
		}

		public int CompanyId
		{
			get
			{
				return _companyId;
			}
			set
			{
				_companyId = value;
			}
		}

		public BasecampSettings(string BasecampUrl, string ApiKey, int companyId = 0)
		{
			InitializeComponent();
			this.BasecampURL = BasecampUrl;
			this.APIKey = ApiKey;
			this.CompanyId = companyId;

			LoadCompanyList();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (comboBoxCompanyToSync.SelectedValue != null)
			{
				CompanyId = (int)comboBoxCompanyToSync.SelectedValue;
			}
			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void LoadCompanyList()
		{
			if (!string.IsNullOrEmpty(this.BasecampURL) && !string.IsNullOrEmpty(this.APIKey))
			{

				Companies companies = new Companies(BasecampURL, APIKey);
				List<Company> userCompanies = companies.GetCompanies();

				comboBoxCompanyToSync.DataSource = userCompanies;
				comboBoxCompanyToSync.Refresh();
				var selectedItem = (from Company c in comboBoxCompanyToSync.Items
									where c.Id == CompanyId
									select c);
				try
				{
					comboBoxCompanyToSync.SelectedIndex = comboBoxCompanyToSync.Items.IndexOf(selectedItem.FirstOrDefault());
				}
				catch (ArgumentNullException)
				{
					comboBoxCompanyToSync.SelectedIndex = 0;
				}
				comboBoxCompanyToSync.Refresh();
			}
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			LoadCompanyList();
		}

		private void textBoxBasecampUrl_TextChanged(object sender, EventArgs e)
		{
			LoadCompanyList();
		}

		private void textBoxAPIKey_TextChanged(object sender, EventArgs e)
		{
			LoadCompanyList();
		}

		private void pictureBoxAPIKeyHelp_Click(object sender, EventArgs e)
		{
			Process.Start("http://help.37signals.com/basecamp/questions/405-how-do-i-enable-the-api");
		}
	}
}
