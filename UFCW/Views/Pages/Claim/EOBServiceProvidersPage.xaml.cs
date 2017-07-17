using System;
using System.Collections.Generic;
using UFCW.Services;
using UFCW.ViewModels.Claims;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Claim
{
    public partial class EOBServiceProvidersPage : ContentPage
    {
        EOBServiceProvidersVM serviceProvidersVM;
        long claimNumber = 0;
        public EOBServiceProvidersPage(long _claimumber)
        {
            InitializeComponent();
            claimNumber = _claimumber;
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			serviceProvidersVM = new EOBServiceProvidersVM();
			BindingContext = serviceProvidersVM;
			//ServiceProvidersList.ItemsSource = serviceProvidersVM.serviceProvidersList;
            FetchServiceProviders();
		}

		/// <summary>
		/// Fetchs the service providers list from the server.
		/// </summary>
		public async void FetchServiceProviders()
		{
			serviceProvidersVM.IsBusy = true;
            ClaimDetail[] serviceProviders = await serviceProvidersVM.FetchEOBDetails(claimNumber.ToString());
			if (serviceProviders != null && serviceProviders.Length > 0)
			{
				//ServiceProvidersList.IsVisible = true;
				NoDataLabel.IsVisible = false;
				UpdatePage(serviceProviders);
			}
			else
			{
				NoDataLabel.IsVisible = true;
			}
			serviceProvidersVM.IsBusy = false;
		}

		/// <summary>
		/// Updates the listview 
		/// </summary>
		/// <param name="data">Data.</param>
		private void UpdatePage(ClaimDetail[] data)
		{
            foreach (ClaimDetail detail in data)
			{
                serviceProvidersVM.serviceProvidersList.Add(detail);
			}
		}

		/// <summary>
		/// Handles the Check Issued tapped event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		//protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		//{
		//	var selectedCheck = ((ListView)sender).SelectedItem;
		//	CheckIssued checkIssued = (CheckIssued)selectedCheck;
		//	CheckIssuedDetailPage checksIssuedDetailPage = new CheckIssuedDetailPage();
		//	checksIssuedDetailPage.BindingContext = checkIssued;
		//	await Navigation.PushAsync(checksIssuedDetailPage);
		//	((ListView)sender).SelectedItem = null;
		//}

		protected override void OnAppearing()
		{
			//FetchServiceProviders();
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            //serviceProvidersVM.serviceProvidersList.Clear();
			//NoDataLabel.IsVisible = false;
			//ServiceProvidersList.IsVisible = false;
		}
	}
}
