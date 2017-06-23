using System;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;

namespace UFCW.ViewModels.ActivePension
{
    public class CurrentYearContributionVM: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        private CurrentYearContribution _currentYearContribution;
		private bool isBusy = false;

		/// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.ActivePension.CurrentYearContributionVM"/> class.
        /// </summary>
		public CurrentYearContributionVM()
		{
            _currentYearContribution = new CurrentYearContribution();
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
        /// Gets or sets the current year contribution.
        /// </summary>
        /// <value>The current year contribution.</value>
		public CurrentYearContribution currentYearContribution
		{
			get { return _currentYearContribution; }
			set
			{
				if (_currentYearContribution != value)
				{
					_currentYearContribution = value;
					OnPropertyChanged("currentYearContribution");
				}
			}
		}

		/// <summary>
        /// Fetchs the current year contribution.
        /// </summary>
        /// <returns>The current year contribution.</returns>
		public async Task<CurrentYearContribution> FetchCurrentYearContribution()
		{
			var pensionService = new ActivePensionService();
            currentYearContribution = await pensionService.FetchCurrentYearContribution(Settings.UserToken, Settings.UserSSN);
            return currentYearContribution;
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
