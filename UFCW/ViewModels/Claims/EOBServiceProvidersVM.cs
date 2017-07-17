using System;
using System.ComponentModel;
using UFCW.Services.UserService;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services;
using UFCW.Services.Services.Claims;

namespace UFCW.ViewModels.Claims
{
    public class EOBServiceProvidersVM
    {
       
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<ClaimDetail> serviceProvidersList;
		private bool isBusy = false;

		public EOBServiceProvidersVM()
		{
			serviceProvidersList = new ObservableCollection<ClaimDetail>();
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

        public async Task<ClaimDetail[]> FetchEOBDetails(string claimNumber)
		{
			var service = new ClaimService();
            //return await service.FetchClaimEOB(Settings.UserToken, Settings.UserSSN, claimNumber);
            return GetTempServiceProviders();
		}

        ClaimDetail[] GetTempServiceProviders()
        {
            ClaimDetail[] list = new ClaimDetail[2];

			ClaimDetail detail = new ClaimDetail();
			detail.CLAIM_NUMBER = 123123;
			detail.INSURED_INITIALS = "UMAR";
			detail.PATIENT = "SELF";
			detail.COV_TO_DATE = "11/9/2005";
			detail.DEP_TYPE = "Detail?";
			detail.CHARGES = 9876;
			list[0] = detail; 

            ClaimDetail detail2 = new ClaimDetail();
			detail2.CLAIM_NUMBER = 345678;
			detail2.INSURED_INITIALS = "UMAR";
			detail2.PATIENT = "SELF";
			detail2.COV_TO_DATE = "11/9/2005";
			detail2.DEP_TYPE = "Detail?";
			detail2.CHARGES = 9876;
			list[1] = detail2;

            return list;
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