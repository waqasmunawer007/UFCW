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
            FetchHistoryByEmployer();
		}

		/// <summary>
        /// Fetchs the history by employer.
        /// </summary>
		public async void FetchHistoryByEmployer()
		{
			historyByEmployerVM.IsBusy = true;
            HistoryByEmployer[] history = await historyByEmployerVM.FetchHistoryByEmployer();
			if (history != null)
			{
				UpdatePage(history);
			}
			else
			{
				await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION);
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
	}
}
