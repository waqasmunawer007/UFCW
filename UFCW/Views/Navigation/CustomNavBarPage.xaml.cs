using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UFCW
{
	public partial class CustomNavBarPage : ContentPage
	{
		public CustomNavBarPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}
	}
}

