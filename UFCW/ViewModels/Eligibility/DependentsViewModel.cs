using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using UFCW.Services.Models.Eligibility;
using System.Threading.Tasks;

namespace UFCW.ViewModels.Eligibility
{
	public class DependentsViewModel:INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Dependant> dependentsList;

		private bool isBusy = false;

		string email = "sam@paysolar.com";
		string token = "0000";
		string ssn = "413112352";

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
			var beniftisService = new EligibilityService();
            return await beniftisService.FetchDependents(token, ssn, email);
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