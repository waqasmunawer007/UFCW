using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Services.Models.Eligibility.Benifits;
using UFCW.ViewModels;
using Xamarin.Forms;

namespace UFCW
{
	public partial class BenefitPlanPage : ContentPage
	{
        BenifitsViewModel benifitsVM;

		public BenefitPlanPage()
		{
		    InitializeComponent();
            benifitsVM = new BenifitsViewModel();
            BindingContext = benifitsVM;
            BenifitsList.ItemsSource = benifitsVM.BenifitsList;
		}

		/// <summary>
		/// Fetchs the benifits list from the server and updates ListView with data
		/// </summary>
        public async void FetchBenifits()
		{
            benifitsVM.IsBusy = true;
            Benifits[] banifits = await benifitsVM.FetchBenifits();
            if (banifits != null && banifits.Length > 0)
			{
                BenifitsList.IsVisible = true;
                NoDataLabel.IsVisible = false;
				UpdatePage(banifits);
			}
			else
			{
				BenifitsList.IsVisible = false;
				NoDataLabel.IsVisible = true;
			}
            benifitsVM.IsBusy = false;
		}

		private void UpdatePage(Benifits[] data)
		{
            foreach (Benifits benifit in data)
			{
                benifitsVM.BenifitsList.Add(benifit);
			}
		}

        protected override void OnAppearing()
        {
            FetchBenifits();
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Benefits Plan Page");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            NoDataLabel.IsVisible = false;
            BenifitsList.IsVisible = false;
            benifitsVM.BenifitsList.Clear();
        }
	}
}
