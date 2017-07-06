using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class HistoryByYearDetailPage : ContentPage
    {
        public HistoryByYearDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("History By Year Detail Page");
        }
    }
}
