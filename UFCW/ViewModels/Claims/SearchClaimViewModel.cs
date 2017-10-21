using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services;
using UFCW.Services.Models.Claims;
using UFCW.Services.Services.Claims;
using UFCW.Views.Pages.Claim;
using Xamarin.Forms;

namespace UFCW
{
    public class SearchClaimViewModel : INotifyPropertyChanged
    {
       
        private readonly static DateTime MinDate = DateTime.Parse("Jan 1 1970");
        private readonly static DateTime MaxDate = DateTime.Parse("Dec 31 2050");
        private static DateTime FromDefaultDate = DateTime.Parse("Jan 1 1980");
        public DateTime MinimumDate => MinDate;
        public DateTime MaximumDate => MaxDate;

		public DateTime toDate = DateTime.Now;
		public DateTime fromDate = FromDefaultDate;
      
        INavigation Navigation;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ClaimDetail> searchedClaimsList;

        public ICommand DetailClaimCommand { get; set; }
        public ICommand SearchClaimCommand { get; set; }
        public ICommand ResetFiltersCommand { get; set; }

        public ObservableCollection<ClaimType> claimTypes; 
		public ObservableCollection<ClaimStatus> claimStatuses;
		public ObservableCollection<Patient> patientTypes;
        int pageNumber = 0;
		private readonly static int PageSize = 5;
        int TotalPages = 0;

        //Search filters Values
        string claimType;
        string claimStatus;
        string searchDate;
        string searchPatient;
        string searchDependent;

        public SearchClaimViewModel(INavigation mainPageNav)
        {
			searchedClaimsList = new ObservableCollection<ClaimDetail>();
            SearchedClaimsList = new ObservableCollection<ClaimDetail>();
			claimTypes = new ObservableCollection<ClaimType>();
			claimStatuses = new ObservableCollection<ClaimStatus>();
			patientTypes = new ObservableCollection<Patient>();
            Navigation = mainPageNav;
            SetupCommands();
		}
        /// <summary>
        /// Setups the commands for Resest,Search And Detail buttons.
        /// </summary>
        private void SetupCommands()
        {
			DetailClaimCommand = new Command(async (e) =>
		   {
			   ClaimDetail selectedItem = (e as ClaimDetail);
			   ClaimDetailPage detailPage = new ClaimDetailPage();
			   detailPage.BindingContext = selectedItem;
			   await Navigation.PushAsync(detailPage);
		   });
			ResetFiltersCommand = new Command(() =>
			{
				ClaimTypeSelectedIndex = 0;
				ClaimStatusSelectedIndex = 0;
				PatientSelectedIndex = 0;
                FirstDependentName = "";
                FromDate = FromDefaultDate;
                ToDate = DateTime.Now;
                SearchedClaimsList.Clear();
			});
			SearchClaimCommand = new Command(() =>
			{
                SearchedClaimsList.Clear();
                pageNumber = 0;
                TotalPages = 0;
                IsBusy = true;

                if (PatientTypes.Count > 0) //make sure Search Option fetched from server before going to hit Search request 
                {
					Patient selectedPatientType = PatientTypes[patientSelectedIndex];
					ClaimType selectedCliamType = ClaimTypes[claimTypeSelectedIndex];
					ClaimStatus selectedClaimStatus = ClaimStatuses[claimStatusSelectedIndex];
					String dependentName = FirstDependentName;
					DateTime selectedFromDate = FromDate;
					DateTime selectedToDate = ToDate;
                    string fromDateString = selectedFromDate.ToString("yyyy-MM-dd");
                    string toDateString = selectedToDate.ToString("yyyy-MM-dd");
					
                    claimType = selectedCliamType.Value;
					claimStatus = selectedClaimStatus.Value;
					searchDate = fromDateString +" - "+toDateString; 
					searchPatient = selectedPatientType.Value;
					searchDependent = dependentName;
					ApplyClaimSearch();
                }
			});
        }


		#region Properties
		private bool isBusy = false;
		private bool isLoading = false;
		int claimTypeSelectedIndex;
		int claimStatusSelectedIndex;
		int patientSelectedIndex;
		String firstDepedentName;

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
		
        public ObservableCollection<ClaimDetail> SearchedClaimsList
		{
            get { return searchedClaimsList;}
			set
			{
				if (searchedClaimsList != value)
                {
                    searchedClaimsList = value;
					OnPropertyChanged("SearchedClaimsList");
				}
			}
		}

        //Claim Type dropdown options
		public ObservableCollection<ClaimType> ClaimTypes
        {
			get { return claimTypes; }
			set
			{
				if (claimTypes != value)
				{
					claimTypes = value;
					OnPropertyChanged("ClaimTypes");
				}
			}
        }
        //Claim Status drop down options
        public ObservableCollection<ClaimStatus> ClaimStatuses
		{
			get { return claimStatuses; }
			set
			{
				if (claimStatuses != value)
				{
					claimStatuses = value;
					OnPropertyChanged("ClaimStatuses");
				}
			}
		}
        //Patient drop down
        public ObservableCollection<Patient> PatientTypes
		{
			get { return patientTypes; }
			set
			{
				if (patientTypes != value)
				{
					patientTypes = value;
					OnPropertyChanged("PatientTypes");
				}
			}
		}

