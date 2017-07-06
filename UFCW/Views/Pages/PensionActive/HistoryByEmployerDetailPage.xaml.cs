using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class HistoryByEmployerDetailPage : ContentPage
    {
        public HistoryByEmployerDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("History By Employer Detail Page");
        }
    }
}
