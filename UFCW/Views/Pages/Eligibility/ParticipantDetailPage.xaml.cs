using Plugin.GoogleAnalytics;
using System;
using System.Collections.Generic;
using UFCW.Services.Models.Eligibility;
using UFCW.ViewModels.Eligibility;
using Xamarin.Forms;

namespace UFCW
{
	public partial class ParticipantDetailPage : ContentPage
	{
		public ParticipantDetailPage()
		{
			InitializeComponent();
			BindingContext = App.user; //TODO remove this code once Key-Pairs db integrated
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoogleAnalytics.Current.Tracker.SendView("Participant Detail Page");
        }
    }
}
