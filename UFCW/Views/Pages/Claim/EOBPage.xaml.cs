using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.Services;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Claim
{
    public partial class EOBPage : ContentPage
    {
        ClaimDetail claimDetail;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EOBServiceProvidersPage(claimDetail.CLAIM_NUMBER));
        }

        public EOBPage(ClaimDetail detail)
        {
            InitializeComponent();
            BindingContext = detail;
            claimDetail = detail;
            NavigationPage.SetBackButtonTitle(this, "");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("EOB Page");
        }
    }
}
