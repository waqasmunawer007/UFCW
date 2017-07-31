using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW
{
	public partial class SelfPaymentPage : ContentPage
	{
		public SelfPaymentPage()
		{
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Self Payment Page");
        }
    }
}
