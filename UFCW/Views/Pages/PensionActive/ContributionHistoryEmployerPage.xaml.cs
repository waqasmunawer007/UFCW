using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class ContributionHistoryEmployerPage : ContentPage
    {
        HistoryByEmployerVM historyByEmployerVM;
		public ContributionHistoryEmployerPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			historyByEmployerVM = new HistoryByEmployerVM();
			BindingContext = historyByEmployerVM;
            HistoryByEmployerList.ItemsSource = historyByEmployerVM.historyByEmployerList;

		}

		/// <summary>
        /// Fetchs the history by employer.
        /// </summary>
		public async void FetchHistoryByEmployer()
		{
			historyByEmployerVM.IsBusy = true;
            HistoryByEmployer[] history = await historyByEmployerVM.FetchHistoryByEmployer();
            if (history != null && history.Length > 0)
			{
                HistoryByEmployerList.IsVisible = true;
                NoDataLabel.IsVisible = false;
				UpdatePage(history);
			}
			else
			{
				HistoryByEmployerList.IsVisible = false;
				NoDataLabel.IsVisible = true;
			}
			historyByEmployerVM.IsBusy = false;
		}

		/// <summary>
        /// Updates the page.
        /// </summary>
        /// <param name="data">Data.</param>
		private void UpdatePage(HistoryByEmployer[] data)
		{
            foreach (HistoryByEmployer history in data)
			{
                historyByEmployerVM.historyByEmployerList.Add(history);
			}
		}

		/// <summary>
        /// Handles the item tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
		protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
            var selectedHistory = ((ListView)sender).SelectedItem;
            HistoryByEmployer history = (HistoryByEmployer)selectedHistory;
            HistoryByEmployerDetailPage historyDetailPage = new HistoryByEmployerDetailPage();
			historyDetailPage.BindingContext = history;
			await Navigation.PushAsync(historyDetailPage);
			((ListView)sender).SelectedItem = null;
		}

		protected override void OnAppearing()
		{
            FetchHistoryByEmployer();
			base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Contribution History (Employer) Page");
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            historyByEmployerVM.historyByEmployerList.Clear();
            NoDataLabel.IsVisible = false;
            HistoryByEmployerList.IsVisible = false;
		}
	}
}
