using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW
{
	public partial class NewsPage : ContentPage
	{
		public NewsPage()
		{
			InitializeComponent();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("News Page");
        }
    }
}
