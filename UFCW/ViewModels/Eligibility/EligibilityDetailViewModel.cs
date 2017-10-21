using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Helpers;
using UFCW.Services.Models.Eligibility;
using UFCW.Services.UserService;
using UFCW.Views.Pages.Eligibility;
using Xamarin.Forms;

namespace UFCW.ViewModels.Eligibility
{
    public class EligibilityDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private EligibilityDetail eligibilityDetail;
        private Eligibilty eligibility;
		private bool isBusy = false;

		public EligibilityDetailViewModel()
		{
           
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

		public Eligibilty EligibilityObj
		{
			get { return eligibility; }
			set
			{
				if (eligibility != value)
				{
					eligibility = value;
					OnPropertyChanged("EligibilityObj");
				}
			}
		}

        public EligibilityDetail EligibilityDetail
		{
			get { return eligibilityDetail; }
			set
			{
				if (eligibilityDetail != value)
				{
					eligibilityDetail = value;
					OnPropertyChanged("EligibilityDetailItem");
				}
			}
		}
		
		/// <summary>
		/// Applies the claim search.
		/// </summary>
		/// <returns>The claim search.</returns>
		public async Task FetchEligibilityDetail(string eligibilityId)
		{
            IsBusy = true;
			var eligibilityService = new EligibilityService();
            EligibilityDetail detail = await eligibilityService.FetchEligibilityDetail(eligibilityId);
			if (detail != null)
			{
                this.EligibilityDetail = detail;
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
