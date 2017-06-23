using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using UFCW.Services.Models.Eligibility;
using System.Threading.Tasks;
using UFCW.Helpers;

namespace UFCW.ViewModels.Eligibility
{
	public class DependentsViewModel:INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Dependant> dependentsList;
		private bool isBusy = false;
		
		public DependentsViewModel()
		{
            dependentsList = new ObservableCollection<Dependant>();
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

        public async Task<Dependant[]> FetchDependents()
		{
			var eligibilityService = new EligibilityService();
            return await eligibilityService.FetchDependents(Settings.UserToken, Settings.UserSSN, Settings.UserEmail);
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