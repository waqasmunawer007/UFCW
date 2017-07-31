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
            BindingContext = viewModel;
            LinksList.ItemsSource = viewModel.LinksList;
            viewModel.FetchPublicLinks();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
	}
}
