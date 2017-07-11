using System;
using System.Collections.Generic;
using UFCW.Constants;
using UFCW.Services.Models.ActivePension;
using UFCW.ViewModels.ActivePension;
using Xamarin.Forms;

namespace UFCW.Views.Pages.PensionActive
{
    public partial class DocumentsPage : ContentPage
    {
        DocumentsVM documentsVM;
		public DocumentsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, ""); //hide back button title
			documentsVM = new DocumentsVM();
			BindingContext = documentsVM;
            DocumentsList.ItemsSource = documentsVM.documentsList;
			DocumentsList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				// don't do anything if we just de-selected the row
				if (e.Item == null) return;
				// do something with e.SelectedItem
				((ListView)sender).SelectedItem = null; // de-select the row
			};
		}

		/// <summary>
        /// Fetchs the documents.
        /// </summary>
		public async void FetchDocuments()
		{
			documentsVM.IsBusy = true;
            PlanDocument[] documents = await documentsVM.FetchDocuments();
			if (documents != null && documents.Length > 0)
			{
                DocumentsList.IsVisible = true;
                NoDataLabel.IsVisible = false;
                UpdatePage(documents);
			}
			else
			{
				DocumentsList.IsVisible = false;
				NoDataLabel.IsVisible = true;
			}
			documentsVM.IsBusy = false;
		}

		/// <summary>
        /// Updates the page.
        /// </summary>
        /// <param name="data">Data.</param>
		private void UpdatePage(PlanDocument[] data)
		{
            foreach (PlanDocument document in data)
			{
                documentsVM.documentsList.Add(document);
			}
		}

        public void LinkClicked(object sender, System.EventArgs e)
        {
			string url = ((Button)sender).Text;
			Device.OpenUri(new System.Uri(url));
		}

		protected override void OnAppearing()
		{
			FetchDocuments();
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			documentsVM.documentsList.Clear();
            NoDataLabel.IsVisible = false;
            DocumentsList.IsVisible = false;
		}
	}
}
