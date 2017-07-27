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
using UFCW.Services.Services.Claims;
using UFCW.Views.Pages.Claim;
using Xamarin.Forms;

namespace UFCW
{
    public class SearchClaimViewModel : INotifyPropertyChanged
    {
        private readonly static int PageSize = 1;
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
                IsBusy = true;
				Patient selectedPatientType = PatientTypes[patientSelectedIndex];
				ClaimType selectedCliamType = ClaimTypes[claimTypeSelectedIndex];
				ClaimStatus selectedClaimStatus = ClaimStatuses[claimStatusSelectedIndex];
				String dependentName = FirstDependentName;
				DateTime selectedFromDate = FromDate;
				DateTime selectedToDate = ToDate;
                ApplyClaimSearch(pageNumber, selectedCliamType.Value, selectedClaimStatus.Value, "date", selectedPatientType.Value, dependentName);
    //            List<ClaimDetail> list1  = LoadMore(); //Todo add service method here
				//foreach (ClaimDetail d in list1)
				//{
				//	this.SearchedClaimsList.Add(d);
				//}
			});
        }


		#region Properties
		private bool isBusy = false;
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
		
        public ObservableCollection<ClaimDetail> SearchedClaimsList
		{
            get { return searchedClaimsList;}
			set
			{
				if (searchedClaimsList != value)
				{
                    Debug.WriteLine("Property changes called");
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
            ClaimFilters filters = await claimService.FetchSearchFilters(Settings.UserToken, Settings.UserSSN);
			if (filters != null)
			{
                ClaimType emptyClaimType = new ClaimType()
                {
                    Text = "",
                    Value = ""
                };
                this.ClaimTypes.Add(emptyClaimType);
				foreach (ClaimType claimType in filters.ClaimTypes)
				{
					this.ClaimTypes.Add(claimType);
				}
                ClaimStatus emptyClaimStatus = new ClaimStatus()
				{
					Text = "",
                    Value = ""
				};
                this.ClaimStatuses.Add(emptyClaimStatus);
				foreach (ClaimStatus claimStatus in filters.ClaimStatuses)
				{
					this.ClaimStatuses.Add(claimStatus);
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
        /// Applies the claim search.
        /// </summary>
        /// <returns>The claim search.</returns>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="claimType">Claim type.</param>
        /// <param name="claimStatus">Claim status.</param>
        /// <param name="searchDate">Search date.</param>
        /// <param name="searchPatient">Search patient.</param>
        /// <param name="searchDependent">Search dependent.</param>
		public async Task ApplyClaimSearch(int pageNumber,string claimType, string claimStatus, string searchDate, string searchPatient,string searchDependent)
		{
			
			Dictionary<string, object> parameters = new Dictionary<string, object>();
            //Todo uncomment this code once the search works with dynamic values
			//parameters.Add(WebApiConstants.TOKEN, Settings.UserToken);
			//parameters.Add(WebApiConstants.SSN, Settings.UserSSN);
			//parameters.Add(WebApiConstants.ClaimType, claimType);
			//parameters.Add(WebApiConstants.ClaimStatus, claimStatus);
			//parameters.Add(WebApiConstants.SearchDate, searchDate);
			//parameters.Add(WebApiConstants.SearchPatient, searchPatient);
			//parameters.Add(WebApiConstants.SearchDependent, searchDependent);
			//parameters.Add(WebApiConstants.PageNumber, pageNumber);
			//parameters.Add(WebApiConstants.PageSize, PageSize);

            //Todo remove this code once the search works with dynamic search criteria
			parameters.Add(WebApiConstants.TOKEN, "0494");
			parameters.Add(WebApiConstants.SSN, "254049432");
			parameters.Add(WebApiConstants.ClaimType,"MED");
			parameters.Add(WebApiConstants.ClaimStatus,"I");
			parameters.Add(WebApiConstants.SearchDate,"2003-01-11 - 2017-01-11");
			parameters.Add(WebApiConstants.SearchPatient,"");
			parameters.Add(WebApiConstants.SearchDependent,"");
			parameters.Add(WebApiConstants.PageNumber, pageNumber);
			parameters.Add(WebApiConstants.PageSize, PageSize);


			var claimService = new ClaimService();
		    ClaimDetail[] searchedClaims = await claimService.SearchClaim(parameters);
            Debug.WriteLine("Total records "+ searchedClaims.Length);
			foreach (ClaimDetail d in searchedClaims)
			{
				this.SearchedClaimsList.Add(d);
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
        public static int PageCount = 0;
        public static int TotalPages = 3;
        public bool isLoading;
        public List<ClaimDetail> LoadMore()
		{
            List<ClaimDetail> c = new List<ClaimDetail>();
            if (PageCount <= TotalPages)
            {
				Debug.WriteLine("In Load More");
                isLoading = true;
                PageCount++;
				ClaimDetail c1 = new ClaimDetail();
				c1.CLAIM_NUMBER = 1212;
				c1.INSURED_INITIALS = "abs";
				c1.PATIENT = "SELF";
				c1.DENTAL_SERVICE = "Dental";
				c1.CLAIM_STATUS = "Processed";
				c1.CLAIM_TYPE = "Dental";
				c1.DateCreated = "05/06/2017";//?????????

				//Claimant Information
				c1.INSURED_LAST_NAME = "RA BRANDEL";
				c1.ADDRESS1 = "800 QUACCO RD   247 ";
				c1.ADDRESS2 = "800 QUACCO RD   786";
				c1.CITY = "SAVANNAH";
				c1.STATE_CODE = "12345";
				c1.ZIP_CODE = 54000;
				c1.PATIENT = "SELF";
				c1.GENDER = "F";
				c1.AGE = 63;

				c1.EMPLOYER_NAME = "KROG.-SAVON-SV-PL D";
				c1.COV_FROM_DATE = "4/1/2002";
				c1.COV_TO_DATE = "10/1/2005";
				c1.FUND_ID = "AT MEAT RET-PL M-HI";
				c1.PLAN_ID = "D";
				c1.LOCAL_NUMBER = 1996;

				//Dental Summary
				c1.YTD_DENTAL = "162.00";
				c1.DENTAL_DEDUCTION = "25.00";
				c1.EXAM_CLEAN_DATE = "11/9/2005 12:00:00 AM";
				c1.LT_DENTAL = "1453.80";
				c1.LT_ORTHODONTIC = "0.00";
				c1.X_RAY_DATE = "11/9/2005";
				c1.PAY_REMARKS = "KROG.-SAVON-SV-PL D ";


				ClaimDetail c2 = new ClaimDetail();
				c2.CLAIM_NUMBER = 1213;
				c2.INSURED_INITIALS = "absdsd xfr";
				c2.PATIENT = "SELF";
				c2.DENTAL_SERVICE = "Dental";

				ClaimDetail c3 = new ClaimDetail();
				c3.CLAIM_NUMBER = 1214;
				c3.INSURED_INITIALS = "xyzw";
				c3.PATIENT = "SELF";
				c3.DENTAL_SERVICE = "Dental";

				ClaimDetail c4 = new ClaimDetail();
				c4.CLAIM_NUMBER = 545656;
				c4.INSURED_INITIALS = "stve";
				c4.PATIENT = "SELF";
				c4.DENTAL_SERVICE = "Dental";

                c.Add(c1);
                Debug.WriteLine("First Element added");
				c.Add(c2);
				c.Add(c3);
				c.Add(c4);
                isLoading = false;
            }

            return c;
		}
	}
}


