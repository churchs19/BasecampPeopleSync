using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Shane.Church.Basecamp.OutlookPeopleSync.Properties;
using System.IO;

namespace Shane.Church.Basecamp.OutlookPeopleSync
{
	public partial class BasecampSync : Form
	{
		private List<Person> _people;
		private Company _company;
		private Outlook.Application _application;

		public BasecampSync(Outlook.Application application)
		{
			InitializeComponent();
			_people = new List<Person>();
			_company = new Company();
			_application = application;
		}

		private void BasecampSync_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Settings.Default.APIKey) && !string.IsNullOrEmpty(Settings.Default.BasecampURL) && (Settings.Default.CompanyId > 0))
			{
				People peopleService = new People(Settings.Default.BasecampURL, Settings.Default.APIKey);
				_people = peopleService.GetPeopleForCompany(Settings.Default.CompanyId);
				Companies companiesService = new Companies(Settings.Default.BasecampURL, Settings.Default.APIKey);
				_company = companiesService.GetCompany(Settings.Default.CompanyId);

				labelProgress.Text = "Processing " + _people.Count + " contacts in " + _company.Name + "...";

				if (!backgroundWorkerSync.IsBusy)
				{
					backgroundWorkerSync.RunWorkerAsync();
				}
			}
			else
			{
				MessageBox.Show("Please configure Basecamp settings before running the sync process.", "Basecamp Sync Error");
				DialogResult = System.Windows.Forms.DialogResult.Abort;
				this.Close();
			}
		}
	
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			if (backgroundWorkerSync.WorkerSupportsCancellation)
			{
				backgroundWorkerSync.CancelAsync();
			}
		}

		private void backgroundWorkerSync_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			if (_application != null)
			{
				for (int i = 0; i < _people.Count; i++ )
				{
					if (worker.CancellationPending)
					{
						e.Cancel = true;
						break;
					}
					else
					{
						Person p = _people[i];
						worker.ReportProgress((i*100) / _people.Count , "Processing contact " + i + " of " + _people.Count + " - " + p.FirstName + " " + p.LastName);
						Outlook.ContactItem contact = FindContactByName(p.FirstName, p.LastName);
						bool isUpdate = true;


						if (contact == null)
						{
							//Create new contact
							contact = (Outlook.ContactItem)this._application.CreateItem(Outlook.OlItemType.olContactItem);
							isUpdate = false;
						}

						string notes = "Basecamp People Sync Update - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n\r\n";
						notes += "----------------------------------------------------\r\n";

						if (!string.IsNullOrEmpty(p.FirstName)) 
						{
							if (!string.IsNullOrEmpty(contact.FirstName) && contact.FirstName != p.FirstName)
							{
								notes += "First Name: " + contact.FirstName + " to " + p.FirstName + "\r\n";
							}
							contact.FirstName = p.FirstName; 
						}
						if (!string.IsNullOrEmpty(p.LastName))
						{
							if (!string.IsNullOrEmpty(contact.LastName) && contact.LastName != p.LastName)
							{
								notes += "Last Name: " + contact.LastName + " to " + p.LastName + "\r\n";
							}
							contact.LastName = p.LastName; 
						}
						if (!string.IsNullOrEmpty(p.IMService) && !string.IsNullOrEmpty(p.IMHandle)) 
						{
							if (!string.IsNullOrEmpty(contact.IMAddress) && contact.IMAddress != (p.IMService + ": " + p.IMHandle))
							{
								notes += "IM Address: " + contact.IMAddress + " to " + p.IMService + ": " + p.IMHandle + "\r\n";
							}
							contact.IMAddress = p.IMService + ": " + p.IMHandle; 
						}
						if (!string.IsNullOrEmpty(p.FaxPhone)) 
						{
							if (!string.IsNullOrEmpty(contact.BusinessFaxNumber) && contact.BusinessFaxNumber != p.FaxPhone)
							{
								notes += "Fax Number: " + contact.BusinessFaxNumber + " to " + p.FaxPhone + "\r\n";
							}
							contact.BusinessFaxNumber = p.FaxPhone; 
						}
						if (!string.IsNullOrEmpty(p.OfficePhone))
						{
							if (string.IsNullOrEmpty(p.OfficePhoneExt))
							{
								if (!string.IsNullOrEmpty(contact.BusinessTelephoneNumber) && contact.BusinessTelephoneNumber != p.OfficePhone)
								{
									notes += "Office Phone: " + contact.BusinessTelephoneNumber + " to " + p.OfficePhone + "\r\n";
								}
								contact.BusinessTelephoneNumber = p.OfficePhone;
							}
							else
							{
								if (!string.IsNullOrEmpty(contact.BusinessTelephoneNumber) && contact.BusinessTelephoneNumber != (p.OfficePhone + " x" + p.OfficePhoneExt))
								{
									notes += "Office Phone: " + contact.BusinessTelephoneNumber + " to " + p.OfficePhone + " x" + p.OfficePhoneExt + "\r\n";
								}
								contact.BusinessTelephoneNumber = p.OfficePhone + " x" + p.OfficePhoneExt;
							}
						}
						if (!string.IsNullOrEmpty(p.EmailAddress))
						{
							int updatedEmail = 0;
							if (string.IsNullOrEmpty(contact.Email1Address))
							{
								//Empty primary email
								contact.Email1Address = p.EmailAddress;
								updatedEmail = 1;
							}
							else
							{
								//Put the email in the first empty email slot
								if (contact.Email1Address.ToLower() != p.EmailAddress.ToLower())
								{
									if (string.IsNullOrEmpty(contact.Email2Address))
									{
										updatedEmail = 2;
										contact.Email2Address = p.EmailAddress;
									}
									else if (contact.Email2Address.ToLower() != p.EmailAddress.ToLower())
									{
										if (string.IsNullOrEmpty(contact.Email3Address))
										{
											updatedEmail = 3;
											contact.Email3Address = p.EmailAddress;
										}
										else
										{
											notes += "Email (" + p.EmailAddress + ") Not Stored.  No free email address slots.\r\n";
										}
									}
								}
								if (updatedEmail != 0)
								{
									notes += "Email " + updatedEmail.ToString() + " Address to " + p.EmailAddress + "\r\n";
								}
							}
						}
						if (!string.IsNullOrEmpty(p.HomePhone)) 
						{
							if (!string.IsNullOrEmpty(contact.HomeTelephoneNumber) && contact.HomeTelephoneNumber != p.HomePhone)
							{
								notes += "Home Number: " + contact.HomeTelephoneNumber + " to " + p.HomePhone + "\r\n";
							}
							contact.HomeTelephoneNumber = p.HomePhone; 
						}
						if (!string.IsNullOrEmpty(p.MobilePhone)) 
						{
							if (!string.IsNullOrEmpty(contact.HomeTelephoneNumber) && contact.HomeTelephoneNumber != p.HomePhone)
							{
								notes += "Mobile Number: " + contact.HomeTelephoneNumber + " to " + p.HomePhone + "\r\n";
							}
							contact.MobileTelephoneNumber = p.MobilePhone; 
						}
						if (!string.IsNullOrEmpty(p.Title)) 
						{
							if (!string.IsNullOrEmpty(contact.JobTitle) && contact.JobTitle != p.Title)
							{
								notes += "Job Title: " + contact.JobTitle + " to " + p.Title + "\r\n";
							}
							contact.JobTitle = p.Title; 
						}
						string filename = "";
						if (!string.IsNullOrEmpty(p.AvatarUrl))
						{
							//Save the image to disk, load it into contact and then delete after save
							string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "BasecampSync";
							if (!Directory.Exists(path))
							{
								Directory.CreateDirectory(path);
							}

							Bitmap picture = p.GetAvatarBitmap();
							if (picture != null)
							{
								filename = path + Path.DirectorySeparatorChar + p.Id.ToString() + ".jpg";
								picture.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
								contact.AddPicture(filename);
								notes += "Updated Picture\r\n";
							}
						}

						if (!string.IsNullOrEmpty(_company.Name))
						{
							if (!string.IsNullOrEmpty(contact.CompanyName) && contact.CompanyName != _company.Name)
							{
								notes += "Company Name: " + contact.CompanyName + " to " + _company.Name + "\r\n";
							}
							contact.CompanyName = _company.Name;
						}
						if (!string.IsNullOrEmpty(_company.AddressOne))
						{
							if (!string.IsNullOrEmpty(_company.AddressTwo))
							{
								if (!string.IsNullOrEmpty(contact.BusinessAddressStreet) && contact.BusinessAddressStreet != (_company.AddressOne + "\n" + _company.AddressTwo))
								{
									notes += "Business Address Street: " + contact.BusinessAddressStreet + " to " + _company.AddressOne + "\n" + _company.AddressTwo + "\r\n";
								}
								contact.BusinessAddressStreet = _company.AddressOne + "\n" + _company.AddressTwo;
							}
							else
							{
								if (!string.IsNullOrEmpty(contact.BusinessAddressStreet) && contact.BusinessAddressStreet != _company.AddressOne)
								{
									notes += "Business Address Street: " + contact.BusinessAddressStreet + " to " + _company.AddressOne + "\r\n";
								}
								contact.BusinessAddressStreet = _company.AddressOne;
							}
						}
						if (!string.IsNullOrEmpty(_company.City)) 
						{
							if (!string.IsNullOrEmpty(contact.BusinessAddressCity) && contact.BusinessAddressCity != _company.City)
							{
								notes += "Business Address City: " + contact.BusinessAddressCity + " to " + _company.City + "\r\n";
							}
							contact.BusinessAddressCity = _company.City; 
						}
						if (!string.IsNullOrEmpty(_company.State))
						{
							if (!string.IsNullOrEmpty(contact.BusinessAddressState) && contact.BusinessAddressState != _company.State)
							{
								notes += "Business Address State: " + contact.BusinessAddressState + " to " + _company.State + "\r\n";
							}
							contact.BusinessAddressState = _company.State;
						}
						if (!string.IsNullOrEmpty(_company.Zip))
						{
							if (!string.IsNullOrEmpty(contact.BusinessAddressPostalCode) && contact.BusinessAddressPostalCode != _company.Zip)
							{
								notes += "Business Address Postal Code: " + contact.BusinessAddressPostalCode + " to " + _company.Zip + "\r\n";
							}
							contact.BusinessAddressPostalCode = _company.Zip;
						}
						if (!string.IsNullOrEmpty(_company.Country)) 
						{
							if (!string.IsNullOrEmpty(contact.BusinessAddressCountry) && contact.BusinessAddressCountry != _company.Country)
							{
								notes += "Business Address Country: " + contact.BusinessAddressCountry + " to " + _company.Country + "\r\n";
							}
							contact.BusinessAddressCountry = _company.Country; 
						}
						if (!string.IsNullOrEmpty(_company.OfficePhone)) 
						{
							if (!string.IsNullOrEmpty(contact.CompanyMainTelephoneNumber) && contact.CompanyMainTelephoneNumber != _company.OfficePhone)
							{
								notes += "Company Phone Number: " + contact.CompanyMainTelephoneNumber + " to " + _company.OfficePhone + "\r\n";
							}
							contact.CompanyMainTelephoneNumber = _company.OfficePhone; 
						}
						if (!string.IsNullOrEmpty(_company.WebAddress) && string.IsNullOrEmpty(contact.WebPage)) 
						{
							notes += "Web Page to " + _company.WebAddress + "\r\n";
							contact.WebPage = _company.WebAddress;
						}
						notes += "----------------------------------------------------\r\n";

						if (isUpdate)
						{
							if (!string.IsNullOrEmpty(contact.Body))
							{
								contact.Body += "\r\n\r\n";
							}
							contact.Body += notes;
						}

						contact.Save();

						if (filename != "")
						{
							File.Delete(filename);
						}
					}
				}
			}
		}

		private void backgroundWorkerSync_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBarSync.Value = e.ProgressPercentage;
			labelProgress.Text = e.UserState.ToString();
		}

		private void backgroundWorkerSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}
			else if (e.Error != null)
			{
				DialogResult = System.Windows.Forms.DialogResult.Abort;
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
			this.Close();
		}

		private Outlook.ContactItem FindContactByName(string firstName, string lastName)
		{
			Outlook.NameSpace outlookNameSpace = this._application.GetNamespace("MAPI");
			Outlook.MAPIFolder contactsFolder = outlookNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

			Outlook.Items contactItems = contactsFolder.Items;
			try
			{
				Outlook.ContactItem contact = contactItems.Find(String.Format("[FirstName]='{0}' and [LastName]='{1}'", firstName, lastName)) as Outlook.ContactItem;
				return contact;
			}
			catch
			{
				return null;
			}
		}
	}
}
