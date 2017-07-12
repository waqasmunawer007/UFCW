using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services;
using UFCW.Services.Services.Claims;

namespace UFCW.ViewModels.Claims
{
    public class EOBViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<ClaimDetail> checksIssuedList;
		private bool isBusy = false;

        public EOBViewModel()
        {
            checksIssuedList = new ObservableCollection<ClaimDetail>();
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

		public async Task<ClaimDetail[]> FetchChecksIssued()
		{
			var service = new ClaimService();
            return await service.FetchClaimEOB(Settings.UserToken, Settings.UserSSN, Settings.UserEmail);
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