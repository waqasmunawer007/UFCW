
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.GoogleAnalytics;
using UFCW.Constants;
using UFCW.Services.Models.Inbox;
using UFCW.ViewModels.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class InboxPage : ContentPage
    {
        InboxViewModel inboxVM;
        public bool ifPublicNewsRequest = true;
		public InboxPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
            inboxVM = new InboxViewModel(Navigation);
			BindingContext = inboxVM;
            MessagesList.ItemsSource = inboxVM.messagesList;
		}

		
		public async void FetchMessagesList()
		{
			inboxVM.IsBusy = true;
            Message[] messages = await inboxVM.FetchMessagesList();
			if (messages != null && messages.Length > 0)
			{
				MessagesList.IsVisible = true;
				NoDataLabel.IsVisible = false;
				UpdatePage(messages);
			}
			else
			{
				NoDataLabel.IsVisible = true;
			}
			inboxVM.IsBusy = false;
		}

		/// <summary>
		/// Updates the listview 
		/// </summary>
		/// <param name="data">Data.</param>
        private void UpdatePage(Message[] data)
		{
            foreach (Message message in data)
			{
                inboxVM.messagesList.Add(message);
			}
		}

		protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var selectedCheck = ((ListView)sender).SelectedItem;
            Message message = (Message)selectedCheck;
            Debug.WriteLine("This is message from: " + message.From);
			//CheckIssuedDetailPage checksIssuedDetailPage = new CheckIssuedDetailPage();
			//checksIssuedDetailPage.BindingContext = checkIssued;
			//await Navigation.PushAsync(checksIssuedDetailPage);
			//((ListView)sender).SelectedItem = null;
			//GoogleAnalytics.Current.Tracker.SendEvent("ListView", "ItemTapped", AppConstants.CheckedIssued_Event_Messae, 1);
		}

		protected override void OnAppearing()
		{
            FetchMessagesList();
			base.OnAppearing();
			GoogleAnalytics.Current.Tracker.SendView("Inbox Issued Page");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            inboxVM.messagesList.Clear();
			NoDataLabel.IsVisible = false;
			MessagesList.IsVisible = false;
		}
	}
}
