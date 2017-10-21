using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Helpers;
using UFCW.Services.Models.Pension;
using UFCW.Services.Services.Pension;
using Xamarin.Forms;

namespace UFCW.ViewModels.Pension
{
    public class SummaryPlanDocViewModel: INotifyPropertyChanged
    {
        public ICommand ShowUrlCommand { set; get; }
        
        
        public SummaryPlanDocViewModel()
        {
            SummaryPlanDocsList = new ObservableCollection<SummaryPlanDoc>();
            ShowUrlCommand = new Command<SummaryPlanDoc>((e)=> {
                SummaryPlanDoc selectedItem = e;
                string url = selectedItem.Link;
                if (!String.IsNullOrEmpty(url))
                {
                    Device.OpenUri(new System.Uri(url));
                }
               
            });
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
            return await pansionService.FetchSummaryPlanDoc();
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
