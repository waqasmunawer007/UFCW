using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.ActivePension;
using UFCW.Services.Services.ActivePension;

namespace UFCW.ViewModels.ActivePension
{
    public class HistoryByEmployerVM: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<HistoryByEmployer> historyByEmployerList;
		private bool isBusy = false;

		public HistoryByEmployerVM()
		{
			historyByEmployerList = new ObservableCollection<HistoryByEmployer>();
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
        /// Fetchs the history by employer.
        /// </summary>
        /// <returns>The history by employer.</returns>
		public async Task<HistoryByEmployer[]> FetchHistoryByEmployer()
		{
            var service = new ActivePensionService();
            return await service.FetchHistoryByEmployer();
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