using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW
{
	public partial class ClaimsReportPage : ContentPage
	{
		public ClaimsReportPage()
		{
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Claims Report Page");
        }
    }
}
