using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UFCW
{
	public partial class CustomNavBar : ContentView
	{
		public CustomNavBar()
		{
			InitializeComponent();
		}

		public void OnHamburgerIconTapped(Object sender, EventArgs e)
		{
			var currentPage = App.Current.MainPage;
			var master = currentPage as MasterDetailPage;
			master.IsPresented = true;
		}

		public async void OnCogIconTapped(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}
	}
}

