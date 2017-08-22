
using System;
using System.Collections.Generic;
using Plugin.GoogleAnalytics;
using UFCW.Services.Models.Inbox;
using UFCW.ViewModels.Inbox;
using Xamarin.Forms;

namespace UFCW.Views.Pages.Inbox
{
    public partial class InboxPage : ContentPage
    {
        InboxViewModel inboxVM;
		public InboxPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
            inboxVM = new InboxViewModel();
			BindingContext = inboxVM;
            //ChecksIssuedList.ItemsSource = inboxVM.messagesList;
		}

		
		public async void FetchMessagesList()
		{
			inboxVM.IsBusy = true;
            Message[] messages = await inboxVM.FetchMessagesList();
			if (messages != null && messages.Length > 0)
			{
				//ChecksIssuedList.IsVisible = true;
				//NoDataLabel.IsVisible = false;
				UpdatePage(messages);
			}
			else
			{
				//NoDataLabel.IsVisible = true;
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

		/// <summary>
		/// Handles the Check Issued tapped event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		//protected async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		//{
			//var selectedCheck = ((ListView)sender).SelectedItem;
			//CheckIssued checkIssued = (CheckIssued)selectedCheck;
			//CheckIssuedDetailPage checksIssuedDetailPage = new CheckIssuedDetailPage();
			//checksIssuedDetailPage.BindingContext = checkIssued;
			//await Navigation.PushAsync(checksIssuedDetailPage);
			//((ListView)sender).SelectedItem = null;
			//GoogleAnalytics.Current.Tracker.SendEvent("ListView", "ItemTapped", AppConstants.CheckedIssued_Event_Messae, 1);
		//}

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
			//NoDataLabel.IsVisible = false;
			//ChecksIssuedList.IsVisible = false;
		}
	}
}
