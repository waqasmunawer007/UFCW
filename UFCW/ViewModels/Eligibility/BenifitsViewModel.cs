using System;
using System.Threading.Tasks;
using UFCW.Services.Models.Eligibility.Benifits;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using UFCW.Helpers;

namespace UFCW.ViewModels
{
    public class BenifitsViewModel: INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Benifits> BenifitsList;
        private bool isBusy = false;

        public BenifitsViewModel()
        {
            BenifitsList = new ObservableCollection<Benifits>();
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
        public async Task<Benifits[]> FetchBenifits()
		{
			var eligibilityService = new EligibilityService();
            return await eligibilityService.FetchUserBenifits(Settings.UserToken, Settings.UserSSN, Settings.UserEmail);
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
