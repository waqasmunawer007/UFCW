using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.Services;
using UFCW.ViewModels.Claims;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Claim
{
    public partial class ClaimDetailPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Artina Button Clikced...");
            ClaimDetail detail = (ClaimDetail)BindingContext;
			EOBPage pageEOB = new EOBPage(detail);
			Navigation.PushAsync(pageEOB);
		}

        ClaimsDetailVM claimsDetailVM;

        public ClaimDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            System.Diagnostics.Debug.WriteLine("Inside the constructor of ClaimDetailPage...");
            //claimsDetailVM = new ClaimsDetailVM(Navigation);
            //BindingContext = claimsDetailVM;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Claim Detail Page");
        }
    }
}
