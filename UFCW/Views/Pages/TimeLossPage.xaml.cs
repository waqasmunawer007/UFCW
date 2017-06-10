using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels;
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
	}
}