		public DateTime FromDate
		{
            get { return fromDate; }
			set
			{
				if (fromDate != value)
				{
                    fromDate = value;
					OnPropertyChanged("FromDate");
				}
			}
		}
		public DateTime ToDate
		{
			get { return toDate; }
			set
			{
				if (toDate != value)
				{
					toDate = value;
					OnPropertyChanged("ToDate");
				}
			}
		}
        /// <summary>
        /// Gets or sets the first name of the dependent.
        /// </summary>
        /// <value>The first name of the dependent.</value>
		public String FirstDependentName
		{
            get { return firstDepedentName; }
			set
			{
				if (firstDepedentName != value)
				{
					firstDepedentName = value;
					OnPropertyChanged("FirstDependentName");
				}
			}
		}
        /// <summary>
        /// Gets or sets the index of the claim type selected.
        /// </summary>
        /// <value>The index of the claim type selected.</value>
		public int ClaimTypeSelectedIndex
		{
            get { return claimTypeSelectedIndex; }
			set
			{
				if (claimTypeSelectedIndex != value)
				{
					claimTypeSelectedIndex = value;
                    OnPropertyChanged(nameof(ClaimTypeSelectedIndex));
				}
			}
		}
        /// <summary>
        /// Gets or sets the index of the claim status selected.
        /// </summary>
        /// <value>The index of the claim status selected.</value>
		public int ClaimStatusSelectedIndex
		{
			get { return claimStatusSelectedIndex; }
			set
			{
				if (claimStatusSelectedIndex != value)
				{
					claimStatusSelectedIndex = value;
					OnPropertyChanged("ClaimStatusSelectedIndex");
				}
			}
		}
        /// <summary>
        /// Gets or sets the index of the patient selected.
        /// </summary>
        /// <value>The index of the patient selected.</value>
		public int PatientSelectedIndex
		{
			get { return patientSelectedIndex; }
			set
			{
				if (patientSelectedIndex != value)
				{
					patientSelectedIndex = value;
					OnPropertyChanged("PatientSelectedIndex");
				}
			}
		}
        #endregion


        #region Server calls
        /// <summary>
        /// Gets the claim search filters option.
        /// </summary>
        /// <returns>The claim search filters.</returns>
        public async Task GetClaimSearchFilters()
        {
            this.ClaimTypes.Clear();
            this.ClaimStatuses.Clear();
            this.PatientTypes.Clear();

			var claimService = new ClaimService();
            ClaimFilters filters = await claimService.FetchSearchFilters();
			if (filters != null)
			{
                ClaimType emptyClaimType = new ClaimType()
                {
                    Text = "",
                    Value = ""
                };
                this.ClaimTypes.Add(emptyClaimType);
				foreach (ClaimType cType in filters.ClaimTypes)
				{
					this.ClaimTypes.Add(cType);
				}
                ClaimStatus emptyClaimStatus = new ClaimStatus()
				{
					Text = "",
                    Value = ""
				};
                this.ClaimStatuses.Add(emptyClaimStatus);
				foreach (ClaimStatus cStatus in filters.ClaimStatuses)
				{
					this.ClaimStatuses.Add(cStatus);
				}
                Patient emptyPatient = new Patient()
				{
					Text = "",
                    Value = ""
				};
                this.PatientTypes.Add(emptyPatient);
				foreach (Patient patient in filters.Patients)
				{
					this.PatientTypes.Add(patient);
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
				await ApplyClaimSearch();
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
		public async Task ApplyClaimSearch()
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
            parameters.Add(WebApiConstants.EMAIL, Settings.UserEmail);
			parameters.Add(WebApiConstants.ClaimType, claimType);
			parameters.Add(WebApiConstants.ClaimStatus, claimStatus);
			parameters.Add(WebApiConstants.SearchDate, searchDate);
			parameters.Add(WebApiConstants.SearchPatient, searchPatient);
			parameters.Add(WebApiConstants.SearchDependent, searchDependent);
			parameters.Add(WebApiConstants.PageNumber, pageNumber);
			parameters.Add(WebApiConstants.PageSize, PageSize);


			var claimService = new ClaimService();
		    ClaimSearchResponse searchedClaims = await claimService.SearchClaim(parameters);
            if (searchedClaims != null)
            {
                TotalPages = searchedClaims.RecordsFiltered;
				foreach (ClaimDetail d in searchedClaims.Data)
				{
					this.SearchedClaimsList.Add(d);
				}

            }
            IsBusy = false;

		}
        #endregion 

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


