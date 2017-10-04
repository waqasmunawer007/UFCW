
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
            MessagesList.ItemsSource = inboxVM.inboxMessagesList;
		}

		
		public async void FetchMailbox()
		{
			inboxVM.IsBusy = true;
            MailboxResponse messages = await inboxVM.FetchMessagesList();
            if (messages != null && messages.InBoxMessages.Count > 0)
			{
				MessagesList.IsVisible = true;
				NoDataLabel.IsVisible = false;
                MessageGrid.IsVisible = true;
				UpdatePage(messages.InBoxMessages);
			}
			else
			{
				NoDataLabel.IsVisible = true;
                MessagesList.IsVisible = false;
                MessageGrid.IsVisible = false;
			}
			inboxVM.IsBusy = false;
		}

		/// <summary>
		/// Updates the listview 
		/// </summary>
		/// <param name="data">Data.</param>
        private void UpdatePage(List<InBoxMessage> inboxMessages)
		{
            foreach (InBoxMessage message in inboxMessages)
			{
                inboxVM.inboxMessagesList.Add(message);
			}
		}

		//protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		//{
		//	var selectedCheck = ((ListView)sender).SelectedItem;
  //          Message message = (Message)selectedCheck;
  //          Debug.WriteLine("This is message from: " + message.From);
		//	//CheckIssuedDetailPage checksIssuedDetailPage = new CheckIssuedDetailPage();
		//	//checksIssuedDetailPage.BindingContext = checkIssued;
		//	//await Navigation.PushAsync(checksIssuedDetailPage);
		//	//((ListView)sender).SelectedItem = null;
		//	//GoogleAnalytics.Current.Tracker.SendEvent("ListView", "ItemTapped", AppConstants.CheckedIssued_Event_Messae, 1);
		//}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            FetchMailbox();
			GoogleAnalytics.Current.Tracker.SendView("Inbox Issued Page");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            inboxVM.inboxMessagesList.Clear();
			NoDataLabel.IsVisible = false;
			MessagesList.IsVisible = false;
		}
	}
}
