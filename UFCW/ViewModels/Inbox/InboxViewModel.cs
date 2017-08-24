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
        public ObservableCollection<Message> messagesList;
		private bool isBusy = false;
        public ICommand DetailClaimCommand { get; set; }
        INavigation Navigation;

		public InboxViewModel(INavigation pageNav)
        {
			messagesList = new ObservableCollection<Message>();
            Navigation = pageNav;
            SetupCommands();
		}

        private void SetupCommands()
        {
            DetailClaimCommand = new Command(async (e) =>
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
        public async Task<Message[]> FetchMessagesList()
		{
			var service = new InboxService();
            return await service.FetchInboxList(Settings.UserToken, Settings.UserSSN);
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