using System;
using System.Collections.Generic;
using Plugin.GoogleAnalytics;
using UFCW.Services.Models.Inbox;
using UFCW.ViewModels.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class ViewMessagePage : ContentPage
    {
        MessageDetailVM viewModel;
        string messageId;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ComposeMessagePage(messageId));
        }
        public  ViewMessagePage(string messageId)
        {
            InitializeComponent();
            this.messageId = messageId;
            viewModel = new MessageDetailVM();
            BindingContext = viewModel;
        }
		protected async override void OnAppearing()
		{
			base.OnAppearing();
            InBoxMessage message = await viewModel.GetMessage(messageId);
			BindingContext = message;
			GoogleAnalytics.Current.Tracker.SendView("View Message Page Opened");
		}
    }
}
