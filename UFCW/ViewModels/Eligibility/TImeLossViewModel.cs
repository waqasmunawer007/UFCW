using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.Eligibility;
using UFCW.Services.Models.User;
using UFCW.Services.UserService;

namespace UFCW.ViewModels
{
    public class TimeLossViewModel: INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        public TimeLoss[] timeLossServerResponse;
        public ObservableCollection<TimeLoss> timeLossList;
        private bool isBusy = false;
		

        public TimeLossViewModel()
        {
            timeLossList = new ObservableCollection<TimeLoss>();
        }
        public TimeLoss[] TimeLossServerResponse
		{
			get { return timeLossServerResponse; }
			set
			{
				timeLossServerResponse = value;
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
		/// <summary>
        /// Gets the time loss.
        /// </summary>
        /// <returns>The time loss.</returns>
        public async Task<TimeLoss[]> GetTimeLoss()
        {
            string ssn = "413112352"; //Todo remove this hard code value, once logged in SSN has valid data
			var eligibilityService = new EligibilityService();
            timeLossServerResponse = await eligibilityService.FetchTimeLoss(Settings.UserToken, ssn,Settings.UserEmail);
            return timeLossServerResponse;
        }
    }
}
