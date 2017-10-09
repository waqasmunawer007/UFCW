using System;
using System.Collections.Generic;
using System.Diagnostics;
using UFCW.ViewModels.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ComposeMessagePage : ContentPage
    {
        ComposeMessageVM viewModel;
        public ComposeMessagePage()
        {
            InitializeComponent();
            viewModel = new ComposeMessageVM(Navigation);
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.FetchAdmainMailbox();

        }
	}
}
