﻿using System;
using Xamarin.Forms;

namespace UFCW
{
	public partial class MainMenuPage : ContentPage
	{
		private readonly INavigation _navigation;

		public MainMenuPage(INavigation navigation)
		{
			InitializeComponent();

			_navigation = navigation;

			BindingContext = new SamplesViewModel(navigation);
		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var sample = sampleListView.SelectedItem as Sample;

			if (sample != null)
			{
				if (sample.PageType == typeof(RootPage))
				{
					await DisplayAlert("Hey", string.Format("You are already here, on sample {0}.", sample.Name), "OK");
				}
				else
				{
					await sample.NavigateToSample(_navigation);
				}

				sampleListView.SelectedItem = null;
			}
		}

		private async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}

		public void OnBtnCustomClicked()
		{
			//var uri = "mailto:hello@grialkit.com?subject=I%20want%20a%20custom%20theme%20for%20my%20Grial%20app&body=Please%20leave%20us%20your%20comments.";
			var uri = "http://grialkit.com/getquote";
			Device.OpenUri(new Uri(uri));
		}
	}
}