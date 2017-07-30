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
    public class EligibilityReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        INavigation Navigation;
        public ICommand DetailEligibilityCommand { get; set; }
        public ObservableCollection<Eligibilty> eligibilityReportData;

		
		private readonly static int PageSize = 10;
		public int TotalPages;
        public int pageNumber;
		private bool isBusy = false;
		private bool isLoading = false;

		public EligibilityReportViewModel(INavigation mainPageNav)
		{
			eligibilityReportData = new ObservableCollection<Eligibilty>();
			Navigation = mainPageNav;
			pageNumber = 0;
			TotalPages = 0;


			DetailEligibilityCommand = new Command(async (e) =>
		    {
                Eligibilty selectedItem = (e as Eligibilty);
		        EligibilityDetailPage detailPage = new EligibilityDetailPage(selectedItem);
			    detailPage.BindingContext = selectedItem;
			    await Navigation.PushAsync(detailPage);
		    });
           
		}

        public void ResetData()
        {
			EligibilityReportData.Clear();
			pageNumber = 0;
			TotalPages = 0;
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
		public bool IsLoading
		{
			get { return isLoading; }
			set
			{
				if (isLoading != value)
				{
					isLoading = value;
					OnPropertyChanged("IsLoading");
				}
			}
		}
        public ObservableCollection<Eligibilty> EligibilityReportData
		{
			get { return eligibilityReportData; }
			set
			{
				if (eligibilityReportData != value)
				{
					eligibilityReportData = value;
					OnPropertyChanged("EligibilityReportData");
				}
			}
		}
		/// <summary>
		/// Loads the more record if user hits bottom of the list view
		/// </summary>
		/// <returns>The more.</returns>
		public async Task LoadMore()
		{
			pageNumber += 1;
			if (pageNumber < TotalPages)
			{
				IsLoading = true;
				await FetchEligibilityReport();
				IsLoading = false;
			}
			else
			{
				pageNumber = 0;
				TotalPages = 0;
			}

		}
		/// <summary>
		/// Applies the claim search.
		/// </summary>
		/// <returns>The claim search.</returns>
		public async Task FetchEligibilityReport()
		{
			var eligibilityService = new EligibilityService();
            EligibilityReportResponse reportData = await eligibilityService.FetchEligibilityReport(Settings.UserToken, Settings.UserSSN, pageNumber, PageSize);
			if (reportData != null)
			{
				TotalPages = reportData.RecordsFiltered;
                foreach (Eligibilty e in reportData.data)
				{
					this.EligibilityReportData.Add(e);
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

	}
}
