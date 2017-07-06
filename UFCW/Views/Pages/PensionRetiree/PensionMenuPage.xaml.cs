using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.Pension;
using UFCW.ViewModels.Pension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class PensionMenuPage : ContentPage
    {
        PensionMenuVM pensionMenuVM;
        public PensionMenuPage()
        {
            InitializeComponent();
            pensionMenuVM = new PensionMenuVM();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = pensionMenuVM;
            }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Retiree Pension Page");
        }
    }
}
