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
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<Claim> SearchedClaimsList;
		private bool isBusy = false;

		public SearchClaimViewModel()
		{
			SearchedClaimsList = new ObservableCollection<Claim>();
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
		/// Applies the claim search based on different filter values.
		/// </summary>
		/// <returns>The claim search.</returns>
		/// <param name="claimType">Claim type.</param>
		/// <param name="claimStatus">Claim status.</param>
		/// <param name="fromDate">From date.</param>
		/// <param name="toDate">To date.</param>
		public async Task<Claim[]> ApplyClaimSearch(string claimType, string claimStatus, string fromDate, string toDate)
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


