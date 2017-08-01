using System;
using System.Collections.Generic;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW.Views
{
    public partial class AboutUsPage : ContentPage
    {
        AboutUsViewModel viewModel;
		public bool ifPublicAboutUsRequest = false;
        public AboutUsPage()
        {
            InitializeComponent();
            viewModel = new AboutUsViewModel();
            BindingContext = viewModel;
			
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (ifPublicAboutUsRequest)
			{
				viewModel.FetchPublicAboutUS();
			}
			else
			{
				viewModel.FetchPublicAboutUS();
			}
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
