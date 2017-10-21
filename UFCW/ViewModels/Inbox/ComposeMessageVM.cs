using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.Inbox;
using UFCW.Services.Services.Inbox;
using Xamarin.Forms;

namespace UFCW.ViewModels.Inbox
{
	public class ComposeMessageVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool isBusy = false;
		public ICommand ComposeMessageCommand { get; set; }
		INavigation Navigation;
        private ObservableCollection<AdminMailbox> toConatacts;
        private string subject;
        private string messageBody;
        int toContactSelectedIndex;

		public ComposeMessageVM(INavigation nav) 
        {
            Navigation = nav;
            toConatacts = new ObservableCollection<AdminMailbox>();
			
			ComposeMessageCommand = new Command(async (e) =>
			{
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                AdminMailbox selectedToContact = ToConatacts[toContactSelectedIndex];
                if (!String.IsNullOrEmpty(selectedToContact.Value) && !String.IsNullOrEmpty(Subject) && !String.IsNullOrEmpty(MessageBody))
                {
                    string uuid = System.Guid.NewGuid().ToString();
					parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
					parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
                    parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
					parameters.Add(WebApiConstants.UserID, Settings.UserID);
					parameters.Add(WebApiConstants.MailBoxMessageID, uuid);
                    parameters.Add(WebApiConstants.MessageTo, selectedToContact.Value); 
                    parameters.Add(WebApiConstants.ToDescription, selectedToContact.Text);
					parameters.Add(WebApiConstants.From, Settings.UserID);
					parameters.Add(WebApiConstants.FromDescription, Settings.UserName);
					parameters.Add(WebApiConstants.Subject, Subject);
					parameters.Add(WebApiConstants.Body, MessageBody);
                    await ComposeMessage(parameters);
					

                }
                else
                {
                   await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE,AppConstants.COMPOSE_VALIDATION_MESSAGE , "OK");
                }
			});
        }
        public int SelectedToContactIndex(string toContactId)
        {
            int index = 0;
            for (int i = 0; i < ToConatacts.Count; i++)
            {
                if (toContactId.Equals(ToConatacts[i].Text))
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }
		public string Subject
		{
			get { return subject; }
			set
			{
				if (subject != value)
				{
					subject = value;
					OnPropertyChanged(nameof(Subject));
				}
			}
		}
		public string MessageBody
		{
			get { return messageBody; }
			set
			{
				if (messageBody != value)
				{
					messageBody = value;
					OnPropertyChanged(nameof(MessageBody));
				}
			}
		}

		public ObservableCollection<AdminMailbox> ToConatacts
		{
			get { return toConatacts; }
			set
			{
				if (toConatacts != value)
				{
					toConatacts = value;
					OnPropertyChanged(nameof(ToConatacts));
				}
			}
		}

		public int ToContactSelectedIndex
		{
			get { return toContactSelectedIndex; }
			set
			{
				if (toContactSelectedIndex != value)
				{
					toContactSelectedIndex = value;
					OnPropertyChanged(nameof(ToContactSelectedIndex));
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating for Activity Indicator.
		/// </summary>
		/// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				if (isBusy != value)
				{
					isBusy = value;
					OnPropertyChanged("IsBusy");
				}
			}
		}

		/// <summary>
		/// Fetchs the messages list.
		/// </summary>
		/// <returns>The messages list.</returns>
		public async Task<SendMessageResponse> ComposeMessage(Dictionary<string, object> parameters)
		{
			IsBusy = true;
			var service = new InboxService();
            SendMessageResponse message = await service.SendMessage(parameters);
            if (message.MessageSent)
			{
				Subject = "";
				MessageBody = "";
				ToContactSelectedIndex = 0;
			    await Application.Current.MainPage.DisplayAlert("", AppConstants.COMPOSE_EAMIl_SENT, "OK");
			}
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_MESSAGE, AppConstants.ERROR_MESSAGE, "OK"); 
            }
			IsBusy = false;
			return message;
		}

		public async Task<AdminMailbox[]> FetchAdmainMailbox()
		{
			var service = new InboxService();
            AdminMailbox[] adminMailbox = await service.GetAdminMailbox();
			this.ToConatacts.Clear();
            if (adminMailbox != null)
            {
                AdminMailbox emptyMailbox = new AdminMailbox() { Text = "", Value = "" };
                ToConatacts.Add(emptyMailbox);
				foreach (AdminMailbox mailboxEmail in adminMailbox)
				{
					this.ToConatacts.Add(mailboxEmail);
				}
            }
			return adminMailbox;
		}
		/// <summary>
		/// Ons the property changed.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
