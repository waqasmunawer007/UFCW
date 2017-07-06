using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Eligibility
{
    public partial class EligibilityMenuPage : ContentPage
    {
        EligibilityMenuVM eligibilityVM;

        public EligibilityMenuPage()
        {
            InitializeComponent();
            eligibilityVM = new EligibilityMenuVM();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = eligibilityVM;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Eligibility Page");
        }
    }
}
