using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Services.Models.NonCore;
using UFCW.Services.Services.NonCore;

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
			IsBusy = true;
			var service = new NonCoreService();
			NonCoreResponse responseData = await service.FetchPublicNonCoreData();
			if (responseData != null)
			{
                URL = responseData.AboutUS;
			}
			IsBusy = false;
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
