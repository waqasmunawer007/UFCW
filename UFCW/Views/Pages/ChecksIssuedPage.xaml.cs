using System;
using System.Collections.Generic;
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
			checksIssuedVM = new ChecksIssuedViewModel();
			BindingContext = checksIssuedVM;
			ChecksIssuedList.ItemsSource = checksIssuedVM.checksIssuedList;
			FetchChecksIssued();
		}

        public async void FetchChecksIssued()
        {
			checksIssuedVM.IsBusy = true;
            CheckIssued[] checks = await checksIssuedVM.FetchChecksIssued();
			UpdatePage(checks);
			checksIssuedVM.IsBusy = false;
        }

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
		}
	}
}
