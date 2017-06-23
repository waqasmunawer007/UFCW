using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels.Eligibility;
using UFCW.Views.Pages;
using Xamarin.Forms;

namespace UFCW
{
	public partial class ChecksIssuedPage : ContentPage
	{
        ChecksIssuedViewModel checksIssuedVM;
		public ChecksIssuedPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			checksIssuedVM = new ChecksIssuedViewModel();
			BindingContext = checksIssuedVM;
			ChecksIssuedList.ItemsSource = checksIssuedVM.checksIssuedList;
			FetchChecksIssued();
		}

		/// <summary>
		/// Fetchs the issued checks list from the server.
		/// </summary>
        public async void FetchChecksIssued()
        {
			checksIssuedVM.IsBusy = true;
            CheckIssued[] checks = await checksIssuedVM.FetchChecksIssued();
			if (checks != null)
			{
				UpdatePage(checks);
			}
			else
			{
				//todo show this message in center of the screen, if data list is empty
				await this.DisplayAlert("", AppConstants.Empty_Data_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
			}
			checksIssuedVM.IsBusy = false;
        }

		/// <summary>
		/// Updates the listview 
		/// </summary>
		/// <param name="data">Data.</param>
		private void UpdatePage(CheckIssued[] data)
		{
			foreach (CheckIssued checkDetail in data)
			{
                checksIssuedVM.checksIssuedList.Add(checkDetail);
			}
		}

		/// <summary>
		/// Handles the Check Issued tapped event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
            var selectedCheck = ((ListView)sender).SelectedItem;
            CheckIssued checkIssued = (CheckIssued)selectedCheck;
            CheckIssuedDetailPage checksIssuedDetailPage = new CheckIssuedDetailPage();
			checksIssuedDetailPage.BindingContext = checkIssued;
			await Navigation.PushAsync(checksIssuedDetailPage);
            ((ListView)sender).SelectedItem = null;
		}
	}
}
