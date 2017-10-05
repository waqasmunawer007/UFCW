using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Services.Models.Inbox;
using UFCW.Services.Services.Inbox;
using UFCW.Views.Pages.Inbox;
using Xamarin.Forms;

namespace UFCW.ViewModels.Inbox
{
	public class MessageDetailVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	
		private bool isBusy = false;
        public InBoxMessage inboxMessage { get; set; }
		
		public MessageDetailVM(){}

		public InBoxMessage InboxMessage
		{
			get { return inboxMessage; }
			set
			{
				if (inboxMessage != value)
				{
					inboxMessage = value;
					OnPropertyChanged("InboxMessage");
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
		public async Task<InBoxMessage> GetMessage(string messageID)
		{
            IsBusy = true;
			var service = new InboxService();
            InBoxMessage message = await service.GetMessage(messageID);
            if (!message.IsRead)
            {
                await service.ReadMessage(message.MailBoxMessageID);
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