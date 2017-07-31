using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW
{
	public partial class EligibilityReportPage : ContentPage
	{
		public EligibilityReportPage()
		{
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Eligibility Report Page");
        }
    }
}
