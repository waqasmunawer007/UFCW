using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace UFCW
{
	public partial class DashboardPage : ContentPage
	{
		public DashboardPage()
		{
			InitializeComponent();

			BindingContext = new DashboardViewModel();
		}

		public async void NavigateToGrialSettingsPage()
		{
			await Navigation.PushAsync(new GrialDemoSettings());
		}
	}
}