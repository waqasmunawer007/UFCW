using System;
using System.Collections.Generic;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW
{
	public partial class LinksPage : ContentPage
	{
		LinksViewModel viewModel;
		public LinksPage()
		{
			InitializeComponent();
            viewModel = new LinksViewModel();
            LinksList.ItemsSource = viewModel.LinksList;
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.FetchPublicLinks();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
			viewModel.IsBusy = false;
            viewModel.LinksList.Clear();
        }
	}
}
