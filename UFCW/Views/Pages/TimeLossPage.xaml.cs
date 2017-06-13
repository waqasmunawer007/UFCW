using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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
            timeLossViewModel = new TimeLossViewModel();
            BindingContext = timeLossViewModel;
            TimeLossList.ItemsSource = timeLossViewModel.timeLossList;
             GetTimeLosses();
		}
		/// <summary>
		/// Gets the time losses list from the server
		/// </summary>
		/// <returns>The time losses.</returns>
        private async Task GetTimeLosses()
        {
            timeLossViewModel.IsBusy = true;
            string email = "sam@paysolar.com";
            string token = "0000";
            string ssn = "413112352";
           TimeLoss[] timeLossServerResponse = await timeLossViewModel.GetTimeLoss(token, ssn, email);
            if (timeLossServerResponse != null)
            {
                Debug.WriteLine("Time loss found " + timeLossServerResponse.Length);
                UpdatePage(timeLossServerResponse);
            }
            else
            {
				Debug.WriteLine("Time loss not found "); 
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
		}
	}
}
