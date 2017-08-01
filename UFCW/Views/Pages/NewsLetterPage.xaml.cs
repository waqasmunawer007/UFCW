using System;
using System.Collections.Generic;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW.Views.Pages
{
    public partial class NewsLetterPage : ContentPage
    {
        NewsLetterViewModel viewModel;
        public bool ifPublicNewsLetterRequest;
        public NewsLetterPage()
        {
            InitializeComponent();
            viewModel = new NewsLetterViewModel();
			BindingContext = viewModel;
            NewsLetterList.ItemsSource = viewModel.NewsLetterList;
			NewsLetterList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
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
			if (ifPublicNewsLetterRequest)
			{
                viewModel.FetchPublicNewsLetter();
			}
			else
			{
                viewModel.FetchAuthNewsLetter();
			}
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.IsBusy = false;
            viewModel.NewsLetterList.Clear();
        }
    }
}
