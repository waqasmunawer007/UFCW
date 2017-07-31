using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages
{
    public partial class CheckIssuedDetailPage : ContentPage
    {
        public CheckIssuedDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Check Issued Detial Page");
        }
    }
}
