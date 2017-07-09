using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UFCW.Constants;
using UFCW.Services;
using Xamarin.Forms;

namespace UFCW
{
	public partial class SearchClaimPage : ContentPage
	{
		
		SearchClaimViewModel viewModel;
        ObservableCollection<ClaimDetail> sampleData = new ObservableCollection<ClaimDetail>();
		


		public SearchClaimPage()
		{
			InitializeComponent();
            viewModel = new SearchClaimViewModel(Navigation);
			BindingContext = viewModel;
            ClaimsList.ItemsSource = viewModel.SearchedClaimsList;
			AdjustUIStyle(); //adjust Search & Reset button sizes
		}

   //     void Handle_ClaimDetailClicked(object sender, System.EventArgs e)
   //     {
			//var button = sender as Button;
        //    var claimDetail = button.BindingContext as ClaimDetail;
        //}

        //private async void LoadMoreClaims_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        //{
        //    var viewCellDetails = e.Item as ClaimDetail;

        //}
       

		/// <summary>
		/// Adjust the UI style for Reset and Search Buttons.
		/// </summary>
		private void AdjustUIStyle()
		{ 
			SearchButton.HeightRequest = 35;
			SearchButton.FontSize = 14;
			ResetButton.HeightRequest = 35;
			ResetButton.FontSize = 14;
			ResetButton.BackgroundColor = Color.FromHex("EF5350");
		}
		public async void FetchSearchFilterOptions()
		{
			viewModel.IsBusy = true;
			ClaimFilters filters = await viewModel.GetClaimSearchFilters();
			if (filters != null)
			{
				
			}
			else
			{
				//todo show this message in center of the screen, if data list is empty
				await this.DisplayAlert("", AppConstants.Empty_Data_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			viewModel.IsBusy = false;
		}
		/// <summary>
		/// Applies the search filter.
		/// </summary>
		/// <param name="claimType">Claim type.</param>
		/// <param name="claimStatus">Claim status.</param>
		/// <param name="fromDate">From date.</param>
		/// <param name="toDate">To date.</param>
		public async void ApplySearchFilter(string claimType, string claimStatus, string fromDate, string toDate)
		{
			viewModel.IsBusy = true;
			ClaimDetail[] searchedClaims = await viewModel.ApplyClaimSearch(claimType,claimStatus,fromDate,toDate);
			if (searchedClaims != null)
			{
				UpdatePage(searchedClaims);
			}
			else
			{
				//todo show this message in center of the screen, if data list is empty
				await this.DisplayAlert("", AppConstants.Empty_Data_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			viewModel.IsBusy = false;
		}
		private void UpdatePage(ClaimDetail[] data)
		{
			foreach (ClaimDetail claim in data)
			{
				viewModel.SearchedClaimsList.Add(claim);
			}
		}
	}
}
