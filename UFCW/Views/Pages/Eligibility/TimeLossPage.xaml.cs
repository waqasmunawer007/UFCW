using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Helpers;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels;
using UFCW.Views.Pages;
using Xamarin.Forms;

namespace UFCW
{
	public partial class TimeLossPage : ContentPage
	{
        
        TimeLossViewModel timeLossViewModel;
		public TimeLossPage()
		{
			InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
            timeLossViewModel = new TimeLossViewModel();
            BindingContext = timeLossViewModel;
            TimeLossList.ItemsSource = timeLossViewModel.timeLossList;
		}
		/// <summary>
		/// Gets the time losses list from the server
		/// </summary>
		/// <returns>The time losses.</returns>
        private async Task GetTimeLosses()
        {
            timeLossViewModel.IsBusy = true;
			TimeLoss[] timeLossServerResponse = await timeLossViewModel.GetTimeLoss();
            if (timeLossServerResponse != null && timeLossServerResponse.Length > 0)
			{
                TimeLossList.IsVisible = true;
                NoDataLabel.IsVisible = false;
                UpdatePage(timeLossServerResponse);
            }
    		else
			{
				TimeLossList.IsVisible = false;
				NoDataLabel.IsVisible = true;
			}
            timeLossViewModel.IsBusy = false;
        }

		private void UpdatePage(TimeLoss[] data)
		{
            foreach (TimeLoss timeLoss in data)
			{
                timeLossViewModel.timeLossList.Add(timeLoss);
			}
		}
        /// <summary>
        /// Handles the TimeLoss item tapped event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
            var selectedTimeLoss = ((ListView)sender).SelectedItem;
            TimeLoss timeLoss = (TimeLoss)selectedTimeLoss;
            TimeLossDetailsPage timeLossDetailPage = new TimeLossDetailsPage();
            timeLossDetailPage.BindingContext = timeLoss;
            await Navigation.PushAsync(timeLossDetailPage);
            ((ListView)sender).SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			GetTimeLosses();
			base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Time Loss Page");
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			timeLossViewModel.timeLossList.Clear();
            NoDataLabel.IsVisible = false;
            TimeLossList.IsVisible = false;
		}
	}
}
