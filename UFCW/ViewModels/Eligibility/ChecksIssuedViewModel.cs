using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using UFCW.Services.Models.Eligibility;
using System.Threading.Tasks;
using UFCW.Helpers;

namespace UFCW.ViewModels.Eligibility
{
    public class ChecksIssuedViewModel: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<CheckIssued> checksIssuedList;
		private bool isBusy = false;

		

		public ChecksIssuedViewModel()
		{
			checksIssuedList = new ObservableCollection<CheckIssued>();
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

		public async Task<CheckIssued[]> FetchChecksIssued()
		{
            string ssn = "413112352"; //Todo remove this hard code value, once logged in SSN has valid data
			var beniftisService = new EligibilityService();
            return await beniftisService.FetchChecksIssued(Settings.UserToken, ssn, Settings.UserEmail);
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