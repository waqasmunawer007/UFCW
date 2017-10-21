
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
            MessagesList.ItemsSource = inboxVM.InboxMessagesList;
			MessagesList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				// don't do anything if we just de-selected the row
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
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
                inboxVM.InboxMessagesList.Add(message);
			}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
            FetchMailbox();
			GoogleAnalytics.Current.Tracker.SendView("Inbox Issued Page");
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            inboxVM.InboxMessagesList.Clear();
			NoDataLabel.IsVisible = false;
			MessagesList.IsVisible = false;
		}
	}
}
