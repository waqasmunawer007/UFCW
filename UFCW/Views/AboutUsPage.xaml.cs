using System;
using System.Collections.Generic;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW.Views
{
    public partial class AboutUsPage : ContentPage
    {
        AboutUsViewModel viewModel;
        public AboutUsPage()
        {
            InitializeComponent();
            viewModel = new AboutUsViewModel();
            BindingContext = viewModel;
			viewModel.FetchPublicAboutUS();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
		

        }
    }
}
