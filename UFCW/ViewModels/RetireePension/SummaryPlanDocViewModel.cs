using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services.Models.Pension;
using UFCW.Services.Services.Pension;

namespace UFCW.ViewModels.Pension
{
    public class SummaryPlanDocViewModel: INotifyPropertyChanged
    {
        public SummaryPlanDocViewModel()
        {
            SummaryPlanDocsList = new ObservableCollection<SummaryPlanDoc>();
        }
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<SummaryPlanDoc> SummaryPlanDocsList;
		private bool isBusy = false;

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
		public async Task<SummaryPlanDoc[]> FetchSummaryPlanDocs()
		{
            var pansionService = new PensionService();
            return await pansionService.FetchSummaryPlanDoc(Settings.UserToken, Settings.UserSSN, Settings.UserEmail);
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
