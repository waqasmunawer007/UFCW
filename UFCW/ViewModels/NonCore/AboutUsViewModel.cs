using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;
using Xamarin.Forms;

namespace UFCW.ViewModels.NonCore
{
	public class AboutUsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public string url = "";
		private bool isBusy = false;

		public AboutUsViewModel(){}
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

		public String URL
		{
			get { return url; }
			set
			{
				if (url != value)
				{
					url = value;
					OnPropertyChanged("URL");
				}
			}
		}

		/// <summary>
		/// Fetchs the public news.
		/// </summary>
		/// <returns>The public news.</returns>
		public async Task FetchPublicAboutUS()
		{
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchPublicNonCoreData();
			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
				URL = responseData.AboutUS;
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert(AppConstants.ERROR_TITLE, responseData.Message, "OK");
			}
	     }
        /// <summary>
        /// Fetchs the authentcated user about us.
        /// </summary>
        /// <returns>The auth about us.</returns>
		public async Task FetchAuthAboutUS()
		{
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchAuthNonCoreData(Settings.UserToken, Settings.UserSSN);
			if (responseData != null && String.IsNullOrEmpty(responseData.Message))
			{
                URL = responseData.AboutUS;
			}
			else
			{
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
