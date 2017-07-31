using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class ContributionHistoryYearPage : ContentPage
    {
        HistoryByYearVM historyByYearVM;
		public ContributionHistoryYearPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			historyByYearVM = new HistoryByYearVM();
			BindingContext = historyByYearVM;
            HistoryBYearList.ItemsSource = historyByYearVM.historyByYearList;
		}

		/// <summary>
        /// Fetchs the history by year.
        /// </summary>
		public async void FetchHistoryByYear()
		{
			historyByYearVM.IsBusy = true;
            HistoryByYear[] history = await historyByYearVM.FetchHistoryByYear();
            if (history != null && history.Length > 0)
			{
				HistoryBYearList.IsVisible = true;
				NoDataLabel.IsVisible = false;
				UpdatePage(history);
			}
			else
			{
				HistoryBYearList.IsVisible = false;
				NoDataLabel.IsVisible = true;
			}
			historyByYearVM.IsBusy = false;
		}

		/// <summary>
        /// Updates the page.
        /// </summary>
        /// <param name="data">Data.</param>
		private void UpdatePage(HistoryByYear[] data)
		{
			foreach (HistoryByYear history in data)
			{
                historyByYearVM.historyByYearList.Add(history);
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
			HistoryByYear history = (HistoryByYear)selectedHistory;
			HistoryByYearDetailPage historyDetailPage = new HistoryByYearDetailPage();
			historyDetailPage.BindingContext = history;
			await Navigation.PushAsync(historyDetailPage);
			((ListView)sender).SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			FetchHistoryByYear();
			base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Contribution History (Year) Page");
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			historyByYearVM.historyByYearList.Clear();
            NoDataLabel.IsVisible = false;
            HistoryBYearList.IsVisible = false;
		}
	}
}
