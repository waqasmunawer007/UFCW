using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class MyTaxesPage : ContentPage
    {
        public MyTaxesPage()
        {
            InitializeComponent();
            BindingContext = App.retiree.MyTaxes;
            }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("My Taxes Page");
        }
    }
}
