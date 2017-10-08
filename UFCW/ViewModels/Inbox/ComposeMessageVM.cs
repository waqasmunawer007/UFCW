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
        private ObservableCollection<ToContactItem> toConatacts;
        private string subject;
        private string messageBody;
        int toContactSelectedIndex;



		public ComposeMessageVM(INavigation nav) 
        {
            Navigation = nav;
			toConatacts = new ObservableCollection<ToContactItem>()
			{
			    new ToContactItem(){ToText = "",ToValue = ""},
				new ToContactItem(){ToText = "AddressChange",ToValue = "AddressChange"},
				new ToContactItem(){ToText = "ContactUs",ToValue = "ContactUs"},
				new ToContactItem(){ToText = "PensionAdmin",ToValue = "PensionAdmin"},
				new ToContactItem(){ToText = "HWAdmin",ToValue = "HWAdmin"}

			};
           // ToConatacts = toConatacts;
			ComposeMessageCommand = new Command(async (e) =>
			{
                
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                ToContactItem selectedToContact = ToConatacts[toContactSelectedIndex];
                if (!String.IsNullOrEmpty(selectedToContact.ToValue) && !String.IsNullOrEmpty(Subject) && !String.IsNullOrEmpty(MessageBody))
                {
                    string uuid = System.Guid.NewGuid().ToString();
					parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
					parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
					parameters.Add(WebApiConstants.UserID, Settings.UserID);
					parameters.Add(WebApiConstants.MailBoxMessageID, uuid);
					parameters.Add(WebApiConstants.MessageTo, ""); //Todo need to clear from the client
					parameters.Add(WebApiConstants.ToDescription, selectedToContact.ToValue);
					parameters.Add(WebApiConstants.From, Settings.UserID);
					parameters.Add(WebApiConstants.FromDescription, Settings.UserName);
					parameters.Add(WebApiConstants.Subject, Subject);
					parameters.Add(WebApiConstants.Body, MessageBody);
					await ComposeMessage(parameters);
					Subject = "";
					MessageBody = "";
                    ToContactSelectedIndex = 0;

                }
                else
                {
                   await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE,AppConstants.COMPOSE_VALIDATION_MESSAGE , "OK");
                }

				//ViewMessagePage detailPage = new ViewMessagePage(selectedItem.MailBoxMessageID);
				//await Navigation.PushAsync(detailPage);
			});
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

		public ObservableCollection<ToContactItem> ToConatacts
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
			
			}
			IsBusy = false;
			return message;
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
