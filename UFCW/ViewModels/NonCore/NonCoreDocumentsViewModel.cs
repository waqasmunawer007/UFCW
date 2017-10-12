using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;
using Xamarin.Forms;

namespace UFCW.ViewModels.NonCore
{
	public class NonCoreDocumentsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<Document> documentList;
		public ICommand UrlCommand { set; get; }
		private bool isBusy = false;

		public NonCoreDocumentsViewModel()
		{
			documentList = new ObservableCollection<Document>();
			UrlCommand = new Command<Document>((e) =>
			{
				Document selectedItem = e;
                string url = AppConstants.BaseWebAppURL + selectedItem.Url;
				if (!String.IsNullOrEmpty(url))
				{
					Device.OpenUri(new System.Uri(url));
				}

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

        public ObservableCollection<Document> DocumentList
		{
			get { return documentList; }
			set
			{
				if (documentList != value)
				{
					documentList = value;
					OnPropertyChanged("DocumentList");
				}
			}
		}

		/// <summary>
		/// Fetchs the public news.
		/// </summary>
		/// <returns>The public news.</returns>
		public async Task FetchPublicDocument()
		{
			IsBusy = true;
            this.DocumentList.Clear();
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchPublicNonCoreData();
			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				foreach (Document document in responseData.Documents)
				{

					this.DocumentList.Add(document);
				}
				IsBusy = false;
			}
			else
			{
				IsBusy = false;
				await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE, responseData.Message, "OK");
			}
		}

        /// <summary>
        /// Fetchs the auth non core document.
        /// </summary>
        /// <returns>The auth document.</returns>
		public async Task FetchAuthDocument()
		{
			IsBusy = true;
			this.DocumentList.Clear();
			var service = new NonCoreService();
            NonCoreResponse responseData = await service.FetchAuthNonCoreData(Settings.UserToken, Settings.UserSSN);
			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				foreach (Document document in responseData.Documents)
				{

					this.DocumentList.Add(document);
				}
				IsBusy = false;
			}
			else
			{
				IsBusy = false;
				await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE, responseData.Message, "OK");
			}
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

