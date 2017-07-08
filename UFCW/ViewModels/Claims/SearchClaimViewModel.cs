using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using UFCW.Helpers;
using UFCW.Services;
using UFCW.Services.Services.Claims;

namespace UFCW
{
	public class SearchClaimViewModel: INotifyPropertyChanged
	{
		private readonly static DateTime MinDate = DateTime.Parse("Jan 1 1960");
		private readonly static DateTime MaxDate = DateTime.Parse("Dec 31 2050");
        private readonly static DateTime FromDate = DateTime.Parse("Jan 1 1980");

		public DateTime Now => DateTime.Now;
        public DateTime FromDateDefault => FromDate;
		public DateTime MinimumDate => MinDate;
		public DateTime MaximumDate => MaxDate;

		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<ClaimDetail> SearchedClaimsList;
		private bool isBusy = false;

		public SearchClaimViewModel()
		{
			SearchedClaimsList = new ObservableCollection<ClaimDetail>();
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
		/// Gets the claim search filters option.
		/// </summary>
		/// <returns>The claim search filters.</returns>
		public async Task<ClaimFilters> GetClaimSearchFilters()
		{
			var claimService = new ClaimService();
			return await claimService.FetchSearchFilters(Settings.UserToken, Settings.UserSSN);
		}
		/// <summary>
		/// Applies the claim search.
		/// </summary>
		/// <returns>The claim search.</returns>
		/// <param name="claimType">Claim type.</param>
		/// <param name="claimStatus">Claim status.</param>
		/// <param name="fromDate">From date.</param>
		/// <param name="toDate">To date.</param>
		public async Task<ClaimDetail[]> ApplyClaimSearch(string claimType, string claimStatus, string fromDate, string toDate)
		{
			var claimService = new ClaimService();
			return await claimService.SearchClaim(Settings.UserToken, Settings.UserSSN, claimType,claimStatus,fromDate,toDate);
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


