using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW.Views.Pages
{
    public partial class TimeLossDetailsPage : ContentPage
    {
        public TimeLossDetailsPage()
        {
            InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Time Loss Detail Page");
        }
    }
}
