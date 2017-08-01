using System;
using System.Collections.Generic;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW
{
	public partial class LinksPage : ContentPage
	{
		LinksViewModel viewModel;
        public bool ifPublicLinksRequest;
		public LinksPage()
		{
			InitializeComponent();
            viewModel = new LinksViewModel();
            BindingContext = viewModel;
            LinksList.ItemsSource = viewModel.LinksList;
			LinksList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				// don't do anything if we just de-selected the row
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (ifPublicLinksRequest)
			{
				viewModel.FetchPublicLinks();
			}
			else
			{
                viewModel.FetchAuthLinks();
			}
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.IsBusy = false;
            viewModel.LinksList.Clear();
        }
	}
}
