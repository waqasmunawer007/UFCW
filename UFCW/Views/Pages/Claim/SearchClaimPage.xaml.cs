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
		public SearchClaimPage()
		{
			InitializeComponent();
			viewModel = new SearchClaimViewModel();
			BindingContext = viewModel;
			ClaimsList.ItemsSource = PrePareSampleData();
			//FetchFAQs();

			UpdateUIStyle();
		}

		private ObservableCollection<ClaimDetail> PrePareSampleData()
		{
			ObservableCollection<ClaimDetail> sampleData = new ObservableCollection<ClaimDetail>();
			ClaimDetail c1 = new ClaimDetail();
			c1.CLAIM_NUMBER = 1212;
			c1.INSURED_INITIALS = "abs";
			c1.PATIENT = "SELF";
			c1.DENTAL_SERVICE = "Dental";

			ClaimDetail c2 = new ClaimDetail();
			c2.CLAIM_NUMBER = 1213;
			c2.INSURED_INITIALS = "absdsd";
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

			sampleData.Add(c1);
			sampleData.Add(c2);
			sampleData.Add(c3);
			sampleData.Add(c4);
			return sampleData;
		}

		/// <summary>
		/// Updates the UI style for Reset and Search Buttons.
		/// </summary>
		private void UpdateUIStyle()
		{ 
			SearchButton.HeightRequest = 35;
			SearchButton.FontSize = 12;
			ResetButton.HeightRequest = 35;
			ResetButton.FontSize = 12;
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
