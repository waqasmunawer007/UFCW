using System;
using System.Collections.Generic;
using Plugin.GoogleAnalytics;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW.Views
{
    public partial class NonCoreFAQPage : ContentPage
    {
        NonCoreFAQViewModel viewModel;
        public bool ifPublicFAQRequest;
        public NonCoreFAQPage()
        {
            InitializeComponent();
			viewModel = new NonCoreFAQViewModel();
			BindingContext = viewModel;
            FAQList.ItemsSource = viewModel.FAQList;
			FAQList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				// don't do anything if we just de-selected the row
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			GoogleAnalytics.Current.Tracker.SendView("NonCore FAQ Page");
			if (ifPublicFAQRequest)
			{
                viewModel.FetchPublicFAQ();
			}
			else
			{
                viewModel.FetchAuthFAQ();
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			viewModel.IsBusy = false;
            viewModel.FAQList.Clear();
		}
    }
}
