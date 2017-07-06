using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages.Pension
{
    public partial class MyBenifitsPage : ContentPage
    {
        public MyBenifitsPage()
        {
            InitializeComponent();
            BindingContext = App.retiree.My_Benefits;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("My Benefits Page");
        }
    }
}
