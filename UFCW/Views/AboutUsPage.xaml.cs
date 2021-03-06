﻿using System;
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
			
			
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("About Us Page");
			viewModel = new AboutUsViewModel();
			
			if (ifPublicAboutUsRequest)
			{
                await viewModel.FetchPublicAboutUS();
			}
			else
			{
                await viewModel.FetchAuthAboutUS();
			}
            BindingContext = viewModel;
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
