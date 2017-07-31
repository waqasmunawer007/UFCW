using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW
{
	public partial class LinksPage : ContentPage
	{
		public LinksPage()
		{
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Links Page");
        }
    }
}
