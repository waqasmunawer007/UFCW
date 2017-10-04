using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.Inbox;
using UFCW.Services.Services.Inbox;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using UFCW.Views.Pages.Inbox;

namespace UFCW.ViewModels.Inbox
{
	public class InboxViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<InBoxMessage> inboxMessagesList;
		private bool isBusy = false;
        public ICommand InboxMessageCommand { get; set; }
        INavigation Navigation;

		public InboxViewModel(INavigation pageNav)
        {
			inboxMessagesList = new ObservableCollection<InBoxMessage>();
            Navigation = pageNav;
            SetupCommands();
		}

        private void SetupCommands()
        {
            InboxMessageCommand = new Command(async (e) =>
            {
                Message selectedItem = (e as Message);
                ViewMessagePage detailPage = new ViewMessagePage(selectedItem);
                await Navigation.PushAsync(detailPage);
            });
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
        public async Task<MailboxResponse> FetchMessagesList()
		{
			var service = new InboxService();
            return await service.FetchMailbox("ea2f9819-456a-49bf-a288-297cda67a2d8");
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