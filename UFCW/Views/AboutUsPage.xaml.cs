using System;
using System.Collections.Generic;
using Plugin.GoogleAnalytics;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW.Views
{
    public partial class AboutUsPage : ContentPage
    {
        AboutUsViewModel viewModel;
		public bool ifPublicAboutUsRequest = false;
        public AboutUsPage()
        {
            InitializeComponent();
            viewModel = new AboutUsViewModel();
            BindingContext = viewModel;
			
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("About Us Page");
			if (ifPublicAboutUsRequest)
			{
				viewModel.FetchPublicAboutUS();
			}
			else
			{
                viewModel.FetchAuthAboutUS();
			}
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
