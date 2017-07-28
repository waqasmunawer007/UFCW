using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UFCW.Constants;
using UFCW.Services;
using UXDivers.Artina.Shared;
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
			ClaimsList.ItemAppearing += (sender, e) =>
             {
                 int itemsCount = viewModel.SearchedClaimsList.Count;
                 if (viewModel.IsLoading || itemsCount == 0)
                     return;
                 ClaimDetail lastClaimCellItem = e.Item as ClaimDetail;
                 //hit bottom!
                 if (lastClaimCellItem.CLAIM_NUMBER == viewModel.SearchedClaimsList[itemsCount - 1].CLAIM_NUMBER)
                 {
                     viewModel.LoadMore();
                 }
             };
			AdjustUIStyle(); //adjust Search & Reset button sizes
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FetchSearchFilterOptions();
        }
        /// <summary>
        /// Adjust the UI style for Reset and Search Buttons.
        /// </summary>
        private void AdjustUIStyle()
		{
			if (Device.RuntimePlatform == Device.iOS)
			{
				DependentNameEntry.Style = (Style)Application.Current.Resources["ArtinaRoundedEntryStyle"]; //apply rounded rect style
			}
			else if (Device.RuntimePlatform == Device.Android)
			{
				DependentNameEntry.Style = (Style)Application.Current.Resources["ArtinaEntryStyle"]; //apply bottom line style
			}
			SearchButton.HeightRequest = 35;
			SearchButton.FontSize = 14;
			ResetButton.HeightRequest = 35;
			ResetButton.FontSize = 14;
			ResetButton.BackgroundColor = Color.FromHex("EF5350");
		}
		public async void FetchSearchFilterOptions()
		{
			//viewModel.IsBusy = true;
			await viewModel.GetClaimSearchFilters();
			//viewModel.IsBusy = false;
		}
	}
}
