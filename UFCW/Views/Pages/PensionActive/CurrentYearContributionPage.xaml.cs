﻿using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class CurrentYearContributionPage : ContentPage
    {
        CurrentYearContributionVM contributionVM;
        public CurrentYearContributionPage()
        {
            InitializeComponent();
            contributionVM = new CurrentYearContributionVM();
        }

        async Task FetchCurrentYearContribution()
        {
           CurrentYearContribution currentYearContributon = await contributionVM.FetchCurrentYearContribution();
            if (currentYearContributon != null)
            {
				BindingContext = contributionVM.currentYearContribution;
            }
            else
            {
               await this.DisplayAlert(AppConstants.ERROR_TITLE, AppConstants.ERROR_MESSAGE, null, AppConstants.DIALOG_OK_OPTION); 
            }
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            FetchCurrentYearContribution();
            GoogleAnalytics.Current.Tracker.SendView("Current Year Contribution Page");
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

    }
}
