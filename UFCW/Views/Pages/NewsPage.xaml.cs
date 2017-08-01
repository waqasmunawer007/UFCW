using System;
using System.Collections.Generic;
using UFCW.ViewModels;
using UFCW.Views.Pages;
using Xamarin.Forms;

namespace UFCW
{
	public partial class NewsPage : ContentPage
	{
        NewsViewModel viewModel;
        public bool ifPublicNewsRequest = false;
		public NewsPage()
		{
			InitializeComponent();
            viewModel = new NewsViewModel();
			BindingContext = viewModel;
            NewsList.ItemsSource = viewModel.NewsList;	
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (ifPublicNewsRequest)
			{
				viewModel.FetchPublicNews();
			}
			else
			{
                viewModel.FetchAuthNews();
			}
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.IsBusy = false;
            viewModel.NewsList.Clear();
        }

        protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var selectedNews = ((ListView)sender).SelectedItem;
            News news = (News)selectedNews;
            NewsDetailPage newsDetailPage = new NewsDetailPage();
			newsDetailPage.BindingContext = news;
			await Navigation.PushAsync(newsDetailPage);
			((ListView)sender).SelectedItem = null;
		}
	}
}
