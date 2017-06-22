using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;

namespace UFCW.ViewModels.ActivePension
{
    public class HistoryByYearVM: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<HistoryByYear> historyByYearList;

		private bool isBusy = false;

		string email = "sam@paysolar.com";
		string token = "0000";
		string ssn = "413112352";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UFCW.ViewModels.ActivePension.HistoryByYearVM"/> class.
        /// </summary>
		public HistoryByYearVM()
		{
			historyByYearList = new ObservableCollection<HistoryByYear>();
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
        /// Fetchs the history by year.
        /// </summary>
        /// <returns>The history by year.</returns>
        public async Task<HistoryByYear[]> FetchHistoryByYear()
		{
			var service = new ActivePensionService();
            return await service.FetchHistoryByYear(token, ssn);
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