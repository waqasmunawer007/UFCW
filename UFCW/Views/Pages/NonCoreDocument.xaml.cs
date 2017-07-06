using System;
using System.Collections.Generic;
using Plugin.GoogleAnalytics;
using UFCW.ViewModels.NonCore;
using Xamarin.Forms;

namespace UFCW.Views.Pages
{
    public partial class NonCoreDocument : ContentPage
    {
        NonCoreDocumentsViewModel viewModel;
        public bool ifPublicDocRequest = false;
        public NonCoreDocument()
        {
            InitializeComponent();
            viewModel = new NonCoreDocumentsViewModel();
            BindingContext = viewModel;
            NonCoreDocumentsList.ItemsSource = viewModel.DocumentList;
			NonCoreDocumentsList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
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
            GoogleAnalytics.Current.Tracker.SendView("Document Page");
			if (ifPublicDocRequest)
			{
				viewModel.FetchPublicDocument();
			}
			else
			{
				viewModel.FetchAuthDocument();
			}	
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.IsBusy = false;
            viewModel.DocumentList.Clear();
        }
    }
}
